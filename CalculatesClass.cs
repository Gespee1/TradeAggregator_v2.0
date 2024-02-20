using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;
using System.Configuration;

namespace TradeAggregator
{
    class CalculatesClass
    {
        private SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aggregator"].ConnectionString);
        public bool isCalculateEnd = false;

        public void CalcOrderParallel()
        {
            Thread t1 = new Thread(CalculateOrders);
            t1.IsBackground = false;
            t1.Start();

            
        }

        // Метод расчета заказов в параллельном потоке
        private void CalculateOrders()
        {
            SqlCommand command;
            SqlDataAdapter adapter;
            DataTable dt = new DataTable();
            Int64 VendorId = 0, ComOfferRecId = 0, ComOfferVendRecId = 0;
            int ComOffVendsCount = 0, qty = 0;

            _connection.Open();
            command = new SqlCommand($"SELECT o.RecId, o.NetworkId, a.VendorID, o.Date, ol.ProductId, a.Price, " +
                $"ol.Qty as 'OrderQTY', a.Qty as 'VendorQTY' FROM Orders o " +
                $"left join OrderLines ol on ol.OrderId = o.RecId " +
                $"join Assortment a on a.ProductID = ol.ProductId " +
                $"where o.Status = 0 order by o.RecId, a.VendorID, ol.ProductId", _connection);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            if (dt.Rows.Count > 0) // Создание нового КП
            {
                command = new SqlCommand($"insert into CommercialOffers values ({dt.Rows[0][0]}, '{dt.Rows[0][3]}', " +
                        $"{dt.Rows[0][1]}, 0, 0, 0, '')", _connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("SELECT SCOPE_IDENTITY()", _connection); // Получение только что добавленного ид
                ComOfferRecId = Convert.ToInt64(command.ExecuteScalar());
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (VendorId != Convert.ToInt64(dt.Rows[i][2])) // Создание нового поставщика в КП
                {
                    VendorId = Convert.ToInt64(dt.Rows[i][2]);
                    command = new SqlCommand($"insert into CommercialOfferVendors values ({ComOfferRecId}, {VendorId}, 0)", _connection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand("SELECT SCOPE_IDENTITY()", _connection); // Получение только что добавленного ид
                    ComOfferVendRecId = Convert.ToInt64(command.ExecuteScalar());

                    ComOffVendsCount++;
                }
                // Заполнение КП
                qty = Convert.ToInt32(dt.Rows[i][6]) < Convert.ToInt32(dt.Rows[i][7]) ? Convert.ToInt32(dt.Rows[i][6]) : Convert.ToInt32(dt.Rows[i][7]);
                command = new SqlCommand($"insert into CommercialOfferLines values ({ComOfferRecId}, {ComOfferVendRecId}, {dt.Rows[i][4]}, " +
                    $"{qty}, 1)", _connection);
                command.ExecuteNonQuery();

                if (ComOffVendsCount == 5)
                    break;
            }
            if (dt.Rows.Count > 0)
            {
                command = new SqlCommand($"update Orders set Status = 1 where RecId = {dt.Rows[0][0]}", _connection);
                command.ExecuteNonQuery();
            }
            /*for (int i = 0; i < 1000000; i++)
            {
                //if (i % 10000 == 0)
                    //Thread.Sleep(1000);
                if (i % 100000 == 0)
                {
                    Console.WriteLine($"Параллельный поток достиг {i}");
                }
            }
            Console.WriteLine($"Параллельный поток завершился");
            */

            Thread.Sleep(10000);

            isCalculateEnd = true;

            //_connection.Close();
        }



    }
}

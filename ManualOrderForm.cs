using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TradeAggregator
{
    public partial class ManualOrderForm : Form
    {
        private SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aggregator"].ConnectionString);
        private Int64 _userID;

        public ManualOrderForm()
        {
            InitializeComponent();
        }
        public ManualOrderForm(Int64 userID)
        {
            _userID = userID;
            InitializeComponent();
        }

        private void ManualOrderForm_Load(object sender, EventArgs e)
        {
            _connection.Open();
        }









        private void ManualOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connection.Close();
        }
    }
}

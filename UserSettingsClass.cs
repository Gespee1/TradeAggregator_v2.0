using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin;

namespace TradeAggregator
{
    class UserSettingsClass
    {
        private SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aggregator"].ConnectionString);
        public MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        // Вывод настроек интерфейса по пользователю
        public void getUiSettings()
        {
            SqlCommand command;
            SqlDataReader reader;

            _connection.Open();
            command = new SqlCommand($"select us.UITheme, us.UIPrimary, us.UIDarkPrimary, us.UILightPrimary, us.UIAccent, us.UIShade " +
                $"from UserSettings us join Users u on us.[User] = u.RecID " +
                $"where u.PCName = '{Environment.UserDomainName}' and u.UserName = '{Environment.UserName}'", _connection);
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                materialSkinManager.Theme = (MaterialSkinManager.Themes)Convert.ToInt32(reader[0]);
                materialSkinManager.ColorScheme = new ColorScheme((Primary)reader[1], (Primary)reader[2], (Primary)reader[3],
                    (Accent)reader[4], (TextShade)reader[5]);
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.BlueGrey900, Primary.BlueGrey500,
                    Accent.Amber700, TextShade.WHITE);
            }
            reader.Close();
            _connection.Close();
        }

        // Сохранение настроек интерфейса по пользователю
        public void setUiSettings(MaterialSkinManager mSkinManager, Int64 userId)
        {
            SqlCommand command;
            SqlDataReader reader;

            _connection.Open();

            command = new SqlCommand($"select us.[User] " +
                $"from UserSettings us join Users u on us.[User] = u.RecID " +
                $"where u.PCName = '{Environment.UserDomainName}' and u.UserName = '{Environment.UserName}'", _connection);
            reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                reader.Close();
                command = new SqlCommand($"update UserSettings set UITheme = {(int)mSkinManager.Theme}, " +
                    $"UIPrimary = {mSkinManager.ColorScheme.PrimaryColor.ToArgb()}, UIDarkPrimary = {mSkinManager.ColorScheme.DarkPrimaryColor.ToArgb()}, " +
                    $"UILightPrimary = {mSkinManager.ColorScheme.LightPrimaryColor.ToArgb()}, UIAccent = {mSkinManager.ColorScheme.AccentColor.ToArgb()}, " +
                    $"UIShade = {mSkinManager.ColorScheme.TextColor.ToArgb()} " +
                    $"where [User] = {userId}"
                    , _connection);
                command.ExecuteNonQuery();
            }
            else
            {
                reader.Close();
                command = new SqlCommand($"insert into UserSettings values ({userId}, null, {(int)mSkinManager.Theme}, " +
                    $"{mSkinManager.ColorScheme.PrimaryColor.ToArgb()}, {mSkinManager.ColorScheme.DarkPrimaryColor.ToArgb()}, " +
                    $"{mSkinManager.ColorScheme.LightPrimaryColor.ToArgb()}, {mSkinManager.ColorScheme.AccentColor.ToArgb()}, " +
                    $"{mSkinManager.ColorScheme.TextColor.ToArgb()}) "
                    , _connection);
                command.ExecuteNonQuery();
            }
            
            _connection.Close();
        }


        // Запрос из БД пути для скачивания файлов по пользователю
        public string getSavePath()
        {
            SqlCommand command;
            SqlDataReader reader;
            string savePath = "";

            _connection.Open();
            command = new SqlCommand($"select Path2Save " +
                $"from UserSettings us join Users u on us.[User] = u.RecID " +
                $"where u.PCName = '{Environment.UserDomainName}' and u.UserName = '{Environment.UserName}'", _connection);
            reader = command.ExecuteReader();
            if (reader.Read())
                savePath = reader[0].ToString();
            
            reader.Close();
            _connection.Close();

            return savePath;
        }


        // Сохранение в БД пути для скачивания файлов по пользователю
        public void setSavePath(string strPath, Int64 userId)
        {
            SqlCommand command;
            SqlDataReader reader;

            _connection.Open();

            command = new SqlCommand($"select us.[User] " +
                $"from UserSettings us join Users u on us.[User] = u.RecID " +
                $"where u.PCName = '{Environment.UserDomainName}' and u.UserName = '{Environment.UserName}'", _connection);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                command = new SqlCommand($"update UserSettings set Path2Save = {strPath} " +
                    $"where [User] = (select top 1 RecId from Users where " +
                    $"PCName = '{Environment.UserDomainName}' and UserName = '{Environment.UserName}')"
                    , _connection);
                command.ExecuteNonQuery();
            }
            else
            {
                reader.Close();
                command = new SqlCommand($"insert into UserSettings values ({userId}, {strPath}, null, null, null, null, null, null) "
                    , _connection);
                command.ExecuteNonQuery();
            }

            _connection.Close();
        }

    }
}

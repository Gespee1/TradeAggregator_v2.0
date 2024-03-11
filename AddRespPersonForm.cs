using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TradeAggregator
{
    public partial class AddRespPersonForm : MaterialForm
    {
        private SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aggregator"].ConnectionString);
        private MainForm _parent;

        public AddRespPersonForm()
        {
            InitializeComponent();
        }
        public AddRespPersonForm(MainForm parent)
        {
            UserSettingsClass us = new UserSettingsClass();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

            InitializeComponent();
            _parent = parent;

            us.getUiSettings();

            materialSkinManager.Theme = us.materialSkinManager.Theme;
            materialSkinManager.ColorScheme = us.materialSkinManager.ColorScheme;
            materialSkinManager.AddFormToManage(this);
        }

        // Создание новой записи
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // Проверка введенных данных
            if(!isValuesValid())
                return;


            _connection.Open();

            SqlCommand command = new SqlCommand($"insert into ResponsiblePersons values ('{textBoxName.Text}', '{maskTextBoxNumber.Text}', " +
                $"'{textBoxEmail.Text}', '{textBoxPost.Text}')", _connection);
            command.ExecuteNonQuery();
            _parent.NewRespPersonName = textBoxName.Text;
            this.DialogResult = DialogResult.OK;

            _connection.Close();
            this.Close();
        }

        private bool isValuesValid()
        {
            string[] FIO_words;
            char[] numletters;

            // Общая проверка
            if (textBoxName.Text == "" || maskTextBoxNumber.Text == "8-   -   -  -" || textBoxEmail.Text == "" || textBoxPost.Text == "")
            {
                MaterialMessageBox.Show("Не все данные введены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning, false,
                    FlexibleMaterialForm.ButtonsPosition.Center);
                return false;
            }

            // Проверка ФИО
            FIO_words = textBoxName.Text.Split(' ');
            if (FIO_words.Length != 3)
            {
                MaterialMessageBox.Show("Введенное вами ФИО должно содержать 3 слова!","Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning, false, 
                    FlexibleMaterialForm.ButtonsPosition.Center);
                return false;
            }

            // Проверка номера
            numletters = maskTextBoxNumber.Text.ToCharArray();
            if (maskTextBoxNumber.Text.Contains(' ') || numletters.Length != 15)
            {
                MaterialMessageBox.Show("Вы не ввели телефонный номер полностью!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning, false,
                    FlexibleMaterialForm.ButtonsPosition.Center);
                return false;
            }

            // Проверка email'a
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(textBoxEmail.Text, pattern))
            {
                MaterialMessageBox.Show("Введенный вами email адрес не подходит под шаблон!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning, false,
                    FlexibleMaterialForm.ButtonsPosition.Center);
                return false;
            }

            return true;
        }

        private void AddRespPersonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

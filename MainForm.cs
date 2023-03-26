﻿using System;
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
    public partial class MainForm : Form
    {
        private SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AggregatorDataBase"].ConnectionString);
        private bool _registrationFlag = false;

        public MainForm()
        {
            InitializeComponent();
        }

        // Загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            _connection.Open();
            if (_connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
                MessageBox.Show("Не удалось подключиться к базе данных.\nПроверьте подключение!","Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CheckState();
            CheckSaveProfile();


            // Создание тестовых поставщиков и торговых сетей для табличных частей
            bool ATTENTION = true;
            if(!ATTENTION)
            {
                DataTable dt1 = new DataTable(), dt2 = new DataTable();
                Console.WriteLine("Начало запросов");
                SqlCommand command = new SqlCommand("SELECT TOP (200) p.RecID FROM[Aggregator].[dbo].[Profiles] p order by p.ForeignID", _connection);
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(dt1);

                command = new SqlCommand("SELECT TOP (200) p.RecID FROM[Aggregator].[dbo].[Profiles] p order by p.ForeignID desc", _connection);
                adapt = new SqlDataAdapter(command);
                adapt.Fill(dt2);
                Console.WriteLine("Запросы выполнены");

                Console.WriteLine("Начало циклов");
                for (int i = 0; i < 200; i++)
                {
                    command = new SqlCommand($"insert into Users values(0, 'Login{i+1}', '{i}n{i+3}f{i+1}', 0, 'PC{i+1}', 'User{i+1}', {dt1.Rows[i][0]})", _connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Прогресс: {Math.Round(Convert.ToDouble((i+1)/4), 2)}");
                }
                for (int i = 0; i < 200; i++)
                {
                    command = new SqlCommand($"insert into Users values(1, 'Login{i+1+200}', '{i}n{i+3}f{i+1}', 0, 'PC{i+1+200}', 'User{i+1+200}', {dt2.Rows[i][0]})", _connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Прогресс: {Math.Round(Convert.ToDouble((i + 1) / 4) + 50, 2)}");
                }
                Console.WriteLine("Циклы завершились!");
            }
        }

        // Изменения интерфейса для разных режимов
        private void CheckState()
        {
            if(_registrationFlag) // Режим регистрации
            {
                labelMain.Text = "Регистрация";
                Size = new Size(390, 320);
                MinimumSize = new Size(390, 320);
                MaximumSize = new Size(390, 320);
                labelType.Visible = true;
                labelPassRepeat.Visible = true;
                comboBoxType.Visible = true;
                textBoxPassRepeat.Visible = true;
                checkBoxSave.Visible = false;
                buttonSwitch.Text = "Отмена";
                buttonApply.Text = "Регистрация";
            }
            else
            {
                labelMain.Text = "Авторизация";
                Size = new Size(390, 260);
                MinimumSize = new Size(390, 260);
                MaximumSize = new Size(390, 260);
                labelType.Visible = false;
                labelPassRepeat.Visible = false;
                comboBoxType.Visible = false;
                textBoxPassRepeat.Visible = false;
                checkBoxSave.Visible = true;
                buttonSwitch.Text = "Регистрация";
                buttonApply.Text = "Войти";
            }
        }

        // Кнопка смены режимов
        private void buttonSwitch_Click(object sender, EventArgs e)
        {
            if (_registrationFlag)
                _registrationFlag = false;
            else
                _registrationFlag = true;
            CheckState();
        }

        // Вход / регистрация
        private void buttonApply_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            SqlDataReader reader;
            Int64 userRecID;
            bool saveFlag;

            if (CheckNullTextBoxes())
                return;

            if(_registrationFlag) // Регистрация
            {
                if (textBoxPass.Text.Trim() != textBoxPassRepeat.Text.Trim())
                {
                    MessageBox.Show("Пароли не совпадают!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                command = new SqlCommand($"select RecID from Users where Login = " +
                    $"'{textBoxLogin.Text.Trim()}'", _connection);
                if(!(command.ExecuteScalar() is null))
                {
                    MessageBox.Show("Такой логин уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                command = new SqlCommand($"insert into Users values ({comboBoxType.SelectedIndex}, " +
                    $"'{textBoxLogin.Text.Trim()}', '{textBoxPass.Text.Trim()}', 0, '{Environment.UserDomainName}', " +
                    $"'{Environment.UserName}', null)", _connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Регистрация успешно завершена.", "Поздравляем");

                //Переключение на режим входа
                _registrationFlag = false;
                CheckState();
            }
            else // Авторизация
            {
                // Поиск логина
                command = new SqlCommand($"select RecID from Users where Login = " +
                    $"'{textBoxLogin.Text.Trim()}'", _connection);
                if(command.ExecuteScalar() is null)
                {
                    MessageBox.Show("Логин не найден!\nПроверьте правильность введенных " +
                        "данных или зарегистрируйтесь.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка пароля + получение ID и SaveFlag
                command = new SqlCommand("select RecID, SaveFlag from Users where Login = " +
                    $"'{textBoxLogin.Text.Trim()}' and Password = '{textBoxPass.Text.Trim()}'", _connection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userRecID = Convert.ToInt64(reader[0]);
                    saveFlag = Convert.ToBoolean(reader[1]);
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Пароль введен не верно!\nПопробуйте снова.",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    reader.Close();
                    return;
                }

                // Вкл или выкл режима запоминания
                if(saveFlag != checkBoxSave.Checked)
                {
                    if(checkBoxSave.Checked) // Вкл
                    {
                        command = new SqlCommand($"update Users set SaveFlag = 1" +
                            $"where PCName = '{Environment.UserDomainName}' and " +
                            $"UserName = '{Environment.UserName}'", _connection);
                        command.ExecuteNonQuery();
                    }
                    else // Выкл
                    {
                        command = new SqlCommand($"update Users set SaveFlag = 0" +
                            $"where PCName = '{Environment.UserDomainName}' and " +
                            $"UserName = '{Environment.UserName}'", _connection);
                        command.ExecuteNonQuery();
                    }
                }

                // Открытие формы личного кабинета
                Form accountForm = new AccountForm(userRecID);
                this.Hide();
                accountForm.ShowDialog();
                this.Close();
            }
        }


        // Проверка полей на заполненность
        private bool CheckNullTextBoxes()
        {

            return false;
        }

        // Поиск сохраненных данных для входа на этом устройстве
        private void CheckSaveProfile()
        {
            bool saveFlag;

            SqlCommand command = new SqlCommand($"select Login, Password, SaveFlag from Users " +
                $"where PCName = '{Environment.UserDomainName}' and " +
                $"UserName = '{Environment.UserName}'", _connection);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                saveFlag = Convert.ToBoolean(reader[2]);
                if(saveFlag)
                {
                    textBoxLogin.Text = reader[0].ToString();
                    textBoxPass.Text = reader[1].ToString();
                    checkBoxSave.Checked = saveFlag;
                }
            }
            reader.Close();
        }

        // Закрытие формы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connection.Close();
        }

        
    }
}

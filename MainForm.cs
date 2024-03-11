using C1.Framework.Drawing.Gdi;
using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using Windows.System;

namespace TradeAggregator
{
    public partial class MainForm : MaterialForm
    {
        private SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aggregator"].ConnectionString);
        private Int64 _userID, _profileId, _extraCommOfferId;
        private bool _typeIndex,
            _tabsReady = false,
            _canChange,
            _changeStatus = false,
            _vendorShownFlag = true,
            _listMode = true;
        private string _userName, _extraCommOfferStatus;
        private MaterialSkinManager _materialSkinManager;
        private CalculatesClass _calculatesClass;
        public string NewRespPersonName;
        private ColorScheme
                _colorBlue = new ColorScheme(Primary.Blue900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Amber700, TextShade.WHITE),
                _colorGreen = new ColorScheme(Primary.Green900, Primary.LightGreen900, Primary.LightGreen500, Accent.Red700, TextShade.WHITE),
                _colorRed = new ColorScheme(Primary.Red900, Primary.Red600, Primary.Red300, Accent.Green700, TextShade.WHITE),
                _colorOrange = new ColorScheme(Primary.Orange900, Primary.DeepOrange900, Primary.DeepOrange500, Accent.Blue700, TextShade.WHITE),
                _colorBrown = new ColorScheme(Primary.Brown900, Primary.Brown600, Primary.Brown300, Accent.Blue700, TextShade.WHITE);

        //
        // ------------------------------------ОБЩИЙ КОД------------------------------------
        //
        // Дефолтный конструктор
        public MainForm()
        {
            InitializeComponent();
        }
        // Конструктор с параметрами
        public MainForm(Int64 userId)
        {
            _userID = userId;
            InitializeComponent();
        }
        // Загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            UserSettingsClass us = new UserSettingsClass();
            _materialSkinManager = MaterialSkinManager.Instance;

            us.getUiSettings();

            _materialSkinManager.Theme = us.materialSkinManager.Theme;
            _materialSkinManager.ColorScheme = us.materialSkinManager.ColorScheme;
            _materialSkinManager.AddFormToManage(this);

            _connection.Open();
            loadData();
        }
        // Загрузка данных о пользователе
        private void loadData()
        {
            SqlCommand command = new SqlCommand($"select Type, Login from Users where RecID = {_userID}", _connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                _typeIndex = Convert.ToBoolean(reader[0]);
                _userName = $"Добро пожаловать, {reader[1]}!";
                this.Text = _userName;
                reader.Close();

                if (_typeIndex) // 0 - поставщик | 1 - торговая сеть
                // Отображение и сокрытие вкладок соответствующего типа пользователя
                {
                    materialTabControlMenu.TabPages.Clear();
                    materialTabControlMenu.TabPages.Add(PageMain);
                    materialTabControlMenu.TabPages.Add(PageProfile);
                    materialTabControlMenu.TabPages.Add(PageVendor);
                    materialTabControlMenu.TabPages.Add(PageAutoOrder);
                    materialTabControlMenu.TabPages.Add(PageManualOrder);
                    materialTabControlMenu.TabPages.Add(PageCommOffers);
                    materialTabControlMenu.TabPages.Add(PageContracts);
                    materialTabControlMenu.TabPages.Add(PageGraphs);
                    materialTabControlMenu.TabPages.Add(PageSettings);
                }
                else
                {
                    materialTabControlMenu.TabPages.Clear();
                    // Андрюх, добавь сюда свои вкладки
                }
                _tabsReady = true;
            }
        }
        // Изменения при смене вкладок
        private void materialTabControlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_tabsReady)
            {
                switch (materialTabControlMenu.SelectedTab.Name)
                {
                    case "PageMain":
                        this.Text = _userName;
                        break;
                    case "PageProfile":
                        this.Text = "Профиль";
                        loadProfileData();
                        setProfileObjEnabled();
                        break;
                    case "PageVendor":
                        this.Text = "Поставщики";

                        gridsApplyStyle(metroGridVendors);
                        loadVendorsData();
                        break;
                    case "PageAutoOrder":
                        this.Text = "Автоматический заказ";
                        treeViewCategory.DrawMode = TreeViewDrawMode.OwnerDrawText;
                        //treeViewCategory.ForeColor = Color.White;
                        categoriesLoad();
                        break;
                    case "PageManualOrder":
                        this.Text = "Ручной заказ";
                        gridsApplyStyle(metroGridManualOrder);

                        break;
                    case "PageCommOffers":
                        this.Text = "Комерческие предложения";
                        loadCommOffersData();
                        break;
                    case "PageContracts":
                        this.Text = "Договоры";
                        loadContractsData();
                        break;
                    case "PageGraphs":
                        this.Text = "Финансовые графики";
                        break;
                    case "PageSettings":
                        this.Text = "Настройки";
                        loadUIData();
                        break;
                }
            }
        }

        // Нажатие кнопки "Назад"
        private void materialButtonBack_Click(object sender, EventArgs e)
        {
            if (!_vendorShownFlag)
            {
                _vendorShownFlag = true;
                materialButtonBack.Visible = false;
                loadVendorsData();
            }
        }
        // Закрытие формы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connection.Close();
        }
        // Начало рассчетов коммерческих предложений
        private void beginCalculateCommOffers()
        {
            TimerCallback tc;
            System.Threading.Timer timer;
            _calculatesClass = new CalculatesClass();
            _calculatesClass.CalcOrderParallel();

            MaterialMessageBox.Show("Ваш заказ принят, ожидайте коммерческих предложений.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Запуск таймера с проверкой конца расчетов
            tc = new TimerCallback(timerCheckCalculateEnd);
            timer = new System.Threading.Timer(tc, 0, 0, 2000);
            
        }
        // Метод проверки конца расчетов комм. предложения
        private void timerCheckCalculateEnd(object obj)
        {
            PopupNotifier popup = new PopupNotifier();

            if (_calculatesClass.isCalculateEnd == true)
            {
                popup.TitleText = "Обработка заказа.";
                popup.ContentText = "Ваш заказ успешно обработан!";
                popup.Popup();
                
            }


        }
        // Стилизация всех таблиц формы
        private void gridsApplyStyle(MetroGrid  metroGrid)
        {

            // Выбор цветовой схемы для таблиц
            if (_materialSkinManager.ColorScheme.PrimaryColor == _colorBlue.PrimaryColor)
            {
                metroGrid.ColumnHeadersDefaultCellStyle.BackColor = _colorBlue.DarkPrimaryColor;
                metroGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = _colorBlue.PrimaryColor;
                metroGrid.RowsDefaultCellStyle.SelectionBackColor= _colorBlue.AccentColor;
            }
            else if (_materialSkinManager.ColorScheme.PrimaryColor == _colorGreen.PrimaryColor)
            {
                metroGrid.ColumnHeadersDefaultCellStyle.BackColor = _colorGreen.DarkPrimaryColor;
                metroGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = _colorGreen.PrimaryColor;
                metroGrid.RowsDefaultCellStyle.SelectionBackColor = _colorGreen.AccentColor;
            }
            else if (_materialSkinManager.ColorScheme.PrimaryColor == _colorRed.PrimaryColor)
            {
                metroGrid.ColumnHeadersDefaultCellStyle.BackColor = _colorRed.DarkPrimaryColor;
                metroGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = _colorRed.PrimaryColor;
                metroGrid.RowsDefaultCellStyle.SelectionBackColor = _colorRed.AccentColor;
            }
            else if (_materialSkinManager.ColorScheme.PrimaryColor == _colorOrange.PrimaryColor)
            {
                metroGrid.ColumnHeadersDefaultCellStyle.BackColor = _colorOrange.DarkPrimaryColor;
                metroGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = _colorOrange.PrimaryColor;
                metroGrid.RowsDefaultCellStyle.SelectionBackColor = _colorOrange.AccentColor;
            }
            else if (_materialSkinManager.ColorScheme.PrimaryColor == _colorBrown.PrimaryColor)
            {
                metroGrid.ColumnHeadersDefaultCellStyle.BackColor = _colorBrown.DarkPrimaryColor;
                metroGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = _colorBrown.PrimaryColor;
                metroGrid.RowsDefaultCellStyle.SelectionBackColor = _colorBrown.AccentColor;
            }


            if (_materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT)
            {
                metroGrid.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
                metroGrid.RowsDefaultCellStyle.ForeColor = Color.Black;
                metroGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(180, 180, 180);
            }
            else
            {
                metroGrid.RowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                metroGrid.RowsDefaultCellStyle.ForeColor = Color.White;
                metroGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(80, 80, 80);
            }
        }




        //
        // ------------------------------------ВКЛАДКА "ГЛАВНАЯ"------------------------------------
        //



        //
        // ------------------------------------ВКЛАДКА "ПРОФИЛЬ"------------------------------------
        //
        // Загрузка данных формы профиля
        private void loadProfileData()
        {
            int newProfileRecId;
            SqlCommand command;
            SqlDataReader reader;
            string innKpp;

            loadRespPersons();

            command = new SqlCommand($"select ProfileId from Users where RecID = {_userID}", _connection);
            _profileId = Convert.ToInt64(command.ExecuteScalar());

            if (_profileId != 0)
            {
                command = new SqlCommand($"select rp.Name, p.[Name], p.[UrasticName], p.[INN_KPP], p.[DirectorName], p.[UrasticAddress], p.[Account]" +
                    $", p.[BankName], p.[BankBik], p.[CorrAccount] from Profiles p " +
                    $"left join ResponsiblePersons rp on p.RespPerson = rp.RecID " +
                    $"where p.RecID = {_profileId}", _connection);
                reader = command.ExecuteReader();
                reader.Read();
                textBoxCode.Text = _profileId.ToString();
                comboBoxRespPerson.SelectedItem = reader[0].ToString();
                textBoxName.Text = reader[1].ToString();
                textBoxUrName.Text = reader[2].ToString();
                innKpp = reader[3].ToString();
                if (innKpp.Contains("/"))
                {
                    textBoxINN.Text = innKpp.Split('/')[0];
                    textBoxKPP.Text = innKpp.Split('/')[1];
                }
                textBoxDirector.Text = reader[4].ToString();
                textBoxUrAddress.Text = reader[5].ToString();
                textBoxBankAccount.Text = reader[6].ToString();
                textBoxBankName.Text = reader[7].ToString();
                textBoxBankBIK.Text = reader[8].ToString();
                textBoxCorrAccount.Text = reader[9].ToString();
                reader.Close();
            }
            else
            {
                command = new SqlCommand($"insert into Profiles values (0, '', '', '', '', '', '', '', '', '', '')", _connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("SELECT SCOPE_IDENTITY()", _connection); // Получение только что добавленного ид
                newProfileRecId = Convert.ToInt32(command.ExecuteScalar());
                command = new SqlCommand($"update Users set ProfileId = {newProfileRecId} where RecID = {_userID}", _connection);
                command.ExecuteNonQuery();
                _profileId = newProfileRecId;
            }
        }
        // Загрузка списка ответственных лиц
        private void loadRespPersons()
        {
            SqlCommand command = new SqlCommand($"select Name from ResponsiblePersons", _connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                comboBoxRespPerson.Items.Add(reader[0].ToString());
            reader.Close();
        }
        // Включение\выключение взаимодействия с объектами на форме
        private void setProfileObjEnabled()
        {
            if (!_changeStatus)
            {
                comboBoxRespPerson.Enabled = false;
                textBoxName.Enabled = false;
                textBoxUrName.Enabled = false;
                textBoxINN.Enabled = false;
                textBoxKPP.Enabled = false;
                textBoxDirector.Enabled = false;
                textBoxUrAddress.Enabled = false;
                textBoxBankAccount.Enabled = false;
                textBoxBankName.Enabled = false;
                textBoxBankBIK.Enabled = false;
                textBoxCorrAccount.Enabled = false;
                buttonAddRespPerson.Enabled = false;
            }
            else
            {
                comboBoxRespPerson.Enabled = true;
                textBoxName.Enabled = true;
                textBoxUrName.Enabled = true;
                textBoxINN.Enabled = true;
                textBoxKPP.Enabled = true;
                textBoxDirector.Enabled = true;
                textBoxUrAddress.Enabled = true;
                textBoxBankAccount.Enabled = true;
                textBoxBankName.Enabled = true;
                textBoxBankBIK.Enabled = true;
                textBoxCorrAccount.Enabled = true;
                buttonAddRespPerson.Enabled = true;
            }
        }
        // Кнопка переключения режима редактирования и сохранения
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (_changeStatus)
                _changeStatus = false;
            else
                _changeStatus = true;
            setProfileObjEnabled();
        }
        // Открытие формы создания отв. лица
        private void buttonAddRespPerson_Click(object sender, EventArgs e)
        {
            MaterialForm addRP = new AddRespPersonForm(this);
            DialogResult dr = addRP.ShowDialog();
            if (dr == DialogResult.OK)
            {
                loadRespPersons();
                comboBoxRespPerson.SelectedItem = NewRespPersonName;
            }
        }
        //
        // Запись в БД измененных данных
        //
        // Ответственное лицо
        private void comboBoxRespPerson_Leave(object sender, EventArgs e)
        {
            updateProfileInfo($"RespPerson = (select RecID from ResponsiblePersons where Name = '{comboBoxRespPerson.SelectedItem}')");
        }
        // Наименоваине
        private void textBoxName_Leave(object sender, EventArgs e)
        {
            updateProfileInfo($"Name = '{textBoxName.Text}'");
        }
        // Юр. наименоваине
        private void textBoxUrName_Leave(object sender, EventArgs e)
        {
            updateProfileInfo($"UrasticName = '{textBoxUrName.Text}'");
        }
        // ИНН/КПП
        private void textBoxINN_Leave(object sender, EventArgs e)
        {
            updateProfileInfo($"INN_KPP = '{textBoxINN.Text + '/' + textBoxKPP.Text}'");
        }
        // ИНН/КПП
        private void textBoxKPP_Leave(object sender, EventArgs e)
        {
            updateProfileInfo($"INN_KPP = '{textBoxINN.Text + '/' + textBoxKPP.Text}'");
        }
        // ФИО директора
        private void textBoxDirector_Leave(object sender, EventArgs e)
        {
            updateProfileInfo($"DirectorName = '{textBoxDirector.Text}'");
        }
        // Юр. адрес
        private void textBoxUrAddress_Leave(object sender, EventArgs e)
        {
            updateProfileInfo($"UrasticAddress = '{textBoxUrAddress.Text}'");
        }
        // Наим. банка
        private void textBoxBankName_Leave(object sender, EventArgs e)
        {
            updateProfileInfo($"BankName = '{textBoxBankName.Text}'");
        }
        // БИК
        private void textBoxBankBIK_Leave(object sender, EventArgs e)
        {
            updateProfileInfo($"BankBik = '{textBoxBankBIK.Text}'");
        }
        // Банковский счет
        private void textBoxBankAccount_Leave(object sender, EventArgs e)
        {
            updateProfileInfo($"Account = '{textBoxBankAccount.Text}'");
        }
        // Корр. счет
        private void textBoxCorrAccount_Leave(object sender, EventArgs e)
        {
            updateProfileInfo($"CorrAccount = '{textBoxCorrAccount.Text}'");
        }
        // Общий метод обновления
        private void updateProfileInfo(string queryStr)
        {
            SqlCommand command = new SqlCommand($"update Profiles set {queryStr} where RecID = {_profileId}", _connection);
            command.ExecuteNonQuery();
        }


        //
        // ------------------------------------ВКЛАДКА "ПОСТАВЩИКИ"------------------------------------
        //
        // Загрузка списка поставщиков\ассортимента поставщиков
        private void loadVendorsData(Int64 vendId = 0, string vendName = "")
        {
            SqlCommand command;
            SqlDataAdapter adapt;
            DataTable dt;

            if(_vendorShownFlag)
            {
                this.Text = "Поставщики";
                command = new SqlCommand($"SELECT p.[RecID] as 'Номер поставщика'" +
                    $", p.[Name] as 'Наименование'" +
                    $", p.[UrasticName] as 'Юр. наименование'" +
                    $", p.[INN_KPP] as 'ИНН\\КПП'" +
                    $", p.[DirectorName] as 'Директор'" +
                    $", p.[UrasticAddress] as 'Юр. адрес'" +
                    $", p.[Account] as 'Банковский счет'" +
                    $", p.[BankName] as 'Наименование банка'" +
                    $", p.[BankBik] as 'БИК банка'" +
                    $", p.[CorrAccount] as 'Корр. счет'" +
                    $",case when(rp.[Name] is null) then '-' " +
                    $"else rp.[Name] end as 'Ответств. лицо' " +
                    $"FROM[Aggregator].[dbo].[Users] u " +
                    $"join[Aggregator].[dbo].[Profiles] p on p.RecID = u.ProfileId " +
                    $"left join[Aggregator].[dbo].[ResponsiblePersons] rp on rp.RecID = p.RespPerson " +
                    $"where u.Type = 0", _connection);
            }
            else
            {
                this.Text = $"Ассортимент поставщика {vendName}";
                command = new SqlCommand($"SELECT p.[ProductID] as 'Код продукта'" +
                    $", p.[Name] as 'Название'" +
                    $", case when(c.[L4] is null) then '-' " +
                    $"else c.[L4] end as 'Код группы товаров'" +
                    $", case when(c.[L4_name] is null) then '-' " +
                    $"else c.[L4_name] end as 'Наименование группы товаров'" +
                    $", case when(bp.[Brand] is null) then '-' " +
                    $"else bp.[Brand] end as 'Торговая марка'" +
                    $",case when(bp.[Producer] is null) then '-' " +
                    $"else bp.[Producer] end as 'Производитель'" +
                    $",a.[Price] as 'Цена, руб.'" +
                    $",a.[Qty] as 'Количество, шт/кг/л' " +
                    $"FROM[Aggregator].[dbo].[Assortment] a " +
                    $"left join[Aggregator].[dbo].[Products] p on p.ProductID = a.ProductID " +
                    $"left join[Aggregator].[dbo].[Classifier] c on c.ForeignID = p.ClassifierID " +
                    $"left join[Aggregator].[dbo].[BrandProducer] bp on bp.ForeignID = p.BrandProdID " +
                    $"where a.VendorID = {vendId}", _connection);
            }
            
            dt = new DataTable();
            adapt = new SqlDataAdapter(command);

            adapt.Fill(dt);
            metroGridVendors.Columns.Clear();
            metroGridVendors.DataSource = dt;
            metroGridVendors.ReadOnly = true;
            for (int i = 0; i < metroGridVendors.ColumnCount; i++)
                metroGridVendors.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        // Двойной клик по гриде со списком поставщиков
        private void metroGridVendors_DoubleClick(object sender, EventArgs e)
        {
            if(_vendorShownFlag)
            {
                _vendorShownFlag = false;
                loadVendorsData(Convert.ToInt64(metroGridVendors.Rows[metroGridVendors.CurrentRow.Index].Cells["Номер поставщика"].Value),
                    metroGridVendors.Rows[metroGridVendors.CurrentRow.Index].Cells["Юр. наименование"].Value.ToString());
                materialButtonBack.Visible = true;
            }
        }



        //
        // ------------------------------------ВКЛАДКА "АВТО-ЗАКАЗ"------------------------------------
        //
        // Загрузка категорий
        private void categoriesLoad()
        {
            SqlCommand command = new SqlCommand("SELECT L1, L1_name, L2, L2_name, L3, L3_name, L4, L4_name " +
                "FROM Classifier ORDER BY L4", _connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            int L1, L2, L3;
            L1 = L2 = L3 = -1;
            string prevNode1, prevNode2, prevNode3;
            prevNode1 = prevNode2 = prevNode3 = "";

            treeViewCategory.BeginUpdate();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() != prevNode1)
                {
                    prevNode1 = dt.Rows[i][0].ToString();
                    treeViewCategory.Nodes.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                    L1++;
                    L2 = -1;
                    L3 = -1;
                }
                if (dt.Rows[i][2].ToString() != prevNode2)
                {
                    prevNode2 = dt.Rows[i][2].ToString();
                    treeViewCategory.Nodes[L1].Nodes.Add(dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString());
                    L2++;
                    L3 = -1;
                }
                if (dt.Rows[i][4].ToString() != prevNode3)
                {
                    prevNode3 = dt.Rows[i][4].ToString();
                    treeViewCategory.Nodes[L1].Nodes[L2].Nodes.Add(dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString());
                    L3++;
                }
                treeViewCategory.Nodes[L1].Nodes[L2].Nodes[L3].Nodes.Add(dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString());
            }
            treeViewCategory.EndUpdate();

        }
        private void treeViewCategory_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            System.Drawing.SolidBrush greenBrush = new System.Drawing.SolidBrush(Color.Orange);
            if (e.Node.IsSelected)
            {
                if (treeViewCategory.Focused)
                    e.Graphics.FillRectangle(greenBrush, e.Bounds);
            }
            else
                e.Graphics.FillRectangle(System.Drawing.Brushes.Transparent, e.Bounds);

            TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.TreeView.Font, e.Node.Bounds, e.Node.ForeColor);
        }
        // Двойной клик по дереву категорий
        private void treeViewCategory_DoubleClick(object sender, EventArgs e)
        {
            addProductsFromCategory();
        }
        // Кнопка "Отобразить товары" над деревом категорий
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addProductsFromCategory();
        }
        private void addProductsFromCategory()
        {
            DataTable dt = new DataTable();
            SqlCommand command;
            SqlDataAdapter adapt;

            // Проверка, что выбрана категория последнего уровня
            if (treeViewCategory.SelectedNode.Level != 3)
            {
                MaterialMessageBox.Show("Пожалуйста, выберите категорию самого последнего уровня детализации.\n\n" +
                    "Это необходимо для того, чтобы избежать огромного количества оторажаемых товаров.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Удаление не отмеченных галочкой товаров
            deleteUnselectedRows();

            // Поиск товаров по выбранной категории
            command = new SqlCommand($"select p.ProductID, p.Name " +
                $"from Classifier c " +
                $"join Products p on p.ClassifierID = c.ForeignID " +
                $"where c.L1 = '{treeViewCategory.SelectedNode.Name}' or " +
                $"c.L2 = '{treeViewCategory.SelectedNode.Name}' or " +
                $"c.L3 = '{treeViewCategory.SelectedNode.Name}' or " +
                $"c.L4 = '{treeViewCategory.SelectedNode.Name}'", _connection);
            adapt = new SqlDataAdapter(command);
            adapt.Fill(dt);
            // Добавление товаров из новой категории
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!isItAlreadyInserted(dt.Rows[i][0].ToString()))
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["ProductCode"].Value = dt.Rows[i][0];
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Product"].Value = dt.Rows[i][1];
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Qty"].Value = 1;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["AddFlag"].Value = false;
                }
            }
            //Console.WriteLine($"Tag: {treeViewCategory.SelectedNode.Name}, Text: {treeViewCategory.SelectedNode.Text}"); // Код категории + Наименование категории
        }
        // Проверка, не добавлен ли уже такой товар
        private bool isItAlreadyInserted(string productID)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells["ProductCode"].Value.ToString() == productID)
                    return true;
            }
            return false;
        }
        // Удаление товаров
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }
        // Удаление невыбранных галочкой товаров
        private void убратьНевыбранныеТоварыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            deleteUnselectedRows();
        }
        // Метод удаления невыбранных галочкой товаров
        private void deleteUnselectedRows()
        {
            for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["AddFlag"].Value) != true)
                    dataGridView1.Rows.RemoveAt(i);
        }
        // Изменение значения ячеек гриды
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Проверка правильности ввода кол-ва
            if (e.ColumnIndex == 2 && Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value) < 0)
            {
                MessageBox.Show("Количество товара в заказе не может быть меньше 0!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value = 1;
            }

            // Автопроставление галочки, если изменилось кол-во
            if (e.ColumnIndex == 2 && Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value) != 1)
                dataGridView1.Rows[e.RowIndex].Cells["AddFlag"].Value = true;
        }
        // Создание заказа
        private void materialButtonAddAutoOrder_Click(object sender, EventArgs e)
        {
            Int64 orderRecId;

            dataGridView1.EndEdit();
            deleteUnselectedRows();

            SqlCommand command = new SqlCommand($"insert into Orders values " +
                $"({_userID}, '{DateTime.Now.ToShortDateString()}', 0)", _connection);
            command.ExecuteNonQuery();
            command = new SqlCommand("SELECT SCOPE_IDENTITY()", _connection); // Получение только что добавленного ид
            orderRecId = Convert.ToInt64(command.ExecuteScalar());
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                command = new SqlCommand($"insert into OrderLines values ({orderRecId}, {dataGridView1.Rows[i].Cells["ProductCode"].Value}, " +
                    $"{dataGridView1.Rows[i].Cells["Qty"].Value})", _connection);
                command.ExecuteNonQuery();
            }

            this.beginCalculateCommOffers();
        }

       


        //
        // ------------------------------------ВКЛАДКА "РУЧНОЙ ЗАКАЗ"------------------------------------
        //
        // Кнопка поиска товаров по фильтрам
        private void materialButtonManualOrderSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            SqlDataAdapter adapt;
            DataTable dt;
            DataGridViewCheckBoxColumn flagCol, saleCol;
            DataGridViewTextBoxColumn priceCol, deliveryCol;

            command = new SqlCommand($"SELECT TOP (1000) " +
                $"[ProductID] as 'Код продукта',[Name] as 'Наименование товара'," +
                $"c.L4_name as 'Категория',b.Producer as 'Производитель',b.Brand as 'Торговая марка' " +
                $"FROM [Aggregator].[dbo].[Products] p  join [Aggregator].[dbo].[Classifier] c on c.ForeignID = p.ClassifierID  " +
                $"join [Aggregator].[dbo].[BrandProducer] b on b.ForeignID = p.BrandProdID " +
                $"where p.[Name] like N'%{materialTextBoxProductNameFilter.Text}%'", _connection);
            dt = new DataTable();
            adapt = new SqlDataAdapter(command);

            adapt.Fill(0, 100, dt);
            metroGridManualOrder.Columns.Clear();
            metroGridManualOrder.DataSource = dt;
            for(int i = 0; i < metroGridManualOrder.Columns.Count; i++)
                metroGridManualOrder.Columns[i].ReadOnly = true;

            flagCol = new DataGridViewCheckBoxColumn();
            flagCol.Name = "addFlag";
            flagCol.HeaderText = "Добавить";

            ////// временный хардкод
            saleCol = new DataGridViewCheckBoxColumn();
            saleCol.Name = "sale";
            saleCol.HeaderText = "Распродажа";

            priceCol = new DataGridViewTextBoxColumn();
            priceCol.Name = "price";
            priceCol.HeaderText = "Стоимость, руб.";

            deliveryCol = new DataGridViewTextBoxColumn();
            deliveryCol.Name = "delivery";
            deliveryCol.HeaderText = "Доставка, км";


            metroGridManualOrder.Columns.Add(priceCol);
            metroGridManualOrder.Columns["price"].ReadOnly = false;
            metroGridManualOrder.Columns.Add(saleCol);
            metroGridManualOrder.Columns["sale"].ReadOnly = false;
            metroGridManualOrder.Columns.Add(deliveryCol);
            metroGridManualOrder.Columns["delivery"].ReadOnly = false;
            metroGridManualOrder.Columns.Add(flagCol);
            metroGridManualOrder.Columns["addFlag"].ReadOnly = false;

        }
        // Кнопка создания заказа
        private void materialButtonAddManualOrder_Click(object sender, EventArgs e)
        {
            PopupNotifier popup = new PopupNotifier();

            popup.TitleText = "Обработка заказа.";
            popup.ContentText = "Ваш заказ успешно обработан!";
            popup.Popup();

            this.beginCalculateCommOffers();
        }



        //
        // ------------------------------------ВКЛАДКА "ПРЕДЛОЖЕНИЯ"------------------------------------
        //
        // Загрузка основных данных формы
        private void loadCommOffersData()
        {
            DataTable dt = new DataTable();

            // Преднастройка грид
            if (_listMode) // Форма списка
            {
                buttonReturn.Visible = false;
                buttonApply.Visible = false;
                splitContainer1.Panel2MinSize = 0;
                splitContainer1.Panel2.Enabled = false;
                splitContainer1.SplitterDistance = splitContainer1.Size.Width;
                splitContainer1.IsSplitterFixed = true;
            }
            else
            {
                buttonReturn.Visible = true;
                buttonApply.Visible = true;
                splitContainer1.IsSplitterFixed = false;
                splitContainer1.SplitterDistance = Convert.ToInt32(splitContainer1.Size.Width / 2);
                splitContainer1.Panel2MinSize = 25;
                splitContainer1.Panel2.Enabled = true;
            }


            if (_listMode) // Форма списка
            {
                SqlCommand command = new SqlCommand($"select co.RecId as 'Номер КП', " +
                    $"co.OrderId as 'Номер заказа', co.Date as 'Дата', net.UrasticName as 'Торговая компания', " +
                    $"case when co.Status = 0 then 'Создано' " +
                    $"when co.Status = 1 then 'Утверджено ТК' " +
                    $"when co.Status = 2 then 'Утверджено' " +
                    $"when co.Status = -1 then 'Отклонено поставщиком' " +
                    $"end as 'Статус', co.NetworkReadFlag " +
                    $"from CommercialOffers co " +
                    $"left join Users u on u.RecID = {_userID}" +
                    $"left join Profiles net on net.RecID = u.ProfileId", _connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);

                dataGridViewVendors.Columns.Clear();
                dataGridViewVendors.DataSource = dt;
                dataGridViewVendors.Columns["NetworkReadFlag"].Visible = false;

                for (int i = 0; i < dataGridViewVendors.ColumnCount; i++)
                    dataGridViewVendors.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                for (int i = 0; i < dataGridViewVendors.RowCount; i++)
                {
                    if (Convert.ToBoolean(dataGridViewVendors.Rows[i].Cells["NetworkReadFlag"].Value) == false)
                        dataGridViewVendors.Rows[i].DefaultCellStyle.Font = new System.Drawing.Font(dataGridViewVendors.Font, FontStyle.Bold);
                }
            }
            else // Документная форма
            {
                SqlCommand command;
                SqlDataReader reader;

                checkStatus();

                command = new SqlCommand($"select cov.RecId, p.Name, cov.Selected " +
                        $"from CommercialOfferVendors cov " +
                        $"left join Profiles p on p.RecID = cov.VendorId " +
                        $"where cov.CommercialOfferId = {_extraCommOfferId}", _connection);
                dataGridViewVendors.DataSource = null;
                dataGridViewVendors.Columns.Clear();
                dataGridViewVendors.Columns.Add(new DataGridViewTextBoxColumn() { Name = "VendCode", HeaderText = "Код поставщика" });
                dataGridViewVendors.Columns.Add(new DataGridViewTextBoxColumn() { Name = "VendName", HeaderText = "Поставщик" });
                dataGridViewVendors.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Select", HeaderText = "Выбор" });
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridViewVendors.Rows.Add();
                    dataGridViewVendors.Rows[dataGridViewVendors.RowCount - 1].Cells[0].Value = reader[0].ToString();
                    dataGridViewVendors.Rows[dataGridViewVendors.RowCount - 1].Cells[1].Value = reader[1].ToString();
                    dataGridViewVendors.Rows[dataGridViewVendors.RowCount - 1].Cells[2].Value = Convert.ToBoolean(reader[2]);
                }
                reader.Close();

                command = new SqlCommand($"select col.ProductId, p.Name, col.Qty, a.Price, col.Selected " +
                    $"from CommercialOfferLines col " +
                    $"left join Products p on p.ProductID = col.ProductId " +
                    $"left join CommercialOfferVendors cov on cov.RecId = col.ComOffVendorId " +
                    $"left join Assortment a on a.VendorID = cov.VendorId and a.ProductID = col.ProductId " +
                    $"where col.CommercialOfferId = {_extraCommOfferId} and col.ComOffVendorId = {dataGridViewVendors.Rows[0].Cells[0].Value}", _connection);
                dataGridViewProducts.DataSource = null;
                dataGridViewProducts.Columns.Clear();
                dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ProductCode", HeaderText = "Код продукта" });
                dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ProductName", HeaderText = "Продукт" });
                dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Qty", HeaderText = "Количество, шт/кг/л" });
                dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Price", HeaderText = "Стоимость, руб." });
                dataGridViewProducts.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Select", HeaderText = "Выбор" });
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridViewProducts.Rows.Add();
                    dataGridViewProducts.Rows[dataGridViewProducts.RowCount - 1].Cells[0].Value = reader[0].ToString();
                    dataGridViewProducts.Rows[dataGridViewProducts.RowCount - 1].Cells[1].Value = reader[1].ToString();
                    dataGridViewProducts.Rows[dataGridViewProducts.RowCount - 1].Cells[2].Value = reader[2].ToString();
                    dataGridViewProducts.Rows[dataGridViewProducts.RowCount - 1].Cells[3].Value = reader[3].ToString();
                    dataGridViewProducts.Rows[dataGridViewProducts.RowCount - 1].Cells[4].Value = Convert.ToBoolean(reader[4]);
                }
                reader.Close();

                // Запрет сортировки
                for (int i = 0; i < dataGridViewVendors.ColumnCount; i++)
                    dataGridViewVendors.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                for (int i = 0; i < dataGridViewProducts.ColumnCount; i++)
                    dataGridViewProducts.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        // Настройка документной формы в зависимости от статуса
        private void checkStatus()
        {
            switch (_extraCommOfferStatus)
            {
                case "Утверджено ТК":
                    buttonApply.Enabled = false;
                    break;
                case "Утверджено":
                    buttonApply.Enabled = false;
                    break;
            }
        }
        // Одиночный клик по гриде поставщиков
        private void dataGridViewVendors_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!_listMode)
            {
                SqlCommand command = new SqlCommand($"select col.ProductId, p.Name, col.Qty, a.Price, col.Selected " +
                        $"from CommercialOfferLines col " +
                        $"left join Products p on p.ProductID = col.ProductId " +
                        $"left join CommercialOfferVendors cov on cov.RecId = col.ComOffVendorId " +
                        $"left join Assortment a on a.VendorID = cov.VendorId and a.ProductID = col.ProductId " +
                        $"where col.CommercialOfferId = {_extraCommOfferId} and col.ComOffVendorId = " +
                        $"{dataGridViewVendors.Rows[dataGridViewVendors.CurrentRow.Index].Cells[0].Value}", _connection);
                dataGridViewProducts.Rows.Clear();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridViewProducts.Rows.Add();
                    dataGridViewProducts.Rows[dataGridViewProducts.RowCount - 1].Cells[0].Value = reader[0].ToString();
                    dataGridViewProducts.Rows[dataGridViewProducts.RowCount - 1].Cells[1].Value = reader[1].ToString();
                    dataGridViewProducts.Rows[dataGridViewProducts.RowCount - 1].Cells[2].Value = reader[2].ToString();
                    dataGridViewProducts.Rows[dataGridViewProducts.RowCount - 1].Cells[3].Value = reader[3].ToString();
                    dataGridViewProducts.Rows[dataGridViewProducts.RowCount - 1].Cells[4].Value = Convert.ToBoolean(reader[4]);
                }
                reader.Close();
            }
        }
        // Двойной клик по гриде
        private void dataGridViewVendors_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_listMode)
                openCommOff();
        }


        // Открытие КП
        private void openCommOff()
        {
            SqlCommand command;

            _listMode = false;
            _extraCommOfferId = Convert.ToInt64(dataGridViewVendors.Rows[dataGridViewVendors.CurrentRow.Index].Cells["Номер КП"].Value);
            _extraCommOfferStatus = dataGridViewVendors.Rows[dataGridViewVendors.CurrentRow.Index].Cells["Статус"].Value.ToString();

            if (_listMode) // Форма списка
            {
                // Выставление флага прочитанности
                if (Convert.ToBoolean(dataGridViewVendors.Rows[dataGridViewVendors.CurrentRow.Index].Cells["NetworkReadFlag"].Value) == false)
                {
                    command = new SqlCommand($"update CommercialOffers set NetworkReadFlag = 1 where RecId = {_extraCommOfferId}", _connection);
                    command.ExecuteNonQuery();
                }

            }

            loadCommOffersData();
        }
        // Возврат к списку КП
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            _listMode = true;
            loadCommOffersData();
        }
        // Кнопка утверждения КП
        private void buttonApply_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            SqlCommand command;

            dialog = MessageBox.Show("Вы уверены, что хотите утвердить коммерческое предложение?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridViewVendors.RowCount; i++)
                {
                    if (Convert.ToBoolean(dataGridViewVendors.Rows[i].Cells["Select"].Value) == true)
                    {
                        command = new SqlCommand($"update CommercialOfferVendors set Selected = 1 where CommercialOfferId = {_extraCommOfferId} and " +
                            $"VendorId = {dataGridViewVendors.Rows[i].Cells["VendCode"].Value}", _connection);
                        command.ExecuteNonQuery();
                    }
                }
                command = new SqlCommand($"update CommercialOffers set Status = 1 where RecId = {_extraCommOfferId}", _connection);
                command.ExecuteNonQuery();
                
                _listMode = true;
                loadCommOffersData();
            }
        }




        //
        // ------------------------------------ВКЛАДКА "ДОГОВОРЫ"------------------------------------
        //
        // Загрузка списка Договоров
        private void loadContractsData()
        {
            SqlCommand command;
            SqlDataAdapter adapt;
            DataTable dt;

            command = new SqlCommand($"SELECT  Contracts.RecId As 'Код договора', " +
                $"Contracts.CommercialOfferId As 'Код коммерческого предложения', " +
                $"Contracts.Date As 'Дата', case when Contracts.Status = 0 then 'Создан' " +
                $"when Contracts.Status = 1 then 'Действует' " +
                $"when Contracts.Status = 2 then 'Закрыт' end AS 'Статус' " +
                $"FROM  CommercialOffers, Contracts WHERE Contracts.CommercialOfferId = CommercialOffers.RecId AND " +
                $"NetworkId = '{_userID}'", _connection);

            dt = new DataTable();
            adapt = new SqlDataAdapter(command);

            adapt.Fill(dt);
            metroGridContracts.Columns.Clear();
            metroGridContracts.DataSource = dt;
            metroGridContracts.ReadOnly = true;
            for (int i = 0; i < metroGridContracts.ColumnCount; i++)
                metroGridContracts.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }





        //
        // ------------------------------------ВКЛАДКА "НАСТРОЙКИ"------------------------------------
        //
        // Отображение данных UI на форме
        private void loadUIData()
        {
            UserSettingsClass us = new UserSettingsClass();

            // Выбор на форме текущей цветовой темы
            if (_materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT)
            {
                materialSwitchTheme.Text = "Светлая тема";
                materialSwitchTheme.Checked = true;
            }
            else
            {
                materialSwitchTheme.Text = "Тёмная тема";
                materialSwitchTheme.Checked = false;
            }

            // Загрузка сохраненного пути для пользователя
            materialTextBoxSaveFolder.Text = us.getSavePath();

            // Выбор действующей цветовой схемы в комбобоксе
            if (_materialSkinManager.ColorScheme.PrimaryColor == _colorBlue.PrimaryColor)
                materialComboBoxColorScheme.SelectedIndex = 0;
            else if (_materialSkinManager.ColorScheme.PrimaryColor == _colorGreen.PrimaryColor)
                materialComboBoxColorScheme.SelectedIndex = 1;
            else if (_materialSkinManager.ColorScheme.PrimaryColor == _colorRed.PrimaryColor)
                materialComboBoxColorScheme.SelectedIndex = 2;
            else if (_materialSkinManager.ColorScheme.PrimaryColor == _colorOrange.PrimaryColor)
                materialComboBoxColorScheme.SelectedIndex = 3;
            else if (_materialSkinManager.ColorScheme.PrimaryColor == _colorBrown.PrimaryColor)
                materialComboBoxColorScheme.SelectedIndex = 4;
        }
        // Переключение темы
        private void materialSwitchTheme_CheckedChanged(object sender, EventArgs e)
        {
            UserSettingsClass us = new UserSettingsClass();

            if(materialSwitchTheme.Checked)
            {
                materialSwitchTheme.Text = "Светлая тема";
                _materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                us.setUiSettings(_materialSkinManager, _userID);
            }
            else
            {
                materialSwitchTheme.Text = "Тёмная тема";
                _materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                us.setUiSettings(_materialSkinManager, _userID);
            }
        }
        // Изменение цветовой схемы
        private void materialComboBoxColorScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserSettingsClass us = new UserSettingsClass();

            switch (materialComboBoxColorScheme.SelectedIndex)
            {
                case 0:
                    _materialSkinManager.ColorScheme = _colorBlue;
                    break;
                case 1:
                    _materialSkinManager.ColorScheme = _colorGreen;
                    break;
                case 2:
                    _materialSkinManager.ColorScheme = _colorRed;
                    break;
                case 3:
                    _materialSkinManager.ColorScheme = _colorOrange;
                    break;
                case 4:
                    _materialSkinManager.ColorScheme = _colorBrown;
                    break;
            }
            us.setUiSettings(_materialSkinManager, _userID);
            this.Refresh();
        }
        
        // Выбор пути сохранения файлов
        private void materialFloatingActionButtonSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            UserSettingsClass us = new UserSettingsClass();

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                materialTextBoxSaveFolder.Text = FBD.SelectedPath;

                us.setSavePath(materialTextBoxSaveFolder.Text, _userID);
            }
        }

        // Кнопка "О программе"
        private void materialButtonAbout_Click(object sender, EventArgs e)
        {
            MaterialMessageBox.Show("Данная информационная система выполнена студентом кафедры АСУ ТУСУР г. Томск Белотеловым Денисом Андреевичем.\n\n" +
                "Информационная система была разработана в рамках нескольких практик в компани ООО \"УК\"ЛАМА\" в 2023-2024 гг.\n\n" +
                "Руководители от университета: Миньков С.Л. и Мицель А.А.\n\n" +
                "Руководитель от компании: Молдован Н.А.\n\n" +
                "2024 год", "О программе", 
                MessageBoxButtons.OK, MessageBoxIcon.Information, true, FlexibleMaterialForm.ButtonsPosition.Center);
        }

        
    }
}

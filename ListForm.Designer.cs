namespace TradeAggregator
{
    partial class ListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonAllProd = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonDecline = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поставщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графикКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьГрафикДляВсехToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonProfile = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.договорToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.актсчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетсверкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAllProd
            // 
            this.buttonAllProd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAllProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAllProd.Location = new System.Drawing.Point(165, 80);
            this.buttonAllProd.Name = "buttonAllProd";
            this.buttonAllProd.Size = new System.Drawing.Size(143, 30);
            this.buttonAllProd.TabIndex = 13;
            this.buttonAllProd.Text = "Все товары";
            this.buttonAllProd.UseVisualStyleBackColor = true;
            this.buttonAllProd.Visible = false;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.Location = new System.Drawing.Point(209, 37);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(99, 20);
            this.labelHeader.TabIndex = 14;
            this.labelHeader.Text = "Заголовок";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Location = new System.Drawing.Point(12, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1158, 383);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonImport.Location = new System.Drawing.Point(326, 80);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(231, 30);
            this.buttonImport.TabIndex = 16;
            this.buttonImport.Text = "Импорт товаров из Excel";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Visible = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(772, 80);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(95, 29);
            this.buttonAdd.TabIndex = 17;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Visible = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChange.Location = new System.Drawing.Point(873, 80);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(95, 29);
            this.buttonChange.TabIndex = 18;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Visible = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.Location = new System.Drawing.Point(974, 80);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(95, 29);
            this.buttonDelete.TabIndex = 19;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Visible = false;
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.Location = new System.Drawing.Point(1075, 80);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(95, 29);
            this.buttonBack.TabIndex = 20;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Visible = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Location = new System.Drawing.Point(563, 80);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(95, 29);
            this.buttonAccept.TabIndex = 21;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Visible = false;
            // 
            // buttonDecline
            // 
            this.buttonDecline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDecline.Location = new System.Drawing.Point(664, 80);
            this.buttonDecline.Name = "buttonDecline";
            this.buttonDecline.Size = new System.Drawing.Size(102, 29);
            this.buttonDecline.TabIndex = 22;
            this.buttonDecline.Text = "Отклонить";
            this.buttonDecline.UseVisualStyleBackColor = true;
            this.buttonDecline.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.действияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 29);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поставщикиToolStripMenuItem,
            this.графикКУToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(84, 25);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // поставщикиToolStripMenuItem
            // 
            this.поставщикиToolStripMenuItem.Name = "поставщикиToolStripMenuItem";
            this.поставщикиToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.поставщикиToolStripMenuItem.Text = "Справочники";
            // 
            // графикКУToolStripMenuItem
            // 
            this.графикКУToolStripMenuItem.Name = "графикКУToolStripMenuItem";
            this.графикКУToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.графикКУToolStripMenuItem.Text = "График КУ";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьГрафикToolStripMenuItem,
            this.создатьГрафикДляВсехToolStripMenuItem,
            this.показатьГрафикToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // создатьГрафикToolStripMenuItem
            // 
            this.создатьГрафикToolStripMenuItem.Name = "создатьГрафикToolStripMenuItem";
            this.создатьГрафикToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.создатьГрафикToolStripMenuItem.Text = "Создать график для выбранного КУ";
            // 
            // создатьГрафикДляВсехToolStripMenuItem
            // 
            this.создатьГрафикДляВсехToolStripMenuItem.Name = "создатьГрафикДляВсехToolStripMenuItem";
            this.создатьГрафикДляВсехToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.создатьГрафикДляВсехToolStripMenuItem.Text = "Создать график для всех КУ";
            // 
            // показатьГрафикToolStripMenuItem
            // 
            this.показатьГрафикToolStripMenuItem.Name = "показатьГрафикToolStripMenuItem";
            this.показатьГрафикToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.показатьГрафикToolStripMenuItem.Text = "Показать график";
            // 
            // buttonProfile
            // 
            this.buttonProfile.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonProfile.Location = new System.Drawing.Point(12, 80);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new System.Drawing.Size(147, 30);
            this.buttonProfile.TabIndex = 24;
            this.buttonProfile.Text = "Профиль";
            this.buttonProfile.UseVisualStyleBackColor = true;
            this.buttonProfile.Visible = false;
            this.buttonProfile.Click += new System.EventHandler(this.buttonProfile_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDownload});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1182, 24);
            this.menuStrip2.TabIndex = 25;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItemDownload
            // 
            this.toolStripMenuItemDownload.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.договорToolStripMenuItem,
            this.актсчетToolStripMenuItem,
            this.отчетсверкуToolStripMenuItem});
            this.toolStripMenuItemDownload.Name = "toolStripMenuItemDownload";
            this.toolStripMenuItemDownload.Size = new System.Drawing.Size(89, 24);
            this.toolStripMenuItemDownload.Text = "Загрузить";
            this.toolStripMenuItemDownload.Visible = false;
            // 
            // договорToolStripMenuItem
            // 
            this.договорToolStripMenuItem.Name = "договорToolStripMenuItem";
            this.договорToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.договорToolStripMenuItem.Text = "Договор поставки";
            // 
            // актсчетToolStripMenuItem
            // 
            this.актсчетToolStripMenuItem.Name = "актсчетToolStripMenuItem";
            this.актсчетToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.актсчетToolStripMenuItem.Text = "Акт-счет";
            // 
            // отчетсверкуToolStripMenuItem
            // 
            this.отчетсверкуToolStripMenuItem.Name = "отчетсверкуToolStripMenuItem";
            this.отчетсверкуToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.отчетсверкуToolStripMenuItem.Text = "Отчет-сверку";
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 513);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.buttonProfile);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonDecline);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.buttonAllProd);
            this.Name = "ListForm";
            this.ShowIcon = false;
            this.Text = "Справочник";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Assortment_FormClosing);
            this.Load += new System.EventHandler(this.AssortmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAllProd;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonDecline;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поставщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикКУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьГрафикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьГрафикДляВсехToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьГрафикToolStripMenuItem;
        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDownload;
        private System.Windows.Forms.ToolStripMenuItem договорToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem актсчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетсверкуToolStripMenuItem;
    }
}
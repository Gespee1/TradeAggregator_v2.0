
namespace TradeAggregator
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.textBoxLogin = new MaterialSkin.Controls.MaterialTextBox2();
            this.textBoxPass = new MaterialSkin.Controls.MaterialTextBox2();
            this.buttonApply = new MaterialSkin.Controls.MaterialButton();
            this.buttonSwitch = new MaterialSkin.Controls.MaterialButton();
            this.checkBoxSave = new MaterialSkin.Controls.MaterialSwitch();
            this.textBoxPassRepeat = new MaterialSkin.Controls.MaterialTextBox2();
            this.comboBoxType = new MaterialSkin.Controls.MaterialComboBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.AnimateReadOnly = false;
            this.textBoxLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxLogin.Depth = 0;
            this.textBoxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLogin.HideSelection = true;
            this.textBoxLogin.Hint = "Логин";
            this.textBoxLogin.LeadingIcon = null;
            this.textBoxLogin.LeaveOnEnterKey = true;
            this.textBoxLogin.Location = new System.Drawing.Point(127, 128);
            this.textBoxLogin.MaxLength = 32767;
            this.textBoxLogin.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.PasswordChar = '\0';
            this.textBoxLogin.PrefixSuffixText = null;
            this.textBoxLogin.ReadOnly = false;
            this.textBoxLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLogin.SelectedText = "";
            this.textBoxLogin.SelectionLength = 0;
            this.textBoxLogin.SelectionStart = 0;
            this.textBoxLogin.ShortcutsEnabled = true;
            this.textBoxLogin.Size = new System.Drawing.Size(196, 36);
            this.textBoxLogin.TabIndex = 3;
            this.textBoxLogin.TabStop = false;
            this.textBoxLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxLogin.TrailingIcon = null;
            this.textBoxLogin.UseSystemPasswordChar = false;
            this.textBoxLogin.UseTallSize = false;
            // 
            // textBoxPass
            // 
            this.textBoxPass.AnimateReadOnly = false;
            this.textBoxPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxPass.Depth = 0;
            this.textBoxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPass.HideSelection = true;
            this.textBoxPass.Hint = "Пароль";
            this.textBoxPass.LeadingIcon = null;
            this.textBoxPass.Location = new System.Drawing.Point(127, 170);
            this.textBoxPass.MaxLength = 32767;
            this.textBoxPass.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '●';
            this.textBoxPass.PrefixSuffixText = null;
            this.textBoxPass.ReadOnly = false;
            this.textBoxPass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxPass.SelectedText = "";
            this.textBoxPass.SelectionLength = 0;
            this.textBoxPass.SelectionStart = 0;
            this.textBoxPass.ShortcutsEnabled = true;
            this.textBoxPass.Size = new System.Drawing.Size(196, 36);
            this.textBoxPass.TabIndex = 4;
            this.textBoxPass.TabStop = false;
            this.textBoxPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxPass.TrailingIcon = null;
            this.textBoxPass.UseSystemPasswordChar = true;
            this.textBoxPass.UseTallSize = false;
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonApply.AutoSize = false;
            this.buttonApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonApply.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonApply.Depth = 0;
            this.buttonApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonApply.HighEmphasis = true;
            this.buttonApply.Icon = null;
            this.buttonApply.Location = new System.Drawing.Point(230, 340);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonApply.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonApply.Size = new System.Drawing.Size(126, 36);
            this.buttonApply.TabIndex = 5;
            this.buttonApply.Text = "Вход";
            this.buttonApply.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonApply.UseAccentColor = false;
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonSwitch
            // 
            this.buttonSwitch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSwitch.AutoSize = false;
            this.buttonSwitch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSwitch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSwitch.Depth = 0;
            this.buttonSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSwitch.HighEmphasis = true;
            this.buttonSwitch.Icon = null;
            this.buttonSwitch.Location = new System.Drawing.Point(96, 340);
            this.buttonSwitch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSwitch.Name = "buttonSwitch";
            this.buttonSwitch.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonSwitch.Size = new System.Drawing.Size(126, 36);
            this.buttonSwitch.TabIndex = 6;
            this.buttonSwitch.Text = "Регистрация";
            this.buttonSwitch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonSwitch.UseAccentColor = false;
            this.buttonSwitch.UseVisualStyleBackColor = true;
            this.buttonSwitch.Click += new System.EventHandler(this.buttonSwitch_Click);
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxSave.AutoSize = true;
            this.checkBoxSave.Depth = 0;
            this.checkBoxSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSave.Location = new System.Drawing.Point(127, 297);
            this.checkBoxSave.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxSave.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Ripple = true;
            this.checkBoxSave.Size = new System.Drawing.Size(184, 37);
            this.checkBoxSave.TabIndex = 7;
            this.checkBoxSave.Text = "Запомнить меня";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            // 
            // textBoxPassRepeat
            // 
            this.textBoxPassRepeat.AnimateReadOnly = false;
            this.textBoxPassRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxPassRepeat.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxPassRepeat.Depth = 0;
            this.textBoxPassRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassRepeat.HideSelection = true;
            this.textBoxPassRepeat.Hint = "Повторите пароль";
            this.textBoxPassRepeat.LeadingIcon = null;
            this.textBoxPassRepeat.Location = new System.Drawing.Point(127, 212);
            this.textBoxPassRepeat.MaxLength = 32767;
            this.textBoxPassRepeat.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxPassRepeat.Name = "textBoxPassRepeat";
            this.textBoxPassRepeat.PasswordChar = '●';
            this.textBoxPassRepeat.PrefixSuffixText = null;
            this.textBoxPassRepeat.ReadOnly = false;
            this.textBoxPassRepeat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxPassRepeat.SelectedText = "";
            this.textBoxPassRepeat.SelectionLength = 0;
            this.textBoxPassRepeat.SelectionStart = 0;
            this.textBoxPassRepeat.ShortcutsEnabled = true;
            this.textBoxPassRepeat.Size = new System.Drawing.Size(196, 36);
            this.textBoxPassRepeat.TabIndex = 9;
            this.textBoxPassRepeat.TabStop = false;
            this.textBoxPassRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxPassRepeat.TrailingIcon = null;
            this.textBoxPassRepeat.UseSystemPasswordChar = true;
            this.textBoxPassRepeat.UseTallSize = false;
            this.textBoxPassRepeat.Visible = false;
            // 
            // comboBoxType
            // 
            this.comboBoxType.AutoResize = false;
            this.comboBoxType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxType.Depth = 0;
            this.comboBoxType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxType.DropDownHeight = 118;
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.DropDownWidth = 121;
            this.comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Hint = "Тип профиля";
            this.comboBoxType.IntegralHeight = false;
            this.comboBoxType.ItemHeight = 29;
            this.comboBoxType.Items.AddRange(new object[] {
            "Поставщик",
            "Торговая сеть"});
            this.comboBoxType.Location = new System.Drawing.Point(127, 254);
            this.comboBoxType.MaxDropDownItems = 4;
            this.comboBoxType.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(196, 35);
            this.comboBoxType.StartIndex = 0;
            this.comboBoxType.TabIndex = 11;
            this.comboBoxType.UseTallSize = false;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.ErrorImage = null;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.InitialImage = null;
            this.pictureBoxLogo.Location = new System.Drawing.Point(127, 67);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(196, 55);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 12;
            this.pictureBoxLogo.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 404);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxPassRepeat);
            this.Controls.Add(this.checkBoxSave);
            this.Controls.Add(this.buttonSwitch);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxLogin);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(390, 310);
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox2 textBoxLogin;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxPass;
        private MaterialSkin.Controls.MaterialButton buttonApply;
        private MaterialSkin.Controls.MaterialButton buttonSwitch;
        private MaterialSkin.Controls.MaterialSwitch checkBoxSave;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxPassRepeat;
        private MaterialSkin.Controls.MaterialComboBox comboBoxType;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}


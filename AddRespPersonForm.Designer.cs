
namespace TradeAggregator
{
    partial class AddRespPersonForm
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
            this.textBoxName = new MaterialSkin.Controls.MaterialTextBox();
            this.maskTextBoxNumber = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.textBoxEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxPost = new MaterialSkin.Controls.MaterialTextBox();
            this.buttonCreate = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.AnimateReadOnly = false;
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Depth = 0;
            this.textBoxName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxName.Hint = "ФИО";
            this.textBoxName.LeadingIcon = null;
            this.textBoxName.LeaveOnEnterKey = true;
            this.textBoxName.Location = new System.Drawing.Point(74, 67);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxName.Multiline = false;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(349, 50);
            this.textBoxName.TabIndex = 7;
            this.textBoxName.Text = "";
            this.textBoxName.TrailingIcon = null;
            // 
            // maskTextBoxNumber
            // 
            this.maskTextBoxNumber.AllowPromptAsInput = true;
            this.maskTextBoxNumber.AnimateReadOnly = false;
            this.maskTextBoxNumber.AsciiOnly = false;
            this.maskTextBoxNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.maskTextBoxNumber.BeepOnError = false;
            this.maskTextBoxNumber.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.maskTextBoxNumber.Depth = 0;
            this.maskTextBoxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.maskTextBoxNumber.HidePromptOnLeave = false;
            this.maskTextBoxNumber.HideSelection = true;
            this.maskTextBoxNumber.Hint = "Телефонный номер";
            this.maskTextBoxNumber.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.maskTextBoxNumber.LeadingIcon = null;
            this.maskTextBoxNumber.LeaveOnEnterKey = true;
            this.maskTextBoxNumber.Location = new System.Drawing.Point(74, 123);
            this.maskTextBoxNumber.Mask = "8-000-000-00-00";
            this.maskTextBoxNumber.MaxLength = 32767;
            this.maskTextBoxNumber.MouseState = MaterialSkin.MouseState.OUT;
            this.maskTextBoxNumber.Name = "maskTextBoxNumber";
            this.maskTextBoxNumber.PasswordChar = '\0';
            this.maskTextBoxNumber.PrefixSuffixText = null;
            this.maskTextBoxNumber.PromptChar = '_';
            this.maskTextBoxNumber.ReadOnly = false;
            this.maskTextBoxNumber.RejectInputOnFirstFailure = false;
            this.maskTextBoxNumber.ResetOnPrompt = true;
            this.maskTextBoxNumber.ResetOnSpace = true;
            this.maskTextBoxNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskTextBoxNumber.SelectedText = "";
            this.maskTextBoxNumber.SelectionLength = 0;
            this.maskTextBoxNumber.SelectionStart = 0;
            this.maskTextBoxNumber.ShortcutsEnabled = true;
            this.maskTextBoxNumber.Size = new System.Drawing.Size(349, 48);
            this.maskTextBoxNumber.SkipLiterals = true;
            this.maskTextBoxNumber.TabIndex = 10;
            this.maskTextBoxNumber.TabStop = false;
            this.maskTextBoxNumber.Text = "8-   -   -  -";
            this.maskTextBoxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.maskTextBoxNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.maskTextBoxNumber.TrailingIcon = null;
            this.maskTextBoxNumber.UseSystemPasswordChar = false;
            this.maskTextBoxNumber.ValidatingType = null;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.AnimateReadOnly = false;
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEmail.Depth = 0;
            this.textBoxEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxEmail.Hint = "Электронная почта";
            this.textBoxEmail.LeadingIcon = null;
            this.textBoxEmail.LeaveOnEnterKey = true;
            this.textBoxEmail.Location = new System.Drawing.Point(74, 179);
            this.textBoxEmail.MaxLength = 50;
            this.textBoxEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxEmail.Multiline = false;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(349, 50);
            this.textBoxEmail.TabIndex = 12;
            this.textBoxEmail.Text = "";
            this.textBoxEmail.TrailingIcon = null;
            // 
            // textBoxPost
            // 
            this.textBoxPost.AnimateReadOnly = false;
            this.textBoxPost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPost.Depth = 0;
            this.textBoxPost.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxPost.Hint = "Должность";
            this.textBoxPost.LeadingIcon = null;
            this.textBoxPost.LeaveOnEnterKey = true;
            this.textBoxPost.Location = new System.Drawing.Point(74, 235);
            this.textBoxPost.MaxLength = 50;
            this.textBoxPost.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxPost.Multiline = false;
            this.textBoxPost.Name = "textBoxPost";
            this.textBoxPost.Size = new System.Drawing.Size(237, 50);
            this.textBoxPost.TabIndex = 14;
            this.textBoxPost.Text = "";
            this.textBoxPost.TrailingIcon = null;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.AutoSize = false;
            this.buttonCreate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonCreate.Depth = 0;
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreate.HighEmphasis = true;
            this.buttonCreate.Icon = null;
            this.buttonCreate.Location = new System.Drawing.Point(318, 235);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonCreate.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonCreate.Size = new System.Drawing.Size(105, 50);
            this.buttonCreate.TabIndex = 25;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonCreate.UseAccentColor = false;
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // AddRespPersonForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(518, 295);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxPost);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.maskTextBoxNumber);
            this.Controls.Add(this.textBoxName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(518, 295);
            this.MinimumSize = new System.Drawing.Size(518, 295);
            this.Name = "AddRespPersonForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание ответственного лица";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddRespPersonForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox textBoxName;
        private MaterialSkin.Controls.MaterialMaskedTextBox maskTextBoxNumber;
        private MaterialSkin.Controls.MaterialTextBox textBoxEmail;
        private MaterialSkin.Controls.MaterialTextBox textBoxPost;
        private MaterialSkin.Controls.MaterialButton buttonCreate;
    }
}
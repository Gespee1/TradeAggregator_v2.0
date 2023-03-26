﻿
namespace TradeAggregator
{
    partial class AccountForm
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
            this.labelMain = new System.Windows.Forms.Label();
            this.buttonProfile = new System.Windows.Forms.Button();
            this.buttonVendors = new System.Windows.Forms.Button();
            this.buttonOrder = new System.Windows.Forms.Button();
            this.buttonKP = new System.Windows.Forms.Button();
            this.buttonContracts = new System.Windows.Forms.Button();
            this.buttonProfileVend = new System.Windows.Forms.Button();
            this.buttonAssortment = new System.Windows.Forms.Button();
            this.buttonCont = new System.Windows.Forms.Button();
            this.buttonKU = new System.Windows.Forms.Button();
            this.buttonReceivedKP = new System.Windows.Forms.Button();
            this.buttonGraph = new System.Windows.Forms.Button();
            this.panelNetwork = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelVendor = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelNetwork.SuspendLayout();
            this.panelVendor.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMain.Location = new System.Drawing.Point(25, 38);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(230, 20);
            this.labelMain.TabIndex = 1;
            this.labelMain.Text = "Вы авторизовались как ...";
            // 
            // buttonProfile
            // 
            this.buttonProfile.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonProfile.Location = new System.Drawing.Point(3, 53);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new System.Drawing.Size(240, 30);
            this.buttonProfile.TabIndex = 6;
            this.buttonProfile.Text = "Профиль";
            this.buttonProfile.UseVisualStyleBackColor = true;
            this.buttonProfile.Click += new System.EventHandler(this.buttonProfile_Click);
            // 
            // buttonVendors
            // 
            this.buttonVendors.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonVendors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonVendors.Location = new System.Drawing.Point(3, 89);
            this.buttonVendors.Name = "buttonVendors";
            this.buttonVendors.Size = new System.Drawing.Size(240, 30);
            this.buttonVendors.TabIndex = 7;
            this.buttonVendors.Text = "Поставщики";
            this.buttonVendors.UseVisualStyleBackColor = true;
            this.buttonVendors.Click += new System.EventHandler(this.buttonVendors_Click);
            // 
            // buttonOrder
            // 
            this.buttonOrder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOrder.Location = new System.Drawing.Point(3, 125);
            this.buttonOrder.Name = "buttonOrder";
            this.buttonOrder.Size = new System.Drawing.Size(240, 30);
            this.buttonOrder.TabIndex = 8;
            this.buttonOrder.Text = "Создать заказ";
            this.buttonOrder.UseVisualStyleBackColor = true;
            this.buttonOrder.Click += new System.EventHandler(this.buttonOrder_Click);
            // 
            // buttonKP
            // 
            this.buttonKP.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonKP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonKP.Location = new System.Drawing.Point(3, 161);
            this.buttonKP.Name = "buttonKP";
            this.buttonKP.Size = new System.Drawing.Size(240, 30);
            this.buttonKP.TabIndex = 9;
            this.buttonKP.Text = "Коммерческие предложения";
            this.buttonKP.UseVisualStyleBackColor = true;
            this.buttonKP.Click += new System.EventHandler(this.buttonKP_Click);
            // 
            // buttonContracts
            // 
            this.buttonContracts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonContracts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonContracts.Location = new System.Drawing.Point(3, 197);
            this.buttonContracts.Name = "buttonContracts";
            this.buttonContracts.Size = new System.Drawing.Size(240, 30);
            this.buttonContracts.TabIndex = 10;
            this.buttonContracts.Text = "Договоры";
            this.buttonContracts.UseVisualStyleBackColor = true;
            this.buttonContracts.Click += new System.EventHandler(this.buttonContracts_Click);
            // 
            // buttonProfileVend
            // 
            this.buttonProfileVend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonProfileVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonProfileVend.Location = new System.Drawing.Point(8, 31);
            this.buttonProfileVend.Name = "buttonProfileVend";
            this.buttonProfileVend.Size = new System.Drawing.Size(240, 30);
            this.buttonProfileVend.TabIndex = 12;
            this.buttonProfileVend.Text = "Профиль";
            this.buttonProfileVend.UseVisualStyleBackColor = true;
            this.buttonProfileVend.Click += new System.EventHandler(this.buttonProfileVend_Click);
            // 
            // buttonAssortment
            // 
            this.buttonAssortment.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAssortment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAssortment.Location = new System.Drawing.Point(8, 67);
            this.buttonAssortment.Name = "buttonAssortment";
            this.buttonAssortment.Size = new System.Drawing.Size(240, 30);
            this.buttonAssortment.TabIndex = 13;
            this.buttonAssortment.Text = "Ассортимент";
            this.buttonAssortment.UseVisualStyleBackColor = true;
            this.buttonAssortment.Click += new System.EventHandler(this.buttonAssortment_Click);
            // 
            // buttonCont
            // 
            this.buttonCont.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCont.Location = new System.Drawing.Point(8, 197);
            this.buttonCont.Name = "buttonCont";
            this.buttonCont.Size = new System.Drawing.Size(240, 30);
            this.buttonCont.TabIndex = 14;
            this.buttonCont.Text = "Договоры";
            this.buttonCont.UseVisualStyleBackColor = true;
            this.buttonCont.Click += new System.EventHandler(this.buttonCont_Click);
            // 
            // buttonKU
            // 
            this.buttonKU.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonKU.Location = new System.Drawing.Point(8, 103);
            this.buttonKU.Name = "buttonKU";
            this.buttonKU.Size = new System.Drawing.Size(240, 30);
            this.buttonKU.TabIndex = 15;
            this.buttonKU.Text = "Коммерческие условия";
            this.buttonKU.UseVisualStyleBackColor = true;
            this.buttonKU.Click += new System.EventHandler(this.buttonKU_Click);
            // 
            // buttonReceivedKP
            // 
            this.buttonReceivedKP.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonReceivedKP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReceivedKP.Location = new System.Drawing.Point(11, 139);
            this.buttonReceivedKP.Name = "buttonReceivedKP";
            this.buttonReceivedKP.Size = new System.Drawing.Size(240, 52);
            this.buttonReceivedKP.TabIndex = 17;
            this.buttonReceivedKP.Text = "Поступившие коммерческие предложения";
            this.buttonReceivedKP.UseVisualStyleBackColor = true;
            this.buttonReceivedKP.Click += new System.EventHandler(this.buttonReceivedKP_Click);
            // 
            // buttonGraph
            // 
            this.buttonGraph.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGraph.Location = new System.Drawing.Point(8, 233);
            this.buttonGraph.Name = "buttonGraph";
            this.buttonGraph.Size = new System.Drawing.Size(240, 30);
            this.buttonGraph.TabIndex = 18;
            this.buttonGraph.Text = "Финансовые-графики";
            this.buttonGraph.UseVisualStyleBackColor = true;
            this.buttonGraph.Click += new System.EventHandler(this.buttonGraph_Click);
            // 
            // panelNetwork
            // 
            this.panelNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelNetwork.Controls.Add(this.button1);
            this.panelNetwork.Controls.Add(this.buttonProfile);
            this.panelNetwork.Controls.Add(this.buttonVendors);
            this.panelNetwork.Controls.Add(this.buttonOrder);
            this.panelNetwork.Controls.Add(this.buttonKP);
            this.panelNetwork.Controls.Add(this.buttonContracts);
            this.panelNetwork.Location = new System.Drawing.Point(12, 85);
            this.panelNetwork.Name = "panelNetwork";
            this.panelNetwork.Size = new System.Drawing.Size(250, 266);
            this.panelNetwork.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(3, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 30);
            this.button1.TabIndex = 11;
            this.button1.Text = "Финансовые графики";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonGraph_Click);
            // 
            // panelVendor
            // 
            this.panelVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVendor.Controls.Add(this.buttonProfileVend);
            this.panelVendor.Controls.Add(this.buttonAssortment);
            this.panelVendor.Controls.Add(this.buttonCont);
            this.panelVendor.Controls.Add(this.buttonGraph);
            this.panelVendor.Controls.Add(this.buttonKU);
            this.panelVendor.Controls.Add(this.buttonReceivedKP);
            this.panelVendor.Location = new System.Drawing.Point(268, 85);
            this.panelVendor.Name = "panelVendor";
            this.panelVendor.Size = new System.Drawing.Size(251, 266);
            this.panelVendor.TabIndex = 20;
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(533, 28);
            this.menuStrip.TabIndex = 21;
            this.menuStrip.Text = "menuStrip2";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(116, 24);
            this.toolStripMenuItemAbout.Text = "О программе";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 363);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panelVendor);
            this.Controls.Add(this.panelNetwork);
            this.Controls.Add(this.labelMain);
            this.Name = "AccountForm";
            this.ShowIcon = false;
            this.Text = "Личный кабинет";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountForm_FormClosing);
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.panelNetwork.ResumeLayout(false);
            this.panelVendor.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.Button buttonVendors;
        private System.Windows.Forms.Button buttonOrder;
        private System.Windows.Forms.Button buttonKP;
        private System.Windows.Forms.Button buttonContracts;
        private System.Windows.Forms.Button buttonProfileVend;
        private System.Windows.Forms.Button buttonAssortment;
        private System.Windows.Forms.Button buttonCont;
        private System.Windows.Forms.Button buttonKU;
        private System.Windows.Forms.Button buttonReceivedKP;
        private System.Windows.Forms.Button buttonGraph;
        private System.Windows.Forms.Panel panelNetwork;
        private System.Windows.Forms.Panel panelVendor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
    }
}
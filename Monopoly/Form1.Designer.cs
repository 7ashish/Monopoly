namespace Monopoly
{
    partial class Monopoly
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
            this.Registeration = new System.Windows.Forms.Panel();
            this.NumberofplayerPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfPlayers = new System.Windows.Forms.ComboBox();
            this.PlayerReg_Panel = new System.Windows.Forms.Panel();
            this.Token_TXT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Playername_TXT = new System.Windows.Forms.TextBox();
            this.Add_BTN = new System.Windows.Forms.Button();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Next_btn = new System.Windows.Forms.Button();
            this.Next_BTN2 = new System.Windows.Forms.Button();
            this.Panel = new System.Windows.Forms.Panel();
            this.PhotoPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Registeration.SuspendLayout();
            this.NumberofplayerPanel.SuspendLayout();
            this.PlayerReg_Panel.SuspendLayout();
            this.GamePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Registeration
            // 
            this.Registeration.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Registeration.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Registeration.Controls.Add(this.NumberofplayerPanel);
            this.Registeration.Controls.Add(this.PlayerReg_Panel);
            this.Registeration.Controls.Add(this.Panel);
            this.Registeration.Controls.Add(this.PhotoPanel);
            this.Registeration.Location = new System.Drawing.Point(0, 0);
            this.Registeration.Name = "Registeration";
            this.Registeration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Registeration.Size = new System.Drawing.Size(1165, 627);
            this.Registeration.TabIndex = 0;
            // 
            // NumberofplayerPanel
            // 
            this.NumberofplayerPanel.Controls.Add(this.Next_btn);
            this.NumberofplayerPanel.Controls.Add(this.label1);
            this.NumberofplayerPanel.Controls.Add(this.NumberOfPlayers);
            this.NumberofplayerPanel.Location = new System.Drawing.Point(238, 292);
            this.NumberofplayerPanel.Name = "NumberofplayerPanel";
            this.NumberofplayerPanel.Size = new System.Drawing.Size(608, 332);
            this.NumberofplayerPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose Number of Players";
            // 
            // NumberOfPlayers
            // 
            this.NumberOfPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumberOfPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NumberOfPlayers.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfPlayers.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.NumberOfPlayers.FormattingEnabled = true;
            this.NumberOfPlayers.Items.AddRange(new object[] {
            "\t\t\t\t2",
            "\t\t\t\t3",
            "\t\t\t\t4"});
            this.NumberOfPlayers.Location = new System.Drawing.Point(205, 129);
            this.NumberOfPlayers.Name = "NumberOfPlayers";
            this.NumberOfPlayers.Size = new System.Drawing.Size(211, 31);
            this.NumberOfPlayers.TabIndex = 0;
            this.NumberOfPlayers.SelectedIndexChanged += new System.EventHandler(this.NumberOfPlayers_SelectedIndexChanged);
            // 
            // PlayerReg_Panel
            // 
            this.PlayerReg_Panel.Controls.Add(this.Add_BTN);
            this.PlayerReg_Panel.Controls.Add(this.Next_BTN2);
            this.PlayerReg_Panel.Controls.Add(this.Token_TXT);
            this.PlayerReg_Panel.Controls.Add(this.label3);
            this.PlayerReg_Panel.Controls.Add(this.label2);
            this.PlayerReg_Panel.Controls.Add(this.Playername_TXT);
            this.PlayerReg_Panel.Location = new System.Drawing.Point(238, 292);
            this.PlayerReg_Panel.Name = "PlayerReg_Panel";
            this.PlayerReg_Panel.Size = new System.Drawing.Size(608, 335);
            this.PlayerReg_Panel.TabIndex = 3;
            // 
            // Token_TXT
            // 
            this.Token_TXT.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Token_TXT.Location = new System.Drawing.Point(268, 129);
            this.Token_TXT.Name = "Token_TXT";
            this.Token_TXT.ReadOnly = true;
            this.Token_TXT.Size = new System.Drawing.Size(190, 27);
            this.Token_TXT.TabIndex = 4;
            this.Token_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(78, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Player Token";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(78, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player Name";
            // 
            // Playername_TXT
            // 
            this.Playername_TXT.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Playername_TXT.Location = new System.Drawing.Point(268, 51);
            this.Playername_TXT.Name = "Playername_TXT";
            this.Playername_TXT.Size = new System.Drawing.Size(190, 27);
            this.Playername_TXT.TabIndex = 0;
            this.Playername_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Playername_TXT.TextChanged += new System.EventHandler(this.Playername_TXT_TextChanged);
            // 
            // Add_BTN
            // 
            this.Add_BTN.Enabled = false;
            this.Add_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Add_BTN.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_BTN.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Add_BTN.Location = new System.Drawing.Point(239, 223);
            this.Add_BTN.Name = "Add_BTN";
            this.Add_BTN.Size = new System.Drawing.Size(90, 46);
            this.Add_BTN.TabIndex = 6;
            this.Add_BTN.Text = "Add";
            this.Add_BTN.UseVisualStyleBackColor = true;
            this.Add_BTN.Click += new System.EventHandler(this.Add_BTN_Click);
            // 
            // GamePanel
            // 
            this.GamePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GamePanel.Controls.Add(this.panel1);
            this.GamePanel.Location = new System.Drawing.Point(0, 0);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GamePanel.Size = new System.Drawing.Size(1165, 627);
            this.GamePanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Monopoly.Properties.Resources.Monopoly;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(216, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 624);
            this.panel1.TabIndex = 0;
            // 
            // Next_btn
            // 
            this.Next_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Next_btn.Enabled = false;
            this.Next_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Next_btn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Next_btn.ForeColor = System.Drawing.Color.CadetBlue;
            this.Next_btn.Image = global::Monopoly.Properties.Resources.Actions_go_next_icon;
            this.Next_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Next_btn.Location = new System.Drawing.Point(482, 262);
            this.Next_btn.Name = "Next_btn";
            this.Next_btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Next_btn.Size = new System.Drawing.Size(101, 40);
            this.Next_btn.TabIndex = 2;
            this.Next_btn.Text = "Next";
            this.Next_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Next_btn.UseVisualStyleBackColor = true;
            this.Next_btn.Click += new System.EventHandler(this.Next_btn_Click);
            // 
            // Next_BTN2
            // 
            this.Next_BTN2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Next_BTN2.Enabled = false;
            this.Next_BTN2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Next_BTN2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Next_BTN2.ForeColor = System.Drawing.Color.CadetBlue;
            this.Next_BTN2.Image = global::Monopoly.Properties.Resources.Actions_go_next_icon;
            this.Next_BTN2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Next_BTN2.Location = new System.Drawing.Point(471, 262);
            this.Next_BTN2.Name = "Next_BTN2";
            this.Next_BTN2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Next_BTN2.Size = new System.Drawing.Size(101, 40);
            this.Next_BTN2.TabIndex = 5;
            this.Next_BTN2.Text = "Next";
            this.Next_BTN2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Next_BTN2.UseVisualStyleBackColor = true;
            this.Next_BTN2.Click += new System.EventHandler(this.Next_BTN2_Click);
            // 
            // Panel
            // 
            this.Panel.BackgroundImage = global::Monopoly.Properties.Resources.monopoly_man_1;
            this.Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Panel.Location = new System.Drawing.Point(852, 283);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(310, 344);
            this.Panel.TabIndex = 1;
            // 
            // PhotoPanel
            // 
            this.PhotoPanel.BackgroundImage = global::Monopoly.Properties.Resources.monopoly_intl_pack_logo;
            this.PhotoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PhotoPanel.Location = new System.Drawing.Point(0, 0);
            this.PhotoPanel.Name = "PhotoPanel";
            this.PhotoPanel.Size = new System.Drawing.Size(1165, 286);
            this.PhotoPanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(680, 551);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(18, 18);
            this.panel2.TabIndex = 0;
            // 
            // Monopoly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 628);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.Registeration);
            this.Name = "Monopoly";
            this.Text = "Monooly";
            this.Registeration.ResumeLayout(false);
            this.NumberofplayerPanel.ResumeLayout(false);
            this.NumberofplayerPanel.PerformLayout();
            this.PlayerReg_Panel.ResumeLayout(false);
            this.PlayerReg_Panel.PerformLayout();
            this.GamePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PhotoPanel;
        private System.Windows.Forms.Panel Registeration;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Panel NumberofplayerPanel;
        private System.Windows.Forms.Button Next_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox NumberOfPlayers;
        private System.Windows.Forms.Panel PlayerReg_Panel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Playername_TXT;
        private System.Windows.Forms.TextBox Token_TXT;
        private System.Windows.Forms.Button Next_BTN2;
        private System.Windows.Forms.Button Add_BTN;
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}


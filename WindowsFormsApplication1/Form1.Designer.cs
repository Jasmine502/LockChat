namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.loginBox = new System.Windows.Forms.GroupBox();
            this.pfpLbl = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.pfpBtn = new System.Windows.Forms.Button();
            this.txtColourLbl = new System.Windows.Forms.Label();
            this.foreColorBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.listMessage = new System.Windows.Forms.ListBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rosesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloudsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.underwaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meadowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solidColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buddyPFP = new System.Windows.Forms.PictureBox();
            this.userPFP = new System.Windows.Forms.PictureBox();
            this.loginBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buddyPFP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPFP)).BeginInit();
            this.SuspendLayout();
            // 
            // loginBox
            // 
            this.loginBox.BackColor = System.Drawing.Color.Transparent;
            this.loginBox.Controls.Add(this.pfpLbl);
            this.loginBox.Controls.Add(this.usernameBox);
            this.loginBox.Controls.Add(this.usernameLbl);
            this.loginBox.Controls.Add(this.pfpBtn);
            this.loginBox.Controls.Add(this.txtColourLbl);
            this.loginBox.Controls.Add(this.foreColorBox);
            this.loginBox.Controls.Add(this.nameBox);
            this.loginBox.Controls.Add(this.nameLbl);
            this.loginBox.Location = new System.Drawing.Point(17, 35);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(460, 114);
            this.loginBox.TabIndex = 0;
            this.loginBox.TabStop = false;
            this.loginBox.Text = "Login:";
            // 
            // pfpLbl
            // 
            this.pfpLbl.AutoSize = true;
            this.pfpLbl.Location = new System.Drawing.Point(235, 66);
            this.pfpLbl.Name = "pfpLbl";
            this.pfpLbl.Size = new System.Drawing.Size(75, 13);
            this.pfpLbl.TabIndex = 6;
            this.pfpLbl.Text = "Profile Picture:";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(235, 37);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(129, 20);
            this.usernameBox.TabIndex = 2;
            this.usernameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageBox_KeyDown);
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Location = new System.Drawing.Point(232, 20);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(58, 13);
            this.usernameLbl.TabIndex = 5;
            this.usernameLbl.Text = "Username:";
            // 
            // pfpBtn
            // 
            this.pfpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pfpBtn.ForeColor = System.Drawing.Color.Black;
            this.pfpBtn.Location = new System.Drawing.Point(235, 82);
            this.pfpBtn.Name = "pfpBtn";
            this.pfpBtn.Size = new System.Drawing.Size(129, 20);
            this.pfpBtn.TabIndex = 4;
            this.pfpBtn.Text = "Choose Icon!";
            this.pfpBtn.UseVisualStyleBackColor = true;
            this.pfpBtn.Click += new System.EventHandler(this.pfpBtn_Click);
            // 
            // txtColourLbl
            // 
            this.txtColourLbl.AutoSize = true;
            this.txtColourLbl.Location = new System.Drawing.Point(97, 66);
            this.txtColourLbl.Name = "txtColourLbl";
            this.txtColourLbl.Size = new System.Drawing.Size(64, 13);
            this.txtColourLbl.TabIndex = 2;
            this.txtColourLbl.Text = "Text Colour:";
            this.txtColourLbl.Click += new System.EventHandler(this.label2_Click);
            // 
            // foreColorBox
            // 
            this.foreColorBox.Location = new System.Drawing.Point(100, 82);
            this.foreColorBox.Name = "foreColorBox";
            this.foreColorBox.Size = new System.Drawing.Size(129, 20);
            this.foreColorBox.TabIndex = 3;
            this.foreColorBox.TextChanged += new System.EventHandler(this.colorBox_TextChanged);
            this.foreColorBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageBox_KeyDown);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(100, 37);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(129, 20);
            this.nameBox.TabIndex = 1;
            this.nameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageBox_KeyDown);
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(97, 20);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(38, 13);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Name:";
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.Location = new System.Drawing.Point(17, 155);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(460, 27);
            this.connectButton.TabIndex = 5;
            this.connectButton.Text = "CONNECT";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // listMessage
            // 
            this.listMessage.FormattingEnabled = true;
            this.listMessage.HorizontalScrollbar = true;
            this.listMessage.Location = new System.Drawing.Point(73, 188);
            this.listMessage.Name = "listMessage";
            this.listMessage.Size = new System.Drawing.Size(348, 212);
            this.listMessage.TabIndex = 2;
            this.listMessage.TabStop = false;
            this.listMessage.SelectedIndexChanged += new System.EventHandler(this.listMessage_SelectedIndexChanged);
            // 
            // messageBox
            // 
            this.messageBox.Enabled = false;
            this.messageBox.Location = new System.Drawing.Point(17, 411);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(460, 20);
            this.messageBox.TabIndex = 6;
            this.messageBox.TextChanged += new System.EventHandler(this.messageBox_TextChanged);
            this.messageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageBox_KeyDown);
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.Location = new System.Drawing.Point(17, 437);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(460, 31);
            this.sendButton.TabIndex = 7;
            this.sendButton.Text = "SEND";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(494, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rosesToolStripMenuItem,
            this.cloudsToolStripMenuItem,
            this.spaceToolStripMenuItem,
            this.underwaterToolStripMenuItem,
            this.meadowToolStripMenuItem,
            this.solidColourToolStripMenuItem,
            this.customToolStripMenuItem});
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            // 
            // rosesToolStripMenuItem
            // 
            this.rosesToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.rosesToolStripMenuItem.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.RosesBG;
            this.rosesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.rosesToolStripMenuItem.Name = "rosesToolStripMenuItem";
            this.rosesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rosesToolStripMenuItem.Text = "Roses";
            this.rosesToolStripMenuItem.Click += new System.EventHandler(this.rosesToolStripMenuItem_Click);
            // 
            // cloudsToolStripMenuItem
            // 
            this.cloudsToolStripMenuItem.BackColor = System.Drawing.Color.Aqua;
            this.cloudsToolStripMenuItem.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.SkyBG;
            this.cloudsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cloudsToolStripMenuItem.Name = "cloudsToolStripMenuItem";
            this.cloudsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cloudsToolStripMenuItem.Text = "Sky";
            this.cloudsToolStripMenuItem.Click += new System.EventHandler(this.cloudsToolStripMenuItem_Click);
            // 
            // spaceToolStripMenuItem
            // 
            this.spaceToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.spaceToolStripMenuItem.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.SpaceBG;
            this.spaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.spaceToolStripMenuItem.Name = "spaceToolStripMenuItem";
            this.spaceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spaceToolStripMenuItem.Text = "Space";
            this.spaceToolStripMenuItem.Click += new System.EventHandler(this.spaceToolStripMenuItem_Click);
            // 
            // underwaterToolStripMenuItem
            // 
            this.underwaterToolStripMenuItem.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.UnderwaterBG;
            this.underwaterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.underwaterToolStripMenuItem.Name = "underwaterToolStripMenuItem";
            this.underwaterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.underwaterToolStripMenuItem.Text = "Underwater";
            this.underwaterToolStripMenuItem.Click += new System.EventHandler(this.underwaterToolStripMenuItem_Click);
            // 
            // meadowToolStripMenuItem
            // 
            this.meadowToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.meadowToolStripMenuItem.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.MeadowBG;
            this.meadowToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.meadowToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.meadowToolStripMenuItem.Name = "meadowToolStripMenuItem";
            this.meadowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.meadowToolStripMenuItem.Text = "Meadow";
            this.meadowToolStripMenuItem.Click += new System.EventHandler(this.meadowToolStripMenuItem_Click);
            // 
            // solidColourToolStripMenuItem
            // 
            this.solidColourToolStripMenuItem.Name = "solidColourToolStripMenuItem";
            this.solidColourToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.solidColourToolStripMenuItem.Text = "Solid Colour";
            this.solidColourToolStripMenuItem.Click += new System.EventHandler(this.solidColourToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customToolStripMenuItem.Text = "Custom...";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            // 
            // buddyPFP
            // 
            this.buddyPFP.Location = new System.Drawing.Point(427, 188);
            this.buddyPFP.Name = "buddyPFP";
            this.buddyPFP.Size = new System.Drawing.Size(50, 50);
            this.buddyPFP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buddyPFP.TabIndex = 9;
            this.buddyPFP.TabStop = false;
            // 
            // userPFP
            // 
            this.userPFP.Location = new System.Drawing.Point(17, 188);
            this.userPFP.Name = "userPFP";
            this.userPFP.Size = new System.Drawing.Size(50, 50);
            this.userPFP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPFP.TabIndex = 7;
            this.userPFP.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 477);
            this.Controls.Add(this.buddyPFP);
            this.Controls.Add(this.userPFP);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.listMessage);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(510, 516);
            this.MinimumSize = new System.Drawing.Size(510, 516);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.loginBox.ResumeLayout(false);
            this.loginBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buddyPFP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPFP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox loginBox;
        private System.Windows.Forms.Label txtColourLbl;
        private System.Windows.Forms.TextBox foreColorBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ListBox listMessage;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.Button pfpBtn;
        private System.Windows.Forms.Label pfpLbl;
        private System.Windows.Forms.PictureBox userPFP;
        private System.Windows.Forms.PictureBox buddyPFP;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rosesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloudsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem underwaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meadowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solidColourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
    }
}


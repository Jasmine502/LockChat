namespace WindowsFormsApplication1
{
    partial class Login
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
            this.loginBox = new System.Windows.Forms.GroupBox();
            this.lockInBtn = new System.Windows.Forms.Button();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.lockChatBox = new System.Windows.Forms.PictureBox();
            this.loginBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lockChatBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loginBox
            // 
            this.loginBox.BackColor = System.Drawing.Color.Transparent;
            this.loginBox.Controls.Add(this.lockInBtn);
            this.loginBox.Controls.Add(this.usernameBox);
            this.loginBox.Controls.Add(this.usernameLbl);
            this.loginBox.Controls.Add(this.nameBox);
            this.loginBox.Controls.Add(this.nameLbl);
            this.loginBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBox.Location = new System.Drawing.Point(12, 165);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(160, 137);
            this.loginBox.TabIndex = 1;
            this.loginBox.TabStop = false;
            // 
            // lockInBtn
            // 
            this.lockInBtn.Location = new System.Drawing.Point(50, 101);
            this.lockInBtn.Name = "lockInBtn";
            this.lockInBtn.Size = new System.Drawing.Size(59, 27);
            this.lockInBtn.TabIndex = 3;
            this.lockInBtn.Text = "Lock In!";
            this.lockInBtn.UseVisualStyleBackColor = true;
            this.lockInBtn.Click += new System.EventHandler(this.lockInBtn_Click);
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(9, 33);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(140, 21);
            this.usernameBox.TabIndex = 0;
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLbl.Location = new System.Drawing.Point(6, 17);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(81, 13);
            this.usernameLbl.TabIndex = 5;
            this.usernameLbl.Text = "Screen Name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(9, 73);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(140, 21);
            this.nameBox.TabIndex = 1;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(6, 57);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(39, 13);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Name";
            // 
            // lockChatBox
            // 
            this.lockChatBox.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.lockchat;
            this.lockChatBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lockChatBox.Location = new System.Drawing.Point(12, 12);
            this.lockChatBox.Name = "lockChatBox";
            this.lockChatBox.Size = new System.Drawing.Size(160, 147);
            this.lockChatBox.TabIndex = 2;
            this.lockChatBox.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 314);
            this.Controls.Add(this.lockChatBox);
            this.Controls.Add(this.loginBox);
            this.Name = "Login";
            this.Text = "Login";
            this.loginBox.ResumeLayout(false);
            this.loginBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lockChatBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox loginBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.PictureBox lockChatBox;
        private System.Windows.Forms.Button lockInBtn;
    }
}
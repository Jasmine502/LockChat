namespace WindowsFormsApplication1
{
    partial class Friends
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
            this.chooseEsther = new System.Windows.Forms.Button();
            this.chooseSonia = new System.Windows.Forms.Button();
            this.chooseMelanie = new System.Windows.Forms.Button();
            this.chooseAimee = new System.Windows.Forms.Button();
            this.buddyListGroupBox = new System.Windows.Forms.GroupBox();
            this.bioBox = new System.Windows.Forms.PictureBox();
            this.buddyListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bioBox)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseEsther
            // 
            this.chooseEsther.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseEsther.Location = new System.Drawing.Point(6, 19);
            this.chooseEsther.Name = "chooseEsther";
            this.chooseEsther.Size = new System.Drawing.Size(139, 38);
            this.chooseEsther.TabIndex = 12;
            this.chooseEsther.Text = "Angel616";
            this.chooseEsther.UseVisualStyleBackColor = true;
            this.chooseEsther.Click += new System.EventHandler(this.chooseEsther_Click);
            this.chooseEsther.MouseHover += new System.EventHandler(this.chooseEsther_MouseHover);
            // 
            // chooseSonia
            // 
            this.chooseSonia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseSonia.Location = new System.Drawing.Point(6, 63);
            this.chooseSonia.Name = "chooseSonia";
            this.chooseSonia.Size = new System.Drawing.Size(139, 38);
            this.chooseSonia.TabIndex = 11;
            this.chooseSonia.Text = "xXx_Sony_xXx";
            this.chooseSonia.UseVisualStyleBackColor = true;
            this.chooseSonia.Click += new System.EventHandler(this.chooseSonia_Click);
            this.chooseSonia.MouseHover += new System.EventHandler(this.chooseSonia_MouseHover);
            // 
            // chooseMelanie
            // 
            this.chooseMelanie.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseMelanie.Location = new System.Drawing.Point(6, 151);
            this.chooseMelanie.Name = "chooseMelanie";
            this.chooseMelanie.Size = new System.Drawing.Size(139, 38);
            this.chooseMelanie.TabIndex = 14;
            this.chooseMelanie.Text = "MelanieS";
            this.chooseMelanie.UseVisualStyleBackColor = true;
            this.chooseMelanie.Click += new System.EventHandler(this.chooseMelanie_Click);
            this.chooseMelanie.MouseHover += new System.EventHandler(this.chooseMelanie_MouseHover);
            // 
            // chooseAimee
            // 
            this.chooseAimee.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseAimee.Location = new System.Drawing.Point(9, 107);
            this.chooseAimee.Name = "chooseAimee";
            this.chooseAimee.Size = new System.Drawing.Size(139, 38);
            this.chooseAimee.TabIndex = 13;
            this.chooseAimee.Text = "aimaggot666";
            this.chooseAimee.UseVisualStyleBackColor = true;
            this.chooseAimee.Click += new System.EventHandler(this.chooseAimee_Click);
            this.chooseAimee.MouseHover += new System.EventHandler(this.chooseAimee_MouseHover);
            // 
            // buddyListGroupBox
            // 
            this.buddyListGroupBox.Controls.Add(this.bioBox);
            this.buddyListGroupBox.Controls.Add(this.chooseEsther);
            this.buddyListGroupBox.Controls.Add(this.chooseSonia);
            this.buddyListGroupBox.Controls.Add(this.chooseMelanie);
            this.buddyListGroupBox.Controls.Add(this.chooseAimee);
            this.buddyListGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buddyListGroupBox.Location = new System.Drawing.Point(12, 12);
            this.buddyListGroupBox.Name = "buddyListGroupBox";
            this.buddyListGroupBox.Size = new System.Drawing.Size(523, 482);
            this.buddyListGroupBox.TabIndex = 17;
            this.buddyListGroupBox.TabStop = false;
            this.buddyListGroupBox.Text = "@name\'s Buddy List";
            // 
            // bioBox
            // 
            this.bioBox.Location = new System.Drawing.Point(151, 19);
            this.bioBox.Name = "bioBox";
            this.bioBox.Size = new System.Drawing.Size(356, 452);
            this.bioBox.TabIndex = 15;
            this.bioBox.TabStop = false;
            // 
            // Friends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 506);
            this.Controls.Add(this.buddyListGroupBox);
            this.Name = "Friends";
            this.Text = "Friends";
            this.buddyListGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bioBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bioBox;
        private System.Windows.Forms.Button chooseEsther;
        private System.Windows.Forms.Button chooseSonia;
        private System.Windows.Forms.Button chooseMelanie;
        private System.Windows.Forms.Button chooseAimee;
        private System.Windows.Forms.GroupBox buddyListGroupBox;
    }
}
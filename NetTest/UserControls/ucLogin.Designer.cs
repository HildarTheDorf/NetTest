namespace NetTest.UserControls
{
    partial class ucLogin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LIusername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LIpwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LIsubmit = new System.Windows.Forms.Button();
            this.LIstatus = new System.Windows.Forms.Label();
            this.Licontinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LIusername
            // 
            this.LIusername.Location = new System.Drawing.Point(188, 32);
            this.LIusername.Name = "LIusername";
            this.LIusername.Size = new System.Drawing.Size(100, 20);
            this.LIusername.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(112, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "User name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(110, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LIpwd
            // 
            this.LIpwd.Location = new System.Drawing.Point(188, 59);
            this.LIpwd.Name = "LIpwd";
            this.LIpwd.PasswordChar = '*';
            this.LIpwd.Size = new System.Drawing.Size(100, 20);
            this.LIpwd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Login";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LIsubmit
            // 
            this.LIsubmit.Location = new System.Drawing.Point(188, 96);
            this.LIsubmit.Name = "LIsubmit";
            this.LIsubmit.Size = new System.Drawing.Size(75, 23);
            this.LIsubmit.TabIndex = 5;
            this.LIsubmit.Text = "Login";
            this.LIsubmit.UseVisualStyleBackColor = true;
            this.LIsubmit.Click += new System.EventHandler(this.liSubmit_Click);
            // 
            // LIstatus
            // 
            this.LIstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIstatus.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.LIstatus.Location = new System.Drawing.Point(115, 129);
            this.LIstatus.Name = "LIstatus";
            this.LIstatus.Size = new System.Drawing.Size(236, 23);
            this.LIstatus.TabIndex = 6;
            this.LIstatus.Text = "Logged in";
            this.LIstatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Licontinue
            // 
            this.Licontinue.Location = new System.Drawing.Point(352, 129);
            this.Licontinue.Name = "Licontinue";
            this.Licontinue.Size = new System.Drawing.Size(75, 23);
            this.Licontinue.TabIndex = 7;
            this.Licontinue.Text = "Continue";
            this.Licontinue.UseVisualStyleBackColor = true;
            this.Licontinue.Click += new System.EventHandler(this.Licontinue_Click);
            // 
            // ucLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Licontinue);
            this.Controls.Add(this.LIstatus);
            this.Controls.Add(this.LIsubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LIpwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LIusername);
            this.Name = "ucLogin";
            this.Size = new System.Drawing.Size(677, 371);
            this.Load += new System.EventHandler(this.doLoadClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LIusername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LIpwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LIsubmit;
        private System.Windows.Forms.Label LIstatus;
        private System.Windows.Forms.Button Licontinue;
    }
}

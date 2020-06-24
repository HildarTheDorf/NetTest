namespace NetTest
{
    partial class PettyCash
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
            this.pan_UC = new System.Windows.Forms.Panel();
            this.butMainMenu = new System.Windows.Forms.Button();
            this.labVersion = new System.Windows.Forms.Label();
            this.labBalance = new System.Windows.Forms.Label();
            this.labBalanceText = new System.Windows.Forms.Label();
            this.pan_Balance = new System.Windows.Forms.Panel();
            this.butLogout = new System.Windows.Forms.Button();
            this.pan_Balance.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_UC
            // 
            this.pan_UC.Location = new System.Drawing.Point(58, 30);
            this.pan_UC.Name = "pan_UC";
            this.pan_UC.Size = new System.Drawing.Size(677, 331);
            this.pan_UC.TabIndex = 5;
            // 
            // butMainMenu
            // 
            this.butMainMenu.Location = new System.Drawing.Point(58, 386);
            this.butMainMenu.Name = "butMainMenu";
            this.butMainMenu.Size = new System.Drawing.Size(75, 23);
            this.butMainMenu.TabIndex = 12;
            this.butMainMenu.Text = "Main Menu";
            this.butMainMenu.UseVisualStyleBackColor = true;
            this.butMainMenu.Click += new System.EventHandler(this.doMainMenuClick);
            // 
            // labVersion
            // 
            this.labVersion.AutoSize = true;
            this.labVersion.Location = new System.Drawing.Point(60, 425);
            this.labVersion.Name = "labVersion";
            this.labVersion.Size = new System.Drawing.Size(45, 13);
            this.labVersion.TabIndex = 13;
            this.labVersion.Text = "Version:";
            // 
            // labBalance
            // 
            this.labBalance.AutoSize = true;
            this.labBalance.Location = new System.Drawing.Point(127, 3);
            this.labBalance.Name = "labBalance";
            this.labBalance.Size = new System.Drawing.Size(45, 13);
            this.labBalance.TabIndex = 15;
            this.labBalance.Text = "balance";
            // 
            // labBalanceText
            // 
            this.labBalanceText.AutoSize = true;
            this.labBalanceText.Location = new System.Drawing.Point(17, 3);
            this.labBalanceText.Name = "labBalanceText";
            this.labBalanceText.Size = new System.Drawing.Size(103, 13);
            this.labBalanceText.TabIndex = 14;
            this.labBalanceText.Text = "Petty Cash Balance:";
            // 
            // pan_Balance
            // 
            this.pan_Balance.Controls.Add(this.labBalanceText);
            this.pan_Balance.Controls.Add(this.labBalance);
            this.pan_Balance.Location = new System.Drawing.Point(222, 387);
            this.pan_Balance.Name = "pan_Balance";
            this.pan_Balance.Size = new System.Drawing.Size(216, 22);
            this.pan_Balance.TabIndex = 16;
            // 
            // butLogout
            // 
            this.butLogout.Enabled = false;
            this.butLogout.Location = new System.Drawing.Point(139, 386);
            this.butLogout.Name = "butLogout";
            this.butLogout.Size = new System.Drawing.Size(75, 23);
            this.butLogout.TabIndex = 17;
            this.butLogout.Text = "Logout";
            this.butLogout.UseVisualStyleBackColor = true;
            this.butLogout.Click += new System.EventHandler(this.butLogout_Click);
            // 
            // PettyCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butLogout);
            this.Controls.Add(this.pan_Balance);
            this.Controls.Add(this.labVersion);
            this.Controls.Add(this.butMainMenu);
            this.Controls.Add(this.pan_UC);
            this.Name = "PettyCash";
            this.Text = "PettyCash";
            this.pan_Balance.ResumeLayout(false);
            this.pan_Balance.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pan_UC;
        private System.Windows.Forms.Button butMainMenu;
        private System.Windows.Forms.Label labVersion;
        private System.Windows.Forms.Label labBalance;
        private System.Windows.Forms.Label labBalanceText;
        private System.Windows.Forms.Panel pan_Balance;
        private System.Windows.Forms.Button butLogout;
    }
}
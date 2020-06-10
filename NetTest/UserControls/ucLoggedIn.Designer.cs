namespace NetTest.UserControls
{
    partial class ucLoggedIn
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
            this.label3 = new System.Windows.Forms.Label();
            this.LINaddcash = new System.Windows.Forms.Button();
            this.LINspendcash = new System.Windows.Forms.Button();
            this.LINtransactions = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LINbalance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LINuser = new System.Windows.Forms.Button();
            this.LINLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(121, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Petty Cash Options";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LINaddcash
            // 
            this.LINaddcash.Location = new System.Drawing.Point(73, 40);
            this.LINaddcash.Name = "LINaddcash";
            this.LINaddcash.Size = new System.Drawing.Size(75, 23);
            this.LINaddcash.TabIndex = 6;
            this.LINaddcash.Text = "Add cash";
            this.LINaddcash.UseVisualStyleBackColor = true;
            this.LINaddcash.Click += new System.EventHandler(this.LINaddcash_Click);
            // 
            // LINspendcash
            // 
            this.LINspendcash.Location = new System.Drawing.Point(73, 70);
            this.LINspendcash.Name = "LINspendcash";
            this.LINspendcash.Size = new System.Drawing.Size(75, 23);
            this.LINspendcash.TabIndex = 7;
            this.LINspendcash.Text = "Spend cash";
            this.LINspendcash.UseVisualStyleBackColor = true;
            this.LINspendcash.Click += new System.EventHandler(this.LINspendcash_Click);
            // 
            // LINtransactions
            // 
            this.LINtransactions.Location = new System.Drawing.Point(52, 99);
            this.LINtransactions.Name = "LINtransactions";
            this.LINtransactions.Size = new System.Drawing.Size(115, 23);
            this.LINtransactions.TabIndex = 8;
            this.LINtransactions.Text = "View Transactions";
            this.LINtransactions.UseVisualStyleBackColor = true;
            this.LINtransactions.Click += new System.EventHandler(this.LINtransactions_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Petty Cash Balance:";
            // 
            // LINbalance
            // 
            this.LINbalance.AutoSize = true;
            this.LINbalance.Location = new System.Drawing.Point(140, 133);
            this.LINbalance.Name = "LINbalance";
            this.LINbalance.Size = new System.Drawing.Size(45, 13);
            this.LINbalance.TabIndex = 10;
            this.LINbalance.Text = "balance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Logged in user:";
            // 
            // LINuser
            // 
            this.LINuser.Location = new System.Drawing.Point(332, 35);
            this.LINuser.Name = "LINuser";
            this.LINuser.Size = new System.Drawing.Size(75, 23);
            this.LINuser.TabIndex = 12;
            this.LINuser.Text = "User";
            this.LINuser.UseVisualStyleBackColor = true;
            // 
            // LINLogout
            // 
            this.LINLogout.Enabled = false;
            this.LINLogout.Location = new System.Drawing.Point(332, 70);
            this.LINLogout.Name = "LINLogout";
            this.LINLogout.Size = new System.Drawing.Size(75, 23);
            this.LINLogout.TabIndex = 13;
            this.LINLogout.Text = "Logout";
            this.LINLogout.UseVisualStyleBackColor = true;
            this.LINLogout.Click += new System.EventHandler(this.LINLogout_Click);
            // 
            // ucLoggedIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LINLogout);
            this.Controls.Add(this.LINuser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LINbalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LINtransactions);
            this.Controls.Add(this.LINspendcash);
            this.Controls.Add(this.LINaddcash);
            this.Controls.Add(this.label3);
            this.Name = "ucLoggedIn";
            this.Size = new System.Drawing.Size(433, 163);
            this.Load += new System.EventHandler(this.ucLoggedIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LINaddcash;
        private System.Windows.Forms.Button LINspendcash;
        private System.Windows.Forms.Button LINtransactions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LINbalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LINuser;
        private System.Windows.Forms.Button LINLogout;
    }
}

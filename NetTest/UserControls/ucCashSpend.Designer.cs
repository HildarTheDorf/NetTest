namespace NetTest.UserControls
{
    partial class ucCashSpend
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
            this.PCScombo = new System.Windows.Forms.ComboBox();
            this.PCSamount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PCSspend = new System.Windows.Forms.Button();
            this.pan_MessageBox = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Petty Cash Spend";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PCScombo
            // 
            this.PCScombo.FormattingEnabled = true;
            this.PCScombo.Location = new System.Drawing.Point(18, 57);
            this.PCScombo.Name = "PCScombo";
            this.PCScombo.Size = new System.Drawing.Size(180, 21);
            this.PCScombo.TabIndex = 7;
            this.PCScombo.SelectedIndexChanged += new System.EventHandler(this.comboSelectOptionChanged);
            // 
            // PCSamount
            // 
            this.PCSamount.Location = new System.Drawing.Point(294, 57);
            this.PCSamount.Name = "PCSamount";
            this.PCSamount.Size = new System.Drawing.Size(71, 20);
            this.PCSamount.TabIndex = 8;
            this.PCSamount.TextChanged += new System.EventHandler(this.PCSamount_TextChanged);
            this.PCSamount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PCSamount_KeyPress);
            this.PCSamount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PCSamount_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Amount";
            // 
            // PCSspend
            // 
            this.PCSspend.Location = new System.Drawing.Point(414, 57);
            this.PCSspend.Name = "PCSspend";
            this.PCSspend.Size = new System.Drawing.Size(75, 23);
            this.PCSspend.TabIndex = 10;
            this.PCSspend.Text = "Spend";
            this.PCSspend.UseVisualStyleBackColor = true;
            this.PCSspend.Click += new System.EventHandler(this.PCSspend_Click);
            // 
            // pan_MessageBox
            // 
            this.pan_MessageBox.Location = new System.Drawing.Point(157, 117);
            this.pan_MessageBox.Name = "pan_MessageBox";
            this.pan_MessageBox.Size = new System.Drawing.Size(317, 181);
            this.pan_MessageBox.TabIndex = 11;
            // 
            // ucCashSpend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pan_MessageBox);
            this.Controls.Add(this.PCSspend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PCSamount);
            this.Controls.Add(this.PCScombo);
            this.Controls.Add(this.label3);
            this.Name = "ucCashSpend";
            this.Size = new System.Drawing.Size(677, 371);
            this.Load += new System.EventHandler(this.doLoadClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox PCScombo;
        private System.Windows.Forms.TextBox PCSamount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PCSspend;
        private System.Windows.Forms.Panel pan_MessageBox;
    }
}

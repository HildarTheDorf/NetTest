namespace NetTest.UserControls
{
    partial class ucCashAdd
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
            this.PCAadd = new System.Windows.Forms.Button();
            this.PCAamount = new System.Windows.Forms.TextBox();
            this.pan_MessageBox = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(122, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Petty Cash Add";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PCAadd
            // 
            this.PCAadd.Location = new System.Drawing.Point(237, 71);
            this.PCAadd.Name = "PCAadd";
            this.PCAadd.Size = new System.Drawing.Size(75, 23);
            this.PCAadd.TabIndex = 14;
            this.PCAadd.Text = "Add";
            this.PCAadd.UseVisualStyleBackColor = true;
            this.PCAadd.Click += new System.EventHandler(this.PCSAdd_Click);
            // 
            // PCAamount
            // 
            this.PCAamount.Location = new System.Drawing.Point(117, 71);
            this.PCAamount.Name = "PCAamount";
            this.PCAamount.Size = new System.Drawing.Size(71, 20);
            this.PCAamount.TabIndex = 13;
            // 
            // pan_MessageBox
            // 
            this.pan_MessageBox.Location = new System.Drawing.Point(166, 120);
            this.pan_MessageBox.Name = "pan_MessageBox";
            this.pan_MessageBox.Size = new System.Drawing.Size(317, 181);
            this.pan_MessageBox.TabIndex = 15;
            // 
            // ucCashAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pan_MessageBox);
            this.Controls.Add(this.PCAadd);
            this.Controls.Add(this.PCAamount);
            this.Controls.Add(this.label3);
            this.Name = "ucCashAdd";
            this.Size = new System.Drawing.Size(677, 371);
            this.Load += new System.EventHandler(this.doLoadClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button PCAadd;
        private System.Windows.Forms.TextBox PCAamount;
        private System.Windows.Forms.Panel pan_MessageBox;
    }
}

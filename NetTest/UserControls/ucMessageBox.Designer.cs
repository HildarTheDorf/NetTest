namespace NetTest.UserControls
{
    partial class ucMessageBox
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
            this.labMessageBox = new System.Windows.Forms.Label();
            this.butMessageBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labMessageBox
            // 
            this.labMessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMessageBox.Location = new System.Drawing.Point(8, 40);
            this.labMessageBox.Name = "labMessageBox";
            this.labMessageBox.Size = new System.Drawing.Size(300, 30);
            this.labMessageBox.TabIndex = 0;
            this.labMessageBox.Text = "This is a message which can be very long";
            this.labMessageBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butMessageBox
            // 
            this.butMessageBox.Location = new System.Drawing.Point(222, 109);
            this.butMessageBox.Name = "butMessageBox";
            this.butMessageBox.Size = new System.Drawing.Size(75, 23);
            this.butMessageBox.TabIndex = 1;
            this.butMessageBox.Text = "OK";
            this.butMessageBox.UseVisualStyleBackColor = true;
            this.butMessageBox.Click += new System.EventHandler(this.butClick);
            // 
            // ucMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.butMessageBox);
            this.Controls.Add(this.labMessageBox);
            this.Name = "ucMessageBox";
            this.Size = new System.Drawing.Size(315, 179);
            this.Load += new System.EventHandler(this.doLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labMessageBox;
        private System.Windows.Forms.Button butMessageBox;
    }
}

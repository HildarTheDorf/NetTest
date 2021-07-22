
namespace NetTest.UserControls
{
    partial class ucProfile
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tblRoles = new System.Windows.Forms.DataGridView();
            this.lblRoles = new System.Windows.Forms.Label();
            this.tblAuditLog = new System.Windows.Forms.DataGridView();
            this.lblAuditLog = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAuditLog)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(4, 4);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(86, 20);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(97, 4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(100, 26);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(97, 33);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnly = true;
            this.txtLastName.Size = new System.Drawing.Size(100, 26);
            this.txtLastName.TabIndex = 3;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(4, 33);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(86, 20);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(98, 62);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(100, 26);
            this.txtUsername.TabIndex = 5;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(5, 62);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(83, 20);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username";
            // 
            // tblRoles
            // 
            this.tblRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblRoles.Location = new System.Drawing.Point(3, 138);
            this.tblRoles.Name = "tblRoles";
            this.tblRoles.RowHeadersWidth = 62;
            this.tblRoles.RowTemplate.Height = 28;
            this.tblRoles.Size = new System.Drawing.Size(997, 182);
            this.tblRoles.TabIndex = 6;
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(9, 112);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(50, 20);
            this.lblRoles.TabIndex = 7;
            this.lblRoles.Text = "Roles";
            // 
            // tblAuditLog
            // 
            this.tblAuditLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAuditLog.Location = new System.Drawing.Point(8, 404);
            this.tblAuditLog.Name = "tblAuditLog";
            this.tblAuditLog.RowHeadersWidth = 62;
            this.tblAuditLog.RowTemplate.Height = 28;
            this.tblAuditLog.Size = new System.Drawing.Size(992, 150);
            this.tblAuditLog.TabIndex = 8;
            // 
            // lblAuditLog
            // 
            this.lblAuditLog.AutoSize = true;
            this.lblAuditLog.Location = new System.Drawing.Point(9, 351);
            this.lblAuditLog.Name = "lblAuditLog";
            this.lblAuditLog.Size = new System.Drawing.Size(77, 20);
            this.lblAuditLog.TabIndex = 9;
            this.lblAuditLog.Text = "Audit Log";
            // 
            // ucProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAuditLog);
            this.Controls.Add(this.tblAuditLog);
            this.Controls.Add(this.lblRoles);
            this.Controls.Add(this.tblRoles);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Name = "ucProfile";
            this.Size = new System.Drawing.Size(1016, 571);
            ((System.ComponentModel.ISupportInitialize)(this.tblRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAuditLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.DataGridView tblRoles;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.DataGridView tblAuditLog;
        private System.Windows.Forms.Label lblAuditLog;
    }
}

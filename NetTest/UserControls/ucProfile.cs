using System.Linq;
using System.Windows.Forms;
using NetTest.Models;

namespace NetTest.UserControls
{
    public partial class ucProfile : UserControl
    {
        private readonly mUCs m_UCs;
        private readonly mAccount m_Account;

        public ucProfile(mUCs m_UCs)
        {
            this.m_UCs = m_UCs;
            this.m_Account = new mAccount();

            InitializeComponent();

            var acc = m_Account.getAccount();
            txtFirstName.Text = acc.accFirstName;
            txtLastName.Text = acc.accLastName;
            txtUsername.Text = acc.accUserName;

            tblRoles.Columns.Add("roleKey", "Name");
            tblRoles.Columns.Add("roleName", "Description");

            foreach (var role in acc.Roles)
            {
                tblRoles.Rows.Add(role.roleKey, role.roleName);
            }

            tblAuditLog.Columns.Add("accAutKey", "Key");
            tblAuditLog.Columns.Add("accAutDT", "Date/Time");

            foreach (var audit in m_Account.getAudit(acc.accUserName).OrderByDescending(audit => audit.accAudDT))
            {
                tblAuditLog.Rows.Add(audit.accAutKey, audit.accAudDT);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetTest.Models;

namespace NetTest.UserControls
{
    public partial class ucTransactions : UserControl
    {
        cAccount cAcc = null;
        private mUCs m_UCs = null;
        mCash m_cash = null;
        public ucTransactions(mUCs m_UCs)
        {
            this.m_UCs = m_UCs;
            InitializeComponent();
        }


        public void Init()
        {
            cAcc = new mAccount().getAccount();
            if (cAcc == null)
            {
                m_UCs.ShowScreen_Login();
            }
            else
            {
                m_cash = new mCash();
                var lCash = m_cash.doReadList();

                for (int i = 0; i < lCash.Count; i++)
                {
                    dgTransactions.Rows.Add();
                    dgTransactions.Rows[i].Cells["DateTime"].Value = lCash[i].pcaDT.ToString("dd/MM/yyyy HH:mm");
                    dgTransactions.Rows[i].Cells["Person"].Value = lCash[i].accUserName;
                    dgTransactions.Rows[i].Cells["Category"].Value = lCash[i].pccName;
                    dgTransactions.Rows[i].Cells["Amount"].Value = lCash[i].pcaAmount.ToString("C2");
                }
            }
        }

        private void butMainMain_Click(object sender, EventArgs e)
        {

        }

        private void doLoadClick(object sender, EventArgs e)
        {
            Init();
        }
    }
}

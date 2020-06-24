using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NetTest.Models;

namespace NetTest.UserControls
{
    public partial class ucCashSpend : UserControl
    {
        cAccount cAcc = null;
        private mUCs m_UCs = null;
        private mCash m_cash = null;
        private string pcc_select = "PCC_Select";

        public ucCashSpend(mUCs m_UCs)
        {
            this.m_UCs = m_UCs;

            InitializeComponent();
        }


        public void Init()
        {
            m_UCs.SetMessageBox(pan_MessageBox);
            cAcc = new mAccount().getAccount();
            if (cAcc == null)
            {
                m_UCs.ShowScreen_Login();
            }

            m_cash = new mCash();

            ButtonPCSpendEnable(false);

            var dict = new Dictionary<string, string>();
            var lCat = m_cash.getCategoryList();
            dict.Add(pcc_select, "Select Category");
            for (int i = 0; i < lCat.Count; i++)
            {
                string key = lCat[i].pccKey;
                string value = lCat[i].pccName;
                if (String.Compare(key, CashCategory.PCC_CashAdd.ToString(), true) != 0)
                {
                    dict.Add(key, value);
                }
            }
            PCScombo.DataSource = new BindingSource(dict, null);
            PCScombo.DisplayMember = "Value";
            PCScombo.ValueMember = "Key";

        }




        private void PCSamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void PCSamount_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void PCSamount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void PCSspend_Click(object sender, EventArgs e)
        {
            double balance = m_cash.getBalance();
            KeyValuePair<string,string> sel = (KeyValuePair<string, string>)PCScombo.SelectedItem;

            CashCategory catKey;
            if(!Enum.TryParse(sel.Key, true, out catKey))
            {

            }
            double cash;
            if (!double.TryParse(PCSamount.Text, out cash))
            {
                //Cash amount not successfully parsed
            }
            if (cash <= 0.0)
            {
               m_UCs.MessageBoxShow("Please ensure a correct spending amount");
            }
            else if (cash > balance)
            {
                m_UCs.MessageBoxShow("Insufficient funds to complete transaction");
            }
            else
            {
                var r_cash = m_cash.doUpdate(cAcc.accUserName, catKey, cash, AccountAuditType.AAT_CashSpent);
                if (r_cash == null)
                {
                    //Cash not successfully added
                }

                m_UCs.ShowScreen_Transactions();
            }
        }


        private void doLoadClick(object sender, EventArgs e)
        {
            Init();
        }

        private void comboSelectOptionChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, string> sel = (KeyValuePair<string, string>)PCScombo.SelectedItem;
            string key = sel.Key;
            if (String.Compare(key, pcc_select,true) == 0)
            {
                ButtonPCSpendEnable(false);
            }
            else
            {
                ButtonPCSpendEnable(true);
            }
        }

        private void ButtonPCSpendEnable(bool enable)
        {
            if (enable)
            {
                PCSspend.Enabled = true;
            }
            else
            {
                PCSspend.Enabled = false;
            }
        }
    }
}

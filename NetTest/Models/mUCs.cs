using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NetTest.UserControls;
using System.Windows.Forms;

namespace NetTest.Models
{
    public class mUCs
    {

        private PettyCash m_form;
        private Control m_panel;
        private Control m_balance;
        private Panel m_messagebox;

        public mUCs(PettyCash form)
        {
            m_form = form;
            m_panel = form.Controls["pan_UC"];
            m_balance = form.Controls["pan_Balance"];
        }

        public void removeControls()
        {
            foreach (Control cont in m_panel.Controls)
            {
                m_panel.Controls.Remove(cont);
            }
        }

        public void ShowBalance(bool show)
        {
            if (show)
            {
                double balance = new mCash().getBalance();
                UpdateBalance(balance);

                m_balance.Show();
            }
            else
            {
                m_balance.Hide();
            }
        }

        private void UpdateBalance(double value)
        {
            Label labBalance = (Label)m_balance.Controls["labBalance"];
            labBalance.Text = value.ToString("C2");
        }

        public void ShowScreen_Login()
        {
            removeControls();

            m_panel.Controls.Add(new ucLogin(this));

            MainMenuButtonEnable(false);
            LogoutButtonEnable(false);
            ShowBalance(false);
        }

        public void ShowScreen_Main()
        {
            removeControls();
            m_panel.Controls.Add(new ucMain(this));

            MainMenuButtonEnable(false);
            LogoutButtonEnable(true);
            ShowBalance(true);
        }

        internal void ShowScreen_Profile()
        {
            removeControls();
            m_panel.Controls.Add(new ucProfile(this));

            MainMenuButtonEnable(true);
            LogoutButtonEnable(true);
            ShowBalance(true);
        }

        public void ShowScreen_CashAdd()
        {
            removeControls();
            m_panel.Controls.Add(new ucCashAdd(this));

            MainMenuButtonEnable(true);
            LogoutButtonEnable(true);
            ShowBalance(true);
        }
        public void ShowScreen_CashSpend()
        {
            removeControls();
            m_panel.Controls.Add(new ucCashSpend(this));

            MainMenuButtonEnable(true);
            LogoutButtonEnable(true);
            ShowBalance(true);
        }
        public void ShowScreen_Transactions()
        {
            removeControls();
            m_panel.Controls.Add(new ucTransactions(this));

            MainMenuButtonEnable(true);
            LogoutButtonEnable(true);
            ShowBalance(true);
        }

        public void SetMessageBox(Panel panMB)
        {
            m_messagebox = panMB;
        }

        public void MessageBoxShow(string text)
        {
            m_messagebox.Controls.Add(new ucMessageBox(m_messagebox, text));
        }

        public void MainMenuButtonEnable(bool enable)
        {
            Control butMainMenu = m_form.Controls["butMainMenu"];
            butMainMenu.Enabled = enable;
        }
        public void LogoutButtonEnable(bool enable)
        {
            Control butLogout = m_form.Controls["butLogout"];
            butLogout.Enabled = enable;
        }

    }
}

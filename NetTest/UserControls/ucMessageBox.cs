using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetTest.UserControls
{
    public partial class ucMessageBox : UserControl
    {
        private string m_text = "";
        private Control m_parent;
        public ucMessageBox(Control parent, string text)
        {
            m_text = text;
            m_parent = parent;
            foreach (Control cont in m_parent.Controls)
            {
                m_parent.Controls.Remove(cont);
            }

            InitializeComponent();

        }

        private void Init()
        {
            labMessageBox.Text = m_text;
        }

        private void doLoad(object sender, EventArgs e)
        {
            Init();
        }

        private void butClick(object sender, EventArgs e)
        {
            foreach (Control cont in m_parent.Controls)
            {
                m_parent.Controls.Remove(cont);
            }
        }
    }
}

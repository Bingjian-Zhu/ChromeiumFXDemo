using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromeiumFXDemo
{
    public partial class ShadowForm : Form
    {
        private string mUrl = "";
        public ShadowForm(string url)
        {
            InitializeComponent();
            mUrl = url;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            NewPageForm page = new NewPageForm(mUrl);
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowInTaskbar = false;
            page.ShowDialog(this);
            Close();
        }

        private void ShadowForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            timer1.Enabled = true;
        }
    }
}

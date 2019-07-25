using ChromeiumFXDemo.CfxHelper;
using Chromium.WebBrowser;
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
    public partial class NewPageForm : Form
    {
        ChromWebHelper cwh;
        ChromiumWebBrowser webBrowser;
        private string mUrl = "";
        public NewPageForm(string url)
        {
            InitializeComponent();
            mUrl = url;
        }

        private void NewPageForm_Load(object sender, EventArgs e)
        {
            webBrowser = new ChromiumWebBrowser(mUrl);
            webBrowser.GlobalObject.AddFunction("newpage").Execute += NewPage;
            webBrowser.GlobalObject.AddFunction("closefrm").Execute += CloseFrm;
            webBrowser.Dock = DockStyle.Fill;//铺满
            this.Controls.Add(webBrowser);//加入窗体
            cwh = new ChromWebHelper(webBrowser);

            CEFHelper.cefevent(webBrowser, this.Handle);
        }

        private void NewPage(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
        {
            //获取js传入的参数，需对应到参数类型
            if (e.Arguments.Length > 0)
            {
                ShadowForm shadow = new ShadowForm(e.Arguments[0].StringValue);
                shadow.Show();
            }

            ////设置返回值，可为基本类型,js将接收到此返回值,如不需返回值,则此处可省略
            //e.SetReturnValue("这是调用c#函数的结果");
        }

        private void CloseFrm(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
        {
            this.Close();
        }
    }
}

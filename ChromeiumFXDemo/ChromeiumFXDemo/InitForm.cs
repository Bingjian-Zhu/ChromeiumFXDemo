using ChromBrowser.ViewModel;
using ChromeiumFXDemo.CfxHelper;
using Chromium.WebBrowser;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace ChromeiumFXDemo
{
    public partial class InitForm : Form
    {
        ChromWebHelper cwh;
        private string mUrl = "";
        ChromiumWebBrowser testWeb;
        public InitForm(string url)
        {
            InitializeComponent();
            mUrl = url;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            testWeb = new ChromiumWebBrowser(mUrl);
            testWeb.GlobalObject.AddFunction("newpage").Execute += NewPage;//定义JS调用C#事件
            testWeb.GlobalObject.AddFunction("userLogin").Execute += UserLogin;//定义JS调用C#事件
            testWeb.Dock = DockStyle.Fill;//铺满
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(testWeb);
            cwh = new ChromWebHelper(testWeb);//右键菜单设置
            CEFHelper.cefevent(testWeb, this.Handle);//F12调试窗口
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

        private void UserLogin(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                //获取js传入的参数，需对应到参数类型
                if (e.Arguments.Length > 0)
                {
                    if (e.Arguments[0].StringValue == "test" && e.Arguments[1].StringValue == "123")
                    {
                        UserInfo user = new UserInfo();
                        user.userName = "admin";
                        user.token = "JWT.token";
                        response.success = true;
                        response.data = JsonConvert.SerializeObject(user);
                        e.SetReturnValue(JsonConvert.SerializeObject(response));//返回数据
                    }
                    else
                    {
                        response.success = false;
                        response.errMsg = "用户名或密码错误！";
                        e.SetReturnValue(JsonConvert.SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsg = ex.Message;
                e.SetReturnValue(JsonConvert.SerializeObject(response));
            }

        }
    }
}

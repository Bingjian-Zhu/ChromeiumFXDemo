using Chromium.WebBrowser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeiumFXDemo.CFXHelper
{
    public class IncokeJS
    {
        /// <summary>
        /// C#调用JS的方法（注意，需要页面完全加载JS代码后才能获取到值）
        /// </summary>
        /// <param name="webBrowser"></param>
        /// <param name="str">传递的字符串</param>
        public static void invokeJs(ChromiumWebBrowser webBrowser, string str)
        {
            webBrowser.ExecuteJavascript(str);
        }
    }
}

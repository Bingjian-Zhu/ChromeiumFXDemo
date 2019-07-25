using Chromium;
using Chromium.Event;
using Chromium.WebBrowser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChromeiumFXDemo.CfxHelper
{
    /// <summary>
    /// hopb额外帮助事件 需去除
    /// </summary>
    public class CEFHelper
    {
        static ChromiumWebBrowser _wb = null;
        static IntPtr handles = IntPtr.Zero;
        public static void cefevent(ChromiumWebBrowser wb, IntPtr handle)
        {
            _wb = wb;
            handles = handle;
            wb.KeyboardHandler.OnPreKeyEvent += OralMainFrm_KeyDown;

        }

        private static void OralMainFrm_KeyDown(object sender, CfxOnPreKeyEventEventArgs e)
        {
            var val = e.Event.WindowsKeyCode;
            if (val == 123)
            {
                getF12Function(_wb);
            }

            if (val == 122)
            {

            }
        }

        /// <summary>
        /// 用于调出f12事件
        /// </summary>
        /// <param name="wb"></param>
        public static void getF12Function(ChromiumWebBrowser wb)
        {
            CfxWindowInfo windowInfo = new CfxWindowInfo();


            windowInfo.Style = (WindowStyle.WS_OVERLAPPEDWINDOW | WindowStyle.WS_CLIPCHILDREN | WindowStyle.WS_CLIPSIBLINGS | WindowStyle.WS_VISIBLE);
            windowInfo.ParentWindow = handles;
            windowInfo.WindowName = "Dev Tools";

            windowInfo.Width = 800;
            windowInfo.Height = 600;

            wb.BrowserHost.ShowDevTools(windowInfo, new CfxClient(), new CfxBrowserSettings(), null);
        }
    }
}

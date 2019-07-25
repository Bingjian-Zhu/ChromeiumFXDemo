using Chromium;
using Chromium.WebBrowser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromeiumFXDemo
{
    public class ChromiumFxHelper
    {
        public static void Init()
        {
            SetLibPath(Application.StartupPath, Application.StartupPath);
            LoadInitEvent();
            ChromiumWebBrowser.Initialize();
        }

        public static void ShutDown()
        {
            ChromiumWebBrowser.Shutdown();
        }

        /// <summary>
        /// 初始化ChromiumFx和cef相关的文件路径,包括CEF文件夹和libcfx.dll
        /// </summary>
        /// <param name="cefPath"></param>
        /// <param name="cfxPath"></param>
        static void SetLibPath(string cefPath, string cfxPath)
        {
            CfxRuntime.LibCfxDirPath = cfxPath;
            CfxRuntime.LibCefDirPath = cefPath;
        }

        #region LoadInitEvent

        static void LoadInitEvent()
        {
            ChromiumWebBrowser.OnBeforeCfxInitialize += ChromiumWebBrowser_OnBeforeCfxInitialize;
            ChromiumWebBrowser.OnBeforeCommandLineProcessing += ChromiumWebBrowser_OnBeforeCommandLineProcessing;

        }

        static void ChromiumWebBrowser_OnBeforeCommandLineProcessing(Chromium.Event.CfxOnBeforeCommandLineProcessingEventArgs e)
        {

            e.CommandLine.AppendSwitchWithValue("ppapi-flash-version", "32.0.0.171");//当前CEF文件夹内的flash版本为32.0.0.171=>ppapi
            e.CommandLine.AppendSwitchWithValue("ppapi-flash-path", "pepflashplayer32_32_0_0_171.dll");
            Environment.SetEnvironmentVariable("ComSpec", "cmd.exe");//解决flash中黑框闪一下的问题，且cef文件夹内需要放置一个无效的cmd.exe(已放于cef文件夹)

        }

        static void ChromiumWebBrowser_OnBeforeCfxInitialize(Chromium.WebBrowser.Event.OnBeforeCfxInitializeEventArgs e)
        {
            e.Settings.CachePath = "Session";
            e.Settings.Locale = "zh-CN";
        }

        public static string UrlEncodeToChrome(string sUrl)
        {
            sUrl = sUrl.Replace("/", "\\");
            char[] sTmpArray = { '\\' };
            string[] sSplit = sUrl.Split(sTmpArray);
            for (int i = 1; i < sSplit.Length; ++i)
            {
                sSplit[i] = System.Web.HttpUtility.UrlEncode(sSplit[i]);
            }
            return string.Join("\\", sSplit).Replace("+", " ");
        }
        #endregion
    }
}

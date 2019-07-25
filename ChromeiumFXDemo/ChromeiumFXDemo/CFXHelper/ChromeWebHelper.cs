using Chromium.WebBrowser;

namespace ChromeiumFXDemo.CfxHelper
{
    //右键菜单设置
    public class ChromWebHelper
    {
        public ChromWebHelper(ChromiumWebBrowser wb)
        {
            wb.ContextMenuHandler.OnBeforeContextMenu += ContextMenuHandler_OnBeforeContextMenu;
            wb.KeyboardHandler.OnPreKeyEvent += KeyboardHandler_OnPreKeyEvent;
            wb.DragHandler.OnDragEnter += DragHandler_OnDragEnter;
        }

        private void KeyboardHandler_OnPreKeyEvent(object sender, Chromium.Event.CfxOnPreKeyEventEventArgs e)
        {
            if (e.Event.WindowsKeyCode == 8 && e.Event.FocusOnEditableField == 0)
            {
                e.SetReturnValue(true);
            }
            //if (e.Event.WindowsKeyCode ==123)
            //{
            //    e.SetReturnValue(true);
            //}
        }

        private void DragHandler_OnDragEnter(object sender, Chromium.Event.CfxOnDragEnterEventArgs e)
        {
            e.SetReturnValue(true);
        }

        private void ContextMenuHandler_OnBeforeContextMenu(object sender, Chromium.Event.CfxOnBeforeContextMenuEventArgs e)
        {
            //设置默认的快捷菜单显示项为中文
            if (e.Params.IsEditable == true)
            {
                e.Model.Clear();//取消右键菜单
                //编辑区显示的菜单
                //e.Model.SetLabelAt(0, "撤销         Ctrl+Z");
                //e.Model.SetLabelAt(1, "恢复         Ctrl+Y");
                //e.Model.SetLabelAt(3, "剪切         Ctrl+X");
                //e.Model.SetLabelAt(4, "复制         Ctrl+C");
                //e.Model.SetLabelAt(5, "粘贴         Ctrl+V");
                //e.Model.SetLabelAt(6, "删除");
                //e.Model.SetLabelAt(8, "全选         Ctrl+A");
            }
            else
            {
                e.Model.Clear();
            }
        }
    }
}

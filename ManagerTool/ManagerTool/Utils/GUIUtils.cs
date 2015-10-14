using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerTool {
    public static class GUIUtils {
        /// <summary>
        /// When the user click on a TextBox (or any control with a Text parameter)
        /// a folder Browser dialog is shown. The selected folder path will set the
        /// TextBox Text parameter.
        /// </summary>
        /// <param name="sender">The TextBox (or any control with a text parameter).</param>
        public static void TextBoxClickFolderBrowserDialog(object sender) {
            if (sender != null) {
                var tb = sender as TextBox;
                if (tb != null) {
                    var fBrowser = new FolderBrowserDialog();
                    fBrowser.SelectedPath = tb.Text;
                    fBrowser.ShowDialog();
                    tb.Text = fBrowser.SelectedPath;
                }
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace DemoWinForms.ExtensionMethods
{
    public static class ControlExtensionMethods
    {
        #region Fields

        #endregion

        #region Public Methods

        // example: this.RunInUIThread(() => this.progressBar1.Value = 0);
        public static void RunInUIThread(this Control control, Action action)
        {
            if (control == null || control.IsDisposed)
            {
                return;
            }

            if (control.InvokeRequired)
            {
                System.Threading.ThreadStart method = () => RunInUIThread(control, action);
                control.BeginInvoke(method);
            }
            else
            {
                action();
            }
        }

        #endregion
    }
}

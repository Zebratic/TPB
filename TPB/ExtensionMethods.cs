using System;
using System.Windows.Forms;

namespace TPB
{
    static class ExtensionMethods
    {
        public static void ShowError(this Exception ex)
        {
            MessageBox.Show(ex.Message, Application.ProductName,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

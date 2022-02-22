using System.Windows.Forms;

namespace TpbForWindows.Views.Forms
{
    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navigates the webbrowser to a certain page
        /// </summary>
        public void NavigateTo(string link)
        {
            BringToFront();
            webBrowser.Navigate(link);
        }
    }
}

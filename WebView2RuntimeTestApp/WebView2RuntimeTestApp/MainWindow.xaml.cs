using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WebView2RuntimeTestApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void getVersionButton_Click(object sender, RoutedEventArgs e)
        {
            string browserVersionString = Microsoft.Web.WebView2.Core.CoreWebView2Environment.GetAvailableBrowserVersionString(string.Empty);

            versionText.Text = browserVersionString;
        }
    }
}

using Microsoft.UI.Xaml.Controls;
using Microsoft.Web.WebView2.Core;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NativeWebWinUI2App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            AddressBar.Text = "https://developer.microsoft.com/en-us/microsoft-edge/webview2/";
            webView2.Source = new Uri(AddressBar.Text);

            webView2.NavigationCompleted += WebView2_NavigationCompleted;

            InitializeWebView2Async();

            StatusUpdate("Ready");
        }

        private async void InitializeWebView2Async()
        {
            await webView2.EnsureCoreWebView2Async();

            var browserHostObject = new ThermometerWRC.Thermometer();
            browserHostObject.AdjustTemperature(1.0f);

            var dispatchAdapter = new WinRTAdapter.DispatchAdapter();
            webView2.CoreWebView2.AddHostObjectToScript("Windows", dispatchAdapter.WrapNamedObject("Windows", dispatchAdapter));
            webView2.CoreWebView2.AddHostObjectToScript("ThermometerWRC", dispatchAdapter.WrapNamedObject("ThermometerWRC", dispatchAdapter));

            // Run these commands to use your winrt objects in the browser:
            /*
            const Windows = chrome.webview.hostObjects.sync.Windows;
            (new Windows.Globalization.Language("en-US")).displayName;

            const rc = chrome.webview.hostObjects.sync.ThermometerWRC;
            const thermometer = new rc.Thermometer();
            thermometer.adjustTemperature(1.0);
            thermometer.adjustTemperature(1.0);
            */
        }

        private void StatusUpdate(string message)
        {
            StatusBar.Text = message;
        }

        private void WebView2_NavigationCompleted(WebView2 sender, CoreWebView2NavigationCompletedEventArgs args)
        {
            StatusUpdate("Navigation complete");
        }

        private bool TryCreateUri(String potentialUri, out Uri result)
        {
            StatusUpdate("TryCreateUri");

            Uri uri;
            if ((Uri.TryCreate(potentialUri, UriKind.Absolute, out uri) || Uri.TryCreate("http://" + potentialUri, UriKind.Absolute, out uri)) &&
                (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                result = uri;
                return true;
            }
            else
            {
                StatusUpdate("Unable to configure URI");
                result = null;
                return false;
            }
        }

        private void TryNavigate()
        {
            StatusUpdate("TryNavigate");

            Uri destinationUri;
            if (TryCreateUri(AddressBar.Text, out destinationUri))
            {
                webView2.Source = destinationUri;
            }
            else
            {
                StatusUpdate("URI couldn't be figured out use it as a bing search term");

                String bingString = "https://www.bing.com/search?q=" + Uri.EscapeUriString(AddressBar.Text);
                if (TryCreateUri(bingString, out destinationUri))
                {
                    AddressBar.Text = destinationUri.AbsoluteUri;
                    webView2.Source = destinationUri;
                }
                else
                {
                    StatusUpdate("URI couldn't be configured as bing search term, giving up");
                }
            }
        }

        private void Go_OnClick(object sender, RoutedEventArgs e)
        {
            StatusUpdate("Go_OnClick: " + AddressBar.Text);

            TryNavigate();
        }

        private void AddressBar_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                StatusUpdate("AddressBar_KeyDown [Enter]: " + AddressBar.Text);

                e.Handled = true;
                TryNavigate();
            }
        }
    }
}
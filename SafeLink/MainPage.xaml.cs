using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Net;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SafeLink
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"^https://\w+\.safelinks\.protection\.outlook\.com/\?url=(.*)&data=02|01|", RegexOptions.IgnoreCase);
            string UrlString = WebUtility.UrlDecode(URL.Text);
            var match = regex.Match(UrlString);
            if (match.Success && match.Groups.Count > 1 && match.Groups[1].Success) {
                Result.Text = match.Groups[1].Value;
            } else {
                Result.Text = "failed";
            }
        }
    }
}

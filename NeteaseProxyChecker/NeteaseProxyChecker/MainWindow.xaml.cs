using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NeteaseProxyChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tbSearch_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbSearch.Text = "";
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            label.Content = "Response: ";
            checkProxy();
        }

        private async void checkProxy()
        {
            string info = await getInfoTask("http://"+tbSearch.Text+ "/music.163.com/api/song/detail?ids=[35847388]");
            if(info == null)
            {
                label.Content = label.Content + " proxy failed!";
            }
            else
            {
                label.Content = label.Content + " proxy worked!";
            }
        }

        private static async Task<string> getInfoTask(string url)
        {
            try {
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
                request.Method = "GET";
                request.Accept = "application/json";
                WebResponse responseObject = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request);
                var responseStream = responseObject.GetResponseStream();
                var sr = new StreamReader(responseStream);
                string received = await sr.ReadToEndAsync();
                return received;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AsyncAndSync
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

        private void executeSync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Run();

            watch.Stop();

            resultsWindow.Text += $"Total execution time: {watch.ElapsedMilliseconds}";
        }

        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await RunAsync();

            watch.Stop();

            resultsWindow.Text += $"Total execution time: {watch.ElapsedMilliseconds}";
        }

        private async void executeAsyncInParallel_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await RunAsyncInParallel();

            watch.Stop();

            resultsWindow.Text += $"Total execution time: {watch.ElapsedMilliseconds}";
        }

        private void Run()
        {
            var websites = GetTestWebsites();

            foreach (var website in websites)
            {
                WebsiteDataModel websiteData = DownloadWebsite(website);
                ReportWebsiteData(websiteData);
            }
        }

        private async Task RunAsync()
        {
            foreach (var website in GetTestWebsites())
            {
                // this allows the UI to respond and be moved but the "await" means that it still does each call one after the other
                // asynchronous calls made synchronously
                WebsiteDataModel websiteData = await Task.Run(() => DownloadWebsite(website));

                ReportWebsiteData(websiteData);
            }
        }

        private async Task RunAsyncInParallel()
        {
            var tasks = new List<Task<WebsiteDataModel>>();

            foreach (var website in GetTestWebsites())
            {
                // this will fire off all of the tasks in quick succession
                tasks.Add(DownloadWebsiteAsync(website));
            }

            // and wait for the slowest one to finish before continuing
            var results = await Task.WhenAll(tasks);

            foreach (var result in results)
            {
                ReportWebsiteData(result);
            }
        }

        private WebsiteDataModel DownloadWebsite(string website)
        {
            WebClient client = new WebClient();

            var watch = Stopwatch.StartNew();

            WebsiteDataModel websiteData = new WebsiteDataModel
            {
                WebsiteUrl = website, 
                WebsiteData = client.DownloadString(website)
            };

            watch.Stop();
            websiteData.ResponseTime = watch.ElapsedMilliseconds;

            return websiteData;
        }

        private async Task<WebsiteDataModel> DownloadWebsiteAsync(string website)
        {
            WebClient client = new WebClient();

            var watch = Stopwatch.StartNew();

            WebsiteDataModel websiteData = new WebsiteDataModel
            {
                WebsiteUrl = website, 
                WebsiteData = await client.DownloadStringTaskAsync(website)
            };

            watch.Stop();
            websiteData.ResponseTime = watch.ElapsedMilliseconds;

            return websiteData;
        }

        private List<string> GetTestWebsites()
        {
            var testWebsites = new List<string>();

            resultsWindow.Text = string.Empty;

            testWebsites.Add("https://www.bbc.co.uk");
            testWebsites.Add("https://www.codeproject.com");
            testWebsites.Add("https://www.google.com");
            testWebsites.Add("https://www.microsoft.com");
            testWebsites.Add("http://www.open.ac.uk");
            testWebsites.Add("https://www.stackoverflow.com");
            testWebsites.Add("https://www.yahoo.com");

            return testWebsites;
        }

        private void ReportWebsiteData(WebsiteDataModel websiteData)
        {
            resultsWindow.Text += $"{websiteData.WebsiteUrl} downloaded: {websiteData.WebsiteData.Length} characters in {websiteData.ResponseTime} ms.{Environment.NewLine} ";
        }
    }
}
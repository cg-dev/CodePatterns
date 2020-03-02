using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAndSync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void executeSync_Click(object sender, RoutedEventArgs e)
        {
            resultsWindow.Text = string.Empty;
            resultsWindow.Refresh();
            progressBar.Value = 0;

            var watch = Stopwatch.StartNew();

            ReportResults(SyncMethods.RunDownloadSync());

            watch.Stop();

            resultsWindow.Text += $"Total execution time: {watch.ElapsedMilliseconds}";
        }

        private void executeSyncInParallel_Click(object sender, RoutedEventArgs e)
        {
            resultsWindow.Text = string.Empty;
            resultsWindow.Refresh();
            progressBar.Value = 0;

            var watch = Stopwatch.StartNew();

            ReportResults(SyncMethods.RunDownloadParallelSync());

            watch.Stop();

            resultsWindow.Text += $"Total execution time: {watch.ElapsedMilliseconds}";
        }

        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            resultsWindow.Text = string.Empty;
            resultsWindow.Refresh();
            progressBar.Value = 0;

            var progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += ReportProgress;

            var watch = Stopwatch.StartNew();

            try
            {
                cancellationTokenSource.Dispose();
                cancellationTokenSource = new CancellationTokenSource();
                var results = await AsyncMethods.RunDownloadAsync(progress, cancellationTokenSource.Token);
                ReportResults(results);
            }
            catch (OperationCanceledException)
            {
                resultsWindow.Text += $"The async download was cancelled {Environment.NewLine}";
            }

            watch.Stop();

            resultsWindow.Text += $"Total execution time: {watch.ElapsedMilliseconds}";
        }

        private async void executeAsyncInParallel_Click(object sender, RoutedEventArgs e)
        {
            resultsWindow.Text = string.Empty;
            resultsWindow.Refresh();
            progressBar.Value = 0;

            var watch = Stopwatch.StartNew();

            var results = await AsyncMethods.RunDownloadAsyncInParallel();

            ReportResults(results);

            watch.Stop();

            resultsWindow.Text += $"Total execution time: {watch.ElapsedMilliseconds}";
        }

        private void ReportProgress(object sender, ProgressReportModel e)
        {
            progressBar.Value = e.PercentageComplete;
            ReportResults(e.WebsitesDownloaded);
        }

        private void cancelOperation_Click(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

        private void ReportResults(List<WebsiteDataModel> results)
        {
            resultsWindow.Text = string.Empty;

            foreach (var result in results)
            {
                resultsWindow.Text += $"{result.WebsiteUrl} downloaded: {result.WebsiteData.Length} characters in {result.ResponseTime} ms.{Environment.NewLine}";
            }

            progressBar.Value = 100;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndSync
{
    public static class AsyncMethods
    {
        public static async Task<List<WebsiteDataModel>>  RunDownloadAsync(IProgress<ProgressReportModel> progress, CancellationToken cancellationToken)
        {
            var testWebsites = CommonMethods.GetTestWebsites();
            var results = new List<WebsiteDataModel>();
            var report = new ProgressReportModel();

            foreach (var website in testWebsites)
            {
                // this allows the UI to respond and be moved but the "await" means that it still does each call one after the other
                // asynchronous calls made synchronously
                var result = await AsyncMethods.DownloadWebsiteAsync(website);
                results.Add(result);

                cancellationToken.ThrowIfCancellationRequested();

                report.WebsitesDownloaded = results;
                report.PercentageComplete = (results.Count * 100) / testWebsites.Count;
                progress.Report(report);
            }

            return results;
        }
        
        public static async Task<List<WebsiteDataModel>>  RunDownloadAsyncInParallel()
        {
            var testWebsites = CommonMethods.GetTestWebsites();
            var tasks = new List<Task<WebsiteDataModel>>();

            foreach (var website in testWebsites)
            {
                // this will fire off all of the tasks in quick succession
                tasks.Add(DownloadWebsiteAsync(website));
            }

            // and wait for them all to finish before continuing (effectively the slowest one will control things)
            var results = await Task.WhenAll(tasks);

            return new List<WebsiteDataModel>(results);
        }

        public static async Task<WebsiteDataModel> DownloadWebsiteAsync(string website)
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
    }
}
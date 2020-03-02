using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace AsyncAndSync
{
    public static class SyncMethods
    {
        public static List<WebsiteDataModel> RunDownloadSync()
        {
            var testWebsites = CommonMethods.GetTestWebsites();
            var output = new List<WebsiteDataModel>();

            // run each step one after the other
            foreach(var website in testWebsites)
            {
                var result = DownloadWebsite(website);
                output.Add(result);
            }

            return output;
        }
        
        public static List<WebsiteDataModel> RunDownloadParallelSync()
        {
            var testWebsites = CommonMethods.GetTestWebsites();
            var results = new List<WebsiteDataModel>();

            // run all at the same time synchronously so everything is locked until they are all done but only for the time that the slowest one takes
            Parallel.ForEach<string>(testWebsites, (website) =>
            {
                var result = DownloadWebsite(website);
                results.Add(result);
            });

            return results;
        }

        public static WebsiteDataModel DownloadWebsite(string website)
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
    }
}
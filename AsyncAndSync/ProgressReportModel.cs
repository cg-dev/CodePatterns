using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncAndSync
{
    public class ProgressReportModel
    {
        public int PercentageComplete { get; set; } = 0;
        public List<WebsiteDataModel> WebsitesDownloaded { get; set; } = new List<WebsiteDataModel>();
    }
}
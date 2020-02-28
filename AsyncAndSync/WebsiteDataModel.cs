namespace AsyncAndSync
{
    public class WebsiteDataModel
    {
        public string WebsiteUrl { get; set; } = string.Empty;
        public string WebsiteData { get; set; } = string.Empty;
        public long ResponseTime { get; set; } = 0;
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncAndSync
{
    public static class CommonMethods
    {
        public static List<string> GetTestWebsites()
        {
            var testWebsites = new List<string>();

            testWebsites.Add("https://www.amazon.com");
            testWebsites.Add("https://www.bbc.co.uk");
            testWebsites.Add("https://www.codeproject.com");
            testWebsites.Add("https://www.cnn.com");
            testWebsites.Add("https://www.facebook.com");
            testWebsites.Add("https://www.google.com");
            testWebsites.Add("https://www.microsoft.com");
            testWebsites.Add("http://www.open.ac.uk");
            testWebsites.Add("https://www.stackoverflow.com");
            testWebsites.Add("https://www.twitter.com");
            testWebsites.Add("https://www.yahoo.com");

            return testWebsites;
        }
    }
}
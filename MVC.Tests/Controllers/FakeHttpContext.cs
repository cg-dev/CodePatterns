namespace MVC.Tests.Controllers
{
    using System.Web;

    class FakeHttpContext : HttpContextBase
    {
        private HttpRequestBase _request = new FakeHttpRequest();

        public override HttpRequestBase Request
        {
            get
            {
                return _request;
            }
        }
    }
}
namespace MVC.Tests.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    class FakeControllerContext : ControllerContext
    {
        private HttpContextBase _context = new FakeHttpContext();

        public override HttpContextBase HttpContext
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }
    }
}
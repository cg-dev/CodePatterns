using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC.Tests.Controllers
{
    using System.Collections.Specialized;
    using System.Web;

    class FakeHttpRequest : HttpRequestBase
    {
        public override string this[string key]
        {
            get
            {
                return null;
            }
        }

        public override NameValueCollection Headers
        {
            get
            {
                return new NameValueCollection();
            }
        }
    }
}

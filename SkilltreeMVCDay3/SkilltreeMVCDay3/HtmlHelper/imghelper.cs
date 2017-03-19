using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExtensionMethods.Helper
{
    public static class imghelper
    {
        public static MvcHtmlString FakeImg(this HtmlHelper helper, int h,int w)
        {
            //MvcHtmlString(Htmlstring)
            return new MvcHtmlString("");
        }
    }
}
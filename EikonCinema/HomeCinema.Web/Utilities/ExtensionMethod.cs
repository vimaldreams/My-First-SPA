using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Web.Utilities
{
    public static class ExtensionMethod
    {
        public static HtmlDocument ToHtmlDocument(this string value)
        {
            var document = new HtmlDocument();
            document.LoadHtml(value);
            return document;
        }        
    }
}

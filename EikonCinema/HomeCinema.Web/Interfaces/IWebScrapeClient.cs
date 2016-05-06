using HomeCinema.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Web.Interfaces
{
    public interface IWebScrapeClient
    {
        WebScrapeResponse Get(string url);
    }
}

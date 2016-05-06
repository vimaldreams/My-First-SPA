using HomeCinema.Web.Interfaces;
using HomeCinema.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Web.Models
{
    public class PageAutomator : IPageAutomator
    {
        public PageAutomator()
        { 
        
        }

        public PageResponse GetFirstPageResponse(PageRequest request)
        {
            PageResponse pageResponse = new PageResponse();

            var webScrapeClient = new WebScrapeClient();
            var webResponse = webScrapeClient.Get(request.rawUrl);
            pageResponse.value = webResponse.Value;

            return pageResponse;
        }
    }
}

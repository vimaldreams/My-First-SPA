using HomeCinema.Web.Models.Response.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Web.Models
{
    public class PageProvider : PageSearchBase
    {
        private readonly PageAutomator automator;
        private readonly PageParser parser;

        public PageProvider()
        {
            automator = new PageAutomator();
            parser = new PageParser();
        }

        public override Item GetAvailabilityResponse(PageRequest request)
        {
            PageResponse response = automator.GetFirstPageResponse(request);
            return parser.GetPageResults(response); 
        }
    }
}

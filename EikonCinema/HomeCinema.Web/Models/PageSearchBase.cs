using HomeCinema.Web.Interfaces;
using HomeCinema.Web.Models.Response.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Web.Models
{
    public abstract class PageSearchBase : IPageSearchBase
    {
        protected PageSearchBase()
        { 
        
        }

        public abstract Item GetAvailabilityResponse(PageRequest request);

        public Item GetAvailabilityLiveSearch(PageRequest request)
        {
            Item searchResults = GetAvailabilityResponse(request);
            return searchResults;
        }
    }
}

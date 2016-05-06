using Newtonsoft.Json;
using HomeCinema.Web.Interfaces;
using HomeCinema.Web.Models.Response.Search;
using HomeCinema.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Web.Models
{
    public class PageParser : IPageParser
    {
        public PageParser() 
        {
 
        }

        public Item GetPageResults(PageResponse response)
        {
            List<int> searchPosition = new List<int>();

            Item movieData = JsonConvert.DeserializeObject<Item>(response.value);

            return movieData;
        }
    }
}

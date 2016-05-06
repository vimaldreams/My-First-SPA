using HomeCinema.Web.Models;
using HomeCinema.Web.Models.Response.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Web.Interfaces
{
    public interface IPageParser
    {
        Item GetPageResults(PageResponse response);
    }
}

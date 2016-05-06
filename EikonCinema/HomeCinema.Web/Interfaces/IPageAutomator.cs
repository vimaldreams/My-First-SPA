using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Web.Interfaces
{
    public interface IPageAutomator
    {
        PageResponse GetFirstPageResponse(PageRequest request);
    }
}

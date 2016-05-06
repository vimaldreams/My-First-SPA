using HomeCinema.Web.Models;
using HomeCinema.Web.Models.Response.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeCinema.Web
{
    [RoutePrefix("Response")]
    public class SearchApiController : ApiController
    {
        private PageRequest request { get; set; }

        // GET api/<controller>
        [Route("Search")]
        public IEnumerable<Search> Get()
        {
            return StartSearch("").Search;
        }

        // GET api/<controller>
        [Route("Search")]
        public IEnumerable<Search> Get(string searchTerm)
        {
            return StartSearch(searchTerm).Search;
        }

        private Item StartSearch(string searchTerm)
        {
            //an abstract class can be instantiated by using a concrete class
            PageSearchBase searchBase = new PageProvider(); 

            request = new PageRequest();
            request.rawUrl = "http://www.omdbapi.com/?s=" + searchTerm;
            if (string.IsNullOrEmpty(searchTerm))
                request.rawUrl = "http://www.omdbapi.com/?s=Star Wars";
            Item searchResults = searchBase.GetAvailabilityLiveSearch(request);
            return searchResults;
        }
    }
}
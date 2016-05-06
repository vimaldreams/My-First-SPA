using AutoMapper;
using HomeCinema.Data.Repositories;
using HomeCinema.Data.Infrastructure;
using HomeCinema.Entities;
using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HomeCinema.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/movies")]
    public class MoviesController : ApiController
    {
        private readonly IEntityBaseRepository<Movie> _moviesRepository;

        public MoviesController(IEntityBaseRepository<Movie> moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;
            var movies = _moviesRepository.GetAll().OrderByDescending(m => m.ReleaseDate).Take(6).ToList();

            IEnumerable<MovieViewModel> moviesVM = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies);

            response = request.CreateResponse<IEnumerable<MovieViewModel>>(HttpStatusCode.OK, moviesVM);

            return response;                 
        }

        [AllowAnonymous]
        [Route("{filter?}")]
        public HttpResponseMessage Get(HttpRequestMessage request, string filter = null)
        {
            HttpResponseMessage response = null;
            List<Movie> movies = null;
               
            if (!string.IsNullOrEmpty(filter))
            {
                movies = _moviesRepository
                    .FindBy(m => m.Title.ToLower()
                    .Contains(filter.ToLower().Trim()))
                    .OrderBy(m => m.ID)
                    .ToList();
            }
            else
            {
                movies = _moviesRepository
                    .GetAll()
                    .OrderBy(m => m.ID)
                    .ToList();
            }

            IEnumerable<MovieViewModel> moviesVM = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies);

            response = request.CreateResponse<IEnumerable<MovieViewModel>>(HttpStatusCode.OK, moviesVM);

            return response;
        }
    }
}
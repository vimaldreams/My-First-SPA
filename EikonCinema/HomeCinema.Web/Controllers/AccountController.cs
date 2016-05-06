using HomeCinema.Data.Infrastructure;
using HomeCinema.Services;
using HomeCinema.Services.Utilities;
using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeCinema.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IMembershipService _membershipService;

        public AccountController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
        {            
            HttpResponseMessage response = null;

            if (ModelState.IsValid)
            {
                MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);

                if (_userContext.User != null)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                }
            }
            else
                response = request.CreateResponse(HttpStatusCode.OK, new { success = false });

            return response;            
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel user)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
            }
            else
            {
                Entities.User _user = _membershipService.CreateUser(user.Username, user.Email, user.Password, new int[] { 1 });

                if (_user != null)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                }
            }

            return response;            
        }
    }
}
using MayordomoApi.BussinesLayer;
using MayordomoApi.Entities;
using MayordomoApi.Helpers;
using MayordomoApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MayordomoApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/authenticate")]
    public class AuthenticateController : ApiController
    {
        BLUser u = new BLUser();
           
        [HttpGet]
        [Route("validateemail")]
        public async Task<IHttpActionResult> ValidateEmail(string email)
        {
            var response = await u.ValidateEmail(email);
            return Ok(response);
        }

        [HttpPost]
        [Route("insertuser")]
        public async Task<IHttpActionResult> InsertUser(UserVM user)
        {
            user.Photo = Upload.ImagePath(user.PhotoBytes);
            var response = await u.InsertUser(user);
            return Ok(response);
        }


        [HttpPost]
        [Route("dologin")]
        public async Task<IHttpActionResult> DoLogin(UserVM us)
        {
            var response = await u.DoLogin(us.Email, us.Password);
            return Ok(response);
        }

        [HttpPost]
        [Route("aoth")]
        public async Task<IHttpActionResult> Token(UserVM us)
        {
            var response = await u.DoLogin(us.Email, us.Password);
            if(response != null && response.Result != null)
            {
                var token = TokenGenerator.GenerateTokenJwt(response.Result.Name);
                return Ok(token);
            }
            return BadRequest();
        }

    }
}

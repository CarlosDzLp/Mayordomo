using MayordomoApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MayordomoApi.Controllers
{
    //[Authorize]
    //[RoutePrefix("api/customers")]


    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("validateemail")]
        public async Task<IHttpActionResult> ValidateEmail()
        {
            return Ok(true);
        }

        //[HttpPost]
        //[Route("authenticate")]
        //public IHttpActionResult Authenticate(LoginRequest login)
        //{
            //if (login == null)
              //  return Unauthorized();

            //TODO: Validate credentials Correctly, this code is only for demo !!
            //bool isCredentialValid = (login.Password == "123456");
            //if (isCredentialValid)
            //{
               // var token = TokenGenerator.GenerateTokenJwt(login.Username);
              //  return Ok(token);
            //}
            //else
            //{
             //   return Unauthorized();
           // }
        //}
    }
}

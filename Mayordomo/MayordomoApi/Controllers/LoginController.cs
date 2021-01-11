using MayordomoApi.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MayordomoApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        BLUser u = new BLUser();

        [HttpGet]
        [Route("alluser")]
        public async Task<IHttpActionResult> AllUser()
        {
            var response = await u.AllUser();
            return Ok(response);
        }

        [HttpGet]
        [Route("activateaccountuser")]
        public async Task<IHttpActionResult> ActivateAccountUser(Guid IdUser)
        {
            var response = await u.ActivateAccountUser(IdUser);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteAccount")]
        public async Task<IHttpActionResult> DeleteAccount(Guid IdUser)
        {
            var response = await u.DeleteAccount(IdUser);
            return Ok(response);
        }
    }
}

using MayordomoApi.BussinesLayer;
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
    [Authorize]
    [RoutePrefix("api/celula")]
    public class CelulaController : ApiController
    {
        BLCelulas c = new BLCelulas();

        [HttpGet]
        [Route("allcelulas")]
        public async Task<IHttpActionResult> AllCelulas()
        {
            var response = await c.SelectCelula();
            return Ok(response);
        }

        [HttpGet]
        [Route("alltypemember")]
        public async Task<IHttpActionResult> AllTypeMember()
        {
            var response = await c.SelectTypeMember();
            return Ok(response);
        }

        [HttpPost]
        [Route("insertcelula")]
        public async Task<IHttpActionResult> InsertCelulas(CelulaVM celula)
        {
            var response = await c.InsertCelula(celula);
            return Ok(response);
        }


        [HttpPut]
        [Route("updatecelula")]
        public async Task<IHttpActionResult> UpdateCelula(CelulaVM celula)
        {
            var response = await c.UpdateCelula(celula);
            return Ok(response);
        }

        [HttpDelete]
        [Route("deletecelula")]
        public async Task<IHttpActionResult> DeleteCelula(Guid IdCelula)
        {
            var response = await c.DeleteCelula(IdCelula);
            return Ok(response);
        }
    }
}

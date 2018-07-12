using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIInterface;
using APIRepository;
using APIEntity;
using Myapi.Attributes;
namespace Myapi.Controllers


{
    [RoutePrefix("api/TOfficers")]
    [TOfficerAuthentication]
    public class TOfficersController : ApiController
    {
        TOfficerRepository trepo = new TOfficerRepository();



        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(this.trepo.GetAll());
        }

        [Route("{TO_accId}", Name = "GettOfficerById")]
        public IHttpActionResult Get(int TO_accId)
        {
            TOfficer u = new TOfficer();
            u = this.trepo.Get(TO_accId);

            if (u == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(u);
            }
        }

        [Route("")]
        public IHttpActionResult Post(TOfficer tOfficer)
        {

            this.trepo.Insert(tOfficer);
            string uri = Url.Link("GetUserById", new { id = tOfficer.TO_accId });
            return Created("GetCategoryById", tOfficer);
        }

        [Route("{TO_accId}")]
        public IHttpActionResult Put([FromBody]TOfficer tOfficer, [FromUri]int TO_accId)
        {
            tOfficer.TO_accId = TO_accId;
            this.trepo.Update(tOfficer);
            return Ok(tOfficer);
        }

        [Route("{TO_accId}")]
        public IHttpActionResult Delete([FromUri]int TO_accId)
        {
            this.trepo.Delete(TO_accId);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}

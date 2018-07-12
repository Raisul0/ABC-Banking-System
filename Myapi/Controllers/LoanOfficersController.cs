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
    [RoutePrefix("api/LoanOfficers")]
    [LOfficerAuthentication]
    public class LoanOfficersController : ApiController
    {

        LORepository lrepo = new LORepository();



        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(this.lrepo.GetAll());
        }
        [Route("{LOfficer_Id}", Name = "GetLOfficer_Id")]
        public IHttpActionResult Get(int LOfficer_Id)
        {
            LoanOfficer u = new LoanOfficer();
            u = this.lrepo.Get(LOfficer_Id);

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
        public IHttpActionResult Post(LoanOfficer loanOfficer)
        {

            this.lrepo.Insert(loanOfficer);
            string uri = Url.Link("GetLOfficer_Id", new { id = loanOfficer.LOfficer_Id });
            return Created("GetLOfficer_Id", loanOfficer);
        }

        [Route("{LOfficer_Id}")]
        public IHttpActionResult Put([FromBody]LoanOfficer loanOfficer, [FromUri]int LOfficer_Id)
        {
            loanOfficer.LOfficer_Id = LOfficer_Id;
            this.lrepo.Update(loanOfficer);
            return Ok(loanOfficer);
        }

        [Route("{LOfficer_Id}")]
        public IHttpActionResult Delete([FromUri]int LOfficer_Id)
        {
            this.lrepo.Delete(LOfficer_Id);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}

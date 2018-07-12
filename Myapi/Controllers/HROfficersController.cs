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
    [RoutePrefix("api/HROfficers")]
    [HROfficerAuthentication]
    public class HROfficersController : ApiController
    {
        HROfficerRepository hrepo = new HROfficerRepository();



        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(this.hrepo.GetAll());
        }
        [Route("{HR_acc_Id}", Name = "GetHR_acc_Id")]
        public IHttpActionResult Get(int HR_acc_Id)
        {
            HROfficer u = new HROfficer();
            u = this.hrepo.Get(HR_acc_Id);

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
        public IHttpActionResult Post(HROfficer hROfficer)
        {

            this.hrepo.Insert(hROfficer);
            string uri = Url.Link("GetUserById", new { id = hROfficer.HR_acc_Id });
            return Created("GetCategoryById", hROfficer);
        }

        [Route("{HR_acc_Id}")]
        public IHttpActionResult Put([FromBody]HROfficer hROfficer, [FromUri]int HR_acc_Id)
        {
            hROfficer.HR_acc_Id = HR_acc_Id;
            this.hrepo.Update(hROfficer);
            return Ok(hROfficer);
        }

        [Route("{HR_acc_Id}")]
        public IHttpActionResult Delete([FromUri]int HR_acc_Id)
        {
            this.hrepo.Delete(HR_acc_Id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

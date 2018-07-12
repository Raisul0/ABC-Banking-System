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
    [RoutePrefix("api/Branches")]
    [AdminAuthentication]
    public class BranchesController : ApiController
    {
        BranchRepository brepo = new BranchRepository();



        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(this.brepo.GetAll());
        }


        [Route("{Branch_Location}", Name = "GetLocation")]
        public IHttpActionResult Get(string Branch_Location)
        {
            Branch u = new Branch();
            u = this.brepo.Get(Branch_Location);

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
        public IHttpActionResult Post(Branch branch)
        {

            this.brepo.Insert(branch);
            string uri = Url.Link("GetBMById", new { id = branch.Branch_Location });
            return Created("GetBMById", branch);
        }

    }
}

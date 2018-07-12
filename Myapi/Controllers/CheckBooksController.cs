using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIRepository;
using APIEntity;
using Myapi.Attributes;

namespace Myapi.Controllers
{
    [RoutePrefix("api/CheckBooks")]
    [LoginAuthentication]

    public class CheckBooksController : ApiController
    {
        CheckBookRepository cbrepo = new CheckBookRepository();



        [Route("")][OfficerAuthentication]
        public IHttpActionResult Get()
        {
            return Ok(this.cbrepo.GetAll());
        }

        [Route("")][UserAuthentication]
        public IHttpActionResult Post(CheckBook checkBook)
        {

            this.cbrepo.Insert(checkBook);
            string uri = Url.Link("GetCheckBookByName", new { id = checkBook.Check_User_name });
            return Created("GetCheckBookByName", checkBook);
        }

        [Route("{Check_User_name}")][OfficerAuthentication]
        public IHttpActionResult Put([FromBody]CheckBook checkBook, [FromUri]string Check_User_name)
        {
            checkBook.Check_User_name = Check_User_name;
            this.cbrepo.Update(checkBook);
            return Ok(checkBook);
        }

    }
}

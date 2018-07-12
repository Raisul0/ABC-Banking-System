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
    [RoutePrefix("api/Expenses")]
    public class ExpensesController : ApiController
    {

        ExpenseRepository erepo = new ExpenseRepository();



        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(this.erepo.GetAll());
        }
        [Route("{Expense_date}", Name = "GetexpenseById")]
        public IHttpActionResult Get(string Expense_date)
        {
            Expense u = new Expense();
            u = this.erepo.Get(Expense_date);

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
        public IHttpActionResult Post(Expense expense)
        {

            this.erepo.Insert(expense);
            string uri = Url.Link("GetUserById", new { id = expense.Expense_date });
            return Created("GetCategoryById", expense);
        }
    }
}

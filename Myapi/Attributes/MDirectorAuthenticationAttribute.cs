﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading;
using System.Security.Principal;
using APIRepository;

namespace Myapi.Attributes
{
    public class MDirectorAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string encodedString = actionContext.Request.Headers.Authorization.Parameter;
                string decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(encodedString));
                string[] arr = decodedString.Split(new char[] { ':' });
                string username = arr[0];
                string password = arr[1];

                MDirectorRepository urepo = new MDirectorRepository();

                if (username == urepo.Get(username).MD_name && password == urepo.Get(username).MD_password)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }

        }
    }
}
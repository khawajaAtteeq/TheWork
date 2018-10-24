using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BusinessServices;

namespace TheWork.ActionFilters
{
    /// <summary>
    /// This action filter will only recognize Token coming in requests. 
    /// It assumes that, requests are already authenticated through our login channel,
    ///  and now user is authorized/not authorized to use other services like Products
    ///  in our case, there could be n number of other services too, which can use this
    ///  authorization action filter. For request to get authorized, nbow we don’t have
    ///  to pass user credentials. Only token(received from Authenticate controller after
    ///  successful validation) needs to be passed through request.
    /// </summary>
    public class AuthorizationRequiredAttribute:ActionFilterAttribute
    {
        //Override the OnActionExecuting method of ActionFilterAttribute, 
        //this is the way we define an action filter in API project.

        //The overridden method checks for “Token” attribute in the Header of every request,
        //if token is present, it calls ValidateToken method from TokenServices to check
        //if the token exists in the database.If token is valid, our request is navigated
        //to the actual controller and action that we requested, else you’ll get an error
        //message saying unauthorized.
        
        private const string Token = "Token";

        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            //  Get API key provider
            var provider = filterContext.ControllerContext.Configuration
                .DependencyResolver.GetService(typeof(ITokenServices)) as ITokenServices;

            if (filterContext.Request.Headers.Contains(Token))
            {
                var tokenValue = filterContext.Request.Headers.GetValues(Token).First();

                // Validate Token
                if (provider != null && !provider.ValidateToken(tokenValue))
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Invalid Request" };
                    filterContext.Response = responseMessage;
                }
            }
            else
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            base.OnActionExecuting(filterContext);

        }
   
    }
}
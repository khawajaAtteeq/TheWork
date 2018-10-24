using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using BusinessServices;
using TheWork.Filters;

namespace TheWork.Controllers
{
    [ApiAuthenticationFilter]
    public class AuthenticateController : ApiController
    {

        #region Private variable.

        private readonly ITokenServices _tokenServices;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public AuthenticateController(ITokenServices tokenServices)
        {
            _tokenServices = tokenServices;
        }

        #endregion

        /// <summary>
        /// Authenticates user and returns token with expiry.
        /// There is a single Authenticate method / action in this controller. 
        /// one can decorate it with multiple endpoints like POST/ROUT("jack/log/login/users/")
        /// </summary>
        /// <returns></returns>
        [Route("login")]
        [Route("authenticate")]
        [Route("get/token")]
        public HttpResponseMessage Authenticate()
        {
            //Authenticate method first checks for CurrentThreadPrincipal 
            //and if the user is authenticated or not i.e job done by authentication filter
            
            if (System.Threading.Thread.CurrentPrincipal != null && 
                System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                //our BasicAuthenticationIdentity class, We used userId 
                //property so that we can make use of this property when we try to generate token, 
                //that we are doing in this controller’s Authenticate method,
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity 
                    as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    var userId = basicAuthenticationIdentity.UserId;
                    return GetAuthToken(userId);
                }
            }
            return null;
        }

        /// <summary>
        /// Returns auth token for the validated user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private HttpResponseMessage GetAuthToken(int userId)
        {
            var token = _tokenServices.GenerateToken(userId);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            //When it finds that the user is authenticated, it generates an auth token 
            //with the help of TokenServices and returns user with Token and its expiry
            response.Headers.Add("Token", token.AuthToken);
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;
        }
   
    }
}

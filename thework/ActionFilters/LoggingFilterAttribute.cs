using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;
using TheWork.Helpers;

namespace TheWork.ActionFilters
{
    /// <summary>
    /// Action filter will be responsible for handling all the incoming requests
    ///  to our APIs and logging them using NLogger class. We have 
    /// “OnActionExecuting” method that is implicitly called if we
    ///  mark our controllers or global application to use that particular filter.
    ///  So each time any action of any controller will 
    /// be hit, our “OnActionExecuting” method will execute to log the request.
    /// 
    /// todo
    /// The LoggingFilterAttribute class derived from ActionFilterAttribute,
    ///  which is under System.Web.Http.Filters and overriding the OnActionExecuting method.
    ///Here we have replaced the default “ITraceWriter” service with
    ///  our NLogger class instance in the controller’s service container.
    ///  Now GetTraceWriter() method will return our instance
    ///  (instance NLogger class) and Info() will call trace() method of our NLogger class.
    /// </summary>
    public class LoggingFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            //todo
            //is used to resolve dependency between ITaceWriter and NLogger class.
            //Thereafter we use a variable named trace to get the instance and trace.
            //    Info() is used to log the request and whatever text we want to add
            //        along with that request.
            GlobalConfiguration.Configuration.Services
                //Here we have replaced the default “ITraceWriter” service with
                .Replace(typeof(ITraceWriter), new NLogger());
            var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
            trace.Info(filterContext.Request, "Controller : " +
                filterContext.ControllerContext
                .ControllerDescriptor.ControllerType.FullName +
                Environment.NewLine + "Action : " + filterContext
                .ActionDescriptor.ActionName, "JSON", filterContext.ActionArguments);
        }//todo important 
        //In order to register the created action filter 
        //to application’s filters, just add a new instance
        //    of your action filter to config.Filters in 
        //WebApiConfig class
    }
}
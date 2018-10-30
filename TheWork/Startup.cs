using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TheWork.Startup))]

namespace TheWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           // app.UseWebApi(WebApiConfig.Register());
           //Just the test checkin on 
        }
    }
}

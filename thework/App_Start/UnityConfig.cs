using System.Web.Http;
using System.Web.Mvc;
using BusinessServices;
//using DataModel.UnitOfWork;
using Microsoft.Practices.Unity;
using Resolver;
using Unity.Mvc5;
using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;
using Unity.WebApi;
using UnityDependencyResolver = Unity.Mvc5.UnityDependencyResolver;

namespace TheWork
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //Just specify the components below these commented lines that 
            //we need to resolve.In our case, it’s ProductServices and UnitOfWork, 
            //    so just add,
            //container.RegisterType<IProductServices, ProductServices>()
            //    .RegisterType<UnitOfWork>(
            //        new HierarchicalLifetimeManager()
            //    );

            //“HierarchicalLifetimeManager” maintains the lifetime of the object and 
            //child object depends upon parent object’s lifetime.
            //System.Web.Mvc.DependencyResolver.SetResolver(new Unity.WebApi.UnityDependencyResolver(container));
            //DependencyResolver
            //    .SetResolver(new UnityDependencyResolver(container));
            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // register dependency resolver for WebAPI RC
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
     
            // register dependency resolver for WebAPI RC
            // GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            //new Unity.TheWork.UnityDependencyResolver(container);
            RegisterTypes(container);
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            //Note that in RegisterTypes method we load components/dlls through reflection 
            //making use of ComponentLoader.We wrote two lines, first to load TheWork.dll 
            //and another one to load Business Services.dll
            //Component initialization via MEF
            ComponentLoader.LoadContainer(container, ".\\bin", "TheWork.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "BusinessServices.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "DataModel.dll");
        }

    }
}
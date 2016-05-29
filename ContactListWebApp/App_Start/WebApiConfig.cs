using System.Web.Http;
using ContactListWebApp.IocContainer;
using ContactListWebApp.Repositories;
using ContactListWebApp.Services;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;

namespace ContactListWebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IContactService, ContactService>(new HierarchicalLifetimeManager());
            container.RegisterType<IContactRepository, ContactRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IJobService, JobService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICompanyService, CompanyService>(new HierarchicalLifetimeManager());
            container.RegisterType<IJobRepository, JobRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICompanyRepository, CompanyRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("ActionApi", "api/{controller}/{action}/{id}", new {id = RouteParameter.Optional});
        }
    }
}

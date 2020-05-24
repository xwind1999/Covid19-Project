using CovidAssignment.Controllers;
using CovidAssignment.DataContext;
using CovidAssignment.Models;
using CovidAssignment.Repository;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;

namespace CovidAssignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterSingleton<CovidApiContext>();
            container.RegisterSingleton<CovidApiProperty>();
            container.RegisterSingleton<ICountryRepository, CountryRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            ControllerBuilder.Current.SetControllerFactory(new IocControllerFactory(container));
        }
    }
}
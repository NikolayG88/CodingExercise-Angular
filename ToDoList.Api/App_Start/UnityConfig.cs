using CodingExercise.API.App_Start;
using Application.Interfaces;
using Application.Services;
using System.Web.Http;
using Unity.WebApi;
using Persistance;
using Unity;

namespace CodingExercise.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);


            var mapperConfig = new MapperConfig();

            container.RegisterInstance(mapperConfig.CreateMapper());

            container.RegisterType<IToDoListService, ToDoListService>();
            container.RegisterType<IAppDbContext, AppDbContext>();
        }
    }
}
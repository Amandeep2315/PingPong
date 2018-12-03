using DataBaseAccess.Repository;
using PingPong.BusinessObject;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace PingPong.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
           
            container.RegisterType<IPlayerRepository, PlayerRepository>();
            container.RegisterType<IPlayerBusinessObject, PlayerBusinessObject>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
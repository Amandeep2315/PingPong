using DataBaseAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using AutoMapper;

namespace PingPong.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();

            using (var ctxt = new DatabaseContext())
            {
                System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());
            }
        }
    }
}

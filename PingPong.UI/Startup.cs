using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PingPong.UI.Startup))]
namespace PingPong.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}

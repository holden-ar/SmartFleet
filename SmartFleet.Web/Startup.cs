using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartFleet.Web.Startup))]
namespace SmartFleet.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

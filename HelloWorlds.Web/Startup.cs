using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloWorlds.Web.Startup))]
namespace HelloWorlds.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

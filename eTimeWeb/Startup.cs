using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eTimeWeb.Startup))]
namespace eTimeWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

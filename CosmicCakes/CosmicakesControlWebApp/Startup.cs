using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CosmicakesControlWebApp.Startup))]
namespace CosmicakesControlWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

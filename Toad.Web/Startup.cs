using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Toad.Web.Startup))]
namespace Toad.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}

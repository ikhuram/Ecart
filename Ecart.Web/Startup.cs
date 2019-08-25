using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ecart.Web.Startup))]
namespace Ecart.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

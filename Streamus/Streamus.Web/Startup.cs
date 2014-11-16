using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Streamus.Web.Startup))]
namespace Streamus.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

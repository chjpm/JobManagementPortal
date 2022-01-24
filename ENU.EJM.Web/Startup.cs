using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ENU.EJM.Web.Startup))]
namespace ENU.EJM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

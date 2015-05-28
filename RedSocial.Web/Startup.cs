using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedSocial.Web.Startup))]
namespace RedSocial.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

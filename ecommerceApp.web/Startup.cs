using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ecommerceApp.web.Startup))]
namespace ecommerceApp.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(emanetV2.Web.Startup))]
namespace emanetV2.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(emanetV2.Admin.Startup))]
namespace emanetV2.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

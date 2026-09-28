using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nosotros_TS.Startup))]
namespace Nosotros_TS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

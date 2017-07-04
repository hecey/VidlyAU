using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyAU.Startup))]
namespace VidlyAU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

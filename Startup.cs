using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HPS.Startup))]
namespace HPS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

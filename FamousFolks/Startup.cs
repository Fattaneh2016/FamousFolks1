using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamousFolks.Startup))]
namespace FamousFolks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stal_Rondo.Startup))]
namespace Stal_Rondo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

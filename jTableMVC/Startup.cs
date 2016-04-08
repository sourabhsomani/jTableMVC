using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jTableMVC.Startup))]
namespace jTableMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

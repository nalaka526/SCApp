using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SCApp.Startup))]
namespace SCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

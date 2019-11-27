using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(medlogin.Startup))]
namespace medlogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

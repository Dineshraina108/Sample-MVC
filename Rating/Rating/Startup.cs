using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rating.Startup))]
namespace Rating
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

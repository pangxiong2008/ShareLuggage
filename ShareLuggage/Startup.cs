using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShareLuggage.Startup))]
namespace ShareLuggage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

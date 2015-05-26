using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrackaryASP.Startup))]
namespace TrackaryASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

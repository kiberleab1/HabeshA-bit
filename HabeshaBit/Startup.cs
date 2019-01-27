using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HabeshaBit.Startup))]
namespace HabeshaBit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

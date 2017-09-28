using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JudgeApps.Startup))]
namespace JudgeApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

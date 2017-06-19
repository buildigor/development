using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebStatistic.Startup))]
namespace WebStatistic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

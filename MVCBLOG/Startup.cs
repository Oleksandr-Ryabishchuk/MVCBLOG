using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBLOG.Startup))]
namespace MVCBLOG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

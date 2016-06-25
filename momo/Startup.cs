using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(momo.Startup))]
namespace momo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

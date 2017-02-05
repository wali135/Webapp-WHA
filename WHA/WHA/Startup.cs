using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WHA.Startup))]
namespace WHA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

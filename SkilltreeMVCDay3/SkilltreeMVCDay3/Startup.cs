using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkilltreeMVCDay3.Startup))]
namespace SkilltreeMVCDay3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

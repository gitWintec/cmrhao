using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cmrhao.Startup))]
namespace cmrhao
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

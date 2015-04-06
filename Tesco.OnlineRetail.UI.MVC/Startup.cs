using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tesco.OnlineRetail.UI.MVC.Startup))]
namespace Tesco.OnlineRetail.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

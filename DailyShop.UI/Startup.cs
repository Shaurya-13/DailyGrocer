using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DailyShop.UI.Startup))]
namespace DailyShop.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

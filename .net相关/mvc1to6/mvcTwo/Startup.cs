using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcTwo.Startup))]
namespace mvcTwo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

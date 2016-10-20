using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnitTestingTutorial.Startup))]
namespace UnitTestingTutorial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

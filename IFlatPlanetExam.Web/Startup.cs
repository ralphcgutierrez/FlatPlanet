using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IFlatPlanetExam.Web.Startup))]
namespace IFlatPlanetExam.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}

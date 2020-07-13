using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebProyect.Startup))]
namespace WebProyect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

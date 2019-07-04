using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetMutuelle.Startup))]
namespace ProjetMutuelle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

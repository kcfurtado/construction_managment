using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConstrucaoCivil.Startup))]
namespace ConstrucaoCivil
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

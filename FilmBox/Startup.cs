using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmBox.Startup))]
namespace FilmBox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

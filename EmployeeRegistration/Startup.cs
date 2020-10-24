using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeRegistration.Startup))]
namespace EmployeeRegistration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

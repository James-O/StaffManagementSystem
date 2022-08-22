using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StaffManagementSystem.Startup))]
namespace StaffManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

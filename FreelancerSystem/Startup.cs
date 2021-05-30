using FreelancerSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FreelancerSystem.Startup))]
namespace FreelancerSystem
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            CreateUsers();
        }
        public void CreateUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "mahmoud@gmail.com";
            user.UserName = "mahmoud0020";
            user.phone = 01225;
            user.FirstName = "mahmoud";
            user.LastName = "ramadan";
            
            var check = userManager.Create(user, "Assoonas2016@");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admins");
            }
        }
        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Editor"))
            {
                role = new IdentityRole();
                role.Name = "Freelancer";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Viewer"))
            {
                role = new IdentityRole();
                role.Name = "Client";
                roleManager.Create(role);
            }
        }
    }
}

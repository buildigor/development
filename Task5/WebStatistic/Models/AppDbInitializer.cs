using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebStatistic.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleAdmin = new IdentityRole("admin");
            var roleUser = new IdentityRole("user");
            roleManager.Create(roleAdmin);
            roleManager.Create(roleUser);
            var admin = new ApplicationUser
            {
                Email = "vanovichigor@gmail.com",
                UserName = "vanovichigor@gmail.com"
            };
            const string password = "O_0igor";
            var rezult = userManager.Create(admin, password);
            if (rezult.Succeeded)
            {
                userManager.AddToRole(admin.Id, roleAdmin.Name);
                userManager.AddToRole(admin.Id, roleUser.Name);
            }
            base.Seed(context);
        }
    }
}
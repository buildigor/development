using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using WebStatistic.Models;

namespace WebStatistic.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private RoleManager<IdentityRole> _roleManager;
        public RoleManager<IdentityRole> RoleManager
        {
            get { return _roleManager ?? HttpContext.GetOwinContext().Get<RoleManager<IdentityRole>>(); }
            private set
            {
                _roleManager = value;
            }
        }
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = collection["roleName"]
                });
                _context.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(string roleName)
        {
            var thisRole = _context.Roles.FirstOrDefault(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            _context.Roles.Remove(thisRole);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string roleName)
        {
            var thisRole = _context.Roles.FirstOrDefault(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));

            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                _context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ManageUserRoles()
        {
            var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string userName, string roleName)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));
           // AccountController account = new AccountController {ControllerContext = ControllerContext};
            if (user != null) UserManager.AddToRole(user.Id, roleName);

            ViewBag.ResultMessage = string.Format("Role {0} for {1} created successfully!",roleName,user.UserName);
            var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(x => new SelectListItem { Value = x.Name.ToString(), Text = x.Name }).ToList();
            ViewBag.Roles = list;

            ViewBag.RolesForThisUser = UserManager.GetRolesAsync(user.Id).Result;
            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string userName, string roleName)
        {

            ApplicationUser user = _context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));

            if (user != null && UserManager.IsInRole(user.Id, roleName))
            {
                UserManager.RemoveFromRole(user.Id, roleName);
                ViewBag.ResultOfDeleteMessage = string.Format("Role {0} removed from user {1} successfully!",roleName,user.UserName);
            }
            else
            {
                ViewBag.ResultOfDeleteMessage = "This user doesn't belong to selected role.";
            }
            var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(x => new SelectListItem { Value = x.Name.ToString(), Text = x.Name }).ToList();
            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }
        
        public ActionResult UsersOfRole(string roleName)
        {
            var identityRole = _context.Roles.FirstOrDefault(x => x.Name == roleName);
            if (identityRole != null)
            {
                var roleId = identityRole.Id;
                var users = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(roleId)).Select(x=>x.UserName).ToList();
                ViewBag.Users = users;
            }
            return View("UsersInRole");
        }
    }
}
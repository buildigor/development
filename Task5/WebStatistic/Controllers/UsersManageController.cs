using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebStatistic.Models;

namespace WebStatistic.Controllers
{
    public class UsersManageController : Controller
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
        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        // GET: UsersManage
        public  ActionResult Index()
        {
            return View(UserManager.Users.ToList());
        }

        public  ActionResult Details(string id)
        {
            var user = UserManager.FindById(id);
            ViewBag.Roles = UserManager.GetRoles(user.Id);
            return View(user);
        }

        public async Task<ActionResult> Create()
        {
            var roles = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Id");
            ViewBag.RoleId = roles;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel userRegisterViewModel, params string[] roles)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser(){UserName = userRegisterViewModel.Email,Email = userRegisterViewModel.Email};
                var result = UserManager.Create(user, userRegisterViewModel.Password);
                if (result.Succeeded)
                {
                    if (roles!=null)
                    {
                        var resultRole = await UserManager.AddToRolesAsync(user.Id, roles);
                        if (!resultRole.Succeeded)
                        {
                            ModelState.AddModelError("",resultRole.Errors.FirstOrDefault());
                            ViewBag.RoleId = new SelectList(RoleManager.Roles.ToList(), "Name", "Name");
                            return View();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.Errors.First());
                    ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
                    return View();
                }
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
            return View();
        }
    }
}
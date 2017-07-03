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

        public ActionResult Edit(string id)
        {
            var user = UserManager.FindById(id);
            var userRoles = UserManager.GetRoles(user.Id);
            ViewBag.UserName = user.UserName;
            ViewBag.UserRoles = userRoles;
            return View(new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
            });
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Email,Id")] EditUserViewModel editUser,params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindById(editUser.Id);
                user.UserName = editUser.Email;
                user.Email = editUser.Email;
                var userRoles = UserManager.GetRoles(user.Id);
                selectedRoles = selectedRoles ?? new string[] {};
                var result = UserManager.AddToRoles(user.Id, selectedRoles.Except(userRoles).ToArray<string>());
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                result = UserManager.RemoveFromRoles(user.Id, userRoles.Except(selectedRoles).ToArray<string>());
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            ApplicationUser user = UserManager.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteUser(string id)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindById(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                var result = UserManager.Delete(user);
                if (result.Succeeded) return RedirectToAction("Index");
                ModelState.AddModelError("", result.Errors.First());
                return View();
            }
            return View();
        }
    }
}
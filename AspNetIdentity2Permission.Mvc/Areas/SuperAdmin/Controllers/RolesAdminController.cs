using AspNetIdentity2Permission.Mvc.Controllers;
using AspNetIdentity2Permission.Mvc.Models;
using AutoMapper;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;


namespace AspNetIdentity2Permission.Mvc.Areas.SuperAdmin.Controllers
{

    public class RolesAdminController : BaseController
    {

        // GET: RolesAdmin
        [Description("角色列表")]
        public ActionResult Index(int index = 1)
        {
            var roles = _roleManager.Roles;
            var views = new List<RoleViewModel>();
            foreach (var role in roles)
            {
                var view = Mapper.Map<RoleViewModel>(role);
                views.Add(view);
            }
            return View(views.ToPagedList(index, 10));//显示角色清单
        }

        //异步读取角色详情
        // GET: /Roles/Details/5
        [Description("角色详情")]
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await _roleManager.FindByIdAsync(id);
            // 读取角色内的用户列表。
            var users = new List<ApplicationUser>();
            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }
            ViewBag.Users = users;
            ViewBag.UserCount = users.Count();
            var view = Mapper.Map<RoleViewModel>(role);
            return View(view);
        }

        //
        //读取角色创建
        // GET: /Roles/Create
        [Description("新建角色")]
        public ActionResult Create()
        {
            return View();
        }

        //异步写入角色创建
        // POST: /Roles/Create
        [Description("新建角色，保存")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = Mapper.Map<ApplicationRole>(roleViewModel);
                var roleresult = await _roleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        //异步读取角色编辑
        // GET: /Roles/Edit/Admin
        [Description("编辑角色")]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            var view = Mapper.Map<RoleViewModel>(role);
            return View(view);
        }

        //异步写入角色编辑
        // POST: /Roles/Edit/5
        [Description("编辑角色，保存")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Description,Name,Id")] RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(roleModel.Id);
                role.Name = roleModel.Name;
                role.Description = roleModel.Description;
                await _roleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        //异步读取角色删除
        // GET: /Roles/Delete/5
        [Description("删除角色")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            var view = Mapper.Map<RoleViewModel>(role);
            return View(view);
        }

        //异步写入角色删除
        // POST: /Roles/Delete/5
        [Description("删除角色，保存")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                var result = await _roleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
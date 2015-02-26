using AspNetIdentity2Permission.Mvc.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace AspNetIdentity2Permission.Mvc.Controllers
{
  
    public class RolesAdminController : BaseController
    {

        // GET: RolesAdmin
        [Description("角色列表")]
        public ActionResult Index()
        {
            return View(_roleManager.Roles);//显示角色清单
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
            return View(role);
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
        [Description("新建角色，提交")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole(roleViewModel.Name)
                    {
                        Description = roleViewModel.Description
                    };
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
            RoleViewModel roleModel = new RoleViewModel { Id = role.Id, Name = role.Name, Description = role.Description };
            return View(roleModel);
        }

        //异步写入角色编辑
        // POST: /Roles/Edit/5
        [Description("编辑角色，提交")]
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
            return View(role);
        }

        //异步写入角色删除
        // POST: /Roles/Delete/5
        [Description("删除角色，提交")]
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
using AspNetIdentity2Permission.Mvc.Models;
using AutoMapper;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace AspNetIdentity2Permission.Mvc.Controllers
{
    [Description("用户-角色维护")]
    public class UserRoleController : BaseController
    {

        // GET: UsersAdmin
        [Description("用户列表")]
        public async Task<ActionResult> Index(int index = 1)
        {
            var users = await _userManager.Users.ToListAsync();
            var views = new List<EditUserViewModel>();
            foreach (var user in users)
            {
                var view = Mapper.Map<EditUserViewModel>(user);
                views.Add(view);
            }
            return View(views.ToPagedList(index, 10));
        }

        //
        //异步读取用户详情
        //GET: /Users/Details/5
        [Description("用户详情")]
        public async Task<ActionResult> Details(string id)
        {
            //用户为空时返回400错误
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //按Id查找用户
            var user = await _userManager.FindByIdAsync(id);
            var view = Mapper.Map<EditUserViewModel>(user);
            ViewBag.RoleNames = await _userManager.GetRolesAsync(user.Id);

            return View(view);
        }

        //
        //异步读取用户创建
        //GET:/Users/Create
        [Description("新建用户")]
        public async Task<ActionResult> Create()
        {
            //读取角色列表
            ViewBag.RoleId = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
            return View();
        }
        //
        //异步写入用户创建
        // POST: /Users/Create
        [Description("新建用户，保存")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel userViewModel, params  string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = Mapper.Map<ApplicationUser>(userViewModel);
                var adminResult = await _userManager.CreateAsync(user, userViewModel.Password);

                //
                if (adminResult.Succeeded)
                {
                    if (selectedRoles != null)
                    {
                        var result = await _userManager.AddToRolesAsync(user.Id, selectedRoles);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First());
                            ViewBag.RoleId = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
                            return View();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", adminResult.Errors.First());
                    ViewBag.RoleId = new SelectList(_roleManager.Roles, "Name", "Name");
                    return View();
                }
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(_roleManager.Roles, "Name", "Name");
            return View();
        }

        //
        //读取用户编辑
        // GET: /Users/Edit/1
        [Description("编辑用户")]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var userRoles = await _userManager.GetRolesAsync(user.Id);
            var view = Mapper.Map<EditUserViewModel>(user);
            view.RolesList = _roleManager.Roles.ToList().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                });
            return View(view);
        }
        //
        //写入用户编辑
        // POST: /Users/Edit/5
        [Description("编辑用户，保存")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserName,Email,Id")]EditUserViewModel editUser, params string[] selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                //不允许修改用户名
                user.Email = editUser.Email;
                //更新用户信息
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                //更新角色
                var userRoles = await _userManager.GetRolesAsync(user.Id);
                selectedRole = selectedRole ?? new string[] { };
                result = await _userManager.AddToRolesAsync(user.Id, selectedRole.Except(userRoles).ToArray<string>());
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "操作失败。");
            return View();
        }

        //
        //读取用户删除
        // GET: /Users/Delete/5
        [Description("删除用户")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var view = Mapper.Map<EditUserViewModel>(user);
            return View(view);
        }
        //
        //写入角色删除
        // POST: /Users/Delete/5
        [Description("删除用户，保存")]
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
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                var result = await _userManager.DeleteAsync(user);
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
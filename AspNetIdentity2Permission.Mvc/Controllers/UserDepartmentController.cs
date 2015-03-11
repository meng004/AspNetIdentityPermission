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
    [Description("用户-部门维护")]
    public class UserDepartmentController : BaseController
    {

        // GET: UsersAdmin
        [Description("用户-部门列表")]
        public async Task<ActionResult> Index(int index = 1)
        {
            var users = await _userManager.Users.ToListAsync();
            var views = Mapper.Map<IList<EditUserDepartmentViewModel>>(users);

            return View(views.ToPagedList(index, 10));
        }

        //
        //异步读取用户详情
        //GET: /Users/Details/5
        [Description("用户-部门详情")]
        public async Task<ActionResult> Details(string id)
        {
            //用户为空时返回400错误
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //按Id查找用户
            var user = await _userManager.FindByIdAsync(id);
            var view = Mapper.Map<EditUserDepartmentViewModel>(user);
            var departmentIds = user.Departments.Select(d => d.DepartmentId);

            ViewBag.DepartmentNames = departmentIds.Select(t => _db.Departments.Find(t).Name).ToList();

            return View(view);
        }

        //
        //读取用户编辑
        // GET: /Users/Edit/1
        [Description("编辑用户-部门")]
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
            //取部门名称
            var departmentIds = user.Departments.Select(d => d.DepartmentId).ToList();

            var view = Mapper.Map<EditUserDepartmentViewModel>(user);
            //部门是否选中
            view.DepartmentList = _db.Departments.ToList().Select(x => new SelectListItem()
                {
                    Selected = departmentIds.Contains(x.Id),
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            return View(view);
        }
        //
        //写入用户编辑
        // POST: /Users/Edit/5
        [Description("编辑用户-部门，保存")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserName,Email,Id")]EditUserDepartmentViewModel editUser, params int[] selectedDepartments)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                //删除现在所属部门
                var departments = user.Departments.ToList();
                departments.Each(t => _db.Set<UserDepartment>().Remove(t));
                
                //新增所属部门
                selectedDepartments = selectedDepartments ?? new int[] { };                
                selectedDepartments.Each(departmentId =>
                {
                    var userDepartment = new UserDepartment { ApplicationUserId = user.Id, DepartmentId = departmentId };
                    _db.Set<UserDepartment>().Add(userDepartment);
                });

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "操作失败。");
            return View();
        }

    }
}
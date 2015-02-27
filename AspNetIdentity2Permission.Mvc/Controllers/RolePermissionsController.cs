using AspNetIdentity2Permission.Mvc.Models;
using AutoMapper;
using Infragistics.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetIdentity2Permission.Mvc.Controllers
{
    public class RolePermissionsController : BaseController
    {
        // GET: RolePermissions
        [Description("角色-权限列表")]
        public ActionResult Index(string roleId)
        {
            //取role列表
            var roles = _roleManager.Roles.ToList();
            //roleId是否为空
            if (string.IsNullOrWhiteSpace(roleId))
            {
                //取第一个role的id
                roleId = roles.FirstOrDefault().Id;
            }
            //放入viewbag，设置默认值
            ViewBag.RoleID = new SelectList(roles, "ID", "Name", roleId);
            //取角色权限列表
            var permissions = _roleManager.GetRolePermissions(roleId);
            //创建ViewModel
            var permissionViews = new List<PermissionViewModel>();

            //var map = Mapper.CreateMap<ApplicationPermission, PermissionViewModel>();
            permissions.Each(t =>
            {
                var view = Mapper.Map<PermissionViewModel>(t);
                view.RoleId = roleId;
                permissionViews.Add(view);
            });
            //排序
            permissionViews.Sort(new PermissionViewModelComparer());
            return View(permissionViews);
        }

        // GET: RolePermissions/Details/5
        [Description("角色-权限详情")]
        public async Task<ActionResult> Details(string roleId, string permissionId)
        {
            if (string.IsNullOrWhiteSpace(roleId) || string.IsNullOrWhiteSpace(permissionId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //取权限
            ApplicationPermission applicationPermission = _db.Permissions.Find(permissionId);
            //取角色
            var role = await _roleManager.FindByIdAsync(roleId);
            if (applicationPermission == null)
            {
                return HttpNotFound();
            }
            var view = Mapper.Map<PermissionViewModel>(applicationPermission);
            view.RoleId = roleId;
            view.RoleName = role.Name;

            return View(view);
        }

        // POST: RolePermissions/Create
        [Description("新建角色-权限,列表")]
        [GridDataSourceAction]
        public ActionResult Create(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var roles = _roleManager.Roles.ToList();
            ViewBag.RoleID = new SelectList(roles, "ID", "Name", roleId);

            //取角色权限ID
            var rolePermissions = _roleManager.GetRolePermissions(roleId);
            //取全部权限与角色权限的差集
            var allPermission = _db.Permissions.ToList();
            var permissions = allPermission.Except(rolePermissions, new ApplicationPermissionEqualityComparer());
            //创建ViewModel
            var permissionViews = new List<PermissionViewModel>();
            permissions.Each(t =>
            {
                var view = Mapper.Map<PermissionViewModel>(t);

                permissionViews.Add(view);
            });
            //排序
            permissionViews.Sort(new PermissionViewModelComparer());
            return View(permissionViews.AsQueryable());
        }

        // POST: RolePermissions/Edit/5
        [Description("新建角色-权限，保存")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string roleId, IEnumerable<ApplicationPermission> data)
        {
            if (string.IsNullOrWhiteSpace(roleId) || data.Count() == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //添加Permission
            foreach (var item in data)
            {
                var permission = new ApplicationRolePermission
                {
                    RoleId = roleId,
                    PermissionId = item.Id
                };
                //方法1,用set<>().Add()
                _db.Set<ApplicationRolePermission>().Add(permission);
            }
            //保存;
            var records = await _db.SaveChangesAsync();
            //方法1，用JsonResult类封装，格式为Json，客户端直接使用
            var response = new Dictionary<string, bool>();
            response.Add("Success", true);
            return new JsonResult { Data = response };
        }

        // GET: RolePermissions/Delete/5
        [Description("删除角色-权限")]
        public async Task<ActionResult> Delete(string roleId, string permissionId)
        {
            if (string.IsNullOrWhiteSpace(roleId) || string.IsNullOrWhiteSpace(permissionId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationPermission applicationPermission = _db.Permissions.Find(permissionId);
            var role = await _roleManager.FindByIdAsync(roleId);
            if (applicationPermission == null)
            {
                return HttpNotFound();
            }
            //创建viewModel
            var view = Mapper.Map<PermissionViewModel>(applicationPermission);
            view.RoleId = roleId;
            view.RoleName = role.Name;

            return View(view);
        }

        // POST: RolePermissions/Delete/5
        [Description("删除角色-权限，保存")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string roleId, string permissionId)
        {
            if (string.IsNullOrWhiteSpace(roleId) || string.IsNullOrWhiteSpace(permissionId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                //验证role与permission
                var role = await _roleManager.FindByIdAsync(roleId);
                var permission = _db.Permissions.Find(permissionId);
                if (role == null || permission == null)
                {
                    return HttpNotFound();
                }
                //删除Permission
                var entity = new ApplicationRolePermission { RoleId = roleId, PermissionId = permissionId };
                _db.Set<ApplicationRolePermission>().Attach(entity);
                _db.Entry(entity).State = EntityState.Deleted;

                var result = await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { roleId = roleId });
        }
    }
}

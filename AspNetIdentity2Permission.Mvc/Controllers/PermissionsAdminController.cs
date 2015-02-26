using AspNetIdentity2Permission.Mvc.Models;
using AutoMapper;
using Infragistics.Web.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace AspNetIdentity2Permission.Mvc.Controllers
{
    public class PermissionsAdminController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            //var roleViews = await GetRoleViews();
            //ViewBag.RoleID = new SelectList(roleViews, "ID", "Name", roleViews.FirstOrDefault().Id);
            var permissions = await _db.Permissions.ToListAsync();
            //创建ViewModel
            var permissionViews = new List<PermissionViewModel>();

            var map = Mapper.CreateMap<ApplicationPermission, PermissionViewModel>();
            permissions.Each(t =>
            {
                var view = Mapper.Map<PermissionViewModel>(t);

                permissionViews.Add(view);
            });
            //排序
            permissionViews.Sort(new PermissionViewModelComparer());
            return View(permissionViews);
        }

        // GET: PermissionsAdmin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationPermission applicationPermission = _db.Permissions.Find(id);
            if (applicationPermission == null)
            {
                return HttpNotFound();
            }
            return View(applicationPermission);
        }

        // GET: PermissionsAdmin/Create
        [GridDataSourceAction]
        public ActionResult Create()
        {
            //创建ViewModel
            var permissionViews = new List<PermissionViewModel>();
            //取Permission
            var permissions = _permissionsOfAssembly;
            var map = Mapper.CreateMap<ApplicationPermission, PermissionViewModel>();
            permissions.Each(t =>
            {
                var view = Mapper.Map<PermissionViewModel>(t);

                permissionViews.Add(view);
            });
            //排序
            permissionViews.Sort(new PermissionViewModelComparer());

            return View(permissionViews.AsQueryable());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IEnumerable<PermissionViewModel> data)
        {
            if (data == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "参数不能为空");
            }
            foreach (var item in data)
            {
                //创建权限
                var permission = new ApplicationPermission
                {
                    Id = item.Id,
                    Action = item.Action,
                    Controller = item.Controller,
                    Description = item.Description
                };
                _db.Permissions.Add(permission);
            }
            //保存
            await _db.SaveChangesAsync();
            //返回消息
            JsonResult result = new JsonResult();
            Dictionary<string, bool> response = new Dictionary<string, bool>();
            response.Add("Success", true);
            result.Data = response;
            return result;
        }

        // GET: PermissionsAdmin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationPermission applicationPermission = _db.Permissions.Find(id);
            if (applicationPermission == null)
            {
                return HttpNotFound();
            }
            return View(applicationPermission);
        }

        // POST: PermissionsAdmin/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Controller,Action,Params,Description")] ApplicationPermission applicationPermission)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(applicationPermission).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationPermission);
        }

        // GET: PermissionsAdmin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationPermission applicationPermission = _db.Permissions.Find(id);
            if (applicationPermission == null)
            {
                return HttpNotFound();
            }
            return View(applicationPermission);
        }

        // POST: PermissionsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationPermission applicationPermission = _db.Permissions.Find(id);
            _db.Permissions.Remove(applicationPermission);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

using AspNetIdentity2Permission.Mvc.Models;
using System.ComponentModel;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using AutoMapper;
using System.Collections.Generic;
using AspNetIdentity2Permission.Mvc.Controllers;

namespace AspNetIdentity2Permission.Mvc.Areas.SuperAdmin.Controllers
{
    public class DepartmentController : BaseController
    {

        // GET: /Department/
        [Description("部门列表")]
        public async Task<ActionResult> Index(int index = 1)
        {
            var departments = await _db.Departments.ToListAsync();
            var views = Mapper.Map<IList<DepartmentViewModel>>(departments);
            //分页
            return View(views.ToPagedList(index, 10));
        }


        // GET: /Department/Details/5
        [Description("部门详情")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await _db.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            var view = Mapper.Map<DepartmentViewModel>(department);
            return View(view);
        }

        // GET: /Department/Create
        [Description("新建部门")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Department/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Description("新建部门，保存")]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Add(department);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var view = Mapper.Map<DepartmentViewModel>(department);
            return View(view);
        }

        // GET: /Department/Edit/5
        [Description("编辑部门")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await _db.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            var view = Mapper.Map<DepartmentViewModel>(department);
            return View(view);
        }

        // POST: /Department/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Description("编辑部门，保存")]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(department).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var view = Mapper.Map<DepartmentViewModel>(department);
            return View(view);
        }

        // GET: /Department/Delete/5
        [Description("删除部门")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await _db.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            var view = Mapper.Map<DepartmentViewModel>(department);
            return View(view);
        }

        // POST: /Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Description("删除部门，保存")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Department department = await _db.Departments.FindAsync(id);
            _db.Departments.Remove(department);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}

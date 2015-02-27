using AspNetIdentity2Permission.Mvc.Models;
using AspNetIdentity2Permission.Mvc.Services;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity2Permission.Mvc.Controllers
{
    /// <summary>
    /// 基础类
    /// </summary>
    [IdentityAuthorize(Roles="管理员")]
    public abstract class BaseController : Controller
    {
        public BaseController()
        {

        }
        public BaseController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private ApplicationUserManager userManager;
        protected ApplicationUserManager _userManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        private ApplicationRoleManager roleManager;
        protected ApplicationRoleManager _roleManager
        {
            get
            {
                return roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                roleManager = value;
            }
        }

        private ApplicationDbContext db;
        protected ApplicationDbContext _db
        {
            get
            {
                return db ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
            private set
            {
                db = value;
            }
        }
        /// <summary>
        /// 缓存key
        /// </summary>
        const string _permissionKey = "PermissionsOfAssembly";
        /// <summary>
        /// 程序集中权限集合
        /// </summary>
        protected IEnumerable<ApplicationPermission> _permissionsOfAssembly
        {
            get
            {
                var permissions = HttpContext.Application.Get(_permissionKey) as IEnumerable<ApplicationPermission>;
                if (permissions == null)
                {
                    //取程序集中全部权限
                    permissions = ActionPermissionService.GetAllActionByAssembly();
                    //添加到缓存
                    HttpContext.Application.Add(_permissionKey, permissions);
                }
                return permissions;
            }
        }
    }
}
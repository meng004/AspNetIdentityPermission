using AspNetIdentity2Permission.Mvc.Models;
using AspNetIdentity2Permission.Mvc.Services;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;


namespace AspNetIdentity2Permission.Mvc
{
    /// <summary>
    /// 访问授权验证
    /// </summary>
    [Description("验证访问权限")]
    public class IdentityAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 授权上下文
        /// </summary>
        private AuthorizationContext _filterContext;

        #region 重写父类方法
        /// <summary>
        /// 重写授权验证方法
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            _filterContext = filterContext;
            base.OnAuthorization(filterContext);
        }
        /// <summary>
        /// 重写核心验证方法
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //取父类的验证结果
            var result = base.AuthorizeCore(httpContext);
            //如果验证未通过，则调用访问验证逻辑
            if (!result)
            {
                return HasPermission(_filterContext);
            }
            return result;
        }
        #endregion

        #region 帮助方法
        /// <summary>
        /// 当前请求是否具有访问权限
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        private bool HasPermission(AuthorizationContext filterContext)
        {
            //取当前用户的权限            
            var rolePermissions = GetUserPermissions(filterContext.HttpContext);
            //待访问的Action的Permission
            var action = new ApplicationPermission
            {
                Action = filterContext.ActionDescriptor.ActionName,
                Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Description = ActionPermissionService.GetDescription(filterContext.ActionDescriptor)
            };
            //是否授权
            return rolePermissions.Contains(action, new ApplicationPermissionEqualityComparer());
        }

        /// <summary>
        /// 取当前用户的权限列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private IEnumerable<ApplicationPermission> GetUserPermissions(HttpContextBase context)
        {
            //取登录名
            var username = context.User.Identity.Name;
            //构建缓存key
            var key = string.Format("UserPermissions_{0}", username);
            //从缓存中取权限
            var permissions = HttpContext.Current.Session[key]
                                as IEnumerable<ApplicationPermission>;
            //若没有，则从db中取并写入缓存
            if (permissions == null)
            {
                //取rolemanager
                var roleManager = context.GetOwinContext().Get<ApplicationRoleManager>();
                //取用户权限集合
                permissions = roleManager.GetUserPermissions(username);
                //写入缓存
                context.Session.Add(key, permissions);
            }
            return permissions;
        }

        #endregion
    }
}
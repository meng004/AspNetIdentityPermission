using AspNetIdentity2Permission.Mvc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AspNetIdentity2Permission.Mvc
{

    //配置此应用程序中使用的应用程序角色管理器。RoleManager 在 ASP.NET Identity 中定义，并由此应用程序使用。
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));
        }

        /// <summary>
        /// 获取角色的权限列表
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns>权限ID列表的IQueryable</returns>
        public IEnumerable<ApplicationPermission> GetRolePermissions(string roleId)
        {
            //取数据上下文
            var context = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>();
            //取角色
            var role = context.Roles.Include(r => r.Permissions).FirstOrDefault(t => t.Id == roleId);
            //取权限ID列表        
            var rolePermissionIds = role.Permissions.Select(t => t.PermissionId);
            //取权限列表
            var permissions = context.Permissions.Where(p => rolePermissionIds.Contains(p.Id)).ToList();
            return permissions;
        }

        /// <summary>
        /// 取用户的权限列表
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        public IEnumerable<ApplicationPermission> GetUserPermissions(string username)
        {
            //用户权限集合
            var userPermissions = new List<ApplicationPermission>();
            //取数据上下文
            var context = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>();
            //取用户
            var user = context.Users.Include(u => u.Roles)
                              .FirstOrDefault(t => t.UserName.ToUpper() == username.ToUpper());
            //取用户所属角色的所有权限
            foreach (var item in user.Roles)
            {
                //取角色权限
                var rolePermissions = GetRolePermissions(item.RoleId);
                //插入用户权限
                userPermissions.InsertRange(userPermissions.Count, rolePermissions);
            }
            return userPermissions;
        }

    }

    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //创建用户名为admin@123.com，密码为“Admin@123456”并把该用户添加到角色组"Admin"中
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name1 = "Admin";//用户名
            const string email1 = "admin@123.com";//邮箱
            const string password1 = "Admin@123456";//密码
            const string roleName1 = "Admin";//用户要添加到的角色组
            const string description1 = "管理员";
            const string name2 = "user";//用户名
            const string email2 = "user@123.com";//邮箱
            const string password2 = "User@123456";//密码
            const string roleName2 = "User";
            const string description2 = "普通用户";

            //如果没有Admin用户组则创建该组
            var role1 = roleManager.FindByName(roleName1);
            if (role1 == null)
            {
                role1 = new ApplicationRole() { Name = roleName1, Description = description1 };
                var roleresult = roleManager.Create(role1);
            }

            var role2 = roleManager.FindByName(roleName2);
            if (role2 == null)
            {
                role2 = new ApplicationRole() { Name = roleName2, Description = description2 };
                var roleresult = roleManager.Create(role2);
            }
            //如果没有admin@123.com用户则创建该用户
            var user1 = userManager.FindByName(name1);
            if (user1 == null)
            {
                user1 = new ApplicationUser
                {
                    UserName = name1,
                    Email = email1,
                    Password = password1,
                };
                var result = userManager.Create(user1, password1);
                result = userManager.SetLockoutEnabled(user1.Id, false);
            }

            var user2 = userManager.FindByName(name2);
            if (user2 == null)
            {
                user2 = new ApplicationUser
                {
                    UserName = name2,
                    Email = email2,
                    Password = password2,
                };
                var result = userManager.Create(user2, password2);
                result = userManager.SetLockoutEnabled(user2.Id, false);
            }

            // 把用户admin@123.com添加到用户组Admin中
            var rolesForUser1 = userManager.GetRoles(user1.Id);
            if (!rolesForUser1.Contains(role1.Name))
            {
                var result = userManager.AddToRole(user1.Id, role1.Name);
            }

            var rolesForUser2 = userManager.GetRoles(user2.Id);
            if (!rolesForUser2.Contains(role2.Name))
            {
                var result = userManager.AddToRole(user2.Id, role2.Name);
            }
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // 在此处插入电子邮件服务可发送电子邮件。
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // 在此处插入 SMS 服务可发送短信。
            return Task.FromResult(0);
        }
    }

    // 配置此应用程序中使用的应用程序用户管理器。UserManager 在 ASP.NET Identity 中定义，并由此应用程序使用。
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // 配置用户名的验证逻辑
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // 配置密码的验证逻辑
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // 配置用户锁定默认值
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // 注册双重身份验证提供程序。此应用程序使用手机和电子邮件作为接收用于验证用户的代码的一个步骤
            // 你可以编写自己的提供程序并将其插入到此处。
            manager.RegisterTwoFactorProvider("电话代码", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "你的安全代码是 {0}"
            });
            manager.RegisterTwoFactorProvider("电子邮件代码", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "安全代码",
                BodyFormat = "你的安全代码是 {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // 配置要在此应用程序中使用的应用程序登录管理器。
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

    }
}

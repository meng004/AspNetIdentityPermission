using System.Web.Mvc;

namespace AspNetIdentity2Permission.Mvc.Areas.SuperAdmin
{
    public class SuperAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SuperAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SuperAdmin_default",
                "SuperAdmin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, 
                new string[] {"AspNetIdentity2Permission.Mvc.Areas.SuperAdmin.Controllers"}
            );
        }
    }
}
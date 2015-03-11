using AspNetIdentity2Permission.Mvc.Models;
using System.ComponentModel;

namespace AspNetIdentity2Permission.Mvc
{
    [Description("AutoMapper配置")]
    public class AutoMapperProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationPermission, PermissionViewModel>();
            CreateMap<PermissionViewModel, ApplicationPermission>();
            CreateMap<ApplicationRole, RoleViewModel>();
            CreateMap<RoleViewModel, ApplicationRole>()
                .ForMember(
                            dest => dest.Id,
                            sour =>
                            {
                                sour.MapFrom(s => s.Id ?? System.Guid.NewGuid().ToString());
                            });

            CreateMap<ApplicationUser, EditUserRoleViewModel>();
            CreateMap<EditUserRoleViewModel, ApplicationUser>();
            CreateMap<ApplicationUser, EditUserDepartmentViewModel>();
            CreateMap<RegisterViewModel, ApplicationUser>();
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, Department>();
        }
    }

    [Description("AutoMapper匹配")]
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
        }
    }
}
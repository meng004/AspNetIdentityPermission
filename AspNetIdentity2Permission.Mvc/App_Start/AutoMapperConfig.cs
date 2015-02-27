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

            CreateMap<ApplicationUser, EditUserViewModel>();
            CreateMap<EditUserViewModel, ApplicationUser>();
            CreateMap<RegisterViewModel, ApplicationUser>();
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
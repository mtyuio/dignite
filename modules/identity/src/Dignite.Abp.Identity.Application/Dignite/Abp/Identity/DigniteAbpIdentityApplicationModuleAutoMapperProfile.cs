﻿using AutoMapper;
using Volo.Abp.Identity;

namespace Dignite.Abp.Identity
{
    public class DigniteAbpIdentityApplicationModuleAutoMapperProfile : Profile
    {
        public DigniteAbpIdentityApplicationModuleAutoMapperProfile()
        {

            CreateMap<IdentityRole, IdentityRoleDto>()
                .ForMember(r => r.ParentId, r => r.Ignore())
                .MapExtraProperties();

            CreateMap<OrganizationUnit, OrganizationUnitDto>()
                .ForMember(r => r.IsActive, r => r.Ignore())
                .ForMember(r => r.Position, r => r.Ignore())
                .ForMember(r => r.ChildrenCount, r => r.Ignore())
                .MapExtraProperties();
            CreateMap<OrganizationUnit, OrganizationUnitEditDto>()
                .ForMember(r => r.IsActive, r => r.Ignore())
                .MapExtraProperties();
        }
    }
}

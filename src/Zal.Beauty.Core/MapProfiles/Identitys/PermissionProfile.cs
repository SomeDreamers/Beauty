using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.ORM.Identitys;
using Zal.Beauty.Interface.Models.Results.Identitys;

namespace Zal.Beauty.Core.MapProfiles.Identitys
{
    /// <summary>
    /// 权限profile
    /// </summary>
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<RolePermission, RolePermissionResult>();
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.ORM.Identitys;
using Zal.Beauty.Interface.Models.Parameters.Identitys;
using Zal.Beauty.Interface.Models.Results.Identitys;

namespace Zal.Beauty.Core.MapProfiles.Identitys
{
    /// <summary>
    /// 角色profile
    /// </summary>
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleParameter, Role>();
            CreateMap<Role, RoleResult>();
            CreateMap<Role, RoleInfoResult>();
        }
    }
}

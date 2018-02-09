using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.Common;
using Zal.Beauty.Core.ORM.Identitys;
using Zal.Beauty.Interface.Models.Parameters.Identitys;
using Zal.Beauty.Interface.Models.Results.Identitys;

namespace Zal.Beauty.Core.MapProfiles.Identitys
{
    /// <summary>
    /// 用户profile
    /// </summary>
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserParameter, User>();
            CreateMap<User, UserResult>();
            CreateMap<EntitySet<User>, EntitySet<UserResult>>();
        }
    }
}

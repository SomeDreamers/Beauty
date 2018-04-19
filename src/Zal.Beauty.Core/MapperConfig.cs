﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.MapProfiles;
using Zal.Beauty.Core.MapProfiles.Identitys;
using Zal.Beauty.Core.MapProfiles.Commons;
using Zal.Beauty.Core.MapProfiles.Wechats;
using Zal.Beauty.Core.MapProfiles.Malls;

namespace Zal.Beauty.Core
{
    /// <summary>
    /// 对象映射配置
    /// </summary>
    public class MapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            //cfg.CreateMap<Pagination, PageSort>();

            #region Identity
            cfg.AddProfile<UserProfile>();
            cfg.AddProfile<RoleProfile>();
            #endregion

            #region Wechat
            cfg.AddProfile<CustomerProfile>();
            cfg.AddProfile<MessageProfile>();
            #endregion

            #region Mall
            cfg.AddProfile<BrandProfile>();
            #endregion

            cfg.AddProfile<TagProfile>();
            cfg.AddProfile<FileProfile>();

        }
    }
}

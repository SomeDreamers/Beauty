using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.MapProfiles;
using Zal.Beauty.Core.MapProfiles.Wechats;

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
            cfg.AddProfile<AccountProfile>();
            #endregion

            #region Wechat
            cfg.AddProfile<CustomerProfile>();
            #endregion
        }
    }
}

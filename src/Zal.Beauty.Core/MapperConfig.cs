using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.MapProfiles;

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
            cfg.AddProfile<AccountProfile>();
            cfg.AddProfile<TagProfile>();
        }
    }
}

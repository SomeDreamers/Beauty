using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Core;

namespace Zal.Beauty.WebApp
{
    public class MapperInitializer
    {
        public static void Initialize()
        {
            var cfg = new MapperConfigurationExpression();
            MapperConfig.Configure(cfg);
            Mapper.Initialize(cfg);
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.ORM.Malls;
using Zal.Beauty.Interface.Models.Results.Malls;
using Zal.Beauty.Interface.Models.Templates.Malls;

namespace Zal.Beauty.Core.MapProfiles.Malls
{
    /// <summary>
    /// 品牌profile
    /// </summary>
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandTemplate, Brand>();
            CreateMap<Brand, BrandResult>();
        }
    }
}

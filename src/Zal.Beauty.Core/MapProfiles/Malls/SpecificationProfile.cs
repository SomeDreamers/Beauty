using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.ORM.Malls;
using Zal.Beauty.Interface.Models.Parameters.Malls;
using Zal.Beauty.Interface.Models.Results.Malls;

namespace Zal.Beauty.Core.MapProfiles.Malls
{
    /// <summary>
    /// 规格profile
    /// </summary>
    public class SpecificationProfile : Profile
    {
        public SpecificationProfile()
        {
            CreateMap<SpecificationParameter, Specification>();
            CreateMap<Specification, SpecificationResult>();
        }
    }
}

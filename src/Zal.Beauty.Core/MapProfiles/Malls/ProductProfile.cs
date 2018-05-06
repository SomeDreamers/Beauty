using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.ORM.Malls;
using Zal.Beauty.Interface.Models.Parameters.Malls;
using Zal.Beauty.Interface.Models.Results.Malls;

namespace Zal.Beauty.Core.MapProfiles.Malls
{
    /// <summary>
    /// 商品profile
    /// </summary>
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResult>();
            CreateMap<ProductParameter, Product>();
            CreateMap<EntitySet<Product>, EntitySet<ProductResult>>();
        }
    }
}

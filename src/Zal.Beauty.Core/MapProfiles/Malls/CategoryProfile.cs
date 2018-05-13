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
    /// 商品分类profile
    /// </summary>
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryParameter, Category>();
            CreateMap<Category,CategoryResult>();
        }
    }
}

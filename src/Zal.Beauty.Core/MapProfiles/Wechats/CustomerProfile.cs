using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.ORM.Wechats;
using Zal.Beauty.Interface.Models.Parameters.Wechats;
using Zal.Beauty.Interface.Models.Results.Wechats;

namespace Zal.Beauty.Core.MapProfiles.Wechats
{
    /// <summary>
    /// 客户对象映射
    /// </summary>
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerParamater, Customer>();
            CreateMap<Customer, CustomerResult>();
            CreateMap<EntitySet<Customer>, EntitySet<CustomerResult>>();
        }
    }
}

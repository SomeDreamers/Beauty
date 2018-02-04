using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.ORM.Commons;
using Zal.Beauty.Core.ORM.Identitys;
using Zal.Beauty.Interface.Models.Parameters.Commons;
using Zal.Beauty.Interface.Models.Parameters.Identitys;
using Zal.Beauty.Interface.Models.Results.Commons;
using Zal.Beauty.Interface.Models.Results.Identitys;

namespace Zal.Beauty.Core.MapProfiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<TagParameter, Tag>();
            CreateMap<Tag, TagResult>();

        }


    }
}

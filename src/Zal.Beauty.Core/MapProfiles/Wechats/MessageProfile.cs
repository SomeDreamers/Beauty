using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.ORM.Wechats;
using Zal.Beauty.Interface.Models.Parameters.Wechats;
using Zal.Beauty.Interface.Models.Results.Wechats;

namespace Zal.Beauty.Core.MapProfiles.Wechats
{
    /// <summary>
    /// 微信消息映射
    /// </summary>
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageParameter, Message>();
            CreateMap<Message, MessageResult>();
        }
    }
}

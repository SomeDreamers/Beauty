using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.Common;
using Zal.Beauty.Core.ORM.Wechats;
using Zal.Beauty.Interface.Enums.Wechats;
using Zal.Beauty.Interface.IManager.Wechats;
using Zal.Beauty.Interface.Models.Parameters.Wechats;
using Zal.Beauty.Interface.Models.Results.Wechats;

namespace Zal.Beauty.Core.Managers.Wechats
{
    /// <summary>
    /// 消息manager
    /// </summary>
    public class MessageManager : IMessageManager
    {
        private readonly ApplicationDbContext context;

        public MessageManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 保存消息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task SaveAsync(MessageParameter parameter)
        {
            var message = Mapper.Map<Message>(parameter);
            context.Messages.Add(message);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 保存消息(同步)
        /// </summary>
        /// <param name="parameter"></param>
        public void Save(MessageParameter parameter)
        {
            var message = Mapper.Map<Message>(parameter);
            context.Messages.Add(message);
            context.SaveChanges();
        }

        /// <summary>
        /// 获取消息集合
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns></returns>
        public async Task<EntitySet<MessageResult>> GetMessageSetAsync(MessageQuery queryParameter)
        {
            var query = context.Messages.AsQueryable();
            if (queryParameter.MsgSource == 1)
                query = query.Where(c => c.FromUserId > 0);
            else if(queryParameter.MsgSource == 2)
                query = query.Where(c => c.ToUserId > 0);
            if (!string.IsNullOrEmpty(queryParameter.FromUserNick))
                query = query.Where(c => c.FromUserNick.Contains(queryParameter.FromUserNick));
            if (!string.IsNullOrEmpty(queryParameter.ToUserNick))
                query = query.Where(c => c.ToUserNick.Contains(queryParameter.ToUserNick));
            if (Enum.IsDefined(typeof(EMsgType), queryParameter.Type))
                query = query.Where(c => c.Type == queryParameter.Type);
            if (queryParameter.CreateBegin != DateTime.MinValue)
                query = query.Where(c => c.CreateTime >= queryParameter.CreateBegin);
            if (queryParameter.CreateEnd != DateTime.MinValue)
                query = query.Where(c => c.CreateTime <= queryParameter.CreateEnd);
            //默认按时间逆序
            query.OrderByDescending(c=>c.CreateTime);
            var cusSet = await query.ToEntitySetAsync(queryParameter);
            return Mapper.Map<EntitySet<MessageResult>>(cusSet);
        }
    }
}

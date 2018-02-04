using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Core.ORM.Wechats;
using Zal.Beauty.Interface.IManager.Wechats;
using Zal.Beauty.Interface.Models.Parameters.Wechats;

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
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Interface.Models.Parameters.Wechats;

namespace Zal.Beauty.Interface.IManager.Wechats
{
    /// <summary>
    /// 消息接口
    /// </summary>
    public interface IMessageManager
    {
        /// <summary>
        /// 保存消息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task SaveAsync(MessageParameter parameter);

        /// <summary>
        /// 保存消息(同步)
        /// </summary>
        /// <param name="parameter"></param>
        void Save(MessageParameter parameter);
    }
}

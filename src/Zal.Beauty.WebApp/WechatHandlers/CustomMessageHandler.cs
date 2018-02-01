using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Interface.Enums.Wechats;
using Zal.Beauty.Interface.IManager.Wechats;
using Zal.Beauty.Interface.Models.Parameters.Wechats;

namespace Zal.Beauty.WebApp.WechatHandlers
{
    /// <summary>
    /// 微信消息处理器
    /// </summary>
    public class CustomMessageHandler : MessageHandler<CustomMessageContext>
    {
        private readonly ICustomerManager customerManager;
        private readonly IMessageManager messageManager;
        public CustomMessageHandler(Stream inputStream, PostModel postModel, ICustomerManager customerManager, IMessageManager messageManager)
            : base(inputStream, postModel)
        {
            this.customerManager = customerManager;
            this.messageManager = messageManager;
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>(); //ResponseMessageText也可以是News等其他类型
            responseMessage.Content = "您好，我们已接收到您发送的消息，很快会给您回复！"; //默认消息
            return responseMessage;
        }

        /// <summary>
        /// 接收图片
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = string.Format("您好，我们已接收到您发送的消息，很快会给您回复！");
            //获取发送用户信息
            var customer = customerManager.GetCustomerByOpenId(requestMessage.FromUserName);
            //存储消息
            MessageParameter parameter = new MessageParameter
            {
                Type = EMsgType.Image,
                Content = "",
                FromUserId = customer == null ? 0 : customer.Id,
                FromUserName = requestMessage.FromUserName,
                ToUserName = requestMessage.ToUserName,
                MediaId = requestMessage.MediaId,
                PicUrl = requestMessage.PicUrl,

            };
            messageManager.Save(parameter);
            return responseMessage;
        }

        /// <summary>
        /// 接收文本
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = string.Format("您好，我们已接收到您发送的消息，很快会给您回复！");
            //获取发送用户信息
            var customer = customerManager.GetCustomerByOpenId(requestMessage.FromUserName);
            //存储消息
            MessageParameter parameter = new MessageParameter
            {
                Type = EMsgType.Text,
                Content = requestMessage.Content,
                FromUserId = customer == null ? 0 : customer.Id,
                FromUserName = requestMessage.FromUserName,
                ToUserName = requestMessage.ToUserName
            };
            messageManager.Save(parameter);
            return responseMessage;
        }

        /// <summary>
        /// 接收事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEventRequest(IRequestMessageEventBase requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = string.Format("推送事件");
            return responseMessage;
        }
    }
}

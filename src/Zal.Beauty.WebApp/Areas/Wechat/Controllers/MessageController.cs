using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin;
using Senparc.Weixin.CommonAPIs;
using Senparc.Weixin.MP.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.ORM.Wechats;
using Zal.Beauty.Interface.Enums.Wechats;
using Zal.Beauty.Interface.IManager.Wechats;
using Zal.Beauty.Interface.Models.Parameters.Wechats;
using Zal.Beauty.WebApp.Configs;

namespace Zal.Beauty.WebApp.Areas.Wechat.Controllers
{
    /// <summary>
    /// 消息Controller
    /// </summary>
    [Area("Wechat"), Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageManager messageManager;
        public MessageController(IMessageManager messageManager)
        {
            this.messageManager = messageManager;
        }

        /// <summary>
        /// 消息列表界面
        /// </summary>
        /// <returns></returns>
        public IActionResult List(int MsgSource = 1)
        {
            ViewData["MsgSource"] = MsgSource;
            return View();
        }

        /// <summary>
        /// 获取消息数据ajax
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IActionResult> MsgSetAjax(MessageQuery query)
        {
            var msgSet = await messageManager.GetMessageSetAsync(query);
            return Json(msgSet);
        }

        /// <summary>
        /// 回复消息
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ReplayMessage(long messageId, string content)
        {
            var message = await messageManager.GetMessageByIdAsync(messageId);
            //构建发送消息
            MessageParameter sendMessage = new MessageParameter
            {
                ToUserId = message.FromUserId,
                Type = EMsgType.Text,
                Content = content,
                FromUserName = message.ToUserName,
                ToUserName = message.FromUserName,
                ToUserNick = message.FromUserNick,
                CreateTime = DateTime.Now
            };
            //获取accessToken
            var accessToken = AccessTokenContainer.TryGetAccessToken(WeixinConfig.AppId, WeixinConfig.AppSecret);
            //发送消息
            var data = new
            {
                touser = sendMessage.ToUserName,
                msgtype = "text",
                text = new
                {
                    content = content
                }
            };
            var result = await CommonJsonSend.SendAsync(accessToken, WeixinConfig.URL_FORMAT, data);
            if(result.errcode != ReturnCode.请求成功)
            {
                return Json(new ReturnResult { IsSuccess = false, Message = result.errmsg });
            }
            //保存发送消息
            await messageManager.SaveAsync(sendMessage);
            return Json(new ReturnResult());
        }
    }
}

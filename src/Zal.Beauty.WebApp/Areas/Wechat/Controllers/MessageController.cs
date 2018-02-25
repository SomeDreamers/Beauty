using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Interface.IManager.Wechats;
using Zal.Beauty.Interface.Models.Parameters.Wechats;

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
        public IActionResult List(int MegSource = 1)
        {
            ViewData["MegSource"] = MegSource;
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
    }
}

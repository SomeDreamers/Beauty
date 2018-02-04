using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.WebApp.Areas.Identity.Helpers;
using Zal.Beauty.WebApp.Configs;

namespace Zal.Beauty.WebApp.Filters
{
    /// <summary>
    /// OAuth自动验证，可以加在Action或整个Controller上
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CustomerOAuthAttribute : ActionFilterAttribute
    {
        protected string _appId { get; set; }
        protected string _oauthCallbackUrl { get; set; }
        protected OAuthScope _oauthScope { get; set; }
        public CustomerOAuthAttribute(string appId = null, string oauthCallbackUrl = null, OAuthScope oauthScope = OAuthScope.snsapi_userinfo)
        {
            _appId = appId ?? WeixinConfig.AppId;
            _oauthCallbackUrl = oauthCallbackUrl ?? WeixinConfig.WeixinOAuthCallbackUrl;
            _oauthScope = oauthScope;
        }

        /// <summary>
        /// 验证登录等信息
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //首先读取用户登录的cookie信息进行判断
            string userCookie = "";
            if (context.HttpContext.Request.Cookies.TryGetValue(ConstKeys.WechatSessionKey, out userCookie))
            {
                base.OnActionExecuting(context);
            }
            else
            {
                var state = ConstKeys.WechatState;//随机数，用于识别请求可靠性
                context.HttpContext.Response.Cookies.Append("state", state);//储存随机数到cookie
                var callbackUrl = Senparc.Weixin.HttpUtility.UrlUtility.GenerateOAuthCallbackUrl(context.HttpContext, _oauthCallbackUrl);
                var url = OAuthApi.GetAuthorizeUrl(_appId, callbackUrl, state, _oauthScope);
                context.Result = new RedirectResult(url);
            }
        }


    }
}

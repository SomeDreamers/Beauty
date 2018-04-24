using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Base.Enums;
using Zal.Beauty.Base.Utils;
using Zal.Beauty.Interface.IManager.Wechats;
using Zal.Beauty.Interface.Models.Parameters.Wechats;
using Zal.Beauty.WebApp.Configs;

namespace Zal.Beauty.WebApp.Controllers
{
    /// <summary>
    /// 微信认证Controller
    /// </summary>
    public class OAuth2Controller : Controller
    {
        public ICustomerManager customerManager { get; set; }
        public OAuth2Controller(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }

        /// <summary>
        /// 认证授权
        /// </summary>
        /// <param name="returnUrl">用户尝试进入的需要登录的页面</param>
        /// <returns></returns>
        public ActionResult Index(string returnUrl)
        {
            var state = ConstKeys.WechatState;//随机数，用于识别请求可靠性
            HttpContext.Response.Cookies.Append("state", state);//储存随机数到cookie

            ViewData["returnUrl"] = returnUrl;

            //此页面引导用户点击授权
            ViewData["UrlUserInfo"] =
                OAuthApi.GetAuthorizeUrl(WeixinConfig.AppId,
                "http://sdk.weixin.senparc.com/oauth2/UserInfoCallback?returnUrl=" + returnUrl.UrlEncode(),
                state, OAuthScope.snsapi_userinfo);
            return View();
        }

        /// <summary>
        /// OAuthScope.snsapi_userinfo方式回调
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <param name="returnUrl">用户最初尝试进入的页面</param>
        /// <returns></returns>
        public async Task<ActionResult> UserInfoCallbackAsync(string code, string state, string returnUrl)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }
            var cookisState = "";
            if (!HttpContext.Request.Cookies.TryGetValue("state", out cookisState) || state != cookisState)
            {
                //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下，
                //建议用完之后就清空，将其一次性使用
                //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                return Content("验证失败！请从正规途径进入！");
            }

            OAuthAccessTokenResult result = null;

            //通过，用code换取access_token
            try
            {
                result = OAuthApi.GetAccessToken(WeixinConfig.AppId, WeixinConfig.AppSecret, code);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            if (result.errcode != ReturnCode.请求成功)
            {
                return Content("错误：" + result.errmsg);
            }
            //下面2个数据也可以自己封装成一个类，储存在数据库中（建议结合缓存）
            //如果可以确保安全，可以将access_token存入用户的cookie中，每一个人的access_token是不一样的
            //Session["OAuthAccessTokenStartTime"] = DateTime.Now;
            //Session["OAuthAccessToken"] = result;

            //因为第一步选择的是OAuthScope.snsapi_userinfo，这里可以进一步获取用户详细信息
            try
            {
                OAuthUserInfo wxUserInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                //验证通过注册用户信息
                CustomerParamater customer = new CustomerParamater
                {
                    Nick = wxUserInfo.nickname,
                    Openid = wxUserInfo.openid,
                    Unionid = wxUserInfo.unionid,
                    Sex = (ESexType)wxUserInfo.sex,
                    Country = wxUserInfo.country,
                    Province = wxUserInfo.province,
                    City = wxUserInfo.city,
                    Icon = wxUserInfo.headimgurl,
                    CreateTime = DateTime.Now
                };
                var returnResult = await customerManager.AddCustomerAsync(customer);

                HttpContext.Response.Cookies.Append(ConstKeys.WechatSessionKey, CommonUtil.SerializeObject(customer));

                //跳转连接
                return Redirect(string.IsNullOrEmpty(returnUrl) ? WeixinConfig.WeixinHomeUrl : returnUrl);
            }
            catch (ErrorJsonResultException ex)
            {
                return Content(ex.Message);
            }
        }
    }
}

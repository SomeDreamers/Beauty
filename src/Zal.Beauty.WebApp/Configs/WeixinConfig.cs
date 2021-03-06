﻿using Senparc.Weixin.MP.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zal.Beauty.WebApp.Configs
{
    /// <summary>
    /// 微信配置类
    /// </summary>
    public class WeixinConfig
    {
        public static readonly string Token = "9F89C84A559F573636A47FF8DAED0D33";//与微信公众账号后台的Token设置保持一致，区分大小写。
        public static readonly string EncodingAESKey = null;//与微信公众账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string AppId = "wx8dbc3c0e83df87fe";//与微信公众账号后台的AppId设置保持一致，区分大小写。
        public static readonly string AppSecret = "39fc0d777bdd271e3e1e587a1119a5b6";

        public static readonly string WeixinOAuthCallbackUrl = "/Oauth2/UserInfoCallbackAsync";
        public static readonly string WeixinHomeUrl = "/Shelf/Index";

        public const string URL_FORMAT = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";

        public static void RegistWeixinAppMsg()
        {
            AccessTokenContainer.Register(AppId, AppSecret);
        }
    }
}

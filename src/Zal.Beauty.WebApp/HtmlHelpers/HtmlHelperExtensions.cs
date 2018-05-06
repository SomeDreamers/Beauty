using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.WebApp.Configs;

namespace Zal.Beauty.WebApp.HtmlHelpers
{
    /// <summary>
    /// HTML helper 扩展标签
    /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// 页面标题
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static HtmlString PageTitle(this IHtmlHelper helper)
        {
            Node quote1st = null;
            foreach (var Node1st in PermissionKeysMvcSetting.Nodes)
            {
                quote1st = new Node { Title = Node1st.Title, Route = Node1st.Route };
                Node quote2nd = null;
                foreach (var Node2st in Node1st.ChildNodes)
                {
                    quote2nd = new Node { Title = Node2st.Title, Route = Node2st.Route };
                    foreach (var Node3rd in Node2st.ChildNodes)
                    {
                        if (Node3rd.Route == helper.ViewContext.HttpContext.Request.Path)
                        {
                            return new HtmlString($"{quote1st.Title}-{quote2nd.Title}");
                        }
                    }
                }
            }
            return new HtmlString($"首页");
        }

        /// <summary>
        /// 视图路由标签
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static HtmlString BlockQuote(this IHtmlHelper helper, bool isNeedBackBtn = false, string href = "/Home/Index")
        {
            Node homeQuote = new Node { Title = "首页", Route = "/Home/Index" };
            Node quote1st = null;
            foreach (var Node1st in PermissionKeysMvcSetting.Nodes)
            {
                quote1st = new Node { Title = Node1st.Title, Route = Node1st.Route };
                Node quote2nd = null;
                foreach (var Node2st in Node1st.ChildNodes)
                {
                    quote2nd = new Node { Title = Node2st.Title, Route = Node2st.Route };
                    foreach (var Node3rd in Node2st.ChildNodes)
                    {
                        if (Node3rd.Route == helper.ViewContext.HttpContext.Request.Path)
                        {
                            return new HtmlString($"<div class=\"breadcrumb-env\">" +
                                $"<ol class=\"breadcrumb bc-1\" style=\"margin-bottom: 5px;\">" +
                                $"<li><a href=\"{homeQuote.Route}\"><i class=\"fa-home\"></i>{homeQuote.Title}</a></li>" +
                                $"<li><a href=\"{quote1st.Route}\">{quote1st.Title}</a></li>" +
                                $"<li><a href=\"{quote2nd.Route}\">{quote2nd.Title}</a></li>" +
                                $"<li class=\"active\"><strong>{Node3rd.Title}</strong></li>" + 
                                (isNeedBackBtn ? $"<button onclick=\"window.location.href='{href}'\" class=\"btn btn-primary btn-sm btn-icon\" style=\"float: right;\">返回</button>" : "") + 
                                "</ol></div>");
                        }
                    }
                }
            }
            return new HtmlString($"");
        }
    }
}

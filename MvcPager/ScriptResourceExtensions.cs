/*
 ASP.NET MvcPager 分页组件
 Copyright:2009-2013 陕西省延安市吴起县 杨涛\Webdiyer (http://www.webdiyer.com)
 Source code released under Ms-PL license
 */
using System.Web.Mvc;
using System.Web.UI;
namespace Webdiyer.WebControls.Mvc
{
    public static class ScriptResourceExtensions
    {
        public static void RegisterMvcPagerScriptResource(this HtmlHelper html)
        {
            var page = html.ViewContext.HttpContext.CurrentHandler as Page;
            var scriptUrl = (page ?? new Page()).ClientScript.GetWebResourceUrl(typeof(PagerHelper), "Webdiyer.WebControls.Mvc.MvcPager.min.js");
            html.ViewContext.Writer.Write("<script type=\"text/javascript\" src=\"" + scriptUrl + "\"></script>");
        }
    }
}
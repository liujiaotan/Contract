/*
 ASP.NET MvcPager 分页组件
 Copyright:2009-2013 陕西省延安市吴起县 杨涛\Webdiyer (http://www.webdiyer.com)
 Source code released under Ms-PL license
 */
namespace Webdiyer.WebControls.Mvc
{
    public class MvcAjaxOptions : System.Web.Mvc.Ajax.AjaxOptions
    {
        public bool EnablePartialLoading { get; set; }
        public string DataFormId { get; set; }
    }
}
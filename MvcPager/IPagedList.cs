/*
ASP.NET MvcPager 分页组件
Copyright:2009-2013 陕西省延安市吴起县 杨涛\Webdiyer (http://www.webdiyer.com)
Source code released under Ms-PL license
*/
using System.Collections;
using System.Collections.Generic;
namespace Webdiyer.WebControls.Mvc
{
    public interface IPagedList : IEnumerable
    {
        int CurrentPageIndex { get; set; }
        int PageSize { get; set; }
        int TotalItemCount { get; set; }
    }
    public interface IPagedList<T> : IEnumerable<T>, IPagedList { }
}
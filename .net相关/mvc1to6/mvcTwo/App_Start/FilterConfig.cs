using System.Web;
using System.Web.Mvc;

using mvcTwo.Filters;

namespace mvcTwo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new EmployeeExceptionFilter());
        }
    }
}

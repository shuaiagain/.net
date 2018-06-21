using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using mvcTwo.Logger;

namespace mvcTwo.Filters
{
    public class EmployeeExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            FileLogger log = new FileLogger();

            log.LogException(filterContext.Exception);
            base.OnException(filterContext);
        }
    }
}
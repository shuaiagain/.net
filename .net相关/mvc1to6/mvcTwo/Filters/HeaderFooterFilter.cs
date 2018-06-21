using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mvcTwo.ViewModels;
using System.Web.Mvc;

namespace mvcTwo.Filters
{
    public class HeaderFooterFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            ViewResult v = filterContext.Result as ViewResult;
            if (v != null) // v will null when v is not a ViewResult
            {
                BaseViewModel bvm = v.Model as BaseViewModel;
                if (bvm != null)//bvm will be null when we want a view without Header and footer
                {
                    bvm.UserName = HttpContext.Current.User.Identity.Name;
                    bvm.FooterData = new FooterViewModel();
                    bvm.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
                    bvm.FooterData.Year = DateTime.Now.Year.ToString();
                }
            }
        }
    }
}
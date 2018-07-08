using System.Web.Mvc;

namespace mvcTwo.Areas.SPA
{
    public class SPAAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SPA";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SPA_default",
                "SPA/{controller}/{action}/{id}",
                new { controller="Main", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
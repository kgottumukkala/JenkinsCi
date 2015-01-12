using System.Web.Mvc;
using System.Web.Optimization;

namespace Chipotle.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
             name: "DeleteMember",
             url: "Admin/User/DeleteUser/{id}",
             defaults: new { controller = "User", action = "DeleteUser", id=UrlParameter.Optional }
               );
            RegisterBundles();
        }

        

        private void RegisterBundles ()
        {
            BundleConfig.RegisterBundles( BundleTable.Bundles );
        } 
    }
}
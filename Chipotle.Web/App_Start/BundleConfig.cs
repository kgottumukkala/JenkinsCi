using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Chipotle.Web
{
    internal static class BundleConfig
    {
        internal static void RegisterBundles ( BundleCollection bundles )
        {
            bundles.Add( new ScriptBundle( "~/bundles/jquery" ).Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/jquery-ui-{version}.js",
                         "~/Scripts/jquery.validate.min.js" )
                         );
            bundles.Add( new ScriptBundle( "~/bundles/modernizr" ).Include(
                       "~/Scripts/modernizr-*" ) );
            bundles.Add( new ScriptBundle( "~/bundles/bootstrap" ).Include(
                      "~/Scripts/bootstrap.js" ) );
            //bundles.Add( new ScriptBundle( "~/bundles/jqueryui" ).Include(
            //    "~/Scripts/jquery-ui-{version}.js") );
            //bundles.Add( new ScriptBundle( "~/bundles/jqueryvalidate" ).Include(
            //    "~/Scripts/jquery.validate.min.js" ) );
            //bundles.Add( new ScriptBundle( "~/bundles/flexigrid" ).Include(
            //    "~/Scripts/flexigrid.js" ).Include(
            //    "~/Scripts/flexigrid.pack.js" ) 
            //     );

            bundles.Add( new ScriptBundle( "~/bundles/knockout" ).Include(
                      "~/Scripts/knockout-{version}.js" ) );
            bundles.Add( new StyleBundle( "~/Content/css" ).Include(
                       "~/Content/bootstrap.css",
                       "~/Content/Site.css",
                       "~/Content/bootstrap-responsive.css",
                       "~/Content/Common.css",
                       
                       "~/Content/flexigrid/flexigrid.css" ) );


        }
    }
}
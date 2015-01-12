using Chipotle.Entity.Models;
using Chipotle.Web.ServiceClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Chipotle.Web.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        IServiceClient<Role> client = new RoleServiceClient();

        #region Controller Actions
        
        //
        // GET: /Admin/Role/
        public ActionResult Index ()
        {
            return View();
        }

        /// <summary>
        /// Api Call to Get all roles
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRoles ( string pageSize = "10", string pageNum = "1" )
        {
            try
            {
                var roles = client.Get();//Get all roles
                              
                return CreateFlexiJson( roles, Convert.ToInt32( pageNum ), roles.Count(), Convert.ToInt32( pageSize ) );
            }
            catch ( Exception ex )
            {
                return Json( "" );
            }

        }

        //
        // GET: /Admin/Role/Details/5
        public JsonResult Details ( int id )
        {
            var role = client.Get( id );
            return Json( role, JsonRequestBehavior.AllowGet );
        }

        //
        // GET: /Admin/Role/Create
        public ActionResult Create ()
        {
            return View();
        }

        //
        // POST: /Admin/Role/Create
        [HttpPost]
        public void Create ( Role role )
        {
            try
            {
                var added = client.Add( role );
               
            }
            catch
            {
                //return View();
            }
        }

        //
        // GET: /Admin/Role/Edit/5
        public ActionResult Edit ( int id )
        {
            var role = client.Get( id );
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.InitialData = serializer.Serialize( role );
            return View();
        }

        //
        // POST: /Admin/Role/Edit/5
        [HttpPost]
        public void Edit ( Role role )
        {
            try
            {
                // TODO: Add update logic here
                var edited = client.Update( role );
                //return Redirect( "~/admin/role" );
            }
            catch
            {
                //return Redirect( "~/admin/role" );
            }
        }

        //
        // GET: /Admin/Role/Delete/5
        public ViewResult Delete ( int id )
        {
            var role = client.Get( id );
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.InitialData = serializer.Serialize( role );
            return View();
        }

        //
        // POST: /Admin/Role/Delete/5
        [HttpPost]
        public void Delete ( int id, FormCollection collection = null )
        {
            try
            {

                // TODO: Add delete logic here
                var deleted = client.Delete( id );
                //return RedirectToAction("Index");
            }
            catch
            {
                //return View();
            }
        }

        #endregion
        
        #region Private Methods

        private JsonResult CreateFlexiJson ( List<Role> items, int page, int total, int pageSize )
        {

            int to = page * pageSize;
            int from = ( to - pageSize ) + 1;
            items = ( page == 1 ? items.Take( pageSize ) : items.Skip( (page - 1) * pageSize ).Take( pageSize ) ).ToList();
            return Json( new { totalRows = total, result = items }, JsonRequestBehavior.AllowGet );
        }

        #endregion
    }
}

using Chipotle.Entity.Models;
using Chipotle.Web.ServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Chipotle.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Admin/User/
        public ActionResult Index()
        {
            
            //return View(client.GetUsers());
            return View();
        }

        public JsonResult GetUsers()
        {
            IServiceClient<User> serviceClient = new UserServiceClient();
            return Json( "", JsonRequestBehavior.AllowGet );
        }

        //
        // GET: /Admin/User/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        //
        // GET: /Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return View(); 
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
           
            return View();
        }

        //
        // POST: /Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/User/Delete/5
        //[HttpPost]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                // TODO: Add delete logic here
                return View();
               
            }
            catch
            {
                return View();
            }
        }
    }
}

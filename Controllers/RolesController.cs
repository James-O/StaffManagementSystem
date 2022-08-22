using StaffManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffManagementSystem.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Role()
        {
            using(StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
            {
                var role = db.RolesTbs.ToList();
                return View(role);
            }
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolesModel rolemodel)
        {
            RolesTb role = new RolesTb()
            {
                RoleTbName = rolemodel.RoleTbName,
                RoleTbDescription = rolemodel.RoleTbDescription,
                CreatedBy = rolemodel.CreatedBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = rolemodel.UpdatedBy,
                UpdatedOn = DateTime.Now
            };
            if (ModelState.IsValid)
            {
                using (StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
                {
                    db.RolesTbs.Add(role);
                    db.SaveChanges();
                    ModelState.Clear();
                }
            }
            
            return View();
        }
    }
}
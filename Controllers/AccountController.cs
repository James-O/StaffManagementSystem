using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using StaffManagementSystem.Models;
using System.Data.Entity;

namespace StaffManagementSystem.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            if (Session["StaffId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModels user)
        {
            if (ModelState.IsValid)
            {
                using (StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
                {
                    var login = db.StaffTbs.FirstOrDefault(a => a.Email == user.Email && a.Password == user.Password);
                    if (login != null)
                    {
                        Session["StaffId"] = login.StaffId.ToString();
                        Session["Email"] = login.Email.ToString();
                        Session["Password"] = login.Password.ToString();
                        Session["IsFirstLogOn"] = login.IsFirstLogOn.ToString();
                        if (login.IsFirstLogOn.ToString() == "False")
                        {
                            Session["FirstName"] = null;
                        }
                        else
                        {
                            Session["FirstName"] = login.FirstName.ToString();
                        }
                                                    
                        Session["Status"] = "False";

                        return RedirectToAction("Dashboard");
                    }
                }
            }
            return View(user);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserModels viewModels)
        {
            StaffTb user = new StaffTb()
            {
                Email = viewModels.Email,
                Password = viewModels.Password,
                FirstName = null,
                LastName = null,
                Address = null,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            if (ModelState.IsValid)
            {
                using (StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
                {
                    var dd = db.StaffTbs.Where(x => x.Email == viewModels.Email).FirstOrDefault();
                    if (dd == null)
                    {
                        db.StaffTbs.Add(user);
                        db.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Message = "You are registered successfully";
                    }
                    else
                    {
                        ViewBag.Message = "User already exist, please login";
                    }
                    

                }
            }
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dashboard(UpdateDetailsModel updatedetails)
        {
            using (StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
            {
                var staff = db.StaffTbs.FirstOrDefault(s => s.Email == updatedetails.Email);
                staff.FirstName = updatedetails.FirstName;
                staff.LastName = updatedetails.LastName;
                staff.Address = updatedetails.Address;
                Session["FirstName"] = staff.FirstName.ToString();
                staff.IsFirstLogOn = true;

                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                Session["Status"] = "True";
                Session["IsFirstLogOn"] = staff.IsFirstLogOn.ToString();
                ViewBag.Message = "Details updated successfully";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            //Session["StaffId"] = null;
            //Session["FirstName"] = null;
            //Session["StaffId"] = null;
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }
        
    }
}
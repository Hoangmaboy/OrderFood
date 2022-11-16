using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using OF_Project.Models;
using OF_Project.Logic;

namespace OF_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult loginAd(string para1, string para2)
        {
            UserManager admin = new UserManager();
            Admin e1 = admin.logged(para1, para2);
            string jsonStr = JsonConvert.SerializeObject(e1);
            HttpContext.Session.SetString("user", jsonStr);
            if (e1 != null)
            {
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.Error = "Login Failed! Please check your username and password!";
                return View("/Views/Home/Login.cshtml");
            }
        }
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult ChangePass()
        {
            string jsonstr = HttpContext.Session.GetString("user");
            Admin em;
            if (jsonstr is null)
            {
                return View("/Views/Home/Login.cshtml");
            }
            else
            {
                em = JsonConvert.DeserializeObject<Admin>(jsonstr);
                ViewBag.users = em;
                return View();
            }
        }
        public IActionResult DoChangePass()
        {
            string oldPass = Request.Form["PassNow"];
            string newPass = Request.Form["passNew"];
            string repass = Request.Form["re_pass"];
            string jsonstr = HttpContext.Session.GetString("user");
            Admin em;
            if (jsonstr is null)
            {
                return View("/Views/Home/Login.cshtml");
            }
            else
            {
                em = JsonConvert.DeserializeObject<Admin>(jsonstr);
                using (var context = new OrderFoodContext())
                {
                    em = context.Admins.FirstOrDefault(x => x.Id == em.Id);

                    if (!oldPass.Equals(em.Password))
                    {
                        ViewBag.err = "Old password is not correct!";
                        ViewBag.oldPa = oldPass;
                        ViewBag.newPa = newPass;
                        ViewBag.rePa = repass;
                        ViewBag.users = em;
                        return View("/Views/Employee/ChangePass.cshtml");
                    }
                    if (!newPass.Equals(repass))
                    {
                        ViewBag.err = "Re-password is not match with new password!";
                        ViewBag.oldPa = oldPass;
                        ViewBag.newPa = newPass;
                        ViewBag.rePa = repass;
                        ViewBag.users = em;
                        return View("/Views/Employee/ChangePass.cshtml");
                    }
                    em.Password = newPass;
                    context.Update(em);
                    context.SaveChanges();
                }
                //return $"{oldPass} - {newPass} - {repass}";
                HttpContext.Session.Remove("user");
                return View("/Views/Home/Login.cshtml");
            }
        }

    }
}

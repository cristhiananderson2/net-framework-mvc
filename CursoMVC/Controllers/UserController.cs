using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Models.TableViewModels;
using CursoMVC.Models.ViewModels;

namespace CursoMVC.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using(cursomvc_Entities db = new cursomvc_Entities())
            {
                lst = (from d in db.user
                          where d.idState == 1
                          select new UserTableViewModel
                          {
                              Id = d.id,
                              Email = d.email,
                              Age = d.age
                          }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel obj)
        {
            if(!ModelState.IsValid)
            {
                return View(obj);
            }

            using (cursomvc_Entities db = new cursomvc_Entities())
            {
                var oUser = new user();
                oUser.idState = 1;
                oUser.email = obj.Email;
                oUser.password = obj.Password;
                oUser.age = obj.Age;
                db.user.Add(oUser);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
           
        }

    }
}
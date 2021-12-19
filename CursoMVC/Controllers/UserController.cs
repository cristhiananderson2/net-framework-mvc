using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Models.TableViewModels;

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

    }
}
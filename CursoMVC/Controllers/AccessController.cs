using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;

namespace CursoMVC.Controllers
{
    public class AccessController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (cursomvc_Entities db = new cursomvc_Entities()) 
                {
                    var lst = from d in db.user
                              where d.email == user && d.password == password && d.idState == 1
                              select d;

                    if(lst.Count() > 0)
                    {
                        user oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }else
                    {
                        return Content("Usuario inválido :c");
                    }
                }
           
            }
            catch(Exception ex)
            {
                return Content("Ocurrió un error :c " + ex.Message );
            }
        }
    }
}
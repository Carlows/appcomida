using app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app.Controllers
{
    public class AppController : Controller
    {
        public readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var model = db.Registros.ToList();

            return View();
        }
    }
}
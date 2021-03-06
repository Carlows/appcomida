﻿using app.Infrastructure.Services;
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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            Exception exception = Server.GetLastError();
            return Json(new { error = exception.Message }, JsonRequestBehavior.AllowGet);
        }
    }
}
using app.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app.Controllers
{
    public class RegistrosController : Controller
    {        
        public readonly IRegistroService _registros;

        public RegistrosController(IRegistroService registrosService)
        {
            _registros = registrosService;
        }

        public JsonResult GetAllRecords()
        {
            var model = _registros.GetAllRecords();

            return Json(model, JsonRequestBehavior.AllowGet);
        }
	}
}
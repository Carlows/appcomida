using app.Infrastructure.Services;
using app.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpPost]
        public JsonResult CreateRecord(RegistroViewModel model)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    var registro = _registros.CreateRecord(model);

                    return Json(registro);
                }
                catch(Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
                    return Json(new { error = "Hubo un error al agregar el registro" });
                }
            }

            // return error
            Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
            return Json(new { error = "Hubo un error al agregar el registro" });
        }
	}
}
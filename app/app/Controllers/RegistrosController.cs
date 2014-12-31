using app.Infrastructure.Services;
using app.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Routing;
using app.Infrastructure.Repositories;


namespace app.Controllers
{
    public class RegistrosController : Controller
    {
        public readonly IRegistroService _registros;
        public readonly IAuthRepository _authrepo;

        public RegistrosController(IRegistroService registrosService, IAuthRepository authRepo)
        {
            this._authrepo = authRepo;
            _registros = registrosService;
        }

        public JsonResult GetAllRecords()
        {
            var model = _registros.GetRecordsDescending();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRecord(int? id)
        {       
            if(id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { error = "Id es null" }, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var record = _registros.FindRecordById(id);

                if(record != null)
                {
                    return Json(record, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { error = "No se pudo encontrar el producto" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "Hubo un error al encontrar el registro: " + e.Message }, JsonRequestBehavior.AllowGet);
            }
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
                    return Json(new { error = "Hubo un error al agregar el registro: " + e.Message });
                }
            }

            // return error
            Response.StatusCode = (int)HttpStatusCode.BadRequest; 
            return Json(new { error = "Hubo un error al agregar el registro" });
        }
	}
}
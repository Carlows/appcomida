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
using System.Threading.Tasks;
using app.Infrastructure.Logging;


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
            try
            {
                var model = _registros.GetRecordsDescending();

                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                new LogEvent("Message" + e.Message + " InnerException: " + e.InnerException + " Trace: " + e.StackTrace).Raise();

                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = e.Message }, JsonRequestBehavior.AllowGet);
            }
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
                new LogEvent("Message" + e.Message + " InnerException: " + e.InnerException + " Trace: " + e.StackTrace).Raise();

                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "Hubo un error al encontrar el registro: " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Authorize]
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
                    new LogEvent("Message" + e.Message + " InnerException: " + e.InnerException + " Trace: " + e.StackTrace).Raise();

                    Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
                    return Json(new { error = "Hubo un error al agregar el registro: " + e.Message });
                }
            }

            // return error
            Response.StatusCode = (int)HttpStatusCode.BadRequest; 
            return Json(new { error = "Hubo un error al agregar el registro" });
        }

        [HttpPost]
        [Authorize]
        public async Task<JsonResult> VoteRecord(int registroID, bool vote)
        {
            try
            {
                await _registros.AddOrUpdateVote(registroID, GetUserName(), vote);

                var registro = _registros.FindRecordById(registroID);

                var model = registro.VoteCount;

                return Json(new { count = model });
            }
            catch(KeyNotFoundException e)
            {
                Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return Json(new { error = "Usuario no encontrado" });
            }
            catch(Exception e)
            {
                new LogEvent("Message" + e.Message + " InnerException: " + e.InnerException + " Trace: " + e.StackTrace).Raise();

                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "Hubo un error al agregar el registro: " + e.Message });
            }
        }

        private string GetUserName()
        {
            ClaimsPrincipal principal = (ClaimsPrincipal)User;

            var name = principal.Claims.Where(c => c.Type == "sub").Single().Value;

            return name;
        }
	}
}
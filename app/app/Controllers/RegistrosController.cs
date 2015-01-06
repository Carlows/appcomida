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
            throw new Exception("oh noes!");
            var model = _registros.GetRecordsDescending();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult FindRecord(string query, string state)
        //{
        //    //if (String.IsNullOrWhiteSpace(query))
        //    //{
        //    //    Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //    //    return Json(new { error = "Datos invalidos" }, JsonRequestBehavior.AllowGet);
        //    //}


        //}

        public JsonResult GetRecord(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { error = "Id es null" }, JsonRequestBehavior.AllowGet);
            }

            var record = _registros.FindRecordById(id);

            if (record != null)
            {
                return Json(record, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(new { error = "No se pudo encontrar el producto" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Authorize]
        public JsonResult CreateRecord(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var registro = _registros.CreateRecord(model);

                return Json(registro);
            }

            // return error
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { error = "Hubo un error al agregar el registro" });
        }

        [HttpPost]
        [Authorize]
        public async Task<JsonResult> VoteRecord(int registroID, bool vote)
        {
            await _registros.AddOrUpdateVote(registroID, GetUserName(), vote);

            var registro = _registros.FindRecordById(registroID);

            var model = registro.VoteCount;

            return Json(new { count = model });
        }

        private string GetUserName()
        {
            ClaimsPrincipal principal = (ClaimsPrincipal)User;

            var name = principal.Claims.Where(c => c.Type == "sub").Single().Value;

            return name;
        }
    }
}
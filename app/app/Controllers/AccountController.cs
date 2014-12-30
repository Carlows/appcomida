using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using app.Models;
using app.Infrastructure.Repositories;
using System.Net;

namespace app.Controllers
{
    [Authorize]
    [RoutePrefix("Account")]
    public class AccountController : Controller
    {
        private readonly IAuthRepository _repo;

        public AccountController(IAuthRepository repository)
        {
            _repo = repository;
        }

        // POST /Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { error = "Debes ingresar los datos correctamente" });
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            HttpStatusCode? errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                Response.StatusCode = (int)errorResult;
                return Json(new { error = "Error al procesar la solicitud" });
            }

            return Json(new { success = "Fuiste registrado correctamente" });
        }

        private HttpStatusCode? GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return HttpStatusCode.InternalServerError;
            }

            if (!result.Succeeded)
            {
                return HttpStatusCode.BadRequest;
            }

            return null;
        }
    }
}
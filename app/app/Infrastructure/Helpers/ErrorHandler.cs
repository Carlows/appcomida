using app.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace app.Infrastructure.Helpers
{
    public class ErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception != null && !filterContext.ExceptionHandled)
            {
                Exception ex = filterContext.Exception;
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

                string exceptionMessage =
                    string.Format("Message: {0}\nInnerException: {1}\nTrace: {2}", ex.Message, ex.InnerException, ex.StackTrace)
                    .Replace("\n", Environment.NewLine);

                new LogEvent(exceptionMessage).Raise();

                if (filterContext.Exception is KeyNotFoundException)
                {
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                    filterContext.Result = new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new
                        {
                            error = "Usuario no encontrado"
                        }
                    };
                }
                else
                {
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    filterContext.Result = new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new
                        {
                            error = "Se produjo una excepcion y no se pudo procesar la solicitud."
                        }
                    };                    
                }
            }
            else
            {
                base.OnException(filterContext);
            }
        }
    }
}

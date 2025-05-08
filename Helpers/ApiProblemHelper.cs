using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace apivendora.Helpers
{
    public static class ApiProblemHelper
    {
        public static ProblemDetails NotFound(HttpContext context, string detail)
        {
            return new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "Recurso no encontrado",
                Status = 404,
                Detail = detail,
                Instance = context.Request.Path
            };
        }

        public static ProblemDetails BadRequest(HttpContext context, string detail)
        {
            return new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "Solicitud incorrecta",
                Status = 400,
                Detail = detail,
                Instance = context.Request.Path
            };
        }

        public static ValidationProblemDetails BadRequestWithModelState(HttpContext context, ModelStateDictionary modelState)
        {
            return new ValidationProblemDetails(modelState)
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    Title = "Solicitud incorrecta",
                    Status = 400,
                    Detail = "Uno o más errores de validación han ocurrido.",
                    Instance = context.Request.Path
                };
        }

    }
}

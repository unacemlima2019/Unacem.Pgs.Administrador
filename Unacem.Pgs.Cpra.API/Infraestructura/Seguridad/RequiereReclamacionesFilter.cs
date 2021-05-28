using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Unacem.Pgs.Cpra.API.Infraestructura.Seguridad
{
    public class RequiereReclamacionesFilter : IAuthorizationFilter
    {
        private readonly Claim _Claim;

        public RequiereReclamacionesFilter(Claim pClaim)
        {
            _Claim = pClaim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var esTokenValido = context.HttpContext.User.Claims.Any();
            if (!esTokenValido)
            {
                context.Result = new JsonResult(new { descripcionResultado = "Unauthorized - Token invalido." }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else
            {
                var tieneReclamoValido = context.HttpContext.User.Claims.Any(c => c.Type == _Claim.Type && c.Value == _Claim.Value);
                if (!tieneReclamoValido)
                    context.Result = new JsonResult(new { descripcionResultado = "Unauthorized - Claim invalido." }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}

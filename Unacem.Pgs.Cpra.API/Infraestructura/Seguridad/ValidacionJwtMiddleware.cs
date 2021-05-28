using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Unacem.Pgs.Cpra.API.Infraestructura.Seguridad
{
    public class ValidacionJwtMiddleware
    {
        private readonly RequestDelegate _RequestDelegado;
        private readonly IConfiguration _IConfiguracion;

        public ValidacionJwtMiddleware(RequestDelegate pRequestDelegate, IConfiguration pIConfiguration)
        {
            _RequestDelegado = pRequestDelegate;
            _IConfiguracion = pIConfiguration;
        }

        public async Task Invoke(HttpContext pHttpContext)
        {
            var tokenJwt = pHttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (tokenJwt != null)
                AdjuntarClaimUsuarioAContexto(pHttpContext, tokenJwt);

            await _RequestDelegado(pHttpContext);
        }

        private void AdjuntarClaimUsuarioAContexto(HttpContext pHttpContext, string pTokenJwt)
        {
            try
            {
                SecurityToken tokenDeSeguridad;
                var controladorToken = new JwtSecurityTokenHandler();

                var paramentrosDeValidacion = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_IConfiguracion.GetValue<string>("ParametrosValidacionJwt:Secreto"))),
                    ValidAudience = _IConfiguracion.GetValue<string>("ParametrosValidacionJwt:Audiencia"),
                    ValidIssuer = _IConfiguracion.GetValue<string>("ParametrosValidacionJwt:Emisor"),
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true
                };

                Thread.CurrentPrincipal = controladorToken.ValidateToken(pTokenJwt, paramentrosDeValidacion, out tokenDeSeguridad);
                pHttpContext.User = controladorToken.ValidateToken(pTokenJwt, paramentrosDeValidacion, out tokenDeSeguridad);
            }
            catch (Exception ex)
            {
                //pHttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                //throw;
            }

        }
    }
}

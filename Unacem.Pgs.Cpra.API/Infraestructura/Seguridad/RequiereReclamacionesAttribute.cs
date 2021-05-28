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
    public class RequiereReclamacionesAttribute : TypeFilterAttribute
    {
        public RequiereReclamacionesAttribute(string pTipoReclamacion, string pValorReclamacion): base(typeof(RequiereReclamacionesFilter))
        {
            Arguments = new object[] { new Claim(pTipoReclamacion, pValorReclamacion) };
        }
    }
}

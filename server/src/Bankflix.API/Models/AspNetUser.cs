using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Bankflix.API.Models
{
    public class AspNetUser : IUsuario
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Identificacao => _accessor.HttpContext.User.Identity.Name;

        public Guid ObterAutenticadoId()
        {
            return VerificarSeEstaAutenticado() ? Guid.Parse(_accessor.HttpContext.User.Identity.Name) : Guid.Empty;
        }

        public IEnumerable<Claim> ObterPermissoes()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public bool VerificarSeEstaAutenticado()
        {
            var estaAutenticado = false;

            try
            {
                estaAutenticado = _accessor.HttpContext.User.Identity.IsAuthenticated;
            }

            catch
            {
                estaAutenticado = false;
            }

            return estaAutenticado;
        }
    }
}

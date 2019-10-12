using Bankflix.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Bankflix.API.Configurations
{
    public static class ConfiguracoesSeguranca
    {
        private const string _chave = "27GRJws6ohnP1ksGMHplJMn5sYRzLmtDk1WtmEqRmUid6QkIYP#bankflix.core";

        public static void ConfigurarAutenticacao(this IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(_chave);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Agencia", policy => { policy.RequireClaim("agencia", "1"); });
                options.AddPolicy("Cliente", policy => { policy.RequireClaim("cliente", "1"); });
                options.AddPolicy("Autenticado", policy => { policy.RequireAuthenticatedUser(); });

                options.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
        }

        public static string GerarToken(UsuarioViewModel usuarioViewModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_chave);
            var allClaims = new List<Claim>();

            switch (usuarioViewModel.TipoUsuario)
            {
                case (TipoUsuario.Agencia):
                    {
                        allClaims.Add(new Claim("agencia", "1"));
                        break;
                    }

                case (TipoUsuario.Cliente):
                    {
                        allClaims.Add(new Claim("cliente", "1"));
                        break;
                    }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new GenericIdentity(usuarioViewModel.Id.ToString(), "Login"),
                    allClaims
                ),
                NotBefore = DateTime.UtcNow.AddMinutes(-15),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

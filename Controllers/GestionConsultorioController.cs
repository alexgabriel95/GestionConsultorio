using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestionConsultorio.Models;
using GestionConsultorio.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using GestionConsultorio.Models.LS.Comp.Encriptador;


namespace GestionConsultorio.Controllers
{
    public class GestionConsultorioController : Controller
    {
        protected IDbContext db;

        protected GestionConsultorioController(IDbContext context)
        {
            db = context;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }


        public static Usuarioset GetUsuarioLogueado(HttpContext c)
        {
            var usuarioId = c.User.FindFirst(ClaimTypes.NameIdentifier);
            if (usuarioId == null)
            {
                return null;
            }
            //var usuario = c.Session.GetObjectFromJson<Usuarioset>(KeySession);
            Usuarioset usuario;
            using (var db = new DataContext())
            {
                usuario = Usuarioset.ObtenerUsuarioActivoPorId(db, Int32.Parse(usuarioId.Value));
            }
            return usuario;
        }
        //public async Task SetUsuarioLogueado(Usuarioset usuario)
        //{
        //    var claims = new[]
        //               {
        //                    new Claim(ClaimTypes.Name, usuario.NombreCompleto()),
        //                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
        //                };

        //    var claimsIdentity = new ClaimsIdentity(
        //        claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //    var authProperties = new AuthenticationProperties
        //    {
        //        //AllowRefresh = <bool>,
        //        // Refreshing the authentication session should be allowed.

        //        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(usuario.Perfil.SessionTimeOut),
        //        // The time at which the authentication ticket expires. A 
        //        // value set here overrides the ExpireTimeSpan option of 
        //        // CookieAuthenticationOptions set with AddCookie.

        //        //IsPersistent = true,
        //        // Whether the authentication session is persisted across 
        //        // multiple requests. Required when setting the 
        //        // ExpireTimeSpan option of CookieAuthenticationOptions 
        //        // set with AddCookie. Also required when setting 
        //        // ExpiresUtc.

        //        //IssuedUtc = <DateTimeOffset>,
        //        // The time at which the authentication ticket was issued.

        //        //RedirectUri = <string>
        //        // The full path or absolute URI to be used as an http 
        //        // redirect response value.
        //    };

        //    await HttpContext.SignInAsync(
        //        CookieAuthenticationDefaults.AuthenticationScheme,
        //        new ClaimsPrincipal(claimsIdentity),
        //        authProperties);
        //}

        //public async Task BorrarSesionAsync() => await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


        public void GenerarModal(string titulo, string detalle)
        {
            TempData["TituloModal"] = titulo;
            TempData["DetalleModal"] = detalle;
        }
    }
}

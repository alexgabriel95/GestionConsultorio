using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionConsultorio.Models.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionConsultorio.Models.Entities;
using GestionConsultorio.Models.LS.Comp.Encriptador;

namespace GestionConsultorio.Models
{
    public partial class Usuarioset
    {
        //public string NombreCompleto()
        //{
        //    return Nombre.Desencriptar() + " " + Apellido.Desencriptar();
        //}

        public static IEnumerable<SelectListItem> ObtenerTiposDoc(IDbContext db)
        {
            var valores = Enum.GetValues(typeof(TipoDocumento)).Cast<TipoDocumento>().ToList();

            return valores.Select(u => new SelectListItem
            {
                Value = u.ToString(),
                Text = u.ToString()
            }).ToList();

        }

        public static Usuarioset ObtenerUsuarioActivoPorId(IDbContext db, int id)
        {
            return db.Usuarioset.Include(x => x.Perfil)
                .ThenInclude(x => x.Perfilpaginaset)
                .ThenInclude(x => x.Pagina)
                .Include(x=>x.Perfil.Perfilpermisoset)
                .ThenInclude(x =>x.Permiso)
                .FirstOrDefault(x => x.Id == id && !x.FechaBaja.HasValue);
        }

        public static Usuarioset ObtenerUsuarioPorId(IDbContext db, int id)
        {
            return db.Usuarioset
                .Include(x => x.Perfil)
                .ThenInclude(x => x.Perfilpaginaset)
                .ThenInclude(x => x.Pagina)
                .ThenInclude(x => x.Menupaginaset)
                .ThenInclude(x => x.Menu)
                .FirstOrDefault(x => x.Id == id);
        }

        public static async Task<List<Usuarioset>> ObtenerUsuarios(IDbContext db)
        {
            return await db.Usuarioset.Include(x => x.Perfil).Where(x => x.FechaBaja == null).ToListAsync();
        }

        public static string GenerarRandomPassword()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        public static async Task<List<Usuarioset>> ObtenerUsuariosSegunPuedeCrear(IDbContext db, int perfilEnSesionId)
        {
            return await db.Usuarioset.Include(x => x.Perfil).ThenInclude(x => x.PuedecrearsetPerfilAcrearNavigation)
             .Where(x => x.Perfil.PuedecrearsetPerfilAcrearNavigation.Any(p => p.PuedeCrear == perfilEnSesionId))
             .ToListAsync();
        }
        public static async Task<Usuarioset> ObtenerUsuarioPorDocumento(IDbContext db, int documento)
        {
            return await db.Usuarioset.FirstOrDefaultAsync(x => x.NumeroDocumento == documento);
        }

        public static List<Usuarioset> ObtenerUsuariosPorPerfil(IDbContext db, int perfilId)
        {
            return db.Usuarioset.Where(x => x.PerfilId == perfilId).ToList();
        }
        public static void ActualizarFechaSesion(IDbContext db, Usuarioset usuario)
        {
            usuario.UltimoInicioSesion = DateTime.Now;
            db.Usuarioset.Update(usuario);
            db.SaveChanges();
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionConsultorio.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionConsultorio.Models
{
    public partial class Perfilset
    {
        public static List<SelectListItem> ObtenerPerfilesDll(IDbContext db)
        {
            return db.Perfilset.Select(t => new SelectListItem { Text = t.Nombre, Value = t.Id.ToString() }).ToList();
        }



        public static async Task<List<Perfilset>> ObtenerPerfiles(IDbContext db)
        {
            return await db.Perfilset.ToListAsync();
        }

        public static async Task<Perfilset> ObtenerPerfilPorId(IDbContext db, int perfilId)
        {
            return await db.Perfilset.FirstOrDefaultAsync(x => x.Id == perfilId);
        }

        public static async Task<Perfilpaginaset> ObtenerPerfilPagina(IDbContext db, int paginaId, int perfilId)
        {
            Perfilpaginaset permiso = await db.Perfilpaginaset.FirstOrDefaultAsync(x => x.PaginaId == paginaId && x.PerfilId == perfilId);
            if (permiso == null)
            {
                permiso = new Perfilpaginaset
                {
                    Pagina = await Paginaset.ObtenerPaginaPorId(db, paginaId),
                    Perfil = await ObtenerPerfilPorId(db, perfilId),
                    PaginaId = paginaId,
                    PerfilId = perfilId
                };
            }

            return permiso;
        }

        public static async Task<Perfilpermisoset> ObtenerPerfilPermiso(IDbContext db, int permisoId, int perfilId)
        {

            Perfilpermisoset permiso = await db.Perfilpermisoset.FirstOrDefaultAsync(x => x.PermisoId == permisoId && x.PerfilId == perfilId);
            if (permiso == null)
            {
                permiso = new Perfilpermisoset
                {
                    Permiso = Permisoset.ObtenerPermisoPorId(db, permisoId),
                    Perfil = await ObtenerPerfilPorId(db, perfilId),
                    PermisoId = permisoId,
                    PerfilId = perfilId
                };
            }

            return permiso;
        }
        public static async Task<List<Perfilset>> ObtenerPerfilesPermiso(IDbContext db, string codigoPermiso) //Devuelve los perfiles que tengan asignado determinado permiso
        {
            Permisoset permiso = await Permisoset.ObtenerPermisoPorCodigo(db, codigoPermiso);
            int idPermiso = permiso.Id;

            List<Perfilpermisoset> listPerfilPermiso = await db.Perfilpermisoset.Where(x => x.PermisoId == idPermiso).ToListAsync();


            List<Perfilset> perfiles = new List<Perfilset>();
            foreach (var item in listPerfilPermiso)
            {
                perfiles.Add(item.Perfil);
            }

            return perfiles;
        }
        public static async Task<Perfilset> ObtenerPerfilSitema(IDbContext db, string codigo) //Devuelve los perfiles que tengan asignado determinado permiso
        {

            return await db.Perfilset.FirstOrDefaultAsync(x => x.Nombre == codigo);
        }

        public static async Task<Puedecrearset> ObtenerPuedeCrear(IDbContext db, Perfilset perfilACrear, Perfilset perfil)
        {

            Puedecrearset puedeCrear =
                await db.Puedecrearset.FirstOrDefaultAsync(p =>
                    p.PerfilAcrear == perfilACrear.Id && p.PuedeCrear == perfil.Id);

            if (puedeCrear == null)
            {
                puedeCrear = new Puedecrearset
                {
                    PerfilAcrear = perfilACrear.Id,
                    PuedeCrear = perfil.Id,
                    PerfilAcrearNavigation = perfilACrear,
                    PuedeCrearNavigation = perfil
                };
            }

            return puedeCrear;
        }

        public static async Task<List<SelectListItem>> ObtenerPerfilesParaCrear(IDbContext db, int perfilId)
        {
            return await db.Perfilset.Where(x => x.PuedecrearsetPerfilAcrearNavigation.Any(pu => pu.PuedeCrear == perfilId)).Select(t => new SelectListItem { Text = t.Nombre, Value = t.Id.ToString() }).ToListAsync();
        }

        public bool ValidarPermiso(string codigo)
        {
            bool tienePermiso = false;

            using (var db = new DataContext())
            {
                tienePermiso = db.Perfilset.Include(x => x.Perfilpermisoset).ThenInclude(x => x.Permiso).FirstOrDefault(p => p.Id == Id)
                    .Perfilpermisoset.Any(y => y.Permiso.Codigo == codigo);
            }

            return tienePermiso;
        }


    }
}

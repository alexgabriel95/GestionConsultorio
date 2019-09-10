using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionConsultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionConsultorio.Models
{
    public partial class Permisoset
    {
        public static IEnumerable<Permisoset> ObtenerPermisos(IDbContext db)
        {
            return db.Permisoset.ToList();
        }

        public static Permisoset ObtenerPermisoPorId(IDbContext db, int idPermiso)
        {
            return db.Permisoset.FirstOrDefault(x => x.Id == idPermiso);
        }

        public static async Task<Permisoset> ObtenerPermisoPorCodigo(IDbContext db, string codigoPermiso)
        {
            return await db.Permisoset.FirstOrDefaultAsync(x => x.Codigo == codigoPermiso);
        }
    }
}

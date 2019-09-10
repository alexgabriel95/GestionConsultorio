using GestionConsultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionConsultorio.Models
{
    public partial class Paginaset
        {
            public static IEnumerable<Paginaset> ObtenerPaginas(IDbContext db)
            {
                return db.Paginaset.ToList();
            }

            public static async Task<Paginaset> ObtenerPaginaPorId(IDbContext db, int paginaId)
            {
                return await db.Paginaset.FirstOrDefaultAsync(x => x.Id == paginaId);
            }
        }
}


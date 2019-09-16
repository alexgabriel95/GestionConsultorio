using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionConsultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionConsultorio.Models
{
    public partial class Menuset
    {
        public static List<Menuset> ObtenerMenues(Usuarioset u)
        {
            List<Menuset> m = new List<Menuset>();
            using (var db = new DataContext())
            {
                var uLogueado = Usuarioset.ObtenerUsuarioPorId(db, u.Id);
                m = uLogueado.Perfil.Perfilpaginaset.Where(x => x.PerfilId == u.PerfilId && x.Pagina.Menupaginaset.Any(mp => mp.MenuId.HasValue))
                    .SelectMany(s => s.Pagina.Menupaginaset).Select(mp => mp.Menu).Distinct().OrderBy(x=>x.Order).ToList();
            }

            return m;
        }
    }
}

using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Paginaset
    {
        public Paginaset()
        {
            Menupaginaset = new HashSet<Menupaginaset>();
            Perfilpaginaset = new HashSet<Perfilpaginaset>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public virtual ICollection<Menupaginaset> Menupaginaset { get; set; }
        public virtual ICollection<Perfilpaginaset> Perfilpaginaset { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Perfilset
    {
        public Perfilset()
        {
            Perfilpaginaset = new HashSet<Perfilpaginaset>();
            Perfilpermisoset = new HashSet<Perfilpermisoset>();
            PuedecrearsetPerfilAcrearNavigation = new HashSet<Puedecrearset>();
            PuedecrearsetPuedeCrearNavigation = new HashSet<Puedecrearset>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int SessionTimeOut { get; set; }
        public int? TipoPerfil { get; set; }

        public virtual Usuarioset Usuarioset { get; set; }
        public virtual ICollection<Perfilpaginaset> Perfilpaginaset { get; set; }
        public virtual ICollection<Perfilpermisoset> Perfilpermisoset { get; set; }
        public virtual ICollection<Puedecrearset> PuedecrearsetPerfilAcrearNavigation { get; set; }
        public virtual ICollection<Puedecrearset> PuedecrearsetPuedeCrearNavigation { get; set; }
    }
}

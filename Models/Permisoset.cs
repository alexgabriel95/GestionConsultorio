using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Permisoset
    {
        public Permisoset()
        {
            Perfilpermisoset = new HashSet<Perfilpermisoset>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionCompleta { get; set; }
        public string Grupo { get; set; }

        public ICollection<Perfilpermisoset> Perfilpermisoset { get; set; }
    }
}

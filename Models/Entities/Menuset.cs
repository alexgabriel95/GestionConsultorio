using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Menuset
    {
        public Menuset()
        {
            Menupaginaset = new HashSet<Menupaginaset>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string IconClass { get; set; }
        public string Order { get; set; }

        public virtual ICollection<Menupaginaset> Menupaginaset { get; set; }
    }
}

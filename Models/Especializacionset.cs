using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Especializacionset
    {
        public Especializacionset()
        {
            Especialidadusuarioset = new HashSet<Especialidadusuarioset>();
        }

        public int Id { get; set; }
        public string NombreEspecializacion { get; set; }

        public Atencionset Atencionset { get; set; }
        public ICollection<Especialidadusuarioset> Especialidadusuarioset { get; set; }
    }
}

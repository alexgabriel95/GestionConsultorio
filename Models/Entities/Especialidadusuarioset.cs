using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Especialidadusuarioset
    {
        public int UsuarioId { get; set; }
        public int EspecializacionId { get; set; }

        public Especializacionset Especializacion { get; set; }
        public Usuarioset Usuario { get; set; }
    }
}

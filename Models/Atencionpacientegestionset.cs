using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Atencionpacientegestionset
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int? EstadoGestion { get; set; }
        public DateTime? FechaGestion { get; set; }
        public int? AtencionPacienteId { get; set; }

        public Atencionset AtencionPaciente { get; set; }
    }
}

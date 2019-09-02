using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Contactopacienteset
    {
        public Contactopacienteset()
        {
            Contactoset = new HashSet<Contactoset>();
        }

        public int Id { get; set; }
        public int PacienteId { get; set; }

        public Pacienteset Paciente { get; set; }
        public ICollection<Contactoset> Contactoset { get; set; }
    }
}

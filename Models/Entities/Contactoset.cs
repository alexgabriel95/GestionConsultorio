using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Contactoset
    {
        public int Id { get; set; }
        public string Dato { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? ContactoPacienteId { get; set; }
        public int? TipoContacto { get; set; }
        public int? UsuarioIdAlta { get; set; }
        public int? UsuarioIdBaja { get; set; }

        public Contactopacienteset ContactoPaciente { get; set; }
        public Usuarioset UsuarioIdAltaNavigation { get; set; }
        public Usuarioset UsuarioIdBajaNavigation { get; set; }
    }
}

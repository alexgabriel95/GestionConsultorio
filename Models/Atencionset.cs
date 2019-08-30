using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Atencionset
    {
        public Atencionset()
        {
            Atencionpacientegestionset = new HashSet<Atencionpacientegestionset>();
            Gestionperdidaset = new HashSet<Gestionperdidaset>();
            Medicamentoatencionset = new HashSet<Medicamentoatencionset>();
        }

        public int Id { get; set; }
        public DateTime FechaAtencion { get; set; }
        public DateTime FechaAltaAtencion { get; set; }
        public int? UsuarioIdAlta { get; set; }
        public int? UsuarioIdMedico { get; set; }
        public int? UsuarioIdBaja { get; set; }
        public int? EspecializacionId { get; set; }

        public Usuarioset Id1 { get; set; }
        public Especializacionset IdNavigation { get; set; }
        public ICollection<Atencionpacientegestionset> Atencionpacientegestionset { get; set; }
        public ICollection<Gestionperdidaset> Gestionperdidaset { get; set; }
        public ICollection<Medicamentoatencionset> Medicamentoatencionset { get; set; }
    }
}

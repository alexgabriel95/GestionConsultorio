using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Usuarioset
    {
        public Usuarioset()
        {
            ContactosetUsuarioIdAltaNavigation = new HashSet<Contactoset>();
            ContactosetUsuarioIdBajaNavigation = new HashSet<Contactoset>();
            Especialidadusuarioset = new HashSet<Especialidadusuarioset>();
            Notificacionusuarioset = new HashSet<Notificacionusuarioset>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? UltimoInicioSesion { get; set; }
        public int PerfilId { get; set; }
        public int? UsuarioIdAlta { get; set; }
        public int? UsuarioIdBaja { get; set; }

        public Usuarioset Id1 { get; set; }
        public Perfilset IdNavigation { get; set; }
        public Atencionset Atencionset { get; set; }
        public Usuarioset InverseId1 { get; set; }
        public ICollection<Contactoset> ContactosetUsuarioIdAltaNavigation { get; set; }
        public ICollection<Contactoset> ContactosetUsuarioIdBajaNavigation { get; set; }
        public ICollection<Especialidadusuarioset> Especialidadusuarioset { get; set; }
        public ICollection<Notificacionusuarioset> Notificacionusuarioset { get; set; }
    }
}

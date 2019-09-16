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

        public virtual Usuarioset UsuarioAlta { get; set; }
        public virtual Perfilset Perfil { get; set; }
        public virtual Atencionset Atencionset { get; set; }
        public virtual Usuarioset UsuarioBaja { get; set; }
        public virtual ICollection<Contactoset> ContactosetUsuarioIdAltaNavigation { get; set; }
        public virtual ICollection<Contactoset> ContactosetUsuarioIdBajaNavigation { get; set; }
        public virtual ICollection<Especialidadusuarioset> Especialidadusuarioset { get; set; }
        public virtual ICollection<Notificacionusuarioset> Notificacionusuarioset { get; set; }
    }
}

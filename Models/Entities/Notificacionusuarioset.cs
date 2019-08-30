using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Notificacionusuarioset
    {
        public int Id { get; set; }
        public bool? FueLeido { get; set; }
        public int NotificacionId { get; set; }
        public int UsuarioId { get; set; }

        public Notificacionset Notificacion { get; set; }
        public Usuarioset Usuario { get; set; }
    }
}

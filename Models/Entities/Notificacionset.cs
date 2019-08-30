using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Notificacionset
    {
        public Notificacionset()
        {
            Notificacionusuarioset = new HashSet<Notificacionusuarioset>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public string Titulo { get; set; }

        public ICollection<Notificacionusuarioset> Notificacionusuarioset { get; set; }
    }
}

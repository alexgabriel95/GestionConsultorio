using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Pacienteset
    {
        public Pacienteset()
        {
            Contactopacienteset = new HashSet<Contactopacienteset>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumento { get; set; }
        public int Numerodocumento { get; set; }
        public string DireccionCalle { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }

        public ICollection<Contactopacienteset> Contactopacienteset { get; set; }
    }
}

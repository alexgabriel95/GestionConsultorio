using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Gestionperdidaset
    {
        public int Id { get; set; }
        public int? AtencionId { get; set; }

        public Atencionset Atencion { get; set; }
    }
}

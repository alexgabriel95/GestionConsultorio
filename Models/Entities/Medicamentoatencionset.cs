using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Medicamentoatencionset
    {
        public int AtencionId { get; set; }
        public int MedicamentoId { get; set; }

        public Atencionset Atencion { get; set; }
        public Medicamentoset Medicamento { get; set; }
    }
}

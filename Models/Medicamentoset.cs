using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Medicamentoset
    {
        public Medicamentoset()
        {
            Medicamentoatencionset = new HashSet<Medicamentoatencionset>();
        }

        public int Id { get; set; }
        public string NombreMedicamento { get; set; }
        public DateTime FechaCarga { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int CantidadDisponible { get; set; }

        public ICollection<Medicamentoatencionset> Medicamentoatencionset { get; set; }
    }
}

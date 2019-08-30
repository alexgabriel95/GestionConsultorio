using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Puedecrearset
    {
        public int PuedeCrear { get; set; }
        public int PerfilAcrear { get; set; }

        public Perfilset PerfilAcrearNavigation { get; set; }
        public Perfilset PuedeCrearNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionConsultorio.ViewModels
{
    public class EditarPerfilViewModel
    {
        public int PerfilId { get; set; }
        public string Nombre { get; set; }
        public int Timeout { get; set; }
    }
}

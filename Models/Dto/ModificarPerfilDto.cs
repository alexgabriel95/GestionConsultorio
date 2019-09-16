using System;
using System.Collections.Generic;
using System.Text;

namespace GestionConsultorio.Models.Dto
{
    public class ModificarPermisoDto
    {
        public int PaginaId { get; set; }
        public bool Permitido { get; set; }
        public int PerfilId { get; set; }
        public int PermisoId { get; set; }
        public int PerfilCrearId { get; set; }
    }
}

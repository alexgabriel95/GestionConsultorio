using System;
using System.Collections.Generic;
using System.Text;
using GestionConsultorio.Models.Entities;

namespace GestionConsultorio.Models.Dto
{
    public class CrearPerfilDto
    {
        public string Descripcion { get; set; }
        public int TimeOut { get; set; }
        public TipoPerfil TipoPerfil { get; set; }
    }
}

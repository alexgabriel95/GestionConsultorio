using GestionConsultorio.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionConsultorio.Models.Dto
{
    public class UsuarioAltaDto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public TipoDocumento TipoDoc { get; set; }
        [Required]
        public string NumeroDoc { get; set; }
        [Required]
        public string Email { get; set; }
        public string Telefono { get; set; }
        [Required]
        public int PerfilId { get; set; }


    }

    public class usuarioLoginDto
    {
        public string email { get; set; }
        public string password { get; set; }
        public string NumeroDocumento { get; set; }

    }

    public class UsuarioCambiarClaveDto
    {
        public int UsuarioId { get; set; }
        public string NuevaClave { get; set; }
        public string ConfirmarClave { get; set; }
        public string NumeroDocumento { get; set; }
        public string DV { get; set; }
        public TipoDocumento TipoDoc { get; set; }
    };
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Dominio.Seguridad
{
   public  class Usuario
    {
       
       public Guid Id { get; set; }
       [Required]

       [MaxLength(40)]
        public string Nombre { get; set; }

       [MaxLength(40)]
       public string Apellidos { get; set; }

       [Required]
       [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

       [Required]
        public string Foto { get; set; }

       [Required]
       [MaxLength(20)]
       [Display(Name="Nombre Usuario")]
        public string NombreUsuario { get; set; }

       [Required]
       [Display(Name="Contraseña")]
        public string  Contraseña  { get; set; }
       
       
       [NotMapped]
       [Compare("Contraseña")]
       public string ConfirmacionContraseña { get; set; }

       public bool BloqueoCuenta { get; set; }

       public string intentosFallidos { get; set; }


       public virtual List<Usuario>Amigos { get; set; }

       public virtual List<SolicitudAmistad> solicitudes { get; set; }

    }
}

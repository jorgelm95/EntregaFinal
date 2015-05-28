using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Dominio.Seguridad
{
   public  class SolicitudAmistad
    {
        public Guid Id { get; set; }

        public Usuario UsuarioEnviaSolicitud { get; set; }
        public Usuario usuarioRecibeSolicitud { get; set; }
        public bool AceptaSolicitud { get; set; } 
        public DateTime FechaAmistad { get; set; }
       
       

    }
}

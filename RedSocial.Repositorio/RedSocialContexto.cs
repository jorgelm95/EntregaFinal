using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedSocial.Dominio.Seguridad;
namespace RedSocial.Repositorio
{
   public class RedSocialContexto : DbContext
    {
       public RedSocialContexto()   : base("ConexionRedSocial2")
       {

       }

       public  DbSet<Usuario> Usuarios { get; set; }
       public DbSet<SolicitudAmistad> Solicitudes { get; set; }

    }
}

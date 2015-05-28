using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesDominio = RedSocial.Dominio.Seguridad;
using repositorio = RedSocial.Repositorio.Seguridad;
namespace RedSocial.Repositorio.Seguridad
{
  public class SolicitudAmistad
    {

      repositorio.Usuario repoUsuario = new repositorio.Usuario();


      public SolicitudAmistad()
      {
          
      }
 

      public void EnviarSolicitudAmistad(Guid IDusuarioReceptor, string nombreemisor)
      {


          using (RedSocialContexto solicitudContexto = new RedSocialContexto())
          {
              var usuarioEmisor = repoUsuario.consultarUsuarioPorNombre(nombreemisor);
              var usurioReceptor = repoUsuario.consultarUsuarioPorId(IDusuarioReceptor);

              EntidadesDominio.SolicitudAmistad solictid = new EntidadesDominio.SolicitudAmistad();
              solictid.UsuarioEnviaSolicitud = usuarioEmisor;
              solictid.usuarioRecibeSolicitud = usurioReceptor;
              solictid.AceptaSolicitud = false;
              solictid.FechaAmistad = DateTime.Now;

              solicitudContexto.Solicitudes.Add(solictid);
              solicitudContexto.SaveChanges();
          }
      }

      public void AceptarSolicitud(Guid id)
      {
       
          using(RedSocialContexto solicitudContexto = new RedSocialContexto()){

          var solicitudAceptar = consultarSolicitud(id);
          solicitudAceptar.AceptaSolicitud = true;

          repositorio.Usuario repoUsuario = new repositorio.Usuario();

          var usuarioActualizarListaAmigos = repoUsuario.consultarUsuarioPorId(solicitudAceptar.UsuarioEnviaSolicitud.Id);
          usuarioActualizarListaAmigos.Amigos.Add(solicitudAceptar.usuarioRecibeSolicitud);
          solicitudContexto.SaveChanges();
          }
      }

      public EntidadesDominio.SolicitudAmistad consultarSolicitud(Guid id)
      {
          using (RedSocialContexto solicitudContexto = new RedSocialContexto())
          {

              var solicitudBuscada = solicitudContexto.Solicitudes.FirstOrDefault(s => s.Id == id);
              return solicitudBuscada;
          }
      }


      public void EliminarSolicitud(Guid id)
      {

          using (RedSocialContexto solicitudContexto = new RedSocialContexto())
          {
              var solicitudEliminar = consultarSolicitud(id);
              solicitudContexto.Solicitudes.Remove(solicitudEliminar);
              solicitudContexto.SaveChanges();
          }
      }


    }
}

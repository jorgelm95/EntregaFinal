using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using entidadesDominio = RedSocial.Dominio.Seguridad;
using repositorio = RedSocial.Repositorio.Seguridad;

namespace RedSocial.Web.Areas.Seguridad.Controllers
{
    public class SolicitudAmistadController : Controller
    {
        // GET: Seguridad/SolicitudAmistad
        repositorio.SolicitudAmistad repoSolicitud = new repositorio.SolicitudAmistad();
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult EnviarSolicitud(string idereceptor, string nombreemi)
        {

             //var idemisor = Guid.Parse(idUsuarioemisor);
           var idreceptor =  Guid.Parse(idereceptor);

           repoSolicitud.EnviarSolicitudAmistad(idreceptor, nombreemi);

           return Content("solicitud enviada");

        }

        public ActionResult AceptarSolicitud(Guid idsolicitud)
        {
            Repositorio.Seguridad.Usuario repoUsuario = new Repositorio.Seguridad.Usuario();
            Repositorio.Seguridad.SolicitudAmistad repoSolicitud = new Repositorio.Seguridad.SolicitudAmistad();

            repoSolicitud.AceptarSolicitud(idsolicitud);    

            return RedirectToAction("Perfil", "Usuario");
        }



    }
}




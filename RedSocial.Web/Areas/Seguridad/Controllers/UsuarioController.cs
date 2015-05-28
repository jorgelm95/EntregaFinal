using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using entidadesDominio = RedSocial.Dominio.Seguridad;
using repositorio = RedSocial.Repositorio.Seguridad;

namespace RedSocial.Web.Areas.Seguridad.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Seguridad/Usuario

        
        repositorio.Usuario repoUsuario = new repositorio.Usuario();

        public ActionResult Index()
        {
            return View("Index");
        }


        public ActionResult CrearCuenta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearCuenta(entidadesDominio.Usuario usuario, HttpPostedFileBase Foto)
        {
            if (ModelState.IsValid)
            {
             
                var nombreArchvioImagen = "";
                var ruta = "";
                    usuario.Id = Guid.NewGuid();

                    nombreArchvioImagen = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Foto.FileName);
                    ruta =  Path.Combine(Server.MapPath("/imagenes/"),nombreArchvioImagen);
                    var rutaImagen = (nombreArchvioImagen);
                    Foto.SaveAs(ruta);

                    usuario.Foto = rutaImagen;

                    @ViewBag.rutaImagen = usuario.Foto;

                    repoUsuario.GuardarUsuario(usuario);
                    return RedirectToAction("Index", "Home");   
            }
            else
            {
                @ViewBag.ErrorCuenta = "llene todos los campos porfavor";
                return View();
            }
        }


        public ActionResult ValidarCorreo(string correoValidar)
        {
            var usuario = repoUsuario.ValidarCorreo(correoValidar);

            if (usuario != null)
            {
                return Json(new {estado = "NOOK"}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new {estado="OK"}, JsonRequestBehavior.AllowGet);
            }
           
        }

        public ActionResult EditarUsuario(Guid id)
        {
            var usuario = repoUsuario.consultarUsuarioPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult EditarUsuario(entidadesDominio.Usuario usuario, HttpPostedFileBase Foto)
        {


                //var nombreArchvioImagen = "";
               // var ruta = "";
               // usuario.Id = Guid.NewGuid();
                
                //nombreArchvioImagen = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Foto.FileName);
               /* ruta = Path.Combine(Server.MapPath("/imagenes/"), nombreArchvioImagen);
                var rutaImagen = (nombreArchvioImagen);
                Foto.SaveAs(ruta);

                usuario.Foto = rutaImagen;
            */

                var usuarioEditar = repoUsuario.consultarUsuarioPorId(usuario.Id);
                usuarioEditar.Nombre = usuario.Nombre;
                usuarioEditar.Apellidos = usuario.Apellidos;
                usuarioEditar.Email = usuario.Email;
               // usuarioEditar.Foto = usuario.Foto;
                usuarioEditar.Contraseña = usuario.Contraseña;
                usuarioEditar.ConfirmacionContraseña = usuario.ConfirmacionContraseña;
                usuarioEditar.BloqueoCuenta = usuario.BloqueoCuenta;

                repoUsuario.EditarUsuario(usuario);
                return RedirectToAction("Perfil", "Usuario", new { id = usuario.Id,area = "Seguridad"});
                      
        }


        [HttpPost]
        public ActionResult Login(string usuario, string clave)
        {            
            var usuarioValidar = repoUsuario.Login(usuario, clave);
            if (usuarioValidar !=  null && usuarioValidar.BloqueoCuenta == false)
            {

                FormsAuthentication.SetAuthCookie(usuarioValidar.NombreUsuario, false);
                var usuarioSerializado = Json(usuarioValidar);
                repoUsuario.resetearUsuario(usuarioValidar);
             
                return Json(new { url = Url.Action("Perfil", "Usuario", new { id = usuarioValidar.Id, area = "Seguridad"})});
              
              }
            else
            {
                // string intentosmalos =  repoUsuario.itentosFallidos(usuario);
               // if(Convert.ToInt32(intentosmalos) == 3){

                 //   repoUsuario.bloquearCuenta(usuario);
                
                return Json(new { estado = "invalido"});

            }
            
        }

        public ActionResult Perfil(Guid id)
        {

            var usuarioLogueado = repoUsuario.consultarUsuarioPorId(id);

            ViewBag.correo = usuarioLogueado.Email;
            ViewBag.Id = usuarioLogueado.Id;
            ViewBag.correo = "ejemplo@gmail.com";
            var nomUsuario = usuarioLogueado.Nombre;
            ViewBag.nombre = nomUsuario;
            return View(usuarioLogueado);
        }


        public ActionResult VerPerfil(Guid id)
        {
            var usuario = repoUsuario.consultarUsuarioPorId(id);
            return View(usuario);
        }

        // modificar metodo de manera asincrona
        public ActionResult BuscarAmigos(string palabra)
        {
            List<entidadesDominio.Usuario> amigosEncontrados = repoUsuario.ListaUsuariosPorNombre(palabra);

            var contidadAmigos = amigosEncontrados.Count();
            if (contidadAmigos > 0)
            {
                ViewBag.ListaAmigosBuscados = amigosEncontrados.ToList();
                return PartialView(amigosEncontrados);

            }
            else
            {
                return Content("no hay amigos");
            }
            

           /* if (amigosEncontrados != null)
            { 
             var listaAmigos =  Json(amigosEncontrados);
                return Json(new{amigos = listaAmigos, estado="OK", numeroFilas = listaAmigos.MaxJsonLength}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new {mensaje = "no se encontraron amigos" }, JsonRequestBehavior.AllowGet);
            }
          */  
        }



        


    }
}
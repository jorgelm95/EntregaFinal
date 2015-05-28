using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using entidadesDominio = RedSocial.Dominio.Seguridad;
using repo = RedSocial.Repositorio.Seguridad;
namespace RedSocial.Servicios.Controllers
{
    public class UsuarioController : ApiController
    {


        public  IEnumerable<entidadesDominio.Usuario>Get()
        {
            repo.Usuario repoUasuario = new repo.Usuario();
            List<entidadesDominio.Usuario> listaUsuarios = new List<entidadesDominio.Usuario>();
             listaUsuarios = repoUasuario.listaUsuarios();
             return listaUsuarios;
        }

    }
}

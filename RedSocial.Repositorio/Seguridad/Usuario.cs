using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using EntidadesDominio = RedSocial.Dominio.Seguridad;

namespace RedSocial.Repositorio.Seguridad
{
    public class Usuario
    {
     private   RedSocialContexto contexto;
        public Usuario()
        {
            contexto = new RedSocialContexto();
        }

        public void GuardarUsuario(EntidadesDominio.Usuario usuario)
        {
            usuario.BloqueoCuenta = false;
            usuario.intentosFallidos = Convert.ToString(0);
            contexto.Usuarios.Add(usuario);
            
            contexto.SaveChanges();
        }


        public EntidadesDominio.Usuario consultarUsuarioPorId(Guid id)
        {
            var usuarioConsultar = contexto.Usuarios.FirstOrDefault(u => u.Id == id);
            return usuarioConsultar;
        }

        public void EditarUsuario(EntidadesDominio.Usuario usuario)
        {
            var usuarioEditar = consultarUsuarioPorId(usuario.Id);
            usuario.Nombre = usuarioEditar.Nombre;
            usuario.Apellidos = usuarioEditar.Apellidos;
            usuario.Email = usuarioEditar.Email;
            usuario.Contraseña = usuarioEditar.Contraseña;
            usuario.ConfirmacionContraseña = usuarioEditar.ConfirmacionContraseña;
            usuario.BloqueoCuenta = usuarioEditar.BloqueoCuenta;
            contexto.SaveChanges();
        }

        public void EliminarUsuario(EntidadesDominio.Usuario usuario)
        {
            var usuarioEliminar = consultarUsuarioPorId(usuario.Id);
            contexto.Usuarios.Remove(usuarioEliminar);
            contexto.SaveChanges();
        }


        public EntidadesDominio.Usuario Login(string nombreusuario, string contraseña)
        {
            var usuarioValidado = contexto.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreusuario && u.Contraseña == contraseña);

            if (usuarioValidado == null)
            {
               
                return usuarioValidado;
            }
            else
            {
                return usuarioValidado;
            }
        }

        public EntidadesDominio.Usuario consultarUsuarioPorNombre(string nombreemi)
        {
            var usuario = contexto.Usuarios.FirstOrDefault(u => u.Nombre == nombreemi);
            return usuario;
        }

        public EntidadesDominio.Usuario ValidarCorreo(string correo)
        {
            var usuario = contexto.Usuarios.FirstOrDefault(u => u.Email == correo);
            return usuario;
        }


        public List<EntidadesDominio.Usuario> ListaUsuariosPorNombre(string nombre)
        {
            List<EntidadesDominio.Usuario> listaUsuarios = contexto.Usuarios.Where(u => u.Nombre.Contains(nombre)).ToList();
            return listaUsuarios;
        }


        public List<EntidadesDominio.Usuario> Amigos(Guid idusuario)
        {
            List<EntidadesDominio.Usuario> listaAmigos = new List<EntidadesDominio.Usuario>();

            var usuario = consultarUsuarioPorId(idusuario);

            listaAmigos = usuario.Amigos.ToList();
            return listaAmigos;
        }


        public EntidadesDominio.Usuario consultarUsuarioPorNombreUsuario(string nombreUsuario)
        {
            var usuario = contexto.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
            return usuario;
        }

        public void resetearUsuario(EntidadesDominio.Usuario usuario)
        {
            var usuarioResetear = consultarUsuarioPorId(usuario.Id);
            usuarioResetear.intentosFallidos = Convert.ToString(0);
            contexto.SaveChanges();
        }


        public string itentosFallidos(string nombreusuario)
        {
            EntidadesDominio.Usuario usuario = consultarUsuarioPorNombreUsuario(nombreusuario);
           
            string intentosMalos = usuario.intentosFallidos;

            var intentos = "1 intento malo";
            var malos = Convert.ToString(intentos);
            usuario.intentosFallidos = intentos;
           string numeroIntentos_fallidos = usuario.intentosFallidos;     
           contexto.SaveChanges();
           return numeroIntentos_fallidos;
        }
 

        public void bloquearCuenta(string nombreusuario)
        {
            var usuarioBloquear = consultarUsuarioPorNombreUsuario(nombreusuario);
            usuarioBloquear.BloqueoCuenta = true;         
            contexto.SaveChanges();

        }

        public List<EntidadesDominio.Usuario> listaUsuarios()
        {
            return contexto.Usuarios.ToList();
        }

    }
}

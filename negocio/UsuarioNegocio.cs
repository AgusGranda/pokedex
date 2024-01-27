using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {

        public void registrar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {

                datos.setearProcedure("AltaUsuario");
                datos.cargarParametros("@email", usuario.Email);
                datos.cargarParametros("@pass", usuario.Pass);
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }


        public bool loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id,Admin, ImagenPerfil, Nombre, Apellido From USUARIOS where Email= @user AND Pass = @pass");
                datos.cargarParametros("@user", usuario.Email);
                datos.cargarParametros("@pass", usuario.Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.TipoUsuario = (bool)(datos.Lector["Admin"]);
                    if (!(datos.Lector["Nombre"]  is DBNull))
                        usuario.ImagenPerfil = (string)(datos.Lector["ImagenPerfil"]);

                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["Nombre"];

                    if (datos.Lector["Apellido"] is DBNull)
                        usuario.Apellido = (string)datos.Lector["Apellido"];

                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public void actualizar(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update USUARIOS set ImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido  Where Id=@id");
                datos.cargarParametros("@imagen", (object)user.ImagenPerfil ?? DBNull.Value);
                datos.cargarParametros("@nombre", user.Nombre);
                datos.cargarParametros("@apellido", user.Apellido);
                datos.cargarParametros("@id",user.Id);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

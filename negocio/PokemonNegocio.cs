using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos data = new AccesoDatos();

            try
            {

                data.setearConsulta("select POKEMONS.Id,Numero,Nombre,POKEMONS.Descripcion,UrlImagen,Tipo.Descripcion Tipo,Debilidad.Descripcion Debilidad, POKEMONS.IdTipo, POKEMONS.IdDebilidad from POKEMONS inner join ELEMENTOS as Tipo on Tipo.id = IdTipo inner join ELEMENTOS as Debilidad on Debilidad.id = IdDebilidad where Activo = 1");
                data.ejecutarLectura();

                while (data.Lector.Read())
                {
                    Pokemon aux = new Pokemon();

                    aux.Id = (int)data.Lector["Id"];
                    aux.Numero = (int)data.Lector["Numero"];
                    aux.Nombre = (string)data.Lector["Nombre"];
                    aux.Descripcion = (string)data.Lector["Descripcion"];

                    if (!(data.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)data.Lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)data.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)data.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)data.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)data.Lector["Debilidad"];


                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }

        public List<Pokemon> listarConSp()
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos data = new AccesoDatos();

            try
            {


                //data.setearConsulta("select POKEMONS.Id,Numero,Nombre,POKEMONS.Descripcion,UrlImagen,Tipo.Descripcion Tipo,Debilidad.Descripcion Debilidad, POKEMONS.IdTipo, POKEMONS.IdDebilidad from POKEMONS inner join ELEMENTOS as Tipo on Tipo.id = IdTipo inner join ELEMENTOS as Debilidad on Debilidad.id = IdDebilidad where Activo = 1");
                //data.ejecutarLectura();

                data.setearProcedure("storedListar");
                data.ejecutarLectura();

                while (data.Lector.Read())
                {
                    Pokemon aux = new Pokemon();

                    aux.Id = (int)data.Lector["Id"];
                    aux.Numero = (int)data.Lector["Numero"];
                    aux.Nombre = (string)data.Lector["Nombre"];
                    aux.Descripcion = (string)data.Lector["Descripcion"];

                    if (!(data.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)data.Lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)data.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)data.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)data.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)data.Lector["Debilidad"];


                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }

        public void agregar(Pokemon poke)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearConsulta("insert into POKEMONS (Numero,Nombre,Descripcion,IdTipo,IdDebilidad,UrlImagen,Activo) values(" + poke.Numero + ",'" + poke.Nombre + "','" + poke.Descripcion + "',@IdTipo,@IdDebilidad,@UrlImagen,1)");
                data.cargarParametros("@IdTipo", poke.Tipo.Id);
                data.cargarParametros("@IdDebilidad", poke.Debilidad.Id);
                data.cargarParametros("@UrlImagen", poke.UrlImagen);
                data.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }

        }

        public void agregarConSp(Pokemon poke)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearProcedure("storedAltaPokemon");

                data.cargarParametros("@numero", poke.Numero);
                data.cargarParametros("@nombre", poke.Nombre);
                data.cargarParametros("@descripcion", poke.Descripcion);
                data.cargarParametros("@imagen", poke.UrlImagen);
                data.cargarParametros("@idTipo", poke.Tipo.Id);
                data.cargarParametros("@idDebilidad", poke.Debilidad.Id);

                data.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }

        }

        public void modificar(Pokemon poke)
        {

            AccesoDatos data = new AccesoDatos();

            try
            {
                // editar consulta sql
                data.setearConsulta("update POKEMONS set Numero=@numero , Nombre =@nombre, Descripcion=@descripcion, UrlImagen=@img,IdTipo=@tipo , IdDebilidad=@debilidad  where Id=@id ");
                data.cargarParametros("@numero", poke.Numero);
                data.cargarParametros("@nombre", poke.Nombre);
                data.cargarParametros("@descripcion", poke.Descripcion);
                data.cargarParametros("@img", poke.UrlImagen);
                data.cargarParametros("@tipo", poke.Tipo.Id);
                data.cargarParametros("@debilidad", poke.Debilidad.Id);
                data.cargarParametros("@id", poke.Id);
                data.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }

        }

        public void modificarConSp(Pokemon poke)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearProcedure("storedModificarPokemon");

                data.cargarParametros("@id", poke.Id);
                data.cargarParametros("@numero",poke.Numero);
                data.cargarParametros("@nombre",poke.Nombre);
                data.cargarParametros("@descripcion",poke.Descripcion);
                data.cargarParametros("@img",poke.UrlImagen);
                data.cargarParametros("@tipo",poke.Tipo.Id);
                data.cargarParametros("@debilidad", poke.Debilidad.Id);

                data.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }


        }

        public void eliminar(int id)
        {


            try
            {
                AccesoDatos data = new AccesoDatos();
                data.setearConsulta("delete from POKEMONS where id=@Id");
                data.cargarParametros("@Id", id);
                data.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminacionLogica(int id)
        {
            try
            {
                AccesoDatos data = new AccesoDatos();
                data.setearConsulta("update POKEMONS set Activo=0 where id=@Id");
                data.cargarParametros("@Id", id);
                data.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<Pokemon> filtrar(string campo, string subcampo, string filtro)
        {
            List<Pokemon> listaFiltrada = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                string consulta = "select POKEMONS.Id,Numero,Nombre,POKEMONS.Descripcion,UrlImagen,Tipo.Descripcion Tipo,Debilidad.Descripcion Debilidad, POKEMONS.IdTipo, POKEMONS.IdDebilidad from POKEMONS inner join ELEMENTOS as Tipo on Tipo.id = IdTipo inner join ELEMENTOS as Debilidad on Debilidad.id = IdDebilidad where Activo = 1 And ";

                if (campo == "Número")
                {
                    switch (subcampo)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                        default:
                            consulta += "Numero = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (subcampo)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (subcampo)
                    {
                        case "Comienza con":
                            consulta += "P.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "P.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    listaFiltrada.Add(aux);
                }

                return listaFiltrada;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Pokemon filtrarPorId(int id)
        {

            AccesoDatos data = new AccesoDatos();
            Pokemon pokemon = new Pokemon();

            try
            {

                data.setearProcedure("storedFiltoID");
                data.cargarParametros("@id", id);
                data.ejecutarLectura();

                while ( data.Lector.Read()) {


                    pokemon.Id = (int)data.Lector["Id"];
                    pokemon.Numero = (int)data.Lector["Numero"];
                    pokemon.Nombre = (string)data.Lector["Nombre"];
                    pokemon.Descripcion = (string)data.Lector["Descripcion"];
                    pokemon.UrlImagen = (string)data.Lector["UrlImagen"];

                    pokemon.Tipo = new Elemento();
                    pokemon.Tipo.Id = (int)data.Lector["IdTipo"];
                    pokemon.Debilidad = new Elemento();
                    pokemon.Debilidad.Id = (int)data.Lector["IdDebilidad"];
                }
          
                return pokemon;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }

        }

    }




}

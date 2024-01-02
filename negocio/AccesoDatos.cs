using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;

namespace negocio
{
    internal class AccesoDatos
    {

        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        public SqlDataReader Lector
        { get { return lector; } }


        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS;database=POKEDEX_DB;integrated security = true");
            comando = new SqlCommand();

        }

       

        public void setearConsulta(string consulta)
        {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
        }

        public void setearProcedure(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ejecutarLectura()
        {

            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void cargarParametros(string nombre, object numero)
        {
            comando.Parameters.AddWithValue(nombre, numero);
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();

            conexion.Close();
        }   



    }
}

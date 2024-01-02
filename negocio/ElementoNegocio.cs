using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ElementoNegocio
    {
        public List<Elemento> listar()
        {
			List<Elemento> lista = new List<Elemento>();
			AccesoDatos data = new AccesoDatos();	

			try
			{
				data.setearConsulta("select id, Descripcion from ELEMENTOS");
				data.ejecutarLectura();

				while (data.Lector.Read())
				{
					Elemento aux = new Elemento();
					aux.Id = (int)data.Lector["id"];
					aux.Descripcion = (string)data.Lector["Descripcion"];

					lista.Add(aux);
				}

				return lista;
			}
			catch (Exception ex)
			{

				throw ex;
			}

        }
    }
}

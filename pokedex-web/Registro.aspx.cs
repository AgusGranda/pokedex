using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace pokedex_web
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                string email = txtEmail.Text;
                string pass = txtPass.Text;

                Usuario user = new Usuario(email,pass);

                negocio.registrar(user);

                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
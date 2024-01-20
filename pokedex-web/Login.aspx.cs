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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                string email = txtEmail.Text;
                string pass = txtPass.Text;

                Usuario aux = new Usuario(email,pass,false);
 
                if (negocio.loguear(aux))
                {
                    Session.Add("usuario",aux);
                    Response.Redirect("Default.aspx");

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
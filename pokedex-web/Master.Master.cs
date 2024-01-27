using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace pokedex_web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login || Page is Default || Page is Registro))
            {
                if (!(Seguridad.sesionActiva(Session["usuario"])))
                    Response.Redirect("Login.aspx", false);
            }

            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Usuario user = (Usuario)Session["usuario"];
                imgPerfil.ImageUrl = user.ImagenPerfil != null ? "~/Images/" + user.ImagenPerfil : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTIVQOt-9G5UlfqH-mzgSK983qIgSI6QKyPK5w43UFIHA&s";
            }
            else
                imgPerfil.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTIVQOt-9G5UlfqH-mzgSK983qIgSI6QKyPK5w43UFIHA&s";
        }
    

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}
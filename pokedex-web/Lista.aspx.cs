using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace pokedex_web
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Seguridad.sesionActiva(Session["usuario"]) && Seguridad.sesionAdmin(Session["usuario"])))
            {
                Session.Add("error", "No tienes permisos de administrador");
                Response.Redirect("Error.aspx");
            }
          
            PokemonNegocio negocio = new PokemonNegocio();
            Session.Add("Lista", negocio.listarConSp());
            dgvLista.DataSource = Session["Lista"];
            dgvLista.DataBind();

            filtroAvanzado();




        }

        protected void dgvLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvLista.SelectedDataKey.Value.ToString();
            Response.Redirect("Formulario.aspx?id=" + id);
        }

        protected void dgvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvLista.PageIndex = e.NewPageIndex;
            dgvLista.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["Lista"];
            List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            dgvLista.DataSource = listaFiltrada;
            dgvLista.DataBind();

        }


        protected void filtroAvanzado()
        {
            if (!IsPostBack)
            {
                ddlCriterio.Items.Add("Nombre");
                ddlCriterio.Items.Add("Numero");
                ddlCriterio.Items.Add("Tipo");
            }
            if (ddlCriterio.SelectedValue.ToString() == "Nombre" || ddlCriterio.SelectedValue.ToString() == "Tipo")
            {
                ddlSubcriterio.Items.Clear();
                ddlSubcriterio.Items.Add("Contiene");
                ddlSubcriterio.Items.Add("Comienza con");
                ddlSubcriterio.Items.Add("Termina con");

            }
            else if (ddlCriterio.SelectedValue.ToString() == "Numero")
            {
                ddlSubcriterio.Items.Clear();
                ddlSubcriterio.Items.Add("Mayor a");
                ddlSubcriterio.Items.Add("Menor a");
                ddlSubcriterio.Items.Add("Igual a");
            }



        }

        protected void btnBuscarAvanzado_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();

            string criterio = ddlCriterio.SelectedValue.ToString();
            string subCriterio = ddlSubcriterio.SelectedValue.ToString();
            string filtro = txtFiltroAvanzado.Text;
            bool activo = chActivo.Checked;

            try
            {
                List<Pokemon> listaFiltrada = negocio.filtrar(criterio, subCriterio, filtro, activo);
                dgvLista.DataSource = listaFiltrada;
                dgvLista.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
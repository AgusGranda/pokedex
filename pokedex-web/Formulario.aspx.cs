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
    public partial class Formulario : System.Web.UI.Page
    {
        public string urlImagen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            if (!IsPostBack)
            {
                ElementoNegocio negocio = new ElementoNegocio();
                List<Elemento> lista = negocio.listar();

                ddlTipo.DataSource = lista;
                ddlTipo.DataValueField = "Id";
                ddlTipo.DataTextField = "Descripcion";
                ddlTipo.DataBind();

                ddlDebilidad.DataSource = lista;
                ddlDebilidad.DataValueField = "Id";
                ddlDebilidad.DataTextField = "Descripcion";
                ddlDebilidad.DataBind();
            }

            if (Request.QueryString["id"] != null && !IsPostBack)
            {

                int id = int.Parse(Request.QueryString["id"]);

                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon seleccionado = negocio.filtrarPorId(id);


                txtId.Text = seleccionado.Id.ToString();
                txtNombre.Text = seleccionado.Nombre;
                txtNumero.Text = seleccionado.Numero.ToString();
                txtDescripcion.Text = seleccionado.Descripcion;
                txtImagen.Text = seleccionado.UrlImagen;
                ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();
                txtImagen_TextChanged(sender, e);
            }


        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            urlImagen = txtImagen.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon nuevo = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();


                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtImagen.Text;

                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);


                if(Request.QueryString["id"] == null)
                    negocio.agregarConSp(nuevo);
                else
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSp(nuevo);
                }

                Response.Redirect("Lista.aspx", false);


            }
            catch(Exception ex)
            {

                throw ex;
            }
        }
    }
}
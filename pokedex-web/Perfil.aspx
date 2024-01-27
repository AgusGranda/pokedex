<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="pokedex_web.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Mi Perfil</h2>



    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div class="row">

        <div class="col-6">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"/>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnAceptar_Click"/>
                <a href="Default.aspx" class="btn btn-secondary">Cancelar</a>
            </div>
        </div>

        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagen" class="form-label">Imagen</label>
                        <input type="file" id="txtImagen" runat="server" class="form-control" />
                    </div>
                    <div class="mb-3">
                        <asp:Image ID="imgNuevoPerfil" runat="server" ImageUrl="https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png"
                            CssClass="img-fluid mb-3" Width="50%" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>




</asp:Content>

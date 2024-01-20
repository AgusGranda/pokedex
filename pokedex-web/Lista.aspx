<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="pokedex_web.Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row align-items-end">
        <div class="col-6">
            <label for="txtFiltro" class="form-label">Filtro</label>
            <div class="mb-3">
                <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <asp:CheckBox ID="chAvanzado" runat="server" AutoPostBack="true" />
                <label for="chAvanzado">Filtro Avanzado</label>
            </div>
        </div>
    </div>


    <%if (chAvanzado.Checked)
        {  %>

    <div class="row">

        <div class="col-3">
            <label for="ddlCriterio" class="form-label">Criterio</label>
            <div class="mb-3">
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <label for="ddlSubcriterio" class="form-label">Subcriterio</label>
            <div class="mb-3">
                <asp:DropDownList ID="ddlSubcriterio" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <label for="txtFiltroAvanzado" class="form-label">Filtro</label>
            <div class="mb-3">
                <asp:TextBox ID="txtFiltroAvanzado" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>
        <div class="col-3">
            <label for="chActivo" class="form-label">Activo</label>
            <div class="mb-3">
                <asp:CheckBox ID="chActivo" runat="server" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
            <asp:Button ID="btnBuscarAvanzado" runat="server" Text="Buscar" CssClass="btn-primary" OnClick="btnBuscarAvanzado_Click" />
            </div>
        </div>

    </div>



    <%} %>

    <asp:GridView runat="server" ID="dgvLista" CssClass="table" DataKeyNames="Id"
        OnSelectedIndexChanged="dgvLista_SelectedIndexChanged" AutoGenerateColumns="false"
        OnPageIndexChanging="dgvLista_PageIndexChanging"
        AllowPaging="true" PageSize="3">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Numero" DataField="Numero" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Editar" />
        </Columns>
    </asp:GridView>
    <a href="Formulario.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>

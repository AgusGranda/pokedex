<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="pokedex_web.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView runat="server" ID="dgvLista" CssClass="table" DataKeyNames="Id"
         OnSelectedIndexChanged="dgvLista_SelectedIndexChanged"  AutoGenerateColumns="false" 
         OnPageIndexChanging="dgvLista_PageIndexChanging"
         AllowPaging="true" PageSize="3" >
       <Columns>
           <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
           <asp:BoundField HeaderText="Numero" DataField="Numero" />
           <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
           <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Editar"  />
       </Columns>
    </asp:GridView>
    <a href="Formulario.aspx" class="btn btn-primary" >Agregar</a>
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="pokedex_web.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-4"></div>
    <div class="col-4">
        <div class="mb-3">
            <label for="email" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="user@ejemplo.com"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="pass" class="form-label">Contraseña</label>
            <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" placeholder="****"></asp:TextBox>
        </div>
    </div>
    <div class="col-4"></div>

</div>
<div class="row">
    <div class="col-4"></div>
    <div class="col-2">
        <asp:Button ID="btnRegistro" runat="server" Text="Registrarme" CssClass="btn btn-primary" OnClick="btnRegistro_Click" />
    </div>
    <div class="col-4"></div>
</div>
</asp:Content>
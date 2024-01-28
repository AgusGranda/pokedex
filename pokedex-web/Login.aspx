<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pokedex_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>        
        function validar()
        {
            const txtEmail = document.getElementById("txtEmail");
            if (txtEmail.value == "")
            {
                txtEmail.classList.add("is-invalid");
                return false;

            }
            txtEmail.classList.remove("is-ivalid");
            return true
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <div class="mb-3">
                <label for="email" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" ClientIDMode="Static" runat="server" CssClass="form-control"  placeholder="user@ejemplo.com"></asp:TextBox>
               
            </div>
            <div class="mb-3">
                <label for="pass" class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control"  placeholder="****"></asp:TextBox>
                <asp:RequiredFieldValidator style="color:red" ErrorMessage="Debes ingresar una contraseña valida" ControlToValidate="txtPass" runat="server" />
            </div>
        </div>
        <div class="col-4"></div>

    </div>
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
        </div>
        <div class="col-4"></div>
    </div>
</asp:Content>

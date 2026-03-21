<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Grupo10_ControlPrestamos_ASPNet._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<style>
    /* Contenedor principal similar a la cabecera "Equipos" */
    .login-container {
        max-width: 450px;
        margin: 40px auto;
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    }

    .login-header {
        color: #333;
        font-weight: bold;
        margin-bottom: 20px;
    }

    /* Estilo del botón "Ingresar" basado en "+ Nuevo Equipo" */
    .btn-green {
        background-color: #28a745;
        color: white;
        border: none;
        padding: 10px 20px;
        border-radius: 4px;
        font-weight: 500;
        transition: background-color 0.2s;
    }

    .btn-green:hover {
        background-color: #218838;
        color: white;
        text-decoration: none;
    }

    /* Estilo de los campos de texto basado en el buscador */
    .custom-input {
        border: 1px solid #ced4da;
        border-radius: 4px;
        padding: 8px 12px;
        width: 100%;
        background-color: #f8f9fa;
    }

    /* Estilo de etiquetas */
    .custom-label {
        font-weight: 600;
        color: #444;
        display: block;
        margin-bottom: 5px;
    }

    /* Contenedor de errores */
    .error-msg {
        font-size: 0.85em;
        display: block;
        margin-top: 5px;
    }
</style>

<div class="login-container">
    <h2 class="login-header">Inicio de Sesión</h2>
    <hr />

    <div class="form-group mb-3">
        <asp:Label ID="lblUsuarioText" runat="server" Text="Usuario:" CssClass="custom-label" />
        <asp:TextBox ID="txtUsuario" runat="server" CssClass="custom-input" placeholder="Ej. SM1001" />
        <asp:RequiredFieldValidator 
            ID="rfvUsuario"
            runat="server"
            ControlToValidate="txtUsuario"
            ErrorMessage="¡El usuario es obligatorio!"
            ForeColor="#dc3545"
            CssClass="error-msg" />
    </div>

    <div class="form-group mb-3">
        <asp:Label ID="lblPasswordText" runat="server" Text="Contraseña:" CssClass="custom-label" />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="custom-input" />
        <asp:RequiredFieldValidator 
            ID="rfvPassword"
            runat="server"
            ControlToValidate="txtPassword"
            ErrorMessage="¡La contraseña es obligatoria!"
            ForeColor="#dc3545"
            CssClass="error-msg" />
    </div>

    <div class="mt-4">
        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn-green" OnClick="btnLogin_Click" />
    </div>

    <div class="mt-3">
        <asp:Label ID="lblMensaje" runat="server" ForeColor="#dc3545" />
    </div>
</div>

</asp:Content>

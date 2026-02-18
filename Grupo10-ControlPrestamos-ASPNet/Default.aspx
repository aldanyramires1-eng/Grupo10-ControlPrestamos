 <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Grupo10_ControlPrestamos_ASPNet._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <h3>Inicio de Sesión</h3>
<hr />

<asp:Label ID="lblUsuarioText" runat="server" Text="Usuario:" />
<br />
<asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
&nbsp;
<asp:RequiredFieldValidator 
    ID="rfvUsuario"
    runat="server"
    ControlToValidate="txtUsuario"
    ErrorMessage="El usuario es obligatorio!!"
    ForeColor="Red" />
<br /><br />

<asp:Label ID="lblPasswordText" runat="server" Text="Contraseña:" />
<br />
<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
&nbsp;
<asp:RequiredFieldValidator 
    ID="rfvPassword"
    runat="server"
    ControlToValidate="txtPassword"
    ErrorMessage="La contraseña es obligatoria!!"
    ForeColor="Red" />
<br /><br />

<asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
<br /><br />

<asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />


</asp:Content>

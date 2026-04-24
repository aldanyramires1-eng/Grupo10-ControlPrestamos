<%@ Page Title="Registrar nuevo préstamo" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="PrestamoNuevo.aspx.cs" Inherits="Grupo10_ControlPrestamos_ASPNet.PrestamoNuevo" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; background: #f5f5f5; }
        h2 { color: #222; }
        .contenedor { background: white; padding: 24px; border-radius: 6px; max-width: 520px; box-shadow: 0 1px 4px rgba(0,0,0,.12); }
        .campo { margin-bottom: 14px; }
        .campo label { display: block; font-weight: bold; margin-bottom: 4px; }
        .campo input[type=text], .campo select, .campo input[type=date] {
            width: 100%; padding: 7px 10px; border: 1px solid #ccc;
            border-radius: 4px; box-sizing: border-box; font-size: 14px;
        }
        .error { color: red; font-size: 13px; }
        .btnGuardar { background: #1e6e5e; color: white; border: none; padding: 9px 24px; border-radius: 4px; cursor: pointer; font-size: 15px; }
        .btnGuardar:hover { background: #155045; }
        .btnVolver { background: #888; color: white; border: none; padding: 9px 18px; border-radius: 4px; cursor: pointer; font-size: 14px; margin-left: 10px; text-decoration: none; display: inline-block; }
        .btnVolver:hover { background: #666; }
        .exito { background: #e6f4ea; border: 1px solid #28a745; color: #1a5e28; padding: 12px; border-radius: 4px; margin-bottom: 16px; }
        .vs { background: #fff0f0; border: 1px solid #cc0000; padding: 10px 14px; border-radius: 4px; margin-bottom: 14px; color: #cc0000; }
        .vs ul { margin: 4px 0 0 16px; padding: 0; }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Registrar Nuevo Préstamo</h2>

        <div class="contenedor">

            <asp:Panel ID="pnlExito" runat="server" Visible="false" CssClass="exito">
                <asp:Label ID="lblExito" runat="server" />
            </asp:Panel>

            <asp:ValidationSummary ID="vsErrores" runat="server" CssClass="vs" HeaderText="Se encontraron los siguientes errores:" ShowMessageBox="false" ShowSummary="true" DisplayMode="List" />

            <div class="campo">
                <label>Nombre del Cliente:</label>
                <asp:TextBox ID="txtNombreCliente" runat="server" placeholder="Nombre completo" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombreCliente" ErrorMessage="El nombre del cliente es obligatorio." CssClass="error" Display="Dynamic" Text="* El nombre es obligatorio." />
            </div>

            <div class="campo">
                <label>Artículo / Equipo:</label>
                <asp:DropDownList ID="ddlArticulo" runat="server">
                    <asp:ListItem Text="Seleccione…" Value="" />
                    <asp:ListItem Text="Teclado Sintetizador" Value="Teclado Sintetizador" />
                    <asp:ListItem Text="Proyector Epson"      Value="Proyector Epson" />
                    <asp:ListItem Text="Libro de C#"          Value="Libro de C#" />
                    <asp:ListItem Text="Cable HDMI"           Value="Cable HDMI" />
                    <asp:ListItem Text="Laptop Dell"          Value="Laptop Dell" />
                    <asp:ListItem Text="Tablet Samsung"       Value="Tablet Samsung" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlArticulo" InitialValue="" ErrorMessage="Debe seleccionar un artículo." CssClass="error" Display="Dynamic" Text="* Debe seleccionar un artículo." />
            </div>

            <div class="campo">
                <label>Fecha Esperada de Devolución:</label>
                <asp:TextBox ID="txtFechaDevolucion" runat="server" TextMode="Date" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFechaDevolucion" ErrorMessage="La fecha de devolución es obligatoria." CssClass="error" Display="Dynamic" Text="* La fecha es obligatoria." />
                <asp:CustomValidator ID="cvFecha" runat="server" ControlToValidate="txtFechaDevolucion" OnServerValidate="cvFecha_ServerValidate" ErrorMessage="La fecha debe ser posterior a hoy." CssClass="error" Display="Dynamic" Text="* La fecha debe ser posterior a hoy." />
            </div>

            <div class="campo">
                <label>Estado Inicial:</label>
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem Text="Prestado"  Value="Prestado" />
                    <asp:ListItem Text="Devuelto"  Value="Devuelto" />
                    <asp:ListItem Text="Atrasado"  Value="Atrasado" />
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Préstamo" CssClass="btnGuardar" OnClick="btnGuardar_Click" />
            <a href="Historial.aspx" class="btnVolver">← Ver Historial</a>

        </div>
  </asp:Content>
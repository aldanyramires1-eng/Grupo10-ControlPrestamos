<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrestamoNuevo.aspx.cs" Inherits="Grupo10_ControlPrestamos_ASPNet.PrestamoNuevo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrar Nuevo Préstamo</title>
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
</head>
<body>
    <form id="form1" runat="server">
        <h2>Registrar Nuevo Préstamo</h2>

        <div class="contenedor">

            <asp:Panel ID="pnlExito" runat="server" Visible="false" CssClass="exito">
                <asp:Label ID="lblExito" runat="server" />
            </asp:Panel>

            <asp:ValidationSummary ID="vsErrores" runat="server"
                CssClass="vs"
                HeaderText="Se encontraron los siguientes errores:"
                ShowMessageBox="false"
                ShowSummary="true"
                DisplayMode="List" />

            <!-- Carnet -->
            <div class="campo">
                <label>Carnet del Estudiante:</label>
                <asp:TextBox ID="txtCarnet" runat="server" placeholder="Ej. JP1001" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="txtCarnet"
                    ErrorMessage="El carnet es obligatorio."
                    CssClass="error" Display="Dynamic" Text="* El carnet es obligatorio." />
            </div>

            <!-- Nombre -->
            <div class="campo">
                <label>Nombre del Estudiante:</label>
                <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre completo" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="txtNombre"
                    ErrorMessage="El nombre es obligatorio."
                    CssClass="error" Display="Dynamic" Text="* El nombre es obligatorio." />
            </div>

            <!-- Equipo -->
            <div class="campo">
                <label>Libro / Equipo:</label>
                <asp:DropDownList ID="ddlEquipo" runat="server">
                    <asp:ListItem Text="Seleccione…" Value="" />
                    <asp:ListItem Text="Teclado Sintetizador" Value="Teclado Sintetizador" />
                    <asp:ListItem Text="Proyector EPSON"      Value="Proyector EPSON" />
                    <asp:ListItem Text="Libro de C#"          Value="Libro de C#" />
                    <asp:ListItem Text="Cable HDMI"           Value="Cable HDMI" />
                    <asp:ListItem Text="Laptop Dell"          Value="Laptop Dell" />
                    <asp:ListItem Text="Tablet Samsung"       Value="Tablet Samsung" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="ddlEquipo"
                    InitialValue=""
                    ErrorMessage="Debe seleccionar un equipo o libro."
                    CssClass="error" Display="Dynamic" Text="* Debe seleccionar un equipo o libro." />
            </div>

            <!-- Fecha -->
            <div class="campo">
                <label>Fecha Esperada de Devolución:</label>
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="txtFecha"
                    ErrorMessage="La fecha de devolución es obligatoria."
                    CssClass="error" Display="Dynamic" Text="* La fecha es obligatoria." />
                <asp:CustomValidator ID="cvFecha" runat="server"
                    ControlToValidate="txtFecha"
                    OnServerValidate="cvFecha_ServerValidate"
                    ErrorMessage="La fecha debe ser posterior a hoy."
                    CssClass="error" Display="Dynamic" Text="* La fecha debe ser posterior a hoy." />
            </div>

            <!-- Estado -->
            <div class="campo">
                <label>Estado:</label>
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem Text="A tiempo"  Value="A tiempo" />
                    <asp:ListItem Text="Atrasados" Value="Atrasados" />
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Préstamo"
                CssClass="btnGuardar" OnClick="btnGuardar_Click" />
            <a href="Equipos.aspx" class="btnVolver">← Volver</a>

        </div>
    </form>
</body>
</html>


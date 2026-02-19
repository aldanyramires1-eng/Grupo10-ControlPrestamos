<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipoNuevo.aspx.cs" Inherits="Grupo10_ControlPrestamos_ASPNet.EquipoNuevo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agregar Equipo</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; background: #f5f5f5; }
        h2 { color: #222; }
        .contenedor { background: white; padding: 24px; border-radius: 6px; max-width: 520px; box-shadow: 0 1px 4px rgba(0,0,0,.12); }
        .campo { margin-bottom: 14px; }
        .campo label { display: block; font-weight: bold; margin-bottom: 4px; }
        .campo input[type=text], .campo select, .campo textarea {
            width: 100%; padding: 7px 10px; border: 1px solid #ccc;
            border-radius: 4px; box-sizing: border-box; font-size: 14px;
        }
        .campo textarea { resize: vertical; height: 80px; }
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
        <h2>Agregar Nuevo Equipo</h2>

        <div class="contenedor">

            <!-- Éxito -->
            <asp:Panel ID="pnlExito" runat="server" Visible="false" CssClass="exito">
                <asp:Label ID="lblExito" runat="server" />
            </asp:Panel>

            <!-- ValidationSummary -->
            <asp:ValidationSummary ID="vsErrores" runat="server"
                CssClass="vs"
                HeaderText="Se encontraron los siguientes errores:"
                ShowMessageBox="false"
                ShowSummary="true"
                DisplayMode="List" />

            <!-- Código del equipo -->
            <div class="campo">
                <label>Código del Equipo:</label>
                <asp:TextBox ID="txtCodigo" runat="server" placeholder="Ej. EQ-001" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="txtCodigo"
                    ErrorMessage="El código del equipo es obligatorio."
                    CssClass="error" Display="Dynamic" Text="* El código es obligatorio." />
            </div>

            <!-- Nombre del equipo -->
            <div class="campo">
                <label>Nombre del Equipo:</label>
                <asp:TextBox ID="txtNombre" runat="server" placeholder="Ej. Proyector EPSON" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="txtNombre"
                    ErrorMessage="El nombre del equipo es obligatorio."
                    CssClass="error" Display="Dynamic" Text="* El nombre es obligatorio." />
            </div>

            <!-- Categoría -->
            <div class="campo">
                <label>Categoría:</label>
                <asp:DropDownList ID="ddlCategoria" runat="server">
                    <asp:ListItem Text="Seleccione…"      Value="" />
                    <asp:ListItem Text="Electrónico"      Value="Electrónico" />
                    <asp:ListItem Text="Libro / Material" Value="Libro / Material" />
                    <asp:ListItem Text="Accesorio"        Value="Accesorio" />
                    <asp:ListItem Text="Instrumento"      Value="Instrumento" />
                    <asp:ListItem Text="Otro"             Value="Otro" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="ddlCategoria"
                    InitialValue=""
                    ErrorMessage="Debe seleccionar una categoría."
                    CssClass="error" Display="Dynamic" Text="* Seleccione una categoría." />
            </div>

            <!-- Cantidad disponible -->
            <div class="campo">
                <label>Cantidad Disponible:</label>
                <asp:TextBox ID="txtCantidad" runat="server" placeholder="Ej. 5" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="txtCantidad"
                    ErrorMessage="La cantidad es obligatoria."
                    CssClass="error" Display="Dynamic" Text="* La cantidad es obligatoria." />
                <asp:RangeValidator runat="server"
                    ControlToValidate="txtCantidad"
                    Type="Integer"
                    MinimumValue="1"
                    MaximumValue="999"
                    ErrorMessage="La cantidad debe ser un número entre 1 y 999."
                    CssClass="error" Display="Dynamic" Text="* Ingrese un número entre 1 y 999." />
            </div>

            <!-- Estado del equipo -->
            <div class="campo">
                <label>Estado del Equipo:</label>
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem Text="Disponible"  Value="Disponible" />
                    <asp:ListItem Text="En préstamo" Value="En préstamo" />
                    <asp:ListItem Text="En reparación" Value="En reparación" />
                    <asp:ListItem Text="Dado de baja" Value="Dado de baja" />
                </asp:DropDownList>
            </div>

            <!-- Descripción -->
            <div class="campo">
                <label>Descripción <small>(opcional)</small>:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine"
                    placeholder="Descripción breve del equipo..." />
            </div>

            <!-- Botones -->
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Equipo"
                CssClass="btnGuardar" OnClick="btnGuardar_Click" />
            <a href="Equipos.aspx" class="btnVolver">← Volver</a>

        </div>
    </form>
</body>
</html>


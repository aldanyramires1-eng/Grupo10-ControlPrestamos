<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="Grupo10_ControlPrestamos_ASPNet.Historial" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Préstamos Activos</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; background: #f5f5f5; }
        .contenedor { background: white; padding: 24px; border-radius: 6px; box-shadow: 0 1px 4px rgba(0,0,0,.12); }
        .tabla { width: 100%; border-collapse: collapse; margin-top: 20px; }
        .tabla th, .tabla td { border: 1px solid #ddd; padding: 8px; text-align: left; }
        .tabla th { background-color: #1e6e5e; color: white; }
        .controles { margin-bottom: 15px; }
        .controles input, .controles select, .controles button { padding: 6px; margin-right: 10px; }
        .btnNuevo { background: #28a745; color: white; border: none; padding: 8px 16px; border-radius: 4px; cursor: pointer; text-decoration: none; display: inline-block; float: right; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <a class="btnNuevo" href="PrestamoNuevo.aspx">+ Nuevo Préstamo</a>
            <h2>Control de Préstamos</h2>
            
            <div class="controles">
                <label>Buscar Cliente:</label>
                <asp:TextBox ID="txtBuscarCliente" runat="server" placeholder="Ej. Carlos..."></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                
                <label>Filtrar por Estado: </label>
                <asp:DropDownList ID="ddlFiltroEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFiltroEstado_SelectedIndexChanged">
                    <asp:ListItem Text="Todos" Value="Todos" />
                    <asp:ListItem Text="Prestado" Value="Prestado" />
                    <asp:ListItem Text="Atrasado" Value="Atrasado" />
                    <asp:ListItem Text="Devuelto" Value="Devuelto" />
                </asp:DropDownList>
            </div>

            <asp:GridView ID="gvHistorial" runat="server" AutoGenerateColumns="False" CssClass="tabla">
                <Columns>
                    <asp:BoundField DataField="IdPrestamo" HeaderText="ID" />
                    <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="Articulo" HeaderText="Artículo" />
                    <asp:BoundField DataField="FechaPrestamo" HeaderText="F. Préstamo" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="FechaDevolucionEsperada" HeaderText="F. Dev. Esperada" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
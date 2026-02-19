<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="Grupo10_ControlPrestamos_ASPNet.Historial" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Historial de Préstamos</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        .filtros { margin-bottom: 20px; padding: 15px; background-color: #f4f4f4; border-radius: 8px; }
        .boton { padding: 5px 15px; background-color: #007bff; color: white; border: none; cursor: pointer; }
        .boton:hover { background-color: #0056b3; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Historial de Préstamos</h2>

            <div class="filtros">
                <asp:Label ID="lblBuscar" runat="server" Text="Buscar Carnet o Estudiante: " Font-Bold="true"></asp:Label>
                <asp:TextBox ID="txtBuscar" runat="server" Width="200px" Placeholder="Ej. SM1001 o Juan" OnTextChanged="txtBuscar_TextChanged"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text=" Buscar" CssClass="boton" OnClick="btnBuscar_Click" />
                
                &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblFiltro" runat="server" Text="Filtrar por Estado: " Font-Bold="true"></asp:Label>
                <asp:DropDownList ID="ddlFiltroEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFiltroEstado_SelectedIndexChanged">
                    <asp:ListItem Text="Todos" Value="Todos"></asp:ListItem>
                    <asp:ListItem Text="A tiempo" Value="A tiempo"></asp:ListItem>
                    <asp:ListItem Text="Atrasados" Value="Atrasados"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <hr />

            <asp:GridView ID="gvHistorial" runat="server" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Carnet" HeaderText="Carnet" />
                    <asp:BoundField DataField="Estudiante" HeaderText="Nombre del Estudiante" />
                    <asp:BoundField DataField="Articulo" HeaderText="Libro/Equipo" />
                    <asp:BoundField DataField="FechaEsperada" HeaderText="Fecha Esperada" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                </Columns>
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#E3EAEB" />
            </asp:GridView>

            <br />
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>

        </div>
    </form>
</body>
</html>
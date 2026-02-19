<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="Grupo10_ControlPrestamos_ASPNet.Equipos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Equipos</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; background: #f5f5f5; }
        h2 { color: #222; }
        .filtros { background: #ececec; padding: 12px 16px; margin-bottom: 16px; border-radius: 4px; }
        .filtros label { font-weight: bold; margin-right: 6px; }
        .filtros input[type=text] { padding: 5px 8px; margin-right: 6px; border: 1px solid #ccc; border-radius: 3px; }
        .filtros select { padding: 5px 8px; border: 1px solid #ccc; border-radius: 3px; }
        .btnBuscar { background: #1a73e8; color: white; border: none; padding: 6px 16px; border-radius: 3px; cursor: pointer; }
        .btnBuscar:hover { background: #155ab6; }
        .btnNuevo { background: #28a745; color: white; border: none; padding: 6px 16px; border-radius: 3px; cursor: pointer; text-decoration: none; display: inline-block; margin-bottom: 10px; }
        .btnNuevo:hover { background: #1e7e34; }
        table { border-collapse: collapse; width: 100%; background: white; }
        th { background: #1e6e5e; color: white; padding: 10px 14px; text-align: left; }
        td { padding: 9px 14px; border-bottom: 1px solid #ddd; }
        tr:nth-child(even) td { background: #f0f7f5; }
        .estado-tiempo { color: #1a7a1a; font-weight: bold; }
        .estado-atrasado { color: #cc0000; font-weight: bold; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Equipos</h2>

        <a class="btnNuevo" href="EquipoNuevo.aspx">+ Nuevo Equipo</a>

        <div class="filtros">
            <label>Buscar Carnet o Estudiante:</label>
            <asp:TextBox ID="txtBuscar" runat="server" placeholder="Ej. SM1001 o Juan" />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btnBuscar"
                OnClick="btnBuscar_Click" />
            &nbsp;&nbsp;
            <label>Filtrar por Estado:</label>
            <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true"
                OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                <asp:ListItem Text="Todos" Value="Todos" />
                <asp:ListItem Text="A tiempo" Value="A tiempo" />
                <asp:ListItem Text="Atrasados" Value="Atrasados" />
            </asp:DropDownList>
        </div>

        <asp:GridView ID="gvPrestamos" runat="server"
            AutoGenerateColumns="false"
            EmptyDataText="No se encontraron préstamos."
            Width="100%">
            <Columns>
                <asp:BoundField DataField="Carnet"    HeaderText="Carnet" />
                <asp:BoundField DataField="Nombre"    HeaderText="Nombre del Estudiante" />
                <asp:BoundField DataField="Equipo"    HeaderText="Libro/Equipo" />
                <asp:BoundField DataField="FechaEsperada" HeaderText="Fecha Esperada"
                    DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Label runat="server"
                            Text='<%# Eval("Estado") %>'
                            CssClass='<%# Eval("Estado").ToString() == "A tiempo" ? "estado-tiempo" : "estado-atrasado" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>


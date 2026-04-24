<%@ Page Title="Equipos" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="Grupo10_ControlPrestamos_ASPNet.Equipos" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
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
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Equipos</h2>

        <div class="filtros">
            <label>Buscar Carnet o Estudiante:</label>
            <asp:TextBox ID="txtBuscar" runat="server" placeholder="Ej. SM1001 o Juan" />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btnBuscar"
                OnClick="btnBuscar_Click" />
        </div>

        <asp:GridView ID="gvPrestamos" runat="server"
            AutoGenerateColumns="false"
            EmptyDataText="No se encontraron préstamos."
            Width="100%">
            <Columns>
                <asp:BoundField DataField="IdPrestamo"    HeaderText="Codigo del Prestamo" />
                <asp:BoundField DataField="NombreCliente"    HeaderText="Nombre del Estudiante" />
                <asp:BoundField DataField="Articulo"    HeaderText="Equipo" />
                <asp:BoundField DataField="FechaPrestamo" HeaderText="Fecha Esperada"
                    DataFormatString="{0:dd/MM/yyyy}" />
            </Columns>
        </asp:GridView>
  </asp:Content>

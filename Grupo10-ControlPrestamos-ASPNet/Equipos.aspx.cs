using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Grupo10_ControlPrestamos_ASPNet
{
    public partial class Equipos : System.Web.UI.Page
    {
        // Modelo de datos
        public class Prestamo
        {
            public string Carnet { get; set; }
            public string Nombre { get; set; }
            public string Equipo { get; set; }
            public DateTime FechaEsperada { get; set; }
            public string Estado { get; set; }
        }

        // Datos de muestra (en un proyecto real vendrían de BD)
        private List<Prestamo> ObtenerDatos()
        {
            return new List<Prestamo>
            {
                new Prestamo { Carnet="SQ2026", Nombre="Samuel Leonardo Quijano", Equipo="Teclado Sintetizador", FechaEsperada=new DateTime(2026,2,20), Estado="A tiempo" },
                new Prestamo { Carnet="JP1001", Nombre="Juan Perez",               Equipo="Proyector EPSON",      FechaEsperada=new DateTime(2026,2,15), Estado="Atrasados" },
                new Prestamo { Carnet="MR3003", Nombre="Maria Ramos",              Equipo="Libro de C#",          FechaEsperada=new DateTime(2026,2,17), Estado="Atrasados" },
                new Prestamo { Carnet="AL4004", Nombre="Ana Lopez",                Equipo="Cable HDMI",           FechaEsperada=new DateTime(2026,2,23), Estado="A tiempo" },
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarGrid("", "Todos");

            // Si volvemos de PrestamoNuevo.aspx con un nuevo registro en Session
            if (Session["NuevoPrestamo"] != null)
            {
                CargarGrid("", "Todos");
                Session.Remove("NuevoPrestamo");
            }
        }

        private void CargarGrid(string buscar, string estado)
        {
            var datos = ObtenerDatos();

            if (!string.IsNullOrWhiteSpace(buscar))
                datos = datos.Where(p =>
                    p.Carnet.IndexOf(buscar, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    p.Nombre.IndexOf(buscar, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();

            if (estado != "Todos")
                datos = datos.Where(p => p.Estado == estado).ToList();

            gvPrestamos.DataSource = datos;
            gvPrestamos.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrid(txtBuscar.Text.Trim(), ddlEstado.SelectedValue);
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid(txtBuscar.Text.Trim(), ddlEstado.SelectedValue);
        }
    }
}

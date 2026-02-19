using System;
using System.Collections.Generic;
using System.Linq;

namespace Grupo10_ControlPrestamos_ASPNet
{
    public partial class Historial : System.Web.UI.Page
    {
        public class Prestamo
        {
            public string Carnet { get; set; }
            public string Estudiante { get; set; }
            public string Articulo { get; set; }
            public DateTime FechaEsperada { get; set; }

            public string Estado
            {
                get
                {
                    if (DateTime.Now.Date > FechaEsperada.Date)
                        return "Atrasados";
                    else
                        return "A tiempo";
                }
            }
        }

        private List<Prestamo> ObtenerDatosFake()
        {
            return new List<Prestamo>
            {
                new Prestamo { Carnet = "SQ2026", Estudiante = "Samuel Leonardo Quijano", Articulo = "Teclado Sintetizador", FechaEsperada = DateTime.Now.AddDays(2) },
                new Prestamo { Carnet = "JP1001", Estudiante = "Juan Perez", Articulo = "Proyector EPSON", FechaEsperada = DateTime.Now.AddDays(-3) },
                new Prestamo { Carnet = "MR3003", Estudiante = "Maria Ramos", Articulo = "Libro de C#", FechaEsperada = DateTime.Now.AddDays(-1) },
                new Prestamo { Carnet = "AL4004", Estudiante = "Ana Lopez", Articulo = "Cable HDMI", FechaEsperada = DateTime.Now.AddDays(5) }
            };
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarTabla();
            }
        }


        private void CargarTabla(string filtroTexto = "", string filtroEstado = "Todos")
        {
            var datos = ObtenerDatosFake();

            if (!string.IsNullOrEmpty(filtroTexto))
            {
                datos = datos.Where(d => d.Carnet.ToLower().Contains(filtroTexto.ToLower()) ||
                                         d.Estudiante.ToLower().Contains(filtroTexto.ToLower())).ToList();
            }

            if (filtroEstado != "Todos")
            {
                datos = datos.Where(d => d.Estado == filtroEstado).ToList();
            }


            gvHistorial.DataSource = datos;
            gvHistorial.DataBind();

            if (datos.Count == 0)
                lblMensaje.Text = "No se encontraron préstamos con esos filtros.";
            else
                lblMensaje.Text = "";
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarTabla(txtBuscar.Text, ddlFiltroEstado.SelectedValue);
        }

        protected void ddlFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTabla(txtBuscar.Text, ddlFiltroEstado.SelectedValue);
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ///aqui di doble click sin querer en la barra de busqueda y se genero este evento, solo obvienlo :v
        }
    }
}
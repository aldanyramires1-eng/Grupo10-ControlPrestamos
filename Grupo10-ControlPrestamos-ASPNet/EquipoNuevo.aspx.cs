using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Grupo10_ControlPrestamos_ASPNet
{
    public partial class EquipoNuevo : System.Web.UI.Page
    {
        public class Equipo
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Categoria { get; set; }
            public int Cantidad { get; set; }
            public string Estado { get; set; }
            public string Descripcion { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Inicializar lista de equipos en Session si no existe
            if (Session["ListaEquipos"] == null)
                Session["ListaEquipos"] = new List<Equipo>();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string codigo = txtCodigo.Text.Trim().ToUpper();
            string nombre = txtNombre.Text.Trim();
            string categoria = ddlCategoria.SelectedItem.Text;
            int cantidad = int.Parse(txtCantidad.Text.Trim());
            string estado = ddlEstado.SelectedItem.Text;
            string descripcion = txtDescripcion.Text.Trim();

            // Guardar en Session (en proyecto real sería BD)
            var lista = (List<Equipo>)Session["ListaEquipos"];
            lista.Add(new Equipo
            {
                Codigo = codigo,
                Nombre = nombre,
                Categoria = categoria,
                Cantidad = cantidad,
                Estado = estado,
                Descripcion = descripcion
            });
            Session["ListaEquipos"] = lista;

            // Mostrar confirmación
            pnlExito.Visible = true;
            lblExito.Text =
                "<strong>✔ Equipo registrado exitosamente</strong><br/>" +
                "Código: " + codigo + " | " +
                "Nombre: " + nombre + "<br/>" +
                "Categoría: " + categoria + " | " +
                "Cantidad: " + cantidad + " | " +
                "Estado: " + estado +
                (string.IsNullOrEmpty(descripcion) ? "" : "<br/>Descripción: " + descripcion);

            // Limpiar formulario
            txtCodigo.Text = "";
            txtNombre.Text = "";
            ddlCategoria.SelectedIndex = 0;
            txtCantidad.Text = "";
            ddlEstado.SelectedIndex = 0;
            txtDescripcion.Text = "";
        }
    }
}

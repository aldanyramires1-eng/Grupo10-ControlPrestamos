using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Grupo10_ControlPrestamos_ASPNet
{
    public partial class PrestamoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fijar atributo min del input date al día siguiente
                txtFecha.Attributes["min"] = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");
            }
        }

        // ── CustomValidator: la fecha debe ser estrictamente mayor a hoy ──
        protected void cvFecha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime fecha;
            if (DateTime.TryParse(args.Value, out fecha))
                args.IsValid = fecha.Date > DateTime.Today;
            else
                args.IsValid = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string carnet = txtCarnet.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string equipo = ddlEquipo.SelectedItem.Text;
            string fecha = Convert.ToDateTime(txtFecha.Text).ToString("dd/MM/yyyy");
            string estado = ddlEstado.SelectedItem.Text;

            Session["NuevoPrestamo"] = true;

            pnlExito.Visible = true;
            lblExito.Text =
                "<strong>✔ Préstamo registrado exitosamente</strong><br/>" +
                "Carnet: " + carnet + " | " +
                "Estudiante: " + nombre + "<br/>" +
                "Equipo: " + equipo + " | " +
                "Devolución: " + fecha + " | " +
                "Estado: " + estado;

            // Limpiar campos
            txtCarnet.Text = "";
            txtNombre.Text = "";
            ddlEquipo.SelectedIndex = 0;
            txtFecha.Text = "";
            ddlEstado.SelectedIndex = 0;
        }
    }
}

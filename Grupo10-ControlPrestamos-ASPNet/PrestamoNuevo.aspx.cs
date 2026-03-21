using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Grupo10_ControlPrestamos_ASPNet
{
    public partial class PrestamoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFechaDevolucion.Attributes["min"] = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");
            }
        }

        protected void cvFecha_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
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

            string nombreCliente = txtNombreCliente.Text.Trim();
            string articulo = ddlArticulo.SelectedItem.Text;
            DateTime fechaPrestamo = DateTime.Today;
            DateTime fechaDevolucion = Convert.ToDateTime(txtFechaDevolucion.Text);
            string estado = ddlEstado.SelectedValue;


            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
       
                    string query = "INSERT INTO Prestamos (NombreCliente, Articulo, FechaPrestamo, FechaDevolucionEsperada, Estado) VALUES (@Nombre, @Articulo, @FechaP, @FechaD, @Estado)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@Nombre", nombreCliente);
                        cmd.Parameters.AddWithValue("@Articulo", articulo);
                        cmd.Parameters.AddWithValue("@FechaP", fechaPrestamo);
                        cmd.Parameters.AddWithValue("@FechaD", fechaDevolucion);
                        cmd.Parameters.AddWithValue("@Estado", estado);

                        con.Open();
                        cmd.ExecuteNonQuery(); 
                        con.Close();
                    }
                }


                pnlExito.Visible = true;
                lblExito.Text = "<strong>✔ Préstamo guardado exitosamente en la base de datos.</strong>";
                lblExito.ForeColor = System.Drawing.Color.Green;


                txtNombreCliente.Text = "";
                ddlArticulo.SelectedIndex = 0;
                txtFechaDevolucion.Text = "";
                ddlEstado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                pnlExito.Visible = true;
                lblExito.Text = "<strong>❌ Error al guardar:</strong> " + ex.Message;
                lblExito.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Grupo10_ControlPrestamos_ASPNet
{
    public partial class Historial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarHistorial();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        protected void ddlFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            DataTable dt = ObtenerDatosDeBD();
            DataTable dtFiltrado = dt.Clone();

            string filtroEstado = ddlFiltroEstado.SelectedValue;
            string textoBusqueda = txtBuscarCliente.Text.Trim().ToLower();

            foreach (DataRow row in dt.Rows)
            {

                bool coincideEstado = (filtroEstado == "Todos" || row["Estado"].ToString() == filtroEstado);
                bool coincideNombre = (string.IsNullOrEmpty(textoBusqueda) || row["NombreCliente"].ToString().ToLower().Contains(textoBusqueda));

                if (coincideEstado && coincideNombre)
                {
                    dtFiltrado.ImportRow(row);
                }
            }

            gvHistorial.DataSource = dtFiltrado;
            gvHistorial.DataBind();
        }

        private DataTable ObtenerDatosDeBD()
        {
            DataTable dt = new DataTable();


            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                string query = "SELECT IdPrestamo, NombreCliente, Articulo, FechaPrestamo, FechaDevolucionEsperada, Estado FROM Prestamos";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Grupo10_ControlPrestamos_ASPNet
{
    public partial class Equipos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaDatos();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }

        private void CargaDatos()
        {
            DataTable dt = ObtenerDatosDeBD();
            DataTable dtFiltrado = dt.Clone();

            string textoBusqueda = txtBuscar.Text.Trim().ToLower();

            foreach (DataRow row in dt.Rows)
            {

                bool coincideNombre = (string.IsNullOrEmpty(textoBusqueda) || row["NombreCliente"].ToString().ToLower().Contains(textoBusqueda));

                if (coincideNombre)
                {
                    dtFiltrado.ImportRow(row);
                }
            }

            gvPrestamos.DataSource = dtFiltrado;
            gvPrestamos.DataBind();
        }


        private DataTable ObtenerDatosDeBD()
        {
            DataTable dt = new DataTable();


            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                string query = "SELECT IdPrestamo, NombreCliente, Articulo, FechaPrestamo FROM HistorialPrestamos";

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

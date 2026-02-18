using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Grupo10_ControlPrestamos_ASPNet
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "admin" && txtPassword.Text == "123")
            {
                Session["Usuario"] = txtUsuario.Text;
                Response.Redirect("Equipos.aspx");
            }
            else
            {
                lblMensaje.Text = "Credenciales incorrectas.";
            }
        }

    }
}
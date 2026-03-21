using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Grupo10_ControlPrestamos_ASPNet
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Menu1.Visible = !string.Equals(
            Request.AppRelativeCurrentExecutionFilePath,
            "~/Default.aspx",
             StringComparison.OrdinalIgnoreCase);

            if (Session["Usuario"] != null)
            {
                lblUsuario.Text = "Usuario logueado: " + Session["Usuario"].ToString();
            }
        }
    }
}
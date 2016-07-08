using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.Template
{
    public partial class MP : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PERFIL_ID"] == null)
            {
                Response.Redirect("~/UI_SEGURIDAD/Acceso.aspx");
            }

            if (Session["PERSONAL_NOMBRE_USUARIO"] != null)
            {
                lblLogin.Text = Session["PERSONAL_NOMBRE_USUARIO"].ToString();
                

            }

            
                

        }

        protected void lkbSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI_SEGURIDAD/Acceso.aspx");
        }

        protected void link_Salir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();

            Response.Redirect("~/UI_SEGURIDAD/Acceso.aspx");
        }
        
            




    }
}
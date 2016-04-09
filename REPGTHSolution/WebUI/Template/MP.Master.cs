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

            if (Session["PERFIL_ID"].ToString() != "1")
            {
                MenuItemCollection menuItems = MnuPeti.Items;
                MenuItem adminItem = new MenuItem();
                foreach (MenuItem menuItem in menuItems)
                {
                    if (menuItem.Text == "Administracion")
                        adminItem = menuItem;
                }
                menuItems.Remove(adminItem);

            }
            
                

        }

        protected void lkbSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI_SEGURIDAD/Acceso.aspx");
        }
    }
}
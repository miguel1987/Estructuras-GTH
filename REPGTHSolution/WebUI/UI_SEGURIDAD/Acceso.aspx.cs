using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.UI_SEGURIDAD
{
    public partial class Acceso : PageBaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
   
        }

        protected void btnIntentar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}
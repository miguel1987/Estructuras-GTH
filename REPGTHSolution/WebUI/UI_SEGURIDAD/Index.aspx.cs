using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.UI_SEGURIDAD
{
    public partial class Index : PageBaseClass 
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.validarUsuarioEnDominio();
        }
    }
}
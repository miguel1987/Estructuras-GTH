using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessEntities;
using BusinessLogicLayer;
using Telerik.Web.UI;
using System.Collections;
using System.Text;

namespace WebUI.UI_EVALUACION
{
    public partial class pruebaM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadTreeView();
        }

        private void LoadTreeView()
        {
            
            
        }

      
        
       

        protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {

        }

        
    }
}
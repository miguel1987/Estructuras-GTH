using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            
            TreeNode node1 = new TreeNode("Node 1");
            node1.ChildNodes.Add(new TreeNode("Node 1 - 1"));
            node1.ChildNodes.Add(new TreeNode("Node 1 - 2"));
            node1.ChildNodes.Add(new TreeNode("Node 1 - 3"));
            node1.ChildNodes.Add(new TreeNode("Node 1 - 4"));
            TreeView1.Nodes.Add(node1);

            TreeNode node2 = new TreeNode("Node 2");
            node2.ChildNodes.Add(new TreeNode("Node 2 - 1"));
            node2.ChildNodes.Add(new TreeNode("Node 2 - 2"));
            node2.ChildNodes.Add(new TreeNode("Node 2 - 3"));
            node2.ChildNodes.Add(new TreeNode("Node 2 - 4"));
            TreeView1.Nodes.Add(node2);

            TreeNode node3 = new TreeNode("Node 3");
            node3.ChildNodes.Add(new TreeNode("Node 3 - 1"));
            node3.ChildNodes.Add(new TreeNode("Node 2 - 4"));
            TreeView1.Nodes.Add(node3);
        }

      

       

        protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {

        }

        
    }
}
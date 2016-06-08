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

namespace WebUI.UI_ADMINISTRACION
{
    public partial class CompetenciasTransversales : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());      
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            rgCompetenciaTransversal.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";

            rgCompetenciaTransversal.Rebind();

        }

        protected void linkBuscar_Click(object sender, EventArgs e)
        {

            rgCompetenciaTransversal.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";

            rgCompetenciaTransversal.Rebind();

        }

        protected void rgCompetenciaTransversal_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }



        protected void rgCompetenciaTransversal_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }



        protected void rgCompetenciaTransversal_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;

            BL_COMPETENCIA_TRANSVERSAL.EliminarCompetenciaTransversal((Guid)ID);
            rgCompetenciaTransversal.DataBind();
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
           
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            BE_COMPETENCIA_TRANSVERSAL oentidad = new BE_COMPETENCIA_TRANSVERSAL();

            Nullable<Guid> ID;

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());


            oentidad.ID = (Guid)ID;
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();
            oentidad.CODIGO = values["CODIGO"].ToString();          

            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_COMPETENCIA_TRANSVERSAL.InsertarCompetenciaTransversal(oentidad);

            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_COMPETENCIA_TRANSVERSAL.ActualizarCompetenciaTransversal(oentidad);

            }
        }
    }
}
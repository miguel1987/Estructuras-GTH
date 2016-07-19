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
    public partial class ParametrosSistema : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());      
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            rgParametros.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";
            rgParametros.Rebind();
        }

        protected void linkBuscar_Click(object sender, EventArgs e)
        {
            rgParametros.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";
            rgParametros.Rebind();
        }

        protected void rgParametros_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }

        protected void rgParametros_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }

        protected void rgParametros_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;
            //TODO: Validar que no se pueda eliminar si existen competencias asociadas a un puesto.
            BL_PARAMETRO.EliminarParametro((Guid)ID);
            rgParametros.DataBind();
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
           
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            BE_PARAMETRO oentidad = new BE_PARAMETRO();

            Nullable<Guid> ID;

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());

            oentidad.ID = (Guid)ID;
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();
            oentidad.CODIGO = values["CODIGO"].ToString();
            oentidad.VALOR = values["VALOR"].ToString();


            if (action == "Edit")
            {               
                oentidad.USUARIO_CREACION = USUARIO;
                BL_PARAMETRO.ActualizarParametro(oentidad);
            }
        }
    }
}
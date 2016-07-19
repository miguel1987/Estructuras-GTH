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
    public partial class Competencias : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());      
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            rgCompetencia.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";
            rgCompetencia.Rebind();
        }

        protected void linkBuscar_Click(object sender, EventArgs e)
        {
            rgCompetencia.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";
            rgCompetencia.Rebind();
        }

        protected void rgCompetencia_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (!e.Item.GetType().Name.Equals("GridEditFormInsertItem"))
                {
                    BE_COMPETENCIA editableItem = ((BE_COMPETENCIA)e.Item.DataItem);
                    RadComboBox rcbTemp = (RadComboBox)e.Item.FindControl("rcbTipoCompetencia");
                    if (rcbTemp != null)
                        rcbTemp.SelectedValue = editableItem.COMPETENCIA_TIPO_ID.ToString();
                }
            }
        }

        protected void rgCompetencia_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }

        protected void rgCompetencia_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }

        protected void rgCompetencia_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;
            //TODO: Validar que no se pueda eliminar si existen competencias asociadas a un puesto.
            BL_COMPETENCIA.EliminarCompetencia((Guid)ID);
            rgCompetencia.DataBind();
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
           
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);
            RadComboBox oRadComboBox_TipoCompetencia = (RadComboBox)e.Item.FindControl("rcbTipoCompetencia");
            BE_COMPETENCIA oentidad = new BE_COMPETENCIA();

            Nullable<Guid> ID;

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());


            oentidad.ID = (Guid)ID;
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();
            oentidad.CODIGO = values["CODIGO"].ToString();

            if (!String.IsNullOrEmpty(oRadComboBox_TipoCompetencia.SelectedValue))
            {
                oentidad.COMPETENCIA_TIPO_ID = Guid.Parse(oRadComboBox_TipoCompetencia.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox_TipoCompetencia.Text = String.Empty;
                return;
            }

            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_COMPETENCIA.InsertarCompetencia(oentidad);

            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_COMPETENCIA.ActualizarCompetencia(oentidad);
            }
        }
    }
}
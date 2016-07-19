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
    public partial class Gerencia : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
        }

        protected void rgGerencia_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)            
            {
                if (!e.Item.GetType().Name.Equals("GridEditFormInsertItem"))                
                {
                    BE_GERENCIA editableItem = ((BE_GERENCIA)e.Item.DataItem);
                    RadComboBox rcbTemp = (RadComboBox)e.Item.FindControl("rcbEmpresa");
                    if (rcbTemp != null)
                        rcbTemp.SelectedValue = editableItem.EMPRESA_ID.ToString();
                }
            }
           
        }

        protected void rgGerencia_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }

        protected void rgGerencia_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }

        protected void rgGerencia_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            int validarEliminar = 0;
            BL_AREA BL_AREA = new BL_AREA();
            BL_GERENCIA BL_GERENCIA = new BL_GERENCIA();
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;

            //Validar que la gerencia a eliminar no esté asociada a ninguna área activa.  
            List<BE_AREA> lstAreas = BL_AREA.SeleccionarAreaGerencia((Guid)ID);
            if (lstAreas == null || lstAreas.Count == 0)
                validarEliminar += 1; 

             if (validarEliminar > 0)
            {
                BL_GERENCIA.EliminarGerencia((Guid)ID);
                rgGerencia.DataBind();
            }
            else
            {
                 string message = "'No puede eliminar una Gerencia asociada a una o más Áreas'";
                 string javaScriptCode = "Sys.Application.add_load(function() {showRadConfirm(" + message + ");});";
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "RadConfirmStart", javaScriptCode, true);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            rgGerencia.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_EMPRESA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";
            rgGerencia.Rebind();
        }

        protected void linkBuscar_Click(object sender, EventArgs e)
        {
            rgGerencia.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_EMPRESA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";
            rgGerencia.Rebind();
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
            BL_GERENCIA BL_GERENCIA = new BL_GERENCIA();
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            RadComboBox oRadComboBox2 = (RadComboBox)e.Item.FindControl("rcbEmpresa");

            BE_GERENCIA oentidad = new BE_GERENCIA();

            Nullable<Guid> ID;

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());

            oentidad.ID = (Guid)ID;
            oentidad.CODIGO = values["CODIGO"].ToString();
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();
            if (!String.IsNullOrEmpty(oRadComboBox2.SelectedValue))
            {
                oentidad.EMPRESA_ID = Guid.Parse(oRadComboBox2.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox2.Text = String.Empty;
                return;
            }

            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_GERENCIA.InsertarGerencia(oentidad);
            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_GERENCIA.ActualizarGerencia(oentidad);
            }
        }
    }
}
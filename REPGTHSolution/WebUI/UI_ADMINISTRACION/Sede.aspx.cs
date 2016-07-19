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
    public partial class Sede : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
        }

        protected void rgSede_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)            
            {
                if (!e.Item.GetType().Name.Equals("GridEditFormInsertItem"))                
                {
                    BE_SEDE editableItem = ((BE_SEDE)e.Item.DataItem);
                    RadComboBox rcbTemp = (RadComboBox)e.Item.FindControl("rcbEmpresa");
                    if (rcbTemp != null)
                        rcbTemp.SelectedValue = editableItem.EMPRESA_ID.ToString();
                }
            }
           
        }

        protected void rgSede_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }

        protected void rgSede_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }

        protected void rgSede_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            int validarEliminar = 0;
            BL_SEDE BL_SEDE = new BL_SEDE();
            BL_PERSONAL BL_PERSONAL = new BL_PERSONAL();
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;

            //Validar que la sede a eliminar no esté asociada a ningún personal activa.  
            List<BE_PERSONAL> lstPersonal = BL_PERSONAL.SeleccionarPersonalPorSede((Guid)ID);
            if (lstPersonal == null || lstPersonal.Count == 0)
                validarEliminar += 1; 

             if (validarEliminar > 0)
            {
                BL_SEDE.EliminarSede((Guid)ID);
                rgSede.DataBind();
            }
            else
            {
                 string message = "'No puede eliminar una Sede asociada a una o más Personas'";
                 string javaScriptCode = "Sys.Application.add_load(function() {showRadConfirm(" + message + ");});";
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "RadConfirmStart", javaScriptCode, true);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            rgSede.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_EMPRESA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";
            rgSede.Rebind();
        }

        protected void linkBuscar_Click(object sender, EventArgs e)
        {
            rgSede.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_EMPRESA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";
            rgSede.Rebind();
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
            BL_SEDE BL_SEDE = new BL_SEDE();
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            RadComboBox oRadComboBox2 = (RadComboBox)e.Item.FindControl("rcbEmpresa");

            BE_SEDE oentidad = new BE_SEDE();

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
                BL_SEDE.InsertarSede(oentidad);
            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_SEDE.ActualizarSede(oentidad);
            }
        }
    }
}
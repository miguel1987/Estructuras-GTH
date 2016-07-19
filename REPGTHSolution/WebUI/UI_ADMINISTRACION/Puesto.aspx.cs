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
    public partial class Puesto : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
        }

        protected void rgPuesto_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)            
            {
                if (!e.Item.GetType().Name.Equals("GridEditFormInsertItem"))                
                {
                    BE_PUESTO editableItem = ((BE_PUESTO)e.Item.DataItem);
                    RadComboBox rcbTemp = (RadComboBox)e.Item.FindControl("rcbEmpresa");
                    if (rcbTemp != null)
                        rcbTemp.SelectedValue = editableItem.EMPRESA_ID.ToString();
                    RadComboBox rcbTempNivel = (RadComboBox)e.Item.FindControl("rcbNivel");
                    if (rcbTempNivel != null)
                        rcbTempNivel.SelectedValue = editableItem.NIVEL.ToString();
                }
            }           
        }

        protected void rgPuesto_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }

        protected void rgPuesto_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }

        protected void rgPuesto_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            int validarEliminar = 0;
            BL_PERSONAL BL_PERSONAL = new BL_PERSONAL();
            BL_PUESTO BL_PUESTO = new BL_PUESTO();
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;

            //Validar que el área a eliminar no esté asociada a ninguna personal      
            List<BE_PERSONAL> lstPersonal = BL_PERSONAL.SeleccionarPersonalPorArea((Guid)ID);
            if (lstPersonal == null || lstPersonal.Count == 0)
                validarEliminar += 1;                        

             if (validarEliminar > 0)
            {
                BL_PUESTO.EliminarPuesto((Guid)ID);
                rgPuesto.DataBind();
            }
            else
            {
                 string message = "'No puede eliminar un Puesto asociada a una o más Personas'";
                 string javaScriptCode = "Sys.Application.add_load(function() {showRadConfirm(" + message + ");});";
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "RadConfirmStart", javaScriptCode, true);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            rgPuesto.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_EMPRESA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";
            rgPuesto.Rebind();
        }

        protected void linkBuscar_Click(object sender, EventArgs e)
        {
            rgPuesto.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_EMPRESA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";
            rgPuesto.Rebind();
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
            BL_PUESTO BL_PUESTO = new BL_PUESTO();
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            RadComboBox oRadComboBox2 = (RadComboBox)e.Item.FindControl("rcbEmpresa");
            RadComboBox oRadComboBox_Nivel = (RadComboBox)e.Item.FindControl("rcbNivel");

            BE_PUESTO oentidad = new BE_PUESTO();

            Nullable<Guid> ID;

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());

            oentidad.ID = (Guid)ID;
            oentidad.CODIGO = values["CODIGO"].ToString();
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();
            if (!String.IsNullOrEmpty(oRadComboBox_Nivel.SelectedValue))
            {
                oentidad.NIVEL = Int32.Parse(oRadComboBox_Nivel.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox_Nivel.Text = String.Empty;
                return;
            }
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
                BL_PUESTO.InsertarPuesto(oentidad);
            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_PUESTO.ActualizarPuesto(oentidad);
            }
        }
    }
}
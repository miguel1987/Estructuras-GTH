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
    public partial class Coordinacion : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
            
           
        }

        protected void rgCoordinacion_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)            
            {
                if (!e.Item.GetType().Name.Equals("GridEditFormInsertItem"))                
                {
                    BE_COORDINACION editableItem = ((BE_COORDINACION)e.Item.DataItem);
                    RadComboBox rcbTempEmpresa = (RadComboBox)e.Item.FindControl("rcbEmpresa");
                    if (rcbTempEmpresa != null)
                    {
                        rcbTempEmpresa.SelectedValue = editableItem.oBE_EMPRESA.ID.ToString();
                    }
                    RadComboBox rcbTempGerencia = (RadComboBox)e.Item.FindControl("rcbGerencia");
                    if (rcbTempGerencia != null)
                    {
                        this.odsGerencia.SelectParameters.Clear();
                        this.odsGerencia.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, rcbTempEmpresa.SelectedValue);

                        rcbTempGerencia.DataBind();

                        rcbTempGerencia.SelectedValue = editableItem.oBE_GERENCIA.ID.ToString();
                    }
                    RadComboBox rcbTempArea = (RadComboBox)e.Item.FindControl("rcbArea");
                    if (rcbTempArea != null)
                    {
                        this.odsArea.SelectParameters.Clear();
                        this.odsArea.SelectParameters.Add("gerencia_id", System.Data.DbType.Guid, rcbTempGerencia.SelectedValue);

                        rcbTempArea.DataBind();

                        rcbTempArea.SelectedValue = editableItem.AREA_ID.ToString();
                    }
                }
            }
        }

        protected void rcbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {           
       
            RadComboBox rcbTempEmpresa = (RadComboBox)sender;
            String selected = rcbTempEmpresa.SelectedValue;
            RadComboBox rcbTempGerencia = (RadComboBox)rcbTempEmpresa.NamingContainer.FindControl("rcbGerencia");
            rcbTempGerencia.ClearSelection();
            this.odsGerencia.SelectParameters.Clear();
            this.odsGerencia.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, selected);            

            rcbTempGerencia.DataBind();            

        }

        protected void rcbGerencia_SelectedIndexChanged(object sender, EventArgs e)
        {

            RadComboBox rcbTempGerencia = (RadComboBox)sender;
            String selected = rcbTempGerencia.SelectedValue;
            RadComboBox rcbTempArea = (RadComboBox)rcbTempGerencia.NamingContainer.FindControl("rcbArea");
            rcbTempArea.ClearSelection();
            this.odsArea.SelectParameters.Clear();
            this.odsArea.SelectParameters.Add("gerencia_id", System.Data.DbType.Guid, selected);

            rcbTempArea.DataBind();

        }



        protected void rgCoordinacion_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
            
        }



        protected void rgCoordinacion_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }



        protected void rgCoordinacion_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            int validarEliminar = 0;
            BL_PERSONAL BL_PERSONAL = new BL_PERSONAL();
            
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;
            
            //Validar que el área a eliminar no esté asociada a ninguna persona
            List<BE_PERSONAL> lstPersonal = BL_PERSONAL.SeleccionarPersonalPorCoordinacion((Guid)ID);
            if (lstPersonal == null || lstPersonal.Count == 0)           
                validarEliminar += 1;                        

            if (validarEliminar > 0)
            {
                BL_COORDINACION BL_COORDINACION = new BL_COORDINACION();
                BL_COORDINACION.EliminarCoordinacion((Guid)ID);
                rgCoordinacion.DataBind();
            }
            else
            {
               string message = "'No puede eliminar una Coordinación asociada a un Personal'";
               string javaScriptCode = "Sys.Application.add_load(function() {showRadConfirm(" + message + ");});";
               ScriptManager.RegisterStartupScript(this, this.GetType(), "RadConfirmStart", javaScriptCode, true);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            rgCoordinacion.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_EMPRESA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_GERENCIA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";

            rgCoordinacion.Rebind();

        }

        protected void linkBuscar_Click(object sender, EventArgs e)
        {

            rgCoordinacion.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_EMPRESA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_GERENCIA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";

            rgCoordinacion.Rebind();

        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
            BL_COORDINACION BL_COORDINACION = new BL_COORDINACION();
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            RadComboBox oRadComboBox2 = (RadComboBox)e.Item.FindControl("rcbGerencia");
            RadComboBox oRadComboBox3 = (RadComboBox)e.Item.FindControl("rcbEmpresa");
            RadComboBox oRadComboBox4 = (RadComboBox)e.Item.FindControl("rcbArea");

            BE_COORDINACION oentidad = new BE_COORDINACION();

            Nullable<Guid> ID;
            
            if(e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else            
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
           
            oentidad.ID = (Guid)ID;
            oentidad.CODIGO = values["CODIGO"].ToString();
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();
            if (!String.IsNullOrEmpty(oRadComboBox2.SelectedValue)){
                oentidad.AREA_ID = Guid.Parse(oRadComboBox4.SelectedValue);
            }else{
                e.Canceled = true;
                oRadComboBox4.Text=String.Empty;
                oRadComboBox4.EmptyMessage = "<SELECCIONAR>";
                return;
            }
            
            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_COORDINACION.InsertarCoordinacion(oentidad);

            }else{
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_COORDINACION.ActualizarCoordinacion(oentidad);

            }

            

        }
    }
}
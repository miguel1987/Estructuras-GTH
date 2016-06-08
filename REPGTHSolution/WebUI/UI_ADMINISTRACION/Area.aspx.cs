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
    public partial class Area : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
            
           
        }

        protected void rgArea_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)            
            {
                if (!e.Item.GetType().Name.Equals("GridEditFormInsertItem"))                
                {
                    BE_AREA editableItem = ((BE_AREA)e.Item.DataItem);
                    RadComboBox rcbTempEmpresa = (RadComboBox)e.Item.FindControl("rcbEmpresa");
                    if (rcbTempEmpresa != null)
                    {
                        rcbTempEmpresa.SelectedValue = editableItem.EMPRESA_ID.ToString();
                    }
                    RadComboBox rcbTemp = (RadComboBox)e.Item.FindControl("rcbGerencia");
                    if (rcbTemp != null)
                    {
                        this.odsGerencia.SelectParameters.Clear();
                        this.odsGerencia.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, rcbTempEmpresa.SelectedValue);

                        rcbTemp.DataBind();

                        rcbTemp.SelectedValue = editableItem.GERENCIA_ID.ToString();
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


        protected void rgArea_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
            
        }



        protected void rgArea_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }


            
        protected void rgArea_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            int validarEliminar = 0;
            BL_PERSONAL BL_PERSONAL = new BL_PERSONAL();
            
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
                BL_AREA BL_AREA = new BL_AREA();
                BL_AREA.EliminarArea((Guid)ID);
                rgArea.DataBind();
            }
            else
            {
               string message = "'No puede eliminar un Área asociada a un Personal'";
               string javaScriptCode = "Sys.Application.add_load(function() {showRadConfirm(" + message + ");});";
               ScriptManager.RegisterStartupScript(this, this.GetType(), "RadConfirmStart", javaScriptCode, true);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            rgArea.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_EMPRESA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_GERENCIA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";

            rgArea.Rebind();

        }

        protected void linkBuscar_Click(object sender, EventArgs e)
        {

            rgArea.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_EMPRESA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_GERENCIA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";

            rgArea.Rebind();

        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
            BL_AREA BL_AREA = new BL_AREA();
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            RadComboBox oRadComboBox2 = (RadComboBox)e.Item.FindControl("rcbGerencia");
            RadComboBox oRadComboBox3 = (RadComboBox)e.Item.FindControl("rcbEmpresa");

            BE_AREA oentidad = new BE_AREA();

            Nullable<Guid> ID;
            
            if(e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else            
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());

           
                

            oentidad.ID = (Guid)ID;
            oentidad.CODIGO = values["CODIGO"].ToString();
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();
            if (!String.IsNullOrEmpty(oRadComboBox2.SelectedValue)){
                oentidad.GERENCIA_ID = Guid.Parse(oRadComboBox2.SelectedValue);
            }else{
                e.Canceled = true;
                oRadComboBox2.Text=String.Empty;
                oRadComboBox2.EmptyMessage = "<SELECCIONAR>";
                return;
            }
            if (!String.IsNullOrEmpty(oRadComboBox3.SelectedValue))
            {
                oentidad.EMPRESA_ID = Guid.Parse(oRadComboBox3.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox3.Text = String.Empty;
                return;
            }

            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_AREA.InsertarArea(oentidad);

            }else{
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_AREA.ActualizarAreas(oentidad);

            }

            

        }
    }
}
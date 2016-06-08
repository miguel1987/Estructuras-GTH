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
    public partial class CompetenciasPorPuesto : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
            
           
        }

        protected void rgCompetenciasPuesto_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)            
            {
                if (!e.Item.GetType().Name.Equals("GridEditFormInsertItem"))                
                {
                    BE_COMPETENCIAS_POR_PUESTO editableItem = ((BE_COMPETENCIAS_POR_PUESTO)e.Item.DataItem);
                    RadComboBox rcbTempEmpresa = (RadComboBox)e.Item.FindControl("rcbEmpresa");
                    if (rcbTempEmpresa != null)
                    {
                        rcbTempEmpresa.SelectedValue = editableItem.EMPRESA_ID.ToString();
                    }
                    RadComboBox rcbTemp = (RadComboBox)e.Item.FindControl("rcbPuesto");
                    if (rcbTemp != null)
                    {
                        this.odsPuesto.SelectParameters.Clear();
                        this.odsPuesto.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, rcbTempEmpresa.SelectedValue);

                        rcbTemp.DataBind();

                        rcbTemp.SelectedValue = editableItem.PUESTO_ID.ToString();
                    }
                    RadComboBox rcbTempCompetencia = (RadComboBox)e.Item.FindControl("rcbCompetencia");
                    if (rcbTempCompetencia != null)
                    {
                        rcbTempCompetencia.SelectedValue = editableItem.COMPETENCIA_ID.ToString();
                    }
                }
            }
        }

        protected void rcbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {           
       
            RadComboBox rcbTempEmpresa = (RadComboBox)sender;
            String selected = rcbTempEmpresa.SelectedValue;
            RadComboBox rcbTempPuesto = (RadComboBox)rcbTempEmpresa.NamingContainer.FindControl("rcbPuesto");
            rcbTempPuesto.ClearSelection();
            this.odsPuesto.SelectParameters.Clear();
            this.odsPuesto.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, selected);

            rcbTempPuesto.DataBind();            

        }


        protected void rgCompetenciasPuesto_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
            
        }



        protected void rgCompetenciasPuesto_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }



        protected void rgCompetenciasPuesto_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;           
            
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;

            BL_COMPETENCIAS_POR_PUESTO BL_COMPETENCIAS_POR_PUESTO = new BL_COMPETENCIAS_POR_PUESTO();
            BL_COMPETENCIAS_POR_PUESTO.EliminarCompetenciaPuesto((Guid)ID);
            rgCompetenciasPuesto.DataBind();
          
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            rgCompetenciasPuesto.MasterTableView.FilterExpression = "([oBE_PUESTO.DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_COMPETENCIA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";

            rgCompetenciasPuesto.Rebind();

        }

        protected void linkBuscar_Click(object sender, EventArgs e)
        {

            rgCompetenciasPuesto.MasterTableView.FilterExpression = "([oBE_PUESTO.DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_COMPETENCIA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";

            rgCompetenciasPuesto.Rebind();

        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
            BL_COMPETENCIAS_POR_PUESTO BL_COMPETENCIAS_POR_PUESTO = new BL_COMPETENCIAS_POR_PUESTO();
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            RadComboBox oRadComboBox_Competencia = (RadComboBox)e.Item.FindControl("rcbCompetencia");
            RadComboBox oRadComboBox_Puesto = (RadComboBox)e.Item.FindControl("rcbPuesto");
            RadComboBox oRadComboBox_Empresa = (RadComboBox)e.Item.FindControl("rcbEmpresa");

            BE_COMPETENCIAS_POR_PUESTO oentidad = new BE_COMPETENCIAS_POR_PUESTO();

            Nullable<Guid> ID;
            
            if(e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else            
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());

           
                
            
            oentidad.ID = (Guid)ID;
            oentidad.COMPETENCIA_PUESTO_VALOR_REQUERIDO = Int32.Parse(values["COMPETENCIA_PUESTO_VALOR_REQUERIDO"].ToString());
            
            if (!String.IsNullOrEmpty(oRadComboBox_Puesto.SelectedValue))
            {
                oentidad.PUESTO_ID= Guid.Parse(oRadComboBox_Puesto.SelectedValue);
            }
            else{
                e.Canceled = true;
                oRadComboBox_Puesto.Text = String.Empty;
                oRadComboBox_Puesto.EmptyMessage = "<SELECCIONAR>";
                return;
            }
            if (!String.IsNullOrEmpty(oRadComboBox_Empresa.SelectedValue))
            {
                oentidad.EMPRESA_ID = Guid.Parse(oRadComboBox_Empresa.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox_Empresa.Text = String.Empty;
                return;
            }

            if (!String.IsNullOrEmpty(oRadComboBox_Competencia.SelectedValue))
            {
                oentidad.COMPETENCIA_ID = Guid.Parse(oRadComboBox_Competencia.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox_Competencia.Text = String.Empty;
                oRadComboBox_Puesto.EmptyMessage = "<SELECCIONAR>";
                return;
            }

            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;               
                BL_COMPETENCIAS_POR_PUESTO.InsertarCompetenciaPuesto(oentidad);

            }else{
                oentidad.USUARIO_CREACION = USUARIO;               
                BL_COMPETENCIAS_POR_PUESTO.ActualizarCompetenciaPuesto(oentidad);

            }

            

        }
    }
}
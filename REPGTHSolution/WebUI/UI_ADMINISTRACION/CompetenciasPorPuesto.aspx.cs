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
using System.Web.DynamicData;
using System.Data;

namespace WebUI.UI_ADMINISTRACION
{
    public partial class CompetenciasPorPuesto : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
            rcbEmpresaCab.SelectedIndex = 0;
            dynamic data = odsCompetenciaPuesto;
            
            rgCompetenciasPuesto.MasterTableView.DataSource =data;
            
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

                    RadComboBox rcbTempGerencia = (RadComboBox)e.Item.FindControl("rcbGerencia");
                    if (rcbTempGerencia != null)
                    {
                        this.odsGerencia.SelectParameters.Clear();
                        this.odsGerencia.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, rcbTempEmpresa.SelectedValue);

                        rcbTempGerencia.DataBind();

                        if (editableItem.oBE_GERENCIA.ID != null)
                            rcbTempGerencia.SelectedValue = editableItem.oBE_GERENCIA.ID.ToString();

                    }

                    RadComboBox rcbTempArea = (RadComboBox)e.Item.FindControl("rcbArea");
                    if (rcbTempArea != null)
                    {
                        this.odsArea.SelectParameters.Clear();
                        this.odsArea.SelectParameters.Add("gerencia_id", System.Data.DbType.Guid, rcbTempGerencia.SelectedValue);

                        rcbTempArea.DataBind();

                        if (editableItem.oBE_AREA.ID != null)
                           rcbTempArea.SelectedValue = editableItem.oBE_AREA.ID.ToString();
                    }

                    RadComboBox rcbTempCoordinacion = (RadComboBox)e.Item.FindControl("rcbCoordinacion");
                    if (rcbTempCoordinacion != null)
                    {
                        this.odsCoordinacion.SelectParameters.Clear();
                        this.odsCoordinacion.SelectParameters.Add("area_id", System.Data.DbType.Guid, rcbTempArea.SelectedValue);

                        rcbTempCoordinacion.DataBind();

                        if (editableItem.oBE_COORDINACION != null)
                            rcbTempCoordinacion.SelectedValue = editableItem.oBE_COORDINACION.ID.ToString();
                    }

                    RadComboBox rcbTempPuesto = (RadComboBox)e.Item.FindControl("rcbPuesto");
                    if (rcbTempPuesto != null)
                    {
                        this.odsPuesto.SelectParameters.Clear();
                        this.odsPuesto.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, rcbTempEmpresa.SelectedValue);

                        rcbTempPuesto.DataBind();

                        rcbTempPuesto.SelectedValue = editableItem.PUESTO_ID.ToString();
                    }
                    RadComboBox rcbTempCompetencia = (RadComboBox)e.Item.FindControl("rcbCompetencia");
                    if (rcbTempCompetencia != null)
                    {
                        rcbTempCompetencia.SelectedValue = editableItem.COMPETENCIA_ID.ToString();
                    }

                    RadComboBox rcbTempTipoCompetencia = (RadComboBox)e.Item.FindControl("rcbTipoCompetencia");
                    if (rcbTempTipoCompetencia != null)
                    {
                        rcbTempTipoCompetencia.SelectedValue = editableItem.oBE_COMPETENCIA_TIPO.ID.ToString();
                    }

                    //Desahabilitamos controles durante edición solo puede editar el valor requerido
                    rcbTempEmpresa.Enabled = false;
                    rcbTempGerencia.Enabled = false;
                    rcbTempArea.Enabled = false;
                    rcbTempCoordinacion.Enabled = false;
                    rcbTempTipoCompetencia.Enabled = false;
                    rcbTempCompetencia.Enabled = false;
                    rcbTempPuesto.Enabled = false;

                }
            }
        }

        protected void rcbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {           
       
            RadComboBox rcbTempEmpresa = (RadComboBox)sender;            
            RadComboBox rcbTempGerencia = (RadComboBox)rcbTempEmpresa.NamingContainer.FindControl("rcbGerencia");
            RadComboBox rcbTempArea = (RadComboBox)rcbTempEmpresa.NamingContainer.FindControl("rcbArea");
            RadComboBox rcbTempCoordinacion = (RadComboBox)rcbTempEmpresa.NamingContainer.FindControl("rcbCoordinacion");
            RadComboBox rcbTempPuesto = (RadComboBox)rcbTempEmpresa.NamingContainer.FindControl("rcbPuesto");
            rcbTempGerencia.ClearSelection();            
            rcbTempPuesto.ClearSelection();

            this.odsGerencia.SelectParameters.Clear();
            this.odsGerencia.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, rcbTempEmpresa.SelectedValue);
            rcbTempGerencia.DataBind();

            this.odsPuesto.SelectParameters.Clear();
            this.odsPuesto.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, rcbTempEmpresa.SelectedValue);
            rcbTempPuesto.DataBind();                       

        }

        protected void rcbGerencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadComboBox rcbTempGerencia = (RadComboBox)sender;
            String selected = rcbTempGerencia.SelectedValue;
            RadComboBox rcbTempArea = (RadComboBox)rcbTempGerencia.NamingContainer.FindControl("rcbArea");
            RadComboBox rcbTempCoordinacion = (RadComboBox)rcbTempGerencia.NamingContainer.FindControl("rcbCoordinacion");  
            RadComboBox rcbTempPuesto = (RadComboBox)rcbTempGerencia.NamingContainer.FindControl("rcbPuesto");

            rcbTempArea.ClearSelection();           
            rcbTempPuesto.ClearSelection();
            rcbTempCoordinacion.ClearSelection();

            this.odsArea.SelectParameters.Clear();
            this.odsArea.SelectParameters.Add("gerencia_id", System.Data.DbType.Guid, selected);
            rcbTempArea.DataBind();

            this.odsCoordinacion.SelectParameters.Clear();
            this.odsCoordinacion.SelectParameters.Add("area_id", System.Data.DbType.Guid, rcbTempArea.SelectedValue);
            rcbTempCoordinacion.DataBind();            

            this.odsPuesto.SelectParameters.Clear();
            this.odsPuesto.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, Guid.Empty.ToString());
            this.odsPuesto.SelectParameters.Add("gerencia_id", System.Data.DbType.Guid, rcbTempGerencia.SelectedValue);
            rcbTempPuesto.DataBind();                

        }

        protected void rcbArea_SelectedIndexChanged(object sender, EventArgs e)
        {

            RadComboBox rcbTempArea = (RadComboBox)sender;
            String selected = rcbTempArea.SelectedValue;            
            RadComboBox rcbTempCoordinacion = (RadComboBox)rcbTempArea.NamingContainer.FindControl("rcbCoordinacion");
            RadComboBox rcbTempPuesto = (RadComboBox)rcbTempArea.NamingContainer.FindControl("rcbPuesto");
            rcbTempCoordinacion.ClearSelection();

            this.odsCoordinacion.SelectParameters.Clear();
            this.odsCoordinacion.SelectParameters.Add("area_id", System.Data.DbType.Guid, selected);
            rcbTempCoordinacion.DataBind();

            if (rcbTempArea.Items.Count != 0)
            {
                rcbTempPuesto.ClearSelection();
                this.odsPuesto.SelectParameters.Clear();
                this.odsPuesto.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, Guid.Empty.ToString());
                this.odsPuesto.SelectParameters.Add("gerencia_id", System.Data.DbType.Guid, Guid.Empty.ToString());
                this.odsPuesto.SelectParameters.Add("area_id", System.Data.DbType.Guid, rcbTempArea.SelectedValue);
                rcbTempPuesto.DataBind(); 
            }            
            
        }

        protected void rcbCoordinacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            RadComboBox rcbTempCoordinacion = (RadComboBox)sender;
            String selected = rcbTempCoordinacion.SelectedValue;
            RadComboBox rcbTempPuesto = (RadComboBox)rcbTempCoordinacion.NamingContainer.FindControl("rcbPuesto");

            if (rcbTempCoordinacion.Items.Count != 0)
            {

                rcbTempPuesto.ClearSelection();
                this.odsPuesto.SelectParameters.Clear();
                this.odsPuesto.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, Guid.Empty.ToString());
                this.odsPuesto.SelectParameters.Add("gerencia_id", System.Data.DbType.Guid, Guid.Empty.ToString());
                this.odsPuesto.SelectParameters.Add("area_id", System.Data.DbType.Guid, Guid.Empty.ToString());
                this.odsPuesto.SelectParameters.Add("coordinacion_id", System.Data.DbType.Guid, rcbTempCoordinacion.SelectedValue);

                rcbTempPuesto.DataBind();
            }
            
        }



 //---------------------------------------------------------------------------------------------------------------------------------
        protected void rcbEmpresaCab_SelectedIndexChanged(object sender, EventArgs e)
        {
            rcbGerenciaCab.ClearSelection();
            
            odsGerencia.SelectParameters.Clear();
            odsGerencia.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, rcbEmpresaCab.SelectedValue);
            rcbGerenciaCab.DataBind();

            odsCompetenciaPuesto.SelectParameters.Clear();
            odsCompetenciaPuesto.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, rcbEmpresaCab.SelectedValue);
            rgCompetenciasPuesto.DataBind();

        }

        protected void rcbGerenciaCab_SelectedIndexChanged(object sender, EventArgs e)
        {   
            rcbAreaCab.ClearSelection();
           
            odsArea.SelectParameters.Clear();
            odsArea.SelectParameters.Add("gerencia_id", System.Data.DbType.Guid, rcbGerenciaCab.SelectedValue);
            rcbAreaCab.DataBind();

            if (rcbAreaCab.Items.Count == 0)
                rcbAreaCab_SelectedIndexChanged(sender, e);

            odsCompetenciaPuesto.SelectParameters.Clear();
            odsCompetenciaPuesto.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, this.rcbEmpresaCab.SelectedValue);
            odsCompetenciaPuesto.SelectParameters.Add("gerencia_id", System.Data.DbType.Guid, rcbGerenciaCab.SelectedValue);
            rgCompetenciasPuesto.DataBind();

        }

        protected void rcbAreaCab_SelectedIndexChanged(object sender, EventArgs e)
        {           
            rcbCoordinacionCab.ClearSelection();
            odsCoordinacion.SelectParameters.Clear();
            odsCoordinacion.SelectParameters.Add("area_id", System.Data.DbType.Guid, rcbAreaCab.SelectedValue);
            rcbCoordinacionCab.DataBind();

            if (rcbAreaCab.Items.Count != 0)
            {
                odsCompetenciaPuesto.SelectParameters.Clear();
                odsCompetenciaPuesto.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, this.rcbEmpresaCab.SelectedValue);
                odsCompetenciaPuesto.SelectParameters.Add("gerencia_id", System.Data.DbType.Guid, rcbGerenciaCab.SelectedValue);
                odsCompetenciaPuesto.SelectParameters.Add("area_id", System.Data.DbType.Guid, rcbAreaCab.SelectedValue);
                rgCompetenciasPuesto.DataBind();
            }            
        }

        protected void rcbCoordinacionCab_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rcbCoordinacionCab.Items.Count != 0)
            {
                odsCompetenciaPuesto.SelectParameters.Clear();
                odsCompetenciaPuesto.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, this.rcbEmpresaCab.SelectedValue);
                odsCompetenciaPuesto.SelectParameters.Add("gerencia_id", System.Data.DbType.Guid, rcbGerenciaCab.SelectedValue);
                odsCompetenciaPuesto.SelectParameters.Add("area_id", System.Data.DbType.Guid, rcbAreaCab.SelectedValue);
                odsCompetenciaPuesto.SelectParameters.Add("coordinacion_id", System.Data.DbType.Guid, rcbCoordinacionCab.SelectedValue);
                rgCompetenciasPuesto.DataBind();
            }
        }













//----------------------------------------------------------------------------------------------------------------------------------------------------
        protected void rcbTipoCompetencia_SelectedIndexChanged(object sender, EventArgs e)
        {

            RadComboBox rcbTempTipoCompetencia = (RadComboBox)sender;
            String selected = rcbTempTipoCompetencia.SelectedValue;
            RadComboBox rcbTempCompetencia = (RadComboBox)rcbTempTipoCompetencia.NamingContainer.FindControl("rcbCompetencia");
            rcbTempCompetencia.ClearSelection();
            this.odsCompetencia.SelectParameters.Clear();
            this.odsCompetencia.SelectParameters.Add("idTipoCompetencia", System.Data.DbType.Guid, selected);

            rcbTempCompetencia.DataBind();

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
            rgCompetenciasPuesto.MasterTableView.FilterExpression = "([oBE_PUESTO.DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_COMPETENCIA_TIPO.COMPETENCIA_TIPO_DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [oBE_COMPETENCIA.DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";

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

            if (values["COMPETENCIA_PUESTO_VALOR_REQUERIDO"] == null)
                oentidad.COMPETENCIA_PUESTO_VALOR_REQUERIDO = 0;
            else
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

            } else{
                oentidad.USUARIO_CREACION = USUARIO;               
                BL_COMPETENCIAS_POR_PUESTO.ActualizarCompetenciaPuesto(oentidad);
            }
        }
    }
}
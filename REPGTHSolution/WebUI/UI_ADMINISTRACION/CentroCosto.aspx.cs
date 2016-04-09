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
    public partial class CentroCosto : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());            
            
        }

        protected void rgCentroCosto_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (!e.Item.GetType().Name.Equals("GridEditFormInsertItem"))
                {
                    BE_CENTRO_COSTO editableItem = ((BE_CENTRO_COSTO)e.Item.DataItem);
                    RadComboBox rcbTempEmpresa = (RadComboBox)e.Item.FindControl("rcbEmpresa");
                    if (rcbTempEmpresa != null)
                        rcbTempEmpresa.SelectedValue = editableItem.EMPRESA_ID.ToString();

                    RadComboBox rcbTempGerencia = (RadComboBox)e.Item.FindControl("rcbGerencia");
                    if (rcbTempGerencia != null)
                    {
                        this.odsGerencia.SelectParameters.Clear();
                        this.odsGerencia.SelectParameters.Add("empresa_id", System.Data.DbType.Guid, rcbTempEmpresa.SelectedValue);

                        rcbTempGerencia.DataBind();

                        rcbTempGerencia.SelectedValue = editableItem.GERENCIA_ID.ToString();
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
            RadComboBox rcbTempArea= (RadComboBox)rcbTempEmpresa.NamingContainer.FindControl("rcbArea");
            rcbTempGerencia.ClearSelection();
            rcbTempArea.ClearSelection();
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

        protected void rgCentroCosto_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }



        protected void rgCentroCosto_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }



        protected void rgCentroCosto_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;
            BL_CENTRO_COSTO BL_CENTRO_COSTO = new BL_CENTRO_COSTO();
            BL_CENTRO_COSTO.EliminarCentroCosto((Guid)ID);
            rgCentroCosto.DataBind();
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
            BL_CENTRO_COSTO BL_CENTRO_COSTO = new BL_CENTRO_COSTO();
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            RadComboBox oRadComboBox2 = (RadComboBox)e.Item.FindControl("rcbGerencia");
            RadComboBox oRadComboBox3 = (RadComboBox)e.Item.FindControl("rcbEmpresa");
            RadComboBox oRadComboBox_Area = (RadComboBox)e.Item.FindControl("rcbArea");

            BE_CENTRO_COSTO oentidad = new BE_CENTRO_COSTO();

            Nullable<Guid> ID;

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());


            oentidad.ID = (Guid)ID;
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();
            oentidad.CODIGO = values["CODIGO"].ToString();
            if (!String.IsNullOrEmpty(oRadComboBox2.SelectedValue))
            {
                oentidad.GERENCIA_ID = Guid.Parse(oRadComboBox2.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox2.Text = String.Empty;
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

            if (!String.IsNullOrEmpty(oRadComboBox_Area.SelectedValue))
            {
                oentidad.AREA_ID = Guid.Parse(oRadComboBox_Area.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox_Area.Text = String.Empty;
                oRadComboBox_Area.EmptyMessage = "<SELECCIONAR>";
                return;
            }

            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_CENTRO_COSTO.InsertarCentroCosto(oentidad);

            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_CENTRO_COSTO.ActualizarCentroCosto(oentidad);

            }



        }
    }
}
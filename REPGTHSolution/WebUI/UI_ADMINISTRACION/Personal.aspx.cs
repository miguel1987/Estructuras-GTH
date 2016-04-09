using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BusinessEntities;
using BusinessLogicLayer;
using System.Collections;
using System.Text;

namespace WebUI.UI_ADMINISTRACION
{
    public partial class Personal : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());

        }

        protected void rgPersonal_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (!e.Item.GetType().Name.Equals("GridEditFormInsertItem"))
                {
                    BE_PERSONAL editableItem = ((BE_PERSONAL)e.Item.DataItem);

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

                    RadComboBox rcbPerfiles = (RadComboBox)e.Item.FindControl("rcbPerfiles");
                    if (rcbPerfiles != null)
                        rcbPerfiles.SelectedValue = editableItem.PERFIL_ID.ToString();

                    RadComboBox rcbTempTipoJefe = (RadComboBox)e.Item.FindControl("rcbTipoJefe");
                    if (rcbTempTipoJefe != null)
                        rcbTempTipoJefe.SelectedValue = editableItem.ES_JEFE.ToString();

                }
            }

        }

        protected void rcbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

            RadComboBox rcbTempEmpresa = (RadComboBox)sender;
            String selected = rcbTempEmpresa.SelectedValue;
            RadComboBox rcbTempGerencia = (RadComboBox)rcbTempEmpresa.NamingContainer.FindControl("rcbGerencia");
            RadComboBox rcbTempArea = (RadComboBox)rcbTempEmpresa.NamingContainer.FindControl("rcbArea");
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


        protected void rgPersonal_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }



        protected void rgPersonal_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }



        protected void rgPersonal_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;

            BL_PERSONAL BL_PERSONAL = new BL_PERSONAL();
            BL_PERSONAL.EliminarPersonal((Guid)ID);
            rgPersonal.DataBind();
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity

            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            RadComboBox oRadComboBox1 = (RadComboBox)e.Item.FindControl("rcbEmpresa");

            RadComboBox oRadComboBox2 = (RadComboBox)e.Item.FindControl("rcbGerencia");

            RadComboBox oRadComboBox3 = (RadComboBox)e.Item.FindControl("rcbArea");

            RadComboBox oRadComboBox4 = (RadComboBox)e.Item.FindControl("rcbPerfiles");

            RadComboBox oRadComboBox_TipoJefe = (RadComboBox)e.Item.FindControl("rcbTipoJefe");   


            BE_PERSONAL oentidad = new BE_PERSONAL();
            BL_PERSONAL BL_PERSONAL = new BL_PERSONAL();

            Nullable<Guid> ID;

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());


            oentidad.ID = (Guid)ID;
            oentidad.CODIGO_TRABAJO = values["CODIGO_TRABAJO"].ToString();
            oentidad.NOMBRES = values["NOMBRES"].ToString();
            oentidad.APELLIDO_PATERNO = values["APELLIDO_PATERNO"].ToString();
            oentidad.APELLIDO_MATERNO = values["APELLIDO_MATERNO"].ToString();
            oentidad.DEPARTAMENTO = String.Empty;
            oentidad.PUESTO = values["PUESTO"].ToString();
            oentidad.CORREO = values["CORREO"].ToString();
            oentidad.NOMBRE_USUARIO = values["NOMBRE_USUARIO"].ToString();

            if (!String.IsNullOrEmpty(oRadComboBox1.SelectedValue))
            {
                oentidad.EMPRESA_ID = Guid.Parse(oRadComboBox1.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox1.Text = String.Empty;
                return;
            }

            if (!String.IsNullOrEmpty(oRadComboBox2.SelectedValue))
            {
                oentidad.GERENCIA_ID = Guid.Parse(oRadComboBox2.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox2.Text = String.Empty;
                return;
            }


            if (!String.IsNullOrEmpty(oRadComboBox4.SelectedValue))
            {
                oentidad.PERFIL_ID = Int32.Parse(oRadComboBox4.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox4.Text = String.Empty;
                return;
            }


            if (!String.IsNullOrEmpty(oRadComboBox3.SelectedValue))
            {
                oentidad.AREA_ID = Guid.Parse(oRadComboBox3.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox3.Text = String.Empty;
                return;
            }

            if (!String.IsNullOrEmpty(oRadComboBox_TipoJefe.SelectedValue))
            {
                oentidad.ES_JEFE = Int32.Parse(oRadComboBox_TipoJefe.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox_TipoJefe.Text = String.Empty;
                return;
            }


            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_PERSONAL.InsertarPersonal(oentidad);
                rgPersonal.Rebind();
                
            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_PERSONAL.ActualizarPersonal(oentidad);
                rgPersonal.Rebind();
                
            }
        }
    }
}
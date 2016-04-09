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
    public partial class Direccion : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
        }
        protected void rgDireccion_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.EditItem)
            {
                if (!e.Item.GetType().Name.Equals("GridDataInsertItem"))
                {
                    BE_DIRECCION editableItem = ((BE_DIRECCION)e.Item.DataItem);
                }
            }

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (!e.Item.GetType().Name.Equals("GridEditFormInsertItem"))
                {
                    BE_DIRECCION editableItem = ((BE_DIRECCION)e.Item.DataItem);

                    RadComboBox rcbTempTipoSolicitud = (RadComboBox)e.Item.FindControl("rcbTipoSolicitud");
                    if (rcbTempTipoSolicitud != null)
                        rcbTempTipoSolicitud.SelectedValue = editableItem.TIPO_ENVIO.ToString();

                    RadComboBox rcbTempTipoDireccion = (RadComboBox)e.Item.FindControl("rcbTipoDireccion");
                    if (rcbTempTipoDireccion != null)
                        rcbTempTipoDireccion.SelectedValue = editableItem.TIPO.ToString();

                }
            }

        }

        protected void rcbTipoDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {

            RadComboBox rcbTempTipoDireccion = (RadComboBox)sender;
            String selected = rcbTempTipoDireccion.SelectedValue;
            TextBox txtTempDestinatario = (TextBox)rcbTempTipoDireccion.NamingContainer.FindControl("txtDestinatario");
            TextBox txtTempAtencion = (TextBox)rcbTempTipoDireccion.NamingContainer.FindControl("txtAtencion");
            if (selected == "1")
            {
                txtTempDestinatario.Enabled = false;
                txtTempAtencion.Enabled = false;
            }
            else
            {
                txtTempDestinatario.Enabled = true;
                txtTempAtencion.Enabled = true;
            }

        }


        protected void rgDireccion_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }



        protected void rgDireccion_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }



        protected void rgDireccion_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;

            if (BL_DIRECCION.EliminarDireccion((Guid)ID))
                BL_DIRECCION.EliminarDireccionAtencionPorDestinatario((Guid)ID);

            rgDireccion.DataBind();
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity

            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            RadComboBox oRadComboBox_TipoSolicitud = (RadComboBox)e.Item.FindControl("rcbTipoSolicitud");
            RadComboBox oRadComboBox_TipoDireccion = (RadComboBox)e.Item.FindControl("rcbTipoDireccion");
            TextBox oTextBox_Destinatario = (TextBox)e.Item.FindControl("txtDestinatario");
            TextBox oTextBox_Atencion = (TextBox)e.Item.FindControl("txtAtencion");            

            Nullable<Guid> ID;

            BE_DIRECCION oentidad = new BE_DIRECCION();

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());


            oentidad.ID = (Guid)ID;
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();

            if (!String.IsNullOrEmpty(oRadComboBox_TipoSolicitud.SelectedValue))
            {
                oentidad.TIPO_ENVIO = Int32.Parse(oRadComboBox_TipoSolicitud.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox_TipoSolicitud.Text = String.Empty;
                return;
            }

            if (!String.IsNullOrEmpty(oRadComboBox_TipoDireccion.SelectedValue))
            {
                oentidad.TIPO = Int32.Parse(oRadComboBox_TipoDireccion.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox_TipoDireccion.Text = String.Empty;
                return;
            }

            if (!String.IsNullOrEmpty(oTextBox_Destinatario.Text))
            {
                oentidad.DESTINATARIO = oTextBox_Destinatario.Text;
            }
            else
            {
                oentidad.DESTINATARIO = String.Empty;                
            }

            if (!String.IsNullOrEmpty(oTextBox_Atencion.Text))
            {
                oentidad.ATENCION = oTextBox_Atencion.Text;
            }
            else
            {
                oentidad.ATENCION = String.Empty;
            }

            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_DIRECCION.InsertarDireccion(oentidad);
            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_DIRECCION.ActualizarDireccion(oentidad);
            }
        }

    }
}
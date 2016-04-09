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
    public partial class DireccionAtencion : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
        }
        protected void rgDireccionAtencion_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.EditItem)
            {
                if (!e.Item.GetType().Name.Equals("GridDataInsertItem"))
                {
                    BE_DIRECCION_ATENCION editableItem = ((BE_DIRECCION_ATENCION)e.Item.DataItem);
                }
            }

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (!e.Item.GetType().Name.Equals("GridEditFormInsertItem"))
                {
                    BE_DIRECCION_ATENCION editableItem = ((BE_DIRECCION_ATENCION)e.Item.DataItem);

                    RadComboBox rcbTempDireccionDestinatario = (RadComboBox)e.Item.FindControl("rcbDireccionDestinatario");
                    if (rcbTempDireccionDestinatario != null)
                        rcbTempDireccionDestinatario.SelectedValue = editableItem.oBE_DIRECCION.ID.ToString();                    

                }
            }

        }


        protected void rgDireccionAtencion_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }



        protected void rgDireccionAtencion_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }



        protected void rgDireccionAtencion_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;

            BL_DIRECCION.EliminarDireccionAtencion((Guid)ID);
            rgDireccionAtencion.DataBind();
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity

            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            RadComboBox oRadComboBox_DireccionDestinatario = (RadComboBox)e.Item.FindControl("rcbDireccionDestinatario");                       
            TextBox oTextBox_Atencion = (TextBox)e.Item.FindControl("txtAtencion");            

            Nullable<Guid> ID;

            BE_DIRECCION_ATENCION oentidad = new BE_DIRECCION_ATENCION();

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());


            oentidad.ID = (Guid)ID;            

            if (!String.IsNullOrEmpty(oRadComboBox_DireccionDestinatario.SelectedValue))
            {
                oentidad.DIRECCION_ID = Guid.Parse(oRadComboBox_DireccionDestinatario.SelectedValue);
                oentidad.DESTINATARIO = oRadComboBox_DireccionDestinatario.SelectedItem.Text;
            }
            else
            {
                e.Canceled = true;
                oRadComboBox_DireccionDestinatario.Text = String.Empty;
                return;
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
                BL_DIRECCION.InsertarDireccionAtencion(oentidad);
            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_DIRECCION.ActualizarDireccionAtencion(oentidad);
            }
        }

    }
}
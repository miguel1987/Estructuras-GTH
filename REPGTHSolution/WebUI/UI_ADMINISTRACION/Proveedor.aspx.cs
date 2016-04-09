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
    public partial class Proveedor : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());

        }

        protected void rgProveedor_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.EditItem)
            {
                if (!e.Item.GetType().Name.Equals("GridDataInsertItem"))
                {
                    BE_PROVEEDOR editableItem = ((BE_PROVEEDOR)e.Item.DataItem);                    
                }
            }

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (!e.Item.GetType().Name.Equals("GridEditFormInsertItem"))
                {
                    BE_PROVEEDOR editableItem = ((BE_PROVEEDOR)e.Item.DataItem);  
                    
                    RadComboBox rcbTempTipoSolicitud = (RadComboBox)e.Item.FindControl("rcbTipoSolicitud");
                    if (rcbTempTipoSolicitud != null)
                        rcbTempTipoSolicitud.SelectedValue = editableItem.TIPO.ToString();

                }
            }

        }


        protected void rgProveedor_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }



        protected void rgProveedor_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }



        protected void rgProveedor_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;

            BL_PROVEEDOR.EliminarProveedor((Guid)ID);
            rgProveedor.DataBind();
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity

            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            RadComboBox oRadComboBox_TipoSolicitud = (RadComboBox)e.Item.FindControl("rcbTipoSolicitud");            

            Nullable<Guid> ID;

            BE_PROVEEDOR oentidad = new BE_PROVEEDOR();

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());


            oentidad.ID = (Guid)ID;
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();

            if (!String.IsNullOrEmpty(oRadComboBox_TipoSolicitud.SelectedValue))
            {
                oentidad.TIPO = Int32.Parse(oRadComboBox_TipoSolicitud.SelectedValue);
            }
            else
            {
                e.Canceled = true;
                oRadComboBox_TipoSolicitud.Text = String.Empty;
                return;
            }

            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_PROVEEDOR.InsertarProveedor(oentidad);
            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_PROVEEDOR.ActualizarProveedor(oentidad);
            }
        }


    }
}
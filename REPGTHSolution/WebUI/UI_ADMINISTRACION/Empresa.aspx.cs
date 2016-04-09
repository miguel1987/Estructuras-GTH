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
    public partial class Empresa : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());

        }

        protected void rgEmpresa_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.EditItem)
            {
                if (!e.Item.GetType().Name.Equals("GridDataInsertItem"))
                {
                    BE_EMPRESA editableItem = ((BE_EMPRESA)e.Item.DataItem);
                }
            }

        }


        protected void rgEmpresa_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }



        protected void rgEmpresa_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }



        protected void rgEmpresa_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            int validarEliminar = 0;
            BL_EMPRESA BL_EMPRESA = new BL_EMPRESA();
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;

            //Validar que la empresa a eliminar no esté asociada a ninguna gerencia activa.    
            BL_GERENCIA BL_GERENCIA = new BL_GERENCIA();                
            List<BE_GERENCIA> lstGerencias = BL_GERENCIA.SeleccionarGerenciaPorEmpresa((Guid)ID);

            if (lstGerencias == null || lstGerencias.Count == 0)
                validarEliminar += 1;     
    
            if (validarEliminar > 0)
            {
                BL_EMPRESA.EliminarEmpresa((Guid)ID);
                rgEmpresa.DataBind();
            }
            else
            {
                string message = "'No puede eliminar una Empresa asociada a una o más Gerencias'";
                string javaScriptCode = "Sys.Application.add_load(function() {showRadConfirm(" + message + ");});";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RadConfirmStart", javaScriptCode, true);
            }
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
            BL_EMPRESA BL_EMPRESA = new BL_EMPRESA();
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            BE_EMPRESA oentidad = new BE_EMPRESA();

            Nullable<Guid> ID;

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());


            oentidad.ID = (Guid)ID;
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();

            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_EMPRESA.InsertarEmpresa(oentidad);
            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_EMPRESA.ActualizarEmpresa(oentidad);
            }
        }
    }
}
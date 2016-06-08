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
    public partial class GrupoOrganizacional : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());

        }

        protected void rgGrupoOrganizacional_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.EditItem)
            {
                if (!e.Item.GetType().Name.Equals("GridDataInsertItem"))
                {
                    BE_GRUPO_ORGANIZACIONAL editableItem = ((BE_GRUPO_ORGANIZACIONAL)e.Item.DataItem);
                }
            }

        }


        protected void rgGrupoOrganizacional_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }



        protected void rgGrupoOrganizacional_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }



        protected void rgGrupoOrganizacional_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            int validarEliminar = 0;
            BL_GRUPO_ORGANIZACIONAL BL_GRUPO_ORGANIZACIONAL = new BL_GRUPO_ORGANIZACIONAL();
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;

            //Validar que el grupo organizacional a eliminar no esté asociada a ninguna personal activa.    
            BL_PERSONAL BL_PERSONAL = new BL_PERSONAL();
            List<BE_PERSONAL> lstPersonal = BL_PERSONAL.SeleccionarPersonalPorGrupoOrganizacional((Guid)ID);

            if (lstPersonal == null || lstPersonal.Count == 0)
                validarEliminar += 1;     
    
            if (validarEliminar > 0)
            {
                BL_GRUPO_ORGANIZACIONAL.EliminarGrupoOrganizacional((Guid)ID);
                rgGrupoOrganizacional.DataBind();
            }
            else
            {
                string message = "'No puede eliminar un Grupo Organizacional asociada a una o más Personas'";
                string javaScriptCode = "Sys.Application.add_load(function() {showRadConfirm(" + message + ");});";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RadConfirmStart", javaScriptCode, true);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            rgGrupoOrganizacional.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";

            rgGrupoOrganizacional.Rebind();

        }

        protected void linkBuscar_Click(object sender, EventArgs e)
        {

            rgGrupoOrganizacional.MasterTableView.FilterExpression = "([DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [CODIGO]LIKE \'%" + txtBuscar.Text.Trim() + "%\')";

            rgGrupoOrganizacional.Rebind();

        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
            BL_GRUPO_ORGANIZACIONAL BL_GRUPO_ORGANIZACIONAL = new BL_GRUPO_ORGANIZACIONAL();
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            BE_GRUPO_ORGANIZACIONAL oentidad = new BE_GRUPO_ORGANIZACIONAL();

            Nullable<Guid> ID;

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());


            oentidad.ID = (Guid)ID;
            oentidad.CODIGO = values["CODIGO"].ToString();
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();

            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_GRUPO_ORGANIZACIONAL.InsertarGrupoOrganizacional(oentidad);
            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_GRUPO_ORGANIZACIONAL.ActualizarGrupoOrganizacional(oentidad);
            }
        }
    }
}
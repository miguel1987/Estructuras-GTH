﻿using System;
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
    public partial class CuentaMayor : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());      
        }

        protected void rgCuentaMayor_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "add");
        }



        protected void rgCuentaMayor_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e, "Edit");
        }



        protected void rgCuentaMayor_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Nullable<Guid> ID;
            if (editableItem.GetDataKeyValue("ID") != null)
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());
            else
                ID = Guid.Empty;
           
            BL_CUENTA_MAYOR.EliminarCuentaMayor((Guid)ID);
            rgCuentaMayor.DataBind();
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e, String action)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
           
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);           

            BE_CUENTA_MAYOR oentidad = new BE_CUENTA_MAYOR();

            Nullable<Guid> ID;

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                ID = Guid.Empty;
            else
                ID = Guid.Parse(editableItem.GetDataKeyValue("ID").ToString());


            oentidad.ID = (Guid)ID;
            oentidad.DESCRIPCION = values["DESCRIPCION"].ToString();
            oentidad.CODIGO = values["CODIGO"].ToString();          

            if (action == "add")
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_CUENTA_MAYOR.InsertarCuentaMayor(oentidad);

            }
            else
            {
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ESTADO = 1;
                BL_CUENTA_MAYOR.ActualizarCuentaMayor(oentidad);

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using Telerik.Web.UI;
using System.Threading;
using System.Security.Principal;
using System.Net;

namespace WebUI
{
    /// <summary>
    /// Clase para los metodos generales
    /// </summary>
    public class PageBaseClass : System.Web.UI.Page
    {
        public void CargarGridView(GridView grdControl, object oControl)
        {
            grdControl.DataSource = oControl;
            grdControl.DataBind();
        }
        /// <summary>
        /// Cargar DropDownList con datos
        /// </summary>
        /// <param name="ddlControl">Control al cual se desea llenar de datos</param>
        /// <param name="pEntrada">1: Agregan un item de de TODOS, 2: Agrega un item de seleccionar, 0: none</param>
        public void CargarDropDownList(DropDownList ddlControl, string FieldValue, string FieldText, object oControl, Int16 pEntrada = 0)
        {

            ddlControl.Items.Clear();
            ddlControl.DataTextField = FieldText;
            ddlControl.DataValueField = FieldValue;
            ddlControl.DataSource = oControl;
            ddlControl.DataBind();


            if (pEntrada == 1)
            {
                ddlControl.Items.Insert(0, new ListItem("<TODOS> ", "%"));
                ddlControl.SelectedValue = "%";
            }
            if (pEntrada == 2)
            {
                ddlControl.Items.Insert(0, new ListItem("<SELECCIONAR> ", "-"));
                ddlControl.SelectedValue = "-";
            }
            if (pEntrada == 3)
            {                
                ddlControl.Items.Insert(0, new ListItem("<SELECCIONAR>", "-"));
                ddlControl.Items.Insert(1, new ListItem("<OTRO>", "0"));
                ddlControl.SelectedValue = "-";

            }

        }

        /// <summary>
        /// Cargar DropDownList con datos
        /// </summary>
        /// <param name="ddlControl">Control al cual se desea llenar de datos</param>
        /// <param name="pEntrada">1: Agregan un item de de TODOS, 2: Agrega un item de seleccionar, 0: none</param>
        public void CargarDropDownList(RadComboBox ddlControl, string FieldValue, string FieldText, object oControl, Int16 pEntrada = 0)
        {

            ddlControl.Items.Clear();
            ddlControl.DataTextField = FieldText;
            ddlControl.DataValueField = FieldValue;
            ddlControl.DataSource = oControl;
            ddlControl.DataBind();


            if (pEntrada == 1)
            {
                ddlControl.Items.Insert(0, new RadComboBoxItem("TODOS...", "%"));
                ddlControl.SelectedValue = "%";
            }
            if (pEntrada == 2)
            {
                ddlControl.Items.Insert(0, new RadComboBoxItem("SELECCIONAR...", "-"));
                ddlControl.SelectedValue = "-";
            }
            if (pEntrada == 3)
            {
                ddlControl.Items.Insert(0, new RadComboBoxItem("SELECCIONAR...", "-"));
                ddlControl.Items.Insert(1, new RadComboBoxItem("OTRO...", "0"));
                ddlControl.SelectedValue = "-";

            }

        }  
       

        public void MostrarMensaje(System.Web.UI.ControlCollection control, string message, bool cerrarPagina = false)
        {
            string str = null;
            if (cerrarPagina)
            {
                str = "<script language='JavaScript'>alert('" + message.Trim().Replace("'", "\\'").Replace(System.Environment.NewLine, "<br/>") + "'); CloseFormOK();</script>";
            }
            else
            {
                str = "<script language='JavaScript'>alert('" + message.Trim().Replace("'", "\\'").Replace(System.Environment.NewLine, "<br/>") + "');</script>";
            }
            control.Add(new LiteralControl(str));
        }

        

        public void validarUsuarioEnDominio()
        {
            //string userId = HttpContext.Current.User.Identity.Name.ToString();
            
            string userId = "Pc\\soporte_ipd";               
            
            string[] useridNew = userId.Trim().Split(new[] { "\\" }, StringSplitOptions.None);
            
            BusinessEntities.BE_USUARIO oBE_USUARIO = BusinessLogicLayer.BL_USUARIO.SeleccionarPersonalPorUsuario(useridNew[1]);
            if (oBE_USUARIO == null || oBE_USUARIO.PERSONAL_ID == Guid.Empty)
            {
                Response.Redirect("../UI_SEGURIDAD/Acceso.aspx");
            }
            else if (oBE_USUARIO.PERFIL_ID == 0) //Sin Perfil
            {
                Response.Redirect("../UI_SEGURIDAD/Acceso.aspx");
            }
            else
            {
                Session.Add("PERSONAL_ID", oBE_USUARIO.PERSONAL_ID);
                Session.Add("COORDINACION_ID", oBE_USUARIO.oBE_PERSONAL.COORDINACION_ID);
                Session.Add("AREA_ID", oBE_USUARIO.oBE_PERSONAL.AREA_ID);
                Session.Add("GERENCIA_ID", oBE_USUARIO.oBE_PERSONAL.GERENCIA_ID);
                Session.Add("EMPRESA_ID", oBE_USUARIO.oBE_PERSONAL.EMPRESA_ID);
                Session.Add("PERSONAL_NOMBRE_USUARIO", oBE_USUARIO.oBE_PERSONAL.NOMBRE_USUARIO);
                Session.Add("PERFIL_ID", oBE_USUARIO.PERFIL_ID);
                Session.Add("PERSONAL_NOMBRE_COMPLETO", oBE_USUARIO.oBE_PERSONAL.NOMBRES_COMPLETOS);
                Session.Add("PERSONAL_PUESTO", oBE_USUARIO.oBE_PERSONAL.PUESTO_ID);
                if (oBE_USUARIO.oBE_PERSONAL.oBE_GRUPO_ORGANIZACIONAL != null)
                    Session.Add("GRUPO_ORGANIZACIONAL_CODIGO", oBE_USUARIO.oBE_PERSONAL.oBE_GRUPO_ORGANIZACIONAL.CODIGO);
                else
                    Session.Add("GRUPO_ORGANIZACIONAL_CODIGO", String.Empty);
            }     
            
        }
    }
    
    public class CustomReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    {

        // local variable for network credential.
        private string _UserName;
        private string _PassWord;
        private string _DomainName;
        public CustomReportCredentials(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
        }
        public WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;  // not use ImpersonationUser
            }
        }
        public ICredentials NetworkCredentials
        {
            get
            {

                // use NetworkCredentials
                return new NetworkCredential(_UserName, _PassWord, _DomainName);
            }
        }
        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {

            // not use FormsCredentials unless you have implements a custom autentication.
            authCookie = null;
            user = password = authority = null;
            return false;
        }

    }

}
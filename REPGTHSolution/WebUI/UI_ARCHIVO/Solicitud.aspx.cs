using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BusinessEntities;
using BusinessLogicLayer;
using Telerik.Web.UI;
using System.Collections;
using System.Text;

namespace WebUI.UI_ARCHIVO
{
    public partial class Solicitud : PageBaseClass
    {
        Guid USUARIO;
        const int MaxTotalBytes = 1048576; // 1 MB

        protected void Page_Load(object sender, EventArgs e)
        {  

            if (!Page.IsPostBack)
            {
                try
                {
                    this.validarUsuarioEnDominio();
                    USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());                    

                    HttpContext Context = HttpContext.Current;
                    this.lblMensaje.Text = string.Empty;
                    this.hdfSolicitudEstado.Value = string.Empty;
                    this.hdfSolicitudId.Value = string.Empty;
                    
                    //Recupero SolicitudId si estamos actualizando
                    if (Context.Items.Contains("heSolicitudId"))
                    {
                        hdfSolicitudId.Value = Context.Items["heSolicitudId"].ToString();
                    }
                    if (!String.IsNullOrEmpty(Context.Request.QueryString["heSolicitudId"]))
                    {                       
                        hdfSolicitudId.Value = Context.Request.QueryString["heSolicitudId"];
                    } 

                    if (hdfSolicitudId.Value.Equals(String.Empty))
                    {
                        //Crear Nueva Solicitud
                        btnCerrar.Visible = false;
                        btnGenerarEtiqueta.Visible = false;
                        //Cargo Valores Por Defecto
                        LoadDatosSolicitud();
                        ddlTipoSolicitud_SelectedIndexChanged(sender, e);

                    }
                    else
                    {
                        //Actualizar Solicitud Seleccionada
                        CargarValoresSolicitud(Guid.Parse(hdfSolicitudId.Value));  
                        //Cargar Documentos                                                   
                        List<BE_DOCUMENTO> lstDocumentos = BL_DOCUMENTO.SeleccionarDocumentosPorSolicitud(Guid.Parse(hdfSolicitudId.Value));
                        if (lstDocumentos == null || lstDocumentos.Count == 0)
                        {
                            RadGrid rgDocumentos = (RadGrid)rpbSolicitud.FindItemByValue("Documentos").FindControl("rgDocumentos");
                            rgDocumentos.DataSource = String.Empty;                            
                            
                        }

  
                    }
                    ValidarPerfilUsuario();

                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al Cargar Solicitud:" + ex.ToString();

                }

            }
        }

        protected void ValidarPerfilUsuario()
        {
            //Si perfil = Usuario solo puede crear solicitudes en su empresa, gerencia y área
            if (Session["PERFIL_ID"].ToString() == "2")
            {
                DropDownList ddlEmpresa = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlEmpresa");
                DropDownList ddlGerencia = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlGerencia");                
                DropDownList ddlArea = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlArea");
                ddlEmpresa.Enabled = false;
                ddlGerencia.Enabled = false;
                //301115: Cambio solicitado por usuarios. Habilitar todas las áreas de la gerencia a la que pertenece el usuario
                ddlArea.Enabled = true;
            }

        }

        protected void ValidarEstadoSolicitud(int estadoSolicitud)
        {
            switch (estadoSolicitud)
            {
                case 1:
                    btnGenerarEtiqueta.Enabled = false;
                    btnCerrar.Enabled = false;
                    lblMensaje.Text = "Solicitud Pendiente de Aprobación";
                    break;
                case 2:
                    btnCerrar.Enabled = true;
                    btnGenerarEtiqueta.Enabled = true;
                    lblMensaje.Text = "Solicitud Aprobada";
                    break;
                case 3:
                    btnGuardar.Enabled = false;
                    btnGenerarEtiqueta.Enabled = false;
                    btnCerrar.Enabled = false;
                    lblMensaje.Text = "Solicitud Rechazada";
                    break;
                case 4:
                    btnGuardar.Enabled = false;
                    btnGenerarEtiqueta.Enabled = false;
                    btnCerrar.Enabled = false;
                    lblMensaje.Text = "Solicitud Cerrada";
                    RadGrid rgDocumentos = (RadGrid)rpbSolicitud.FindItemByValue("Documentos").FindControl("rgDocumentos");                    
                    rgDocumentos.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    rgDocumentos.MasterTableView.GetColumn("EliminarDocumento").Display = false;
                    break;   
                default:
                    btnGenerarEtiqueta.Enabled = false;
                    btnCerrar.Enabled = false;
                    lblMensaje.Text = "Solicitud Pendiente de Aprobación";                    
                    break;
            }
        }

        protected void ValidarActualizador(Guid UsuarioActualizador, Guid UsuarioCreador)
        {
            if (UsuarioActualizador != UsuarioCreador)
            {               
                if (Session["PERFIL_ID"].ToString() == "2")
                {
                    //Ocultar botones
                    btnGuardar.Enabled = false;
                    btnCerrar.Enabled = false;
                    btnGenerarEtiqueta.Enabled = false;
                    
                }
                else if (Session["PERFIL_ID"].ToString() == "1")
                {
                    //Si es administrador puede editar cualquier solicitud
                    btnGuardar.Enabled = true;                    

                }

            }       
        }

        protected void LoadDatosSolicitud()
        {           

            RadDatePicker rdpFechaRegistro = (RadDatePicker)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("rdpFechaRegistro");
            TextBox txtSolicitante = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtSolicitante");            
            DropDownList ddlEmpresa = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlEmpresa");
            DropDownList ddlGerencia = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlGerencia");
            DropDownList ddlArea = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlArea");
                        
            rdpFechaRegistro.SelectedDate = DateTime.Now.Date;
            LoadEmpresa(0);
            LoadGerencia(0);
            LoadCuentaMayor();
            LoadAutorizador();
            txtSolicitante.Text = Session["PERSONAL_NOMBRE_COMPLETO"].ToString();

        }

        protected void LoadEmpresa(int isEdit)
        {
            BL_EMPRESA BL_EMPRESA = new BL_EMPRESA();

            DropDownList ddlEmpresa = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlEmpresa");

            this.CargarDropDownList(ddlEmpresa, "ID", "DESCRIPCION", BL_EMPRESA.SeleccionarEmpresa(), 0);

            if (isEdit == 0)
                ddlEmpresa.SelectedValue = Session["EMPRESA_ID"].ToString();            
            
        }


        protected void LoadGerencia(int isEdit)
        {
            BL_GERENCIA BL_GERENCIA = new BL_GERENCIA();

            DropDownList ddlEmpresa = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlEmpresa");
            DropDownList ddlGerencia = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlGerencia");

            this.CargarDropDownList(ddlGerencia, "ID", "DESCRIPCION", BL_GERENCIA.SeleccionarGerenciaPorEmpresa(Guid.Parse(ddlEmpresa.SelectedValue)));

            if (isEdit == 0)
            {
                ddlGerencia.SelectedValue = Session["GERENCIA_ID"].ToString();
                LoadArea(isEdit);
                
            }
            
           
        }

        protected void LoadArea(int isEdit)
        {
            BL_AREA BL_AREA = new BL_AREA();

            DropDownList ddlArea = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlArea");
            DropDownList ddlGerencia = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlGerencia");

            if (ddlGerencia.SelectedValue != String.Empty)
                this.CargarDropDownList(ddlArea, "ID", "DESCRIPCION", BL_AREA.SeleccionarAreaGerencia(Guid.Parse(ddlGerencia.SelectedValue)));

            if (isEdit == 0)
            {
                ddlArea.SelectedValue = Session["AREA_ID"].ToString();
                LoadCentroCosto();
                LoadOrden();
                LoadCentroGestor();            
                
            }
            

        }

        protected void LoadCentroCosto()
        {
            BL_CENTRO_COSTO BL_CENTRO_COSTO = new BL_CENTRO_COSTO();

            DropDownList ddlCentroCosto = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCentroCosto");
            DropDownList ddlArea = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlArea");

            if (ddlArea.SelectedValue != String.Empty)
                this.CargarDropDownList(ddlCentroCosto, "ID", "CODIGO_DESCRIPCION", BL_CENTRO_COSTO.SeleccionarCentroCostoArea(Guid.Parse(ddlArea.SelectedValue)), 3);
           
        }

        protected void LoadOrden()
        {
            BL_ORDEN BL_ORDEN = new BL_ORDEN();

            DropDownList ddlOrden = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlOrden");
            DropDownList ddlArea = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlArea");

            if (ddlArea.SelectedValue != String.Empty)
                this.CargarDropDownList(ddlOrden, "ID", "CODIGO_DESCRIPCION", BL_ORDEN.SeleccionarOrdenesPorArea(Guid.Parse(ddlArea.SelectedValue)), 3);

        }

        protected void LoadCentroGestor()
        {
            BL_CENTRO_GESTOR BL_CENTRO_GESTOR = new BL_CENTRO_GESTOR();

            DropDownList ddlCentroGestor = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCentroGestor");
            DropDownList ddlArea = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlArea");

            if (ddlArea.SelectedValue != String.Empty)
                this.CargarDropDownList(ddlCentroGestor, "ID", "CODIGO_DESCRIPCION", BL_CENTRO_GESTOR.SeleccionarCentrosGestoresPorArea(Guid.Parse(ddlArea.SelectedValue)), 3); 

        }

        protected void LoadCuentaMayor()
        {
            BL_CUENTA_MAYOR BL_CUENTA_MAYOR = new BL_CUENTA_MAYOR();

            DropDownList ddlCuentaMayor = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCuentaMayor");

            this.CargarDropDownList(ddlCuentaMayor, "ID", "CODIGO_DESCRIPCION", BL_CUENTA_MAYOR.SeleccionarCuentasMayores(), 0);

        }

        protected void LoadAutorizador()
        {
            BL_PERSONAL BL_PERSONAL = new BL_PERSONAL();

            DropDownList ddlAutoriza = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlAutoriza");
            DropDownList ddlGerencia = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlGerencia");

            if (ddlGerencia.SelectedValue != String.Empty)
                this.CargarDropDownList(ddlAutoriza, "ID", "NOMBRES_COMPLETOS", BL_PERSONAL.SeleccionarPersonalJefesPorGerencia(Guid.Parse(ddlGerencia.SelectedValue)));

        }

        protected void LoadProveedor(int tipoSolicitud)
        {
            BL_PROVEEDOR BL_PROVEEDOR = new BL_PROVEEDOR();

            DropDownList ddlProveedor = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlProveedor");

            this.CargarDropDownList(ddlProveedor, "ID", "DESCRIPCION", BL_PROVEEDOR.SeleccionarProveedoresPorTipo(tipoSolicitud), 0);            

        }

        protected void SiguienteButton_Click(object sender, EventArgs e)
        {
            GoToSiguienteItem();
        }

        protected void ddlTipoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTipoSolicitud(0);
        }

        protected void ddlCentroCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox txtOtroCentroCosto = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtOtroCentroCosto");
            DropDownList ddlCentroCosto = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCentroCosto");

            if (ddlCentroCosto.SelectedValue != "0" && ddlCentroCosto.SelectedValue != "-")
            {
                txtOtroCentroCosto.Visible = false;

            }
            else if (ddlCentroCosto.SelectedValue == "-")
            {
                txtOtroCentroCosto.Visible = false;               
            }
            else
            {
                txtOtroCentroCosto.Visible = true;                
            }
        }

        protected void ddlOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox txtOtraOrden = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtOtraOrden");
            DropDownList ddlOrden = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlOrden");

            if (ddlOrden.SelectedValue != "0" && ddlOrden.SelectedValue != "-")
            {
                txtOtraOrden.Visible = false;

            }
            else if (ddlOrden.SelectedValue == "-")
            {
                txtOtraOrden.Visible = false;
            }
            else
            {
                txtOtraOrden.Visible = true;
            }
        }

        protected void ddlCentroGestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox txtOtroCentroGestor = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtOtroCentroGestor");
            DropDownList ddlCentroGestor = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCentroGestor");

            if (ddlCentroGestor.SelectedValue != "0" && ddlCentroGestor.SelectedValue != "-")
            {
                txtOtroCentroGestor.Visible = false;

            }
            else if (ddlCentroGestor.SelectedValue == "-")
            {
                txtOtroCentroGestor.Visible = false;
            }
            else
            {
                txtOtroCentroGestor.Visible = true;
            }
        }

        protected void ddlDireccionDestinatario_SelectedIndexChanged(object sender, EventArgs e)
        {           
            string tipoSolicitud = String.Empty;           

            DropDownList ddlTipoSolicitud = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlTipoSolicitud");


            if (ddlTipoSolicitud.SelectedValue.ToString() == "1")
            {
                tipoSolicitud = "DatosEnvioNacional";

            }
            else if (ddlTipoSolicitud.SelectedValue.ToString() == "2")
            {
                tipoSolicitud = "DatosEnvioInternacional";

            }

            //txtDestinatario = Dirección Destinatario y ddlDireccionDestinatario = Destinatario
            Label lblOtroDestinatario = (Label)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("lblOtroDestinatario");
            TextBox txtOtroDestinatario = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtOtroDestinatario");
            TextBox txtDestinatario = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtDestinatario");
            RadComboBox ddlDireccionDestinatario = (RadComboBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("ddlDireccionDestinatario");
            RadComboBox ddlAtencion = (RadComboBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("ddlAtencion");

            if (ddlDireccionDestinatario.SelectedValue != "0" && ddlDireccionDestinatario.SelectedValue != "-" && ddlDireccionDestinatario.SelectedValue!="")
            {
                BE_DIRECCION oBE_DIRECCION = BL_DIRECCION.SeleccionarDireccionPorId(Guid.Parse(ddlDireccionDestinatario.SelectedValue));

                txtDestinatario.Text = oBE_DIRECCION.DESCRIPCION;
                //cargar atención de destinatario
                this.CargarDropDownList(ddlAtencion, "ID", "ATENCION", BL_DIRECCION.SeleccionarDireccionesAtencionPorDestinatario(oBE_DIRECCION.ID), 3);
                txtOtroDestinatario.Visible = false;
                lblOtroDestinatario.Visible = false;

            }
            else if (ddlDireccionDestinatario.SelectedValue == "-")
            {
                txtOtroDestinatario.Visible = false;
                lblOtroDestinatario.Visible = false;
                txtOtroDestinatario.Text = String.Empty;
                ddlAtencion.ClearSelection();                  
                ddlAtencion.SelectedValue = "-";                
                txtDestinatario.Text = String.Empty;
                ddlAtencion_SelectedIndexChanged(sender, e);
            }
            else if (ddlDireccionDestinatario.SelectedValue == "0")
            {
                txtOtroDestinatario.Visible = true;
                lblOtroDestinatario.Visible = true;
                txtOtroDestinatario.Text = String.Empty;
                if (ddlAtencion.Items.Count == 0)
                {
                    ddlAtencion.Items.Insert(0, new RadComboBoxItem("SELECCIONAR...", "-"));
                    ddlAtencion.Items.Insert(1, new RadComboBoxItem("OTRO...", "0"));  
                }
                ddlAtencion.ClearSelection();
                ddlAtencion.SelectedValue = "0";
                txtDestinatario.Text = String.Empty;
                ddlAtencion_SelectedIndexChanged(sender, e);
            }
            else if (ddlDireccionDestinatario.SelectedValue == "")
            {
                txtOtroDestinatario.Visible = false;
                lblOtroDestinatario.Visible = false;
                txtOtroDestinatario.Text = String.Empty;
                ddlAtencion.ClearSelection();
                ddlAtencion.SelectedValue = "-";
                txtDestinatario.Text = String.Empty;
                ddlDireccionDestinatario.SelectedValue = "-";
            }
        }

        protected void ddlDireccionRemitente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSolicitud = String.Empty;

            DropDownList ddlTipoSolicitud = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlTipoSolicitud");

            if (ddlTipoSolicitud.SelectedValue.ToString() == "1")
            {
                tipoSolicitud = "DatosEnvioNacional";

            }
            else if (ddlTipoSolicitud.SelectedValue.ToString() == "2")
            {
                tipoSolicitud = "DatosEnvioInternacional";

            }

            //txtDireccionRemitente = Dirección Remitente y ddlDireccionRemitente = Sede Remitente
            Label lblOtroRemitente = (Label)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("lblOtroRemitente");
            TextBox txtOtroRemitente = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtOtroRemitente");
            TextBox txtDireccionRemitente = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtDireccionRemitente");
            DropDownList ddlDireccionRemitente = (DropDownList)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("ddlDireccionRemitente");
            

            if (ddlDireccionRemitente.SelectedValue != "0" && ddlDireccionRemitente.SelectedValue != "-")
            {
                BE_DIRECCION oBE_DIRECCION = BL_DIRECCION.SeleccionarDireccionPorId(Guid.Parse(ddlDireccionRemitente.SelectedValue));

                txtDireccionRemitente.Text = oBE_DIRECCION.DESCRIPCION;                
                txtOtroRemitente.Visible = false;
                lblOtroRemitente.Visible = false;

            }
            else if (ddlDireccionRemitente.SelectedValue == "-")
            {
                txtOtroRemitente.Visible = false;
                lblOtroRemitente.Visible = false;
                txtOtroRemitente.Text = String.Empty;                
                txtDireccionRemitente.Text = String.Empty;
            }
            else
            {
                txtOtroRemitente.Visible = true;
                lblOtroRemitente.Visible = true;
                txtOtroRemitente.Text = String.Empty;                
                txtDireccionRemitente.Text = String.Empty;
            }
        }

        protected void ddlAtencion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSolicitud = String.Empty;

            DropDownList ddlTipoSolicitud = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlTipoSolicitud");

            if (ddlTipoSolicitud.SelectedValue.ToString() == "1")
            {
                tipoSolicitud = "DatosEnvioNacional";

            }
            else if (ddlTipoSolicitud.SelectedValue.ToString() == "2")
            {
                tipoSolicitud = "DatosEnvioInternacional";

            }
           
            Label lblOtraAtencion = (Label)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("lblOtraAtencion");
            TextBox txtOtraAtencion = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtOtraAtencion");
            RadComboBox ddlAtencion = (RadComboBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("ddlAtencion");

            if (ddlAtencion.SelectedValue != "0" && ddlAtencion.SelectedValue != "-" && ddlAtencion.SelectedValue!="")
            {                
                txtOtraAtencion.Visible = false;
                lblOtraAtencion.Visible = false;

            }
            else if (ddlAtencion.SelectedValue == "-")
            {
                txtOtraAtencion.Visible = false;
                lblOtraAtencion.Visible = false;
                txtOtraAtencion.Text = String.Empty;                
            }
            else if (ddlAtencion.SelectedValue == "0")
            {
                txtOtraAtencion.Visible = true;
                lblOtraAtencion.Visible = true;
                txtOtraAtencion.Text = String.Empty;                
            }
            else if (ddlAtencion.SelectedValue == "")
            {
                txtOtraAtencion.Visible = false;
                lblOtraAtencion.Visible = false;
                txtOtraAtencion.Text = String.Empty;
                ddlAtencion.SelectedValue = "-";
            }

        }

        protected void CargarTipoSolicitud(int isEdit)
        {

            DropDownList ddlTipoSolicitud = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlTipoSolicitud");
            int selectedIndex = rpbSolicitud.SelectedItem.Index;

            //Validamos si el envío es nacional o internacional 1=Nacional, 2=Internacional
            if (ddlTipoSolicitud.SelectedValue.ToString() == "1") //Datos de Envíos Nacionales
            {
                rpbSolicitud.Items[selectedIndex + 1].Visible = true;
                rpbSolicitud.Items[selectedIndex + 2].Visible = false;
                if (isEdit == 1)
                {
                    rpbSolicitud.Items[selectedIndex + 1].Enabled = true;
                    if ((Convert.ToInt32(hdfSolicitudEstado.Value) == (int)BE_SOLICITUD.SOLICITUD_ESTADO.Aprobada) || (Convert.ToInt32(hdfSolicitudEstado.Value) == (int)BE_SOLICITUD.SOLICITUD_ESTADO.Cerrada))
                    {
                        rpbSolicitud.Items[selectedIndex + 3].Enabled = true;
                        rpbSolicitud.Items[selectedIndex + 3].Visible = true;
                    }
                }
                else
                {
                   
                    LoadDatosEnvioNacional();
                }
            }
            else //Datos de Envíos Internacionales
            {
                rpbSolicitud.Items[selectedIndex + 1].Visible = false;
                rpbSolicitud.Items[selectedIndex + 2].Visible = true;
                if (isEdit == 1)
                {
                    rpbSolicitud.Items[selectedIndex + 2].Enabled = true;
                    if ((Convert.ToInt32(hdfSolicitudEstado.Value) == (int)BE_SOLICITUD.SOLICITUD_ESTADO.Aprobada) || (Convert.ToInt32(hdfSolicitudEstado.Value) == (int)BE_SOLICITUD.SOLICITUD_ESTADO.Cerrada))
                    {
                        rpbSolicitud.Items[selectedIndex + 3].Enabled = true;
                        rpbSolicitud.Items[selectedIndex + 3].Visible = true;
                    }
                }   
                else
                {
                     LoadDatosEnvioInternacional();
                }
            }

            LoadProveedor(Convert.ToInt32(ddlTipoSolicitud.SelectedValue));
            
        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGerencia(1);
            LoadArea(1);
            LoadAutorizador();
            LoadCentroCosto();
            LoadOrden();
            LoadCentroGestor();
        }


        protected void ddlGerencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadArea(1);
            LoadAutorizador();
            LoadCentroCosto();
            LoadOrden();
            LoadCentroGestor();
       
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCentroCosto();
            LoadOrden();
            LoadCentroGestor();
        }

        protected void LoadDatosEnvioNacional()
        {

            RadDatePicker rdpFechaEnvio = (RadDatePicker)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("rdpFechaEnvio");
            TextBox txtRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtRemitente");
            TextBox txtCosto = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtCosto");
            TextBox txtPeso = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtPeso");
            DropDownList ddlArea = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlArea");
            TextBox txtSolicitante = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtSolicitante");


            rdpFechaEnvio.SelectedDate = DateTime.Now.Date;
            if (ddlArea.SelectedValue != String.Empty)
                txtRemitente.Text = ddlArea.SelectedItem.Text.ToString() + " - " + txtSolicitante.Text.ToString();
            else
                txtRemitente.Text = txtSolicitante.Text.ToString();

            txtPeso.Text = "0.50";
            txtCosto.Text = "0.00";
            LoadDirecciones();

        }

        protected void LoadDatosEnvioInternacional()
        {

            RadDatePicker rdpFechaEnvio = (RadDatePicker)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("rdpFechaEnvio");
            TextBox txtRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtRemitente");
            TextBox txtCosto = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtCosto");
            TextBox txtPeso = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtPeso");
            DropDownList ddlArea = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlArea");
            TextBox txtSolicitante = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtSolicitante");


            rdpFechaEnvio.SelectedDate = DateTime.Now.Date;
            txtRemitente.Text = ddlArea.SelectedItem.Text.ToString() + " - " + txtSolicitante.Text.ToString();
            txtPeso.Text = "0.50";
            txtCosto.Text = "0.00";
            LoadDirecciones();

        }



        protected void LoadDirecciones()
        {
            BL_DIRECCION BL_DIRECCION = new BL_DIRECCION();
            BE_DIRECCION BE_DIRECCION = new BE_DIRECCION();
            
            DropDownList ddlTipoSolicitud = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlTipoSolicitud");

            //Validamos si el envío es nacional o internacional 1=Nacional, 2=Internacional
            if (ddlTipoSolicitud.SelectedValue.ToString() == "1")
            {
                DropDownList ddlDireccionRemitente = (DropDownList)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("ddlDireccionRemitente");
                RadComboBox ddlDireccionDestinatario = (RadComboBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("ddlDireccionDestinatario");

                ddlDireccionRemitente.ClearSelection();
                ddlDireccionDestinatario.ClearSelection();

                this.CargarDropDownList(ddlDireccionRemitente, "ID", "DESTINATARIO", BL_DIRECCION.SeleccionarDireccionesPorTipo((int)BE_DIRECCION.DIRECCION_TIPO_ENVIO.Nacional, (int)BE_DIRECCION.DIRECCION_TIPO.Remitente), 3);
                this.CargarDropDownList(ddlDireccionDestinatario, "ID", "DESTINATARIO", BL_DIRECCION.SeleccionarDireccionesPorTipo((int)BE_DIRECCION.DIRECCION_TIPO_ENVIO.Nacional, (int)BE_DIRECCION.DIRECCION_TIPO.Destinatario), 3);
                
            }
            else
            {
                DropDownList ddlDireccionRemitente = (DropDownList)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("ddlDireccionRemitente");
                RadComboBox ddlDireccionDestinatario = (RadComboBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("ddlDireccionDestinatario");
                this.CargarDropDownList(ddlDireccionRemitente, "ID", "DESTINATARIO", BL_DIRECCION.SeleccionarDireccionesPorTipo((int)BE_DIRECCION.DIRECCION_TIPO_ENVIO.Nacional, (int)BE_DIRECCION.DIRECCION_TIPO.Remitente), 3);
                this.CargarDropDownList(ddlDireccionDestinatario, "ID", "DESTINATARIO", BL_DIRECCION.SeleccionarDireccionesPorTipo((int)BE_DIRECCION.DIRECCION_TIPO_ENVIO.International, (int)BE_DIRECCION.DIRECCION_TIPO.Destinatario), 3);
                
            }   
        }       

        protected void CargarValoresSolicitud(Guid solicitudId)
        {
            BE_SOLICITUD oBE_SOLICITUD = BL_SOLICITUD.SeleccionarSolicitudPorId(solicitudId);
            string tipoSolicitud = String.Empty;
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
            
            hdfSolicitudEstado.Value = oBE_SOLICITUD.ESTADO.ToString();
            hdfCorrespondenciaId.Value = oBE_SOLICITUD.oBE_CORRESPONDENCIA.ID.ToString();
            hdfSolicitudCodigo.Value = oBE_SOLICITUD.CODIGO.ToString();

            if (oBE_SOLICITUD != null)
            { 
                //Inicializamos los controles
                Label lblNumeroSolicitud = (Label)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("lblNumeroSolicitud");
                TextBox txtNumeroSolicitud = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtNumeroSolicitud");
                DropDownList ddlPrioridad = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlPrioridad");
                DropDownList ddlTipoSolicitud = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlTipoSolicitud");
                RadDatePicker rdpFechaRegistro = (RadDatePicker)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("rdpFechaRegistro");
                DropDownList ddlEmpresa = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlEmpresa");
                DropDownList ddlGerencia = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlGerencia");
                DropDownList ddlArea = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlArea");
                DropDownList ddlCentroCosto = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCentroCosto");
                DropDownList ddlOrden = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlOrden");
                DropDownList ddlCentroGestor = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCentroGestor");
                DropDownList ddlCuentaMayor = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCuentaMayor");
                DropDownList ddlAutoriza = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlAutoriza");
                TextBox txtSolicitante = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtSolicitante");
                CheckBox chkSolicitarAprobacion = (CheckBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("chkSolicitarAprobacion");
                DropDownList ddlProveedor = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlProveedor");

                //Validamos si el envío es nacional o internacional 1=Nacional, 2=Internacional
                ddlTipoSolicitud.SelectedValue = oBE_SOLICITUD.TIPO.ToString();
                CargarTipoSolicitud(1);
                LoadEmpresa(1);
                LoadCuentaMayor();                
                LoadDirecciones();                

                if (ddlTipoSolicitud.SelectedValue.ToString() == "1")
                {
                    tipoSolicitud = "DatosEnvioNacional";

                }
                else if (ddlTipoSolicitud.SelectedValue.ToString() == "2")
                {
                     tipoSolicitud = "DatosEnvioInternacional";

                }

                TextBox txtOrdenCourier = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtOrdenCourier");
                RadDatePicker rdpFechaEnvio = (RadDatePicker)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("rdpFechaEnvio");
                TextBox txtRemitente = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtRemitente");
                
                DropDownList ddlTipoEnvio = (DropDownList)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("ddlTipoEnvio");
                DropDownList ddlCaracteristica = (DropDownList)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("ddlCaracteristica");
                TextBox txtCantidad = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtCantidad");
                TextBox txtCosto = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtCosto");
                TextBox txtPeso = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtPeso");
                TextBox txtContenido = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtContenido");
                TextBox txtGuia = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtGuia");

                //txtDireccionRemitente = Dirección Remitente y ddlDireccionDestinatario = Remitente Sede
                DropDownList ddlDireccionRemitente = (DropDownList)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("ddlDireccionRemitente");
                TextBox txtDireccionRemitente = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtDireccionRemitente");                
                
                //txtDestinatario = Dirección Destinatario y ddlDireccionDestinatario = Destinatario
                TextBox txtDestinatario = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtDestinatario");
                RadComboBox ddlDireccionDestinatario = (RadComboBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("ddlDireccionDestinatario");
                RadComboBox ddlAtencion = (RadComboBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("ddlAtencion");

                TextBox txtMedidas = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtMedidas");
                TextBox txtCostoDeclarar = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtCostoDeclarar");
                TextBox txtTelefono = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtTelefono");
                TextBox txtPais = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtPais");
                TextBox txtEstadoProvincia = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtEstadoProvincia");
                TextBox txtCiudad = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtCiudad");
                TextBox txtCodigoPostal = (TextBox)rpbSolicitud.FindItemByValue(tipoSolicitud).FindControl("txtCodigoPostal");

                //Llenamos los controles con los datos de la solicitud
                txtNumeroSolicitud.Text = oBE_SOLICITUD.CODIGO.ToString();
                ddlPrioridad.SelectedValue = oBE_SOLICITUD.PRIORIDAD.ToString();
                
                rdpFechaRegistro.SelectedDate = Convert.ToDateTime(oBE_SOLICITUD.FECHA_REGISTRO).Date;
                
                ddlEmpresa.SelectedValue = oBE_SOLICITUD.EMPRESA_ID.ToString();

                LoadGerencia(1);

                ddlGerencia.SelectedValue = oBE_SOLICITUD.GERENCIA_ID.ToString();

                LoadAutorizador();

                LoadArea(1);

                ddlArea.SelectedValue = oBE_SOLICITUD.AREA_ID.ToString();

                LoadCentroCosto();
                LoadCentroGestor();
                LoadOrden();


                if (oBE_SOLICITUD.CENTRO_COSTO_ID == Guid.Empty)
                    ddlCentroCosto.SelectedValue = "-";
                else
                    ddlCentroCosto.SelectedValue = oBE_SOLICITUD.CENTRO_COSTO_ID.ToString();

                ddlCentroGestor.SelectedValue = oBE_SOLICITUD.CENTRO_GESTOR_ID.ToString();

                if (oBE_SOLICITUD.ORDEN_ID == Guid.Empty)
                    ddlOrden.SelectedValue = "-";
                else
                    ddlOrden.SelectedValue = oBE_SOLICITUD.ORDEN_ID.ToString();

              
                ddlCuentaMayor.SelectedValue = oBE_SOLICITUD.CUENTA_MAYOR_ID.ToString();
                ddlAutoriza.SelectedValue = oBE_SOLICITUD.AUTORIZADOR.ToString();

                txtSolicitante.Text = oBE_SOLICITUD.SOLICITANTE;
                chkSolicitarAprobacion.Checked = Convert.ToBoolean(oBE_SOLICITUD.REQUIERE_APROBACION);
                ddlProveedor.SelectedValue = oBE_SOLICITUD.oBE_CORRESPONDENCIA.PROVEEDOR_ID.ToString();
                txtOrdenCourier.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.ORDEN_PROVEEDOR;
                rdpFechaEnvio.SelectedDate = Convert.ToDateTime(oBE_SOLICITUD.oBE_CORRESPONDENCIA.FECHA_ENVIO).Date;
                txtRemitente.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.REMITENTE;
                
                ddlTipoEnvio.SelectedValue = oBE_SOLICITUD.oBE_CORRESPONDENCIA.TIPO.ToString();
                ddlCaracteristica.SelectedValue = oBE_SOLICITUD.oBE_CORRESPONDENCIA.CARACTERISTICA.ToString();
                txtCantidad.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.CANTIDAD.ToString();
                txtCosto.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.COSTO.ToString();
                txtPeso.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.PESO.ToString();
                txtContenido.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.CONTENIDO;

                //txtDireccionRemitente = Dirección Destinatario y ddlDireccionRemitente = Remitente Sede
                ddlDireccionRemitente.SelectedValue = oBE_SOLICITUD.oBE_CORRESPONDENCIA.DIRECCION_REMITENTE_ID.ToString();
                if (ddlDireccionRemitente.SelectedValue != "-")
                {
                    BE_DIRECCION oBE_DIRECCION_REMITENTE = BL_DIRECCION.SeleccionarDireccionPorId(Guid.Parse(ddlDireccionRemitente.SelectedValue));

                    txtDireccionRemitente.Text = oBE_DIRECCION_REMITENTE.DESCRIPCION;
                }
                else
                 {
                     txtDireccionRemitente.Text = String.Empty;
                 }



                //txtDestinatario = Dirección Destinatario y ddlDireccionDestinatario = Destinatario
                ddlDireccionDestinatario.SelectedValue = oBE_SOLICITUD.oBE_CORRESPONDENCIA.DIRECCION_DESTINATARIO_ID.ToString();
                if (ddlDireccionDestinatario.SelectedValue != "-")
                {
                    BE_DIRECCION oBE_DIRECCION = BL_DIRECCION.SeleccionarDireccionPorId(Guid.Parse(ddlDireccionDestinatario.SelectedValue));
                    txtDestinatario.Text = oBE_DIRECCION.DESCRIPCION;

                    //Cargar combo de atención y seleccionar atención
                    this.CargarDropDownList(ddlAtencion, "ID", "ATENCION", BL_DIRECCION.SeleccionarDireccionesAtencionPorDestinatario(Guid.Parse(ddlDireccionDestinatario.SelectedValue)), 3);

                    ddlAtencion.SelectedValue = oBE_SOLICITUD.oBE_CORRESPONDENCIA.ATENCION_ID.ToString();
                }
                else
                {
                    txtDestinatario.Text = String.Empty;
                    ddlAtencion.SelectedValue = "-";
                }              
                

                if (Int32.Parse(hdfSolicitudEstado.Value) == (int)BE_SOLICITUD.SOLICITUD_ESTADO.Aprobada)
                    chkSolicitarAprobacion.Checked = false;

                if (ddlTipoSolicitud.SelectedValue.ToString() == "1")
                {
                    //Cargar: "DatosEnvioNacional"
                    txtGuia.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.GUIA;

                }
                else if (ddlTipoSolicitud.SelectedValue.ToString() == "2")
                {
                    //Cargar: "DatosEnvioInternacional"
                    txtMedidas.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.MEDIDAS;
                    txtCostoDeclarar.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.COSTO_DECLARAR;
                    txtTelefono.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.TELEFONO;
                    txtPais.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.PAIS;
                    txtEstadoProvincia.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.ESTADO_PROVINCIA;
                    txtCiudad.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.CIUDAD;
                    txtCodigoPostal.Text = oBE_SOLICITUD.oBE_CORRESPONDENCIA.CODIGO_POSTAL;

                }

                //Validar el estado de la solicitud
                ValidarEstadoSolicitud(Convert.ToInt32(hdfSolicitudEstado.Value));
                
                //Habilitar Nro. Solicitud
                lblNumeroSolicitud.Visible = true;
                txtNumeroSolicitud.Visible = true;

                //Validar usuario que actualiza la solicitud sea el mismo que la creó
                ValidarActualizador(USUARIO, oBE_SOLICITUD.USUARIO_CREACION);
            }
        }
    

        private void GoToSiguienteItem()
        {
            int selectedIndex = rpbSolicitud.SelectedItem.Index;
            DropDownList ddlTipoSolicitud = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlTipoSolicitud");
           

            if (rpbSolicitud.Items.Count <= selectedIndex + 1)
            {
                selectedIndex = rpbSolicitud.Items.Count - 2;
            }
            if (ddlTipoSolicitud.SelectedValue.ToString() == "1")
            {
                rpbSolicitud.Items[selectedIndex + 1].Selected = true;
                rpbSolicitud.Items[selectedIndex + 1].Expanded = true;
                rpbSolicitud.Items[selectedIndex + 1].Enabled = true;
                rpbSolicitud.Items[selectedIndex].Expanded = false;
                
            }
            else
            {
                rpbSolicitud.Items[selectedIndex + 2].Selected = true;
                rpbSolicitud.Items[selectedIndex + 2].Expanded = true;
                rpbSolicitud.Items[selectedIndex + 2].Enabled = true;
                rpbSolicitud.Items[selectedIndex].Expanded = false;
               
            }   
                    
        }

        protected int ValidarDatosSolicitud()
        {
            //Validar DatosSolicitud
            DropDownList ddlTipoSolicitud = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlTipoSolicitud");
            RadDatePicker rdpFechaRegistro = (RadDatePicker)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("rdpFechaRegistro");
            DropDownList ddlEmpresa = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlEmpresa");
            DropDownList ddlGerencia = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlGerencia");
            DropDownList ddlArea = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlArea");
            DropDownList ddlCentroCosto = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCentroCosto");
            DropDownList ddlCentroGestor = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCentroGestor");
            DropDownList ddlOrden = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlOrden");
            TextBox txtOtroCentroCosto = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtOtroCentroCosto");
            TextBox txtOtraOrden = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtOtraOrden");
            TextBox txtOtroCentroGestor = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtOtroCentroGestor");
            TextBox txtSolicitante = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtSolicitante");
            DropDownList ddlAutoriza = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlAutoriza");
            lblMensaje.Text = String.Empty;
            string mensajeSolicitud = String.Empty;
            string mensajeEnvio = String.Empty;
            int esValida = 1;

            if (rdpFechaRegistro.SelectedDate.ToString() == String.Empty)
                mensajeSolicitud += "Fecha Registro - ";
            if (ddlEmpresa.SelectedValue.ToString() == String.Empty)
                mensajeSolicitud += "Empresa - ";
            if (ddlGerencia.SelectedValue.ToString() == String.Empty)
                mensajeSolicitud += "Gerencia - ";
            if (ddlArea.SelectedValue.ToString() == String.Empty)
                mensajeSolicitud += "Area - ";
            if (ddlCentroCosto.SelectedValue.ToString() == ddlOrden.SelectedValue.ToString())
                mensajeSolicitud += "Centro de Costo u Orden - ";
            if (ddlCentroCosto.SelectedValue.ToString() == "0" && txtOtroCentroCosto.Text == String.Empty)
                mensajeSolicitud += "Centro de Costo - ";
            if (ddlOrden.SelectedValue.ToString() == "0" && txtOtraOrden.Text == String.Empty)
                mensajeSolicitud += "Orden - ";
            if (ddlCentroGestor.SelectedValue.ToString() == "-")
                mensajeSolicitud += "Centro Gestor - ";
            if (ddlCentroGestor.SelectedValue.ToString() == "0" && txtOtroCentroGestor.Text == String.Empty)
                mensajeSolicitud += "Centro de Gestor - ";
            if (ddlAutoriza.SelectedValue.ToString() == String.Empty)
                mensajeSolicitud += "Autorizador - ";
            if (txtSolicitante.Text == string.Empty)
                mensajeSolicitud += "Solicitante.";

            if (mensajeSolicitud != String.Empty)
            {
                lblMensaje.Text = "Datos Solicitud, ingresar: " + mensajeSolicitud + ". ";
                esValida = 0;
            }

            if (ddlTipoSolicitud.SelectedValue.ToString() == "1")
            {
                //Validar Datos Envío Nacional
                TextBox txtOrdenCourier = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtOrdenCourier");                
                RadDatePicker rdpFechaEnvio = (RadDatePicker)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("rdpFechaEnvio");
                TextBox txtRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtRemitente");                
                DropDownList ddlDireccionRemitente = (DropDownList)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("ddlDireccionRemitente");
                TextBox txtDireccionRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtDireccionRemitente");
                TextBox txtCantidad = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtCantidad");
                TextBox txtCosto = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtCosto");
                TextBox txtPeso = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtPeso");
                TextBox txtContenido = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtContenido");
                TextBox txtDestinatario = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtDestinatario");
                RadComboBox ddlDireccionDestinatario = (RadComboBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("ddlDireccionDestinatario");
                RadComboBox ddlAtencion = (RadComboBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("ddlAtencion");
                TextBox txtOtraAtencion = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtOtraAtencion");


                if (txtOrdenCourier.Text == String.Empty)
                    mensajeEnvio += "Nro. Orden Courier - ";
                if (rdpFechaEnvio.SelectedDate.ToString() == String.Empty)
                    mensajeEnvio += "Fecha Envío - ";
                if (txtRemitente.Text == String.Empty)
                    mensajeEnvio += "Remitente - ";
                if (ddlDireccionRemitente.SelectedValue.ToString() == "-")
                    mensajeEnvio += "Dirección Sede Remitente - ";
                if (txtDireccionRemitente.Text.ToString() == "-")
                    mensajeEnvio += "Dirección Remitente - ";
                if (txtCantidad.Text == String.Empty)
                    mensajeEnvio += "Cantidad - ";
                if (txtCosto.Text == String.Empty)
                    mensajeEnvio += "Costo - ";
                if (txtPeso.Text == String.Empty)
                    mensajeEnvio += "Peso - ";
                if (txtContenido.Text == String.Empty)
                    mensajeEnvio += "Contenido - ";
                if (txtDestinatario.Text == String.Empty)
                    mensajeEnvio += "Dirección Destinatario - ";
                if (ddlDireccionDestinatario.SelectedValue.ToString() == "-" || ddlDireccionDestinatario.SelectedValue.ToString() == "")
                    mensajeEnvio += "Destinatario - ";
                if (ddlAtencion.SelectedValue.ToString() == "-" || ddlAtencion.SelectedValue.ToString() == "")
                    mensajeEnvio += "Destinatario Atención ";
                if (ddlAtencion.SelectedValue.ToString() == "0" && txtOtraAtencion.Text == "")
                    mensajeEnvio += "Destinatario Atención ";

                if (mensajeEnvio != String.Empty)
                {
                    lblMensaje.Text += "Datos de Envío, ingresar: " + mensajeEnvio + ". ";
                    esValida = 0;
                }              

            }
            else if (ddlTipoSolicitud.SelectedValue.ToString() == "2") 
            {
                //Validar Datos Envío Internacional
                TextBox txtOrdenCourier = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtOrdenCourier");   
                RadDatePicker rdpFechaEnvio = (RadDatePicker)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("rdpFechaEnvio");
                TextBox txtRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtRemitente");
                DropDownList ddlDireccionRemitente = (DropDownList)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("ddlDireccionRemitente");
                TextBox txtDireccionRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtDireccionRemitente");
                TextBox txtCantidad = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtCantidad");
                TextBox txtCosto = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtCosto");
                TextBox txtPeso = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtPeso");
                TextBox txtMedidas = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtMedidas");
                TextBox txtCostoDeclarar = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtCostoDeclarar");
                TextBox txtContenido = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtContenido");
                TextBox txtTelefono = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtTelefono");
                TextBox txtPais = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtPais");
                TextBox txtEstadoProvincia = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtEstadoProvincia");
                TextBox txtCiudad = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtCiudad");
                TextBox txtCodigoPostal = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtCodigoPostal");                
                TextBox txtDestinatario = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtDestinatario");
                RadComboBox ddlDireccionDestinatario = (RadComboBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("ddlDireccionDestinatario");
                RadComboBox ddlAtencion = (RadComboBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("ddlAtencion");
                TextBox txtOtraAtencion = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtOtraAtencion");

                if (txtOrdenCourier.Text == String.Empty)
                    mensajeEnvio += "Nro. Orden Courier - ";
                if (rdpFechaEnvio.SelectedDate.ToString() == String.Empty)
                    mensajeEnvio += "Fecha Envío - ";
                if (txtRemitente.Text == String.Empty)
                    mensajeEnvio += "Remitente - ";
                if (ddlDireccionRemitente.SelectedValue.ToString() == "-")
                    mensajeEnvio += "Dirección Sede Remitente - ";
                if (txtDireccionRemitente.Text.ToString() == "-")
                    mensajeEnvio += "Dirección Remitente - ";
                if (txtCantidad.Text == String.Empty)
                    mensajeEnvio += "Cantidad - ";
                if (txtCosto.Text == String.Empty)
                    mensajeEnvio += "Costo - ";
                if (txtPeso.Text == String.Empty)
                    mensajeEnvio += "Peso - ";               
                if (txtMedidas.Text == String.Empty)
                    mensajeEnvio += "Medidas - ";
                if (txtCostoDeclarar.Text == String.Empty)
                    mensajeEnvio += "Costo a Declarar - ";
                if (txtContenido.Text == String.Empty)
                    mensajeEnvio += "Contenido - ";
                if (txtTelefono.Text == String.Empty)
                    mensajeEnvio += "Teléfono - ";
                if (txtPais.Text == String.Empty)
                    mensajeEnvio += "País - ";
                if (txtEstadoProvincia.Text == String.Empty)
                    mensajeEnvio += "Estado o Provincia - ";
                if (txtCiudad.Text == String.Empty)
                    mensajeEnvio += "Ciudad - ";
                if (txtCodigoPostal.Text == String.Empty)
                    mensajeEnvio += "Código Postal - ";
                if (txtDestinatario.Text == String.Empty)
                    mensajeEnvio += "Dirección Destinatario - ";
                if (ddlDireccionDestinatario.SelectedValue.ToString() == "-")
                    mensajeEnvio += "Destinatario - ";
                if (ddlAtencion.SelectedValue.ToString() == "-")
                    mensajeEnvio += "Destinatario Atención ";
                if (ddlAtencion.SelectedValue.ToString() == "0" && txtOtraAtencion.Text == "")
                    mensajeEnvio += "Destinatario Atención ";

                if (mensajeEnvio != String.Empty)
                {
                    lblMensaje.Text += "Datos de Envío, ingresar: " + mensajeEnvio + ". ";
                    esValida = 0;
                }
                
            }
          
            return esValida;
           
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
                

                if (ValidarDatosSolicitud() == 1)
                {

                    BL_PERSONAL BL_PERSONAL = new BL_PERSONAL();
                    string emailAutorizador = string.Empty;
                
                    //Inicializamos controles
                    DropDownList ddlPrioridad = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlPrioridad");
                    DropDownList ddlTipoSolicitud = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlTipoSolicitud");
                    RadDatePicker rdpFechaRegistro = (RadDatePicker)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("rdpFechaRegistro");
                    DropDownList ddlEmpresa = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlEmpresa");
                    DropDownList ddlGerencia = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlGerencia");
                    DropDownList ddlArea = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlArea");
                    DropDownList ddlCentroCosto = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCentroCosto");
                    DropDownList ddlOrden = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlOrden");
                    DropDownList ddlCentroGestor = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCentroGestor");
                    TextBox txtOtroCentroCosto = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtOtroCentroCosto");
                    TextBox txtOtraOrden = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtOtraOrden");
                    TextBox txtOtroCentroGestor = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtOtroCentroGestor");
                    DropDownList ddlCuentaMayor = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlCuentaMayor");
                    DropDownList ddlAutoriza = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlAutoriza");
                    TextBox txtSolicitante = (TextBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("txtSolicitante");
                    CheckBox chkSolicitarAprobacion = (CheckBox)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("chkSolicitarAprobacion");
                    DropDownList ddlProveedor = (DropDownList)rpbSolicitud.FindItemByValue("DatosSolicitud").FindControl("ddlProveedor");

                    BE_SOLICITUD oBE_SOLICITUD = new BE_SOLICITUD();
                    BE_CORRESPONDENCIA oBE_CORRESPONDENCIA = new BE_CORRESPONDENCIA();
                    oBE_SOLICITUD.FECHA_REGISTRO = rdpFechaRegistro.SelectedDate.ToString();
                    oBE_SOLICITUD.EMPRESA_ID = Guid.Parse(ddlEmpresa.SelectedValue);
                    oBE_SOLICITUD.GERENCIA_ID = Guid.Parse(ddlGerencia.SelectedValue);
                    oBE_SOLICITUD.AREA_ID = Guid.Parse(ddlArea.SelectedValue);
                    oBE_SOLICITUD.PRIORIDAD = Int32.Parse(ddlPrioridad.SelectedValue);
                    oBE_SOLICITUD.TIPO = Int32.Parse(ddlTipoSolicitud.SelectedValue);

                    //Si centro de costo es Otro ("0") entonces se inserta un nuevo centro de costo sino se asigna el valor seleccionado en el combo
                    if (ddlCentroCosto.SelectedValue == "0")
                    {                        
                        BE_CENTRO_COSTO oBE_CENTRO_COSTO = new BE_CENTRO_COSTO();
                        Guid centroCostoId = Guid.Empty;

                        oBE_CENTRO_COSTO.ID = Guid.Empty;
                        oBE_CENTRO_COSTO.DESCRIPCION = txtOtroCentroCosto.Text;
                        oBE_CENTRO_COSTO.CODIGO = txtOtroCentroCosto.Text;
                        oBE_CENTRO_COSTO.EMPRESA_ID = Guid.Parse(ddlEmpresa.SelectedValue);
                        oBE_CENTRO_COSTO.GERENCIA_ID = Guid.Parse(ddlGerencia.SelectedValue);
                        oBE_CENTRO_COSTO.AREA_ID = Guid.Parse(ddlArea.SelectedValue);
                        oBE_CENTRO_COSTO.USUARIO_CREACION = USUARIO;
                        oBE_CENTRO_COSTO.ESTADO = 1;

                        centroCostoId = BL_CENTRO_COSTO.InsertarCentroCosto(oBE_CENTRO_COSTO);

                        if (centroCostoId != Guid.Empty)
                        {
                            oBE_SOLICITUD.CENTRO_COSTO_ID = centroCostoId;
                        }
                        else
                        {
                            lblMensaje.Text = "Error al registrar nuevo centro de costo.";
                            return;
                        }

                    }
                    else
                    {
                        oBE_SOLICITUD.CENTRO_COSTO_ID = ddlCentroCosto.SelectedValue.ToString().Equals("-") ? Guid.Empty : Guid.Parse(ddlCentroCosto.SelectedValue);
                    }

                    //Si Orden es Otro ("0") entonces se inserta un nueva Orden sino se asigna el valor seleccionado en el combo
                    if (ddlOrden.SelectedValue == "0")
                    {
                        BE_ORDEN oBE_ORDEN = new BE_ORDEN();
                        Guid ordenId = Guid.Empty;

                        oBE_ORDEN.ID = Guid.Empty;
                        oBE_ORDEN.DESCRIPCION = txtOtraOrden.Text;
                        oBE_ORDEN.CODIGO = txtOtraOrden.Text;
                        oBE_ORDEN.EMPRESA_ID = Guid.Parse(ddlEmpresa.SelectedValue);
                        oBE_ORDEN.GERENCIA_ID = Guid.Parse(ddlGerencia.SelectedValue);
                        oBE_ORDEN.AREA_ID = Guid.Parse(ddlArea.SelectedValue);
                        oBE_ORDEN.USUARIO_CREACION = USUARIO;
                        oBE_ORDEN.ESTADO = 1;

                        ordenId = BL_ORDEN.InsertarOrden(oBE_ORDEN);

                        if (ordenId != Guid.Empty)
                        {
                            oBE_SOLICITUD.ORDEN_ID = ordenId;
                        }
                        else
                        {
                            lblMensaje.Text = "Error al registrar nueva orden.";
                            return;
                        }

                    }
                    else
                    {
                        oBE_SOLICITUD.ORDEN_ID = ddlOrden.SelectedValue.ToString().Equals("-") ? Guid.Empty : Guid.Parse(ddlOrden.SelectedValue);
                    }

                    //Si centro de gestor es Otro ("0") entonces se inserta un nuevo centro gestor sino se asigna el valor seleccionado en el combo
                    if (ddlCentroGestor.SelectedValue == "0")
                    {
                        BE_CENTRO_GESTOR oBE_CENTRO_GESTOR = new BE_CENTRO_GESTOR();
                        Guid centroGestorId = Guid.Empty;

                        oBE_CENTRO_GESTOR.ID = Guid.Empty;
                        oBE_CENTRO_GESTOR.DESCRIPCION = txtOtroCentroGestor.Text;
                        oBE_CENTRO_GESTOR.CODIGO = txtOtroCentroGestor.Text;
                        oBE_CENTRO_GESTOR.EMPRESA_ID = Guid.Parse(ddlEmpresa.SelectedValue);
                        oBE_CENTRO_GESTOR.GERENCIA_ID = Guid.Parse(ddlGerencia.SelectedValue);
                        oBE_CENTRO_GESTOR.AREA_ID = Guid.Parse(ddlArea.SelectedValue);
                        oBE_CENTRO_GESTOR.USUARIO_CREACION = USUARIO;
                        oBE_CENTRO_GESTOR.ESTADO = 1;

                        centroGestorId = BL_CENTRO_GESTOR.InsertarCentroGestor(oBE_CENTRO_GESTOR);

                        if (centroGestorId != Guid.Empty)
                        {
                            oBE_SOLICITUD.CENTRO_GESTOR_ID = centroGestorId;
                        }
                        else
                        {
                            lblMensaje.Text = "Error al registrar nuevo centro de costo.";
                            return;
                        }

                    }
                    else
                    {                        
                        oBE_SOLICITUD.CENTRO_GESTOR_ID = Guid.Parse(ddlCentroGestor.SelectedValue);
                    }

                    oBE_SOLICITUD.CUENTA_MAYOR_ID = Guid.Parse(ddlCuentaMayor.SelectedValue);
                    oBE_SOLICITUD.AUTORIZADOR = Guid.Parse(ddlAutoriza.SelectedValue);
                    oBE_SOLICITUD.REQUIERE_APROBACION =Convert.ToInt32(chkSolicitarAprobacion.Checked);
                    oBE_SOLICITUD.SOLICITANTE = txtSolicitante.Text;
                    oBE_SOLICITUD.USUARIO_CREACION = USUARIO;

                    if (chkSolicitarAprobacion.Checked)
                    {
                        oBE_SOLICITUD.ESTADO = (int)BE_SOLICITUD.SOLICITUD_ESTADO.PendienteAprobacion;
                    }
                    else
                    {
                        oBE_SOLICITUD.ESTADO = (int)BE_SOLICITUD.SOLICITUD_ESTADO.Aprobada;
                    }

                    oBE_CORRESPONDENCIA.ESTADO = oBE_SOLICITUD.ESTADO;
                    oBE_SOLICITUD.oBE_CORRESPONDENCIA = oBE_CORRESPONDENCIA;
                    oBE_SOLICITUD.oBE_CORRESPONDENCIA.TIPO_ENVIO = Int32.Parse(ddlTipoSolicitud.SelectedValue);
                    oBE_SOLICITUD.oBE_CORRESPONDENCIA.PROVEEDOR_ID = Guid.Parse(ddlProveedor.SelectedValue);

                    if (ddlTipoSolicitud.SelectedValue.ToString() == "1")
                    {
                        //Datos Envío Nacional
                        TextBox txtOrdenCourier = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtOrdenCourier");
                        RadDatePicker rdpFechaEnvio = (RadDatePicker)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("rdpFechaEnvio");
                        TextBox txtRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtRemitente");
                        
                        DropDownList ddlTipoEnvio = (DropDownList)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("ddlTipoEnvio");
                        DropDownList ddlCaracteristica = (DropDownList)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("ddlCaracteristica");
                        TextBox txtCantidad = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtCantidad");
                        TextBox txtCosto = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtCosto");
                        TextBox txtPeso = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtPeso");
                        TextBox txtContenido = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtContenido");
                        TextBox txtGuia = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtGuia");

                        //txtDireccionRemitente = Dirección Remitente y ddlDireccionDestinatario = Remitente Sede
                        TextBox txtDireccionRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtDireccionRemitente");
                        TextBox txtOtroRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtOtroRemitente");
                        DropDownList ddlDireccionRemitente = (DropDownList)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("ddlDireccionRemitente");
                        TextBox txtAtencionRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtAtencionRemitente");
                        
                        //txtDestinatario = Dirección Destinatario y ddlDireccionDestinatario = Destinatario
                        TextBox txtDestinatario = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtDestinatario");
                        TextBox txtOtroDestinatario = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtOtroDestinatario");
                        RadComboBox ddlDireccionDestinatario = (RadComboBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("ddlDireccionDestinatario");
                        RadComboBox ddlAtencion = (RadComboBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("ddlAtencion");
                        TextBox txtOtraAtencion = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioNacional").FindControl("txtOtraAtencion");

                        //Se asignan valores de direccion remitente si "otro" se inserta nueva direccion sino se envian valores de remitente seleccionado
                        if (ddlDireccionRemitente.SelectedValue == "0")
                        {
                            BE_DIRECCION oBE_DIRECCION = new BE_DIRECCION();
                            Guid direccionId = Guid.Empty;

                            oBE_DIRECCION.ID = Guid.Empty;
                            oBE_DIRECCION.DESCRIPCION = txtDireccionRemitente.Text;
                            oBE_DIRECCION.TIPO_ENVIO = Int32.Parse(ddlTipoSolicitud.SelectedValue);
                            oBE_DIRECCION.TIPO = (int)BE_DIRECCION.DIRECCION_TIPO.Remitente;
                            oBE_DIRECCION.DESTINATARIO = txtOtroRemitente.Text;
                            oBE_DIRECCION.ATENCION = String.Empty;
                            oBE_DIRECCION.USUARIO_CREACION = USUARIO;
                            oBE_DIRECCION.ESTADO = 1;

                            direccionId = BL_DIRECCION.InsertarDireccion(oBE_DIRECCION);

                            if (direccionId != Guid.Empty)
                            {

                                oBE_SOLICITUD.oBE_CORRESPONDENCIA.DIRECCION_REMITENTE_ID = direccionId;
                            }
                            else
                            {
                                lblMensaje.Text = "Error al registrar nueva sede de remitente.";
                                return;
                            }
                        }
                        else
                        {
                            oBE_SOLICITUD.oBE_CORRESPONDENCIA.DIRECCION_REMITENTE_ID = Guid.Parse(ddlDireccionRemitente.SelectedValue);                            
                        }

                        //Se asignan valores de direccion destinatario si "otro" se inserta nueva direccion sino se envian valores de destinatario seleccionado
                        if (ddlDireccionDestinatario.SelectedValue == "0")
                        {
                            BE_DIRECCION oBE_DIRECCION = new BE_DIRECCION();
                            Guid direccionId = Guid.Empty;

                            oBE_DIRECCION.ID = Guid.Empty;
                            oBE_DIRECCION.DESCRIPCION = txtDestinatario.Text;
                            oBE_DIRECCION.TIPO_ENVIO = Int32.Parse(ddlTipoSolicitud.SelectedValue);
                            oBE_DIRECCION.TIPO = (int)BE_DIRECCION.DIRECCION_TIPO.Destinatario;
                            oBE_DIRECCION.DESTINATARIO = txtOtroDestinatario.Text;
                            oBE_DIRECCION.ATENCION = ddlAtencion.SelectedItem.Text;
                            oBE_DIRECCION.USUARIO_CREACION = USUARIO;
                            oBE_DIRECCION.ESTADO = 1;

                            direccionId = BL_DIRECCION.InsertarDireccion(oBE_DIRECCION);

                            if (direccionId != Guid.Empty)
                            {
                                oBE_SOLICITUD.oBE_CORRESPONDENCIA.DESTINATARIO = txtOtroDestinatario.Text;
                                //oBE_SOLICITUD.oBE_CORRESPONDENCIA.ATENCION = txtAtencion.Text;
                                oBE_SOLICITUD.oBE_CORRESPONDENCIA.DIRECCION_DESTINATARIO_ID = direccionId;
                            }
                            else
                            {
                                lblMensaje.Text = "Error al registrar nuevo destinatario.";
                                return;
                            }
                        }
                        else
                        {
                            oBE_SOLICITUD.oBE_CORRESPONDENCIA.DESTINATARIO = ddlDireccionDestinatario.SelectedItem.Text;                            
                            oBE_SOLICITUD.oBE_CORRESPONDENCIA.DIRECCION_DESTINATARIO_ID = Guid.Parse(ddlDireccionDestinatario.SelectedValue);
                        }

                        //Se asignan valores de destinatario atención si "otro" se inserta nueva atención sino se envian valores de destinatario atención seleccionado
                        if (ddlAtencion.SelectedValue == "0")
                        {
                            BE_DIRECCION_ATENCION oBE_DIRECCION_ATENCION = new BE_DIRECCION_ATENCION();
                            Guid direccion_atencion_Id = Guid.Empty;

                            oBE_DIRECCION_ATENCION.ID = Guid.Empty;
                            oBE_DIRECCION_ATENCION.DIRECCION_ID = oBE_SOLICITUD.oBE_CORRESPONDENCIA.DIRECCION_DESTINATARIO_ID;
                            oBE_DIRECCION_ATENCION.DESTINATARIO = oBE_SOLICITUD.oBE_CORRESPONDENCIA.DESTINATARIO;
                            oBE_DIRECCION_ATENCION.ATENCION = txtOtraAtencion.Text;
                            oBE_DIRECCION_ATENCION.USUARIO_CREACION = USUARIO;
                            oBE_DIRECCION_ATENCION.ESTADO = 1;

                            direccion_atencion_Id = BL_DIRECCION.InsertarDireccionAtencion(oBE_DIRECCION_ATENCION);

                            if (direccion_atencion_Id != Guid.Empty)
                            {
                                oBE_SOLICITUD.oBE_CORRESPONDENCIA.ATENCION = txtOtraAtencion.Text;
                                oBE_SOLICITUD.oBE_CORRESPONDENCIA.ATENCION_ID = direccion_atencion_Id;
                            }
                            else
                            {
                                lblMensaje.Text = "Error al registrar nueva atención de destinatario.";
                                return;
                            }
                        }
                        else
                        {
                            oBE_SOLICITUD.oBE_CORRESPONDENCIA.ATENCION = ddlAtencion.SelectedItem.Text;                            
                            oBE_SOLICITUD.oBE_CORRESPONDENCIA.ATENCION_ID = Guid.Parse(ddlAtencion.SelectedValue);
                        }

                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.TIPO = Int32.Parse(ddlTipoEnvio.SelectedValue);
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.CARACTERISTICA = Int32.Parse(ddlCaracteristica.SelectedValue);
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.ORDEN_PROVEEDOR = txtOrdenCourier.Text;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.FECHA_ENVIO = rdpFechaEnvio.SelectedDate.ToString();
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.REMITENTE = txtRemitente.Text;                        
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.CANTIDAD = Decimal.Parse(txtCantidad.Text);
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.PESO = Decimal.Parse(txtPeso.Text);
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.COSTO = Decimal.Parse(txtCosto.Text);
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.CONTENIDO = txtContenido.Text;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.GUIA = txtGuia.Text.ToString();                       
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.MEDIDAS = String.Empty;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.COSTO_DECLARAR = "0.00";
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.TELEFONO = String.Empty;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.PAIS = String.Empty;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.ESTADO_PROVINCIA = String.Empty;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.CIUDAD = String.Empty;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.CODIGO_POSTAL = String.Empty;

                    }
                    else if (ddlTipoSolicitud.SelectedValue.ToString() == "2")
                    {
                        //Datos Envío Internacional
                        TextBox txtOrdenCourier = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtOrdenCourier");
                        RadDatePicker rdpFechaEnvio = (RadDatePicker)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("rdpFechaEnvio");
                        TextBox txtRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtRemitente");                        
                        DropDownList ddlTipoEnvio = (DropDownList)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("ddlTipoEnvio");
                        DropDownList ddlCaracteristica = (DropDownList)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("ddlCaracteristica");
                        TextBox txtCantidad = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtCantidad");
                        TextBox txtCosto = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtCosto");
                        TextBox txtPeso = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtPeso");
                        TextBox txtMedidas = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtMedidas");
                        TextBox txtCostoDeclarar = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtCostoDeclarar");
                        TextBox txtContenido = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtContenido");
                        TextBox txtTelefono = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtTelefono");
                        TextBox txtPais = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtPais");
                        TextBox txtEstadoProvincia = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtEstadoProvincia");
                        TextBox txtCiudad = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtCiudad");
                        TextBox txtCodigoPostal = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtCodigoPostal");

                        //txtDireccionRemitente = Dirección Remitente y ddlDireccionRemitente = Sede Remitente
                        DropDownList ddlDireccionRemitente = (DropDownList)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("ddlDireccionRemitente");
                        TextBox txtDireccionRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtDireccionRemitente");
                        TextBox txtOtroRemitente = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtOtroRemitente");                        

                        //txtDestinatario = Dirección Destinatario y ddlDireccionDestinatario = Destinatario
                        TextBox txtDestinatario = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtDestinatario");
                        TextBox txtOtroDestinatario = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtOtroDestinatario");
                        RadComboBox ddlDireccionDestinatario = (RadComboBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("ddlDireccionDestinatario");
                        RadComboBox ddlAtencion = (RadComboBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("ddlAtencion");
                        TextBox txtOtraAtencion = (TextBox)rpbSolicitud.FindItemByValue("DatosEnvioInternacional").FindControl("txtOtraAtencion");

                        //Se asignan valores de direccion remitente si "otro" se inserta nueva direccion sino se envian valores de remitente seleccionado
                        if (ddlDireccionRemitente.SelectedValue == "0")
                        {
                            BE_DIRECCION oBE_DIRECCION = new BE_DIRECCION();
                            Guid direccionId = Guid.Empty;

                            oBE_DIRECCION.ID = Guid.Empty;
                            oBE_DIRECCION.DESCRIPCION = txtDireccionRemitente.Text;
                            oBE_DIRECCION.TIPO_ENVIO = Int32.Parse(ddlTipoSolicitud.SelectedValue);
                            oBE_DIRECCION.TIPO = (int)BE_DIRECCION.DIRECCION_TIPO.Remitente;
                            oBE_DIRECCION.DESTINATARIO = txtOtroRemitente.Text;
                            oBE_DIRECCION.ATENCION = String.Empty;
                            oBE_DIRECCION.USUARIO_CREACION = USUARIO;
                            oBE_DIRECCION.ESTADO = 1;

                            direccionId = BL_DIRECCION.InsertarDireccion(oBE_DIRECCION);

                            if (direccionId != Guid.Empty)
                            {

                                oBE_SOLICITUD.oBE_CORRESPONDENCIA.DIRECCION_REMITENTE_ID = direccionId;
                            }
                            else
                            {
                                lblMensaje.Text = "Error al registrar nueva sede de remitente.";
                                return;
                            }
                        }
                        else
                        {
                            oBE_SOLICITUD.oBE_CORRESPONDENCIA.DIRECCION_REMITENTE_ID = Guid.Parse(ddlDireccionRemitente.SelectedValue);
                        }
                        
                        
                        //Se asignan valores de direccion destinatario si "otro" se inserta nueva direccion sino se envian valores de destinatario seleccionado
                        if (ddlDireccionDestinatario.SelectedValue == "0")
                        {
                            BE_DIRECCION oBE_DIRECCION = new BE_DIRECCION();
                            Guid direccionId = Guid.Empty;

                            oBE_DIRECCION.ID = Guid.Empty;
                            oBE_DIRECCION.DESCRIPCION = txtDestinatario.Text;
                            oBE_DIRECCION.TIPO_ENVIO = Int32.Parse(ddlTipoSolicitud.SelectedValue);
                            oBE_DIRECCION.TIPO = (int)BE_DIRECCION.DIRECCION_TIPO.Destinatario;
                            oBE_DIRECCION.DESTINATARIO = txtOtroDestinatario.Text;
                            oBE_DIRECCION.ATENCION = ddlAtencion.SelectedItem.Text;
                            oBE_DIRECCION.USUARIO_CREACION = USUARIO;
                            oBE_DIRECCION.ESTADO = 1;

                            direccionId = BL_DIRECCION.InsertarDireccion(oBE_DIRECCION);

                            if (direccionId != Guid.Empty)
                            {
                                oBE_SOLICITUD.oBE_CORRESPONDENCIA.DESTINATARIO = txtOtroDestinatario.Text;                                
                                oBE_SOLICITUD.oBE_CORRESPONDENCIA.DIRECCION_DESTINATARIO_ID = direccionId;
                            }
                            else
                            {
                                lblMensaje.Text = "Error al registrar nuevo destinatario.";
                                return;
                            }
                        }
                        else
                        {
                            oBE_SOLICITUD.oBE_CORRESPONDENCIA.DESTINATARIO = ddlDireccionDestinatario.SelectedItem.Text;                           
                            oBE_SOLICITUD.oBE_CORRESPONDENCIA.DIRECCION_DESTINATARIO_ID = Guid.Parse(ddlDireccionDestinatario.SelectedValue);
                        }

                        //Se asignan valores de destinatario atención si "otro" se inserta nueva atención sino se envian valores de destinatario atención seleccionado
                        if (ddlAtencion.SelectedValue == "0")
                        {
                            BE_DIRECCION_ATENCION oBE_DIRECCION_ATENCION = new BE_DIRECCION_ATENCION();
                            Guid direccion_atencion_Id = Guid.Empty;

                            oBE_DIRECCION_ATENCION.ID = Guid.Empty;
                            oBE_DIRECCION_ATENCION.DIRECCION_ID = oBE_SOLICITUD.oBE_CORRESPONDENCIA.DIRECCION_DESTINATARIO_ID;
                            oBE_DIRECCION_ATENCION.DESTINATARIO = oBE_SOLICITUD.oBE_CORRESPONDENCIA.DESTINATARIO;
                            oBE_DIRECCION_ATENCION.ATENCION = txtOtraAtencion.Text;
                            oBE_DIRECCION_ATENCION.USUARIO_CREACION = USUARIO;
                            oBE_DIRECCION_ATENCION.ESTADO = 1;

                            direccion_atencion_Id = BL_DIRECCION.InsertarDireccionAtencion(oBE_DIRECCION_ATENCION);

                            if (direccion_atencion_Id != Guid.Empty)
                            {
                                oBE_SOLICITUD.oBE_CORRESPONDENCIA.ATENCION = txtOtraAtencion.Text;
                                oBE_SOLICITUD.oBE_CORRESPONDENCIA.ATENCION_ID = direccion_atencion_Id;
                            }
                            else
                            {
                                lblMensaje.Text = "Error al registrar nueva atención de destinatario.";
                                return;
                            }
                        }
                        else
                        {
                            oBE_SOLICITUD.oBE_CORRESPONDENCIA.ATENCION = ddlAtencion.SelectedItem.Text;
                            oBE_SOLICITUD.oBE_CORRESPONDENCIA.ATENCION_ID = Guid.Parse(ddlAtencion.SelectedValue);
                        }

                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.TIPO = Int32.Parse(ddlTipoEnvio.SelectedValue);
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.CARACTERISTICA = Int32.Parse(ddlCaracteristica.SelectedValue);                    
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.ORDEN_PROVEEDOR = txtOrdenCourier.Text;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.FECHA_ENVIO = rdpFechaEnvio.SelectedDate.ToString();
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.REMITENTE = txtRemitente.Text;                        
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.CANTIDAD = Decimal.Parse(txtCantidad.Text);
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.PESO = Decimal.Parse(txtPeso.Text);
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.COSTO = Decimal.Parse(txtCosto.Text);
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.CONTENIDO = txtContenido.Text;                        
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.MEDIDAS = txtMedidas.Text;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.COSTO_DECLARAR = txtCostoDeclarar.Text;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.TELEFONO = txtTelefono.Text;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.PAIS = txtPais.Text;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.ESTADO_PROVINCIA = txtEstadoProvincia.Text;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.CIUDAD = txtCiudad.Text;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.CODIGO_POSTAL = txtCodigoPostal.Text;
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.GUIA = String.Empty;

                    }   
                    if (hdfSolicitudId.Value.Equals(String.Empty))
                    {
                        //Insertar Solicitud
                        Guid idSolicitudTmp = BL_SOLICITUD.InsertarSolicitud(oBE_SOLICITUD);
                        this.hdfSolicitudId.Value = idSolicitudTmp == Guid.Empty ? String.Empty : idSolicitudTmp.ToString();                        
                        

                        if (!hdfSolicitudId.Value.Equals(String.Empty))
                        { 
                            lblMensaje.Text = "La Solicitud se registró satisfactoriamente.";

                            int selectedIndex = rpbSolicitud.SelectedItem.Index;                        
                            rpbSolicitud.Items[0].Selected = true;
                            rpbSolicitud.Items[0].Expanded = true;
                            rpbSolicitud.Items[0].Enabled = true;
                            if (selectedIndex != 0)
                                rpbSolicitud.Items[selectedIndex].Expanded = false;
                            
                            this.hdfSolicitudEstado.Value = oBE_SOLICITUD.ESTADO.ToString();

                            if (hdfSolicitudEstado.Value == "1") // Pendiente de Aprobación
                            {
                                //Enviar solicitud de aprobacion por correo
                                //Obtener correo del autorizador
                                emailAutorizador = BL_PERSONAL.GetEmailAutorizador(oBE_SOLICITUD.AUTORIZADOR, oBE_SOLICITUD.GERENCIA_ID);
                                if (emailAutorizador != String.Empty)
                                {
                                    if (BL_SOLICITUD.SolicitarAprobacionSolicitud(Guid.Parse(hdfSolicitudId.Value), emailAutorizador))
                                        lblMensaje.Text += " Un correo fue enviado al autorizador para aprobar su solicitud.";
                                }
                                else
                                {
                                    lblMensaje.Text += " No se ha podido enviar correo al autorizador para aprobar su solicitud. Por favor contacte a su administrador para que asigne a su jefe una dirección de correo en el sistema.";
                                }

                            }
                            else if (hdfSolicitudEstado.Value == "2") // Aprobada
                            {
                                //Si la solicitud está aprobada mostramos botones y sección de documentos
                                btnCerrar.Visible = true;
                                btnGenerarEtiqueta.Visible = true;
                               
                                RadGrid rgDocumentos = (RadGrid)rpbSolicitud.FindItemByValue("Documentos").FindControl("rgDocumentos");
                                rgDocumentos.DataSource = String.Empty;
                                rgDocumentos.DataBind();

                                rpbSolicitud.Items[3].Enabled = true;
                                rpbSolicitud.Items[3].Visible = true;
                            }
                   
                        }
                        else
                        {
                            lblMensaje.Text = "Error al registar la Solicitud. Revisar la información registrada";                       

                        }

                        //End Insertar    
                    }
                    else
                    {
                        //Actualizar Solicitud
                        oBE_SOLICITUD.ID = Guid.Parse(hdfSolicitudId.Value);
                        //oBE_SOLICITUD.oBE_CORRESPONDENCIA.ID = Guid.Parse(hdfCorrespondenciaId.Value);
                        oBE_SOLICITUD.oBE_CORRESPONDENCIA.SOLICITUD_ID = oBE_SOLICITUD.ID;
                        if (BL_SOLICITUD.ActualizarSolicitud(oBE_SOLICITUD))
                        {
                            lblMensaje.Text = "La Solicitud se actualizó satisfactoriamente.";

                            if (hdfSolicitudEstado.Value == "1") // Pendiente de Aprobación
                            {
                                //Enviar solicitud de aprobacion por correo
                                //Obtener correo del autorizador
                                emailAutorizador = BL_PERSONAL.GetEmailAutorizador(oBE_SOLICITUD.AUTORIZADOR, oBE_SOLICITUD.GERENCIA_ID);
                                if (emailAutorizador != String.Empty)
                                {
                                    if (BL_SOLICITUD.SolicitarAprobacionSolicitud(Guid.Parse(hdfSolicitudId.Value), emailAutorizador))
                                        lblMensaje.Text += " Un correo fue enviado al autorizador para aprobar su solicitud.";
                                }
                                else
                                {
                                    lblMensaje.Text += " No se ha podido enviar correo al autorizador para aprobar su solicitud. Por favor contacte a su administrador para que asigne a su jefe una dirección de correo en el sistema.";
                                }                               

                            }

                            int selectedIndex = rpbSolicitud.SelectedItem.Index;
                            rpbSolicitud.Items[0].Selected = true;
                            rpbSolicitud.Items[0].Expanded = true;
                            rpbSolicitud.Items[0].Enabled = true;
                            if (selectedIndex != 0)
                                rpbSolicitud.Items[selectedIndex].Expanded = false;
                        }
                        else
                        {
                            lblMensaje.Text = "Error al actualizar la Solicitud. Revisar la información registrada";

                        }

                        //End Actualizar

                    }   
                }
            }        
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al Guardar Solicitud:" + ex.ToString();

            }
        }

        protected void cerrarButton_Click(object sender, EventArgs e)
        {
            try
            {
                USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
                if (BL_SOLICITUD.ActualizarEstadoSolicitud(Guid.Parse(hdfSolicitudId.Value), (int)BE_SOLICITUD.SOLICITUD_ESTADO.Cerrada, USUARIO, String.Empty))
                {
                    lblMensaje.Text = "La Solicitud se cerró satisfactoriamente.";
                    btnCerrar.Enabled = false;
                    btnGenerarEtiqueta.Enabled = false;
                    btnGuardar.Enabled = false;
                    RadGrid rgDocumentos = (RadGrid)rpbSolicitud.FindItemByValue("Documentos").FindControl("rgDocumentos");
                    rgDocumentos.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;                   
                    rgDocumentos.MasterTableView.GetColumn("EliminarDocumento").Display = false;
                }
                else
                {
                    lblMensaje.Text = "Error al cerrar la Solicitud. Revisar la información registrada";

                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al Cerrar Solicitud:" + ex.ToString();

            }
        }

        protected void generarSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdfSolicitudCodigo.Value == String.Empty)
                {
                    BE_SOLICITUD oBE_SOLICITUD = BL_SOLICITUD.SeleccionarSolicitudPorId(Guid.Parse(hdfSolicitudId.Value));

                    hdfSolicitudCodigo.Value = oBE_SOLICITUD.CODIGO.ToString();
                }

                string url = "../UI_REPORTES/Etiqueta.aspx?heSolicitudCodigo=" + hdfSolicitudCodigo.Value.ToString();
                string s = "window.open('" + url + "');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "script", s, true);

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al Generar Etiqueta:" + ex.ToString();

            }
        }


        protected void rgDocumentos_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {

                RadGrid rgDocumentos = (RadGrid)rpbSolicitud.FindItemByValue("Documentos").FindControl("rgDocumentos");

                ObjectDataSource ObjectDataSourceDocumentos = (ObjectDataSource)rpbSolicitud.FindItemByValue("Documentos").FindControl("ObjectDataSourceDocumentos");
                rgDocumentos.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = true;
                rgDocumentos.MasterTableView.NoMasterRecordsText = "No existen documentos registrados para la solicitud.";

                ObjectDataSourceDocumentos.SelectParameters.Clear();
                ObjectDataSourceDocumentos.SelectParameters.Add("solicitudId", this.hdfSolicitudId.Value);

                rgDocumentos.DataSource = ObjectDataSourceDocumentos;
                
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al Cargar Documentos:" + ex.ToString();

            }
        }


        protected string TrimDescripcion(string descripcion)
        {
            if (!string.IsNullOrEmpty(descripcion) && descripcion.Length > 200)
            {
                return string.Concat(descripcion.Substring(0, 200), "...");
            }
            return descripcion;
        }


        protected void rgDocumentos_InsertCommand(object source, GridCommandEventArgs e)
        {
             try
            {    
                GridEditFormInsertItem insertItem = e.Item as GridEditFormInsertItem;
                RadGrid rgDocumentos = (RadGrid)rpbSolicitud.FindItemByValue("Documentos").FindControl("rgDocumentos");

                USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
                string Nombre = (insertItem["NOMBRE"].FindControl("txtNombre") as RadTextBox).Text;
                string Descripcion = (insertItem["DESCRIPCION"].FindControl("txtDescripcion") as RadTextBox).Text;
                string Fecha = (insertItem["FECHA_REGISTRO"].FindControl("rdpFecha") as RadDatePicker).SelectedDate.ToString();
                RadAsyncUpload radAsyncUpload = insertItem["Upload"].FindControl("AsyncUpload1") as RadAsyncUpload;

                //Validar que se haya subido un archivo
                if (radAsyncUpload.UploadedFiles.Count > 0)  
                {
                    string path = Server.MapPath(ConfigurationManager.AppSettings["DocumentPath"].ToString());
                    UploadedFile file = radAsyncUpload.UploadedFiles[0]; 

                    if (file.ContentLength < MaxTotalBytes)
                    {
                        file.SaveAs(path + file.GetName(), true);            

                        //Insertar en tabla documentos
                        BE_DOCUMENTO oBE_DOCUMENTO = new BE_DOCUMENTO();
                        oBE_DOCUMENTO.ID = Guid.Empty;
                        oBE_DOCUMENTO.NOMBRE = Nombre;
                        oBE_DOCUMENTO.DESCRIPCION = Descripcion;
                        oBE_DOCUMENTO.FECHA_REGISTRO = Fecha;
                        oBE_DOCUMENTO.URL = file.GetName().ToString();
                        oBE_DOCUMENTO.SOLICITUD_ID = Guid.Parse(this.hdfSolicitudId.Value);
                        oBE_DOCUMENTO.USUARIO_CREACION = USUARIO;

                        if (BL_DOCUMENTO.InsertarDocumento(oBE_DOCUMENTO))
                            lblMensaje.Text = "El documento fue insertado correctamente";

                        rgDocumentos.DataBind();
                    }
                    else
                    {
                        lblMensaje.Text = "El tamaño del archivo debe ser mejor a 1MB";
                
                    }
                }
                else
                {
                    lblMensaje.Text = "Debe seleccionar un documento. Si lo ha hecho revise que la extensión sea la correcta (imagenes, doc. o pdf.)";

                }
            }
             catch (Exception ex)
             {
                 lblMensaje.Text = "Error al Insertar Documentos:" + ex.ToString();

             }
            

        }

        protected void rgDocumentos_DeleteCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                GridDataItem item = e.Item as GridDataItem;
                RadGrid rgDocumentos = (RadGrid)rpbSolicitud.FindItemByValue("Documentos").FindControl("rgDocumentos");
                Guid ID = Guid.Parse(item.OwnerTableView.DataKeyValues[item.ItemIndex]["ID"].ToString());

                if (BL_DOCUMENTO.EliminarDocumento(ID))
                {
                    lblMensaje.Text = "El documento fue eliminado correctamente";

                    List<BE_DOCUMENTO> lstDocumentos = BL_DOCUMENTO.SeleccionarDocumentosPorSolicitud(Guid.Parse(hdfSolicitudId.Value));
                    if (lstDocumentos == null || lstDocumentos.Count == 0)
                    {                            
                            rgDocumentos.DataSource = String.Empty;

                     }
                    
                }

                rgDocumentos.DataBind();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al Eliminar Documentos:" + ex.ToString();

            }
        }

        protected void rgDocumentos_ItemCommand(object source, GridCommandEventArgs e)
        {
             try
            {                               
                
            
                if (e.CommandName == RadGrid.InitInsertCommandName)
                {

                    List<BE_DOCUMENTO> lstDocumentos = BL_DOCUMENTO.SeleccionarDocumentosPorSolicitud(Guid.Parse(hdfSolicitudId.Value));
                    if (lstDocumentos == null || lstDocumentos.Count == 0)
                    {
                        RadGrid rgDocumentos = (RadGrid)rpbSolicitud.FindItemByValue("Documentos").FindControl("rgDocumentos");
                        rgDocumentos.DataSource = String.Empty;

                    }

                    e.Canceled = true;
                    System.Collections.Specialized.ListDictionary Valores = new System.Collections.Specialized.ListDictionary();

                    Valores.Add("FECHA_REGISTRO", DateTime.Now.Date);
                    Valores.Add("NOMBRE", "");
                    Valores.Add("DESCRIPCION", "");
                    Valores.Add("URL", "");

                    e.Item.OwnerTableView.InsertItem(Valores);
                
                }

                else if (e.CommandName == RadGrid.EditCommandName)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetEditMode", "isEditMode = true;", true);
                }

                else if (e.CommandName == RadGrid.RebindGridCommandName)
                {
                    List<BE_DOCUMENTO> lstDocumentos = BL_DOCUMENTO.SeleccionarDocumentosPorSolicitud(Guid.Parse(hdfSolicitudId.Value));
                    if (lstDocumentos == null || lstDocumentos.Count == 0)
                    {
                        RadGrid rgDocumentos = (RadGrid)rpbSolicitud.FindItemByValue("Documentos").FindControl("rgDocumentos");
                        rgDocumentos.DataSource = String.Empty;

                    }
                }

            }
             catch (Exception ex)
             {
                 lblMensaje.Text = "Error al Cargar Documentos:" + ex.ToString();

             }
        }

        protected void rgDocumentos_ItemDataBound(object sender, GridItemEventArgs e)
        {

            try
            {
                HyperLink hplDocumento1 = null;
                hplDocumento1 = (HyperLink)e.Item.FindControl("hplDocumento");
                if (e.Item.DataItem != null)
                {
                    string path = ConfigurationManager.AppSettings["DocumentPath"].ToString();
                    String filename = DataBinder.Eval(e.Item.DataItem, "URL").ToString();
                    String URL = String.Concat(path, filename);
                    if (hplDocumento1 == null)
                    {
                        hplDocumento1 = (HyperLink)e.Item.FindControl("hplSolicitud");
                        if (hplDocumento1 != null)
                            hplDocumento1.NavigateUrl = URL;
                    }
                    else
                        hplDocumento1.NavigateUrl = URL;



                }
            }
            catch (Exception ex)
            {

                lblMensaje.Text = "Error al Cargar Documentos:" + ex.ToString();

            }
        }


        protected void AsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            if (e.File.ContentLength < MaxTotalBytes)
            {
                e.IsValid = true;  
            }
            else
            {
                e.IsValid = false;
                lblMensaje.Text = "El tamaño del archivo debe ser menor a 1MB";
                
            }
        }
      
    }
}
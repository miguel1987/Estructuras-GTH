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

namespace WebUI.UI_ARCHIVO
{
    public partial class SolicitudesAprobacion : PageBaseClass
    {
        Guid USUARIO;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    validarUsuarioEnDominio();                    

                    LoadEmpresa();
                    //LoadDestinatario();
                    //Asignamos valores por defecto
                    ddlEmpresa.SelectedValue = Session["EMPRESA_ID"].ToString();
                    ddlArea.SelectedValue = Session["AREA_ID"].ToString();
                    rdpFechaRegistroDesde.SelectedDate = Convert.ToDateTime("01/01/" + DateTime.Now.Year.ToString()).Date;
                    rdpFechaRegistroHasta.SelectedDate = DateTime.Now.Date;
                    ValidarPerfilUsuario();
                    ActualizarGrilla();

                }
                catch (Exception ex)
                {

                    lblMensaje.Text = "Error al Cargar Solicitudes:" + ex.ToString();

                }

            }

        }

        protected void ValidarPerfilUsuario()
        {
            //Si perfil = Usuario solo puede crear solicitudes en su empresa, gerencia y área
            if (Session["PERFIL_ID"].ToString() == "2")
            {
                ddlEmpresa.Enabled = false;
                ddlGerencia.Enabled = false;
                //301115: Cambio solicitado por usuarios. Habilitar todas las áreas de la gerencia a la que pertenece el usuario
                ddlArea.Enabled = true;
            }

        }

        protected void LoadEmpresa()
        {
            BL_EMPRESA BL_EMPRESA = new BL_EMPRESA();

            this.CargarDropDownList(ddlEmpresa, "ID", "DESCRIPCION", BL_EMPRESA.SeleccionarEmpresa(), 0);



            LoadGerencia(0);

        }

        protected void LoadGerencia(int isEdit)
        {
            BL_GERENCIA BL_GERENCIA = new BL_GERENCIA();

            if (ddlEmpresa.SelectedValue != String.Empty)
                this.CargarDropDownList(ddlGerencia, "ID", "DESCRIPCION", BL_GERENCIA.SeleccionarGerenciaPorEmpresa(Guid.Parse(ddlEmpresa.SelectedValue)), 0);

            if (isEdit == 0)
                ddlGerencia.SelectedValue = Session["GERENCIA_ID"].ToString();

            LoadArea();

        }

        protected void LoadArea()
        {
            BL_AREA BL_AREA = new BL_AREA();

            if (ddlGerencia.SelectedValue!= String.Empty)
                this.CargarDropDownList(ddlArea, "ID", "DESCRIPCION", BL_AREA.SeleccionarAreaGerencia(Guid.Parse(ddlGerencia.SelectedValue)));

        }

        //protected void LoadDestinatario()
        //{
        //    BL_DESTINATARIO BL_DESTINATARIO = new BL_DESTINATARIO();

        //    this.CargarDropDownList(ddlDestinatario, "DIRECCION_ID", "NOMBRE", BL_DESTINATARIO.SeleccionarDestinatarioPorTipo(Convert.ToInt32(ddlTipoSolicitud.SelectedValue)));

        //}

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGerencia(1);
            ActualizarGrilla();

        }

        protected void ddlGerencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadArea();
            ActualizarGrilla();

        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();

        }

        protected void ddlTipoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadDestinatario();
            ActualizarGrilla();

        }

        protected void cargarSolicitudes_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarGrilla();

            }
            catch (Exception ex)
            {

                lblMensaje.Text = "Error al Cargar Solicitudes:" + ex.ToString();

            }
        }

        protected void nuevaSolicitud_Click(object sender, EventArgs e)
        {
            Server.Transfer("Solicitud.aspx", false);
        }

        protected void ActualizarGrilla()
        {
            int estadoSolicitud = (int)BE_SOLICITUD.SOLICITUD_ESTADO.PendienteAprobacion;
            rgSolicitudes.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;

            rgSolicitudes.MasterTableView.NoMasterRecordsText = "No existen solicitudes registrados para esos parámetros de consulta.";

            ObjectDataSourceSolicitudes.SelectParameters.Clear();
            ObjectDataSourceSolicitudes.SelectParameters.Add("empresaId", ddlEmpresa.SelectedValue);
            ObjectDataSourceSolicitudes.SelectParameters.Add("gerenciaId", ddlGerencia.SelectedValue);
            ObjectDataSourceSolicitudes.SelectParameters.Add("areaId", ddlArea.SelectedValue);
            ObjectDataSourceSolicitudes.SelectParameters.Add("tipo", ddlTipoSolicitud.SelectedValue);
            //ObjectDataSourceSolicitudes.SelectParameters.Add("destinatario", ddlDestinatario.SelectedItem.Text);
            ObjectDataSourceSolicitudes.SelectParameters.Add("destinatario", "_");
            ObjectDataSourceSolicitudes.SelectParameters.Add("fechaDesde", rdpFechaRegistroDesde.SelectedDate.ToString());
            ObjectDataSourceSolicitudes.SelectParameters.Add("fechaHasta", rdpFechaRegistroHasta.SelectedDate.ToString());
            ObjectDataSourceSolicitudes.SelectParameters.Add("estado", estadoSolicitud.ToString());

            if (Session["PERFIL_ID"].ToString() == "2")
            {
                ObjectDataSourceSolicitudes.SelectParameters.Add("usuarioId", Session["PERSONAL_ID"].ToString());
            }

        }

        protected void rgSolicitudes_ItemDataBound(object sender, GridItemEventArgs e)
        {

            try
            {
                HyperLink hplSolicitud1 = null;
                hplSolicitud1 = (HyperLink)e.Item.FindControl("hplSolicitud");
                if (e.Item.DataItem != null)
                {
                    String ID = DataBinder.Eval(e.Item.DataItem, "ID").ToString();
                    if (hplSolicitud1 == null)
                    {
                        hplSolicitud1 = (HyperLink)e.Item.FindControl("hplSolicitud2");
                        if (hplSolicitud1 != null)
                            hplSolicitud1.NavigateUrl = String.Concat("Solicitud.aspx?heSolicitudId=", ID);
                    }
                    else
                        hplSolicitud1.NavigateUrl = String.Concat("Solicitud.aspx?heSolicitudId=", ID);



                }
            }
            catch (Exception ex)
            {

                lblMensaje.Text = "Error al Cargar Solicitudes:" + ex.ToString();

            }
        }

        protected void rgSolicitudes_ApproveCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());

            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            BL_SOLICITUD.ActualizarEstadoSolicitud(Guid.Parse(values["ID"].ToString()), (int)BE_SOLICITUD.SOLICITUD_ESTADO.Aprobada, USUARIO, values["SOLICITANTE_CORREO"].ToString());
        }

        protected void rgSolicitudes_RejectCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());

            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            BL_SOLICITUD.ActualizarEstadoSolicitud(Guid.Parse(values["ID"].ToString()), (int)BE_SOLICITUD.SOLICITUD_ESTADO.Rechazada, USUARIO, values["SOLICITANTE_CORREO"].ToString());
        }
    }
}
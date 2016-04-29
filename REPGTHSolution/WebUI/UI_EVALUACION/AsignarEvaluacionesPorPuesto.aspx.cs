using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using BusinessEntities;
using Telerik.Web.UI;
using System.Collections;
using System.Threading;
using System.Drawing;

namespace WebUI.UI_EVALUACION
{
    public partial class AsignarEvaluacionesPorPuesto : PageBaseClass
    {
        Guid USUARIO;

        protected void Page_Load(object sender, EventArgs e)
        {

            validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());


            if (!String.IsNullOrEmpty(Request.QueryString["pPersonalId"])) hf_PersonalId.Value = Request.QueryString["pPersonalId"];

            if (!String.IsNullOrEmpty(Request.QueryString["pPuestoId"])) hf_PuestoId.Value = Request.QueryString["pPuestoId"];

            if (!String.IsNullOrEmpty(Request.QueryString["pDescripcionPersonal"])) hf_Personal.Value = Request.QueryString["pDescripcionPersonal"];

            if (!String.IsNullOrEmpty(Request.QueryString["pDescripcionPuesto"])) hf_Puesto.Value = Request.QueryString["pDescripcionPuesto"];
            if (!string.IsNullOrEmpty(Request.QueryString["PDepartamento"])) hf_Departamento.Value = Request.QueryString["PDepartamento"];


            if (!Page.IsPostBack)
            {
                //Asignar valores
                lblArea.Text =hf_Departamento.Value;
                lblPersonal.Text = hf_Personal.Value;
                lblPuesto.Text = hf_Puesto.Value;

                //Cargar Tipos Competencias
                LoadTipoCompetencia();  
                                
                //Competencias por Puesto
                this.odsCompetenciasPuesto.SelectParameters[0].DefaultValue = hf_PuestoId.Value;
                this.odsCompetenciasPuesto.SelectParameters[1].DefaultValue = ddlTipoCompetencias.SelectedValue;
            }


        }

        protected void LoadTipoCompetencia()
        {
            BL_COMPETENCIAS_TIPOS BL_COMPETENCIAS_TIPOS = new BL_COMPETENCIAS_TIPOS();

            this.CargarDropDownList(ddlTipoCompetencias, "ID", "COMPETENCIA_TIPO_DESCRIPCION", BL_COMPETENCIAS_TIPOS.SeleccionarCompetenciasTipos(), 0);
           
        }

        protected void ddlTipoCompetencias_SelectedIndexChanged(object sender, EventArgs e)
        {           
            ActualizarGrilla();

        }

        protected void ActualizarGrilla()
        {
            rgAsignarCompetencias.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;

            rgAsignarCompetencias.MasterTableView.NoMasterRecordsText = "No existen competencias registrados para estos parámetros de consulta.";

            odsCompetenciasPuesto.SelectParameters.Clear();
            odsCompetenciasPuesto.SelectParameters.Add("idPuesto", hf_PuestoId.Value);
            odsCompetenciasPuesto.SelectParameters.Add("idTipoCompetencia", ddlTipoCompetencias.SelectedValue);
           

        }
    }
}
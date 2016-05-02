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

        protected void rgAsignarCompetencias_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e);
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            //create new entity
            BL_COMPETENCIAS_POR_PUESTO BL_AREA = new BL_COMPETENCIAS_POR_PUESTO();
            //populate its properties
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            BE_COMPETENCIAS_POR_PUESTO oentidad = new BE_COMPETENCIAS_POR_PUESTO();

            Nullable<Guid> COMPETENCIA_ID;

            if (e.CommandName == RadGrid.PerformInsertCommandName)
                COMPETENCIA_ID = Guid.Empty;
            else
                COMPETENCIA_ID = Guid.Parse(editableItem.GetDataKeyValue("COMPETENCIA_ID").ToString());

            oentidad.COMPETENCIA_ID = (Guid)COMPETENCIA_ID;
            
            oentidad.REAL = (int)values["REAL"];
            oentidad.BRECHA = oentidad.REAL - (int)values["REQUERIDO"];
            oentidad.COMENTARIO = values["COMENTARIO"].ToString();
            oentidad.USUARIO_CREACION = USUARIO;
            oentidad.ESTADO_EVALUACION = (int)BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.En_Evaluacion;
            oentidad.ANIO_EVALUACION = DateTime.Now.Year;

        //    if (oentidad.REAL==0)
        //    {                
        //        BL_COMPETENCIAS_POR_PUESTO.InsertarEvaluacion(oentidad);
        //    }
        //    else
        //    {
        //        BL_COMPETENCIAS_POR_PUESTO.ActualizarEvaluacion(oentidad);

        //    }

        }

        //protected void rgAsignarCompetencias_UpdateCommand(object sender, GridCommandEventArgs e)
        //{
            
        //}
    }
}
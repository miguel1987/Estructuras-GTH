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
        
        Guid USUARIO=Guid.Empty;
        BE_EVALUACION_COMPETENCIA_PUESTO BE_EVALUACION_COMPETENCIA_PUESTO = new BE_EVALUACION_COMPETENCIA_PUESTO();

        protected void Page_Load(object sender, EventArgs e)
        {

            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());

            if (!Page.IsPostBack)
            {
                try
                {
                    if (!String.IsNullOrEmpty(Request.QueryString["pPersonalId"])) hf_PersonalId.Value = Request.QueryString["pPersonalId"];

                    if (!String.IsNullOrEmpty(Request.QueryString["pPuestoId"])) hf_PuestoId.Value = Request.QueryString["pPuestoId"];

                    if (!String.IsNullOrEmpty(Request.QueryString["pDescripcionPersonal"])) hf_Personal.Value = Request.QueryString["pDescripcionPersonal"];

                    if (!String.IsNullOrEmpty(Request.QueryString["pDescripcionPuesto"])) hf_Puesto.Value = Request.QueryString["pDescripcionPuesto"];
                    if (!string.IsNullOrEmpty(Request.QueryString["PDepartamento"])) hf_Departamento.Value = Request.QueryString["PDepartamento"];
                    if (!string.IsNullOrEmpty(Request.QueryString["PEstadoDescripcion"])) hf_Estado.Value = Request.QueryString["PEstadoDescripcion"];

                    //Asignar valores
                    lblArea.Text = hf_Departamento.Value;
                    lblPersonal.Text = hf_Personal.Value;
                    lblPuesto.Text = hf_Puesto.Value;

                    //Cargar Tipos Competencias
                    LoadTipoCompetencia();

                    //Competencias por Puesto          
                    odsCompetenciasPuesto.SelectParameters.Clear();
                    odsCompetenciasPuesto.SelectParameters.Add("idPuesto", hf_PuestoId.Value);
                    odsCompetenciasPuesto.SelectParameters.Add("idTipoCompetencia", ddlTipoCompetencias.SelectedValue);
                    odsCompetenciasPuesto.SelectParameters.Add("idPersonal", hf_PersonalId.Value);
                  
                   
                    
                }
                catch (Exception ex)
                {

                    lblMensaje.Text = "Error al Asignar Evaluació:" + ex.ToString();

                }
            }

            btnGuardarEvaluacionFinal.Visible = false;
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
            odsCompetenciasPuesto.SelectParameters.Add("idPersonal", hf_PersonalId.Value);
            rgAsignarCompetencias.Rebind();

        }

        protected void rgAsignarCompetencias_ItemDataBound(object sender, GridItemEventArgs e)
        {
            
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {

                (e.Item as GridEditableItem)["COMPETENCIA_PUESTO_VALOR_REQUERIDO"].Visible = false;
                (e.Item as GridEditableItem)["ESTADO_EVALUACION"].Visible = false;

            }
            if (hf_Estado.Value == BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.Evaluado.ToString() && Session["PERFIL_ID"].ToString() == "2")
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;

                    ImageButton imageButton = (ImageButton)item["EditCommandColumn"].Controls[0];
                    imageButton.Visible = false;
                }

            }

            if (e.Item is GridPagerItem)
            {
                GridPagerItem pagerItem = e.Item as GridPagerItem;
                int itemsCount = pagerItem.Paging.DataSourceCount;
                if (itemsCount > 0)
                    btnGuardarEvaluacionFinal.Visible = true;
                
            }
            

            
        }

        
        protected void rgAsignarCompetencias_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GrabarActualizar(sender, e);
        }

        protected void GrabarActualizar(object sender, GridCommandEventArgs e)
        {
            try
            {
                var editableItem = ((GridEditableItem)e.Item);
                //create new entity
                BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL = new BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL();
                //populate its properties
                Hashtable values = new Hashtable();
                editableItem.ExtractValues(values);
                TextBox tbTipo = null;

                BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL oentidad = new BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL();

                Nullable<Guid> COMPETENCIA_ID;


                if (e.CommandName == RadGrid.PerformInsertCommandName)
                    COMPETENCIA_ID = Guid.Empty;
                else
                    COMPETENCIA_ID = Guid.Parse(editableItem.GetDataKeyValue("COMPETENCIA_ID").ToString());
                tbTipo = (TextBox)e.Item.FindControl("txtValorReal");
                oentidad.COMPETENCIA_ID = (Guid)COMPETENCIA_ID;
                hf_CompetenciaId.Value = oentidad.COMPETENCIA_ID.ToString();
                oentidad.PERSONAL_ID = Guid.Parse(hf_PersonalId.Value);
                oentidad.PUESTO_ID = Guid.Parse(hf_PuestoId.Value);
                oentidad.REAL = Convert.ToInt32(tbTipo.Text);
                oentidad.BRECHA = Convert.ToInt32(values["COMPETENCIA_PUESTO_VALOR_REQUERIDO"]) - oentidad.REAL;
                oentidad.ESTADO_EVALUACION = Convert.ToInt16(values["ESTADO_EVALUACION"]);
                oentidad.COMENTARIO = values["COMENTARIO"].ToString();
                oentidad.USUARIO_CREACION = USUARIO;
                oentidad.ANIO_EVALUACION = DateTime.Now.Year;
                if (oentidad.BRECHA < 0)
                    oentidad.BRECHA = 0;

                if (oentidad.ESTADO_EVALUACION == (int)BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.Pendiente)
                {
                    oentidad.ESTADO_EVALUACION = (int)BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.En_Evaluacion;
                    BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.InsertarEvaluacionCompetenciasPuestosPersonal(oentidad);
                }
                else
                {
                    oentidad.ESTADO_EVALUACION = (int)BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.En_Evaluacion;
                    BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.ActualizarEvaluacionCompetenciasPuestosPersonal(oentidad);
                }
            }
            catch (Exception ex)
            {

                lblMensaje.Text = "Error al Asignar Evaluación:" + ex.ToString();

            }

        }


        protected void btnGuardarEvaluacionFinal_Click(object sender, EventArgs e)
        {
            try
            {

                int competencias_por_evaluar = 0;
                Guid idPuesto = Guid.Parse(hf_PuestoId.Value);

                competencias_por_evaluar = BL_COMPETENCIAS_POR_PUESTO.EvaluacionFinalGrabar(idPuesto);

                if (competencias_por_evaluar == 0)
                {
                    BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL = new BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL();


                    BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL oentidadeValua = new BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL();


                    oentidadeValua.PERSONAL_ID = Guid.Parse(hf_PersonalId.Value);
                    oentidadeValua.PUESTO_ID = Guid.Parse(hf_PuestoId.Value);
                    BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.ActualizarEvaluacionFinal(oentidadeValua);
                    hf_Estado.Value = BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.Evaluado.ToString();
                    ActualizarGrilla();

                    lblMensaje.Text = "Se actualizó el Estado de las Competencias a Evaluado. Éstas ya no podrán ser editadas, salvo por un usuario administrador";


                }

                else
                    lblMensaje.Text = "Existen competencias sin Evaluar. Debe evaluar todas las competencias.";
            }
            catch (Exception ex)
            {

                lblMensaje.Text = "Error al Asignar Evaluació:" + ex.ToString();

            }

        }

       
    }
}
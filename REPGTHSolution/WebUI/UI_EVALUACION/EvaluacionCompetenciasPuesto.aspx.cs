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
    public partial class EvaluacionCompetenciasPuesto : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());

            if (!Page.IsPostBack)
            {
                try
                {
                    validarUsuarioEnDominio();                    
                    SeguridadEstructura();                                        
                }
                catch (Exception ex)
                {

                    lblMensaje.Text = "Error al Cargar Solicitudes:" + ex.ToString();
                }

            }

        }
            
        protected void SeguridadEstructura()
        {
            //Variables para cargar pivot por defecto
            string nivel = "0";
            string jerarquia_id = Session["EMPRESA_ID"].ToString();

            //Cargamos la estructura jerarquica de REP
            //1. Cargar una lista de objetos de tipo Empresas            

            BL_EMPRESA BL_EMPRESA = new BL_EMPRESA();
            List<BE_EMPRESA> lstEmpresas = BL_EMPRESA.SeleccionarEmpresa();

            //2. Recorrear la lista con un foreach y añadir al tree view estructura un nodo por cada empresa
            foreach (BE_EMPRESA oEmpresa in lstEmpresas)
            {
                RadTreeNode nodeEmpresa = new RadTreeNode(oEmpresa.DESCRIPCION.ToString(), oEmpresa.ID.ToString());
                nodeEmpresa.Expanded = true;
                //Añadir nodo Presidencia - CEO


                BL_PRESIDENCIA BL_PRESIDENCIA = new BL_PRESIDENCIA();
                List<BE_PRESIDENCIA> lstPresidencias = BL_PRESIDENCIA.SeleccionarPresidenciaPorEmpresa(oEmpresa.ID);
                foreach (BE_PRESIDENCIA oPresidencia in lstPresidencias)
                {
                    RadTreeNode nodePresidencia = new RadTreeNode(oPresidencia.DESCRIPCION.ToString(), oPresidencia.ID.ToString());
                    nodeEmpresa.Nodes.Add(nodePresidencia);
                    nodePresidencia.Expanded = true;
                    BL_GERENCIA BL_GERENCIA = new BL_GERENCIA();
                    List<BE_GERENCIA> lstGerencias = BL_GERENCIA.SeleccionarGerenciaPorEmpresa(oEmpresa.ID);

                    foreach (BE_GERENCIA oGerencia in lstGerencias)
                    {
                        RadTreeNode nodeGerencia = new RadTreeNode(oGerencia.DESCRIPCION.ToString(), oGerencia.ID.ToString());

                        if (oGerencia.ID.ToString() == (Session["GERENCIA_ID"].ToString()))
                        {
                            nodeGerencia.Expanded = true;
                            nodeGerencia.Enabled = true;
                        }
                        else
                        {
                            nodeGerencia.Expanded = false;
                            nodeGerencia.Enabled = false;
                        }

                        BL_AREA BL_AREA = new BL_AREA();
                        List<BE_AREA> lstAreas = BL_AREA.SeleccionarAreaGerencia(oGerencia.ID);

                        foreach (BE_AREA oArea in lstAreas)
                        {
                            RadTreeNode nodeAreas = new RadTreeNode(oArea.DESCRIPCION.ToString(), oArea.ID.ToString());
                            RadTreeNode nodeCoordinacion = null;

                            if (oArea.ID.ToString() == (Session["AREA_ID"].ToString()))
                            {
                                nodeAreas.Expanded = true;
                                nodeAreas.Enabled = true;
                            }
                            else
                            {
                                nodeAreas.Expanded = false;
                                nodeAreas.Enabled = false;
                            }

                            //llamar a BL COORDINACION  MÉTODO SELECCIONAR COORDINACION POR AREA
                            BL_COORDINACION BL_COORDINACION = new BL_COORDINACION();
                            List<BE_COORDINACION> lstCoordinacion = BL_COORDINACION.SeleccionarCoordinacionPorArea(oArea.ID);
                            foreach (BE_COORDINACION oCoordinacion in lstCoordinacion)
                            {
                                nodeCoordinacion = new RadTreeNode(oCoordinacion.DESCRIPCION.ToString(), oCoordinacion.ID.ToString());

                                if (oCoordinacion.ID.ToString() == (Session["COORDINACION_ID"].ToString()))
                                {
                                    nodeCoordinacion.Expanded = true;
                                    nodeCoordinacion.Enabled = true;
                                }
                                else
                                {
                                    if ((Session["GRUPO_ORGANIZACIONAL_CODIGO"].ToString() != "GE" && Session["GRUPO_ORGANIZACIONAL_CODIGO"].ToString() != "JD"))
                                    {
                                        nodeCoordinacion.Expanded = false;
                                        nodeCoordinacion.Enabled = false;
                                    }
                                }

                                nodeAreas.Nodes.Add(nodeCoordinacion);

                            }

                            nodeGerencia.Nodes.Add(nodeAreas);

                            if (Session["PERFIL_ID"].ToString() == "1")
                            {

                                nodePresidencia.Enabled = true;
                                nodeGerencia.Enabled = true;
                                nodeAreas.Enabled = true;
                                if (nodeCoordinacion != null)
                                nodeCoordinacion.Enabled = true;
                            }
                            else if (Session["PERFIL_ID"].ToString() == "2" && Session["GRUPO_ORGANIZACIONAL_CODIGO"].ToString() == "GE")
                            {
                                nivel = "2";
                                jerarquia_id = Session["GERENCIA_ID"].ToString();
                                nodePresidencia.Enabled = false;
                                nodeEmpresa.Enabled = false;
                                nodeAreas.Enabled = true;
                                if (nodeCoordinacion != null)
                                    nodeCoordinacion.Enabled = true;

                            }
                            else if (Session["PERFIL_ID"].ToString() == "2" && Session["GRUPO_ORGANIZACIONAL_CODIGO"].ToString() == "JD")
                            {
                                nivel = "3";
                                jerarquia_id = Session["AREA_ID"].ToString();
                                nodeEmpresa.Enabled = false;
                                nodePresidencia.Enabled = false;
                                nodeGerencia.Enabled = false;
                                nodeAreas.Enabled = true;

                            }

                            else if (Session["PERFIL_ID"].ToString() == "2" && Session["GRUPO_ORGANIZACIONAL_CODIGO"].ToString() == "CO")
                            {
                                nivel = "4";
                                jerarquia_id = Session["COORDINACION_ID"].ToString();
                                nodeEmpresa.Enabled = false;
                                nodePresidencia.Enabled = false;
                                nodeGerencia.Enabled = false;
                                nodeAreas.Enabled = false;

                            }
                            else
                            {
                                nodeEmpresa.Enabled = false;
                                nodePresidencia.Enabled = false;
                                nodeGerencia.Enabled = false;
                                nodeAreas.Enabled = false;

                            }

                        }


                        nodePresidencia.Nodes.Add(nodeGerencia);

                    }
                }

                this.rtvEstructuras.Nodes.Add(nodeEmpresa);
            }

            if (nivel == "0")
            {

                if (Session["AREA_ID"].ToString() == Guid.Empty.ToString())
                {
                    nivel = "2";
                    jerarquia_id = Session["GERENCIA_ID"].ToString();
                }

                if (Session["COORDINACION_ID"] == Guid.Empty.ToString())
                {
                    nivel = "3";
                    jerarquia_id = Session["AREA_ID"].ToString();
                }
                else
                {
                    nivel = "4";
                    jerarquia_id = Session["COORDINACION_ID"].ToString();
                }

            }

            LoadGrilla(jerarquia_id, nivel);                                                     
        }
        
        protected void rtvEstructuras_NodeClick(object sender, RadTreeNodeEventArgs e)
        {                                 
            string idNodo = e.Node.Value.ToString();

            string nivel = rtvEstructuras.SelectedNode.Level.ToString();

            lblArea.Text = e.Node.Text;                
            ActualizarGrilla(idNodo, nivel);
        }

        protected void ActualizarGrilla(string idNodo, string nivel)
        {
            rgEvaluaciones.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;

            rgEvaluaciones.MasterTableView.NoMasterRecordsText = "No existen evaluaciones registrados para esos parámetros de consulta.";

            odsEvaluacionesEstado.SelectParameters.Clear();

            odsEvaluacionesEstado.SelectParameters.Add("jerarquia_id", System.Data.DbType.Guid, idNodo);

            odsEvaluacionesEstado.SelectParameters.Add("nivel", System.Data.DbType.Int16, nivel);

            rgEvaluaciones.DataBind();
        }

        protected void LoadGrilla(string idNodo, string nivel)
        {
            rgEvaluaciones.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;

            rgEvaluaciones.MasterTableView.NoMasterRecordsText = "No existen evaluaciones registrados para esos parámetros de consulta.";

            odsEvaluacionesEstado.SelectParameters.Clear();

            odsEvaluacionesEstado.SelectParameters.Add("jerarquia_id", System.Data.DbType.Guid, idNodo);

            odsEvaluacionesEstado.SelectParameters.Add("nivel", System.Data.DbType.Int16, nivel);
            
            rgEvaluaciones.DataBind();
        }

        protected void rgEvaluaciones_ItemDataBound(object sender, GridItemEventArgs e)
        {

            //Se añadió código para llamada a pop-up de asignación de participantes
            if (e.Item.DataItem != null)
            {
                string departamento=String.Empty;
                String idPersonal = DataBinder.Eval(e.Item.DataItem, "PERSONAL_ID").ToString();
                String idPuesto = DataBinder.Eval(e.Item.DataItem, "PUESTO_ID").ToString();
                string puesto=DataBinder.Eval(e.Item.DataItem,"PUESTO_DESCRIPCION").ToString();
                string personal = DataBinder.Eval(e.Item.DataItem, "PERSONAL_DESCRIPCION").ToString();
                if(DataBinder.Eval(e.Item.DataItem, "AREA")!=null)
                     departamento = DataBinder.Eval(e.Item.DataItem, "AREA").ToString();
                string estado = DataBinder.Eval(e.Item.DataItem, "ESTADO_DESCRIPCION").ToString();

                HyperLink hplEvaluarPersonal1 = null;
                string UrlEvaluar = "AsignarEvaluacionesPorPuesto.aspx?lightbox[iframe]=true&lightbox[width]=613&lightbox[height]=352&pPersonalId=" + idPersonal + "&pPuestoId=" + idPuesto + "&pDescripcionPersonal=" + personal + "&pDescripcionPuesto=" + puesto + "&PDepartamento=" +departamento +"&PEstadoDescripcion="+estado;

                hplEvaluarPersonal1 = (HyperLink)e.Item.FindControl("hplEvaluarPersonal");
                if (hplEvaluarPersonal1 == null)
                {
                    hplEvaluarPersonal1 = (HyperLink)e.Item.FindControl("hplEvaluarPersonal2");
                    if (hplEvaluarPersonal1 != null)
                        hplEvaluarPersonal1.NavigateUrl = UrlEvaluar;
                }
                else
                    hplEvaluarPersonal1.NavigateUrl = UrlEvaluar;
            }            
        }
        
        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            rgEvaluaciones.MasterTableView.FilterExpression = "([PERSONAL_DESCRIPCION] LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [PUESTO_DESCRIPCION]LIKE \'%" + txtBuscar.Text.Trim() + "%\' OR [ESTADO_DESCRIPCION]LIKE \'%" +txtBuscar.Text.Trim()+"%\')";            
           rgEvaluaciones.Rebind();
           
          }                       
        }
    }




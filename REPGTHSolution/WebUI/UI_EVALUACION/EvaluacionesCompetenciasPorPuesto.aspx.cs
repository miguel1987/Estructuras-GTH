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
    public partial class EvaluacionesCompetenciasPorPuesto : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());

            if (!Page.IsPostBack)
            {
                try
                {
                    validarUsuarioEnDominio();
                    ValidarPerfilUsuario();
                    LoadEstructura();
                    addTooltips();
                    LoadCombo(Session["EMPRESA_ID"].ToString(), "0");

                    LoadGrilla(rcbPuesto.SelectedValue, rcbCompetenciasPuesto.SelectedValue);
                   
                    
                    
                    
                   
                    
                }
                catch (Exception ex)
                {

                    lblMensaje.Text = "Error al Cargar Evaluaciones:" + ex.ToString();

                }

            }

        }

        protected void ValidarPerfilUsuario()
        {
            //Recuperamos el perfil del usuario para validar sus accesos
            //Validar Accesos por Perfil
            
        }



        protected void LoadEstructura()
        {
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

                        BL_AREA BL_AREA = new BL_AREA();
                        List<BE_AREA> lstAreas = BL_AREA.SeleccionarAreaGerencia(oGerencia.ID);

                        foreach (BE_AREA oArea in lstAreas)
                        {
                            RadTreeNode nodeAreas = new RadTreeNode(oArea.DESCRIPCION.ToString(), oArea.ID.ToString());

                            //llamar a BL COORDINACION  MÉTODO SELECCIONAR COORDINACION POR AREA
                            BL_COORDINACION BL_COORDINACION = new BL_COORDINACION();
                            List<BE_COORDINACION> lstCoordinacion = BL_COORDINACION.SeleccionarCoordinacionPorArea(oArea.ID);
                            foreach (BE_COORDINACION oCoordinacion in lstCoordinacion)
                            {
                                RadTreeNode nodeCoordinacion = new RadTreeNode(oCoordinacion.DESCRIPCION.ToString(), oCoordinacion.ID.ToString());
                                nodeAreas.Nodes.Add(nodeCoordinacion);

                            }
                           

                            nodeGerencia.Nodes.Add(nodeAreas);
                        }


                        nodePresidencia.Nodes.Add(nodeGerencia);

                    }
                }

                this.rtvTransversales.Nodes.Add(nodeEmpresa);


            }
        

        }
                
       
        protected void rtvTransversales_NodeClick(object sender, RadTreeNodeEventArgs e)
        {       

            string idNodo= e.Node.Value.ToString();

            string nivel = rtvTransversales.SelectedNode.Level.ToString();
            
            LoadCombo(idNodo, nivel);
            
        }
        

        protected void LoadCombo(string idNodo, string nivel)
        {

            odsPuesto.SelectParameters.Clear();
            odsPuesto.SelectParameters.Add("jerarquia_id", System.Data.DbType.Guid, idNodo);
            odsPuesto.SelectParameters.Add("nivel", System.Data.DbType.Int16, nivel);
            rcbPuesto.DataBind();
            rcbCompetenciasPuesto.DataBind();
            
        }

        protected void LoadGrilla(string puesto_id, string competencia_tipo_id)
        {

            odsCompetenciasPuesto.SelectParameters.Clear();
            odsCompetenciasPuesto.SelectParameters.Add("puesto_id", System.Data.DbType.Guid, puesto_id);
            odsCompetenciasPuesto.SelectParameters.Add("competencia_tipo_id", System.Data.DbType.Guid, competencia_tipo_id);
            odsCompetenciasPuesto.DataBind();
        }

        protected void rcbCompetenciasPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadGrilla(rcbPuesto.SelectedValue, rcbCompetenciasPuesto.SelectedValue);
            rgEvaluacionesporPuesto.Rebind();
            

        }

        protected void rcbPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadGrilla(rcbPuesto.SelectedValue, rcbCompetenciasPuesto.SelectedValue);
            rgEvaluacionesporPuesto.Rebind();


        }


        protected void addTooltips()
        {
            RadToolTipManager1.TargetControls.Clear();

            foreach (RadTreeNode node in rtvTransversales.Nodes)
            {
                node.Attributes.Add("ID", node.Text);
                RadToolTipManager1.TargetControls.Add(node.Attributes["ID"], true);
                NodesInNode(node);
            }
        }

        protected void NodesInNode(RadTreeNode startNode)
        {
            if (startNode.Nodes.Count > 0)
            {
                foreach (RadTreeNode node in startNode.Nodes)
                {

                    node.Attributes.Add("ID", node.Text);
                    RadToolTipManager1.TargetControls.Add(node.Attributes["ID"], true);
                    NodesInNode(node);
                }
            }
        }



        protected void RadToolTipManager1_AjaxUpdate(object sender, ToolTipUpdateEventArgs e)
        {
            Label text = new Label();
            text.Text = e.TargetControlID;
            e.UpdatePanel.ContentTemplateContainer.Controls.Add(text);
        }       






        protected void rgEvaluacionesporPuesto_CellDataBound(object sender, PivotGridCellDataBoundEventArgs e)
        {
            if (e.Cell is PivotGridRowHeaderCell)
            {
                if (e.Cell.Text.IndexOf("Grand Total") >= 0)
                {
                    e.Cell.Text = "Gesamtsumme:";
                }
            }
            else if (e.Cell is PivotGridColumnHeaderCell)
            {
                int index = e.Cell.Text.IndexOf("Sum of VALOR_REAL");
                if (index >= 0)
                {
                    e.Cell.Text = e.Cell.Text.Replace("Sum of VALOR_REAL", "REAL");
                }
                else
                {
                    index = e.Cell.Text.IndexOf("Sum of BRECHA");
                    if (index >= 0)
                    {
                        e.Cell.Text = e.Cell.Text.Replace("Sum of BRECHA", "BRECHA");
                    }
                }

            }
        }
    
       
    }
}
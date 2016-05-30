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
using System.Drawing;

namespace WebUI.UI_ARCHIVO
{
    public partial class EvaluacionesTransversalesLiderazgo : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;
        BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES = new BusinessEntities.BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES();


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
                    LoadGrilla(Session["EMPRESA_ID"].ToString(), "0");
                    lblMensaje.Text = hf_Contador.Value;





                }
                catch (Exception ex)
                {

                    lblMensaje.Text = "Error al Cargar Solicitudes:" + ex.ToString();

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

            string idNodo = e.Node.Value.ToString();

            string nivel = rtvTransversales.SelectedNode.Level.ToString();
            LoadGrilla(idNodo, nivel);
        }


        protected void LoadGrilla(string idNodo, string nivel)
        {

            odsEvaluacionesTransversales.SelectParameters.Clear();

            odsEvaluacionesTransversales.SelectParameters.Add("jerarquia_id", System.Data.DbType.Guid, idNodo);

            odsEvaluacionesTransversales.SelectParameters.Add("nivel", System.Data.DbType.Int16, nivel);

            rgEvaluacionesTransversalesporPersonal.DataBind();

            CalcularIndicador(idNodo, nivel);
        }

        protected void CalcularIndicador(string idNodo, string nivel)
        {

            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
            BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES = new BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES();

            oListaEvaluacionesTransversales = BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarEvaluacionesTransversalesPorJerarquia(Guid.Parse(idNodo), Int32.Parse(nivel));

            decimal contadorCompetenciasDesarrolladas = 0;
            decimal contadorTotalRegistros = 0;
            string valor = string.Empty;
            //TODO: Traer de BD
            obtenervalor(valor);
            int parametroCompetenciasDesarrolladas = BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.VALOR;

            decimal indicador = 0;

            contadorTotalRegistros = oListaEvaluacionesTransversales.Count;

            foreach (var itemevaluaciones in oListaEvaluacionesTransversales)
            {
                BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES oEvaluacion_Competencia_Transversales = new BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES();
                oEvaluacion_Competencia_Transversales.PORCENTAJE = itemevaluaciones.PORCENTAJE * 100;
                if (oEvaluacion_Competencia_Transversales.PORCENTAJE >= parametroCompetenciasDesarrolladas)
                    contadorCompetenciasDesarrolladas++;
            }
            if (contadorCompetenciasDesarrolladas > 0 && contadorTotalRegistros > 0)

                indicador = (contadorCompetenciasDesarrolladas / contadorTotalRegistros) * 100;

            this.lblIndicador.Text = Decimal.Round(indicador, 0).ToString();


        }

        protected void obtenervalor(string valor)
        {
            int prueba;


            valor = BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.PARAMETRO_SISTEMA.DESARROLLADAS.ToString();
            prueba = BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ParametroSistemaporValor(valor);
            BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.VALOR = prueba;


        }

        protected void rgEvaluacionesTransversalesporPersonal_CellDataBound(object sender, PivotGridCellDataBoundEventArgs e)
        {



            int porcentaje;

            if (e.Cell is PivotGridDataCell)
            {
                PivotGridDataCell cell = e.Cell as PivotGridDataCell;


                if (cell.CellType == PivotGridDataCellType.DataCell)
                {

                    if (cell != null)
                    {

                        switch ((cell.Field as PivotGridAggregateField).DataField)
                        {

                            //color the cells showing totals for TotalPrice based on their value
                            case "PORCENTAJE":
                                if (cell.DataItem != null && cell.DataItem.ToString().Length > 0)
                                {
                                    
                                    decimal price = Convert.ToDecimal(cell.DataItem);
                                    porcentaje = Convert.ToInt32(price * 100);
                                    if (porcentaje > 80)
                                    {

                                        //cell.CssClass = "format_pivotgrid_desarrolladas";

                                        int color = 0xF30F1A;

                                        cell.BackColor = Color.FromArgb(color);
                                        
                                    }
                                    else if (porcentaje < 80)
                                        cell.CssClass = "format_pivotgrid_no_desarrolladas";
                                    

                                    //if ((cell.Field as PivotGridAggregateField).DataField>80 )
                                    //{ }
                                }
                                break;
                        }
                    }
                }


            }


            
        }



        

















    }
}
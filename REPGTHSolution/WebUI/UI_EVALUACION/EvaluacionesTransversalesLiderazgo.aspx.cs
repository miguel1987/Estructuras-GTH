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

namespace WebUI.UI_EVALUACION
{
    public partial class EvaluacionesTransversalesLiderazgo : PageBaseClass
    {
        Guid USUARIO = Guid.Empty;
        string USUARIO_GRUPO_ORGANIZACIONAL = String.Empty;
        string USUARIO_EMPRESA = String.Empty;
        BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES = new BusinessEntities.BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            this.validarUsuarioEnDominio();
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
            USUARIO_GRUPO_ORGANIZACIONAL = Session["GRUPO_ORGANIZACIONAL_CODIGO"].ToString();
            USUARIO_EMPRESA = Session["EMPRESA_ID"].ToString();
            
            if (!Page.IsPostBack)
            {
                try
                {
                    validarUsuarioEnDominio();
                    if (Session["PERFIL_ID"].ToString() == "1")
                    {
                        LoadEstructura();
                        hf_NodoParent.Value = USUARIO_EMPRESA;
                        LoadGrilla(Session["EMPRESA_ID"].ToString(), "0");


                    }
                    else
                    {

                        SeguridadEstructura();
                    }             
                    lblMensaje.Text = hf_Contador.Value;                    
                }
                catch (Exception ex)
                {

                    lblMensaje.Text = "Error al Cargar Evaluaciones:" + ex.ToString();

                }

            }

            

        }

        protected void rtvTransversales_NodeClick(object sender, RadTreeNodeEventArgs e)
        {
            string idNodo = e.Node.Value.ToString();          
            string nivel = rtvTransversales.SelectedNode.Level.ToString();

            if (nivel == "0" || nivel == "1" || nivel == "2")
                hf_NodoParent.Value = USUARIO_EMPRESA;
            else
                hf_NodoParent.Value = e.Node.ParentNode.Value.ToString();

            LoadGrilla(idNodo, nivel);            
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
                            
                            if (Session["PERFIL_ID"].ToString() == "2" && Session["GRUPO_ORGANIZACIONAL_CODIGO"].ToString() == "GE")
                            {
                                nivel = "2";
                                jerarquia_id = Session["GERENCIA_ID"].ToString();
                                nodePresidencia.Enabled =false;
                                nodeEmpresa.Enabled = false;
                                nodeAreas.Enabled = true;
                                if(nodeCoordinacion!=null)
                                nodeCoordinacion.Enabled = true;
                            
                            }
                            else if (Session["PERFIL_ID"].ToString() == "2" && Session["GRUPO_ORGANIZACIONAL_CODIGO"].ToString() == "JD")
                            {
                                nivel = "3";
                                jerarquia_id = Session["AREA_ID"].ToString();
                                nodeEmpresa.Enabled = false;
                                nodePresidencia.Enabled = false;
                                nodeGerencia.Enabled = false;   

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
                                linkGenerarReporte.Visible = false;

                            }
                            
                        }

                        nodePresidencia.Nodes.Add(nodeGerencia);
                        
                    }
                }

                this.rtvTransversales.Nodes.Add(nodeEmpresa);


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

        protected void LoadGrilla(string idNodo, string nivel)
        // protected void LoadGrilla(string idNodo, string nivel, string idNodoSuperior)
        {
            int result;
            int res;
            string total;

            odsEvaluacionesTransversales.SelectParameters.Clear();

            odsEvaluacionesTransversales.SelectParameters.Add("jerarquia_id", System.Data.DbType.Guid, idNodo);

            odsEvaluacionesTransversales.SelectParameters.Add("nivel", System.Data.DbType.Int16, nivel);
            if (Session["PERFIL_ID"].ToString() == "2")
            {
                odsEvaluacionesTransversales.SelectParameters.Add("usuario_id", System.Data.DbType.Guid, USUARIO.ToString());
                odsEvaluacionesTransversales.SelectParameters.Add("usuario_grupo_organizacional", System.Data.DbType.String, USUARIO_GRUPO_ORGANIZACIONAL);
            }

            rgEvaluacionesTransversalesporPersonal.DataBind();

            CalcularIndicador(idNodo, nivel);
            CalcularIndicadorGerente(idNodo, nivel);
            
            
            result = Convert.ToInt16(nivel);
            if (result > 0)
                res = result - 1;
            else
                res = result;
            //CalcularIndicadorGerente(idNodoSuperior, nivel -1)
            
            total = res.ToString();
            CalcularIndicadorEmpresa(hf_NodoParent.Value, total);
           

            
            if(lblIndicadorGerencia.Text=="0%")
                this.lblIndicadorGerencia.Text=this.lblIndicador.Text;
        }

        protected void CalcularIndicador(string idNodo, string nivel)
        {

            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();           

            BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES = new BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES();

            

            oListaEvaluacionesTransversales = BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarEvaluacionesTransversalesPorJerarquia(Guid.Parse(idNodo), Int32.Parse(nivel));

            List<object[]> lstPersonalCompetencias = oListaEvaluacionesTransversales
                /* Group the list by the element at position 0 in each item */
            .GroupBy(o => o.PERSONAL_ID)
                        /* Project the created grouping into a new object[]: */
            .Select(i => new object[]
            {
                i.Key,
                i.Average(x=>x.PORCENTAJE*100)
                //i.Average(x => x.PORCENTAJE)
            })
            .ToList();

            decimal contadorCompetenciasDesarrolladas = 0;
            decimal contadorTotalRegistros = 0;
            //string valor = string.Empty;
            //TODO: Traer de BD
            //obtenervalor(valor);
            int parametroCompetenciasDesarrolladas = obtenervalorparametroindicador();

            decimal indicador = 0;
            decimal cont = 80;

            contadorTotalRegistros = lstPersonalCompetencias.Count;

            foreach (var itemPersonas in lstPersonalCompetencias)
            {
                decimal itemsPersonas = (decimal)itemPersonas[1];
                decimal TotalPersonas = decimal.Round(itemsPersonas, 0);

                if (TotalPersonas > cont)
                    contadorCompetenciasDesarrolladas++;
            }
        
            if (contadorCompetenciasDesarrolladas > 0 && contadorTotalRegistros > 0)

                indicador = (contadorCompetenciasDesarrolladas / contadorTotalRegistros) * 100;

            this.lblIndicador.Text = Decimal.Round(indicador, 0).ToString()+"%";
            if (indicador >= parametroCompetenciasDesarrolladas)
                this.lblIndicador.ForeColor = System.Drawing.Color.Green;
            if (indicador < parametroCompetenciasDesarrolladas)
                this.lblIndicador.ForeColor = System.Drawing.Color.Red;
        }

        protected void CalcularIndicadorGerente(string idNodo, string nivel)
        {

            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesIndicador = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
            BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES = new BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES();

            oListaEvaluacionesIndicador = BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.CalcularIndicadorporGerencia(Guid.Parse(idNodo), Int32.Parse(nivel));
            List<object[]> lstPersonalCompetencias = oListaEvaluacionesIndicador
                /* Group the list by the element at position 0 in each item */
            .GroupBy(o => o.PERSONAL_ID)
                /* Project the created grouping into a new object[]: */
            .Select(i => new object[]
            {
                i.Key,
                i.Average(x=>x.PORCENTAJE*100)
            })
            .ToList();

            decimal contadorGerencia = 0;
            decimal contadorTotalRegistros = 0;
            
            //string valor = string.Empty;
            
            //obtenervalor(valor);

            int parametroCompetenciasDesarrolladas = obtenervalorparametroindicador();

            decimal indicador = 0;
            decimal cont = 80;
            contadorTotalRegistros = lstPersonalCompetencias.Count;

          
            foreach (var itemPersonas in lstPersonalCompetencias)
            {
                decimal itemsPersonas = (decimal)itemPersonas[1];
                decimal TotalPersonas = decimal.Round(itemsPersonas, 0);

                if (TotalPersonas > cont)
                    contadorGerencia++;
            }
            if (contadorGerencia > 0 && contadorTotalRegistros > 0)

                indicador = (contadorGerencia / contadorTotalRegistros) * 100;

            this.lblIndicadorGerencia.Text = Decimal.Round(indicador, 0).ToString() + "%";

            if (indicador >= parametroCompetenciasDesarrolladas)
                this.lblIndicadorGerencia.ForeColor = System.Drawing.Color.Green;
            if (indicador < parametroCompetenciasDesarrolladas)
                this.lblIndicadorGerencia.ForeColor = System.Drawing.Color.Red;
        }


        protected void CalcularIndicadorEmpresa(string idNodo, string nivel)
        {

            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesIndicador = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
            BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES = new BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES();

            oListaEvaluacionesIndicador = BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.CalcularIndicadorporEmpresa(Guid.Parse(idNodo), Int32.Parse(nivel));
            
            List<object[]> lstPersonalCompetencias = oListaEvaluacionesIndicador
                /* Group the list by the element at position 0 in each item */
            .GroupBy(o => o.PERSONAL_ID)
                /* Project the created grouping into a new object[]: */
            .Select(i => new object[]
            {
                i.Key,
                i.Average(x=>x.PORCENTAJE*100)
                //i.Sum(x => x.COMPETENCIA_NO_DESARROLLADA)
            })
            .ToList();

            decimal contadorGerencia = 0;
            decimal contadorTotalRegistros = 0;

            //string valor = string.Empty;

            //obtenervalor(valor);

            int parametroCompetenciasDesarrolladas = obtenervalorparametroindicador();

            decimal indicador = 0;
            decimal cont =80;
            contadorTotalRegistros = lstPersonalCompetencias.Count;


            foreach (var itemPersonas in lstPersonalCompetencias)
            {
                decimal itemsPersonas = (decimal)itemPersonas[1];
                decimal TotalPersonas = decimal.Round(itemsPersonas, 0);

                if (TotalPersonas > cont)
                    contadorGerencia++;
            }
            if (contadorGerencia > 0 && contadorTotalRegistros > 0)

                indicador = (contadorGerencia / contadorTotalRegistros) * 100;

            this.lblIndicadorEmpresa.Text = Decimal.Round(indicador, 0).ToString() + "%";

            if (indicador >= parametroCompetenciasDesarrolladas)
                this.lblIndicadorEmpresa.ForeColor = System.Drawing.Color.Green;
            if (indicador < parametroCompetenciasDesarrolladas)
                this.lblIndicadorEmpresa.ForeColor = System.Drawing.Color.Red;
        }

        protected void obtenervalor(string valor)
        {
            int parametro;

            valor = BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.PARAMETRO_SISTEMA.DESARROLLADAS.ToString();
            parametro = BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ParametroSistemaporValor(valor);
            BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.VALOR = parametro;
        }

        protected int obtenervalorparametroindicador()
        {
            int parametro;
            string valor;
            valor = BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.PARAMETRO_SISTEMA.INDICADOR_DESARROLLO_TRANSVERSALES.ToString();
            parametro = BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ParametroSistemaporValor(valor);
            return BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.VALOR = parametro;
        }

        protected void obtenerColorVerde(string valor)
        {
            string color;

            valor = BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.PARAMETRO_SISTEMA.VERDE.ToString();
            color = BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ParametroSistemaporValorColor(valor);
            BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.VALOR_COLOR =color;
        }

        protected void obtenerColorAmarillo(string valor)
        {
            string color;

            valor = BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.PARAMETRO_SISTEMA.AMARILLO.ToString();
            color = BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ParametroSistemaporValorColor(valor);
            BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.VALOR_COLOR = color;
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            rgEvaluacionesTransversalesporPersonal.FilterByLabel(PivotGridFilterFunction.Contains, rgEvaluacionesTransversalesporPersonal.Fields["PERSONAL_DESCRIPCION"],txtBuscar.Text);
        }
       
        protected void rgEvaluacionesTransversalesporPersonal_CellDataBound(object sender, PivotGridCellDataBoundEventArgs e)
        {       
            
            int porcentaje;

            string valor_desarrolladas = string.Empty;

            obtenervalor(valor_desarrolladas);

            int parametroCompetenciasDesarrolladas = BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.VALOR;

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
                                    if (porcentaje >= parametroCompetenciasDesarrolladas)
                                    {

                                        
                                        string valor = string.Empty;
                                       
                                        obtenerColorVerde(valor);

                                        string color =BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.VALOR_COLOR;
                                        
                                        cell.BackColor = ColorTranslator.FromHtml(color);                                        
                                    }
                                    else if (porcentaje < parametroCompetenciasDesarrolladas)
                                    {
                                        string valor = string.Empty;

                                        obtenerColorAmarillo(valor);

                                        string color = BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.VALOR_COLOR;

                                        cell.BackColor = ColorTranslator.FromHtml(color);
                                    }                                   
                                }
                                break;
                        }
                    }
                }
            }            
        }
    }
}
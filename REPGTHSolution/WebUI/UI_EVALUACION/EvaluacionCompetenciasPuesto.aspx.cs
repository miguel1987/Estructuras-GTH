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
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());

            if (!Page.IsPostBack)
            {
                try
                {
                    validarUsuarioEnDominio();
                    ValidarPerfilUsuario();
                    LoadEstructura();

                    LoadGrilla(Session["EMPRESA_ID"].ToString(), "0");


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

                            // FOR EACH ASIGNAS EL NODECOORDINADION
                            // ADD NODE COORDINACION AL NODE AREA

                            nodeGerencia.Nodes.Add(nodeAreas);
                        }


                        nodePresidencia.Nodes.Add(nodeGerencia);

                    }
                }

                this.rtvEstructuras.Nodes.Add(nodeEmpresa);


            }


            //3. Por cada Empresa Cargar una lista de objetos de tipo Presidencias               
            //4. Recorrer la lista con un foreach y añadir a cada nodo de empresa un nodo por presidencia
            //5. Por cada Empresa Cargar una lista de objetos de tipo gerencias
            //6. Recorrer la lista con un forech y añadir a cada nodo empresa un nodo por cada gerencia.
            //7. Por cada Empresa Cargar una lista de objetos de tipo areas
            //8. Recorrer la lista con un forech y añadir a cada nodo empresa un nodo por cada areas.
            //9. Por cada Empresa Cargar una lista de objetos de tipo coordinacion
            //10. Recorrer la lista con un forech y añadir a cada nodo empresa un nodo por cada coordinacion.
            //this.rtvEstructuras

        }


        /////

        protected void rtvEstructuras_NodeClick(object sender, RadTreeNodeEventArgs e)
        {
            
            //poner codigo del radgrid
           
            string idNodo = e.Node.Value.ToString();

            string nivel = rtvEstructuras.SelectedNode.Level.ToString();
            
            //Presidencia
            //if (nivel == "1")
            //    idNodo = e.Node.Parent;
            
            
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
            //RadToolTipManager2.TargetControls.Add(idNodo, nivel, true);
            rgEvaluaciones.DataBind();
        }

        protected void rgEvaluaciones_ItemDataBound(object sender, GridItemEventArgs e)
        {

            //Se añadió código para llamada a pop-up de asignación de participantes
            if (e.Item.DataItem != null)
            {
                String idPersonal = DataBinder.Eval(e.Item.DataItem, "PERSONAL_ID").ToString();
                String idPuesto = DataBinder.Eval(e.Item.DataItem, "PUESTO_ID").ToString();
                string puesto=DataBinder.Eval(e.Item.DataItem,"PUESTO_DESCRIPCION").ToString();
                string personal = DataBinder.Eval(e.Item.DataItem, "PERSONAL_DESCRIPCION").ToString();
                string departamento = DataBinder.Eval(e.Item.DataItem, "AREA").ToString();
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
            
           //GridColumn column = rgEvaluaciones.MasterTableView.GetColumn("PERSONAL_DESCRIPCION");
           //column.CurrentFilterFunction = GridKnownFunction.Contains;
           //column.CurrentFilterValue = txtBuscar.Text.Trim();
           // GridColumn masterColumn = (GridColumn)rgEvaluaciones.MasterTableView.GetColumnSafe("PERSONAL_DESCRIPCION","PUESTO_DESCRIPCION");
           //masterColumn.CurrentFilterFunction = GridKnownFunction.Contains;
           //masterColumn.CurrentFilterValue = txtBuscar.Text.Trim();
           rgEvaluaciones.Rebind();
           
        }


       


        
        }
    }




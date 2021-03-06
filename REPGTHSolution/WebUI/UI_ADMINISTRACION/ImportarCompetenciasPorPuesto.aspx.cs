﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.Data.OleDb;
using BusinessEntities;
using BusinessLogicLayer;

namespace WebUI.UI_ADMINISTRACION
{
    public partial class ImportarCompetenciasPorPuesto : System.Web.UI.Page
    {
        Guid USUARIO = Guid.Empty;
        const int MaxTotalBytes = 1048576; // 1 MB
        string path;
        UploadedFile file;
        List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> lst = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
                
                lblMensajeCompetencia.Text = string.Empty;
                cargarGrilla();
                this.AsyncUpload2.Localization.Select = "Seleccionar";
                
            }
            catch (Exception ex)
            {
                lblFile.Text = string.Empty;
                lblMensajeCompetencia.Text = "Error al Cargar Datos: Formato de Archivo no válido" + ex.Message;

            }

        }


        protected void AsyncUpload2_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            if (e.File.ContentLength < MaxTotalBytes)
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
                lblMensajeCompetencia.Text = "El tamaño del archivo debe ser menor a 1MB";

            }
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar que se haya subido un archivo
                if (AsyncUpload2.UploadedFiles.Count > 0)
                {
                    path = Server.MapPath(ConfigurationManager.AppSettings["DocumentPath"].ToString());

                    file = AsyncUpload2.UploadedFiles[0];

                    if (file.ContentLength < MaxTotalBytes)
                    {
                        file.SaveAs(path + file.GetName(), true);

                    }
                }
                lblFile.Text = file.GetName();
                cargarGrilla();
            }
            catch (Exception ex)
            {
                lblMensajeCompetencia.Text = "Error al Cargar Datos: Formato de Archivo no válido " + ex.Message;
                lblFile.Text = string.Empty;
                rgImportarCompetencias.DataSource = string.Empty;
                rgImportarCompetencias.Rebind();

            }
            lblRegistro.Text = string.Empty;
        }


        void cargarGrilla()
        {
           
                path = Server.MapPath(ConfigurationManager.AppSettings["DocumentPath"].ToString());
                string provider = ConfigurationManager.AppSettings["Provider"].ToString();
                string Extended = ConfigurationManager.AppSettings["Extended"].ToString();
                string DataSource = ConfigurationManager.AppSettings["Data_Source"].ToString();

                if (this.AsyncUpload2.UploadedFiles.Count > 0 || rgImportarCompetencias.Items.Count > 0)
                {

                    if (lblFile.Text != string.Empty)
                    {
                        string strConn = provider +
                             DataSource + path + lblFile.Text + "; " + Extended;

                        DataSet ds = new DataSet();
                        string select = ConfigurationManager.AppSettings["Select_Competencias_Por_Puesto"].ToString();
                        OleDbDataAdapter da = new OleDbDataAdapter
                        (select, strConn);
                        da.Fill(ds);
                        dynamic data = ds;
                        rgImportarCompetencias.DataSource = data;
                        rgImportarCompetencias.DataBind();
                    }
                }
                else
                {
                    rgImportarCompetencias.DataSource = String.Empty;
                }            
        }


        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (rgImportarCompetencias.Items.Count > 0)
            {
                try
                {
                    System.Threading.Thread.Sleep(2000);
                    rgImportarCompetencias.AllowPaging = false;
                    rgImportarCompetencias.Rebind();
                    string msjerror = "los siguientes códigos de usuarios no han sido registrados: ";
                    BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL = new BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL();


                    foreach (GridDataItem item in rgImportarCompetencias.MasterTableView.Items)
                    {

                        BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL OBE_COMPE_PUESTO_PERSONAL = new BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL();
                        BL_COMPETENCIA BL_COMPETENCIA = new BL_COMPETENCIA();
                        BL_COMPETENCIAS_POR_PUESTO BL_COMPETENCIAS_POR_PUESTO = new BusinessLogicLayer.BL_COMPETENCIAS_POR_PUESTO();
                        BE_PERSONAL OBE_PERSONAL = new BE_PERSONAL();
                        string Codigo = item["cod_trabajador"].Text;
                        string Codigo_personal = Codigo;
                        OBE_PERSONAL = BL_COMPETENCIA.SeleccionarPersonalporCodigo(Codigo_personal);
                        OBE_COMPE_PUESTO_PERSONAL.PUESTO_ID = OBE_PERSONAL.PUESTO_ID;
                        OBE_COMPE_PUESTO_PERSONAL.PERSONAL_ID = OBE_PERSONAL.ID;
                        string Codigo_competencia = item["cod_competencia"].Text;

                        OBE_COMPE_PUESTO_PERSONAL.COMPETENCIA_ID = Guid.Parse(BL_COMPETENCIA.seleccionarporCodigo(Codigo_competencia));
                        OBE_COMPE_PUESTO_PERSONAL.COMPETENCIA_PUESTO_VALOR_REQUERIDO = Convert.ToInt32((BL_COMPETENCIAS_POR_PUESTO.SeleccionarValorRequerido(OBE_COMPE_PUESTO_PERSONAL)));
                        OBE_COMPE_PUESTO_PERSONAL.REAL = int.Parse(item["evaluacion"].Text);
                        OBE_COMPE_PUESTO_PERSONAL.BRECHA = OBE_COMPE_PUESTO_PERSONAL.COMPETENCIA_PUESTO_VALOR_REQUERIDO - OBE_COMPE_PUESTO_PERSONAL.REAL;
                        OBE_COMPE_PUESTO_PERSONAL.COMENTARIO = item["comentario"].Text;
                        OBE_COMPE_PUESTO_PERSONAL.USUARIO_CREACION = USUARIO;
                        OBE_COMPE_PUESTO_PERSONAL.ANIO_EVALUACION = DateTime.Now.Year;

                        if (OBE_COMPE_PUESTO_PERSONAL.BRECHA < 0)
                        {
                            OBE_COMPE_PUESTO_PERSONAL.BRECHA = 0;
                        }

                        bool Existe_Competencia = BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.ExisteEvaluacionCompetenciasPuestoPersonal(OBE_COMPE_PUESTO_PERSONAL);
                        if (Existe_Competencia == true)
                        {
                            OBE_COMPE_PUESTO_PERSONAL.ESTADO_EVALUACION = (int)BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.En_Evaluacion;
                            BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.ActualizarEvaluacionCompetenciasPuestosPersonal(OBE_COMPE_PUESTO_PERSONAL);
                        }
                        else
                            if (OBE_COMPE_PUESTO_PERSONAL.PERSONAL_ID != Guid.Empty)
                                BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.InsertarEvaluacionCompetenciasPuestosPersonal(OBE_COMPE_PUESTO_PERSONAL);

                            else
                            {

                                if (msjerror.Contains(Codigo_personal) == false)
                                    msjerror += Codigo_personal + " - ";

                                lblMensajeCompetencia.Text = msjerror;
                            }
                    }

                    if (lblMensajeCompetencia.Text != String.Empty)
                        lblRegistro.Text = "Las evaluaciones fueron importadas con éxito, sin embargo " + lblMensajeCompetencia.Text;
                    else
                        lblRegistro.Text = "Las evaluaciones fueron importadas con éxito";

                    lblMensajeCompetencia.Text = String.Empty;

                    rgImportarCompetencias.AllowPaging = true;
                    rgImportarCompetencias.Rebind();
                }
                catch (Exception ex)
                {
                    lblMensajeCompetencia.Text = "Error al Importar Evaluaciones: " + ex.ToString();

                }
            }
            else
                lblRegistro.Text = "Datos Incompletos no a Cargado el archivo a Importar";
        }

    }
}
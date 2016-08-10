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
    public partial class ImportarEvaluacionesTransversales : System.Web.UI.Page
    {
        Guid USUARIO = Guid.Empty;
        const int MaxTotalBytes = 1048576; // 1 MB
        string path;
        UploadedFile file;
        List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> lst = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();

        protected void Page_Load(object sender, EventArgs e)
        {
            USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
            cargarGrilla();

        }


        protected void AsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            if (e.File.ContentLength < MaxTotalBytes)
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
                lblMensaje.Text = "El tamaño del archivo debe ser menor a 1MB";

            }
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Validar que se haya subido un archivo
            if (AsyncUpload1.UploadedFiles.Count > 0)
            {
                path = Server.MapPath(ConfigurationManager.AppSettings["DocumentPath"].ToString());

                file = AsyncUpload1.UploadedFiles[0];

                if (file.ContentLength < MaxTotalBytes)
                {
                    file.SaveAs(path + file.GetName(), true);

                }
            }

            cargarGrilla();

        }


        void cargarGrilla()
        {
            path = Server.MapPath(ConfigurationManager.AppSettings["DocumentPath"].ToString());
            string provider = ConfigurationManager.AppSettings["Provaider"].ToString();
            string file = ConfigurationManager.AppSettings["file Transversales"].ToString();
            string Extended = ConfigurationManager.AppSettings["Extencion"].ToString();
            string DataSource = ConfigurationManager.AppSettings["Data Source"].ToString();
            string strConn = provider +
                 DataSource + path + file + Extended;

            DataSet ds = new DataSet();
            string select = ConfigurationManager.AppSettings["Select Competencias Transversales"].ToString();
            OleDbDataAdapter da = new OleDbDataAdapter
            (select, strConn);
            da.Fill(ds);
            dynamic data = ds;
            RadGrid1.MasterTableView.DataSource = data;
            RadGrid1.DataBind();
        }


        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            RadGrid1.AllowPaging = false;
            RadGrid1.Rebind();
            string msjerror = "Los siguientes códigos de usuarios no han sido registrados: ";

            foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
            {

                BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES OBE_COMPE_TRANS = new BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES();
                BL_IMPORTAR_EVALUACIONES_TRANSVERSALES BL_IMPORTAR_EVALUACIONES = new BL_IMPORTAR_EVALUACIONES_TRANSVERSALES();
                BE_PERSONAL OBE_PERSONAL = new BE_PERSONAL();
                string porcentaje;
                string Codigo = item["user_id"].Text;
                string Codigo_personal = Codigo.Remove(0, 6);
                OBE_PERSONAL = BL_IMPORTAR_EVALUACIONES.SeleccionarPersonalporCodigo(Codigo_personal);
                OBE_COMPE_TRANS.CODIGO = Codigo_personal;
                OBE_COMPE_TRANS.PERSONAL_ID = OBE_PERSONAL.ID;
                OBE_COMPE_TRANS.PUESTO_ID = OBE_PERSONAL.PUESTO_ID;
                OBE_COMPE_TRANS.USUARIO_CREACION =USUARIO;
                OBE_COMPE_TRANS.ANIO = DateTime.Now.Year;
                string Codigo_competencia =item["cod_competencia"].Text;

               
                OBE_COMPE_TRANS.COMPETENCIA_TRANSVERSAL_ID = Guid.Parse(BL_IMPORTAR_EVALUACIONES_TRANSVERSALES.seleccionarporCodigo(Codigo_competencia));
                porcentaje = item["evaluacion"].Text;
                


                decimal valor = Convert.ToDecimal(porcentaje);
                valor.ToString("0.##");



                OBE_COMPE_TRANS.PORCENTAJE = valor;

                bool Existe_Evaluacion = BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ExisteEvaluacionTransversal(OBE_COMPE_TRANS);
                if (Existe_Evaluacion == true)
                    BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ActualizacionEvaluacionTransversal(OBE_COMPE_TRANS);
                else
                    if (OBE_COMPE_TRANS.PERSONAL_ID != Guid.Empty && OBE_COMPE_TRANS.COMPETENCIA_TRANSVERSAL_ID != Guid.Empty)
                        BL_IMPORTAR_EVALUACIONES_TRANSVERSALES.InsertarEvaluacionTransversales(OBE_COMPE_TRANS);
                    else
                    {

                        if (msjerror.Contains(Codigo_personal) == false)
                            msjerror += Codigo_personal + " - ";

                        lblMensaje.Text = msjerror;
                    }

               

            }
            RadGrid1.AllowPaging = true;
            RadGrid1.Rebind();

        }

    }
}
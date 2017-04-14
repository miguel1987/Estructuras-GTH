using System;
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
using System.Windows.Forms; 


namespace WebUI.UI_ADMINISTRACION
{
    public partial class ImportarEvaluacionesTransversales : System.Web.UI.Page
    {
        Guid USUARIO = Guid.Empty;
        const int MaxTotalBytes = 1048576; // 1 MB
        string path;
        UploadedFile file;
        string file_name = string.Empty;
        List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> lst = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                USUARIO = Guid.Parse(Session["PERSONAL_ID"].ToString());
                lblError.Text = string.Empty;
                

                cargarGrilla();
                this.AsyncUpload1.Localization.Select = "Seleccionar";
            }
            catch (Exception ex)
            {
                lblFile.Text = string.Empty;
                lblError.Text = "Error al Cargar Datos: Formato de Archivo no válido" + ex.Message;
            }
           
            
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
            try
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
                lblFile.Text = file.GetName();
                cargarGrilla();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al Cargar Datos: Formato de Archivo no válido" + ex.Message;
                lblFile.Text = string.Empty;
                rgImportarTransversales.DataSource = String.Empty;
                rgImportarTransversales.Rebind();
            }
            lblRegistro.Text = string.Empty;
        }


        void cargarGrilla()
        {
            path = Server.MapPath(ConfigurationManager.AppSettings["DocumentPath"].ToString());
            string provider = ConfigurationManager.AppSettings["Provider"].ToString();
            string Extended = ConfigurationManager.AppSettings["Extended"].ToString();
            string DataSource = ConfigurationManager.AppSettings["Data_Source"].ToString();
            
            if (this.AsyncUpload1.UploadedFiles.Count > 0 || rgImportarTransversales.Items.Count > 0)
            {
               
                if (lblFile.Text != string.Empty)
                {
                    string strConn = provider +
                         DataSource + path + lblFile.Text + "; " + Extended;

                    DataSet ds = new DataSet();
                    string select = ConfigurationManager.AppSettings["Select_Competencias_Transversales"].ToString();
                    OleDbDataAdapter da = new OleDbDataAdapter
                    (select, strConn);
                    da.Fill(ds);
                    dynamic data = ds;
                    
                    rgImportarTransversales.DataSource = ds;
                    rgImportarTransversales.DataBind();
                }
            }
            else
            {
                rgImportarTransversales.DataSource = String.Empty;
                
            }
        }


        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (rgImportarTransversales.Items.Count > 0)
            {
                try
                {
                    System.Threading.Thread.Sleep(2000);
                    rgImportarTransversales.AllowPaging = false;
                    rgImportarTransversales.Rebind();
                    string msjerror = "los siguientes códigos de usuarios no fueron encontrados: ";

                    foreach (GridDataItem item in rgImportarTransversales.MasterTableView.Items)
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
                        OBE_COMPE_TRANS.USUARIO_CREACION = USUARIO;
                        OBE_COMPE_TRANS.ANIO =Convert.ToInt32( rcbFecha.SelectedValue);
                        string Codigo_competencia = item["cod_competencia"].Text;


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

                    if (lblMensaje.Text != String.Empty)
                        lblRegistro.Text = "Las evaluaciones fueron importadas con éxito, sin embargo " + lblMensaje.Text;
                    else
                        lblRegistro.Text = "Las evaluaciones fueron importadas con éxito";

                    lblMensaje.Text = String.Empty;

                    rgImportarTransversales.AllowPaging = true;
                    rgImportarTransversales.Rebind();

                }
                catch (Exception ex)
                {
                    lblError.Text = "Error al Importar Evaluaciones :" + ex.ToString();

                }
            }

            else
                lblRegistro.Text = "Datos Incompletos no a Cargado el archivo a Importar";

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (rgImportarTransversales.Items.Count > 0)
            {
                MessageBox.Show("Esta seguro de Eliminar el año", "eliminar Importacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                BL_IMPORTAR_EVALUACIONES_TRANSVERSALES BL_IMPORTAR_EVALUACIONES_TRANSVERSALES = new BL_IMPORTAR_EVALUACIONES_TRANSVERSALES();
                int ANIO = Convert.ToInt32(rcbFecha.SelectedValue);
                BL_IMPORTAR_EVALUACIONES_TRANSVERSALES.EliminarEvaluacionTransversales(ANIO);
            }
            else
                MessageBox.Show("No se puede eliminar por que no se ha Importado la Informacion");
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Net;

namespace WebUI.UI_REPORTES
{
    public partial class Etiqueta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string codigoSolicitud = "0";

                //Recupero SolicitudCodigo 
                if (Context.Items.Contains("heSolicitudCodigo"))
                {
                    codigoSolicitud = Context.Items["heSolicitudCodigo"].ToString();
                }
                if (!String.IsNullOrEmpty(Context.Request.QueryString["heSolicitudCodigo"]))
                {
                    codigoSolicitud = Context.Request.QueryString["heSolicitudCodigo"];
                }                

                IReportServerCredentials irsc = new CustomReportCredentials("soporte_ipd", "1002SOsg*", "ISAMDNT");
                ReportViewer1.ServerReport.ReportServerCredentials = irsc;

                ReportViewer1.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportPath"].ToString() + ConfigurationManager.AppSettings["Etiqueta"].ToString();
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"].ToString());

                ReportParameter solicitudCodigo = new ReportParameter();
                solicitudCodigo.Name = "SOLICITUD_CODIGO";
                solicitudCodigo.Values.Add(codigoSolicitud);

                // Set the report parameters for the report
                ReportViewer1.ServerReport.SetParameters(
                    new ReportParameter[] { solicitudCodigo });

                // Render to pdf
                Byte[] results = ReportViewer1.ServerReport.Render("PDF");

                Response.ContentType = "Application/pdf";
                Response.AddHeader("content-disposition", "attachment; filename=etiqueta.pdf");
                Response.OutputStream.Write(results, 0, results.Length);

                //This is very important if you want to directly download from stream instead of file
                Response.End();

            }


        }
    }
}
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
    public partial class ReporteCompetenciasPuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                IReportServerCredentials irsc = new CustomReportCredentials("soporte_ipd", "1002SOsg*", "ISAMDNT");
                ReportViewer1.ServerReport.ReportServerCredentials = irsc;

                ReportViewer1.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportPath"].ToString() + ConfigurationManager.AppSettings["Reporte_Competencias_Puesto"].ToString();
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"].ToString());
            }

        }
    }
}
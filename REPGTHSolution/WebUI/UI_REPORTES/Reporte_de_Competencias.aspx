<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="Reporte_de_Competencias.aspx.cs" Inherits="WebUI.UI_REPORTES.Reporte_de_Competencias" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
<div class="frm_titulo01">Reporte de Competencias</div>  
<br /> 
<br /> 
<br />
<br /> 
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Width="100%" Height="300%"
        Font-Size="8pt" InteractiveDeviceInfos="(Colección)" ProcessingMode="Remote" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
    </rsweb:ReportViewer>
</asp:Content>

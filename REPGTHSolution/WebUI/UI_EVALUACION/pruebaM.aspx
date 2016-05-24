<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pruebaM.aspx.cs" Inherits="WebUI.UI_EVALUACION.pruebaM" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 255px;
        }
        .grid_header
        {}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    


    <telerik:RadPivotGrid CssClass="grid_header" ShowFilterHeaderZone="false" 
        AllowFilteringByColumn="false"  ID="RadPivotGrid2" runat="server" Culture="es-PE" 
        ColumnGrandTotalCellStyle-CssClass="HideCell" TotalsSettings-GrandTotalsVisibility="None"
         Width="98%" 
        Skin="BlackMetroTouch" AllowFiltering="False">
        <PagerStyle ChangePageSizeButtonToolTip="Change Page Size" PageSizeControlType="RadComboBox">
        </PagerStyle>
        <Fields>          
            <telerik:PivotGridRowField DataField="CODIGO" UniqueName="CODIGO"
                ZoneIndex="1">                
            </telerik:PivotGridRowField>
            <telerik:PivotGridRowField DataField="PERSONAL_DESCRIPCION" UniqueName="PERSONAL_DESCRIPCION"
                ZoneIndex="1">                
            </telerik:PivotGridRowField>
            <telerik:PivotGridRowField DataField="PUESTO_DESCRIPCION" UniqueName="PUESTO_DESCRIPCION"
                ZoneIndex="1">                
            </telerik:PivotGridRowField>
            <telerik:PivotGridColumnField DataField="COMPETENCIA_TRANSVERSAL_DESCRIPCION" UniqueName="COMPETENCIA_TRANSVERSAL_DESCRIPCION" 
                ZoneIndex="1" CellStyle-CssClass="HideCell">
            </telerik:PivotGridColumnField>
            <telerik:PivotGridColumnField DataField="EVALUACION_COMPETENCIA_TRANSVERSAL_PORCENTAJE" UniqueName="EVALUACION_COMPETENCIA_TRANSVERSAL_PORCENTAJE" 
                ZoneIndex="1">               
            </telerik:PivotGridColumnField>
           
            <telerik:PivotGridAggregateField DataField="PORCENTAJE" CellStyle-CssClass="centrado">
                <CellTemplate>
                    <asp:TextBox ID="txtScala" runat="server" Width="30px"></asp:TextBox>
                </CellTemplate>
            </telerik:PivotGridAggregateField>
        </Fields>
        
        <ConfigurationPanelSettings EnableOlapTreeViewLoadOnDemand="True"></ConfigurationPanelSettings>
    </telerik:RadPivotGrid>


</asp:Content>


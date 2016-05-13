<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pruebaM.aspx.cs" Inherits="WebUI.UI_EVALUACION.pruebaM" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 255px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <telerik:RadPivotGrid CssClass="grid_header" ShowFilterHeaderZone="false" 
        AllowFilteringByColumn="false"  ID="RadPivotGrid1" runat="server" Culture="es-PE" 
        ColumnGrandTotalCellStyle-CssClass="HideCell" TotalsSettings-GrandTotalsVisibility="None"
         Width="100%" 
        Skin="BlackMetroTouch" AllowFiltering="False">
        <PagerStyle ChangePageSizeButtonToolTip="Change Page Size" PageSizeControlType="RadComboBox">
        </PagerStyle>
        <Fields>
            <telerik:PivotGridRowField DataField="PROYECTO_ID" UniqueName="PROYECTO_ID" ZoneIndex="0"
                CellStyle-CssClass="HideCell">
            </telerik:PivotGridRowField>
            <telerik:PivotGridRowField DataField="PROYECTO_NOMBRE" UniqueName="PROYECTO_NOMBRE"
                ZoneIndex="1">
                <CellTemplate>
                    <asp:LinkButton ID="hplNombreProyecto" runat="server"></asp:LinkButton>
                </CellTemplate>
            </telerik:PivotGridRowField>
            <telerik:PivotGridColumnField DataField="INDICADOR_ID" UniqueName="INDICADOR_ID" IsHidden="True" 
                ZoneIndex="0" CellStyle-CssClass="HideCell">
            </telerik:PivotGridColumnField>
            <telerik:PivotGridColumnField DataField="INDICADOR_NOMBRE" UniqueName="INDICADOR_NOMBRE" 
                ZoneIndex="1">
                <CellTemplate>
                    <asp:LinkButton ID="hplindicador" runat="server"></asp:LinkButton>
                </CellTemplate>
            </telerik:PivotGridColumnField>
            <telerik:PivotGridAggregateField DataField="PLAN_GESTION_ESCALA_IMPACTO" CellStyle-CssClass="centrado">
                <CellTemplate>
                    <asp:TextBox ID="txtScala" runat="server" Width="30px"></asp:TextBox>
                </CellTemplate>
            </telerik:PivotGridAggregateField>
        </Fields>
        
        <ConfigurationPanelSettings EnableOlapTreeViewLoadOnDemand="True"></ConfigurationPanelSettings>
    </telerik:RadPivotGrid>
</asp:Content>


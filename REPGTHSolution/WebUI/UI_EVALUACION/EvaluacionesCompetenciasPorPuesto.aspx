<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="EvaluacionesCompetenciasPorPuesto.aspx.cs" Inherits="WebUI.UI_ARCHIVO.EvaluacionesCompetenciasPorPuesto" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">

<div class="frm_titulo01">Evaluaciones Competencias por Puestos</div>
<link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/TreeView.MySilk.css" rel="stylesheet" type="text/css" />
          <div class="margen"></div>
          <div class="margen"></div>
          <div class="derecha">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
              <td style="height: 50px">
                  <asp:Label ID="lblPuesto" runat="server" Text="Puesto:"></asp:Label>
                  <telerik:RadComboBox ID="rcbPuesto" runat="server" DataValueField="ID" DataTextField="DESCRIPCION" DataSourceID="odsPuesto" AutoPostBack="true" OnSelectedIndexChanged="rcbPuesto_SelectedIndexChanged" >
                  </telerik:RadComboBox>
                     </td>
             <td style="height: 50px">
                 <asp:Label ID="lblTipoCompetencias" runat="server" Text="Tipo Competencias"></asp:Label>
                 <telerik:RadComboBox ID="rcbCompetenciasPuesto" runat="server" 
                     DataValueField="ID" DataTextField="COMPETENCIA_TIPO_DESCRIPCION" 
                      DataSourceID="odsCompetenciasTipos1" AutoPostBack="true" OnSelectedIndexChanged="rcbCompetenciasPuesto_SelectedIndexChanged" >
                 </telerik:RadComboBox>
             
             </td>
            <td style="height: 50px"><a class="frm_boton ">Generar Reporte</a></td>
            <td width="20" style="height: 50px"></td>
            <td style="height: 50px"></td>
            <td style="height: 50px"></td>
          </tr>
            </table>
      </div>
          <div class="margen"></div>
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
              <td valign="top" width="292"><div class="cont_frm area-tree"> 
                  
                  <!--Arbol -->
                  
                 <telerik:RadTreeView style="overflow-x:hidden" ID="rtvTransversales" runat="server" OnNodeClick="rtvTransversales_NodeClick"></telerik:RadTreeView>
                  
                  <!--Arbol --> 
                  
                </div></td>
              <td width="10">&nbsp;</td>
              <td valign="top">
              <telerik:RadPivotGrid ID="rgEvaluacionesporPuesto" runat="server" ShowColumnHeaderZone="false" ShowRowHeaderZone="false" ShowDataHeaderZone="false" EnableZoneContextMenu="false"  ShowFilterHeaderZone="false"   TotalsSettings-GrandTotalsVisibility="None" AllowSorting="true" 
        AllowFilteringByColumn="false"   DataSourceID="odsCompetenciasPuesto" OnCellDataBound="rgEvaluacionesporPuesto_CellDataBound" Width="100%" Height="350px"
                       Culture="es-PE" CellPadding="2" CellSpacing="2"  
         AllowPaging="True" AllowFiltering="true" >
        <ClientSettings Scrolling-AllowVerticalScroll="true">
            </ClientSettings>
             
            <TotalsSettings RowsSubTotalsPosition="None" RowGrandTotalsPosition="None" ColumnsSubTotalsPosition="None" ColumnGrandTotalsPosition="None"  />       
        
        <PagerStyle ChangePageSizeButtonToolTip="Change Page Size" PageSizeControlType="RadComboBox">
        </PagerStyle>
        <Fields>          
            <telerik:PivotGridRowField DataField="COMPETENCIA_DESCRIPCION" UniqueName="COMPETENCIA_DESCRIPCION" CellStyle-Width="50px">                
            </telerik:PivotGridRowField>            
            <telerik:PivotGridRowField DataField="VALOR_REQUERIDO" UniqueName="VALOR_REQUERIDO" CellStyle-Width="80px">                
            </telerik:PivotGridRowField>
            <telerik:PivotGridColumnField DataField="PERSONAL_DESCRIPCION" UniqueName="PERSONAL_DESCRIPCION">
            </telerik:PivotGridColumnField>                   
            <telerik:PivotGridAggregateField DataField="VALOR_REAL" UniqueName="VALOR_REAL" CellStyle-Width="30px">
            </telerik:PivotGridAggregateField>
            <telerik:PivotGridAggregateField DataField="BRECHA" UniqueName="BRECHA" Caption="BRECHA" CellStyle-Width="30px">               
            </telerik:PivotGridAggregateField>
        </Fields>

        <TotalsSettings GrandTotalsVisibility="None" RowsSubTotalsPosition="None" 
                      RowGrandTotalsPosition="None" ColumnsSubTotalsPosition="None" 
                      ColumnGrandTotalsPosition="None"></TotalsSettings>

        
        
        <ConfigurationPanelSettings EnableOlapTreeViewLoadOnDemand="True"></ConfigurationPanelSettings>
    </telerik:RadPivotGrid>                                                                              
      </table>
          <div class="margen"></div>          
          <div class="margen"></div>
          <asp:ObjectDataSource ID="odsCompetenciasPuesto" runat="server" SelectMethod="SeleccionarEvaluaciones" TypeName="BusinessLogicLayer.BL_EVALUACIONES_COMPETENCIAS_POR_PUESTO"
            DataObjectTypeName="BusinessEntities.BE_EVALUACION_COMPETENCIA_PUESTO">    
          </asp:ObjectDataSource>

      <asp:ObjectDataSource ID="odsPuesto" runat="server" SelectMethod="SeleccionarPuestosPorJerarquia" TypeName="BusinessLogicLayer.BL_EVALUACIONES_COMPETENCIAS_POR_PUESTO"
        DataObjectTypeName="BusinessEntities.BE_PUESTO">    
      </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="odsCompetenciasTipos1" runat="server" SelectMethod="SeleccionarCompetenciasTipos"
        TypeName="BusinessLogicLayer.BL_COMPETENCIAS_TIPOS" DataObjectTypeName="BusinessEntities.BE_COMPETENCIAS_TIPOS"></asp:ObjectDataSource>
        
     

    <p class="mensaje">
         <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
       </p>
          <!--Area de Contenido -->
  
   
</asp:Content>


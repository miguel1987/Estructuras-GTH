<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="EvaluacionesTransversalesLiderazgo.aspx" Inherits="WebUI.UI_ARCHIVO.EvaluacionesTransversalesLiderazgo" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">

<div class="frm_titulo01">Evaluaciones transversales y de liderazgo</div>
<link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/TreeView.MySilk.css" rel="stylesheet" type="text/css" />
          <div class="margen"></div>
          <div class="margen"></div>
          <div class="derecha">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
            <td><a class="frm_boton ">Generar Reporte</a></td>
            <td width="20">&nbsp;</td>
            <td></td>
            <td></td>
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
              <telerik:RadPivotGrid ID="rgEvaluacionesTransversalesporPersonal" runat="server" ShowFilterHeaderZone="false"   TotalsSettings-GrandTotalsVisibility="None" AllowSorting="true" 
        AllowFilteringByColumn="false"  Culture="es-PE" DataSourceID="odsEvaluacionesTransversales" OnCellDataBound="rgEvaluacionesTransversalesporPersonal_CellDataBound" 
        Height="370px" AllowPaging="True" AllowFiltering="true" >
        
        <ClientSettings>
        
          <Scrolling AllowVerticalScroll="true" SaveScrollPosition="true"></Scrolling>
          
            
            </ClientSettings>
            <DataCellStyle Width="100px" />  
            <TotalsSettings RowsSubTotalsPosition="None" RowGrandTotalsPosition="None"
ColumnsSubTotalsPosition="None" ColumnGrandTotalsPosition="None"  />       
        
        <PagerStyle ChangePageSizeButtonToolTip="Change Page Size" PageSizeControlType="RadComboBox">
        </PagerStyle>

<%--<OlapSettings>
<XmlaConnectionSettings Encoding="utf-8"></XmlaConnectionSettings>
</OlapSettings>--%>
        <Fields>          
            <telerik:PivotGridRowField DataField="CODIGO" UniqueName="CODIGO"
               >                
            </telerik:PivotGridRowField>
            <telerik:PivotGridRowField DataField="PERSONAL_DESCRIPCION" UniqueName="PERSONAL_DESCRIPCION"
                >                
            </telerik:PivotGridRowField>
            <telerik:PivotGridRowField DataField="PUESTO_DESCRIPCION" UniqueName="PUESTO_DESCRIPCION"
                >                
            </telerik:PivotGridRowField>
            <telerik:PivotGridColumnField DataField="COMPETENCIA_TRANSVERSAL_DESCRIPCION" UniqueName="COMPETENCIA_TRANSVERSAL_DESCRIPCION" 
                ZoneIndex="1">
            </telerik:PivotGridColumnField>
            <telerik:PivotGridAggregateField DataField="PORCENTAJE" Aggregate="Sum">
               </telerik:PivotGridAggregateField>
            </Fields>

<TotalsSettings GrandTotalsVisibility="None" RowsSubTotalsPosition="None" 
                      RowGrandTotalsPosition="None" ColumnsSubTotalsPosition="None" 
                      ColumnGrandTotalsPosition="None"></TotalsSettings>

        <ConfigurationPanelSettings EnableOlapTreeViewLoadOnDemand="True"></ConfigurationPanelSettings>

<DataCellStyle Width="100px"></DataCellStyle>
    </telerik:RadPivotGrid>         
      </table>
          <div class="margen"></div>
          <div class="texto derecha"> Indicador general de colaboradores con competencias desarolladas: <span class="anotacion1"> <asp:Label ID="lblIndicador" runat="server"></asp:Label>%</span> </div>
          <div class="margen"></div>
          <asp:ObjectDataSource  ID="odsEvaluacionesTransversales" runat="server" SelectMethod="SeleccionarEvaluacionesTransversalesPorJerarquia"         
        TypeName="BusinessLogicLayer.BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES" DataObjectTypeName="BusinessEntities.BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES">
        
    </asp:ObjectDataSource>

     

    <p class="mensaje">
         <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
       </p>
          <!--Area de Contenido -->
<asp:HiddenField ID="hf_Contador" runat="server" /> 
  
   
</asp:Content>


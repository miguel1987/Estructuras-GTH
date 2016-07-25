<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="EvaluacionesTransversalesLiderazgo.aspx" Inherits="WebUI.UI_ARCHIVO.EvaluacionesTransversalesLiderazgo" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">

<div class="frm_titulo01">Evaluaciones Transversales y de Liderazgo</div>
<link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/TreeView.MySilk.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Pivot.css" rel="stylesheet" type="text/css" />
          <div class="margen"></div>
          <div class="margen"></div>
          <div class="derecha">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
              <td>
                  <telerik:RadTextBox CssClass="frmTxtBuscar"  ID="txtBuscar" runat="server" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" EnableEmbeddedSkins="false"
                 Skin="MySilk"></telerik:RadTextBox></td>
                  <td><a class="frm_boton ">Ir</a></td>
            <td><a class="frm_boton" href="../UI_REPORTES/ReporteCompetenciasTransversales.aspx" target="_blank">Generar Reporte</a></td>
            <td width="20">&nbsp;</td>
            
           
          </tr>
            </table>
      </div>
          <div class="margen"></div>
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
              <td valign="top" width="292"><div class="cont_frm area-tree"> 
                  
                  <!--Arbol -->
                  
                 <telerik:RadTreeView Style="white-space: normal"  ID="rtvTransversales" runat="server" OnNodeClick="rtvTransversales_NodeClick" ></telerik:RadTreeView>
                  
                  <!--Arbol --> 
                  
                </div></td>
              <td width="10">&nbsp;</td>
              <td valign="top">
              <telerik:RadPivotGrid ID="rgEvaluacionesTransversalesporPersonal" CssClass="Pivot" runat="server" ShowColumnHeaderZone="false" ShowRowHeaderZone="false" ShowDataHeaderZone="false" EnableZoneContextMenu="false"  ShowFilterHeaderZone="false"   TotalsSettings-GrandTotalsVisibility="None" 
               AllowSort="false" AllowFilteringByColumn="false" DataSourceID="odsEvaluacionesTransversales" OnCellDataBound="rgEvaluacionesTransversalesporPersonal_CellDataBound" width="800px"
                       Culture="es-PE" CellPadding="4" CellSpacing="4" 
                       AllowPaging="True" AllowFiltering="true" >
        
        <ClientSettings EnableFieldsDragDrop="true">  
        
        <Scrolling  AllowVerticalScroll="true" ></Scrolling>      
            </ClientSettings>
            

            
             
            <TotalsSettings RowsSubTotalsPosition="None" RowGrandTotalsPosition="None"
ColumnsSubTotalsPosition="None" ColumnGrandTotalsPosition="None"  />       
        
        
        <Fields>          
            <telerik:PivotGridRowField DataField="CODIGO" UniqueName="CODIGO" CellStyle-Width="140px" CellStyle-Height="10px"
               >                
            </telerik:PivotGridRowField>
            <telerik:PivotGridRowField DataField="PERSONAL_DESCRIPCION" UniqueName="PERSONAL_DESCRIPCION" CellStyle-Width="60px" CellStyle-Height="10px"
                >                
            </telerik:PivotGridRowField>
            <telerik:PivotGridRowField DataField="PUESTO_DESCRIPCION" UniqueName="PUESTO_DESCRIPCION" CellStyle-Width="140px" CellStyle-Height="10px"
                >                
            </telerik:PivotGridRowField>
            <telerik:PivotGridColumnField DataField="COMPETENCIA_TRANSVERSAL_DESCRIPCION" UniqueName="COMPETENCIA_TRANSVERSAL_DESCRIPCION" CellStyle-Width="30px" CellStyle-Height="10px">
            </telerik:PivotGridColumnField >
            <telerik:PivotGridAggregateField DataField="PORCENTAJE" Aggregate="Sum" CellStyle-Width="30px" CellStyle-Height="10px" DataFormatString="{0:P0}"  >
            
               </telerik:PivotGridAggregateField>
            </Fields>

<TotalsSettings GrandTotalsVisibility="None" RowsSubTotalsPosition="None" 
                      RowGrandTotalsPosition="None" ColumnsSubTotalsPosition="None" 
                      ColumnGrandTotalsPosition="None"></TotalsSettings>

        <ConfigurationPanelSettings EnableOlapTreeViewLoadOnDemand="True"></ConfigurationPanelSettings>

<DataCellStyle Width="100px"></DataCellStyle>
    </telerik:RadPivotGrid>  
        <div style="clear:both;" class="texto derecha"> Indicador general de colaboradores con competencias desarolladas: <span class="anotacion1"> <asp:Label ID="lblIndicador" runat="server"></asp:Label>%</span> 
              <br />
          Indicador general de colaboradores por Gerencia/Departamento<span class="anotacion1"> <asp:Label ID="lblIndicadorGerencia" runat="server"></asp:Label>%</span>
          
          </div>   
      </table>
      
          <div class="margen">
          </div>          
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


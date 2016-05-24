﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="EvaluacionesCompetenciasPorPuesto.aspx.cs" Inherits="WebUI.UI_ARCHIVO.EvaluacionesCompetenciasPorPuesto" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">

<div class="frm_titulo01">Evaluaciones Competencias por Puesto</div>
<link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/TreeView.MySilk.css" rel="stylesheet" type="text/css" />
          <div class="margen"></div>
          <div class="margen"></div>
          <div class="derecha">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
              <td>
                  <asp:Label ID="lblPuesto" runat="server" Text="Puesto:"></asp:Label>
                  <asp:DropDownList ID="ddlPuesto" runat="server" Height="17px" Width="135px">
                  </asp:DropDownList>   </td>
             <td>
                 <asp:Label ID="lblTipoCompetencias" runat="server" Text="Tipo Competencias"></asp:Label>
                 <asp:DropDownList ID="ddlTipoCompetencias" runat="server" Height="17px" Width="135px">
                 </asp:DropDownList>
             
             </td>
            <td><a class="frm_boton ">Generar Reporte</a></td>
            <td width="20">&nbsp;</td>
            <td><telerik:RadTextBox CssClass="frmTxtBuscar"  ID="txtBuscar" runat="server" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" EnableEmbeddedSkins="false"
                 Skin="MySilk"></telerik:RadTextBox></td>
            <td><a class="frm_boton ">Ir</a></td>
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
              <telerik:RadPivotGrid     ShowFilterHeaderZone="false"   TotalsSettings-GrandTotalsVisibility="None" AllowSorting="true" 
        AllowFilteringByColumn="false"  ID="rgEvaluacionesTransversalesporPersonal" 
                      runat="server" Culture="es-PE" DataSourceID="odsEvaluacionesTransversales"
        Height="370px" AllowPaging="True" AllowFiltering="false" >
        <ClientSettings Scrolling-AllowVerticalScroll="true">
            </ClientSettings>
            <DataCellStyle Width="100px" />  
            <TotalsSettings RowsSubTotalsPosition="None" RowGrandTotalsPosition="None"
ColumnsSubTotalsPosition="None" ColumnGrandTotalsPosition="None"  />       
        
        <PagerStyle ChangePageSizeButtonToolTip="Change Page Size" PageSizeControlType="RadComboBox">
        </PagerStyle>
        <Fields>          
            <telerik:PivotGridRowField DataField="COMPETENCIAS" UniqueName="COMPETENCIAS">                
            </telerik:PivotGridRowField>
            <telerik:PivotGridRowField DataField="TECNICAS" UniqueName="TECNICAS">                
            </telerik:PivotGridRowField>
            <telerik:PivotGridRowField DataField="REQUERIDO" UniqueName="REQUERIDO">                
            </telerik:PivotGridRowField>
            <telerik:PivotGridColumnField DataField="COMPETENCIA_TRANSVERSAL_DESCRIPCION" UniqueName="COMPETENCIA_TRANSVERSAL_DESCRIPCION" 
                ZoneIndex="1">
            </telerik:PivotGridColumnField>
        
           
            <telerik:PivotGridAggregateField DataField="PORCENTAJE" Aggregate="Sum">
               
            </telerik:PivotGridAggregateField>
        </Fields>
        
        <ConfigurationPanelSettings EnableOlapTreeViewLoadOnDemand="True"></ConfigurationPanelSettings>
    </telerik:RadPivotGrid>
                 <%-- <telerik:RadGrid ID="rgEvaluacionesTransversales" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsEvaluacionesTransversales" GridLines="None" 
                      AllowPaging="True" Width="103%" AllowSorting="True"   AllowFilteringByColumn="false"
       EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" EnableLinqExpressions="false">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        
        <MasterTableView DataSourceID="odsEvaluacionesTransversales" font-size = "9" CommandItemDisplay="None" DataKeyNames="ID"
         ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="true" ShowHeader="true" HorizontalAlign="NotSet" AutoGenerateColumns="False"   
         OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen evaluaciones registrados para los parámetros seleccionados.
            </NoRecordsTemplate>
            
             <CommandItemSettings  ShowRefreshButton="false" />       
            <Columns>
                <telerik:GridBoundColumn DataField="PUESTO_ID" HeaderText="PUESTO_ID" SortExpression="PUESTO_ID" UniqueName="PUESTO_ID" HeaderStyle-Width="90%" Display="false">                    
                </telerik:GridBoundColumn>    
                <telerik:GridBoundColumn DataField="PERSONAL_ID" HeaderText="PERSONAL_ID" SortExpression="PERSONAL_ID" UniqueName="PERSONAL_ID" HeaderStyle-Width="90%" Display="false">                    
                </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn DataField="CODIGO" HeaderText="CODIGO" SortExpression="CODIGO" UniqueName="CODIGO" 
                    AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn>  
                <telerik:GridBoundColumn DataField="PERSONAL_DESCRIPCION" HeaderText="COLABORADORES" SortExpression="PERSONAL_DESCRIPCION" UniqueName="PERSONAL_DESCRIPCION" 
                    AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn DataField="PUESTO_DESCRIPCION" HeaderText="PUESTO" SortExpression="PUESTO_DESCRIPCION" UniqueName="PUESTO_DESCRIPCION" AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn> 
                <telerik:GridBoundColumn DataField="PORCENTAJE_INSPIRAR" HeaderText="INSPIRAR_ MOTIVAR" SortExpression="PORCENTAJE_INSPIRAR" UniqueName="PORCENTAJE_INSPIRAR" AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn> 
                <telerik:GridBoundColumn DataField="PORCENTAJE_ESTRATEGICA" HeaderText="VISION_ ESTRATEGICA" SortExpression="PORCENTAJE_ESTRATEGICA" UniqueName="PORCENTAJE_ESTRATEGICA" AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn> 
                <telerik:GridBoundColumn DataField="PORCENTAJE_CONSTRUCCION" HeaderText="CONSTRUCCION_ REDES_COLABORATIVAS" SortExpression="PORCENTAJE_CONSTRUCCION" UniqueName="PORCENTAJE_CONSTRUCCION" AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PORCENTAJE_DECISION" HeaderText="JUICIO_  DECISION" SortExpression="PORCENTAJE_DECISION" UniqueName="PORCENTAJE_DECISION" AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn> 
                <telerik:GridBoundColumn DataField="PORCENTAJE_RESULTADOS" HeaderText="ORIENTACION_ RESULTADOS" SortExpression="PORCENTAJE_RESULTADOS" UniqueName="PORCENTAJE_RESULTADOS" AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn>                              
            </Columns>
            <EditFormSettings>
            <EditColumn UniqueName="EditCommandColumn" CancelText="Cancelar" UpdateText="Actualizar"
                  InsertText="Insertar">
                </EditColumn>
            </EditFormSettings>
            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
        </MasterTableView>
        
        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
        <HeaderStyle Width="200px" />
            <PagerStyle Mode="NextPrevAndNumeric" />
    </telerik:RadGrid>--%>
                
                
           
                
           
      </table>
          <div class="margen"></div>
          <div class="texto izquierda"> Indicador general de colaboradores con competencias desarolladas: <span class="anotacion1"> 62%</span> </div>
          <div class="margen"></div>
          <asp:ObjectDataSource  ID="odsEvaluacionesTransversales" runat="server" SelectMethod="SeleccionarEvaluacionesTransversalesPorJerarquia"         
        TypeName="BusinessLogicLayer.BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES" DataObjectTypeName="BusinessEntities.BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES">
        
    </asp:ObjectDataSource>

     

    <p class="mensaje">
         <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
       </p>
          <!--Area de Contenido -->
  
   
</asp:Content>

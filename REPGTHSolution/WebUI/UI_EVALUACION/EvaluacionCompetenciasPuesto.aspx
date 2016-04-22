<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="EvaluacionCompetenciasPuesto.aspx.cs" Inherits="WebUI.UI_ARCHIVO.EvaluacionCompetenciasPuesto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">

   <div class="frm_titulo01">Evaluaciones Competencias por Puesto</div>
          <div class="margen"></div>
          <div class="margen"></div>
          <div class="izquierda">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
            <td><a class="frm_boton ">Generar Reporte</a></td>
            <td width="20">&nbsp;</td>
            <td><input type="text"  class="frmTxtBuscar " value="Buscar" /></td>
            <td><a class="frm_boton ">Ir</a></td>
          </tr>
            </table>
      </div>
          <div class="margen"></div>
          <table border="0" cellspacing="0" cellpadding="0" 
        style="width: 99%; height: 726px" >
        <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" />
        <tr>
              <td valign="top" style="width: 24px"> <div class="cont_frm">
              
              <telerik:RadTreeView  ID="rtvEstructuras" runat="server"  OnNodeClick="rtvEstructuras_NodeClick" ></telerik:RadTreeView>
             </div> </td>              
              <td valign="top" style="width: 269px"> <div class="cont_frm">
              <telerik:RadGrid ID="rgEvaluaciones" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsEvaluacionesEstado"
        PageSize="10" GridLines="None" AllowPaging="True" Width="100%" AllowSorting="true" 
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" >
        

       
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        
        <MasterTableView DataSourceID="odsEvaluacionesEstado" font-size = "9" CommandItemDisplay="None" DataKeyNames="ID"
         ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="True" ShowHeader="True" HorizontalAlign="NotSet" AutoGenerateColumns="False"   
         OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen evaluaciones registrados para los parámetros seleccionados.
            </NoRecordsTemplate>
            
            <CommandItemSettings AddNewRecordText="Añadir Nuevo Registro" RefreshText="Actualizar" ExportToPdfText="Exportar a PDF"></CommandItemSettings>           
            <Columns>
                <telerik:GridBoundColumn DataField="PUESTO_ID" HeaderText="PUESTO_ID" SortExpression="PUESTO_ID" UniqueName="PUESTO_ID" HeaderStyle-Width="90%" Display="false">                    
                </telerik:GridBoundColumn>    
                <telerik:GridBoundColumn DataField="PERSONAL_ID" HeaderText="PERSONAL_ID" SortExpression="PERSONAL_ID" UniqueName="PERSONAL_ID" HeaderStyle-Width="90%" Display="false">                    
                </telerik:GridBoundColumn> 
                <telerik:GridBoundColumn DataField="CODIGO" HeaderText="CODIGO_ID" SortExpression="CODIGO" UniqueName="CODIGO" HeaderStyle-Width="90%" Display="false">                    
                </telerik:GridBoundColumn>     
                <telerik:GridBoundColumn DataField="PUESTO_DESCRIPCION" HeaderText="PUESTO" SortExpression="PUESTO_DESCRIPCION" UniqueName="PUESTO_DESCRIPCION" HeaderStyle-Font-Size="8" 
                    AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn>  
                <telerik:GridBoundColumn DataField="PERSONAL_DESCRIPCION" HeaderText="COLABORADORES" SortExpression="PERSONAL_DESCRIPCION" UniqueName="PERSONAL_DESCRIPCION" HeaderStyle-Font-Size="8" HeaderStyle-Width="260px"  
                    AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn DataField="ESTADO_DESCRIPCION" HeaderText="ESTADO_DESCRIPCION" SortExpression="ESTADO_DESCRIPCION" UniqueName="ESTADO" AutoPostBackOnFilter="true" HeaderStyle-Font-Size="8" >                    
                </telerik:GridBoundColumn>                               
                <telerik:GridEditCommandColumn ButtonType="ImageButton" 
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif" EditText="Actualizar">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Gerencia?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Gerencia Eliminada" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarGerencia">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                </telerik:GridButtonColumn>
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
    </telerik:RadGrid>
  </div> </td>
              <%--recuperar aca %>
              <%--<td valign="top"><table border="0" cellpadding="0" cellspacing="0" class="grid">
                  <tbody>
                  <tr>
                      <th class="grid_header">Código </th>
                      <th class="grid_header">Nombre </th>
                      <th class="grid_header">Puesto </th>
                      <th class="grid_header">Inspirar y Motivar </th>
                      <th class="grid_header">Visión Estratégica </th>
                      <th class="grid_header">Contribución y Redes Corporativas </th>
                      <th class="grid_header">Orienteción a Resultados</th>
                      <th class="grid_header">Indicador por Puesto</th>
                    </tr>
                  <tr>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                    </tr>
                  <tr>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                    </tr>
                  <tr>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                    </tr>
                  <tr>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                    </tr>
                  <tr>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                      <td class="grid_fila1">PageMaker including </td>
                    </tr>
                  <tr>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                      <td class="grid_fila2">PageMaker including </td>
                    </tr>
                </tbody>
                </table>
            <div class="salto"> </div>
            <table class="grid_linea" width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                <td><table border="0" cellpadding="2" cellspacing="2" class="paginacion">
                    <tbody>
                      <tr>
                        <td height="30"><a href="#"><img src="../Images/pag_primero.png" width="19" height="24"></a></td>
                        <td><a href="#"><img src="../Images/pag_anterior.png" width="19" height="24"></a></td>
                        <td><a href="#" class="pag">1</a><a href="#" class="pag">2</a><a class="pag_activo" href="#">3</a><a href="#" class="pag">4</a><a href="#" class="pag">5</a></td>
                        <td><a href="#"><img src="../Images/pag_siguiente.png" width="19" height="24"></a></td>
                        <td><a href="#"><img src="../Images/pag_ultimo.png" width="19" height="24"></a></td>
                      </tr>
                    </tbody>
                  </table></td>
                <td>&nbsp;</td>
                <td><div class="texto izquierda"> Página <span class="anotacion2">1</span> de <span class="anotacion2">10</span> elementos </div></td>
              </tr>
                </table></td>
            </tr>--%>
      </table>
          <div class="margen"></div>
          <div class="texto izquierda"> Indicador general de colaboradores con competencias desarolladas: <span class="anotacion1"> 62%</span> </div>
          <div class="margen"></div>
   <%-- <telerik:RadGrid runat="server" ID="rgEvaluaciones" AutoGenerateColumns="False" CellSpacing="0"
        Culture="es-ES" GridLines="None" 
          PageSize="10" AllowPaging="True" 
        AllowFilteringByColumn="True"  AllowSorting="true" Skin="MySilk"         
        EnableEmbeddedSkins="False" ImagesPath="../Styles/Grid/">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView AllowFilteringByColumn="True" CommandItemDisplay="Top" EditMode="EditForms"
            ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="True" ShowHeader="True"
            Width="100%" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen evaluaciones registrados para los parámetros seleccionados.
            </NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="ID" DataType="System.Guid" FilterControlAltText="Filter ID column"
                    HeaderText="ID" SortExpression="ID" UniqueName="ID" Display="false" ReadOnly="true"
                    ForceExtractValue="Always">
                </telerik:GridBoundColumn> 
                <telerik:GridTemplateColumn HeaderText="PUESTO" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" UniqueName="PUESTO" 
                AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false" DataField="PUESTO" SortExpression="PUESTO">                  
                </telerik:GridTemplateColumn>  
                <telerik:GridTemplateColumn HeaderText="COLABORADOR" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" UniqueName="COLABORADOR" 
                AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false" DataField="COLABORADOR" SortExpression="COLABORADOR">                  
                </telerik:GridTemplateColumn>  
                <telerik:GridTemplateColumn HeaderText="ESTADO" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" UniqueName="ESTADO" 
                AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false" DataField="ESTADO" SortExpression="ESTADO">                  
                </telerik:GridTemplateColumn>  
                <telerik:GridEditCommandColumn ButtonType="ImageButton" EditText="Actualizar"
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Está seguro que deseas eliminar esta evaluación?"
                    ConfirmDialogType="RadWindow" ConfirmTitle="Evaluación Eliminada" ButtonType="ImageButton"
                    CommandName="Delete" Text="Eliminar" UniqueName="EliminarEvaluacion" ImageUrl="../Styles/Grid/Delete.gif">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                </telerik:GridButtonColumn>                                                                    
             </Columns>
              <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
        </MasterTableView>
        <ClientSettings EnableRowHoverStyle="true">
            <Selecting AllowRowSelect="True"></Selecting>
        </ClientSettings>
        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
        <HeaderContextMenu EnableEmbeddedScripts="False">
        </HeaderContextMenu>
    </telerik:RadGrid>
    <asp:ObjectDataSource ID="ObjectDataSourceEvaluaciones" runat="server" SelectMethod="SeleccionarEvaluacionesPorJerarquia" TypeName="BusinessLogicLayer.BL_EVALUACION_COMPETENCIAS_PUESTO"></asp:ObjectDataSource>--%>
   <%--<asp:ObjectDataSource ID="ObjectDataSourceEvaluaciones" runat="server" SelectMethod="SeleccionarEvaluacionesPorJerarquia"         
        TypeName="BusinessLogicLayer.BL_EVALUACION_COMPETENCIAS_PUESTO" >
    </asp:ObjectDataSource>--%>
    <asp:ObjectDataSource ID="odsEvaluacionesEstado" runat="server" SelectMethod="SeleccionarEvaluacionesPorJerarquia"         
        TypeName="BusinessLogicLayer.BL_EVALUACION_COMPETENCIAS_PUESTO" DataObjectTypeName="BusinessEntities.BE_EVALUACION_COMPETENCIA_PUESTO">
    </asp:ObjectDataSource>
     <p class="mensaje">
         <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
       </p>
    </div> 
    <br />
    <br />      
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="EvaluacionCompetenciasPuesto.aspx.cs" Inherits="WebUI.UI_EVALUACION.EvaluacionCompetenciasPuesto" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
    <link href="../Styles/jquery.lightbox.css" rel="stylesheet" type="text/css" />
  <link href="../Styles/jquery.lightbox.ie6.css" rel="stylesheet" type="text/css" />
  <script src="../Scripts/jquery.lightbox.js" type="text/javascript"></script>

 <link href="../Styles/jquery.lightbox.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/jquery.lightbox.ie6.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/TreeView.MySilk.css" rel="stylesheet" type="text/css" />
    
 <script type="text/javascript">
     jQuery(document).ready(function () {
         jQuery('.lightbox').lightbox();
     });

 </script>

  <div class="frm_titulo01">Evaluar Competencias Técnicas y Habilidades</div>
          <div class="margen"></div>
          <div class="margen"></div>

          <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
              <td valign="top" width="292"><div class="cont_frm area-tree"> 
              
                  
                  <!--Arbol -->
                  
                    <telerik:RadTreeView Style="white-space: normal"  EnableDragAndDrop="false" EnableDragAndDropBetweenNodes="false"  ID="rtvEstructuras" runat="server"  
                      OnNodeClick="rtvEstructuras_NodeClick" EnableEmbeddedSkins="False" 
                          Skin="Default" ImagesPath="../Styles/TreeView/"   >
                        <collapseanimation type="Linear" />
                    <CollapseAnimation Type="InCubic"></CollapseAnimation>
                    
                      </telerik:RadTreeView>
                  </div>
                  
                  <!--Arbol --> 
                  
                </td>
              <td width="10">&nbsp;</td>
              <td valign="top">                                                   
              <div class="izquierda frm_titulo02">  
              <asp:Label ID="lblArea" runat="server"> </asp:Label>
              </div>                                    
            <div class="derecha">
                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                      <td><telerik:RadTextBox CssClass="frmTxtBuscar"  ID="txtBuscar" runat="server" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" EnableEmbeddedSkins="false"
                 Skin="MySilk"></telerik:RadTextBox></td>
                      <td><a class="frm_boton ">Ir</a></td>                    
                    </tr>
              </table>
                </div>
            <div class="margen"></div>
            
            <!--Grilla -->
                  <telerik:RadGrid ID="rgEvaluaciones" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsEvaluacionesEstado" GridLines="None" 
                      AllowPaging="True" Width="103%" AllowSorting="True"  
                      OnItemDataBound="rgEvaluaciones_ItemDataBound" AllowFilteringByColumn="false"
       EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" EnableLinqExpressions="false">      
                      <groupingsettings casesensitive="False" />
        <ExportSettings>
            <Pdf PageWidth="" />
<Pdf PageWidth=""></Pdf>
        </ExportSettings>
        
        <MasterTableView DataSourceID="odsEvaluacionesEstado" CommandItemDisplay="None" DataKeyNames="ID"
         ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="True" ShowHeader="True" HorizontalAlign="NotSet" AutoGenerateColumns="false"   
         OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen evaluaciones registrados para los parámetros seleccionados.
            </NoRecordsTemplate>           
            <CommandItemSettings AddNewRecordText="Añadir Nuevo Registro" RefreshText="Actualizar" ExportToPdfText="Exportar a PDF"></CommandItemSettings>           

<RowIndicatorColumn Visible="True" FilterImageUrl="../Styles/Grid/Filter.gif" SortAscImageUrl="../Styles/Grid/SortAsc.gif" SortDescImageUrl="../Styles/Grid/SortDesc.gif" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn ExpandImageUrl="../Styles/Grid/SinglePlus.gif" CollapseImageUrl="../Styles/Grid/SingleMinus.gif" Visible="True" FilterImageUrl="../Styles/Grid/Filter.gif" SortAscImageUrl="../Styles/Grid/SortAsc.gif" SortDescImageUrl="../Styles/Grid/SortDesc.gif" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="PUESTO_ID" HeaderText="PUESTO_ID" SortExpression="PUESTO_ID" UniqueName="PUESTO_ID" HeaderStyle-Width="90%" Display="false">                    
<HeaderStyle Width="90%"></HeaderStyle>
                </telerik:GridBoundColumn>    
                <telerik:GridBoundColumn DataField="PERSONAL_ID" HeaderText="PERSONAL_ID" SortExpression="PERSONAL_ID" UniqueName="PERSONAL_ID" HeaderStyle-Width="90%" Display="false">                    
<HeaderStyle Width="90%"></HeaderStyle>
                </telerik:GridBoundColumn> 
                <telerik:GridBoundColumn DataField="AREA" HeaderText="DEPARTAMENTO" SortExpression="AREA" UniqueName="AREA" HeaderStyle-Width="90%" Display="false">
<HeaderStyle Width="90%"></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="CODIGO" HeaderText="CODIGO_ID" SortExpression="CODIGO" UniqueName="CODIGO" HeaderStyle-Width="90%" Display="false">                    
<HeaderStyle Width="90%"></HeaderStyle>
                </telerik:GridBoundColumn>     
                <telerik:GridBoundColumn DataField="PUESTO_DESCRIPCION" HeaderText="PUESTO" SortExpression="PUESTO_DESCRIPCION" UniqueName="PUESTO_DESCRIPCION"  
                    AutoPostBackOnFilter="true" >                    
                </telerik:GridBoundColumn>  
                <telerik:GridBoundColumn DataField="PERSONAL_DESCRIPCION" HeaderText="COLABORADORES" SortExpression="PERSONAL_DESCRIPCION" UniqueName="PERSONAL_DESCRIPCION" HeaderStyle-Font-Size="8" HeaderStyle-Width="260px"  
                    AutoPostBackOnFilter="true">                      
<HeaderStyle Font-Size="8pt" Width="260px"></HeaderStyle>
                </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn DataField="ESTADO_DESCRIPCION" HeaderText="ESTADO" SortExpression="ESTADO_DESCRIPCION" UniqueName="ESTADO" AutoPostBackOnFilter="true" HeaderStyle-Font-Size="8" >                    
<HeaderStyle Font-Size="8pt"></HeaderStyle>
                </telerik:GridBoundColumn>                                      
               <telerik:GridTemplateColumn HeaderText="EVALUAR" HeaderStyle-Width="30px" UniqueName="EVALUAR" EditFormHeaderTextFormat = "">
                    <ItemTemplate>
                        <asp:HyperLink ID="hplEvaluarPersonal" ImageUrl="../images/ico-edit.png" ToolTip="Evaluar Colaborador" Text="Evaluar Colaborador" runat="server" CssClass="lightbox"></asp:HyperLink>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:HyperLink ID="hplEvaluarPersonal2" ImageUrl="../images/ico-edit.png" ToolTip="Evaluar Colaborador" Text="Evaluar Colaborador" runat="server" CssClass="lightbox"></asp:HyperLink>
                    </EditItemTemplate>
                    <HeaderStyle Width="80px"></HeaderStyle>
                </telerik:GridTemplateColumn>                
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

<HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
    </telerik:RadGrid>
            <!--Grilla -->
             <asp:ObjectDataSource ID="odsEvaluacionesEstado" runat="server" SelectMethod="SeleccionarEvaluacionesPorJerarquia"         
        TypeName="BusinessLogicLayer.BL_EVALUACION_COMPETENCIAS_PUESTO" DataObjectTypeName="BusinessEntities.BE_EVALUACION_COMPETENCIA_PUESTO">
    </asp:ObjectDataSource>    
     <p class="mensaje">
         <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
       </p>
           </td>
            </tr>
      </table>   
</asp:Content>


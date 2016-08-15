<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="CompetenciasPorPuesto.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.CompetenciasPorPuesto" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
  <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" /> 
  <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript">
      function showRadConfirm(text) {
          radalert(text, null, null, "Eliminar Competencias Por Puesto");
      }
  </script>        
          <div class="frm_titulo01">Administrar Competencias Por Puesto</div>          
       
          <div class="margen"></div>
          <div class="izquierda">        
      </div>
          <div class="derecha">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
            <td><telerik:RadTextBox CssClass="frmTxtBuscar"  ID="txtBuscar" runat="server" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" EnableEmbeddedSkins="false"
                 Skin="MySilk"></telerik:RadTextBox></td>
            <td><asp:HyperLink class="frm_boton" ID="linkBuscar" runat="server">Ir</asp:HyperLink></td>
            <td><a class="frm_boton" href="../UI_REPORTES/Reporte_Competencias_por_Puesto.aspx" target="_blank" runat="server" id="linkGenerarReporte">Generar Reporte</a></td>
            <td></td>
          </tr>
            </table>
      </div>
    <table style="width: 100%">
        <tr>
            <td style="text-align: left; width: 25%">
                <asp:Label ID="lblEmpresa" runat="server" CssClass="estilosLabel" Text="EMPRESA:"></asp:Label>
            </td>
            <td style="text-align: left; width: 25%">
                <telerik:RadComboBox ID="rcbEmpresaCab" Runat="server" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsEmpresa" LoadingMessage="Cargando..." AutoPostBack="true"  OnSelectedIndexChanged="rcbEmpresaCab_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td style="text-align: left; width: 25%">
               <asp:Label ID="lblGerencia" runat="server" CssClass="estilosLabel" Text="GERENCIA:"></asp:Label></td>
            <td style="text-align: left; width: 167px">
               <telerik:RadComboBox ID="rcbGerenciaCab" Runat="server" DataValueField="ID" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                  AllowCustomText="true"  DataSourceID="odsGerencia" LoadingMessage="Cargando..." AutoPostBack="true"  OnSelectedIndexChanged="rcbGerenciaCab_SelectedIndexChanged"> 
                </telerik:RadComboBox>
            </td>
            <td style="text-align: left; width: 25%">
               <asp:Label ID="lblDepartamento" runat="server" CssClass="estilosLabel" Text="DEPARTAMENTO:"></asp:Label></td>
            <td style="text-align: left">
                <telerik:RadComboBox ID="rcbAreaCab" Runat="server" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsArea" LoadingMessage="Cargando..." AutoPostBack="true"  OnSelectedIndexChanged="rcbAreaCab_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td style="text-align: left; width: 25%">
               <asp:Label ID="lblCoordinacion" runat="server" CssClass="estilosLabel" Text="COORDINACION:"></asp:Label></td>
            <td style="width: 171px">
                <telerik:RadComboBox ID="rcbCoordinacionCab" Runat="server" DataValueField="ID"
                            MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsCoordinacion" LoadingMessage="Cargando..."  AutoPostBack="true" OnSelectedIndexChanged="rcbCoordinacionCab_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
        </tr>       
    </table>
          <div class="margen"></div>
      <table border="0" cellpadding="0" cellspacing="0" class="grid">   
      </table>    
 <telerik:RadGrid ID="rgCompetenciasPuesto" HorizontalAlign="Center" runat="server" EditMode="EditForms" 
        CellSpacing="0" Culture="es-ES" DataSourceID="odsCompetenciaPuesto"
        OnInsertCommand="rgCompetenciasPuesto_InsertCommand" OnDeleteCommand="rgCompetenciasPuesto_DeleteCommand"
        OnUpdateCommand="rgCompetenciasPuesto_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="100%" 
        OnItemDataBound="rgCompetenciasPuesto_ItemDataBound" AllowSorting="true" AllowFilteringByColumn="False"
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto" EnableLinqExpressions="false">
        <groupingsettings casesensitive="False" />
        <ExportSettings>
            <Pdf PageWidth="" />
<Pdf PageWidth=""></Pdf>
        </ExportSettings>
        <MasterTableView DataSourceID="odsCompetenciaPuesto"
        CommandItemDisplay="Top" DataKeyNames="ID" HorizontalAlign="NotSet" AutoGenerateColumns="False" EditMode="EditForms" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen Competencias por Puesto registradas.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Competencias Por Puesto" RefreshText="Actualizar"></CommandItemSettings>   

<RowIndicatorColumn Visible="True" FilterImageUrl="../Styles/Grid/Filter.gif" SortAscImageUrl="../Styles/Grid/SortAsc.gif" SortDescImageUrl="../Styles/Grid/SortDesc.gif" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn ExpandImageUrl="../Styles/Grid/SinglePlus.gif" CollapseImageUrl="../Styles/Grid/SingleMinus.gif" Visible="True" FilterImageUrl="../Styles/Grid/Filter.gif" SortAscImageUrl="../Styles/Grid/SortAsc.gif" SortDescImageUrl="../Styles/Grid/SortDesc.gif" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>                                                  
                <telerik:GridTemplateColumn  HeaderText="EMPRESA" HeaderStyle-Width="10%" SortExpression="oBE_EMPRESA.DESCRIPCION" UniqueName="oBE_EMPRESA.DESCRIPCION" DataField="oBE_EMPRESA.DESCRIPCION" Display="false"
                AutoPostBackOnFilter="true">                       
                        <ItemTemplate>
                            <%# Eval("oBE_EMPRESA.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbEmpresa" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsEmpresa" LoadingMessage="Cargando..." Width="50%" AutoPostBack="true" OnSelectedIndexChanged="rcbEmpresa_SelectedIndexChanged">
                            </telerik:RadComboBox>
                                
                        </EditItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

                    </telerik:GridTemplateColumn>   

                               <telerik:GridTemplateColumn  HeaderText="GERENCIA" HeaderStyle-Width="10%" SortExpression="oBE_GERENCIA.DESCRIPCION" UniqueName="oBE_GERENCIA.DESCRIPCION" DataField="oBE_GERENCIA.DESCRIPCION" Display="false"
                AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_GERENCIA.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbGerencia" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsGerencia" LoadingMessage="Cargando..." Width="50%" AutoPostBack="true" OnSelectedIndexChanged="rcbGerencia_SelectedIndexChanged">
                            </telerik:RadComboBox>
                               
                        </EditItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

                    </telerik:GridTemplateColumn> 

                    <telerik:GridTemplateColumn  HeaderText="AREA" HeaderStyle-Width="10%" SortExpression="oBE_AREA.DESCRIPCION" UniqueName="oBE_AREA.DESCRIPCION" DataField="oBE_AREA.DESCRIPCION" Display="false"
                AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_AREA.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbArea" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsArea" LoadingMessage="Cargando..." Width="50%" AutoPostBack="true" OnSelectedIndexChanged="rcbArea_SelectedIndexChanged">
                            </telerik:RadComboBox>
                                
                        </EditItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

                    </telerik:GridTemplateColumn> 

                    <telerik:GridTemplateColumn  HeaderText="COORDINACION" HeaderStyle-Width="10%" SortExpression="oBE_COORDINACION.DESCRIPCION" UniqueName="oBE_COORDINACION.DESCRIPCION" DataField="oBE_COORDINACION.DESCRIPCION" Display="false"
                AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_COORDINACION.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbCoordinacion" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsCoordinacion" LoadingMessage="Cargando..." Width="50%" AutoPostBack="true" OnSelectedIndexChanged="rcbCoordinacion_SelectedIndexChanged">
                            </telerik:RadComboBox>
                                 
                        </EditItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn  HeaderText="PUESTO" HeaderStyle-Width="50%" SortExpression="oBE_PUESTO.DESCRIPCION" UniqueName="oBE_PUESTO.DESCRIPCION" DataField="oBE_PUESTO.DESCRIPCION"
                AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_PUESTO.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbPuesto" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsPuesto" LoadingMessage="Cargando..." Width="50%">
                            </telerik:RadComboBox>                               
                        </EditItemTemplate>

<HeaderStyle Width="30%"></HeaderStyle>
                    </telerik:GridTemplateColumn> 
                    <telerik:GridTemplateColumn  HeaderText="TIPO COMPETENCIA" HeaderStyle-Width="25%" SortExpression="oBE_COMPETENCIA_TIPO.COMPETENCIA_TIPO_DESCRIPCION" UniqueName="oBE_COMPETENCIA_TIPO.COMPETENCIA_TIPO_DESCRIPCION" DataField="oBE_COMPETENCIA_TIPO.COMPETENCIA_TIPO_DESCRIPCION"
                    AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_COMPETENCIA_TIPO.COMPETENCIA_TIPO_DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbTipoCompetencia" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="COMPETENCIA_TIPO_DESCRIPCION" AllowCustomText="true" DataSourceID="odsTipoCompetencia" LoadingMessage="Cargando..." Width="50%" AutoPostBack="true" OnSelectedIndexChanged="rcbTipoCompetencia_SelectedIndexChanged">
                            </telerik:RadComboBox>                             
                        </EditItemTemplate>

<HeaderStyle Width="25%"></HeaderStyle>
                    </telerik:GridTemplateColumn>   
                    <telerik:GridTemplateColumn HeaderText="COMPETENCIA" HeaderStyle-Width="25%" SortExpression="oBE_COMPETENCIA.DESCRIPCION" DataField="oBE_COMPETENCIA.DESCRIPCION" UniqueName="oBE_COMPETENCIA.DESCRIPCION"
                    AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_COMPETENCIA.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbCompetencia" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsCompetencia" LoadingMessage="Cargando..." Width="50%">
                            </telerik:RadComboBox>                          
                        </EditItemTemplate>

<HeaderStyle Width="25%"></HeaderStyle>
                    </telerik:GridTemplateColumn> 
                    <telerik:GridBoundColumn DataField="COMPETENCIA_PUESTO_VALOR_REQUERIDO"
                    HeaderText="VALOR REQUERIDO" SortExpression="COMPETENCIA_PUESTO_VALOR_REQUERIDO" UniqueName="COMPETENCIA_PUESTO_VALOR_REQUERIDO" HeaderStyle-Width="10%">                  
<HeaderStyle Width="10%"></HeaderStyle>
                </telerik:GridBoundColumn>                    
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" EditText="Actualizar"
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Competencia por Puesto?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Eliminar Competencia Por Puesto " ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarComptenciaPorPuesto">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings>
             <EditColumn UniqueName="EditCommandColumn" CancelText="Cancelar" UpdateText="Actualizar" InsertText="Insertar">
             </EditColumn>
            </EditFormSettings>
            <PagerStyle Mode="NextPrevAndNumeric" PageSizeLabelText="Nro. Items por Página:" PagerTextFormat="{4} Página {0} de {1}, Filas {2} a {3} de {5}" />            
        </MasterTableView>             

<PagerStyle PrevPageImageUrl="../Styles/Grid/PagingPrev.gif" NextPageImageUrl="../Styles/Grid/PagingNext.gif" FirstPageImageUrl="../Styles/Grid/PagingFirst.gif" LastPageImageUrl="../Styles/Grid/PagingLast.gif" PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False" EnableEmbeddedSkins="False"></FilterMenu>

<HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
    </telerik:RadGrid>
    <br />
    <div>
    <asp:ValidationSummary ID="ValidationSummary" ForeColor="Red" 
        HeaderText="(*) Campos Obligatorios."
        DisplayMode="SingleParagraph"
        EnableClientScript="true"
        runat="server"/>
        </div>  
     <asp:ObjectDataSource ID="odsCompetenciaPuesto" runat="server" SelectMethod="SeleccionarCompetenciasPorPuesto"         
        TypeName="BusinessLogicLayer.BL_COMPETENCIAS_POR_PUESTO">    
    </asp:ObjectDataSource>  
    <asp:ObjectDataSource ID="odsPuesto" runat="server" SelectMethod="SeleccionarPuesto"         
        TypeName="BusinessLogicLayer.BL_PUESTO">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsCompetencia" runat="server" SelectMethod="SeleccionarCompetencias"         
        TypeName="BusinessLogicLayer.BL_COMPETENCIA">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsEmpresa" runat="server" SelectMethod="SeleccionarEmpresa"         
        TypeName="BusinessLogicLayer.BL_EMPRESA">
    </asp:ObjectDataSource>  
    <asp:ObjectDataSource ID="odsTipoCompetencia" runat="server" SelectMethod="SeleccionarCompetenciasTipos"
        TypeName="BusinessLogicLayer.BL_COMPETENCIAS_TIPOS" DataObjectTypeName="BusinessEntities.BE_COMPETENCIAS_TIPOS"></asp:ObjectDataSource>    
    <asp:ObjectDataSource ID="odsGerencia" runat="server" SelectMethod="SeleccionarGerencia"
    TypeName="BusinessLogicLayer.BL_GERENCIA"></asp:ObjectDataSource> 
    <asp:ObjectDataSource ID="odsArea" runat="server" SelectMethod="SeleccionarArea"
    TypeName="BusinessLogicLayer.BL_AREA"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsCoordinacion" runat="server" SelectMethod="SeleccionarCoordinacion"
    TypeName="BusinessLogicLayer.BL_COORDINACION"></asp:ObjectDataSource>

        


    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
</asp:Content>
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="Personal.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.Personal" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
  <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" /> 
  <script type="text/javascript">
      function showRadConfirm(text) {
          radalert(text, null, null, "Eliminar Área");
      }
  </script>        
          <div class="frm_titulo01">Administrar Personal</div>          
       
          <div class="margen"></div>
          <div class="izquierda">        
      </div>
          <div class="derecha">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
            <td><telerik:RadTextBox CssClass="frmTxtBuscar"  ID="txtBuscar" runat="server" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" EnableEmbeddedSkins="false"
                 Skin="MySilk"></telerik:RadTextBox></td>
            <td><asp:HyperLink class="frm_boton" ID="linkBuscar" runat="server">Ir</asp:HyperLink>
            </td>
          </tr>
            </table>
      </div>
          <div class="margen"></div>
      <table border="0" cellpadding="0" cellspacing="0" class="grid">   
      </table>    
      <telerik:RadGrid ID="rgPersonal" HorizontalAlign="Center" runat="server" CellSpacing="0"
       Culture="es-ES" DataSourceID="odsPersonal" OnInsertCommand="rgPersonal_InsertCommand"
        OnDeleteCommand="rgPersonal_DeleteCommand" OnUpdateCommand="rgPersonal_UpdateCommand" AllowFilteringByColumn="false" 
        PageSize="10" GridLines="None" AllowPaging="True" Width="80%" OnItemDataBound="rgPersonal_ItemDataBound"
        AllowSorting="true" ImagesPath="../Styles/Grid/" EnableEmbeddedSkins="False"
        Skin="MySilk" Style="margin: auto" EnableLinqExpressions="false">
          <groupingsettings casesensitive="False" />
        <ExportSettings>
            <Pdf PageWidth="" />
<Pdf PageWidth=""></Pdf>
        </ExportSettings>
        <MasterTableView CommandItemDisplay="Top" DataKeyNames="ID" HorizontalAlign="NotSet" DataSourceID="odsPersonal"
            AutoGenerateColumns="False" EditMode="EditForms" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existe personal registrado.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Personal" RefreshText="Actualizar" ExportToPdfText="Exportar a PDF"></CommandItemSettings>                        

<RowIndicatorColumn Visible="True" FilterImageUrl="../Styles/Grid/Filter.gif" SortAscImageUrl="../Styles/Grid/SortAsc.gif" SortDescImageUrl="../Styles/Grid/SortDesc.gif" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn ExpandImageUrl="../Styles/Grid/SinglePlus.gif" CollapseImageUrl="../Styles/Grid/SingleMinus.gif" Visible="True" FilterImageUrl="../Styles/Grid/Filter.gif" SortAscImageUrl="../Styles/Grid/SortAsc.gif" SortDescImageUrl="../Styles/Grid/SortDesc.gif" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="CODIGO_TRABAJO" 
                    HeaderText="CODIGO" SortExpression="CODIGO_TRABAJO" UniqueName="CODIGO_TRABAJO" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NOMBRES"
                    HeaderText="NOMBRES" SortExpression="NOMBRES" UniqueName="NOMBRES"  
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="APELLIDO_PATERNO"
                    HeaderText="APELLIDO PATERNO" SortExpression="APELLIDO_PATERNO" UniqueName="APELLIDO_PATERNO" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="APELLIDO_MATERNO" 
                    HeaderText="APELLIDO MATERNO" SortExpression="APELLIDO_MATERNO" UniqueName="APELLIDO_MATERNO" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>                                               
                <telerik:GridBoundColumn DataField="CORREO"
                    HeaderText="CORREO" SortExpression="CORREO" UniqueName="CORREO" AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn DataField="NOMBRE_USUARIO" 
                    HeaderText="NOMBRE USUARIO" SortExpression="NOMBRE_USUARIO" UniqueName="NOMBRE_USUARIO" AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>             
                <telerik:GridTemplateColumn HeaderText="EMPRESA" HeaderStyle-Width="250px" SortExpression="oBE_EMPRESA.DESCRIPCION" DataField="oBE_EMPRESA.DESCRIPCION" UniqueName="oBE_EMPRESA.DESCRIPCION" 
                AutoPostBackOnFilter="true">
                    <ItemTemplate>
                        <%# Eval("oBE_EMPRESA.DESCRIPCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox Width="50%" runat="server" ID="rcbEmpresa" DataValueField="ID"
                            MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsEmpresa" LoadingMessage="Cargando..." AutoPostBack="true" OnSelectedIndexChanged="rcbEmpresa_SelectedIndexChanged">
                        </telerik:RadComboBox>                        
                    </EditItemTemplate>

<HeaderStyle Width="250px"></HeaderStyle>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="SEDE" HeaderStyle-Width="250px" SortExpression="oBE_SEDE.DESCRIPCION" DataField="oBE_SEDE.DESCRIPCION" UniqueName="oBE_SEDE.DESCRIPCION"
                AutoPostBackOnFilter="true">
                    <ItemTemplate>
                        <%# Eval("oBE_SEDE.DESCRIPCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox Width="50%" runat="server" ID="rcbSede" DataValueField="ID"
                            MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsSede" LoadingMessage="Cargando...">
                        </telerik:RadComboBox>
                                                
                    </EditItemTemplate>

<HeaderStyle Width="250px"></HeaderStyle>
                </telerik:GridTemplateColumn>               
                <telerik:GridTemplateColumn HeaderText="GERENCIA" HeaderStyle-Width="250px" SortExpression="oBE_GERENCIA.DESCRIPCION" DataField="oBE_GERENCIA.DESCRIPCION" UniqueName="oBE_GERENCIA.DESCRIPCION"
                AutoPostBackOnFilter="true">
                    <ItemTemplate>
                        <%# Eval("oBE_GERENCIA.DESCRIPCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox Width="50%" runat="server" ID="rcbGerencia" DataValueField="ID"
                            MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsGerencia" LoadingMessage="Cargando..." AutoPostBack="true" OnSelectedIndexChanged="rcbGerencia_SelectedIndexChanged">
                        </telerik:RadComboBox>                     
                    </EditItemTemplate>

<HeaderStyle Width="250px"></HeaderStyle>
                </telerik:GridTemplateColumn>               
                <telerik:GridTemplateColumn HeaderText="AREA" HeaderStyle-Width="250px" SortExpression="oBE_AREA.DESCRIPCION" DataField="oBE_AREA.DESCRIPCION" UniqueName="oBE_AREA.DESCRIPCION"
                AutoPostBackOnFilter="true">
                    <ItemTemplate>
                        <%# Eval("oBE_AREA.DESCRIPCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox Width="50%" runat="server" ID="rcbArea" DataValueField="ID"
                            MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsArea" LoadingMessage="Cargando..."  AutoPostBack="true" OnSelectedIndexChanged="rcbArea_SelectedIndexChanged">
                        </telerik:RadComboBox>                        
                    </EditItemTemplate>

<HeaderStyle Width="250px"></HeaderStyle>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="COORDINACION" HeaderStyle-Width="250px" SortExpression="oBE_COORDINACION.DESCRIPCION" DataField="oBE_COORDINACION.DESCRIPCION" UniqueName="oBE_COORDINACION.DESCRIPCION"
                AutoPostBackOnFilter="true">
                    <ItemTemplate>
                        <%# Eval("oBE_COORDINACION.DESCRIPCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox Width="50%" runat="server" ID="rcbCoordinacion" DataValueField="ID"
                            MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsCoordinacion" LoadingMessage="Cargando...">
                        </telerik:RadComboBox>
                                                    
                    </EditItemTemplate>

<HeaderStyle Width="250px"></HeaderStyle>
                </telerik:GridTemplateColumn>                
                <telerik:GridTemplateColumn HeaderText="PUESTO" SortExpression="oBE_PUESTO.DESCRIPCION" Datafield="oBE_PUESTO.DESCRIPCION" UniqueName="oBE_PUESTO.DESCRIPCION"
                AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_PUESTO.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox runat="server" ID="rcbPuesto" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsPuesto" LoadingMessage="Cargando..." Width="50%">
                            </telerik:RadComboBox>
                              
                        </EditItemTemplate>
                </telerik:GridTemplateColumn>                                 
                <telerik:GridTemplateColumn HeaderText="GRUPO ORGANIZACIONAL" HeaderStyle-Width="250px" SortExpression="oBE_GRUPO_ORGANIZACIONAL.DESCRIPCION" DataField="oBE_GRUPO_ORGANIZACIONAL.DESCRIPCION" UniqueName="oBE_GRUPO_ORGANIZACIONAL.DESCRIPCION"
                AutoPostBackOnFilter="true">
                    <ItemTemplate>
                        <%# Eval("oBE_GRUPO_ORGANIZACIONAL.DESCRIPCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox Width="50%" runat="server" ID="rcbGrupoOrganizacional" DataValueField="ID"
                            MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsGrupoOrganizacional" LoadingMessage="Cargando...">
                        </telerik:RadComboBox>
                                          
                    </EditItemTemplate>

<HeaderStyle Width="250px"></HeaderStyle>
                </telerik:GridTemplateColumn>                
                <telerik:GridTemplateColumn HeaderText="PERFIL" HeaderStyle-Width="250px" SortExpression="oBE_PERFILES.DESCRIPCION" Datafield="oBE_PERFILES.DESCRIPCION" UniqueName="oBE_PERFILES.DESCRIPCION"
                AutoPostBackOnFilter="true">
                    <ItemTemplate>
                        <%# Eval("oBE_PERFILES.DESCRIPCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox Width="50%" runat="server" ID="rcbPerfiles" DataValueField="ID"
                            MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsPerfiles" LoadingMessage="Cargando...">
                        </telerik:RadComboBox>
                        
                    </EditItemTemplate>

<HeaderStyle Width="250px"></HeaderStyle>
                </telerik:GridTemplateColumn>                
                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn" EditText="Actualizar">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Persona?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Persona Eliminada" ButtonType="ImageButton" CommandName="Delete"
                    Text="Eliminar" UniqueName="EliminarPersona">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn UniqueName="EditCommandColumn" CancelText="Cancelar" UpdateText="Actualizar"
                  InsertText="Insertar">
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
        <asp:ValidationSummary ID="ValidationSummary" ForeColor="Red" HeaderText="(*) Campos Obligatorios."
            DisplayMode="SingleParagraph" EnableClientScript="true" runat="server" />
    </div>
    <asp:ObjectDataSource ID="odsPersonal" runat="server" SelectMethod="SeleccionarPersonal"
        DataObjectTypeName="BusinessEntities.BE_PERSONAL" TypeName="BusinessLogicLayer.BL_PERSONAL">
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="odsEmpresa" runat="server" SelectMethod="SeleccionarEmpresa"         
        TypeName="BusinessLogicLayer.BL_EMPRESA">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsGerencia" runat="server" SelectMethod="SeleccionarGerencia"
        TypeName="BusinessLogicLayer.BL_GERENCIA"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsArea" runat="server" SelectMethod="SeleccionarArea"
        TypeName="BusinessLogicLayer.BL_AREA"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsCoordinacion" runat="server" SelectMethod="SeleccionarCoordinacion"
        TypeName="BusinessLogicLayer.BL_COORDINACION"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsPerfiles" runat="server" 
        SelectMethod="SeleccionarPERFILES" TypeName="BusinessLogicLayer.BL_PERFILES">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsSede" runat="server" SelectMethod="SeleccionarSede"         
        TypeName="BusinessLogicLayer.BL_SEDE">    
    </asp:ObjectDataSource>  
    <asp:ObjectDataSource ID="odsGrupoOrganizacional" runat="server" SelectMethod="SeleccionarGrupoOrganizacional"         
        TypeName="BusinessLogicLayer.BL_GRUPO_ORGANIZACIONAL">    
    </asp:ObjectDataSource>  
    <asp:ObjectDataSource ID="odsPuesto" runat="server" SelectMethod="SeleccionarPuesto"         
        TypeName="BusinessLogicLayer.BL_PUESTO">    
    </asp:ObjectDataSource>  
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
</asp:Content>
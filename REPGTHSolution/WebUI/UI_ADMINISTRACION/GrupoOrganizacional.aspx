<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="GrupoOrganizacional.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.GrupoOrganizacional" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
           
  <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" /> 
  <script type="text/javascript">
        function showRadConfirm(text) {
            radalert(text, null, null, "Eliminar Grupo Organizacional");
        }
  </script>        
          <div class="frm_titulo01">Administrar Grupos Organizacionales</div>          
       
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

        <telerik:RadGrid ID="rgGrupoOrganizacional" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsGrupoOrganizacional"
        OnInsertCommand="rgGrupoOrganizacional_InsertCommand" OnDeleteCommand="rgGrupoOrganizacional_DeleteCommand"
        OnUpdateCommand="rgGrupoOrganizacional_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="100%" 
        OnItemDataBound="rgGrupoOrganizacional_ItemDataBound" AllowSorting="true" AllowFilteringByColumn="False" 
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto" EnableLinqExpressions="false">
            <groupingsettings casesensitive="False" />
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView DataSourceID="odsGrupoOrganizacional" CommandItemDisplay="Top" DataKeyNames="ID" HorizontalAlign="NotSet" 
        AutoGenerateColumns="False" EditMode="EditForms" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen Grupos Organizacionales registradas.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Grupo Organizacional" RefreshText="Actualizar"></CommandItemSettings>   

<RowIndicatorColumn Visible="True" FilterImageUrl="../Styles/Grid/Filter.gif" SortAscImageUrl="../Styles/Grid/SortAsc.gif" SortDescImageUrl="../Styles/Grid/SortDesc.gif" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn ExpandImageUrl="../Styles/Grid/SinglePlus.gif" CollapseImageUrl="../Styles/Grid/SingleMinus.gif" Visible="True" FilterImageUrl="../Styles/Grid/Filter.gif" SortAscImageUrl="../Styles/Grid/SortAsc.gif" SortDescImageUrl="../Styles/Grid/SortDesc.gif" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>     
                <telerik:GridBoundColumn DataField="CODIGO" HeaderText="CODIGO" SortExpression="CODIGO" UniqueName="CODIGO" HeaderStyle-Width="50%" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>

<HeaderStyle Width="50%"></HeaderStyle>
                </telerik:GridBoundColumn>              
                <telerik:GridBoundColumn DataField="DESCRIPCION" HeaderText="GRUPO ORGANIZACIONAL" SortExpression="DESCRIPCION" UniqueName="DESCRIPCION" HeaderStyle-Width="50%" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>

<HeaderStyle Width="50%"></HeaderStyle>
                </telerik:GridBoundColumn>                        
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" EditText="Actualizar"
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar este Grupo Organizacional?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Eliminar Grupo Organizacional" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarGrupoOrganizacional">
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

        <FilterMenu EnableImageSprites="False">
        </FilterMenu>

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
    <asp:ObjectDataSource ID="odsGrupoOrganizacional" runat="server" SelectMethod="SeleccionarGrupoOrganizacional"         
        TypeName="BusinessLogicLayer.BL_GRUPO_ORGANIZACIONAL">
    </asp:ObjectDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
   
</asp:Content>
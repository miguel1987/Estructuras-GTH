<%@ Page Language="C#" MasterPageFile="~/Template/MP.Master" AutoEventWireup="true" CodeBehind="Sede.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.Sede" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
  <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" /> 
  <script type="text/javascript">
      function showRadConfirm(text) {
          radalert(text, null, null, "Eliminar Sede");
      }
  </script>        
          <div class="frm_titulo01">Administrar Sedes</div>          
       
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
 <telerik:RadGrid ID="rgSede" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsSede"
        OnInsertCommand="rgSede_InsertCommand" OnDeleteCommand="rgSede_DeleteCommand"
        OnUpdateCommand="rgSede_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="100%" 
        OnItemDataBound="rgSede_ItemDataBound" AllowSorting="true" AllowFilteringByColumn="False" 
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto" EnableLinqExpressions="false">
        <groupingsettings casesensitive="False" />
        <ExportSettings>
            <Pdf PageWidth="" />
<Pdf PageWidth=""></Pdf>
        </ExportSettings>
        
        <MasterTableView DataSourceID="odsSede" CommandItemDisplay="Top" EditMode="EditForms" DataKeyNames="ID"
         ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="True" ShowHeader="True" HorizontalAlign="NotSet" AutoGenerateColumns="False"   
         OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen Sedes registradas.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Sede" RefreshText="Actualizar" ExportToPdfText="Exportar a PDF"></CommandItemSettings>           
           
<RowIndicatorColumn Visible="True" FilterImageUrl="../Styles/Grid/Filter.gif" SortAscImageUrl="../Styles/Grid/SortAsc.gif" SortDescImageUrl="../Styles/Grid/SortDesc.gif" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn ExpandImageUrl="../Styles/Grid/SinglePlus.gif" CollapseImageUrl="../Styles/Grid/SingleMinus.gif" Visible="True" FilterImageUrl="../Styles/Grid/Filter.gif" SortAscImageUrl="../Styles/Grid/SortAsc.gif" SortDescImageUrl="../Styles/Grid/SortDesc.gif" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
           
            <Columns>   
                <telerik:GridBoundColumn DataField="CODIGO"
                    HeaderText="CODIGO" SortExpression="CODIGO" UniqueName="CODIGO" AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>                
                <telerik:GridBoundColumn DataField="DESCRIPCION" 
                    HeaderText="SEDE" SortExpression="DESCRIPCION" UniqueName="DESCRIPCION" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>       
                <telerik:GridTemplateColumn HeaderText="EMPRESA" HeaderStyle-Width="250px" SortExpression="oBE_EMPRESA.DESCRIPCION" Datafield="oBE_EMPRESA.DESCRIPCION" UniqueName="oBE_EMPRESA.DESCRIPCION"  
                AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_EMPRESA.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbEmpresa" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsEmpresa" LoadingMessage="Cargando..." Width="50%">
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ControlToValidate="rcbEmpresa" 
                                ForeColor="Red" Text="*">
                            </asp:RequiredFieldValidator>     
                        </EditItemTemplate>

<HeaderStyle Width="250px"></HeaderStyle>
                    </telerik:GridTemplateColumn>                   
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" 
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif" EditText="Actualizar">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Sede?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Sede Eliminada" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarSede">
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
    <asp:ObjectDataSource ID="odsSede" runat="server" SelectMethod="SeleccionarSede"         
        TypeName="BusinessLogicLayer.BL_SEDE" DataObjectTypeName="BusinessEntities.BE_SEDE">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsEmpresa" runat="server" SelectMethod="SeleccionarEmpresa"         
        TypeName="BusinessLogicLayer.BL_EMPRESA">
    </asp:ObjectDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
   
</asp:Content>


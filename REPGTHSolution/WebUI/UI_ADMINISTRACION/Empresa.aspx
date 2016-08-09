<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="Empresa.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.Empresa" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
           
  <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" /> 
  <script type="text/javascript">
        function showRadConfirm(text) {
            radalert(text, null, null, "Eliminar Empresa");
        }
  </script>        
          <div class="frm_titulo01">Administrar Empresas</div>          
       
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

        <telerik:RadGrid ID="rgEmpresa" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsEmpresa"
        OnInsertCommand="rgEmpresa_InsertCommand" OnDeleteCommand="rgEmpresa_DeleteCommand"
        OnUpdateCommand="rgEmpresa_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="100%" 
        OnItemDataBound="rgEmpresa_ItemDataBound" AllowSorting="true" AllowFilteringByColumn="False" 
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto" EnableLinqExpressions="false">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView DataSourceID="odsEmpresa" CommandItemDisplay="Top" DataKeyNames="ID" HorizontalAlign="NotSet" 
        AutoGenerateColumns="False" EditMode="EditForms" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen empresas registradas.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Empresa" RefreshText="Actualizar"></CommandItemSettings>   
            <Columns>     
                <telerik:GridBoundColumn DataField="CODIGO" HeaderText="CODIGO" SortExpression="CODIGO" UniqueName="CODIGO" HeaderStyle-Width="50%" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>              
                <telerik:GridBoundColumn DataField="DESCRIPCION" HeaderText="EMPRESA" SortExpression="DESCRIPCION" UniqueName="DESCRIPCION" HeaderStyle-Width="50%" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>                        
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" EditText="Actualizar"
                    UniqueName="EditCommandColumn" CancelImageUrl="../images/ico-edit.png" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Empresa?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Eliminar Empresa" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarEmpresa">
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
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>
    <br />
    <div>
    <asp:ValidationSummary ID="ValidationSummary" ForeColor="Red" 
        HeaderText="(*) Campos Obligatorios."
        DisplayMode="SingleParagraph"
        EnableClientScript="true"
        runat="server"/>
        </div>    
    <asp:ObjectDataSource ID="odsEmpresa" runat="server" SelectMethod="SeleccionarEmpresa"         
        TypeName="BusinessLogicLayer.BL_EMPRESA">
    </asp:ObjectDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
   
</asp:Content>
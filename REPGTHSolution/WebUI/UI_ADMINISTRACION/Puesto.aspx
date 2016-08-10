<%@ Page Language="C#" MasterPageFile="~/Template/MP.Master" AutoEventWireup="true" CodeBehind="Puesto.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.Puesto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
  <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" /> 
  <script type="text/javascript">
      function showRadConfirm(text) {
          radalert(text, null, null, "Eliminar Puesto");
      }
  </script>        
          <div class="frm_titulo01">Administrar Puestos</div>          
       
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
 <telerik:RadGrid ID="rgPuesto" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsPuesto"
        OnInsertCommand="rgPuesto_InsertCommand" OnDeleteCommand="rgPuesto_DeleteCommand"
        OnUpdateCommand="rgPuesto_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="100%" 
        OnItemDataBound="rgPuesto_ItemDataBound" AllowSorting="true" AllowFilteringByColumn="False" 
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto" EnableLinqExpressions="false">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        
        <MasterTableView DataSourceID="odsPuesto" CommandItemDisplay="Top" EditMode="EditForms" DataKeyNames="ID"
         ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="True" ShowHeader="True" HorizontalAlign="NotSet" AutoGenerateColumns="False"   
         OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen puestos registrados.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Puesto" RefreshText="Actualizar" ExportToPdfText="Exportar a PDF"></CommandItemSettings>           
           
            <Columns>   
                <telerik:GridBoundColumn DataField="CODIGO" HeaderStyle-Width="35%"
                    HeaderText="CODIGO" SortExpression="CODIGO" UniqueName="CODIGO" AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>                
                <telerik:GridBoundColumn DataField="DESCRIPCION" HeaderStyle-Width="35%" 
                    HeaderText="PUESTO" SortExpression="DESCRIPCION" UniqueName="DESCRIPCION" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>  
                <telerik:GridTemplateColumn HeaderText="NIVEL" HeaderStyle-Width="15%" SortExpression="oBE_NIVEL_PUESTO.DESCRIPCION" DataField="oBE_NIVEL_PUESTO.DESCRIPCION" UniqueName="oBE_NIVEL_PUESTO.DESCRIPCION"
                AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_NIVEL_PUESTO.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox runat="server" ID="rcbNivel" DataValueField="CODIGO" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsNivelPuesto" LoadingMessage="Cargando..." Width="50%">
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvNivel" runat="server" ControlToValidate="rcbNivel" 
                                ForeColor="Red" Text="*">
                            </asp:RequiredFieldValidator>     
                        </EditItemTemplate>
                </telerik:GridTemplateColumn>        
                <telerik:GridTemplateColumn HeaderText="EMPRESA" HeaderStyle-Width="15%" SortExpression="oBE_EMPRESA.DESCRIPCION" Datafield="oBE_EMPRESA.DESCRIPCION" UniqueName="oBE_EMPRESA.DESCRIPCION"  
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
                    </telerik:GridTemplateColumn>                   
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" 
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif" EditText="Actualizar">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar este Puesto?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Puesto Eliminado" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarPuesto">
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
    </telerik:RadGrid>
    <br />
    <div>
    <asp:ValidationSummary ID="ValidationSummary" ForeColor="Red" 
        HeaderText="(*) Campos Obligatorios."
        DisplayMode="SingleParagraph"
        EnableClientScript="true"
        runat="server"/>
        </div>    
    <asp:ObjectDataSource ID="odsPuesto" runat="server" SelectMethod="SeleccionarPuesto"         
        TypeName="BusinessLogicLayer.BL_PUESTO" DataObjectTypeName="BusinessEntities.BE_PUESTO">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsEmpresa" runat="server" SelectMethod="SeleccionarEmpresa"         
        TypeName="BusinessLogicLayer.BL_EMPRESA">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsNivelPuesto" runat="server" SelectMethod="SeleccionarNivelPuesto"         
        TypeName="BusinessLogicLayer.BL_PUESTO">
    </asp:ObjectDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
   
</asp:Content>


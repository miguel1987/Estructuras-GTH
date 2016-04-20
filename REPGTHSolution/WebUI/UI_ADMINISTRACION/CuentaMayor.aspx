<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="CuentaMayor.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.CuentaMayor" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
 <h1 class="tit_01">MANTENIMIENTO DE CUENTA MAYOR</h1>
 <telerik:RadGrid ID="rgCuentaMayor" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsCuentaMayor"
        OnInsertCommand="rgCuentaMayor_InsertCommand" OnDeleteCommand="rgCuentaMayor_DeleteCommand"
        OnUpdateCommand="rgCuentaMayor_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="50%" AllowSorting="true" AllowFilteringByColumn="True"
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView
        CommandItemDisplay="Top" DataKeyNames="ID" AllowFilteringByColumn="True" DataSourceID="odsCuentaMayor"
            HorizontalAlign="NotSet" AutoGenerateColumns="False" EditMode="EditForms" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen cuentas mayores registradas.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Nuevo Registro" RefreshText="Actualizar" ExportToPdfText="Exportar a PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="CODIGO" FilterControlAltText="Filter CODIGO column"
                    HeaderText="CODIGO" SortExpression="CODIGO" UniqueName="CODIGO" HeaderStyle-Width="250px" 
                    AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>       
                <telerik:GridBoundColumn DataField="DESCRIPCION" FilterControlAltText="Filter DESCRIPCION column"
                    HeaderText="CUENTA MAYOR" SortExpression="DESCRIPCION" UniqueName="DESCRIPCION" HeaderStyle-Width="350px" 
                    AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>   
                <telerik:GridEditCommandColumn ButtonType="ImageButton" EditText="Actualizar"
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Cuenta Mayor?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Cuenta Mayor Eliminada" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarCentroCosto">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                </telerik:GridButtonColumn>
            </Columns>

            <EditFormSettings>
            <EditColumn UniqueName="EditCommandColumn" CancelText="Cancelar" UpdateText="Actualizar" InsertText="Insertar">
                                        </EditColumn>
            </EditFormSettings>

            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
        </MasterTableView>
        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
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
    <asp:ObjectDataSource ID="odsCuentaMayor" runat="server" SelectMethod="SeleccionarCuentasMayores"         
        TypeName="BusinessLogicLayer.BL_CUENTA_MAYOR" DataObjectTypeName="BusinessEntities.BE_CUENTA_MAYOR">    
    </asp:ObjectDataSource> 
  </asp:Content>
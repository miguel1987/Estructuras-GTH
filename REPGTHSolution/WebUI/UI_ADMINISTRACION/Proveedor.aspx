<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MP.Master" AutoEventWireup="true" CodeBehind="Proveedor.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.Proveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
 <h1 class="tit_01">MANTENIMIENTO DE PROVEEDORES</h1>
 <telerik:RadGrid ID="rgProveedor" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsProveedor"
        OnInsertCommand="rgProveedor_InsertCommand" OnDeleteCommand="rgProveedor_DeleteCommand"
        OnUpdateCommand="rgProveedor_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="50%" 
        OnItemDataBound="rgProveedor_ItemDataBound" AllowSorting="true" AllowFilteringByColumn="True" 
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView DataSourceID="odsProveedor"
        CommandItemDisplay="Top" DataKeyNames="ID" AllowFilteringByColumn="True" 
            HorizontalAlign="NotSet" AutoGenerateColumns="False" EditMode="EditForms" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen proveedores registrados.
            </NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="DESCRIPCION" FilterControlAltText="Filter DESCRIPCION column"
                    HeaderText="PROVEEDOR" SortExpression="DESCRIPCION" UniqueName="DESCRIPCION" 
                    AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>    
                <telerik:GridTemplateColumn HeaderText="TIPO" SortExpression="oBE_TIPO_SOLICITUD.DESCRIPCION" DataField="oBE_TIPO_SOLICITUD.DESCRIPCION" UniqueName="oBE_TIPO_SOLICITUD.DESCRIPCION"
                AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                        <ItemTemplate>
                            <%# Eval("oBE_TIPO_SOLICITUD.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox runat="server" ID="rcbTipoSolicitud" DataValueField="CODIGO" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsTipoSolicitud" LoadingMessage="Cargando..." Width="50%">
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvTipoSolicitud" runat="server" ControlToValidate="rcbTipoSolicitud" 
                                ForeColor="Red" Text="*">
                            </asp:RequiredFieldValidator>     
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>                
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" EditText="Actualizar" 
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Proveedor?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Proveedor Eliminada" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarProveedor">
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
    <asp:ObjectDataSource ID="odsProveedor" runat="server" SelectMethod="SeleccionarProveedores"         
        TypeName="BusinessLogicLayer.BL_PROVEEDOR">
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="odsTipoSolicitud" runat="server" SelectMethod="SeleccionarTipoSolicitud"         
        TypeName="BusinessLogicLayer.BL_PROVEEDOR">    
    </asp:ObjectDataSource>  
   
</asp:Content>


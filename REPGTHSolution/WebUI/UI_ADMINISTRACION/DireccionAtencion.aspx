<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="DireccionAtencion.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.DireccionAtencion" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
 <h1 class="tit_01">MANTENIMIENTO DE DESTINATARIOS ATENCIÓN</h1>
 <telerik:RadGrid ID="rgDireccionAtencion" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsDireccion"
        OnInsertCommand="rgDireccionAtencion_InsertCommand" OnDeleteCommand="rgDireccionAtencion_DeleteCommand"
        OnUpdateCommand="rgDireccionAtencion_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="50%" 
        OnItemDataBound="rgDireccionAtencion_ItemDataBound" AllowSorting="true" AllowFilteringByColumn="True"
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView DataSourceID="odsDireccionAtencion"
        CommandItemDisplay="Top" DataKeyNames="ID"  AllowFilteringByColumn="True"
            HorizontalAlign="NotSet" AutoGenerateColumns="False" EditMode="EditForms" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen direcciones registrados.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Nuevo Registro" RefreshText="Actualizar" ExportToPdfText="Exportar a PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="DESTINATARIO" SortExpression="oBE_DIRECCION.DESTINATARIO" DataField="oBE_DIRECCION.DESTINATARIO" UniqueName="oBE_DIRECCION.DESTINATARIO" 
                AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                        <ItemTemplate>
                            <%# Eval("oBE_DIRECCION.DESTINATARIO")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox runat="server" ID="rcbDireccionDestinatario" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESTINATARIO" AllowCustomText="true" DataSourceID="odsDireccion" LoadingMessage="Cargando..." Width="50%">
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvDestinatario" runat="server" ControlToValidate="rcbDireccionDestinatario" 
                                ForeColor="Red" Text="*">
                            </asp:RequiredFieldValidator>     
                        </EditItemTemplate>
                </telerik:GridTemplateColumn>                                
                <telerik:GridTemplateColumn HeaderText="ATENCION" DataField="ATENCION" HeaderStyle-Width="250px"
                    UniqueName="ATENCION" AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                    <ItemTemplate>
                        <%# Eval("ATENCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAtencion" runat="server" Text='<%# Eval("ATENCION")%>'></asp:TextBox>                        
                    </EditItemTemplate>
                    <HeaderStyle Width="100px"></HeaderStyle>
                </telerik:GridTemplateColumn>    
                <telerik:GridEditCommandColumn ButtonType="ImageButton" EditText="Actualizar"
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Dirección?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Dirección Eliminada" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
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
    <asp:ObjectDataSource ID="odsDireccion" runat="server" SelectMethod="SeleccionarDireccionesDestinatario"         
        TypeName="BusinessLogicLayer.BL_DIRECCION">
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="odsDireccionAtencion" runat="server" SelectMethod="SeleccionarDireccionesAtencion"         
        TypeName="BusinessLogicLayer.BL_DIRECCION">    
    </asp:ObjectDataSource>     
   
</asp:Content>
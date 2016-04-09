<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="Direccion.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.Direccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
 <h1 class="tit_01">MANTENIMIENTO DE DIRECCIONES</h1>
 <telerik:RadGrid ID="rgDireccion" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsDireccion"
        OnInsertCommand="rgDireccion_InsertCommand" OnDeleteCommand="rgDireccion_DeleteCommand"
        OnUpdateCommand="rgDireccion_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="50%" 
        OnItemDataBound="rgDireccion_ItemDataBound" AllowSorting="true" AllowFilteringByColumn="True"
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView DataSourceID="odsDireccion"
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
                <telerik:GridTemplateColumn HeaderText="TIPO ENVIO" SortExpression="oBE_TIPO_SOLICITUD.DESCRIPCION" DataField="oBE_TIPO_SOLICITUD.DESCRIPCION" UniqueName="oBE_TIPO_SOLICITUD.DESCRIPCION" 
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
                <telerik:GridTemplateColumn HeaderText="TIPO DIRECCION" SortExpression="oBE_TIPO_DIRECCION.DESCRIPCION" DataField="oBE_TIPO_DIRECCION.DESCRIPCION" UniqueName="oBE_TIPO_DIRECCION.DESCRIPCION"
                AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                        <ItemTemplate>
                            <%# Eval("oBE_TIPO_DIRECCION.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox runat="server" ID="rcbTipoDireccion" DataValueField="CODIGO" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsTipoDireccion" LoadingMessage="Cargando..." Width="50%" AutoPostBack="true" OnSelectedIndexChanged="rcbTipoDireccion_SelectedIndexChanged">
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvTipoDireccion" runat="server" ControlToValidate="rcbTipoDireccion" 
                                ForeColor="Red" Text="*">
                            </asp:RequiredFieldValidator>     
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>  
                <telerik:GridBoundColumn DataField="DESCRIPCION" FilterControlAltText="Filter DESCRIPCION column"
                    HeaderText="DIRECCION" SortExpression="DESCRIPCION" UniqueName="DESCRIPCION" 
                    AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                   <%-- <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>--%>
                </telerik:GridBoundColumn> 
                <telerik:GridTemplateColumn HeaderText="DESTINATARIO" DataField="DESTINATARIO" HeaderStyle-Width="250px"
                    UniqueName="DESTINATARIO" AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                    <ItemTemplate>
                        <%# Eval("DESTINATARIO")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDestinatario" runat="server" Text='<%# Eval("DESTINATARIO")%>'></asp:TextBox>                        
                    </EditItemTemplate>
                    <HeaderStyle Width="100px"></HeaderStyle>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="ATENCION" DataField="ATENCION" HeaderStyle-Width="250px" Display="false"
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
    <asp:ObjectDataSource ID="odsDireccion" runat="server" SelectMethod="SeleccionarDirecciones"         
        TypeName="BusinessLogicLayer.BL_DIRECCION">
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="odsTipoSolicitud" runat="server" SelectMethod="SeleccionarTipoSolicitud"         
        TypeName="BusinessLogicLayer.BL_PROVEEDOR">    
    </asp:ObjectDataSource>  
    <asp:ObjectDataSource ID="odsTipoDireccion" runat="server" SelectMethod="SeleccionarTipoDireccion"         
        TypeName="BusinessLogicLayer.BL_DIRECCION">    
    </asp:ObjectDataSource>  
   
</asp:Content>
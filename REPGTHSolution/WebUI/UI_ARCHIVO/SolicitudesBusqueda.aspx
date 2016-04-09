<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="SolicitudesBusqueda.aspx.cs" Inherits="WebUI.UI_ARCHIVO.SolicitudesBusqueda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/PanelBar.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="Label,Textbox,select,textarea" Skin="Silk" />
    <h1 class="tit_01">LISTADO DE SOLICITUDES</h1>
    <div class="panel-container-consultar">
        EMPRESA:
        <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlEmpresa_SelectedIndexChanged" >
        </asp:DropDownList>
        GERENCIA:
        <asp:DropDownList ID="ddlGerencia" runat="server" AutoPostBack="True" onselectedindexchanged="ddlGerencia_SelectedIndexChanged" >
        </asp:DropDownList>
        AREA:
        <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" onselectedindexchanged="ddlArea_SelectedIndexChanged">
        </asp:DropDownList>              
        <br />      
        <br />
        <br />
        <%--DESTINATARIO:
        <asp:DropDownList ID="ddlDestinatario" runat="server" AutoPostBack="True" Width="150px">
        </asp:DropDownList>  --%>
         TIPO:
        <asp:DropDownList ID="ddlTipoSolicitud" runat="server" Width="200px" AutoPostBack="True" onselectedindexchanged="ddlTipoSolicitud_SelectedIndexChanged">            
            <asp:ListItem Value="1">Mensajería Nacional</asp:ListItem>
            <asp:ListItem Value="2">Mensajería Internacional</asp:ListItem>
        </asp:DropDownList> 
        DESDE:
        <telerik:RadDatePicker ID="rdpFechaRegistroDesde" CssClass="dateInput" runat="server" ValidationGroup="SolicitudValidationGroup" 
        Width="140px" Skin="Silk"></telerik:RadDatePicker>  
        <asp:RequiredFieldValidator runat="server" ID="rfvFechaRegistroDesde" ValidationGroup="SolicitudValidationGroup" 
        ControlToValidate="rdpFechaRegistroDesde" ForeColor="Red" ErrorMessage="(*) Ingresar Fecha Desde la que desea realizar la consulta" Text="(*)"></asp:RequiredFieldValidator>
         HASTA:
        <telerik:RadDatePicker ID="rdpFechaRegistroHasta" CssClass="dateInput" runat="server" ValidationGroup="SolicitudValidationGroup" 
        Width="140px" Skin="Silk"></telerik:RadDatePicker>  
        <asp:RequiredFieldValidator runat="server" ID="rfvFechaRegistroHasta" ValidationGroup="SolicitudValidationGroup" 
        ControlToValidate="rdpFechaRegistroHasta" ForeColor="Red" ErrorMessage="(*) Ingresar Fecha Hasta la que desea realizar la consulta" Text="(*)"></asp:RequiredFieldValidator> 
         <br />        
         <br />
         <asp:ValidationSummary runat="server" ForeColor="Red" ID="validationSummary" CssClass="validationSummary" ValidationGroup="SolicitudValidationGroup" />
        <p class="buttons">
        <telerik:RadButton runat="server" Text="Consultar" ID="btnConsultar" Skin="Silk"
            ValidationGroup="SolicitudValidationGroup" OnClick="cargarSolicitudes_Click" />
        <telerik:RadButton runat="server" Text="Nueva Solicitud" ID="btnNuevo" Skin="Silk" OnClick="nuevaSolicitud_Click" />
       </p>
       <p class="mensaje">
         <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
       </p>
    </div> 
    <div class="panel-container-grid">
    <telerik:RadGrid runat="server" ID="rgSolicitudes" AutoGenerateColumns="False" CellSpacing="0"
        Culture="es-ES" DataSourceID="ObjectDataSourceSolicitudes" GridLines="None" 
        OnItemDataBound="rgSolicitudes_ItemDataBound" OnDeleteCommand="rgSolicitudes_DeleteCommand" PageSize="10" AllowPaging="True" 
        AllowFilteringByColumn="True"  AllowSorting="true" Skin="MySilk"         
        EnableEmbeddedSkins="False" ImagesPath="../Styles/Grid/">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView DataSourceID="ObjectDataSourceSolicitudes" AllowFilteringByColumn="True" CommandItemDisplay="Top" EditMode="EditForms"
            ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="True" ShowHeader="True"
            Width="100%" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen solicitudes registrados para los parámetros seleccionados.
            </NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="ID" DataType="System.Guid" FilterControlAltText="Filter ID column"
                    HeaderText="ID" SortExpression="ID" UniqueName="ID" Display="false" ReadOnly="true"
                    ForceExtractValue="Always">
                </telerik:GridBoundColumn> 
                <telerik:GridTemplateColumn HeaderText="NRO SOLICITUD" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" UniqueName="CODIGO" 
                AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false" DataField="CODIGO" SortExpression="CODIGO">
                    <ItemTemplate>
                        <asp:HyperLink ID="hplSolicitud" runat="server"><%# Eval("CODIGO")%></asp:HyperLink>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:HyperLink ID="hplSolicitud2" runat="server"><%# Eval("CODIGO")%></asp:HyperLink>
                    </EditItemTemplate>
                    <HeaderStyle Width="80px"></HeaderStyle>
                </telerik:GridTemplateColumn>  
                <telerik:GridTemplateColumn HeaderText="FECHA" DataField="FECHA_REGISTRO" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" 
                    UniqueName="FECHA_REGISTRO" FilterControlWidth="80px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                        ShowFilterIcon="false" SortExpression="FECHA_REGISTRO">
                    <ItemTemplate>
                        <%# Eval("FECHA_REGISTRO")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadDatePicker ID="rdpFechaRegistro" runat="server" SelectedDate='<%# Eval("FECHA_REGISTRO")%>'></telerik:RadDatePicker>                                               
                    </EditItemTemplate>
                    <HeaderStyle Width="80px"></HeaderStyle>
                </telerik:GridTemplateColumn>   
                <telerik:GridTemplateColumn HeaderText="SOLICITANTE" DataField="SOLICITANTE" HeaderStyle-Width="250px" HeaderStyle-HorizontalAlign="Center" 
                    UniqueName="SOLICITANTE" FilterControlWidth="250px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                        ShowFilterIcon="false" SortExpression="SOLICITANTE">
                    <ItemTemplate>
                        <%# Eval("SOLICITANTE")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSolicitante" runat="server" Text='<%# Eval("SOLICITANTE")%>'></asp:TextBox>                        
                    </EditItemTemplate>
                    <HeaderStyle Width="250px"></HeaderStyle>
                </telerik:GridTemplateColumn>    
                <telerik:GridTemplateColumn HeaderText="DESTINATARIO" DataField="DESTINATARIO" HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" 
                    UniqueName="DESTINATARIO" FilterControlWidth="200px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                        ShowFilterIcon="false" SortExpression="DESTINATARIO">
                    <ItemTemplate>
                        <%# Eval("DESTINATARIO")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDestinatario" runat="server" Text='<%# Eval("DESTINATARIO")%>'></asp:TextBox>                        
                    </EditItemTemplate>
                    <HeaderStyle Width="200px"></HeaderStyle>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="NRO ORDEN" DataField="ORDEN_PROVEEDOR" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" 
                    UniqueName="ORDEN_PROVEEDOR" FilterControlWidth="80px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                        ShowFilterIcon="false" SortExpression="ORDEN_PROVEEDOR">
                    <ItemTemplate>
                        <%# Eval("ORDEN_PROVEEDOR")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtOrdenProveedor" runat="server" Text='<%# Eval("ORDEN_PROVEEDOR")%>'></asp:TextBox>                        
                    </EditItemTemplate>
                    <HeaderStyle Width="80px"></HeaderStyle>
                </telerik:GridTemplateColumn> 
                <telerik:GridTemplateColumn HeaderText="ESTADO" DataField="ESTADO_DESCRIPCION" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" 
                    UniqueName="ESTADO_DESCRIPCION" FilterControlWidth="80px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                        ShowFilterIcon="false" SortExpression="ESTADO_DESCRIPCION">
                    <ItemTemplate>
                        <%# Eval("ESTADO_DESCRIPCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEstado" runat="server" Text='<%# Eval("ESTADO_DESCRIPCION")%>'></asp:TextBox>                        
                    </EditItemTemplate>
                    <HeaderStyle Width="80px"></HeaderStyle>
                </telerik:GridTemplateColumn>
                <telerik:GridButtonColumn ConfirmText="¿Está seguro que deseas eliminar esta solicitud?"
                    ConfirmDialogType="RadWindow" ConfirmTitle="Solicitud Eliminada" ButtonType="ImageButton"
                    CommandName="Delete" Text="Eliminar" UniqueName="EliminarSolicitud" ImageUrl="../Styles/Grid/Delete.gif">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                </telerik:GridButtonColumn>     
                <telerik:GridButtonColumn ButtonType="ImageButton" Text="Imprimir" UniqueName="Print" ImageUrl="../Styles/Grid/Imprimir1.gif">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                </telerik:GridButtonColumn>                                                   
             </Columns>
              <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
        </MasterTableView>
        <ClientSettings EnableRowHoverStyle="true">
            <Selecting AllowRowSelect="True"></Selecting>
        </ClientSettings>
        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
        <HeaderContextMenu EnableEmbeddedScripts="False">
        </HeaderContextMenu>
    </telerik:RadGrid>
    <asp:ObjectDataSource ID="ObjectDataSourceSolicitudes" runat="server" SelectMethod="SeleccionarSolicitudes" TypeName="BusinessLogicLayer.BL_SOLICITUD"></asp:ObjectDataSource>
    </div> 
    <br />
    <br />      
</asp:Content>


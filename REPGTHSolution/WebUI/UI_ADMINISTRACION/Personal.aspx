<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="Personal.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.Personal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
    <h1 class="tit_01">
        MANTENIMIENTO DE PERSONAL</h1>
    <telerik:RadGrid ID="rgPersonal" HorizontalAlign="Center" runat="server" CellSpacing="0"
       Culture="es-ES" DataSourceID="odsPersonal" OnInsertCommand="rgPersonal_InsertCommand"
        OnDeleteCommand="rgPersonal_DeleteCommand" OnUpdateCommand="rgPersonal_UpdateCommand" AllowFilteringByColumn="True" 
        PageSize="10" GridLines="None" AllowPaging="True" Width="80%" OnItemDataBound="rgPersonal_ItemDataBound"
        AllowSorting="false" ImagesPath="../Styles/Grid/" EnableEmbeddedSkins="False"
        Skin="MySilk" Style="margin: auto">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView CommandItemDisplay="Top" DataKeyNames="ID" HorizontalAlign="NotSet" AllowFilteringByColumn="True" DataSourceID="odsPersonal"
            AutoGenerateColumns="False" EditMode="EditForms" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existe personal registrado.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Nuevo Registro" RefreshText="Actualizar" ExportToPdfText="Exportar a PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="CODIGO_TRABAJO" FilterControlAltText="Filter CODIGO_TRABAJO column"
                    HeaderText="CODIGO" SortExpression="CODIGO_TRABAJO" UniqueName="CODIGO_TRABAJO" 
                    AutoPostBackOnFilter="true" FilterControlWidth="50px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NOMBRES" FilterControlAltText="Filter NOMBRES column"
                    HeaderText="NOMBRES" SortExpression="NOMBRES" UniqueName="NOMBRES"  
                    AutoPostBackOnFilter="true" FilterControlWidth="100px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="APELLIDO_PATERNO" FilterControlAltText="Filter APELLIDO_PATERNO column"
                    HeaderText="APELLIDO PATERNO" SortExpression="APELLIDO_PATERNO" UniqueName="APELLIDO_PATERNO" 
                    AutoPostBackOnFilter="true" FilterControlWidth="100px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="APELLIDO_MATERNO" FilterControlAltText="Filter APELLIDO_MATERNO column"
                    HeaderText="APELLIDO MATERNO" SortExpression="APELLIDO_MATERNO" UniqueName="APELLIDO_MATERNO" 
                    AutoPostBackOnFilter="true" FilterControlWidth="100px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>               
                <telerik:GridBoundColumn DataField="DEPARTAMENTO" FilterControlAltText="Filter DEPARTAMENTO column"
                    HeaderText="DEPARTAMENTO" SortExpression="DEPARTAMENTO" UniqueName="DEPARTAMENTO"
                    Display="false" ReadOnly="true" AutoPostBackOnFilter="true" FilterControlWidth="100px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="false">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PUESTO" FilterControlAltText="Filter PUESTO column"
                    HeaderText="PUESTO" SortExpression="PUESTO" UniqueName="PUESTO" AutoPostBackOnFilter="true" 
                    FilterControlWidth="100px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="ES JEFE" SortExpression="oBE_TIPO_JEFE.DESCRIPCION" Datafield="oBE_TIPO_JEFE.DESCRIPCION" UniqueName="oBE_TIPO_JEFE.DESCRIPCION"
                AutoPostBackOnFilter="true" FilterControlWidth="50px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                        <ItemTemplate>
                            <%# Eval("oBE_TIPO_JEFE.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox runat="server" ID="rcbTipoJefe" DataValueField="CODIGO" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsTipoJefe" LoadingMessage="Cargando..." Width="50%">
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvTipoJefe" runat="server" ControlToValidate="rcbTipoJefe" ForeColor="Red" Text="*">
                            </asp:RequiredFieldValidator>     
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn> 
                <telerik:GridBoundColumn DataField="CORREO" FilterControlAltText="Filter CORREO column"
                    HeaderText="CORREO" SortExpression="CORREO" UniqueName="CORREO" AutoPostBackOnFilter="true" FilterControlWidth="100px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NOMBRE_USUARIO" FilterControlAltText="Filter NOMBRE_USUARIO column"
                    HeaderText="NOMBRE USUARIO PROPIETARIO" SortExpression="NOMBRE_USUARIO" UniqueName="NOMBRE_USUARIO" AutoPostBackOnFilter="true" FilterControlWidth="100px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="PERFIL" HeaderStyle-Width="250px" SortExpression="oBE_PERFILES.DESCRIPCION" Datafield="oBE_PERFILES.DESCRIPCION" UniqueName="oBE_PERFILES.DESCRIPCION"
                AutoPostBackOnFilter="true" FilterControlWidth="50px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                    <ItemTemplate>
                        <%# Eval("oBE_PERFILES.DESCRIPCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox Width="50%" runat="server" ID="rcbPerfiles" DataValueField="ID"
                            MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsPerfiles" LoadingMessage="Cargando...">
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="rfvPerfiles" runat="server" ControlToValidate="rcbPerfiles"
                            ForeColor="Red" Text="*">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>                
                <telerik:GridTemplateColumn HeaderText="EMPRESA" HeaderStyle-Width="250px" SortExpression="oBE_EMPRESA.DESCRIPCION" DataField="oBE_EMPRESA.DESCRIPCION" UniqueName="oBE_EMPRESA.DESCRIPCION" 
                AutoPostBackOnFilter="true" FilterControlWidth="100px" CurrentFilterFunction="Contains" ShowFilterIcon="false" AllowFiltering="false">
                    <ItemTemplate>
                        <%# Eval("oBE_EMPRESA.DESCRIPCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox Width="50%" runat="server" ID="rcbEmpresa" DataValueField="ID"
                            MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsEmpresa" LoadingMessage="Cargando..." AutoPostBack="true" OnSelectedIndexChanged="rcbEmpresa_SelectedIndexChanged">
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ControlToValidate="rcbEmpresa"
                            ForeColor="Red" Text="*">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>               
                <telerik:GridTemplateColumn HeaderText="GERENCIA" HeaderStyle-Width="250px" SortExpression="oBE_GERENCIA.DESCRIPCION" DataField="oBE_GERENCIA.DESCRIPCION" UniqueName="oBE_GERENCIA.DESCRIPCION"
                AutoPostBackOnFilter="true" FilterControlWidth="100px" CurrentFilterFunction="Contains" ShowFilterIcon="false" AllowFiltering="false">
                    <ItemTemplate>
                        <%# Eval("oBE_GERENCIA.DESCRIPCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox Width="50%" runat="server" ID="rcbGerencia" DataValueField="ID"
                            MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsGerencia" LoadingMessage="Cargando..." AutoPostBack="true" OnSelectedIndexChanged="rcbGerencia_SelectedIndexChanged">
                        </telerik:RadComboBox>
                     <%--   <asp:RequiredFieldValidator ID="rfvGerencia" runat="server" ControlToValidate="rcbGerencia"
                            ForeColor="Red" Text="*">
                        </asp:RequiredFieldValidator>--%>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>               
                <telerik:GridTemplateColumn HeaderText="AREA" HeaderStyle-Width="250px" SortExpression="oBE_AREA.DESCRIPCION" DataField="oBE_AREA.DESCRIPCION" UniqueName="oBE_AREA.DESCRIPCION"
                AutoPostBackOnFilter="true" FilterControlWidth="100px" CurrentFilterFunction="Contains" ShowFilterIcon="false" AllowFiltering="false">
                    <ItemTemplate>
                        <%# Eval("oBE_AREA.DESCRIPCION")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox Width="50%" runat="server" ID="rcbArea" DataValueField="ID"
                            MarkFirstMatch="true" Filter="None" EnableTextSelection="true" DataTextField="DESCRIPCION"
                            AllowCustomText="true" DataSourceID="odsArea" LoadingMessage="Cargando...">
                        </telerik:RadComboBox>
                        <%--<asp:RequiredFieldValidator ID="rfvArea" runat="server" ControlToValidate="rcbArea"
                            ForeColor="Red" Text="*">
                        </asp:RequiredFieldValidator>--%>
                    </EditItemTemplate>
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
            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
        </MasterTableView>
        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
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
    <asp:ObjectDataSource ID="odsPerfiles" runat="server" 
        SelectMethod="SeleccionarPERFILES" TypeName="BusinessLogicLayer.BL_PERFILES">
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="odsTipoJefe" runat="server" SelectMethod="SeleccionarTipoJefe"         
        TypeName="BusinessLogicLayer.BL_PERSONAL">    
    </asp:ObjectDataSource>  
</asp:Content>
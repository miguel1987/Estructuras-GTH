<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="Area.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.Area" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
 <h1 class="tit_01">MANTENIMIENTO DE AREA</h1>
 <script type="text/javascript">
     function showRadConfirm(text) 
     {
         radalert(text, null, null, "Elimnar Área");
     }
    </script>
    
    <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" />
 <telerik:RadGrid ID="rgArea" HorizontalAlign="Center" runat="server" EditMode="InPlace" 
        CellSpacing="0" Culture="es-ES" DataSourceID="odsArea"
        OnInsertCommand="rgArea_InsertCommand" OnDeleteCommand="rgArea_DeleteCommand"
        OnUpdateCommand="rgArea_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="50%" 
        OnItemDataBound="rgArea_ItemDataBound" AllowSorting="true" AllowFilteringByColumn="True"
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView DataSourceID="odsArea"
        CommandItemDisplay="Top" DataKeyNames="ID" AllowFilteringByColumn="True"
            HorizontalAlign="NotSet" AutoGenerateColumns="False" EditMode="EditForms" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen áreas registradas.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Nuevo Registro" RefreshText="Actualizar"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>                
                <telerik:GridBoundColumn DataField="DESCRIPCION" FilterControlAltText="Filter DESCRIPCION column"
                    HeaderText="AREA" SortExpression="DESCRIPCION" UniqueName="DESCRIPCION" HeaderStyle-Width="350px" 
                    AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>       
                <telerik:GridTemplateColumn HeaderText="EMPRESA" HeaderStyle-Width="250px" SortExpression="oBE_EMPRESA.DESCRIPCION" UniqueName="oBE_EMPRESA.DESCRIPCION" DataField="oBE_EMPRESA.DESCRIPCION"
                AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                        <ItemTemplate>
                            <%# Eval("oBE_EMPRESA.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbEmpresa" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsEmpresa" LoadingMessage="Cargando..." Width="50%" AutoPostBack="true" OnSelectedIndexChanged="rcbEmpresa_SelectedIndexChanged">
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ControlToValidate="rcbEmpresa" 
                                ForeColor="Red" Text="*">
                            </asp:RequiredFieldValidator>     
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>    
                    <telerik:GridTemplateColumn HeaderText="GERENCIA" HeaderStyle-Width="250px" SortExpression="oBE_GERENCIA.DESCRIPCION" DataField="oBE_GERENCIA.DESCRIPCION" UniqueName="oBE_GERENCIA.DESCRIPCION"
                    AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                        <ItemTemplate>
                            <%# Eval("oBE_GERENCIA.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbGerencia" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsGerencia" LoadingMessage="Cargando..." Width="50%">
                            </telerik:RadComboBox>
                           <%-- <asp:RequiredFieldValidator ID="rfvGerencia" runat="server" ControlToValidate="rcbGerencia" 
                                ForeColor="Red" Text="*">
                            </asp:RequiredFieldValidator>     --%>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>                  
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" EditText="Actualizar"
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Área?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Eliminar Área " ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarArea">
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
     <asp:ObjectDataSource ID="odsArea" runat="server" SelectMethod="SeleccionarArea"         
        TypeName="BusinessLogicLayer.BL_AREA" DataObjectTypeName="BusinessEntities.BE_AREA">    
    </asp:ObjectDataSource>  
    <asp:ObjectDataSource ID="odsGerencia" runat="server" SelectMethod="SeleccionarGerencia"         
        TypeName="BusinessLogicLayer.BL_GERENCIA">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsEmpresa" runat="server" SelectMethod="SeleccionarEmpresa"         
        TypeName="BusinessLogicLayer.BL_EMPRESA">
    </asp:ObjectDataSource>   
    
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
</asp:Content>
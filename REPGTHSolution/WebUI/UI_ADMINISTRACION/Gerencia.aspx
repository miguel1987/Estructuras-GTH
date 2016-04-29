﻿<%@ Page Language="C#" MasterPageFile="~/Template/MP.Master" AutoEventWireup="true" CodeBehind="Gerencia.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.Gerencia" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
 <h1 class="tit_01">MANTENIMIENTO DE GERENCIA</h1>
 <script type="text/javascript">
     function showRadConfirm(text) {
         radalert(text, null, null, "Elimnar Gerencia");
     }
    </script>
    <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" />
 <telerik:RadGrid ID="rgGerencia" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsGerencia"
        OnInsertCommand="rgGerencia_InsertCommand" OnDeleteCommand="rgGerencia_DeleteCommand"
        OnUpdateCommand="rgGerencia_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="50%" 
        OnItemDataBound="rgGerencia_ItemDataBound" AllowSorting="true" AllowFilteringByColumn="True" 
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        
        <MasterTableView DataSourceID="odsGerencia" AllowFilteringByColumn="True" CommandItemDisplay="Top" EditMode="EditForms"
         ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="True" ShowHeader="True" HorizontalAlign="NotSet" AutoGenerateColumns="False"   
         OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen gerencias registradas.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Nuevo Registro" RefreshText="Actualizar" ExportToPdfText="Exportar a PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>                 
                <telerik:GridBoundColumn DataField="DESCRIPCION" FilterControlAltText="Filter DESCRIPCION column"
                    HeaderText="GERENCIA" SortExpression="DESCRIPCION" UniqueName="DESCRIPCION" 
                    AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>       
                <telerik:GridTemplateColumn HeaderText="EMPRESA" HeaderStyle-Width="250px" SortExpression="oBE_EMPRESA.DESCRIPCION" Datafield="oBE_EMPRESA.DESCRIPCION" UniqueName="oBE_EMPRESA.DESCRIPCION"  
                AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" ShowFilterIcon="false">
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
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Gerencia?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Gerencia Eliminada" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarGerencia">
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
    <asp:ValidationSummary ID="ValidationSummary" ForeColor="Red" 
        HeaderText="(*) Campos Obligatorios."
        DisplayMode="SingleParagraph"
        EnableClientScript="true"
        runat="server"/>
        </div>    
    <asp:ObjectDataSource ID="odsGerencia" runat="server" SelectMethod="SeleccionarGerencia"         
        TypeName="BusinessLogicLayer.BL_GERENCIA" DataObjectTypeName="BusinessEntities.BE_GERENCIA">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsEmpresa" runat="server" SelectMethod="SeleccionarEmpresa"         
        TypeName="BusinessLogicLayer.BL_EMPRESA">
    </asp:ObjectDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
   
</asp:Content>


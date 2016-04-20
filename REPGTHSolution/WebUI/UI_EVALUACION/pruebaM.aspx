<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pruebaM.aspx.cs" Inherits="WebUI.UI_EVALUACION.pruebaM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 255px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" >
    </asp:ScriptManager>

    <table class="style1">
        <tr>
            <td>
                &nbsp;<br />
                <br />
                <asp:TreeView ID="TreeView1" runat="server" 
                    ontreenodeexpanded="TreeView1_TreeNodeExpanded" >
                </asp:TreeView>
            </td>



            <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" />
                <td> <telerik:RadGrid  ID="rgEvaluaciones" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsGerencia"
        PageSize="10" GridLines="None" AllowPaging="True" Width="50%" 
        AllowSorting="true" AllowFilteringByColumn="True" 
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        
        <MasterTableView DataSourceID="odsGerencia" AllowFilteringByColumn="True" CommandItemDisplay="Top" EditMode="EditForms"
         ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="True" ShowHeader="True" HorizontalAlign="NotSet" AutoGenerateColumns="False"   
         OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen evaluaciones registrados para los parámetros seleccionados.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Nuevo Registro" RefreshText="Actualizar" ExportToPdfText="Exportar a PDF"></CommandItemSettings>
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
                <telerik:GridTemplateColumn HeaderText="PUESTO" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" UniqueName="PUESTO" 
                AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false" DataField="PUESTO" SortExpression="PUESTO">                  
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="COLABORADOR" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" UniqueName="COLABORADOR" 
                AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false" DataField="COLABORADOR" SortExpression="COLABORADOR">                  
                </telerik:GridTemplateColumn> 
                <telerik:GridTemplateColumn HeaderText="ESTADO" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" UniqueName="ESTADO" 
                AutoPostBackOnFilter="true" FilterControlWidth="120px" CurrentFilterFunction="Contains" 
                 ShowFilterIcon="false" DataField="ESTADO" SortExpression="ESTADO">                  
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
    </telerik:RadGrid></td>
            
        </tr>
        </table>
    

    <%--<table class="style1">
        <tr>
            <td class="style2">
                <asp:TreeView ID="TreeView1" runat="server">
                    <Nodes>
                        <asp:TreeNode Text="New Node" Value="New Node"></asp:TreeNode>
                        <asp:TreeNode Text="New Node" Value="New Node"></asp:TreeNode>
                        <asp:TreeNode Text="New Node" Value="New Node"></asp:TreeNode>
                    </Nodes>
                </asp:TreeView>
            </td>
            <td class="style3">
                <asp:GridView ID="GridView1" runat="server" Width="210px">
                    <Columns>
                        <asp:BoundField />
                        <asp:BoundField />
                        <asp:BoundField />
                        <asp:BoundField />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>--%>

    <%--<asp:ObjectDataSource ID="ObjectDataSourceEvluaciones" runat="server" SelectMethod="SeleccionarEvaluacionesPorJerarquia" TypeName="BusinessLogicLayer.BL_EVALUACION_COMPETENCIAS_PUESTO"></asp:ObjectDataSource>--%>
    <asp:ObjectDataSource ID="odsGerencia" runat="server" SelectMethod="SeleccionarGerencia"         
        TypeName="BusinessLogicLayer.BL_GERENCIA" DataObjectTypeName="BusinessEntities.BE_GERENCIA">
    </asp:ObjectDataSource>
</asp:Content>


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
            <telerik:RadGrid ID="RadGrid1" runat="server" DataSourceID="odsEvaluacionesTransversales">
            
                <MasterTableView DataSourceID="odsEvaluacionesTransversales" CommandItemDisplay="Top" DataKeyNames="ID"
         ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="true" ShowHeader="true" HorizontalAlign="NotSet" AutoGenerateColumns="False"   
         OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen evaluaciones registrados para los parámetros seleccionados.
            </NoRecordsTemplate>
            
            <%--<CommandItemSettings  AddNewRecordText="Añadir Nuevo Registro"  RefreshText="Actualizar" ExportToPdfText="Exportar a PDF"></CommandItemSettings> --%>          
            <Columns>
                <telerik:GridBoundColumn DataField="PUESTO_ID" HeaderText="PUESTO_ID" SortExpression="PUESTO_ID" UniqueName="PUESTO_ID" HeaderStyle-Width="90%" Display="false">                    
                </telerik:GridBoundColumn>    
                <telerik:GridBoundColumn DataField="PERSONAL_ID" HeaderText="PERSONAL_ID" SortExpression="PERSONAL_ID" UniqueName="PERSONAL_ID" HeaderStyle-Width="90%" Display="false">                    
                </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn DataField="PUESTO_DESCRIPCION" HeaderText="PUESTO" SortExpression="PUESTO_DESCRIPCION" UniqueName="PUESTO_DESCRIPCION" 
                    AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn>  
                <telerik:GridBoundColumn DataField="PERSONAL_DESCRIPCION" HeaderText="COLABORADORES" SortExpression="PERSONAL_DESCRIPCION" UniqueName="PERSONAL_DESCRIPCION" 
                    AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn DataField="ESTADO_DESCRIPCION" HeaderText="ESTADO_DESCRIPCION" SortExpression="ESTADO_DESCRIPCION" UniqueName="ESTADO" AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn>                               
                <%--<telerik:GridEditCommandColumn ButtonType="ImageButton" 
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif" EditText="Actualizar">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>--%>
                <%--<telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Gerencia?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Gerencia Eliminada" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarGerencia">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                </telerik:GridButtonColumn>--%>
            </Columns>
            <%--<EditFormSettings>
            <EditColumn UniqueName="EditCommandColumn" CancelText="Cancelar" UpdateText="Actualizar"
                  InsertText="Insertar">
                </EditColumn>
            </EditFormSettings>--%>
            <%--<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>--%>
        </MasterTableView>
            </telerik:RadGrid>


           
            
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
    <asp:ObjectDataSource ID="odsEvaluacionesTransversales" runat="server" SelectMethod="SeleccionarEvaluacionesPorJerarquia"         
        TypeName="BusinessLogicLayer.BL_EVALUACION_COMPETENCIAS_PUESTO" DataObjectTypeName="BusinessEntities.BE_EVALUACION_COMPETENCIA_PUESTO">
    </asp:ObjectDataSource>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pruebaM.aspx.cs" Inherits="WebUI.UI_EVALUACION.pruebaM" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
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


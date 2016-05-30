<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pruebaM.aspx.cs" Inherits="WebUI.UI_EVALUACION.pruebaM" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .grid_header
        {}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    


    <telerik:RadMenu ID="RadMenu1" runat="server" Skin="Black">
    <Items>
        <telerik:RadMenuItem Text="Home" NavigateUrl="DefaultCS.aspx" />
        <telerik:RadMenuItem Text="Products">
            <GroupSettings Width="200px" />
            <Items>
              <telerik:RadMenuItem Text="Chairs" NavigateUrl="DefaultCS.aspx?page=chairs">
              </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem Text="Sections" NavigateUrl="DefaultCS.aspx?page=strores" />
    </Items>
</telerik:RadMenu>


</asp:Content>


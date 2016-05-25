<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pruebaM.aspx.cs" Inherits="WebUI.UI_EVALUACION.pruebaM" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .grid_header
        {}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    


    <telerik:RadMenu ID="RadMenu1" Runat="server">
        <Items>
            <telerik:RadMenuItem runat="server" Text="Root RadMenuItem1">
            </telerik:RadMenuItem>
            <telerik:RadMenuItem runat="server" Text="Root RadMenuItem2">
            </telerik:RadMenuItem>
        </Items>
    </telerik:RadMenu>


</asp:Content>


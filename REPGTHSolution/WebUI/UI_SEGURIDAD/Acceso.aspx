<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="WebUI.UI_SEGURIDAD.Acceso" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;text-align:center">

        
        <img src="../Images/contenido_restringido.jpg" /><br />
        <asp:Button ID="btnIntentar" runat="server" Text="Intentar de nuevo" 
            onclick="btnIntentar_Click" />
    </div>
    </form>
</body>
</html>

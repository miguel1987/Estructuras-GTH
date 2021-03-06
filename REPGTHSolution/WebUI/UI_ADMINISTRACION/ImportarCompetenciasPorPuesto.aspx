﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MP.Master" AutoEventWireup="true" CodeBehind="ImportarCompetenciasPorPuesto.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.ImportarCompetenciasPorPuesto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_contenedor" runat="server">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title></title>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
   <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
 
    <script type="text/javascript">
        var uploadedFilesCount = 0;
        var isEditMode;
        function validateRadUpload(source, e) {
            // When the RadGrid is in Edit mode the user is not obliged to upload file.
            if (isEditMode == null || isEditMode == undefined) {
                e.IsValid = false;

                if (uploadedFilesCount > 0) {
                    e.IsValid = true;
                }
            }
            isEditMode = null;
        }

        function OnClientFileUploaded(sender, eventArgs) {
            uploadedFilesCount++;
        }
             
  </script> 

</head>
<body>
    <telerik:RadAjaxManager ID="RadAjaxManager2" DefaultLoadingPanelID="RadAjaxLoadingPanel2"
        runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxPanel1">
                <UpdatedControls>
                    <%--<telerik:AjaxUpdatedControl ControlID="btnUpload"/>--%>
                    <telerik:AjaxUpdatedControl ControlID="rgImportarCompetencias"  />
                </UpdatedControls>
            </telerik:AjaxSetting>
            </AjaxSettings>
 </telerik:RadAjaxManager>
    <div class="frm_titulo01">Importar Competencias Por Puesto</div>
    <br />
    <br />
    <br />
    <br />
    <br />  
     <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" IsSticky="true" 
        runat="server" style="position:absolute; top: 168px; left: 535px;">
        <img alt="Cargando..." src='<%= RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Ajax.loading.gif") %>' 
                    style="border: 0px;" /> 
     </telerik:RadAjaxLoadingPanel> 

    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel2">
    <table style="width: 100%">
        <tr>
            <td class="area-tree" style="width: 153px">	   
    <asp:Label ID="lblArchivo" 
        runat="server" CssClass="estilosLabel" Text="Seleccionar Archivo :">
      </asp:Label>      
            </td>
            <td style="width: 275px">      
        <telerik:RadAsyncUpload runat="server" ID="AsyncUpload2" RenderMode="Lightweight" CssClass="photo-upload"
            OnClientFileUploaded="OnClientFileUploaded" AllowedFileExtensions="xls,xlsx"                                                                     
            MaxFileSize="1048576" OnFileUploaded="AsyncUpload2_FileUploaded" Width="200px" 
            ChunkSize="0" Culture="es-ES" Skin="Office2010Silver" 
              style="text-align: justify" Height="19px" AutoAddFileInputs="False">
        </telerik:RadAsyncUpload>        
            </td>
            <td style="width: 127px; text-align: left;">      
        <telerik:RadButton ID="btnUpload" runat="server" Text="Cargar Datos" 
            OnClick="btnUpload_Click" Skin="Office2010Silver" style="text-align: right" 
                    Height="22px" Width="80px">
        </telerik:RadButton>        
            </td>
            <td style="width: 626px; text-align: left;">
            <telerik:RadButton ID="btnGrabar" runat="server" Text="Importar Evaluaciones" 
            OnClick="btnGrabar_Click" Skin="Office2010Silver" style="text-align: right" 
                    Width="136px" Height="22px">
        </telerik:RadButton>           
                &nbsp;</td>
        </tr>
        </table>
         <br />
         <br />
         <asp:Label ID="lblRegistro" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
         <br />         
        <telerik:RadGrid ID="rgImportarCompetencias" HorizontalAlign="Center" runat="server" 
        CellSpacing="0" Culture="es-ES"
             AutoGenerateColumns="false" GridLines="None"
            AllowPaging="True" AllowFilteringByColumn="false"
       EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" 
            EnableLinqExpressions="false" EnableTheming="false">
            <MasterTableView Width="100%" CommandItemDisplay="None" 
         ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="True" ShowHeader="True" HorizontalAlign="NotSet" AutoGenerateColumns="False"   
         OverrideDataSourceControlSorting="true"> 
         <NoRecordsTemplate>
                No existen Evaluaciones de Competencias por Puesto Cargadas.
            </NoRecordsTemplate>                              
                <Columns>                                        
                    <telerik:GridBoundColumn DataField="cod_trabajador" HeaderText="cod_trabajador">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="cod_competencia" HeaderText="cod_competencia">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="evaluacion" HeaderText="evaluacion">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="comentario" HeaderText="comentario">
                    </telerik:GridBoundColumn>
                </Columns>      
              <PagerStyle Mode="NextPrevAndNumeric" PageSizeLabelText="Nro. Items por Página:" PagerTextFormat="{4} Página {0} de {1}, Filas {2} a {3} de {5}" />                                        
            </MasterTableView>    
            <PagerStyle PrevPageImageUrl="../Styles/Grid/PagingPrev.gif" NextPageImageUrl="../Styles/Grid/PagingNext.gif" FirstPageImageUrl="../Styles/Grid/PagingFirst.gif" LastPageImageUrl="../Styles/Grid/PagingLast.gif" PageSizeControlType="RadComboBox"></PagerStyle>                                            
            </telerik:RadGrid>        
        <br />
        <asp:Label ID="lblMensajeCompetencia" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </telerik:RadAjaxPanel>
        <asp:Label ID="lblFile" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
</body>
</html>
</asp:Content>

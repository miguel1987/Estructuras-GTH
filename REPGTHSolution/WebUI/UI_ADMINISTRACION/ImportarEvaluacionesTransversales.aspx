<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MP.Master" AutoEventWireup="true" CodeBehind="ImportarEvaluacionesTransversales.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.ImportarEvaluacionesTransversales" %>
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
  <script type="text/javascript">
  (function ($) {
    requestStart = function (target, arguments) {
        if (arguments.get_eventTarget().indexOf("btnUpload") > -1) {
            arguments.set_enableAjax(false);
        }
    }
  
  </script>

</head>
<body>
    
	<script type="text/javascript">
	    //Put your JavaScript code here.
    </script>
	
    <telerik:RadAjaxManager ID="RadAjaxManager2" DefaultLoadingPanelID="RadAjaxLoadingPanel2"
        runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxPanel1">
                <UpdatedControls>
                    <%--<telerik:AjaxUpdatedControl ControlID="btnUpload"/>--%>
                    <telerik:AjaxUpdatedControl ControlID="rgImportarTransversales"  />
                </UpdatedControls>
            </telerik:AjaxSetting>
            </AjaxSettings>
 </telerik:RadAjaxManager>
    <div class="frm_titulo01">Importar Evaluaciones Transversales</div>
    <br />
    <br />
    <br />
    <br />
    <br />   
       <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel2"> 
     
    <table style="width: 100%">
        <tr>
            <td class="area-tree" style="width: 153px">	   
    <asp:Label ID="lblArchivo" 
        runat="server" CssClass="estilosLabel" Text="Seleccionar Archivo :">
      </asp:Label>
     
      
            </td>
            <td style="width: 238px" class="area-tree">
 
        <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" RenderMode="Lightweight" CssClass="photo-upload"
            OnClientFileUploaded="OnClientFileUploaded" AllowedFileExtensions="jpg,jpeg,png,gif,pdf,doc,docx,xls,xlsx"
                                                                     
            MaxFileSize="1048576" OnFileUploaded="AsyncUpload1_FileUploaded" Width="200px" 
            ChunkSize="0" Culture="es-ES" Skin="Office2010Silver" 
              style="text-align: justify" Height="19px" AutoAddFileInputs="False">
        </telerik:RadAsyncUpload>
        
            </td>
            <td style="width: 101px; text-align: left;">
     
          
        <telerik:RadButton ID="btnUpload" runat="server" Text="Cargar Datos" 
            OnClick="btnUpload_Click" Skin="Office2010Silver" style="text-align: right" 
                    Height="22px" Width="93px">
        </telerik:RadButton>
        
            </td>
            <td style="width: 626px; text-align: left;">
            <telerik:RadButton ID="btnGrabar" runat="server" Text="Importar Evaluaciones" 
            OnClick="btnGrabar_Click" Skin="Office2010Silver" style="text-align: right" 
                    Width="147px">
        </telerik:RadButton>           
                &nbsp;</td>
        </tr>
        </table>
         <br />
         <br />
         <br />
         
<%--         <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" IsSticky="true" 
        runat="server" style="position:absolute; top: 618px; left: 653px;" 
><img alt="Loading..." src='<%= RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Ajax.loading.gif") %>' 
                    style="border: 0px;" /> 
                </telerik:RadAjaxLoadingPanel>--%>
         
      
         
        <telerik:RadGrid ID="rgImportarTransversales" HorizontalAlign="Center" runat="server" PageSize="10" 
        CellSpacing="0" Culture="es-ES"
             AutoGenerateColumns="false" GridLines="None"
            AllowPaging="True" AllowFilteringByColumn="false"
       EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" 
            EnableLinqExpressions="false" EnableTheming="false">
            <MasterTableView Width="100%" CommandItemDisplay="none" 
         ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="True" ShowHeader="True" HorizontalAlign="NotSet" AutoGenerateColumns="false"   
         OverrideDataSourceControlSorting="true" >    
         <NoRecordsTemplate>
                No existen Competencias por Puesto registradas.</NoRecordsTemplate>                           
                <Columns>                                        
                    <telerik:GridBoundColumn DataField="user_id" HeaderText="user_id">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="cod_competencia" HeaderText="cod_competencia">
                    </telerik:GridBoundColumn>
                    <telerik:GridNumericColumn DataField="evaluacion" HeaderText="evaluacion" DataFormatString="{0:f2}" AllowRounding="false"   DataType="System.Decimal"  />                                                           
                </Columns>                                              
            </MasterTableView>                                                
            </telerik:RadGrid>
                </telerik:RadAjaxPanel>         
        <br />
        <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
	       	
</body>
</html>
    
</asp:Content>

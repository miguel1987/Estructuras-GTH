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

  <script type="text/javascript">
      function Clicking(sender) {
          var selectedText = $(sender).find("option:selected").text();
          if (confirm('¿Está seguro de eliminar las evaluaciones de este año?\nNOTA: No podra recuperarlas una vez eliminadas. ' + selectedText + " ?")) {
              $("#hfResponse").val('Yes');
          } else {
              $("#hfResponse").val('No');
          }

      }
</script>

</head>
<body>
    <asp:HiddenField ID="hfResponse" runat="server" ClientIDMode="Static"/>
	<script type="text/javascript">
	    //Put your JavaScript code here.
    </script>
	
    <telerik:RadAjaxManager ID="RadAjaxManager2" DefaultLoadingPanelID="RadAjaxLoadingPanel2"
        runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxPanel1">
                <UpdatedControls>                   
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
       <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" IsSticky="true" 
        runat="server" style="position:absolute; top: 168px; left: 535px;">
        <img alt="Cargando..." src='<%= RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Ajax.loading.gif") %>' 
                    style="border: 0px;" /> 
                </telerik:RadAjaxLoadingPanel>
       <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel2"> 
     
    <table style="width: 100%; height: 73px;">
        <tr>
            <td class="area-tree" style="width: 153px">	   
    <asp:Label ID="lblArchivo" 
        runat="server" CssClass="estilosLabel" Text="Seleccionar Archivo :">
      </asp:Label>
     
      
            </td>
            <td style="width: 238px" class="area-tree">
 
        <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" RenderMode="Lightweight" CssClass="photo-upload"
            OnClientFileUploaded="OnClientFileUploaded" AllowedFileExtensions="xls,xlsx"                                                                     
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
            <td style="width: 223px; text-align: left;">
                &nbsp;</td>
       <td>&nbsp;</td>
            
        </tr>
        </table>
        <table align="left" style="width: 599px; margin-left: 0px">
            <tr>
                <td class="area-tree" style="width: 20px; text-align: left;">
                    <asp:Label ID="Label1" runat="server" CssClass="estilosLabel" 
                        Text="Seleccionar Fecha:"> </asp:Label>
                </td>
                <td style="width: 44px">
                    <telerik:RadComboBox ID="rcbFecha" Runat="server">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="2015" Value="2015" />
                            <telerik:RadComboBoxItem runat="server" Text="2016" Value="2016" />
                            <telerik:RadComboBoxItem runat="server" Text="2017" Value="2017" />
                            <telerik:RadComboBoxItem runat="server" Text="2018" Value="2018" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
                <td style="width: 2px">
                    <telerik:RadButton ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" 
                        Skin="Office2010Silver" style="text-align: right" Text="Importar Evaluaciones" 
                        Width="147px">
                    </telerik:RadButton>
                </td>
                <td class="area-tree" style="width: 37px">
                <telerik:RadWindowManager  ID="RadWindowManager1"  runat="server">
</telerik:RadWindowManager>
                    <telerik:RadButton ID="btnEliminar" runat="server" Skin="Office2010Silver" 
                        style="text-align: right" Text="Eliminar"  onclick="btnEliminar_Click" OnClientClicked="Clicking">
                    </telerik:RadButton>
                    
                </td>
            </tr>
           </table>
           
         <br />
         <br />
         <asp:Label ID="lblRegistro" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
         <br />         
         
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
                No existen Evaluaciones de Competencias Transversales Cargadas.</NoRecordsTemplate>                           
                <Columns>                                        
                    <telerik:GridBoundColumn DataField="user_id" HeaderText="user_id">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="cod_competencia" HeaderText="cod_competencia">
                    </telerik:GridBoundColumn>
                    <telerik:GridNumericColumn DataField="evaluacion" HeaderText="evaluacion" DataFormatString="{0:f2}" AllowRounding="false"   DataType="System.Decimal"  />                                                           
                </Columns>  
               <PagerStyle Mode="NextPrevAndNumeric" PageSizeLabelText="Nro. Items por Página:" PagerTextFormat="{4} Página {0} de {1}, Filas {2} a {3} de {5}" />                                                                                    
            </MasterTableView>   
            <PagerStyle PrevPageImageUrl="../Styles/Grid/PagingPrev.gif" NextPageImageUrl="../Styles/Grid/PagingNext.gif" FirstPageImageUrl="../Styles/Grid/PagingFirst.gif" LastPageImageUrl="../Styles/Grid/PagingLast.gif" PageSizeControlType="RadComboBox"></PagerStyle>                                            
            </telerik:RadGrid>
                         
        <br />
        <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblError" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
       
        </telerik:RadAjaxPanel>
        <asp:Label ID="lblFile" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
	      	
</body>
</html>
    
</asp:Content>

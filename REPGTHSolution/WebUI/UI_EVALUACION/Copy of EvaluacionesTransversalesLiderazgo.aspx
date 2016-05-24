﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="EvaluacionesTransversalesLiderazgo.aspx.cs" Inherits="WebUI.UI_ARCHIVO.EvaluacionesTransversalesLiderazgo" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">

   <div class="frm_titulo01">Evaluaciones transversales y de liderazgo</div>
          <div class="margen"></div>
          <div class="margen"></div>
          <div class="izquierda">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
            <td><a class="frm_boton ">Generar Reporte</a></td>
            <td width="20">&nbsp;</td>
            <td><input type="text"  class="frmTxtBuscar " value="Buscar" /></td>
            <td><a class="frm_boton ">Ir</a></td>
          </tr>
            </table>
      </div>
          <div class="margen"></div>
          <table border="0" cellspacing="0" cellpadding="0" 
        style="width: 100%; height: 110px" >
        <%--<link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" />--%>
              <link href="../Styles/Grid.prueba1.css" rel="stylesheet" type="text/css" />
        <tr>
              <td valign="top" style="width: 28px"> <div class="cont_frm">
              
              <%--<telerik:RadTreeView  ID="rtvTransversales" runat="server"  OnNodeClick="rtvTransversales_NodeClick"></telerik:RadTreeView>--%>
              <telerik:RadTreeView ID="rtvTransversales" runat="server" OnNodeClick="rtvTransversales_NodeClick"></telerik:RadTreeView>
             </div> </td>              
              <td valign="top" style="width: 310px"> <div class="cont_frm">
              <telerik:RadGrid RenderMode = "Lightweight" ID="rgEvaluacionesTransversales"  runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsEvaluacionesTransversales"
        PageSize="10" GridLines="None" AllowPaging="True" Width="100%" AllowSorting="true" 
        EnableEmbeddedSkins="False" Skin="Metro"  FilterItemStyle-Wrap="False" ActiveItemStyle-Wrap="False" EditItemStyle-Wrap="False" EnableEmbeddedScripts="True" FilterMenu-RenderMode="Lightweight" GroupHeaderItemStyle-Wrap="False" HeaderStyle-Wrap="False" MasterTableView-EnableSplitHeaderText="False" MasterTableView-InsertItemDisplay="Top" MasterTableView-ShowHeader="True" PagerStyle-Wrap="False" ShowHeader="False">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        
        <MasterTableView DataSourceID="odsEvaluacionesTransversales" font-size = "9" CommandItemDisplay="None" DataKeyNames="ID"
         ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="true" ShowHeader="true" HorizontalAlign="NotSet" AutoGenerateColumns="False"   
         OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen evaluaciones registrados para los parámetros seleccionados.
            </NoRecordsTemplate>
            
             <CommandItemSettings  ShowRefreshButton="false" />       
            <Columns>
                <telerik:GridBoundColumn DataField="PUESTO_ID" HeaderText="PUESTO_ID" SortExpression="PUESTO_ID" UniqueName="PUESTO_ID" HeaderStyle-Width="90%" Display="false">                    
                </telerik:GridBoundColumn>    
                <telerik:GridBoundColumn DataField="PERSONAL_ID" HeaderText="PERSONAL_ID" SortExpression="PERSONAL_ID" UniqueName="PERSONAL_ID" HeaderStyle-Width="90%" Display="false">                    
                </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn DataField="CODIGO" HeaderText="CODIGO" SortExpression="CODIGO" UniqueName="CODIGO" 
                    AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn>  
                <telerik:GridBoundColumn DataField="PERSONAL_DESCRIPCION" HeaderText="COLABORADORES" SortExpression="PERSONAL_DESCRIPCION" UniqueName="PERSONAL_DESCRIPCION" 
                    AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn DataField="PUESTO_DESCRIPCION" HeaderText="PUESTO" SortExpression="PUESTO_DESCRIPCION" UniqueName="PUESTO_DESCRIPCION" AutoPostBackOnFilter="true">                    
                </telerik:GridBoundColumn>                               
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
        <HeaderStyle Width="200px" />
            <PagerStyle Mode="NextPrevAndNumeric" />
    </telerik:RadGrid>
   </div></td>
      </table>
          <div class="margen"></div>
          <div class="texto izquierda"> Indicador general de colaboradores con competencias desarolladas: <span class="anotacion1"> 62%</span> </div>
          <div class="margen"></div>
    <asp:ObjectDataSource ID="odsEvaluacionesTransversales" runat="server" SelectMethod="SeleccionarEvaluacionesTransversalesPorJerarquia"         
        TypeName="BusinessLogicLayer.BL__EVALUACIONES_COMPETENCIAS_TRANSVERSALES" DataObjectTypeName="BusinessEntities.BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES">
    </asp:ObjectDataSource>
     <p class="mensaje">
         <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
       </p>
    </div> 
    <br />
    <br />      
</asp:Content>

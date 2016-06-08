<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarEvaluacionesPorPuesto.aspx.cs" Inherits="WebUI.UI_EVALUACION.AsignarEvaluacionesPorPuesto" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Evaluar Competencias por Puesto</title>
    <script src="../Scripts/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../Styles/General.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 158px;
        }
    </style>
    <h2>Evaluar Competencias por Puesto</h2>

    <div style="height: 72px">
    Area: 
        <asp:Label ID="lblArea" runat="server" Text=""></asp:Label>
   <br />
   <br />
    Cargo:
        <asp:Label ID="lblPuesto" runat="server" Text=""></asp:Label>
    <br />
    <br />
    Colaborador:
        <asp:Label ID="lblPersonal" runat="server" Text=""></asp:Label>
    </div>
</head>
<body>
    <form id="form1" runat="server"  >
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <center style="height: 42px"> Tipo Competencias: 
    <asp:DropDownList ID="ddlTipoCompetencias" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlTipoCompetencias_SelectedIndexChanged">
    </asp:DropDownList>
</center>
   <br />
   <div>
   <telerik:RadGrid ID="rgAsignarCompetencias"  
           runat="server" Skin="MySilk" ImagesPath="../Styles/Grid/" Culture="es-ES" 
           DataSourceID="odsCompetenciasPuesto" OnItemDataBound="rgAsignarCompetencias_ItemDataBound" OnUpdateCommand="rgAsignarCompetencias_UpdateCommand" AllowPaging="True" 
           AllowSorting="True" EnableEmbeddedSkins="False">

           <MasterTableView DataSourceID="odsCompetenciasPuesto" CommandItemDisplay="None" DataKeyNames="COMPETENCIA_ID"
         ShowHeadersWhenNoRecords="true" EnableNoRecordsTemplate="True" ShowHeader="True" HorizontalAlign="NotSet" AutoGenerateColumns="False"   
         OverrideDataSourceControlSorting="true" FilterExpression="True" EditMode="EditForms">
            <NoRecordsTemplate>
                No existen evaluaciones registrados para los parámetros seleccionados.
            </NoRecordsTemplate>
<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>          
                <telerik:GridBoundColumn ReadOnly="true" DataField="COMPETENCIA_DESCRIPCION" HeaderText="TECNICAS" SortExpression="COMPETENCIA_DESCRIPCION" UniqueName="COMPETENCIA_DESCRIPCION"  HeaderStyle-Font-Size="8">                    
<HeaderStyle Width="50%"></HeaderStyle>
                </telerik:GridBoundColumn> 
                <telerik:GridBoundColumn EditFormHeaderTextFormat="" DataField="COMPETENCIA_PUESTO_VALOR_REQUERIDO" HeaderText="REQUERIDO" SortExpression="COMPETENCIA_PUESTO_VALOR_REQUERIDO" UniqueName="COMPETENCIA_PUESTO_VALOR_REQUERIDO"  HeaderStyle-Font-Size="8">                    
<HeaderStyle Width="90%"></HeaderStyle>
                </telerik:GridBoundColumn>     
                <telerik:GridBoundColumn DataField="REAL" HeaderText="REAL" SortExpression="REAL" UniqueName="REAL" 
                    AutoPostBackOnFilter="true">  
                                   <ColumnValidationSettings EnableRequiredFieldValidation="true"  >
        <RequiredFieldValidator ForeColor="Red" ErrorMessage="(*)Ingresar Valor Real"></RequiredFieldValidator>     
    </ColumnValidationSettings>  
<HeaderStyle Font-Size="8pt"></HeaderStyle>

            </telerik:GridBoundColumn>  
                <telerik:GridBoundColumn DataField="COMENTARIO" HeaderText="COMENTARIO" SortExpression="COMENTARIO" UniqueName="COMENTARIO" 
                    AutoPostBackOnFilter="true" AllowFiltering="true">
                                    <ColumnValidationSettings EnableRequiredFieldValidation="true"  >
        <RequiredFieldValidator ForeColor="Red" ErrorMessage="(*)Ingresar Comentario"></RequiredFieldValidator>     
    </ColumnValidationSettings>  
<HeaderStyle Font-Size="8pt" Width="260px"></HeaderStyle>
        
                    </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn ReadOnly="true" DataField="BRECHA" HeaderText="BRECHA" SortExpression="BRECHA" UniqueName="BRECHA" AutoPostBackOnFilter="true"  >                    
<HeaderStyle Font-Size="8pt"></HeaderStyle>
                </telerik:GridBoundColumn>       
                <telerik:GridBoundColumn EditFormHeaderTextFormat="" Visible="false" DataField="ESTADO_EVALUACION" HeaderText="" SortExpression="ESTADO_EVALUACION" UniqueName="ESTADO_EVALUACION" AutoPostBackOnFilter="true" Display="true">                    
<HeaderStyle Font-Size="8pt"></HeaderStyle>
                </telerik:GridBoundColumn>
                <%--<telerik:GridTemplateColumn DataField="ESTADO_EVALUACION" EditFormHeaderTextFormat="" HeaderText="ESTADO_EVALUACION" SortExpression="ESTADO_EVALUACION" Visible="false"
                    UniqueName="ESTADO_EVALUACION" ColumnEditorID="GridTextBoxColumnEditorTipo" HeaderStyle-Width="8px"
                    ItemStyle-Width="8px">
                    <ItemTemplate>
                        <asp:Label ID="lblEstadoEvaluacion" runat="server" Text='<%# Eval("ESTADO_EVALUACION")%>' Visible="false" />
                    </ItemTemplate>
                    

                    <EditItemTemplate>
                        <asp:TextBox ID="tbEstadoEvaluacion" runat="server" Enabled="false" Columns="3" Width="300px" Text='<%# Eval("ESTADO_EVALUACION")%>' Visible="false">
                        </asp:TextBox>
                    </EditItemTemplate>                    
                    <HeaderStyle Width="8px"></HeaderStyle>
                    <ItemStyle Width="8px"></ItemStyle>
                </telerik:GridTemplateColumn> --%>
               <telerik:GridEditCommandColumn ButtonType="ImageButton" EditText="Actualizar"
                    UniqueName="EditCommandColumn" CancelImageUrl="../images/ico-delete.png" 
                    InsertImageUrl="../images/ico-edit.png" UpdateImageUrl="../images/ico-edit.png">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>               
            </Columns>
            <EditFormSettings>
             <EditColumn UniqueName="EditCommandColumn" CancelText="Cancelar" UpdateText="Actualizar" InsertText="Insertar">
             </EditColumn>
            </EditFormSettings>
            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
        </MasterTableView>
        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>        
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
       </telerik:RadGrid>
   </div>
   <div>
       <table class="tabla_pagina">
           <tr>
               <td class="style1">
                   <telerik:RadButton RenderMode="Lightweight" ID="btnGuardarEvaluacionFinal" 
           runat="server" Primary="true" with="100%" OnClick="btnGuardarEvaluacionFinal_Click"
    Text="Guardar Evaluación Final" Skin="Metro"  Width="163px" Height="37px" 
           style="text-align: left">
    </telerik:RadButton></td>
               <td>
                   &nbsp;</td>
           </tr>
       </table>
          <p class="mensaje">
         <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
       </p>
    </div>
  <asp:ObjectDataSource ID="odsCompetenciasTipos" runat="server" SelectMethod="SeleccionarCompetenciasTipos"
        TypeName="BusinessLogicLayer.BL_COMPETENCIAS_TIPOS"></asp:ObjectDataSource>
  <asp:ObjectDataSource ID="odsCompetenciasPuesto" runat="server" SelectMethod="SeleccionarCompetenciasPorPuestoyTipo" TypeName="BusinessLogicLayer.BL_COMPETENCIAS_POR_PUESTO"
    DataObjectTypeName="BusinessEntities.BE_COMPETENCIAS_POR_PUESTO">
   <%-- <SelectParameters>
        <asp:Parameter Name="idPuesto" Type="String" DefaultValue="00000000-0000-0000-0000-000000000000" />           
        <asp:Parameter Name="idTipoCompetencia" Type="String" DefaultValue="00000000-0000-0000-0000-000000000000" />
        <asp:Parameter Name="idPersonal" Type="String" DefaultValue="00000000-0000-0000-0000-000000000000" />
    </SelectParameters>--%>
  </asp:ObjectDataSource>
  <asp:HiddenField ID="hf_PersonalId" runat="server" />
  <asp:HiddenField ID="hf_Personal" runat="server" />
  <asp:HiddenField ID="hf_PuestoId" runat="server" />
  <asp:HiddenField ID="hf_Puesto" runat="server" />
  <asp:HiddenField ID="hf_Departamento" runat="server" />   
  <asp:HiddenField ID="hf_Estado" runat="server" /> 
  <asp:HiddenField ID="hf_CompetenciaId" runat="server" Value="" />                 
</form>
</body>
</html>

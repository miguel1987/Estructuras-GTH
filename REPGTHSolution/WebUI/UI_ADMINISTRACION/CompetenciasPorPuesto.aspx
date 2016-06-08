<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="CompetenciasPorPuesto.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.CompetenciasPorPuesto" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
  <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" /> 
  <script type="text/javascript">
      function showRadConfirm(text) {
          radalert(text, null, null, "Eliminar Competencias Por Puesto");
      }
  </script>        
          <div class="frm_titulo01">Administrar Competencias Por Puesto</div>          
       
          <div class="margen"></div>
          <div class="izquierda">        
      </div>
          <div class="derecha">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
            <td><telerik:RadTextBox CssClass="frmTxtBuscar"  ID="txtBuscar" runat="server" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" EnableEmbeddedSkins="false"
                 Skin="MySilk"></telerik:RadTextBox></td>
            <td><asp:HyperLink class="frm_boton" ID="linkBuscar" runat="server">Ir</asp:HyperLink>
            </td>
          </tr>
            </table>
      </div>
          <div class="margen"></div>
      <table border="0" cellpadding="0" cellspacing="0" class="grid">   
      </table>    
 <telerik:RadGrid ID="rgCompetenciasPuesto" HorizontalAlign="Center" runat="server" EditMode="EditForms" 
        CellSpacing="0" Culture="es-ES" DataSourceID="odsCompetenciaPuesto"
        OnInsertCommand="rgCompetenciasPuesto_InsertCommand" OnDeleteCommand="rgCompetenciasPuesto_DeleteCommand"
        OnUpdateCommand="rgCompetenciasPuesto_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="100%" 
        OnItemDataBound="rgCompetenciasPuesto_ItemDataBound" AllowSorting="true" AllowFilteringByColumn="False"
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto" EnableLinqExpressions="false">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView DataSourceID="odsCompetenciaPuesto"
        CommandItemDisplay="Top" DataKeyNames="ID" HorizontalAlign="NotSet" AutoGenerateColumns="False" EditMode="EditForms" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen Competencias por Puesto registradas.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Competencias Por Puesto" RefreshText="Actualizar"></CommandItemSettings>   
            <Columns>                                                  
                <telerik:GridTemplateColumn  HeaderText="EMPRESA" HeaderStyle-Width="25%" SortExpression="oBE_EMPRESA.DESCRIPCION" UniqueName="oBE_EMPRESA.DESCRIPCION" DataField="oBE_EMPRESA.DESCRIPCION"
                AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_EMPRESA.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbEmpresa" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsEmpresa" LoadingMessage="Cargando..." Width="50%" AutoPostBack="true" OnSelectedIndexChanged="rcbEmpresa_SelectedIndexChanged">
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ControlToValidate="rcbEmpresa" 
                                ForeColor="Red" Text="*">
                            </asp:RequiredFieldValidator>     
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>   
                    <telerik:GridTemplateColumn  HeaderText="PUESTO" HeaderStyle-Width="25%" SortExpression="oBE_PUESTO.DESCRIPCION" UniqueName="oBE_PUESTO.DESCRIPCION" DataField="oBE_PUESTO.DESCRIPCION"
                AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_PUESTO.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbPuesto" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsPuesto" LoadingMessage="Cargando..." Width="50%">
                            </telerik:RadComboBox>                               
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn> 
                    <telerik:GridTemplateColumn HeaderText="COMPETENCIA" HeaderStyle-Width="25%" SortExpression="oBE_COMPETENCIA.DESCRIPCION" DataField="oBE_COMPETENCIA.DESCRIPCION" UniqueName="oBE_COMPETENCIA.DESCRIPCION"
                    AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_COMPETENCIA.DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox
                            runat="server" ID="rcbCompetencia" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="DESCRIPCION" AllowCustomText="true" DataSourceID="odsCompetencia" LoadingMessage="Cargando..." Width="50%">
                            </telerik:RadComboBox>                          
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn> 
                    <telerik:GridBoundColumn DataField="COMPETENCIA_PUESTO_VALOR_REQUERIDO"
                    HeaderText="VALOR REQUERIDO" SortExpression="COMPETENCIA_PUESTO_VALOR_REQUERIDO" UniqueName="COMPETENCIA_PUESTO_VALOR_REQUERIDO" HeaderStyle-Width="25%">
                    <%--<ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>--%>
                </telerik:GridBoundColumn>                    
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" EditText="Actualizar"
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Competencia por Puesto?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Eliminar Competencia Por Puesto " ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarComptenciaPorPuesto">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings>
             <EditColumn UniqueName="EditCommandColumn" CancelText="Cancelar" UpdateText="Actualizar" InsertText="Insertar">
             </EditColumn>
            </EditFormSettings>
            <PagerStyle Mode="NextPrevAndNumeric" PageSizeLabelText="Nro. Items por Página:" PagerTextFormat="{4} Página {0} de {1}, Filas {2} a {3} de {5}" />            
        </MasterTableView>             
    </telerik:RadGrid>
    <br />
    <div>
    <asp:ValidationSummary ID="ValidationSummary" ForeColor="Red" 
        HeaderText="(*) Campos Obligatorios."
        DisplayMode="SingleParagraph"
        EnableClientScript="true"
        runat="server"/>
        </div>  
     <asp:ObjectDataSource ID="odsCompetenciaPuesto" runat="server" SelectMethod="SeleccionarCompetenciasPorPuesto"         
        TypeName="BusinessLogicLayer.BL_COMPETENCIAS_POR_PUESTO" DataObjectTypeName="BusinessEntities.BE_AREA">    
    </asp:ObjectDataSource>  
    <asp:ObjectDataSource ID="odsPuesto" runat="server" SelectMethod="SeleccionarPuesto"         
        TypeName="BusinessLogicLayer.BL_PUESTO">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsCompetencia" runat="server" SelectMethod="SeleccionarCompetencias"         
        TypeName="BusinessLogicLayer.BL_COMPETENCIA">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsEmpresa" runat="server" SelectMethod="SeleccionarEmpresa"         
        TypeName="BusinessLogicLayer.BL_EMPRESA">
    </asp:ObjectDataSource>   
    
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
</asp:Content>
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="Competencias.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.Competencias" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
           
  <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" /> 
  <script type="text/javascript">
      function showRadConfirm(text) {
          radalert(text, null, null, "Eliminar Competencia");
      }
  </script>        
          <div class="frm_titulo01">Administrar Catálogo Compentencia</div>          
       
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

        <telerik:RadGrid ID="rgCompetencia" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsCompetencia" OnItemDataBound="rgCompetencia_ItemDataBound"
        OnInsertCommand="rgCompetencia_InsertCommand" OnDeleteCommand="rgCompetencia_DeleteCommand"
        OnUpdateCommand="rgCompetencia_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="100%" AllowSorting="true" AllowFilteringByColumn="False" 
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto" EnableLinqExpressions="false">
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView DataSourceID="odsCompetencia" CommandItemDisplay="Top" DataKeyNames="ID" HorizontalAlign="NotSet" 
        AutoGenerateColumns="False" EditMode="EditForms" OverrideDataSourceControlSorting="true">
            <NoRecordsTemplate>
                No existen Competencias registradas.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Competencia" RefreshText="Actualizar"></CommandItemSettings>   
            <Columns>     
                <telerik:GridBoundColumn DataField="CODIGO" HeaderText="CODIGO" SortExpression="CODIGO" UniqueName="CODIGO" HeaderStyle-Width="20%" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn> 
                <telerik:GridTemplateColumn HeaderText="TIPO" HeaderStyle-Width="40%" SortExpression="oBE_COMPETENCIA_TIPO.COMPETENCIA_TIPO_DESCRIPCION" DataField="oBE_COMPETENCIA_TIPO.COMPETENCIA_TIPO_DESCRIPCION" UniqueName="oBE_COMPETENCIA_TIPO.COMPETENCIA_TIPO_DESCRIPCION"
                AutoPostBackOnFilter="true">
                        <ItemTemplate>
                            <%# Eval("oBE_COMPETENCIA_TIPO.COMPETENCIA_TIPO_DESCRIPCION")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <telerik:RadComboBox runat="server" ID="rcbTipoCompetencia" DataValueField="ID" MarkFirstMatch="true" Filter="None" EnableTextSelection="true"
                                DataTextField="COMPETENCIA_TIPO_DESCRIPCION" AllowCustomText="true" DataSourceID="odsTipoCompetencia" LoadingMessage="Cargando..." Width="50%">
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvTipoCompetencia" runat="server" ControlToValidate="rcbTipoCompetencia" 
                                ForeColor="Red" Text="*">
                            </asp:RequiredFieldValidator>     
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>                 
                <telerik:GridBoundColumn DataField="DESCRIPCION" HeaderText="COMPETENCIA" SortExpression="DESCRIPCION" UniqueName="DESCRIPCION" HeaderStyle-Width="40%" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>                        
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" EditText="Actualizar"
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar esta Competencia?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Eliminar Competencia" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarCompetencia">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings>
             <EditColumn UniqueName="EditCommandColumn" CancelText="Cancelar" UpdateText="Actualizar"
                              InsertText="Insertar">
                            </EditColumn>
            </EditFormSettings>
            <PagerStyle Mode="NextPrevAndNumeric" PageSizeLabelText="Nro. Items por Página:" PagerTextFormat="{4} Página {0} de {1}, Filas {2} a {3} de {5}" />
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>
    <br />
    <div>
    <asp:ValidationSummary ID="ValidationSummary" ForeColor="Red" 
        HeaderText="(*) Campos Obligatorios."
        DisplayMode="SingleParagraph"
        EnableClientScript="true"
        runat="server"/>
        </div>    
    <asp:ObjectDataSource ID="odsCompetencia" runat="server" SelectMethod="SeleccionarCompetencias"         
        TypeName="BusinessLogicLayer.BL_COMPETENCIA">
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="odsTipoCompetencia" runat="server" SelectMethod="SeleccionarCompetenciasTipos"         
        TypeName="BusinessLogicLayer.BL_COMPETENCIAS_TIPOS">
    </asp:ObjectDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
   
</asp:Content>
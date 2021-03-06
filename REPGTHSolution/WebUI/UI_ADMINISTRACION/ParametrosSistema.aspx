﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/MP.Master" CodeBehind="ParametrosSistema.aspx.cs" Inherits="WebUI.UI_ADMINISTRACION.ParametrosSistema" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
           
  <link href="../Styles/Grid.MySilk.css" rel="stylesheet" type="text/css" /> 
  <script type="text/javascript">
      function showRadConfirm(text) {
          radalert(text, null, null, "Eliminar Parámetro del Sistema");
      }
  </script>        
          <div class="frm_titulo01">Administrar Parámetros del Sistema</div>          
       
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

        <telerik:RadGrid ID="rgParametros" HorizontalAlign="Center" runat="server"  
        CellSpacing="0" Culture="es-ES" DataSourceID="odsParametros"
        OnInsertCommand="rgParametros_InsertCommand" OnDeleteCommand="rgParametros_DeleteCommand"
        OnUpdateCommand="rgParametros_UpdateCommand" PageSize="10"
        GridLines="None" AllowPaging="True" Width="100%" AllowSorting="true" AllowFilteringByColumn="False" 
        EnableEmbeddedSkins="False" Skin="MySilk" ImagesPath="../Styles/Grid/" style="margin: auto" EnableLinqExpressions="false">
            <groupingsettings casesensitive="False" />
        <ExportSettings>
            <Pdf PageWidth="" />
        </ExportSettings>
        <MasterTableView DataSourceID="odsParametros" CommandItemDisplay="Top" DataKeyNames="ID" HorizontalAlign="NotSet" 
        AutoGenerateColumns="False" EditMode="EditForms" OverrideDataSourceControlSorting="true" CommandItemSettings-ShowAddNewRecordButton="false">
            <NoRecordsTemplate>
                No existen Parámetros registrados.
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Añadir Parámetro" RefreshText="Actualizar"></CommandItemSettings>   

<RowIndicatorColumn Visible="True" FilterImageUrl="../Styles/Grid/Filter.gif" SortAscImageUrl="../Styles/Grid/SortAsc.gif" SortDescImageUrl="../Styles/Grid/SortDesc.gif" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn ExpandImageUrl="../Styles/Grid/SinglePlus.gif" CollapseImageUrl="../Styles/Grid/SingleMinus.gif" Visible="True" FilterImageUrl="../Styles/Grid/Filter.gif" SortAscImageUrl="../Styles/Grid/SortAsc.gif" SortDescImageUrl="../Styles/Grid/SortDesc.gif" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>     
                <telerik:GridBoundColumn DataField="CODIGO" HeaderText="CODIGO" SortExpression="CODIGO" UniqueName="CODIGO" HeaderStyle-Width="30%" Display="false"
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>

<HeaderStyle Width="30%"></HeaderStyle>
                </telerik:GridBoundColumn>                           
                <telerik:GridBoundColumn DataField="DESCRIPCION" HeaderText="PARAMETRO" SortExpression="DESCRIPCION" UniqueName="DESCRIPCION" HeaderStyle-Width="40%" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>

<HeaderStyle Width="40%"></HeaderStyle>
                </telerik:GridBoundColumn>     
                <telerik:GridBoundColumn DataField="VALOR" HeaderText="VALOR" SortExpression="VALOR" UniqueName="VALOR" HeaderStyle-Width="60%" 
                    AutoPostBackOnFilter="true">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>

<HeaderStyle Width="50%"></HeaderStyle>
                </telerik:GridBoundColumn>                    
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" EditText="Actualizar"
                    UniqueName="EditCommandColumn" CancelImageUrl="../Styles/Grid/Cancel.gif" 
                    InsertImageUrl="../Styles/Grid/Update.gif" UpdateImageUrl="../Styles/Grid/Update.gif">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn ConfirmText="¿Deseas eliminar este Parámetro?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Eliminar Parámetro" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="EliminarParámetro">
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

<PagerStyle PrevPageImageUrl="../Styles/Grid/PagingPrev.gif" NextPageImageUrl="../Styles/Grid/PagingNext.gif" FirstPageImageUrl="../Styles/Grid/PagingFirst.gif" LastPageImageUrl="../Styles/Grid/PagingLast.gif" PageSizeControlType="RadComboBox"></PagerStyle>

        <FilterMenu EnableImageSprites="False">
        </FilterMenu>

<HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
    </telerik:RadGrid>
    <br />
    <div>
    <asp:ValidationSummary ID="ValidationSummary" ForeColor="Red" 
        HeaderText="(*) Campos Obligatorios."
        DisplayMode="SingleParagraph"
        EnableClientScript="true"
        runat="server"/>
        </div>    
    <asp:ObjectDataSource ID="odsParametros" runat="server" SelectMethod="SeleccionarParametros"         
        TypeName="BusinessLogicLayer.BL_PARAMETRO">
    </asp:ObjectDataSource>    
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
   
</asp:Content>
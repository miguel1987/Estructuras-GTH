<%@ Page Language="C#" MasterPageFile="~/Template/MP.Master" AutoEventWireup="true" CodeBehind="Solicitud.aspx.cs" Inherits="WebUI.UI_ARCHIVO.Solicitud" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">--%>
     
<%--</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_contenedor" runat="server">
<link href="../Styles/PanelBar.css" rel="stylesheet" type="text/css" />
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
 <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="Label,Textbox,select,textarea" Skin="Silk" />
 <h1 class="tit_01">SOLICITUD DE CORRESPONDENCIA</h1>
 <div class="panel-container">       
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
            <telerik:RadPanelBar runat="server" ID="rpbSolicitud" ExpandMode="SingleExpandedItem" Skin="Silk" Width="100%">
                <Items>
                    <telerik:RadPanelItem Expanded="True" Text="Datos de la Solicitud" runat="server" Selected="true">
                        <Items>
                            <telerik:RadPanelItem Value="DatosSolicitud" runat="server">
                                <ItemTemplate>
                                    <div class="qsf-fb">
                                        <ul id="datosSolicitud">
                                            <li>
                                                <asp:Label runat="server" ID="lblNumeroSolicitud" AssociatedControlID="txtNumeroSolicitud" Visible="false">Nro. Solicitud REP:</asp:Label>
                                             <asp:TextBox ID="txtNumeroSolicitud" runat="server" ValidationGroup="SolicitudValidationGroup"
                                                    Width="200px" Enabled="false" CssClass="textInput" Visible="false"></asp:TextBox>
                                             <asp:DropDownList ID="ddlProveedor" runat="server"  Width="10px" AutoPostBack="True" visible="false"></asp:DropDownList> 
                                            </li>
                                            <li>
                                             <asp:Label runat="server" ID="lblPrioridad" AssociatedControlID="ddlPrioridad">Prioridad:</asp:Label>                                                
                                                <asp:DropDownList ID="ddlPrioridad" runat="server" ValidationGroup="SolicitudValidationGroup" Width="150px" AutoPostBack="True">
                                                    <asp:ListItem Value="1">Normal</asp:ListItem>
                                                    <asp:ListItem Value="2">Media</asp:ListItem>
                                                    <asp:ListItem Value="3">Urgente</asp:ListItem>
                                                </asp:DropDownList>   
                                            <asp:Label runat="server" ID="lblFechaRegistro"  CssClass="label2" AssociatedControlID="rdpFechaRegistro">Fecha:</asp:Label>
                                            <telerik:RadDatePicker ID="rdpFechaRegistro" CssClass="dateInput" runat="server" ValidationGroup="SolicitudValidationGroup" 
                                                 Width="140px" Skin="Silk"></telerik:RadDatePicker>                                               
                                             <asp:RequiredFieldValidator runat="server" ID="rfvFechaRegistro" ValidationGroup="SolicitudValidationGroup" 
                                                    ControlToValidate="rdpFechaRegistro" ForeColor="Red" ErrorMessage="(*) Ingresar Fecha de Registro" Text="(*)"></asp:RequiredFieldValidator>                                                                                                                                 
                                            </li>                                                                                    
                                            <li>
                                                <asp:Label runat="server" ID="lblEmpresa" AssociatedControlID="ddlEmpresa">Empresa:</asp:Label>
                                                <asp:DropDownList ID="ddlEmpresa" runat="server" ValidationGroup="SolicitudValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlEmpresa_SelectedIndexChanged">
                                                </asp:DropDownList>                                               
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblGerencia" AssociatedControlID="ddlGerencia">Gerencia:</asp:Label>
                                                <asp:DropDownList ID="ddlGerencia" runat="server" ValidationGroup="SolicitudValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlGerencia_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblArea" AssociatedControlID="ddlArea">Area:</asp:Label>
                                                <asp:DropDownList ID="ddlArea" runat="server" ValidationGroup="SolicitudValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblTipoSolicitud" AssociatedControlID="ddlTipoSolicitud">Tipo de Solicitud:</asp:Label>                                                
                                                <asp:DropDownList ID="ddlTipoSolicitud" runat="server" ValidationGroup="SolicitudValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoSolicitud_SelectedIndexChanged">
                                                    <asp:ListItem Value="1">Mensajería y Flete Nacional</asp:ListItem>
                                                    <asp:ListItem Value="2">Mensajería y Flete Internacional</asp:ListItem>
                                                </asp:DropDownList>
                                            </li>                                         
                                            <li>
                                                <asp:Label runat="server" ID="lblSolicitante" AssociatedControlID="txtSolicitante">Solicitante:</asp:Label>
                                                <asp:TextBox ID="txtSolicitante" CssClass="textInput" runat="server" ValidationGroup="SolicitudValidationGroup"
                                                    Width="200px"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvSolicitante" ValidationGroup="SolicitudValidationGroup"
                                                    ControlToValidate="txtSolicitante" ForeColor="Red" ErrorMessage="(*) Ingresar Solicitante" Text="(*)"></asp:RequiredFieldValidator>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblCentroCosto" AssociatedControlID="ddlCentroCosto">Centro de Costo:</asp:Label>
                                                <asp:DropDownList ID="ddlCentroCosto" runat="server" ValidationGroup="SolicitudValidationGroup" Width="145px" AutoPostBack="True" OnSelectedIndexChanged="ddlCentroCosto_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtOtroCentroCosto" CssClass="textInput4" runat="server" ValidationGroup="SolicitudValidationGroup" Width="100px" Visible="false" MaxLength="7"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rfvOtroCentroCosto" runat="server" ValidationExpression="\d+" ControlToValidate="txtOtroCentroCosto" 
                                                ForeColor="Red" ErrorMessage="Sólo puede ingresar números" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblOrden" AssociatedControlID="ddlOrden">Orden:</asp:Label>
                                                <asp:DropDownList ID="ddlOrden" runat="server" ValidationGroup="SolicitudValidationGroup" Width="145px" AutoPostBack="True" OnSelectedIndexChanged="ddlOrden_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtOtraOrden" CssClass="textInput4" runat="server" ValidationGroup="SolicitudValidationGroup" Width="100px" Visible="false" MaxLength="9"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rfvOtraOrden" runat="server" ValidationExpression="\d+" ControlToValidate="txtOtraOrden" 
                                                ForeColor="Red" ErrorMessage="Sólo puede ingresar números" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblCentroGestor" AssociatedControlID="ddlCentroGestor">Centro Gestor:</asp:Label>
                                                <asp:DropDownList ID="ddlCentroGestor" runat="server" ValidationGroup="SolicitudValidationGroup" Width="145px" AutoPostBack="True" OnSelectedIndexChanged="ddlCentroGestor_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtOtroCentroGestor" CssClass="textInput4" runat="server" ValidationGroup="SolicitudValidationGroup" Width="100px" Visible="false" MaxLength="5"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rfvOtroCentroGestor" runat="server" ValidationExpression="^a-zA-Z0-9\s" ControlToValidate="txtOtraOrden" 
                                                ForeColor="Red" ErrorMessage="Sólo puede ingresar números y letras" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblCuentaMayor" AssociatedControlID="ddlCuentaMayor">Cuenta Mayor:</asp:Label>
                                                <asp:DropDownList ID="ddlCuentaMayor" runat="server" ValidationGroup="SolicitudValidationGroup" Width="355px" AutoPostBack="True">
                                                </asp:DropDownList>                                                
                                            </li>
                                               <li>
                                                <asp:Label runat="server" ID="lblAutoriza" AssociatedControlID="ddlAutoriza">Autoriza:</asp:Label>
                                                <asp:DropDownList ID="ddlAutoriza" runat="server" ValidationGroup="SolicitudValidationGroup" Width="355px" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblSolicitarAprobacion" AssociatedControlID="chkSolicitarAprobacion">Solicitar Aprobación:</asp:Label>
                                                <asp:CheckBox runat="server" ID="chkSolicitarAprobacion" Text="Notificar por Correo" />                                                                                          
                                            </li>
                                        </ul>
                                        <br />    
                                         <asp:ValidationSummary runat="server" ForeColor="Red" ID="validationSummary" CssClass="validationSummary" ValidationGroup="SolicitudValidationGroup" />                                    
                                        <p class="button_next">
                                            <telerik:RadButton runat="server" ID="btnSiguienteDatosSolicitud" OnClick="SiguienteButton_Click" Text="Siguiente" Skin="Silk"
                                                ValidationGroup="SolicitudValidationGroup" />
                                        </p>
                                    </div>
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem Enabled="false" Text="Datos del Envío Nacional" runat="server">
                        <Items>
                            <telerik:RadPanelItem Value="DatosEnvioNacional" runat="server">
                                <ItemTemplate>
                                    <div class="qsf-fb" id="datosEnvioNacional">                                        
                                        <ul>
                                            <li>
                                             <asp:Label runat="server" ID="lblOrdenCourier" AssociatedControlID="txtOrdenCourier">Nro. Orden Courier:</asp:Label>
                                             <asp:TextBox ID="txtOrdenCourier" runat="server" ValidationGroup="EnvioValidationGroup"
                                              Enabled="true" CssClass="textInput2"></asp:TextBox> 
                                             <asp:RequiredFieldValidator runat="server" ID="rfvOrdenCourier" ValidationGroup="EnvioValidationGroup" 
                                                ControlToValidate="txtOrdenCourier" ForeColor="Red" ErrorMessage="(*) Ingresar Nro. Orden Courier" Text="(*)"></asp:RequiredFieldValidator>

                                            <asp:Label runat="server" ID="lblFechaEnvio"  CssClass="label2" AssociatedControlID="rdpFechaEnvio">Fecha:</asp:Label>
                                            <telerik:RadDatePicker ID="rdpFechaEnvio" CssClass="dateInput" runat="server" ValidationGroup="EnvioValidationGroup" 
                                                 Width="140px" Skin="Silk"></telerik:RadDatePicker>                                               
                                             <asp:RequiredFieldValidator runat="server" ID="rfvFechaEnvio" ValidationGroup="EnvioValidationGroup" 
                                                    ControlToValidate="rdpFechaEnvio" ForeColor="Red" ErrorMessage="(*) Ingresar Fecha de Registro" Text="(*)"></asp:RequiredFieldValidator>                                                                                                                                 
                                            </li>      
                                            <li>
                                                <asp:Label runat="server" ID="lblRemitente" AssociatedControlID="txtRemitente">Remitente:</asp:Label>
                                                <asp:TextBox ID="txtRemitente" CssClass="textInput" runat="server" ValidationGroup="EnvioValidationGroup"
                                                    Width="200px" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvRemitente" ValidationGroup="EnvioValidationGroup"
                                                    ControlToValidate="txtRemitente" ForeColor="Red" ErrorMessage="(*) Ingresar Remitente" Text="(*)"></asp:RequiredFieldValidator>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblRemitenteSede" AssociatedControlID="ddlDireccionRemitente">Sede:</asp:Label>
                                                <asp:DropDownList ID="ddlDireccionRemitente" runat="server" ValidationGroup="EnvioValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlDireccionRemitente_SelectedIndexChanged">
                                                </asp:DropDownList>                   
                                             </li>
                                             <li>
                                                <asp:Label runat="server" ID="lblOtroRemitente" AssociatedControlID="txtDireccionRemitente" Text="Nueva Sede:" Visible="false"></asp:Label>                                                
                                                 <asp:TextBox ID="txtOtroRemitente" CssClass="textInput4" runat="server" ValidationGroup="EnvioValidationGroup"
                                                    Width="50px" Visible="false"></asp:TextBox>                                             
                                            </li>
                                             <li>
                                                <asp:Label runat="server" ID="lblDireccionRemitente" AssociatedControlID="ddlDireccionRemitente">Dirección:</asp:Label>
                                                <asp:TextBox ID="txtDireccionRemitente" CssClass="textInput" runat="server" ValidationGroup="EnvioValidationGroup"
                                                    Width="200px" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvDireccionRemitente" ValidationGroup="EnvioValidationGroup"
                                                    ControlToValidate="txtDireccionRemitente" ForeColor="Red" ErrorMessage="(*) Ingresar Dirección Destinatario" Text="(*)"></asp:RequiredFieldValidator>                                                
                                            </li>                                               
                                            <li>
                                                 <asp:Label runat="server" ID="lblTipoEnvio" AssociatedControlID="ddlTipoEnvio">Tipo Envío:</asp:Label>                                                
                                                 <asp:DropDownList ID="ddlTipoEnvio" runat="server" ValidationGroup="EnvioValidationGroup" Width="110px" AutoPostBack="True">
                                                        <asp:ListItem Value="1">Sobre</asp:ListItem>
                                                        <asp:ListItem Value="2">Paquete</asp:ListItem>
                                                 </asp:DropDownList>                                         

                                                <asp:Label runat="server" ID="lblCantidad"  CssClass="label4" AssociatedControlID="txtCantidad">Cantidad:</asp:Label>
                                                <asp:TextBox ID="txtCantidad" runat="server" ValidationGroup="EnvioValidationGroup"
                                                  Enabled="true" Width="135"></asp:TextBox>                                             
                                              
                                                 <asp:RequiredFieldValidator runat="server" ID="rfvCantidad" ValidationGroup="EnvioValidationGroup" 
                                                        ControlToValidate="txtCantidad" ForeColor="Red" ErrorMessage="(*) Ingresar Cantidad" Text="(*)"></asp:RequiredFieldValidator>                                                                                                                                 
                                            </li>    
                                            <li>
                                                 <asp:Label runat="server" ID="lblCaracteristica" AssociatedControlID="ddlCaracteristica">Característica:</asp:Label>                                                
                                                 <asp:DropDownList ID="ddlCaracteristica" runat="server" ValidationGroup="EnvioValidationGroup" Width="110px" AutoPostBack="True">
                                                        <asp:ListItem Value="0">Ninguna</asp:ListItem>
                                                        <asp:ListItem Value="1">Confidencial</asp:ListItem>
                                                        <asp:ListItem Value="2">Frágil</asp:ListItem>
                                                 </asp:DropDownList>                                         

                                               <asp:Label runat="server" ID="lblGuia"  CssClass="label4" AssociatedControlID="txtGuia">Nro. Guía:</asp:Label>
                                                <asp:TextBox ID="txtGuia" runat="server" ValidationGroup="EnvioValidationGroup"
                                                  Enabled="true" Width="135"></asp:TextBox>  
                                            </li>    
                                             <li>
                                                 <asp:Label runat="server" ID="lblPeso" AssociatedControlID="txtPeso">Peso (Kg.):</asp:Label>                                                
                                                 <asp:TextBox ID="txtPeso" runat="server" ValidationGroup="EnvioValidationGroup"
                                                 Enabled="true" CssClass="textInput3"></asp:TextBox> 
                                                <asp:RequiredFieldValidator runat="server" ID="rfvPeso" ValidationGroup="EnvioValidationGroup" 
                                                ControlToValidate="txtPeso" ForeColor="Red" ErrorMessage="(*) Ingresar Peso" Text="(*)"></asp:RequiredFieldValidator>                                      

                                                <asp:Label runat="server" ID="lblCosto"  CssClass="label3" AssociatedControlID="txtCosto">Costo Ref(S/.):</asp:Label>
                                                <asp:TextBox ID="txtCosto" runat="server" ValidationGroup="EnvioValidationGroup"
                                                  Enabled="true" Width="135"></asp:TextBox>                                             
                                              
                                                 <asp:RequiredFieldValidator runat="server" ID="rfvCosto" ValidationGroup="EnvioValidationGroup" 
                                                        ControlToValidate="txtCosto" ForeColor="Red" ErrorMessage="(*) Ingresar Costo Referencia" Text="(*)"></asp:RequiredFieldValidator>                                                                                                                                 
                                            </li> 
                                            <li>
                                                <asp:Label runat="server" ID="lblContenido" AssociatedControlID="txtContenido">Contenido:</asp:Label>
                                                <asp:TextBox ID="txtContenido" runat="server" Columns="85" Rows="5" TextMode="MultiLine" ValidationGroup="EnvioValidationGroup"
                                                    CssClass="textInput"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvContenido" ValidationGroup="EnvioValidationGroup"
                                                    ControlToValidate="txtContenido" ForeColor="Red" ErrorMessage="(*) Ingresar Contenido" Text="(*)"></asp:RequiredFieldValidator>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblDestinatario" AssociatedControlID="txtDestinatario">Destinatario:</asp:Label>
                                               <%-- <asp:DropDownList ID="ddlDireccionDestinatario" runat="server" ValidationGroup="EnvioValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlDireccionDestinatario_SelectedIndexChanged">
                                                </asp:DropDownList>    --%>   
                                                <telerik:RadComboBox ID="ddlDireccionDestinatario" runat="server" ValidationGroup="EnvioValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlDireccionDestinatario_SelectedIndexChanged" 
                                                AllowCustomText="true" MarkFirstMatch="true" AutoCompleteSeparator="">
                                                </telerik:RadComboBox>                                          
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblOtroDestinatario" AssociatedControlID="txtDestinatario" Text="Nuevo Destinatario:" Visible="false"></asp:Label>                                                
                                                <asp:TextBox ID="txtOtroDestinatario" CssClass="textInput4" runat="server" ValidationGroup="EnvioValidationGroup"
                                                    Width="100px" Visible="false"></asp:TextBox>                                               
                                            </li>
                                             <li>
                                                <asp:Label runat="server" ID="lblDireccionDestinatario" AssociatedControlID="ddlDireccionDestinatario">Dirección:</asp:Label>
                                                <asp:TextBox ID="txtDestinatario" CssClass="textInput" runat="server" ValidationGroup="EnvioValidationGroup"
                                                    Width="200px" TextMode="MultiLine"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator runat="server" ID="rfvDestinatario" ValidationGroup="EnvioValidationGroup"
                                                    ControlToValidate="txtDestinatario" ForeColor="Red" ErrorMessage="(*) Ingresar Dirección Destinatario" Text="(*)"></asp:RequiredFieldValidator>                                                --%>
                                            </li>   
                                            <li>
                                                <asp:Label runat="server" ID="lblAtencion" AssociatedControlID="ddlAtencion">Atención:</asp:Label>
                                                <%--<asp:DropDownList ID="ddlAtencion" runat="server" ValidationGroup="EnvioValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlAtencion_SelectedIndexChanged">
                                                </asp:DropDownList> --%>   
                                                <telerik:RadComboBox ID="ddlAtencion" runat="server" ValidationGroup="EnvioValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlAtencion_SelectedIndexChanged" 
                                                AllowCustomText="true" MarkFirstMatch="true" AutoCompleteSeparator="">
                                                </telerik:RadComboBox>                                               
                                                <%--<asp:RequiredFieldValidator runat="server" ID="rfvAtencion" ValidationGroup="EnvioValidationGroup"
                                                    ControlToValidate="ddlAtencion" ForeColor="Red" ErrorMessage="(*) Ingresar Destinatario Atención" Text="(*)"></asp:RequiredFieldValidator>--%>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblOtraAtencion" AssociatedControlID="txtOtraAtencion" Text="Nueva Atención:" Visible="false"></asp:Label>                                                
                                                <asp:TextBox ID="txtOtraAtencion" CssClass="textInput4" runat="server" ValidationGroup="EnvioValidationGroup"
                                                    Width="100px" Visible="false"></asp:TextBox>                                               
                                            </li>
                                        </ul>  
                                        <br />  
                                        <asp:ValidationSummary runat="server" ForeColor="Red" ID="validationSummary" CssClass="validationSummary" ValidationGroup="EnvioValidationGroup" />                                    
                                    </div>
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem Enabled="false" Visible="false" Text="Datos del Envío Internacional" runat="server">
                        <Items>
                            <telerik:RadPanelItem Value="DatosEnvioInternacional" runat="server">
                                <ItemTemplate>
                                    <div class="qsf-fb" id="datosEnvioInternacional">                                        
                                        <ul>
                                            <li>
                                             <asp:Label runat="server" ID="lblOrdenCourier" AssociatedControlID="txtOrdenCourier">Nro. Orden Courier:</asp:Label>
                                             <asp:TextBox ID="txtOrdenCourier" runat="server" ValidationGroup="EnvioValidationGroup"
                                              Enabled="true" CssClass="textInput2"></asp:TextBox> 
                                             <asp:RequiredFieldValidator runat="server" ID="rfvOrdenCourier" ValidationGroup="EnvioValidationGroup" 
                                                ControlToValidate="txtOrdenCourier" ForeColor="Red" ErrorMessage="(*) Ingresar Nro. Orden Courier" Text="(*)"></asp:RequiredFieldValidator>

                                            <asp:Label runat="server" ID="lblFechaEnvio"  CssClass="label2" AssociatedControlID="rdpFechaEnvio">Fecha:</asp:Label>
                                            <telerik:RadDatePicker ID="rdpFechaEnvio" CssClass="dateInput" runat="server" ValidationGroup="EnvioValidationGroup" 
                                                 Width="140px" Skin="Silk"></telerik:RadDatePicker>                                               
                                             <asp:RequiredFieldValidator runat="server" ID="rfvFechaEnvio" ValidationGroup="EnvioValidationGroup" 
                                                    ControlToValidate="rdpFechaEnvio" ForeColor="Red" ErrorMessage="(*) Ingresar Fecha de Registro" Text="(*)"></asp:RequiredFieldValidator>                                                                                                                                 
                                            </li>      
                                            <li>
                                                <asp:Label runat="server" ID="lblRemitente" AssociatedControlID="txtRemitente">Remitente:</asp:Label>
                                                <asp:TextBox ID="txtRemitente" CssClass="textInput" runat="server" ValidationGroup="EnvioValidationGroup"
                                                    Width="200px"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvRemitente" ValidationGroup="EnvioValidationGroup"
                                                    ControlToValidate="txtRemitente" ForeColor="Red" ErrorMessage="(*) Ingresar Remitente" Text="(*)"></asp:RequiredFieldValidator>
                                            </li>
                                             <li>
                                                <asp:Label runat="server" ID="lblRemitenteSede" AssociatedControlID="ddlDireccionRemitente">Sede:</asp:Label>
                                                <asp:DropDownList ID="ddlDireccionRemitente" runat="server" ValidationGroup="EnvioValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlDireccionRemitente_SelectedIndexChanged">
                                                </asp:DropDownList>                   
                                             </li>
                                             <li>
                                                <asp:Label runat="server" ID="lblOtroRemitente" AssociatedControlID="txtDireccionRemitente" Text="Nueva Sede:" Visible="false"></asp:Label>                                                
                                                 <asp:TextBox ID="txtOtroRemitente" CssClass="textInput4" runat="server" ValidationGroup="EnvioValidationGroup"
                                                    Width="50px" Visible="false"></asp:TextBox>                                             
                                            </li>
                                             <li>
                                                <asp:Label runat="server" ID="lblDireccionRemitente" AssociatedControlID="ddlDireccionRemitente">Dirección:</asp:Label>
                                                <asp:TextBox ID="txtDireccionRemitente" CssClass="textInput" runat="server" ValidationGroup="EnvioValidationGroup"
                                                    Width="200px" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvDireccionRemitente" ValidationGroup="EnvioValidationGroup"
                                                    ControlToValidate="txtDireccionRemitente" ForeColor="Red" ErrorMessage="(*) Ingresar Dirección Destinatario" Text="(*)"></asp:RequiredFieldValidator>                                                
                                            </li>
                                             <li>
                                                 <asp:Label runat="server" ID="lblTipoEnvio" AssociatedControlID="ddlTipoEnvio">Tipo Envío:</asp:Label>                                                
                                                 <asp:DropDownList ID="ddlTipoEnvio" runat="server" ValidationGroup="EnvioValidationGroup" Width="110px" AutoPostBack="True">
                                                        <asp:ListItem Value="1">Sobre</asp:ListItem>
                                                        <asp:ListItem Value="2">Paquete</asp:ListItem>
                                                 </asp:DropDownList>                                         

                                                <asp:Label runat="server" ID="lblCantidad"  CssClass="label4" AssociatedControlID="txtCantidad">Cantidad:</asp:Label>
                                                <asp:TextBox ID="txtCantidad" runat="server" ValidationGroup="EnvioValidationGroup"
                                                  Enabled="true" Width="135"></asp:TextBox>                                             
                                              
                                                 <asp:RequiredFieldValidator runat="server" ID="rfvCantidad" ValidationGroup="EnvioValidationGroup" 
                                                        ControlToValidate="txtCantidad" ForeColor="Red" ErrorMessage="(*) Ingresar Cantidad" Text="(*)"></asp:RequiredFieldValidator>                                                                                                                                 
                                            </li>  
                                            <li>
                                                 <asp:Label runat="server" ID="lblPeso" AssociatedControlID="txtPeso">Peso (Kg.):</asp:Label>                                                
                                                 <asp:TextBox ID="txtPeso" runat="server" ValidationGroup="EnvioValidationGroup"
                                                 Enabled="true" CssClass="textInput3"></asp:TextBox> 
                                                <asp:RequiredFieldValidator runat="server" ID="rfvPeso" ValidationGroup="EnvioValidationGroup" 
                                                ControlToValidate="txtPeso" ForeColor="Red" ErrorMessage="(*) Ingresar Peso" Text="(*)"></asp:RequiredFieldValidator>                                      

                                                <asp:Label runat="server" ID="lblCosto"  CssClass="label3" AssociatedControlID="txtCosto">Costo Ref(S/.):</asp:Label>
                                                <asp:TextBox ID="txtCosto" runat="server" ValidationGroup="EnvioValidationGroup"
                                                  Enabled="true" Width="135"></asp:TextBox>                                             
                                              
                                                 <asp:RequiredFieldValidator runat="server" ID="rfvCosto" ValidationGroup="EnvioValidationGroup" 
                                                        ControlToValidate="txtCosto" ForeColor="Red" ErrorMessage="(*) Ingresar Costo Referencia" Text="(*)"></asp:RequiredFieldValidator>                                                                                                                                 
                                            </li> 
                                            <li>
                                                 <asp:Label runat="server" ID="lblMedidas" AssociatedControlID="txtMedidas">Medidas (LxWxH):</asp:Label>                                                
                                                 <asp:TextBox ID="txtMedidas" runat="server" ValidationGroup="EnvioValidationGroup"
                                                 Enabled="true" CssClass="textInput3"></asp:TextBox> 
                                                <asp:RequiredFieldValidator runat="server" ID="rfvMedidas" ValidationGroup="EnvioValidationGroup" 
                                                ControlToValidate="txtMedidas" ForeColor="Red" ErrorMessage="(*) Ingresar Medidas" Text="(*)"></asp:RequiredFieldValidator>                                      

                                                <asp:Label runat="server" ID="lblCostoDeclarar"  CssClass="label3" AssociatedControlID="txtCostoDeclarar">Costo Declarar:</asp:Label>
                                                <asp:TextBox ID="txtCostoDeclarar" runat="server" ValidationGroup="EnvioValidationGroup"
                                                  Enabled="true" Width="135"></asp:TextBox>                                             
                                              
                                                 <asp:RequiredFieldValidator runat="server" ID="rfvCostoDeclarar" ValidationGroup="EnvioValidationGroup" 
                                                        ControlToValidate="txtCostoDeclarar" ForeColor="Red" ErrorMessage="(*) Ingresar Costo a Declarar" Text="(*)"></asp:RequiredFieldValidator>                                                                                                                                 
                                            </li> 
                                            <li>
                                                <asp:Label runat="server" ID="lblContenido" AssociatedControlID="txtContenido">Contenido:</asp:Label>
                                                <asp:TextBox ID="txtContenido" runat="server" Columns="85" Rows="5" TextMode="MultiLine" ValidationGroup="EnvioValidationGroup"
                                                    CssClass="textInput"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvContenido" ValidationGroup="EnvioValidationGroup"
                                                    ControlToValidate="txtContenido" ForeColor="Red" ErrorMessage="(*) Ingresar Contenido" Text="(*)"></asp:RequiredFieldValidator>
                                            </li>  
                                            <li>
                                                 <asp:Label runat="server" ID="lblCaracteristica" AssociatedControlID="ddlCaracteristica">Característica:</asp:Label>                                                
                                                 <asp:DropDownList ID="ddlCaracteristica" runat="server" ValidationGroup="EnvioValidationGroup" Width="110px" AutoPostBack="True">
                                                        <asp:ListItem Value="0">Ninguna</asp:ListItem>
                                                        <asp:ListItem Value="1">Confidencial</asp:ListItem>
                                                        <asp:ListItem Value="2">Frágil</asp:ListItem>
                                                 </asp:DropDownList>                                         

                                               <asp:Label runat="server" ID="lblTelefono"  CssClass="label4" AssociatedControlID="txtTelefono">Teléfono:</asp:Label>
                                                <asp:TextBox ID="txtTelefono" runat="server" ValidationGroup="EnvioValidationGroup"
                                                  Enabled="true" Width="135"></asp:TextBox>  
                                            </li>
                                            <li>
                                                 <asp:Label runat="server" ID="lblPais" AssociatedControlID="txtPais">País:</asp:Label>                                                
                                                 <asp:TextBox ID="txtPais" runat="server" ValidationGroup="EnvioValidationGroup"
                                                 Enabled="true" CssClass="textInput3"></asp:TextBox> 
                                                <asp:RequiredFieldValidator runat="server" ID="rfvPais" ValidationGroup="EnvioValidationGroup" 
                                                ControlToValidate="txtPais" ForeColor="Red" ErrorMessage="(*) Ingresar País" Text="(*)"></asp:RequiredFieldValidator>                                      

                                                <asp:Label runat="server" ID="lblEstadoProvincia"  CssClass="label3" AssociatedControlID="txtEstadoProvincia">Estado/Prov.:</asp:Label>
                                                <asp:TextBox ID="txtEstadoProvincia" runat="server" ValidationGroup="EnvioValidationGroup"
                                                  Enabled="true" Width="135"></asp:TextBox>                                             
                                              
                                                 <asp:RequiredFieldValidator runat="server" ID="rfvEstadoProvincia" ValidationGroup="EnvioValidationGroup" 
                                                        ControlToValidate="txtEstadoProvincia" ForeColor="Red" ErrorMessage="(*) Ingresar Estado o Provincia" Text="(*)"></asp:RequiredFieldValidator>                                                                                                                                 
                                            </li> 
                                            <li>
                                                 <asp:Label runat="server" ID="lblCiudad" AssociatedControlID="txtCiudad">Ciudad:</asp:Label>                                                
                                                 <asp:TextBox ID="txtCiudad" runat="server" ValidationGroup="EnvioValidationGroup"
                                                 Enabled="true" CssClass="textInput3"></asp:TextBox> 
                                                <asp:RequiredFieldValidator runat="server" ID="rfvCiudad" ValidationGroup="EnvioValidationGroup" 
                                                ControlToValidate="txtCiudad" ForeColor="Red" ErrorMessage="(*) Ingresar Ciudad" Text="(*)"></asp:RequiredFieldValidator>                                      

                                                <asp:Label runat="server" ID="lblCodigoPostal"  CssClass="label3" AssociatedControlID="txtCodigoPostal">Código Postal:</asp:Label>
                                                <asp:TextBox ID="txtCodigoPostal" runat="server" ValidationGroup="EnvioValidationGroup"
                                                  Enabled="true" Width="135"></asp:TextBox>                                             
                                              
                                                 <asp:RequiredFieldValidator runat="server" ID="rfvCodigoPostal" ValidationGroup="EnvioValidationGroup" 
                                                        ControlToValidate="txtCodigoPostal" ForeColor="Red" ErrorMessage="(*) Ingresar Código Postal" Text="(*)"></asp:RequiredFieldValidator>                                                                                                                                 
                                            </li> 
                                            <li>
                                                <asp:Label runat="server" ID="lblDestinatario" AssociatedControlID="txtDestinatario">Destinatario:</asp:Label>
                                                <%--<asp:DropDownList ID="ddlDireccionDestinatario" runat="server" ValidationGroup="EnvioValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlDireccionDestinatario_SelectedIndexChanged">
                                                </asp:DropDownList> --%>  
                                                <telerik:RadComboBox ID="ddlDireccionDestinatario" runat="server" ValidationGroup="EnvioValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlDireccionDestinatario_SelectedIndexChanged" 
                                                AllowCustomText="true" MarkFirstMatch="true" AutoCompleteSeparator="">
                                                </telerik:RadComboBox>                                                      
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblOtroDestinatario" AssociatedControlID="txtDestinatario" Text="Nuevo Destinatario:" Visible="false"></asp:Label>                                                
                                                <asp:TextBox ID="txtOtroDestinatario" CssClass="textInput4" runat="server" ValidationGroup="EnvioValidationGroup"
                                                    Width="100px" Visible="false"></asp:TextBox>                                               
                                            </li>
                                             <li>
                                                <asp:Label runat="server" ID="lblDireccionDestinatario" AssociatedControlID="ddlDireccionDestinatario">Dirección:</asp:Label>
                                                <asp:TextBox ID="txtDestinatario" CssClass="textInput" runat="server" ValidationGroup="EnvioValidationGroup"
                                                    Width="200px" TextMode="MultiLine"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator runat="server" ID="rfvDestinatario" ValidationGroup="EnvioValidationGroup"
                                                    ControlToValidate="txtDestinatario" ForeColor="Red" ErrorMessage="(*) Ingresar Dirección Destinatario" Text="(*)"></asp:RequiredFieldValidator>                                                --%>
                                            </li>   
                                            <li>
                                                <asp:Label runat="server" ID="lblAtencion" AssociatedControlID="ddlAtencion">Atención:</asp:Label>
                                               <%-- <asp:DropDownList ID="ddlAtencion" runat="server" ValidationGroup="EnvioValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlAtencion_SelectedIndexChanged">
                                                </asp:DropDownList> --%>         
                                                <telerik:RadComboBox ID="ddlAtencion" runat="server" ValidationGroup="EnvioValidationGroup" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlAtencion_SelectedIndexChanged" 
                                                AllowCustomText="true" MarkFirstMatch="true" AutoCompleteSeparator="">
                                                </telerik:RadComboBox>                                        
                                               <%-- <asp:RequiredFieldValidator runat="server" ID="rfvAtencion" ValidationGroup="EnvioValidationGroup"
                                                    ControlToValidate="ddlAtencion" ForeColor="Red" ErrorMessage="(*) Ingresar Destinatario Atención" Text="(*)"></asp:RequiredFieldValidator>--%>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="lblOtraAtencion" AssociatedControlID="txtOtraAtencion" Text="Nueva Atención:" Visible="false"></asp:Label>                                                
                                                <asp:TextBox ID="txtOtraAtencion" CssClass="textInput4" runat="server" ValidationGroup="EnvioValidationGroup"
                                                    Width="100px" Visible="false"></asp:TextBox>                                               
                                            </li>
                                        </ul>  
                                        <br />  
                                        <asp:ValidationSummary runat="server" ForeColor="Red" ID="validationSummary" CssClass="validationSummary" ValidationGroup="EnvioValidationGroup" />                                          
                                    </div>
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem Enabled="False" Visible="false" Text="Documentos" runat="server">
                        <Items>
                            <telerik:RadPanelItem Value="Documentos" runat="server">
                                <ItemTemplate>
                                    <div class="qsf-fb">
                                        <div class="formList" id="formList">                                            
                                            <div class="documentos">
                                                <h2>Adjuntar Documentos:</h2>
                                            </div>
                                                <telerik:RadGrid runat="server" ID="rgDocumentos" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" GridLines="None" PageSize="5" Culture="es-ES" OnItemDataBound="rgDocumentos_ItemDataBound"   
                                                OnNeedDataSource="rgDocumentos_NeedDataSource" OnInsertCommand="rgDocumentos_InsertCommand" 
                                                OnDeleteCommand="rgDocumentos_DeleteCommand" OnItemCommand="rgDocumentos_ItemCommand">
                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="ID">
                                                    <Columns>  
                                                        <telerik:GridBoundColumn DataField="ID" DataType="System.Guid" HeaderText="ID" SortExpression="ID" 
                                                        UniqueName="ID" Display="false" ReadOnly="true" ForceExtractValue="Always">
                                                        </telerik:GridBoundColumn> 
                                                        <telerik:GridBoundColumn DataField="URL" DataType="System.String" HeaderText="URL" SortExpression="URL" 
                                                        UniqueName="URL" Display="false" ReadOnly="true" ForceExtractValue="Always">
                                                        </telerik:GridBoundColumn> 
                                                         <telerik:GridTemplateColumn HeaderText="Fecha" HeaderStyle-HorizontalAlign="Center" UniqueName="FECHA_REGISTRO" DataField="FECHA_REGISTRO">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Eval("FECHA_REGISTRO") %>' Width = "150px"></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                              <telerik:RadDatePicker ID="rdpFecha" runat="server" SelectedDate='<%# Eval("FECHA_REGISTRO")%>' Width="210px"></telerik:RadDatePicker>  
                                                               <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="rdpFecha" ForeColor="Red"
                                                                    ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>                                             
                                                            </EditItemTemplate>
                                                            <ItemStyle VerticalAlign="Top"></ItemStyle>
                                                        </telerik:GridTemplateColumn>                                                      
                                                        <telerik:GridTemplateColumn HeaderText="Nombre" HeaderStyle-HorizontalAlign="Center" UniqueName="NOMBRE" SortExpression="NOMBRE" DataField="NOMBRE">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblNombre" Text='<%# Eval("NOMBRE") %>' Width = "150px"></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <telerik:RadTextBox runat="server" Width="210px" ID="txtNombre" Text='<%# Eval("NOMBRE") %>'>
                                                                </telerik:RadTextBox>
                                                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ForeColor="Red"
                                                                    ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <HeaderStyle Width="30%"></HeaderStyle>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Descripción" HeaderStyle-HorizontalAlign="Center" UniqueName="DESCRIPCION" DataField="DESCRIPCION">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDescripcion" runat="server" Text='<%# TrimDescripcion(Eval("DESCRIPCION") as string) %>' Width = "150px"></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <telerik:RadTextBox ID="txtDescripcion" Width="210px" runat="server" TextMode="MultiLine"
                                                                    Text='<%# Eval("DESCRIPCION") %>' Height="50px">
                                                                </telerik:RadTextBox>
                                                                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" ForeColor="Red"
                                                                    ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <ItemStyle VerticalAlign="Top"></ItemStyle>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Documento" HeaderStyle-HorizontalAlign="Center"  UniqueName="Upload">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hplDocumento" runat="server" Target="_blank"><%# Eval("NOMBRE")%></asp:HyperLink>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" OnClientFileUploaded="OnClientFileUploaded" AllowedFileExtensions="jpg,jpeg,png,gif,pdf,doc,docx"
                                                                     MaxFileSize="1048576" OnFileUploaded="AsyncUpload1_FileUploaded" Width="200px">
                                                                </telerik:RadAsyncUpload>
                                                            </EditItemTemplate>
                                                        </telerik:GridTemplateColumn>   
                                                        <telerik:GridButtonColumn Text="Eliminar" CommandName="Delete" UniqueName="EliminarDocumento" ButtonType="ImageButton">
                                                            <HeaderStyle Width="36px"></HeaderStyle>
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn ButtonType="ImageButton">
                                                        </EditColumn>
                                                    </EditFormSettings>                                                   
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                            <asp:ObjectDataSource ID="ObjectDataSourceDocumentos" runat="server" SelectMethod="SeleccionarDocumentosPorSolicitud" TypeName="BusinessLogicLayer.BL_DOCUMENTO"></asp:ObjectDataSource>
                                        </div>                                        
                                    </div>
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                </Items>
                <CollapseAnimation Duration="0" Type="None" />
                <ExpandAnimation Duration="0" Type="None" />
            </telerik:RadPanelBar>   
           <p class="mensaje">
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
           </p>                    
           <p class="buttons">
                &nbsp;<telerik:RadButton runat="server" Text="Guardar" ID="btnGuardar" Skin="Silk"
                    ValidationGroup="EnvioValidationGroup" OnClick="guardarButton_Click" />
                <p>
                    &nbsp;<telerik:RadButton ID="btnCerrar" runat="server" OnClick="cerrarButton_Click" 
                        Skin="Silk" Text="Cerrar Solicitud" />
                    <p>
                        &nbsp;<telerik:RadButton ID="btnGenerarEtiqueta" runat="server" 
                            OnClick="generarSolicitud_Click" Skin="Silk" Text="Generar Etiqueta" 
                            Width="120px" />
                        <p>
                            <asp:HiddenField ID="hdfSolicitudId" runat="server" />
                            <asp:HiddenField ID="hdfSolicitudCodigo" runat="server" />
                            <asp:HiddenField ID="hdfCorrespondenciaId" runat="server" />
                            <asp:HiddenField ID="hdfSolicitudEstado" runat="server" />
                        </p>
                    </p>
                </p>
            </p>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>
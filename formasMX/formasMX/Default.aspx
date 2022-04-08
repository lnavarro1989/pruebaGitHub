<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master-formasmx.Master" CodeBehind="Default.aspx.vb" Inherits="formasMX._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a name="contact" id="contact">
    <div class="needs-validation" novalidate>
                    <div class="form-row">
                        <legend class="header">Contacto</legend>                    
                                           
                      <div class="col-md-6 mb-3">
                        <label for="name">Nombre</label>                        
                          <asp:TextBox runat="server" ID="name" CssClass="form-control" placeholder="Nombre" required></asp:TextBox>
                        <div class="invalid-feedback">
                                Por favor, ingrese su Nombre.
                    </div>
                      </div>                   
                    
                        <div class="col-md-6 mb-3">
                            <label for="email">Correo</label>
                                 <div class="input-group">                         
                                
                                <asp:TextBox runat="server" type="email" ID="email" CssClass="form-control" placeholder="Email" aria-describedby="inputGroupPrepend" required></asp:TextBox>
                            <div class="invalid-feedback">
                                        Por favor, ingrese su correo eléctronico.
                            </div>
                         </div>
                        </div> 
                    
                    
                    <%--  <div class="col-md-6 mb-3">
                        <label for="meg">Mensaje</label>                        
                        <asp:TextBox runat="server" ID="msg" type="text" CssClass="form-control" placeholder="Ingrese su mensaje aquí, le responderemos lo antes posible." TextMode="MultiLine" Rows="3" required></asp:TextBox>
                          <div class="invalid-feedback">
                          Por favor ingrese su mensaje.
                        </div>
                      </div> --%>                         
                     </div>  
                        <div class="text-left">
                            <asp:Button runat="server" ID="enviar" CssClass="btn btn-outline-secondary" Text="Enviar Mensaje" /> 
                        </div>       
                 </div>
        <br />
    <%--<div class="modal-footer">--%>
        <asp:Panel ID="procesoStatusContainer" runat="server" Visible="False" EnableViewState="False">
            <asp:Label ID="procesoStatus" runat="server" Visible="false"></asp:Label>
            <asp:Image runat="server" ID="imgEnviado" ImageUrl="~/img/mail2.gif" CssClass="card-img" Visible="false" />
        </asp:Panel>
        
    <%--</div>--%> 
       <script>
           // Example starter JavaScript for disabling form submissions if there are invalid fields
           (function () {
               'use strict';
               window.addEventListener('load', function () {
                   // Fetch all the forms we want to apply custom Bootstrap validation styles to
                   var forms = document.getElementsByClassName('needs-validation');
                   // Loop over them and prevent submission
                   var validation = Array.prototype.filter.call(forms, function (form) {
                       form.addEventListener('submit', function (event) {
                           if (form.checkValidity() === false) {
                               event.preventDefault();
                               event.stopPropagation();
                           }
                           form.classList.add('was-validated');
                       }, false);
                   });
               }, false);
           })();
            </script>    
    </a></asp:Content>

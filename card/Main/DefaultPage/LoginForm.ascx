<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LoginForm.ascx.vb" Inherits="Main_DefaultPage_LoginForm" %>
<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>




 
             
<dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" 
        ClientInstanceName="loginPanel">
        <ClientSideEvents EndCallback="function(s, e) {
          alert('DD');
	 if (s.cpRedirectUrl) {
   
            window.top.location.href = s.cpRedirectUrl;
        }
}" />
        <PanelCollection>
<dx:PanelContent runat="server" SupportsDisabledAttribute="True">
   <asp:Panel ID="Panel1" runat="server" DefaultButton="ASPxButton1">
                     <div class="thumbnail">
                     
                     <div class="caption">
                     
                        <div class="control-group">
                            
       <label class="control-label" for="inputEmail">Username</label>
       <div class="controls">
      
           <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" style="margin-bottom: 0px" 
                                    Width="100%" MaxLength="20" EnableTheming="True" Height="35px">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
</div>
     </div>
                         <div class="form-group">
                            
       <label class="control-label" for="inputEmail">Password</label>
       <div class="controls">
      
            <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Password="True" 
                                    style="margin-bottom: 0px" Width="100%" MaxLength="20" Height="35px">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
</div>
     </div>


                         <div class="form-group">
                            
       
       <div class="controls">
     
      
          
         
          
</div>
     </div>
                         <div class="form-group">
                            
       
       <div class="controls">
           <asp:Label ID="ASPxLabel1" runat="server" Text=""></asp:Label>
      
          
  
           <asp:Button ID="ASPxButton1" CssClass="btn btn-success" 
                        Visible="true" runat="server" Text="เข้าใช้งานระบบ"  UseSubmitBehavior="False"  />
          
</div>


     </div>
                         
                     </div>
                   </div>
                 
</asp:Panel>

            </dx:PanelContent>
</PanelCollection>
    </dx:ASPxCallbackPanel>  
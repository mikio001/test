<%@ Page  Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPageBootstrap.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Main_Login" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>





<%@ Register src="../../zulu_cms/contents/HtmlContent.ascx" tagname="HtmlContent" tagprefix="uc1" %>

<%@ Register src="LoginForm.ascx" tagname="LoginForm" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div class="row">
  <div class="col-md-4 col-md-offset-4">   <uc2:LoginForm ID="LoginForm1" runat="server" /></div>
  
</div>
                  
                  
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentHeader">
   
       
                   
               
    
</asp:Content>


<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentBanner">
    <div class="bs-header" >              
      <div class="container">
        <h1>เข้าใช้งานระบบ </h1>
        <p>Login</p>       
      </div>                  
</div>
     </asp:Content>




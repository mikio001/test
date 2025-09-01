<%@ Page Title="" Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPagebootstrap.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Main_Default" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>



<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx1" %>









<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx2" %>

<%@ Register assembly="DevExpress.XtraCharts.v21.1.Web, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<%@ Register src="LoginForm.ascx" tagname="LoginForm" tagprefix="uc1" %>










<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style type="text/css">
        .auto-style1 {
            width: 236px;
            height: 238px;
        }
    </style>
    
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
     <div class="col-lg-offset-3 col-lg-6">

      <uc1:LoginForm ID="LoginForm1" runat="server" />
                  
       
    
 
  
</div></div>

    
  
     
        </asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentHeader">
    

</asp:Content>



<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentFooter">
    <script>
        $("#pagenavbar").hide();
        $("body").addClass("bs-docs-home");
        $('body').css("background-image", "url(../Images/Textured-Background.png)");
      //  $('body').css("background-repeat", "no-repeat");
        $('body').css("background-size", "100%");
        $("#pageFooter").hide();
        $('.bs-header').css('background', 'transparent');
   </script>
</asp:Content>




<asp:Content ID="Content6" runat="server" contentplaceholderid="ContentBanner">
    <div class="bs-header noprint" >              
      <div class="container">
        <h1 style="color: #CCC" ><span style="color: #FFF">card </span> <span style="color: #FF0000">management system</span></h1>
               <p style="color: #FFFFFF">บริหารจัดการบัตรเข้าพิธี ปริญญาบัตร </p>    
            
      </div>                  
</div>
     </asp:Content>






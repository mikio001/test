<%@ Page Title="" Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPagebootstrap.master" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="Main_Default" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>



<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx1" %>









<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx2" %>

<%@ Register assembly="DevExpress.XtraCharts.v21.1.Web, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<%@ Register src="LoginForm.ascx" tagname="LoginForm" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        </asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="mainContainer0" class="container bs-docs-container" style="margin-top: 10px">
       <div class="col-lg-4 animated bounceInRight" style="-webkit-animation-delay: 0.3s;">
        <div class="panel panel-default">
            <div class="panel-body" style="color: #000">
                <div class="media">
                    <a class="pull-left" href="../REF/card_edit.aspx"><i class="fa fa-plus fa-5x" style="color: rgb(87, 87, 87)"></i></a>
                    <div class="media-body">
                        <a href="../REF/card_edit.aspx">
                        <h4 class="media-heading">เพิ่มคณะกรรมการ</h4>
                        พิธีปริญญาบัตร</a>
                    </div>
                </div>
            </div>
        </div>
           </div>
     <%--   <div class="col-lg-4 animated bounceInRight" style="-webkit-animation-delay: 0.3s;">
        <div class="panel panel-default">
            <div class="panel-body" style="color: #000">
                <div class="media">
                    <a class="pull-left" href="../MAS/USER_PICK.aspx"><i class="fa fa-plus fa-5x" style="color: rgb(87, 87, 87)"></i></a>
                    <div class="media-body">
                        <a href="../MAS/USER_PICK.aspx">
                        <h4 class="media-heading">เบิกวัสดุ สำนักงาน</h4>
                        กองกลาง มหาวิทยาลัยพะเยา </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
       
            <div class="col-lg-4 animated bounceInRight" style="-webkit-animation-delay: 0.6s;">
        <div class="panel panel-default">
            <div class="panel-body" style="color: #000">
                <div class="media">
                    <a class="pull-left" href="../REF/USER_Material.aspx"><i class="fa fa-bar-chart fa-5x" style="color: rgb(87, 87, 87)"></i></a>
                    <div class="media-body">
                        <a href="../REF/USER_Material.aspx">
                        <h4 class="media-heading">รายงาน</h4>
                        วัสดุคงเหลือ </a>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
</div>

    
  
     
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






<%@ Page Title="" Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPageBootstrap.master" AutoEventWireup="false" CodeFile="News_Read.aspx.vb" Inherits="News_Read" %>

<%@ Register src="../../zulu_cms/contents/NewsReader.ascx" tagname="NewsReader" tagprefix="uc1" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        h1, .h1 {
            font-size: 16px;
        }
    </style>
   
        <div class="col-sm-12 maincontent" style="padding-top: 50px">
   <div class="well">
    <uc1:NewsReader ID="NewsReader1" runat="server" ContentID="Newsupsp" />

   </div>

</div>

</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentBanner">
</asp:Content>



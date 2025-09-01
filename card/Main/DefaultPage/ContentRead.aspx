<%@ Page Title="" Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPageBootstrap.master" AutoEventWireup="false" CodeFile="ContentRead.aspx.vb" Inherits="Main_DefaultPage_ContentRead" %>

<%@ Register src="../../zulu_cms/contents/HtmlContent.ascx" tagname="HtmlContent" tagprefix="uc1" %>
<%@ Register src="../../zulu_cms/ReaderControl.ascx" tagname="ReaderControl" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:HtmlContent ID="HtmlContent1" runat="server" />
</asp:Content>


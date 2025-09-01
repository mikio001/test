<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UPV5_4MAINSLIDE.ascx.vb" Inherits="zulu_cms_contents_SlideCalendar" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc2" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="editortoolbox" tagprefix="uc1" %>
<uc2:StartEditorToolbox ID="StartEditorToolbox1" runat="server" />
    <LINK href="../zulu_cms/contents/CasualSlide/screen.css" rel="stylesheet" type="text/css" media="screen, projection">     
<LINK href="../zulu_cms/contents/CasualSlide/enhanced.css" rel="stylesheet" type="text/css" media="screen, projection">  

<SCRIPT src="../zulu_cms/contents/CasualSlide/jquery.cycle.all.latest.js" type="text/javascript"></SCRIPT>
<SCRIPT src="../zulu_cms/contents/CasualSlide/functions.js" type="text/javascript"></SCRIPT>
 
                                         
                                           
 <DIV class="carousel" id="hp_carousel">

<DIV class="view-content">
    

 <cc1:DirectRender ID="PhotoSlider" runat="server" />




</DIV>
</DIV>                                       
                    
<uc1:editortoolbox ID="EndEditorToolbox1" runat="server" 
    EditorPage="HtmlEditor" />
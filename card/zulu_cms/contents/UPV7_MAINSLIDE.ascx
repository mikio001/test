<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UPV7_MAINSLIDE.ascx.vb" Inherits="zulu_cms_contents_SlideCalendar" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc2" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="editortoolbox" tagprefix="uc1" %>
<uc2:StartEditorToolbox ID="StartEditorToolbox1" runat="server" />

 
                             
                                           
 <DIV class="carousel" id="hp_carousel">

<DIV class="view-content">
        <div class='oneByOne1' align='center'>
                        <div id='banner'>
                         
                           
                            

 <cc1:DirectRender ID="PhotoSlider" runat="server" />

  </div>
                        
                    </div>   


</DIV>
</DIV>                                       
                    
<uc1:editortoolbox ID="EndEditorToolbox1" runat="server" 
    EditorPage="HtmlEditor" />
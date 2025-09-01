<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UPV5_MAINSLIDE.ascx.vb" Inherits="zulu_cms_contents_SlideCalendar" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc2" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="editortoolbox" tagprefix="uc1" %>
<uc2:StartEditorToolbox ID="StartEditorToolbox1" runat="server" />

  <cc1:DirectRender ID="PhotoSlider" runat="server" />
                                            
                                           
                                        
                    
<uc1:editortoolbox ID="EndEditorToolbox1" runat="server" 
    EditorPage="HtmlEditor" />
<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ContentSlide.ascx.vb" Inherits="zulu_cms_contents_ContentSlide" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<uc1:StartEditorToolbox ID="ContentSlideStart" runat="server" />
<cc1:DirectRender ID="ContentSlide" runat="server" />
<uc2:EndEditorToolbox ID="ContentSlideEnd" runat="server" />
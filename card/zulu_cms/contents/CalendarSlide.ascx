<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CalendarSlide.ascx.vb" Inherits="zulu_cms_contents_CalendarSlide" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<uc1:StartEditorToolbox ID="CalendarSlideStart" runat="server" />
<cc1:DirectRender ID="CalendarSlide" runat="server" />
<uc2:EndEditorToolbox ID="CalendarSlideEnd" runat="server" />
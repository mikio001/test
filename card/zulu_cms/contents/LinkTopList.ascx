<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LinkTopList.ascx.vb" Inherits="zulu_cms_contents_LinkTopList" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<uc1:StartEditorToolbox ID="StartEditorToolbox1" runat="server" />
<cc1:DirectRender ID="LinkTopList" runat="server" />
<uc2:EndEditorToolbox ID="EndEditorToolbox1" runat="server" />
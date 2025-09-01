<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NewsReadermm.ascx.vb" Inherits="zulu_cms_contents_NewsReader" %>
<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<%@ Register assembly="Zulu" namespace="Zulu.UI" tagprefix="cc1" %>

<uc1:StartEditorToolbox ID="StartNewsReader" runat="server" />
<cc1:DirectRender ID="NewsReader" runat="server" />
<uc2:EndEditorToolbox ID="EndNewsReader" runat="server" />
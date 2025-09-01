<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NewsTopListcalen.ascx.vb" Inherits="zulu_cms_contents_NewsTopList" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<%@ Register Src="~/zulu_cms/StartToolbox.ascx" TagPrefix="uc1" TagName="StartToolbox" %>


<uc1:StartToolbox runat="server" id="StartToolbox" /> 
<cc1:DirectRender ID="NewsTopList" runat="server" />
<uc2:EndEditorToolbox ID="EndEditorToolbox1" runat="server" />
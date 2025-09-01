<%@ Control Language="VB" AutoEventWireup="false" CodeFile="HtmlContent.ascx.vb" Inherits="zulu_cms_contents_HtmlContent" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EditorToolbox" tagprefix="uc1" %>
<%@ Register src="../StartToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc2" %>

<cc1:DirectRender ID="HtmlContent" runat="server" />
<uc1:editortoolbox ID="HtmlEditorToolbox" runat="server" 
    EditorPage="HtmlEditor" />
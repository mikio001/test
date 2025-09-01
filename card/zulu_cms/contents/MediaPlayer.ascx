<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MediaPlayer.ascx.vb" Inherits="zulu_cms_contents_MediaPlayer" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EditorToolbox" tagprefix="uc1" %>
<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc2" %>
<uc2:StartEditorToolbox ID="MediaPlayerEditor0" runat="server" />
<cc1:DirectRender ID="MediaPlayer" runat="server" />
<uc1:editortoolbox ID="MediaPlayerEditor1" runat="server"/>
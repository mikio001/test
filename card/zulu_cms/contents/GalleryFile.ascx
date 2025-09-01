<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GalleryFile.ascx.vb" Inherits="zulu_cms_contents_Gallery" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<uc1:StartEditorToolbox ID="GalleryStart" runat="server" />
<cc1:DirectRender ID="Gallery" runat="server" />
<uc2:EndEditorToolbox ID="GalleryEnd" runat="server" 
    CustomEditPage="GalleryFileEditor" />
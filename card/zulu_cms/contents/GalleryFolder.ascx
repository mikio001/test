<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GalleryFolder.ascx.vb" Inherits="zulu_cms_contents_Gallery" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

      
<uc1:StartEditorToolbox ID="GalleryStart" runat="server" />
<cc1:DirectRender ID="Gallery" runat="server" />
<uc2:EndEditorToolbox ID="GalleryEnd" runat="server" 
    CustomEditPage="GalleryFileEditor" />


   
    
   

    

   
<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NewsFormV7.ascx.vb" Inherits="zulu_cms_editors_NewsAdd" %><%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<%@ Register assembly="Zulu" namespace="Zulu.UI" tagprefix="cc1" %>

 <script type="text/javascript">
    // <![CDATA[
     function ShowDoc() {
         var url = btnRefUrl.GetText();
         window.open(url);
     }
    // ]]> 
    </script>

<table cellpadding="0" cellspacing="2" class="text">
<tr>
<td>หัวเรื่อง:</td>
<td>
    <dx:ASPxTextBox ID="newsTitle" runat="server" MaxLength="255" Width="400px">
        <ValidationSettings>
            <RequiredField ErrorText="โปรดกรอก" IsRequired="True" />
        </ValidationSettings>
    </dx:ASPxTextBox>
    </td>
</tr>
<tr>
<td>คำอธิบายหัวเรื่อง :</td>
<td>
    <dx:ASPxTextBox ID="newsSubTitle" runat="server" MaxLength="500" Width="400px" 
        Height="70px">
        
    </dx:ASPxTextBox>
    </td>
</tr>
<tr>
<td>วันหมดอายุ:</td>
<td>
    <dx:ASPxDateEdit ID="newsExpireDate" runat="server">        
    </dx:ASPxDateEdit>
    </td>
</tr>
<tr>
<td>ประเภท:</td>
<td>
    <dx:ASPxComboBox ID="cmbContentType" runat="server" ClientIDMode="AutoID" 
        DataSourceID="SqlDataSource1" SelectedIndex="0" TextField="name" 
        ValueField="contentTypeID" ValueType="System.Int32">
    </dx:ASPxComboBox>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ZuluDB %>" 
        SelectCommand="SELECT * FROM [ZCMS_CONTENT_TYPE]"></asp:SqlDataSource>
    </td>
</tr>
<tr>
<td>ภาพประกอบหัวข้อ:</td>
<td>
    <cc1:FileSelector ID="btnRefImg" runat="server" Width="400px">
    </cc1:FileSelector>
    </td>
</tr>
<tr>
<td>ไฟล์เอกสาร:</td>

<td><table><tr><td> <cc1:FileSelector ID="btnRefUrl" runat="server" Width="400px" 
        ClientInstanceName="btnRefUrl">
    </cc1:FileSelector></td><td>
        <dx:ASPxButton ID="ASPxButton1" runat="server" 
            Text="Preview" Height="12px" ClientIDMode="AutoID" Font-Size="X-Small">
            <ClientSideEvents Click="function(s, e) {
	ShowDoc();
}" />
        </dx:ASPxButton>
        </td></tr></table>
   
    </td>
</tr>
<tr>
<td valign="top" colspan="2">เนื้อหา:</td>
</tr>
<tr>
<td valign="top" colspan="2">
    <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server" Width="800px">
<SettingsImageUpload>
<ValidationSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png, .pdf, .doc, .docx" notallowedfileextensionerrortext="This file extension isn't allowed (.jpe, .jpeg, .jpg, .gif, .png, .pdf, .doc, .docx)" maxfilesize="50000"></ValidationSettings>
</SettingsImageUpload>

<SettingsImageSelector enabled="True">
<CommonSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png, .pdf, .doc, .docx"></CommonSettings>
    <uploadsettings enabled="True">
    </uploadsettings>
</SettingsImageSelector>
    </dx:ASPxHtmlEditor>
    <cc1:FckEditor ID="FckEditor1" runat="server" EnableFileUpload="True">
    </cc1:FckEditor>
    </td>
</tr>
</table>
<%@ Page Title="" Language="VB" MasterPageFile="~/zulu_web/VCMasterPage.master" AutoEventWireup="false" CodeFile="NewForm.aspx.vb" Inherits="zulu_cms_editors_NewEditer" %>
<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register assembly="Zulu" namespace="Zulu.UI" tagprefix="cc1" %>

<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <dx:ASPxCallbackPanel ID="cbPanel" runat="server" ClientInstanceName="cbPanel">
                    <PanelCollection>
<dx:PanelContent ID="PanelContent1" runat="server">   <table cellpadding="0" cellspacing="2" style="padding-left: 6px;">
        <tr>
           
            <td>
                <dx:ASPxButton ID="btnSave" runat="server" Text="บันทึก" >
                    <ClientSideEvents Click="function(s, e) {
	//cbPanel.PerformCallback('SAVE');
}" />
                    <Image Url="~/zulu_web/images/ok.gif"></Image>
                </dx:ASPxButton>
            </td>
        
            <td>
                <dx:ASPxButton ID="btnCancel" runat="server" Text="ปิด" AutoPostBack="False" CausesValidation="False"
                    UseSubmitBehavior="False">
                    <Image Url="~/zulu_web/images/cancel.gif"></Image>
                    <ClientSideEvents Click="function(s,e){zulu_cms_closeEditor();}" />
                </dx:ASPxButton>
            </td>
        </tr>
    </table>
       <asp:Literal ID="ltMsg" runat="server" Mode="PassThrough"></asp:Literal>
    <hr />
<table cellpadding="0" cellspacing="2" class="text" width="100%">
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
<%--<tr>
<td>วันหมดอายุ:</td>
<td>
    <dx:ASPxDateEdit ID="newsExpireDate" runat="server">        
    </dx:ASPxDateEdit>
    </td>
</tr>--%>
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
 <%--   <cc1:FileSelector ID="btnRefImg" runat="server" Width="400px">
    </cc1:FileSelector>--%>
    <table><tr><td> <asp:FileUpload ID="btnRefImg" runat="server" /> </td><td><asp:Label ID="lblRefImg" runat="server" Text="Label"></asp:Label></td></tr></table>
  
    </td>
</tr>
    <tr>
<td>ภาพBG</td>
<td>
 <%--   <cc1:FileSelector ID="btnRefImg" runat="server" Width="400px">
    </cc1:FileSelector>--%>
    <table><tr><td> <asp:FileUpload ID="btnRefImfGB" runat="server" /> </td><td><asp:Label ID="lblRefImfGB" runat="server" Text="Label"></asp:Label></td></tr></table>
  
    </td>
</tr>
<tr>
<td>ไฟล์เอกสาร:</td>

<td>
    <table><tr><td> <asp:FileUpload ID="btnRefUrl" runat="server" /></td><td>
        <asp:Label ID="lblRefUrl" runat="server" Text="Label"></asp:Label></td></tr></table> 
   
    </td>
</tr>
<tr>
<td valign="top" colspan="2">เนื้อหา:</td>
</tr>
<tr>
<td valign="top" colspan="2">
   <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server" Height="390px" Width="100%">
                                <SettingsImageUpload UploadImageFolder="~/FileUpload/">
                                    <ValidationSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png" MultiSelectionErrorText="Attention! 

The following {0} files are invalid because they exceed the allowed file size ({1}) or their extensions are not allowed. These files have been removed from selection, so they will not be uploaded. 

{2}"
                                        MaxFileSize="10485760">
                                    </ValidationSettings>
                                </SettingsImageUpload>

                                <SettingsImageSelector Enabled="True">
                                    <CommonSettings RootFolder="~/FileUpload" />
                                </SettingsImageSelector>

                                <SettingsDocumentSelector Enabled="True">
                                    <CommonSettings AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .txt, .xls, .xlsx, .ppt, .pptx, .jpg, .png, .jpeg, .gif, .avi"
                                        RootFolder="~/FileUpload" EnableMultiSelect="True" InitialFolder="~/FileUpload"></CommonSettings>
                                    <EditingSettings AllowCreate="True" AllowDelete="True" AllowRename="True" TemporaryFolder="~/FileUpload" />
                                    <UploadSettings Enabled="True" UseAdvancedUploadMode="True">
                                        <AdvancedModeSettings EnableMultiSelect="True" />
                                    </UploadSettings>
                                </SettingsDocumentSelector>
                            </dx:ASPxHtmlEditor>
    </td>
</tr>
</table></dx:PanelContent>
</PanelCollection>
                </dx:ASPxCallbackPanel>
 
  
</asp:Content>


<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CalendarForm.ascx.vb"
    Inherits="zulu_cms_editors_CalendarEdit" %>
<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<%@ Register assembly="Zulu" namespace="Zulu.UI" tagprefix="cc1" %>
<table cellpadding="0" cellspacing="4" class="text">
    <tr>
        <td>
            หัวเรื่อง:
        </td>
        <td>
            <dx:ASPxTextBox ID="txtTitle" runat="server" Width="300px">
                <ValidationSettings>
                    <RequiredField ErrorText="" IsRequired="True" />
                </ValidationSettings>
            </dx:ASPxTextBox>
        </td>
    </tr>
    <tr>
        <td>
            ประเภท:</td>
        <td>
            <dx:ASPxComboBox ID="cmbContentType" runat="server" ClientIDMode="AutoID" 
                DataSourceID="SqlDataSource1" TextField="name" ValueField="contentTypeID" 
                ValueType="System.Int32">
                <ValidationSettings>
                    <RequiredField ErrorText="" IsRequired="True" />
                </ValidationSettings>
            </dx:ASPxComboBox>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ZuluDB %>" 
                SelectCommand="SELECT contentTypeID, name FROM dbo.ZCMS_CONTENT_TYPE WHERE (contentTypeID BETWEEN 100 AND 199)">
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td>
            กำหนดเริ่ม:</td>
        <td>
            <dx:ASPxDateEdit ID="deStart" runat="server">
                <ValidationSettings>
                    <RequiredField ErrorText="" IsRequired="True" />
                </ValidationSettings>
            </dx:ASPxDateEdit>
        </td>
    </tr>
    <tr>
        <td>
            กำหนดสิ้นสุด:</td>
        <td>
            <dx:ASPxDateEdit ID="deEnd" runat="server">
                <ValidationSettings>
                    <RequiredField ErrorText="" IsRequired="True" />
                </ValidationSettings>
            </dx:ASPxDateEdit>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            รายละเอียดเพิ่มเติม</td>
    </tr>
    <tr>
        <td colspan="2">
            <cc1:FckEditor ID="FckEditor1" runat="server" EnableFileUpload="True">
            </cc1:FckEditor>
        </td>
    </tr>
</table>

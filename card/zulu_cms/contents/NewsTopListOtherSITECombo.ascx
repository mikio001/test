<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NewsTopListOtherSITECombo.ascx.vb" Inherits="zulu_cms_contents_NewsTopList" %>
<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>




<%@ Register src="NewsTopListOtherSITE.ascx" tagname="NewsTopListOtherSITE" tagprefix="uc3" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width: 100%">
    <tr>
        <td align="right">
            เลือกแสดงข่าว
               <asp:DropDownList ID="DropDownList1" runat="server" style="margin-bottom: 3px" 
                AutoPostBack="True">
                <asp:ListItem>ทั้งหมด</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <uc3:NewsTopListOtherSITE ID="NewsTopListOtherSITE1" runat="server" />
            
        </td>
    </tr>
</table>
    </ContentTemplate>
</asp:UpdatePanel>





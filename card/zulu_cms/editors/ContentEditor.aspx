<%@ Page Title="" Language="VB" MasterPageFile="~/zulu_web/VCMasterPage.master" AutoEventWireup="false" CodeFile="ContentEditor.aspx.vb" Inherits="zulu_cms_editors_NewEditer" %>
<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var contetID = "<%=GetContentID()%>";
        var SiteID = "<%=GetSiteID()%>";

        var editorName = "ContentForm";
        function showEditor(newsID) {
            window.location = editorName+".aspx?itemID=" + newsID + "&contentID=" + contetID + "&SiteID=" + SiteID;
        }
        function addEditor() {
            window.location = editorName + ".aspx?contentID=" + contetID + "&SiteID=" + SiteID;
        }
    </script>
    <button type="button" onclick="addEditor()" value="เพิ่ม">เพิ่ม</button>
 
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
        ClientIDMode="AutoID" DataSourceID="SqlDataSource1" KeyFieldName="itemID" Width="100%">
        <Columns>
            <dx:GridViewDataHyperLinkColumn Caption="&amp;nbsp;" FieldName="itemID"
                ReadOnly="True" VisibleIndex="0" Width="16px">
                <PropertiesHyperLinkEdit ImageUrl="~/zulu_web/images/edit.gif"
                    NavigateUrlFormatString="javascript:showEditor({0})">
                </PropertiesHyperLinkEdit>
                <EditFormSettings Visible="False" />
            </dx:GridViewDataHyperLinkColumn>
            <dx:GridViewCommandColumn ButtonType="Image" Caption="&amp;nbsp;"
                VisibleIndex="0" Width="16px">
                <DeleteButton Visible="True">
                    <Image Url="~/zulu_web/images/delete.gif">
                    </Image>
                </DeleteButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="title" VisibleIndex="1"
                Caption="หัวเรื่อง">
            </dx:GridViewDataTextColumn>
        
            <dx:GridViewDataDateColumn FieldName="modifyDate" VisibleIndex="3"
                Caption="แก้ไขล่าสุด">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="modifyBy" VisibleIndex="4"
                Caption="ผู้แก้ไข">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="createDate" VisibleIndex="5"
                Caption="วันที่สร้าง">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="createBy" VisibleIndex="7"
                Caption="ผู้สร้าง">
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior ConfirmDelete="True" />
        <SettingsText ConfirmDelete="ต้องการลบใช่หรือไม่?" />
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:ZuluDB %>"
        SelectCommand="SELECT [itemID], [title], [modifyDate], [modifyBy], [createDate], [createBy],[contentType] FROM [ZCMS_CONTENT] WHERE  ([contentID] = @contentID) and ([siteID]=@siteID)   ORDER BY [itemID] DESC"
        DeleteCommand="DELETE FROM ZCMS_CONTENT WHERE (itemID = @itemID)">
        <DeleteParameters>
            <asp:Parameter Name="itemID" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Name="contentID" Type="String" />
            <asp:Parameter Name="siteID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server"
        ConnectionString="<%$ ConnectionStrings:ZuluDB %>" SelectCommand="SELECT * FROM [ZCMS_CONTENT_TYPE]"></asp:SqlDataSource>
</asp:Content>


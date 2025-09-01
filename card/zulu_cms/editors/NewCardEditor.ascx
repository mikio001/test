<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NewCardEditor.ascx.vb" Inherits="zulu_cms_editors_NewsCard" %>
<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<script type="text/javascript">
    var contetID = "<%=GetContentID()%>";

    function showEditor(newsID) {
        window.location = "Editor.aspx?editor=NewCardForm&itemID=" + newsID + "&contentID=" + contetID;
    }
</script>
<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
    ClientIDMode="AutoID" DataSourceID="SqlDataSource1" KeyFieldName="itemID" 
    Width="100%">
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
        <dx:GridViewDataTextColumn Caption="ลำดับ" FieldName="orderNo" VisibleIndex="2" 
            Width="30px">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataImageColumn Caption="ภาพตัวอย่าง" VisibleIndex="3" 
            FieldName="refUrl">
            <PropertiesImage ImageUrlFormatString="{0}&amp;thumb=1">
            </PropertiesImage>
        </dx:GridViewDataImageColumn>
        <dx:GridViewDataTextColumn FieldName="title" VisibleIndex="1" 
            Caption="หัวเรื่อง">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataComboBoxColumn Caption="ประเภท" FieldName="contentType" 
            VisibleIndex="4">
            <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="name" 
                ValueField="contentTypeID" ValueType="System.Int32">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataDateColumn FieldName="modifyDate" VisibleIndex="5" 
            Caption="แก้ไขล่าสุด">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="modifyBy" VisibleIndex="6" 
            Caption="ผู้แก้ไข">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="createDate" VisibleIndex="7" 
            Caption="วันที่สร้าง">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="createBy" VisibleIndex="8" 
            Caption="ผู้สร้าง">
        </dx:GridViewDataTextColumn>
    </Columns>
    <SettingsBehavior ConfirmDelete="True" />
    <SettingsText ConfirmDelete="ต้องการลบเนื้อหาใช่หรือไม่?" />
</dx:ASPxGridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ZuluDB %>" 
    
    SelectCommand="SELECT [itemID], [title], [modifyDate], [modifyBy], [createDate], [createBy],[contentType],orderNo,refUrl FROM [ZCMS_CONTENT] WHERE ([contentID] = @contentID) and ([siteID]=@siteID) and expireDate >= GETDATE() order by itemID desc" 
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
    ConnectionString="<%$ ConnectionStrings:ZuluDB %>" 
    SelectCommand="SELECT * FROM [ZCMS_CONTENT_TYPE]"></asp:SqlDataSource>



<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GalleryFileEditor.ascx.vb" Inherits="zulu_cms_editors_LinkEditor" %>
<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<script src="../zulu_store/script.js" type="text/javascript"></script>
<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
    ClientIDMode="AutoID" ClientInstanceName="ASPxGridView1" DataSourceID="SqlDataSource1" KeyFieldName="itemID" 
    Width="100%">
    <Columns>
        <dx:GridViewCommandColumn Caption="&amp;nbsp;" VisibleIndex="0" 
            ButtonType="Image" Width="60px">
            <EditButton Visible="True">
                <Image Url="~/zulu_web/images/edit.gif">
                </Image>
            </EditButton>
            <NewButton Visible="True">
                <Image Url="~/zulu_web/images/add.gif">
                </Image>
            </NewButton>
            <DeleteButton Visible="True">
                <Image Url="~/zulu_web/images/delete.gif">
                </Image>
            </DeleteButton>
            <CancelButton>
                <Image Url="~/zulu_web/images/cancel.gif">
                </Image>
            </CancelButton>
            <UpdateButton>
                <Image Url="~/zulu_web/images/save.gif">
                </Image>
            </UpdateButton>
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn ShowInCustomizationForm="True" VisibleIndex="0" 
            Width="20px">
            <DataItemTemplate>
                <a href="#" onclick="GalleryFileBrowser(<%#eval("itemID")%>)" ><img src="../zulu_web/images/folder.gif" border=0 /></a>
            </DataItemTemplate>
            <EditItemTemplate>
                &nbsp;&nbsp;
            </EditItemTemplate>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataSpinEditColumn Caption="ลำดับที่" FieldName="orderNo" 
            VisibleIndex="1" Width="40px">
            <PropertiesSpinEdit DisplayFormatString="g" Width="40px">
                <ValidationSettings>
                    <RequiredField IsRequired="True" />
                </ValidationSettings>
            </PropertiesSpinEdit>
        </dx:GridViewDataSpinEditColumn>
        <dx:GridViewDataTextColumn FieldName="title" VisibleIndex="3" 
            Caption="ชื่ออัลบั้ม" Width="200px">
            <PropertiesTextEdit Width="200px">
                <ValidationSettings>
                    <RequiredField IsRequired="True" />
                </ValidationSettings>
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataMemoColumn Caption="คำอธิบาย" FieldName="contentBody" 
            VisibleIndex="4">
            <PropertiesMemoEdit Rows="3" Width="300px">
            </PropertiesMemoEdit>
        </dx:GridViewDataMemoColumn>
    </Columns>
    <SettingsBehavior ConfirmDelete="True" />
    <SettingsEditing Mode="Inline" />
    <SettingsText ConfirmDelete="ท่านต้องการลบข้อมูลใช่หรือไม่?" />
</dx:ASPxGridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConflictDetection="CompareAllValues" 
    ConnectionString="<%$ ConnectionStrings:ZuluDB %>" 
    DeleteCommand="DELETE FROM [ZCMS_CONTENT] WHERE [itemID] = @original_itemID" 
    InsertCommand="INSERT INTO [ZCMS_CONTENT] ([title], [contentBody], [contentID], [orderNo], [refUrl], [siteID],[modifyBy],[modifyDate], [editorID],createDate,createBy,status,contentType) VALUES (@title, @contentBody, @contentID, @orderNo, @refUrl, @siteID,@modifyBy,GETDATE(), 'LINK',GETDATE(),@modifyBy,0,@contentType)"
    OldValuesParameterFormatString="original_{0}" 
    SelectCommand="SELECT * FROM [ZCMS_CONTENT] WHERE ([contentID] = @contentID) and ([siteID]=@siteID) ORDER BY [orderNo]" 
    UpdateCommand="UPDATE [ZCMS_CONTENT] SET [title] = @title, [contentBody] = @contentBody, [orderNo] = @orderNo, [refUrl] = @refUrl, [modifyBy]=@modifyBy, [modifyDate]=GETDATE(),contentType=@contentType WHERE [itemID] = @original_itemID">
    <DeleteParameters>
        <asp:Parameter Name="original_itemID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="title" Type="String" />
        <asp:Parameter Name="contentBody" Type="String" />
        <asp:Parameter Name="contentID" Type="String" />
        <asp:Parameter Name="orderNo" Type="Int32" />
        <asp:Parameter Name="refUrl" Type="String" />
        <asp:Parameter Name="siteID" Type="String" />
        <asp:Parameter Name="modifyBy" Type="String" />
        <asp:Parameter Name="contentType" Type="Int32" />
    </InsertParameters>
    <SelectParameters>
        <asp:Parameter Name="contentID" Type="String" />
        <asp:Parameter Name="siteID" Type="String" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="title" Type="String" />
        <asp:Parameter Name="contentBody" Type="String" />
        <asp:Parameter Name="contentID" Type="String" />
        <asp:Parameter Name="orderNo" Type="Int32" />
        <asp:Parameter Name="refUrl" Type="String" />
        <asp:Parameter Name="original_itemID" Type="Int32" />
        <asp:Parameter Name="modifyBy" Type="String" />
        <asp:Parameter Name="contentType" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ZuluDB %>" 
    SelectCommand="SELECT * FROM [ZCMS_CONTENT_TYPE]"></asp:SqlDataSource>



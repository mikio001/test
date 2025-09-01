<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SearchResult.ascx.vb" Inherits="zulu_cms_contents_SearchResult" %>
<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<dx:ASPxGridView ID="resultGrid" runat="server" Width="100%" 
    AutoGenerateColumns="False" ClientIDMode="AutoID" DataSourceID="SqlDataSource1" 
    KeyFieldName="itemID">
    <Columns>
        <dx:GridViewDataHyperLinkColumn Caption="ชื่อรายการ" FieldName="itemID" 
            VisibleIndex="2">
            <PropertiesHyperLinkEdit TextField="title">
            </PropertiesHyperLinkEdit>
            <CellStyle HorizontalAlign="Left">
            </CellStyle>
        </dx:GridViewDataHyperLinkColumn>
        <dx:GridViewDataDateColumn Caption="วันที่ปรับปรุงล่าสุด" 
            FieldName="modifyDate" VisibleIndex="3" Width="140px">
            <PropertiesDateEdit DisplayFormatString="d MMM yyyy HH:mm:ss">
            </PropertiesDateEdit>
        </dx:GridViewDataDateColumn>
    </Columns>
    <Styles>
        <AlternatingRow BackColor="#F3F3F3">
        </AlternatingRow>
    </Styles>
    <Border BorderStyle="None" />
</dx:ASPxGridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ZuluDB %>" 
    SelectCommand="SELECT [itemID], [title], [modifyDate] FROM [ZCMS_CONTENT] WHERE   (CONTAINS([contentBody], @keyword) OR CONTAINS([title], @keyword))">
    <SelectParameters>
    
       
        <asp:Parameter Name="keyword" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>


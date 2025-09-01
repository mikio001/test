<%@ Page Title="" Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPageAUTH.master" AutoEventWireup="false" CodeFile="Unit.aspx.vb" Inherits="Main_COFFEE_ManageTable" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBanner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableTheming="True" KeyFieldName="UnitID" Theme="Moderno" Width="100%">
        <SettingsCommandButton>
            <NewButton Text="เพิ่ม">
            </NewButton>
            <UpdateButton Text="บันทึก">
            </UpdateButton>
            <CancelButton Text="ยกเลิก">
            </CancelButton>
            <EditButton Text="แก้ไข">
            </EditButton>
            <DeleteButton Text="ลบ">
            </DeleteButton>
        </SettingsCommandButton>
          <Columns>
            <dx:GridViewCommandColumn ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="100px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="UnitID" ReadOnly="True" Visible="False" VisibleIndex="1" ShowInCustomizationForm="True">
                <editformsettings visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="หน่วยนับ" FieldName="UnitName" VisibleIndex="2" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior ConfirmDelete="True" />
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" DeleteCommand="DELETE FROM [REF_UNIT] WHERE [UnitID] = @UnitID" InsertCommand="INSERT INTO REF_UNIT(UnitName) VALUES (@UnitName)" SelectCommand="SELECT * FROM [REF_UNIT]" UpdateCommand="UPDATE REF_UNIT SET UnitName = @UnitName WHERE (UnitID = @UnitID)">
        <DeleteParameters>
            <asp:Parameter Name="UnitID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="UnitName" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="UnitName" Type="String" />
            <asp:Parameter Name="UnitID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" Runat="Server">
</asp:Content>


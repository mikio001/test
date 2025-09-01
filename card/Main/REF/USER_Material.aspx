<%@ Page Title="" Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPageAUTH.master" AutoEventWireup="false" CodeFile="USER_Material.aspx.vb" Inherits="Main_COFFEE_ManageTable" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBanner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="window.open('print/rptMaterial.aspx?type=' + 'IS' , '_blank')"> <span class="glyphicon glyphicon-print"></span> พิมพ์รายงานวัสดุIS</button>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableTheming="True" KeyFieldName="MaterialID" Theme="Moderno" Width="100%">
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
          <SettingsPopup>
            <EditForm HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter" />
        </SettingsPopup>
        <SettingsSearchPanel Visible="True" />
        <Columns>
            <dx:GridViewCommandColumn ButtonType="Button" VisibleIndex="0" Visible="False">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="MaterialID" ReadOnly="True" Visible="False" VisibleIndex="1">
                <editformsettings visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="รหัสวัตถุดิบ" FieldName="MaterialCode" VisibleIndex="2" Width="100px">
                <PropertiesTextEdit Width="100px">
                </PropertiesTextEdit>
              
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="ชื่อวัตถุดิบ/รายการ" FieldName="MaterialName" VisibleIndex="3">
                <PropertiesTextEdit>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="รหัสบาร์โค๊ด" FieldName="Barcode" VisibleIndex="4">
                <PropertiesTextEdit>
                    <ValidationSettings ErrorDisplayMode="ImageWithText">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="ประเภท" FieldName="TypeID" VisibleIndex="7">
                <PropertiesComboBox DataSourceID="REF_TYPE" TextField="TypeName" ValueField="TypeID">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="หน่วยนับ" FieldName="UnitID" VisibleIndex="8">
                <PropertiesComboBox DataSourceID="REF_UNIT" TextField="UnitName" ValueField="UnitID">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn Caption="จำนวนขั้นต่ำ" FieldName="MinVolumn" VisibleIndex="5" Width="50px">
                <PropertiesSpinEdit DisplayFormatString="g" NullDisplayText="0" Width="100px">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataMemoColumn Caption="หมายเหตุ" FieldName="Remark" VisibleIndex="9">
                <PropertiesMemoEdit Height="50px">
                </PropertiesMemoEdit>
            </dx:GridViewDataMemoColumn>
            <dx:GridViewDataTextColumn Caption="จำนวนคงเหลือ" FieldName="BalanceVolumn" VisibleIndex="6" Width="50px">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
          
            <dx:GridViewDataTextColumn Caption="สถานที่" FieldName="location" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
          
        </Columns>
        <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm">
        </SettingsEditing>
        <Settings ShowHeaderFilterButton="True" />
        <SettingsBehavior ConfirmDelete="True" />
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" DeleteCommand="UPDATE REF_MATERIAL SET  MaterialStatus = N'D' WHERE (MaterialID = @MaterialID)" InsertCommand="INSERT INTO REF_MATERIAL(MaterialCode, MaterialName, Barcode, MinVolumn, TypeID, UnitID, Remark, CreateDate, CreateUser, BalanceVolumn, location, MaterialStatus) VALUES (@MaterialCode, @MaterialName, @Barcode, @MinVolumn, @TypeID, @UnitID, @Remark, GETDATE(), @CreateUser, 0, @location, N'N')" SelectCommand="SELECT MaterialID, MaterialCode, MaterialName, Barcode, MinVolumn, TypeID, UnitID, Remark, CreateDate, CreateUser, LastDate, LastUser, BalanceVolumn, Price, location, MaterialStatus FROM REF_MATERIAL WHERE (MaterialStatus = N'N')" UpdateCommand="UPDATE REF_MATERIAL SET MaterialCode = @MaterialCode, MaterialName = @MaterialName, Barcode = @Barcode, MinVolumn = @MinVolumn, TypeID = @TypeID, UnitID = @UnitID, Remark = @Remark, LastDate = GETDATE(), LastUser = @LastUser, location = @location WHERE (MaterialID = @MaterialID)">
        <DeleteParameters>
            <asp:Parameter Name="MaterialID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
           <asp:Parameter Name="MaterialCode" Type="String" />
            <asp:Parameter Name="MaterialName" Type="String" />
            <asp:Parameter Name="Barcode" Type="String" />
            <asp:Parameter Name="MinVolumn" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="TypeID" Type="Int32" />
            <asp:Parameter Name="UnitID" Type="Int32" />
            <asp:Parameter Name="Remark" Type="String" />
            <asp:SessionParameter SessionField="username" Name="CreateUser" Type="String" />  
            <asp:Parameter Name="location" />
        </InsertParameters>
        <UpdateParameters>
           <asp:Parameter Name="MaterialCode" Type="String" />
            <asp:Parameter Name="MaterialName" Type="String" />
            <asp:Parameter Name="Barcode" Type="String" />
            <asp:Parameter Name="MinVolumn" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="TypeID" Type="Int32" />
            <asp:Parameter Name="UnitID" Type="Int32" />
            <asp:Parameter Name="Remark" Type="String" />         
            <asp:SessionParameter SessionField="username" Name="LastUser" Type="String" />           
            <asp:Parameter Name="location" />
            <asp:Parameter Name="MaterialID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="REF_TYPE" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [REF_TYPE]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="REF_UNIT" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [REF_UNIT]">
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" Runat="Server">
</asp:Content>


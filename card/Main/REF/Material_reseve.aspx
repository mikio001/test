<%@ Page Title="" Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPageAUTH.master" AutoEventWireup="false" CodeFile="Material_reseve.aspx.vb" Inherits="Main_COFFEE_ManageTable" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        
     <link href="../eternicode-bootstrap-datepicker/css/datepicker3.css" rel="stylesheet" />

        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBanner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <%#Eval("brand") %>
     <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="window.open('print/rptMaterial_RS.aspx?type=' + 'RS' , '_blank')"> <span class="glyphicon glyphicon-print"></span> พิมพ์รายงานวัสดุ</button>
     <%-- <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="window.open('print/rptMaterial.aspx?type=' + 'IS' , '_blank')"> <span class="glyphicon glyphicon-print"></span> พิมพ์รายงานวัสดุIS</button>--%>
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
            <dx:GridViewCommandColumn ButtonType="Button" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" ShowDeleteButton="True">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="MaterialID" ReadOnly="True" Visible="False" VisibleIndex="1">
                <editformsettings visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="ชื่อวัสดุ" FieldName="MaterialName" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataSpinEditColumn Caption="จำนวนขั้นต่ำ" FieldName="MinVolumn" VisibleIndex="4" Width="50px" Visible="False">
                <PropertiesSpinEdit DisplayFormatString="g" NullDisplayText="0" Width="100px">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataMemoColumn Caption="หมายเหตุ" FieldName="Remark" VisibleIndex="9">
                <PropertiesMemoEdit Height="50px">
                </PropertiesMemoEdit>
            </dx:GridViewDataMemoColumn>
            <dx:GridViewDataTextColumn Caption="จำนวนคงเหลือ" FieldName="BalanceVolumn" VisibleIndex="5" Width="50px">
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
          
            <dx:GridViewDataTextColumn Caption="สถานที่" FieldName="location" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
          
            <dx:GridViewDataTextColumn Caption="view" VisibleIndex="11">
                  <EditFormSettings Visible="False" />
                              <DataItemTemplate>
                  

                    <button class="btn <%# getFile(Eval("MaterialID"))%>" type="button" onclick="txt_MaterialID.SetValue('<%#Eval("MaterialID")%>');loadfile.PerformCallback();$('#md_show').modal('show');">รายละเอียด</button>
<%--loadfile.PerformCallback();--%>
                </DataItemTemplate>
              
            </dx:GridViewDataTextColumn>
          
        </Columns>
        <SettingsPager PageSize="50">
        </SettingsPager>
        <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm">
        </SettingsEditing>
        <Settings ShowHeaderFilterButton="True" />
        <SettingsBehavior ConfirmDelete="True" />
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" DeleteCommand="UPDATE REF_MATERIAL SET  MaterialStatus = N'D' WHERE (MaterialID = @MaterialID)" InsertCommand="INSERT INTO REF_MATERIAL(MaterialCode, MaterialName, Barcode, MinVolumn, TypeID, UnitID, Remark, CreateDate, CreateUser, BalanceVolumn, location, MaterialStatus, IS_IM, ReciveFile) VALUES (@MaterialCode, @MaterialName, @Barcode, 1, @TypeID, @UnitID, @Remark, GETDATE(), @CreateUser, @BalanceVolumn, @location, N'N', N'RS', N'nophoto.jpg')" SelectCommand="SELECT MaterialID, MaterialCode, MaterialName, Barcode, MinVolumn, TypeID, UnitID, Remark, CreateDate, CreateUser, LastDate, LastUser, BalanceVolumn, Price, location, MaterialStatus, IS_IM FROM REF_MATERIAL WHERE (IS_IM = N'RS') AND (MaterialStatus = N'N') ORDER BY MaterialID DESC" UpdateCommand="UPDATE REF_MATERIAL SET MaterialCode = @MaterialCode, MaterialName = @MaterialName, Remark = @Remark, LastDate = GETDATE(), location = @location, BalanceVolumn = @BalanceVolumn WHERE (MaterialID = @MaterialID)">
        <DeleteParameters>
            <asp:Parameter Name="MaterialID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
           <asp:Parameter Name="MaterialCode" Type="String" />
            <asp:Parameter Name="MaterialName" Type="String" />
            <asp:Parameter Name="Barcode" Type="String" />
            <asp:Parameter Name="TypeID" Type="Int32" />
            <asp:Parameter Name="UnitID" Type="Int32" />
            <asp:Parameter Name="Remark" Type="String" />
            <asp:SessionParameter SessionField="username" Name="CreateUser" Type="String" />  
            <asp:Parameter Name="BalanceVolumn" />
            <asp:Parameter Name="location" />
        </InsertParameters>
        <UpdateParameters>
           <asp:Parameter Name="MaterialCode" Type="String" />
            <asp:Parameter Name="MaterialName" Type="String" />
            <asp:Parameter Name="Remark" Type="String" />         
            <asp:Parameter Name="location" />
            <asp:Parameter Name="BalanceVolumn" />
            <asp:Parameter Name="MaterialID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="REF_TYPE" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [REF_TYPE]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="REF_UNIT" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [REF_UNIT]">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="typeim_is" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [REF_IM_IS_TB]">
    </asp:SqlDataSource>

    <div class="modal face" id="mdReport" data-backdrop='static' tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"></h4>
      </div>
      <div class="modal-body">
      <div class="row"  style="  margin-top: 6px;">
    <div class="col-md-3"> <label  class="col-sm-12 control-label" style="  margin-top: 6px;"> เลือกช่วงวันที่ </label></div>    <div class="col-sm-6 ">  
        <div id="sandbox-container"><div class="input-daterange input-group" id="datepicker">
               <asp:TextBox ID="DStart" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
   
    <span class="input-group-addon">to</span>
   <asp:TextBox ID="DEnd" ClientIDMode="Static" CssClass="form-control" class="input-sm form-control" runat="server"></asp:TextBox>
</div></div>
   </div> 

    </div>
          <div class="row" style="padding-top:10px"><div class="col-md-offset-3 col-md-2"> <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="window.open('print/rptMaterial.aspx?DStart=' + $('#DStart').val() + '&DEnd='+$('#DEnd').val() + '&type='+ 'IM', '_blank')">พิมพ์รายงาน</button></div></div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div>


        <div class="modal fade" id="md_show" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document" style = "width:60%">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="H2">รายละเอียด</h4>
      </div>
      <div class="modal-body">
          <dx:ASPxCallbackPanel ID="loadfile" runat="server" ClientInstanceName="loadfile" Width="100%">
              <PanelCollection>
<dx:PanelContent runat="server">
    <asp:DataList ID="DataList2" runat="server" DataKeyField="MaterialID" DataSourceID="SqlDataSource5" Width="100%">
        <ItemTemplate>
         
            <div class="row">
  <div class="col-md-4">
    <div class="thumbnail">
      <a href="/w3images/lights.jpg">
        <img src="img/<%#Eval("ReciveFile") %>" alt="Lights" style="width:100%">
        <div class="caption">
        <%--  <p> ปีงบประมาณ   <label><%#Eval("YEAR") %></label></p>--%>
        </div>
      </a>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
  </div>
  <div class="col-md-8">




    <table class="table">
  <thead>
 <%--   <tr>
      <th scope="col" class="auto-style2">หมายเลขสินทรัพย์ถาวร</th>
      <th >    <label><%#Eval("ID_ITEM") %></label></th>
    
     
    </tr>--%>
  </thead>
  <tbody>
    <tr>
      <th scope="row" class="auto-style2">ชื่อ</th>
    <th ><label><%#Eval("MaterialName") %></label></th>
    
     
    </tr>
    <tr>
      <th scope="row" class="auto-style2">จำนวน</th>
      <th ><label><%#Eval("BalanceVolumn") %></label></th>
      
     
    </tr>
    <%--<tr>
      <th scope="row" class="auto-style2">หน่วยวัด</th>
       <th ><label><%#Eval("unit") %></label></th>
      
     
    </tr>--%>
      <tr>
          <th class="auto-style2" scope="row">ต้นทุนต่อหน่วย</th>
          <th ><label><%#Eval("Price") %></label></th>
      </tr>
      <tr>
          <th class="auto-style2" scope="row">ยี่ห้อ</th>
          <th ><label><%#Eval("brand") %></label></th>
      </tr>
      <tr>
          <th class="auto-style2" scope="row">โมเดล</th>
          <th ><label><%#Eval("modal") %></label></th>
      </tr>
      <tr>
          <th class="auto-style2" scope="row">S/N</th>
          <th ><label><%#Eval("NUM") %></label></th>
      </tr>
      <tr>
          <th class="auto-style2" scope="row">สถานที่เก็บ</th>
           <th ><label><%#Eval("location") %></label></th>
      </tr>
      <tr>
          <th class="auto-style2" scope="row">ผู้รับผิดชอบ</th>
           <th ><label><%#Eval("responsible") %></label></th>
      </tr>
  </tbody>
</table>
  </div>
  
</div>


        
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT [MaterialID], [MaterialCode], [MaterialName], [Barcode], [MinVolumn], [TypeID], [UnitID], [Remark], [CreateDate], [CreateUser], [LastDate], [LastUser], [BalanceVolumn], [Price], [location], [MaterialStatus], [MaterialIM_IS], [IS_IM], [unit], [brand], [modal], [NUM], [Person_Name], [YEAR], [ReciveFile], [lend], [IMG_File_TEMP], [responsible] FROM [REF_MATERIAL] WHERE ([MaterialID] = @MaterialID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="txt_MaterialID" Name="MaterialID" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
                  </dx:PanelContent>
</PanelCollection>
          </dx:ASPxCallbackPanel>


                  
          <dx:ASPxCallback ID="cbfile" runat="server" ClientInstanceName="cbfile">
          </dx:ASPxCallback>

                  
          <table class="nav-justified">
              <tr>
                  <td class="auto-style3">

                  
       <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-static" />
              
                    </td>
                  <td>
              
                   <%-- <button class="btn btn-primary" type="button" onclick="cbfile.PerformCallback();loadfile.PerformCallback();"><span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span></button>--%>
                  </td>
              </tr>
          </table>
                </div>
    <div class="modal-footer">
        <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn btn-primary" />
          <%#Eval("brand") %>
        <button type="button" class="btn btn-default" data-dismiss="modal">Close 
    
  </div>
</div><!-- /.modal -->
        </div>

        <dx:ASPxTextBox ID="reciveID2" ClientVisible="false" runat="server" ClientInstanceName="reciveID2" Width="170px">
    </dx:ASPxTextBox>
<%--ClientVisible="false"--%>
                  
    <dx:ASPxTextBox ID="txt_MaterialID" ClientVisible="false"  runat="server" ClientInstanceName="txt_MaterialID" Width="170px">
    </dx:ASPxTextBox>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" Runat="Server">
      <script src="../eternicode-bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script>
        $('#sandbox-container .input-daterange').datepicker({
            format: "dd/mm/yyyy",
            calendarWeeks: true
        });
  </script>
</asp:Content>


<%@ Page Title="" Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPageAUTH.master" AutoEventWireup="false" CodeFile="card_edit2.aspx.vb" Inherits="Main_COFFEE_ManageTable" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        
     <link href="../eternicode-bootstrap-datepicker/css/datepicker3.css" rel="stylesheet" />
     <style type="text/css">

          #md_show .modal-dialog {
         width:50%}
              .auto-style2 {
                  width: 139px;
              }

              .auto-style3 {
                  width: 142px;
              }


              .auto-style4 {
                  width: 44px;
                  height: 57px;
              }


              .auto-style6 {
                  width: 111px;
                  text-align: right;
              }


              .auto-style7 {
                  width: 256px;
              }


     </style>
     <script>



         function getCheckbox() {
           
             var val = '';
             $(':checkbox:checked').each(function (i) {
                
                     if ($(this).val() != undefined) {
                     if (val != "") {
                         val = val + ","
                     }
                     val = val + "'" + $(this).val() + "'";
                         
                 
                 }
                 
             });
             //    alert(val);
           
             prinData(val);



         }

         function prinData(data) {
             var files = $("#Select1 option:selected").text();
             if (data != "") {
                 // var param = { 'sid': data, 'sname': $("#lblstation").text(), 'files': files };

              
                 var ck = document.getElementById('txt_ck_I').value;


                 window.open("Print/print_report_edit.aspx?type=2&id=" + data);
               

              
             }
                          else {
                 alert("กรุณาเลือกข้อมูล");
             }

         }


         function getCheckbox2() {

             var val = '';
             $(':checkbox:checked').each(function (i) {

                 if ($(this).val() != undefined) {
                     if (val != "") {
                         val = val + ","
                     }
                     val = val + "'" + $(this).val() + "'";


                 }

             });
             //    alert(val);

             prinData2(val);



         }

         function prinData2(data) {
             var files = $("#Select1 option:selected").text();
             if (data != "") {
                 // var param = { 'sid': data, 'sname': $("#lblstation").text(), 'files': files };




                 window.open("Print/print_data.aspx?id=" + data);


             } else {
                 alert("กรุณาเลือกข้อมูล");
             }

         }





         function toggle(oInput) {
    var aInputs = document.getElementsByTagName('input');
    for (var i=0;i<aInputs.length;i++) {
        if (aInputs[i] != oInput) {
            aInputs[i].checked = oInput.checked;
        }
    }
}

     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBanner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
        <table class="nav-justified">
            <tr>
                <td class="auto-style6">&nbsp;ประเภท:</td>
                <td class="auto-style7"><dx:ASPxComboBox ID="ASPxComboBox1" runat="server" AutoPostBack="True" DataSourceID="Card_edit_TB" SelectedIndex="0" TextField="Card_edit_name" ValueField="Card_edit_ID" ClientIDMode="Static" ClientInstanceName="ASPxComboBox1" DataSecurityMode="Strict" Width="250px">
      </dx:ASPxComboBox>
                </td>
                <td>
   
       <%-- <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="txt_ck.SetValue(1);getCheckbox();"> <span class="glyphicon glyphicon-print"></span> ปริ้นบัตร</button> 
                      <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="txt_ck.SetValue(2);getCheckbox();"> <span class="glyphicon glyphicon-print"></span> ปริ้นตาราง</button> --%>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">เลือกทั้งหมด:</td>
                <td class="auto-style7">
  <input type='checkbox' class='checkall'  onClick='toggle(this)' /> <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="txt_ck.SetValue(2);getCheckbox();"> <span class="glyphicon glyphicon-print"></span> ปริ้นตารางPDF</button></td>
                <td>    </td>
            </tr>
            </table>
      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [Card_TYPE_TB]"></asp:SqlDataSource>
     <div class="alert alert-danger" role="alert">
        <strong>แจ้งความประสงค์!</strong> ขอใช้บัตรติดหน้าอกโดยบัตรสีชมพูและสีแดง กรุณาแนบรูปภาพ สวมชุดปกติขาว
      </div
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableTheming="True" KeyFieldName="Card_ID" Theme="Moderno" Width="100%" ClientInstanceName="ASPxGridView1">
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

<FilterControl AutoUpdatePosition="False"></FilterControl>
        </SettingsPopup>
        <SettingsSearchPanel Visible="True" />
                    <EditFormLayoutProperties ColCount="2" ColumnCount="2">
                        <Items>
                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="CitizenID" ColumnSpan="2">
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Card_Name" ColumnSpan="2">
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Card_Surname" ColumnSpan="2">
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Card_Job" ColumnSpan="2">
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Card_TYPE" ColumnSpan="2">
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Card_duty" ColumnSpan="2">
                            </dx:GridViewColumnLayoutItem>
                            <dx:EditModeCommandLayoutItem ColSpan="1" HorizontalAlign="Right">
                            </dx:EditModeCommandLayoutItem>
                        </Items>
                    </EditFormLayoutProperties>
        <Columns>
              <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
              </dx:GridViewCommandColumn>
              <dx:GridViewDataTextColumn Caption="เลือก" VisibleIndex="1" ShowInCustomizationForm="True">
                                  <editformsettings visible="False" />
                                    <dataitemtemplate>
                                       <input id='checkbox<%#Eval("Card_ID")%>' class="form-control" name="selector[]" type="checkbox" value='<%#Eval("Card_ID")%>' />
                                    </dataitemtemplate>
            </dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn Caption="ชื่อ" FieldName="Card_Name" VisibleIndex="4" Width="200px" ShowInCustomizationForm="True">
              
            </dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn Caption="รายละเอียดการปฏิบัติหน้าที่" VisibleIndex="8" FieldName="Card_duty" ShowInCustomizationForm="True">
                            
                <PropertiesTextEdit MaxLength="30">
                </PropertiesTextEdit>
                            
            </dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn Caption="เลขบัตรประชาชน" FieldName="CitizenID" VisibleIndex="9" ShowInCustomizationForm="True" Visible="False">
                <PropertiesTextEdit>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn Caption="รูป" VisibleIndex="2" ShowInCustomizationForm="True">
                  <EditFormSettings Visible="False" />
                  <DataItemTemplate>
                       <img alt="..." class="auto-style4" src='img/<%#Eval("Card_img")%>' onclick='txt_ID.SetValue(&#039;<%#Eval("Card_ID")%>&#039;);loadfile.PerformCallback();$(&#039;#md_show&#039;).modal(&#039;show&#039;);'> </img>
                  </DataItemTemplate>
              </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Card_Surname" VisibleIndex="5" Caption="นามสกุล" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
              <dx:GridViewDataComboBoxColumn Caption="ประเภท" FieldName="Card_TYPE" Visible="False" VisibleIndex="3">
                  <PropertiesComboBox DataSourceID="TYPE" TextField="Card_TYPE_name" ValueField="Card_TYPE">
                  </PropertiesComboBox>
                  <EditFormSettings Visible="True" />
              </dx:GridViewDataComboBoxColumn>
              <dx:GridViewDataComboBoxColumn FieldName="Card_edit_ID" Caption="คณะกรรมการฝ่าย" VisibleIndex="11">
                <PropertiesComboBox DataSourceID="Card_edit_TB" TextField="Card_edit_name" ValueField="Card_edit_ID"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
              <dx:GridViewDataComboBoxColumn Caption="บทบาทหน้าที่" FieldName="Card_Job" VisibleIndex="7" Width="50px">
                  <PropertiesComboBox DataSourceID="event" TextField="event_name" ValueField="event_name">
                  </PropertiesComboBox>
                  <DataItemTemplate>
                      <%#Eval("Card_Job")%><%# getCard_TYPE(Eval("Card_TYPE"))%>
                  </DataItemTemplate>
              </dx:GridViewDataComboBoxColumn>
        </Columns>
     
        <SettingsPager PageSize="200">
            <PageSizeItemSettings ShowAllItem="True" Visible="True">
            </PageSizeItemSettings>
        </SettingsPager>
        <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm">
        </SettingsEditing>
        <Settings ShowHeaderFilterButton="True" ShowFilterRow="True" />
        <SettingsBehavior ConfirmDelete="True" />
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT Card_Num, Card_Name, Card_Surname, CitizenID, Card_Job, Card_duty, Card_FAC_Name, Card_TYPE, Card_Status, Card_img, IMG_File_TEMP, Card_ID, Card_edit_ID, Card_year FROM Card_TB WHERE (Card_edit_ID = @Card_edit_ID) AND (Card_year = 2567) ORDER BY Card_Num DESC" DeleteCommand="DELETE FROM [Card_TB] WHERE [Card_ID] = @Card_ID" InsertCommand="INSERT INTO Card_TB(Card_Num, Card_Name, Card_Surname, Card_Job, Card_duty, Card_TYPE, Card_Status, Card_img, CitizenID, Card_FAC_Name, Card_edit_ID, Card_year) VALUES (@Card_Num, @Card_Name, @Card_Surname, @Card_Job, @Card_duty, @Card_TYPE, @Card_Status, N'nophoto.jpg', @CitizenID, N'มหาวิทยาลัยพะเยา', @Card_edit_ID, 2567)" UpdateCommand="UPDATE Card_TB SET Card_Num = @Card_Num, Card_Name = @Card_Name, Card_Surname = @Card_Surname, Card_Job = @Card_Job, Card_duty = @Card_duty, Card_TYPE = @Card_TYPE, Card_Status = @Card_Status, CitizenID = @CitizenID, Card_FAC_Name = @Card_FAC_Name  WHERE (Card_ID = @Card_ID)">
        <DeleteParameters>
            <asp:Parameter Name="Card_ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Card_Num" Type="String" />
            <asp:Parameter Name="Card_Name" Type="String" />
            <asp:Parameter Name="Card_Surname" Type="String" />
            <asp:Parameter Name="Card_Job" Type="String" />
            <asp:Parameter Name="Card_duty" Type="String" />
            <asp:Parameter Name="Card_TYPE" Type="Int32" />
            <asp:Parameter Name="Card_Status" Type="Int32" />
            <asp:Parameter Name="CitizenID" Type="String" />
          <asp:ControlParameter ControlID="ASPxComboBox1" Name="Card_edit_ID" PropertyName="Value" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ASPxComboBox1" Name="Card_edit_ID" PropertyName="Value" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Card_Num" Type="String" />
            <asp:Parameter Name="Card_Name" Type="String" />
            <asp:Parameter Name="Card_Surname" Type="String" />
            <asp:Parameter Name="Card_Job" Type="String" />
            <asp:Parameter Name="Card_duty" Type="String" />
            <asp:Parameter Name="Card_TYPE" Type="Int32" />
            <asp:Parameter Name="Card_Status" Type="Int32" />
            <asp:Parameter Name="CitizenID" Type="String" />
            <asp:Parameter Name="Card_FAC_Name" Type="String" />
            <asp:Parameter Name="Card_ID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="Card_edit_TB" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT [Card_edit_ID], [Card_edit_name] FROM [Card_edit_TB]">
    </asp:SqlDataSource>
 
    <asp:SqlDataSource ID="REF_TYPE" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT [item_status], [item_status_name] FROM [item_statusTB]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="lean_TB" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT [lean], [lean_name] FROM [lean_TB]">
    </asp:SqlDataSource>

 
    <asp:SqlDataSource ID="TYPE" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT [Card_TYPE], [Card_TYPE_name] FROM [Card_TYPE_TB]">
    </asp:SqlDataSource>

 
    <asp:SqlDataSource ID="event" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT [event_id], [event_name] FROM [event_TB]">
    </asp:SqlDataSource>

     <br />

    <asp:SqlDataSource ID="typeim_is" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [REF_IM_IS_TB]">
    </asp:SqlDataSource>



    <div class="row">
        <div class="col-md-6">

            <div class="alert alert-danger" role="alert">
        <strong>แจ้งความประสงค์!</strong> ขอใช้บัตรจอดรถ
      </div>

<dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource6" KeyFieldName="parking_ID">
<SettingsPopup>
<FilterControl AutoUpdatePosition="False"></FilterControl>
</SettingsPopup>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0"></dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="parking_Name" VisibleIndex="1" Caption="ประเภทบัตรจอดรถ">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="quantity" VisibleIndex="4" Caption="จำนวน">
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="parking_color" Caption="สีบัตร" VisibleIndex="3">
                <EditFormSettings Visible="False"></EditFormSettings>
                <DataItemTemplate>
                    <a style="background-color:  <%#Eval("parking_color")%>">  ____</a>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
        </div>
        <div class="col-md-6">
            <img src="img/2024-01-26_9-25-46.png" style="width: 100%" />
            <img src="img/2024-01-26_9-26-10.png" style="width: 100%" />
            <img src="img/w.png" style="width: 100%" />
        </div>
       
      </div>


    <asp:SqlDataSource runat="server" ID="SqlDataSource6" ConnectionString='<%$ ConnectionStrings:MAINDB %>' DeleteCommand="DELETE FROM [Parking_TB] WHERE [parking_ID] = @parking_ID" InsertCommand="INSERT INTO [Parking_TB] ([parking_name], [Card_edit_ID], [quantity]) VALUES (@parking_name, @Card_edit_ID, @quantity)" SelectCommand="SELECT Parking_TB.parking_ID, Parking_TB.Card_edit_ID, Parking_TB.quantity, parking.parking_Name, parking.parking_color FROM Parking_TB INNER JOIN parking ON Parking_TB.parking_name = parking.parking WHERE (Parking_TB.Card_edit_ID = @Card_edit_ID)" UpdateCommand="UPDATE [Parking_TB] SET [quantity] = @quantity WHERE [parking_ID] = @parking_ID">
        <DeleteParameters>
            <asp:Parameter Name="parking_ID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="parking_name" Type="String"></asp:Parameter>
            <asp:Parameter Name="Card_edit_ID" Type="String"></asp:Parameter>
            <asp:Parameter Name="quantity" Type="String"></asp:Parameter>
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ASPxComboBox1" PropertyName="Value" Name="Card_edit_ID" Type="String"></asp:ControlParameter>
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="quantity" Type="String"></asp:Parameter>
            <asp:Parameter Name="parking_ID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
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
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="H2">อัพโหลดรูป</h4>
      </div>
      <div class="modal-body">
          <dx:ASPxCallbackPanel ID="loadfile" runat="server" ClientInstanceName="loadfile" Width="100%">
              <PanelCollection>
<dx:PanelContent runat="server">
  
         
            


      
    
                  </dx:PanelContent>
</PanelCollection>
          </dx:ASPxCallbackPanel>
    <dx:ASPxTextBox ID="reciveID2" ClientVisible="false" runat="server" ClientInstanceName="reciveID2" Width="170px">
    </dx:ASPxTextBox>

                  
          <dx:ASPxCallback ID="cbfile" runat="server" ClientInstanceName="cbfile">
          </dx:ASPxCallback>

                  
          <table class="nav-justified">
              <tr>
                  <td class="auto-style3">

                  
       <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-static" />
              
                    </td>
                  <td>
              <asp:Button ID="Button2" runat="server" Text="ลบรูป" CssClass="btn btn-danger" />
                     
                
                      </td>
              </tr>
          </table>
                </div>
    <div class="modal-footer">
        <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn btn-primary" />
        <%#Eval("UNITCOST")%>
        <button type="button" class="btn btn-default" data-dismiss="modal">Close   </button>
 
        
        
</div>
    </div>
    
    </div>
    </div>
    


    <dx:ASPxCallbackPanel ID="cbck" runat="server" Width="200px" ClientInstanceName="cbck"></dx:ASPxCallbackPanel>


      <dx:ASPxTextBox ID="txt_ID"  runat="server" ClientInstanceName="txt_ID" ClientVisible="false" Width="170px">
    </dx:ASPxTextBox>
      <dx:ASPxTextBox ID="txt_ck"  runat="server" ClientInstanceName="txt_ck" ClientVisible="false" Width="170px" ClientIDMode="Static">
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


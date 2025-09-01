<%@ Page Title="" Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPageAUTH.master" AutoEventWireup="false" CodeFile="card_edit - Copy.aspx.vb" Inherits="Main_COFFEE_ManageTable" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        
     <link href="../eternicode-bootstrap-datepicker/css/datepicker3.css" rel="stylesheet" />
          <style type="text/css">

          #md_show .modal-dialog {
         width:50%}
              
              .auto-style3 {
                  width: 142px;
              }


              .auto-style6 {
                  width: 111px;
                  text-align: right;
              }


              .auto-style7 {
                  width: 256px;
              }


              .auto-style8 {
                  width: 111px;
                  text-align: right;
                  height: 46px;
              }
              .auto-style9 {
                  width: 256px;
                  height: 46px;
              }
              .auto-style10 {
                  height: 46px;
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
                <td class="auto-style7">
                    
                    <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:MAINDB %>' SelectCommand="SELECT [Card_edit_ID], [Card_edit_name] FROM [Card_edit_TB]"></asp:SqlDataSource>
                    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" AutoPostBack="True" DataSourceID="Card_edit_TB" SelectedIndex="0" TextField="Card_edit_name" ValueField="Card_edit_ID" ClientIDMode="Static" ClientInstanceName="ASPxComboBox1" DataSecurityMode="Strict" Width="250px">
      </dx:ASPxComboBox>
                </td>
                <td>
   
       <%-- <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="txt_ck.SetValue(1);getCheckbox();"> <span class="glyphicon glyphicon-print"></span> ปริ้นบัตร</button> 
                      <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="txt_ck.SetValue(2);getCheckbox();"> <span class="glyphicon glyphicon-print"></span> ปริ้นตาราง</button> --%>
    <asp:SqlDataSource ID="Card_edit_TB" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT [Card_edit_ID], [Card_edit_name] FROM [Card_edit_TB]">
    </asp:SqlDataSource>
 
                </td>
            </tr>
            <tr>
                <td class="auto-style8">เลือกทั้งหมด:</td>
                <td class="auto-style9">
  <input type='checkbox' class='checkall'  onClick='toggle(this)' /> <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="txt_ck.SetValue(2);getCheckbox();"> <span class="glyphicon glyphicon-print"></span> ปริ้นตารางPDF</button></td>
                <td class="auto-style10">    </td>
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
     
        <SettingsPager PageSize="200">
            <PageSizeItemSettings ShowAllItem="True" Visible="True">
            </PageSizeItemSettings>
        </SettingsPager>
        <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm">
        </SettingsEditing>
        <Settings ShowHeaderFilterButton="True" ShowFilterRow="True" />
        <SettingsBehavior ConfirmDelete="True" />
    </dx:ASPxGridView>

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


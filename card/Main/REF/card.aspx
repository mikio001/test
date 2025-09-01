<%@ Page Title="" Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPageAUTH.master" AutoEventWireup="false" CodeFile="card.aspx.vb" Inherits="Main_COFFEE_ManageTable" %>

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

                 var cbb = document.getElementById('ASPxComboBox1_I').value;
                 var ck = document.getElementById('txt_ck_I').value;

 if (ck == "1") {
                    
   if (cbb == "บัตรสีชมพู(บุคคลชั้นในสุด)") {
                     window.open("Print/card_pink.aspx?type=1&id=" + data);
                 }
                 else if (cbb == "บัตรสีแดง(บุคคลชั้นในสุด)") {
                     window.open("Print/BarcodePrint.aspx?type=2&id=" + data);
                 }
                 else if (cbb == "บัตรสีเหลือง(บุคคลชั้นกลาง)") {
                     window.open("Print/card_y.aspx?type=3&id=" + data);
                 }


                 }
 else if (ck == "2") {
                   if (cbb == "บัตรสีชมพู(บุคคลชั้นในสุด)") {
                     window.open("Print/print_r_data.aspx?type=1&id=" + data);
                 }
                 else if (cbb == "บัตรสีแดง(บุคคลชั้นในสุด)") {
                     window.open("Print/print_r_data.aspx?type=2&id=" + data);
                 }
                 else if (cbb == "บัตรสีเหลือง(บุคคลชั้นกลาง)") {
                     window.open("Print/print_r_data.aspx?type=3&id=" + data);
                 }

             }
 else if (ck == "3") {
     if (cbb == "บัตรสีชมพู(บุคคลชั้นในสุด)") {
         window.open("excel.aspx?type=1&id=" + data);
     }
     else if (cbb == "บัตรสีแดง(บุคคลชั้นในสุด)") {
         window.open("excel.aspx?type=2&id=" + data);
     }
     else if (cbb == "บัตรสีเหลือง(บุคคลชั้นกลาง)") {
         window.open("excel.aspx?type=3&id=" + data);
     }

 }

else if (ck == "3") {
     if (cbb == "บัตรสีชมพู(บุคคลชั้นในสุด)") {
         window.open("excel.aspx?type=1&id=" + data);
     }
     else if (cbb == "บัตรสีแดง(บุคคลชั้นในสุด)") {
         window.open("excel.aspx?type=2&id=" + data);
     }
     else if (cbb == "บัตรสีเหลือง(บุคคลชั้นกลาง)") {
         window.open("excel.aspx?type=3&id=" + data);
     }

 }

else if (ck == "4") {
     if (cbb == "บัตรสีชมพู(บุคคลชั้นในสุด)") {
         window.open("Print/print_report.aspx?type=1&id=" + data);
     }
     else if (cbb == "บัตรสีแดง(บุคคลชั้นในสุด)") {
         window.open("Print/print_report.aspx?type=2&id=" + data);
     }
     else if (cbb == "บัตรสีเหลือง(บุคคลชั้นกลาง)") {
         window.open("Print/print_report.aspx?type=3&id=" + data);
     }

 }

              
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
   
    <%--<button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="getCheckbox2();"> <span class="glyphicon glyphicon-print"></span> ข้อมูล</button>--%>
        <table class="nav-justified">
            <tr>
                <td class="auto-style6">&nbsp;ประเภท:</td>
                <td class="auto-style7"><dx:ASPxComboBox ID="ASPxComboBox1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" SelectedIndex="1" TextField="Card_TYPE_name" ValueField="Card_TYPE" ClientIDMode="Static" ClientInstanceName="ASPxComboBox1" DataSecurityMode="Strict" Width="250px">
      </dx:ASPxComboBox>
                </td>
                <td>
   
        <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="txt_ck.SetValue(1);getCheckbox();"> <span class="glyphicon glyphicon-print"></span> ปริ้นบัตร</button> 
                      <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="txt_ck.SetValue(2);getCheckbox();"> <span class="glyphicon glyphicon-print"></span> ปริ้นตารางPDF</button> 
                            <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="txt_ck.SetValue(3);getCheckbox();"> <span class="glyphicon glyphicon-print"></span> ปริ้นตารางEXCEL</button> 
                    <button type="button" class="btn btn-primary " style="margin-bottom:10px; margin-right:14px;" onclick="txt_ck.SetValue(4);getCheckbox();"> <span class="glyphicon glyphicon-print"></span> ปริ้นตารางรายงาน</button> 
                </td>
            </tr>
            <tr>
                <td class="auto-style6">เลือกทั้งหมด:</td>
                <td class="auto-style7">
  <input type='checkbox' class='checkall'  onClick='toggle(this)' /></td>
                <td>&nbsp;</td>
            </tr>
            </table>
      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [Card_TYPE_TB]"></asp:SqlDataSource>
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
                    <EditFormLayoutProperties>
                        <Items>
                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Card_TYPE">
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Card_Num">
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Card_Name">
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Card_Surname">
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Card_Job">
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Card_duty">
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="CitizenID">
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="ฝ่าย">
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
            <dx:GridViewDataTextColumn Caption="ชื่อ" FieldName="Card_Name" VisibleIndex="5" Width="200px" ShowInCustomizationForm="True">
                <PropertiesTextEdit Width="100px">
                </PropertiesTextEdit>
              
            </dx:GridViewDataTextColumn>
          
            <dx:GridViewDataTextColumn Caption="รายละเอียดการปฏิบัติหน้าที่" VisibleIndex="8" FieldName="Card_duty" ShowInCustomizationForm="True">
                            
            </dx:GridViewDataTextColumn>

          
            <dx:GridViewDataTextColumn Caption="เลขบัตรประชาชน" FieldName="CitizenID" VisibleIndex="9" ShowInCustomizationForm="True" Visible="False">
                <PropertiesTextEdit>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
          
          
              <dx:GridViewDataTextColumn Caption="รูป" VisibleIndex="2">
                  <EditFormSettings Visible="False" />
                  <DataItemTemplate>
                       <img alt="..." class="auto-style4" src='img/<%#Eval("Card_img")%>' onclick='txt_ID.SetValue(&#039;<%#Eval("Card_ID")%>&#039;);loadfile.PerformCallback();$(&#039;#md_show&#039;).modal(&#039;show&#039;);'> </img>
                  </DataItemTemplate>
              </dx:GridViewDataTextColumn>

          
            <dx:GridViewDataTextColumn Caption="ลำดับ" VisibleIndex="4" FieldName="Card_Num" Width="30px">
            </dx:GridViewDataTextColumn>

            
            <dx:GridViewDataTextColumn FieldName="Card_Surname" VisibleIndex="6" Caption="นามสกุล">
            </dx:GridViewDataTextColumn>

      
              <dx:GridViewDataComboBoxColumn Caption="ประเภท" FieldName="Card_TYPE" Visible="False" VisibleIndex="3">
                  <PropertiesComboBox DataSourceID="TYPE" TextField="Card_TYPE_name" ValueField="Card_TYPE">
                  </PropertiesComboBox>
                  <EditFormSettings Visible="True" />
              </dx:GridViewDataComboBoxColumn>

            
              <dx:GridViewDataComboBoxColumn Caption="ฝ่าย" FieldName="Card_edit_ID" VisibleIndex="11">
                  <PropertiesComboBox DataSourceID="REF_TYPE" TextField="Card_edit_name" ValueField="Card_edit_ID">
                  </PropertiesComboBox>
              </dx:GridViewDataComboBoxColumn>

            
              <dx:GridViewDataComboBoxColumn Caption="บทบาทหน้าที่" FieldName="Card_Job" ShowInCustomizationForm="True" VisibleIndex="7" Width="50px">
                  <PropertiesComboBox DataSourceID="event" TextField="event_name" ValueField="event_name">
                  </PropertiesComboBox>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT Card_Num, Card_Name, Card_Surname, CitizenID, Card_Job, Card_duty, Card_FAC_Name, Card_TYPE, Card_Status, Card_img, IMG_File_TEMP, Card_ID, Card_year, Card_edit_ID FROM Card_TB WHERE (Card_TYPE = @Card_TYPE) AND (Card_year = 2567) ORDER BY Card_Num" DeleteCommand="DELETE FROM [Card_TB] WHERE [Card_ID] = @Card_ID" InsertCommand="INSERT INTO Card_TB(Card_Num, Card_Name, Card_Surname, Card_Job, Card_duty, Card_TYPE, Card_Status, Card_img, CitizenID, Card_FAC_Name, Card_year, Card_edit_ID) VALUES (@Card_Num, @Card_Name, @Card_Surname, @Card_Job, @Card_duty, @Card_TYPE, @Card_Status, N'nophoto.jpg', @CitizenID, @Card_FAC_Name, 2567, @Card_edit_ID)" UpdateCommand="UPDATE Card_TB SET Card_Num = @Card_Num, Card_Name = @Card_Name, Card_Surname = @Card_Surname, Card_Job = @Card_Job, Card_duty = @Card_duty, Card_TYPE = @Card_TYPE, Card_Status = @Card_Status, CitizenID = @CitizenID, Card_FAC_Name = @Card_FAC_Name, Card_edit_ID = @Card_edit_ID WHERE (Card_ID = @Card_ID)">
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
            <asp:Parameter Name="Card_FAC_Name" Type="String" />
            <asp:Parameter Name="Card_edit_ID" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ASPxComboBox1" Name="Card_TYPE" PropertyName="Value" />
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
            <asp:Parameter Name="Card_edit_ID" />
            <asp:Parameter Name="Card_ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>


    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
    </dx:ASPxGridViewExporter>
    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="ASPxButton">
    </dx:ASPxButton>


 
    <asp:SqlDataSource ID="REF_TYPE" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [Card_edit_TB]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="lean_TB" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT [lean], [lean_name] FROM [lean_TB]">
    </asp:SqlDataSource>

 
    <asp:SqlDataSource ID="TYPE" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT [Card_TYPE], [Card_TYPE_name] FROM [Card_TYPE_TB]">
    </asp:SqlDataSource>

 
    <asp:SqlDataSource ID="event" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT event_id, event_name FROM event_TB ">
    </asp:SqlDataSource>



     <br />

    <asp:SqlDataSource ID="typeim_is" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [REF_IM_IS_TB]">
    </asp:SqlDataSource>
     




    <div class="panel-group">
  <div class="panel panel-default">
    <div class="panel-body">แสดงรายชื่อที่ซ้ำ<div>
  </div>
  <div class="panel panel-default">
    <div class="panel-body">

<asp:DataList ID="DataList4" runat="server" DataSourceID="SqlDataSource6" Width="100%">
        <ItemTemplate>
            ชื่อ:<asp:Label ID="Card_NameLabel" runat="server" Text='<%# Eval("Card_Name") %>' />
            <br />
            ฝ่าย:
            <asp:Label ID="Card_edit_nameLabel" runat="server" Text='<%# Eval("Card_edit_name") %>' />
            <br />
            สีบัตร:
            <asp:Label ID="Card_TYPE_nameLabel" runat="server" Text='<%# Eval("Card_TYPE_name") %>' />
            <br />
            เลขบัตร:  <asp:Label ID="Label1" runat="server" Text='<%# Eval("CitizenID") %>' />
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>


    </div>
  </div>
</div>

    
      <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT Card_TB.Card_Name, Card_edit_TB.Card_edit_name, Card_TYPE_TB.Card_TYPE_name, Card_TB.CitizenID FROM View_duplicate INNER JOIN Card_TB ON View_duplicate.CitizenID = Card_TB.CitizenID INNER JOIN Card_edit_TB ON Card_TB.Card_edit_ID = Card_edit_TB.Card_edit_ID INNER JOIN Card_TYPE_TB ON Card_TB.Card_TYPE = Card_TYPE_TB.Card_TYPE ORDER BY Card_TB.CitizenID"></asp:SqlDataSource>
     
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
        <h4 class="modal-title" id="H2">รายละเอียดครุภัณฑ์</h4>
      </div>
      <div class="modal-body">
          <dx:ASPxCallbackPanel ID="loadfile" runat="server" ClientInstanceName="loadfile" Width="100%">
              <PanelCollection>
<dx:PanelContent runat="server">
  
         
            <div class="row">
  <div class="col-md-4">


    

      

      
    

      

  </div>
  <div class="col-md-8">

      
          


      

      
          


      

  </div>
  
</div>


      
    
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
        <%#Eval("SERIALNUM")%>
        <button type="button" class="btn btn-default" data-dismiss="modal">Close   </button>
 
        
        
</div>
    </div>
    
    </div>
    </div>
    <div class="modal fade" id="md_edit" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="H2">สถานะ</h4>
      </div>
      <div class="modal-body">
          
          <dx:BootstrapComboBox ID="cbbstatus" runat="server" DataSourceID="SqlDataSource4" SelectedIndex="0" TextField="item_status_name" ValueField="item_status"></dx:BootstrapComboBox>

                  
    
                      <br />
    
             <dx:ASPxTextBox ID="txtlocation"  runat="server" ClientInstanceName="txtlocation" Width="170px" NullText="สถานที่">
    </dx:ASPxTextBox>
                <br />
          <dx:BootstrapMemo ID="Memo1" runat="server" NullText="รายละเอียด" Width="100%">
          </dx:BootstrapMemo>

                  
    
                  
          
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [item_statusTB]"></asp:SqlDataSource>

                  
    
                  
          
                </div>
    <div class="modal-footer">
        <asp:Button ID="Button4" runat="server" Text="บันทึก" CssClass="btn btn-primary" />

        <button type="button" class="btn btn-default" data-dismiss="modal">Close  </button> 
 
        </div>
        </div>
</div>
    </div>


    <dx:ASPxCallbackPanel ID="cbck" runat="server" Width="200px" ClientInstanceName="cbck"></dx:ASPxCallbackPanel>


      <dx:ASPxTextBox ID="txt_ID"  runat="server" ClientInstanceName="txt_ID" Width="170px" ClientVisible="false">
    </dx:ASPxTextBox>
      <dx:ASPxTextBox ID="txt_ck"  runat="server" ClientInstanceName="txt_ck" Width="170px" ClientIDMode="Static" >
    </dx:ASPxTextBox>
<%--ClientVisible="false"--%>

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


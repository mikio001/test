<%@ Page Title="" Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPageAUTH.master" AutoEventWireup="false" CodeFile="item.aspx.vb" Inherits="Main_COFFEE_ManageTable" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        
     <link href="../eternicode-bootstrap-datepicker/css/datepicker3.css" rel="stylesheet" />
          <style type="text/css">
              #md_show .modal-dialog {
                  width: 50%
              }
                #md_edit .modal-dialog {
                  width: 60%
              }

              .auto-style2 {
                  width: 139px;
              }


              .auto-style3 {
                  width: 142px;
              }

            .highlighted {
    background-color: yellow; /* เปลี่ยนสีเป็นสีเหลืองหรือสีที่คุณต้องการ */
}

              .auto-style4 {
                  width: 89px;
              }
              .auto-style6 {
                  width: 50px;
                  text-align: right;
              }
              .auto-style7 {
                  width: 267px;
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
                 window.open("Print/print_item1_img.aspx?id=" + data);


             } else {
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


         function refreshDiv() {
             // สร้าง XMLHttpRequest object
           
         }

      

     </script>
     <script>


     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBanner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <%
           Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
           Dim builder As New StringBuilder
           builder.Append(" SELECT  TOP (" + "1200" + ") *   FROM dbo.View_ASSET where 1 = 1  ")

           builder.Append("AND (ASSETID LIKE N'%" + txt_search.Value + "%' OR NAME LIKE N'%" + txt_search.Value + "%' OR MAINTENANCEINFO1 LIKE N'%" + txt_search.Value + "%' OR MODEL LIKE N'%" + txt_search.Value + "%'  OR SERIALNUM LIKE N'%" + txt_search.Value + "%'  OR location LIKE N'%" + txt_search.Value + "%' OR caretaker LIKE N'%" + txt_search.Value + "%')")

           If rdock.SelectedItem.Value = "0" Then
           ElseIf rdock.SelectedItem.Value = "//" Then
               builder.Append("AND (ck LIKE N'%" + "//" + "%')")
           ElseIf rdock.SelectedItem.Value = "--" Then
               builder.Append("AND (ck LIKE N'%" + "--" + "%')")
           End If

           If ASPxComboBox1.SelectedItem.Value = "13" Then

           Else
               builder.Append("AND (item_status =" + ASPxComboBox1.SelectedItem.Value + ")")
           End If


           Dim dtb = db.GetDataTable(builder.ToString)

    %>
    <ul class="nav nav-pills">
  <li class="nav-item">
   <input type='checkbox' class='checkall'  onClick='toggle(this)' />
  </li>
  <li class="nav-item">
     <a class="nav-link active" href="#" onclick="getCheckbox2();" ><span class="glyphicon glyphicon-print"></span>  พิมพ์ข้อมูล</a>
  </li>
 
 
        <li class="nav-item">
    <a class="nav-link active" href="#" onclick="getCheckbox();" ><span class="glyphicon glyphicon-print"></span>  พิมพ์รูปภาพ</a>
  </li>
         <li class="nav-item">
       <asp:Button ID="bntprint" runat="server" Text="พิมพ์รายงานทั้งหมด" CssClass="btn " />
    
  </li>
        <li class="nav-item">
            <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" SelectedIndex="12" TextField="item_status_name" ValueField="item_status">
            </dx:ASPxComboBox>
        </li>
</ul>
 
       

    <br />
    <table class="nav-justified">
        
        <tr>
            <td class="auto-style6">ค้นหา:</td>
            <td class="auto-style7">
      <dx:BootstrapTextBox ID="txt_search" runat="server" ClientInstanceName="txt_search"></dx:BootstrapTextBox>
            </td>
            <td>



                <asp:Button ID="Button3" runat="server" Text="ค้นหา " />
            </td>
            <td style="text-align: right">
                <dx:ASPxRadioButtonList ID="rdock" runat="server" ClientInstanceName="rdock" RepeatDirection="Horizontal" SelectedIndex="0" AutoPostBack="True">
                    <Items>
                        <dx:ListEditItem Text="ทั้งหมด" Value="0" Selected="True"></dx:ListEditItem>
                        <dx:ListEditItem Text="เสร็จสิ้น" Value="//"></dx:ListEditItem>
                        <dx:ListEditItem Text="รอดำเนินการ" Value="--"></dx:ListEditItem>
                    </Items>
                </dx:ASPxRadioButtonList>
 

               
  
            </td>
              <td style="text-align: right">
                       <button type="button" class="btn btn-dark">
  แสดงรายการ <span class="badge badge-light"><% Response.Write(dtb.Rows.Count)%></span>
  <span class="sr-only">unread messages</span>
</button>
                         </td>
        </tr>
        
    </table>
&nbsp;
      
  

   
 
    <table class="table table-bordered"  id="myTable_RNF">
        <thead>
            <tr style=" background-color: #7f64ff78;">
                <th style="width: 2%;">เลือก</th>
                 <th style="width: 2%;">ลำดับ</th>
                <th style="width: 2%;">view</th>
                <%--<th style="width: 2%;">/</th>--%>
                <th style="width: 2%;">แก้ไข</th>
                <th style="width: 25%;">หมายเลขครุภัณฑ์</th>
                <th style="width: 25%;">ชื่อ</th>
                <th style="width: 12%;">ยี่ห้อ</th>
                <th style="width: 12%;">โมเดล</th>
                <th style="width: 2%;">s/n</th>
                <th style="width: 2%;">สถานที่</th>
                <th style="width: 12%;">ผู้รับผิดชอบ</th>
            </tr>
        </thead>
        <tbody >
            <%
                Dim i As Integer = 0
                While (i < dtb.Rows.Count)

            %>
       
            <tr >
                 
                 <td class="">
                     <input id='checkbox <% Response.Write(dtb.Rows(i).Item("ASSETID"))%>' class="form-control" name="selector[]" type="checkbox" value='<% Response.Write(dtb.Rows(i).Item("ASSETID"))%>' />
                                </td>
                                  <td>
                   <% Response.Write(i + 1)%>
                </td>
                <td>
                    <%  If dtb.Rows(i).Item("ReciveFile") = "nophoto.jpg" Then %>
                    <button class='btn ' onclick='txt_ID.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("ASSETID"))%>&#039;);loadfile.PerformCallback();$(&#039;#md_show&#039;).modal(&#039;show&#039;);' type="button">
                        <span class="glyphicon glyphicon-th-list" aria-hidden="true"></span>
                    </button>
                    <% Else %>
                    <button class='btn btn-success' onclick='txt_ID.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("ASSETID"))%>&#039;);loadfile.PerformCallback();$(&#039;#md_show&#039;).modal(&#039;show&#039;);' type="button">
                        <span class="glyphicon glyphicon-th-list" aria-hidden="true"></span>
                    </button>
                    <% End If %>
                </td>


            <%--    <td>
                    <button class='btn ' onclick='txt_ID.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("ASSETID"))%>&#039;);cbck.PerformCallback();refreshDiv();' type="button">
                        <% Response.Write(dtb.Rows(i).Item("ck"))%>
                    </button>
                </td>--%>
                               
                   <td>
                           <%  If dtb.Rows(i).Item("ck") = "--" Then %>
                  <button class='btn ' onclick='txt_ID.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("ASSETID"))%>&#039;);txtck.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("ck"))%>&#039;);txtcaretaker.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("caretaker"))%>&#039;);txtlocation.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("location_new"))%>&#039;);txtdetail.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("detail"))%>&#039;);cbbstatus.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("item_status"))%>&#039;);$(&#039;#md_edit&#039;).modal(&#039;show&#039;);txt1.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("ASSETID"))%>&#039;);txt2.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("NAME"))%>&#039;);loadimg.PerformCallback();' type="button">
                    <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                    </button>
                    <% Else %>
                    <button class='btn btn-success' onclick='txt_ID.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("ASSETID"))%>&#039;);txtck.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("ck"))%>&#039;);txtcaretaker.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("caretaker"))%>&#039;);txtlocation.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("location_new"))%>&#039;);txtdetail.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("detail"))%>&#039;);cbbstatus.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("item_status"))%>&#039;);$(&#039;#md_edit&#039;).modal(&#039;show&#039;);txt1.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("ASSETID"))%>&#039;);txt2.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("NAME"))%>&#039;);loadimg.PerformCallback();' type="button">
                    <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                    </button>
                    <% End If %>


                        
                </td>

                <td>
                    <% Response.Write(dtb.Rows(i).Item("ASSETID"))%>
                </td>
                <td>
                    <% Response.Write(dtb.Rows(i).Item("NAME"))%>
                </td>
                                <td>
                    <% Response.Write(dtb.Rows(i).Item("MAINTENANCEINFO1"))%>
                </td>
                                <td>
                    <% Response.Write(dtb.Rows(i).Item("MODEL"))%>
                </td>
                                <td>
                    <% Response.Write(dtb.Rows(i).Item("SERIALNUM"))%>
                </td>
                              <td>
                    <% Response.Write(dtb.Rows(i).Item("location_new"))%>
                </td>
                              <td>
                    <% Response.Write(dtb.Rows(i).Item("caretaker"))%>
                </td>
            </tr>
            <%
                    i += 1
                End While
                db.Close()
            %>
        </tbody>
    </table>
   
       

    <%
        db.Close()
    %>
   



      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT [item_status_name], [item_status] FROM [item_statusTB]"></asp:SqlDataSource>
        


    <asp:SqlDataSource ID="REF_TYPE" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT [item_status], [item_status_name] FROM [item_statusTB]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="lean_TB" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT [lean], [lean_name] FROM [lean_TB]">
    </asp:SqlDataSource>

     <br />

    <asp:SqlDataSource ID="typeim_is" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [REF_IM_IS_TB]">
    </asp:SqlDataSource>
       <dx:ASPxTextBox ID="txt_ID"  runat="server" ClientInstanceName="txt_ID"  ClientVisible="False" Width="170px">
    </dx:ASPxTextBox>
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

<%#Eval("MAINTENANCEINFO1")%>
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

<asp:DataList ID="DataList1" runat="server" DataKeyField="ID_ITEM" DataSourceID="SqlDataSource3" Width="100%">
          <ItemTemplate>
<div class="thumbnail">
      <a href="/w3images/lights.jpg">
        <img src="img/<%#Eval("ReciveFile") %>" alt="Lights" style="width:100%">
        <div class="caption">
          <p> <%#Eval("item_status_name")%>  </p>
               <p> <%#Eval("detail")%> </p>
        </div>
      </a>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>



          </ItemTemplate>
      </asp:DataList>
    

      

      <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT ITEM_TB.ID_ITEM, ITEM_TB.item_status, ITEM_TB.ReciveFile, item_statusTB.item_status_name, ITEM_TB.detail FROM ITEM_TB INNER JOIN item_statusTB ON ITEM_TB.item_status = item_statusTB.item_status WHERE (ITEM_TB.ID_ITEM = @ID_ITEM)">
          <SelectParameters>
              <asp:ControlParameter ControlID="txt_ID" Name="ID_ITEM" PropertyName="Text" Type="String" />
          </SelectParameters>
      </asp:SqlDataSource>
    

      

  </div>
  <div class="col-md-8">

      <asp:DataList ID="DataList3" runat="server" DataSourceID="SqlDataitem" Width="100%">

          <ItemTemplate>
<table class="table">
  <thead>
    <tr>
      <th scope="col" class="auto-style2">หมายเลขสินทรัพย์ถาวร</th>
      <th >    <label><%#Eval("ASSETID")%></label></th>
        </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row" class="auto-style2">ชื่อ</th>
    <th ><label><%#Eval("NAME")%></label></th>
    
     
    </tr>
    
    <tr>
      <th scope="row" class="auto-style2">หน่วยวัด</th>
       <th ><label><%#Eval("UNITOFMEASURE")%></label></th>
      
     
    </tr>
      <tr>
          <th class="auto-style2" scope="row">ต้นทุนต่อหน่วย</th>
          <th ><label><%#Eval("UNITCOST")%></label></th>
      </tr>
      <tr>
          <th class="auto-style2" scope="row">ยี่ห้อ</th>
          <th ><label><%#Eval("MAINTENANCEINFO1")%></label></th>
      </tr>
      <tr>
          <th class="auto-style2" scope="row">โมเดล</th>
          <th ><label><%#Eval("MODEL")%></label></th>
      </tr>
      <tr>
          <th class="auto-style2" scope="row">หมายเลขลำดับประจำสินค้า</th>
          <th ><label><%#Eval("SERIALNUM")%></label></th>
      </tr>
      <tr>
          <th class="auto-style2" scope="row">สถานที่เก็บ</th>
           <th ><label><%#Eval("location_new")%></label></th>
      </tr>
      <tr>
          <th class="auto-style2" scope="row">ผู้รับผิดชอบ</th>
           <th ><label><%#Eval("caretaker")%></label></th>
      </tr>
  </tbody>
</table>
              </ItemTemplate>
      </asp:DataList>
          
      <asp:SqlDataSource ID="SqlDataitem" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [View_ASSET] WHERE ([ASSETID] = @ASSETID)">
          <SelectParameters>
              <asp:ControlParameter ControlID="txt_ID" Name="ASSETID" PropertyName="Text" Type="String" />
          </SelectParameters>
      </asp:SqlDataSource>
          


      

  </div>
  
</div>


      
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT ID, ReciveFile, ID_ITEM, NAME, VAlUE, unit, Cost, brand, modal, NUM, location, PERSON, YEAR, item_status FROM ITEM_TB WHERE (ID = @ID) ">
        <SelectParameters>
            <asp:ControlParameter ControlID="txt_ID" Name="ID" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
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
                      <%#Eval("MODEL")%>
                
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
    <div class="modal fade bd-example-modal-lg" id="md_edit" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="H2">สถานะ</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4">
                            <dx:ASPxCallbackPanel ID="loadimg" runat="server" ClientInstanceName="loadimg" Width="100%">
              <PanelCollection>
<dx:PanelContent runat="server">
     

<asp:DataList ID="DataList2" runat="server" DataKeyField="ID_ITEM" DataSourceID="SqlDataSource1" Width="100%">
          <ItemTemplate>
<div class="thumbnail">
      <a href="/w3images/lights.jpg">
        <img src="img/<%#Eval("ReciveFile") %>" alt="Lights" style="width:100%">
        <div class="caption">
          <p> <%#Eval("item_status_name")%>  </p>
               <p> <%#Eval("detail")%> </p>
        </div>
      </a>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

          </ItemTemplate>
      </asp:DataList>
    

      

      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT ITEM_TB.ID_ITEM, ITEM_TB.item_status, ITEM_TB.ReciveFile, item_statusTB.item_status_name, ITEM_TB.detail FROM ITEM_TB INNER JOIN item_statusTB ON ITEM_TB.item_status = item_statusTB.item_status WHERE (ITEM_TB.ID_ITEM = @ID_ITEM)">
          <SelectParameters>
              <asp:ControlParameter ControlID="txt_ID" Name="ID_ITEM" PropertyName="Text" Type="String" />
          </SelectParameters>
      </asp:SqlDataSource>
    


 
  



      
    
                  </dx:PanelContent>
</PanelCollection>
          </dx:ASPxCallbackPanel>


                        </div>
                        <div class="col-md-8">
                                <table class="table">
  <thead>
    <tr>
      <th scope="col" class="auto-style2">หมายเลขสินทรัพย์ถาวร</th>
      <th >    
          <dx:ASPxTextBox ID="txt1" runat="server" ClientInstanceName="txt1" Width="100%" >
                            </dx:ASPxTextBox>

      </th>
        </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row" class="auto-style2">ชื่อครุภัณฑ์</th>
    <th > <dx:ASPxTextBox ID="txt2" runat="server" ClientInstanceName="txt2" Width="100%">
                            </dx:ASPxTextBox></th>
    
     
    </tr>
     
    <tr>
      <th scope="row" class="auto-style2">ตรวจสอบ</th>
       <th >
             <dx:ASPxRadioButtonList ID="txtck" runat="server" ClientInstanceName="txtck" RepeatDirection="Horizontal">
                                <Items>
                                    <dx:ListEditItem Text="รอตรวจสอบ" Value="--" ImageUrl="img/2.png"></dx:ListEditItem>
                                    <dx:ListEditItem Text="เสร็จสิ้น" Value="//" ImageUrl="img/1.png"></dx:ListEditItem>
                                </Items>
                            </dx:ASPxRadioButtonList>
       </th>
          </tr>
   
         <tr>
             <th scope="col" class="auto-style2">ผู้รับผิดชอบ</th>
             <th>
                  <dx:ASPxTextBox ID="txtcaretaker" runat="server" ClientInstanceName="txtcaretaker" Width="100%" NullText="ผู้รับผิดชอบ">
                            </dx:ASPxTextBox>
             </th>
         </tr>


      <tr>
          <th scope="col" class="auto-style2">สถานที่</th>
          <th>
                <dx:ASPxTextBox ID="txtlocation" runat="server" ClientInstanceName="txtlocation" Width="100%" NullText="สถานที่">
                            </dx:ASPxTextBox>
          </th>
      </tr>
      <tr>
          <th scope="col" class="auto-style2">รายละเอียด</th>
          <th>
                <dx:ASPxTextBox ID="txtdetail" runat="server" ClientInstanceName="txtdetail" Width="100%" NullText="รายละเอียด">
                            </dx:ASPxTextBox>
          </th>
      </tr>
            <tr>
          <th scope="col" class="auto-style2">ตรวจสอบ</th>
          <th>
              <dx:BootstrapComboBox ID="cbbstatus" runat="server" ClientInstanceName="cbbstatus">
                                <Items>
                                    <dx:BootstrapListEditItem Text="ใช้งาน" Value="1"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="เสื่อมสภาพ" Value="2"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="ชำรุด" Value="3"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="จำหน่าย" Value="4"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="หาย" Value="5"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="โอนย้าย(ระบุหน่วยงาน)" Value="6"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="รอดำเนินการ" Value="7"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="ตรวจสอบ" Value="8"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="ยกเลิก" Value="9"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="ตรวจไม่พบ" Value="10"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="หมดความจำเป็น" Value="11"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="ออกจากระบบ" Value="12"></dx:BootstrapListEditItem>
                                </Items>
                            </dx:BootstrapComboBox>
          </th>
      </tr>
           

  </tbody>
</table>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:MAINDB %>" SelectCommand="SELECT * FROM [item_statusTB]"></asp:SqlDataSource>
                        </div>
                    </div>

                
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button4" runat="server" Text="บันทึก" CssClass="btn btn-primary" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close  </button>
                </div>
            </div>
        </div>
    </div>


    <dx:ASPxCallbackPanel ID="cbck" runat="server" Width="200px" ClientInstanceName="cbck"  ClientVisible="False" ></dx:ASPxCallbackPanel>


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


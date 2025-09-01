<%@ Page Language="VB" AutoEventWireup="false" CodeFile="item_table.aspx.vb" Inherits="Main_REF_item_table" %>

  <%
      Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)

      Dim txt_search = Request.QueryString("txt_search")
      Dim builder As New StringBuilder
      builder.Append(" SELECT  TOP (" + "100" + ") *   FROM dbo.View_ASSET where 1 = 1  ")

      builder.Append("AND (ASSETID LIKE N'%" + txt_search + "%' OR NAME LIKE N'%" + txt_search + "%' OR MAINTENANCEINFO1 LIKE N'%" + txt_search + "%' OR MODEL LIKE N'%" + txt_search + "%'  OR SERIALNUM LIKE N'%" + txt_search + "%'  OR location LIKE N'%" + txt_search + "%' OR caretaker LIKE N'%" + txt_search + "%')")

      Dim dtb = db.GetDataTable(builder.ToString)

    %>
    <table class="table table-bordered" style="margin-top: 50px" id="myTable_RNF">
        <thead>
            <tr style=" background-color: #7f64ff78;">
                <th style="width: 2%;">เลือก</th>
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
                      <button class='btn ' onclick='txt_ID.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("ASSETID"))%>&#039;);txtlocation.SetValue(&#039;<% Response.Write(dtb.Rows(i).Item("location_new"))%>&#039;);$(&#039;#md_edit&#039;).modal(&#039;show&#039;);' type="button">
                    <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                    </button>
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


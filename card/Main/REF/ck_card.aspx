<%@ Page Title="" Language="VB" MasterPageFile="~/Main/DefaultPage/MasterPageAUTH.master" AutoEventWireup="false" CodeFile="ck_card.aspx.vb" Inherits="Main_REF_ck_card" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBanner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
     
  <table class="table table-striped">
  <thead>
    <tr>
       <th scope="col">ลำดับ</th>
          <th scope="col">คณะกรรมการฝ่าย</th>
          <th scope="col">สีชมพู</th>
          <th scope="col">สีแดง</th>
        <th scope="col">สีเหลือง</th>
          <th scope="col">รวม</th>
          <th scope="col">จอดรถP1</th>
          <th scope="col">จอดรถP2</th>
          <th scope="col">บัตรผ่านทาง</th>
    </tr>
  </thead>
  <tbody>

      <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
<ItemTemplate>

    <tr>
        <th scope="row"><%# Eval("Card_edit_ID") %></th>
        <td><%# Eval("Card_edit_name") %></td>
        <td><%# getpink(Eval("Card_edit_ID")) %></td>
        <td><%# getred(Eval("Card_edit_ID")) %></td>
        <td><%# getyellow(Eval("Card_edit_ID")) %></td>
        <td><%# getcount(Eval("Card_edit_ID")) %></td>
        <td><%# getparkred(Eval("Card_edit_ID")) %></td>
        <td><%# getparkgreen(Eval("Card_edit_ID")) %></td>
        <td><%# getparkw(Eval("Card_edit_ID")) %></td>
    </tr>

            </ItemTemplate>
      </asp:Repeater>
      

            <%  Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False) %>
            <% Dim ck1 = db.GetValue("SELECT        COUNT(*) AS Expr1 FROM     dbo.Card_TB WHERE        (Card_year = 2567) AND (Card_TYPE = 1)") %>
            <% Dim ck2 = db.GetValue("SELECT        COUNT(*) AS Expr1 FROM     dbo.Card_TB WHERE        (Card_year = 2567) AND (Card_TYPE = 2)") %>
            <% Dim ck3 = db.GetValue("SELECT        COUNT(*) AS Expr1 FROM     dbo.Card_TB WHERE        (Card_year = 2567) AND (Card_TYPE = 3)") %>
            <% Dim ck4 = db.GetValue("SELECT        COUNT(*) AS Expr1 FROM     dbo.Card_TB WHERE        (Card_year = 2567) ") %>
            <% Dim ck5 = db.GetValue("SELECT        ISNULL(SUM(quantity), 0) AS sum FROM            dbo.Parking_TB GROUP BY parking_name HAVING (parking_name = N'1')") %>
            <% Dim ck6 = db.GetValue("SELECT        ISNULL(SUM(quantity), 0) AS sum FROM            dbo.Parking_TB GROUP BY parking_name HAVING (parking_name = N'2')") %>
            <% Dim ck7 = db.GetValue("SELECT        ISNULL(SUM(quantity), 0) AS sum FROM            dbo.Parking_TB GROUP BY parking_name HAVING (parking_name = N'3')") %>
        <tr class="table-primary" style="background-color: #C0C0C0">
        <th class="text-center" colspan="2" > รวม</th>
        <td><div style="background-color:  #FF33FF;width: 100%;text-align: center; font-weight: bold;"> <% Response.Write(ck1) %>  </div></td>
        <td><div style="background-color:  #FF0000;width: 100%;text-align: center; font-weight: bold;"> <% Response.Write(ck2) %>  </div></td>
        <td><div style="background-color:  #FFFF00;width: 100%;text-align: center; font-weight: bold;"> <% Response.Write(ck3) %>  </div></td>
        <td><div style="width: 100%;text-align: center; font-weight: bold;"> <% Response.Write(ck4) %>  </div></td>
        <td><div style="background-color:  #fe4647;width: 100%;text-align: center; font-weight: bold;"> <% Response.Write(ck5) %>  </div></td>
        <td><div style="background-color:  #2fc77a;width: 100%;text-align: center; font-weight: bold;"> <% Response.Write(ck6) %>  </div></td>
        <td><div style="background-color:  #c8c8c8;width: 100%;text-align: center; font-weight: bold;"> <% Response.Write(ck7) %>  </div></td>
    </tr>
           <% db.Close() %>
   
  </tbody>
</table>





          

        
    
  
     
 

   


<a style="width: 100%; background-color: #CCCCFF; text-align: center;"></a>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:MAINDB %>' SelectCommand="SELECT [Card_edit_ID], [Card_edit_name] FROM [Card_edit_TB]"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" Runat="Server">
</asp:Content>


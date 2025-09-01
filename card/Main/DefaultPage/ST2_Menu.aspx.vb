Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web
Imports System.Windows.Forms
Partial Class Main_ST2_Menu
    Inherits System.Web.UI.Page

    Protected Sub ASPxButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxButton2.Click
        UpPage()
    End Sub
    Protected Sub ASPxButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxButton3.Click
        DownPage()
    End Sub

    Protected Sub ASPxTreeList1_CustomCallback(sender As Object, e As DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs) Handles ASPxTreeList1.CustomCallback
        If e.Argument = "D" Then
            DownPage()
        ElseIf e.Argument = "U" Then
            UpPage()
        End If
    End Sub
    Sub UpPage()
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)
        Dim a = ASPxTreeList1.FocusedNode.Key
        db.Execute("update MY_MENU set ParentField=0 where ParentField is null")
        Dim index = db.GetValue("select ParentField from MY_MENU where Menu_PK=" & a)
        Dim dtb = db.GetDataTable("select Menu_PK from MY_MENU where ParentField=(select ParentField from MY_MENU where Menu_PK=" & a & ") order by MenuIndex,Menu_PK")
        Dim myIndex = 0
        For i As Integer = 0 To dtb.Rows.Count - 1
            If dtb.Rows(i).Item("Menu_PK") = a Then
                myIndex = i
                If i = 0 Then
                    GoTo NonSort
                End If
            End If
            db.Execute("update MY_MENU set MenuIndex=" & i & " where Menu_PK=" & dtb.Rows(i).Item("Menu_PK"))
        Next
        Dim b = db.Execute("update MY_MENU set MenuIndex=MenuIndex+1 where MenuIndex=" & myIndex - 1 & " and ParentField=(select ParentField from MY_MENU where Menu_PK=" & a & ")")
        Dim err = db.GetException
        Dim c = db.Execute("update MY_MENU set MenuIndex=" & myIndex & "-1 where Menu_PK=" & a)
        ASPxTreeList1.DataBind()
NonSort:
        'db.Execute("update MY_MENU set ParentField=null where ParentField=0")
        db.Close()
    End Sub
    Sub DownPage()
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)
        Dim a = ASPxTreeList1.FocusedNode.Key
        db.Execute("update MY_MENU set ParentField=0 where ParentField is null")
        Dim index = db.GetValue("select ParentField from MY_MENU where Menu_PK=" & a)
        Dim dtb = db.GetDataTable("select Menu_PK from MY_MENU where ParentField=(select ParentField from MY_MENU where Menu_PK=" & a & ") order by MenuIndex,Menu_PK")
        Dim myIndex = 0
        Dim err = db.GetException
        For i As Integer = 0 To dtb.Rows.Count - 1
            If dtb.Rows(i).Item("Menu_PK") = a Then
                myIndex = i
                If i = dtb.Rows.Count - 1 Then
                    GoTo NonSort
                End If
            End If
            db.Execute("update MY_MENU set MenuIndex=" & i & " where Menu_PK=" & dtb.Rows(i).Item("Menu_PK"))
        Next
        Dim b = db.Execute("update MY_MENU set MenuIndex=MenuIndex-1 where MenuIndex=" & myIndex + 1 & " and ParentField=(select ParentField from MY_MENU where Menu_PK=" & a & ")")

        Dim c = db.Execute("update MY_MENU set MenuIndex=" & myIndex & "+1 where Menu_PK=" & a)
        ASPxTreeList1.DataBind()
NonSort:
        'db.Execute("update MY_MENU set ParentField=null where ParentField=0")
        db.Close()
    End Sub
  

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("security") <> "A" Then Response.Redirect("../DefaultPage/AccessDenied.aspx")
    End Sub
End Class

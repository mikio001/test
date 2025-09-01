Imports System.Data

Partial Class Main_DefaultPage_ListMenu
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)
        db.Execute("update MY_MENU set ParentField=0 where ParentField is null")
        Dim sql = ""
        Dim security = Session("security")
        If security Is Nothing Then security = ""
        Dim dtbAll As DataTable
        Dim str = ""
        If Request.QueryString("m") Is Nothing Then
            sql = "SELECT Menu_PK, MenuURL, MenuName, ParentField, menuIndex, PreviewField,HideLogin  FROM MY_LISTMENU WHERE ParentField=0 and ((CHARINDEX(@Permission, AllowShow, 0) > 0)  or (@Permission = 'A')  or (AllowShow = '')  or (AllowShow IS NULL)) order by ParentField,menuIndex"
            dtbAll = db.GetDataTable(sql, db.NewParam("Permission", security))
        Else
            sql = "SELECT Menu_PK, MenuURL, MenuName, ParentField, menuIndex, PreviewField,HideLogin  FROM MY_LISTMENU WHERE ParentField=@ParentField and ((CHARINDEX(@Permission, AllowShow, 0) > 0)  or (@Permission = 'A')  or (AllowShow = '')  or (AllowShow IS NULL)) order by ParentField,menuIndex"
            dtbAll = db.GetDataTable(sql, db.NewParam("Permission", security), db.NewParam("ParentField", Request.QueryString("m")))
        End If
        For Each dr In dtbAll.Rows
            str &= "<div class='col-lg-3'>"
            str &= " <div class='thumbnail' style='background-color:#463265 !important;border:0px;box-shadow: inset 0 3px 5px rgba(0,0,0,.075), 0 1px 0 rgba(255,255,255,.1);'>"
            str &= " <div class='caption' style='color:#cdbfe3'>"

            If dr("MenuURL").ToString = "" Then
                str &= "  <div  style='float:left; margin-right:10px;'><span style='font-size:30px;color: rgb(192, 167, 67);' class='glyphicon glyphicon-folder-open'></span></div>  "
                str &= "   <span><a href='Default.aspx?m=" & dr("Menu_PK") & " ' >" & dr("MenuName") & "</a> </span>"
            Else
                str &= "  <div  style='float:left; margin-right:10px;'><span style='font-size:30px;color:#FFF' class='glyphicon glyphicon-file'></span></div>  "
                str &= "   <span><a href='" & dr("MenuURL") & " ' >" & dr("MenuName") & "</a> </span>"
            End If

            str &= "</div>"
            str &= "  </div>"
            str &= "</div>"
        Next


        Label1.Text = str
    End Sub
End Class

Imports Microsoft.VisualBasic
Imports System.Data

Public Class MenuGenerater
    Function BuildMenu(ByVal menu As DevExpress.Web.ASPxMenu, ByVal security As String)
        ' Get DataView
        'Dim sqldata As New SqlDataSource
        '  Dim a As New Zulu.Cms.ReaderControl
        If security Is Nothing Then security = ""
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)
        db.Execute("update MY_MENU set ParentField=0 where ParentField is null")

        Dim sql = ""
        'If security = "" Then
        '    sql = "SELECT Menu_PK, MenuURL, MenuName, ParentField, menuIndex, PreviewField,HideLogin  FROM MY_MENU WHERE ((CHARINDEX(@Permission, AllowShow, 0) > 0)  or (@Permission = 'A')  or (AllowShow = '')  or (AllowShow IS NULL)) order by ParentField,menuIndex"
        'Else
        '    sql = "SELECT Menu_PK, MenuURL, MenuName, ParentField, menuIndex, PreviewField,HideLogin  FROM MY_MENU WHERE ((CHARINDEX(@Permission, AllowShow, 0) > 0)  or (@Permission = 'A')  or (AllowShow = '')  or (AllowShow IS NULL)) order by ParentField,menuIndex"
        'End If
        If security = "" Then
            sql = "SELECT Menu_PK, MenuURL, MenuName, ParentField, menuIndex, PreviewField,HideLogin  FROM MY_MENU WHERE (HideLogin=1) and ((CHARINDEX(@Permission, AllowShow, 0) > 0)  or (@Permission = 'A')  or (AllowShow = '')  or (AllowShow IS NULL)) order by ParentField,menuIndex"
        Else
            sql = "SELECT Menu_PK, MenuURL, MenuName, ParentField, menuIndex, PreviewField,HideLogin  FROM MY_MENU WHERE (HideLogin<>1 or HideLogin is null) and ((CHARINDEX(@Permission, AllowShow, 0) > 0)  or (@Permission = 'A')  or (AllowShow = '')  or (AllowShow IS NULL)) order by ParentField,menuIndex"
        End If

        Dim arg As DataSourceSelectArguments = New DataSourceSelectArguments()
        Dim dataView As DataTable = db.GetDataTable(sql, db.NewParam("Permission", security)) 'TryCast(sqldata.Select(arg), DataView)
        ' dataView.Sort = "ParentField"

        ' Build Menu Items
        Dim menuItems As Dictionary(Of String, DevExpress.Web.MenuItem) = New Dictionary(Of String, DevExpress.Web.MenuItem)()

        For i As Integer = 0 To dataView.Rows.Count - 1

            Dim row As DataRow = dataView.Rows(i)
            Dim item As DevExpress.Web.MenuItem = CreateMenuItem(row)

            Dim itemID As String = row("Menu_PK").ToString()
            Dim parentID As String = row("ParentField").ToString()

            If menuItems.ContainsKey(parentID) Then
                menuItems(parentID).Items.Add(item)
            Else
                If parentID = 0 Then ' It's Root Item
                    menu.Items.Add(item)
                End If
            End If
            menuItems.Add(itemID, item)

nxt:

        Next i
        Return menu
    End Function

    Private Function CreateMenuItem(ByVal row As DataRow) As DevExpress.Web.MenuItem
        Dim ret As DevExpress.Web.MenuItem = New DevExpress.Web.MenuItem()
        ret.Text = row("MenuName").ToString()
        ret.NavigateUrl = row("MenuURL").ToString()
        Return ret
    End Function

    Function BuildMenuUL(ByVal security As String, ParentField As Integer) As String
        Dim ULMenu = ""
        ' Get DataView
        'Dim sqldata As New SqlDataSource
        '  Dim a As New Zulu.Cms.ReaderControl
        If security Is Nothing Then security = ""
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)
        db.Execute("update MY_MENU set ParentField=0 where ParentField is null")

        Dim sql = ""
        'If security = "" Then
        '    sql = "SELECT Menu_PK, MenuURL, MenuName, ParentField, menuIndex, PreviewField,HideLogin  FROM MY_MENU WHERE ((CHARINDEX(@Permission, AllowShow, 0) > 0)  or (@Permission = 'A')  or (AllowShow = '')  or (AllowShow IS NULL)) order by ParentField,menuIndex"
        'Else
        '    sql = "SELECT Menu_PK, MenuURL, MenuName, ParentField, menuIndex, PreviewField,HideLogin  FROM MY_MENU WHERE ((CHARINDEX(@Permission, AllowShow, 0) > 0)  or (@Permission = 'A')  or (AllowShow = '')  or (AllowShow IS NULL)) order by ParentField,menuIndex"
        'End If
        If security = "" Then
            sql = "SELECT Menu_PK, MenuURL, MenuName, ParentField, menuIndex, PreviewField,HideLogin  FROM MY_MENU WHERE ParentField=0 and (HideLogin=1) and ((CHARINDEX(@Permission, AllowShow, 0) > 0)  or (@Permission = 'A')  or (AllowShow = '')  or (AllowShow IS NULL)) order by ParentField,menuIndex"
        Else
            sql = "SELECT Menu_PK, MenuURL, MenuName, ParentField, menuIndex, PreviewField,HideLogin  FROM MY_MENU WHERE ParentField=0 and (HideLogin<>1 or HideLogin is null) and ((CHARINDEX(@Permission, AllowShow, 0) > 0)  or (@Permission = 'A')  or (AllowShow = '')  or (AllowShow IS NULL)) order by ParentField,menuIndex"
        End If

        Dim dtbAll = db.GetDataTable(sql, db.NewParam("Permission", security))

        Dim arg As DataSourceSelectArguments = New DataSourceSelectArguments()
        Dim dataView As DataTable = db.GetDataTable(sql, db.NewParam("Permission", security)) 'TryCast(sqldata.Select(arg), DataView)
        ' dataView.Sort = "ParentField"

        ' Build Menu Items
        Dim menuItems As Dictionary(Of String, DevExpress.Web.MenuItem) = New Dictionary(Of String, DevExpress.Web.MenuItem)()
        ULMenu &= "<ul class='nav'>"
        For i As Integer = 0 To dataView.Rows.Count - 1
            Dim row As DataRow = dataView.Rows(i)

            Dim dr = dtbAll.Select("ParentField=" & row("Menu_PK"))
            If dr.Length = 0 Then
                ULMenu &= "<li><a href=''>" & row("MenuName") & "</a></li>"
            Else
                ULMenu &= "<li class='dropdown open'><a href='#' class='dropdown-toggle' data-toggle='dropdown'>Dropdown <b class='caret'></b></a>"
            End If
            '<li class="dropdown open">
            '               <a href="#" class="dropdown-toggle" data-toggle="dropdown">Dropdown <b class="caret"></b></a>
            '               <ul class="dropdown-menu">
            '                 <li><a href="#">Action</a></li>
            '                 <li><a href="#">Another action</a></li>
            '                 <li><a href="#">Something else here</a></li>
            '                 <li class="divider"></li>
            '                 <li class="nav-header">Nav header</li>
            '                 <li><a href="#">Separated link</a></li>
            '                 <li><a href="#">One more separated link</a></li>
            '               </ul>
            '             </li>

            'Dim item As DevExpress.Web.MenuItem = CreateMenuItem(row)

            'Dim itemID As String = row("Menu_PK").ToString()
            'Dim parentID As String = row("ParentField").ToString()

            'If menuItems.ContainsKey(parentID) Then
            '    menuItems(parentID).Items.Add(item)
            'Else
            '    If parentID = 0 Then ' It's Root Item
            '        Menu.Items.Add(item)
            '    End If
            'End If
            'menuItems.Add(itemID, item)

nxt:

        Next i
        ULMenu &= "</ul>"
        Return ULMenu
    End Function

    'Private Function CreateMenuItem(ByVal row As DataRow) As DevExpress.Web.MenuItem
    '    Dim ret As DevExpress.Web.MenuItem = New DevExpress.Web.MenuItem()
    '    ret.Text = row("MenuName").ToString()
    '    ret.NavigateUrl = row("MenuURL").ToString()
    '    Return ret
    'End Function
End Class

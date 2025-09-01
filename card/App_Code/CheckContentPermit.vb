Imports Microsoft.VisualBasic
Imports Zulu.Web

Public Class CheckContentPermit
    Public Function CheckAddPermission(ByVal ContentID As String, Optional ByVal SSiteID As String = "") As Boolean
        If CheckAdminPermission(SSiteID) Then
            Return True
            Exit Function
        End If
        If SSiteID = "" Then SSiteID = Zulu.Cms.Factory.SiteID
        Dim rtn As Boolean = False
        If ContentID = "" Then Return True
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)
        Dim dr = db.GetReader("select ContentID,canAdd from ZCMS_SITE_ACL where canAdd=1 and SiteID=@SiteID and username=@Username", db.NewParam("SiteID", SSiteID), db.NewParam("Username", Zulu.Security.Factory.UserProvider.GetCurrentUsername))
        db.ThrowIfError()
        If dr.Read Then
            Dim CID = dr.GetString(0)
            If CID = "*" Then
                rtn = True
            Else
                Dim CIDStr = Split(CID, ",")
                If CIDStr.Length = 1 Then
                    If ContentID = CIDStr(0) Then rtn = True
                Else
                    For i As Integer = 0 To CIDStr.Length - 1
                        If ContentID = CIDStr(i) Then
                            rtn = True
                            Exit For
                        End If

                    Next
                End If
            End If
        End If
        dr.Close()
        db.Close()
        Return rtn
    End Function

    Public Function CheckEditPermission(ByVal ContentID As String, Optional ByVal SSiteID As String = "") As Boolean
        If CheckAdminPermission(SSiteID) Then
            Return True
            Exit Function
        End If
        If SSiteID = "" Then SSiteID = Zulu.Cms.Factory.SiteID
        Dim rtn As Boolean = False
        If ContentID = "" Then Return True
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)
        Dim dr = db.GetReader("select ContentID,canAdd from ZCMS_SITE_ACL where canEdit=1 and SiteID=@SiteID and username=@Username", db.NewParam("SiteID", SSiteID), db.NewParam("Username", Zulu.Security.Factory.UserProvider.GetCurrentUsername))
        db.ThrowIfError()
        If dr.Read Then
            Dim CID = dr.GetString(0)
            If CID = "*" Then
                rtn = True
            Else
                Dim CIDStr = Split(CID, ",")
                If CIDStr.Length = 1 Then
                    If ContentID = CIDStr(0) Then rtn = True
                Else
                    For i As Integer = 0 To CIDStr.Length - 1
                        If ContentID = CIDStr(i) Then
                            rtn = True
                            Exit For
                        End If

                    Next
                End If
            End If
        End If
        dr.Close()
        db.Close()
        Return rtn
    End Function

 
    Public Function CheckDeletePermission(ByVal ContentID As String, Optional ByVal SSiteID As String = "") As Boolean
        If CheckAdminPermission(SSiteID) Then
            Return True
            Exit Function
        End If
        If SSiteID = "" Then SSiteID = Zulu.Cms.Factory.SiteID
        Dim rtn As Boolean = False
        'If ContentID = "" Then Return True
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)
        Dim dr = db.GetReader("select ContentID,canDel from ZCMS_SITE_ACL where canDel=1 and SiteID=@SiteID and username=@Username", db.NewParam("SiteID", SSiteID), db.NewParam("Username", Zulu.Security.Factory.UserProvider.GetCurrentUsername))
        db.ThrowIfError()
        If dr.Read Then
            Dim CID = dr.GetString(0)
            If CID = "*" Then
                rtn = True
            Else
                Dim CIDStr = Split(CID, ",")
                If CIDStr.Length = 1 Then
                    If ContentID = CIDStr(0) Then rtn = True
                Else
                    For i As Integer = 0 To CIDStr.Length - 1
                        If ContentID = CIDStr(i) Then
                            rtn = True
                            Exit For
                        End If

                    Next
                End If
            End If
        End If
        dr.Close()
        db.Close()
        Return rtn
    End Function
    Public Function CheckAdminPermission(Optional ByVal SSiteID As String = "") As Boolean
        If SSiteID = "" Then SSiteID = Zulu.Cms.Factory.SiteID
        Dim rtn As Boolean = False
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim dr = db.GetReader("select ContentID,canAdmin from ZCMS_SITE_ACL where canAdmin=1 and SiteID=@SiteID and username=@Username", db.NewParam("SiteID", SSiteID), db.NewParam("Username", Zulu.Security.Factory.UserProvider.GetCurrentUsername))
        db.ThrowIfError()
        If dr.Read Then
            rtn = True
        End If
        dr.Close()
        db.Close()
        Return rtn
    End Function
    Public Function CheckPropPermission(Optional ByVal SSiteID As String = "") As Boolean
        If CheckAdminPermission(SSiteID) Then
            Return True
            Exit Function
        End If
        If SSiteID = "" Then SSiteID = Zulu.Cms.Factory.SiteID
        Dim rtn As Boolean = False
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim dr = db.GetReader("select ContentID,canProp from ZCMS_SITE_ACL where canProp=1 and SiteID=@SiteID and username=@Username", db.NewParam("SiteID", SSiteID), db.NewParam("Username", Zulu.Security.Factory.UserProvider.GetCurrentUsername))
        db.ThrowIfError()
        If dr.Read Then
            rtn = True
        End If
        dr.Close()
        db.Close()
        Return rtn
    End Function
    Public Function CheckSitePermission(Optional ByVal SSiteID As String = "") As Boolean
        If CheckAdminPermission(SSiteID) Then
            Return True
            Exit Function
        End If
        If SSiteID = "" Then SSiteID = Zulu.Cms.Factory.SiteID
        Dim rtn As Boolean = False
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim dr = db.GetReader("select ContentID from ZCMS_SITE_ACL where SiteID=@SiteID and username=@Username", db.NewParam("SiteID", SSiteID), db.NewParam("Username", Zulu.Security.Factory.UserProvider.GetCurrentUsername))
        db.ThrowIfError()
        If dr.Read Then
            rtn = True
        End If
        dr.Close()
        db.Close()
        Return rtn
    End Function
    


End Class

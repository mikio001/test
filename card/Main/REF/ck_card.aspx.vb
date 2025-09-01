
Partial Class Main_REF_ck_card
    Inherits System.Web.UI.Page
    Function getcount(Card_edit_ID)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""
        Dim ck = db.GetValue("SELECT COUNT(*) AS Expr1 FROM dbo.Card_TB WHERE (Card_edit_ID = @Card_edit_ID) and Card_year = 2567", db.NewParam("Card_edit_ID", Card_edit_ID))

        ret = ck


        db.Close()
        Return ret
    End Function
    Function getpink(Card_edit_ID)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""
        Dim ck As String
        ck = db.GetValue("SELECT COUNT(*) AS Expr1 FROM dbo.Card_TB WHERE (Card_edit_ID = @Card_edit_ID) and Card_year = 2567 and Card_TYPE = 1", db.NewParam("Card_edit_ID", Card_edit_ID))
        If ck = 0 Then
            ret = "<div style='background-color:  #FFFFFF;width: 100%;text-align: center;'>" + ck + " </div>"

        Else
            ret = "<div style='background-color:  #FF33FF;width: 100%;text-align: center;'>" + ck + " </div>"
        End If


        db.Close()
        Return ret
    End Function
    Function getred(Card_edit_ID)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""
        Dim ck As String
        ck = db.GetValue("SELECT COUNT(*) AS Expr1 FROM dbo.Card_TB WHERE (Card_edit_ID = @Card_edit_ID) and Card_year = 2567 and Card_TYPE = 2", db.NewParam("Card_edit_ID", Card_edit_ID))

        If ck = 0 Then
            ret = "<div style='background-color:  #FFFFFF;width: 100%;text-align: center;'>" + ck + " </div>"

        Else
            ret = "<div style='background-color:  #FF0000;width: 100%;text-align: center;'>" + ck + " </div>"
        End If



        db.Close()
        Return ret
    End Function
    Function getyellow(Card_edit_ID)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""
        Dim ck As String
        ck = db.GetValue("SELECT COUNT(*) AS Expr1 FROM dbo.Card_TB WHERE (Card_edit_ID = @Card_edit_ID) and Card_year = 2567 and Card_TYPE = 3", db.NewParam("Card_edit_ID", Card_edit_ID))

        If ck = 0 Then
            ret = "<div style='background-color:  #FFFFFF;width: 100%;text-align: center;'>" + ck + " </div>"

        Else
            ret = "<div style='background-color:  #FFFF00;width: 100%;text-align: center;'>" + ck + " </div>"
        End If

        db.Close()
        Return ret
    End Function
    Function getparkred(Card_edit_ID)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""
        Dim ck As String
        ck = db.GetValue("SELECT        ISNULL(quantity, 0) AS Expr1 FROM            dbo.Parking_TB WHERE        (Card_edit_ID = @Card_edit_ID) AND (parking_name = N'1')", db.NewParam("Card_edit_ID", Card_edit_ID))

        If ck = 0 Then
            ret = "<div style='background-color:  #FFFFFF;width: 100%;text-align: center;'>" + ck + " </div>"

        Else
            ret = "<div style='background-color:  #fe4647;width: 100%;text-align: center;'>" + ck + " </div>"
        End If

        db.Close()
        Return ret
    End Function
    Function getparkgreen(Card_edit_ID)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""
        Dim ck As String
        ck = db.GetValue("SELECT        ISNULL(quantity, 0) AS Expr1 FROM            dbo.Parking_TB WHERE        (Card_edit_ID = @Card_edit_ID) AND (parking_name = N'2')", db.NewParam("Card_edit_ID", Card_edit_ID))

        If ck = 0 Then
            ret = "<div style='width: 100%;text-align: center;'>" + ck + " </div>"

        Else
            ret = "<div style='background-color:  #2fc77a;width: 100%;text-align: center;'>" + ck + " </div>"
        End If

        db.Close()
        Return ret
    End Function
    Function getparkw(Card_edit_ID)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""
        Dim ck As String
        ck = db.GetValue("SELECT        ISNULL(quantity, 0) AS Expr1 FROM            dbo.Parking_TB WHERE        (Card_edit_ID = @Card_edit_ID) AND (parking_name = N'3')", db.NewParam("Card_edit_ID", Card_edit_ID))

        If ck = 0 Then
            ret = "<div style='width: 100%;text-align: center;'>" + ck + " </div>"

        Else
            ret = "<div style='background-color:  #c8c8c8;width: 100%;text-align: center;'>" + ck + " </div>"
        End If

        db.Close()
        Return ret
    End Function


    Function getpinksum(Card_edit_ID)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""
        Dim ck As String
        ck = db.GetValue("SELECT        COUNT(*) AS Expr1 FROM     dbo.Card_TB WHERE        (Card_year = 2567) AND (Card_TYPE = 1)")
        If ck = 0 Then
            ret = "<div style='background-color:  #FFFFFF;width: 100%;text-align: center;'>" + ck + " </div>"

        Else
            ret = "<div style='background-color:  #FF33FF;width: 100%;text-align: center;'>" + ck + " </div>"
        End If


        db.Close()
        Return ret
    End Function
End Class

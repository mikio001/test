
Partial Class Main_DefaultPage_LoginForm
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
       
        If Not Page.IsCallback Then
            Dim newCookie As HttpCookie = Request.Cookies("Authensecurity")
            If Not IsNothing(newCookie) Then
                If Not newCookie("username") Is Nothing Then


                    Session("username") = newCookie("username")
                    Session("SessionKey") = newCookie("SessionKey")
                    Session("security") = newCookie("security")
                    Session("DescriptionName") = newCookie("DescriptionName")
                    Session("DescriptionNameT") = newCookie("DescriptionNameT")
                    Response.Cookies("Authensecurity").Expires = Now.AddDays(15)
                    Try
                        Dim u As String = Request.QueryString("u")
                        If Not IsNothing(u) Then
                            Response.Redirect(u)
                        Else
                            Response.Redirect("../defaultpage/default.aspx")
                        End If



                    Catch ex As Exception
                      
                    End Try
                End If


            End If
        End If
        If Not Session("username") Is Nothing Then
            ASPxCallbackPanel1.Visible = False
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxButton1.Click
        login()
    End Sub
  
    Sub login()
        Dim auth As New AuthenService.AuthenService
        'Dim cr As New System.Net.NetworkCredential(ASPxTextBox1.Text, ASPxTextBox2.Text, "up")
        'Dim pr As New System.Net.WebProxy("proxy.up.ac.th", 8080)
        'pr.Credentials = cr
        'auth.Proxy = pr
        Dim enc As New EncodeBase64
        Session("EditMode") = False
        Dim errorMSG = ""
        Try

            Dim errorT = ""

            errorMSG = ("1")
            Dim AuthenResult = auth.Login(enc.encode(ASPxTextBox1.Text), enc.encode(ASPxTextBox2.Text), "WEB", "WEB", "DOC", "", "")
            Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)

            If (AuthenResult = "") Then
                ASPxLabel1.Text = "Username หรือ Password ไม่ถูกต้อง"
                Exit Sub
            ElseIf AuthenResult = "SESSION_LOCK" Then
                ASPxLabel1.Text = "คุณกรอกรหัสผิดเกิน 3 ครั้ง กรุณาลองใหม่อีกครั้งในภายหลัง"
                Exit Sub
            ElseIf AuthenResult = "ExecuteNonQuery requires an open and available Connection. The connection's current state is closed." Then
                ASPxLabel1.Text = "การเชื่อมต่อมีปัญหา กรุณาลองใหม่อีกครั้งภายหลัง"
                Exit Sub
            End If
            errorMSG = ("2")
            Dim citizenid = auth.GetRefenceID(AuthenResult)
            errorMSG = ("3")
            Dim dr = db.GetDataTable("select * from MY_PERMISSION_USER where username=@username", db.NewParam("username", ASPxTextBox1.Text))
            db.ThrowIfError()
            If db.IsError(errorT) Then
                ASPxLabel1.Text = "Error 02"
                Exit Sub
            End If


            If dr.Rows.Count <> 0 Then
                Dim dtb = db.GetDataTable("SELECT * FROM MAS_PERSON WHERE (CitizenID = @CitizenID)", db.NewParam("CitizenID", citizenid))
                If dtb.Rows.Count <> 0 Then
                    Session("username") = ASPxTextBox1.Text
                    Session("SessionKey") = AuthenResult
                    Session("security") = dr.Rows(0)("permission").ToString
                    Session("citizenID") = citizenid
                    Session("FacultyID") = dtb.Rows(0).Item("FacultyID")
                    Session("PersonID") = dtb.Rows(0).Item("PersonID")
                    Session("PersonName") = dtb.Rows(0).Item("PersonName")



                    Response.Redirect("../DefaultPage/index.aspx")

                Else
                    ASPxLabel1.Text = "คุณไม่มีสิทธ์ในการเข้าใช้ระบบ กรุณาติดต่อผู้ดูแลระบบ"
                End If
                Dim u As String = Request.QueryString("u")
                dr = Nothing
                db.Close()
                If Not String.IsNullOrEmpty(u) Then
                    Response.Redirect(ResolveClientUrl(Server.UrlDecode(u)))
                Else

                End If
            Else
                'บุคคลทั่วไป
                Dim dtb = db.GetDataTable("SELECT * FROM MAS_PERSON WHERE (CitizenID = @CitizenID)", db.NewParam("CitizenID", citizenid))
                If dtb.Rows.Count <> 0 Then
                    Session("username") = ASPxTextBox1.Text
                    Session("SessionKey") = AuthenResult
                    Session("security") = "U"
                    Session("citizenID") = citizenid
                    Session("FacultyID") = dtb.Rows(0).Item("FacultyID")
                    Session("PersonID") = dtb.Rows(0).Item("PersonID")
                    Session("PersonName") = dtb.Rows(0).Item("PersonName")

                    Response.Redirect("../DefaultPage/index.aspx")
                Else

                    ASPxLabel1.Text = "คุณไม่มีสิทธ์ในการเข้าใช้ระบบ กรุณาติดต่อผู้ดูแลระบบ"

                End If
                'ss
            End If



            
            dr = Nothing

            db.Close()
        Catch ex As Exception

            ASPxLabel1.Text = "Username หรือ Password ไม่ถูกต้อง (" & ex.Message & ")" & errorMSG

        End Try
    End Sub
End Class

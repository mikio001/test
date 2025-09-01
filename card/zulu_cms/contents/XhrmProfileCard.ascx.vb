
Partial Class zulu_cms_contents_XhrmProfileList
    Inherits Zulu.Cms.ReaderControl

    Public Property SelectCommand As String = "SELECT HMR_PERSON.PERSON_MID, REF_PREFIX.PREFIX_NAME_TH, HMR_PERSON.STF_FNAME, HMR_PERSON.STF_LNAME, REF_FAC.FAC_NAME, REF_DEPT.DEPT_NAME_TH, REF_UNIT.UNIT_NAME_TH,HRM_PERSON_XCONTACT.PICTURE_URL FROM HMR_PERSON LEFT JOIN HRM_PERSON_XCUR ON HMR_PERSON.PERSON_MID = HRM_PERSON_XCUR.PERSON_MID LEFT JOIN REF_DEPT ON HRM_PERSON_XCUR.DEPT_ID = REF_DEPT.DEPT_ID LEFT JOIN REF_FAC ON HRM_PERSON_XCUR.FAC_ID = REF_FAC.FAC_ID LEFT JOIN REF_PREFIX ON HRM_PERSON_XCUR.PREFIX_ID = REF_PREFIX.PREFIX_ID LEFT JOIN REF_UNIT ON HRM_PERSON_XCUR.UNIT_ID = REF_UNIT.UNIT_ID LEFT JOIN HRM_PERSON_XCONTACT ON HMR_PERSON.PERSON_MID=HRM_PERSON_XCONTACT.PERSON_MID"
    Public Property FilterCommand As String
    Public Property OrderCommand As String
    Public Property NumberOfColumns As Integer = 3
    Public Property CaptionFormatString As String = "{1}{2} {3}"
    Public Property ShowPicture As Boolean = True
    Public Property Width As String = "100%"
    Public Property PictureWidth As Integer = 100
    Public Property pictureHeight As Integer = 150
    Public Property Spacing As Integer = 10
    Public Property DefaultPictureUrl As String = "~/zulu_cms/resources/nopic.jpg"

    Protected Overrides Sub Render(ByVal w As System.Web.UI.HtmlTextWriter)
        Dim sql As String = SelectCommand

        If Not String.IsNullOrEmpty(FilterCommand) Then
            sql &= " WHERE " & FilterCommand
        End If

        If Not String.IsNullOrEmpty(OrderCommand) Then
            sql &= " ORDER BY " & OrderCommand
        End If

        Dim db = Zulu.Data.PlatformFactory.GetPlatform("XhrmDB", True, False)
        Dim dr = db.GetReader(sql)
        Dim errMsg As String = ""

        If db.IsError(errMsg) Then
            Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
        Else
            Dim params(dr.FieldCount - 1) As String
            Dim hasData As Boolean = True
            Dim wx = CInt(100 / NumberOfColumns)
            Dim pic As String
            Dim noPic = ResolveClientUrl(DefaultPictureUrl)

            w.Write("<table cellpadding=""0"" cellspacing=""" & Spacing & """ style=""width:" & Width & """>")

            While hasData
                w.Write("<tr>")

                For i As Integer = 0 To NumberOfColumns - 1
                    hasData = dr.Read

                    If hasData Then
                        For j As Integer = 0 To dr.FieldCount - 1
                            params(j) = dr(j).ToString
                        Next

                        w.Write("<td width=""" & wx & "%"" valign=""top"" class=""profileCard"">")

                        If ShowPicture Then
                            If Not dr.IsDBNull(dr.GetOrdinal("PICTURE_URL")) Then
                                w.Write("<div class=""profileCardPicture"">")
                                w.Write("<img src=""")
                                pic = dr("PICTURE_URL")

                                If Not String.IsNullOrEmpty(pic) Then
                                    w.Write(pic)
                                Else
                                    w.Write(noPic)
                                End If

                                w.Write("""")
                                w.Write(" width=""" & PictureWidth & """")
                                w.Write(" height=""" & pictureHeight & """")
                                w.Write("/>")
                                w.Write("</div>")
                            End If
                        End If

                        w.Write("<div class=""profileCardCaption"">")
                        w.Write(String.Format(CaptionFormatString, params))
                        w.Write("</div>")

                        w.Write("</td>")
                    Else
                        w.Write("<td width=""" & wx & "%"">")
                        w.Write("</td>")
                    End If
                Next

                w.Write("</tr>")
            End While

            w.Write("</table>")
            dr.Close()
        End If

        db.Close()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        'StartEditorToolbox1.ContentID = ContentID
    End Sub
End Class

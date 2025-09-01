
Partial Class zulu_cms_contents_CalendarView
    Inherits Zulu.Cms.ReaderControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsCallback Then
            ASPxScheduler1.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None
            ASPxScheduler1.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None
            ASPxScheduler1.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None
            ASPxScheduler1.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None
            ASPxScheduler1.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None
            ASPxScheduler1.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.None
            ASPxScheduler1.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None
            SqlDataSource1.SelectParameters("siteID").DefaultValue = SiteID
            SqlDataSource1.SelectParameters("contentID").DefaultValue = ContentID
            SqlDataSource1.DataBind()
        End If
    End Sub

    Protected Sub ASPxScheduler1_FetchAppointments(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.FetchAppointmentsEventArgs) Handles ASPxScheduler1.FetchAppointments
        '
        'SqlDataSource1.SelectParameters("startDate").DefaultValue = e.Interval.Start
        'SqlDataSource1.SelectParameters("endDate").DefaultValue = e.Interval.End
        'SqlDataSource1.DataBind()
        'ASPxScheduler1.DataBind()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = "CALSLIDE"
    End Sub
End Class

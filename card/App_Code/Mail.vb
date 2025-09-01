Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Net

Public Class Mail

    Private _email As String = "devadmin@up.ac.th"
    Private _smtp As String = "10.200.10.21"
    Private _mailto As String
    Private _message, _subject As String
    Private _attachment As Array
    Public Errortext As String
    ''' <summary>From</summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property email() As String
        Set(ByVal value As String)
            Me._email = value
        End Set
    End Property

    ''' <summary>SMPT get from config</summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property smtp() As String
        Set(ByVal value As String)
            Me._smtp = value
        End Set
    End Property

    Public WriteOnly Property mailTo() As String
        Set(ByVal value As String)
            Me._mailto = value
        End Set
    End Property

    Public Property message() As String
        Set(ByVal value As String)
            Me._message = value
        End Set
        Get
            Return _message
        End Get
    End Property


    Public WriteOnly Property subject() As String
        Set(ByVal value As String)
            Me._subject = value
        End Set
    End Property

    ''' <summary>path file</summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property attachment() As Array
        Set(ByVal value As Array)
            Me._attachment = value
        End Set
    End Property

    ''' <summary>Send Email</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Send() As Boolean
        '
        Dim vSMTP As New SmtpClient(_smtp)
        Dim vMail As New MailMessage
        Dim vFrom As New MailAddress(_email)
        'Dim ln As New Logins

        Try
            ' vSMTP.Credentials = New NetworkCredential("devadmin", "1234qwer1", "up.local")
            Dim cr As New System.Net.NetworkCredential("devadmin", "1234qwer1", "up.local")
            Dim pr As New System.Net.WebProxy("proxy.up.ac.th", 8080)
            vSMTP.Credentials = cr
            'vSMTP.Credentials = CredentialCache.DefaultNetworkCredentials
            'vSMTP.UseDefaultCredentials = True

            With vMail
                .From = vFrom
                .Subject = Me._subject
                Me.loadMailBody(vMail)
            End With
            vMail.IsBodyHtml = True
            Me.loadMailTo(vMail)
            Me.loadAttachment(vMail)

            vSMTP.Send(vMail)
            vMail.Dispose()
            vSMTP.Dispose()
        Catch ex As Exception
            Errortext = ex.Message
            'MessageBox.Show(ex.Message)
            vMail.Dispose()
            vSMTP.Dispose()
            Return False
        End Try

        'Try

        '    'vSMTP.Send("theerapongc@nu.ac.th", "ment_th@hotmail.com", "test", "test")
        '    'vSMTP.Credentials = System.Net.ICredentials


        '    vSMTP.Credentials = CredentialCache.DefaultNetworkCredentials

        '    vSMTP.Send(_email, _mailto, _subject, _message)
        '    vSMTP.Send(
        'Catch ex As Exception
        '    Return False
        'End Try

        Return True

    End Function

    Private Sub loadMailTo(ByVal _mailMessage As MailMessage)
        Dim vArray As Array = Me._mailto.Split(";")
        For IntItem As Int16 = 0 To vArray.Length - 1
            If (vArray(IntItem) <> "") Then
                _mailMessage.To.Add(vArray(IntItem))
            End If
        Next

    End Sub

    Private Sub loadMailToMultiSelect(ByVal _mailMessage As MailMessage, ByVal _address As String)
        _mailMessage.To.Add(_address)        
    End Sub

    Private Sub loadAttachment(ByVal _mailMessage As MailMessage)
        If Not IsNothing(_attachment) Then
            For Each at In Me._attachment
                If Not IsNothing(at) Then
                    Dim vAttach As New Attachment(at)
                    _mailMessage.Attachments.Add(vAttach)
                End If
            Next
        End If
    End Sub

    Private Sub loadMailBody(ByVal _mailMessage As MailMessage)

        _mailMessage.Body = Me._message

    End Sub

End Class

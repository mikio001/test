Imports Microsoft.VisualBasic
Imports System.Security.Cryptography

Public Class Encrypt
    Public Function getHashMD5(ByVal str As String, Optional ByVal count As Integer = 4) As String
        Dim ret = str
        For i As Integer = 1 To count
            ret = MD5(ret)
        Next
        Return ret
    End Function
    Public Function MD5(ByVal strString As String) As String
        Dim ASCIIenc As New ASCIIEncoding
        Dim strReturn As String = ""
        Dim ByteSourceText() As Byte = ASCIIenc.GetBytes(strString)
        Dim Md5Hash As New MD5CryptoServiceProvider
        Dim ByteHash() As Byte = Md5Hash.ComputeHash(ByteSourceText)
        For Each b As Byte In ByteHash
            strReturn = strReturn & b.ToString("x2")
        Next
        Return strReturn
    End Function
End Class

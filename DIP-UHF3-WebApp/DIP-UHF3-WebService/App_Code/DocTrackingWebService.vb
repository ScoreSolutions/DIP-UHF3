Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class DocTrackingWebService
     Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '    Return "Hello World"
    'End Function


    <WebMethod()> _
    Public Function UpdateBorrowTransfer(TransferDateTime As String, AppNo As String, OfficerIdFrom As Long, OfficerIdTo As Long) As String
        Dim ret As String = "False"
        Try

        Catch ex As Exception
            ret = "False|" & ex.Message & vbNewLine & ex.StackTrace
        End Try
        Return ret
    End Function

    <WebMethod()> _
    Public Function CreateTextFileFromSpeedway(CharData As String, SerialNo As String, FileName As String) As String
        Dim ret As String = "False"
        Try
            Dim PathName As String = "D:\SpeedwayTextFile\TempTextFile\"
            If IO.Directory.Exists(PathName) = False Then
                Try
                    IO.Directory.CreateDirectory(PathName)
                Catch ex As Exception

                End Try
            End If

            Dim FilePath As String = PathName & FileName
            Try
                Dim fs As IO.FileStream
                fs = New IO.FileStream(FilePath, FileMode.CreateNew)
                Dim b() As Byte = Convert.FromBase64String(CharData)
                fs.Write(b, 0, b.Length)
                fs.Close()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
        Return ret
    End Function

    <WebMethod()> _
    Public Function UpdateCompleteCreateTextfile() As String
        Dim ret As String = "False"
        Try

        Catch ex As Exception

        End Try
        Return ret
    End Function


    <WebMethod()> _
    Public Function CheckDocTracingTV(MsLEDTvID As Long, TagNo As String) As String
        Dim ret = "False"
        Try
            ret = Engine.DigitalSignageENG.CheckDocTracingTV(MsLEDTvID, TagNo)
        Catch ex As Exception
            ret = "False"
        End Try
        Return ret
    End Function

End Class
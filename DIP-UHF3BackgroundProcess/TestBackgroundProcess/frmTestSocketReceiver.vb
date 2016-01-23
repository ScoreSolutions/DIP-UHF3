Imports System.Net.Sockets
Imports System.Threading
Imports System.Text
Imports System.Net

Public Class frmTestSocketReceiver

    'Private port As Integer = 7878
    'Private Const broadcastAddress As String = "255.255.255.255"
    'Private receivingClient As UdpClient
    'Private sendingClient As UdpClient
    'Private myTextStream As String = "Blah blah blah"
    'Private busy As Boolean = False

    'Private Sub frmTestSocketReceiver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    InitializeSender()
    '    InitializeReceiver()
    'End Sub

    'Private Sub InitializeSender()
    '    Try
    '        sendingClient = New UdpClient(broadcastAddress, port)
    '        sendingClient.EnableBroadcast = True
    '    Catch ex As Exception
    '        MsgBox("Error, unable to setup sender client on port " & port & "." & vbNewLine & vbNewLine & ex.ToString)
    '    End Try
    'End Sub

    'Private Sub InitializeReceiver()
    '    Try
    '        receivingClient = New UdpClient(port)
    '        ThreadPool.QueueUserWorkItem(AddressOf Receiver)
    '    Catch ex As Exception
    '        MsgBox("Error, unable to setup receiver on port " & port & "." & vbNewLine & vbNewLine & ex.ToString)
    '        End
    '    End Try
    'End Sub

    'Private Sub sendStream()
    '    busy = True
    '    Dim i% = 0
    '    Do While i < 4
    '        If myTextStream <> "" Then
    '            Dim data() As Byte = Encoding.ASCII.GetBytes(myTextStream)
    '            Try
    '                sendingClient.Send(data, data.Length)
    '            Catch ex As Exception
    '                MsgBox("Error, unable to send stream." & vbNewLine & vbNewLine & ex.ToString)
    '                End
    '            End Try
    '        End If
    '        Thread.Sleep(5000)
    '        i += 1
    '    Loop
    '    busy = False
    'End Sub

    'Private Sub Receiver()
    '    Dim endPoint As IPEndPoint = New IPEndPoint(IPAddress.Any, port)
    '    While True
    '        Dim data() As Byte
    '        data = receivingClient.Receive(endPoint)
    '        Dim incomingMessage As String = Encoding.ASCII.GetString(data)
    '        If incomingMessage = "what ever the client is requesting, for example," & "GET_VALUES" Then
    '            If busy = False Then Call sendStream()
    '        End If
    '    End While
    'End Sub


End Class
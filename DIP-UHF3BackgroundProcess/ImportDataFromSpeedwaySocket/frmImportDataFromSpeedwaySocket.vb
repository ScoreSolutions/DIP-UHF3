Imports System.Net
Imports System.Net.Sockets
Imports System.Text


Public Class frmImportDataFromSpeedwaySocket
    'Private server As TcpComm.Server
    'Private lat As TcpComm.Utilities.LargeArrayTransferHelper

    'Private Sub frmImportDataFromSpeedwaySocket_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '    If server IsNot Nothing Then server.Close()
    'End Sub

    'Private Sub frmImportDataFromSpeedwaySocket_Shown(sender As Object, e As EventArgs) Handles Me.Shown
    '    server = New TcpComm.Server(AddressOf UpdateUI, , True)
    '    lat = New TcpComm.Utilities.LargeArrayTransferHelper(server)

    '    server.Start(1024)
    'End Sub

    'Public Sub UpdateUI(ByVal bytes() As Byte, ByVal sessionID As Int32, ByVal dataChannel As Byte)

    '    ' Use TcpComm.Utilities.LargeArrayTransferHelper to make it easier to send and receive 
    '    ' large arrays sent via lat.SendArray()
    '    ' The LargeArrayTransferHelperb will assemble any number of incoming large arrays
    '    ' on any channel or from any sessionId, and pass them back to this callback
    '    ' when they are complete. Returns True if it has handled this incomming packet,
    '    ' so we exit the callback when it returns true.
    '    If lat.HandleIncomingBytes(bytes, dataChannel, sessionID) Then Return

    '    If Me.InvokeRequired() Then
    '        ' InvokeRequired: We're running on the background thread. Invoke the delegate.
    '        Me.Invoke(server.ServerCallbackObject, bytes, sessionID, dataChannel)
    '    Else
    '        ' We're on the main UI thread now.
    '        If dataChannel < 251 Then
    '            'Me.lbTextInput.Items.Add("Session " & sessionID.ToString & ": " & TcpComm.Utilities.BytesToString(bytes))
    '            Dim LogData As String = TcpComm.Utilities.BytesToString(bytes)

    '        ElseIf dataChannel = 255 Then
    '            Dim tmp = ""
    '            Dim msg As String = TcpComm.Utilities.BytesToString(bytes)
    '            Dim dontReport As Boolean = False

    '            ' server has finished sending the bytes you put into sendBytes()
    '            If msg.Length > 3 Then tmp = msg.Substring(0, 3)
    '            If tmp = "UBS" Then ' User Bytes Sent.
    '                Dim parts() As String = Split(msg, "UBS:")
    '                msg = "Data sent to session: " & parts(1)
    '            End If

    '            If msg = "Connected." Then UpdateClientsList()
    '            If msg.Contains(" MachineID:") Then UpdateClientsList()
    '            If msg.Contains("Session Stopped. (") Then UpdateClientsList()

    '            'If Not dontReport Then Me.ToolStripStatusLabel1.Text = msg
    '        End If
    '    End If

    'End Sub

    'Private Sub UpdateClientsList()

    '    Dim sessionList As List(Of TcpComm.Server.SessionCommunications) = server.GetSessionCollection()
    '    Dim lvi As ListViewItem

    '    Me.lvClients.Items.Clear()

    '    For Each session As TcpComm.Server.SessionCommunications In sessionList
    '        If session.IsRunning Then
    '            lvi = New ListViewItem(" Connected", 0, lvClients.Groups.Item(0))
    '        Else
    '            lvi = New ListViewItem(" Disconnected", 1, lvClients.Groups.Item(1))
    '        End If

    '        lvi.SubItems.Add(session.sessionID.ToString())
    '        lvi.SubItems.Add(session.machineId)
    '        Me.lvClients.Items.Add(lvi)
    '    Next
    'End Sub


    Private Sub StartServerSocket()
        Dim serverSocket As New TcpListener(1024)
        Dim clientSocket As TcpClient

        serverSocket.Start()
        'msg("Server Started")
        While (True)
            clientSocket = serverSocket.AcceptTcpClient()
            'msg("Client No:" + Convert.ToString(counter) + " started!")
            Dim client As New handleClinet
            client.startClient(clientSocket)
        End While

        clientSocket.Close()
        serverSocket.Stop()
        'msg("exit")
        'Console.ReadLine()

    End Sub


    Private Sub frmImportDataFromSpeedwaySocket_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        StartServerSocket()
    End Sub
End Class

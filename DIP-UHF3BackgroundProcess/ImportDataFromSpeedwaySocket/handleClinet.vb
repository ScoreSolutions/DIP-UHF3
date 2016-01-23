Imports System.Net.Sockets
Imports System.Text

Public Class handleClinet
    Dim clientSocket As TcpClient
    Public Sub startClient(ByVal inClientSocket As TcpClient)
        Me.clientSocket = inClientSocket
        Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf doChat)
        ctThread.Start()
    End Sub
    Private Sub doChat()
        'Dim requestCount As Integer
        Dim bytesFrom(65536) As Byte
        Dim dataFromSPW As String
        Dim sendBytes As [Byte]()
        Dim ResData As String
 
        While (True)
            Try
                Dim networkStream As NetworkStream = clientSocket.GetStream()
                networkStream.Read(bytesFrom, 0, CInt(clientSocket.ReceiveBufferSize))
                dataFromSPW = System.Text.Encoding.ASCII.GetString(bytesFrom)
                'dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"))

                ResData = Engine.SpeedwayENG.InsertDataToFileMoveHistory(dataFromSPW)
                If ResData = "True" Then
                    'msg("From client-" + clNo + dataFromClient)
                    ResData = "True:" & dataFromSPW
                    sendBytes = Encoding.ASCII.GetBytes(ResData)
                    networkStream.Write(sendBytes, 0, sendBytes.Length)
                    networkStream.Flush()
                    'msg(serverResponse)
                End If

                
            Catch ex As Exception
                'MsgBox(ex.ToString)
                ResData = "False#" & ex.Message
            End Try

        End While

    End Sub


End Class

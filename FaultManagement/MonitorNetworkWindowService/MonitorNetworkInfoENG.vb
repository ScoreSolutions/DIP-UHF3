Imports Engine.Common
Imports Engine.Config
Imports LinqDB.TABLE
Imports LinqDB.ConnectDB
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports System.Net.NetworkInformation.Ping

Namespace Info
    Public Class MonitorNetworkInfoENG
       

        '--------------------------------MonitorPort
        Public Shared Sub MonitorPort()
            Try
                Dim TmpCfDT As DataTable = PortConfigENG.GetConfigPortList
                If TmpCfDT.Rows.Count > 0 Then
                    Dim cfDT As DataTable = TmpCfDT.DefaultView.ToTable(True, "PortID")
                    For Each cfDr As DataRow In cfDT.Rows
                        Dim cfLnq As New CfConfigPortLinqDB
                        cfLnq.GetDataByPK(cfDr("PortID"), Nothing)
                        If cfLnq.ID > 0 Then
                            Dim chk As Boolean = (cfLnq.ALLDAYEVENT = "Y")
                            If chk = False Then
                                Dim CurrTime As String = DateTime.Now.ToString("HH:mm")
                                If cfLnq.ALARMTIMEFROM <= CurrTime And CurrTime <= cfLnq.ALARMTIMETO Then
                                    chk = True
                                End If
                            End If

                            If chk = True Then
                                If DateAdd(DateInterval.Minute, 1, cfLnq.LASTCHECKTIME) < LinqDB.ConnectDB.SqlDB.GetDateNowFromDB(Nothing) Then
                                    TmpCfDT.DefaultView.RowFilter = "PortID='" & cfLnq.ID & "'"
                                    For Each dr As DataRowView In TmpCfDT.DefaultView
                                        Dim cfDetailLnq As New CfConfigPortDetailLinqDB
                                        cfDetailLnq.GetDataByPK(dr("PortDetailID"), Nothing)
                                        If cfDetailLnq.ID > 0 Then
                                            Dim awDT As New DataTable
                                            awDT = InfoClass.PortInfo.GetdtWAITING_CLEAR(cfLnq.MACADDRESS, cfDetailLnq.PORTNUMBER)

                                            If TelnetPort(cfLnq.HOSTIP, cfDetailLnq.PORTNUMBER) = False Then
                                                Dim iEng As New InfoClass.PortInfo
                                                iEng.ProcessPortAlarm(awDT, cfLnq, cfDetailLnq.PORTNUMBER, 1, "Mail")
                                            Else
                                                If awDT.Rows.Count > 0 Then
                                                    Dim ClearMsg As String = "Alarm PORT No " & cfDetailLnq.PORTNUMBER & " not connect  on " & cfLnq.HOSTIP & " is clear"
                                                    Dim hw As New InfoClass.HardwareInfo
                                                    hw.SendClearAlarm(cfLnq.HOSTNAME, cfLnq.HOSTIP, cfLnq.MACADDRESS, "CRITICAL", 0, "Mail", "Port" & cfDetailLnq.PORTNUMBER, ClearMsg, awDT.Rows(0)("id"))
                                                    hw = Nothing
                                                End If
                                            End If
                                            awDT.Dispose()
                                        End If
                                        cfDetailLnq = Nothing
                                    Next
                                    TmpCfDT.DefaultView.RowFilter = ""

                                    InfoClass.HardwareInfo.UpdateLastCheckTime(cfLnq.TableName, cfLnq.ID)
                                End If
                            End If
                        End If
                        cfLnq = Nothing
                    Next
                    cfDT.Dispose()
                End If
                TmpCfDT.Dispose()
            Catch ex As Exception
                FunctionEng.CreateErrorLog("MonitorNetworkInfoENG", "MonitorPort", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End Sub
        Private Shared Function TelnetPort(ByVal PIPAddress As String, ByVal PPort As String) As Boolean
            Dim ret As Boolean = False
            Dim remoteIPAddress As IPAddress
            Dim ep As IPEndPoint
            Dim tnSocket As Socket

            ' Get the IP Address and the Port and create an IPEndpoint (ep)
            Try
                remoteIPAddress = IPAddress.Parse(PIPAddress.Trim)
                ep = New IPEndPoint(remoteIPAddress, CType(PPort.Trim, Integer))
                ' Set the socket up (type etc)
                tnSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Try
                    ' Connect
                    tnSocket.Connect(ep)
                    If tnSocket.Connected = True Then
                        ret = True
                    End If
                Catch oEX As SocketException
                    ' error
                    ' You will need to do error cleanup here e.g killing the socket
                    ' and exiting the procedure.

                    FunctionEng.CreateErrorLog("MonitorNetworkInfoENG", "TelnetPort", "SocketException :" & oEX.Message & vbNewLine & oEX.StackTrace)

                    Return False
                End Try
            Catch ex As Exception
                FunctionEng.CreateErrorLog("MonitorNetworkInfoENG", "TelnetPort", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
                Return False
            End Try


            ' Cleanup
            remoteIPAddress = Nothing
            ep = Nothing
            tnSocket = Nothing

            Return ret
        End Function

        '--------------------------------MonitorPort

        Public Shared Sub PingToServer()
            Dim rLnq As New TbRegisterLinqDB
            Dim ret As Boolean = False
            Try
                Dim dt As New DataTable
                dt = rLnq.GetDataList("active_status='Y'", "serverip", Nothing)
                For Each row As DataRow In dt.Rows
                    Dim ip As String = row("ServerIP")
                    Dim ServerName As String = row("ServerName")
                    Dim MacAddress As String = row("MacAddress")
                    Try
                        If My.Computer.Network.Ping(ip, 1000) Then
                            ret = SavePingInfo(ip, ServerName, MacAddress, "Y")
                            If ret = False Then
                                For i As Integer = 0 To 5
                                    ret = SavePingInfo(ip, ServerName, MacAddress, "Y")
                                    If ret = True Then
                                        Exit For
                                    End If
                                Next
                            End If
                        Else
                            ret = SavePingInfo(ip, ServerName, MacAddress, "N")
                            If ret = False Then
                                For i As Integer = 0 To 5
                                    ret = SavePingInfo(ip, ServerName, MacAddress, "N")
                                    If ret = True Then
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Catch ex As Exception
                        FunctionEng.CreateErrorLog("frmNewMain", "PingToServer", "1. Exception :" & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            Catch ex As Exception
                FunctionEng.CreateErrorLog("frmNewMain", "PingToServer", "2. Exception :" & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            rLnq = Nothing
        End Sub

        Private Shared Function SavePingInfo(ServerIP As String, ServerName As String, MacAddress As String, ByVal Status As Char) As Boolean
            Dim ret As Boolean = False
            Try
                Dim trans As New TransactionDB
                Dim lnq As New TbPingInfoLinqDB
                lnq.ChkDataBySERVERIP(ServerIP, trans.Trans)
                If lnq.ID = 0 Then
                    lnq.ChkDataBySERVERNAME(ServerName, trans.Trans)

                    If lnq.ID = 0 Then
                        lnq.ChkDataByMACADDRESS(MacAddress, trans.Trans)
                    End If
                End If

                lnq.SERVERIP = ServerIP
                lnq.SERVERNAME = ServerName
                lnq.MACADDRESS = MacAddress
                lnq.STATUS = Status

                If lnq.ID > 0 Then
                    ret = lnq.UpdateByPK("frmNewMain.SavePingInfo", trans.Trans)
                Else
                    ret = lnq.InsertData("frmNewMain.SavePingInfo", trans.Trans)
                End If

                If ret = True Then
                    ret = CreatePingLog(ServerIP, ServerIP, MacAddress, Status, trans)
                    If ret = True Then
                        If UpdateAvailableData(ServerIP, Status, trans) = True Then
                            trans.CommitTransaction()
                        Else
                            trans.RollbackTransaction()
                        End If
                    Else
                        trans.RollbackTransaction()
                    End If
                Else
                    trans.RollbackTransaction()
                    FunctionEng.CreateErrorLog("frmNewMain", "SavePingInfo", lnq.ErrorMessage)
                End If
                lnq = Nothing
            Catch ex As Exception
                ret = False
                FunctionEng.CreateErrorLog("frmNewMain", "SavePingInfo", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Return ret
        End Function

        Private Shared Function UpdateAvailableData(ServerIP As String, Status As Char, trans As TransactionDB) As Boolean
            Dim ret As Boolean = False
            Try
                Dim lnq As New TbRegisterLinqDB
                lnq.ChkDataBySERVERIP(ServerIP, trans.Trans)
                If lnq.ID > 0 Then

                    'หา Today Available
                    Dim vData As String = DateTime.Now.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
                    Dim sql As String = "Select (sum(case p.Status when 'Y' then 1 else 0 end)*100)/count(p.id) available"
                    sql += " from TB_PING_LOG P "
                    sql += " where Convert(Varchar(8), P.CreatedDate,112)= '" & vData & "'"
                    sql += " and p.ServerIP='" & ServerIP & "'"

                    Dim TodayAvailable As Long = 0
                    Dim dt As DataTable = SqlDB.ExecuteTable(sql, trans.Trans)
                    If dt.Rows.Count > 0 Then
                        If Convert.IsDBNull(dt.Rows(0)("available")) = False Then
                            TodayAvailable = Convert.ToInt64(dt.Rows(0)("available"))
                        Else
                            TodayAvailable = 0
                        End If
                    Else
                        TodayAvailable = 0
                    End If
                    dt.Dispose()

                    Dim uSql As String = "update tb_register "
                    uSql += " set today_alailable='" & TodayAvailable & "',"
                    uSql += " online_status='" & Status & "'"
                    uSql += " where id='" & lnq.ID & "'"
                    ret = lnq.UpdateBySql(uSql, trans.Trans)
                    If ret = False Then
                        FunctionEng.CreateErrorLog("frmNewMain", "UpdateAvailableData", lnq.ErrorMessage)
                    End If
                Else
                    FunctionEng.CreateErrorLog("frmNewMain", "UpdateAvailableData", lnq.ErrorMessage)
                End If
                lnq = Nothing
            Catch ex As Exception
                ret = False
                FunctionEng.CreateErrorLog("frmNewMain", "UpdateAvailableData", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Return ret
        End Function

        Private Shared Function CreatePingLog(ByVal ip As String, ServerName As String, MacAddress As String, ByVal Status As Char, trans As TransactionDB) As Boolean
            Dim ret As Boolean = False
            Try
                'Dim trans As New TransactionDB
                Dim lnq As New TbPingLogLinqDB

                lnq.SERVERIP = ip
                lnq.SERVERNAME = ServerName
                lnq.MACADDRESS = MacAddress
                lnq.STATUS = Status
                ret = lnq.InsertData("frmNewMain.CreatePing", trans.Trans)
                If ret = False Then
                    FunctionEng.CreateErrorLog("frmNewMain", "CreatePingLog", lnq.ErrorMessage)
                End If
                lnq = Nothing
            Catch ex As Exception
                ret = False
                FunctionEng.CreateErrorLog("frmNewMain", "CreatePingLog", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Return ret
        End Function
    End Class
End Namespace


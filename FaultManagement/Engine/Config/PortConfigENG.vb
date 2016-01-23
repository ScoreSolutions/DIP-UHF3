'Imports Engine.ConnectDB
Imports LinqDB.ConnectDB
Namespace Config
    Public Class PortConfigENG
        Inherits ConfigENG
        Dim _HostIP As String = ""
        Dim _HostName As String = ""
        Dim _Port As Long = 0

        Public Property HostIP() As String
            Get
                Return _HostIP.Trim
            End Get
            Set(ByVal value As String)
                _HostIP = value
            End Set
        End Property
        Public Property HostName() As String
            Get
                Return _HostName.Trim
            End Get
            Set(ByVal value As String)
                _HostName = value
            End Set
        End Property
        Public Property Port() As Long
            Get
                Return _Port
            End Get
            Set(ByVal value As Long)
                _Port = value
            End Set
        End Property

        'Private Function CheckAlarmWithTimeConfig(ByVal dr As DataRow) As Boolean
        '    Dim ret As Boolean = False
        '    Dim vDateNow As DateTime = DateTime.Now
        '    Dim CaseDay As Integer = DatePart(DateInterval.Weekday, vDateNow)
        '    Select Case CaseDay
        '        Case 1
        '            ret = (Convert.ToString(dr("AlarmSun")) = "Y")
        '        Case 2
        '            ret = (Convert.ToString(dr("AlarmMon")) = "Y")
        '        Case 3
        '            ret = (Convert.ToString(dr("AlarmTue")) = "Y")
        '        Case 4
        '            ret = (Convert.ToString(dr("AlarmWed")) = "Y")
        '        Case 5
        '            ret = (Convert.ToString(dr("AlarmThu")) = "Y")
        '        Case 6
        '            ret = (Convert.ToString(dr("AlarmFri")) = "Y")
        '        Case 7
        '            ret = (Convert.ToString(dr("AlarmSat")) = "Y")
        '    End Select

        '    If ret = True Then
        '        If Convert.ToString(dr("AllDayEvent")) = "N" Then
        '            If Convert.ToString(dr("AlarmTimeFrom")) <> "" And Convert.ToString(dr("AlarmTimeTo")) <> "" Then
        '                If Convert.ToString(dr("AlarmTimeFrom")) <= vDateNow.ToString("HH:mm") And vDateNow.ToString("HH:mm") <= Convert.ToString(dr("AlarmTimeTo")) Then
        '                    ret = True
        '                Else
        '                    ret = False
        '                End If
        '            Else
        '                ret = False
        '            End If
        '        End If
        '    End If

        '    Return ret
        'End Function
        
        Public Shared Function GetConfigPortList() As DataTable
            Dim dt As New DataTable
            Try
                Dim sql As String = " select cf.id PortID, cfd.id PortDetailID "
                sql += " from CF_CONFIG_PORT cf "
                sql += " inner join CF_CONFIG_PORT_DETAIL cfd on cf.id=cfd.cf_config_port_id"
                sql += " where cf.ActiveStatus='Y' "
                Dim CaseDay As Integer = DatePart(DateInterval.Weekday, DateTime.Now)
                Select Case CaseDay
                    Case 1
                        sql += " and cf.AlarmSun ='Y'"
                    Case 2
                        sql += " and cf.AlarmMon ='Y'"
                    Case 3
                        sql += " and cf.AlarmTue ='Y'"
                    Case 4
                        sql += " and cf.AlarmWed ='Y'"
                    Case 5
                        sql += " and cf.AlarmThu ='Y'"
                    Case 6
                        sql += " and cf.AlarmFri ='Y'"
                    Case 7
                        sql += " and cf.AlarmSat ='Y'"
                End Select


                dt = SqlDB.ExecuteTable(sql)
            Catch ex As Exception

            End Try
            dt.TableName = "GetConfigPortList"
            Return dt
        End Function
    End Class
End Namespace


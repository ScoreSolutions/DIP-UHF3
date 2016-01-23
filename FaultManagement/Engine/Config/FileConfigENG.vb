Imports System.Data
Imports LinqDB.TABLE
Imports System.IO

Namespace Config
    Public Class FileConfigENG
        Inherits ConfigENG

        Dim _ShopName As String = ""
        Dim _ServerName As String = ""
        Dim _IPAddress As String = ""
        Dim _RepeateCheck As Int16 = 0
        Dim _ConfigType As String = ""
        Dim _AlarmType As String = ""
        Dim _AlarmMethod As String = ""
        Dim _IntervalMinute As Int16 = 0
        Dim _CreateDate As String = ""
        Dim _ConfigFileList As New DataTable
        Dim _ConfigList As New DataTable

        Dim _AlamTimeFrom As String = ""
        Dim _AlamTimeTo As String = ""
        Dim _AllDayEvent As String = ""
        Dim _AlamDateList As New DataTable

        Public ReadOnly Property ShopName() As String
            Get
                Return _ShopName.Trim
            End Get
        End Property
        Public ReadOnly Property ServerName() As String
            Get
                Return _ServerName.Trim
            End Get
        End Property
        Public ReadOnly Property IPAddress() As String
            Get
                Return _IPAddress.Trim
            End Get
        End Property

        Public ReadOnly Property RepeateCheck() As Int16
            Get
                Return _RepeateCheck
            End Get
        End Property
        Public ReadOnly Property ConfigType() As String
            Get
                Return _ConfigType.Trim
            End Get
        End Property
        Public ReadOnly Property AlarmType() As String
            Get
                Return _AlarmType.Trim
            End Get
        End Property
        Public ReadOnly Property AlarmMethod() As String
            Get
                Return _AlarmMethod.Trim
            End Get
        End Property
        Public ReadOnly Property IntervalMinute() As Int16
            Get
                Return _IntervalMinute
            End Get
        End Property
        Public ReadOnly Property CreateDate() As String
            Get
                Return _CreateDate.Trim
            End Get
        End Property
        Public ReadOnly Property ConfigFileList() As DataTable
            Get
                Return _ConfigFileList
            End Get
        End Property
        Public ReadOnly Property ConfigList() As DataTable
            Get
                Return _ConfigList
            End Get
        End Property

        Public ReadOnly Property AlamTimeFrom() As String
            Get
                Return _AlamTimeFrom
            End Get
        End Property

        Public ReadOnly Property AlamTimeTo() As String
            Get
                Return _AlamTimeTo
            End Get
        End Property

        Public ReadOnly Property AllDayEvent() As String
            Get
                Return _AllDayEvent
            End Get
        End Property

        Public ReadOnly Property AlamDateList() As DataTable
            Get
                Return _AlamDateList
            End Get
        End Property

#Region "File Size Config"
        

        Public Shared Function GetFileSizeConfigList()
            Dim dt As New DataTable
            Try
                Dim lnq As New CfConfigFilesizeLinqDB

                Dim sql As String = "select cf.id FileSizeID, cfd.id FileSizeDetailID "
                sql += " from CF_CONFIG_FILESIZE cf"
                sql += " inner join CF_CONFIG_FILESIZE_DETAIL cfd on cf.id=cfd.cf_config_filesize_id"
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
                dt = lnq.GetListBySql(sql, Nothing)
                lnq = Nothing

            Catch ex As Exception
                dt = New DataTable
            End Try
            Return dt
        End Function
#End Region
        Public Shared Function GetFileLostConfigList()
            Dim dt As New DataTable
            Try
                Dim lnq As New CfConfigFilesizeLinqDB

                Dim sql As String = "select cf.id FileLostID, cfd.id FileLostDetailID "
                sql += " from CF_CONFIG_FILELOST cf"
                sql += " inner join CF_CONFIG_FILELOST_DETAIL cfd on cf.id=cfd.cf_config_filelost_id"
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

                dt = lnq.GetListBySql(sql, Nothing)
                lnq = Nothing

            Catch ex As Exception
                dt = New DataTable
            End Try
            Return dt
        End Function

    End Class
End Namespace


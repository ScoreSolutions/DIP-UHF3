Imports System.Xml
Imports System.IO
Imports LinqDB.TABLE

Namespace Config
    Public Class ServiceConfigENG
        Inherits ConfigENG

        Dim _ShopName As String = ""
        Dim _ServerName As String = ""
        Dim _IPAddress As String = ""
        Dim _AlarmType As String = ""
        Dim _Severity As String = ""
        Dim _AlarmMethod As String = ""
        Dim _IntervalMinute As Integer = 0
        Dim _RepeateCheck As Integer = 0
        Dim _CreateDate As String = ""
        Dim _ConfigServiceList As New DataTable
        Dim _ConfigList As New DataTable

        Dim _AlamTimeFrom As String = ""
        Dim _AlamTimeTo As String = ""
        Dim _AllDayEvent As String = ""
        Dim _AlamDateList As New DataTable
        Dim _CheckAlarmWithTimeConfig As Boolean = False

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
        Public ReadOnly Property AlarmType() As String
            Get
                Return _AlarmType.Trim
            End Get
        End Property
        Public ReadOnly Property Severity() As String
            Get
                Return _Severity.Trim
            End Get
        End Property
        Public ReadOnly Property AlarmMethod() As String
            Get
                Return _AlarmMethod.Trim
            End Get
        End Property
        Public ReadOnly Property IntervalMinute() As Integer
            Get
                Return _IntervalMinute
            End Get
        End Property
        Public ReadOnly Property RepeateCheck() As Integer
            Get
                Return _RepeateCheck
            End Get
        End Property
        Public ReadOnly Property CreateDate() As String
            Get
                Return _CreateDate.Trim
            End Get
        End Property
        Public ReadOnly Property ConfigServiceList() As DataTable
            Get
                Return _ConfigServiceList
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

        Public Shared Function GetServiceConfigList() As DataTable
            Dim dt As DataTable
            Dim lnq As New CfConfigServiceLinqDB

            Dim sql As String

            sql = "select CF.id as ServiceID, cfd.id ServiceDetailID ,CFd.ms_master_service_checklist_id,MS.WindowServiceName, ms.DisplayName "
            sql += " from CF_CONFIG_SERVICE CF "
            sql += " inner join CF_CONFIG_SERVICE_DETAIL cfd on cfd.cf_config_service_id=cf.id"
            sql += " inner join MS_MASTER_SERVICE_CHECKLIST MS on CFd.ms_master_service_checklist_id = MS.id "
            sql += " where CF.ActiveStatus = 'Y' and ms.ActiveStatus='Y' "

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

            Return dt
        End Function
    End Class
End Namespace


Imports System.Xml
Imports System.IO

Namespace Config
    Public Class CPUConfigENG
        Inherits ConfigENG

        Dim _ShopName As String = ""
        Dim _ServerName As String = ""
        Dim _IPAddress As String = ""
        Dim _RepeateCheck As Int16 = 0
        Dim _ConfigType As String = ""
        Dim _AlarmType As String = ""
        Dim _SeverityMinor As AlarmSeverity
        Dim _SeverityMajor As AlarmSeverity
        Dim _SeverityCritical As AlarmSeverity
        Dim _IntervalMinute As Int16 = 0
        Dim _Active As String = ""
        Dim _CreateDate As String = ""
        Dim _ConfigList As New DataTable

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
        Public ReadOnly Property SeverityMinor() As AlarmSeverity
            Get
                Return _SeverityMinor
            End Get
        End Property
        Public ReadOnly Property SeverityMajor() As AlarmSeverity
            Get
                Return _SeverityMajor
            End Get
        End Property
        Public ReadOnly Property SeverityCritical() As AlarmSeverity
            Get
                Return _SeverityCritical
            End Get
        End Property
        Public ReadOnly Property IntervalMinute() As Int16
            Get
                Return _IntervalMinute
            End Get
        End Property
        Public ReadOnly Property Active() As String
            Get
                Return _Active.Trim
            End Get
        End Property
        Public ReadOnly Property CreateDate() As String
            Get
                Return _CreateDate.Trim
            End Get
        End Property
        Public ReadOnly Property ConfigList() As DataTable
            Get
                Return _ConfigList
            End Get
        End Property

        Public Shared Function GetCPUConfigList() As DataTable
            Dim dt As New DataTable
            Try
                Dim sql As String = " ActiveStatus='Y'"
                Dim CaseDay As Integer = DatePart(DateInterval.Weekday, DateTime.Now)
                Select Case CaseDay
                    Case 1
                        sql += " and AlarmSun ='Y'"
                    Case 2
                        sql += " and AlarmMon ='Y'"
                    Case 3
                        sql += " and AlarmTue ='Y'"
                    Case 4
                        sql += " and AlarmWed ='Y'"
                    Case 5
                        sql += " and AlarmThu ='Y'"
                    Case 6
                        sql += " and AlarmFri ='Y'"
                    Case 7
                        sql += " and AlarmSat ='Y'"
                End Select

                Dim lnq As New LinqDB.TABLE.CfConfigCpuLinqDB
                dt = lnq.GetDataList(sql, "ServerName", Nothing)
                lnq = Nothing
            Catch ex As Exception
                dt = New DataTable
            End Try
            Return dt
        End Function

    End Class
End Namespace


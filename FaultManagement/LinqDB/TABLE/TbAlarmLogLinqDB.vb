Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = LinqDB.ConnectDB.SQLDB
Imports LinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for TB_ALARM_LOG table LinqDB.
    '[Create by  on Febuary, 26 2015]
    Public Class TbAlarmLogLinqDB
        Public sub TbAlarmLogLinqDB()

        End Sub 
        ' TB_ALARM_LOG
        Const _tableName As String = "TB_ALARM_LOG"
        Dim _deletedRow As Int16 = 0

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property TableName As String
            Get
                Return _tableName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage As String
            Get
                Return _information
            End Get
        End Property
        Public ReadOnly Property HaveData As Boolean
            Get
                Return _haveData
            End Get
        End Property


        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATEDDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _CREATEDBY As  String  = ""
        Dim _UPDATEDDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATEDBY As  String  = ""
        Dim _SERVERNAME As  String  = ""
        Dim _HOSTIP As  String  = ""
        Dim _MACADDRESS As  String  = ""
        Dim _ALARMACTIVITY As  String  = ""
        Dim _SEVERITY As  String  = ""
        Dim _ALARMVALUE As  String  = ""
        Dim _ALARMMETHOD As  String  = ""
        Dim _FLAGALARM As  String  = ""
        Dim _SPECIFICPROBLEM As  String  = ""
        Dim _ALARMWAITINGCLEARID As  System.Nullable(Of Long)  = 0

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_CREATEDDATE", DbType:="DateTime")>  _
        Public Property CREATEDDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _CREATEDDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _CREATEDDATE = value
            End Set
        End Property 
        <Column(Storage:="_CREATEDBY", DbType:="VarChar(100)")>  _
        Public Property CREATEDBY() As  String 
            Get
                Return _CREATEDBY
            End Get
            Set(ByVal value As  String )
               _CREATEDBY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATEDDATE", DbType:="DateTime")>  _
        Public Property UPDATEDDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATEDDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATEDDATE = value
            End Set
        End Property 
        <Column(Storage:="_UPDATEDBY", DbType:="VarChar(100)")>  _
        Public Property UPDATEDBY() As  String 
            Get
                Return _UPDATEDBY
            End Get
            Set(ByVal value As  String )
               _UPDATEDBY = value
            End Set
        End Property 
        <Column(Storage:="_SERVERNAME", DbType:="VarChar(255)")>  _
        Public Property SERVERNAME() As  String 
            Get
                Return _SERVERNAME
            End Get
            Set(ByVal value As  String )
               _SERVERNAME = value
            End Set
        End Property 
        <Column(Storage:="_HOSTIP", DbType:="VarChar(50)")>  _
        Public Property HOSTIP() As  String 
            Get
                Return _HOSTIP
            End Get
            Set(ByVal value As  String )
               _HOSTIP = value
            End Set
        End Property 
        <Column(Storage:="_MACADDRESS", DbType:="VarChar(255)")>  _
        Public Property MACADDRESS() As  String 
            Get
                Return _MACADDRESS
            End Get
            Set(ByVal value As  String )
               _MACADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_ALARMACTIVITY", DbType:="VarChar(255)")>  _
        Public Property ALARMACTIVITY() As  String 
            Get
                Return _ALARMACTIVITY
            End Get
            Set(ByVal value As  String )
               _ALARMACTIVITY = value
            End Set
        End Property 
        <Column(Storage:="_SEVERITY", DbType:="VarChar(50)")>  _
        Public Property SEVERITY() As  String 
            Get
                Return _SEVERITY
            End Get
            Set(ByVal value As  String )
               _SEVERITY = value
            End Set
        End Property 
        <Column(Storage:="_ALARMVALUE", DbType:="VarChar(50)")>  _
        Public Property ALARMVALUE() As  String 
            Get
                Return _ALARMVALUE
            End Get
            Set(ByVal value As  String )
               _ALARMVALUE = value
            End Set
        End Property 
        <Column(Storage:="_ALARMMETHOD", DbType:="VarChar(50)")>  _
        Public Property ALARMMETHOD() As  String 
            Get
                Return _ALARMMETHOD
            End Get
            Set(ByVal value As  String )
               _ALARMMETHOD = value
            End Set
        End Property 
        <Column(Storage:="_FLAGALARM", DbType:="VarChar(50)")>  _
        Public Property FLAGALARM() As  String 
            Get
                Return _FLAGALARM
            End Get
            Set(ByVal value As  String )
               _FLAGALARM = value
            End Set
        End Property 
        <Column(Storage:="_SPECIFICPROBLEM", DbType:="VarChar(500)")>  _
        Public Property SPECIFICPROBLEM() As  String 
            Get
                Return _SPECIFICPROBLEM
            End Get
            Set(ByVal value As  String )
               _SPECIFICPROBLEM = value
            End Set
        End Property 
        <Column(Storage:="_ALARMWAITINGCLEARID", DbType:="BigInt")>  _
        Public Property ALARMWAITINGCLEARID() As  System.Nullable(Of Long) 
            Get
                Return _ALARMWAITINGCLEARID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ALARMWAITINGCLEARID = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATEDDATE = New DateTime(1,1,1)
            _CREATEDBY = ""
            _UPDATEDDATE = New DateTime(1,1,1)
            _UPDATEDBY = ""
            _SERVERNAME = ""
            _HOSTIP = ""
            _MACADDRESS = ""
            _ALARMACTIVITY = ""
            _SEVERITY = ""
            _ALARMVALUE = ""
            _ALARMMETHOD = ""
            _FLAGALARM = ""
            _SPECIFICPROBLEM = ""
            _ALARMWAITINGCLEARID = 0
        End Sub

       'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(whClause As String, orderBy As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(Sql As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(Sql, trans)
        End Function


        '/// Returns an indication whether the current data is inserted into TB_ALARM_LOG table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _CreatedBy = LoginName
                _CreatedDate = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TB_ALARM_LOG table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _UpdatedBy = LoginName
                _UpdatedDate = DateTime.Now
                Return doUpdate("ID = " & DB.SetDouble(_ID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TB_ALARM_LOG table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_ALARM_LOG table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(cID As Long, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return doDelete("ID = " & DB.SetDouble(cID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the record of TB_ALARM_LOG by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_ALARM_LOG by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbAlarmLogLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_ALARM_LOG by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_ALARM_LOG table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try

                    ret = (DB.ExecuteNonQuery(SqlInsert, trans) > 0)
                    If ret = False Then
                        _error = DB.ErrorMessage
                    Else
                        _ID = DB.GetLastID(_tableName, trans)
                        _haveData = True
                    End If
                    _information = MessageResources.MSGIN001
                Catch ex As ApplicationException
                    ret = false
                    _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlInsert
                Catch ex As Exception
                    ret = False
                    _error = MessageResources.MSGEC101 & " Exception :" & ex.ToString() & "### SQL: " & SqlInsert
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002 & "### SQL: " & SqlInsert
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to TB_ALARM_LOG table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If _haveData = True Then
                If whText.Trim() <> ""
                    Try

                        ret = (DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = DB.ErrorMessage
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlUpdate & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC102 & " Exception :" & ex.ToString() & "### SQL: " & SqlUpdate & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003 & "### SQL: " & SqlUpdate & tmpWhere
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002 & "### SQL: " & SqlUpdate & tmpWhere
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from TB_ALARM_LOG table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlDelete & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC103 & " Exception :" & ex.ToString() & "### SQL: " & SqlDelete & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003 & "### SQL: " & SqlDelete & tmpWhere
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002 & "### SQL: " & SqlDelete & tmpWhere
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of TB_ALARM_LOG by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " WHERE " & whText
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("CreatedDate")) = False Then _CreatedDate = Convert.ToDateTime(Rdr("CreatedDate"))
                        If Convert.IsDBNull(Rdr("CreatedBy")) = False Then _CreatedBy = Rdr("CreatedBy").ToString()
                        If Convert.IsDBNull(Rdr("UpdatedDate")) = False Then _UpdatedDate = Convert.ToDateTime(Rdr("UpdatedDate"))
                        If Convert.IsDBNull(Rdr("UpdatedBy")) = False Then _UpdatedBy = Rdr("UpdatedBy").ToString()
                        If Convert.IsDBNull(Rdr("ServerName")) = False Then _ServerName = Rdr("ServerName").ToString()
                        If Convert.IsDBNull(Rdr("HostIP")) = False Then _HostIP = Rdr("HostIP").ToString()
                        If Convert.IsDBNull(Rdr("MacAddress")) = False Then _MacAddress = Rdr("MacAddress").ToString()
                        If Convert.IsDBNull(Rdr("AlarmActivity")) = False Then _AlarmActivity = Rdr("AlarmActivity").ToString()
                        If Convert.IsDBNull(Rdr("Severity")) = False Then _Severity = Rdr("Severity").ToString()
                        If Convert.IsDBNull(Rdr("AlarmValue")) = False Then _AlarmValue = Rdr("AlarmValue").ToString()
                        If Convert.IsDBNull(Rdr("AlarmMethod")) = False Then _AlarmMethod = Rdr("AlarmMethod").ToString()
                        If Convert.IsDBNull(Rdr("FlagAlarm")) = False Then _FlagAlarm = Rdr("FlagAlarm").ToString()
                        If Convert.IsDBNull(Rdr("SpecificProblem")) = False Then _SpecificProblem = Rdr("SpecificProblem").ToString()
                        If Convert.IsDBNull(Rdr("AlarmWaitingClearID")) = False Then _AlarmWaitingClearID = Convert.ToInt64(Rdr("AlarmWaitingClearID"))
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of TB_ALARM_LOG by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbAlarmLogLinqDB
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("CreatedDate")) = False Then _CreatedDate = Convert.ToDateTime(Rdr("CreatedDate"))
                        If Convert.IsDBNull(Rdr("CreatedBy")) = False Then _CreatedBy = Rdr("CreatedBy").ToString()
                        If Convert.IsDBNull(Rdr("UpdatedDate")) = False Then _UpdatedDate = Convert.ToDateTime(Rdr("UpdatedDate"))
                        If Convert.IsDBNull(Rdr("UpdatedBy")) = False Then _UpdatedBy = Rdr("UpdatedBy").ToString()
                        If Convert.IsDBNull(Rdr("ServerName")) = False Then _ServerName = Rdr("ServerName").ToString()
                        If Convert.IsDBNull(Rdr("HostIP")) = False Then _HostIP = Rdr("HostIP").ToString()
                        If Convert.IsDBNull(Rdr("MacAddress")) = False Then _MacAddress = Rdr("MacAddress").ToString()
                        If Convert.IsDBNull(Rdr("AlarmActivity")) = False Then _AlarmActivity = Rdr("AlarmActivity").ToString()
                        If Convert.IsDBNull(Rdr("Severity")) = False Then _Severity = Rdr("Severity").ToString()
                        If Convert.IsDBNull(Rdr("AlarmValue")) = False Then _AlarmValue = Rdr("AlarmValue").ToString()
                        If Convert.IsDBNull(Rdr("AlarmMethod")) = False Then _AlarmMethod = Rdr("AlarmMethod").ToString()
                        If Convert.IsDBNull(Rdr("FlagAlarm")) = False Then _FlagAlarm = Rdr("FlagAlarm").ToString()
                        If Convert.IsDBNull(Rdr("SpecificProblem")) = False Then _SpecificProblem = Rdr("SpecificProblem").ToString()
                        If Convert.IsDBNull(Rdr("AlarmWaitingClearID")) = False Then _AlarmWaitingClearID = Convert.ToInt64(Rdr("AlarmWaitingClearID"))
                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return Me
        End Function



        ' SQL Statements


        'Get Insert Statement for table TB_ALARM_LOG
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATEDDATE, CREATEDBY, SERVERNAME, HOSTIP, MACADDRESS, ALARMACTIVITY, SEVERITY, ALARMVALUE, ALARMMETHOD, FLAGALARM, SPECIFICPROBLEM, ALARMWAITINGCLEARID)"
                Sql += " VALUES("
                sql += DB.SetDateTime(_CREATEDDATE) & ", "
                sql += DB.SetString(_CREATEDBY) & ", "
                sql += DB.SetString(_SERVERNAME) & ", "
                sql += DB.SetString(_HOSTIP) & ", "
                sql += DB.SetString(_MACADDRESS) & ", "
                sql += DB.SetString(_ALARMACTIVITY) & ", "
                sql += DB.SetString(_SEVERITY) & ", "
                sql += DB.SetString(_ALARMVALUE) & ", "
                sql += DB.SetString(_ALARMMETHOD) & ", "
                sql += DB.SetString(_FLAGALARM) & ", "
                sql += DB.SetString(_SPECIFICPROBLEM) & ", "
                sql += DB.SetDouble(_ALARMWAITINGCLEARID)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_ALARM_LOG
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATEDDATE = " & DB.SetDateTime(_UPDATEDDATE) & ", "
                Sql += "UPDATEDBY = " & DB.SetString(_UPDATEDBY) & ", "
                Sql += "SERVERNAME = " & DB.SetString(_SERVERNAME) & ", "
                Sql += "HOSTIP = " & DB.SetString(_HOSTIP) & ", "
                Sql += "MACADDRESS = " & DB.SetString(_MACADDRESS) & ", "
                Sql += "ALARMACTIVITY = " & DB.SetString(_ALARMACTIVITY) & ", "
                Sql += "SEVERITY = " & DB.SetString(_SEVERITY) & ", "
                Sql += "ALARMVALUE = " & DB.SetString(_ALARMVALUE) & ", "
                Sql += "ALARMMETHOD = " & DB.SetString(_ALARMMETHOD) & ", "
                Sql += "FLAGALARM = " & DB.SetString(_FLAGALARM) & ", "
                Sql += "SPECIFICPROBLEM = " & DB.SetString(_SPECIFICPROBLEM) & ", "
                Sql += "ALARMWAITINGCLEARID = " & DB.SetDouble(_ALARMWAITINGCLEARID) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_ALARM_LOG
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_ALARM_LOG
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATEDDATE, CREATEDBY, UPDATEDDATE, UPDATEDBY, SERVERNAME, HOSTIP, MACADDRESS, ALARMACTIVITY, SEVERITY, ALARMVALUE, ALARMMETHOD, FLAGALARM, SPECIFICPROBLEM, ALARMWAITINGCLEARID FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
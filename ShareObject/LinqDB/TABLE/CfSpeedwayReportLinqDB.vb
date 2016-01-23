Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = LinqDB.ConnectDB.DIPRFIDSqlDB
Imports LinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for CF_SPEEDWAY_REPORT table LinqDB.
    '[Create by  on March, 16 2015]
    Public Class CfSpeedwayReportLinqDB
        Public sub CfSpeedwayReportLinqDB()

        End Sub 
        ' CF_SPEEDWAY_REPORT
        Const _tableName As String = "CF_SPEEDWAY_REPORT"
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
        Dim _CREATED_BY As String = ""
        Dim _CREATED_DATE As DateTime = New DateTime(1,1,1)
        Dim _UPDATED_BY As  String  = ""
        Dim _UPDATED_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _CF_SPEEDWAY_SETTING_ID As Long = 0
        Dim _REPORT_MODE As String = ""
        Dim _INCLUDE_PEAK_RSSI As String = ""
        Dim _INCLUDE_ANTENNA_PORT_NUMBER As String = ""
        Dim _INCLUDE_FIRST_SEEN_TIME As String = ""
        Dim _INCLUDE_LAST_SEEN_TIME As String = ""
        Dim _INCLUDE_SEEN_COUNT As String = ""
        Dim _INCLUDE_CHANNEL As String = ""
        Dim _INCLUDE_PHASE_ANGLE As String = ""
        Dim _INCLUDE_SERIALIZED_TID As String = ""

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
        <Column(Storage:="_CREATED_BY", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATED_BY() As String
            Get
                Return _CREATED_BY
            End Get
            Set(ByVal value As String)
               _CREATED_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATED_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATED_DATE() As DateTime
            Get
                Return _CREATED_DATE
            End Get
            Set(ByVal value As DateTime)
               _CREATED_DATE = value
            End Set
        End Property 
        <Column(Storage:="_UPDATED_BY", DbType:="VarChar(100)")>  _
        Public Property UPDATED_BY() As  String 
            Get
                Return _UPDATED_BY
            End Get
            Set(ByVal value As  String )
               _UPDATED_BY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATED_DATE", DbType:="DateTime")>  _
        Public Property UPDATED_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATED_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATED_DATE = value
            End Set
        End Property 
        <Column(Storage:="_CF_SPEEDWAY_SETTING_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property CF_SPEEDWAY_SETTING_ID() As Long
            Get
                Return _CF_SPEEDWAY_SETTING_ID
            End Get
            Set(ByVal value As Long)
               _CF_SPEEDWAY_SETTING_ID = value
            End Set
        End Property 
        <Column(Storage:="_REPORT_MODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property REPORT_MODE() As String
            Get
                Return _REPORT_MODE
            End Get
            Set(ByVal value As String)
               _REPORT_MODE = value
            End Set
        End Property 
        <Column(Storage:="_INCLUDE_PEAK_RSSI", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property INCLUDE_PEAK_RSSI() As String
            Get
                Return _INCLUDE_PEAK_RSSI
            End Get
            Set(ByVal value As String)
               _INCLUDE_PEAK_RSSI = value
            End Set
        End Property 
        <Column(Storage:="_INCLUDE_ANTENNA_PORT_NUMBER", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property INCLUDE_ANTENNA_PORT_NUMBER() As String
            Get
                Return _INCLUDE_ANTENNA_PORT_NUMBER
            End Get
            Set(ByVal value As String)
               _INCLUDE_ANTENNA_PORT_NUMBER = value
            End Set
        End Property 
        <Column(Storage:="_INCLUDE_FIRST_SEEN_TIME", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property INCLUDE_FIRST_SEEN_TIME() As String
            Get
                Return _INCLUDE_FIRST_SEEN_TIME
            End Get
            Set(ByVal value As String)
               _INCLUDE_FIRST_SEEN_TIME = value
            End Set
        End Property 
        <Column(Storage:="_INCLUDE_LAST_SEEN_TIME", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property INCLUDE_LAST_SEEN_TIME() As String
            Get
                Return _INCLUDE_LAST_SEEN_TIME
            End Get
            Set(ByVal value As String)
               _INCLUDE_LAST_SEEN_TIME = value
            End Set
        End Property 
        <Column(Storage:="_INCLUDE_SEEN_COUNT", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property INCLUDE_SEEN_COUNT() As String
            Get
                Return _INCLUDE_SEEN_COUNT
            End Get
            Set(ByVal value As String)
               _INCLUDE_SEEN_COUNT = value
            End Set
        End Property 
        <Column(Storage:="_INCLUDE_CHANNEL", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property INCLUDE_CHANNEL() As String
            Get
                Return _INCLUDE_CHANNEL
            End Get
            Set(ByVal value As String)
               _INCLUDE_CHANNEL = value
            End Set
        End Property 
        <Column(Storage:="_INCLUDE_PHASE_ANGLE", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property INCLUDE_PHASE_ANGLE() As String
            Get
                Return _INCLUDE_PHASE_ANGLE
            End Get
            Set(ByVal value As String)
               _INCLUDE_PHASE_ANGLE = value
            End Set
        End Property 
        <Column(Storage:="_INCLUDE_SERIALIZED_TID", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property INCLUDE_SERIALIZED_TID() As String
            Get
                Return _INCLUDE_SERIALIZED_TID
            End Get
            Set(ByVal value As String)
               _INCLUDE_SERIALIZED_TID = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _CF_SPEEDWAY_SETTING_ID = 0
            _REPORT_MODE = ""
            _INCLUDE_PEAK_RSSI = ""
            _INCLUDE_ANTENNA_PORT_NUMBER = ""
            _INCLUDE_FIRST_SEEN_TIME = ""
            _INCLUDE_LAST_SEEN_TIME = ""
            _INCLUDE_SEEN_COUNT = ""
            _INCLUDE_CHANNEL = ""
            _INCLUDE_PHASE_ANGLE = ""
            _INCLUDE_SERIALIZED_TID = ""
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


        '/// Returns an indication whether the current data is inserted into CF_SPEEDWAY_REPORT table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _ID = DB.GetNextID("ID",tableName, trans)
                _Created_By = LoginName
                _Created_date = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to CF_SPEEDWAY_REPORT table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _Updated_By = LoginName
                _Updated_Date = DateTime.Now
                Return doUpdate("ID = " & DB.SetDouble(_ID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to CF_SPEEDWAY_REPORT table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from CF_SPEEDWAY_REPORT table successfully.
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


        '/// Returns an indication whether the record of CF_SPEEDWAY_REPORT by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of CF_SPEEDWAY_REPORT by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As CfSpeedwayReportLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY_REPORT by specified CF_SPEEDWAY_SETTING_ID key is retrieved successfully.
        '/// <param name=cCF_SPEEDWAY_SETTING_ID>The CF_SPEEDWAY_SETTING_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByCF_SPEEDWAY_SETTING_ID(cCF_SPEEDWAY_SETTING_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("CF_SPEEDWAY_SETTING_ID = " & DB.SetDouble(cCF_SPEEDWAY_SETTING_ID) & " ", trans)
        End Function

        '/// Returns an duplicate data record of CF_SPEEDWAY_REPORT by specified CF_SPEEDWAY_SETTING_ID key is retrieved successfully.
        '/// <param name=cCF_SPEEDWAY_SETTING_ID>The CF_SPEEDWAY_SETTING_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByCF_SPEEDWAY_SETTING_ID(cCF_SPEEDWAY_SETTING_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("CF_SPEEDWAY_SETTING_ID = " & DB.SetDouble(cCF_SPEEDWAY_SETTING_ID) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY_REPORT by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into CF_SPEEDWAY_REPORT table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try
                    Dim dt as DataTable = DB.ExecuteTable(SqlInsert, trans, SetParameterData())
                    If dt.Rows.Count = 0 Then
                        _error = DB.ErrorMessage
                        ret = False
                    Else
                        _haveData = True
                        ret = True
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


        '/// Returns an indication whether the current data is updated to CF_SPEEDWAY_REPORT table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If _haveData = True Then
                If whText.Trim() <> ""
                    Try
                        ret = DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans, SetParameterData())
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
                ret = True
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from CF_SPEEDWAY_REPORT table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > -1)
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
                ret = True
            End If

            Return ret
        End Function

        Private Function SetParameterData() As SqlParameter()
            Dim cmbParam(14) As SqlParameter
            cmbParam(0) = New SqlParameter("@_ID", SqlDbType.BigInt)
            cmbParam(0).Value = _ID

            cmbParam(1) = New SqlParameter("@_CREATED_BY", SqlDbType.VarChar)
            cmbParam(1).Value = _CREATED_BY

            cmbParam(2) = New SqlParameter("@_CREATED_DATE", SqlDbType.DateTime)
            cmbParam(2).Value = _CREATED_DATE

            cmbParam(3) = New SqlParameter("@_UPDATED_BY", SqlDbType.VarChar)
            If _UPDATED_BY.Trim <> "" Then 
                cmbParam(3).Value = _UPDATED_BY
            Else
                cmbParam(3).Value = DBNull.value
            End If

            cmbParam(4) = New SqlParameter("@_UPDATED_DATE", SqlDbType.DateTime)
            If _UPDATED_DATE.Value.Year > 1 Then 
                cmbParam(4).Value = _UPDATED_DATE.Value
            Else
                cmbParam(4).Value = DBNull.value
            End If

            cmbParam(5) = New SqlParameter("@_CF_SPEEDWAY_SETTING_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _CF_SPEEDWAY_SETTING_ID

            cmbParam(6) = New SqlParameter("@_REPORT_MODE", SqlDbType.VarChar)
            cmbParam(6).Value = _REPORT_MODE

            cmbParam(7) = New SqlParameter("@_INCLUDE_PEAK_RSSI", SqlDbType.VarChar)
            cmbParam(7).Value = _INCLUDE_PEAK_RSSI

            cmbParam(8) = New SqlParameter("@_INCLUDE_ANTENNA_PORT_NUMBER", SqlDbType.VarChar)
            cmbParam(8).Value = _INCLUDE_ANTENNA_PORT_NUMBER

            cmbParam(9) = New SqlParameter("@_INCLUDE_FIRST_SEEN_TIME", SqlDbType.VarChar)
            cmbParam(9).Value = _INCLUDE_FIRST_SEEN_TIME

            cmbParam(10) = New SqlParameter("@_INCLUDE_LAST_SEEN_TIME", SqlDbType.VarChar)
            cmbParam(10).Value = _INCLUDE_LAST_SEEN_TIME

            cmbParam(11) = New SqlParameter("@_INCLUDE_SEEN_COUNT", SqlDbType.VarChar)
            cmbParam(11).Value = _INCLUDE_SEEN_COUNT

            cmbParam(12) = New SqlParameter("@_INCLUDE_CHANNEL", SqlDbType.VarChar)
            cmbParam(12).Value = _INCLUDE_CHANNEL

            cmbParam(13) = New SqlParameter("@_INCLUDE_PHASE_ANGLE", SqlDbType.VarChar)
            cmbParam(13).Value = _INCLUDE_PHASE_ANGLE

            cmbParam(14) = New SqlParameter("@_INCLUDE_SERIALIZED_TID", SqlDbType.VarChar)
            cmbParam(14).Value = _INCLUDE_SERIALIZED_TID

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY_REPORT by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("created_by")) = False Then _created_by = Rdr("created_by").ToString()
                        If Convert.IsDBNull(Rdr("created_date")) = False Then _created_date = Convert.ToDateTime(Rdr("created_date"))
                        If Convert.IsDBNull(Rdr("updated_by")) = False Then _updated_by = Rdr("updated_by").ToString()
                        If Convert.IsDBNull(Rdr("updated_date")) = False Then _updated_date = Convert.ToDateTime(Rdr("updated_date"))
                        If Convert.IsDBNull(Rdr("cf_speedway_setting_id")) = False Then _cf_speedway_setting_id = Convert.ToInt64(Rdr("cf_speedway_setting_id"))
                        If Convert.IsDBNull(Rdr("report_mode")) = False Then _report_mode = Rdr("report_mode").ToString()
                        If Convert.IsDBNull(Rdr("include_peak_rssi")) = False Then _include_peak_rssi = Rdr("include_peak_rssi").ToString()
                        If Convert.IsDBNull(Rdr("include_antenna_port_number")) = False Then _include_antenna_port_number = Rdr("include_antenna_port_number").ToString()
                        If Convert.IsDBNull(Rdr("include_first_seen_time")) = False Then _include_first_seen_time = Rdr("include_first_seen_time").ToString()
                        If Convert.IsDBNull(Rdr("include_last_seen_time")) = False Then _include_last_seen_time = Rdr("include_last_seen_time").ToString()
                        If Convert.IsDBNull(Rdr("include_seen_count")) = False Then _include_seen_count = Rdr("include_seen_count").ToString()
                        If Convert.IsDBNull(Rdr("include_channel")) = False Then _include_channel = Rdr("include_channel").ToString()
                        If Convert.IsDBNull(Rdr("include_phase_angle")) = False Then _include_phase_angle = Rdr("include_phase_angle").ToString()
                        If Convert.IsDBNull(Rdr("include_serialized_tid")) = False Then _include_serialized_tid = Rdr("include_serialized_tid").ToString()
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


        '/// Returns an indication whether the record of CF_SPEEDWAY_REPORT by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As CfSpeedwayReportLinqDB
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
                        If Convert.IsDBNull(Rdr("created_by")) = False Then _created_by = Rdr("created_by").ToString()
                        If Convert.IsDBNull(Rdr("created_date")) = False Then _created_date = Convert.ToDateTime(Rdr("created_date"))
                        If Convert.IsDBNull(Rdr("updated_by")) = False Then _updated_by = Rdr("updated_by").ToString()
                        If Convert.IsDBNull(Rdr("updated_date")) = False Then _updated_date = Convert.ToDateTime(Rdr("updated_date"))
                        If Convert.IsDBNull(Rdr("cf_speedway_setting_id")) = False Then _cf_speedway_setting_id = Convert.ToInt64(Rdr("cf_speedway_setting_id"))
                        If Convert.IsDBNull(Rdr("report_mode")) = False Then _report_mode = Rdr("report_mode").ToString()
                        If Convert.IsDBNull(Rdr("include_peak_rssi")) = False Then _include_peak_rssi = Rdr("include_peak_rssi").ToString()
                        If Convert.IsDBNull(Rdr("include_antenna_port_number")) = False Then _include_antenna_port_number = Rdr("include_antenna_port_number").ToString()
                        If Convert.IsDBNull(Rdr("include_first_seen_time")) = False Then _include_first_seen_time = Rdr("include_first_seen_time").ToString()
                        If Convert.IsDBNull(Rdr("include_last_seen_time")) = False Then _include_last_seen_time = Rdr("include_last_seen_time").ToString()
                        If Convert.IsDBNull(Rdr("include_seen_count")) = False Then _include_seen_count = Rdr("include_seen_count").ToString()
                        If Convert.IsDBNull(Rdr("include_channel")) = False Then _include_channel = Rdr("include_channel").ToString()
                        If Convert.IsDBNull(Rdr("include_phase_angle")) = False Then _include_phase_angle = Rdr("include_phase_angle").ToString()
                        If Convert.IsDBNull(Rdr("include_serialized_tid")) = False Then _include_serialized_tid = Rdr("include_serialized_tid").ToString()
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


        'Get Insert Statement for table CF_SPEEDWAY_REPORT
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, CF_SPEEDWAY_SETTING_ID, REPORT_MODE, INCLUDE_PEAK_RSSI, INCLUDE_ANTENNA_PORT_NUMBER, INCLUDE_FIRST_SEEN_TIME, INCLUDE_LAST_SEEN_TIME, INCLUDE_SEEN_COUNT, INCLUDE_CHANNEL, INCLUDE_PHASE_ANGLE, INCLUDE_SERIALIZED_TID)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.CF_SPEEDWAY_SETTING_ID, INSERTED.REPORT_MODE, INSERTED.INCLUDE_PEAK_RSSI, INSERTED.INCLUDE_ANTENNA_PORT_NUMBER, INSERTED.INCLUDE_FIRST_SEEN_TIME, INSERTED.INCLUDE_LAST_SEEN_TIME, INSERTED.INCLUDE_SEEN_COUNT, INSERTED.INCLUDE_CHANNEL, INSERTED.INCLUDE_PHASE_ANGLE, INSERTED.INCLUDE_SERIALIZED_TID
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_CF_SPEEDWAY_SETTING_ID" & ", "
                sql += "@_REPORT_MODE" & ", "
                sql += "@_INCLUDE_PEAK_RSSI" & ", "
                sql += "@_INCLUDE_ANTENNA_PORT_NUMBER" & ", "
                sql += "@_INCLUDE_FIRST_SEEN_TIME" & ", "
                sql += "@_INCLUDE_LAST_SEEN_TIME" & ", "
                sql += "@_INCLUDE_SEEN_COUNT" & ", "
                sql += "@_INCLUDE_CHANNEL" & ", "
                sql += "@_INCLUDE_PHASE_ANGLE" & ", "
                sql += "@_INCLUDE_SERIALIZED_TID"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table CF_SPEEDWAY_REPORT
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "CF_SPEEDWAY_SETTING_ID = " & "@_CF_SPEEDWAY_SETTING_ID" & ", "
                Sql += "REPORT_MODE = " & "@_REPORT_MODE" & ", "
                Sql += "INCLUDE_PEAK_RSSI = " & "@_INCLUDE_PEAK_RSSI" & ", "
                Sql += "INCLUDE_ANTENNA_PORT_NUMBER = " & "@_INCLUDE_ANTENNA_PORT_NUMBER" & ", "
                Sql += "INCLUDE_FIRST_SEEN_TIME = " & "@_INCLUDE_FIRST_SEEN_TIME" & ", "
                Sql += "INCLUDE_LAST_SEEN_TIME = " & "@_INCLUDE_LAST_SEEN_TIME" & ", "
                Sql += "INCLUDE_SEEN_COUNT = " & "@_INCLUDE_SEEN_COUNT" & ", "
                Sql += "INCLUDE_CHANNEL = " & "@_INCLUDE_CHANNEL" & ", "
                Sql += "INCLUDE_PHASE_ANGLE = " & "@_INCLUDE_PHASE_ANGLE" & ", "
                Sql += "INCLUDE_SERIALIZED_TID = " & "@_INCLUDE_SERIALIZED_TID" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table CF_SPEEDWAY_REPORT
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table CF_SPEEDWAY_REPORT
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, CF_SPEEDWAY_SETTING_ID, REPORT_MODE, INCLUDE_PEAK_RSSI, INCLUDE_ANTENNA_PORT_NUMBER, INCLUDE_FIRST_SEEN_TIME, INCLUDE_LAST_SEEN_TIME, INCLUDE_SEEN_COUNT, INCLUDE_CHANNEL, INCLUDE_PHASE_ANGLE, INCLUDE_SERIALIZED_TID FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

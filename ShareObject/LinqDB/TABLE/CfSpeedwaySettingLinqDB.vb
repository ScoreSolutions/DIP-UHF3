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
    'Represents a transaction for CF_SPEEDWAY_SETTING table LinqDB.
    '[Create by  on March, 16 2015]
    Public Class CfSpeedwaySettingLinqDB
        Public sub CfSpeedwaySettingLinqDB()

        End Sub 
        ' CF_SPEEDWAY_SETTING
        Const _tableName As String = "CF_SPEEDWAY_SETTING"
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
        Dim _CF_SPEEDWAY_ID As  System.Nullable(Of Long)  = 0
        Dim _SETTING_LABEL As  String  = ""
        Dim _SETTING_DESCRIPTION As  String  = ""
        Dim _SETTING_SEARCH_MODE As String = ""
        Dim _SETTING_SESSION As Long = 0
        Dim _SETTING_TAG_POPULATE_ESTIMATE As Long = 0
        Dim _SETTING_TIME_CORRECT_ENABLED As String = "false"
        Dim _FILTERS_MODE As String = "None"
        Dim _KEEPALIVE_IS_ENABLED As String = "false"
        Dim _KEEPALIVE_PERIOD_IN_MS As Long = 0
        Dim _KEEPALIVE_LINK_DOWN_THRESHOLD As Long = 0

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
        <Column(Storage:="_CF_SPEEDWAY_ID", DbType:="BigInt")>  _
        Public Property CF_SPEEDWAY_ID() As  System.Nullable(Of Long) 
            Get
                Return _CF_SPEEDWAY_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _CF_SPEEDWAY_ID = value
            End Set
        End Property 
        <Column(Storage:="_SETTING_LABEL", DbType:="VarChar(255)")>  _
        Public Property SETTING_LABEL() As  String 
            Get
                Return _SETTING_LABEL
            End Get
            Set(ByVal value As  String )
               _SETTING_LABEL = value
            End Set
        End Property 
        <Column(Storage:="_SETTING_DESCRIPTION", DbType:="VarChar(255)")>  _
        Public Property SETTING_DESCRIPTION() As  String 
            Get
                Return _SETTING_DESCRIPTION
            End Get
            Set(ByVal value As  String )
               _SETTING_DESCRIPTION = value
            End Set
        End Property 
        <Column(Storage:="_SETTING_SEARCH_MODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SETTING_SEARCH_MODE() As String
            Get
                Return _SETTING_SEARCH_MODE
            End Get
            Set(ByVal value As String)
               _SETTING_SEARCH_MODE = value
            End Set
        End Property 
        <Column(Storage:="_SETTING_SESSION", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SETTING_SESSION() As Long
            Get
                Return _SETTING_SESSION
            End Get
            Set(ByVal value As Long)
               _SETTING_SESSION = value
            End Set
        End Property 
        <Column(Storage:="_SETTING_TAG_POPULATE_ESTIMATE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SETTING_TAG_POPULATE_ESTIMATE() As Long
            Get
                Return _SETTING_TAG_POPULATE_ESTIMATE
            End Get
            Set(ByVal value As Long)
               _SETTING_TAG_POPULATE_ESTIMATE = value
            End Set
        End Property 
        <Column(Storage:="_SETTING_TIME_CORRECT_ENABLED", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property SETTING_TIME_CORRECT_ENABLED() As String
            Get
                Return _SETTING_TIME_CORRECT_ENABLED
            End Get
            Set(ByVal value As String)
               _SETTING_TIME_CORRECT_ENABLED = value
            End Set
        End Property 
        <Column(Storage:="_FILTERS_MODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property FILTERS_MODE() As String
            Get
                Return _FILTERS_MODE
            End Get
            Set(ByVal value As String)
               _FILTERS_MODE = value
            End Set
        End Property 
        <Column(Storage:="_KEEPALIVE_IS_ENABLED", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property KEEPALIVE_IS_ENABLED() As String
            Get
                Return _KEEPALIVE_IS_ENABLED
            End Get
            Set(ByVal value As String)
               _KEEPALIVE_IS_ENABLED = value
            End Set
        End Property 
        <Column(Storage:="_KEEPALIVE_PERIOD_IN_MS", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property KEEPALIVE_PERIOD_IN_MS() As Long
            Get
                Return _KEEPALIVE_PERIOD_IN_MS
            End Get
            Set(ByVal value As Long)
               _KEEPALIVE_PERIOD_IN_MS = value
            End Set
        End Property 
        <Column(Storage:="_KEEPALIVE_LINK_DOWN_THRESHOLD", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property KEEPALIVE_LINK_DOWN_THRESHOLD() As Long
            Get
                Return _KEEPALIVE_LINK_DOWN_THRESHOLD
            End Get
            Set(ByVal value As Long)
               _KEEPALIVE_LINK_DOWN_THRESHOLD = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _CF_SPEEDWAY_ID = 0
            _SETTING_LABEL = ""
            _SETTING_DESCRIPTION = ""
            _SETTING_SEARCH_MODE = ""
            _SETTING_SESSION = 0
            _SETTING_TAG_POPULATE_ESTIMATE = 0
            _SETTING_TIME_CORRECT_ENABLED = "false"
            _FILTERS_MODE = "None"
            _KEEPALIVE_IS_ENABLED = "false"
            _KEEPALIVE_PERIOD_IN_MS = 0
            _KEEPALIVE_LINK_DOWN_THRESHOLD = 0
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


        '/// Returns an indication whether the current data is inserted into CF_SPEEDWAY_SETTING table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _Created_By = LoginName
                _Created_date = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to CF_SPEEDWAY_SETTING table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_SPEEDWAY_SETTING table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from CF_SPEEDWAY_SETTING table successfully.
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


        '/// Returns an indication whether the record of CF_SPEEDWAY_SETTING by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of CF_SPEEDWAY_SETTING by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As CfSpeedwaySettingLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY_SETTING by specified CF_SPEEDWAY_ID key is retrieved successfully.
        '/// <param name=cCF_SPEEDWAY_ID>The CF_SPEEDWAY_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByCF_SPEEDWAY_ID(cCF_SPEEDWAY_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("CF_SPEEDWAY_ID = " & DB.SetDouble(cCF_SPEEDWAY_ID) & " ", trans)
        End Function

        '/// Returns an duplicate data record of CF_SPEEDWAY_SETTING by specified CF_SPEEDWAY_ID key is retrieved successfully.
        '/// <param name=cCF_SPEEDWAY_ID>The CF_SPEEDWAY_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByCF_SPEEDWAY_ID(cCF_SPEEDWAY_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("CF_SPEEDWAY_ID = " & DB.SetDouble(cCF_SPEEDWAY_ID) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY_SETTING by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into CF_SPEEDWAY_SETTING table successfully.
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
                        _ID = dt.Rows(0)("ID")
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


        '/// Returns an indication whether the current data is updated to CF_SPEEDWAY_SETTING table successfully.
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


        '/// Returns an indication whether the current data is deleted from CF_SPEEDWAY_SETTING table successfully.
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
            Dim cmbParam(15) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_CF_SPEEDWAY_ID", SqlDbType.BigInt)
            If _CF_SPEEDWAY_ID IsNot Nothing Then 
                cmbParam(5).Value = _CF_SPEEDWAY_ID.Value
            Else
                cmbParam(5).Value = DBNull.value
            End IF

            cmbParam(6) = New SqlParameter("@_SETTING_LABEL", SqlDbType.VarChar)
            If _SETTING_LABEL.Trim <> "" Then 
                cmbParam(6).Value = _SETTING_LABEL
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_SETTING_DESCRIPTION", SqlDbType.VarChar)
            If _SETTING_DESCRIPTION.Trim <> "" Then 
                cmbParam(7).Value = _SETTING_DESCRIPTION
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_SETTING_SEARCH_MODE", SqlDbType.VarChar)
            cmbParam(8).Value = _SETTING_SEARCH_MODE

            cmbParam(9) = New SqlParameter("@_SETTING_SESSION", SqlDbType.Int)
            cmbParam(9).Value = _SETTING_SESSION

            cmbParam(10) = New SqlParameter("@_SETTING_TAG_POPULATE_ESTIMATE", SqlDbType.Int)
            cmbParam(10).Value = _SETTING_TAG_POPULATE_ESTIMATE

            cmbParam(11) = New SqlParameter("@_SETTING_TIME_CORRECT_ENABLED", SqlDbType.VarChar)
            cmbParam(11).Value = _SETTING_TIME_CORRECT_ENABLED

            cmbParam(12) = New SqlParameter("@_FILTERS_MODE", SqlDbType.VarChar)
            cmbParam(12).Value = _FILTERS_MODE

            cmbParam(13) = New SqlParameter("@_KEEPALIVE_IS_ENABLED", SqlDbType.VarChar)
            cmbParam(13).Value = _KEEPALIVE_IS_ENABLED

            cmbParam(14) = New SqlParameter("@_KEEPALIVE_PERIOD_IN_MS", SqlDbType.Int)
            cmbParam(14).Value = _KEEPALIVE_PERIOD_IN_MS

            cmbParam(15) = New SqlParameter("@_KEEPALIVE_LINK_DOWN_THRESHOLD", SqlDbType.Int)
            cmbParam(15).Value = _KEEPALIVE_LINK_DOWN_THRESHOLD

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY_SETTING by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("cf_speedway_id")) = False Then _cf_speedway_id = Convert.ToInt64(Rdr("cf_speedway_id"))
                        If Convert.IsDBNull(Rdr("setting_label")) = False Then _setting_label = Rdr("setting_label").ToString()
                        If Convert.IsDBNull(Rdr("setting_description")) = False Then _setting_description = Rdr("setting_description").ToString()
                        If Convert.IsDBNull(Rdr("setting_search_mode")) = False Then _setting_search_mode = Rdr("setting_search_mode").ToString()
                        If Convert.IsDBNull(Rdr("setting_session")) = False Then _setting_session = Convert.ToInt32(Rdr("setting_session"))
                        If Convert.IsDBNull(Rdr("setting_tag_populate_estimate")) = False Then _setting_tag_populate_estimate = Convert.ToInt32(Rdr("setting_tag_populate_estimate"))
                        If Convert.IsDBNull(Rdr("setting_time_correct_enabled")) = False Then _setting_time_correct_enabled = Rdr("setting_time_correct_enabled").ToString()
                        If Convert.IsDBNull(Rdr("filters_mode")) = False Then _filters_mode = Rdr("filters_mode").ToString()
                        If Convert.IsDBNull(Rdr("keepalive_is_enabled")) = False Then _keepalive_is_enabled = Rdr("keepalive_is_enabled").ToString()
                        If Convert.IsDBNull(Rdr("keepalive_period_in_ms")) = False Then _keepalive_period_in_ms = Convert.ToInt32(Rdr("keepalive_period_in_ms"))
                        If Convert.IsDBNull(Rdr("keepalive_link_down_threshold")) = False Then _keepalive_link_down_threshold = Convert.ToInt32(Rdr("keepalive_link_down_threshold"))
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


        '/// Returns an indication whether the record of CF_SPEEDWAY_SETTING by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As CfSpeedwaySettingLinqDB
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
                        If Convert.IsDBNull(Rdr("cf_speedway_id")) = False Then _cf_speedway_id = Convert.ToInt64(Rdr("cf_speedway_id"))
                        If Convert.IsDBNull(Rdr("setting_label")) = False Then _setting_label = Rdr("setting_label").ToString()
                        If Convert.IsDBNull(Rdr("setting_description")) = False Then _setting_description = Rdr("setting_description").ToString()
                        If Convert.IsDBNull(Rdr("setting_search_mode")) = False Then _setting_search_mode = Rdr("setting_search_mode").ToString()
                        If Convert.IsDBNull(Rdr("setting_session")) = False Then _setting_session = Convert.ToInt32(Rdr("setting_session"))
                        If Convert.IsDBNull(Rdr("setting_tag_populate_estimate")) = False Then _setting_tag_populate_estimate = Convert.ToInt32(Rdr("setting_tag_populate_estimate"))
                        If Convert.IsDBNull(Rdr("setting_time_correct_enabled")) = False Then _setting_time_correct_enabled = Rdr("setting_time_correct_enabled").ToString()
                        If Convert.IsDBNull(Rdr("filters_mode")) = False Then _filters_mode = Rdr("filters_mode").ToString()
                        If Convert.IsDBNull(Rdr("keepalive_is_enabled")) = False Then _keepalive_is_enabled = Rdr("keepalive_is_enabled").ToString()
                        If Convert.IsDBNull(Rdr("keepalive_period_in_ms")) = False Then _keepalive_period_in_ms = Convert.ToInt32(Rdr("keepalive_period_in_ms"))
                        If Convert.IsDBNull(Rdr("keepalive_link_down_threshold")) = False Then _keepalive_link_down_threshold = Convert.ToInt32(Rdr("keepalive_link_down_threshold"))
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


        'Get Insert Statement for table CF_SPEEDWAY_SETTING
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, CF_SPEEDWAY_ID, SETTING_LABEL, SETTING_DESCRIPTION, SETTING_SEARCH_MODE, SETTING_SESSION, SETTING_TAG_POPULATE_ESTIMATE, SETTING_TIME_CORRECT_ENABLED, FILTERS_MODE, KEEPALIVE_IS_ENABLED, KEEPALIVE_PERIOD_IN_MS, KEEPALIVE_LINK_DOWN_THRESHOLD)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.CF_SPEEDWAY_ID, INSERTED.SETTING_LABEL, INSERTED.SETTING_DESCRIPTION, INSERTED.SETTING_SEARCH_MODE, INSERTED.SETTING_SESSION, INSERTED.SETTING_TAG_POPULATE_ESTIMATE, INSERTED.SETTING_TIME_CORRECT_ENABLED, INSERTED.FILTERS_MODE, INSERTED.KEEPALIVE_IS_ENABLED, INSERTED.KEEPALIVE_PERIOD_IN_MS, INSERTED.KEEPALIVE_LINK_DOWN_THRESHOLD
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_CF_SPEEDWAY_ID" & ", "
                sql += "@_SETTING_LABEL" & ", "
                sql += "@_SETTING_DESCRIPTION" & ", "
                sql += "@_SETTING_SEARCH_MODE" & ", "
                sql += "@_SETTING_SESSION" & ", "
                sql += "@_SETTING_TAG_POPULATE_ESTIMATE" & ", "
                sql += "@_SETTING_TIME_CORRECT_ENABLED" & ", "
                sql += "@_FILTERS_MODE" & ", "
                sql += "@_KEEPALIVE_IS_ENABLED" & ", "
                sql += "@_KEEPALIVE_PERIOD_IN_MS" & ", "
                sql += "@_KEEPALIVE_LINK_DOWN_THRESHOLD"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table CF_SPEEDWAY_SETTING
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "CF_SPEEDWAY_ID = " & "@_CF_SPEEDWAY_ID" & ", "
                Sql += "SETTING_LABEL = " & "@_SETTING_LABEL" & ", "
                Sql += "SETTING_DESCRIPTION = " & "@_SETTING_DESCRIPTION" & ", "
                Sql += "SETTING_SEARCH_MODE = " & "@_SETTING_SEARCH_MODE" & ", "
                Sql += "SETTING_SESSION = " & "@_SETTING_SESSION" & ", "
                Sql += "SETTING_TAG_POPULATE_ESTIMATE = " & "@_SETTING_TAG_POPULATE_ESTIMATE" & ", "
                Sql += "SETTING_TIME_CORRECT_ENABLED = " & "@_SETTING_TIME_CORRECT_ENABLED" & ", "
                Sql += "FILTERS_MODE = " & "@_FILTERS_MODE" & ", "
                Sql += "KEEPALIVE_IS_ENABLED = " & "@_KEEPALIVE_IS_ENABLED" & ", "
                Sql += "KEEPALIVE_PERIOD_IN_MS = " & "@_KEEPALIVE_PERIOD_IN_MS" & ", "
                Sql += "KEEPALIVE_LINK_DOWN_THRESHOLD = " & "@_KEEPALIVE_LINK_DOWN_THRESHOLD" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table CF_SPEEDWAY_SETTING
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table CF_SPEEDWAY_SETTING
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, CF_SPEEDWAY_ID, SETTING_LABEL, SETTING_DESCRIPTION, SETTING_SEARCH_MODE, SETTING_SESSION, SETTING_TAG_POPULATE_ESTIMATE, SETTING_TIME_CORRECT_ENABLED, FILTERS_MODE, KEEPALIVE_IS_ENABLED, KEEPALIVE_PERIOD_IN_MS, KEEPALIVE_LINK_DOWN_THRESHOLD FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

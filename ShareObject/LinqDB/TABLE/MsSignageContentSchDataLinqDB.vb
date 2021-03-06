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
    'Represents a transaction for MS_SIGNAGE_CONTENT_SCH_DATA table LinqDB.
    '[Create by  on March, 23 2015]
    Public Class MsSignageContentSchDataLinqDB
        Public sub MsSignageContentSchDataLinqDB()

        End Sub 
        ' MS_SIGNAGE_CONTENT_SCH_DATA
        Const _tableName As String = "MS_SIGNAGE_CONTENT_SCH_DATA"
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
        Dim _MS_SIGNAGE_TEMPLATE_SCHEDULE_ID As Long = 0
        Dim _SCHEDULE_NAME As String = ""
        Dim _MS_SIGNAGE_CONTENT_TEMPLATE_ID As Long = 0
        Dim _TEMPLATE_NAME As String = ""
        Dim _MS_LED_TV_ID As Long = 0
        Dim _TV_NAME As String = ""
        Dim _IP_ADDRESS As String = ""
        Dim _START_TIME As DateTime = New DateTime(1,1,1)
        Dim _END_TIME As DateTime = New DateTime(1,1,1)

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
        <Column(Storage:="_MS_SIGNAGE_TEMPLATE_SCHEDULE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_SIGNAGE_TEMPLATE_SCHEDULE_ID() As Long
            Get
                Return _MS_SIGNAGE_TEMPLATE_SCHEDULE_ID
            End Get
            Set(ByVal value As Long)
               _MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = value
            End Set
        End Property 
        <Column(Storage:="_SCHEDULE_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SCHEDULE_NAME() As String
            Get
                Return _SCHEDULE_NAME
            End Get
            Set(ByVal value As String)
               _SCHEDULE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_MS_SIGNAGE_CONTENT_TEMPLATE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_SIGNAGE_CONTENT_TEMPLATE_ID() As Long
            Get
                Return _MS_SIGNAGE_CONTENT_TEMPLATE_ID
            End Get
            Set(ByVal value As Long)
               _MS_SIGNAGE_CONTENT_TEMPLATE_ID = value
            End Set
        End Property 
        <Column(Storage:="_TEMPLATE_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property TEMPLATE_NAME() As String
            Get
                Return _TEMPLATE_NAME
            End Get
            Set(ByVal value As String)
               _TEMPLATE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_MS_LED_TV_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_LED_TV_ID() As Long
            Get
                Return _MS_LED_TV_ID
            End Get
            Set(ByVal value As Long)
               _MS_LED_TV_ID = value
            End Set
        End Property 
        <Column(Storage:="_TV_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property TV_NAME() As String
            Get
                Return _TV_NAME
            End Get
            Set(ByVal value As String)
               _TV_NAME = value
            End Set
        End Property 
        <Column(Storage:="_IP_ADDRESS", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property IP_ADDRESS() As String
            Get
                Return _IP_ADDRESS
            End Get
            Set(ByVal value As String)
               _IP_ADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_START_TIME", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property START_TIME() As DateTime
            Get
                Return _START_TIME
            End Get
            Set(ByVal value As DateTime)
               _START_TIME = value
            End Set
        End Property 
        <Column(Storage:="_END_TIME", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property END_TIME() As DateTime
            Get
                Return _END_TIME
            End Get
            Set(ByVal value As DateTime)
               _END_TIME = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = 0
            _SCHEDULE_NAME = ""
            _MS_SIGNAGE_CONTENT_TEMPLATE_ID = 0
            _TEMPLATE_NAME = ""
            _MS_LED_TV_ID = 0
            _TV_NAME = ""
            _IP_ADDRESS = ""
            _START_TIME = New DateTime(1,1,1)
            _END_TIME = New DateTime(1,1,1)
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


        '/// Returns an indication whether the current data is inserted into MS_SIGNAGE_CONTENT_SCH_DATA table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_SIGNAGE_CONTENT_SCH_DATA table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_SIGNAGE_CONTENT_SCH_DATA table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from MS_SIGNAGE_CONTENT_SCH_DATA table successfully.
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


        '/// Returns an indication whether the record of MS_SIGNAGE_CONTENT_SCH_DATA by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_SIGNAGE_CONTENT_SCH_DATA by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsSignageContentSchDataLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of MS_SIGNAGE_CONTENT_SCH_DATA by specified MS_LED_TV_ID_START_TIME key is retrieved successfully.
        '/// <param name=cMS_LED_TV_ID_START_TIME>The MS_LED_TV_ID_START_TIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_LED_TV_ID_START_TIME(cMS_LED_TV_ID As Long, cSTART_TIME As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("MS_LED_TV_ID = " & DB.SetDouble(cMS_LED_TV_ID) & " AND START_TIME = " & DB.SetDateTime(cSTART_TIME), trans)
        End Function

        '/// Returns an duplicate data record of MS_SIGNAGE_CONTENT_SCH_DATA by specified MS_LED_TV_ID_START_TIME key is retrieved successfully.
        '/// <param name=cMS_LED_TV_ID_START_TIME>The MS_LED_TV_ID_START_TIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_LED_TV_ID_START_TIME(cMS_LED_TV_ID As Long, cSTART_TIME As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_LED_TV_ID = " & DB.SetDouble(cMS_LED_TV_ID) & " AND START_TIME = " & DB.SetDateTime(cSTART_TIME) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_SIGNAGE_CONTENT_SCH_DATA by specified END_TIME_MS_LED_TV_ID key is retrieved successfully.
        '/// <param name=cEND_TIME_MS_LED_TV_ID>The END_TIME_MS_LED_TV_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByEND_TIME_MS_LED_TV_ID(cEND_TIME As DateTime, cMS_LED_TV_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("END_TIME = " & DB.SetDateTime(cEND_TIME) & " AND MS_LED_TV_ID = " & DB.SetDouble(cMS_LED_TV_ID), trans)
        End Function

        '/// Returns an duplicate data record of MS_SIGNAGE_CONTENT_SCH_DATA by specified END_TIME_MS_LED_TV_ID key is retrieved successfully.
        '/// <param name=cEND_TIME_MS_LED_TV_ID>The END_TIME_MS_LED_TV_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByEND_TIME_MS_LED_TV_ID(cEND_TIME As DateTime, cMS_LED_TV_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("END_TIME = " & DB.SetDateTime(cEND_TIME) & " AND MS_LED_TV_ID = " & DB.SetDouble(cMS_LED_TV_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_SIGNAGE_CONTENT_SCH_DATA by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_SIGNAGE_CONTENT_SCH_DATA table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_SIGNAGE_CONTENT_SCH_DATA table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_SIGNAGE_CONTENT_SCH_DATA table successfully.
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
            Dim cmbParam(13) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_MS_SIGNAGE_TEMPLATE_SCHEDULE_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _MS_SIGNAGE_TEMPLATE_SCHEDULE_ID

            cmbParam(6) = New SqlParameter("@_SCHEDULE_NAME", SqlDbType.VarChar)
            cmbParam(6).Value = _SCHEDULE_NAME

            cmbParam(7) = New SqlParameter("@_MS_SIGNAGE_CONTENT_TEMPLATE_ID", SqlDbType.BigInt)
            cmbParam(7).Value = _MS_SIGNAGE_CONTENT_TEMPLATE_ID

            cmbParam(8) = New SqlParameter("@_TEMPLATE_NAME", SqlDbType.VarChar)
            cmbParam(8).Value = _TEMPLATE_NAME

            cmbParam(9) = New SqlParameter("@_MS_LED_TV_ID", SqlDbType.BigInt)
            cmbParam(9).Value = _MS_LED_TV_ID

            cmbParam(10) = New SqlParameter("@_TV_NAME", SqlDbType.VarChar)
            cmbParam(10).Value = _TV_NAME

            cmbParam(11) = New SqlParameter("@_IP_ADDRESS", SqlDbType.VarChar)
            cmbParam(11).Value = _IP_ADDRESS

            cmbParam(12) = New SqlParameter("@_START_TIME", SqlDbType.DateTime)
            cmbParam(12).Value = _START_TIME

            cmbParam(13) = New SqlParameter("@_END_TIME", SqlDbType.DateTime)
            cmbParam(13).Value = _END_TIME

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_SIGNAGE_CONTENT_SCH_DATA by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ms_signage_template_schedule_id")) = False Then _ms_signage_template_schedule_id = Convert.ToInt64(Rdr("ms_signage_template_schedule_id"))
                        If Convert.IsDBNull(Rdr("schedule_name")) = False Then _schedule_name = Rdr("schedule_name").ToString()
                        If Convert.IsDBNull(Rdr("ms_signage_content_template_id")) = False Then _ms_signage_content_template_id = Convert.ToInt64(Rdr("ms_signage_content_template_id"))
                        If Convert.IsDBNull(Rdr("template_name")) = False Then _template_name = Rdr("template_name").ToString()
                        If Convert.IsDBNull(Rdr("ms_led_tv_id")) = False Then _ms_led_tv_id = Convert.ToInt64(Rdr("ms_led_tv_id"))
                        If Convert.IsDBNull(Rdr("tv_name")) = False Then _tv_name = Rdr("tv_name").ToString()
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("start_time")) = False Then _start_time = Convert.ToDateTime(Rdr("start_time"))
                        If Convert.IsDBNull(Rdr("end_time")) = False Then _end_time = Convert.ToDateTime(Rdr("end_time"))
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


        '/// Returns an indication whether the record of MS_SIGNAGE_CONTENT_SCH_DATA by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As MsSignageContentSchDataLinqDB
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
                        If Convert.IsDBNull(Rdr("ms_signage_template_schedule_id")) = False Then _ms_signage_template_schedule_id = Convert.ToInt64(Rdr("ms_signage_template_schedule_id"))
                        If Convert.IsDBNull(Rdr("schedule_name")) = False Then _schedule_name = Rdr("schedule_name").ToString()
                        If Convert.IsDBNull(Rdr("ms_signage_content_template_id")) = False Then _ms_signage_content_template_id = Convert.ToInt64(Rdr("ms_signage_content_template_id"))
                        If Convert.IsDBNull(Rdr("template_name")) = False Then _template_name = Rdr("template_name").ToString()
                        If Convert.IsDBNull(Rdr("ms_led_tv_id")) = False Then _ms_led_tv_id = Convert.ToInt64(Rdr("ms_led_tv_id"))
                        If Convert.IsDBNull(Rdr("tv_name")) = False Then _tv_name = Rdr("tv_name").ToString()
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("start_time")) = False Then _start_time = Convert.ToDateTime(Rdr("start_time"))
                        If Convert.IsDBNull(Rdr("end_time")) = False Then _end_time = Convert.ToDateTime(Rdr("end_time"))
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


        'Get Insert Statement for table MS_SIGNAGE_CONTENT_SCH_DATA
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_SIGNAGE_TEMPLATE_SCHEDULE_ID, SCHEDULE_NAME, MS_SIGNAGE_CONTENT_TEMPLATE_ID, TEMPLATE_NAME, MS_LED_TV_ID, TV_NAME, IP_ADDRESS, START_TIME, END_TIME)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MS_SIGNAGE_TEMPLATE_SCHEDULE_ID, INSERTED.SCHEDULE_NAME, INSERTED.MS_SIGNAGE_CONTENT_TEMPLATE_ID, INSERTED.TEMPLATE_NAME, INSERTED.MS_LED_TV_ID, INSERTED.TV_NAME, INSERTED.IP_ADDRESS, INSERTED.START_TIME, INSERTED.END_TIME
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_MS_SIGNAGE_TEMPLATE_SCHEDULE_ID" & ", "
                sql += "@_SCHEDULE_NAME" & ", "
                sql += "@_MS_SIGNAGE_CONTENT_TEMPLATE_ID" & ", "
                sql += "@_TEMPLATE_NAME" & ", "
                sql += "@_MS_LED_TV_ID" & ", "
                sql += "@_TV_NAME" & ", "
                sql += "@_IP_ADDRESS" & ", "
                sql += "@_START_TIME" & ", "
                sql += "@_END_TIME"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_SIGNAGE_CONTENT_SCH_DATA
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = " & "@_MS_SIGNAGE_TEMPLATE_SCHEDULE_ID" & ", "
                Sql += "SCHEDULE_NAME = " & "@_SCHEDULE_NAME" & ", "
                Sql += "MS_SIGNAGE_CONTENT_TEMPLATE_ID = " & "@_MS_SIGNAGE_CONTENT_TEMPLATE_ID" & ", "
                Sql += "TEMPLATE_NAME = " & "@_TEMPLATE_NAME" & ", "
                Sql += "MS_LED_TV_ID = " & "@_MS_LED_TV_ID" & ", "
                Sql += "TV_NAME = " & "@_TV_NAME" & ", "
                Sql += "IP_ADDRESS = " & "@_IP_ADDRESS" & ", "
                Sql += "START_TIME = " & "@_START_TIME" & ", "
                Sql += "END_TIME = " & "@_END_TIME" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_SIGNAGE_CONTENT_SCH_DATA
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_SIGNAGE_CONTENT_SCH_DATA
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_SIGNAGE_TEMPLATE_SCHEDULE_ID, SCHEDULE_NAME, MS_SIGNAGE_CONTENT_TEMPLATE_ID, TEMPLATE_NAME, MS_LED_TV_ID, TV_NAME, IP_ADDRESS, START_TIME, END_TIME FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

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
    'Represents a transaction for CF_SPEEDWAY_GPI table LinqDB.
    '[Create by  on March, 16 2015]
    Public Class CfSpeedwayGpiLinqDB
        Public sub CfSpeedwayGpiLinqDB()

        End Sub 
        ' CF_SPEEDWAY_GPI
        Const _tableName As String = "CF_SPEEDWAY_GPI"
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
        Dim _CF_SPEEDWAY_ID As Long = 0
        Dim _PORT_NUMBER As Long = 0
        Dim _IS_ENABLED As String = ""
        Dim _DEBOUNCE_IN_MS As Long = 0
        Dim _AUTO_START_MODE As  String  = ""
        Dim _AUTO_START_GPI_LEVEL As  String  = ""
        Dim _AUTO_START_FIRST_DELAY As  System.Nullable(Of Long)  = 0
        Dim _AUTO_START_PERIOD As  System.Nullable(Of Long)  = 0
        Dim _AUTO_STOP_MODE As  String  = ""
        Dim _AUTO_STOP_GPI_LEVEL As  String  = ""
        Dim _AUTO_STOP_DURATION As  System.Nullable(Of Long)  = 0
        Dim _BRAND_NAME As String = ""
        Dim _MODEL_NAME As String = ""

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
        <Column(Storage:="_CF_SPEEDWAY_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property CF_SPEEDWAY_ID() As Long
            Get
                Return _CF_SPEEDWAY_ID
            End Get
            Set(ByVal value As Long)
               _CF_SPEEDWAY_ID = value
            End Set
        End Property 
        <Column(Storage:="_PORT_NUMBER", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property PORT_NUMBER() As Long
            Get
                Return _PORT_NUMBER
            End Get
            Set(ByVal value As Long)
               _PORT_NUMBER = value
            End Set
        End Property 
        <Column(Storage:="_IS_ENABLED", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_ENABLED() As String
            Get
                Return _IS_ENABLED
            End Get
            Set(ByVal value As String)
               _IS_ENABLED = value
            End Set
        End Property 
        <Column(Storage:="_DEBOUNCE_IN_MS", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property DEBOUNCE_IN_MS() As Long
            Get
                Return _DEBOUNCE_IN_MS
            End Get
            Set(ByVal value As Long)
               _DEBOUNCE_IN_MS = value
            End Set
        End Property 
        <Column(Storage:="_AUTO_START_MODE", DbType:="VarChar(50)")>  _
        Public Property AUTO_START_MODE() As  String 
            Get
                Return _AUTO_START_MODE
            End Get
            Set(ByVal value As  String )
               _AUTO_START_MODE = value
            End Set
        End Property 
        <Column(Storage:="_AUTO_START_GPI_LEVEL", DbType:="VarChar(5)")>  _
        Public Property AUTO_START_GPI_LEVEL() As  String 
            Get
                Return _AUTO_START_GPI_LEVEL
            End Get
            Set(ByVal value As  String )
               _AUTO_START_GPI_LEVEL = value
            End Set
        End Property 
        <Column(Storage:="_AUTO_START_FIRST_DELAY", DbType:="Int")>  _
        Public Property AUTO_START_FIRST_DELAY() As  System.Nullable(Of Long) 
            Get
                Return _AUTO_START_FIRST_DELAY
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _AUTO_START_FIRST_DELAY = value
            End Set
        End Property 
        <Column(Storage:="_AUTO_START_PERIOD", DbType:="Int")>  _
        Public Property AUTO_START_PERIOD() As  System.Nullable(Of Long) 
            Get
                Return _AUTO_START_PERIOD
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _AUTO_START_PERIOD = value
            End Set
        End Property 
        <Column(Storage:="_AUTO_STOP_MODE", DbType:="VarChar(50)")>  _
        Public Property AUTO_STOP_MODE() As  String 
            Get
                Return _AUTO_STOP_MODE
            End Get
            Set(ByVal value As  String )
               _AUTO_STOP_MODE = value
            End Set
        End Property 
        <Column(Storage:="_AUTO_STOP_GPI_LEVEL", DbType:="VarChar(5)")>  _
        Public Property AUTO_STOP_GPI_LEVEL() As  String 
            Get
                Return _AUTO_STOP_GPI_LEVEL
            End Get
            Set(ByVal value As  String )
               _AUTO_STOP_GPI_LEVEL = value
            End Set
        End Property 
        <Column(Storage:="_AUTO_STOP_DURATION", DbType:="Int")>  _
        Public Property AUTO_STOP_DURATION() As  System.Nullable(Of Long) 
            Get
                Return _AUTO_STOP_DURATION
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _AUTO_STOP_DURATION = value
            End Set
        End Property 
        <Column(Storage:="_BRAND_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property BRAND_NAME() As String
            Get
                Return _BRAND_NAME
            End Get
            Set(ByVal value As String)
               _BRAND_NAME = value
            End Set
        End Property 
        <Column(Storage:="_MODEL_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property MODEL_NAME() As String
            Get
                Return _MODEL_NAME
            End Get
            Set(ByVal value As String)
               _MODEL_NAME = value
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
            _PORT_NUMBER = 0
            _IS_ENABLED = ""
            _DEBOUNCE_IN_MS = 0
            _AUTO_START_MODE = ""
            _AUTO_START_GPI_LEVEL = ""
            _AUTO_START_FIRST_DELAY = 0
            _AUTO_START_PERIOD = 0
            _AUTO_STOP_MODE = ""
            _AUTO_STOP_GPI_LEVEL = ""
            _AUTO_STOP_DURATION = 0
            _BRAND_NAME = ""
            _MODEL_NAME = ""
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


        '/// Returns an indication whether the current data is inserted into CF_SPEEDWAY_GPI table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_SPEEDWAY_GPI table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_SPEEDWAY_GPI table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from CF_SPEEDWAY_GPI table successfully.
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


        '/// Returns an indication whether the record of CF_SPEEDWAY_GPI by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of CF_SPEEDWAY_GPI by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As CfSpeedwayGpiLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY_GPI by specified CF_SPEEDWAY_ID_PORT_NUMBER key is retrieved successfully.
        '/// <param name=cCF_SPEEDWAY_ID_PORT_NUMBER>The CF_SPEEDWAY_ID_PORT_NUMBER key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByCF_SPEEDWAY_ID_PORT_NUMBER(cCF_SPEEDWAY_ID As Long, cPORT_NUMBER As Integer, trans As SQLTransaction) As Boolean
            Return doChkData("CF_SPEEDWAY_ID = " & DB.SetDouble(cCF_SPEEDWAY_ID) & " AND PORT_NUMBER = " & DB.SetDouble(cPORT_NUMBER), trans)
        End Function

        '/// Returns an duplicate data record of CF_SPEEDWAY_GPI by specified CF_SPEEDWAY_ID_PORT_NUMBER key is retrieved successfully.
        '/// <param name=cCF_SPEEDWAY_ID_PORT_NUMBER>The CF_SPEEDWAY_ID_PORT_NUMBER key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByCF_SPEEDWAY_ID_PORT_NUMBER(cCF_SPEEDWAY_ID As Long, cPORT_NUMBER As Integer, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("CF_SPEEDWAY_ID = " & DB.SetDouble(cCF_SPEEDWAY_ID) & " AND PORT_NUMBER = " & DB.SetDouble(cPORT_NUMBER) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY_GPI by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into CF_SPEEDWAY_GPI table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_SPEEDWAY_GPI table successfully.
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


        '/// Returns an indication whether the current data is deleted from CF_SPEEDWAY_GPI table successfully.
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
            Dim cmbParam(17) As SqlParameter
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
            cmbParam(5).Value = _CF_SPEEDWAY_ID

            cmbParam(6) = New SqlParameter("@_PORT_NUMBER", SqlDbType.Int)
            cmbParam(6).Value = _PORT_NUMBER

            cmbParam(7) = New SqlParameter("@_IS_ENABLED", SqlDbType.VarChar)
            cmbParam(7).Value = _IS_ENABLED

            cmbParam(8) = New SqlParameter("@_DEBOUNCE_IN_MS", SqlDbType.Int)
            cmbParam(8).Value = _DEBOUNCE_IN_MS

            cmbParam(9) = New SqlParameter("@_AUTO_START_MODE", SqlDbType.VarChar)
            If _AUTO_START_MODE.Trim <> "" Then 
                cmbParam(9).Value = _AUTO_START_MODE
            Else
                cmbParam(9).Value = DBNull.value
            End If

            cmbParam(10) = New SqlParameter("@_AUTO_START_GPI_LEVEL", SqlDbType.VarChar)
            If _AUTO_START_GPI_LEVEL.Trim <> "" Then 
                cmbParam(10).Value = _AUTO_START_GPI_LEVEL
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_AUTO_START_FIRST_DELAY", SqlDbType.Int)
            If _AUTO_START_FIRST_DELAY IsNot Nothing Then 
                cmbParam(11).Value = _AUTO_START_FIRST_DELAY.Value
            Else
                cmbParam(11).Value = DBNull.value
            End IF

            cmbParam(12) = New SqlParameter("@_AUTO_START_PERIOD", SqlDbType.Int)
            If _AUTO_START_PERIOD IsNot Nothing Then 
                cmbParam(12).Value = _AUTO_START_PERIOD.Value
            Else
                cmbParam(12).Value = DBNull.value
            End IF

            cmbParam(13) = New SqlParameter("@_AUTO_STOP_MODE", SqlDbType.VarChar)
            If _AUTO_STOP_MODE.Trim <> "" Then 
                cmbParam(13).Value = _AUTO_STOP_MODE
            Else
                cmbParam(13).Value = DBNull.value
            End If

            cmbParam(14) = New SqlParameter("@_AUTO_STOP_GPI_LEVEL", SqlDbType.VarChar)
            If _AUTO_STOP_GPI_LEVEL.Trim <> "" Then 
                cmbParam(14).Value = _AUTO_STOP_GPI_LEVEL
            Else
                cmbParam(14).Value = DBNull.value
            End If

            cmbParam(15) = New SqlParameter("@_AUTO_STOP_DURATION", SqlDbType.Int)
            If _AUTO_STOP_DURATION IsNot Nothing Then 
                cmbParam(15).Value = _AUTO_STOP_DURATION.Value
            Else
                cmbParam(15).Value = DBNull.value
            End IF

            cmbParam(16) = New SqlParameter("@_BRAND_NAME", SqlDbType.VarChar)
            cmbParam(16).Value = _BRAND_NAME

            cmbParam(17) = New SqlParameter("@_MODEL_NAME", SqlDbType.VarChar)
            cmbParam(17).Value = _MODEL_NAME

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY_GPI by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("port_number")) = False Then _port_number = Convert.ToInt32(Rdr("port_number"))
                        If Convert.IsDBNull(Rdr("is_enabled")) = False Then _is_enabled = Rdr("is_enabled").ToString()
                        If Convert.IsDBNull(Rdr("debounce_in_ms")) = False Then _debounce_in_ms = Convert.ToInt32(Rdr("debounce_in_ms"))
                        If Convert.IsDBNull(Rdr("auto_start_mode")) = False Then _auto_start_mode = Rdr("auto_start_mode").ToString()
                        If Convert.IsDBNull(Rdr("auto_start_gpi_level")) = False Then _auto_start_gpi_level = Rdr("auto_start_gpi_level").ToString()
                        If Convert.IsDBNull(Rdr("auto_start_first_delay")) = False Then _auto_start_first_delay = Convert.ToInt32(Rdr("auto_start_first_delay"))
                        If Convert.IsDBNull(Rdr("auto_start_period")) = False Then _auto_start_period = Convert.ToInt32(Rdr("auto_start_period"))
                        If Convert.IsDBNull(Rdr("auto_stop_mode")) = False Then _auto_stop_mode = Rdr("auto_stop_mode").ToString()
                        If Convert.IsDBNull(Rdr("auto_stop_gpi_level")) = False Then _auto_stop_gpi_level = Rdr("auto_stop_gpi_level").ToString()
                        If Convert.IsDBNull(Rdr("auto_stop_duration")) = False Then _auto_stop_duration = Convert.ToInt32(Rdr("auto_stop_duration"))
                        If Convert.IsDBNull(Rdr("brand_name")) = False Then _brand_name = Rdr("brand_name").ToString()
                        If Convert.IsDBNull(Rdr("model_name")) = False Then _model_name = Rdr("model_name").ToString()
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


        '/// Returns an indication whether the record of CF_SPEEDWAY_GPI by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As CfSpeedwayGpiLinqDB
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
                        If Convert.IsDBNull(Rdr("port_number")) = False Then _port_number = Convert.ToInt32(Rdr("port_number"))
                        If Convert.IsDBNull(Rdr("is_enabled")) = False Then _is_enabled = Rdr("is_enabled").ToString()
                        If Convert.IsDBNull(Rdr("debounce_in_ms")) = False Then _debounce_in_ms = Convert.ToInt32(Rdr("debounce_in_ms"))
                        If Convert.IsDBNull(Rdr("auto_start_mode")) = False Then _auto_start_mode = Rdr("auto_start_mode").ToString()
                        If Convert.IsDBNull(Rdr("auto_start_gpi_level")) = False Then _auto_start_gpi_level = Rdr("auto_start_gpi_level").ToString()
                        If Convert.IsDBNull(Rdr("auto_start_first_delay")) = False Then _auto_start_first_delay = Convert.ToInt32(Rdr("auto_start_first_delay"))
                        If Convert.IsDBNull(Rdr("auto_start_period")) = False Then _auto_start_period = Convert.ToInt32(Rdr("auto_start_period"))
                        If Convert.IsDBNull(Rdr("auto_stop_mode")) = False Then _auto_stop_mode = Rdr("auto_stop_mode").ToString()
                        If Convert.IsDBNull(Rdr("auto_stop_gpi_level")) = False Then _auto_stop_gpi_level = Rdr("auto_stop_gpi_level").ToString()
                        If Convert.IsDBNull(Rdr("auto_stop_duration")) = False Then _auto_stop_duration = Convert.ToInt32(Rdr("auto_stop_duration"))
                        If Convert.IsDBNull(Rdr("brand_name")) = False Then _brand_name = Rdr("brand_name").ToString()
                        If Convert.IsDBNull(Rdr("model_name")) = False Then _model_name = Rdr("model_name").ToString()
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


        'Get Insert Statement for table CF_SPEEDWAY_GPI
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, CF_SPEEDWAY_ID, PORT_NUMBER, IS_ENABLED, DEBOUNCE_IN_MS, AUTO_START_MODE, AUTO_START_GPI_LEVEL, AUTO_START_FIRST_DELAY, AUTO_START_PERIOD, AUTO_STOP_MODE, AUTO_STOP_GPI_LEVEL, AUTO_STOP_DURATION, BRAND_NAME, MODEL_NAME)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.CF_SPEEDWAY_ID, INSERTED.PORT_NUMBER, INSERTED.IS_ENABLED, INSERTED.DEBOUNCE_IN_MS, INSERTED.AUTO_START_MODE, INSERTED.AUTO_START_GPI_LEVEL, INSERTED.AUTO_START_FIRST_DELAY, INSERTED.AUTO_START_PERIOD, INSERTED.AUTO_STOP_MODE, INSERTED.AUTO_STOP_GPI_LEVEL, INSERTED.AUTO_STOP_DURATION, INSERTED.BRAND_NAME, INSERTED.MODEL_NAME
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_CF_SPEEDWAY_ID" & ", "
                sql += "@_PORT_NUMBER" & ", "
                sql += "@_IS_ENABLED" & ", "
                sql += "@_DEBOUNCE_IN_MS" & ", "
                sql += "@_AUTO_START_MODE" & ", "
                sql += "@_AUTO_START_GPI_LEVEL" & ", "
                sql += "@_AUTO_START_FIRST_DELAY" & ", "
                sql += "@_AUTO_START_PERIOD" & ", "
                sql += "@_AUTO_STOP_MODE" & ", "
                sql += "@_AUTO_STOP_GPI_LEVEL" & ", "
                sql += "@_AUTO_STOP_DURATION" & ", "
                sql += "@_BRAND_NAME" & ", "
                sql += "@_MODEL_NAME"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table CF_SPEEDWAY_GPI
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "CF_SPEEDWAY_ID = " & "@_CF_SPEEDWAY_ID" & ", "
                Sql += "PORT_NUMBER = " & "@_PORT_NUMBER" & ", "
                Sql += "IS_ENABLED = " & "@_IS_ENABLED" & ", "
                Sql += "DEBOUNCE_IN_MS = " & "@_DEBOUNCE_IN_MS" & ", "
                Sql += "AUTO_START_MODE = " & "@_AUTO_START_MODE" & ", "
                Sql += "AUTO_START_GPI_LEVEL = " & "@_AUTO_START_GPI_LEVEL" & ", "
                Sql += "AUTO_START_FIRST_DELAY = " & "@_AUTO_START_FIRST_DELAY" & ", "
                Sql += "AUTO_START_PERIOD = " & "@_AUTO_START_PERIOD" & ", "
                Sql += "AUTO_STOP_MODE = " & "@_AUTO_STOP_MODE" & ", "
                Sql += "AUTO_STOP_GPI_LEVEL = " & "@_AUTO_STOP_GPI_LEVEL" & ", "
                Sql += "AUTO_STOP_DURATION = " & "@_AUTO_STOP_DURATION" & ", "
                Sql += "BRAND_NAME = " & "@_BRAND_NAME" & ", "
                Sql += "MODEL_NAME = " & "@_MODEL_NAME" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table CF_SPEEDWAY_GPI
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table CF_SPEEDWAY_GPI
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, CF_SPEEDWAY_ID, PORT_NUMBER, IS_ENABLED, DEBOUNCE_IN_MS, AUTO_START_MODE, AUTO_START_GPI_LEVEL, AUTO_START_FIRST_DELAY, AUTO_START_PERIOD, AUTO_STOP_MODE, AUTO_STOP_GPI_LEVEL, AUTO_STOP_DURATION, BRAND_NAME, MODEL_NAME FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

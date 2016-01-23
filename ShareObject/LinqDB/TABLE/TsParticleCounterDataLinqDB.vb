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
    'Represents a transaction for TS_PARTICLE_COUNTER_DATA table LinqDB.
    '[Create by  on April, 23 2015]
    Public Class TsParticleCounterDataLinqDB
        Public sub TsParticleCounterDataLinqDB()

        End Sub 
        ' TS_PARTICLE_COUNTER_DATA
        Const _tableName As String = "TS_PARTICLE_COUNTER_DATA"
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
        Dim _MS_PARTICLE_COUNTER_DEVICE_ID As Long = 0
        Dim _IMPORT_TIME As DateTime = New DateTime(1,1,1)
        Dim _LOG_FILE_NAME As String = ""
        Dim _LOG_FILE_BYTE() As Byte
        Dim _COUNTER_MODE As String = ""
        Dim _CHANNEL_0_3 As Long = 0
        Dim _CHANNEL_0_5 As Long = 0
        Dim _CHANNEL_1_0 As Long = 0
        Dim _CHANNEL_2_5 As Long = 0
        Dim _CHANNEL_5_0 As Long = 0
        Dim _CHANNEL_10_0 As Long = 0
        Dim _AIR_TEMPERATURE As Double = 0
        Dim _RELATIVE_HUMIDITY As Double = 0
        Dim _DEWPOINT_TEMPERATURE As Double = 0
        Dim _WET_BULB_TEMPERATURE As Double = 0

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
        <Column(Storage:="_MS_PARTICLE_COUNTER_DEVICE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_PARTICLE_COUNTER_DEVICE_ID() As Long
            Get
                Return _MS_PARTICLE_COUNTER_DEVICE_ID
            End Get
            Set(ByVal value As Long)
               _MS_PARTICLE_COUNTER_DEVICE_ID = value
            End Set
        End Property 
        <Column(Storage:="_IMPORT_TIME", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property IMPORT_TIME() As DateTime
            Get
                Return _IMPORT_TIME
            End Get
            Set(ByVal value As DateTime)
               _IMPORT_TIME = value
            End Set
        End Property 
        <Column(Storage:="_LOG_FILE_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property LOG_FILE_NAME() As String
            Get
                Return _LOG_FILE_NAME
            End Get
            Set(ByVal value As String)
               _LOG_FILE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LOG_FILE_BYTE", DbType:="IMAGE NOT NULL ",CanBeNull:=false)>  _
        Public Property LOG_FILE_BYTE() As Byte()
            Get
                Return _LOG_FILE_BYTE
            End Get
            Set(ByVal value() As Byte)
               _LOG_FILE_BYTE = value
            End Set
        End Property 
        <Column(Storage:="_COUNTER_MODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property COUNTER_MODE() As String
            Get
                Return _COUNTER_MODE
            End Get
            Set(ByVal value As String)
               _COUNTER_MODE = value
            End Set
        End Property 
        <Column(Storage:="_CHANNEL_0_3", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANNEL_0_3() As Long
            Get
                Return _CHANNEL_0_3
            End Get
            Set(ByVal value As Long)
               _CHANNEL_0_3 = value
            End Set
        End Property 
        <Column(Storage:="_CHANNEL_0_5", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANNEL_0_5() As Long
            Get
                Return _CHANNEL_0_5
            End Get
            Set(ByVal value As Long)
               _CHANNEL_0_5 = value
            End Set
        End Property 
        <Column(Storage:="_CHANNEL_1_0", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANNEL_1_0() As Long
            Get
                Return _CHANNEL_1_0
            End Get
            Set(ByVal value As Long)
               _CHANNEL_1_0 = value
            End Set
        End Property 
        <Column(Storage:="_CHANNEL_2_5", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANNEL_2_5() As Long
            Get
                Return _CHANNEL_2_5
            End Get
            Set(ByVal value As Long)
               _CHANNEL_2_5 = value
            End Set
        End Property 
        <Column(Storage:="_CHANNEL_5_0", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANNEL_5_0() As Long
            Get
                Return _CHANNEL_5_0
            End Get
            Set(ByVal value As Long)
               _CHANNEL_5_0 = value
            End Set
        End Property 
        <Column(Storage:="_CHANNEL_10_0", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANNEL_10_0() As Long
            Get
                Return _CHANNEL_10_0
            End Get
            Set(ByVal value As Long)
               _CHANNEL_10_0 = value
            End Set
        End Property 
        <Column(Storage:="_AIR_TEMPERATURE", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property AIR_TEMPERATURE() As Double
            Get
                Return _AIR_TEMPERATURE
            End Get
            Set(ByVal value As Double)
               _AIR_TEMPERATURE = value
            End Set
        End Property 
        <Column(Storage:="_RELATIVE_HUMIDITY", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property RELATIVE_HUMIDITY() As Double
            Get
                Return _RELATIVE_HUMIDITY
            End Get
            Set(ByVal value As Double)
               _RELATIVE_HUMIDITY = value
            End Set
        End Property 
        <Column(Storage:="_DEWPOINT_TEMPERATURE", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property DEWPOINT_TEMPERATURE() As Double
            Get
                Return _DEWPOINT_TEMPERATURE
            End Get
            Set(ByVal value As Double)
               _DEWPOINT_TEMPERATURE = value
            End Set
        End Property 
        <Column(Storage:="_WET_BULB_TEMPERATURE", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property WET_BULB_TEMPERATURE() As Double
            Get
                Return _WET_BULB_TEMPERATURE
            End Get
            Set(ByVal value As Double)
               _WET_BULB_TEMPERATURE = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MS_PARTICLE_COUNTER_DEVICE_ID = 0
            _IMPORT_TIME = New DateTime(1,1,1)
            _LOG_FILE_NAME = ""
             _LOG_FILE_BYTE = Nothing
            _COUNTER_MODE = ""
            _CHANNEL_0_3 = 0
            _CHANNEL_0_5 = 0
            _CHANNEL_1_0 = 0
            _CHANNEL_2_5 = 0
            _CHANNEL_5_0 = 0
            _CHANNEL_10_0 = 0
            _AIR_TEMPERATURE = 0
            _RELATIVE_HUMIDITY = 0
            _DEWPOINT_TEMPERATURE = 0
            _WET_BULB_TEMPERATURE = 0
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


        '/// Returns an indication whether the current data is inserted into TS_PARTICLE_COUNTER_DATA table successfully.
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


        '/// Returns an indication whether the current data is updated to TS_PARTICLE_COUNTER_DATA table successfully.
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


        '/// Returns an indication whether the current data is updated to TS_PARTICLE_COUNTER_DATA table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TS_PARTICLE_COUNTER_DATA table successfully.
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


        '/// Returns an indication whether the record of TS_PARTICLE_COUNTER_DATA by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TS_PARTICLE_COUNTER_DATA by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TsParticleCounterDataLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TS_PARTICLE_COUNTER_DATA by specified COUNTER_MODE_MS_PARTICLE_COUNTER_DEVICE_ID key is retrieved successfully.
        '/// <param name=cCOUNTER_MODE_MS_PARTICLE_COUNTER_DEVICE_ID>The COUNTER_MODE_MS_PARTICLE_COUNTER_DEVICE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByCOUNTER_MODE_MS_PARTICLE_COUNTER_DEVICE_ID(cCOUNTER_MODE As String, cMS_PARTICLE_COUNTER_DEVICE_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("COUNTER_MODE = " & DB.SetString(cCOUNTER_MODE) & " AND MS_PARTICLE_COUNTER_DEVICE_ID = " & DB.SetDouble(cMS_PARTICLE_COUNTER_DEVICE_ID), trans)
        End Function

        '/// Returns an duplicate data record of TS_PARTICLE_COUNTER_DATA by specified COUNTER_MODE_MS_PARTICLE_COUNTER_DEVICE_ID key is retrieved successfully.
        '/// <param name=cCOUNTER_MODE_MS_PARTICLE_COUNTER_DEVICE_ID>The COUNTER_MODE_MS_PARTICLE_COUNTER_DEVICE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByCOUNTER_MODE_MS_PARTICLE_COUNTER_DEVICE_ID(cCOUNTER_MODE As String, cMS_PARTICLE_COUNTER_DEVICE_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("COUNTER_MODE = " & DB.SetString(cCOUNTER_MODE) & " AND MS_PARTICLE_COUNTER_DEVICE_ID = " & DB.SetDouble(cMS_PARTICLE_COUNTER_DEVICE_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_PARTICLE_COUNTER_DATA by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TS_PARTICLE_COUNTER_DATA table successfully.
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


        '/// Returns an indication whether the current data is updated to TS_PARTICLE_COUNTER_DATA table successfully.
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


        '/// Returns an indication whether the current data is deleted from TS_PARTICLE_COUNTER_DATA table successfully.
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
            Dim cmbParam(19) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_MS_PARTICLE_COUNTER_DEVICE_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _MS_PARTICLE_COUNTER_DEVICE_ID

            cmbParam(6) = New SqlParameter("@_IMPORT_TIME", SqlDbType.DateTime)
            cmbParam(6).Value = _IMPORT_TIME

            cmbParam(7) = New SqlParameter("@_LOG_FILE_NAME", SqlDbType.VarChar)
            cmbParam(7).Value = _LOG_FILE_NAME

            cmbParam(8) = New SqlParameter("@_LOG_FILE_BYTE",SqlDbType.Image, _LOG_FILE_BYTE.Length)
            cmbParam(8).Value = _LOG_FILE_BYTE

            cmbParam(9) = New SqlParameter("@_COUNTER_MODE", SqlDbType.VarChar)
            cmbParam(9).Value = _COUNTER_MODE

            cmbParam(10) = New SqlParameter("@_CHANNEL_0_3", SqlDbType.BigInt)
            cmbParam(10).Value = _CHANNEL_0_3

            cmbParam(11) = New SqlParameter("@_CHANNEL_0_5", SqlDbType.BigInt)
            cmbParam(11).Value = _CHANNEL_0_5

            cmbParam(12) = New SqlParameter("@_CHANNEL_1_0", SqlDbType.Int)
            cmbParam(12).Value = _CHANNEL_1_0

            cmbParam(13) = New SqlParameter("@_CHANNEL_2_5", SqlDbType.Int)
            cmbParam(13).Value = _CHANNEL_2_5

            cmbParam(14) = New SqlParameter("@_CHANNEL_5_0", SqlDbType.Int)
            cmbParam(14).Value = _CHANNEL_5_0

            cmbParam(15) = New SqlParameter("@_CHANNEL_10_0", SqlDbType.Int)
            cmbParam(15).Value = _CHANNEL_10_0

            cmbParam(16) = New SqlParameter("@_AIR_TEMPERATURE", SqlDbType.Float)
            cmbParam(16).Value = _AIR_TEMPERATURE

            cmbParam(17) = New SqlParameter("@_RELATIVE_HUMIDITY", SqlDbType.Float)
            cmbParam(17).Value = _RELATIVE_HUMIDITY

            cmbParam(18) = New SqlParameter("@_DEWPOINT_TEMPERATURE", SqlDbType.Float)
            cmbParam(18).Value = _DEWPOINT_TEMPERATURE

            cmbParam(19) = New SqlParameter("@_WET_BULB_TEMPERATURE", SqlDbType.Float)
            cmbParam(19).Value = _WET_BULB_TEMPERATURE

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TS_PARTICLE_COUNTER_DATA by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ms_particle_counter_device_id")) = False Then _ms_particle_counter_device_id = Convert.ToInt64(Rdr("ms_particle_counter_device_id"))
                        If Convert.IsDBNull(Rdr("import_time")) = False Then _import_time = Convert.ToDateTime(Rdr("import_time"))
                        If Convert.IsDBNull(Rdr("log_file_name")) = False Then _log_file_name = Rdr("log_file_name").ToString()
                        If Convert.IsDBNull(Rdr("log_file_byte")) = False Then _log_file_byte = CType(Rdr("log_file_byte"), Byte())
                        If Convert.IsDBNull(Rdr("counter_mode")) = False Then _counter_mode = Rdr("counter_mode").ToString()
                        If Convert.IsDBNull(Rdr("channel_0_3")) = False Then _channel_0_3 = Convert.ToInt64(Rdr("channel_0_3"))
                        If Convert.IsDBNull(Rdr("channel_0_5")) = False Then _channel_0_5 = Convert.ToInt64(Rdr("channel_0_5"))
                        If Convert.IsDBNull(Rdr("channel_1_0")) = False Then _channel_1_0 = Convert.ToInt32(Rdr("channel_1_0"))
                        If Convert.IsDBNull(Rdr("channel_2_5")) = False Then _channel_2_5 = Convert.ToInt32(Rdr("channel_2_5"))
                        If Convert.IsDBNull(Rdr("channel_5_0")) = False Then _channel_5_0 = Convert.ToInt32(Rdr("channel_5_0"))
                        If Convert.IsDBNull(Rdr("channel_10_0")) = False Then _channel_10_0 = Convert.ToInt32(Rdr("channel_10_0"))
                        If Convert.IsDBNull(Rdr("air_temperature")) = False Then _air_temperature = Convert.ToDouble(Rdr("air_temperature"))
                        If Convert.IsDBNull(Rdr("relative_humidity")) = False Then _relative_humidity = Convert.ToDouble(Rdr("relative_humidity"))
                        If Convert.IsDBNull(Rdr("dewpoint_temperature")) = False Then _dewpoint_temperature = Convert.ToDouble(Rdr("dewpoint_temperature"))
                        If Convert.IsDBNull(Rdr("wet_bulb_temperature")) = False Then _wet_bulb_temperature = Convert.ToDouble(Rdr("wet_bulb_temperature"))
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


        '/// Returns an indication whether the record of TS_PARTICLE_COUNTER_DATA by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TsParticleCounterDataLinqDB
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
                        If Convert.IsDBNull(Rdr("ms_particle_counter_device_id")) = False Then _ms_particle_counter_device_id = Convert.ToInt64(Rdr("ms_particle_counter_device_id"))
                        If Convert.IsDBNull(Rdr("import_time")) = False Then _import_time = Convert.ToDateTime(Rdr("import_time"))
                        If Convert.IsDBNull(Rdr("log_file_name")) = False Then _log_file_name = Rdr("log_file_name").ToString()
                        If Convert.IsDBNull(Rdr("log_file_byte")) = False Then _log_file_byte = CType(Rdr("log_file_byte"), Byte())
                        If Convert.IsDBNull(Rdr("counter_mode")) = False Then _counter_mode = Rdr("counter_mode").ToString()
                        If Convert.IsDBNull(Rdr("channel_0_3")) = False Then _channel_0_3 = Convert.ToInt64(Rdr("channel_0_3"))
                        If Convert.IsDBNull(Rdr("channel_0_5")) = False Then _channel_0_5 = Convert.ToInt64(Rdr("channel_0_5"))
                        If Convert.IsDBNull(Rdr("channel_1_0")) = False Then _channel_1_0 = Convert.ToInt32(Rdr("channel_1_0"))
                        If Convert.IsDBNull(Rdr("channel_2_5")) = False Then _channel_2_5 = Convert.ToInt32(Rdr("channel_2_5"))
                        If Convert.IsDBNull(Rdr("channel_5_0")) = False Then _channel_5_0 = Convert.ToInt32(Rdr("channel_5_0"))
                        If Convert.IsDBNull(Rdr("channel_10_0")) = False Then _channel_10_0 = Convert.ToInt32(Rdr("channel_10_0"))
                        If Convert.IsDBNull(Rdr("air_temperature")) = False Then _air_temperature = Convert.ToDouble(Rdr("air_temperature"))
                        If Convert.IsDBNull(Rdr("relative_humidity")) = False Then _relative_humidity = Convert.ToDouble(Rdr("relative_humidity"))
                        If Convert.IsDBNull(Rdr("dewpoint_temperature")) = False Then _dewpoint_temperature = Convert.ToDouble(Rdr("dewpoint_temperature"))
                        If Convert.IsDBNull(Rdr("wet_bulb_temperature")) = False Then _wet_bulb_temperature = Convert.ToDouble(Rdr("wet_bulb_temperature"))
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


        'Get Insert Statement for table TS_PARTICLE_COUNTER_DATA
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_PARTICLE_COUNTER_DEVICE_ID, IMPORT_TIME, LOG_FILE_NAME, LOG_FILE_BYTE, COUNTER_MODE, CHANNEL_0_3, CHANNEL_0_5, CHANNEL_1_0, CHANNEL_2_5, CHANNEL_5_0, CHANNEL_10_0, AIR_TEMPERATURE, RELATIVE_HUMIDITY, DEWPOINT_TEMPERATURE, WET_BULB_TEMPERATURE)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MS_PARTICLE_COUNTER_DEVICE_ID, INSERTED.IMPORT_TIME, INSERTED.LOG_FILE_NAME, INSERTED.LOG_FILE_BYTE, INSERTED.COUNTER_MODE, INSERTED.CHANNEL_0_3, INSERTED.CHANNEL_0_5, INSERTED.CHANNEL_1_0, INSERTED.CHANNEL_2_5, INSERTED.CHANNEL_5_0, INSERTED.CHANNEL_10_0, INSERTED.AIR_TEMPERATURE, INSERTED.RELATIVE_HUMIDITY, INSERTED.DEWPOINT_TEMPERATURE, INSERTED.WET_BULB_TEMPERATURE
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_MS_PARTICLE_COUNTER_DEVICE_ID" & ", "
                sql += "@_IMPORT_TIME" & ", "
                sql += "@_LOG_FILE_NAME" & ", "
                sql += "@_LOG_FILE_BYTE" & ", "
                sql += "@_COUNTER_MODE" & ", "
                sql += "@_CHANNEL_0_3" & ", "
                sql += "@_CHANNEL_0_5" & ", "
                sql += "@_CHANNEL_1_0" & ", "
                sql += "@_CHANNEL_2_5" & ", "
                sql += "@_CHANNEL_5_0" & ", "
                sql += "@_CHANNEL_10_0" & ", "
                sql += "@_AIR_TEMPERATURE" & ", "
                sql += "@_RELATIVE_HUMIDITY" & ", "
                sql += "@_DEWPOINT_TEMPERATURE" & ", "
                sql += "@_WET_BULB_TEMPERATURE"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TS_PARTICLE_COUNTER_DATA
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_PARTICLE_COUNTER_DEVICE_ID = " & "@_MS_PARTICLE_COUNTER_DEVICE_ID" & ", "
                Sql += "IMPORT_TIME = " & "@_IMPORT_TIME" & ", "
                Sql += "LOG_FILE_NAME = " & "@_LOG_FILE_NAME" & ", "
                Sql += "LOG_FILE_BYTE = " & "@_LOG_FILE_BYTE" & ", "
                Sql += "COUNTER_MODE = " & "@_COUNTER_MODE" & ", "
                Sql += "CHANNEL_0_3 = " & "@_CHANNEL_0_3" & ", "
                Sql += "CHANNEL_0_5 = " & "@_CHANNEL_0_5" & ", "
                Sql += "CHANNEL_1_0 = " & "@_CHANNEL_1_0" & ", "
                Sql += "CHANNEL_2_5 = " & "@_CHANNEL_2_5" & ", "
                Sql += "CHANNEL_5_0 = " & "@_CHANNEL_5_0" & ", "
                Sql += "CHANNEL_10_0 = " & "@_CHANNEL_10_0" & ", "
                Sql += "AIR_TEMPERATURE = " & "@_AIR_TEMPERATURE" & ", "
                Sql += "RELATIVE_HUMIDITY = " & "@_RELATIVE_HUMIDITY" & ", "
                Sql += "DEWPOINT_TEMPERATURE = " & "@_DEWPOINT_TEMPERATURE" & ", "
                Sql += "WET_BULB_TEMPERATURE = " & "@_WET_BULB_TEMPERATURE" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TS_PARTICLE_COUNTER_DATA
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TS_PARTICLE_COUNTER_DATA
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_PARTICLE_COUNTER_DEVICE_ID, IMPORT_TIME, LOG_FILE_NAME, LOG_FILE_BYTE, COUNTER_MODE, CHANNEL_0_3, CHANNEL_0_5, CHANNEL_1_0, CHANNEL_2_5, CHANNEL_5_0, CHANNEL_10_0, AIR_TEMPERATURE, RELATIVE_HUMIDITY, DEWPOINT_TEMPERATURE, WET_BULB_TEMPERATURE FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

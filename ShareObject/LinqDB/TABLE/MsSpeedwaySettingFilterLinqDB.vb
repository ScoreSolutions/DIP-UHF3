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
    'Represents a transaction for MS_SPEEDWAY_SETTING_FILTER table LinqDB.
    '[Create by  on January, 21 2015]
    Public Class MsSpeedwaySettingFilterLinqDB
        Public sub MsSpeedwaySettingFilterLinqDB()

        End Sub 
        ' MS_SPEEDWAY_SETTING_FILTER
        Const _tableName As String = "MS_SPEEDWAY_SETTING_FILTER"
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
        Dim _MS_SPEEDWAY_SETTING_ID As  System.Nullable(Of Long)  = 0
        Dim _TAG_FILTER_NO As Long = 0
        Dim _MEMORY_BANK As String = "None"
        Dim _BIT_POINTER As Long = 0
        Dim _BIT_COUNT As Long = 0
        Dim _TAG_MASK As  String  = ""
        Dim _FILTER_OP As String = "None"

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
        <Column(Storage:="_MS_SPEEDWAY_SETTING_ID", DbType:="BigInt")>  _
        Public Property MS_SPEEDWAY_SETTING_ID() As  System.Nullable(Of Long) 
            Get
                Return _MS_SPEEDWAY_SETTING_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MS_SPEEDWAY_SETTING_ID = value
            End Set
        End Property 
        <Column(Storage:="_TAG_FILTER_NO", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property TAG_FILTER_NO() As Long
            Get
                Return _TAG_FILTER_NO
            End Get
            Set(ByVal value As Long)
               _TAG_FILTER_NO = value
            End Set
        End Property 
        <Column(Storage:="_MEMORY_BANK", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property MEMORY_BANK() As String
            Get
                Return _MEMORY_BANK
            End Get
            Set(ByVal value As String)
               _MEMORY_BANK = value
            End Set
        End Property 
        <Column(Storage:="_BIT_POINTER", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property BIT_POINTER() As Long
            Get
                Return _BIT_POINTER
            End Get
            Set(ByVal value As Long)
               _BIT_POINTER = value
            End Set
        End Property 
        <Column(Storage:="_BIT_COUNT", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property BIT_COUNT() As Long
            Get
                Return _BIT_COUNT
            End Get
            Set(ByVal value As Long)
               _BIT_COUNT = value
            End Set
        End Property 
        <Column(Storage:="_TAG_MASK", DbType:="VarChar(50)")>  _
        Public Property TAG_MASK() As  String 
            Get
                Return _TAG_MASK
            End Get
            Set(ByVal value As  String )
               _TAG_MASK = value
            End Set
        End Property 
        <Column(Storage:="_FILTER_OP", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property FILTER_OP() As String
            Get
                Return _FILTER_OP
            End Get
            Set(ByVal value As String)
               _FILTER_OP = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MS_SPEEDWAY_SETTING_ID = 0
            _TAG_FILTER_NO = 0
            _MEMORY_BANK = ""
            _BIT_POINTER = 0
            _BIT_COUNT = 0
            _TAG_MASK = ""
            _FILTER_OP = ""
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


        '/// Returns an indication whether the current data is inserted into MS_SPEEDWAY_SETTING_FILTER table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_SPEEDWAY_SETTING_FILTER table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_SPEEDWAY_SETTING_FILTER table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from MS_SPEEDWAY_SETTING_FILTER table successfully.
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


        '/// Returns an indication whether the record of MS_SPEEDWAY_SETTING_FILTER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_SPEEDWAY_SETTING_FILTER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsSpeedwaySettingFilterLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of MS_SPEEDWAY_SETTING_FILTER by specified MS_SPEEDWAY_SETTING_ID_TAG_FILTER_NO key is retrieved successfully.
        '/// <param name=cMS_SPEEDWAY_SETTING_ID_TAG_FILTER_NO>The MS_SPEEDWAY_SETTING_ID_TAG_FILTER_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_SPEEDWAY_SETTING_ID_TAG_FILTER_NO(cMS_SPEEDWAY_SETTING_ID As Long, cTAG_FILTER_NO As Integer, trans As SQLTransaction) As Boolean
            Return doChkData("MS_SPEEDWAY_SETTING_ID = " & DB.SetDouble(cMS_SPEEDWAY_SETTING_ID) & " AND TAG_FILTER_NO = " & DB.SetDouble(cTAG_FILTER_NO), trans)
        End Function

        '/// Returns an duplicate data record of MS_SPEEDWAY_SETTING_FILTER by specified MS_SPEEDWAY_SETTING_ID_TAG_FILTER_NO key is retrieved successfully.
        '/// <param name=cMS_SPEEDWAY_SETTING_ID_TAG_FILTER_NO>The MS_SPEEDWAY_SETTING_ID_TAG_FILTER_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_SPEEDWAY_SETTING_ID_TAG_FILTER_NO(cMS_SPEEDWAY_SETTING_ID As Long, cTAG_FILTER_NO As Integer, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_SPEEDWAY_SETTING_ID = " & DB.SetDouble(cMS_SPEEDWAY_SETTING_ID) & " AND TAG_FILTER_NO = " & DB.SetDouble(cTAG_FILTER_NO) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_SPEEDWAY_SETTING_FILTER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_SPEEDWAY_SETTING_FILTER table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_SPEEDWAY_SETTING_FILTER table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_SPEEDWAY_SETTING_FILTER table successfully.
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
            Dim cmbParam(11) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_MS_SPEEDWAY_SETTING_ID", SqlDbType.BigInt)
            If _MS_SPEEDWAY_SETTING_ID IsNot Nothing Then 
                cmbParam(5).Value = _MS_SPEEDWAY_SETTING_ID.Value
            Else
                cmbParam(5).Value = DBNull.value
            End IF

            cmbParam(6) = New SqlParameter("@_TAG_FILTER_NO", SqlDbType.Int)
            cmbParam(6).Value = _TAG_FILTER_NO

            cmbParam(7) = New SqlParameter("@_MEMORY_BANK", SqlDbType.VarChar)
            cmbParam(7).Value = _MEMORY_BANK

            cmbParam(8) = New SqlParameter("@_BIT_POINTER", SqlDbType.Int)
            cmbParam(8).Value = _BIT_POINTER

            cmbParam(9) = New SqlParameter("@_BIT_COUNT", SqlDbType.Int)
            cmbParam(9).Value = _BIT_COUNT

            cmbParam(10) = New SqlParameter("@_TAG_MASK", SqlDbType.VarChar)
            If _TAG_MASK.Trim <> "" Then 
                cmbParam(10).Value = _TAG_MASK
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_FILTER_OP", SqlDbType.VarChar)
            cmbParam(11).Value = _FILTER_OP

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_SPEEDWAY_SETTING_FILTER by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ms_speedway_setting_id")) = False Then _ms_speedway_setting_id = Convert.ToInt64(Rdr("ms_speedway_setting_id"))
                        If Convert.IsDBNull(Rdr("tag_filter_no")) = False Then _tag_filter_no = Convert.ToInt32(Rdr("tag_filter_no"))
                        If Convert.IsDBNull(Rdr("memory_bank")) = False Then _memory_bank = Rdr("memory_bank").ToString()
                        If Convert.IsDBNull(Rdr("bit_pointer")) = False Then _bit_pointer = Convert.ToInt32(Rdr("bit_pointer"))
                        If Convert.IsDBNull(Rdr("bit_count")) = False Then _bit_count = Convert.ToInt32(Rdr("bit_count"))
                        If Convert.IsDBNull(Rdr("tag_mask")) = False Then _tag_mask = Rdr("tag_mask").ToString()
                        If Convert.IsDBNull(Rdr("filter_op")) = False Then _filter_op = Rdr("filter_op").ToString()
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


        '/// Returns an indication whether the record of MS_SPEEDWAY_SETTING_FILTER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As MsSpeedwaySettingFilterLinqDB
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
                        If Convert.IsDBNull(Rdr("ms_speedway_setting_id")) = False Then _ms_speedway_setting_id = Convert.ToInt64(Rdr("ms_speedway_setting_id"))
                        If Convert.IsDBNull(Rdr("tag_filter_no")) = False Then _tag_filter_no = Convert.ToInt32(Rdr("tag_filter_no"))
                        If Convert.IsDBNull(Rdr("memory_bank")) = False Then _memory_bank = Rdr("memory_bank").ToString()
                        If Convert.IsDBNull(Rdr("bit_pointer")) = False Then _bit_pointer = Convert.ToInt32(Rdr("bit_pointer"))
                        If Convert.IsDBNull(Rdr("bit_count")) = False Then _bit_count = Convert.ToInt32(Rdr("bit_count"))
                        If Convert.IsDBNull(Rdr("tag_mask")) = False Then _tag_mask = Rdr("tag_mask").ToString()
                        If Convert.IsDBNull(Rdr("filter_op")) = False Then _filter_op = Rdr("filter_op").ToString()
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


        'Get Insert Statement for table MS_SPEEDWAY_SETTING_FILTER
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_SPEEDWAY_SETTING_ID, TAG_FILTER_NO, MEMORY_BANK, BIT_POINTER, BIT_COUNT, TAG_MASK, FILTER_OP)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MS_SPEEDWAY_SETTING_ID, INSERTED.TAG_FILTER_NO, INSERTED.MEMORY_BANK, INSERTED.BIT_POINTER, INSERTED.BIT_COUNT, INSERTED.TAG_MASK, INSERTED.FILTER_OP
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_MS_SPEEDWAY_SETTING_ID" & ", "
                sql += "@_TAG_FILTER_NO" & ", "
                sql += "@_MEMORY_BANK" & ", "
                sql += "@_BIT_POINTER" & ", "
                sql += "@_BIT_COUNT" & ", "
                sql += "@_TAG_MASK" & ", "
                sql += "@_FILTER_OP"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_SPEEDWAY_SETTING_FILTER
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_SPEEDWAY_SETTING_ID = " & "@_MS_SPEEDWAY_SETTING_ID" & ", "
                Sql += "TAG_FILTER_NO = " & "@_TAG_FILTER_NO" & ", "
                Sql += "MEMORY_BANK = " & "@_MEMORY_BANK" & ", "
                Sql += "BIT_POINTER = " & "@_BIT_POINTER" & ", "
                Sql += "BIT_COUNT = " & "@_BIT_COUNT" & ", "
                Sql += "TAG_MASK = " & "@_TAG_MASK" & ", "
                Sql += "FILTER_OP = " & "@_FILTER_OP" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_SPEEDWAY_SETTING_FILTER
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_SPEEDWAY_SETTING_FILTER
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_SPEEDWAY_SETTING_ID, TAG_FILTER_NO, MEMORY_BANK, BIT_POINTER, BIT_COUNT, TAG_MASK, FILTER_OP FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

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
    'Represents a transaction for TB_FILEBORROW table LinqDB.
    '[Create by  on June, 5 2015]
    Public Class TbFileborrowLinqDB
        Public sub TbFileborrowLinqDB()

        End Sub 
        ' TB_FILEBORROW
        Const _tableName As String = "TB_FILEBORROW"
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
        Dim _FILEBORROW_CODE As  String  = ""
        Dim _RESERVE_JOB_ID As  System.Nullable(Of Long)  = 0
        Dim _BORROWER_ID As  String  = ""
        Dim _BORROWERNAME As  String  = ""
        Dim _BORROWERSTATUS As  String  = ""
        Dim _BORROWERDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _CREATEBY As  String  = ""
        Dim _CREATEON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATEBY As  String  = ""
        Dim _UPDATEON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _TB_FILELOCATION_ID As  System.Nullable(Of Long)  = 0
        Dim _IS_SEND_COMPLETE As  System.Nullable(Of Char)  = ""
        Dim _SEND_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

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
        <Column(Storage:="_FILEBORROW_CODE", DbType:="VarChar(50)")>  _
        Public Property FILEBORROW_CODE() As  String 
            Get
                Return _FILEBORROW_CODE
            End Get
            Set(ByVal value As  String )
               _FILEBORROW_CODE = value
            End Set
        End Property 
        <Column(Storage:="_RESERVE_JOB_ID", DbType:="BigInt")>  _
        Public Property RESERVE_JOB_ID() As  System.Nullable(Of Long) 
            Get
                Return _RESERVE_JOB_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _RESERVE_JOB_ID = value
            End Set
        End Property 
        <Column(Storage:="_BORROWER_ID", DbType:="VarChar(50)")>  _
        Public Property BORROWER_ID() As  String 
            Get
                Return _BORROWER_ID
            End Get
            Set(ByVal value As  String )
               _BORROWER_ID = value
            End Set
        End Property 
        <Column(Storage:="_BORROWERNAME", DbType:="VarChar(200)")>  _
        Public Property BORROWERNAME() As  String 
            Get
                Return _BORROWERNAME
            End Get
            Set(ByVal value As  String )
               _BORROWERNAME = value
            End Set
        End Property 
        <Column(Storage:="_BORROWERSTATUS", DbType:="VarChar(50)")>  _
        Public Property BORROWERSTATUS() As  String 
            Get
                Return _BORROWERSTATUS
            End Get
            Set(ByVal value As  String )
               _BORROWERSTATUS = value
            End Set
        End Property 
        <Column(Storage:="_BORROWERDATE", DbType:="DateTime")>  _
        Public Property BORROWERDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _BORROWERDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _BORROWERDATE = value
            End Set
        End Property 
        <Column(Storage:="_CREATEBY", DbType:="VarChar(50)")>  _
        Public Property CREATEBY() As  String 
            Get
                Return _CREATEBY
            End Get
            Set(ByVal value As  String )
               _CREATEBY = value
            End Set
        End Property 
        <Column(Storage:="_CREATEON", DbType:="DateTime")>  _
        Public Property CREATEON() As  System.Nullable(Of DateTime) 
            Get
                Return _CREATEON
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _CREATEON = value
            End Set
        End Property 
        <Column(Storage:="_UPDATEBY", DbType:="VarChar(50)")>  _
        Public Property UPDATEBY() As  String 
            Get
                Return _UPDATEBY
            End Get
            Set(ByVal value As  String )
               _UPDATEBY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATEON", DbType:="DateTime")>  _
        Public Property UPDATEON() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATEON
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATEON = value
            End Set
        End Property 
        <Column(Storage:="_TB_FILELOCATION_ID", DbType:="BigInt")>  _
        Public Property TB_FILELOCATION_ID() As  System.Nullable(Of Long) 
            Get
                Return _TB_FILELOCATION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _TB_FILELOCATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_IS_SEND_COMPLETE", DbType:="Char(1)")>  _
        Public Property IS_SEND_COMPLETE() As  System.Nullable(Of Char) 
            Get
                Return _IS_SEND_COMPLETE
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _IS_SEND_COMPLETE = value
            End Set
        End Property 
        <Column(Storage:="_SEND_TIME", DbType:="DateTime")>  _
        Public Property SEND_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _SEND_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _SEND_TIME = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _FILEBORROW_CODE = ""
            _RESERVE_JOB_ID = 0
            _BORROWER_ID = ""
            _BORROWERNAME = ""
            _BORROWERSTATUS = ""
            _BORROWERDATE = New DateTime(1,1,1)
            _CREATEBY = ""
            _CREATEON = New DateTime(1,1,1)
            _UPDATEBY = ""
            _UPDATEON = New DateTime(1,1,1)
            _TB_FILELOCATION_ID = 0
            _IS_SEND_COMPLETE = ""
            _SEND_TIME = New DateTime(1,1,1)
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


        '/// Returns an indication whether the current data is inserted into TB_FILEBORROW table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _ID = DB.GetNextID("ID",tableName, trans)
                _CreateBy = LoginName
                _Createon = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TB_FILEBORROW table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _UpdateBy = LoginName
                _Updateon = DateTime.Now
                Return doUpdate("ID = " & DB.SetDouble(_ID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TB_FILEBORROW table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_FILEBORROW table successfully.
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


        '/// Returns an indication whether the record of TB_FILEBORROW by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_FILEBORROW by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbFileborrowLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_FILEBORROW by specified FILEBORROW_CODE key is retrieved successfully.
        '/// <param name=cFILEBORROW_CODE>The FILEBORROW_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByFILEBORROW_CODE(cFILEBORROW_CODE As String, trans As SQLTransaction) As Boolean
            Return doChkData("FILEBORROW_CODE = " & DB.SetString(cFILEBORROW_CODE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_FILEBORROW by specified FILEBORROW_CODE key is retrieved successfully.
        '/// <param name=cFILEBORROW_CODE>The FILEBORROW_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByFILEBORROW_CODE(cFILEBORROW_CODE As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("FILEBORROW_CODE = " & DB.SetString(cFILEBORROW_CODE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_FILEBORROW by specified BORROWERDATE key is retrieved successfully.
        '/// <param name=cBORROWERDATE>The BORROWERDATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByBORROWERDATE(cBORROWERDATE As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("BORROWERDATE = " & DB.SetDateTime(cBORROWERDATE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_FILEBORROW by specified BORROWERDATE key is retrieved successfully.
        '/// <param name=cBORROWERDATE>The BORROWERDATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByBORROWERDATE(cBORROWERDATE As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("BORROWERDATE = " & DB.SetDateTime(cBORROWERDATE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_FILEBORROW by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_FILEBORROW table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_FILEBORROW table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_FILEBORROW table successfully.
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

            cmbParam(1) = New SqlParameter("@_FILEBORROW_CODE", SqlDbType.VarChar)
            If _FILEBORROW_CODE.Trim <> "" Then 
                cmbParam(1).Value = _FILEBORROW_CODE
            Else
                cmbParam(1).Value = DBNull.value
            End If

            cmbParam(2) = New SqlParameter("@_RESERVE_JOB_ID", SqlDbType.BigInt)
            If _RESERVE_JOB_ID IsNot Nothing Then 
                cmbParam(2).Value = _RESERVE_JOB_ID.Value
            Else
                cmbParam(2).Value = DBNull.value
            End IF

            cmbParam(3) = New SqlParameter("@_BORROWER_ID", SqlDbType.VarChar)
            If _BORROWER_ID.Trim <> "" Then 
                cmbParam(3).Value = _BORROWER_ID
            Else
                cmbParam(3).Value = DBNull.value
            End If

            cmbParam(4) = New SqlParameter("@_BORROWERNAME", SqlDbType.VarChar)
            If _BORROWERNAME.Trim <> "" Then 
                cmbParam(4).Value = _BORROWERNAME
            Else
                cmbParam(4).Value = DBNull.value
            End If

            cmbParam(5) = New SqlParameter("@_BORROWERSTATUS", SqlDbType.VarChar)
            If _BORROWERSTATUS.Trim <> "" Then 
                cmbParam(5).Value = _BORROWERSTATUS
            Else
                cmbParam(5).Value = DBNull.value
            End If

            cmbParam(6) = New SqlParameter("@_BORROWERDATE", SqlDbType.DateTime)
            If _BORROWERDATE.Value.Year > 1 Then 
                cmbParam(6).Value = _BORROWERDATE.Value
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_CREATEBY", SqlDbType.VarChar)
            If _CREATEBY.Trim <> "" Then 
                cmbParam(7).Value = _CREATEBY
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_CREATEON", SqlDbType.DateTime)
            If _CREATEON.Value.Year > 1 Then 
                cmbParam(8).Value = _CREATEON.Value
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_UPDATEBY", SqlDbType.VarChar)
            If _UPDATEBY.Trim <> "" Then 
                cmbParam(9).Value = _UPDATEBY
            Else
                cmbParam(9).Value = DBNull.value
            End If

            cmbParam(10) = New SqlParameter("@_UPDATEON", SqlDbType.DateTime)
            If _UPDATEON.Value.Year > 1 Then 
                cmbParam(10).Value = _UPDATEON.Value
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_TB_FILELOCATION_ID", SqlDbType.BigInt)
            If _TB_FILELOCATION_ID IsNot Nothing Then 
                cmbParam(11).Value = _TB_FILELOCATION_ID.Value
            Else
                cmbParam(11).Value = DBNull.value
            End IF

            cmbParam(12) = New SqlParameter("@_IS_SEND_COMPLETE", SqlDbType.Char)
            If _IS_SEND_COMPLETE.Value <> "" Then 
                cmbParam(12).Value = _IS_SEND_COMPLETE.Value
            Else
                cmbParam(12).Value = DBNull.value
            End IF

            cmbParam(13) = New SqlParameter("@_SEND_TIME", SqlDbType.DateTime)
            If _SEND_TIME.Value.Year > 1 Then 
                cmbParam(13).Value = _SEND_TIME.Value
            Else
                cmbParam(13).Value = DBNull.value
            End If

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_FILEBORROW by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("fileborrow_code")) = False Then _fileborrow_code = Rdr("fileborrow_code").ToString()
                        If Convert.IsDBNull(Rdr("reserve_job_id")) = False Then _reserve_job_id = Convert.ToInt64(Rdr("reserve_job_id"))
                        If Convert.IsDBNull(Rdr("borrower_id")) = False Then _borrower_id = Rdr("borrower_id").ToString()
                        If Convert.IsDBNull(Rdr("borrowername")) = False Then _borrowername = Rdr("borrowername").ToString()
                        If Convert.IsDBNull(Rdr("borrowerstatus")) = False Then _borrowerstatus = Rdr("borrowerstatus").ToString()
                        If Convert.IsDBNull(Rdr("borrowerdate")) = False Then _borrowerdate = Convert.ToDateTime(Rdr("borrowerdate"))
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
                        If Convert.IsDBNull(Rdr("tb_filelocation_id")) = False Then _tb_filelocation_id = Convert.ToInt64(Rdr("tb_filelocation_id"))
                        If Convert.IsDBNull(Rdr("is_send_complete")) = False Then _is_send_complete = Rdr("is_send_complete").ToString()
                        If Convert.IsDBNull(Rdr("send_time")) = False Then _send_time = Convert.ToDateTime(Rdr("send_time"))
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


        '/// Returns an indication whether the record of TB_FILEBORROW by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbFileborrowLinqDB
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
                        If Convert.IsDBNull(Rdr("fileborrow_code")) = False Then _fileborrow_code = Rdr("fileborrow_code").ToString()
                        If Convert.IsDBNull(Rdr("reserve_job_id")) = False Then _reserve_job_id = Convert.ToInt64(Rdr("reserve_job_id"))
                        If Convert.IsDBNull(Rdr("borrower_id")) = False Then _borrower_id = Rdr("borrower_id").ToString()
                        If Convert.IsDBNull(Rdr("borrowername")) = False Then _borrowername = Rdr("borrowername").ToString()
                        If Convert.IsDBNull(Rdr("borrowerstatus")) = False Then _borrowerstatus = Rdr("borrowerstatus").ToString()
                        If Convert.IsDBNull(Rdr("borrowerdate")) = False Then _borrowerdate = Convert.ToDateTime(Rdr("borrowerdate"))
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
                        If Convert.IsDBNull(Rdr("tb_filelocation_id")) = False Then _tb_filelocation_id = Convert.ToInt64(Rdr("tb_filelocation_id"))
                        If Convert.IsDBNull(Rdr("is_send_complete")) = False Then _is_send_complete = Rdr("is_send_complete").ToString()
                        If Convert.IsDBNull(Rdr("send_time")) = False Then _send_time = Convert.ToDateTime(Rdr("send_time"))
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


        'Get Insert Statement for table TB_FILEBORROW
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, FILEBORROW_CODE, RESERVE_JOB_ID, BORROWER_ID, BORROWERNAME, BORROWERSTATUS, BORROWERDATE, CREATEBY, CREATEON, UPDATEBY, UPDATEON, TB_FILELOCATION_ID, IS_SEND_COMPLETE, SEND_TIME)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.FILEBORROW_CODE, INSERTED.RESERVE_JOB_ID, INSERTED.BORROWER_ID, INSERTED.BORROWERNAME, INSERTED.BORROWERSTATUS, INSERTED.BORROWERDATE, INSERTED.CREATEBY, INSERTED.CREATEON, INSERTED.UPDATEBY, INSERTED.UPDATEON, INSERTED.TB_FILELOCATION_ID, INSERTED.IS_SEND_COMPLETE, INSERTED.SEND_TIME
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_FILEBORROW_CODE" & ", "
                sql += "@_RESERVE_JOB_ID" & ", "
                sql += "@_BORROWER_ID" & ", "
                sql += "@_BORROWERNAME" & ", "
                sql += "@_BORROWERSTATUS" & ", "
                sql += "@_BORROWERDATE" & ", "
                sql += "@_CREATEBY" & ", "
                sql += "@_CREATEON" & ", "
                sql += "@_UPDATEBY" & ", "
                sql += "@_UPDATEON" & ", "
                sql += "@_TB_FILELOCATION_ID" & ", "
                sql += "@_IS_SEND_COMPLETE" & ", "
                sql += "@_SEND_TIME"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_FILEBORROW
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "FILEBORROW_CODE = " & "@_FILEBORROW_CODE" & ", "
                Sql += "RESERVE_JOB_ID = " & "@_RESERVE_JOB_ID" & ", "
                Sql += "BORROWER_ID = " & "@_BORROWER_ID" & ", "
                Sql += "BORROWERNAME = " & "@_BORROWERNAME" & ", "
                Sql += "BORROWERSTATUS = " & "@_BORROWERSTATUS" & ", "
                Sql += "BORROWERDATE = " & "@_BORROWERDATE" & ", "
                Sql += "CREATEBY = " & "@_CREATEBY" & ", "
                Sql += "CREATEON = " & "@_CREATEON" & ", "
                Sql += "UPDATEBY = " & "@_UPDATEBY" & ", "
                Sql += "UPDATEON = " & "@_UPDATEON" & ", "
                Sql += "TB_FILELOCATION_ID = " & "@_TB_FILELOCATION_ID" & ", "
                Sql += "IS_SEND_COMPLETE = " & "@_IS_SEND_COMPLETE" & ", "
                Sql += "SEND_TIME = " & "@_SEND_TIME" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_FILEBORROW
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_FILEBORROW
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, FILEBORROW_CODE, RESERVE_JOB_ID, BORROWER_ID, BORROWERNAME, BORROWERSTATUS, BORROWERDATE, CREATEBY, CREATEON, UPDATEBY, UPDATEON, TB_FILELOCATION_ID, IS_SEND_COMPLETE, SEND_TIME FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

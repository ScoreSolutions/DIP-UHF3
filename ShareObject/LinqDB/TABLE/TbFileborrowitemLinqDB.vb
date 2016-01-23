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
    'Represents a transaction for TB_FILEBORROWITEM table LinqDB.
    '[Create by  on January, 14 2015]
    Public Class TbFileborrowitemLinqDB
        Public sub TbFileborrowitemLinqDB()

        End Sub 
        ' TB_FILEBORROWITEM
        Const _tableName As String = "TB_FILEBORROWITEM"
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
        Dim _FILEBORROW_ID As  System.Nullable(Of Long)  = 0
        Dim _RESERVE_ID As  System.Nullable(Of Long)  = 0
        Dim _REQUISITION_ID As  String  = ""
        Dim _RESERVEDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DUEDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _RETURNDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _SCAN_BY As  System.Nullable(Of Char)  = ""
        Dim _OFFICER_RETURN As  String  = ""
        Dim _RETURN_SCAN_BY As  System.Nullable(Of Char)  = ""
        Dim _TAG_CODE As  String  = ""
        Dim _ISUPDATE_INNOVA_BORROW As  System.Nullable(Of Char)  = ""
        Dim _ISUPDATE_INNOVA_RETURN As  System.Nullable(Of Char)  = ""
        Dim _CREATEBY As  String  = ""
        Dim _CREATEON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATEBY As  String  = ""
        Dim _UPDATEON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

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
        <Column(Storage:="_FILEBORROW_ID", DbType:="BigInt")>  _
        Public Property FILEBORROW_ID() As  System.Nullable(Of Long) 
            Get
                Return _FILEBORROW_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _FILEBORROW_ID = value
            End Set
        End Property 
        <Column(Storage:="_RESERVE_ID", DbType:="BigInt")>  _
        Public Property RESERVE_ID() As  System.Nullable(Of Long) 
            Get
                Return _RESERVE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _RESERVE_ID = value
            End Set
        End Property 
        <Column(Storage:="_REQUISITION_ID", DbType:="VarChar(20)")>  _
        Public Property REQUISITION_ID() As  String 
            Get
                Return _REQUISITION_ID
            End Get
            Set(ByVal value As  String )
               _REQUISITION_ID = value
            End Set
        End Property 
        <Column(Storage:="_RESERVEDATE", DbType:="DateTime")>  _
        Public Property RESERVEDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _RESERVEDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _RESERVEDATE = value
            End Set
        End Property 
        <Column(Storage:="_DUEDATE", DbType:="DateTime")>  _
        Public Property DUEDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _DUEDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DUEDATE = value
            End Set
        End Property 
        <Column(Storage:="_RETURNDATE", DbType:="DateTime")>  _
        Public Property RETURNDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _RETURNDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _RETURNDATE = value
            End Set
        End Property 
        <Column(Storage:="_SCAN_BY", DbType:="Char(1)")>  _
        Public Property SCAN_BY() As  System.Nullable(Of Char) 
            Get
                Return _SCAN_BY
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _SCAN_BY = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_RETURN", DbType:="VarChar(50)")>  _
        Public Property OFFICER_RETURN() As  String 
            Get
                Return _OFFICER_RETURN
            End Get
            Set(ByVal value As  String )
               _OFFICER_RETURN = value
            End Set
        End Property 
        <Column(Storage:="_RETURN_SCAN_BY", DbType:="Char(1)")>  _
        Public Property RETURN_SCAN_BY() As  System.Nullable(Of Char) 
            Get
                Return _RETURN_SCAN_BY
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _RETURN_SCAN_BY = value
            End Set
        End Property 
        <Column(Storage:="_TAG_CODE", DbType:="VarChar(10)")>  _
        Public Property TAG_CODE() As  String 
            Get
                Return _TAG_CODE
            End Get
            Set(ByVal value As  String )
               _TAG_CODE = value
            End Set
        End Property 
        <Column(Storage:="_ISUPDATE_INNOVA_BORROW", DbType:="Char(1)")>  _
        Public Property ISUPDATE_INNOVA_BORROW() As  System.Nullable(Of Char) 
            Get
                Return _ISUPDATE_INNOVA_BORROW
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _ISUPDATE_INNOVA_BORROW = value
            End Set
        End Property 
        <Column(Storage:="_ISUPDATE_INNOVA_RETURN", DbType:="Char(1)")>  _
        Public Property ISUPDATE_INNOVA_RETURN() As  System.Nullable(Of Char) 
            Get
                Return _ISUPDATE_INNOVA_RETURN
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _ISUPDATE_INNOVA_RETURN = value
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


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _FILEBORROW_ID = 0
            _RESERVE_ID = 0
            _REQUISITION_ID = ""
            _RESERVEDATE = New DateTime(1,1,1)
            _DUEDATE = New DateTime(1,1,1)
            _RETURNDATE = New DateTime(1,1,1)
            _SCAN_BY = ""
            _OFFICER_RETURN = ""
            _RETURN_SCAN_BY = ""
            _TAG_CODE = ""
            _ISUPDATE_INNOVA_BORROW = ""
            _ISUPDATE_INNOVA_RETURN = ""
            _CREATEBY = ""
            _CREATEON = New DateTime(1,1,1)
            _UPDATEBY = ""
            _UPDATEON = New DateTime(1,1,1)
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


        '/// Returns an indication whether the current data is inserted into TB_FILEBORROWITEM table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_FILEBORROWITEM table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_FILEBORROWITEM table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_FILEBORROWITEM table successfully.
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


        '/// Returns an indication whether the record of TB_FILEBORROWITEM by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_FILEBORROWITEM by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbFileborrowitemLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_FILEBORROWITEM by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_FILEBORROWITEM table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_FILEBORROWITEM table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_FILEBORROWITEM table successfully.
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
            Dim cmbParam(16) As SqlParameter
            cmbParam(0) = New SqlParameter("@_ID", SqlDbType.BigInt)
            cmbParam(0).Value = _ID

            cmbParam(1) = New SqlParameter("@_FILEBORROW_ID", SqlDbType.BigInt)
            If _FILEBORROW_ID IsNot Nothing Then 
                cmbParam(1).Value = _FILEBORROW_ID.Value
            Else
                cmbParam(1).Value = DBNull.value
            End IF

            cmbParam(2) = New SqlParameter("@_RESERVE_ID", SqlDbType.BigInt)
            If _RESERVE_ID IsNot Nothing Then 
                cmbParam(2).Value = _RESERVE_ID.Value
            Else
                cmbParam(2).Value = DBNull.value
            End IF

            cmbParam(3) = New SqlParameter("@_REQUISITION_ID", SqlDbType.VarChar)
            If _REQUISITION_ID.Trim <> "" Then 
                cmbParam(3).Value = _REQUISITION_ID
            Else
                cmbParam(3).Value = DBNull.value
            End If

            cmbParam(4) = New SqlParameter("@_RESERVEDATE", SqlDbType.DateTime)
            If _RESERVEDATE.Value.Year > 1 Then 
                cmbParam(4).Value = _RESERVEDATE.Value
            Else
                cmbParam(4).Value = DBNull.value
            End If

            cmbParam(5) = New SqlParameter("@_DUEDATE", SqlDbType.DateTime)
            If _DUEDATE.Value.Year > 1 Then 
                cmbParam(5).Value = _DUEDATE.Value
            Else
                cmbParam(5).Value = DBNull.value
            End If

            cmbParam(6) = New SqlParameter("@_RETURNDATE", SqlDbType.DateTime)
            If _RETURNDATE.Value.Year > 1 Then 
                cmbParam(6).Value = _RETURNDATE.Value
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_SCAN_BY", SqlDbType.Char)
            If _SCAN_BY.Value <> "" Then 
                cmbParam(7).Value = _SCAN_BY.Value
            Else
                cmbParam(7).Value = DBNull.value
            End IF

            cmbParam(8) = New SqlParameter("@_OFFICER_RETURN", SqlDbType.VarChar)
            If _OFFICER_RETURN.Trim <> "" Then 
                cmbParam(8).Value = _OFFICER_RETURN
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_RETURN_SCAN_BY", SqlDbType.Char)
            If _RETURN_SCAN_BY.Value <> "" Then 
                cmbParam(9).Value = _RETURN_SCAN_BY.Value
            Else
                cmbParam(9).Value = DBNull.value
            End IF

            cmbParam(10) = New SqlParameter("@_TAG_CODE", SqlDbType.VarChar)
            If _TAG_CODE.Trim <> "" Then 
                cmbParam(10).Value = _TAG_CODE
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_ISUPDATE_INNOVA_BORROW", SqlDbType.Char)
            If _ISUPDATE_INNOVA_BORROW.Value <> "" Then 
                cmbParam(11).Value = _ISUPDATE_INNOVA_BORROW.Value
            Else
                cmbParam(11).Value = DBNull.value
            End IF

            cmbParam(12) = New SqlParameter("@_ISUPDATE_INNOVA_RETURN", SqlDbType.Char)
            If _ISUPDATE_INNOVA_RETURN.Value <> "" Then 
                cmbParam(12).Value = _ISUPDATE_INNOVA_RETURN.Value
            Else
                cmbParam(12).Value = DBNull.value
            End IF

            cmbParam(13) = New SqlParameter("@_CREATEBY", SqlDbType.VarChar)
            If _CREATEBY.Trim <> "" Then 
                cmbParam(13).Value = _CREATEBY
            Else
                cmbParam(13).Value = DBNull.value
            End If

            cmbParam(14) = New SqlParameter("@_CREATEON", SqlDbType.DateTime)
            If _CREATEON.Value.Year > 1 Then 
                cmbParam(14).Value = _CREATEON.Value
            Else
                cmbParam(14).Value = DBNull.value
            End If

            cmbParam(15) = New SqlParameter("@_UPDATEBY", SqlDbType.VarChar)
            If _UPDATEBY.Trim <> "" Then 
                cmbParam(15).Value = _UPDATEBY
            Else
                cmbParam(15).Value = DBNull.value
            End If

            cmbParam(16) = New SqlParameter("@_UPDATEON", SqlDbType.DateTime)
            If _UPDATEON.Value.Year > 1 Then 
                cmbParam(16).Value = _UPDATEON.Value
            Else
                cmbParam(16).Value = DBNull.value
            End If

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_FILEBORROWITEM by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("fileborrow_id")) = False Then _fileborrow_id = Convert.ToInt64(Rdr("fileborrow_id"))
                        If Convert.IsDBNull(Rdr("reserve_id")) = False Then _reserve_id = Convert.ToInt64(Rdr("reserve_id"))
                        If Convert.IsDBNull(Rdr("requisition_id")) = False Then _requisition_id = Rdr("requisition_id").ToString()
                        If Convert.IsDBNull(Rdr("reservedate")) = False Then _reservedate = Convert.ToDateTime(Rdr("reservedate"))
                        If Convert.IsDBNull(Rdr("duedate")) = False Then _duedate = Convert.ToDateTime(Rdr("duedate"))
                        If Convert.IsDBNull(Rdr("returndate")) = False Then _returndate = Convert.ToDateTime(Rdr("returndate"))
                        If Convert.IsDBNull(Rdr("scan_by")) = False Then _scan_by = Rdr("scan_by").ToString()
                        If Convert.IsDBNull(Rdr("officer_return")) = False Then _officer_return = Rdr("officer_return").ToString()
                        If Convert.IsDBNull(Rdr("return_scan_by")) = False Then _return_scan_by = Rdr("return_scan_by").ToString()
                        If Convert.IsDBNull(Rdr("tag_code")) = False Then _tag_code = Rdr("tag_code").ToString()
                        If Convert.IsDBNull(Rdr("isUpdate_innova_borrow")) = False Then _isUpdate_innova_borrow = Rdr("isUpdate_innova_borrow").ToString()
                        If Convert.IsDBNull(Rdr("isUpdate_innova_return")) = False Then _isUpdate_innova_return = Rdr("isUpdate_innova_return").ToString()
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
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


        '/// Returns an indication whether the record of TB_FILEBORROWITEM by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbFileborrowitemLinqDB
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
                        If Convert.IsDBNull(Rdr("fileborrow_id")) = False Then _fileborrow_id = Convert.ToInt64(Rdr("fileborrow_id"))
                        If Convert.IsDBNull(Rdr("reserve_id")) = False Then _reserve_id = Convert.ToInt64(Rdr("reserve_id"))
                        If Convert.IsDBNull(Rdr("requisition_id")) = False Then _requisition_id = Rdr("requisition_id").ToString()
                        If Convert.IsDBNull(Rdr("reservedate")) = False Then _reservedate = Convert.ToDateTime(Rdr("reservedate"))
                        If Convert.IsDBNull(Rdr("duedate")) = False Then _duedate = Convert.ToDateTime(Rdr("duedate"))
                        If Convert.IsDBNull(Rdr("returndate")) = False Then _returndate = Convert.ToDateTime(Rdr("returndate"))
                        If Convert.IsDBNull(Rdr("scan_by")) = False Then _scan_by = Rdr("scan_by").ToString()
                        If Convert.IsDBNull(Rdr("officer_return")) = False Then _officer_return = Rdr("officer_return").ToString()
                        If Convert.IsDBNull(Rdr("return_scan_by")) = False Then _return_scan_by = Rdr("return_scan_by").ToString()
                        If Convert.IsDBNull(Rdr("tag_code")) = False Then _tag_code = Rdr("tag_code").ToString()
                        If Convert.IsDBNull(Rdr("isUpdate_innova_borrow")) = False Then _isUpdate_innova_borrow = Rdr("isUpdate_innova_borrow").ToString()
                        If Convert.IsDBNull(Rdr("isUpdate_innova_return")) = False Then _isUpdate_innova_return = Rdr("isUpdate_innova_return").ToString()
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
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


        'Get Insert Statement for table TB_FILEBORROWITEM
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, FILEBORROW_ID, RESERVE_ID, REQUISITION_ID, RESERVEDATE, DUEDATE, RETURNDATE, SCAN_BY, OFFICER_RETURN, RETURN_SCAN_BY, TAG_CODE, ISUPDATE_INNOVA_BORROW, ISUPDATE_INNOVA_RETURN, CREATEBY, CREATEON, UPDATEBY, UPDATEON)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.FILEBORROW_ID, INSERTED.RESERVE_ID, INSERTED.REQUISITION_ID, INSERTED.RESERVEDATE, INSERTED.DUEDATE, INSERTED.RETURNDATE, INSERTED.SCAN_BY, INSERTED.OFFICER_RETURN, INSERTED.RETURN_SCAN_BY, INSERTED.TAG_CODE, INSERTED.ISUPDATE_INNOVA_BORROW, INSERTED.ISUPDATE_INNOVA_RETURN, INSERTED.CREATEBY, INSERTED.CREATEON, INSERTED.UPDATEBY, INSERTED.UPDATEON
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_FILEBORROW_ID" & ", "
                sql += "@_RESERVE_ID" & ", "
                sql += "@_REQUISITION_ID" & ", "
                sql += "@_RESERVEDATE" & ", "
                sql += "@_DUEDATE" & ", "
                sql += "@_RETURNDATE" & ", "
                sql += "@_SCAN_BY" & ", "
                sql += "@_OFFICER_RETURN" & ", "
                sql += "@_RETURN_SCAN_BY" & ", "
                sql += "@_TAG_CODE" & ", "
                sql += "@_ISUPDATE_INNOVA_BORROW" & ", "
                sql += "@_ISUPDATE_INNOVA_RETURN" & ", "
                sql += "@_CREATEBY" & ", "
                sql += "@_CREATEON" & ", "
                sql += "@_UPDATEBY" & ", "
                sql += "@_UPDATEON"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_FILEBORROWITEM
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "FILEBORROW_ID = " & "@_FILEBORROW_ID" & ", "
                Sql += "RESERVE_ID = " & "@_RESERVE_ID" & ", "
                Sql += "REQUISITION_ID = " & "@_REQUISITION_ID" & ", "
                Sql += "RESERVEDATE = " & "@_RESERVEDATE" & ", "
                Sql += "DUEDATE = " & "@_DUEDATE" & ", "
                Sql += "RETURNDATE = " & "@_RETURNDATE" & ", "
                Sql += "SCAN_BY = " & "@_SCAN_BY" & ", "
                Sql += "OFFICER_RETURN = " & "@_OFFICER_RETURN" & ", "
                Sql += "RETURN_SCAN_BY = " & "@_RETURN_SCAN_BY" & ", "
                Sql += "TAG_CODE = " & "@_TAG_CODE" & ", "
                Sql += "ISUPDATE_INNOVA_BORROW = " & "@_ISUPDATE_INNOVA_BORROW" & ", "
                Sql += "ISUPDATE_INNOVA_RETURN = " & "@_ISUPDATE_INNOVA_RETURN" & ", "
                Sql += "CREATEBY = " & "@_CREATEBY" & ", "
                Sql += "CREATEON = " & "@_CREATEON" & ", "
                Sql += "UPDATEBY = " & "@_UPDATEBY" & ", "
                Sql += "UPDATEON = " & "@_UPDATEON" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_FILEBORROWITEM
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_FILEBORROWITEM
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, FILEBORROW_ID, RESERVE_ID, REQUISITION_ID, RESERVEDATE, DUEDATE, RETURNDATE, SCAN_BY, OFFICER_RETURN, RETURN_SCAN_BY, TAG_CODE, ISUPDATE_INNOVA_BORROW, ISUPDATE_INNOVA_RETURN, CREATEBY, CREATEON, UPDATEBY, UPDATEON FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

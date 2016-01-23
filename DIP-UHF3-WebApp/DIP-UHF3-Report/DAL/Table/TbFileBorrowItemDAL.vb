Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DB = DIP_RFID.DAL.Common.Utilities.SqlDB
Imports DIP_RFID.Data.Common.Utilities
Imports DIP_RFID.Data.Table

Namespace Table
    'Represents a transaction for TB_FILEBORROWITEM table DAL.
    '[Create by  on December, 28 2010]
    Public Class TbFileBorrowItemDAL
        Public Sub TbFileBorrowItemDAL()

        End Sub
        ' TB_FILEBORROWITEM
        Const _tableName As String = "TB_FILEBORROWITEM"
        Dim _deletedRow As Int16 = 0

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property TableName() As String
            Get
                Return _tableName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage() As String
            Get
                Return _information
            End Get
        End Property
        Public ReadOnly Property HaveData() As Boolean
            Get
                Return _haveData
            End Get
        End Property


        'Generate Field List
        Dim _ID As Long = 0
        Dim _FILEBORROW_ID As Long = 0
        Dim _RESERVE_ID As Long = 0
        Dim _REQUISITION_ID As String = ""
        Dim _RESERVEDATE As DateTime = New DateTime(1, 1, 1)
        Dim _DUEDATE As DateTime = New DateTime(1, 1, 1)
        Dim _RETURNDATE As DateTime = New DateTime(1, 1, 1)
        Dim _SCAN_BY As String = ""
        Dim _OFFICER_RETURN As String = ""
        Dim _RETURN_SCAN_BY As String = ""
        Dim _TAG_CODE As String = ""
        Dim _ISUPDATE_INNOVA_BORROW As String = ""
        Dim _ISUPDATE_INNOVA_RETURN As String = ""
        Dim _CREATEBY As String = ""
        Dim _CREATEON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATEBY As String = ""
        Dim _UPDATEON As DateTime = New DateTime(1, 1, 1)

        'Generate Field Property 
        Public ReadOnly Property ID() As Long
            Get
                Return _ID
            End Get
        End Property
        Public Property FILEBORROW_ID() As Long
            Get
                Return _FILEBORROW_ID
            End Get
            Set(ByVal value As Long)
                _FILEBORROW_ID = value
            End Set
        End Property
        Public Property RESERVE_ID() As Long
            Get
                Return _RESERVE_ID
            End Get
            Set(ByVal value As Long)
                _RESERVE_ID = value
            End Set
        End Property
        Public Property REQUISITION_ID() As String
            Get
                Return _REQUISITION_ID
            End Get
            Set(ByVal value As String)
                _REQUISITION_ID = value
            End Set
        End Property
        Public Property RESERVEDATE() As DateTime
            Get
                Return _RESERVEDATE
            End Get
            Set(ByVal value As DateTime)
                _RESERVEDATE = value
            End Set
        End Property
        Public Property DUEDATE() As DateTime
            Get
                Return _DUEDATE
            End Get
            Set(ByVal value As DateTime)
                _DUEDATE = value
            End Set
        End Property
        Public Property RETURNDATE() As DateTime
            Get
                Return _RETURNDATE
            End Get
            Set(ByVal value As DateTime)
                _RETURNDATE = value
            End Set
        End Property
        Public Property SCAN_BY() As String
            Get
                Return _SCAN_BY
            End Get
            Set(ByVal value As String)
                _SCAN_BY = value
            End Set
        End Property
        Public Property OFFICER_RETURN() As String
            Get
                Return _OFFICER_RETURN
            End Get
            Set(ByVal value As String)
                _OFFICER_RETURN = value
            End Set
        End Property
        Public Property RETURN_SCAN_BY() As String
            Get
                Return _RETURN_SCAN_BY
            End Get
            Set(ByVal value As String)
                _RETURN_SCAN_BY = value
            End Set
        End Property
        Public Property TAG_CODE() As String
            Get
                Return _TAG_CODE
            End Get
            Set(ByVal value As String)
                _TAG_CODE = value
            End Set
        End Property
        Public Property ISUPDATE_INNOVA_BORROW() As String
            Get
                Return _ISUPDATE_INNOVA_BORROW
            End Get
            Set(ByVal value As String)
                _ISUPDATE_INNOVA_BORROW = value
            End Set
        End Property
        Public Property ISUPDATE_INNOVA_RETURN() As String
            Get
                Return _ISUPDATE_INNOVA_RETURN
            End Get
            Set(ByVal value As String)
                _ISUPDATE_INNOVA_RETURN = value
            End Set
        End Property
        Public ReadOnly Property CREATEBY() As String
            Get
                Return _CREATEBY
            End Get
        End Property
        Public ReadOnly Property CREATEON() As DateTime
            Get
                Return _CREATEON
            End Get
        End Property
        Public ReadOnly Property UPDATEBY() As String
            Get
                Return _UPDATEBY
            End Get
        End Property
        Public ReadOnly Property UPDATEON() As DateTime
            Get
                Return _UPDATEON
            End Get
        End Property


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _FILEBORROW_ID = 0
            _RESERVE_ID = 0
            _REQUISITION_ID = ""
            _RESERVEDATE = New DateTime(1, 1, 1)
            _DUEDATE = New DateTime(1, 1, 1)
            _RETURNDATE = New DateTime(1, 1, 1)
            _SCAN_BY = ""
            _OFFICER_RETURN = ""
            _RETURN_SCAN_BY = ""
            _TAG_CODE = ""
            _ISUPDATE_INNOVA_BORROW = ""
            _ISUPDATE_INNOVA_RETURN = ""
            _CREATEBY = ""
            _CREATEON = New DateTime(1, 1, 1)
            _UPDATEBY = ""
            _UPDATEON = New DateTime(1, 1, 1)
        End Sub

        'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(ByVal whClause As String, ByVal orderBy As String, ByVal trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(ByVal Sql As String, ByVal orderBy As String, ByVal trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(Sql & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        '/// Returns an indication whether the current data is inserted into TB_FILEBORROWITEM table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _id = DB.GetNextID("id", tableName, trans)
            _CREATEBY = UserID
            _CREATEON = DateTime.Now
            Return doInsert(trans)
        End Function


        '/// Returns an indication whether the current data is updated to TB_FILEBORROWITEM table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByid(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATEBY = UserID
            _UPDATEON = DateTime.Now
            Return doUpdate("id = " & DB.SetDouble(_id) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from TB_FILEBORROWITEM table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByid(ByVal trans As SQLTransaction) As Boolean
            Return doDelete("id = " & DB.SetDouble(_id) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_FILEBORROWITEM by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByid(ByVal cid As Long, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_FILEBORROWITEM by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByid(ByVal cid As Long, ByVal trans As SQLTransaction) As TbFileBorrowItemData
            Return doGetMappingData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_FILEBORROWITEM by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_FILEBORROWITEM table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(ByVal trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try
                    ret = (DB.ExecuteNonQuery(SqlInsert, trans) > 0)
                    If ret = False Then
                        _error = MessageResources.MSGEN001
                    Else
                        _haveData = True
                    End If
                    _information = MessageResources.MSGIN001
                Catch ex As ApplicationException
                    ret = False
                    _error = ex.Message
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC101
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to TB_FILEBORROWITEM table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = True Then
                If whText.Trim() <> "" Then
                    Dim tmpWhere As String = " Where " & whText
                    Try
                        ret = (DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGEU001
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message
                    Catch ex As Exception
                        ex.ToString()
                        ret = False
                        _error = MessageResources.MSGEC102
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from TB_FILEBORROWITEM table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = True Then
                If whText.Trim() <> "" Then
                    Dim tmpWhere As String = " Where " & whText
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message
                    Catch ex As Exception
                        ex.ToString()
                        ret = False
                        _error = MessageResources.MSGEC103
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of TB_FILEBORROWITEM by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            ClearData()
            _haveData = False
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
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed = False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function
        '/// Returns an indication whether the Class Data of TB_FILEBORROWITEM by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingData(ByVal ret As TbFileBorrowItemData, ByVal RDr As DataRow) As TbFileBorrowItemData
            If Convert.IsDBNull(Rdr("id")) = False Then ret.ID = Convert.ToInt64(Rdr("id"))
            If Convert.IsDBNull(Rdr("fileborrow_id")) = False Then ret.FILEBORROW_ID = Convert.ToInt64(Rdr("fileborrow_id"))
            If Convert.IsDBNull(Rdr("reserve_id")) = False Then ret.RESERVE_ID = Convert.ToInt64(Rdr("reserve_id"))
            If Convert.IsDBNull(Rdr("requisition_id")) = False Then ret.REQUISITION_ID = Rdr("requisition_id").ToString()
            If Convert.IsDBNull(Rdr("reservedate")) = False Then ret.RESERVEDATE = Convert.ToDateTime(Rdr("reservedate"))
            If Convert.IsDBNull(Rdr("duedate")) = False Then ret.DUEDATE = Convert.ToDateTime(Rdr("duedate"))
            If Convert.IsDBNull(Rdr("returndate")) = False Then ret.RETURNDATE = Convert.ToDateTime(Rdr("returndate"))
            If Convert.IsDBNull(Rdr("scan_by")) = False Then ret.SCAN_BY = Rdr("scan_by").ToString()
            If Convert.IsDBNull(Rdr("officer_return")) = False Then ret.OFFICER_RETURN = Rdr("officer_return").ToString()
            If Convert.IsDBNull(Rdr("return_scan_by")) = False Then ret.RETURN_SCAN_BY = Rdr("return_scan_by").ToString()
            If Convert.IsDBNull(Rdr("tag_code")) = False Then ret.TAG_CODE = Rdr("tag_code").ToString()
            If Convert.IsDBNull(Rdr("isUpdate_innova_borrow")) = False Then ret.ISUPDATE_INNOVA_BORROW = Rdr("isUpdate_innova_borrow").ToString()
            If Convert.IsDBNull(Rdr("isUpdate_innova_return")) = False Then ret.ISUPDATE_INNOVA_RETURN = Rdr("isUpdate_innova_return").ToString()
            If Convert.IsDBNull(Rdr("createby")) = False Then ret.CREATEBY = Rdr("createby").ToString()
            If Convert.IsDBNull(Rdr("createon")) = False Then ret.CREATEON = Convert.ToDateTime(Rdr("createon"))
            If Convert.IsDBNull(Rdr("updateby")) = False Then ret.UPDATEBY = Rdr("updateby").ToString()
            If Convert.IsDBNull(Rdr("updateon")) = False Then ret.UPDATEON = Convert.ToDateTime(Rdr("updateon"))
            Return ret
        End Function


        '/// Returns an indication whether the record of TB_FILEBORROWITEM by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetMappingData(ByVal whText As String, ByVal trans As SQLTransaction) As TbFileBorrowItemData
            ClearData()
            _haveData = False
            Dim ret As New TbFileBorrowItemData
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdt As DataTable
                Try
                    Rdt = DB.ExecuteTable(SqlSelect() & tmpWhere, trans)
                    If Rdt.Rows.Count = 1 Then
                        _haveData = True
                        Dim RDr As DataRow
                        RDr = Rdt.Rows(0)
                        doChkData(whText, trans)
                        ret = doMappingData(ret, RDr)
                    Else
                        _haveData = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdt = Nothing
                Catch ex As Exception
                    ex.ToString()
                    _haveData = False
                    _error = MessageResources.MSGEC104
                    If Rdt IsNot Nothing Then
                        Rdt = Nothing
                    End If
                End Try
            Else
                _haveData = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function



        ' SQL Statements


        'Get Insert Statement for table TB_FILEBORROWITEM
        Private ReadOnly Property SqlInsert() As String
            Get
                Dim Sql As String = ""
                Sql += "INSERT INTO " & tableName & " (ID, FILEBORROW_ID, RESERVE_ID, REQUISITION_ID, RESERVEDATE, DUEDATE, RETURNDATE, SCAN_BY, OFFICER_RETURN, RETURN_SCAN_BY, TAG_CODE, ISUPDATE_INNOVA_BORROW, ISUPDATE_INNOVA_RETURN, CREATEBY, CREATEON, UPDATEBY, UPDATEON)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetDouble(_FILEBORROW_ID) & ", "
                sql += DB.SetDouble(_RESERVE_ID) & ", "
                sql += DB.SetString(_REQUISITION_ID) & ", "
                sql += DB.SetDateTime(_RESERVEDATE) & ", "
                sql += DB.SetDateTime(_DUEDATE) & ", "
                sql += DB.SetDateTime(_RETURNDATE) & ", "
                sql += DB.SetString(_SCAN_BY) & ", "
                sql += DB.SetString(_OFFICER_RETURN) & ", "
                sql += DB.SetString(_RETURN_SCAN_BY) & ", "
                sql += DB.SetString(_TAG_CODE) & ", "
                sql += DB.SetString(_ISUPDATE_INNOVA_BORROW) & ", "
                sql += DB.SetString(_ISUPDATE_INNOVA_RETURN) & ", "
                sql += DB.SetString(_CREATEBY) & ", "
                sql += DB.SetDateTime(_CREATEON) & ", "
                sql += DB.SetString(_UPDATEBY) & ", "
                sql += DB.SetDateTime(_UPDATEON)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_FILEBORROWITEM
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "FILEBORROW_ID = " & DB.SetDouble(_FILEBORROW_ID) & ", "
                Sql += "RESERVE_ID = " & DB.SetDouble(_RESERVE_ID) & ", "
                Sql += "REQUISITION_ID = " & DB.SetString(_REQUISITION_ID) & ", "
                Sql += "RESERVEDATE = " & DB.SetDateTime(_RESERVEDATE) & ", "
                Sql += "DUEDATE = " & DB.SetDateTime(_DUEDATE) & ", "
                Sql += "RETURNDATE = " & DB.SetDateTime(_RETURNDATE) & ", "
                Sql += "SCAN_BY = " & DB.SetString(_SCAN_BY) & ", "
                Sql += "OFFICER_RETURN = " & DB.SetString(_OFFICER_RETURN) & ", "
                Sql += "RETURN_SCAN_BY = " & DB.SetString(_RETURN_SCAN_BY) & ", "
                Sql += "TAG_CODE = " & DB.SetString(_TAG_CODE) & ", "
                Sql += "ISUPDATE_INNOVA_BORROW = " & DB.SetString(_ISUPDATE_INNOVA_BORROW) & ", "
                Sql += "ISUPDATE_INNOVA_RETURN = " & DB.SetString(_ISUPDATE_INNOVA_RETURN) & ", "
                Sql += "CREATEBY = " & DB.SetString(_CREATEBY) & ", "
                Sql += "CREATEON = " & DB.SetDateTime(_CREATEON) & ", "
                Sql += "UPDATEBY = " & DB.SetString(_UPDATEBY) & ", "
                Sql += "UPDATEON = " & DB.SetDateTime(_UPDATEON) + ""
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
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
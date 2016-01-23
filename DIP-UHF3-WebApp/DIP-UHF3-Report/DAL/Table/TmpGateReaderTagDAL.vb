Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DIP_RFID.Data.Table
Imports DB = DIP_RFID.DAL.Common.Utilities.SqlDB
Imports DIP_RFID.Data.Common.Utilities

Namespace Table
    'Represents a transaction for TMP_GATE_READER_TAG table DAL.
    '[Create by  on April, 3 2014]
    Public Class TmpGateReaderTagDAL
        Public Sub TmpGateReaderTagDAL()

        End Sub
        ' TMP_GATE_READER_TAG
        Const _tableName As String = "TMP_GATE_READER_TAG"
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
        Dim _CREATEBY As String = ""
        Dim _CREATEON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATEBY As String = ""
        Dim _UPDATEON As DateTime = New DateTime(1, 1, 1)
        Dim _READER_ID As String = ""
        Dim _TAG_ID As String = ""
        Dim _READ_TYPE As String = ""

        'Generate Field Property 
        Public ReadOnly Property ID() As Long
            Get
                Return _ID
            End Get
        End Property
        Public Property CREATEBY() As String
            Get
                Return _CREATEBY
            End Get
            Set(ByVal value As String)
                _CREATEBY = value
            End Set
        End Property
        Public Property CREATEON() As DateTime
            Get
                Return _CREATEON
            End Get
            Set(ByVal value As DateTime)
                _CREATEON = value
            End Set
        End Property
        Public Property UPDATEBY() As String
            Get
                Return _UPDATEBY
            End Get
            Set(ByVal value As String)
                _UPDATEBY = value
            End Set
        End Property
        Public Property UPDATEON() As DateTime
            Get
                Return _UPDATEON
            End Get
            Set(ByVal value As DateTime)
                _UPDATEON = value
            End Set
        End Property
        Public Property READER_ID() As String
            Get
                Return _READER_ID
            End Get
            Set(ByVal value As String)
                _READER_ID = value
            End Set
        End Property
        Public Property TAG_ID() As String
            Get
                Return _TAG_ID
            End Get
            Set(ByVal value As String)
                _TAG_ID = value
            End Set
        End Property
        Public Property READ_TYPE() As String
            Get
                Return _READ_TYPE
            End Get
            Set(ByVal value As String)
                _READ_TYPE = value
            End Set
        End Property


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATEBY = ""
            _CREATEON = New DateTime(1, 1, 1)
            _UPDATEBY = ""
            _UPDATEON = New DateTime(1, 1, 1)
            _READER_ID = ""
            _TAG_ID = ""
            _READ_TYPE = ""
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


        '/// Returns an indication whether the current data is inserted into TMP_GATE_READER_TAG table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then
                _id = DB.GetNextID("id", tableName, trans)
                _CREATEBY = UserID
                _CREATEON = DateTime.Now
                Return doInsert(trans)
            Else
                _error = "Transaction Is not null"
                Return False
            End If
        End Function


        '/// Returns an indication whether the current data is updated to TMP_GATE_READER_TAG table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then
                _UPDATEBY = UserID
                _UPDATEON = DateTime.Now
                Return doUpdate("id = " & DB.SetDouble(_id) & " ", trans)
            Else
                _error = "Transaction Is not null"
                Return False
            End If
        End Function


        '/// Returns an indication whether the current data is deleted from TMP_GATE_READER_TAG table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(ByVal trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then
                Return doDelete("id = " & DB.SetDouble(_id) & " ", trans)
            Else
                _error = "Transaction Is not null"
                Return False
            End If
        End Function


        '/// Returns an indication whether the record of TMP_GATE_READER_TAG by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(ByVal cid As Long, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TMP_GATE_READER_TAG by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(ByVal cid As Long, ByVal trans As SQLTransaction) As TmpGateReaderTagDAL
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function




        '/// Returns an indication whether the record of TMP_GATE_READER_TAG by specified READER_ID_TAG_ID key is retrieved successfully.
        '/// <param name=cREADER_ID_TAG_ID>The READER_ID_TAG_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByREADER_ID_TAG_ID(ByVal cREADER_ID As String, ByVal cTAG_ID As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("READER_ID = " & DB.SetString(cREADER_ID) & " AND TAG_ID = " & DB.SetString(cTAG_ID), trans)
        End Function

        '/// Returns an indication whether the record of TMP_GATE_READER_TAG by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TMP_GATE_READER_TAG table successfully.
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


        '/// Returns an indication whether the current data is updated to TMP_GATE_READER_TAG table successfully.
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


        '/// Returns an indication whether the current data is deleted from TMP_GATE_READER_TAG table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If doChkData(whText, trans) = True Then
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


        '/// Returns an indication whether the record of TMP_GATE_READER_TAG by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
                        If Convert.IsDBNull(Rdr("reader_id")) = False Then _reader_id = Rdr("reader_id").ToString()
                        If Convert.IsDBNull(Rdr("tag_id")) = False Then _TAG_ID = Rdr("tag_id").ToString()
                        If Convert.IsDBNull(Rdr("read_type")) = False Then _READ_TYPE = Rdr("read_type").ToString()
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


        '/// Returns an indication whether the record of TMP_GATE_READER_TAG by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(ByVal whText As String, ByVal trans As SQLTransaction) As TmpGateReaderTagDAL
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
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
                        If Convert.IsDBNull(Rdr("reader_id")) = False Then _reader_id = Rdr("reader_id").ToString()
                        If Convert.IsDBNull(Rdr("tag_id")) = False Then _TAG_ID = Rdr("tag_id").ToString()
                        If Convert.IsDBNull(Rdr("read_type")) = False Then _READ_TYPE = Rdr("read_type").ToString()
                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed = False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return Me
        End Function



        ' SQL Statements


        'Get Insert Statement for table TMP_GATE_READER_TAG
        Private ReadOnly Property SqlInsert() As String
            Get
                Dim Sql As String = ""
                Sql += "INSERT INTO " & TableName & " (ID, CREATEBY, CREATEON, UPDATEBY, UPDATEON, READER_ID, TAG_ID,READ_TYPE)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATEBY) & ", "
                sql += DB.SetDateTime(_CREATEON) & ", "
                sql += DB.SetString(_UPDATEBY) & ", "
                sql += DB.SetDateTime(_UPDATEON) & ", "
                sql += DB.SetString(_READER_ID) & ", "
                Sql += DB.SetString(_TAG_ID) & ", "
                Sql += DB.SetString(_READ_TYPE)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TMP_GATE_READER_TAG
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATEBY = " & DB.SetString(_CREATEBY) & ", "
                Sql += "CREATEON = " & DB.SetDateTime(_CREATEON) & ", "
                Sql += "UPDATEBY = " & DB.SetString(_UPDATEBY) & ", "
                Sql += "UPDATEON = " & DB.SetDateTime(_UPDATEON) & ", "
                Sql += "READER_ID = " & DB.SetString(_READER_ID) & ", "
                Sql += "TAG_ID = " & DB.SetString(_TAG_ID) & ", "
                Sql += "READ_TYPE = " & DB.SetString(_READ_TYPE) & ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TMP_GATE_READER_TAG
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TMP_GATE_READER_TAG
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
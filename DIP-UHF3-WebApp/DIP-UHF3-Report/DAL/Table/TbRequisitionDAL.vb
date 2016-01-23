Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DB = DIP_RFID.DAL.Common.Utilities.SqlDB
Imports DIP_RFID.Data.Common.Utilities
Imports DIP_RFID.Data.Table

Namespace Table
    'Represents a transaction for TB_REQUISTION table DAL.
    '[Create by  on April, 18 2014]
    Public Class TbRequisitionDAL
        Public Sub TbRequisitionDAL()

        End Sub
        ' TB_REQUISTION
        Const _tableName As String = "TB_REQUISTION"
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
        Dim _REQ_NO As String = ""
        Dim _APP_NO As String = ""
        Dim _APP_NAME As String = ""
        Dim _APP_POSITION As String = ""
        Dim _APP_STATUS As String = ""
        Dim _MAINREQ As String = ""
        Dim _PUBLICNO As String = ""
        Dim _PATENTNO As String = ""
        Dim _AVAILABLE As String = ""
        Dim _LOCKOFFICER As String = ""
        Dim _PATENT_TYPE_ID As Long = 0
        Dim _QTY As Integer = 0
        Dim _SHELF_NAME As String = ""
        Dim _FILELOCATION As String = ""
        Dim _STATUS As String = ""
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
        Public Property REQ_NO() As String
            Get
                Return _REQ_NO
            End Get
            Set(ByVal value As String)
                _REQ_NO = value
            End Set
        End Property
        Public Property APP_NO() As String
            Get
                Return _APP_NO
            End Get
            Set(ByVal value As String)
                _APP_NO = value
            End Set
        End Property
        Public Property APP_NAME() As String
            Get
                Return _APP_NAME
            End Get
            Set(ByVal value As String)
                _APP_NAME = value
            End Set
        End Property
        Public Property APP_POSITION() As String
            Get
                Return _APP_POSITION
            End Get
            Set(ByVal value As String)
                _APP_POSITION = value
            End Set
        End Property
        Public Property APP_STATUS() As String
            Get
                Return _APP_STATUS
            End Get
            Set(ByVal value As String)
                _APP_STATUS = value
            End Set
        End Property
        Public Property MAINREQ() As String
            Get
                Return _MAINREQ
            End Get
            Set(ByVal value As String)
                _MAINREQ = value
            End Set
        End Property
        Public Property PUBLICNO() As String
            Get
                Return _PUBLICNO
            End Get
            Set(ByVal value As String)
                _PUBLICNO = value
            End Set
        End Property
        Public Property PATENTNO() As String
            Get
                Return _PATENTNO
            End Get
            Set(ByVal value As String)
                _PATENTNO = value
            End Set
        End Property
        Public Property AVAILABLE() As String
            Get
                Return _AVAILABLE
            End Get
            Set(ByVal value As String)
                _AVAILABLE = value
            End Set
        End Property
        Public Property LOCKOFFICER() As String
            Get
                Return _LOCKOFFICER
            End Get
            Set(ByVal value As String)
                _LOCKOFFICER = value
            End Set
        End Property
        Public Property PATENT_TYPE_ID() As Long
            Get
                Return _PATENT_TYPE_ID
            End Get
            Set(ByVal value As Long)
                _PATENT_TYPE_ID = value
            End Set
        End Property
        Public Property QTY() As Integer
            Get
                Return _QTY
            End Get
            Set(ByVal value As Integer)
                _QTY = value
            End Set
        End Property
        Public Property SHELF_NAME() As String
            Get
                Return _SHELF_NAME
            End Get
            Set(ByVal value As String)
                _SHELF_NAME = value
            End Set
        End Property
        Public Property FILELOCATION() As String
            Get
                Return _FILELOCATION
            End Get
            Set(ByVal value As String)
                _FILELOCATION = value
            End Set
        End Property
        Public Property STATUS() As String
            Get
                Return _STATUS
            End Get
            Set(ByVal value As String)
                _STATUS = value
            End Set
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


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _REQ_NO = ""
            _APP_NO = ""
            _APP_NAME = ""
            _APP_POSITION = ""
            _APP_STATUS = ""
            _MAINREQ = ""
            _PUBLICNO = ""
            _PATENTNO = ""
            _AVAILABLE = ""
            _LOCKOFFICER = ""
            _PATENT_TYPE_ID = 0
            _QTY = 0
            _SHELF_NAME = ""
            _FILELOCATION = ""
            _STATUS = ""
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
        Public Function GetDataList(ByVal whClause As String, ByVal orderBy As String, ByVal trans As SqlTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIf(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(ByVal Sql As String, ByVal orderBy As String, ByVal trans As SqlTransaction) As DataTable
            Return DB.ExecuteTable(Sql & IIf(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        '/// Returns an indication whether the current data is inserted into TB_REQUISTION table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(ByVal UserID As String, ByVal trans As SqlTransaction) As Boolean
            If trans IsNot Nothing Then
                _ID = DB.GetNextID("id", TableName, trans)
                _CREATEBY = UserID
                _CREATEON = DateTime.Now
                Return doInsert(trans)
            Else
                _error = "Transaction Is not null"
                Return False
            End If
        End Function


        '/// Returns an indication whether the current data is updated to TB_REQUISTION table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByID(ByVal UserID As String, ByVal trans As SqlTransaction) As Boolean
            If trans IsNot Nothing Then
                _UPDATEBY = UserID
                _UPDATEON = DateTime.Now
                Return doUpdate("id = " & DB.SetDouble(_ID) & " ", trans)
            Else
                _error = "Transaction Is not null"
                Return False
            End If
        End Function


        '/// Returns an indication whether the current data is deleted from TB_REQUISTION table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(ByVal trans As SqlTransaction) As Boolean
            If trans IsNot Nothing Then
                Return doDelete("id = " & DB.SetDouble(_ID) & " ", trans)
            Else
                _error = "Transaction Is not null"
                Return False
            End If
        End Function


        '/// Returns an indication whether the record of TB_REQUISTION by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(ByVal cid As Long, ByVal trans As SqlTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_REQUISTION by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByID(ByVal cid As Long, ByVal trans As SqlTransaction) As TbRequisitionDAL
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function

        Public Function GetDataByAPP_NO(ByVal cAPP_NO As String, ByVal trans As SqlTransaction) As TbRequisitionData
            Return doGetMappingData("APP_NO = " & DB.SetString(cAPP_NO) & " ", trans)
        End Function




        '/// Returns an indication whether the record of TB_REQUISTION by specified APP_NO key is retrieved successfully.
        '/// <param name=cAPP_NO>The APP_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByAPP_NO(ByVal cAPP_NO As String, ByVal trans As SqlTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " ", trans)
        End Function

        '/// Returns an indication whether the record of TB_REQUISTION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(ByVal whText As String, ByVal trans As SqlTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_REQUISTION table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(ByVal trans As SqlTransaction) As Boolean
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


        '/// Returns an indication whether the current data is updated to TB_REQUISTION table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(ByVal whText As String, ByVal trans As SqlTransaction) As Boolean
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


        '/// Returns an indication whether the current data is deleted from TB_REQUISTION table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(ByVal whText As String, ByVal trans As SqlTransaction) As Boolean
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


        '/// Returns an indication whether the record of TB_REQUISTION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(ByVal whText As String, ByVal trans As SqlTransaction) As Boolean
            Dim ret As Boolean = True
            ClearData()
            _haveData = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SqlDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _ID = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("req_no")) = False Then _REQ_NO = Rdr("req_no").ToString()
                        If Convert.IsDBNull(Rdr("app_no")) = False Then _APP_NO = Rdr("app_no").ToString()
                        If Convert.IsDBNull(Rdr("app_name")) = False Then _APP_NAME = Rdr("app_name").ToString()
                        If Convert.IsDBNull(Rdr("app_position")) = False Then _APP_POSITION = Rdr("app_position").ToString()
                        If Convert.IsDBNull(Rdr("app_status")) = False Then _APP_STATUS = Rdr("app_status").ToString()
                        If Convert.IsDBNull(Rdr("mainreq")) = False Then _MAINREQ = Rdr("mainreq").ToString()
                        If Convert.IsDBNull(Rdr("publicno")) = False Then _PUBLICNO = Rdr("publicno").ToString()
                        If Convert.IsDBNull(Rdr("patentno")) = False Then _PATENTNO = Rdr("patentno").ToString()
                        If Convert.IsDBNull(Rdr("available")) = False Then _AVAILABLE = Rdr("available").ToString()
                        If Convert.IsDBNull(Rdr("lockofficer")) = False Then _LOCKOFFICER = Rdr("lockofficer").ToString()
                        If Convert.IsDBNull(Rdr("patent_type_id")) = False Then _PATENT_TYPE_ID = Convert.ToInt64(Rdr("patent_type_id"))
                        If Convert.IsDBNull(Rdr("qty")) = False Then _QTY = Convert.ToInt32(Rdr("qty"))
                        If Convert.IsDBNull(Rdr("shelf_name")) = False Then _SHELF_NAME = Rdr("shelf_name").ToString()
                        If Convert.IsDBNull(Rdr("FILELOCATION")) = False Then _FILELOCATION = Rdr("FILELOCATION").ToString()
                        If Convert.IsDBNull(Rdr("status")) = False Then _STATUS = Rdr("status").ToString()
                        If Convert.IsDBNull(Rdr("createby")) = False Then _CREATEBY = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _CREATEON = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _UPDATEBY = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _UPDATEON = Convert.ToDateTime(Rdr("updateon"))
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


        '/// Returns an indication whether the record of TB_REQUISTION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(ByVal whText As String, ByVal trans As SqlTransaction) As TbRequisitionDAL
            ClearData()
            _haveData = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SqlDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _ID = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("req_no")) = False Then _REQ_NO = Rdr("req_no").ToString()
                        If Convert.IsDBNull(Rdr("app_no")) = False Then _APP_NO = Rdr("app_no").ToString()
                        If Convert.IsDBNull(Rdr("app_name")) = False Then _APP_NAME = Rdr("app_name").ToString()
                        If Convert.IsDBNull(Rdr("app_position")) = False Then _APP_POSITION = Rdr("app_position").ToString()
                        If Convert.IsDBNull(Rdr("app_status")) = False Then _APP_STATUS = Rdr("app_status").ToString()
                        If Convert.IsDBNull(Rdr("mainreq")) = False Then _MAINREQ = Rdr("mainreq").ToString()
                        If Convert.IsDBNull(Rdr("publicno")) = False Then _PUBLICNO = Rdr("publicno").ToString()
                        If Convert.IsDBNull(Rdr("patentno")) = False Then _PATENTNO = Rdr("patentno").ToString()
                        If Convert.IsDBNull(Rdr("available")) = False Then _AVAILABLE = Rdr("available").ToString()
                        If Convert.IsDBNull(Rdr("lockofficer")) = False Then _LOCKOFFICER = Rdr("lockofficer").ToString()
                        If Convert.IsDBNull(Rdr("patent_type_id")) = False Then _PATENT_TYPE_ID = Convert.ToInt64(Rdr("patent_type_id"))
                        If Convert.IsDBNull(Rdr("qty")) = False Then _QTY = Convert.ToInt32(Rdr("qty"))
                        If Convert.IsDBNull(Rdr("shelf_name")) = False Then _SHELF_NAME = Rdr("shelf_name").ToString()
                        If Convert.IsDBNull(Rdr("FILELOCATION")) = False Then _FILELOCATION = Rdr("FILELOCATION").ToString()
                        If Convert.IsDBNull(Rdr("status")) = False Then _STATUS = Rdr("status").ToString()
                        If Convert.IsDBNull(Rdr("createby")) = False Then _CREATEBY = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _CREATEON = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _UPDATEBY = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _UPDATEON = Convert.ToDateTime(Rdr("updateon"))
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
        '/// Returns an indication whether the Class Data of TB_REQUISTION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingData(ByVal ret As TbRequisitionData, ByVal RDr As DataRow) As TbRequisitionData
            If Convert.IsDBNull(RDr("id")) = False Then ret.ID = Convert.ToInt64(RDr("id"))
            If Convert.IsDBNull(RDr("req_no")) = False Then ret.REQ_NO = RDr("req_no").ToString()
            If Convert.IsDBNull(RDr("app_no")) = False Then ret.APP_NO = RDr("app_no").ToString()
            If Convert.IsDBNull(RDr("app_name")) = False Then ret.APP_NAME = RDr("app_name").ToString()
            If Convert.IsDBNull(RDr("app_position")) = False Then ret.APP_POSITION = RDr("app_position").ToString()
            If Convert.IsDBNull(RDr("app_status")) = False Then ret.APP_STATUS = RDr("app_status").ToString()
            If Convert.IsDBNull(RDr("mainreq")) = False Then ret.MAINREQ = RDr("mainreq").ToString()
            If Convert.IsDBNull(RDr("publicno")) = False Then ret.PUBLICNO = RDr("publicno").ToString()
            If Convert.IsDBNull(RDr("patentno")) = False Then ret.PATENTNO = RDr("patentno").ToString()
            If Convert.IsDBNull(RDr("available")) = False Then ret.AVAILABLE = RDr("available").ToString()
            If Convert.IsDBNull(RDr("lockofficer")) = False Then ret.LOCKOFFICER = RDr("lockofficer").ToString()
            If Convert.IsDBNull(RDr("patent_type_id")) = False Then ret.PATENT_TYPE_ID = Convert.ToInt64(RDr("patent_type_id"))
            If Convert.IsDBNull(RDr("qty")) = False Then ret.QTY = Convert.ToInt32(RDr("qty"))
            If Convert.IsDBNull(RDr("shelf_name")) = False Then ret.SHELF_NAME = RDr("shelf_name").ToString()
            If Convert.IsDBNull(RDr("createby")) = False Then ret.CREATEBY = RDr("createby").ToString()
            If Convert.IsDBNull(RDr("createon")) = False Then ret.CREATEON = Convert.ToDateTime(RDr("createon"))
            If Convert.IsDBNull(RDr("updateby")) = False Then ret.UPDATEBY = RDr("updateby").ToString()
            If Convert.IsDBNull(RDr("updateon")) = False Then ret.UPDATEON = Convert.ToDateTime(RDr("updateon"))
            Return ret
        End Function


        '/// Returns an indication whether the record of TB_REQUISTION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetMappingData(ByVal whText As String, ByVal trans As SqlTransaction) As TbRequisitionData
            ClearData()
            _haveData = False
            Dim ret As New TbRequisitionData
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


        'Get Insert Statement for table TB_REQUISTION
        Private ReadOnly Property SqlInsert() As String
            Get
                Dim Sql As String = ""
                Sql += "INSERT INTO " & TableName & " (ID, REQ_NO, APP_NO, APP_NAME, APP_POSITION, APP_STATUS, MAINREQ, PUBLICNO, PATENTNO, AVAILABLE, LOCKOFFICER, PATENT_TYPE_ID, QTY, SHELF_NAME, FILELOCATION, STATUS, CREATEBY, CREATEON, UPDATEBY, UPDATEON)"
                Sql += " VALUES("
                Sql += DB.SetDouble(_ID) & ", "
                Sql += DB.SetString(_REQ_NO) & ", "
                Sql += DB.SetString(_APP_NO) & ", "
                Sql += DB.SetString(_APP_NAME) & ", "
                Sql += DB.SetString(_APP_POSITION) & ", "
                Sql += DB.SetString(_APP_STATUS) & ", "
                Sql += DB.SetString(_MAINREQ) & ", "
                Sql += DB.SetString(_PUBLICNO) & ", "
                Sql += DB.SetString(_PATENTNO) & ", "
                Sql += DB.SetString(_AVAILABLE) & ", "
                Sql += DB.SetString(_LOCKOFFICER) & ", "
                Sql += DB.SetDouble(_PATENT_TYPE_ID) & ", "
                Sql += DB.SetDouble(_QTY) & ", "
                Sql += DB.SetString(_SHELF_NAME) & ", "
                Sql += DB.SetString(_FILELOCATION) & ", "
                Sql += DB.SetString(_STATUS) & ", "
                Sql += DB.SetString(_CREATEBY) & ", "
                Sql += DB.SetDateTime(_CREATEON) & ", "
                Sql += DB.SetString(_UPDATEBY) & ", "
                Sql += DB.SetDateTime(_UPDATEON)
                Sql += ")"
                Return Sql
            End Get
        End Property


        'Get update statement form table TB_REQUISTION
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & TableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "REQ_NO = " & DB.SetString(_REQ_NO) & ", "
                Sql += "APP_NO = " & DB.SetString(_APP_NO) & ", "
                Sql += "APP_NAME = " & DB.SetString(_APP_NAME) & ", "
                Sql += "APP_POSITION = " & DB.SetString(_APP_POSITION) & ", "
                Sql += "APP_STATUS = " & DB.SetString(_APP_STATUS) & ", "
                Sql += "MAINREQ = " & DB.SetString(_MAINREQ) & ", "
                Sql += "PUBLICNO = " & DB.SetString(_PUBLICNO) & ", "
                Sql += "PATENTNO = " & DB.SetString(_PATENTNO) & ", "
                Sql += "AVAILABLE = " & DB.SetString(_AVAILABLE) & ", "
                Sql += "LOCKOFFICER = " & DB.SetString(_LOCKOFFICER) & ", "
                Sql += "PATENT_TYPE_ID = " & DB.SetDouble(_PATENT_TYPE_ID) & ", "
                Sql += "QTY = " & DB.SetDouble(_QTY) & ", "
                Sql += "SHELF_NAME = " & DB.SetString(_SHELF_NAME) & ", "
                Sql += "FILELOCATION = " & DB.SetString(_FILELOCATION) & ", "
                Sql += "STATUS = " & DB.SetString(_STATUS) & ", "
                Sql += "CREATEBY = " & DB.SetString(_CREATEBY) & ", "
                Sql += "CREATEON = " & DB.SetDateTime(_CREATEON) & ", "
                Sql += "UPDATEBY = " & DB.SetString(_UPDATEBY) & ", "
                Sql += "UPDATEON = " & DB.SetDateTime(_UPDATEON) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_REQUISTION
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_REQUISTION
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
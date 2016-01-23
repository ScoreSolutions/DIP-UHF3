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
    'Represents a transaction for TB_PATENT table LinqDB.
    '[Create by  on January, 15 2015]
    Public Class TbPatentLinqDB
        Public sub TbPatentLinqDB()

        End Sub 
        ' TB_PATENT
        Const _tableName As String = "TB_PATENT"
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
        Dim _REQ_NO As  String  = ""
        Dim _APP_NO As  String  = ""
        Dim _APP_NAME As  String  = ""
        Dim _APP_POSITION As  String  = ""
        Dim _APP_STATUS As  String  = ""
        Dim _PATENT_TYPE_ID As  System.Nullable(Of Long)  = 0
        Dim _QTY As Long = 0

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
        <Column(Storage:="_REQ_NO", DbType:="VarChar(20)")>  _
        Public Property REQ_NO() As  String 
            Get
                Return _REQ_NO
            End Get
            Set(ByVal value As  String )
               _REQ_NO = value
            End Set
        End Property 
        <Column(Storage:="_APP_NO", DbType:="VarChar(20)")>  _
        Public Property APP_NO() As  String 
            Get
                Return _APP_NO
            End Get
            Set(ByVal value As  String )
               _APP_NO = value
            End Set
        End Property 
        <Column(Storage:="_APP_NAME", DbType:="VarChar(20)")>  _
        Public Property APP_NAME() As  String 
            Get
                Return _APP_NAME
            End Get
            Set(ByVal value As  String )
               _APP_NAME = value
            End Set
        End Property 
        <Column(Storage:="_APP_POSITION", DbType:="VarChar(20)")>  _
        Public Property APP_POSITION() As  String 
            Get
                Return _APP_POSITION
            End Get
            Set(ByVal value As  String )
               _APP_POSITION = value
            End Set
        End Property 
        <Column(Storage:="_APP_STATUS", DbType:="VarChar(50)")>  _
        Public Property APP_STATUS() As  String 
            Get
                Return _APP_STATUS
            End Get
            Set(ByVal value As  String )
               _APP_STATUS = value
            End Set
        End Property 
        <Column(Storage:="_PATENT_TYPE_ID", DbType:="BigInt")>  _
        Public Property PATENT_TYPE_ID() As  System.Nullable(Of Long) 
            Get
                Return _PATENT_TYPE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _PATENT_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property QTY() As Long
            Get
                Return _QTY
            End Get
            Set(ByVal value As Long)
               _QTY = value
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
            _PATENT_TYPE_ID = 0
            _QTY = 0
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


        '/// Returns an indication whether the current data is inserted into TB_PATENT table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _ID = DB.GetNextID("ID",tableName, trans)
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TB_PATENT table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return doUpdate("ID = " & DB.SetDouble(_ID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TB_PATENT table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_PATENT table successfully.
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


        '/// Returns an indication whether the record of TB_PATENT by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_PATENT by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbPatentLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_PATENT by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_PATENT table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_PATENT table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_PATENT table successfully.
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
            Dim cmbParam(7) As SqlParameter
            cmbParam(0) = New SqlParameter("@_ID", SqlDbType.BigInt)
            cmbParam(0).Value = _ID

            cmbParam(1) = New SqlParameter("@_REQ_NO", SqlDbType.VarChar)
            If _REQ_NO.Trim <> "" Then 
                cmbParam(1).Value = _REQ_NO
            Else
                cmbParam(1).Value = DBNull.value
            End If

            cmbParam(2) = New SqlParameter("@_APP_NO", SqlDbType.VarChar)
            If _APP_NO.Trim <> "" Then 
                cmbParam(2).Value = _APP_NO
            Else
                cmbParam(2).Value = DBNull.value
            End If

            cmbParam(3) = New SqlParameter("@_APP_NAME", SqlDbType.VarChar)
            If _APP_NAME.Trim <> "" Then 
                cmbParam(3).Value = _APP_NAME
            Else
                cmbParam(3).Value = DBNull.value
            End If

            cmbParam(4) = New SqlParameter("@_APP_POSITION", SqlDbType.VarChar)
            If _APP_POSITION.Trim <> "" Then 
                cmbParam(4).Value = _APP_POSITION
            Else
                cmbParam(4).Value = DBNull.value
            End If

            cmbParam(5) = New SqlParameter("@_APP_STATUS", SqlDbType.VarChar)
            If _APP_STATUS.Trim <> "" Then 
                cmbParam(5).Value = _APP_STATUS
            Else
                cmbParam(5).Value = DBNull.value
            End If

            cmbParam(6) = New SqlParameter("@_PATENT_TYPE_ID", SqlDbType.BigInt)
            If _PATENT_TYPE_ID IsNot Nothing Then 
                cmbParam(6).Value = _PATENT_TYPE_ID.Value
            Else
                cmbParam(6).Value = DBNull.value
            End IF

            cmbParam(7) = New SqlParameter("@_QTY", SqlDbType.Int)
            cmbParam(7).Value = _QTY

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_PATENT by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("req_no")) = False Then _req_no = Rdr("req_no").ToString()
                        If Convert.IsDBNull(Rdr("app_no")) = False Then _app_no = Rdr("app_no").ToString()
                        If Convert.IsDBNull(Rdr("app_name")) = False Then _app_name = Rdr("app_name").ToString()
                        If Convert.IsDBNull(Rdr("app_position")) = False Then _app_position = Rdr("app_position").ToString()
                        If Convert.IsDBNull(Rdr("app_status")) = False Then _app_status = Rdr("app_status").ToString()
                        If Convert.IsDBNull(Rdr("patent_type_id")) = False Then _patent_type_id = Convert.ToInt64(Rdr("patent_type_id"))
                        If Convert.IsDBNull(Rdr("qty")) = False Then _qty = Convert.ToInt32(Rdr("qty"))
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


        '/// Returns an indication whether the record of TB_PATENT by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbPatentLinqDB
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
                        If Convert.IsDBNull(Rdr("req_no")) = False Then _req_no = Rdr("req_no").ToString()
                        If Convert.IsDBNull(Rdr("app_no")) = False Then _app_no = Rdr("app_no").ToString()
                        If Convert.IsDBNull(Rdr("app_name")) = False Then _app_name = Rdr("app_name").ToString()
                        If Convert.IsDBNull(Rdr("app_position")) = False Then _app_position = Rdr("app_position").ToString()
                        If Convert.IsDBNull(Rdr("app_status")) = False Then _app_status = Rdr("app_status").ToString()
                        If Convert.IsDBNull(Rdr("patent_type_id")) = False Then _patent_type_id = Convert.ToInt64(Rdr("patent_type_id"))
                        If Convert.IsDBNull(Rdr("qty")) = False Then _qty = Convert.ToInt32(Rdr("qty"))
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


        'Get Insert Statement for table TB_PATENT
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, REQ_NO, APP_NO, APP_NAME, APP_POSITION, APP_STATUS, PATENT_TYPE_ID, QTY)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.REQ_NO, INSERTED.APP_NO, INSERTED.APP_NAME, INSERTED.APP_POSITION, INSERTED.APP_STATUS, INSERTED.PATENT_TYPE_ID, INSERTED.QTY
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_REQ_NO" & ", "
                sql += "@_APP_NO" & ", "
                sql += "@_APP_NAME" & ", "
                sql += "@_APP_POSITION" & ", "
                sql += "@_APP_STATUS" & ", "
                sql += "@_PATENT_TYPE_ID" & ", "
                sql += "@_QTY"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_PATENT
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "REQ_NO = " & "@_REQ_NO" & ", "
                Sql += "APP_NO = " & "@_APP_NO" & ", "
                Sql += "APP_NAME = " & "@_APP_NAME" & ", "
                Sql += "APP_POSITION = " & "@_APP_POSITION" & ", "
                Sql += "APP_STATUS = " & "@_APP_STATUS" & ", "
                Sql += "PATENT_TYPE_ID = " & "@_PATENT_TYPE_ID" & ", "
                Sql += "QTY = " & "@_QTY" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_PATENT
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_PATENT
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, REQ_NO, APP_NO, APP_NAME, APP_POSITION, APP_STATUS, PATENT_TYPE_ID, QTY FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

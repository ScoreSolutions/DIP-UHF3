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
    'Represents a transaction for TB_MODULE table LinqDB.
    '[Create by  on January, 15 2015]
    Public Class TbModuleLinqDB
        Public sub TbModuleLinqDB()

        End Sub 
        ' TB_MODULE
        Const _tableName As String = "TB_MODULE"
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
        Dim _MODULE_NAME As  String  = ""
        Dim _MODULE_DESC As  String  = ""
        Dim _CREATEBY As  String  = ""
        Dim _CREATEON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATEBY As  String  = ""
        Dim _UPDATEON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _MODULE_CODE As  String  = ""
        Dim _MODULE_IMG As  String  = ""
        Dim _MODULE_LINK As  String  = ""
        Dim _ISSHOWLINK As  System.Nullable(Of Char)  = ""
        Dim _SEQUENCE As Long = 0
        Dim _ACTIVE_STATUS As Char = "Y"

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
        <Column(Storage:="_MODULE_NAME", DbType:="VarChar(200)")>  _
        Public Property MODULE_NAME() As  String 
            Get
                Return _MODULE_NAME
            End Get
            Set(ByVal value As  String )
               _MODULE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_DESC", DbType:="VarChar(200)")>  _
        Public Property MODULE_DESC() As  String 
            Get
                Return _MODULE_DESC
            End Get
            Set(ByVal value As  String )
               _MODULE_DESC = value
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
        <Column(Storage:="_MODULE_CODE", DbType:="VarChar(50)")>  _
        Public Property MODULE_CODE() As  String 
            Get
                Return _MODULE_CODE
            End Get
            Set(ByVal value As  String )
               _MODULE_CODE = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_IMG", DbType:="VarChar(255)")>  _
        Public Property MODULE_IMG() As  String 
            Get
                Return _MODULE_IMG
            End Get
            Set(ByVal value As  String )
               _MODULE_IMG = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_LINK", DbType:="VarChar(255)")>  _
        Public Property MODULE_LINK() As  String 
            Get
                Return _MODULE_LINK
            End Get
            Set(ByVal value As  String )
               _MODULE_LINK = value
            End Set
        End Property 
        <Column(Storage:="_ISSHOWLINK", DbType:="Char(1)")>  _
        Public Property ISSHOWLINK() As  System.Nullable(Of Char) 
            Get
                Return _ISSHOWLINK
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _ISSHOWLINK = value
            End Set
        End Property 
        <Column(Storage:="_SEQUENCE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SEQUENCE() As Long
            Get
                Return _SEQUENCE
            End Get
            Set(ByVal value As Long)
               _SEQUENCE = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVE_STATUS", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ACTIVE_STATUS() As Char
            Get
                Return _ACTIVE_STATUS
            End Get
            Set(ByVal value As Char)
               _ACTIVE_STATUS = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _MODULE_NAME = ""
            _MODULE_DESC = ""
            _CREATEBY = ""
            _CREATEON = New DateTime(1,1,1)
            _UPDATEBY = ""
            _UPDATEON = New DateTime(1,1,1)
            _MODULE_CODE = ""
            _MODULE_IMG = ""
            _MODULE_LINK = ""
            _ISSHOWLINK = ""
            _SEQUENCE = 0
            _ACTIVE_STATUS = ""
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


        '/// Returns an indication whether the current data is inserted into TB_MODULE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_MODULE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_MODULE table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_MODULE table successfully.
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


        '/// Returns an indication whether the record of TB_MODULE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_MODULE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbModuleLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_MODULE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_MODULE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_MODULE table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_MODULE table successfully.
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
            Dim cmbParam(12) As SqlParameter
            cmbParam(0) = New SqlParameter("@_ID", SqlDbType.BigInt)
            cmbParam(0).Value = _ID

            cmbParam(1) = New SqlParameter("@_MODULE_NAME", SqlDbType.VarChar)
            If _MODULE_NAME.Trim <> "" Then 
                cmbParam(1).Value = _MODULE_NAME
            Else
                cmbParam(1).Value = DBNull.value
            End If

            cmbParam(2) = New SqlParameter("@_MODULE_DESC", SqlDbType.VarChar)
            If _MODULE_DESC.Trim <> "" Then 
                cmbParam(2).Value = _MODULE_DESC
            Else
                cmbParam(2).Value = DBNull.value
            End If

            cmbParam(3) = New SqlParameter("@_CREATEBY", SqlDbType.VarChar)
            If _CREATEBY.Trim <> "" Then 
                cmbParam(3).Value = _CREATEBY
            Else
                cmbParam(3).Value = DBNull.value
            End If

            cmbParam(4) = New SqlParameter("@_CREATEON", SqlDbType.DateTime)
            If _CREATEON.Value.Year > 1 Then 
                cmbParam(4).Value = _CREATEON.Value
            Else
                cmbParam(4).Value = DBNull.value
            End If

            cmbParam(5) = New SqlParameter("@_UPDATEBY", SqlDbType.VarChar)
            If _UPDATEBY.Trim <> "" Then 
                cmbParam(5).Value = _UPDATEBY
            Else
                cmbParam(5).Value = DBNull.value
            End If

            cmbParam(6) = New SqlParameter("@_UPDATEON", SqlDbType.DateTime)
            If _UPDATEON.Value.Year > 1 Then 
                cmbParam(6).Value = _UPDATEON.Value
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_MODULE_CODE", SqlDbType.VarChar)
            If _MODULE_CODE.Trim <> "" Then 
                cmbParam(7).Value = _MODULE_CODE
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_MODULE_IMG", SqlDbType.VarChar)
            If _MODULE_IMG.Trim <> "" Then 
                cmbParam(8).Value = _MODULE_IMG
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_MODULE_LINK", SqlDbType.VarChar)
            If _MODULE_LINK.Trim <> "" Then 
                cmbParam(9).Value = _MODULE_LINK
            Else
                cmbParam(9).Value = DBNull.value
            End If

            cmbParam(10) = New SqlParameter("@_ISSHOWLINK", SqlDbType.Char)
            If _ISSHOWLINK.Value <> "" Then 
                cmbParam(10).Value = _ISSHOWLINK.Value
            Else
                cmbParam(10).Value = DBNull.value
            End IF

            cmbParam(11) = New SqlParameter("@_SEQUENCE", SqlDbType.Int)
            cmbParam(11).Value = _SEQUENCE

            cmbParam(12) = New SqlParameter("@_ACTIVE_STATUS", SqlDbType.Char)
            cmbParam(12).Value = _ACTIVE_STATUS

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_MODULE by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("module_name")) = False Then _module_name = Rdr("module_name").ToString()
                        If Convert.IsDBNull(Rdr("module_desc")) = False Then _module_desc = Rdr("module_desc").ToString()
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
                        If Convert.IsDBNull(Rdr("module_code")) = False Then _module_code = Rdr("module_code").ToString()
                        If Convert.IsDBNull(Rdr("module_img")) = False Then _module_img = Rdr("module_img").ToString()
                        If Convert.IsDBNull(Rdr("module_link")) = False Then _module_link = Rdr("module_link").ToString()
                        If Convert.IsDBNull(Rdr("isshowlink")) = False Then _isshowlink = Rdr("isshowlink").ToString()
                        If Convert.IsDBNull(Rdr("sequence")) = False Then _sequence = Convert.ToInt32(Rdr("sequence"))
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Rdr("active_status").ToString()
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


        '/// Returns an indication whether the record of TB_MODULE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbModuleLinqDB
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
                        If Convert.IsDBNull(Rdr("module_name")) = False Then _module_name = Rdr("module_name").ToString()
                        If Convert.IsDBNull(Rdr("module_desc")) = False Then _module_desc = Rdr("module_desc").ToString()
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
                        If Convert.IsDBNull(Rdr("module_code")) = False Then _module_code = Rdr("module_code").ToString()
                        If Convert.IsDBNull(Rdr("module_img")) = False Then _module_img = Rdr("module_img").ToString()
                        If Convert.IsDBNull(Rdr("module_link")) = False Then _module_link = Rdr("module_link").ToString()
                        If Convert.IsDBNull(Rdr("isshowlink")) = False Then _isshowlink = Rdr("isshowlink").ToString()
                        If Convert.IsDBNull(Rdr("sequence")) = False Then _sequence = Convert.ToInt32(Rdr("sequence"))
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Rdr("active_status").ToString()
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


        'Get Insert Statement for table TB_MODULE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, MODULE_NAME, MODULE_DESC, CREATEBY, CREATEON, UPDATEBY, UPDATEON, MODULE_CODE, MODULE_IMG, MODULE_LINK, ISSHOWLINK, SEQUENCE, ACTIVE_STATUS)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.MODULE_NAME, INSERTED.MODULE_DESC, INSERTED.CREATEBY, INSERTED.CREATEON, INSERTED.UPDATEBY, INSERTED.UPDATEON, INSERTED.MODULE_CODE, INSERTED.MODULE_IMG, INSERTED.MODULE_LINK, INSERTED.ISSHOWLINK, INSERTED.SEQUENCE, INSERTED.ACTIVE_STATUS
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_MODULE_NAME" & ", "
                sql += "@_MODULE_DESC" & ", "
                sql += "@_CREATEBY" & ", "
                sql += "@_CREATEON" & ", "
                sql += "@_UPDATEBY" & ", "
                sql += "@_UPDATEON" & ", "
                sql += "@_MODULE_CODE" & ", "
                sql += "@_MODULE_IMG" & ", "
                sql += "@_MODULE_LINK" & ", "
                sql += "@_ISSHOWLINK" & ", "
                sql += "@_SEQUENCE" & ", "
                sql += "@_ACTIVE_STATUS"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_MODULE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "MODULE_NAME = " & "@_MODULE_NAME" & ", "
                Sql += "MODULE_DESC = " & "@_MODULE_DESC" & ", "
                Sql += "CREATEBY = " & "@_CREATEBY" & ", "
                Sql += "CREATEON = " & "@_CREATEON" & ", "
                Sql += "UPDATEBY = " & "@_UPDATEBY" & ", "
                Sql += "UPDATEON = " & "@_UPDATEON" & ", "
                Sql += "MODULE_CODE = " & "@_MODULE_CODE" & ", "
                Sql += "MODULE_IMG = " & "@_MODULE_IMG" & ", "
                Sql += "MODULE_LINK = " & "@_MODULE_LINK" & ", "
                Sql += "ISSHOWLINK = " & "@_ISSHOWLINK" & ", "
                Sql += "SEQUENCE = " & "@_SEQUENCE" & ", "
                Sql += "ACTIVE_STATUS = " & "@_ACTIVE_STATUS" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_MODULE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_MODULE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, MODULE_NAME, MODULE_DESC, CREATEBY, CREATEON, UPDATEBY, UPDATEON, MODULE_CODE, MODULE_IMG, MODULE_LINK, ISSHOWLINK, SEQUENCE, ACTIVE_STATUS FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

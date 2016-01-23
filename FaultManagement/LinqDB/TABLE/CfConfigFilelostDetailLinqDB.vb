Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = LinqDB.ConnectDB.SQLDB
Imports LinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for CF_CONFIG_FILELOST_DETAIL table LinqDB.
    '[Create by  on March, 2 2015]
    Public Class CfConfigFilelostDetailLinqDB
        Public sub CfConfigFilelostDetailLinqDB()

        End Sub 
        ' CF_CONFIG_FILELOST_DETAIL
        Const _tableName As String = "CF_CONFIG_FILELOST_DETAIL"
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
        Dim _CREATEDDATE As DateTime = New DateTime(1,1,1)
        Dim _CREATEDBY As String = ""
        Dim _UPDATEDDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATEDBY As  String  = ""
        Dim _CF_CONFIG_FILELOST_ID As Long = 0
        Dim _FILENAME As String = ""

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
        <Column(Storage:="_CREATEDDATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATEDDATE() As DateTime
            Get
                Return _CREATEDDATE
            End Get
            Set(ByVal value As DateTime)
               _CREATEDDATE = value
            End Set
        End Property 
        <Column(Storage:="_CREATEDBY", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATEDBY() As String
            Get
                Return _CREATEDBY
            End Get
            Set(ByVal value As String)
               _CREATEDBY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATEDDATE", DbType:="DateTime")>  _
        Public Property UPDATEDDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATEDDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATEDDATE = value
            End Set
        End Property 
        <Column(Storage:="_UPDATEDBY", DbType:="VarChar(100)")>  _
        Public Property UPDATEDBY() As  String 
            Get
                Return _UPDATEDBY
            End Get
            Set(ByVal value As  String )
               _UPDATEDBY = value
            End Set
        End Property 
        <Column(Storage:="_CF_CONFIG_FILELOST_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property CF_CONFIG_FILELOST_ID() As Long
            Get
                Return _CF_CONFIG_FILELOST_ID
            End Get
            Set(ByVal value As Long)
               _CF_CONFIG_FILELOST_ID = value
            End Set
        End Property 
        <Column(Storage:="_FILENAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property FILENAME() As String
            Get
                Return _FILENAME
            End Get
            Set(ByVal value As String)
               _FILENAME = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATEDDATE = New DateTime(1,1,1)
            _CREATEDBY = ""
            _UPDATEDDATE = New DateTime(1,1,1)
            _UPDATEDBY = ""
            _CF_CONFIG_FILELOST_ID = 0
            _FILENAME = ""
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


        '/// Returns an indication whether the current data is inserted into CF_CONFIG_FILELOST_DETAIL table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _ID = DB.GetNextID("ID",tableName, trans)
                _CreatedBy = LoginName
                _CreatedDate = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to CF_CONFIG_FILELOST_DETAIL table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _UpdatedBy = LoginName
                _UpdatedDate = DateTime.Now
                Return doUpdate("ID = " & DB.SetDouble(_ID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to CF_CONFIG_FILELOST_DETAIL table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from CF_CONFIG_FILELOST_DETAIL table successfully.
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


        '/// Returns an indication whether the record of CF_CONFIG_FILELOST_DETAIL by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of CF_CONFIG_FILELOST_DETAIL by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As CfConfigFilelostDetailLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of CF_CONFIG_FILELOST_DETAIL by specified CF_CONFIG_FILELOST_ID_FILENAME key is retrieved successfully.
        '/// <param name=cCF_CONFIG_FILELOST_ID_FILENAME>The CF_CONFIG_FILELOST_ID_FILENAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByCF_CONFIG_FILELOST_ID_FILENAME(cCF_CONFIG_FILELOST_ID As Long, cFILENAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("CF_CONFIG_FILELOST_ID = " & DB.SetDouble(cCF_CONFIG_FILELOST_ID) & " AND FILENAME = " & DB.SetString(cFILENAME), trans)
        End Function

        '/// Returns an duplicate data record of CF_CONFIG_FILELOST_DETAIL by specified CF_CONFIG_FILELOST_ID_FILENAME key is retrieved successfully.
        '/// <param name=cCF_CONFIG_FILELOST_ID_FILENAME>The CF_CONFIG_FILELOST_ID_FILENAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByCF_CONFIG_FILELOST_ID_FILENAME(cCF_CONFIG_FILELOST_ID As Long, cFILENAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("CF_CONFIG_FILELOST_ID = " & DB.SetDouble(cCF_CONFIG_FILELOST_ID) & " AND FILENAME = " & DB.SetString(cFILENAME) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of CF_CONFIG_FILELOST_DETAIL by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into CF_CONFIG_FILELOST_DETAIL table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try

                    ret = (DB.ExecuteNonQuery(SqlInsert, trans) > 0)
                    If ret = False Then
                        _error = DB.ErrorMessage
                    Else
                        _haveData = True
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


        '/// Returns an indication whether the current data is updated to CF_CONFIG_FILELOST_DETAIL table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If _haveData = True Then
                If whText.Trim() <> ""
                    Try

                        ret = (DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans) > 0)
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
                ret = False
                _error = MessageResources.MSGEU002 & "### SQL: " & SqlUpdate & tmpWhere
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from CF_CONFIG_FILELOST_DETAIL table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > 0)
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
                ret = False
                _error = MessageResources.MSGEU002 & "### SQL: " & SqlDelete & tmpWhere
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of CF_CONFIG_FILELOST_DETAIL by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("CreatedDate")) = False Then _CreatedDate = Convert.ToDateTime(Rdr("CreatedDate"))
                        If Convert.IsDBNull(Rdr("CreatedBy")) = False Then _CreatedBy = Rdr("CreatedBy").ToString()
                        If Convert.IsDBNull(Rdr("UpdatedDate")) = False Then _UpdatedDate = Convert.ToDateTime(Rdr("UpdatedDate"))
                        If Convert.IsDBNull(Rdr("UpdatedBy")) = False Then _UpdatedBy = Rdr("UpdatedBy").ToString()
                        If Convert.IsDBNull(Rdr("cf_config_filelost_id")) = False Then _cf_config_filelost_id = Convert.ToInt64(Rdr("cf_config_filelost_id"))
                        If Convert.IsDBNull(Rdr("FileName")) = False Then _FileName = Rdr("FileName").ToString()
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


        '/// Returns an indication whether the record of CF_CONFIG_FILELOST_DETAIL by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As CfConfigFilelostDetailLinqDB
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
                        If Convert.IsDBNull(Rdr("CreatedDate")) = False Then _CreatedDate = Convert.ToDateTime(Rdr("CreatedDate"))
                        If Convert.IsDBNull(Rdr("CreatedBy")) = False Then _CreatedBy = Rdr("CreatedBy").ToString()
                        If Convert.IsDBNull(Rdr("UpdatedDate")) = False Then _UpdatedDate = Convert.ToDateTime(Rdr("UpdatedDate"))
                        If Convert.IsDBNull(Rdr("UpdatedBy")) = False Then _UpdatedBy = Rdr("UpdatedBy").ToString()
                        If Convert.IsDBNull(Rdr("cf_config_filelost_id")) = False Then _cf_config_filelost_id = Convert.ToInt64(Rdr("cf_config_filelost_id"))
                        If Convert.IsDBNull(Rdr("FileName")) = False Then _FileName = Rdr("FileName").ToString()
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


        'Get Insert Statement for table CF_CONFIG_FILELOST_DETAIL
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATEDDATE, CREATEDBY, CF_CONFIG_FILELOST_ID, FILENAME)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetDateTime(_CREATEDDATE) & ", "
                sql += DB.SetString(_CREATEDBY) & ", "
                sql += DB.SetDouble(_CF_CONFIG_FILELOST_ID) & ", "
                sql += DB.SetString(_FILENAME)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table CF_CONFIG_FILELOST_DETAIL
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATEDDATE = " & DB.SetDateTime(_UPDATEDDATE) & ", "
                Sql += "UPDATEDBY = " & DB.SetString(_UPDATEDBY) & ", "
                Sql += "CF_CONFIG_FILELOST_ID = " & DB.SetDouble(_CF_CONFIG_FILELOST_ID) & ", "
                Sql += "FILENAME = " & DB.SetString(_FILENAME) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table CF_CONFIG_FILELOST_DETAIL
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table CF_CONFIG_FILELOST_DETAIL
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATEDDATE, CREATEDBY, UPDATEDDATE, UPDATEDBY, CF_CONFIG_FILELOST_ID, FILENAME FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace

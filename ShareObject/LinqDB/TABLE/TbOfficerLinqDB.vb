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
    'Represents a transaction for TB_OFFICER table LinqDB.
    '[Create by  on August, 7 2015]
    Public Class TbOfficerLinqDB
        Public sub TbOfficerLinqDB()

        End Sub 
        ' TB_OFFICER
        Const _tableName As String = "TB_OFFICER"
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
        Dim _OFFICER_NO As String = ""
        Dim _FNAME As  String  = ""
        Dim _LNAME As  String  = ""
        Dim _DEPARTMENT_ID As  System.Nullable(Of Long)  = 0
        Dim _POSITION_ID As  System.Nullable(Of Long)  = 0
        Dim _USERNAME As  String  = ""
        Dim _PASSWORD As  String  = ""
        Dim _CREATEBY As  String  = ""
        Dim _CREATEON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATEBY As  String  = ""
        Dim _UPDATEON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _TITLE_ID As  System.Nullable(Of Long)  = 0
        Dim _MIFARE_CARD_ID As  String  = ""
        Dim _EMAIL As  String  = ""
        Dim _IS_CHANGE_PWD As Char = "N"

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
        <Column(Storage:="_OFFICER_NO", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property OFFICER_NO() As String
            Get
                Return _OFFICER_NO
            End Get
            Set(ByVal value As String)
               _OFFICER_NO = value
            End Set
        End Property 
        <Column(Storage:="_FNAME", DbType:="VarChar(200)")>  _
        Public Property FNAME() As  String 
            Get
                Return _FNAME
            End Get
            Set(ByVal value As  String )
               _FNAME = value
            End Set
        End Property 
        <Column(Storage:="_LNAME", DbType:="VarChar(200)")>  _
        Public Property LNAME() As  String 
            Get
                Return _LNAME
            End Get
            Set(ByVal value As  String )
               _LNAME = value
            End Set
        End Property 
        <Column(Storage:="_DEPARTMENT_ID", DbType:="BigInt")>  _
        Public Property DEPARTMENT_ID() As  System.Nullable(Of Long) 
            Get
                Return _DEPARTMENT_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DEPARTMENT_ID = value
            End Set
        End Property 
        <Column(Storage:="_POSITION_ID", DbType:="BigInt")>  _
        Public Property POSITION_ID() As  System.Nullable(Of Long) 
            Get
                Return _POSITION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _POSITION_ID = value
            End Set
        End Property 
        <Column(Storage:="_USERNAME", DbType:="VarChar(50)")>  _
        Public Property USERNAME() As  String 
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As  String )
               _USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_PASSWORD", DbType:="VarChar(50)")>  _
        Public Property PASSWORD() As  String 
            Get
                Return _PASSWORD
            End Get
            Set(ByVal value As  String )
               _PASSWORD = value
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
        <Column(Storage:="_TITLE_ID", DbType:="BigInt")>  _
        Public Property TITLE_ID() As  System.Nullable(Of Long) 
            Get
                Return _TITLE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _TITLE_ID = value
            End Set
        End Property 
        <Column(Storage:="_MIFARE_CARD_ID", DbType:="VarChar(50)")>  _
        Public Property MIFARE_CARD_ID() As  String 
            Get
                Return _MIFARE_CARD_ID
            End Get
            Set(ByVal value As  String )
               _MIFARE_CARD_ID = value
            End Set
        End Property 
        <Column(Storage:="_EMAIL", DbType:="VarChar(255)")>  _
        Public Property EMAIL() As  String 
            Get
                Return _EMAIL
            End Get
            Set(ByVal value As  String )
               _EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_IS_CHANGE_PWD", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_CHANGE_PWD() As Char
            Get
                Return _IS_CHANGE_PWD
            End Get
            Set(ByVal value As Char)
               _IS_CHANGE_PWD = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _OFFICER_NO = ""
            _FNAME = ""
            _LNAME = ""
            _DEPARTMENT_ID = 0
            _POSITION_ID = 0
            _USERNAME = ""
            _PASSWORD = ""
            _CREATEBY = ""
            _CREATEON = New DateTime(1,1,1)
            _UPDATEBY = ""
            _UPDATEON = New DateTime(1,1,1)
            _TITLE_ID = 0
            _MIFARE_CARD_ID = ""
            _EMAIL = ""
            _IS_CHANGE_PWD = "N"
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


        '/// Returns an indication whether the current data is inserted into TB_OFFICER table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_OFFICER table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_OFFICER table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_OFFICER table successfully.
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


        '/// Returns an indication whether the record of TB_OFFICER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_OFFICER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbOfficerLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_OFFICER by specified MIFARE_CARD_ID key is retrieved successfully.
        '/// <param name=cMIFARE_CARD_ID>The MIFARE_CARD_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMIFARE_CARD_ID(cMIFARE_CARD_ID As String, trans As SQLTransaction) As Boolean
            Return doChkData("MIFARE_CARD_ID = " & DB.SetString(cMIFARE_CARD_ID) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_OFFICER by specified MIFARE_CARD_ID key is retrieved successfully.
        '/// <param name=cMIFARE_CARD_ID>The MIFARE_CARD_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMIFARE_CARD_ID(cMIFARE_CARD_ID As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MIFARE_CARD_ID = " & DB.SetString(cMIFARE_CARD_ID) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_OFFICER by specified USERNAME key is retrieved successfully.
        '/// <param name=cUSERNAME>The USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByUSERNAME(cUSERNAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("USERNAME = " & DB.SetString(cUSERNAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_OFFICER by specified USERNAME key is retrieved successfully.
        '/// <param name=cUSERNAME>The USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByUSERNAME(cUSERNAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("USERNAME = " & DB.SetString(cUSERNAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_OFFICER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_OFFICER table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_OFFICER table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_OFFICER table successfully.
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
            Dim cmbParam(15) As SqlParameter
            cmbParam(0) = New SqlParameter("@_ID", SqlDbType.BigInt)
            cmbParam(0).Value = _ID

            cmbParam(1) = New SqlParameter("@_OFFICER_NO", SqlDbType.VarChar)
            cmbParam(1).Value = _OFFICER_NO

            cmbParam(2) = New SqlParameter("@_FNAME", SqlDbType.VarChar)
            If _FNAME.Trim <> "" Then 
                cmbParam(2).Value = _FNAME
            Else
                cmbParam(2).Value = DBNull.value
            End If

            cmbParam(3) = New SqlParameter("@_LNAME", SqlDbType.VarChar)
            If _LNAME.Trim <> "" Then 
                cmbParam(3).Value = _LNAME
            Else
                cmbParam(3).Value = DBNull.value
            End If

            cmbParam(4) = New SqlParameter("@_DEPARTMENT_ID", SqlDbType.BigInt)
            If _DEPARTMENT_ID IsNot Nothing Then 
                cmbParam(4).Value = _DEPARTMENT_ID.Value
            Else
                cmbParam(4).Value = DBNull.value
            End IF

            cmbParam(5) = New SqlParameter("@_POSITION_ID", SqlDbType.BigInt)
            If _POSITION_ID IsNot Nothing Then 
                cmbParam(5).Value = _POSITION_ID.Value
            Else
                cmbParam(5).Value = DBNull.value
            End IF

            cmbParam(6) = New SqlParameter("@_USERNAME", SqlDbType.VarChar)
            If _USERNAME.Trim <> "" Then 
                cmbParam(6).Value = _USERNAME
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_PASSWORD", SqlDbType.VarChar)
            If _PASSWORD.Trim <> "" Then 
                cmbParam(7).Value = _PASSWORD
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_CREATEBY", SqlDbType.VarChar)
            If _CREATEBY.Trim <> "" Then 
                cmbParam(8).Value = _CREATEBY
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_CREATEON", SqlDbType.DateTime)
            If _CREATEON.Value.Year > 1 Then 
                cmbParam(9).Value = _CREATEON.Value
            Else
                cmbParam(9).Value = DBNull.value
            End If

            cmbParam(10) = New SqlParameter("@_UPDATEBY", SqlDbType.VarChar)
            If _UPDATEBY.Trim <> "" Then 
                cmbParam(10).Value = _UPDATEBY
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_UPDATEON", SqlDbType.DateTime)
            If _UPDATEON.Value.Year > 1 Then 
                cmbParam(11).Value = _UPDATEON.Value
            Else
                cmbParam(11).Value = DBNull.value
            End If

            cmbParam(12) = New SqlParameter("@_TITLE_ID", SqlDbType.BigInt)
            If _TITLE_ID IsNot Nothing Then 
                cmbParam(12).Value = _TITLE_ID.Value
            Else
                cmbParam(12).Value = DBNull.value
            End IF

            cmbParam(13) = New SqlParameter("@_MIFARE_CARD_ID", SqlDbType.VarChar)
            If _MIFARE_CARD_ID.Trim <> "" Then 
                cmbParam(13).Value = _MIFARE_CARD_ID
            Else
                cmbParam(13).Value = DBNull.value
            End If

            cmbParam(14) = New SqlParameter("@_EMAIL", SqlDbType.VarChar)
            If _EMAIL.Trim <> "" Then 
                cmbParam(14).Value = _EMAIL
            Else
                cmbParam(14).Value = DBNull.value
            End If

            cmbParam(15) = New SqlParameter("@_IS_CHANGE_PWD", SqlDbType.Char)
            cmbParam(15).Value = _IS_CHANGE_PWD

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_OFFICER by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("officer_no")) = False Then _officer_no = Rdr("officer_no").ToString()
                        If Convert.IsDBNull(Rdr("fname")) = False Then _fname = Rdr("fname").ToString()
                        If Convert.IsDBNull(Rdr("lname")) = False Then _lname = Rdr("lname").ToString()
                        If Convert.IsDBNull(Rdr("department_id")) = False Then _department_id = Convert.ToInt64(Rdr("department_id"))
                        If Convert.IsDBNull(Rdr("position_id")) = False Then _position_id = Convert.ToInt64(Rdr("position_id"))
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("password")) = False Then _password = Rdr("password").ToString()
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
                        If Convert.IsDBNull(Rdr("title_id")) = False Then _title_id = Convert.ToInt64(Rdr("title_id"))
                        If Convert.IsDBNull(Rdr("mifare_card_id")) = False Then _mifare_card_id = Rdr("mifare_card_id").ToString()
                        If Convert.IsDBNull(Rdr("email")) = False Then _email = Rdr("email").ToString()
                        If Convert.IsDBNull(Rdr("is_change_pwd")) = False Then _is_change_pwd = Rdr("is_change_pwd").ToString()
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


        '/// Returns an indication whether the record of TB_OFFICER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbOfficerLinqDB
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
                        If Convert.IsDBNull(Rdr("officer_no")) = False Then _officer_no = Rdr("officer_no").ToString()
                        If Convert.IsDBNull(Rdr("fname")) = False Then _fname = Rdr("fname").ToString()
                        If Convert.IsDBNull(Rdr("lname")) = False Then _lname = Rdr("lname").ToString()
                        If Convert.IsDBNull(Rdr("department_id")) = False Then _department_id = Convert.ToInt64(Rdr("department_id"))
                        If Convert.IsDBNull(Rdr("position_id")) = False Then _position_id = Convert.ToInt64(Rdr("position_id"))
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("password")) = False Then _password = Rdr("password").ToString()
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
                        If Convert.IsDBNull(Rdr("title_id")) = False Then _title_id = Convert.ToInt64(Rdr("title_id"))
                        If Convert.IsDBNull(Rdr("mifare_card_id")) = False Then _mifare_card_id = Rdr("mifare_card_id").ToString()
                        If Convert.IsDBNull(Rdr("email")) = False Then _email = Rdr("email").ToString()
                        If Convert.IsDBNull(Rdr("is_change_pwd")) = False Then _is_change_pwd = Rdr("is_change_pwd").ToString()
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


        'Get Insert Statement for table TB_OFFICER
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, OFFICER_NO, FNAME, LNAME, DEPARTMENT_ID, POSITION_ID, USERNAME, PASSWORD, CREATEBY, CREATEON, UPDATEBY, UPDATEON, TITLE_ID, MIFARE_CARD_ID, EMAIL, IS_CHANGE_PWD)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.OFFICER_NO, INSERTED.FNAME, INSERTED.LNAME, INSERTED.DEPARTMENT_ID, INSERTED.POSITION_ID, INSERTED.USERNAME, INSERTED.PASSWORD, INSERTED.CREATEBY, INSERTED.CREATEON, INSERTED.UPDATEBY, INSERTED.UPDATEON, INSERTED.TITLE_ID, INSERTED.MIFARE_CARD_ID, INSERTED.EMAIL, INSERTED.IS_CHANGE_PWD
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_OFFICER_NO" & ", "
                sql += "@_FNAME" & ", "
                sql += "@_LNAME" & ", "
                sql += "@_DEPARTMENT_ID" & ", "
                sql += "@_POSITION_ID" & ", "
                sql += "@_USERNAME" & ", "
                sql += "@_PASSWORD" & ", "
                sql += "@_CREATEBY" & ", "
                sql += "@_CREATEON" & ", "
                sql += "@_UPDATEBY" & ", "
                sql += "@_UPDATEON" & ", "
                sql += "@_TITLE_ID" & ", "
                sql += "@_MIFARE_CARD_ID" & ", "
                sql += "@_EMAIL" & ", "
                sql += "@_IS_CHANGE_PWD"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_OFFICER
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "OFFICER_NO = " & "@_OFFICER_NO" & ", "
                Sql += "FNAME = " & "@_FNAME" & ", "
                Sql += "LNAME = " & "@_LNAME" & ", "
                Sql += "DEPARTMENT_ID = " & "@_DEPARTMENT_ID" & ", "
                Sql += "POSITION_ID = " & "@_POSITION_ID" & ", "
                Sql += "USERNAME = " & "@_USERNAME" & ", "
                Sql += "PASSWORD = " & "@_PASSWORD" & ", "
                Sql += "CREATEBY = " & "@_CREATEBY" & ", "
                Sql += "CREATEON = " & "@_CREATEON" & ", "
                Sql += "UPDATEBY = " & "@_UPDATEBY" & ", "
                Sql += "UPDATEON = " & "@_UPDATEON" & ", "
                Sql += "TITLE_ID = " & "@_TITLE_ID" & ", "
                Sql += "MIFARE_CARD_ID = " & "@_MIFARE_CARD_ID" & ", "
                Sql += "EMAIL = " & "@_EMAIL" & ", "
                Sql += "IS_CHANGE_PWD = " & "@_IS_CHANGE_PWD" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_OFFICER
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_OFFICER
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, OFFICER_NO, FNAME, LNAME, DEPARTMENT_ID, POSITION_ID, USERNAME, PASSWORD, CREATEBY, CREATEON, UPDATEBY, UPDATEON, TITLE_ID, MIFARE_CARD_ID, EMAIL, IS_CHANGE_PWD FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

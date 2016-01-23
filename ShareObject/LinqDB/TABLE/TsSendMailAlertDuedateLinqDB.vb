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
    'Represents a transaction for TS_SEND_MAIL_ALERT_DUEDATE table LinqDB.
    '[Create by  on April, 1 2015]
    Public Class TsSendMailAlertDuedateLinqDB
        Public sub TsSendMailAlertDuedateLinqDB()

        End Sub 
        ' TS_SEND_MAIL_ALERT_DUEDATE
        Const _tableName As String = "TS_SEND_MAIL_ALERT_DUEDATE"
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
        Dim _TB_FILEBORROWITEM_ID As Long = 0
        Dim _BORROWER_NAME As String = ""
        Dim _BORROW_DATE As DateTime = New DateTime(1,1,1)
        Dim _DUE_DATE As DateTime = New DateTime(1,1,1)
        Dim _EMAIL As String = ""
        Dim _MAIL_ALERT_TYPE As Char = "1"
        Dim _SENT_MAIL_DATE As DateTime = New DateTime(1,1,1)
        Dim _APP_NO As String = ""
        Dim _PATENT_TYPE_NAME As String = ""

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
        <Column(Storage:="_TB_FILEBORROWITEM_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property TB_FILEBORROWITEM_ID() As Long
            Get
                Return _TB_FILEBORROWITEM_ID
            End Get
            Set(ByVal value As Long)
               _TB_FILEBORROWITEM_ID = value
            End Set
        End Property 
        <Column(Storage:="_BORROWER_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property BORROWER_NAME() As String
            Get
                Return _BORROWER_NAME
            End Get
            Set(ByVal value As String)
               _BORROWER_NAME = value
            End Set
        End Property 
        <Column(Storage:="_BORROW_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property BORROW_DATE() As DateTime
            Get
                Return _BORROW_DATE
            End Get
            Set(ByVal value As DateTime)
               _BORROW_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DUE_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property DUE_DATE() As DateTime
            Get
                Return _DUE_DATE
            End Get
            Set(ByVal value As DateTime)
               _DUE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_EMAIL", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property EMAIL() As String
            Get
                Return _EMAIL
            End Get
            Set(ByVal value As String)
               _EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_MAIL_ALERT_TYPE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property MAIL_ALERT_TYPE() As Char
            Get
                Return _MAIL_ALERT_TYPE
            End Get
            Set(ByVal value As Char)
               _MAIL_ALERT_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_SENT_MAIL_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property SENT_MAIL_DATE() As DateTime
            Get
                Return _SENT_MAIL_DATE
            End Get
            Set(ByVal value As DateTime)
               _SENT_MAIL_DATE = value
            End Set
        End Property 
        <Column(Storage:="_APP_NO", DbType:="VarChar(20) NOT NULL ",CanBeNull:=false)>  _
        Public Property APP_NO() As String
            Get
                Return _APP_NO
            End Get
            Set(ByVal value As String)
               _APP_NO = value
            End Set
        End Property 
        <Column(Storage:="_PATENT_TYPE_NAME", DbType:="VarChar(200) NOT NULL ",CanBeNull:=false)>  _
        Public Property PATENT_TYPE_NAME() As String
            Get
                Return _PATENT_TYPE_NAME
            End Get
            Set(ByVal value As String)
               _PATENT_TYPE_NAME = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _TB_FILEBORROWITEM_ID = 0
            _BORROWER_NAME = ""
            _BORROW_DATE = New DateTime(1,1,1)
            _DUE_DATE = New DateTime(1,1,1)
            _EMAIL = ""
            _MAIL_ALERT_TYPE = "1"
            _SENT_MAIL_DATE = New DateTime(1,1,1)
            _APP_NO = ""
            _PATENT_TYPE_NAME = ""
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


        '/// Returns an indication whether the current data is inserted into TS_SEND_MAIL_ALERT_DUEDATE table successfully.
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


        '/// Returns an indication whether the current data is updated to TS_SEND_MAIL_ALERT_DUEDATE table successfully.
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


        '/// Returns an indication whether the current data is updated to TS_SEND_MAIL_ALERT_DUEDATE table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TS_SEND_MAIL_ALERT_DUEDATE table successfully.
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


        '/// Returns an indication whether the record of TS_SEND_MAIL_ALERT_DUEDATE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TS_SEND_MAIL_ALERT_DUEDATE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TsSendMailAlertDuedateLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TS_SEND_MAIL_ALERT_DUEDATE by specified MAIL_ALERT_TYPE_TB_FILEBORROWITEM_ID key is retrieved successfully.
        '/// <param name=cMAIL_ALERT_TYPE_TB_FILEBORROWITEM_ID>The MAIL_ALERT_TYPE_TB_FILEBORROWITEM_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMAIL_ALERT_TYPE_TB_FILEBORROWITEM_ID(cMAIL_ALERT_TYPE As String, cTB_FILEBORROWITEM_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MAIL_ALERT_TYPE = " & DB.SetString(cMAIL_ALERT_TYPE) & " AND TB_FILEBORROWITEM_ID = " & DB.SetDouble(cTB_FILEBORROWITEM_ID), trans)
        End Function

        '/// Returns an duplicate data record of TS_SEND_MAIL_ALERT_DUEDATE by specified MAIL_ALERT_TYPE_TB_FILEBORROWITEM_ID key is retrieved successfully.
        '/// <param name=cMAIL_ALERT_TYPE_TB_FILEBORROWITEM_ID>The MAIL_ALERT_TYPE_TB_FILEBORROWITEM_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMAIL_ALERT_TYPE_TB_FILEBORROWITEM_ID(cMAIL_ALERT_TYPE As String, cTB_FILEBORROWITEM_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MAIL_ALERT_TYPE = " & DB.SetString(cMAIL_ALERT_TYPE) & " AND TB_FILEBORROWITEM_ID = " & DB.SetDouble(cTB_FILEBORROWITEM_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_SEND_MAIL_ALERT_DUEDATE by specified APP_NO key is retrieved successfully.
        '/// <param name=cAPP_NO>The APP_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByAPP_NO(cAPP_NO As String, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TS_SEND_MAIL_ALERT_DUEDATE by specified APP_NO key is retrieved successfully.
        '/// <param name=cAPP_NO>The APP_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByAPP_NO(cAPP_NO As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_SEND_MAIL_ALERT_DUEDATE by specified BORROWER_NAME key is retrieved successfully.
        '/// <param name=cBORROWER_NAME>The BORROWER_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByBORROWER_NAME(cBORROWER_NAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("BORROWER_NAME = " & DB.SetString(cBORROWER_NAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TS_SEND_MAIL_ALERT_DUEDATE by specified BORROWER_NAME key is retrieved successfully.
        '/// <param name=cBORROWER_NAME>The BORROWER_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByBORROWER_NAME(cBORROWER_NAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("BORROWER_NAME = " & DB.SetString(cBORROWER_NAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_SEND_MAIL_ALERT_DUEDATE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TS_SEND_MAIL_ALERT_DUEDATE table successfully.
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


        '/// Returns an indication whether the current data is updated to TS_SEND_MAIL_ALERT_DUEDATE table successfully.
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


        '/// Returns an indication whether the current data is deleted from TS_SEND_MAIL_ALERT_DUEDATE table successfully.
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

            cmbParam(5) = New SqlParameter("@_TB_FILEBORROWITEM_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _TB_FILEBORROWITEM_ID

            cmbParam(6) = New SqlParameter("@_BORROWER_NAME", SqlDbType.VarChar)
            cmbParam(6).Value = _BORROWER_NAME

            cmbParam(7) = New SqlParameter("@_BORROW_DATE", SqlDbType.DateTime)
            cmbParam(7).Value = _BORROW_DATE

            cmbParam(8) = New SqlParameter("@_DUE_DATE", SqlDbType.DateTime)
            cmbParam(8).Value = _DUE_DATE

            cmbParam(9) = New SqlParameter("@_EMAIL", SqlDbType.VarChar)
            cmbParam(9).Value = _EMAIL

            cmbParam(10) = New SqlParameter("@_MAIL_ALERT_TYPE", SqlDbType.Char)
            cmbParam(10).Value = _MAIL_ALERT_TYPE

            cmbParam(11) = New SqlParameter("@_SENT_MAIL_DATE", SqlDbType.DateTime)
            cmbParam(11).Value = _SENT_MAIL_DATE

            cmbParam(12) = New SqlParameter("@_APP_NO", SqlDbType.VarChar)
            cmbParam(12).Value = _APP_NO

            cmbParam(13) = New SqlParameter("@_PATENT_TYPE_NAME", SqlDbType.VarChar)
            cmbParam(13).Value = _PATENT_TYPE_NAME

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TS_SEND_MAIL_ALERT_DUEDATE by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("tb_fileborrowitem_id")) = False Then _tb_fileborrowitem_id = Convert.ToInt64(Rdr("tb_fileborrowitem_id"))
                        If Convert.IsDBNull(Rdr("borrower_name")) = False Then _borrower_name = Rdr("borrower_name").ToString()
                        If Convert.IsDBNull(Rdr("borrow_date")) = False Then _borrow_date = Convert.ToDateTime(Rdr("borrow_date"))
                        If Convert.IsDBNull(Rdr("due_date")) = False Then _due_date = Convert.ToDateTime(Rdr("due_date"))
                        If Convert.IsDBNull(Rdr("email")) = False Then _email = Rdr("email").ToString()
                        If Convert.IsDBNull(Rdr("mail_alert_type")) = False Then _mail_alert_type = Rdr("mail_alert_type").ToString()
                        If Convert.IsDBNull(Rdr("sent_mail_date")) = False Then _sent_mail_date = Convert.ToDateTime(Rdr("sent_mail_date"))
                        If Convert.IsDBNull(Rdr("app_no")) = False Then _app_no = Rdr("app_no").ToString()
                        If Convert.IsDBNull(Rdr("patent_type_name")) = False Then _patent_type_name = Rdr("patent_type_name").ToString()
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


        '/// Returns an indication whether the record of TS_SEND_MAIL_ALERT_DUEDATE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TsSendMailAlertDuedateLinqDB
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
                        If Convert.IsDBNull(Rdr("tb_fileborrowitem_id")) = False Then _tb_fileborrowitem_id = Convert.ToInt64(Rdr("tb_fileborrowitem_id"))
                        If Convert.IsDBNull(Rdr("borrower_name")) = False Then _borrower_name = Rdr("borrower_name").ToString()
                        If Convert.IsDBNull(Rdr("borrow_date")) = False Then _borrow_date = Convert.ToDateTime(Rdr("borrow_date"))
                        If Convert.IsDBNull(Rdr("due_date")) = False Then _due_date = Convert.ToDateTime(Rdr("due_date"))
                        If Convert.IsDBNull(Rdr("email")) = False Then _email = Rdr("email").ToString()
                        If Convert.IsDBNull(Rdr("mail_alert_type")) = False Then _mail_alert_type = Rdr("mail_alert_type").ToString()
                        If Convert.IsDBNull(Rdr("sent_mail_date")) = False Then _sent_mail_date = Convert.ToDateTime(Rdr("sent_mail_date"))
                        If Convert.IsDBNull(Rdr("app_no")) = False Then _app_no = Rdr("app_no").ToString()
                        If Convert.IsDBNull(Rdr("patent_type_name")) = False Then _patent_type_name = Rdr("patent_type_name").ToString()
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


        'Get Insert Statement for table TS_SEND_MAIL_ALERT_DUEDATE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, TB_FILEBORROWITEM_ID, BORROWER_NAME, BORROW_DATE, DUE_DATE, EMAIL, MAIL_ALERT_TYPE, SENT_MAIL_DATE, APP_NO, PATENT_TYPE_NAME)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.TB_FILEBORROWITEM_ID, INSERTED.BORROWER_NAME, INSERTED.BORROW_DATE, INSERTED.DUE_DATE, INSERTED.EMAIL, INSERTED.MAIL_ALERT_TYPE, INSERTED.SENT_MAIL_DATE, INSERTED.APP_NO, INSERTED.PATENT_TYPE_NAME
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_TB_FILEBORROWITEM_ID" & ", "
                sql += "@_BORROWER_NAME" & ", "
                sql += "@_BORROW_DATE" & ", "
                sql += "@_DUE_DATE" & ", "
                sql += "@_EMAIL" & ", "
                sql += "@_MAIL_ALERT_TYPE" & ", "
                sql += "@_SENT_MAIL_DATE" & ", "
                sql += "@_APP_NO" & ", "
                sql += "@_PATENT_TYPE_NAME"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TS_SEND_MAIL_ALERT_DUEDATE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "TB_FILEBORROWITEM_ID = " & "@_TB_FILEBORROWITEM_ID" & ", "
                Sql += "BORROWER_NAME = " & "@_BORROWER_NAME" & ", "
                Sql += "BORROW_DATE = " & "@_BORROW_DATE" & ", "
                Sql += "DUE_DATE = " & "@_DUE_DATE" & ", "
                Sql += "EMAIL = " & "@_EMAIL" & ", "
                Sql += "MAIL_ALERT_TYPE = " & "@_MAIL_ALERT_TYPE" & ", "
                Sql += "SENT_MAIL_DATE = " & "@_SENT_MAIL_DATE" & ", "
                Sql += "APP_NO = " & "@_APP_NO" & ", "
                Sql += "PATENT_TYPE_NAME = " & "@_PATENT_TYPE_NAME" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TS_SEND_MAIL_ALERT_DUEDATE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TS_SEND_MAIL_ALERT_DUEDATE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, TB_FILEBORROWITEM_ID, BORROWER_NAME, BORROW_DATE, DUE_DATE, EMAIL, MAIL_ALERT_TYPE, SENT_MAIL_DATE, APP_NO, PATENT_TYPE_NAME FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

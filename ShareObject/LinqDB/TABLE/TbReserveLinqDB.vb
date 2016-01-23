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
    'Represents a transaction for TB_RESERVE table LinqDB.
    '[Create by  on January, 15 2015]
    Public Class TbReserveLinqDB
        Public sub TbReserveLinqDB()

        End Sub 
        ' TB_RESERVE
        Const _tableName As String = "TB_RESERVE"
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
        Dim _REQUIDITION_ID As  System.Nullable(Of Long)  = 0
        Dim _MEMBER_ID As  System.Nullable(Of Long)  = 0
        Dim _MEMBER_NAME As  String  = ""
        Dim _RESERVE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _RESERVE_ORDER As  System.Nullable(Of Long)  = 0
        Dim _RESERVE_JOB_ID As  System.Nullable(Of Long)  = 0
        Dim _REF_INNOVA_ID As  System.Nullable(Of Long)  = 0
        Dim _RESERVE_STATUS As  System.Nullable(Of Char)  = ""
        Dim _BORROWSTATUS As  System.Nullable(Of Char)  = ""
        Dim _OFFICER_ID_RECEIVE As  System.Nullable(Of Long)  = 0
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
        <Column(Storage:="_REQUIDITION_ID", DbType:="BigInt")>  _
        Public Property REQUIDITION_ID() As  System.Nullable(Of Long) 
            Get
                Return _REQUIDITION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _REQUIDITION_ID = value
            End Set
        End Property 
        <Column(Storage:="_MEMBER_ID", DbType:="BigInt")>  _
        Public Property MEMBER_ID() As  System.Nullable(Of Long) 
            Get
                Return _MEMBER_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MEMBER_ID = value
            End Set
        End Property 
        <Column(Storage:="_MEMBER_NAME", DbType:="VarChar(200)")>  _
        Public Property MEMBER_NAME() As  String 
            Get
                Return _MEMBER_NAME
            End Get
            Set(ByVal value As  String )
               _MEMBER_NAME = value
            End Set
        End Property 
        <Column(Storage:="_RESERVE_DATE", DbType:="DateTime")>  _
        Public Property RESERVE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _RESERVE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _RESERVE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_RESERVE_ORDER", DbType:="Int")>  _
        Public Property RESERVE_ORDER() As  System.Nullable(Of Long) 
            Get
                Return _RESERVE_ORDER
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _RESERVE_ORDER = value
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
        <Column(Storage:="_REF_INNOVA_ID", DbType:="BigInt")>  _
        Public Property REF_INNOVA_ID() As  System.Nullable(Of Long) 
            Get
                Return _REF_INNOVA_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _REF_INNOVA_ID = value
            End Set
        End Property 
        <Column(Storage:="_RESERVE_STATUS", DbType:="Char(1)")>  _
        Public Property RESERVE_STATUS() As  System.Nullable(Of Char) 
            Get
                Return _RESERVE_STATUS
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _RESERVE_STATUS = value
            End Set
        End Property 
        <Column(Storage:="_BORROWSTATUS", DbType:="Char(1)")>  _
        Public Property BORROWSTATUS() As  System.Nullable(Of Char) 
            Get
                Return _BORROWSTATUS
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _BORROWSTATUS = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_ID_RECEIVE", DbType:="BigInt")>  _
        Public Property OFFICER_ID_RECEIVE() As  System.Nullable(Of Long) 
            Get
                Return _OFFICER_ID_RECEIVE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _OFFICER_ID_RECEIVE = value
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
            _REQUIDITION_ID = 0
            _MEMBER_ID = 0
            _MEMBER_NAME = ""
            _RESERVE_DATE = New DateTime(1,1,1)
            _RESERVE_ORDER = 0
            _RESERVE_JOB_ID = 0
            _REF_INNOVA_ID = 0
            _RESERVE_STATUS = ""
            _BORROWSTATUS = ""
            _OFFICER_ID_RECEIVE = 0
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


        '/// Returns an indication whether the current data is inserted into TB_RESERVE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_RESERVE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_RESERVE table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_RESERVE table successfully.
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


        '/// Returns an indication whether the record of TB_RESERVE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_RESERVE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbReserveLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_RESERVE by specified BORROWSTATUS_REQUIDITION_ID_RESERVE_DATE key is retrieved successfully.
        '/// <param name=cBORROWSTATUS_REQUIDITION_ID_RESERVE_DATE>The BORROWSTATUS_REQUIDITION_ID_RESERVE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByBORROWSTATUS_REQUIDITION_ID_RESERVE_DATE(cBORROWSTATUS As String, cREQUIDITION_ID As Long, cRESERVE_DATE As DateTime, trans As SqlTransaction) As Boolean
            Return doChkData("BORROWSTATUS = " & DB.SetString(cBORROWSTATUS) & " AND REQUIDITION_ID = " & DB.SetDouble(cREQUIDITION_ID) & " AND RESERVE_DATE = " & DB.SetDateTime(cRESERVE_DATE), trans)
        End Function

        '/// Returns an duplicate data record of TB_RESERVE by specified BORROWSTATUS_REQUIDITION_ID_RESERVE_DATE key is retrieved successfully.
        '/// <param name=cBORROWSTATUS_REQUIDITION_ID_RESERVE_DATE>The BORROWSTATUS_REQUIDITION_ID_RESERVE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByBORROWSTATUS_REQUIDITION_ID_RESERVE_DATE(cBORROWSTATUS As String, cREQUIDITION_ID As Long, cRESERVE_DATE As DateTime, cid As Long, trans As SqlTransaction) As Boolean
            Return doChkData("BORROWSTATUS = " & DB.SetString(cBORROWSTATUS) & " AND REQUIDITION_ID = " & DB.SetDouble(cREQUIDITION_ID) & " AND RESERVE_DATE = " & DB.SetDateTime(cRESERVE_DATE) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_RESERVE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_RESERVE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_RESERVE table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_RESERVE table successfully.
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
            Dim cmbParam(14) As SqlParameter
            cmbParam(0) = New SqlParameter("@_ID", SqlDbType.BigInt)
            cmbParam(0).Value = _ID

            cmbParam(1) = New SqlParameter("@_REQUIDITION_ID", SqlDbType.BigInt)
            If _REQUIDITION_ID IsNot Nothing Then 
                cmbParam(1).Value = _REQUIDITION_ID.Value
            Else
                cmbParam(1).Value = DBNull.value
            End IF

            cmbParam(2) = New SqlParameter("@_MEMBER_ID", SqlDbType.BigInt)
            If _MEMBER_ID IsNot Nothing Then 
                cmbParam(2).Value = _MEMBER_ID.Value
            Else
                cmbParam(2).Value = DBNull.value
            End IF

            cmbParam(3) = New SqlParameter("@_MEMBER_NAME", SqlDbType.VarChar)
            If _MEMBER_NAME.Trim <> "" Then 
                cmbParam(3).Value = _MEMBER_NAME
            Else
                cmbParam(3).Value = DBNull.value
            End If

            cmbParam(4) = New SqlParameter("@_RESERVE_DATE", SqlDbType.DateTime)
            If _RESERVE_DATE.Value.Year > 1 Then 
                cmbParam(4).Value = _RESERVE_DATE.Value
            Else
                cmbParam(4).Value = DBNull.value
            End If

            cmbParam(5) = New SqlParameter("@_RESERVE_ORDER", SqlDbType.Int)
            If _RESERVE_ORDER IsNot Nothing Then 
                cmbParam(5).Value = _RESERVE_ORDER.Value
            Else
                cmbParam(5).Value = DBNull.value
            End IF

            cmbParam(6) = New SqlParameter("@_RESERVE_JOB_ID", SqlDbType.BigInt)
            If _RESERVE_JOB_ID IsNot Nothing Then 
                cmbParam(6).Value = _RESERVE_JOB_ID.Value
            Else
                cmbParam(6).Value = DBNull.value
            End IF

            cmbParam(7) = New SqlParameter("@_REF_INNOVA_ID", SqlDbType.BigInt)
            If _REF_INNOVA_ID IsNot Nothing Then 
                cmbParam(7).Value = _REF_INNOVA_ID.Value
            Else
                cmbParam(7).Value = DBNull.value
            End IF

            cmbParam(8) = New SqlParameter("@_RESERVE_STATUS", SqlDbType.Char)
            If _RESERVE_STATUS.Value <> "" Then 
                cmbParam(8).Value = _RESERVE_STATUS.Value
            Else
                cmbParam(8).Value = DBNull.value
            End IF

            cmbParam(9) = New SqlParameter("@_BORROWSTATUS", SqlDbType.Char)
            If _BORROWSTATUS.Value <> "" Then 
                cmbParam(9).Value = _BORROWSTATUS.Value
            Else
                cmbParam(9).Value = DBNull.value
            End IF

            cmbParam(10) = New SqlParameter("@_OFFICER_ID_RECEIVE", SqlDbType.BigInt)
            If _OFFICER_ID_RECEIVE IsNot Nothing Then 
                cmbParam(10).Value = _OFFICER_ID_RECEIVE.Value
            Else
                cmbParam(10).Value = DBNull.value
            End IF

            cmbParam(11) = New SqlParameter("@_CREATEBY", SqlDbType.VarChar)
            If _CREATEBY.Trim <> "" Then 
                cmbParam(11).Value = _CREATEBY
            Else
                cmbParam(11).Value = DBNull.value
            End If

            cmbParam(12) = New SqlParameter("@_CREATEON", SqlDbType.DateTime)
            If _CREATEON.Value.Year > 1 Then 
                cmbParam(12).Value = _CREATEON.Value
            Else
                cmbParam(12).Value = DBNull.value
            End If

            cmbParam(13) = New SqlParameter("@_UPDATEBY", SqlDbType.VarChar)
            If _UPDATEBY.Trim <> "" Then 
                cmbParam(13).Value = _UPDATEBY
            Else
                cmbParam(13).Value = DBNull.value
            End If

            cmbParam(14) = New SqlParameter("@_UPDATEON", SqlDbType.DateTime)
            If _UPDATEON.Value.Year > 1 Then 
                cmbParam(14).Value = _UPDATEON.Value
            Else
                cmbParam(14).Value = DBNull.value
            End If

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_RESERVE by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("requidition_id")) = False Then _requidition_id = Convert.ToInt64(Rdr("requidition_id"))
                        If Convert.IsDBNull(Rdr("member_id")) = False Then _member_id = Convert.ToInt64(Rdr("member_id"))
                        If Convert.IsDBNull(Rdr("member_name")) = False Then _member_name = Rdr("member_name").ToString()
                        If Convert.IsDBNull(Rdr("reserve_date")) = False Then _reserve_date = Convert.ToDateTime(Rdr("reserve_date"))
                        If Convert.IsDBNull(Rdr("reserve_order")) = False Then _reserve_order = Convert.ToInt32(Rdr("reserve_order"))
                        If Convert.IsDBNull(Rdr("reserve_job_id")) = False Then _reserve_job_id = Convert.ToInt64(Rdr("reserve_job_id"))
                        If Convert.IsDBNull(Rdr("ref_innova_id")) = False Then _ref_innova_id = Convert.ToInt64(Rdr("ref_innova_id"))
                        If Convert.IsDBNull(Rdr("reserve_status")) = False Then _reserve_status = Rdr("reserve_status").ToString()
                        If Convert.IsDBNull(Rdr("borrowstatus")) = False Then _borrowstatus = Rdr("borrowstatus").ToString()
                        If Convert.IsDBNull(Rdr("officer_id_receive")) = False Then _officer_id_receive = Convert.ToInt64(Rdr("officer_id_receive"))
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


        '/// Returns an indication whether the record of TB_RESERVE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbReserveLinqDB
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
                        If Convert.IsDBNull(Rdr("requidition_id")) = False Then _requidition_id = Convert.ToInt64(Rdr("requidition_id"))
                        If Convert.IsDBNull(Rdr("member_id")) = False Then _member_id = Convert.ToInt64(Rdr("member_id"))
                        If Convert.IsDBNull(Rdr("member_name")) = False Then _member_name = Rdr("member_name").ToString()
                        If Convert.IsDBNull(Rdr("reserve_date")) = False Then _reserve_date = Convert.ToDateTime(Rdr("reserve_date"))
                        If Convert.IsDBNull(Rdr("reserve_order")) = False Then _reserve_order = Convert.ToInt32(Rdr("reserve_order"))
                        If Convert.IsDBNull(Rdr("reserve_job_id")) = False Then _reserve_job_id = Convert.ToInt64(Rdr("reserve_job_id"))
                        If Convert.IsDBNull(Rdr("ref_innova_id")) = False Then _ref_innova_id = Convert.ToInt64(Rdr("ref_innova_id"))
                        If Convert.IsDBNull(Rdr("reserve_status")) = False Then _reserve_status = Rdr("reserve_status").ToString()
                        If Convert.IsDBNull(Rdr("borrowstatus")) = False Then _borrowstatus = Rdr("borrowstatus").ToString()
                        If Convert.IsDBNull(Rdr("officer_id_receive")) = False Then _officer_id_receive = Convert.ToInt64(Rdr("officer_id_receive"))
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


        'Get Insert Statement for table TB_RESERVE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, REQUIDITION_ID, MEMBER_ID, MEMBER_NAME, RESERVE_DATE, RESERVE_ORDER, RESERVE_JOB_ID, REF_INNOVA_ID, RESERVE_STATUS, BORROWSTATUS, OFFICER_ID_RECEIVE, CREATEBY, CREATEON, UPDATEBY, UPDATEON)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.REQUIDITION_ID, INSERTED.MEMBER_ID, INSERTED.MEMBER_NAME, INSERTED.RESERVE_DATE, INSERTED.RESERVE_ORDER, INSERTED.RESERVE_JOB_ID, INSERTED.REF_INNOVA_ID, INSERTED.RESERVE_STATUS, INSERTED.BORROWSTATUS, INSERTED.OFFICER_ID_RECEIVE, INSERTED.CREATEBY, INSERTED.CREATEON, INSERTED.UPDATEBY, INSERTED.UPDATEON
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_REQUIDITION_ID" & ", "
                sql += "@_MEMBER_ID" & ", "
                sql += "@_MEMBER_NAME" & ", "
                sql += "@_RESERVE_DATE" & ", "
                sql += "@_RESERVE_ORDER" & ", "
                sql += "@_RESERVE_JOB_ID" & ", "
                sql += "@_REF_INNOVA_ID" & ", "
                sql += "@_RESERVE_STATUS" & ", "
                sql += "@_BORROWSTATUS" & ", "
                sql += "@_OFFICER_ID_RECEIVE" & ", "
                sql += "@_CREATEBY" & ", "
                sql += "@_CREATEON" & ", "
                sql += "@_UPDATEBY" & ", "
                sql += "@_UPDATEON"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_RESERVE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "REQUIDITION_ID = " & "@_REQUIDITION_ID" & ", "
                Sql += "MEMBER_ID = " & "@_MEMBER_ID" & ", "
                Sql += "MEMBER_NAME = " & "@_MEMBER_NAME" & ", "
                Sql += "RESERVE_DATE = " & "@_RESERVE_DATE" & ", "
                Sql += "RESERVE_ORDER = " & "@_RESERVE_ORDER" & ", "
                Sql += "RESERVE_JOB_ID = " & "@_RESERVE_JOB_ID" & ", "
                Sql += "REF_INNOVA_ID = " & "@_REF_INNOVA_ID" & ", "
                Sql += "RESERVE_STATUS = " & "@_RESERVE_STATUS" & ", "
                Sql += "BORROWSTATUS = " & "@_BORROWSTATUS" & ", "
                Sql += "OFFICER_ID_RECEIVE = " & "@_OFFICER_ID_RECEIVE" & ", "
                Sql += "CREATEBY = " & "@_CREATEBY" & ", "
                Sql += "CREATEON = " & "@_CREATEON" & ", "
                Sql += "UPDATEBY = " & "@_UPDATEBY" & ", "
                Sql += "UPDATEON = " & "@_UPDATEON" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_RESERVE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_RESERVE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, REQUIDITION_ID, MEMBER_ID, MEMBER_NAME, RESERVE_DATE, RESERVE_ORDER, RESERVE_JOB_ID, REF_INNOVA_ID, RESERVE_STATUS, BORROWSTATUS, OFFICER_ID_RECEIVE, CREATEBY, CREATEON, UPDATEBY, UPDATEON FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

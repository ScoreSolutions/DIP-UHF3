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
    'Represents a transaction for TB_REQUISTION table LinqDB.
    '[Create by  on April, 7 2015]
    Public Class TbRequistionLinqDB
        Public sub TbRequistionLinqDB()

        End Sub 
        ' TB_REQUISTION
        Const _tableName As String = "TB_REQUISTION"
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
        Dim _MAINREQ As  String  = ""
        Dim _PUBLICNO As  String  = ""
        Dim _PATENTNO As  String  = ""
        Dim _AVAILABLE As  String  = ""
        Dim _LOCKOFFICER As  String  = ""
        Dim _PATENT_TYPE_ID As  System.Nullable(Of Long)  = 0
        Dim _QTY As Long = 0
        Dim _SHELF_NAME As  String  = ""
        Dim _CREATEBY As  String  = ""
        Dim _CREATEON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATEBY As  String  = ""
        Dim _UPDATEON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _FILELOCATION As  System.Nullable(Of Long)  = 0
        Dim _STATUS As  String  = ""
        Dim _SYS_SUBMIT_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _FRM_SUBMIT_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _RECEIVE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _PUBLICDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _APP_SUBMIT_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _LEAVEDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _EJECTDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _CANCELDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _RECOVERDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

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
        <Column(Storage:="_APP_NAME", DbType:="VarChar(1000)")>  _
        Public Property APP_NAME() As  String 
            Get
                Return _APP_NAME
            End Get
            Set(ByVal value As  String )
               _APP_NAME = value
            End Set
        End Property 
        <Column(Storage:="_APP_POSITION", DbType:="VarChar(50)")>  _
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
        <Column(Storage:="_MAINREQ", DbType:="VarChar(200)")>  _
        Public Property MAINREQ() As  String 
            Get
                Return _MAINREQ
            End Get
            Set(ByVal value As  String )
               _MAINREQ = value
            End Set
        End Property 
        <Column(Storage:="_PUBLICNO", DbType:="VarChar(20)")>  _
        Public Property PUBLICNO() As  String 
            Get
                Return _PUBLICNO
            End Get
            Set(ByVal value As  String )
               _PUBLICNO = value
            End Set
        End Property 
        <Column(Storage:="_PATENTNO", DbType:="VarChar(20)")>  _
        Public Property PATENTNO() As  String 
            Get
                Return _PATENTNO
            End Get
            Set(ByVal value As  String )
               _PATENTNO = value
            End Set
        End Property 
        <Column(Storage:="_AVAILABLE", DbType:="VarChar(200)")>  _
        Public Property AVAILABLE() As  String 
            Get
                Return _AVAILABLE
            End Get
            Set(ByVal value As  String )
               _AVAILABLE = value
            End Set
        End Property 
        <Column(Storage:="_LOCKOFFICER", DbType:="VarChar(200)")>  _
        Public Property LOCKOFFICER() As  String 
            Get
                Return _LOCKOFFICER
            End Get
            Set(ByVal value As  String )
               _LOCKOFFICER = value
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
        <Column(Storage:="_SHELF_NAME", DbType:="VarChar(200)")>  _
        Public Property SHELF_NAME() As  String 
            Get
                Return _SHELF_NAME
            End Get
            Set(ByVal value As  String )
               _SHELF_NAME = value
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
        <Column(Storage:="_FILELOCATION", DbType:="Int")>  _
        Public Property FILELOCATION() As  System.Nullable(Of Long) 
            Get
                Return _FILELOCATION
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _FILELOCATION = value
            End Set
        End Property 
        <Column(Storage:="_STATUS", DbType:="VarChar(50)")>  _
        Public Property STATUS() As  String 
            Get
                Return _STATUS
            End Get
            Set(ByVal value As  String )
               _STATUS = value
            End Set
        End Property 
        <Column(Storage:="_SYS_SUBMIT_DATE", DbType:="DateTime")>  _
        Public Property SYS_SUBMIT_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _SYS_SUBMIT_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _SYS_SUBMIT_DATE = value
            End Set
        End Property 
        <Column(Storage:="_FRM_SUBMIT_DATE", DbType:="DateTime")>  _
        Public Property FRM_SUBMIT_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _FRM_SUBMIT_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _FRM_SUBMIT_DATE = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_DATE", DbType:="DateTime")>  _
        Public Property RECEIVE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _RECEIVE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _RECEIVE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_PUBLICDATE", DbType:="DateTime")>  _
        Public Property PUBLICDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _PUBLICDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _PUBLICDATE = value
            End Set
        End Property 
        <Column(Storage:="_APP_SUBMIT_DATE", DbType:="DateTime")>  _
        Public Property APP_SUBMIT_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _APP_SUBMIT_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _APP_SUBMIT_DATE = value
            End Set
        End Property 
        <Column(Storage:="_LEAVEDATE", DbType:="DateTime")>  _
        Public Property LEAVEDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _LEAVEDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _LEAVEDATE = value
            End Set
        End Property 
        <Column(Storage:="_EJECTDATE", DbType:="DateTime")>  _
        Public Property EJECTDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _EJECTDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _EJECTDATE = value
            End Set
        End Property 
        <Column(Storage:="_CANCELDATE", DbType:="DateTime")>  _
        Public Property CANCELDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _CANCELDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _CANCELDATE = value
            End Set
        End Property 
        <Column(Storage:="_RECOVERDATE", DbType:="DateTime")>  _
        Public Property RECOVERDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _RECOVERDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _RECOVERDATE = value
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
            _QTY = 1
            _SHELF_NAME = ""
            _CREATEBY = ""
            _CREATEON = New DateTime(1,1,1)
            _UPDATEBY = ""
            _UPDATEON = New DateTime(1,1,1)
            _FILELOCATION = 0
            _STATUS = ""
            _SYS_SUBMIT_DATE = New DateTime(1,1,1)
            _FRM_SUBMIT_DATE = New DateTime(1,1,1)
            _RECEIVE_DATE = New DateTime(1,1,1)
            _PUBLICDATE = New DateTime(1,1,1)
            _APP_SUBMIT_DATE = New DateTime(1,1,1)
            _LEAVEDATE = New DateTime(1,1,1)
            _EJECTDATE = New DateTime(1,1,1)
            _CANCELDATE = New DateTime(1,1,1)
            _RECOVERDATE = New DateTime(1,1,1)
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


        '/// Returns an indication whether the current data is inserted into TB_REQUISTION table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_REQUISTION table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_REQUISTION table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_REQUISTION table successfully.
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


        '/// Returns an indication whether the record of TB_REQUISTION by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_REQUISTION by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbRequistionLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_REQUISTION by specified PATENT_TYPE_ID key is retrieved successfully.
        '/// <param name=cPATENT_TYPE_ID>The PATENT_TYPE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPATENT_TYPE_ID(cPATENT_TYPE_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("PATENT_TYPE_ID = " & DB.SetDouble(cPATENT_TYPE_ID) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_REQUISTION by specified PATENT_TYPE_ID key is retrieved successfully.
        '/// <param name=cPATENT_TYPE_ID>The PATENT_TYPE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByPATENT_TYPE_ID(cPATENT_TYPE_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("PATENT_TYPE_ID = " & DB.SetDouble(cPATENT_TYPE_ID) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_REQUISTION by specified APP_NO key is retrieved successfully.
        '/// <param name=cAPP_NO>The APP_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByAPP_NO(cAPP_NO As String, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_REQUISTION by specified APP_NO key is retrieved successfully.
        '/// <param name=cAPP_NO>The APP_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByAPP_NO(cAPP_NO As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_REQUISTION by specified CREATEON key is retrieved successfully.
        '/// <param name=cCREATEON>The CREATEON key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByCREATEON(cCREATEON As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("CREATEON = " & DB.SetDateTime(cCREATEON) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_REQUISTION by specified CREATEON key is retrieved successfully.
        '/// <param name=cCREATEON>The CREATEON key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByCREATEON(cCREATEON As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("CREATEON = " & DB.SetDateTime(cCREATEON) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_REQUISTION by specified SHELF_NAME key is retrieved successfully.
        '/// <param name=cSHELF_NAME>The SHELF_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySHELF_NAME(cSHELF_NAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("SHELF_NAME = " & DB.SetString(cSHELF_NAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_REQUISTION by specified SHELF_NAME key is retrieved successfully.
        '/// <param name=cSHELF_NAME>The SHELF_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySHELF_NAME(cSHELF_NAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SHELF_NAME = " & DB.SetString(cSHELF_NAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_REQUISTION by specified FILELOCATION key is retrieved successfully.
        '/// <param name=cFILELOCATION>The FILELOCATION key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByFILELOCATION(cFILELOCATION As Integer, trans As SQLTransaction) As Boolean
            Return doChkData("FILELOCATION = " & DB.SetDouble(cFILELOCATION) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_REQUISTION by specified FILELOCATION key is retrieved successfully.
        '/// <param name=cFILELOCATION>The FILELOCATION key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByFILELOCATION(cFILELOCATION As Integer, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("FILELOCATION = " & DB.SetDouble(cFILELOCATION) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_REQUISTION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_REQUISTION table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_REQUISTION table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_REQUISTION table successfully.
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
            Dim cmbParam(28) As SqlParameter
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

            cmbParam(6) = New SqlParameter("@_MAINREQ", SqlDbType.VarChar)
            If _MAINREQ.Trim <> "" Then 
                cmbParam(6).Value = _MAINREQ
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_PUBLICNO", SqlDbType.VarChar)
            If _PUBLICNO.Trim <> "" Then 
                cmbParam(7).Value = _PUBLICNO
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_PATENTNO", SqlDbType.VarChar)
            If _PATENTNO.Trim <> "" Then 
                cmbParam(8).Value = _PATENTNO
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_AVAILABLE", SqlDbType.VarChar)
            If _AVAILABLE.Trim <> "" Then 
                cmbParam(9).Value = _AVAILABLE
            Else
                cmbParam(9).Value = DBNull.value
            End If

            cmbParam(10) = New SqlParameter("@_LOCKOFFICER", SqlDbType.VarChar)
            If _LOCKOFFICER.Trim <> "" Then 
                cmbParam(10).Value = _LOCKOFFICER
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_PATENT_TYPE_ID", SqlDbType.BigInt)
            If _PATENT_TYPE_ID IsNot Nothing Then 
                cmbParam(11).Value = _PATENT_TYPE_ID.Value
            Else
                cmbParam(11).Value = DBNull.value
            End IF

            cmbParam(12) = New SqlParameter("@_QTY", SqlDbType.Int)
            cmbParam(12).Value = _QTY

            cmbParam(13) = New SqlParameter("@_SHELF_NAME", SqlDbType.VarChar)
            If _SHELF_NAME.Trim <> "" Then 
                cmbParam(13).Value = _SHELF_NAME
            Else
                cmbParam(13).Value = DBNull.value
            End If

            cmbParam(14) = New SqlParameter("@_CREATEBY", SqlDbType.VarChar)
            If _CREATEBY.Trim <> "" Then 
                cmbParam(14).Value = _CREATEBY
            Else
                cmbParam(14).Value = DBNull.value
            End If

            cmbParam(15) = New SqlParameter("@_CREATEON", SqlDbType.DateTime)
            If _CREATEON.Value.Year > 1 Then 
                cmbParam(15).Value = _CREATEON.Value
            Else
                cmbParam(15).Value = DBNull.value
            End If

            cmbParam(16) = New SqlParameter("@_UPDATEBY", SqlDbType.VarChar)
            If _UPDATEBY.Trim <> "" Then 
                cmbParam(16).Value = _UPDATEBY
            Else
                cmbParam(16).Value = DBNull.value
            End If

            cmbParam(17) = New SqlParameter("@_UPDATEON", SqlDbType.DateTime)
            If _UPDATEON.Value.Year > 1 Then 
                cmbParam(17).Value = _UPDATEON.Value
            Else
                cmbParam(17).Value = DBNull.value
            End If

            cmbParam(18) = New SqlParameter("@_FILELOCATION", SqlDbType.Int)
            If _FILELOCATION IsNot Nothing Then 
                cmbParam(18).Value = _FILELOCATION.Value
            Else
                cmbParam(18).Value = DBNull.value
            End IF

            cmbParam(19) = New SqlParameter("@_STATUS", SqlDbType.VarChar)
            If _STATUS.Trim <> "" Then 
                cmbParam(19).Value = _STATUS
            Else
                cmbParam(19).Value = DBNull.value
            End If

            cmbParam(20) = New SqlParameter("@_SYS_SUBMIT_DATE", SqlDbType.DateTime)
            If _SYS_SUBMIT_DATE.Value.Year > 1 Then 
                cmbParam(20).Value = _SYS_SUBMIT_DATE.Value
            Else
                cmbParam(20).Value = DBNull.value
            End If

            cmbParam(21) = New SqlParameter("@_FRM_SUBMIT_DATE", SqlDbType.DateTime)
            If _FRM_SUBMIT_DATE.Value.Year > 1 Then 
                cmbParam(21).Value = _FRM_SUBMIT_DATE.Value
            Else
                cmbParam(21).Value = DBNull.value
            End If

            cmbParam(22) = New SqlParameter("@_RECEIVE_DATE", SqlDbType.DateTime)
            If _RECEIVE_DATE.Value.Year > 1 Then 
                cmbParam(22).Value = _RECEIVE_DATE.Value
            Else
                cmbParam(22).Value = DBNull.value
            End If

            cmbParam(23) = New SqlParameter("@_PUBLICDATE", SqlDbType.DateTime)
            If _PUBLICDATE.Value.Year > 1 Then 
                cmbParam(23).Value = _PUBLICDATE.Value
            Else
                cmbParam(23).Value = DBNull.value
            End If

            cmbParam(24) = New SqlParameter("@_APP_SUBMIT_DATE", SqlDbType.DateTime)
            If _APP_SUBMIT_DATE.Value.Year > 1 Then 
                cmbParam(24).Value = _APP_SUBMIT_DATE.Value
            Else
                cmbParam(24).Value = DBNull.value
            End If

            cmbParam(25) = New SqlParameter("@_LEAVEDATE", SqlDbType.DateTime)
            If _LEAVEDATE.Value.Year > 1 Then 
                cmbParam(25).Value = _LEAVEDATE.Value
            Else
                cmbParam(25).Value = DBNull.value
            End If

            cmbParam(26) = New SqlParameter("@_EJECTDATE", SqlDbType.DateTime)
            If _EJECTDATE.Value.Year > 1 Then 
                cmbParam(26).Value = _EJECTDATE.Value
            Else
                cmbParam(26).Value = DBNull.value
            End If

            cmbParam(27) = New SqlParameter("@_CANCELDATE", SqlDbType.DateTime)
            If _CANCELDATE.Value.Year > 1 Then 
                cmbParam(27).Value = _CANCELDATE.Value
            Else
                cmbParam(27).Value = DBNull.value
            End If

            cmbParam(28) = New SqlParameter("@_RECOVERDATE", SqlDbType.DateTime)
            If _RECOVERDATE.Value.Year > 1 Then 
                cmbParam(28).Value = _RECOVERDATE.Value
            Else
                cmbParam(28).Value = DBNull.value
            End If

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_REQUISTION by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("mainreq")) = False Then _mainreq = Rdr("mainreq").ToString()
                        If Convert.IsDBNull(Rdr("publicno")) = False Then _publicno = Rdr("publicno").ToString()
                        If Convert.IsDBNull(Rdr("patentno")) = False Then _patentno = Rdr("patentno").ToString()
                        If Convert.IsDBNull(Rdr("available")) = False Then _available = Rdr("available").ToString()
                        If Convert.IsDBNull(Rdr("lockofficer")) = False Then _lockofficer = Rdr("lockofficer").ToString()
                        If Convert.IsDBNull(Rdr("patent_type_id")) = False Then _patent_type_id = Convert.ToInt64(Rdr("patent_type_id"))
                        If Convert.IsDBNull(Rdr("qty")) = False Then _qty = Convert.ToInt32(Rdr("qty"))
                        If Convert.IsDBNull(Rdr("shelf_name")) = False Then _shelf_name = Rdr("shelf_name").ToString()
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
                        If Convert.IsDBNull(Rdr("filelocation")) = False Then _filelocation = Convert.ToInt32(Rdr("filelocation"))
                        If Convert.IsDBNull(Rdr("status")) = False Then _status = Rdr("status").ToString()
                        If Convert.IsDBNull(Rdr("sys_submit_date")) = False Then _sys_submit_date = Convert.ToDateTime(Rdr("sys_submit_date"))
                        If Convert.IsDBNull(Rdr("FRM_SUBMIT_DATE")) = False Then _FRM_SUBMIT_DATE = Convert.ToDateTime(Rdr("FRM_SUBMIT_DATE"))
                        If Convert.IsDBNull(Rdr("RECEIVE_DATE")) = False Then _RECEIVE_DATE = Convert.ToDateTime(Rdr("RECEIVE_DATE"))
                        If Convert.IsDBNull(Rdr("PUBLICDATE")) = False Then _PUBLICDATE = Convert.ToDateTime(Rdr("PUBLICDATE"))
                        If Convert.IsDBNull(Rdr("APP_SUBMIT_DATE")) = False Then _APP_SUBMIT_DATE = Convert.ToDateTime(Rdr("APP_SUBMIT_DATE"))
                        If Convert.IsDBNull(Rdr("LEAVEDATE")) = False Then _LEAVEDATE = Convert.ToDateTime(Rdr("LEAVEDATE"))
                        If Convert.IsDBNull(Rdr("EJECTDATE")) = False Then _EJECTDATE = Convert.ToDateTime(Rdr("EJECTDATE"))
                        If Convert.IsDBNull(Rdr("CANCELDATE")) = False Then _CANCELDATE = Convert.ToDateTime(Rdr("CANCELDATE"))
                        If Convert.IsDBNull(Rdr("RECOVERDATE")) = False Then _RECOVERDATE = Convert.ToDateTime(Rdr("RECOVERDATE"))
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


        '/// Returns an indication whether the record of TB_REQUISTION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbRequistionLinqDB
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
                        If Convert.IsDBNull(Rdr("mainreq")) = False Then _mainreq = Rdr("mainreq").ToString()
                        If Convert.IsDBNull(Rdr("publicno")) = False Then _publicno = Rdr("publicno").ToString()
                        If Convert.IsDBNull(Rdr("patentno")) = False Then _patentno = Rdr("patentno").ToString()
                        If Convert.IsDBNull(Rdr("available")) = False Then _available = Rdr("available").ToString()
                        If Convert.IsDBNull(Rdr("lockofficer")) = False Then _lockofficer = Rdr("lockofficer").ToString()
                        If Convert.IsDBNull(Rdr("patent_type_id")) = False Then _patent_type_id = Convert.ToInt64(Rdr("patent_type_id"))
                        If Convert.IsDBNull(Rdr("qty")) = False Then _qty = Convert.ToInt32(Rdr("qty"))
                        If Convert.IsDBNull(Rdr("shelf_name")) = False Then _shelf_name = Rdr("shelf_name").ToString()
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
                        If Convert.IsDBNull(Rdr("filelocation")) = False Then _filelocation = Convert.ToInt32(Rdr("filelocation"))
                        If Convert.IsDBNull(Rdr("status")) = False Then _status = Rdr("status").ToString()
                        If Convert.IsDBNull(Rdr("sys_submit_date")) = False Then _sys_submit_date = Convert.ToDateTime(Rdr("sys_submit_date"))
                        If Convert.IsDBNull(Rdr("FRM_SUBMIT_DATE")) = False Then _FRM_SUBMIT_DATE = Convert.ToDateTime(Rdr("FRM_SUBMIT_DATE"))
                        If Convert.IsDBNull(Rdr("RECEIVE_DATE")) = False Then _RECEIVE_DATE = Convert.ToDateTime(Rdr("RECEIVE_DATE"))
                        If Convert.IsDBNull(Rdr("PUBLICDATE")) = False Then _PUBLICDATE = Convert.ToDateTime(Rdr("PUBLICDATE"))
                        If Convert.IsDBNull(Rdr("APP_SUBMIT_DATE")) = False Then _APP_SUBMIT_DATE = Convert.ToDateTime(Rdr("APP_SUBMIT_DATE"))
                        If Convert.IsDBNull(Rdr("LEAVEDATE")) = False Then _LEAVEDATE = Convert.ToDateTime(Rdr("LEAVEDATE"))
                        If Convert.IsDBNull(Rdr("EJECTDATE")) = False Then _EJECTDATE = Convert.ToDateTime(Rdr("EJECTDATE"))
                        If Convert.IsDBNull(Rdr("CANCELDATE")) = False Then _CANCELDATE = Convert.ToDateTime(Rdr("CANCELDATE"))
                        If Convert.IsDBNull(Rdr("RECOVERDATE")) = False Then _RECOVERDATE = Convert.ToDateTime(Rdr("RECOVERDATE"))
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


        'Get Insert Statement for table TB_REQUISTION
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, REQ_NO, APP_NO, APP_NAME, APP_POSITION, APP_STATUS, MAINREQ, PUBLICNO, PATENTNO, AVAILABLE, LOCKOFFICER, PATENT_TYPE_ID, QTY, SHELF_NAME, CREATEBY, CREATEON, UPDATEBY, UPDATEON, FILELOCATION, STATUS, SYS_SUBMIT_DATE, FRM_SUBMIT_DATE, RECEIVE_DATE, PUBLICDATE, APP_SUBMIT_DATE, LEAVEDATE, EJECTDATE, CANCELDATE, RECOVERDATE)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.REQ_NO, INSERTED.APP_NO, INSERTED.APP_NAME, INSERTED.APP_POSITION, INSERTED.APP_STATUS, INSERTED.MAINREQ, INSERTED.PUBLICNO, INSERTED.PATENTNO, INSERTED.AVAILABLE, INSERTED.LOCKOFFICER, INSERTED.PATENT_TYPE_ID, INSERTED.QTY, INSERTED.SHELF_NAME, INSERTED.CREATEBY, INSERTED.CREATEON, INSERTED.UPDATEBY, INSERTED.UPDATEON, INSERTED.FILELOCATION, INSERTED.STATUS, INSERTED.SYS_SUBMIT_DATE, INSERTED.FRM_SUBMIT_DATE, INSERTED.RECEIVE_DATE, INSERTED.PUBLICDATE, INSERTED.APP_SUBMIT_DATE, INSERTED.LEAVEDATE, INSERTED.EJECTDATE, INSERTED.CANCELDATE, INSERTED.RECOVERDATE
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_REQ_NO" & ", "
                sql += "@_APP_NO" & ", "
                sql += "@_APP_NAME" & ", "
                sql += "@_APP_POSITION" & ", "
                sql += "@_APP_STATUS" & ", "
                sql += "@_MAINREQ" & ", "
                sql += "@_PUBLICNO" & ", "
                sql += "@_PATENTNO" & ", "
                sql += "@_AVAILABLE" & ", "
                sql += "@_LOCKOFFICER" & ", "
                sql += "@_PATENT_TYPE_ID" & ", "
                sql += "@_QTY" & ", "
                sql += "@_SHELF_NAME" & ", "
                sql += "@_CREATEBY" & ", "
                sql += "@_CREATEON" & ", "
                sql += "@_UPDATEBY" & ", "
                sql += "@_UPDATEON" & ", "
                sql += "@_FILELOCATION" & ", "
                sql += "@_STATUS" & ", "
                sql += "@_SYS_SUBMIT_DATE" & ", "
                sql += "@_FRM_SUBMIT_DATE" & ", "
                sql += "@_RECEIVE_DATE" & ", "
                sql += "@_PUBLICDATE" & ", "
                sql += "@_APP_SUBMIT_DATE" & ", "
                sql += "@_LEAVEDATE" & ", "
                sql += "@_EJECTDATE" & ", "
                sql += "@_CANCELDATE" & ", "
                sql += "@_RECOVERDATE"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_REQUISTION
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "REQ_NO = " & "@_REQ_NO" & ", "
                Sql += "APP_NO = " & "@_APP_NO" & ", "
                Sql += "APP_NAME = " & "@_APP_NAME" & ", "
                Sql += "APP_POSITION = " & "@_APP_POSITION" & ", "
                Sql += "APP_STATUS = " & "@_APP_STATUS" & ", "
                Sql += "MAINREQ = " & "@_MAINREQ" & ", "
                Sql += "PUBLICNO = " & "@_PUBLICNO" & ", "
                Sql += "PATENTNO = " & "@_PATENTNO" & ", "
                Sql += "AVAILABLE = " & "@_AVAILABLE" & ", "
                Sql += "LOCKOFFICER = " & "@_LOCKOFFICER" & ", "
                Sql += "PATENT_TYPE_ID = " & "@_PATENT_TYPE_ID" & ", "
                Sql += "QTY = " & "@_QTY" & ", "
                Sql += "SHELF_NAME = " & "@_SHELF_NAME" & ", "
                Sql += "CREATEBY = " & "@_CREATEBY" & ", "
                Sql += "CREATEON = " & "@_CREATEON" & ", "
                Sql += "UPDATEBY = " & "@_UPDATEBY" & ", "
                Sql += "UPDATEON = " & "@_UPDATEON" & ", "
                Sql += "FILELOCATION = " & "@_FILELOCATION" & ", "
                Sql += "STATUS = " & "@_STATUS" & ", "
                Sql += "SYS_SUBMIT_DATE = " & "@_SYS_SUBMIT_DATE" & ", "
                Sql += "FRM_SUBMIT_DATE = " & "@_FRM_SUBMIT_DATE" & ", "
                Sql += "RECEIVE_DATE = " & "@_RECEIVE_DATE" & ", "
                Sql += "PUBLICDATE = " & "@_PUBLICDATE" & ", "
                Sql += "APP_SUBMIT_DATE = " & "@_APP_SUBMIT_DATE" & ", "
                Sql += "LEAVEDATE = " & "@_LEAVEDATE" & ", "
                Sql += "EJECTDATE = " & "@_EJECTDATE" & ", "
                Sql += "CANCELDATE = " & "@_CANCELDATE" & ", "
                Sql += "RECOVERDATE = " & "@_RECOVERDATE" + ""
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
                Dim Sql As String = "SELECT ID, REQ_NO, APP_NO, APP_NAME, APP_POSITION, APP_STATUS, MAINREQ, PUBLICNO, PATENTNO, AVAILABLE, LOCKOFFICER, PATENT_TYPE_ID, QTY, SHELF_NAME, CREATEBY, CREATEON, UPDATEBY, UPDATEON, FILELOCATION, STATUS, SYS_SUBMIT_DATE, FRM_SUBMIT_DATE, RECEIVE_DATE, PUBLICDATE, APP_SUBMIT_DATE, LEAVEDATE, EJECTDATE, CANCELDATE, RECOVERDATE FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

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
    'Represents a transaction for TS_FILE_MOVE_HISTORY table LinqDB.
    '[Create by  on April, 20 2015]
    Public Class TsFileMoveHistoryLinqDB
        Public sub TsFileMoveHistoryLinqDB()

        End Sub 
        ' TS_FILE_MOVE_HISTORY
        Const _tableName As String = "TS_FILE_MOVE_HISTORY"
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
        Dim _APP_NO As String = ""
        Dim _MOVE_DATE As DateTime = New DateTime(1,1,1)
        Dim _READERID As String = ""
        Dim _ANT_PORT_NUMBER As Long = 0
        Dim _RSSI As Double = 0
        Dim _LOCATION_NAME As String = ""
        Dim _MS_ROOM_ID As  System.Nullable(Of Long)  = 0
        Dim _TB_OFFICER_ID As  System.Nullable(Of Long)  = 0
        Dim _OFFICER_NAME As  String  = ""
        Dim _MS_DESKTOP_ID As  System.Nullable(Of Long)  = 0
        Dim _DESK_NAME As  String  = ""
        Dim _MS_GRID_LAYOUT_ID As Long = 0
        Dim _GRID_ROW As Long = 0
        Dim _GRID_COL As Long = 0
        Dim _IS_UPDATE_CURRENT_LOCATION As  System.Nullable(Of Char)  = "N"

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
        <Column(Storage:="_APP_NO", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property APP_NO() As String
            Get
                Return _APP_NO
            End Get
            Set(ByVal value As String)
               _APP_NO = value
            End Set
        End Property 
        <Column(Storage:="_MOVE_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property MOVE_DATE() As DateTime
            Get
                Return _MOVE_DATE
            End Get
            Set(ByVal value As DateTime)
               _MOVE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_READERID", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property READERID() As String
            Get
                Return _READERID
            End Get
            Set(ByVal value As String)
               _READERID = value
            End Set
        End Property 
        <Column(Storage:="_ANT_PORT_NUMBER", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property ANT_PORT_NUMBER() As Long
            Get
                Return _ANT_PORT_NUMBER
            End Get
            Set(ByVal value As Long)
               _ANT_PORT_NUMBER = value
            End Set
        End Property 
        <Column(Storage:="_RSSI", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property RSSI() As Double
            Get
                Return _RSSI
            End Get
            Set(ByVal value As Double)
               _RSSI = value
            End Set
        End Property 
        <Column(Storage:="_LOCATION_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property LOCATION_NAME() As String
            Get
                Return _LOCATION_NAME
            End Get
            Set(ByVal value As String)
               _LOCATION_NAME = value
            End Set
        End Property 
        <Column(Storage:="_MS_ROOM_ID", DbType:="BigInt")>  _
        Public Property MS_ROOM_ID() As  System.Nullable(Of Long) 
            Get
                Return _MS_ROOM_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MS_ROOM_ID = value
            End Set
        End Property 
        <Column(Storage:="_TB_OFFICER_ID", DbType:="BigInt")>  _
        Public Property TB_OFFICER_ID() As  System.Nullable(Of Long) 
            Get
                Return _TB_OFFICER_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _TB_OFFICER_ID = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_NAME", DbType:="VarChar(255)")>  _
        Public Property OFFICER_NAME() As  String 
            Get
                Return _OFFICER_NAME
            End Get
            Set(ByVal value As  String )
               _OFFICER_NAME = value
            End Set
        End Property 
        <Column(Storage:="_MS_DESKTOP_ID", DbType:="BigInt")>  _
        Public Property MS_DESKTOP_ID() As  System.Nullable(Of Long) 
            Get
                Return _MS_DESKTOP_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MS_DESKTOP_ID = value
            End Set
        End Property 
        <Column(Storage:="_DESK_NAME", DbType:="VarChar(255)")>  _
        Public Property DESK_NAME() As  String 
            Get
                Return _DESK_NAME
            End Get
            Set(ByVal value As  String )
               _DESK_NAME = value
            End Set
        End Property 
        <Column(Storage:="_MS_GRID_LAYOUT_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_GRID_LAYOUT_ID() As Long
            Get
                Return _MS_GRID_LAYOUT_ID
            End Get
            Set(ByVal value As Long)
               _MS_GRID_LAYOUT_ID = value
            End Set
        End Property 
        <Column(Storage:="_GRID_ROW", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property GRID_ROW() As Long
            Get
                Return _GRID_ROW
            End Get
            Set(ByVal value As Long)
               _GRID_ROW = value
            End Set
        End Property 
        <Column(Storage:="_GRID_COL", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property GRID_COL() As Long
            Get
                Return _GRID_COL
            End Get
            Set(ByVal value As Long)
               _GRID_COL = value
            End Set
        End Property 
        <Column(Storage:="_IS_UPDATE_CURRENT_LOCATION", DbType:="Char(1)")>  _
        Public Property IS_UPDATE_CURRENT_LOCATION() As  System.Nullable(Of Char) 
            Get
                Return _IS_UPDATE_CURRENT_LOCATION
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _IS_UPDATE_CURRENT_LOCATION = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _APP_NO = ""
            _MOVE_DATE = New DateTime(1,1,1)
            _READERID = ""
            _ANT_PORT_NUMBER = 0
            _RSSI = 0
            _LOCATION_NAME = ""
            _MS_ROOM_ID = 0
            _TB_OFFICER_ID = 0
            _OFFICER_NAME = ""
            _MS_DESKTOP_ID = 0
            _DESK_NAME = ""
            _MS_GRID_LAYOUT_ID = 0
            _GRID_ROW = 0
            _GRID_COL = 0
            _IS_UPDATE_CURRENT_LOCATION = "N"
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


        '/// Returns an indication whether the current data is inserted into TS_FILE_MOVE_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is updated to TS_FILE_MOVE_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is updated to TS_FILE_MOVE_HISTORY table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TS_FILE_MOVE_HISTORY table successfully.
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


        '/// Returns an indication whether the record of TS_FILE_MOVE_HISTORY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TS_FILE_MOVE_HISTORY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TsFileMoveHistoryLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TS_FILE_MOVE_HISTORY by specified APP_NO key is retrieved successfully.
        '/// <param name=cAPP_NO>The APP_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByAPP_NO(cAPP_NO As String, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TS_FILE_MOVE_HISTORY by specified APP_NO key is retrieved successfully.
        '/// <param name=cAPP_NO>The APP_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByAPP_NO(cAPP_NO As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_FILE_MOVE_HISTORY by specified APP_NO_MOVE_DATE key is retrieved successfully.
        '/// <param name=cAPP_NO_MOVE_DATE>The APP_NO_MOVE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByAPP_NO_MOVE_DATE(cAPP_NO As String, cMOVE_DATE As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " AND MOVE_DATE = " & DB.SetDateTime(cMOVE_DATE), trans)
        End Function

        '/// Returns an duplicate data record of TS_FILE_MOVE_HISTORY by specified APP_NO_MOVE_DATE key is retrieved successfully.
        '/// <param name=cAPP_NO_MOVE_DATE>The APP_NO_MOVE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByAPP_NO_MOVE_DATE(cAPP_NO As String, cMOVE_DATE As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " AND MOVE_DATE = " & DB.SetDateTime(cMOVE_DATE) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_FILE_MOVE_HISTORY by specified MOVE_DATE_READERID key is retrieved successfully.
        '/// <param name=cMOVE_DATE_READERID>The MOVE_DATE_READERID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMOVE_DATE_READERID(cMOVE_DATE As DateTime, cREADERID As String, trans As SQLTransaction) As Boolean
            Return doChkData("MOVE_DATE = " & DB.SetDateTime(cMOVE_DATE) & " AND READERID = " & DB.SetString(cREADERID), trans)
        End Function

        '/// Returns an duplicate data record of TS_FILE_MOVE_HISTORY by specified MOVE_DATE_READERID key is retrieved successfully.
        '/// <param name=cMOVE_DATE_READERID>The MOVE_DATE_READERID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMOVE_DATE_READERID(cMOVE_DATE As DateTime, cREADERID As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MOVE_DATE = " & DB.SetDateTime(cMOVE_DATE) & " AND READERID = " & DB.SetString(cREADERID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_FILE_MOVE_HISTORY by specified APP_NO_MOVE_DATE_READERID key is retrieved successfully.
        '/// <param name=cAPP_NO_MOVE_DATE_READERID>The APP_NO_MOVE_DATE_READERID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByAPP_NO_MOVE_DATE_READERID(cAPP_NO As String, cMOVE_DATE As DateTime, cREADERID As String, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " AND MOVE_DATE = " & DB.SetDateTime(cMOVE_DATE) & " AND READERID = " & DB.SetString(cREADERID), trans)
        End Function

        '/// Returns an duplicate data record of TS_FILE_MOVE_HISTORY by specified APP_NO_MOVE_DATE_READERID key is retrieved successfully.
        '/// <param name=cAPP_NO_MOVE_DATE_READERID>The APP_NO_MOVE_DATE_READERID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByAPP_NO_MOVE_DATE_READERID(cAPP_NO As String, cMOVE_DATE As DateTime, cREADERID As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " AND MOVE_DATE = " & DB.SetDateTime(cMOVE_DATE) & " AND READERID = " & DB.SetString(cREADERID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_FILE_MOVE_HISTORY by specified APP_NO_LOCATION_NAME key is retrieved successfully.
        '/// <param name=cAPP_NO_LOCATION_NAME>The APP_NO_LOCATION_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByAPP_NO_LOCATION_NAME(cAPP_NO As String, cLOCATION_NAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " AND LOCATION_NAME = " & DB.SetString(cLOCATION_NAME), trans)
        End Function

        '/// Returns an duplicate data record of TS_FILE_MOVE_HISTORY by specified APP_NO_LOCATION_NAME key is retrieved successfully.
        '/// <param name=cAPP_NO_LOCATION_NAME>The APP_NO_LOCATION_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByAPP_NO_LOCATION_NAME(cAPP_NO As String, cLOCATION_NAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " AND LOCATION_NAME = " & DB.SetString(cLOCATION_NAME) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_FILE_MOVE_HISTORY by specified APP_NO_TB_OFFICER_ID key is retrieved successfully.
        '/// <param name=cAPP_NO_TB_OFFICER_ID>The APP_NO_TB_OFFICER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByAPP_NO_TB_OFFICER_ID(cAPP_NO As String, cTB_OFFICER_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " AND TB_OFFICER_ID = " & DB.SetDouble(cTB_OFFICER_ID), trans)
        End Function

        '/// Returns an duplicate data record of TS_FILE_MOVE_HISTORY by specified APP_NO_TB_OFFICER_ID key is retrieved successfully.
        '/// <param name=cAPP_NO_TB_OFFICER_ID>The APP_NO_TB_OFFICER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByAPP_NO_TB_OFFICER_ID(cAPP_NO As String, cTB_OFFICER_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " AND TB_OFFICER_ID = " & DB.SetDouble(cTB_OFFICER_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_FILE_MOVE_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TS_FILE_MOVE_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is updated to TS_FILE_MOVE_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is deleted from TS_FILE_MOVE_HISTORY table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Try
                        ret = DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans)
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
            Dim cmbParam(19) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_APP_NO", SqlDbType.VarChar)
            cmbParam(5).Value = _APP_NO

            cmbParam(6) = New SqlParameter("@_MOVE_DATE", SqlDbType.DateTime)
            cmbParam(6).Value = _MOVE_DATE

            cmbParam(7) = New SqlParameter("@_READERID", SqlDbType.VarChar)
            cmbParam(7).Value = _READERID

            cmbParam(8) = New SqlParameter("@_ANT_PORT_NUMBER", SqlDbType.Int)
            cmbParam(8).Value = _ANT_PORT_NUMBER

            cmbParam(9) = New SqlParameter("@_RSSI", SqlDbType.Float)
            cmbParam(9).Value = _RSSI

            cmbParam(10) = New SqlParameter("@_LOCATION_NAME", SqlDbType.VarChar)
            cmbParam(10).Value = _LOCATION_NAME

            cmbParam(11) = New SqlParameter("@_MS_ROOM_ID", SqlDbType.BigInt)
            If _MS_ROOM_ID IsNot Nothing Then 
                cmbParam(11).Value = _MS_ROOM_ID.Value
            Else
                cmbParam(11).Value = DBNull.value
            End IF

            cmbParam(12) = New SqlParameter("@_TB_OFFICER_ID", SqlDbType.BigInt)
            If _TB_OFFICER_ID IsNot Nothing Then 
                cmbParam(12).Value = _TB_OFFICER_ID.Value
            Else
                cmbParam(12).Value = DBNull.value
            End IF

            cmbParam(13) = New SqlParameter("@_OFFICER_NAME", SqlDbType.VarChar)
            If _OFFICER_NAME.Trim <> "" Then 
                cmbParam(13).Value = _OFFICER_NAME
            Else
                cmbParam(13).Value = DBNull.value
            End If

            cmbParam(14) = New SqlParameter("@_MS_DESKTOP_ID", SqlDbType.BigInt)
            If _MS_DESKTOP_ID IsNot Nothing Then 
                cmbParam(14).Value = _MS_DESKTOP_ID.Value
            Else
                cmbParam(14).Value = DBNull.value
            End IF

            cmbParam(15) = New SqlParameter("@_DESK_NAME", SqlDbType.VarChar)
            If _DESK_NAME.Trim <> "" Then 
                cmbParam(15).Value = _DESK_NAME
            Else
                cmbParam(15).Value = DBNull.value
            End If

            cmbParam(16) = New SqlParameter("@_MS_GRID_LAYOUT_ID", SqlDbType.BigInt)
            cmbParam(16).Value = _MS_GRID_LAYOUT_ID

            cmbParam(17) = New SqlParameter("@_GRID_ROW", SqlDbType.Int)
            cmbParam(17).Value = _GRID_ROW

            cmbParam(18) = New SqlParameter("@_GRID_COL", SqlDbType.Int)
            cmbParam(18).Value = _GRID_COL

            cmbParam(19) = New SqlParameter("@_IS_UPDATE_CURRENT_LOCATION", SqlDbType.Char)
            If _IS_UPDATE_CURRENT_LOCATION.Value <> "" Then 
                cmbParam(19).Value = _IS_UPDATE_CURRENT_LOCATION.Value
            Else
                cmbParam(19).Value = DBNull.value
            End IF

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TS_FILE_MOVE_HISTORY by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("app_no")) = False Then _app_no = Rdr("app_no").ToString()
                        If Convert.IsDBNull(Rdr("move_date")) = False Then _move_date = Convert.ToDateTime(Rdr("move_date"))
                        If Convert.IsDBNull(Rdr("ReaderID")) = False Then _ReaderID = Rdr("ReaderID").ToString()
                        If Convert.IsDBNull(Rdr("ant_port_number")) = False Then _ant_port_number = Convert.ToInt32(Rdr("ant_port_number"))
                        If Convert.IsDBNull(Rdr("rssi")) = False Then _rssi = Convert.ToDouble(Rdr("rssi"))
                        If Convert.IsDBNull(Rdr("location_name")) = False Then _location_name = Rdr("location_name").ToString()
                        If Convert.IsDBNull(Rdr("ms_room_id")) = False Then _ms_room_id = Convert.ToInt64(Rdr("ms_room_id"))
                        If Convert.IsDBNull(Rdr("tb_officer_id")) = False Then _tb_officer_id = Convert.ToInt64(Rdr("tb_officer_id"))
                        If Convert.IsDBNull(Rdr("officer_name")) = False Then _officer_name = Rdr("officer_name").ToString()
                        If Convert.IsDBNull(Rdr("ms_desktop_id")) = False Then _ms_desktop_id = Convert.ToInt64(Rdr("ms_desktop_id"))
                        If Convert.IsDBNull(Rdr("desk_name")) = False Then _desk_name = Rdr("desk_name").ToString()
                        If Convert.IsDBNull(Rdr("ms_grid_layout_id")) = False Then _ms_grid_layout_id = Convert.ToInt64(Rdr("ms_grid_layout_id"))
                        If Convert.IsDBNull(Rdr("grid_row")) = False Then _grid_row = Convert.ToInt32(Rdr("grid_row"))
                        If Convert.IsDBNull(Rdr("grid_col")) = False Then _grid_col = Convert.ToInt32(Rdr("grid_col"))
                        If Convert.IsDBNull(Rdr("is_update_current_location")) = False Then _is_update_current_location = Rdr("is_update_current_location").ToString()
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


        '/// Returns an indication whether the record of TS_FILE_MOVE_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TsFileMoveHistoryLinqDB
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
                        If Convert.IsDBNull(Rdr("app_no")) = False Then _app_no = Rdr("app_no").ToString()
                        If Convert.IsDBNull(Rdr("move_date")) = False Then _move_date = Convert.ToDateTime(Rdr("move_date"))
                        If Convert.IsDBNull(Rdr("ReaderID")) = False Then _ReaderID = Rdr("ReaderID").ToString()
                        If Convert.IsDBNull(Rdr("ant_port_number")) = False Then _ant_port_number = Convert.ToInt32(Rdr("ant_port_number"))
                        If Convert.IsDBNull(Rdr("rssi")) = False Then _rssi = Convert.ToDouble(Rdr("rssi"))
                        If Convert.IsDBNull(Rdr("location_name")) = False Then _location_name = Rdr("location_name").ToString()
                        If Convert.IsDBNull(Rdr("ms_room_id")) = False Then _ms_room_id = Convert.ToInt64(Rdr("ms_room_id"))
                        If Convert.IsDBNull(Rdr("tb_officer_id")) = False Then _tb_officer_id = Convert.ToInt64(Rdr("tb_officer_id"))
                        If Convert.IsDBNull(Rdr("officer_name")) = False Then _officer_name = Rdr("officer_name").ToString()
                        If Convert.IsDBNull(Rdr("ms_desktop_id")) = False Then _ms_desktop_id = Convert.ToInt64(Rdr("ms_desktop_id"))
                        If Convert.IsDBNull(Rdr("desk_name")) = False Then _desk_name = Rdr("desk_name").ToString()
                        If Convert.IsDBNull(Rdr("ms_grid_layout_id")) = False Then _ms_grid_layout_id = Convert.ToInt64(Rdr("ms_grid_layout_id"))
                        If Convert.IsDBNull(Rdr("grid_row")) = False Then _grid_row = Convert.ToInt32(Rdr("grid_row"))
                        If Convert.IsDBNull(Rdr("grid_col")) = False Then _grid_col = Convert.ToInt32(Rdr("grid_col"))
                        If Convert.IsDBNull(Rdr("is_update_current_location")) = False Then _is_update_current_location = Rdr("is_update_current_location").ToString()
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


        'Get Insert Statement for table TS_FILE_MOVE_HISTORY
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, APP_NO, MOVE_DATE, READERID, ANT_PORT_NUMBER, RSSI, LOCATION_NAME, MS_ROOM_ID, TB_OFFICER_ID, OFFICER_NAME, MS_DESKTOP_ID, DESK_NAME, MS_GRID_LAYOUT_ID, GRID_ROW, GRID_COL, IS_UPDATE_CURRENT_LOCATION)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.APP_NO, INSERTED.MOVE_DATE, INSERTED.READERID, INSERTED.ANT_PORT_NUMBER, INSERTED.RSSI, INSERTED.LOCATION_NAME, INSERTED.MS_ROOM_ID, INSERTED.TB_OFFICER_ID, INSERTED.OFFICER_NAME, INSERTED.MS_DESKTOP_ID, INSERTED.DESK_NAME, INSERTED.MS_GRID_LAYOUT_ID, INSERTED.GRID_ROW, INSERTED.GRID_COL, INSERTED.IS_UPDATE_CURRENT_LOCATION
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_APP_NO" & ", "
                sql += "@_MOVE_DATE" & ", "
                sql += "@_READERID" & ", "
                sql += "@_ANT_PORT_NUMBER" & ", "
                sql += "@_RSSI" & ", "
                sql += "@_LOCATION_NAME" & ", "
                sql += "@_MS_ROOM_ID" & ", "
                sql += "@_TB_OFFICER_ID" & ", "
                sql += "@_OFFICER_NAME" & ", "
                sql += "@_MS_DESKTOP_ID" & ", "
                sql += "@_DESK_NAME" & ", "
                sql += "@_MS_GRID_LAYOUT_ID" & ", "
                sql += "@_GRID_ROW" & ", "
                sql += "@_GRID_COL" & ", "
                sql += "@_IS_UPDATE_CURRENT_LOCATION"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TS_FILE_MOVE_HISTORY
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "APP_NO = " & "@_APP_NO" & ", "
                Sql += "MOVE_DATE = " & "@_MOVE_DATE" & ", "
                Sql += "READERID = " & "@_READERID" & ", "
                Sql += "ANT_PORT_NUMBER = " & "@_ANT_PORT_NUMBER" & ", "
                Sql += "RSSI = " & "@_RSSI" & ", "
                Sql += "LOCATION_NAME = " & "@_LOCATION_NAME" & ", "
                Sql += "MS_ROOM_ID = " & "@_MS_ROOM_ID" & ", "
                Sql += "TB_OFFICER_ID = " & "@_TB_OFFICER_ID" & ", "
                Sql += "OFFICER_NAME = " & "@_OFFICER_NAME" & ", "
                Sql += "MS_DESKTOP_ID = " & "@_MS_DESKTOP_ID" & ", "
                Sql += "DESK_NAME = " & "@_DESK_NAME" & ", "
                Sql += "MS_GRID_LAYOUT_ID = " & "@_MS_GRID_LAYOUT_ID" & ", "
                Sql += "GRID_ROW = " & "@_GRID_ROW" & ", "
                Sql += "GRID_COL = " & "@_GRID_COL" & ", "
                Sql += "IS_UPDATE_CURRENT_LOCATION = " & "@_IS_UPDATE_CURRENT_LOCATION" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TS_FILE_MOVE_HISTORY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TS_FILE_MOVE_HISTORY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, APP_NO, MOVE_DATE, READERID, ANT_PORT_NUMBER, RSSI, LOCATION_NAME, MS_ROOM_ID, TB_OFFICER_ID, OFFICER_NAME, MS_DESKTOP_ID, DESK_NAME, MS_GRID_LAYOUT_ID, GRID_ROW, GRID_COL, IS_UPDATE_CURRENT_LOCATION FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

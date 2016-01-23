Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports DB = LinqDB.ConnectDB.DIPRFIDSqlDB
Imports LinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for CF_SPEEDWAY table LinqDB.
    '[Create by  on April, 29 2015]
    Public Class CfSpeedwayLinqDB
        Public Sub CfSpeedwayLinqDB()

        End Sub
        ' CF_SPEEDWAY
        Const _tableName As String = "CF_SPEEDWAY"
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
        Dim _CREATED_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATED_BY As String = ""
        Dim _UPDATED_DATE As System.Nullable(Of DateTime) = New DateTime(1, 1, 1)
        Dim _MS_SPEEDWAY_ID As System.Nullable(Of Long) = 0
        Dim _READERID As String = ""
        Dim _SERIAL_NO As String = ""
        Dim _IP_ADDRESS As String = ""
        Dim _MAC_ADDRESS As String = ""
        Dim _INSTALL_POSITION As String = ""
        Dim _MS_ROOM_ID As Long = 0
        Dim _MS_SPEEDWAY_OBJECTIVE_ID As Long = 0
        Dim _ANT_QTY As Long = 0
        Dim _GPI_QTY As Long = 0
        Dim _BRAND_NAME As String = ""
        Dim _MODEL_NAME As String = ""
        Dim _ACTIVE_STATUS As Char = "Y"
        Dim _FTP_USER As String = ""
        Dim _FTP_PWD As String = ""
        Dim _FTP_PORT As Long = 0
        Dim _FTP_PATH As String = ""
        Dim _FTP_DATA_PATH As String = ""
        Dim _SCHEDULE_TYPE As Char = "N"
        Dim _SCHEDULE_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _IS_SEND_SPEEDWAY As Char = "N"
        Dim _IS_UPDATE_SETTING As Char = "N"

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="BigInt NOT NULL ", CanBeNull:=False)> _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <Column(Storage:="_CREATED_BY", DbType:="VarChar(100) NOT NULL ", CanBeNull:=False)> _
        Public Property CREATED_BY() As String
            Get
                Return _CREATED_BY
            End Get
            Set(ByVal value As String)
                _CREATED_BY = value
            End Set
        End Property
        <Column(Storage:="_CREATED_DATE", DbType:="DateTime NOT NULL ", CanBeNull:=False)> _
        Public Property CREATED_DATE() As DateTime
            Get
                Return _CREATED_DATE
            End Get
            Set(ByVal value As DateTime)
                _CREATED_DATE = value
            End Set
        End Property
        <Column(Storage:="_UPDATED_BY", DbType:="VarChar(100)")> _
        Public Property UPDATED_BY() As String
            Get
                Return _UPDATED_BY
            End Get
            Set(ByVal value As String)
                _UPDATED_BY = value
            End Set
        End Property
        <Column(Storage:="_UPDATED_DATE", DbType:="DateTime")> _
        Public Property UPDATED_DATE() As System.Nullable(Of DateTime)
            Get
                Return _UPDATED_DATE
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _UPDATED_DATE = value
            End Set
        End Property
        <Column(Storage:="_MS_SPEEDWAY_ID", DbType:="BigInt")> _
        Public Property MS_SPEEDWAY_ID() As System.Nullable(Of Long)
            Get
                Return _MS_SPEEDWAY_ID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _MS_SPEEDWAY_ID = value
            End Set
        End Property
        <Column(Storage:="_READERID", DbType:="VarChar(50) NOT NULL ", CanBeNull:=False)> _
        Public Property READERID() As String
            Get
                Return _READERID
            End Get
            Set(ByVal value As String)
                _READERID = value
            End Set
        End Property
        <Column(Storage:="_SERIAL_NO", DbType:="VarChar(50) NOT NULL ", CanBeNull:=False)> _
        Public Property SERIAL_NO() As String
            Get
                Return _SERIAL_NO
            End Get
            Set(ByVal value As String)
                _SERIAL_NO = value
            End Set
        End Property
        <Column(Storage:="_IP_ADDRESS", DbType:="VarChar(50) NOT NULL ", CanBeNull:=False)> _
        Public Property IP_ADDRESS() As String
            Get
                Return _IP_ADDRESS
            End Get
            Set(ByVal value As String)
                _IP_ADDRESS = value
            End Set
        End Property
        <Column(Storage:="_MAC_ADDRESS", DbType:="VarChar(50) NOT NULL ", CanBeNull:=False)> _
        Public Property MAC_ADDRESS() As String
            Get
                Return _MAC_ADDRESS
            End Get
            Set(ByVal value As String)
                _MAC_ADDRESS = value
            End Set
        End Property
        <Column(Storage:="_INSTALL_POSITION", DbType:="VarChar(255) NOT NULL ", CanBeNull:=False)> _
        Public Property INSTALL_POSITION() As String
            Get
                Return _INSTALL_POSITION
            End Get
            Set(ByVal value As String)
                _INSTALL_POSITION = value
            End Set
        End Property
        <Column(Storage:="_MS_ROOM_ID", DbType:="BigInt NOT NULL ", CanBeNull:=False)> _
        Public Property MS_ROOM_ID() As Long
            Get
                Return _MS_ROOM_ID
            End Get
            Set(ByVal value As Long)
                _MS_ROOM_ID = value
            End Set
        End Property
        <Column(Storage:="_MS_SPEEDWAY_OBJECTIVE_ID", DbType:="BigInt NOT NULL ", CanBeNull:=False)> _
        Public Property MS_SPEEDWAY_OBJECTIVE_ID() As Long
            Get
                Return _MS_SPEEDWAY_OBJECTIVE_ID
            End Get
            Set(ByVal value As Long)
                _MS_SPEEDWAY_OBJECTIVE_ID = value
            End Set
        End Property
        <Column(Storage:="_ANT_QTY", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property ANT_QTY() As Long
            Get
                Return _ANT_QTY
            End Get
            Set(ByVal value As Long)
                _ANT_QTY = value
            End Set
        End Property
        <Column(Storage:="_GPI_QTY", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property GPI_QTY() As Long
            Get
                Return _GPI_QTY
            End Get
            Set(ByVal value As Long)
                _GPI_QTY = value
            End Set
        End Property
        <Column(Storage:="_BRAND_NAME", DbType:="VarChar(255) NOT NULL ", CanBeNull:=False)> _
        Public Property BRAND_NAME() As String
            Get
                Return _BRAND_NAME
            End Get
            Set(ByVal value As String)
                _BRAND_NAME = value
            End Set
        End Property
        <Column(Storage:="_MODEL_NAME", DbType:="VarChar(255) NOT NULL ", CanBeNull:=False)> _
        Public Property MODEL_NAME() As String
            Get
                Return _MODEL_NAME
            End Get
            Set(ByVal value As String)
                _MODEL_NAME = value
            End Set
        End Property
        <Column(Storage:="_ACTIVE_STATUS", DbType:="Char(1) NOT NULL ", CanBeNull:=False)> _
        Public Property ACTIVE_STATUS() As Char
            Get
                Return _ACTIVE_STATUS
            End Get
            Set(ByVal value As Char)
                _ACTIVE_STATUS = value
            End Set
        End Property
        <Column(Storage:="_FTP_USER", DbType:="VarChar(100) NOT NULL ", CanBeNull:=False)> _
        Public Property FTP_USER() As String
            Get
                Return _FTP_USER
            End Get
            Set(ByVal value As String)
                _FTP_USER = value
            End Set
        End Property
        <Column(Storage:="_FTP_PWD", DbType:="VarChar(255) NOT NULL ", CanBeNull:=False)> _
        Public Property FTP_PWD() As String
            Get
                Return _FTP_PWD
            End Get
            Set(ByVal value As String)
                _FTP_PWD = value
            End Set
        End Property
        <Column(Storage:="_FTP_PORT", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property FTP_PORT() As Long
            Get
                Return _FTP_PORT
            End Get
            Set(ByVal value As Long)
                _FTP_PORT = value
            End Set
        End Property
        <Column(Storage:="_FTP_PATH", DbType:="VarChar(255) NOT NULL ", CanBeNull:=False)> _
        Public Property FTP_PATH() As String
            Get
                Return _FTP_PATH
            End Get
            Set(ByVal value As String)
                _FTP_PATH = value
            End Set
        End Property
        <Column(Storage:="_FTP_DATA_PATH", DbType:="VarChar(255)")> _
        Public Property FTP_DATA_PATH() As String
            Get
                Return _FTP_DATA_PATH
            End Get
            Set(ByVal value As String)
                _FTP_DATA_PATH = value
            End Set
        End Property
        <Column(Storage:="_SCHEDULE_TYPE", DbType:="Char(1) NOT NULL ", CanBeNull:=False)> _
        Public Property SCHEDULE_TYPE() As Char
            Get
                Return _SCHEDULE_TYPE
            End Get
            Set(ByVal value As Char)
                _SCHEDULE_TYPE = value
            End Set
        End Property
        <Column(Storage:="_SCHEDULE_DATE", DbType:="DateTime NOT NULL ", CanBeNull:=False)> _
        Public Property SCHEDULE_DATE() As DateTime
            Get
                Return _SCHEDULE_DATE
            End Get
            Set(ByVal value As DateTime)
                _SCHEDULE_DATE = value
            End Set
        End Property
        <Column(Storage:="_IS_SEND_SPEEDWAY", DbType:="Char(1) NOT NULL ", CanBeNull:=False)> _
        Public Property IS_SEND_SPEEDWAY() As Char
            Get
                Return _IS_SEND_SPEEDWAY
            End Get
            Set(ByVal value As Char)
                _IS_SEND_SPEEDWAY = value
            End Set
        End Property
        <Column(Storage:="_IS_UPDATE_SETTING", DbType:="Char(1) NOT NULL ", CanBeNull:=False)> _
        Public Property IS_UPDATE_SETTING() As Char
            Get
                Return _IS_UPDATE_SETTING
            End Get
            Set(ByVal value As Char)
                _IS_UPDATE_SETTING = value
            End Set
        End Property


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1, 1, 1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1, 1, 1)
            _MS_SPEEDWAY_ID = 0
            _READERID = ""
            _SERIAL_NO = ""
            _IP_ADDRESS = ""
            _MAC_ADDRESS = ""
            _INSTALL_POSITION = ""
            _MS_ROOM_ID = 0
            _MS_SPEEDWAY_OBJECTIVE_ID = 0
            _ANT_QTY = 4
            _GPI_QTY = 4
            _BRAND_NAME = ""
            _MODEL_NAME = ""
            _ACTIVE_STATUS = "Y"
            _FTP_USER = ""
            _FTP_PWD = ""
            _FTP_PORT = 0
            _FTP_PATH = ""
            _FTP_DATA_PATH = ""
            _SCHEDULE_TYPE = "N"
            _SCHEDULE_DATE = New DateTime(1, 1, 1)
            _IS_SEND_SPEEDWAY = "N"
            _IS_UPDATE_SETTING = "N"
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


        '/// Returns an indication whether the current data is inserted into CF_SPEEDWAY table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then
                _ID = DB.GetNextID("ID", tableName, trans)
                _Created_By = LoginName
                _Created_date = DateTime.Now
                Return doInsert(trans)
            Else
                _error = "Transaction Is not null"
                Return False
            End If
        End Function


        '/// Returns an indication whether the current data is updated to CF_SPEEDWAY table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then
                _Updated_By = LoginName
                _Updated_Date = DateTime.Now
                Return doUpdate("ID = " & DB.SetDouble(_ID), trans)
            Else
                _error = "Transaction Is not null"
                Return False
            End If
        End Function


        '/// Returns an indication whether the current data is updated to CF_SPEEDWAY table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else
                _error = "Transaction Is not null"
                Return False
            End If
        End Function


        '/// Returns an indication whether the current data is deleted from CF_SPEEDWAY table successfully.
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


        '/// Returns an indication whether the record of CF_SPEEDWAY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of CF_SPEEDWAY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As CfSpeedwayLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY by specified SCHEDULE_DATE_SERIAL_NO key is retrieved successfully.
        '/// <param name=cSCHEDULE_DATE_SERIAL_NO>The SCHEDULE_DATE_SERIAL_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySCHEDULE_DATE_SERIAL_NO(cSCHEDULE_DATE As DateTime, cSERIAL_NO As String, trans As SQLTransaction) As Boolean
            Return doChkData("SCHEDULE_DATE = " & DB.SetDateTime(cSCHEDULE_DATE) & " AND SERIAL_NO = " & DB.SetString(cSERIAL_NO), trans)
        End Function

        '/// Returns an duplicate data record of CF_SPEEDWAY by specified SCHEDULE_DATE_SERIAL_NO key is retrieved successfully.
        '/// <param name=cSCHEDULE_DATE_SERIAL_NO>The SCHEDULE_DATE_SERIAL_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySCHEDULE_DATE_SERIAL_NO(cSCHEDULE_DATE As DateTime, cSERIAL_NO As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SCHEDULE_DATE = " & DB.SetDateTime(cSCHEDULE_DATE) & " AND SERIAL_NO = " & DB.SetString(cSERIAL_NO) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY by specified MAC_ADDRESS_SCHEDULE_DATE key is retrieved successfully.
        '/// <param name=cMAC_ADDRESS_SCHEDULE_DATE>The MAC_ADDRESS_SCHEDULE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMAC_ADDRESS_SCHEDULE_DATE(cMAC_ADDRESS As String, cSCHEDULE_DATE As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("MAC_ADDRESS = " & DB.SetString(cMAC_ADDRESS) & " AND SCHEDULE_DATE = " & DB.SetDateTime(cSCHEDULE_DATE), trans)
        End Function

        '/// Returns an duplicate data record of CF_SPEEDWAY by specified MAC_ADDRESS_SCHEDULE_DATE key is retrieved successfully.
        '/// <param name=cMAC_ADDRESS_SCHEDULE_DATE>The MAC_ADDRESS_SCHEDULE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMAC_ADDRESS_SCHEDULE_DATE(cMAC_ADDRESS As String, cSCHEDULE_DATE As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MAC_ADDRESS = " & DB.SetString(cMAC_ADDRESS) & " AND SCHEDULE_DATE = " & DB.SetDateTime(cSCHEDULE_DATE) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY by specified MS_SPEEDWAY_ID key is retrieved successfully.
        '/// <param name=cMS_SPEEDWAY_ID>The MS_SPEEDWAY_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_SPEEDWAY_ID(cMS_SPEEDWAY_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_SPEEDWAY_ID = " & DB.SetDouble(cMS_SPEEDWAY_ID) & " ", trans)
        End Function

        '/// Returns an duplicate data record of CF_SPEEDWAY by specified MS_SPEEDWAY_ID key is retrieved successfully.
        '/// <param name=cMS_SPEEDWAY_ID>The MS_SPEEDWAY_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_SPEEDWAY_ID(cMS_SPEEDWAY_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_SPEEDWAY_ID = " & DB.SetDouble(cMS_SPEEDWAY_ID) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY by specified SCHEDULE_DATE key is retrieved successfully.
        '/// <param name=cSCHEDULE_DATE>The SCHEDULE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySCHEDULE_DATE(cSCHEDULE_DATE As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("SCHEDULE_DATE = " & DB.SetDateTime(cSCHEDULE_DATE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of CF_SPEEDWAY by specified SCHEDULE_DATE key is retrieved successfully.
        '/// <param name=cSCHEDULE_DATE>The SCHEDULE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySCHEDULE_DATE(cSCHEDULE_DATE As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SCHEDULE_DATE = " & DB.SetDateTime(cSCHEDULE_DATE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into CF_SPEEDWAY table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try
                    Dim dt As DataTable = DB.ExecuteTable(SqlInsert, trans, SetParameterData())
                    If dt.Rows.Count = 0 Then
                        _error = DB.ErrorMessage
                        ret = False
                    Else
                        _haveData = True
                        ret = True
                    End If
                    _information = MessageResources.MSGIN001
                Catch ex As ApplicationException
                    ret = False
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


        '/// Returns an indication whether the current data is updated to CF_SPEEDWAY table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If _haveData = True Then
                If whText.Trim() <> "" Then
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


        '/// Returns an indication whether the current data is deleted from CF_SPEEDWAY table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> "" Then
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
            Dim cmbParam(26) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_MS_SPEEDWAY_ID", SqlDbType.BigInt)
            If _MS_SPEEDWAY_ID IsNot Nothing Then
                cmbParam(5).Value = _MS_SPEEDWAY_ID.Value
            Else
                cmbParam(5).Value = DBNull.value
            End If

            cmbParam(6) = New SqlParameter("@_READERID", SqlDbType.VarChar)
            cmbParam(6).Value = _READERID

            cmbParam(7) = New SqlParameter("@_SERIAL_NO", SqlDbType.VarChar)
            cmbParam(7).Value = _SERIAL_NO

            cmbParam(8) = New SqlParameter("@_IP_ADDRESS", SqlDbType.VarChar)
            cmbParam(8).Value = _IP_ADDRESS

            cmbParam(9) = New SqlParameter("@_MAC_ADDRESS", SqlDbType.VarChar)
            cmbParam(9).Value = _MAC_ADDRESS

            cmbParam(10) = New SqlParameter("@_INSTALL_POSITION", SqlDbType.VarChar)
            cmbParam(10).Value = _INSTALL_POSITION

            cmbParam(11) = New SqlParameter("@_MS_ROOM_ID", SqlDbType.BigInt)
            cmbParam(11).Value = _MS_ROOM_ID

            cmbParam(12) = New SqlParameter("@_MS_SPEEDWAY_OBJECTIVE_ID", SqlDbType.BigInt)
            cmbParam(12).Value = _MS_SPEEDWAY_OBJECTIVE_ID

            cmbParam(13) = New SqlParameter("@_ANT_QTY", SqlDbType.Int)
            cmbParam(13).Value = _ANT_QTY

            cmbParam(14) = New SqlParameter("@_GPI_QTY", SqlDbType.Int)
            cmbParam(14).Value = _GPI_QTY

            cmbParam(15) = New SqlParameter("@_BRAND_NAME", SqlDbType.VarChar)
            cmbParam(15).Value = _BRAND_NAME

            cmbParam(16) = New SqlParameter("@_MODEL_NAME", SqlDbType.VarChar)
            cmbParam(16).Value = _MODEL_NAME

            cmbParam(17) = New SqlParameter("@_ACTIVE_STATUS", SqlDbType.Char)
            cmbParam(17).Value = _ACTIVE_STATUS

            cmbParam(18) = New SqlParameter("@_FTP_USER", SqlDbType.VarChar)
            cmbParam(18).Value = _FTP_USER

            cmbParam(19) = New SqlParameter("@_FTP_PWD", SqlDbType.VarChar)
            cmbParam(19).Value = _FTP_PWD

            cmbParam(20) = New SqlParameter("@_FTP_PORT", SqlDbType.Int)
            cmbParam(20).Value = _FTP_PORT

            cmbParam(21) = New SqlParameter("@_FTP_PATH", SqlDbType.VarChar)
            cmbParam(21).Value = _FTP_PATH

            cmbParam(22) = New SqlParameter("@_FTP_DATA_PATH", SqlDbType.VarChar)
            If _FTP_DATA_PATH.Trim <> "" Then
                cmbParam(22).Value = _FTP_DATA_PATH
            Else
                cmbParam(22).Value = DBNull.value
            End If

            cmbParam(23) = New SqlParameter("@_SCHEDULE_TYPE", SqlDbType.Char)
            cmbParam(23).Value = _SCHEDULE_TYPE

            cmbParam(24) = New SqlParameter("@_SCHEDULE_DATE", SqlDbType.DateTime)
            cmbParam(24).Value = _SCHEDULE_DATE

            cmbParam(25) = New SqlParameter("@_IS_SEND_SPEEDWAY", SqlDbType.Char)
            cmbParam(25).Value = _IS_SEND_SPEEDWAY

            cmbParam(26) = New SqlParameter("@_IS_UPDATE_SETTING", SqlDbType.Char)
            cmbParam(26).Value = _IS_UPDATE_SETTING

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of CF_SPEEDWAY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " WHERE " & whText
            ClearData()
            _haveData = False
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
                        If Convert.IsDBNull(Rdr("ms_speedway_id")) = False Then _ms_speedway_id = Convert.ToInt64(Rdr("ms_speedway_id"))
                        If Convert.IsDBNull(Rdr("ReaderID")) = False Then _ReaderID = Rdr("ReaderID").ToString()
                        If Convert.IsDBNull(Rdr("serial_no")) = False Then _serial_no = Rdr("serial_no").ToString()
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("mac_address")) = False Then _mac_address = Rdr("mac_address").ToString()
                        If Convert.IsDBNull(Rdr("install_position")) = False Then _install_position = Rdr("install_position").ToString()
                        If Convert.IsDBNull(Rdr("ms_room_id")) = False Then _ms_room_id = Convert.ToInt64(Rdr("ms_room_id"))
                        If Convert.IsDBNull(Rdr("ms_speedway_objective_id")) = False Then _ms_speedway_objective_id = Convert.ToInt64(Rdr("ms_speedway_objective_id"))
                        If Convert.IsDBNull(Rdr("ant_qty")) = False Then _ant_qty = Convert.ToInt32(Rdr("ant_qty"))
                        If Convert.IsDBNull(Rdr("gpi_qty")) = False Then _gpi_qty = Convert.ToInt32(Rdr("gpi_qty"))
                        If Convert.IsDBNull(Rdr("brand_name")) = False Then _brand_name = Rdr("brand_name").ToString()
                        If Convert.IsDBNull(Rdr("model_name")) = False Then _model_name = Rdr("model_name").ToString()
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Rdr("active_status").ToString()
                        If Convert.IsDBNull(Rdr("ftp_user")) = False Then _ftp_user = Rdr("ftp_user").ToString()
                        If Convert.IsDBNull(Rdr("ftp_pwd")) = False Then _ftp_pwd = Rdr("ftp_pwd").ToString()
                        If Convert.IsDBNull(Rdr("ftp_port")) = False Then _ftp_port = Convert.ToInt32(Rdr("ftp_port"))
                        If Convert.IsDBNull(Rdr("ftp_path")) = False Then _ftp_path = Rdr("ftp_path").ToString()
                        If Convert.IsDBNull(Rdr("ftp_data_path")) = False Then _ftp_data_path = Rdr("ftp_data_path").ToString()
                        If Convert.IsDBNull(Rdr("schedule_type")) = False Then _schedule_type = Rdr("schedule_type").ToString()
                        If Convert.IsDBNull(Rdr("schedule_date")) = False Then _schedule_date = Convert.ToDateTime(Rdr("schedule_date"))
                        If Convert.IsDBNull(Rdr("is_send_speedway")) = False Then _is_send_speedway = Rdr("is_send_speedway").ToString()
                        If Convert.IsDBNull(Rdr("is_update_setting")) = False Then _is_update_setting = Rdr("is_update_setting").ToString()
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


        '/// Returns an indication whether the record of CF_SPEEDWAY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As CfSpeedwayLinqDB
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
                        If Convert.IsDBNull(Rdr("created_by")) = False Then _created_by = Rdr("created_by").ToString()
                        If Convert.IsDBNull(Rdr("created_date")) = False Then _created_date = Convert.ToDateTime(Rdr("created_date"))
                        If Convert.IsDBNull(Rdr("updated_by")) = False Then _updated_by = Rdr("updated_by").ToString()
                        If Convert.IsDBNull(Rdr("updated_date")) = False Then _updated_date = Convert.ToDateTime(Rdr("updated_date"))
                        If Convert.IsDBNull(Rdr("ms_speedway_id")) = False Then _ms_speedway_id = Convert.ToInt64(Rdr("ms_speedway_id"))
                        If Convert.IsDBNull(Rdr("ReaderID")) = False Then _ReaderID = Rdr("ReaderID").ToString()
                        If Convert.IsDBNull(Rdr("serial_no")) = False Then _serial_no = Rdr("serial_no").ToString()
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("mac_address")) = False Then _mac_address = Rdr("mac_address").ToString()
                        If Convert.IsDBNull(Rdr("install_position")) = False Then _install_position = Rdr("install_position").ToString()
                        If Convert.IsDBNull(Rdr("ms_room_id")) = False Then _ms_room_id = Convert.ToInt64(Rdr("ms_room_id"))
                        If Convert.IsDBNull(Rdr("ms_speedway_objective_id")) = False Then _ms_speedway_objective_id = Convert.ToInt64(Rdr("ms_speedway_objective_id"))
                        If Convert.IsDBNull(Rdr("ant_qty")) = False Then _ant_qty = Convert.ToInt32(Rdr("ant_qty"))
                        If Convert.IsDBNull(Rdr("gpi_qty")) = False Then _gpi_qty = Convert.ToInt32(Rdr("gpi_qty"))
                        If Convert.IsDBNull(Rdr("brand_name")) = False Then _brand_name = Rdr("brand_name").ToString()
                        If Convert.IsDBNull(Rdr("model_name")) = False Then _model_name = Rdr("model_name").ToString()
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Rdr("active_status").ToString()
                        If Convert.IsDBNull(Rdr("ftp_user")) = False Then _ftp_user = Rdr("ftp_user").ToString()
                        If Convert.IsDBNull(Rdr("ftp_pwd")) = False Then _ftp_pwd = Rdr("ftp_pwd").ToString()
                        If Convert.IsDBNull(Rdr("ftp_port")) = False Then _ftp_port = Convert.ToInt32(Rdr("ftp_port"))
                        If Convert.IsDBNull(Rdr("ftp_path")) = False Then _ftp_path = Rdr("ftp_path").ToString()
                        If Convert.IsDBNull(Rdr("ftp_data_path")) = False Then _ftp_data_path = Rdr("ftp_data_path").ToString()
                        If Convert.IsDBNull(Rdr("schedule_type")) = False Then _schedule_type = Rdr("schedule_type").ToString()
                        If Convert.IsDBNull(Rdr("schedule_date")) = False Then _schedule_date = Convert.ToDateTime(Rdr("schedule_date"))
                        If Convert.IsDBNull(Rdr("is_send_speedway")) = False Then _is_send_speedway = Rdr("is_send_speedway").ToString()
                        If Convert.IsDBNull(Rdr("is_update_setting")) = False Then _is_update_setting = Rdr("is_update_setting").ToString()
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


        'Get Insert Statement for table CF_SPEEDWAY
        Private ReadOnly Property SqlInsert() As String
            Get
                Dim Sql As String = ""
                Sql += "INSERT INTO " & tableName & " (ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_SPEEDWAY_ID, READERID, SERIAL_NO, IP_ADDRESS, MAC_ADDRESS, INSTALL_POSITION, MS_ROOM_ID, MS_SPEEDWAY_OBJECTIVE_ID, ANT_QTY, GPI_QTY, BRAND_NAME, MODEL_NAME, ACTIVE_STATUS, FTP_USER, FTP_PWD, FTP_PORT, FTP_PATH, FTP_DATA_PATH, SCHEDULE_TYPE, SCHEDULE_DATE, IS_SEND_SPEEDWAY, IS_UPDATE_SETTING)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MS_SPEEDWAY_ID, INSERTED.READERID, INSERTED.SERIAL_NO, INSERTED.IP_ADDRESS, INSERTED.MAC_ADDRESS, INSERTED.INSTALL_POSITION, INSERTED.MS_ROOM_ID, INSERTED.MS_SPEEDWAY_OBJECTIVE_ID, INSERTED.ANT_QTY, INSERTED.GPI_QTY, INSERTED.BRAND_NAME, INSERTED.MODEL_NAME, INSERTED.ACTIVE_STATUS, INSERTED.FTP_USER, INSERTED.FTP_PWD, INSERTED.FTP_PORT, INSERTED.FTP_PATH, INSERTED.FTP_DATA_PATH, INSERTED.SCHEDULE_TYPE, INSERTED.SCHEDULE_DATE, INSERTED.IS_SEND_SPEEDWAY, INSERTED.IS_UPDATE_SETTING"
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_MS_SPEEDWAY_ID" & ", "
                sql += "@_READERID" & ", "
                sql += "@_SERIAL_NO" & ", "
                sql += "@_IP_ADDRESS" & ", "
                sql += "@_MAC_ADDRESS" & ", "
                sql += "@_INSTALL_POSITION" & ", "
                sql += "@_MS_ROOM_ID" & ", "
                sql += "@_MS_SPEEDWAY_OBJECTIVE_ID" & ", "
                sql += "@_ANT_QTY" & ", "
                sql += "@_GPI_QTY" & ", "
                sql += "@_BRAND_NAME" & ", "
                sql += "@_MODEL_NAME" & ", "
                sql += "@_ACTIVE_STATUS" & ", "
                sql += "@_FTP_USER" & ", "
                sql += "@_FTP_PWD" & ", "
                sql += "@_FTP_PORT" & ", "
                sql += "@_FTP_PATH" & ", "
                sql += "@_FTP_DATA_PATH" & ", "
                sql += "@_SCHEDULE_TYPE" & ", "
                sql += "@_SCHEDULE_DATE" & ", "
                sql += "@_IS_SEND_SPEEDWAY" & ", "
                sql += "@_IS_UPDATE_SETTING"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table CF_SPEEDWAY
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_SPEEDWAY_ID = " & "@_MS_SPEEDWAY_ID" & ", "
                Sql += "READERID = " & "@_READERID" & ", "
                Sql += "SERIAL_NO = " & "@_SERIAL_NO" & ", "
                Sql += "IP_ADDRESS = " & "@_IP_ADDRESS" & ", "
                Sql += "MAC_ADDRESS = " & "@_MAC_ADDRESS" & ", "
                Sql += "INSTALL_POSITION = " & "@_INSTALL_POSITION" & ", "
                Sql += "MS_ROOM_ID = " & "@_MS_ROOM_ID" & ", "
                Sql += "MS_SPEEDWAY_OBJECTIVE_ID = " & "@_MS_SPEEDWAY_OBJECTIVE_ID" & ", "
                Sql += "ANT_QTY = " & "@_ANT_QTY" & ", "
                Sql += "GPI_QTY = " & "@_GPI_QTY" & ", "
                Sql += "BRAND_NAME = " & "@_BRAND_NAME" & ", "
                Sql += "MODEL_NAME = " & "@_MODEL_NAME" & ", "
                Sql += "ACTIVE_STATUS = " & "@_ACTIVE_STATUS" & ", "
                Sql += "FTP_USER = " & "@_FTP_USER" & ", "
                Sql += "FTP_PWD = " & "@_FTP_PWD" & ", "
                Sql += "FTP_PORT = " & "@_FTP_PORT" & ", "
                Sql += "FTP_PATH = " & "@_FTP_PATH" & ", "
                Sql += "FTP_DATA_PATH = " & "@_FTP_DATA_PATH" & ", "
                Sql += "SCHEDULE_TYPE = " & "@_SCHEDULE_TYPE" & ", "
                Sql += "SCHEDULE_DATE = " & "@_SCHEDULE_DATE" & ", "
                Sql += "IS_SEND_SPEEDWAY = " & "@_IS_SEND_SPEEDWAY" & ", "
                Sql += "IS_UPDATE_SETTING = " & "@_IS_UPDATE_SETTING" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table CF_SPEEDWAY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table CF_SPEEDWAY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_SPEEDWAY_ID, READERID, SERIAL_NO, IP_ADDRESS, MAC_ADDRESS, INSTALL_POSITION, MS_ROOM_ID, MS_SPEEDWAY_OBJECTIVE_ID, ANT_QTY, GPI_QTY, BRAND_NAME, MODEL_NAME, ACTIVE_STATUS, FTP_USER, FTP_PWD, FTP_PORT, FTP_PATH, FTP_DATA_PATH, SCHEDULE_TYPE, SCHEDULE_DATE, IS_SEND_SPEEDWAY, IS_UPDATE_SETTING FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
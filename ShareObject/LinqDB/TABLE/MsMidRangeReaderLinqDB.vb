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
    'Represents a transaction for MS_MID_RANGE_READER table LinqDB.
    '[Create by  on April, 9 2015]
    Public Class MsMidRangeReaderLinqDB
        Public sub MsMidRangeReaderLinqDB()

        End Sub 
        ' MS_MID_RANGE_READER
        Const _tableName As String = "MS_MID_RANGE_READER"
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
        Dim _SERIAL_NO As String = ""
        Dim _IP_ADDRESS As String = ""
        Dim _MAC_ADDRESS As String = ""
        Dim _TCP_PORT_NO As Long = 0
        Dim _INSTALL_POSITION As String = ""
        Dim _MS_ROOM_ID As Long = 0
        Dim _MS_SPEEDWAY_OBJECT_ID As Long = 0
        Dim _ANT_QTY As Long = 0
        Dim _BRAND_NAME As  String  = ""
        Dim _MODEL_NAME As  String  = ""
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
        <Column(Storage:="_SERIAL_NO", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERIAL_NO() As String
            Get
                Return _SERIAL_NO
            End Get
            Set(ByVal value As String)
               _SERIAL_NO = value
            End Set
        End Property 
        <Column(Storage:="_IP_ADDRESS", DbType:="VarChar(20) NOT NULL ",CanBeNull:=false)>  _
        Public Property IP_ADDRESS() As String
            Get
                Return _IP_ADDRESS
            End Get
            Set(ByVal value As String)
               _IP_ADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_MAC_ADDRESS", DbType:="VarChar(20) NOT NULL ",CanBeNull:=false)>  _
        Public Property MAC_ADDRESS() As String
            Get
                Return _MAC_ADDRESS
            End Get
            Set(ByVal value As String)
               _MAC_ADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_TCP_PORT_NO", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property TCP_PORT_NO() As Long
            Get
                Return _TCP_PORT_NO
            End Get
            Set(ByVal value As Long)
               _TCP_PORT_NO = value
            End Set
        End Property 
        <Column(Storage:="_INSTALL_POSITION", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property INSTALL_POSITION() As String
            Get
                Return _INSTALL_POSITION
            End Get
            Set(ByVal value As String)
               _INSTALL_POSITION = value
            End Set
        End Property 
        <Column(Storage:="_MS_ROOM_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_ROOM_ID() As Long
            Get
                Return _MS_ROOM_ID
            End Get
            Set(ByVal value As Long)
               _MS_ROOM_ID = value
            End Set
        End Property 
        <Column(Storage:="_MS_SPEEDWAY_OBJECT_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_SPEEDWAY_OBJECT_ID() As Long
            Get
                Return _MS_SPEEDWAY_OBJECT_ID
            End Get
            Set(ByVal value As Long)
               _MS_SPEEDWAY_OBJECT_ID = value
            End Set
        End Property 
        <Column(Storage:="_ANT_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property ANT_QTY() As Long
            Get
                Return _ANT_QTY
            End Get
            Set(ByVal value As Long)
               _ANT_QTY = value
            End Set
        End Property 
        <Column(Storage:="_BRAND_NAME", DbType:="VarChar(255)")>  _
        Public Property BRAND_NAME() As  String 
            Get
                Return _BRAND_NAME
            End Get
            Set(ByVal value As  String )
               _BRAND_NAME = value
            End Set
        End Property 
        <Column(Storage:="_MODEL_NAME", DbType:="VarChar(255)")>  _
        Public Property MODEL_NAME() As  String 
            Get
                Return _MODEL_NAME
            End Get
            Set(ByVal value As  String )
               _MODEL_NAME = value
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
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _SERIAL_NO = ""
            _IP_ADDRESS = ""
            _MAC_ADDRESS = ""
            _TCP_PORT_NO = 0
            _INSTALL_POSITION = ""
            _MS_ROOM_ID = 0
            _MS_SPEEDWAY_OBJECT_ID = 0
            _ANT_QTY = 1
            _BRAND_NAME = ""
            _MODEL_NAME = ""
            _ACTIVE_STATUS = "Y"
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


        '/// Returns an indication whether the current data is inserted into MS_MID_RANGE_READER table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_MID_RANGE_READER table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_MID_RANGE_READER table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from MS_MID_RANGE_READER table successfully.
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


        '/// Returns an indication whether the record of MS_MID_RANGE_READER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_MID_RANGE_READER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsMidRangeReaderLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of MS_MID_RANGE_READER by specified SERIAL_NO key is retrieved successfully.
        '/// <param name=cSERIAL_NO>The SERIAL_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySERIAL_NO(cSERIAL_NO As String, trans As SQLTransaction) As Boolean
            Return doChkData("SERIAL_NO = " & DB.SetString(cSERIAL_NO) & " ", trans)
        End Function

        '/// Returns an duplicate data record of MS_MID_RANGE_READER by specified SERIAL_NO key is retrieved successfully.
        '/// <param name=cSERIAL_NO>The SERIAL_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySERIAL_NO(cSERIAL_NO As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SERIAL_NO = " & DB.SetString(cSERIAL_NO) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_MID_RANGE_READER by specified IP_ADDRESS key is retrieved successfully.
        '/// <param name=cIP_ADDRESS>The IP_ADDRESS key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByIP_ADDRESS(cIP_ADDRESS As String, trans As SQLTransaction) As Boolean
            Return doChkData("IP_ADDRESS = " & DB.SetString(cIP_ADDRESS) & " ", trans)
        End Function

        '/// Returns an duplicate data record of MS_MID_RANGE_READER by specified IP_ADDRESS key is retrieved successfully.
        '/// <param name=cIP_ADDRESS>The IP_ADDRESS key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByIP_ADDRESS(cIP_ADDRESS As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("IP_ADDRESS = " & DB.SetString(cIP_ADDRESS) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_MID_RANGE_READER by specified MAC_ADDRESS key is retrieved successfully.
        '/// <param name=cMAC_ADDRESS>The MAC_ADDRESS key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMAC_ADDRESS(cMAC_ADDRESS As String, trans As SQLTransaction) As Boolean
            Return doChkData("MAC_ADDRESS = " & DB.SetString(cMAC_ADDRESS) & " ", trans)
        End Function

        '/// Returns an duplicate data record of MS_MID_RANGE_READER by specified MAC_ADDRESS key is retrieved successfully.
        '/// <param name=cMAC_ADDRESS>The MAC_ADDRESS key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMAC_ADDRESS(cMAC_ADDRESS As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MAC_ADDRESS = " & DB.SetString(cMAC_ADDRESS) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_MID_RANGE_READER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_MID_RANGE_READER table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_MID_RANGE_READER table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_MID_RANGE_READER table successfully.
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

            cmbParam(5) = New SqlParameter("@_SERIAL_NO", SqlDbType.VarChar)
            cmbParam(5).Value = _SERIAL_NO

            cmbParam(6) = New SqlParameter("@_IP_ADDRESS", SqlDbType.VarChar)
            cmbParam(6).Value = _IP_ADDRESS

            cmbParam(7) = New SqlParameter("@_MAC_ADDRESS", SqlDbType.VarChar)
            cmbParam(7).Value = _MAC_ADDRESS

            cmbParam(8) = New SqlParameter("@_TCP_PORT_NO", SqlDbType.Int)
            cmbParam(8).Value = _TCP_PORT_NO

            cmbParam(9) = New SqlParameter("@_INSTALL_POSITION", SqlDbType.VarChar)
            cmbParam(9).Value = _INSTALL_POSITION

            cmbParam(10) = New SqlParameter("@_MS_ROOM_ID", SqlDbType.BigInt)
            cmbParam(10).Value = _MS_ROOM_ID

            cmbParam(11) = New SqlParameter("@_MS_SPEEDWAY_OBJECT_ID", SqlDbType.BigInt)
            cmbParam(11).Value = _MS_SPEEDWAY_OBJECT_ID

            cmbParam(12) = New SqlParameter("@_ANT_QTY", SqlDbType.Int)
            cmbParam(12).Value = _ANT_QTY

            cmbParam(13) = New SqlParameter("@_BRAND_NAME", SqlDbType.VarChar)
            If _BRAND_NAME.Trim <> "" Then 
                cmbParam(13).Value = _BRAND_NAME
            Else
                cmbParam(13).Value = DBNull.value
            End If

            cmbParam(14) = New SqlParameter("@_MODEL_NAME", SqlDbType.VarChar)
            If _MODEL_NAME.Trim <> "" Then 
                cmbParam(14).Value = _MODEL_NAME
            Else
                cmbParam(14).Value = DBNull.value
            End If

            cmbParam(15) = New SqlParameter("@_ACTIVE_STATUS", SqlDbType.Char)
            cmbParam(15).Value = _ACTIVE_STATUS

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_MID_RANGE_READER by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("serial_no")) = False Then _serial_no = Rdr("serial_no").ToString()
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("mac_address")) = False Then _mac_address = Rdr("mac_address").ToString()
                        If Convert.IsDBNull(Rdr("tcp_port_no")) = False Then _tcp_port_no = Convert.ToInt32(Rdr("tcp_port_no"))
                        If Convert.IsDBNull(Rdr("install_position")) = False Then _install_position = Rdr("install_position").ToString()
                        If Convert.IsDBNull(Rdr("ms_room_id")) = False Then _ms_room_id = Convert.ToInt64(Rdr("ms_room_id"))
                        If Convert.IsDBNull(Rdr("ms_speedway_object_id")) = False Then _ms_speedway_object_id = Convert.ToInt64(Rdr("ms_speedway_object_id"))
                        If Convert.IsDBNull(Rdr("ant_qty")) = False Then _ant_qty = Convert.ToInt32(Rdr("ant_qty"))
                        If Convert.IsDBNull(Rdr("brand_name")) = False Then _brand_name = Rdr("brand_name").ToString()
                        If Convert.IsDBNull(Rdr("model_name")) = False Then _model_name = Rdr("model_name").ToString()
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


        '/// Returns an indication whether the record of MS_MID_RANGE_READER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As MsMidRangeReaderLinqDB
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
                        If Convert.IsDBNull(Rdr("serial_no")) = False Then _serial_no = Rdr("serial_no").ToString()
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("mac_address")) = False Then _mac_address = Rdr("mac_address").ToString()
                        If Convert.IsDBNull(Rdr("tcp_port_no")) = False Then _tcp_port_no = Convert.ToInt32(Rdr("tcp_port_no"))
                        If Convert.IsDBNull(Rdr("install_position")) = False Then _install_position = Rdr("install_position").ToString()
                        If Convert.IsDBNull(Rdr("ms_room_id")) = False Then _ms_room_id = Convert.ToInt64(Rdr("ms_room_id"))
                        If Convert.IsDBNull(Rdr("ms_speedway_object_id")) = False Then _ms_speedway_object_id = Convert.ToInt64(Rdr("ms_speedway_object_id"))
                        If Convert.IsDBNull(Rdr("ant_qty")) = False Then _ant_qty = Convert.ToInt32(Rdr("ant_qty"))
                        If Convert.IsDBNull(Rdr("brand_name")) = False Then _brand_name = Rdr("brand_name").ToString()
                        If Convert.IsDBNull(Rdr("model_name")) = False Then _model_name = Rdr("model_name").ToString()
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


        'Get Insert Statement for table MS_MID_RANGE_READER
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, SERIAL_NO, IP_ADDRESS, MAC_ADDRESS, TCP_PORT_NO, INSTALL_POSITION, MS_ROOM_ID, MS_SPEEDWAY_OBJECT_ID, ANT_QTY, BRAND_NAME, MODEL_NAME, ACTIVE_STATUS)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.SERIAL_NO, INSERTED.IP_ADDRESS, INSERTED.MAC_ADDRESS, INSERTED.TCP_PORT_NO, INSERTED.INSTALL_POSITION, INSERTED.MS_ROOM_ID, INSERTED.MS_SPEEDWAY_OBJECT_ID, INSERTED.ANT_QTY, INSERTED.BRAND_NAME, INSERTED.MODEL_NAME, INSERTED.ACTIVE_STATUS
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_SERIAL_NO" & ", "
                sql += "@_IP_ADDRESS" & ", "
                sql += "@_MAC_ADDRESS" & ", "
                sql += "@_TCP_PORT_NO" & ", "
                sql += "@_INSTALL_POSITION" & ", "
                sql += "@_MS_ROOM_ID" & ", "
                sql += "@_MS_SPEEDWAY_OBJECT_ID" & ", "
                sql += "@_ANT_QTY" & ", "
                sql += "@_BRAND_NAME" & ", "
                sql += "@_MODEL_NAME" & ", "
                sql += "@_ACTIVE_STATUS"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_MID_RANGE_READER
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "SERIAL_NO = " & "@_SERIAL_NO" & ", "
                Sql += "IP_ADDRESS = " & "@_IP_ADDRESS" & ", "
                Sql += "MAC_ADDRESS = " & "@_MAC_ADDRESS" & ", "
                Sql += "TCP_PORT_NO = " & "@_TCP_PORT_NO" & ", "
                Sql += "INSTALL_POSITION = " & "@_INSTALL_POSITION" & ", "
                Sql += "MS_ROOM_ID = " & "@_MS_ROOM_ID" & ", "
                Sql += "MS_SPEEDWAY_OBJECT_ID = " & "@_MS_SPEEDWAY_OBJECT_ID" & ", "
                Sql += "ANT_QTY = " & "@_ANT_QTY" & ", "
                Sql += "BRAND_NAME = " & "@_BRAND_NAME" & ", "
                Sql += "MODEL_NAME = " & "@_MODEL_NAME" & ", "
                Sql += "ACTIVE_STATUS = " & "@_ACTIVE_STATUS" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_MID_RANGE_READER
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_MID_RANGE_READER
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, SERIAL_NO, IP_ADDRESS, MAC_ADDRESS, TCP_PORT_NO, INSTALL_POSITION, MS_ROOM_ID, MS_SPEEDWAY_OBJECT_ID, ANT_QTY, BRAND_NAME, MODEL_NAME, ACTIVE_STATUS FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

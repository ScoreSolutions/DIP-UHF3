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
    'Represents a transaction for TB_IAM_ALIVE table LinqDB.
    '[Create by  on March, 3 2015]
    Public Class TbIamAliveLinqDB
        Public sub TbIamAliveLinqDB()

        End Sub 
        ' TB_IAM_ALIVE
        Const _tableName As String = "TB_IAM_ALIVE"
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
        Dim _SERVERNAME As String = ""
        Dim _MACADDRESS As String = ""
        Dim _HOSTIP As String = ""
        Dim _CFG_MONITOR_TIME_START As String = ""
        Dim _CFG_MONITOR_TIME_END As String = ""
        Dim _CFG_INTERVAL As Long = 0
        Dim _ALIVE_TIME As DateTime = New DateTime(1,1,1)
        Dim _NEXT_ALIVE_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

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
        <Column(Storage:="_SERVERNAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVERNAME() As String
            Get
                Return _SERVERNAME
            End Get
            Set(ByVal value As String)
               _SERVERNAME = value
            End Set
        End Property 
        <Column(Storage:="_MACADDRESS", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property MACADDRESS() As String
            Get
                Return _MACADDRESS
            End Get
            Set(ByVal value As String)
               _MACADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_HOSTIP", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property HOSTIP() As String
            Get
                Return _HOSTIP
            End Get
            Set(ByVal value As String)
               _HOSTIP = value
            End Set
        End Property 
        <Column(Storage:="_CFG_MONITOR_TIME_START", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property CFG_MONITOR_TIME_START() As String
            Get
                Return _CFG_MONITOR_TIME_START
            End Get
            Set(ByVal value As String)
               _CFG_MONITOR_TIME_START = value
            End Set
        End Property 
        <Column(Storage:="_CFG_MONITOR_TIME_END", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property CFG_MONITOR_TIME_END() As String
            Get
                Return _CFG_MONITOR_TIME_END
            End Get
            Set(ByVal value As String)
               _CFG_MONITOR_TIME_END = value
            End Set
        End Property 
        <Column(Storage:="_CFG_INTERVAL", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CFG_INTERVAL() As Long
            Get
                Return _CFG_INTERVAL
            End Get
            Set(ByVal value As Long)
               _CFG_INTERVAL = value
            End Set
        End Property 
        <Column(Storage:="_ALIVE_TIME", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property ALIVE_TIME() As DateTime
            Get
                Return _ALIVE_TIME
            End Get
            Set(ByVal value As DateTime)
               _ALIVE_TIME = value
            End Set
        End Property 
        <Column(Storage:="_NEXT_ALIVE_TIME", DbType:="DateTime")>  _
        Public Property NEXT_ALIVE_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _NEXT_ALIVE_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _NEXT_ALIVE_TIME = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATEDDATE = New DateTime(1,1,1)
            _CREATEDBY = ""
            _UPDATEDDATE = New DateTime(1,1,1)
            _UPDATEDBY = ""
            _SERVERNAME = ""
            _MACADDRESS = ""
            _HOSTIP = ""
            _CFG_MONITOR_TIME_START = ""
            _CFG_MONITOR_TIME_END = ""
            _CFG_INTERVAL = 0
            _ALIVE_TIME = New DateTime(1,1,1)
            _NEXT_ALIVE_TIME = New DateTime(1,1,1)
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


        '/// Returns an indication whether the current data is inserted into TB_IAM_ALIVE table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _CreatedBy = LoginName
                _CreatedDate = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TB_IAM_ALIVE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_IAM_ALIVE table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_IAM_ALIVE table successfully.
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


        '/// Returns an indication whether the record of TB_IAM_ALIVE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_IAM_ALIVE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbIamAliveLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_IAM_ALIVE by specified HOSTIP key is retrieved successfully.
        '/// <param name=cHOSTIP>The HOSTIP key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByHOSTIP(cHOSTIP As String, trans As SQLTransaction) As Boolean
            Return doChkData("HOSTIP = " & DB.SetString(cHOSTIP) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_IAM_ALIVE by specified HOSTIP key is retrieved successfully.
        '/// <param name=cHOSTIP>The HOSTIP key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByHOSTIP(cHOSTIP As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("HOSTIP = " & DB.SetString(cHOSTIP) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_IAM_ALIVE by specified SERVERNAME key is retrieved successfully.
        '/// <param name=cSERVERNAME>The SERVERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySERVERNAME(cSERVERNAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("SERVERNAME = " & DB.SetString(cSERVERNAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_IAM_ALIVE by specified SERVERNAME key is retrieved successfully.
        '/// <param name=cSERVERNAME>The SERVERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySERVERNAME(cSERVERNAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SERVERNAME = " & DB.SetString(cSERVERNAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_IAM_ALIVE by specified MACADDRESS key is retrieved successfully.
        '/// <param name=cMACADDRESS>The MACADDRESS key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMACADDRESS(cMACADDRESS As String, trans As SQLTransaction) As Boolean
            Return doChkData("MACADDRESS = " & DB.SetString(cMACADDRESS) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_IAM_ALIVE by specified MACADDRESS key is retrieved successfully.
        '/// <param name=cMACADDRESS>The MACADDRESS key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMACADDRESS(cMACADDRESS As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MACADDRESS = " & DB.SetString(cMACADDRESS) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_IAM_ALIVE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_IAM_ALIVE table successfully.
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
                        _ID = DB.GetLastID(_tableName, trans)
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


        '/// Returns an indication whether the current data is updated to TB_IAM_ALIVE table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_IAM_ALIVE table successfully.
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


        '/// Returns an indication whether the record of TB_IAM_ALIVE by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ServerName")) = False Then _ServerName = Rdr("ServerName").ToString()
                        If Convert.IsDBNull(Rdr("MacAddress")) = False Then _MacAddress = Rdr("MacAddress").ToString()
                        If Convert.IsDBNull(Rdr("HostIP")) = False Then _HostIP = Rdr("HostIP").ToString()
                        If Convert.IsDBNull(Rdr("cfg_monitor_time_start")) = False Then _cfg_monitor_time_start = Rdr("cfg_monitor_time_start").ToString()
                        If Convert.IsDBNull(Rdr("cfg_monitor_time_end")) = False Then _cfg_monitor_time_end = Rdr("cfg_monitor_time_end").ToString()
                        If Convert.IsDBNull(Rdr("cfg_interval")) = False Then _cfg_interval = Convert.ToInt32(Rdr("cfg_interval"))
                        If Convert.IsDBNull(Rdr("alive_time")) = False Then _alive_time = Convert.ToDateTime(Rdr("alive_time"))
                        If Convert.IsDBNull(Rdr("next_alive_time")) = False Then _next_alive_time = Convert.ToDateTime(Rdr("next_alive_time"))
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


        '/// Returns an indication whether the record of TB_IAM_ALIVE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbIamAliveLinqDB
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
                        If Convert.IsDBNull(Rdr("ServerName")) = False Then _ServerName = Rdr("ServerName").ToString()
                        If Convert.IsDBNull(Rdr("MacAddress")) = False Then _MacAddress = Rdr("MacAddress").ToString()
                        If Convert.IsDBNull(Rdr("HostIP")) = False Then _HostIP = Rdr("HostIP").ToString()
                        If Convert.IsDBNull(Rdr("cfg_monitor_time_start")) = False Then _cfg_monitor_time_start = Rdr("cfg_monitor_time_start").ToString()
                        If Convert.IsDBNull(Rdr("cfg_monitor_time_end")) = False Then _cfg_monitor_time_end = Rdr("cfg_monitor_time_end").ToString()
                        If Convert.IsDBNull(Rdr("cfg_interval")) = False Then _cfg_interval = Convert.ToInt32(Rdr("cfg_interval"))
                        If Convert.IsDBNull(Rdr("alive_time")) = False Then _alive_time = Convert.ToDateTime(Rdr("alive_time"))
                        If Convert.IsDBNull(Rdr("next_alive_time")) = False Then _next_alive_time = Convert.ToDateTime(Rdr("next_alive_time"))
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


        'Get Insert Statement for table TB_IAM_ALIVE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATEDDATE, CREATEDBY, SERVERNAME, MACADDRESS, HOSTIP, CFG_MONITOR_TIME_START, CFG_MONITOR_TIME_END, CFG_INTERVAL, ALIVE_TIME, NEXT_ALIVE_TIME)"
                Sql += " VALUES("
                sql += DB.SetDateTime(_CREATEDDATE) & ", "
                sql += DB.SetString(_CREATEDBY) & ", "
                sql += DB.SetString(_SERVERNAME) & ", "
                sql += DB.SetString(_MACADDRESS) & ", "
                sql += DB.SetString(_HOSTIP) & ", "
                sql += DB.SetString(_CFG_MONITOR_TIME_START) & ", "
                sql += DB.SetString(_CFG_MONITOR_TIME_END) & ", "
                sql += DB.SetDouble(_CFG_INTERVAL) & ", "
                sql += DB.SetDateTime(_ALIVE_TIME) & ", "
                sql += DB.SetDateTime(_NEXT_ALIVE_TIME)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_IAM_ALIVE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATEDDATE = " & DB.SetDateTime(_UPDATEDDATE) & ", "
                Sql += "UPDATEDBY = " & DB.SetString(_UPDATEDBY) & ", "
                Sql += "SERVERNAME = " & DB.SetString(_SERVERNAME) & ", "
                Sql += "MACADDRESS = " & DB.SetString(_MACADDRESS) & ", "
                Sql += "HOSTIP = " & DB.SetString(_HOSTIP) & ", "
                Sql += "CFG_MONITOR_TIME_START = " & DB.SetString(_CFG_MONITOR_TIME_START) & ", "
                Sql += "CFG_MONITOR_TIME_END = " & DB.SetString(_CFG_MONITOR_TIME_END) & ", "
                Sql += "CFG_INTERVAL = " & DB.SetDouble(_CFG_INTERVAL) & ", "
                Sql += "ALIVE_TIME = " & DB.SetDateTime(_ALIVE_TIME) & ", "
                Sql += "NEXT_ALIVE_TIME = " & DB.SetDateTime(_NEXT_ALIVE_TIME) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_IAM_ALIVE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_IAM_ALIVE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATEDDATE, CREATEDBY, UPDATEDDATE, UPDATEDBY, SERVERNAME, MACADDRESS, HOSTIP, CFG_MONITOR_TIME_START, CFG_MONITOR_TIME_END, CFG_INTERVAL, ALIVE_TIME, NEXT_ALIVE_TIME FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace

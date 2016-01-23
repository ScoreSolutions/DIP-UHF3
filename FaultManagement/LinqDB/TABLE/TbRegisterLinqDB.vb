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
    'Represents a transaction for TB_REGISTER table LinqDB.
    '[Create by  on March, 25 2015]
    Public Class TbRegisterLinqDB
        Public sub TbRegisterLinqDB()

        End Sub 
        ' TB_REGISTER
        Const _tableName As String = "TB_REGISTER"
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
        Dim _SERVERIP As String = ""
        Dim _SERVERNAME As String = ""
        Dim _OS As String = ""
        Dim _ACTIVE_STATUS As Char = ""
        Dim _E_MAIL As String = ""
        Dim _FNAME As String = ""
        Dim _LNAME As String = ""
        Dim _SYSTEM_TYPE As String = ""
        Dim _GROUP_ID As Long = 0
        Dim _MACADDRESS As String = ""
        Dim _LOCATIONSERVER As  String  = ""
        Dim _LOCATIONNO As  String  = ""
        Dim _ONLINE_STATUS As  System.Nullable(Of Char)  = ""
        Dim _TODAY_ALAILABLE As  System.Nullable(Of Long)  = 0

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
        <Column(Storage:="_SERVERIP", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVERIP() As String
            Get
                Return _SERVERIP
            End Get
            Set(ByVal value As String)
               _SERVERIP = value
            End Set
        End Property 
        <Column(Storage:="_SERVERNAME", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVERNAME() As String
            Get
                Return _SERVERNAME
            End Get
            Set(ByVal value As String)
               _SERVERNAME = value
            End Set
        End Property 
        <Column(Storage:="_OS", DbType:="VarChar(200) NOT NULL ",CanBeNull:=false)>  _
        Public Property OS() As String
            Get
                Return _OS
            End Get
            Set(ByVal value As String)
               _OS = value
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
        <Column(Storage:="_E_MAIL", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property E_MAIL() As String
            Get
                Return _E_MAIL
            End Get
            Set(ByVal value As String)
               _E_MAIL = value
            End Set
        End Property 
        <Column(Storage:="_FNAME", DbType:="NVarChar(200) NOT NULL ",CanBeNull:=false)>  _
        Public Property FNAME() As String
            Get
                Return _FNAME
            End Get
            Set(ByVal value As String)
               _FNAME = value
            End Set
        End Property 
        <Column(Storage:="_LNAME", DbType:="NVarChar(200) NOT NULL ",CanBeNull:=false)>  _
        Public Property LNAME() As String
            Get
                Return _LNAME
            End Get
            Set(ByVal value As String)
               _LNAME = value
            End Set
        End Property 
        <Column(Storage:="_SYSTEM_TYPE", DbType:="NVarChar(200) NOT NULL ",CanBeNull:=false)>  _
        Public Property SYSTEM_TYPE() As String
            Get
                Return _SYSTEM_TYPE
            End Get
            Set(ByVal value As String)
               _SYSTEM_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_GROUP_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property GROUP_ID() As Long
            Get
                Return _GROUP_ID
            End Get
            Set(ByVal value As Long)
               _GROUP_ID = value
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
        <Column(Storage:="_LOCATIONSERVER", DbType:="VarChar(100)")>  _
        Public Property LOCATIONSERVER() As  String 
            Get
                Return _LOCATIONSERVER
            End Get
            Set(ByVal value As  String )
               _LOCATIONSERVER = value
            End Set
        End Property 
        <Column(Storage:="_LOCATIONNO", DbType:="VarChar(100)")>  _
        Public Property LOCATIONNO() As  String 
            Get
                Return _LOCATIONNO
            End Get
            Set(ByVal value As  String )
               _LOCATIONNO = value
            End Set
        End Property 
        <Column(Storage:="_ONLINE_STATUS", DbType:="Char(1)")>  _
        Public Property ONLINE_STATUS() As  System.Nullable(Of Char) 
            Get
                Return _ONLINE_STATUS
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _ONLINE_STATUS = value
            End Set
        End Property 
        <Column(Storage:="_TODAY_ALAILABLE", DbType:="Int")>  _
        Public Property TODAY_ALAILABLE() As  System.Nullable(Of Long) 
            Get
                Return _TODAY_ALAILABLE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _TODAY_ALAILABLE = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATEDDATE = New DateTime(1,1,1)
            _CREATEDBY = ""
            _UPDATEDDATE = New DateTime(1,1,1)
            _UPDATEDBY = ""
            _SERVERIP = ""
            _SERVERNAME = ""
            _OS = ""
            _ACTIVE_STATUS = ""
            _E_MAIL = ""
            _FNAME = ""
            _LNAME = ""
            _SYSTEM_TYPE = ""
            _GROUP_ID = 0
            _MACADDRESS = ""
            _LOCATIONSERVER = ""
            _LOCATIONNO = ""
            _ONLINE_STATUS = ""
            _TODAY_ALAILABLE = 0
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


        '/// Returns an indication whether the current data is inserted into TB_REGISTER table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_REGISTER table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_REGISTER table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_REGISTER table successfully.
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


        '/// Returns an indication whether the record of TB_REGISTER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_REGISTER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbRegisterLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_REGISTER by specified SERVERIP key is retrieved successfully.
        '/// <param name=cSERVERIP>The SERVERIP key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySERVERIP(cSERVERIP As String, trans As SQLTransaction) As Boolean
            Return doChkData("SERVERIP = " & DB.SetString(cSERVERIP) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_REGISTER by specified SERVERIP key is retrieved successfully.
        '/// <param name=cSERVERIP>The SERVERIP key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySERVERIP(cSERVERIP As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SERVERIP = " & DB.SetString(cSERVERIP) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_REGISTER by specified SERVERNAME key is retrieved successfully.
        '/// <param name=cSERVERNAME>The SERVERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySERVERNAME(cSERVERNAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("SERVERNAME = " & DB.SetString(cSERVERNAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_REGISTER by specified SERVERNAME key is retrieved successfully.
        '/// <param name=cSERVERNAME>The SERVERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySERVERNAME(cSERVERNAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SERVERNAME = " & DB.SetString(cSERVERNAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_REGISTER by specified MACADDRESS key is retrieved successfully.
        '/// <param name=cMACADDRESS>The MACADDRESS key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMACADDRESS(cMACADDRESS As String, trans As SQLTransaction) As Boolean
            Return doChkData("MACADDRESS = " & DB.SetString(cMACADDRESS) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_REGISTER by specified MACADDRESS key is retrieved successfully.
        '/// <param name=cMACADDRESS>The MACADDRESS key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMACADDRESS(cMACADDRESS As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MACADDRESS = " & DB.SetString(cMACADDRESS) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_REGISTER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_REGISTER table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_REGISTER table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_REGISTER table successfully.
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


        '/// Returns an indication whether the record of TB_REGISTER by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ServerIP")) = False Then _ServerIP = Rdr("ServerIP").ToString()
                        If Convert.IsDBNull(Rdr("ServerName")) = False Then _ServerName = Rdr("ServerName").ToString()
                        If Convert.IsDBNull(Rdr("OS")) = False Then _OS = Rdr("OS").ToString()
                        If Convert.IsDBNull(Rdr("Active_Status")) = False Then _Active_Status = Rdr("Active_Status").ToString()
                        If Convert.IsDBNull(Rdr("E_mail")) = False Then _E_mail = Rdr("E_mail").ToString()
                        If Convert.IsDBNull(Rdr("Fname")) = False Then _Fname = Rdr("Fname").ToString()
                        If Convert.IsDBNull(Rdr("Lname")) = False Then _Lname = Rdr("Lname").ToString()
                        If Convert.IsDBNull(Rdr("System_Type")) = False Then _System_Type = Rdr("System_Type").ToString()
                        If Convert.IsDBNull(Rdr("group_id")) = False Then _group_id = Convert.ToInt64(Rdr("group_id"))
                        If Convert.IsDBNull(Rdr("MacAddress")) = False Then _MacAddress = Rdr("MacAddress").ToString()
                        If Convert.IsDBNull(Rdr("LocationServer")) = False Then _LocationServer = Rdr("LocationServer").ToString()
                        If Convert.IsDBNull(Rdr("LocationNo")) = False Then _LocationNo = Rdr("LocationNo").ToString()
                        If Convert.IsDBNull(Rdr("online_status")) = False Then _online_status = Rdr("online_status").ToString()
                        If Convert.IsDBNull(Rdr("today_alailable")) = False Then _today_alailable = Convert.ToInt32(Rdr("today_alailable"))
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


        '/// Returns an indication whether the record of TB_REGISTER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbRegisterLinqDB
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
                        If Convert.IsDBNull(Rdr("ServerIP")) = False Then _ServerIP = Rdr("ServerIP").ToString()
                        If Convert.IsDBNull(Rdr("ServerName")) = False Then _ServerName = Rdr("ServerName").ToString()
                        If Convert.IsDBNull(Rdr("OS")) = False Then _OS = Rdr("OS").ToString()
                        If Convert.IsDBNull(Rdr("Active_Status")) = False Then _Active_Status = Rdr("Active_Status").ToString()
                        If Convert.IsDBNull(Rdr("E_mail")) = False Then _E_mail = Rdr("E_mail").ToString()
                        If Convert.IsDBNull(Rdr("Fname")) = False Then _Fname = Rdr("Fname").ToString()
                        If Convert.IsDBNull(Rdr("Lname")) = False Then _Lname = Rdr("Lname").ToString()
                        If Convert.IsDBNull(Rdr("System_Type")) = False Then _System_Type = Rdr("System_Type").ToString()
                        If Convert.IsDBNull(Rdr("group_id")) = False Then _group_id = Convert.ToInt64(Rdr("group_id"))
                        If Convert.IsDBNull(Rdr("MacAddress")) = False Then _MacAddress = Rdr("MacAddress").ToString()
                        If Convert.IsDBNull(Rdr("LocationServer")) = False Then _LocationServer = Rdr("LocationServer").ToString()
                        If Convert.IsDBNull(Rdr("LocationNo")) = False Then _LocationNo = Rdr("LocationNo").ToString()
                        If Convert.IsDBNull(Rdr("online_status")) = False Then _online_status = Rdr("online_status").ToString()
                        If Convert.IsDBNull(Rdr("today_alailable")) = False Then _today_alailable = Convert.ToInt32(Rdr("today_alailable"))
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


        'Get Insert Statement for table TB_REGISTER
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATEDDATE, CREATEDBY, SERVERIP, SERVERNAME, OS, ACTIVE_STATUS, E_MAIL, FNAME, LNAME, SYSTEM_TYPE, GROUP_ID, MACADDRESS, LOCATIONSERVER, LOCATIONNO, ONLINE_STATUS, TODAY_ALAILABLE)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetDateTime(_CREATEDDATE) & ", "
                sql += DB.SetString(_CREATEDBY) & ", "
                sql += DB.SetString(_SERVERIP) & ", "
                sql += DB.SetString(_SERVERNAME) & ", "
                sql += DB.SetString(_OS) & ", "
                sql += DB.SetString(_ACTIVE_STATUS) & ", "
                sql += DB.SetString(_E_MAIL) & ", "
                sql += DB.SetString(_FNAME) & ", "
                sql += DB.SetString(_LNAME) & ", "
                sql += DB.SetString(_SYSTEM_TYPE) & ", "
                sql += DB.SetDouble(_GROUP_ID) & ", "
                sql += DB.SetString(_MACADDRESS) & ", "
                sql += DB.SetString(_LOCATIONSERVER) & ", "
                sql += DB.SetString(_LOCATIONNO) & ", "
                sql += DB.SetString(_ONLINE_STATUS) & ", "
                sql += DB.SetDouble(_TODAY_ALAILABLE)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_REGISTER
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATEDDATE = " & DB.SetDateTime(_UPDATEDDATE) & ", "
                Sql += "UPDATEDBY = " & DB.SetString(_UPDATEDBY) & ", "
                Sql += "SERVERIP = " & DB.SetString(_SERVERIP) & ", "
                Sql += "SERVERNAME = " & DB.SetString(_SERVERNAME) & ", "
                Sql += "OS = " & DB.SetString(_OS) & ", "
                Sql += "ACTIVE_STATUS = " & DB.SetString(_ACTIVE_STATUS) & ", "
                Sql += "E_MAIL = " & DB.SetString(_E_MAIL) & ", "
                Sql += "FNAME = " & DB.SetString(_FNAME) & ", "
                Sql += "LNAME = " & DB.SetString(_LNAME) & ", "
                Sql += "SYSTEM_TYPE = " & DB.SetString(_SYSTEM_TYPE) & ", "
                Sql += "GROUP_ID = " & DB.SetDouble(_GROUP_ID) & ", "
                Sql += "MACADDRESS = " & DB.SetString(_MACADDRESS) & ", "
                Sql += "LOCATIONSERVER = " & DB.SetString(_LOCATIONSERVER) & ", "
                Sql += "LOCATIONNO = " & DB.SetString(_LOCATIONNO) & ", "
                Sql += "ONLINE_STATUS = " & DB.SetString(_ONLINE_STATUS) & ", "
                Sql += "TODAY_ALAILABLE = " & DB.SetDouble(_TODAY_ALAILABLE) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_REGISTER
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_REGISTER
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATEDDATE, CREATEDBY, UPDATEDDATE, UPDATEDBY, SERVERIP, SERVERNAME, OS, ACTIVE_STATUS, E_MAIL, FNAME, LNAME, SYSTEM_TYPE, GROUP_ID, MACADDRESS, LOCATIONSERVER, LOCATIONNO, ONLINE_STATUS, TODAY_ALAILABLE FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace

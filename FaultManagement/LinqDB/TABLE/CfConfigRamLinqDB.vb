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
    'Represents a transaction for CF_CONFIG_RAM table LinqDB.
    '[Create by  on March, 2 2015]
    Public Class CfConfigRamLinqDB
        Public sub CfConfigRamLinqDB()

        End Sub 
        ' CF_CONFIG_RAM
        Const _tableName As String = "CF_CONFIG_RAM"
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
        Dim _SERVERIP As String = ""
        Dim _CHECKINTERVALMINUTE As Long = 0
        Dim _ALARMMINORVALUE As Long = 0
        Dim _ALARMMAJORVALUE As Long = 0
        Dim _ALARMCRITICALVALUE As Long = 0
        Dim _ACTIVESTATUS As Char = "Y"
        Dim _MACADDRESS As String = ""
        Dim _REPEATCHECKMINOR As Long = 0
        Dim _REPEATCHECKMAJOR As Long = 0
        Dim _REPEATCHECKCRITICAL As Long = 0
        Dim _ALARMSUN As Char = "Y"
        Dim _ALARMMON As Char = "Y"
        Dim _ALARMTUE As Char = "Y"
        Dim _ALARMWED As Char = "Y"
        Dim _ALARMTHU As Char = "Y"
        Dim _ALARMFRI As Char = "Y"
        Dim _ALARMSAT As Char = "Y"
        Dim _ALARMTIMEFROM As  String  = ""
        Dim _ALARMTIMETO As  String  = ""
        Dim _ALLDAYEVENT As Char = "Y"
        Dim _LASTCHECKTIME As DateTime = New DateTime(1,1,1)

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
        <Column(Storage:="_SERVERNAME", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVERNAME() As String
            Get
                Return _SERVERNAME
            End Get
            Set(ByVal value As String)
               _SERVERNAME = value
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
        <Column(Storage:="_CHECKINTERVALMINUTE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHECKINTERVALMINUTE() As Long
            Get
                Return _CHECKINTERVALMINUTE
            End Get
            Set(ByVal value As Long)
               _CHECKINTERVALMINUTE = value
            End Set
        End Property 
        <Column(Storage:="_ALARMMINORVALUE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property ALARMMINORVALUE() As Long
            Get
                Return _ALARMMINORVALUE
            End Get
            Set(ByVal value As Long)
               _ALARMMINORVALUE = value
            End Set
        End Property 
        <Column(Storage:="_ALARMMAJORVALUE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property ALARMMAJORVALUE() As Long
            Get
                Return _ALARMMAJORVALUE
            End Get
            Set(ByVal value As Long)
               _ALARMMAJORVALUE = value
            End Set
        End Property 
        <Column(Storage:="_ALARMCRITICALVALUE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property ALARMCRITICALVALUE() As Long
            Get
                Return _ALARMCRITICALVALUE
            End Get
            Set(ByVal value As Long)
               _ALARMCRITICALVALUE = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVESTATUS", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ACTIVESTATUS() As Char
            Get
                Return _ACTIVESTATUS
            End Get
            Set(ByVal value As Char)
               _ACTIVESTATUS = value
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
        <Column(Storage:="_REPEATCHECKMINOR", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property REPEATCHECKMINOR() As Long
            Get
                Return _REPEATCHECKMINOR
            End Get
            Set(ByVal value As Long)
               _REPEATCHECKMINOR = value
            End Set
        End Property 
        <Column(Storage:="_REPEATCHECKMAJOR", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property REPEATCHECKMAJOR() As Long
            Get
                Return _REPEATCHECKMAJOR
            End Get
            Set(ByVal value As Long)
               _REPEATCHECKMAJOR = value
            End Set
        End Property 
        <Column(Storage:="_REPEATCHECKCRITICAL", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property REPEATCHECKCRITICAL() As Long
            Get
                Return _REPEATCHECKCRITICAL
            End Get
            Set(ByVal value As Long)
               _REPEATCHECKCRITICAL = value
            End Set
        End Property 
        <Column(Storage:="_ALARMSUN", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ALARMSUN() As Char
            Get
                Return _ALARMSUN
            End Get
            Set(ByVal value As Char)
               _ALARMSUN = value
            End Set
        End Property 
        <Column(Storage:="_ALARMMON", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ALARMMON() As Char
            Get
                Return _ALARMMON
            End Get
            Set(ByVal value As Char)
               _ALARMMON = value
            End Set
        End Property 
        <Column(Storage:="_ALARMTUE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ALARMTUE() As Char
            Get
                Return _ALARMTUE
            End Get
            Set(ByVal value As Char)
               _ALARMTUE = value
            End Set
        End Property 
        <Column(Storage:="_ALARMWED", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ALARMWED() As Char
            Get
                Return _ALARMWED
            End Get
            Set(ByVal value As Char)
               _ALARMWED = value
            End Set
        End Property 
        <Column(Storage:="_ALARMTHU", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ALARMTHU() As Char
            Get
                Return _ALARMTHU
            End Get
            Set(ByVal value As Char)
               _ALARMTHU = value
            End Set
        End Property 
        <Column(Storage:="_ALARMFRI", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ALARMFRI() As Char
            Get
                Return _ALARMFRI
            End Get
            Set(ByVal value As Char)
               _ALARMFRI = value
            End Set
        End Property 
        <Column(Storage:="_ALARMSAT", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ALARMSAT() As Char
            Get
                Return _ALARMSAT
            End Get
            Set(ByVal value As Char)
               _ALARMSAT = value
            End Set
        End Property 
        <Column(Storage:="_ALARMTIMEFROM", DbType:="VarChar(5)")>  _
        Public Property ALARMTIMEFROM() As  String 
            Get
                Return _ALARMTIMEFROM
            End Get
            Set(ByVal value As  String )
               _ALARMTIMEFROM = value
            End Set
        End Property 
        <Column(Storage:="_ALARMTIMETO", DbType:="VarChar(5)")>  _
        Public Property ALARMTIMETO() As  String 
            Get
                Return _ALARMTIMETO
            End Get
            Set(ByVal value As  String )
               _ALARMTIMETO = value
            End Set
        End Property 
        <Column(Storage:="_ALLDAYEVENT", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ALLDAYEVENT() As Char
            Get
                Return _ALLDAYEVENT
            End Get
            Set(ByVal value As Char)
               _ALLDAYEVENT = value
            End Set
        End Property 
        <Column(Storage:="_LASTCHECKTIME", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property LASTCHECKTIME() As DateTime
            Get
                Return _LASTCHECKTIME
            End Get
            Set(ByVal value As DateTime)
               _LASTCHECKTIME = value
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
            _SERVERIP = ""
            _CHECKINTERVALMINUTE = 0
            _ALARMMINORVALUE = 0
            _ALARMMAJORVALUE = 0
            _ALARMCRITICALVALUE = 0
            _ACTIVESTATUS = ""
            _MACADDRESS = ""
            _REPEATCHECKMINOR = 0
            _REPEATCHECKMAJOR = 0
            _REPEATCHECKCRITICAL = 0
            _ALARMSUN = ""
            _ALARMMON = ""
            _ALARMTUE = ""
            _ALARMWED = ""
            _ALARMTHU = ""
            _ALARMFRI = ""
            _ALARMSAT = ""
            _ALARMTIMEFROM = ""
            _ALARMTIMETO = ""
            _ALLDAYEVENT = ""
            _LASTCHECKTIME = New DateTime(1,1,1)
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


        '/// Returns an indication whether the current data is inserted into CF_CONFIG_RAM table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_CONFIG_RAM table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_CONFIG_RAM table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from CF_CONFIG_RAM table successfully.
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


        '/// Returns an indication whether the record of CF_CONFIG_RAM by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of CF_CONFIG_RAM by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As CfConfigRamLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of CF_CONFIG_RAM by specified SERVERIP key is retrieved successfully.
        '/// <param name=cSERVERIP>The SERVERIP key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySERVERIP(cSERVERIP As String, trans As SQLTransaction) As Boolean
            Return doChkData("SERVERIP = " & DB.SetString(cSERVERIP) & " ", trans)
        End Function

        '/// Returns an duplicate data record of CF_CONFIG_RAM by specified SERVERIP key is retrieved successfully.
        '/// <param name=cSERVERIP>The SERVERIP key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySERVERIP(cSERVERIP As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SERVERIP = " & DB.SetString(cSERVERIP) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of CF_CONFIG_RAM by specified SERVERNAME key is retrieved successfully.
        '/// <param name=cSERVERNAME>The SERVERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySERVERNAME(cSERVERNAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("SERVERNAME = " & DB.SetString(cSERVERNAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of CF_CONFIG_RAM by specified SERVERNAME key is retrieved successfully.
        '/// <param name=cSERVERNAME>The SERVERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySERVERNAME(cSERVERNAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SERVERNAME = " & DB.SetString(cSERVERNAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of CF_CONFIG_RAM by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into CF_CONFIG_RAM table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_CONFIG_RAM table successfully.
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


        '/// Returns an indication whether the current data is deleted from CF_CONFIG_RAM table successfully.
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


        '/// Returns an indication whether the record of CF_CONFIG_RAM by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ServerIP")) = False Then _ServerIP = Rdr("ServerIP").ToString()
                        If Convert.IsDBNull(Rdr("CheckIntervalMinute")) = False Then _CheckIntervalMinute = Convert.ToInt32(Rdr("CheckIntervalMinute"))
                        If Convert.IsDBNull(Rdr("AlarmMinorValue")) = False Then _AlarmMinorValue = Convert.ToInt32(Rdr("AlarmMinorValue"))
                        If Convert.IsDBNull(Rdr("AlarmMajorValue")) = False Then _AlarmMajorValue = Convert.ToInt32(Rdr("AlarmMajorValue"))
                        If Convert.IsDBNull(Rdr("AlarmCriticalValue")) = False Then _AlarmCriticalValue = Convert.ToInt32(Rdr("AlarmCriticalValue"))
                        If Convert.IsDBNull(Rdr("ActiveStatus")) = False Then _ActiveStatus = Rdr("ActiveStatus").ToString()
                        If Convert.IsDBNull(Rdr("MacAddress")) = False Then _MacAddress = Rdr("MacAddress").ToString()
                        If Convert.IsDBNull(Rdr("RepeatCheckMinor")) = False Then _RepeatCheckMinor = Convert.ToInt32(Rdr("RepeatCheckMinor"))
                        If Convert.IsDBNull(Rdr("RepeatCheckMajor")) = False Then _RepeatCheckMajor = Convert.ToInt32(Rdr("RepeatCheckMajor"))
                        If Convert.IsDBNull(Rdr("RepeatCheckCritical")) = False Then _RepeatCheckCritical = Convert.ToInt32(Rdr("RepeatCheckCritical"))
                        If Convert.IsDBNull(Rdr("AlarmSun")) = False Then _AlarmSun = Rdr("AlarmSun").ToString()
                        If Convert.IsDBNull(Rdr("AlarmMon")) = False Then _AlarmMon = Rdr("AlarmMon").ToString()
                        If Convert.IsDBNull(Rdr("AlarmTue")) = False Then _AlarmTue = Rdr("AlarmTue").ToString()
                        If Convert.IsDBNull(Rdr("AlarmWed")) = False Then _AlarmWed = Rdr("AlarmWed").ToString()
                        If Convert.IsDBNull(Rdr("AlarmThu")) = False Then _AlarmThu = Rdr("AlarmThu").ToString()
                        If Convert.IsDBNull(Rdr("AlarmFri")) = False Then _AlarmFri = Rdr("AlarmFri").ToString()
                        If Convert.IsDBNull(Rdr("AlarmSat")) = False Then _AlarmSat = Rdr("AlarmSat").ToString()
                        If Convert.IsDBNull(Rdr("AlarmTimeFrom")) = False Then _AlarmTimeFrom = Rdr("AlarmTimeFrom").ToString()
                        If Convert.IsDBNull(Rdr("AlarmTimeTo")) = False Then _AlarmTimeTo = Rdr("AlarmTimeTo").ToString()
                        If Convert.IsDBNull(Rdr("AllDayEvent")) = False Then _AllDayEvent = Rdr("AllDayEvent").ToString()
                        If Convert.IsDBNull(Rdr("LastCheckTime")) = False Then _LastCheckTime = Convert.ToDateTime(Rdr("LastCheckTime"))
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


        '/// Returns an indication whether the record of CF_CONFIG_RAM by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As CfConfigRamLinqDB
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
                        If Convert.IsDBNull(Rdr("ServerIP")) = False Then _ServerIP = Rdr("ServerIP").ToString()
                        If Convert.IsDBNull(Rdr("CheckIntervalMinute")) = False Then _CheckIntervalMinute = Convert.ToInt32(Rdr("CheckIntervalMinute"))
                        If Convert.IsDBNull(Rdr("AlarmMinorValue")) = False Then _AlarmMinorValue = Convert.ToInt32(Rdr("AlarmMinorValue"))
                        If Convert.IsDBNull(Rdr("AlarmMajorValue")) = False Then _AlarmMajorValue = Convert.ToInt32(Rdr("AlarmMajorValue"))
                        If Convert.IsDBNull(Rdr("AlarmCriticalValue")) = False Then _AlarmCriticalValue = Convert.ToInt32(Rdr("AlarmCriticalValue"))
                        If Convert.IsDBNull(Rdr("ActiveStatus")) = False Then _ActiveStatus = Rdr("ActiveStatus").ToString()
                        If Convert.IsDBNull(Rdr("MacAddress")) = False Then _MacAddress = Rdr("MacAddress").ToString()
                        If Convert.IsDBNull(Rdr("RepeatCheckMinor")) = False Then _RepeatCheckMinor = Convert.ToInt32(Rdr("RepeatCheckMinor"))
                        If Convert.IsDBNull(Rdr("RepeatCheckMajor")) = False Then _RepeatCheckMajor = Convert.ToInt32(Rdr("RepeatCheckMajor"))
                        If Convert.IsDBNull(Rdr("RepeatCheckCritical")) = False Then _RepeatCheckCritical = Convert.ToInt32(Rdr("RepeatCheckCritical"))
                        If Convert.IsDBNull(Rdr("AlarmSun")) = False Then _AlarmSun = Rdr("AlarmSun").ToString()
                        If Convert.IsDBNull(Rdr("AlarmMon")) = False Then _AlarmMon = Rdr("AlarmMon").ToString()
                        If Convert.IsDBNull(Rdr("AlarmTue")) = False Then _AlarmTue = Rdr("AlarmTue").ToString()
                        If Convert.IsDBNull(Rdr("AlarmWed")) = False Then _AlarmWed = Rdr("AlarmWed").ToString()
                        If Convert.IsDBNull(Rdr("AlarmThu")) = False Then _AlarmThu = Rdr("AlarmThu").ToString()
                        If Convert.IsDBNull(Rdr("AlarmFri")) = False Then _AlarmFri = Rdr("AlarmFri").ToString()
                        If Convert.IsDBNull(Rdr("AlarmSat")) = False Then _AlarmSat = Rdr("AlarmSat").ToString()
                        If Convert.IsDBNull(Rdr("AlarmTimeFrom")) = False Then _AlarmTimeFrom = Rdr("AlarmTimeFrom").ToString()
                        If Convert.IsDBNull(Rdr("AlarmTimeTo")) = False Then _AlarmTimeTo = Rdr("AlarmTimeTo").ToString()
                        If Convert.IsDBNull(Rdr("AllDayEvent")) = False Then _AllDayEvent = Rdr("AllDayEvent").ToString()
                        If Convert.IsDBNull(Rdr("LastCheckTime")) = False Then _LastCheckTime = Convert.ToDateTime(Rdr("LastCheckTime"))
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


        'Get Insert Statement for table CF_CONFIG_RAM
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATEDDATE, CREATEDBY, SERVERNAME, SERVERIP, CHECKINTERVALMINUTE, ALARMMINORVALUE, ALARMMAJORVALUE, ALARMCRITICALVALUE, ACTIVESTATUS, MACADDRESS, REPEATCHECKMINOR, REPEATCHECKMAJOR, REPEATCHECKCRITICAL, ALARMSUN, ALARMMON, ALARMTUE, ALARMWED, ALARMTHU, ALARMFRI, ALARMSAT, ALARMTIMEFROM, ALARMTIMETO, ALLDAYEVENT, LASTCHECKTIME)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetDateTime(_CREATEDDATE) & ", "
                sql += DB.SetString(_CREATEDBY) & ", "
                sql += DB.SetString(_SERVERNAME) & ", "
                sql += DB.SetString(_SERVERIP) & ", "
                sql += DB.SetDouble(_CHECKINTERVALMINUTE) & ", "
                sql += DB.SetDouble(_ALARMMINORVALUE) & ", "
                sql += DB.SetDouble(_ALARMMAJORVALUE) & ", "
                sql += DB.SetDouble(_ALARMCRITICALVALUE) & ", "
                sql += DB.SetString(_ACTIVESTATUS) & ", "
                sql += DB.SetString(_MACADDRESS) & ", "
                sql += DB.SetDouble(_REPEATCHECKMINOR) & ", "
                sql += DB.SetDouble(_REPEATCHECKMAJOR) & ", "
                sql += DB.SetDouble(_REPEATCHECKCRITICAL) & ", "
                sql += DB.SetString(_ALARMSUN) & ", "
                sql += DB.SetString(_ALARMMON) & ", "
                sql += DB.SetString(_ALARMTUE) & ", "
                sql += DB.SetString(_ALARMWED) & ", "
                sql += DB.SetString(_ALARMTHU) & ", "
                sql += DB.SetString(_ALARMFRI) & ", "
                sql += DB.SetString(_ALARMSAT) & ", "
                sql += DB.SetString(_ALARMTIMEFROM) & ", "
                sql += DB.SetString(_ALARMTIMETO) & ", "
                sql += DB.SetString(_ALLDAYEVENT) & ", "
                sql += DB.SetDateTime(_LASTCHECKTIME)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table CF_CONFIG_RAM
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATEDDATE = " & DB.SetDateTime(_UPDATEDDATE) & ", "
                Sql += "UPDATEDBY = " & DB.SetString(_UPDATEDBY) & ", "
                Sql += "SERVERNAME = " & DB.SetString(_SERVERNAME) & ", "
                Sql += "SERVERIP = " & DB.SetString(_SERVERIP) & ", "
                Sql += "CHECKINTERVALMINUTE = " & DB.SetDouble(_CHECKINTERVALMINUTE) & ", "
                Sql += "ALARMMINORVALUE = " & DB.SetDouble(_ALARMMINORVALUE) & ", "
                Sql += "ALARMMAJORVALUE = " & DB.SetDouble(_ALARMMAJORVALUE) & ", "
                Sql += "ALARMCRITICALVALUE = " & DB.SetDouble(_ALARMCRITICALVALUE) & ", "
                Sql += "ACTIVESTATUS = " & DB.SetString(_ACTIVESTATUS) & ", "
                Sql += "MACADDRESS = " & DB.SetString(_MACADDRESS) & ", "
                Sql += "REPEATCHECKMINOR = " & DB.SetDouble(_REPEATCHECKMINOR) & ", "
                Sql += "REPEATCHECKMAJOR = " & DB.SetDouble(_REPEATCHECKMAJOR) & ", "
                Sql += "REPEATCHECKCRITICAL = " & DB.SetDouble(_REPEATCHECKCRITICAL) & ", "
                Sql += "ALARMSUN = " & DB.SetString(_ALARMSUN) & ", "
                Sql += "ALARMMON = " & DB.SetString(_ALARMMON) & ", "
                Sql += "ALARMTUE = " & DB.SetString(_ALARMTUE) & ", "
                Sql += "ALARMWED = " & DB.SetString(_ALARMWED) & ", "
                Sql += "ALARMTHU = " & DB.SetString(_ALARMTHU) & ", "
                Sql += "ALARMFRI = " & DB.SetString(_ALARMFRI) & ", "
                Sql += "ALARMSAT = " & DB.SetString(_ALARMSAT) & ", "
                Sql += "ALARMTIMEFROM = " & DB.SetString(_ALARMTIMEFROM) & ", "
                Sql += "ALARMTIMETO = " & DB.SetString(_ALARMTIMETO) & ", "
                Sql += "ALLDAYEVENT = " & DB.SetString(_ALLDAYEVENT) & ", "
                Sql += "LASTCHECKTIME = " & DB.SetDateTime(_LASTCHECKTIME) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table CF_CONFIG_RAM
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table CF_CONFIG_RAM
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATEDDATE, CREATEDBY, UPDATEDDATE, UPDATEDBY, SERVERNAME, SERVERIP, CHECKINTERVALMINUTE, ALARMMINORVALUE, ALARMMAJORVALUE, ALARMCRITICALVALUE, ACTIVESTATUS, MACADDRESS, REPEATCHECKMINOR, REPEATCHECKMAJOR, REPEATCHECKCRITICAL, ALARMSUN, ALARMMON, ALARMTUE, ALARMWED, ALARMTHU, ALARMFRI, ALARMSAT, ALARMTIMEFROM, ALARMTIMETO, ALLDAYEVENT, LASTCHECKTIME FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace

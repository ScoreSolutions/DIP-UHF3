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
    'Represents a transaction for MS_SIGNAGE_SCHEDULE_WEEKLY table LinqDB.
    '[Create by  on March, 23 2015]
    Public Class MsSignageScheduleWeeklyLinqDB
        Public sub MsSignageScheduleWeeklyLinqDB()

        End Sub 
        ' MS_SIGNAGE_SCHEDULE_WEEKLY
        Const _tableName As String = "MS_SIGNAGE_SCHEDULE_WEEKLY"
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
        Dim _MS_SIGNAGE_TEMPLATE_SCHEDULE_ID As Long = 0
        Dim _RECUR_EVERY_WEEK As Long = 0
        Dim _SCH_SUN As Char = "Y"
        Dim _SCH_MON As Char = "Y"
        Dim _SCH_TUE As Char = "Y"
        Dim _SCH_WED As Char = "Y"
        Dim _SCH_THU As Char = "Y"
        Dim _SCH_FRI As Char = "Y"
        Dim _SCH_SAT As Char = "Y"

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
        <Column(Storage:="_MS_SIGNAGE_TEMPLATE_SCHEDULE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_SIGNAGE_TEMPLATE_SCHEDULE_ID() As Long
            Get
                Return _MS_SIGNAGE_TEMPLATE_SCHEDULE_ID
            End Get
            Set(ByVal value As Long)
               _MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = value
            End Set
        End Property 
        <Column(Storage:="_RECUR_EVERY_WEEK", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property RECUR_EVERY_WEEK() As Long
            Get
                Return _RECUR_EVERY_WEEK
            End Get
            Set(ByVal value As Long)
               _RECUR_EVERY_WEEK = value
            End Set
        End Property 
        <Column(Storage:="_SCH_SUN", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property SCH_SUN() As Char
            Get
                Return _SCH_SUN
            End Get
            Set(ByVal value As Char)
               _SCH_SUN = value
            End Set
        End Property 
        <Column(Storage:="_SCH_MON", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property SCH_MON() As Char
            Get
                Return _SCH_MON
            End Get
            Set(ByVal value As Char)
               _SCH_MON = value
            End Set
        End Property 
        <Column(Storage:="_SCH_TUE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property SCH_TUE() As Char
            Get
                Return _SCH_TUE
            End Get
            Set(ByVal value As Char)
               _SCH_TUE = value
            End Set
        End Property 
        <Column(Storage:="_SCH_WED", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property SCH_WED() As Char
            Get
                Return _SCH_WED
            End Get
            Set(ByVal value As Char)
               _SCH_WED = value
            End Set
        End Property 
        <Column(Storage:="_SCH_THU", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property SCH_THU() As Char
            Get
                Return _SCH_THU
            End Get
            Set(ByVal value As Char)
               _SCH_THU = value
            End Set
        End Property 
        <Column(Storage:="_SCH_FRI", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property SCH_FRI() As Char
            Get
                Return _SCH_FRI
            End Get
            Set(ByVal value As Char)
               _SCH_FRI = value
            End Set
        End Property 
        <Column(Storage:="_SCH_SAT", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property SCH_SAT() As Char
            Get
                Return _SCH_SAT
            End Get
            Set(ByVal value As Char)
               _SCH_SAT = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = 0
            _RECUR_EVERY_WEEK = 0
            _SCH_SUN = "Y"
            _SCH_MON = "Y"
            _SCH_TUE = "Y"
            _SCH_WED = "Y"
            _SCH_THU = "Y"
            _SCH_FRI = "Y"
            _SCH_SAT = "Y"
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


        '/// Returns an indication whether the current data is inserted into MS_SIGNAGE_SCHEDULE_WEEKLY table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_SIGNAGE_SCHEDULE_WEEKLY table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_SIGNAGE_SCHEDULE_WEEKLY table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from MS_SIGNAGE_SCHEDULE_WEEKLY table successfully.
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


        '/// Returns an indication whether the record of MS_SIGNAGE_SCHEDULE_WEEKLY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_SIGNAGE_SCHEDULE_WEEKLY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsSignageScheduleWeeklyLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of MS_SIGNAGE_SCHEDULE_WEEKLY by specified MS_SIGNAGE_TEMPLATE_SCHEDULE_ID key is retrieved successfully.
        '/// <param name=cMS_SIGNAGE_TEMPLATE_SCHEDULE_ID>The MS_SIGNAGE_TEMPLATE_SCHEDULE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_SIGNAGE_TEMPLATE_SCHEDULE_ID(cMS_SIGNAGE_TEMPLATE_SCHEDULE_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = " & DB.SetDouble(cMS_SIGNAGE_TEMPLATE_SCHEDULE_ID) & " ", trans)
        End Function

        '/// Returns an duplicate data record of MS_SIGNAGE_SCHEDULE_WEEKLY by specified MS_SIGNAGE_TEMPLATE_SCHEDULE_ID key is retrieved successfully.
        '/// <param name=cMS_SIGNAGE_TEMPLATE_SCHEDULE_ID>The MS_SIGNAGE_TEMPLATE_SCHEDULE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_SIGNAGE_TEMPLATE_SCHEDULE_ID(cMS_SIGNAGE_TEMPLATE_SCHEDULE_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = " & DB.SetDouble(cMS_SIGNAGE_TEMPLATE_SCHEDULE_ID) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_SIGNAGE_SCHEDULE_WEEKLY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_SIGNAGE_SCHEDULE_WEEKLY table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_SIGNAGE_SCHEDULE_WEEKLY table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_SIGNAGE_SCHEDULE_WEEKLY table successfully.
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

            cmbParam(5) = New SqlParameter("@_MS_SIGNAGE_TEMPLATE_SCHEDULE_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _MS_SIGNAGE_TEMPLATE_SCHEDULE_ID

            cmbParam(6) = New SqlParameter("@_RECUR_EVERY_WEEK", SqlDbType.Int)
            cmbParam(6).Value = _RECUR_EVERY_WEEK

            cmbParam(7) = New SqlParameter("@_SCH_SUN", SqlDbType.Char)
            cmbParam(7).Value = _SCH_SUN

            cmbParam(8) = New SqlParameter("@_SCH_MON", SqlDbType.Char)
            cmbParam(8).Value = _SCH_MON

            cmbParam(9) = New SqlParameter("@_SCH_TUE", SqlDbType.Char)
            cmbParam(9).Value = _SCH_TUE

            cmbParam(10) = New SqlParameter("@_SCH_WED", SqlDbType.Char)
            cmbParam(10).Value = _SCH_WED

            cmbParam(11) = New SqlParameter("@_SCH_THU", SqlDbType.Char)
            cmbParam(11).Value = _SCH_THU

            cmbParam(12) = New SqlParameter("@_SCH_FRI", SqlDbType.Char)
            cmbParam(12).Value = _SCH_FRI

            cmbParam(13) = New SqlParameter("@_SCH_SAT", SqlDbType.Char)
            cmbParam(13).Value = _SCH_SAT

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_SIGNAGE_SCHEDULE_WEEKLY by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ms_signage_template_schedule_id")) = False Then _ms_signage_template_schedule_id = Convert.ToInt64(Rdr("ms_signage_template_schedule_id"))
                        If Convert.IsDBNull(Rdr("recur_every_week")) = False Then _recur_every_week = Convert.ToInt32(Rdr("recur_every_week"))
                        If Convert.IsDBNull(Rdr("sch_sun")) = False Then _sch_sun = Rdr("sch_sun").ToString()
                        If Convert.IsDBNull(Rdr("sch_mon")) = False Then _sch_mon = Rdr("sch_mon").ToString()
                        If Convert.IsDBNull(Rdr("sch_tue")) = False Then _sch_tue = Rdr("sch_tue").ToString()
                        If Convert.IsDBNull(Rdr("sch_wed")) = False Then _sch_wed = Rdr("sch_wed").ToString()
                        If Convert.IsDBNull(Rdr("sch_thu")) = False Then _sch_thu = Rdr("sch_thu").ToString()
                        If Convert.IsDBNull(Rdr("sch_fri")) = False Then _sch_fri = Rdr("sch_fri").ToString()
                        If Convert.IsDBNull(Rdr("sch_sat")) = False Then _sch_sat = Rdr("sch_sat").ToString()
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


        '/// Returns an indication whether the record of MS_SIGNAGE_SCHEDULE_WEEKLY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As MsSignageScheduleWeeklyLinqDB
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
                        If Convert.IsDBNull(Rdr("ms_signage_template_schedule_id")) = False Then _ms_signage_template_schedule_id = Convert.ToInt64(Rdr("ms_signage_template_schedule_id"))
                        If Convert.IsDBNull(Rdr("recur_every_week")) = False Then _recur_every_week = Convert.ToInt32(Rdr("recur_every_week"))
                        If Convert.IsDBNull(Rdr("sch_sun")) = False Then _sch_sun = Rdr("sch_sun").ToString()
                        If Convert.IsDBNull(Rdr("sch_mon")) = False Then _sch_mon = Rdr("sch_mon").ToString()
                        If Convert.IsDBNull(Rdr("sch_tue")) = False Then _sch_tue = Rdr("sch_tue").ToString()
                        If Convert.IsDBNull(Rdr("sch_wed")) = False Then _sch_wed = Rdr("sch_wed").ToString()
                        If Convert.IsDBNull(Rdr("sch_thu")) = False Then _sch_thu = Rdr("sch_thu").ToString()
                        If Convert.IsDBNull(Rdr("sch_fri")) = False Then _sch_fri = Rdr("sch_fri").ToString()
                        If Convert.IsDBNull(Rdr("sch_sat")) = False Then _sch_sat = Rdr("sch_sat").ToString()
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


        'Get Insert Statement for table MS_SIGNAGE_SCHEDULE_WEEKLY
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_SIGNAGE_TEMPLATE_SCHEDULE_ID, RECUR_EVERY_WEEK, SCH_SUN, SCH_MON, SCH_TUE, SCH_WED, SCH_THU, SCH_FRI, SCH_SAT)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MS_SIGNAGE_TEMPLATE_SCHEDULE_ID, INSERTED.RECUR_EVERY_WEEK, INSERTED.SCH_SUN, INSERTED.SCH_MON, INSERTED.SCH_TUE, INSERTED.SCH_WED, INSERTED.SCH_THU, INSERTED.SCH_FRI, INSERTED.SCH_SAT
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_MS_SIGNAGE_TEMPLATE_SCHEDULE_ID" & ", "
                sql += "@_RECUR_EVERY_WEEK" & ", "
                sql += "@_SCH_SUN" & ", "
                sql += "@_SCH_MON" & ", "
                sql += "@_SCH_TUE" & ", "
                sql += "@_SCH_WED" & ", "
                sql += "@_SCH_THU" & ", "
                sql += "@_SCH_FRI" & ", "
                sql += "@_SCH_SAT"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_SIGNAGE_SCHEDULE_WEEKLY
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = " & "@_MS_SIGNAGE_TEMPLATE_SCHEDULE_ID" & ", "
                Sql += "RECUR_EVERY_WEEK = " & "@_RECUR_EVERY_WEEK" & ", "
                Sql += "SCH_SUN = " & "@_SCH_SUN" & ", "
                Sql += "SCH_MON = " & "@_SCH_MON" & ", "
                Sql += "SCH_TUE = " & "@_SCH_TUE" & ", "
                Sql += "SCH_WED = " & "@_SCH_WED" & ", "
                Sql += "SCH_THU = " & "@_SCH_THU" & ", "
                Sql += "SCH_FRI = " & "@_SCH_FRI" & ", "
                Sql += "SCH_SAT = " & "@_SCH_SAT" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_SIGNAGE_SCHEDULE_WEEKLY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_SIGNAGE_SCHEDULE_WEEKLY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_SIGNAGE_TEMPLATE_SCHEDULE_ID, RECUR_EVERY_WEEK, SCH_SUN, SCH_MON, SCH_TUE, SCH_WED, SCH_THU, SCH_FRI, SCH_SAT FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

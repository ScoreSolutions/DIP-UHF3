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
    'Represents a transaction for TS_SIGNAGE_FILE_GROWTH_MONTH table LinqDB.
    '[Create by  on July, 2 2015]
    Public Class TsSignageFileGrowthMonthLinqDB
        Public sub TsSignageFileGrowthMonthLinqDB()

        End Sub 
        ' TS_SIGNAGE_FILE_GROWTH_MONTH
        Const _tableName As String = "TS_SIGNAGE_FILE_GROWTH_MONTH"
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
        Dim _TB_PATENT_TYPE_ID As Long = 0
        Dim _SERIE_NAME As String = ""
        Dim _SHOW_YEAR As String = ""
        Dim _SHOW_MONTH As String = ""
        Dim _FILE_QTY As Long = 0
        Dim _GROWTH_RATIO As Double = 0

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
        <Column(Storage:="_TB_PATENT_TYPE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property TB_PATENT_TYPE_ID() As Long
            Get
                Return _TB_PATENT_TYPE_ID
            End Get
            Set(ByVal value As Long)
               _TB_PATENT_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_SERIE_NAME", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERIE_NAME() As String
            Get
                Return _SERIE_NAME
            End Get
            Set(ByVal value As String)
               _SERIE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SHOW_YEAR", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SHOW_YEAR() As String
            Get
                Return _SHOW_YEAR
            End Get
            Set(ByVal value As String)
               _SHOW_YEAR = value
            End Set
        End Property 
        <Column(Storage:="_SHOW_MONTH", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SHOW_MONTH() As String
            Get
                Return _SHOW_MONTH
            End Get
            Set(ByVal value As String)
               _SHOW_MONTH = value
            End Set
        End Property 
        <Column(Storage:="_FILE_QTY", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property FILE_QTY() As Long
            Get
                Return _FILE_QTY
            End Get
            Set(ByVal value As Long)
               _FILE_QTY = value
            End Set
        End Property 
        <Column(Storage:="_GROWTH_RATIO", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property GROWTH_RATIO() As Double
            Get
                Return _GROWTH_RATIO
            End Get
            Set(ByVal value As Double)
               _GROWTH_RATIO = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _TB_PATENT_TYPE_ID = 0
            _SERIE_NAME = ""
            _SHOW_YEAR = ""
            _SHOW_MONTH = ""
            _FILE_QTY = 0
            _GROWTH_RATIO = 0
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


        '/// Returns an indication whether the current data is inserted into TS_SIGNAGE_FILE_GROWTH_MONTH table successfully.
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


        '/// Returns an indication whether the current data is updated to TS_SIGNAGE_FILE_GROWTH_MONTH table successfully.
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


        '/// Returns an indication whether the current data is updated to TS_SIGNAGE_FILE_GROWTH_MONTH table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TS_SIGNAGE_FILE_GROWTH_MONTH table successfully.
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


        '/// Returns an indication whether the record of TS_SIGNAGE_FILE_GROWTH_MONTH by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TS_SIGNAGE_FILE_GROWTH_MONTH by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TsSignageFileGrowthMonthLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TS_SIGNAGE_FILE_GROWTH_MONTH by specified SHOW_MONTH_SHOW_YEAR_TB_PATENT_TYPE_ID key is retrieved successfully.
        '/// <param name=cSHOW_MONTH_SHOW_YEAR_TB_PATENT_TYPE_ID>The SHOW_MONTH_SHOW_YEAR_TB_PATENT_TYPE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySHOW_MONTH_SHOW_YEAR_TB_PATENT_TYPE_ID(cSHOW_MONTH As String, cSHOW_YEAR As String, cTB_PATENT_TYPE_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SHOW_MONTH = " & DB.SetString(cSHOW_MONTH) & " AND SHOW_YEAR = " & DB.SetString(cSHOW_YEAR) & " AND TB_PATENT_TYPE_ID = " & DB.SetDouble(cTB_PATENT_TYPE_ID), trans)
        End Function

        '/// Returns an duplicate data record of TS_SIGNAGE_FILE_GROWTH_MONTH by specified SHOW_MONTH_SHOW_YEAR_TB_PATENT_TYPE_ID key is retrieved successfully.
        '/// <param name=cSHOW_MONTH_SHOW_YEAR_TB_PATENT_TYPE_ID>The SHOW_MONTH_SHOW_YEAR_TB_PATENT_TYPE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySHOW_MONTH_SHOW_YEAR_TB_PATENT_TYPE_ID(cSHOW_MONTH As String, cSHOW_YEAR As String, cTB_PATENT_TYPE_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SHOW_MONTH = " & DB.SetString(cSHOW_MONTH) & " AND SHOW_YEAR = " & DB.SetString(cSHOW_YEAR) & " AND TB_PATENT_TYPE_ID = " & DB.SetDouble(cTB_PATENT_TYPE_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_SIGNAGE_FILE_GROWTH_MONTH by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TS_SIGNAGE_FILE_GROWTH_MONTH table successfully.
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


        '/// Returns an indication whether the current data is updated to TS_SIGNAGE_FILE_GROWTH_MONTH table successfully.
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


        '/// Returns an indication whether the current data is deleted from TS_SIGNAGE_FILE_GROWTH_MONTH table successfully.
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
            Dim cmbParam(10) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_TB_PATENT_TYPE_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _TB_PATENT_TYPE_ID

            cmbParam(6) = New SqlParameter("@_SERIE_NAME", SqlDbType.VarChar)
            cmbParam(6).Value = _SERIE_NAME

            cmbParam(7) = New SqlParameter("@_SHOW_YEAR", SqlDbType.VarChar)
            cmbParam(7).Value = _SHOW_YEAR

            cmbParam(8) = New SqlParameter("@_SHOW_MONTH", SqlDbType.VarChar)
            cmbParam(8).Value = _SHOW_MONTH

            cmbParam(9) = New SqlParameter("@_FILE_QTY", SqlDbType.BigInt)
            cmbParam(9).Value = _FILE_QTY

            cmbParam(10) = New SqlParameter("@_GROWTH_RATIO", SqlDbType.Float)
            cmbParam(10).Value = _GROWTH_RATIO

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TS_SIGNAGE_FILE_GROWTH_MONTH by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("tb_patent_type_id")) = False Then _tb_patent_type_id = Convert.ToInt64(Rdr("tb_patent_type_id"))
                        If Convert.IsDBNull(Rdr("serie_name")) = False Then _serie_name = Rdr("serie_name").ToString()
                        If Convert.IsDBNull(Rdr("show_year")) = False Then _show_year = Rdr("show_year").ToString()
                        If Convert.IsDBNull(Rdr("show_month")) = False Then _show_month = Rdr("show_month").ToString()
                        If Convert.IsDBNull(Rdr("file_qty")) = False Then _file_qty = Convert.ToInt64(Rdr("file_qty"))
                        If Convert.IsDBNull(Rdr("growth_ratio")) = False Then _growth_ratio = Convert.ToDouble(Rdr("growth_ratio"))
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


        '/// Returns an indication whether the record of TS_SIGNAGE_FILE_GROWTH_MONTH by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TsSignageFileGrowthMonthLinqDB
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
                        If Convert.IsDBNull(Rdr("tb_patent_type_id")) = False Then _tb_patent_type_id = Convert.ToInt64(Rdr("tb_patent_type_id"))
                        If Convert.IsDBNull(Rdr("serie_name")) = False Then _serie_name = Rdr("serie_name").ToString()
                        If Convert.IsDBNull(Rdr("show_year")) = False Then _show_year = Rdr("show_year").ToString()
                        If Convert.IsDBNull(Rdr("show_month")) = False Then _show_month = Rdr("show_month").ToString()
                        If Convert.IsDBNull(Rdr("file_qty")) = False Then _file_qty = Convert.ToInt64(Rdr("file_qty"))
                        If Convert.IsDBNull(Rdr("growth_ratio")) = False Then _growth_ratio = Convert.ToDouble(Rdr("growth_ratio"))
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


        'Get Insert Statement for table TS_SIGNAGE_FILE_GROWTH_MONTH
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, TB_PATENT_TYPE_ID, SERIE_NAME, SHOW_YEAR, SHOW_MONTH, FILE_QTY, GROWTH_RATIO)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.TB_PATENT_TYPE_ID, INSERTED.SERIE_NAME, INSERTED.SHOW_YEAR, INSERTED.SHOW_MONTH, INSERTED.FILE_QTY, INSERTED.GROWTH_RATIO
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_TB_PATENT_TYPE_ID" & ", "
                sql += "@_SERIE_NAME" & ", "
                sql += "@_SHOW_YEAR" & ", "
                sql += "@_SHOW_MONTH" & ", "
                sql += "@_FILE_QTY" & ", "
                sql += "@_GROWTH_RATIO"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TS_SIGNAGE_FILE_GROWTH_MONTH
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "TB_PATENT_TYPE_ID = " & "@_TB_PATENT_TYPE_ID" & ", "
                Sql += "SERIE_NAME = " & "@_SERIE_NAME" & ", "
                Sql += "SHOW_YEAR = " & "@_SHOW_YEAR" & ", "
                Sql += "SHOW_MONTH = " & "@_SHOW_MONTH" & ", "
                Sql += "FILE_QTY = " & "@_FILE_QTY" & ", "
                Sql += "GROWTH_RATIO = " & "@_GROWTH_RATIO" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TS_SIGNAGE_FILE_GROWTH_MONTH
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TS_SIGNAGE_FILE_GROWTH_MONTH
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, TB_PATENT_TYPE_ID, SERIE_NAME, SHOW_YEAR, SHOW_MONTH, FILE_QTY, GROWTH_RATIO FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

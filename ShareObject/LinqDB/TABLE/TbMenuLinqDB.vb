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
    'Represents a transaction for TB_MENU table LinqDB.
    '[Create by  on January, 15 2015]
    Public Class TbMenuLinqDB
        Public sub TbMenuLinqDB()

        End Sub 
        ' TB_MENU
        Const _tableName As String = "TB_MENU"
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
        Dim _MENU_NAME As  String  = ""
        Dim _MENU_TOOLTIP As  String  = ""
        Dim _MENU_URL As  String  = ""
        Dim _MODULE_ID As  System.Nullable(Of Long)  = 0
        Dim _CREATEBY As  String  = ""
        Dim _CREATEON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATEBY As  String  = ""
        Dim _UPDATEON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _MS_SUBMODULE_ID As  System.Nullable(Of Long)  = 0
        Dim _ROWID_ROOTMENU As Long = 0
        Dim _ROWID_PARENTMENU As Long = 0
        Dim _ROWID_SUBPARENTMENU As Long = 0
        Dim _SCREEN_NO As  String  = ""
        Dim _REMARKS As  String  = ""
        Dim _ISMENU As Char = "Y"
        Dim _ISNOTUSE As Char = "N"
        Dim _IMAGEURL As  String  = ""
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
        <Column(Storage:="_MENU_NAME", DbType:="VarChar(200)")>  _
        Public Property MENU_NAME() As  String 
            Get
                Return _MENU_NAME
            End Get
            Set(ByVal value As  String )
               _MENU_NAME = value
            End Set
        End Property 
        <Column(Storage:="_MENU_TOOLTIP", DbType:="VarChar(200)")>  _
        Public Property MENU_TOOLTIP() As  String 
            Get
                Return _MENU_TOOLTIP
            End Get
            Set(ByVal value As  String )
               _MENU_TOOLTIP = value
            End Set
        End Property 
        <Column(Storage:="_MENU_URL", DbType:="VarChar(200)")>  _
        Public Property MENU_URL() As  String 
            Get
                Return _MENU_URL
            End Get
            Set(ByVal value As  String )
               _MENU_URL = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_ID", DbType:="BigInt")>  _
        Public Property MODULE_ID() As  System.Nullable(Of Long) 
            Get
                Return _MODULE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MODULE_ID = value
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
        <Column(Storage:="_MS_SUBMODULE_ID", DbType:="BigInt")>  _
        Public Property MS_SUBMODULE_ID() As  System.Nullable(Of Long) 
            Get
                Return _MS_SUBMODULE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MS_SUBMODULE_ID = value
            End Set
        End Property 
        <Column(Storage:="_ROWID_ROOTMENU", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ROWID_ROOTMENU() As Long
            Get
                Return _ROWID_ROOTMENU
            End Get
            Set(ByVal value As Long)
               _ROWID_ROOTMENU = value
            End Set
        End Property 
        <Column(Storage:="_ROWID_PARENTMENU", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ROWID_PARENTMENU() As Long
            Get
                Return _ROWID_PARENTMENU
            End Get
            Set(ByVal value As Long)
               _ROWID_PARENTMENU = value
            End Set
        End Property 
        <Column(Storage:="_ROWID_SUBPARENTMENU", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ROWID_SUBPARENTMENU() As Long
            Get
                Return _ROWID_SUBPARENTMENU
            End Get
            Set(ByVal value As Long)
               _ROWID_SUBPARENTMENU = value
            End Set
        End Property 
        <Column(Storage:="_SCREEN_NO", DbType:="VarChar(50)")>  _
        Public Property SCREEN_NO() As  String 
            Get
                Return _SCREEN_NO
            End Get
            Set(ByVal value As  String )
               _SCREEN_NO = value
            End Set
        End Property 
        <Column(Storage:="_REMARKS", DbType:="VarChar(255)")>  _
        Public Property REMARKS() As  String 
            Get
                Return _REMARKS
            End Get
            Set(ByVal value As  String )
               _REMARKS = value
            End Set
        End Property 
        <Column(Storage:="_ISMENU", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ISMENU() As Char
            Get
                Return _ISMENU
            End Get
            Set(ByVal value As Char)
               _ISMENU = value
            End Set
        End Property 
        <Column(Storage:="_ISNOTUSE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ISNOTUSE() As Char
            Get
                Return _ISNOTUSE
            End Get
            Set(ByVal value As Char)
               _ISNOTUSE = value
            End Set
        End Property 
        <Column(Storage:="_IMAGEURL", DbType:="VarChar(255)")>  _
        Public Property IMAGEURL() As  String 
            Get
                Return _IMAGEURL
            End Get
            Set(ByVal value As  String )
               _IMAGEURL = value
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
            _MENU_NAME = ""
            _MENU_TOOLTIP = ""
            _MENU_URL = ""
            _MODULE_ID = 0
            _CREATEBY = ""
            _CREATEON = New DateTime(1,1,1)
            _UPDATEBY = ""
            _UPDATEON = New DateTime(1,1,1)
            _MS_SUBMODULE_ID = 0
            _ROWID_ROOTMENU = 0
            _ROWID_PARENTMENU = 0
            _ROWID_SUBPARENTMENU = 0
            _SCREEN_NO = ""
            _REMARKS = ""
            _ISMENU = ""
            _ISNOTUSE = ""
            _IMAGEURL = ""
            _ACTIVE_STATUS = ""
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


        '/// Returns an indication whether the current data is inserted into TB_MENU table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_MENU table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_MENU table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_MENU table successfully.
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


        '/// Returns an indication whether the record of TB_MENU by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_MENU by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbMenuLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_MENU by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_MENU table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_MENU table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_MENU table successfully.
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
            Dim cmbParam(18) As SqlParameter
            cmbParam(0) = New SqlParameter("@_ID", SqlDbType.BigInt)
            cmbParam(0).Value = _ID

            cmbParam(1) = New SqlParameter("@_MENU_NAME", SqlDbType.VarChar)
            If _MENU_NAME.Trim <> "" Then 
                cmbParam(1).Value = _MENU_NAME
            Else
                cmbParam(1).Value = DBNull.value
            End If

            cmbParam(2) = New SqlParameter("@_MENU_TOOLTIP", SqlDbType.VarChar)
            If _MENU_TOOLTIP.Trim <> "" Then 
                cmbParam(2).Value = _MENU_TOOLTIP
            Else
                cmbParam(2).Value = DBNull.value
            End If

            cmbParam(3) = New SqlParameter("@_MENU_URL", SqlDbType.VarChar)
            If _MENU_URL.Trim <> "" Then 
                cmbParam(3).Value = _MENU_URL
            Else
                cmbParam(3).Value = DBNull.value
            End If

            cmbParam(4) = New SqlParameter("@_MODULE_ID", SqlDbType.BigInt)
            If _MODULE_ID IsNot Nothing Then 
                cmbParam(4).Value = _MODULE_ID.Value
            Else
                cmbParam(4).Value = DBNull.value
            End IF

            cmbParam(5) = New SqlParameter("@_CREATEBY", SqlDbType.VarChar)
            If _CREATEBY.Trim <> "" Then 
                cmbParam(5).Value = _CREATEBY
            Else
                cmbParam(5).Value = DBNull.value
            End If

            cmbParam(6) = New SqlParameter("@_CREATEON", SqlDbType.DateTime)
            If _CREATEON.Value.Year > 1 Then 
                cmbParam(6).Value = _CREATEON.Value
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_UPDATEBY", SqlDbType.VarChar)
            If _UPDATEBY.Trim <> "" Then 
                cmbParam(7).Value = _UPDATEBY
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_UPDATEON", SqlDbType.DateTime)
            If _UPDATEON.Value.Year > 1 Then 
                cmbParam(8).Value = _UPDATEON.Value
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_MS_SUBMODULE_ID", SqlDbType.BigInt)
            If _MS_SUBMODULE_ID IsNot Nothing Then 
                cmbParam(9).Value = _MS_SUBMODULE_ID.Value
            Else
                cmbParam(9).Value = DBNull.value
            End IF

            cmbParam(10) = New SqlParameter("@_ROWID_ROOTMENU", SqlDbType.BigInt)
            cmbParam(10).Value = _ROWID_ROOTMENU

            cmbParam(11) = New SqlParameter("@_ROWID_PARENTMENU", SqlDbType.BigInt)
            cmbParam(11).Value = _ROWID_PARENTMENU

            cmbParam(12) = New SqlParameter("@_ROWID_SUBPARENTMENU", SqlDbType.BigInt)
            cmbParam(12).Value = _ROWID_SUBPARENTMENU

            cmbParam(13) = New SqlParameter("@_SCREEN_NO", SqlDbType.VarChar)
            If _SCREEN_NO.Trim <> "" Then 
                cmbParam(13).Value = _SCREEN_NO
            Else
                cmbParam(13).Value = DBNull.value
            End If

            cmbParam(14) = New SqlParameter("@_REMARKS", SqlDbType.VarChar)
            If _REMARKS.Trim <> "" Then 
                cmbParam(14).Value = _REMARKS
            Else
                cmbParam(14).Value = DBNull.value
            End If

            cmbParam(15) = New SqlParameter("@_ISMENU", SqlDbType.Char)
            cmbParam(15).Value = _ISMENU

            cmbParam(16) = New SqlParameter("@_ISNOTUSE", SqlDbType.Char)
            cmbParam(16).Value = _ISNOTUSE

            cmbParam(17) = New SqlParameter("@_IMAGEURL", SqlDbType.VarChar)
            If _IMAGEURL.Trim <> "" Then 
                cmbParam(17).Value = _IMAGEURL
            Else
                cmbParam(17).Value = DBNull.value
            End If

            cmbParam(18) = New SqlParameter("@_ACTIVE_STATUS", SqlDbType.Char)
            cmbParam(18).Value = _ACTIVE_STATUS

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_MENU by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("menu_name")) = False Then _menu_name = Rdr("menu_name").ToString()
                        If Convert.IsDBNull(Rdr("menu_tooltip")) = False Then _menu_tooltip = Rdr("menu_tooltip").ToString()
                        If Convert.IsDBNull(Rdr("menu_url")) = False Then _menu_url = Rdr("menu_url").ToString()
                        If Convert.IsDBNull(Rdr("module_id")) = False Then _module_id = Convert.ToInt64(Rdr("module_id"))
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
                        If Convert.IsDBNull(Rdr("ms_submodule_id")) = False Then _ms_submodule_id = Convert.ToInt64(Rdr("ms_submodule_id"))
                        If Convert.IsDBNull(Rdr("rowid_rootmenu")) = False Then _rowid_rootmenu = Convert.ToInt64(Rdr("rowid_rootmenu"))
                        If Convert.IsDBNull(Rdr("rowid_parentmenu")) = False Then _rowid_parentmenu = Convert.ToInt64(Rdr("rowid_parentmenu"))
                        If Convert.IsDBNull(Rdr("rowid_subparentmenu")) = False Then _rowid_subparentmenu = Convert.ToInt64(Rdr("rowid_subparentmenu"))
                        If Convert.IsDBNull(Rdr("screen_no")) = False Then _screen_no = Rdr("screen_no").ToString()
                        If Convert.IsDBNull(Rdr("remarks")) = False Then _remarks = Rdr("remarks").ToString()
                        If Convert.IsDBNull(Rdr("ismenu")) = False Then _ismenu = Rdr("ismenu").ToString()
                        If Convert.IsDBNull(Rdr("isnotuse")) = False Then _isnotuse = Rdr("isnotuse").ToString()
                        If Convert.IsDBNull(Rdr("imageurl")) = False Then _imageurl = Rdr("imageurl").ToString()
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


        '/// Returns an indication whether the record of TB_MENU by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbMenuLinqDB
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
                        If Convert.IsDBNull(Rdr("menu_name")) = False Then _menu_name = Rdr("menu_name").ToString()
                        If Convert.IsDBNull(Rdr("menu_tooltip")) = False Then _menu_tooltip = Rdr("menu_tooltip").ToString()
                        If Convert.IsDBNull(Rdr("menu_url")) = False Then _menu_url = Rdr("menu_url").ToString()
                        If Convert.IsDBNull(Rdr("module_id")) = False Then _module_id = Convert.ToInt64(Rdr("module_id"))
                        If Convert.IsDBNull(Rdr("createby")) = False Then _createby = Rdr("createby").ToString()
                        If Convert.IsDBNull(Rdr("createon")) = False Then _createon = Convert.ToDateTime(Rdr("createon"))
                        If Convert.IsDBNull(Rdr("updateby")) = False Then _updateby = Rdr("updateby").ToString()
                        If Convert.IsDBNull(Rdr("updateon")) = False Then _updateon = Convert.ToDateTime(Rdr("updateon"))
                        If Convert.IsDBNull(Rdr("ms_submodule_id")) = False Then _ms_submodule_id = Convert.ToInt64(Rdr("ms_submodule_id"))
                        If Convert.IsDBNull(Rdr("rowid_rootmenu")) = False Then _rowid_rootmenu = Convert.ToInt64(Rdr("rowid_rootmenu"))
                        If Convert.IsDBNull(Rdr("rowid_parentmenu")) = False Then _rowid_parentmenu = Convert.ToInt64(Rdr("rowid_parentmenu"))
                        If Convert.IsDBNull(Rdr("rowid_subparentmenu")) = False Then _rowid_subparentmenu = Convert.ToInt64(Rdr("rowid_subparentmenu"))
                        If Convert.IsDBNull(Rdr("screen_no")) = False Then _screen_no = Rdr("screen_no").ToString()
                        If Convert.IsDBNull(Rdr("remarks")) = False Then _remarks = Rdr("remarks").ToString()
                        If Convert.IsDBNull(Rdr("ismenu")) = False Then _ismenu = Rdr("ismenu").ToString()
                        If Convert.IsDBNull(Rdr("isnotuse")) = False Then _isnotuse = Rdr("isnotuse").ToString()
                        If Convert.IsDBNull(Rdr("imageurl")) = False Then _imageurl = Rdr("imageurl").ToString()
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


        'Get Insert Statement for table TB_MENU
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, MENU_NAME, MENU_TOOLTIP, MENU_URL, MODULE_ID, CREATEBY, CREATEON, UPDATEBY, UPDATEON, MS_SUBMODULE_ID, ROWID_ROOTMENU, ROWID_PARENTMENU, ROWID_SUBPARENTMENU, SCREEN_NO, REMARKS, ISMENU, ISNOTUSE, IMAGEURL, ACTIVE_STATUS)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.MENU_NAME, INSERTED.MENU_TOOLTIP, INSERTED.MENU_URL, INSERTED.MODULE_ID, INSERTED.CREATEBY, INSERTED.CREATEON, INSERTED.UPDATEBY, INSERTED.UPDATEON, INSERTED.MS_SUBMODULE_ID, INSERTED.ROWID_ROOTMENU, INSERTED.ROWID_PARENTMENU, INSERTED.ROWID_SUBPARENTMENU, INSERTED.SCREEN_NO, INSERTED.REMARKS, INSERTED.ISMENU, INSERTED.ISNOTUSE, INSERTED.IMAGEURL, INSERTED.ACTIVE_STATUS
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_MENU_NAME" & ", "
                sql += "@_MENU_TOOLTIP" & ", "
                sql += "@_MENU_URL" & ", "
                sql += "@_MODULE_ID" & ", "
                sql += "@_CREATEBY" & ", "
                sql += "@_CREATEON" & ", "
                sql += "@_UPDATEBY" & ", "
                sql += "@_UPDATEON" & ", "
                sql += "@_MS_SUBMODULE_ID" & ", "
                sql += "@_ROWID_ROOTMENU" & ", "
                sql += "@_ROWID_PARENTMENU" & ", "
                sql += "@_ROWID_SUBPARENTMENU" & ", "
                sql += "@_SCREEN_NO" & ", "
                sql += "@_REMARKS" & ", "
                sql += "@_ISMENU" & ", "
                sql += "@_ISNOTUSE" & ", "
                sql += "@_IMAGEURL" & ", "
                sql += "@_ACTIVE_STATUS"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_MENU
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "MENU_NAME = " & "@_MENU_NAME" & ", "
                Sql += "MENU_TOOLTIP = " & "@_MENU_TOOLTIP" & ", "
                Sql += "MENU_URL = " & "@_MENU_URL" & ", "
                Sql += "MODULE_ID = " & "@_MODULE_ID" & ", "
                Sql += "CREATEBY = " & "@_CREATEBY" & ", "
                Sql += "CREATEON = " & "@_CREATEON" & ", "
                Sql += "UPDATEBY = " & "@_UPDATEBY" & ", "
                Sql += "UPDATEON = " & "@_UPDATEON" & ", "
                Sql += "MS_SUBMODULE_ID = " & "@_MS_SUBMODULE_ID" & ", "
                Sql += "ROWID_ROOTMENU = " & "@_ROWID_ROOTMENU" & ", "
                Sql += "ROWID_PARENTMENU = " & "@_ROWID_PARENTMENU" & ", "
                Sql += "ROWID_SUBPARENTMENU = " & "@_ROWID_SUBPARENTMENU" & ", "
                Sql += "SCREEN_NO = " & "@_SCREEN_NO" & ", "
                Sql += "REMARKS = " & "@_REMARKS" & ", "
                Sql += "ISMENU = " & "@_ISMENU" & ", "
                Sql += "ISNOTUSE = " & "@_ISNOTUSE" & ", "
                Sql += "IMAGEURL = " & "@_IMAGEURL" & ", "
                Sql += "ACTIVE_STATUS = " & "@_ACTIVE_STATUS" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_MENU
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_MENU
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, MENU_NAME, MENU_TOOLTIP, MENU_URL, MODULE_ID, CREATEBY, CREATEON, UPDATEBY, UPDATEON, MS_SUBMODULE_ID, ROWID_ROOTMENU, ROWID_PARENTMENU, ROWID_SUBPARENTMENU, SCREEN_NO, REMARKS, ISMENU, ISNOTUSE, IMAGEURL, ACTIVE_STATUS FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace

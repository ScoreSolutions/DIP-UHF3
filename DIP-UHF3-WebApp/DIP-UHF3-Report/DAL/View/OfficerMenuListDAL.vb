Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DB = DIP_RFID.DAL.Common.Utilities.SqlDB
Imports DIP_RFID.Data.Common.Utilities
Imports DIP_RFID.Data.Table

Namespace Table
    'Represents a transaction for v_officer_menu view DAL.
    '[Create by  on December, 27 2010]
    Public Class OfficerMenuListDAL
        Public Sub OfficerMenuListDAL()

        End Sub
        ' v_officer_menu
        Const _viewName As String = "v_officer_menu"

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property ViewName() As String
            Get
                Return _viewName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage() As String
            Get
                Return _information
            End Get
        End Property
        Public ReadOnly Property HaveData() As Boolean
            Get
                Return _haveData
            End Get
        End Property


        'Generate Field List
        Dim _OFFICER_ID As Long = 0
        Dim _STAFF_NAME As String = ""
        Dim _DEPARTMENT_ID As Long = 0
        Dim _POSITION_ID As Long = 0
        Dim _DEPARTMENT_NAME As String = ""
        Dim _POSITION_NAME As String = ""
        Dim _MENU_ID As Long = 0
        Dim _MENU_NAME As String = ""
        Dim _MENU_TOOLTIP As String = ""
        Dim _MENU_URL As String = ""
        Dim _MODULE_ID As String = ""
        Dim _MODULE_NAME As String = ""
        Dim _MODULE_DESC As String = ""

        'Generate Field Property 
        Public Property OFFICER_ID() As Long
            Get
                Return _OFFICER_ID
            End Get
            Set(ByVal value As Long)
                _OFFICER_ID = value
            End Set
        End Property
        Public Property STAFF_NAME() As String
            Get
                Return _STAFF_NAME
            End Get
            Set(ByVal value As String)
                _STAFF_NAME = value
            End Set
        End Property
        Public Property DEPARTMENT_ID() As Long
            Get
                Return _DEPARTMENT_ID
            End Get
            Set(ByVal value As Long)
                _DEPARTMENT_ID = value
            End Set
        End Property
        Public Property POSITION_ID() As Long
            Get
                Return _POSITION_ID
            End Get
            Set(ByVal value As Long)
                _POSITION_ID = value
            End Set
        End Property
        Public Property DEPARTMENT_NAME() As String
            Get
                Return _DEPARTMENT_NAME
            End Get
            Set(ByVal value As String)
                _DEPARTMENT_NAME = value
            End Set
        End Property
        Public Property POSITION_NAME() As String
            Get
                Return _POSITION_NAME
            End Get
            Set(ByVal value As String)
                _POSITION_NAME = value
            End Set
        End Property
        Public Property MENU_ID() As Long
            Get
                Return _MENU_ID
            End Get
            Set(ByVal value As Long)
                _MENU_ID = value
            End Set
        End Property
        Public Property MENU_NAME() As String
            Get
                Return _MENU_NAME
            End Get
            Set(ByVal value As String)
                _MENU_NAME = value
            End Set
        End Property
        Public Property MENU_TOOLTIP() As String
            Get
                Return _MENU_TOOLTIP
            End Get
            Set(ByVal value As String)
                _MENU_TOOLTIP = value
            End Set
        End Property
        Public Property MENU_URL() As String
            Get
                Return _MENU_URL
            End Get
            Set(ByVal value As String)
                _MENU_URL = value
            End Set
        End Property
        Public Property MODULE_ID() As String
            Get
                Return _MODULE_ID
            End Get
            Set(ByVal value As String)
                _MODULE_ID = value
            End Set
        End Property
        Public Property MODULE_NAME() As String
            Get
                Return _MODULE_NAME
            End Get
            Set(ByVal value As String)
                _MODULE_NAME = value
            End Set
        End Property
        Public Property MODULE_DESC() As String
            Get
                Return _MODULE_DESC
            End Get
            Set(ByVal value As String)
                _MODULE_DESC = value
            End Set
        End Property


        'Clear All Data
        Private Sub ClearData()
            _OFFICER_ID = 0
            _STAFF_NAME = ""
            _DEPARTMENT_ID = 0
            _POSITION_ID = 0
            _DEPARTMENT_NAME = ""
            _POSITION_NAME = ""
            _MENU_ID = 0
            _MENU_NAME = ""
            _MENU_TOOLTIP = ""
            _MENU_URL = ""
            _MODULE_ID = ""
            _MODULE_NAME = ""
            _MODULE_DESC = ""
        End Sub

        'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(ByVal whClause As String, ByVal orderBy As String, ByVal trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(ByVal Sql As String, ByVal orderBy As String, ByVal trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(Sql & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        '/// Returns an indication whether the record of v_officer_menu by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the record of v_officer_menu by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            ClearData()
            _haveData = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("officer_id")) = False Then _officer_id = Convert.ToInt64(Rdr("officer_id"))
                        If Convert.IsDBNull(Rdr("staff_name")) = False Then _staff_name = Rdr("staff_name").ToString()
                        If Convert.IsDBNull(Rdr("department_id")) = False Then _department_id = Convert.ToInt64(Rdr("department_id"))
                        If Convert.IsDBNull(Rdr("position_id")) = False Then _position_id = Convert.ToInt64(Rdr("position_id"))
                        If Convert.IsDBNull(Rdr("department_name")) = False Then _department_name = Rdr("department_name").ToString()
                        If Convert.IsDBNull(Rdr("position_name")) = False Then _position_name = Rdr("position_name").ToString()
                        If Convert.IsDBNull(Rdr("menu_id")) = False Then _menu_id = Convert.ToInt64(Rdr("menu_id"))
                        If Convert.IsDBNull(Rdr("menu_name")) = False Then _menu_name = Rdr("menu_name").ToString()
                        If Convert.IsDBNull(Rdr("menu_tooltip")) = False Then _menu_tooltip = Rdr("menu_tooltip").ToString()
                        If Convert.IsDBNull(Rdr("menu_url")) = False Then _menu_url = Rdr("menu_url").ToString()
                        If Convert.IsDBNull(Rdr("module_id")) = False Then _module_id = Rdr("module_id").ToString()
                        If Convert.IsDBNull(Rdr("module_name")) = False Then _module_name = Rdr("module_name").ToString()
                        If Convert.IsDBNull(Rdr("module_desc")) = False Then _module_desc = Rdr("module_desc").ToString()
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed = False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function
        '/// Returns an indication whether the Class Data of v_officer_menu by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingData(ByVal ret As OfficerMenuListData, ByVal RDr As DataRow) As OfficerMenuListData
            If Convert.IsDBNull(Rdr("officer_id")) = False Then ret.OFFICER_ID = Convert.ToInt64(Rdr("officer_id"))
            If Convert.IsDBNull(Rdr("staff_name")) = False Then ret.STAFF_NAME = Rdr("staff_name").ToString()
            If Convert.IsDBNull(Rdr("department_id")) = False Then ret.DEPARTMENT_ID = Convert.ToInt64(Rdr("department_id"))
            If Convert.IsDBNull(Rdr("position_id")) = False Then ret.POSITION_ID = Convert.ToInt64(Rdr("position_id"))
            If Convert.IsDBNull(Rdr("department_name")) = False Then ret.DEPARTMENT_NAME = Rdr("department_name").ToString()
            If Convert.IsDBNull(Rdr("position_name")) = False Then ret.POSITION_NAME = Rdr("position_name").ToString()
            If Convert.IsDBNull(Rdr("menu_id")) = False Then ret.MENU_ID = Convert.ToInt64(Rdr("menu_id"))
            If Convert.IsDBNull(Rdr("menu_name")) = False Then ret.MENU_NAME = Rdr("menu_name").ToString()
            If Convert.IsDBNull(Rdr("menu_tooltip")) = False Then ret.MENU_TOOLTIP = Rdr("menu_tooltip").ToString()
            If Convert.IsDBNull(Rdr("menu_url")) = False Then ret.MENU_URL = Rdr("menu_url").ToString()
            If Convert.IsDBNull(Rdr("module_id")) = False Then ret.MODULE_ID = Rdr("module_id").ToString()
            If Convert.IsDBNull(Rdr("module_name")) = False Then ret.MODULE_NAME = Rdr("module_name").ToString()
            If Convert.IsDBNull(Rdr("module_desc")) = False Then ret.MODULE_DESC = Rdr("module_desc").ToString()
            Return ret
        End Function


        '/// Returns an indication whether the record of v_officer_menu by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetMappingData(ByVal whText As String, ByVal trans As SQLTransaction) As OfficerMenuListData
            ClearData()
            _haveData = False
            Dim ret As New OfficerMenuListData
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdt As DataTable
                Try
                    Rdt = DB.ExecuteTable(SqlSelect() & tmpWhere, trans)
                    If Rdt.Rows.Count = 1 Then
                        _haveData = True
                        Dim RDr As DataRow
                        RDr = Rdt.Rows(0)
                        doChkData(whText, trans)
                        ret = doMappingData(ret, RDr)
                    Else
                        _haveData = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdt = Nothing
                Catch ex As Exception
                    ex.ToString()
                    _haveData = False
                    _error = MessageResources.MSGEC104
                    If Rdt IsNot Nothing Then
                        Rdt = Nothing
                    End If
                End Try
            Else
                _haveData = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function



        ' SQL Statements


        'Get Select Statement for table v_officer_menu
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & viewName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
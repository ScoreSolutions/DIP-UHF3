Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DB = DIP_RFID.DAL.Common.Utilities.SqlDB
Imports DIP_RFID.Data.Common.Utilities
Imports DIP_RFID.Data.View

Namespace View
    'Represents a transaction for v_reserve_list view DAL.
    '[Create by  on January, 19 2011]
    Public Class ReserveListDAL
        Public Sub ReserveListDAL()

        End Sub
        ' v_reserve_list
        Const _viewName As String = "v_reserve_list"

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
        Dim _ID As Long = 0
        Dim _REF_INNOVA_ID As Long = 0
        Dim _MEMBER_ID As Long = 0
        Dim _MEMBER_NAME As String = ""
        Dim _REQ_NO As String = ""
        Dim _RESERVE_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _RESERVE_ORDER As Integer = 0
        Dim _RESERVE_STATUS As String = ""
        Dim _PATENT_TYPE_NAME As String = ""
        Dim _RESERVE_DATE2 As DateTime = New DateTime(1, 1, 1)

        'Generate Field Property 
        Public ReadOnly Property ID() As Long
            Get
                Return _ID
            End Get
        End Property
        Public Property REF_INNOVA_ID() As Long
            Get
                Return _REF_INNOVA_ID
            End Get
            Set(ByVal value As Long)
                _REF_INNOVA_ID = value
            End Set
        End Property
        Public Property MEMBER_ID() As Long
            Get
                Return _MEMBER_ID
            End Get
            Set(ByVal value As Long)
                _MEMBER_ID = value
            End Set
        End Property
        Public Property MEMBER_NAME() As String
            Get
                Return _MEMBER_NAME
            End Get
            Set(ByVal value As String)
                _MEMBER_NAME = value
            End Set
        End Property
        Public Property REQ_NO() As String
            Get
                Return _REQ_NO
            End Get
            Set(ByVal value As String)
                _REQ_NO = value
            End Set
        End Property
        Public Property RESERVE_DATE() As DateTime
            Get
                Return _RESERVE_DATE
            End Get
            Set(ByVal value As DateTime)
                _RESERVE_DATE = value
            End Set
        End Property
        Public Property RESERVE_ORDER() As Integer
            Get
                Return _RESERVE_ORDER
            End Get
            Set(ByVal value As Integer)
                _RESERVE_ORDER = value
            End Set
        End Property
        Public Property RESERVE_STATUS() As String
            Get
                Return _RESERVE_STATUS
            End Get
            Set(ByVal value As String)
                _RESERVE_STATUS = value
            End Set
        End Property
        Public Property PATENT_TYPE_NAME() As String
            Get
                Return _PATENT_TYPE_NAME
            End Get
            Set(ByVal value As String)
                _PATENT_TYPE_NAME = value
            End Set
        End Property
        Public Property RESERVE_DATE2() As DateTime
            Get
                Return _RESERVE_DATE2
            End Get
            Set(ByVal value As DateTime)
                _RESERVE_DATE2 = value
            End Set
        End Property


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _REF_INNOVA_ID = 0
            _MEMBER_ID = 0
            _MEMBER_NAME = ""
            _REQ_NO = ""
            _RESERVE_DATE = New DateTime(1, 1, 1)
            _RESERVE_ORDER = 0
            _RESERVE_STATUS = ""
            _PATENT_TYPE_NAME = ""
            _RESERVE_DATE2 = New DateTime(1, 1, 1)
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


        '/// Returns an indication whether the record of v_reserve_list by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the record of v_reserve_list by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("ref_innova_id")) = False Then _ref_innova_id = Convert.ToInt64(Rdr("ref_innova_id"))
                        If Convert.IsDBNull(Rdr("member_id")) = False Then _member_id = Convert.ToInt64(Rdr("member_id"))
                        If Convert.IsDBNull(Rdr("member_name")) = False Then _member_name = Rdr("member_name").ToString()
                        If Convert.IsDBNull(Rdr("req_no")) = False Then _req_no = Rdr("req_no").ToString()
                        If Convert.IsDBNull(Rdr("reserve_date")) = False Then _reserve_date = Convert.ToDateTime(Rdr("reserve_date"))
                        If Convert.IsDBNull(Rdr("reserve_order")) = False Then _reserve_order = Convert.ToInt32(Rdr("reserve_order"))
                        If Convert.IsDBNull(Rdr("reserve_status")) = False Then _reserve_status = Rdr("reserve_status").ToString()
                        If Convert.IsDBNull(Rdr("patent_type_name")) = False Then _patent_type_name = Rdr("patent_type_name").ToString()
                        If Convert.IsDBNull(Rdr("reserve_date2")) = False Then _reserve_date2 = Convert.ToDateTime(Rdr("reserve_date2"))
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
        '/// Returns an indication whether the Class Data of v_reserve_list by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingData(ByVal ret As ReserveListData, ByVal RDr As DataRow) As ReserveListData
            If Convert.IsDBNull(Rdr("id")) = False Then ret.ID = Convert.ToInt64(Rdr("id"))
            If Convert.IsDBNull(Rdr("ref_innova_id")) = False Then ret.REF_INNOVA_ID = Convert.ToInt64(Rdr("ref_innova_id"))
            If Convert.IsDBNull(Rdr("member_id")) = False Then ret.MEMBER_ID = Convert.ToInt64(Rdr("member_id"))
            If Convert.IsDBNull(Rdr("member_name")) = False Then ret.MEMBER_NAME = Rdr("member_name").ToString()
            If Convert.IsDBNull(Rdr("req_no")) = False Then ret.REQ_NO = Rdr("req_no").ToString()
            If Convert.IsDBNull(Rdr("reserve_date")) = False Then ret.RESERVE_DATE = Convert.ToDateTime(Rdr("reserve_date"))
            If Convert.IsDBNull(Rdr("reserve_order")) = False Then ret.RESERVE_ORDER = Convert.ToInt32(Rdr("reserve_order"))
            If Convert.IsDBNull(Rdr("reserve_status")) = False Then ret.RESERVE_STATUS = Rdr("reserve_status").ToString()
            If Convert.IsDBNull(Rdr("patent_type_name")) = False Then ret.PATENT_TYPE_NAME = Rdr("patent_type_name").ToString()
            If Convert.IsDBNull(Rdr("reserve_date2")) = False Then ret.RESERVE_DATE2 = Convert.ToDateTime(Rdr("reserve_date2"))
            Return ret
        End Function


        '/// Returns an indication whether the record of v_reserve_list by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetMappingData(ByVal whText As String, ByVal trans As SQLTransaction) As ReserveListData
            ClearData()
            _haveData = False
            Dim ret As New ReserveListData
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


        'Get Select Statement for table v_reserve_list
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & viewName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
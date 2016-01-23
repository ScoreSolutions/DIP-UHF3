
Namespace View
    'Represents a transaction for v_reserve_list view Data.
    '[Create by  on January, 19 2011]
    Public Class ReserveListData

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
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
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
    End Class
End Namespace
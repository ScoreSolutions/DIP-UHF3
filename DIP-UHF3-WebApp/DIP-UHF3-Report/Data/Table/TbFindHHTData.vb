
Namespace Table
    'Represents a transaction for TB_FIND_HHT table Data.
    '[Create by  on January, 20 2011]
    Public Class TbFindHHTData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _APP_NO As String = ""
        Dim _LOAD_DATETIME As DateTime = New DateTime(1, 1, 1)
        Dim _LOAD_TYPE As String = ""
        Dim _FIND_STATUS As String = ""
        Dim _REF_ID As Long = 0
        Dim _CREATEBY As String = ""
        Dim _CREATEON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATEBY As String = ""
        Dim _UPDATEON As DateTime = New DateTime(1, 1, 1)

        'Generate Field Property 
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        Public Property APP_NO() As String
            Get
                Return _APP_NO
            End Get
            Set(ByVal value As String)
                _APP_NO = value
            End Set
        End Property
        Public Property LOAD_DATETIME() As DateTime
            Get
                Return _LOAD_DATETIME
            End Get
            Set(ByVal value As DateTime)
                _LOAD_DATETIME = value
            End Set
        End Property
        Public Property LOAD_TYPE() As String
            Get
                Return _LOAD_TYPE
            End Get
            Set(ByVal value As String)
                _LOAD_TYPE = value
            End Set
        End Property
        Public Property FIND_STATUS() As String
            Get
                Return _FIND_STATUS
            End Get
            Set(ByVal value As String)
                _FIND_STATUS = value
            End Set
        End Property
        Public Property REF_ID() As Long
            Get
                Return _REF_ID
            End Get
            Set(ByVal value As Long)
                _REF_ID = value
            End Set
        End Property
        Public Property CREATEBY() As String
            Get
                Return _CREATEBY
            End Get
            Set(ByVal value As String)
                _CREATEBY = value
            End Set
        End Property
        Public Property CREATEON() As DateTime
            Get
                Return _CREATEON
            End Get
            Set(ByVal value As DateTime)
                _CREATEON = value
            End Set
        End Property
        Public Property UPDATEBY() As String
            Get
                Return _UPDATEBY
            End Get
            Set(ByVal value As String)
                _UPDATEBY = value
            End Set
        End Property
        Public Property UPDATEON() As DateTime
            Get
                Return _UPDATEON
            End Get
            Set(ByVal value As DateTime)
                _UPDATEON = value
            End Set
        End Property
    End Class
End Namespace
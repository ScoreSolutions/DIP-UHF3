
Namespace Table
    'Represents a transaction for TB_OFFICER_MENU table Data.
    '[Create by  on December, 27 2010]
    Public Class TbOfficerMenuData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _OFFICER_ID As Long = 0
        Dim _MENU_ID As Long = 0
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
        Public Property OFFICER_ID() As Long
            Get
                Return _OFFICER_ID
            End Get
            Set(ByVal value As Long)
                _OFFICER_ID = value
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
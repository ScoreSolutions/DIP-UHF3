
Namespace Table
    'Represents a transaction for TB_MENU table Data.
    '[Create by  on December, 21 2010]
    Public Class TbMenuData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _MENU_NAME As String = ""
        Dim _MENU_TOOLTIP As String = ""
        Dim _MENU_URL As String = ""
        Dim _MODULE_ID As String = ""
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
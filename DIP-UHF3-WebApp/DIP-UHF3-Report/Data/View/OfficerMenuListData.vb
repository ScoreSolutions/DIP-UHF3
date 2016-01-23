
Namespace Table
    'Represents a transaction for v_officer_menu view Data.
    '[Create by  on December, 27 2010]
    Public Class OfficerMenuListData

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
    End Class
End Namespace
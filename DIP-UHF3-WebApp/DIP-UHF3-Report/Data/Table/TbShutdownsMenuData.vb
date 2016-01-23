
Namespace Table
    'Represents a transaction for TB_SHUTDOWS_MENU table Data.
    '[Create by  on December, 21 2010]
    Public Class TbShutdownsMenuData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _COM_NAME As String = ""
        Dim _MENU_ID As Long = 0
        Dim _OPEN_DATETIME As DateTime = New DateTime(1, 1, 1)
        Dim _CLOSE_DATETIME As DateTime = New DateTime(1, 1, 1)
        Dim _S_STATUS As String = ""
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
        Public Property COM_NAME() As String
            Get
                Return _COM_NAME
            End Get
            Set(ByVal value As String)
                _COM_NAME = value
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
        Public Property OPEN_DATETIME() As DateTime
            Get
                Return _OPEN_DATETIME
            End Get
            Set(ByVal value As DateTime)
                _OPEN_DATETIME = value
            End Set
        End Property
        Public Property CLOSE_DATETIME() As DateTime
            Get
                Return _CLOSE_DATETIME
            End Get
            Set(ByVal value As DateTime)
                _CLOSE_DATETIME = value
            End Set
        End Property
        Public Property S_STATUS() As String
            Get
                Return _S_STATUS
            End Get
            Set(ByVal value As String)
                _S_STATUS = value
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
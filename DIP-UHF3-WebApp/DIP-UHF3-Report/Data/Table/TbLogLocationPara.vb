
Namespace Table
    'Represents a transaction for TB_LOG_LOCATION table Parameter.
    '[Create by  on September, 16 2014]
    Public Class TbLogLocationPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATEBY As String = ""
        Dim _CREATEON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATEBY As String = ""
        Dim _UPDATEON As DateTime = New DateTime(1, 1, 1)
        Dim _APP_NO As String = ""
        Dim _LOG_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _READERID As String = ""

        'Generate Field Property 
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
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
        Public Property APP_NO() As String
            Get
                Return _APP_NO
            End Get
            Set(ByVal value As String)
                _APP_NO = value
            End Set
        End Property
        Public Property LOG_DATE() As DateTime
            Get
                Return _LOG_DATE
            End Get
            Set(ByVal value As DateTime)
                _LOG_DATE = value
            End Set
        End Property
        Public Property READERID() As String
            Get
                Return _READERID
            End Get
            Set(ByVal value As String)
                _READERID = value
            End Set
        End Property
    End Class
End Namespace
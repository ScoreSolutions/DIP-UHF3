
Namespace Table
    'Represents a transaction for TB_GATE_CONSOLE_LOG table Data.
    '[Create by  on January, 24 2011]
    Public Class TbGateConsoleLogData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _APP_NO As String = ""
        Dim _TIMESTAMP As DateTime = New DateTime(1, 1, 1)
        Dim _ISALARM As String = ""
        Dim _ALARM_DISABLE_TIME As DateTime = New DateTime(1, 1, 1)
        Dim _READERID As String = ""
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
        Public Property TIMESTAMP() As DateTime
            Get
                Return _TIMESTAMP
            End Get
            Set(ByVal value As DateTime)
                _TIMESTAMP = value
            End Set
        End Property
        Public Property ISALARM() As String
            Get
                Return _ISALARM
            End Get
            Set(ByVal value As String)
                _ISALARM = value
            End Set
        End Property
        Public Property ALARM_DISABLE_TIME() As DateTime
            Get
                Return _ALARM_DISABLE_TIME
            End Get
            Set(ByVal value As DateTime)
                _ALARM_DISABLE_TIME = value
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
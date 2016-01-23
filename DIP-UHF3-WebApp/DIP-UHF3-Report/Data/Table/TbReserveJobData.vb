
Namespace Table
    'Represents a transaction for TB_RESERVE_JOB table Data.
    '[Create by  on December, 26 2010]
    Public Class TbReserveJobData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _JOB_NO As String = ""
        Dim _JOB_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _MEMBER_ID As Long = 0
        Dim _MEMBER_NAME As String = ""
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
        Public Property JOB_NO() As String
            Get
                Return _JOB_NO
            End Get
            Set(ByVal value As String)
                _JOB_NO = value
            End Set
        End Property
        Public Property JOB_DATE() As DateTime
            Get
                Return _JOB_DATE
            End Get
            Set(ByVal value As DateTime)
                _JOB_DATE = value
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
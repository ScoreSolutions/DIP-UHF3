
Namespace Table
    'Represents a transaction for TMP_GATE_READER_TAG table Data.
    '[Create by  on April, 3 2014]
    Public Class TmpGateReaderTagData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATEBY As String = ""
        Dim _CREATEON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATEBY As String = ""
        Dim _UPDATEON As DateTime = New DateTime(1, 1, 1)
        Dim _READER_ID As String = ""
        Dim _TAG_ID As String = ""
        Dim _READ_TYPE As String = ""

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
        Public Property READER_ID() As String
            Get
                Return _READER_ID
            End Get
            Set(ByVal value As String)
                _READER_ID = value
            End Set
        End Property
        Public Property TAG_ID() As String
            Get
                Return _TAG_ID
            End Get
            Set(ByVal value As String)
                _TAG_ID = value
            End Set
        End Property
        Public Property READ_TYPE() As String
            Get
                Return _READ_TYPE
            End Get
            Set(ByVal value As String)
                _READ_TYPE = value
            End Set
        End Property
    End Class
End Namespace

Namespace Table
    'Represents a transaction for TB_FILEBORROW table Data.
    '[Create by  on December, 25 2010]
    Public Class TbFileBorrowData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _FILEBORROW_CODE As String = ""
        Dim _RESERVE_JOB_ID As Long = 0
        Dim _BORROWER_ID As String = ""
        Dim _BORROWERNAME As String = ""
        Dim _BORROWERSTATUS As String = ""
        Dim _BORROWERDATE As DateTime = New DateTime(1, 1, 1)
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
        Public Property FILEBORROW_CODE() As String
            Get
                Return _FILEBORROW_CODE
            End Get
            Set(ByVal value As String)
                _FILEBORROW_CODE = value
            End Set
        End Property
        Public Property RESERVE_JOB_ID() As Long
            Get
                Return _RESERVE_JOB_ID
            End Get
            Set(ByVal value As Long)
                _RESERVE_JOB_ID = value
            End Set
        End Property
        Public Property BORROWER_ID() As String
            Get
                Return _BORROWER_ID
            End Get
            Set(ByVal value As String)
                _BORROWER_ID = value
            End Set
        End Property
        Public Property BORROWERNAME() As String
            Get
                Return _BORROWERNAME
            End Get
            Set(ByVal value As String)
                _BORROWERNAME = value
            End Set
        End Property
        Public Property BORROWERSTATUS() As String
            Get
                Return _BORROWERSTATUS
            End Get
            Set(ByVal value As String)
                _BORROWERSTATUS = value
            End Set
        End Property
        Public Property BORROWERDATE() As DateTime
            Get
                Return _BORROWERDATE
            End Get
            Set(ByVal value As DateTime)
                _BORROWERDATE = value
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
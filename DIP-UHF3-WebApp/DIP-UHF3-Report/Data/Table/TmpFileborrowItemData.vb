
Namespace Table
    'Represents a transaction for TMP_FILEBORROWITEM table Data.
    '[Create by  on January, 20 2011]
    Public Class TmpFileborrowItemData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _FILEBORROWITEM_ID As Long = 0
        Dim _APP_NO As String = ""
        Dim _RESERVEDATE As DateTime = New DateTime(1, 1, 1)
        Dim _BORROWDATE As DateTime = New DateTime(1, 1, 1)
        Dim _BORROWER_ID As Long = 0
        Dim _BORROWER_NAME As String = ""
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
        Public Property FILEBORROWITEM_ID() As Long
            Get
                Return _FILEBORROWITEM_ID
            End Get
            Set(ByVal value As Long)
                _FILEBORROWITEM_ID = value
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
        Public Property RESERVEDATE() As DateTime
            Get
                Return _RESERVEDATE
            End Get
            Set(ByVal value As DateTime)
                _RESERVEDATE = value
            End Set
        End Property
        Public Property BORROWDATE() As DateTime
            Get
                Return _BORROWDATE
            End Get
            Set(ByVal value As DateTime)
                _BORROWDATE = value
            End Set
        End Property
        Public Property BORROWER_ID() As Long
            Get
                Return _BORROWER_ID
            End Get
            Set(ByVal value As Long)
                _BORROWER_ID = value
            End Set
        End Property
        Public Property BORROWER_NAME() As String
            Get
                Return _BORROWER_NAME
            End Get
            Set(ByVal value As String)
                _BORROWER_NAME = value
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
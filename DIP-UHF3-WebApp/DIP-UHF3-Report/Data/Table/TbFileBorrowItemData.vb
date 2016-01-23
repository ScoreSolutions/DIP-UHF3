
Namespace Table
    'Represents a transaction for TB_FILEBORROWITEM table Data.
    '[Create by  on December, 28 2010]
    Public Class TbFileBorrowItemData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _FILEBORROW_ID As Long = 0
        Dim _RESERVE_ID As Long = 0
        Dim _REQUISITION_ID As String = ""
        Dim _RESERVEDATE As DateTime = New DateTime(1, 1, 1)
        Dim _DUEDATE As DateTime = New DateTime(1, 1, 1)
        Dim _RETURNDATE As DateTime = New DateTime(1, 1, 1)
        Dim _SCAN_BY As String = ""
        Dim _OFFICER_RETURN As String = ""
        Dim _RETURN_SCAN_BY As String = ""
        Dim _TAG_CODE As String = ""
        Dim _ISUPDATE_INNOVA_BORROW As String = ""
        Dim _ISUPDATE_INNOVA_RETURN As String = ""
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
        Public Property FILEBORROW_ID() As Long
            Get
                Return _FILEBORROW_ID
            End Get
            Set(ByVal value As Long)
                _FILEBORROW_ID = value
            End Set
        End Property
        Public Property RESERVE_ID() As Long
            Get
                Return _RESERVE_ID
            End Get
            Set(ByVal value As Long)
                _RESERVE_ID = value
            End Set
        End Property
        Public Property REQUISITION_ID() As String
            Get
                Return _REQUISITION_ID
            End Get
            Set(ByVal value As String)
                _REQUISITION_ID = value
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
        Public Property DUEDATE() As DateTime
            Get
                Return _DUEDATE
            End Get
            Set(ByVal value As DateTime)
                _DUEDATE = value
            End Set
        End Property
        Public Property RETURNDATE() As DateTime
            Get
                Return _RETURNDATE
            End Get
            Set(ByVal value As DateTime)
                _RETURNDATE = value
            End Set
        End Property
        Public Property SCAN_BY() As String
            Get
                Return _SCAN_BY
            End Get
            Set(ByVal value As String)
                _SCAN_BY = value
            End Set
        End Property
        Public Property OFFICER_RETURN() As String
            Get
                Return _OFFICER_RETURN
            End Get
            Set(ByVal value As String)
                _OFFICER_RETURN = value
            End Set
        End Property
        Public Property RETURN_SCAN_BY() As String
            Get
                Return _RETURN_SCAN_BY
            End Get
            Set(ByVal value As String)
                _RETURN_SCAN_BY = value
            End Set
        End Property
        Public Property TAG_CODE() As String
            Get
                Return _TAG_CODE
            End Get
            Set(ByVal value As String)
                _TAG_CODE = value
            End Set
        End Property
        Public Property ISUPDATE_INNOVA_BORROW() As String
            Get
                Return _ISUPDATE_INNOVA_BORROW
            End Get
            Set(ByVal value As String)
                _ISUPDATE_INNOVA_BORROW = value
            End Set
        End Property
        Public Property ISUPDATE_INNOVA_RETURN() As String
            Get
                Return _ISUPDATE_INNOVA_RETURN
            End Get
            Set(ByVal value As String)
                _ISUPDATE_INNOVA_RETURN = value
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

Namespace Table
    'Represents a transaction for TB_REQUISTION table Parameter.
    '[Create by  on April, 18 2014]
    Public Class TbRequisitionData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _REQ_NO As String = ""
        Dim _APP_NO As String = ""
        Dim _APP_NAME As String = ""
        Dim _APP_POSITION As String = ""
        Dim _APP_STATUS As String = ""
        Dim _MAINREQ As String = ""
        Dim _PUBLICNO As String = ""
        Dim _PATENTNO As String = ""
        Dim _AVAILABLE As String = ""
        Dim _LOCKOFFICER As String = ""
        Dim _PATENT_TYPE_ID As Long = 0
        Dim _QTY As Integer = 0
        Dim _SHELF_NAME As String = ""
        Dim _LOCATION As String = ""
        Dim _STATUS As String = ""
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
        Public Property REQ_NO() As String
            Get
                Return _REQ_NO
            End Get
            Set(ByVal value As String)
                _REQ_NO = value
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
        Public Property APP_NAME() As String
            Get
                Return _APP_NAME
            End Get
            Set(ByVal value As String)
                _APP_NAME = value
            End Set
        End Property
        Public Property APP_POSITION() As String
            Get
                Return _APP_POSITION
            End Get
            Set(ByVal value As String)
                _APP_POSITION = value
            End Set
        End Property
        Public Property APP_STATUS() As String
            Get
                Return _APP_STATUS
            End Get
            Set(ByVal value As String)
                _APP_STATUS = value
            End Set
        End Property
        Public Property MAINREQ() As String
            Get
                Return _MAINREQ
            End Get
            Set(ByVal value As String)
                _MAINREQ = value
            End Set
        End Property
        Public Property PUBLICNO() As String
            Get
                Return _PUBLICNO
            End Get
            Set(ByVal value As String)
                _PUBLICNO = value
            End Set
        End Property
        Public Property PATENTNO() As String
            Get
                Return _PATENTNO
            End Get
            Set(ByVal value As String)
                _PATENTNO = value
            End Set
        End Property
        Public Property AVAILABLE() As String
            Get
                Return _AVAILABLE
            End Get
            Set(ByVal value As String)
                _AVAILABLE = value
            End Set
        End Property
        Public Property LOCKOFFICER() As String
            Get
                Return _LOCKOFFICER
            End Get
            Set(ByVal value As String)
                _LOCKOFFICER = value
            End Set
        End Property
        Public Property PATENT_TYPE_ID() As Long
            Get
                Return _PATENT_TYPE_ID
            End Get
            Set(ByVal value As Long)
                _PATENT_TYPE_ID = value
            End Set
        End Property
        Public Property QTY() As Integer
            Get
                Return _QTY
            End Get
            Set(ByVal value As Integer)
                _QTY = value
            End Set
        End Property
        Public Property SHELF_NAME() As String
            Get
                Return _SHELF_NAME
            End Get
            Set(ByVal value As String)
                _SHELF_NAME = value
            End Set
        End Property
        Public Property LOCATION() As String
            Get
                Return _LOCATION
            End Get
            Set(ByVal value As String)
                _LOCATION = value
            End Set
        End Property
        Public Property STATUS() As String
            Get
                Return _STATUS
            End Get
            Set(ByVal value As String)
                _STATUS = value
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
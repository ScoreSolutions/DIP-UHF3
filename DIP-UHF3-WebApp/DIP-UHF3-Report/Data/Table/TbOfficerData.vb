
Namespace Table
    'Represents a transaction for TB_OFFICER table Data.
    '[Create by  on January, 13 2011]
    Public Class TbOfficerData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _OFFICER_NO As String = ""
        Dim _FNAME As String = ""
        Dim _LNAME As String = ""
        Dim _DEPARTMENT_ID As Long = 0
        Dim _POSITION_ID As Long = 0
        Dim _USERNAME As String = ""
        Dim _PASSWORD As String = ""
        Dim _CREATEBY As String = ""
        Dim _CREATEON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATEBY As String = ""
        Dim _UPDATEON As DateTime = New DateTime(1, 1, 1)
        Dim _TITLE_ID As Long = 0
        Dim _MIFARE_CARD_ID As String = ""

        'Generate Field Property 
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        Public Property OFFICER_NO() As String
            Get
                Return _OFFICER_NO
            End Get
            Set(ByVal value As String)
                _OFFICER_NO = value
            End Set
        End Property
        Public Property FNAME() As String
            Get
                Return _FNAME
            End Get
            Set(ByVal value As String)
                _FNAME = value
            End Set
        End Property
        Public Property LNAME() As String
            Get
                Return _LNAME
            End Get
            Set(ByVal value As String)
                _LNAME = value
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
        Public Property USERNAME() As String
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As String)
                _USERNAME = value
            End Set
        End Property
        Public Property PASSWORD() As String
            Get
                Return _PASSWORD
            End Get
            Set(ByVal value As String)
                _PASSWORD = value
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
        Public Property TITLE_ID() As Long
            Get
                Return _TITLE_ID
            End Get
            Set(ByVal value As Long)
                _TITLE_ID = value
            End Set
        End Property
        Public Property MIFARE_CARD_ID() As String
            Get
                Return _MIFARE_CARD_ID
            End Get
            Set(ByVal value As String)
                _MIFARE_CARD_ID = value
            End Set
        End Property
    End Class
End Namespace
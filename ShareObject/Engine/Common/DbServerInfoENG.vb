Namespace Common
    Public Class DbServerInfoENG
        Dim _DbServerIP As String = ""
        Dim _DbDatabaseName As String = ""
        Dim _DbUserID As String = ""
        Dim _DbPassword As String = ""

        Public Property DbServerIP As String
            Get
                Return _DbServerIP.Trim
            End Get
            Set(value As String)
                _DbServerIP = value
            End Set
        End Property

        Public Property DbDatabaseName As String
            Get
                Return _DbDatabaseName.Trim
            End Get
            Set(value As String)
                _DbDatabaseName = value
            End Set
        End Property

        Public Property DbUserID As String
            Get
                Return _DbUserID.Trim
            End Get
            Set(value As String)
                _DbUserID = value
            End Set
        End Property

        Public Property DbPassword As String
            Get
                Return _DbPassword.Trim
            End Get
            Set(value As String)
                _DbPassword = value
            End Set
        End Property

    End Class
End Namespace


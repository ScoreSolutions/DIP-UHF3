Imports System.Data.SqlClient

Namespace ConnectDB
    Public Class PatentSqlDB : Inherits SqlDB

#Region "Get Connection String"
        Protected Shared ReadOnly Property INIFileName() As IniReader
            Get
                Dim INIFlie As String = "C:\Windows\DIP-UHF3.ini"
                Dim ini As New IniReader(INIFlie)
                ini.Section = "PATENTDB"
                Return ini
            End Get
        End Property

        Private Shared ReadOnly Property GetConnectionString() As String
            Get
                Try
                    Dim ini As IniReader = INIFileName
                    Dim DBServerName As String = ini.ReadString("DBServerName")
                    Dim DBDatabaseName As String = ini.ReadString("DBDatabaseName")
                    Dim DBDbUserID As String = ini.ReadString("DBDbUserID")
                    Dim DBDbPwd As String = DeCripPwd(ini.ReadString("DBDbPwd"))
                    ini = Nothing

                    Dim ret As String = "Data Source=" & DBServerName & ";Initial Catalog=" & DBDatabaseName & ";User ID=" & DBDbUserID & ";Password=" & DBDbPwd

                    Return ret
                Catch ex As Exception
                    Throw New ApplicationException(ErrorConnectionString, ex)
                End Try
            End Get
        End Property

        Public Overloads Shared Function GetConnection() As SqlConnection
            Return GetConnection(GetConnectionString)
        End Function


        Public Overloads Shared Function ChkConnection() As Boolean
            Return ChkConnection(GetConnectionString)
        End Function
#End Region

        Friend Overloads Shared Function GetNextID(ByVal fldName As String, ByVal tbName As String, ByVal trans As SqlTransaction) As Long
            Return GetNextID(fldName, tbName, trans, GetConnectionString)
        End Function

        Friend Overloads Shared Function GetLastID(ByVal tbName As String, ByVal trans As SqlTransaction) As Long
            Return GetLastID(tbName, trans, GetConnectionString)
        End Function

#Region "Execute Table"
        Public Overloads Shared Function ExecuteTable(ByVal sql As String) As DataTable
            Return ExecuteTable(sql, GetConnection(), Nothing, Nothing)
        End Function
        Public Overloads Shared Function ExecuteTable(ByVal sql As String, cmdParam() As SqlParameter) As DataTable
            Return ExecuteTable(sql, GetConnection(), Nothing, cmdParam)
        End Function
        Public Overloads Shared Function ExecuteTable(ByVal sql As String, ByVal conn As SqlConnection) As DataTable
            Return ExecuteTable(sql, conn, Nothing, Nothing)
        End Function
        Public Overloads Shared Function ExecuteTable(ByVal sql As String, ByVal trans As SqlTransaction) As DataTable
            Return ExecuteTable(sql, GetConnection(), trans, Nothing)
        End Function
        Public Overloads Shared Function ExecuteTable(ByVal sql As String, ByVal trans As SqlTransaction, cmdParam() As SqlParameter) As DataTable
            Return ExecuteTable(sql, Nothing, trans, cmdParam, GetConnectionString)
        End Function
        Public Overloads Shared Function ExecuteTable(ByVal sql As String, conn As SqlConnection, ByVal trans As SqlTransaction, cmdParam() As SqlParameter) As DataTable
            Return ExecuteTable(sql, conn, trans, cmdParam, GetConnectionString)
        End Function
#End Region

#Region "Execute Non Query"
        Public Overloads Shared Function ExecuteNonQuery(ByVal Sql As String) As Boolean
            Return ExecuteNonQuery(Sql, Nothing, Nothing, Nothing)
        End Function
        Public Overloads Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal conn As SqlConnection) As Boolean
            Return ExecuteNonQuery(Sql, conn, Nothing, Nothing)
        End Function
        Public Overloads Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal trans As SqlTransaction) As Boolean
            Return ExecuteNonQuery(Sql, Nothing, trans, Nothing)
        End Function
        Public Overloads Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal trans As SqlTransaction, ByVal cmdParms() As SqlParameter) As Boolean
            Return ExecuteNonQuery(Sql, Nothing, trans, cmdParms)
        End Function
        Public Overloads Shared Function ExecuteNonQuery(ByVal Sql As String, conn As SqlConnection, ByVal trans As SqlTransaction, ByVal cmdParms() As SqlParameter) As Boolean
            Return ExecuteNonQuery(Sql, conn, trans, cmdParms, GetConnectionString)
        End Function
#End Region

#Region "Execute Reader"
        Public Overloads Shared Function ExecuteReader(ByVal Sql As String) As SqlDataReader
            Return ExecuteReader(Sql, Nothing, Nothing)
        End Function
        Public Overloads Shared Function ExecuteReader(ByVal Sql As String, ByVal trans As SqlTransaction) As SqlDataReader
            Return ExecuteReader(Sql, Nothing, trans)
        End Function

        Public Overloads Shared Function ExecuteReader(ByVal Sql As String, ByVal conn As SqlConnection) As SqlDataReader
            Return ExecuteReader(Sql, conn, Nothing)
        End Function
        Public Overloads Shared Function ExecuteReader(ByVal Sql As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SqlDataReader
            Return ExecuteReader(Sql, conn, trans, GetConnectionString)
        End Function
#End Region


    End Class


End Namespace


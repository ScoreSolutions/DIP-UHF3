Imports Microsoft.VisualBasic
Imports System.Data

Public Class Globals
    Public Shared uData As New LinqDB.ConnectDB.LoginSession()
    Public Shared GUserName As String

    Public Shared DSet As New DataSet("Data")
    Public Shared Serverip As String
    Public Shared PathFile As String
End Class


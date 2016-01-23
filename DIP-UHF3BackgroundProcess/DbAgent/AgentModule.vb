Imports DbAgent.Org.Mentalis.Files
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.Data
Imports System.Threading

Module AgentModule
    Private logPath As String = "Logs"
    Public INIfName As String = Windows.Forms.Application.StartupPath & "\Agent.ini"
    Public StrconnInnova As String = ""
    Public StrconnScore As String = ""

#Region "FromDBAgent"


    Public Function formatConnectionString(ByVal argIP As String, ByVal argDB As String, ByVal argUser As String, ByVal argPassword As String) As String
        Return "Data Source=" & argIP & ";Initial Catalog=" & argDB & ";Persist Security Info=True;User ID=" & argUser & ";Password=" & argPassword
    End Function

    Function GetConnectionString(ByVal Database As Int32) As String
        Dim txt As String = ""
        If Dir(INIfName) <> "" Then
            Dim ini As New IniReader(INIfName)
            ini.Section = "DIP"
            If Database = 1 Then
                txt = formatConnectionString(ini.ReadString("Server1"), ini.ReadString("Database1"), ini.ReadString("Username1"), ini.ReadString("Password1"))
            ElseIf Database = 2 Then
                txt = formatConnectionString(ini.ReadString("Server2"), ini.ReadString("Database2"), ini.ReadString("Username2"), ini.ReadString("Password2"))
            End If
        End If
        Return txt
    End Function


    Function fixData(ByVal arg As Object) As String
        If IsDBNull(arg) Then Return ""
        Return Replace(arg.ToString, "'", "''")
    End Function

    Public Function fixDate(ByVal argTXT As String) As String
        Dim d As String = ""
        Dim m As String = ""
        Dim y As String = ""
        If IsDate(argTXT) Then
            Dim dmy As Date = CDate(argTXT)
            d = dmy.Day
            m = dmy.Month
            y = dmy.Year
            If y > 2500 Then
                y = y - 543
            End If
            Return y.ToString & m.ToString.PadLeft(2, "0") & d.ToString.PadLeft(2, "0")
        Else
            Return ""
        End If
    End Function

    Public Function fixDateTime(ByVal argTXT As String) As String
        Dim txt As String = ""
        If IsDate(argTXT) Then
            txt = fixDate(argTXT) & " " & CDate(argTXT).ToLongTimeString
        End If
        Return txt
    End Function

    Public Function fixDateMT(ByVal argTXT As String) As String
        Dim d As String = ""
        Dim m As String = ""
        Dim y As String = ""
        If IsDate(argTXT) Then
            Dim dmy As Date = CDate(argTXT)
            d = dmy.Day
            m = dmy.Month
            y = dmy.Year
            If y > 2500 Then
                y = y - 543
            End If
            Return y.ToString & "-" & m.ToString.PadLeft(2, "0") & "-" & d.ToString.PadLeft(2, "0")
        Else
            Return ""
        End If
    End Function

    Function WriteLogFile(ByVal txt As TextBox, Optional ByVal lfileName As String = "QLog_") As String
        Dim ret As String = ""
        If Len(txt.Text) > 0 Then
            Dim path As String = Application.StartupPath & "\" & logPath & "\"
            Try
                If Dir(path) = "" Then
                    MkDir(path)
                End If
                Dim fName As String = path & lfileName & fixDate(Now.Date) & "-" & Guid.NewGuid.ToString & ".txt"
                Dim f As New FileStream(fName, FileMode.Create, FileAccess.Write)
                f.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(txt.Text), 0, Len(txt.Text))
                f.Close()
                ret = "*** LogFile writen Successfully! ***"
            Catch ex As Exception
                ret = "[WRITELOG] - " & ex.Message
            End Try
        Else
            ret = ""
        End If
        Return ret
    End Function


    Public Function getVersion()
        Dim VersionNo As System.Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
        Return VersionNo.Major & "." & VersionNo.Minor & "." & VersionNo.Build
    End Function

    Function LeftJoin(ByVal First As DataTable, ByVal Second As DataTable, ByVal FJC As String, ByVal SJC As String) As DataTable
        Return LeftJoin(First, Second, New DataColumn() {First.Columns.Item(FJC)}, New DataColumn() {First.Columns.Item(SJC)})
    End Function

    Function LeftJoin(ByVal First As DataTable, ByVal Second As DataTable, ByVal FJC As DataColumn(), ByVal SJC As DataColumn()) As DataTable
        Dim table As New DataTable("Join")
        Using ds As DataSet = New DataSet
            ds.Tables.AddRange(New DataTable() {First.Copy, Second.Copy})
            Dim parentcolumns As DataColumn() = New DataColumn(FJC.Length - 1) {}
            Dim i As Integer
            For i = 0 To parentcolumns.Length - 1
                parentcolumns(i) = ds.Tables.Item(0).Columns.Item(FJC(i).ColumnName)
            Next i
            Dim childcolumns As DataColumn() = New DataColumn(SJC.Length - 1) {}
            'Dim i As Integer
            For i = 0 To childcolumns.Length - 1
                childcolumns(i) = ds.Tables.Item(1).Columns.Item(SJC(i).ColumnName)
            Next i
            Dim r As New DataRelation(String.Empty, parentcolumns, childcolumns, False)
            ds.Relations.Add(r)
            'Dim i As Integer
            For i = 0 To First.Columns.Count - 1
                table.Columns.Add(First.Columns.Item(i).ColumnName, First.Columns.Item(i).DataType)
            Next i
            'Dim i As Integer
            For i = 0 To Second.Columns.Count - 1
                If Not table.Columns.Contains(Second.Columns.Item(i).ColumnName) Then
                    table.Columns.Add(Second.Columns.Item(i).ColumnName, Second.Columns.Item(i).DataType)
                Else
                    table.Columns.Add((Second.Columns.Item(i).ColumnName & "_Second"), Second.Columns.Item(i).DataType)
                End If
            Next i
            table.BeginLoadData()
            Dim firstrow As DataRow
            For Each firstrow In ds.Tables.Item(0).Rows
                Dim childrows As DataRow() = firstrow.GetChildRows(r)
                If ((Not childrows Is Nothing) AndAlso (childrows.Length > 0)) Then
                    Dim parentarray_ As Object() = firstrow.ItemArray
                    Dim secondrow As DataRow
                    For Each secondrow In childrows
                        Dim secondarray As Object() = secondrow.ItemArray
                        Dim joinarray_ As Object() = New Object((parentarray_.Length + secondarray.Length) - 1) {}
                        Array.Copy(parentarray_, 0, joinarray_, 0, parentarray_.Length)
                        Array.Copy(secondarray, 0, joinarray_, parentarray_.Length, secondarray.Length)
                        table.LoadDataRow(joinarray_, True)
                    Next
                    Continue For
                End If
                Dim parentarray As Object() = firstrow.ItemArray
                Dim joinarray As Object() = New Object(parentarray.Length - 1) {}
                Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length)
                table.LoadDataRow(joinarray, True)
            Next
            table.EndLoadData()
        End Using
        Return table
    End Function

#End Region

End Module


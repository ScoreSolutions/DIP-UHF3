Imports System
Imports System.Web
Imports System.Web.Security
Imports System.Data
Imports System.Linq
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace Web_Config
    Public Class TEMPFILEeng

        Public Shared Function GetFileListOnDrive(DriveLetter As String, LoginHistoryID As Long) As DataTable
            Dim dt As DataTable
            Try
                Dim sql As String = "select f.id, f.ServerIP, f.PathFile,  f.FileSizeGB, "
                sql += " case f.DisplayType "
                sql += " when 'D' then 'Folder' "
                sql += " when 'F' then 'File'"
                sql += " end as DisplayType"
                sql += " from TB_TEMP_FILE f"
                sql += " inner join TB_LOAD_TEMP_PATH tp on tp.id=f.tb_load_temp_path_id"
                sql += " where tp.ts_login_history_id='" & LoginHistoryID & "' and SUBSTRING(f.PathFile,1,1) = '" & DriveLetter & "'"
                sql += " and tp.PathFile='ROOT'"
                sql += " order by f.DisplayType, f.PathFile"

                dt = Engine.Common.FunctionEng.ExecuteDataTable(sql)
                If dt.Rows.Count > 0 Then
                    dt.Columns.Add("PathArgs")
                    dt.Columns.Add("no", GetType(Long))

                    For i As Integer = 0 To dt.Rows.Count - 1
                        dt.Rows(i)("no") = (i + 1)
                        dt.Rows(i)("PathArgs") = dt.Rows(i)("PathFile") & "##" & dt.Rows(i)("DisplayType")
                    Next
                End If
            Catch ex As Exception
                dt = New DataTable
            End Try
            Return dt
        End Function

        Public Shared Function getgvPathFile(ByVal PathFile As String, LoginHistoryID As Long) As DataTable
            Dim dt As DataTable
            Try
                Dim sql As String = "select f.id, f.ServerIP, f.PathFile,  f.FileSizeGB, "
                sql += " case f.DisplayType "
                sql += " when 'D' then 'Folder' "
                sql += " when 'F' then 'File'"
                sql += " end as DisplayType"
                sql += " from TB_TEMP_FILE f"
                sql += " inner join TB_LOAD_TEMP_PATH tp on tp.id=f.tb_load_temp_path_id"
                sql += " where tp.ts_login_history_id='" & LoginHistoryID & "' and SUBSTRING(f.PathFile,1," & PathFile.Length & ") = '" & PathFile & "'"
                sql += " and f.PathFile<>'" & PathFile & "'"
                sql += " order by f.DisplayType, f.PathFile"

                dt = Engine.Common.FunctionEng.ExecuteDataTable(sql)

                If dt.Rows.Count > 0 Then
                    dt.Columns.Add("PathArgs")
                    dt.Columns.Add("no", GetType(Long))

                    For i As Integer = 0 To dt.Rows.Count - 1
                        dt.Rows(i)("no") = (i + 1)
                        dt.Rows(i)("PathArgs") = dt.Rows(i)("PathFile") & "##" & dt.Rows(i)("DisplayType")
                    Next
                End If
            Catch ex As Exception
                dt = New DataTable
            End Try
            Return dt
        End Function

        Public Shared Function CheckLoadPathFile(ByVal PathFile As String, LoginHistoryID As Long) As String
            Dim ret As String = "False"
            Try
                Dim sql As String = "select id "
                sql += " from TB_LOAD_TEMP_PATH "
                sql += " where ts_login_history_id='" & LoginHistoryID & "' and PathFile = '" & PathFile & "'"
                sql += " and Status='Y'"

                Dim dt As DataTable = Engine.Common.FunctionEng.ExecuteDataTable(sql)
                If dt.Rows.Count > 0 Then
                    ret = "True"
                End If
                dt.Dispose()
            Catch ex As Exception
                ret = "False: Exception " & ex.Message & vbNewLine & ex.StackTrace
            End Try
            Return ret
        End Function

        Public Shared Function DeleteAllTempFile(ServerIP As String) As String
            Dim ret As String = "True"
            Try
                Dim sql As String = "delete from TB_TEMP_FILE where  ServerIP='" & ServerIP & "'"
                SqlDB.ExecuteNonQuery(sql)
            Catch ex As Exception
                ret = "False: Exception " & ex.Message & "  " & ex.StackTrace
            End Try

            Return ret
        End Function


        Public Function GetIDTempFile(ByVal wh As String) As String
            Dim dt As New DataTable
            Dim lnq As New TbTempFileLinqDB
            Dim sql As String = ""
            Dim id As String
            Dim trans As New TransactionDB

            'If wh <> "" Then
            '    wh = "and " & wh
            'End If

            sql = "select id,ServerIP,PathFile,FileSizeGB from TB_TEMP_FILE "
            sql += " where serverip = '" & wh & "'"

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            If dt.Rows.Count > 0 Then
                id = dt.Rows(0)(0).ToString
            Else
                id = "0"
            End If

            Return id
        End Function

        

        Public Function tbFileSize(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            'Dim trans As New TransactionDB
            Dim lnq As New TbTempFileLinqDB

            Dim sql As String

            If wh <> "" Then
                wh = " and " & wh
            End If

            sql = "select id,ServerIP,PathFile,FileSizeGB,Status from TB_TEMP_FILE where 1=1"
            sql += wh
            dt = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing

            Return dt
        End Function

        Public Shared Sub DeleteTempFile(LoginHistoryID As String)
            Try
                Dim sql As String = "delete from tb_temp_file "
                sql += " where tb_load_temp_path_id='" & LoginHistoryID & "'"

                SqlDB.ExecuteNonQuery(sql)
            Catch ex As Exception

            End Try
        End Sub

    End Class

End Namespace


Imports System.Data
Imports LinqDB.TABLE
Imports LinqDB.ConnectDB

Namespace Web_Config
    Public Class RegisterENG
        Public Function GetRegisterByID(ID As String) As DataTable
            Dim dt As New DataTable

            Dim lnq As New LinqDB.TABLE.TbRegisterLinqDB
            Dim sql As String = "select ID,ServerIP,ServerName,OS,Active_Status,E_mail,Fname,Lname,System_Type,group_id,"
            sql += " MacAddress,LocationServer,LocationNo,online_status,today_alailable from TB_REGISTER where id ='" & ID & "'"
            dt = lnq.GetListBySql(sql, Nothing)
           
            Return dt
        End Function
    End Class
End Namespace


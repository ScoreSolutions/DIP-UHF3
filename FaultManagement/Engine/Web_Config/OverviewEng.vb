Imports System.Data
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.IO


Namespace Web_Config
    Public Class OverviewEng

      
        Public Function GetgvRegister(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = ("Select id,ServerIP,ServerName,MacAddress,OS,System_Type,(LocationServer +'/'+LocationNo) as Locate_No ")
            sql += (" ,Fname + '  ' + Lname as name ,E_mail from TB_REGISTER where TB_REGISTER.Active_Status = 'Y' ") + wh
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetgvServerList(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB
            Dim sql As String
            sql = ("Select TB_REGISTER.id,ServerIP,ServerName,MacAddress,OS,System_Type ")
            sql += (" ,case when LocationServer = '' then '-/'+LocationNo ")
            sql += (" else case when LocationNo = '' then LocationServer +'/-' ")
            sql += (" else case when LocationServer <> '' and LocationNo <> '' then ")
            sql += (" (LocationServer +'/'+LocationNo) end end end as Locate_No , Fname + '  ' + Lname as name ")
            sql += (" ,E_mail from TB_REGISTER join TB_GROUP on TB_REGISTER.group_id = TB_GROUP.id where TB_GROUP.group_desc = '" & wh & "' and  TB_REGISTER.Active_Status = 'Y' ")
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetgvMGroup(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbGroupLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = ("select TG.group_desc ,Count(TR.id) as Qty  from TB_GROUP TG ")
            sql += (" left join TB_REGISTER TR on TG .id = tr.group_id where group_desc <> 'NoGroup' and TR.active_status = 'Y' group by group_desc ") + wh
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function


        Public Function GetgvRecent(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = ("Select Top 50 AW.ServerName , AW.SpecificProblem ,Severity , AW.AlarmQty , AW.CreatedDate")
            sql += (" ,case when AW.AlarmActivity = 'Process' then AW.AlarmValue")
            sql += (" else case when AW.AlarmActivity = 'Service' then AW.AlarmValue ")
            sql += (" else case when AW.AlarmActivity = 'File' then  Convert(Varchar(255),AW.AlarmValue)+' GB' ")
            sql += (" else case when AW.AlarmActivity = 'Port' then AW.AlarmValue ")
            sql += (" else case when AW.AlarmActivity <> 'Process' and AW.AlarmActivity <> 'Service' then  Convert(Varchar(255),AW.AlarmValue)+' %' end end end end end as PercentValue ")
            sql += (" from TB_ALARM_WAITING_CLEAR AW ")
            sql += (" where AW.FlagAlarm <> 'Clear' and isnull(AW.AlarmValue,'') <> 'Not_Service' ")
            sql += (" Order by AW.CreatedDate DESC") + wh
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

    End Class
End Namespace


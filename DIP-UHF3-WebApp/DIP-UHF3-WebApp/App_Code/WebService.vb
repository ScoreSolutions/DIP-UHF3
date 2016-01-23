Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.Data
Imports System.IO
Imports System.Globalization

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebService
    Inherits System.Web.Services.WebService


#Region "Document Search"
    <WebMethod()> _
    Public Function LoadSearchFileLocation(app_no As String, _
                                           datefrom As String, _
                                           dateto As String, _
                                           borrowername As String, _
                                           statusname As String, _
                                           patenttypeid As String, _
                                           isshow As String) As String
        Try
            Dim strdata As String
            Dim strSql As New StringBuilder
            strSql.Append(" select T.*,isnull(F.color,'') color from (")
            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY table1.realdate desc) AS no, table1.* from (  ")
            strSql.Append(" select   ")
            strSql.Append(" r.id ")
            strSql.Append(" ,convert(varchar, dateadd(year,0,r.reserve_date),103) + ' ' + left(convert(varchar, r.reserve_date,108),5)  as move_date ")
            strSql.Append(" ,rq.app_no ")
            strSql.Append(" ,r.member_name as borrowname ")
            strSql.Append(" ,'จองผ่านระบบ ePattent' as location_name  ")
            strSql.Append(" ,r.reserve_date as realdate  ")
            strSql.Append(" ,s.status_name   ")
            strSql.Append(" ,p.patent_type_name,'0' as ms_floor_id  ")
            strSql.Append(" from tb_reserve  r ")
            strSql.Append(" inner join tb_requistion rq ")
            strSql.Append(" on rq.id  =r.requidition_id ")
            strSql.Append(" left join tb_status s  ")
            strSql.Append(" on s.id = rq.app_status ")
            strSql.Append(" inner join tb_patent_type p ")
            strSql.Append(" on p.id = rq.patent_type_id  ")
            strSql.Append(" where borrowstatus='S' ")
            If app_no <> "" Then
                strSql.Append(" and rq.app_no='" & app_no & "'")
            End If
            If datefrom <> "" And dateto <> "" Then
                strSql.Append(" and convert(varchar, r.reserve_date,112)  between CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(datefrom) & "')  and CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(dateto) & "')")
            End If

            If borrowername <> "" Then
                strSql.Append(" and r.member_name like '%" & borrowername & "%'")
            End If
            If statusname <> "" Then
                strSql.Append(" and s.status_name = '" & statusname & "'")
            End If
            If patenttypeid <> "" Then
                strSql.Append(" and rq.patent_type_id = '" & patenttypeid & "'")
            End If

            strSql.Append(" union  ")
            strSql.Append(" select  ")
            strSql.Append(" fbi.id  ")
            strSql.Append(" ,convert(varchar, dateadd(year,0,fb.borrowerdate ),103) + ' ' + left(convert(varchar, fb.borrowerdate ,108),5)  as move_date ")
            strSql.Append(" ,rq.app_no   ")
            strSql.Append(" ,fb.borrowername as borrowname  ")
            strSql.Append(" ,isnull(fl.location_name,'แฟ้มได้ถูกยืมจากห้องแฟ้มชั้น 6') as location_name   ")
            strSql.Append(" ,fb.borrowerdate as realdate  ")
            strSql.Append("  ,s.status_name   ")
            strSql.Append("  ,p.patent_type_name,'6' as ms_floor_id  ")
            strSql.Append(" from tb_fileborrow fb  ")
            strSql.Append(" inner join tb_fileborrowitem fbi  ")
            strSql.Append(" on fb.id = fbi.fileborrow_id  ")
            strSql.Append(" inner join tb_requistion rq  ")
            strSql.Append(" on rq.id  =fbi.requisition_id  ")
            strSql.Append(" left join tb_filelocation fl  ")
            strSql.Append(" on fl.id  =fb.tb_filelocation_id  ")
            strSql.Append(" left join tb_status s  ")
            strSql.Append(" on s.id = rq.app_status ")
            strSql.Append(" inner join tb_patent_type p ")
            strSql.Append(" on p.id = rq.patent_type_id  ")
            strSql.Append(" where 1=1")
            If app_no <> "" Then
                strSql.Append(" and rq.app_no='" & app_no & "'")
            End If
            If datefrom <> "" And dateto <> "" Then
                strSql.Append(" and convert(varchar, fb.borrowerdate,112)  between CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(datefrom) & "')  and CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(dateto) & "')")
            End If

            If borrowername <> "" Then
                strSql.Append(" and fb.borrowername like '%" & borrowername & "%'")
            End If
            If statusname <> "" Then
                strSql.Append(" and s.status_name = '" & statusname & "'")
            End If
            If patenttypeid <> "" Then
                strSql.Append(" and rq.patent_type_id = '" & patenttypeid & "'")
            End If

            strSql.Append("  union  ")
            strSql.Append("  select")
            strSql.Append("  fvh.id ")
            strSql.Append("  ,convert(varchar, dateadd(year,0,fvh.move_date),103) + ' ' + left(convert(varchar, fvh.move_date,108),5)  as move_date  ")
            strSql.Append("  ,fvh.app_no")
            strSql.Append("  ,isnull(t.title_name,'') + o.fname + ' ' + o.lname  as borrowname ")
            strSql.Append("  ,fvh.location_name  ")
            strSql.Append("  ,fvh.move_date as realdate  ")
            strSql.Append("  ,s.status_name   ")
            strSql.Append("  ,p.patent_type_name,ms_floor_id  ")
            strSql.Append("  from ts_file_move_history fvh  ")
            strSql.Append("  inner join tb_officer o")
            strSql.Append("  on o.id = fvh.tb_officer_id")
            strSql.Append("  left join tb_title t")
            strSql.Append("  on t.id=o.title_id")
            strSql.Append("  inner join tb_requistion rq")
            strSql.Append("  on rq.app_no = fvh.app_no")
            strSql.Append("  left join tb_status s ")
            strSql.Append("  on s.id = rq.app_status")
            strSql.Append("  inner join tb_patent_type p")
            strSql.Append("  on p.id = rq.patent_type_id")
            strSql.Append("  left join MS_ROOM r on fvh.ms_room_id = r.id")
            strSql.Append("  where 1=1  ")
            If app_no <> "" Then
                strSql.Append(" and fvh.app_no='" & app_no & "'")
            End If
            If datefrom <> "" And dateto <> "" Then
                strSql.Append(" and convert(varchar, fvh.move_date,112)  between CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(datefrom) & "')  and CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(dateto) & "')")
            End If

            If borrowername <> "" Then
                strSql.Append(" and( isnull(t.title_name,'') + o.fname + ' ' + o.lname) like '%" & borrowername & "%'")
            End If
            If statusname <> "" Then
                strSql.Append(" and s.status_name = '" & statusname & "'")
            End If
            If patenttypeid <> "" Then
                strSql.Append(" and rq.patent_type_id = '" & patenttypeid & "'")
            End If

            strSql.Append("   ) as table1  where 1=" & isshow)
            strSql.Append(" )T Left Join MS_FLOOR F ON T.ms_floor_id = F.id")
            strSql.Append("   order by  realdate  desc  ")

            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    <WebMethod()> _
    Public Function GetSearchFileLocationToDatatable(app_no As String, _
                                           datefrom As String, _
                                           dateto As String, _
                                           borrowername As String, _
                                           statusname As String, _
                                           patenttypeid As String, _
                                           isshow As String) As DataTable
        Try
            Dim strSql As New StringBuilder
            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY table1.realdate desc) AS no, table1.* from (  ")
            strSql.Append(" select   ")
            strSql.Append(" r.id ")
            strSql.Append(" ,convert(varchar, dateadd(year,0,r.reserve_date),103) + ' ' + left(convert(varchar, r.reserve_date,108),5)  as move_date ")
            strSql.Append(" ,rq.app_no ")
            strSql.Append(" ,r.member_name as borrowname ")
            strSql.Append(" ,'จองผ่านระบบ ePattent' as location_name  ")
            strSql.Append(" ,r.reserve_date as realdate  ")
            strSql.Append(" ,s.status_name   ")
            strSql.Append(" ,p.patent_type_name  ")
            strSql.Append(" from tb_reserve  r ")
            strSql.Append(" inner join tb_requistion rq ")
            strSql.Append(" on rq.id  =r.requidition_id ")
            strSql.Append(" left join tb_status s  ")
            strSql.Append(" on s.id = rq.app_status ")
            strSql.Append(" inner join tb_patent_type p ")
            strSql.Append(" on p.id = rq.patent_type_id  ")
            strSql.Append(" where borrowstatus='S' ")
            If app_no <> "" Then
                strSql.Append(" and rq.app_no='" & app_no & "'")
            End If
            If datefrom <> "" And dateto <> "" Then
                strSql.Append(" and convert(varchar, r.reserve_date,112)  between CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(datefrom) & "')  and CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(dateto) & "')")
            End If

            If borrowername <> "" Then
                strSql.Append(" and r.member_name like '%" & borrowername & "%'")
            End If
            If statusname <> "" Then
                strSql.Append(" and s.status_name = '" & statusname & "'")
            End If
            If patenttypeid <> "" Then
                strSql.Append(" and rq.patent_type_id = '" & patenttypeid & "'")
            End If

            strSql.Append(" union  ")
            strSql.Append(" select  ")
            strSql.Append(" fbi.id  ")
            strSql.Append(" ,convert(varchar, dateadd(year,0,fb.borrowerdate ),103) + ' ' + left(convert(varchar, fb.borrowerdate ,108),5)  as move_date ")
            strSql.Append(" ,rq.app_no   ")
            strSql.Append(" ,fb.borrowername as borrowname  ")
            strSql.Append(" ,isnull(fl.location_name,'แฟ้มได้ถูกยืมจากห้องแฟ้มชั้น 6') as location_name   ")
            strSql.Append(" ,fb.borrowerdate as realdate  ")
            strSql.Append("  ,s.status_name   ")
            strSql.Append("  ,p.patent_type_name  ")
            strSql.Append(" from tb_fileborrow fb  ")
            strSql.Append(" inner join tb_fileborrowitem fbi  ")
            strSql.Append(" on fb.id = fbi.fileborrow_id  ")
            strSql.Append(" inner join tb_requistion rq  ")
            strSql.Append(" on rq.id  =fbi.requisition_id  ")
            strSql.Append(" left join tb_filelocation fl  ")
            strSql.Append(" on fl.id  =fb.tb_filelocation_id  ")
            strSql.Append(" left join tb_status s  ")
            strSql.Append(" on s.id = rq.app_status ")
            strSql.Append(" inner join tb_patent_type p ")
            strSql.Append(" on p.id = rq.patent_type_id  ")
            strSql.Append(" where 1=1")
            If app_no <> "" Then
                strSql.Append(" and rq.app_no='" & app_no & "'")
            End If
            If datefrom <> "" And dateto <> "" Then
                strSql.Append(" and convert(varchar, fb.borrowerdate,112)  between CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(datefrom) & "')  and CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(dateto) & "')")
            End If

            If borrowername <> "" Then
                strSql.Append(" and fb.borrowername like '%" & borrowername & "%'")
            End If
            If statusname <> "" Then
                strSql.Append(" and s.status_name = '" & statusname & "'")
            End If
            If patenttypeid <> "" Then
                strSql.Append(" and rq.patent_type_id = '" & patenttypeid & "'")
            End If

            strSql.Append("  union  ")
            strSql.Append("  select")
            strSql.Append("  fvh.id ")
            strSql.Append("  ,convert(varchar, dateadd(year,0,fvh.move_date),103) + ' ' + left(convert(varchar, fvh.move_date,108),5)  as move_date  ")
            strSql.Append("  ,fvh.app_no")
            strSql.Append("  ,isnull(t.title_name,'') + o.fname + ' ' + o.lname  as borrowname ")
            strSql.Append("  ,fvh.location_name  ")
            strSql.Append("  ,fvh.move_date as realdate  ")
            strSql.Append("  ,s.status_name   ")
            strSql.Append("  ,p.patent_type_name  ")
            strSql.Append("  from ts_file_move_history fvh  ")
            strSql.Append("  inner join tb_officer o")
            strSql.Append("  on o.id = fvh.tb_officer_id")
            strSql.Append("  left join tb_title t")
            strSql.Append("  on t.id=o.title_id")
            strSql.Append("  inner join tb_requistion rq")
            strSql.Append("  on rq.app_no = fvh.app_no")
            strSql.Append("  left join tb_status s ")
            strSql.Append("  on s.id = rq.app_status")
            strSql.Append("  inner join tb_patent_type p")
            strSql.Append("  on p.id = rq.patent_type_id")
            strSql.Append("  where 1=1  ")
            If app_no <> "" Then
                strSql.Append(" and fvh.app_no='" & app_no & "'")
            End If
            If datefrom <> "" And dateto <> "" Then
                strSql.Append(" and convert(varchar, fvh.move_date,112)  between CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(datefrom) & "')  and CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(dateto) & "')")
            End If

            If borrowername <> "" Then
                strSql.Append(" and( isnull(t.title_name,'') + o.fname + ' ' + o.lname) like '%" & borrowername & "%'")
            End If
            If statusname <> "" Then
                strSql.Append(" and s.status_name = '" & statusname & "'")
            End If
            If patenttypeid <> "" Then
                strSql.Append(" and rq.patent_type_id = '" & patenttypeid & "'")
            End If

            strSql.Append("   ) as table1  where 1=" & isshow)
            strSql.Append("   order by  table1.realdate  desc  ")

            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadSearchAmountFileByLocation(floor_id As String, _
                                           patent_type_id As String, _
                                           isshow As String) As String
        Try
            Dim strdata As String
            Dim strSql As New StringBuilder
            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY f.floor_name) AS no ")
            strSql.Append(" ,f.id,f.floor_name,pt.patent_type_name,count(fcl.id) as amountfile")
            strSql.Append(" from ts_file_current_location fcl")
            strSql.Append(" inner join ms_room r")
            strSql.Append(" on r.id = fcl.ms_room_id")
            strSql.Append(" inner join ms_floor f")
            strSql.Append(" on f.id = r.ms_floor_id")
            strSql.Append(" inner join tb_requistion rq")
            strSql.Append(" on fcl.app_no = rq.app_no")
            strSql.Append(" inner join tb_patent_type pt")
            strSql.Append(" on pt.id = rq.patent_type_id")
            strSql.Append(" where 1=1")
            If floor_id <> "" Then
                strSql.Append(" and f.id='" & floor_id & "'")
            End If
            If patent_type_id <> "" Then
                strSql.Append(" and rq.patent_type_id='" & patent_type_id & "'")
            End If
            If isshow <> "" Then
                strSql.Append(" and 1=" & isshow)
            End If
            strSql.Append(" group by f.id,f.floor_name,pt.patent_type_name")
            strSql.Append(" order by f.floor_name")

            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    <WebMethod()> _
    Public Function GetSearchAmountFileByLocationToDatatable(floor_id As String, _
                                           patent_type_id As String, _
                                           isshow As String) As DataTable
        Try
            Dim strSql As New StringBuilder
            'strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY f.floor_name) AS no ")
            'strSql.Append(" ,f.id,f.floor_name,pt.patent_type_name,count(fcl.id) as amountfile")
            'strSql.Append(" from ts_file_current_location fcl")
            'strSql.Append(" inner join ms_room r")
            'strSql.Append(" on r.id = fcl.ms_room_id")
            'strSql.Append(" inner join ms_floor f")
            'strSql.Append(" on f.id = r.ms_floor_id")
            'strSql.Append(" inner join tb_requistion rq")
            'strSql.Append(" on fcl.app_no = rq.app_no")
            'strSql.Append(" inner join tb_patent_type pt")
            'strSql.Append(" on pt.id = rq.patent_type_id")
            'strSql.Append(" where 1=1")

            'If floor_id <> "" Then
            '    strSql.Append(" and r.id='" & floor_id & "'")
            'End If
            'If patent_type_id <> "" Then
            '    strSql.Append(" and rq.patent_type_id='" & patent_type_id & "'")
            'End If
            'If patent_type_id <> "" Then
            '    strSql.Append(" and 1=" & isshow)
            'End If
            'strSql.Append(" group by f.id,f.floor_name,pt.patent_type_name")
            'strSql.Append(" order by f.floor_name")


            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY f.floor_name) AS no ")
            strSql.Append(" ,f.id,f.floor_name,pt.patent_type_name,count(fcl.id) as amountfile")
            strSql.Append(" from ts_file_current_location fcl")
            strSql.Append(" inner join ms_room r")
            strSql.Append(" on r.id = fcl.ms_room_id")
            strSql.Append(" inner join ms_floor f")
            strSql.Append(" on f.id = r.ms_floor_id")
            strSql.Append(" inner join tb_requistion rq")
            strSql.Append(" on fcl.app_no = rq.app_no")
            strSql.Append(" inner join tb_patent_type pt")
            strSql.Append(" on pt.id = rq.patent_type_id")
            strSql.Append(" where 1=1")
            If floor_id <> "" Then
                strSql.Append(" and f.id='" & floor_id & "'")
            End If
            If patent_type_id <> "" Then
                strSql.Append(" and rq.patent_type_id='" & patent_type_id & "'")
            End If
            If isshow <> "" Then
                strSql.Append(" and 1=" & isshow)
            End If
            strSql.Append(" group by f.id,f.floor_name,pt.patent_type_name")
            strSql.Append(" order by f.floor_name")


            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadSearchAmountFileByStatus(status_name As String, _
                                           patent_type_id As String, _
                                           isshow As String) As String
        Try
            Dim strdata As String
            Dim strSql As New StringBuilder
            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY s.id) AS no")
            strSql.Append(" ,s.id,s.status_name,pt.patent_type_name,count(fcl.id) as amountfile")
            strSql.Append(" from ts_file_current_location fcl")
            strSql.Append(" inner join tb_requistion rq")
            strSql.Append(" on fcl.app_no = rq.app_no")
            strSql.Append(" inner join tb_status s")
            strSql.Append(" on s.id = rq.app_status")
            strSql.Append(" inner join tb_patent_type pt")
            strSql.Append(" on pt.id = rq.patent_type_id")
            strSql.Append(" where 1=1 ")
            If status_name <> "" Then
                strSql.Append(" and s.status_name='" & status_name & "'")
            End If
            If patent_type_id <> "" Then
                strSql.Append(" and rq.patent_type_id='" & patent_type_id & "'")
            End If
            If isshow <> "" Then
                strSql.Append(" and 1=" & isshow)
            End If
            strSql.Append(" group by s.id,s.status_name,pt.patent_type_name")
            strSql.Append(" order by s.status_name")


            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    <WebMethod()> _
    Public Function GetSearchAmountFileByStatusToDatatable(status_name As String, _
                                           patent_type_id As String, _
                                           isshow As String) As DataTable
        Try
            Dim strSql As New StringBuilder
            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY s.id) AS no")
            strSql.Append(" ,s.id,s.status_name,pt.patent_type_name,count(fcl.id) as amountfile")
            strSql.Append(" from ts_file_current_location fcl")
            strSql.Append(" inner join tb_requistion rq")
            strSql.Append(" on fcl.app_no = rq.app_no")
            strSql.Append(" inner join tb_status s")
            strSql.Append(" on s.id = rq.app_status")
            strSql.Append(" inner join tb_patent_type pt")
            strSql.Append(" on pt.id = rq.patent_type_id")
            strSql.Append(" where 1=1 ")
            If status_name <> "" Then
                strSql.Append(" and s.status_name='" & status_name & "'")
            End If
            If patent_type_id <> "" Then
                strSql.Append(" and rq.patent_type_id='" & patent_type_id & "'")
            End If
            If patent_type_id <> "" Then
                strSql.Append(" and 1=" & isshow)
            End If
            strSql.Append(" group by s.id,s.status_name,pt.patent_type_name")
            strSql.Append(" order by s.status_name")

            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadSearchAmountFileByDepartment(department_id As String, _
                                           username As String, _
                                           patent_type_id As String, _
                                           isshow As String) As String
        Try
            Dim strdata As String
            Dim strSql As New StringBuilder
            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY d.department_name,fcl.officer_name) AS no")
            strSql.Append(" ,fcl.tb_officer_id,fcl.officer_name ,d.department_name, pt.patent_type_name,count(fcl.id) as amountfile")
            strSql.Append(" from ts_file_current_location fcl")
            strSql.Append(" inner join tb_requistion rq")
            strSql.Append(" on fcl.app_no = rq.app_no")
            strSql.Append(" inner join tb_officer o")
            strSql.Append(" on o.id = fcl.tb_officer_id")
            strSql.Append(" inner join tb_department d")
            strSql.Append(" on d.id = o.department_id")
            strSql.Append(" inner join tb_patent_type pt")
            strSql.Append(" on pt.id = rq.patent_type_id")
            strSql.Append(" where 1=1 ")
            If department_id <> "" Then
                strSql.Append(" and o.department_id='" & department_id & "'")
            End If
            If username <> "" Then
                strSql.Append(" and fcl.officer_name like'%" & username & "%'")
            End If
            If patent_type_id <> "" Then
                strSql.Append(" and rq.patent_type_id='" & patent_type_id & "'")
            End If
            If isshow <> "" Then
                strSql.Append(" and 1=" & isshow)
            End If
            strSql.Append(" group by fcl.tb_officer_id,fcl.officer_name ,d.department_name, pt.patent_type_name")
            strSql.Append(" order by d.department_name,fcl.officer_name")
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    <WebMethod()> _
    Public Function GetSearchAmountFileByDepartmentToDatatable(department_id As String, _
                                           username As String, _
                                           patent_type_id As String, _
                                           isshow As String) As DataTable
        Try
            Dim strSql As New StringBuilder
            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY d.department_name,fcl.officer_name) AS no")
            strSql.Append(" ,fcl.tb_officer_id,fcl.officer_name ,d.department_name, pt.patent_type_name,count(fcl.id) as amountfile")
            strSql.Append(" from ts_file_current_location fcl")
            strSql.Append(" inner join tb_requistion rq")
            strSql.Append(" on fcl.app_no = rq.app_no")
            strSql.Append(" inner join tb_officer o")
            strSql.Append(" on o.id = fcl.tb_officer_id")
            strSql.Append(" inner join tb_department d")
            strSql.Append(" on d.id = o.department_id")
            strSql.Append(" inner join tb_patent_type pt")
            strSql.Append(" on pt.id = rq.patent_type_id")
            strSql.Append(" where 1=1 ")
            If department_id <> "" Then
                strSql.Append(" and o.department_id='" & department_id & "'")
            End If
            If username <> "" Then
                strSql.Append(" and fcl.officer_name like'%" & username & "%'")
            End If
            If patent_type_id <> "" Then
                strSql.Append(" and rq.patent_type_id='" & patent_type_id & "'")
            End If
            If isshow <> "" Then
                strSql.Append(" and 1=" & isshow)
            End If
            strSql.Append(" group by fcl.tb_officer_id,fcl.officer_name ,d.department_name, pt.patent_type_name")
            strSql.Append(" order by d.department_name,fcl.officer_name")


            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadSearchAmountFileByDuration(condition As String, _
                                           day As String, _
                                           time As String, _
                                           patent_type_id As String, _
                                           isshow As String) As String
        Try

            Dim countDay As Integer
            Dim DayDes As String
            Dim conditionDayDesc As String
            Dim conditionDesc As String
            Select Case time
                Case "1"
                    countDay = day * 1
                    DayDes = "วัน"
                Case "2"
                    countDay = day * 30
                    DayDes = "เดือน"
                Case "3"
                    countDay = day * 365
                    DayDes = "ปี"
            End Select
            Select Case condition
                Case "1"
                    conditionDayDesc = "น้อยกว่า"
                    conditionDesc = "<"
                Case "2"
                    conditionDayDesc = "น้อยกว่าเท่ากับ"
                    conditionDesc = "<="
                Case "3"
                    conditionDayDesc = "เท่ากับ"
                    conditionDesc = "="
                Case "4"
                    conditionDayDesc = "มากกว่าเท่ากับ"
                    conditionDesc = ">="
                Case "5"
                    conditionDayDesc = "มากกว่า"
                    conditionDesc = ">"
            End Select
            Dim duration As String = conditionDayDesc & " " & FormatNumber(day, 0) & " " & DayDes


            Dim strdata As String
            Dim strSql As New StringBuilder
            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY pt.patent_type_name) AS no")
            strSql.Append(" ,pt.id")
            strSql.Append(" ,pt.patent_type_name")
            strSql.Append(" ,'" & duration & "' as duration")
            strSql.Append(" ,left(CONVERT(varchar, CAST(count(tmp.id) AS money), 1), len(CONVERT(varchar, CAST(count(tmp.id) AS money), 1)) - 3)  as amountfile")
            strSql.Append(" from tmp_fileborrowitem tmp")
            strSql.Append(" inner join tb_requistion rq")
            strSql.Append(" on rq.app_no= tmp.app_no")
            strSql.Append(" inner join tb_patent_type pt")
            strSql.Append(" on pt.id = rq.patent_type_id")
            strSql.Append(" where 1=1 ")
            If duration <> "" Then
                strSql.Append(" and datediff(day,tmp.borrowdate,getdate()) " & conditionDesc & " " & countDay)
            End If
            If patent_type_id <> "" Then
                strSql.Append(" and rq.patent_type_id='" & patent_type_id & "'")
            End If
            If isshow <> "" Then
                strSql.Append(" and 1=" & isshow)
            End If
            strSql.Append(" group by pt.id ,pt.patent_type_name")
            strSql.Append(" order by pt.patent_type_name")


            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    <WebMethod()> _
    Public Function GetSearchAmountFileByDurationToDatatable(condition As String, _
                                           day As String, _
                                           time As String, _
                                           patent_type_id As String, _
                                           isshow As String) As DataTable
        Try


            Dim countDay As Integer
            Dim DayDes As String
            Dim conditionDayDesc As String
            Dim conditionDesc As String
            Select Case time
                Case "1"
                    countDay = day * 1
                    DayDes = "วัน"
                Case "2"
                    countDay = day * 30
                    DayDes = "เดือน"
                Case "3"
                    countDay = day * 365
                    DayDes = "ปี"
            End Select
            Select Case condition
                Case "1"
                    conditionDayDesc = "น้อยกว่า"
                    conditionDesc = "<"
                Case "2"
                    conditionDayDesc = "น้อยกว่าเท่ากับ"
                    conditionDesc = "<="
                Case "3"
                    conditionDayDesc = "เท่ากับ"
                    conditionDesc = "="
                Case "4"
                    conditionDayDesc = "มากกว่าเท่ากับ"
                    conditionDesc = ">="
                Case "5"
                    conditionDayDesc = "มากกว่า"
                    conditionDesc = ">"
            End Select
            Dim duration As String = conditionDayDesc & " " & FormatNumber(day, 0) & " " & DayDes

            Dim strSql As New StringBuilder
            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY pt.patent_type_name) AS no")
            strSql.Append(" ,pt.id")
            strSql.Append(" ,pt.patent_type_name")
            strSql.Append(" ,'" & duration & "' as duration")
            strSql.Append(" ,left(CONVERT(varchar, CAST(count(tmp.id) AS money), 1), len(CONVERT(varchar, CAST(count(tmp.id) AS money), 1)) - 3)  as amountfile")
            strSql.Append(" from tmp_fileborrowitem tmp")
            strSql.Append(" inner join tb_requistion rq")
            strSql.Append(" on rq.app_no= tmp.app_no")
            strSql.Append(" inner join tb_patent_type pt")
            strSql.Append(" on pt.id = rq.patent_type_id")
            strSql.Append(" where 1=1 ")
            If duration <> "" Then
                strSql.Append(" and datediff(day,tmp.borrowdate,getdate()) " & conditionDesc & " " & countDay)
            End If
            If patent_type_id <> "" Then
                strSql.Append(" and rq.patent_type_id='" & patent_type_id & "'")
            End If
            If isshow <> "" Then
                strSql.Append(" and 1=" & isshow)
            End If
            strSql.Append(" group by pt.id ,pt.patent_type_name")
            strSql.Append(" order by pt.patent_type_name")

            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    <WebMethod()> _
    Public Function LoadFloorPlanByApp_No(app_no As String, login_username As String) As String
        Try
            'app_no = "0001000002"
            Dim re As Boolean = True
            Dim TagNo As String = Engine.FileLocationENG.GetTagNoByAppNo(app_no)
            If TagNo.Trim <> "" Then
                Dim trans As New TransactionDB(SelectDB.DIPRFID)

                Dim ret As Boolean = False
                Dim tLnq As New TmpDocTracingLinqDB

                Dim tmpDt As DataTable = tLnq.GetDataList("tag_no='" & app_no & "' and tracing_status='1'", "", trans.Trans) '
                If tmpDt.Rows.Count = 0 Then
                    tLnq.TAG_NO = app_no
                    tLnq.TRACING_STATUS = "1"
                    tLnq.TRACING_START_TIME = DateTime.Now
                    re = tLnq.InsertData(login_username, trans.Trans)
                    If re = False Then
                        trans.RollbackTransaction()
                        Return "[]"
                    Else
                        trans.CommitTransaction()
                        Threading.Thread.Sleep(2000)
                    End If
                End If
                tmpDt.Dispose()
                tLnq = Nothing
            Else
                re = True
            End If

            If re = True Then
                Dim dtdetail As DataTable
                Dim strSQlDetail As New StringBuilder
                strSQlDetail.Append(" select T1.*,T2.borrowerdate,T2.borrowname from (")
                strSQlDetail.Append(" select top 1 ")
                strSQlDetail.Append(" convert(varchar, fcl.move_date,103) + ' ' + left(convert(varchar, fcl.move_date,108),5)  as strmove_date")
                strSQlDetail.Append(" , fcl.app_no")
                strSQlDetail.Append(" ,fcl.officer_name")
                strSQlDetail.Append(" ,location_name")
                strSQlDetail.Append(" ,fp.image_floor_plan")
                strSQlDetail.Append(" ,fp.image_file_ext")
                strSQlDetail.Append(" ,gl.vertical_line")
                strSQlDetail.Append(" ,gl.horizontal_line")
                strSQlDetail.Append(" ,fcg.grid_col")
                strSQlDetail.Append(" ,fcg.grid_row")
                strSQlDetail.Append(" from ts_file_current_location fcl ")
                strSQlDetail.Append(" inner join ms_room r ")
                strSQlDetail.Append(" on fcl.ms_room_id = r.id ")
                strSQlDetail.Append(" inner join ms_floor_plan fp ")
                strSQlDetail.Append(" on fp.id = r.ms_floor_plan_id_current  ")
                strSQlDetail.Append(" inner join ms_grid_layout gl  ")
                strSQlDetail.Append(" on r.ms_grid_layout_id_current = gl.id  ")
                strSQlDetail.Append(" inner join ts_file_current_grid fcg")
                strSQlDetail.Append(" on fcg.ts_file_current_location_id  =fcl.id")
                strSQlDetail.Append(" where fcl.app_no='" & app_no & "'")
                strSQlDetail.Append(" order by fcl.move_date desc")
                strSQlDetail.Append(" ) T1")
                strSQlDetail.Append(" Left Join")
                strSQlDetail.Append(" (select top 1 convert(varchar, dateadd(year,0,fb.borrowdate ),103) + ' ' + left(convert(varchar, fb.borrowdate ,108),5)  as borrowerdate ")
                strSQlDetail.Append(" ,fb.app_no,fb.borrower_name as borrowname  from [dbo].[TMP_FILEBORROWITEM] fb")
                strSQlDetail.Append(" where 1=1 and fb.app_no='" & app_no & "' order by fb.borrowdate desc) T2 on T1.app_no = T2.app_no ")


                ' strSQlDetail.Append(" (select top 1 convert(varchar, dateadd(year,0,fb.borrowerdate ),103) + ' ' + left(convert(varchar, fb.borrowerdate ,108),5)  as borrowerdate ")
                ' strSQlDetail.Append(" ,rq.app_no,fb.borrowername as borrowname ")
                ' strSQlDetail.Append(" from tb_fileborrow fb ")
                ' strSQlDetail.Append(" inner join tb_fileborrowitem fbi   on fb.id = fbi.fileborrow_id ")
                'strSQlDetail.Append(" inner join tb_requistion rq   on rq.id  =fbi.requisition_id ")
                'strSQlDetail.Append(" where 1=1 and rq.app_no='" & app_no & "' order by borrowerdate desc) T2 on T1.app_no = T2.app_no ")

                dtdetail = DIPRFIDSqlDB.ExecuteTable(strSQlDetail.ToString)
                If dtdetail.Rows.Count <> 0 Then

                    Dim strimagebase64 As String = ""
                    Dim strimagebasesrc As String = ""
                    If dtdetail.Rows(0)("image_file_ext") & "" <> "" Then
                        strimagebasesrc = "data:image/" & dtdetail.Rows(0)("image_file_ext") & ";base64," & Convert.ToBase64String(dtdetail.Rows(0)("image_floor_plan"))
                    End If

                    Dim strfloorplanpath As String
                    Dim indexstrart As Integer = 1
                    Dim gridfound_index As Integer
                    Dim gridfound_col As Integer = Val(dtdetail.Rows(0)("grid_col") & "")
                    Dim gridfound_row As Integer = Val(dtdetail.Rows(0)("grid_row") & "")
                    Dim countRows As Integer = Val(dtdetail.Rows(0)("vertical_line") & "")
                    Dim countColums As Integer = Val(dtdetail.Rows(0)("horizontal_line") & "")
                    Dim addstyle As String = " style=""background-color:red"""
                    Dim tmpstyle As String = ""
                    Dim strSQl As New StringBuilder
                    strSQl.Append("<table border=""1"" style="" background: url('" & strimagebasesrc & "');background-size: 100% auto;background-repeat: no-repeat;align-content: center; border: 1px solid #484;width:740px;height:550px"" >")
                    For i As Integer = 1 To countRows
                        strSQl.Append("<tr>")
                        For j As Integer = 1 To countColums
                            'If indexstrart = gridfound Then
                            '    tmpstyle = addstyle
                            'Else
                            '    tmpstyle = ""
                            'End If
                            If gridfound_col = j And gridfound_row = i Then
                                tmpstyle = addstyle
                                gridfound_index = indexstrart
                            Else
                                tmpstyle = ""
                            End If
                            strSQl.Append("<td id=" & indexstrart & " " & tmpstyle & ">")
                            strSQl.Append("</td>")
                            indexstrart = indexstrart + 1
                        Next
                        strSQl.Append("</tr>")
                    Next
                    strSQl.Append("</table>")

                    Dim dt As New DataTable
                    Dim dr As DataRow
                    dt.Columns.Add("strmove_date")
                    dt.Columns.Add("app_no")
                    dt.Columns.Add("officer_name")
                    dt.Columns.Add("location_name")
                    dt.Columns.Add("showdata")
                    dt.Columns.Add("showfound")
                    dt.Columns.Add("borrowname")
                    dt.Columns.Add("borrowerdate")
                    dr = dt.NewRow
                    dr("strmove_date") = dtdetail.Rows(0)("strmove_date") & ""
                    dr("app_no") = dtdetail.Rows(0)("app_no") & ""
                    dr("officer_name") = dtdetail.Rows(0)("officer_name") & ""
                    dr("location_name") = dtdetail.Rows(0)("location_name") & ""
                    dr("showdata") = strSQl.ToString
                    dr("showfound") = gridfound_index
                    dr("borrowname") = dtdetail.Rows(0)("borrowname") & ""
                    dr("borrowerdate") = dtdetail.Rows(0)("borrowerdate") & ""
                    dt.Rows.Add(dr)

                    Dim strdata As String
                    strdata = clsdtHelper.ConvertDataTableToJson(dt)

                    Return strdata
                Else
                    Return "[]"
                End If
            End If

        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadSearchFileStatus(app_no As String) As String
        Try
            '0201001501
            Dim strdata As String
            Dim strSql As New StringBuilder
            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY table1.realdate asc) AS no, table1.* from ")
            strSql.Append(" ( ")
            strSql.Append(" select ")
            strSql.Append(" rq.id")
            strSql.Append(" ,convert(varchar, dateadd(year,0,rq.createon),103) + ' ' + left(convert(varchar, rq.createon,108),5)  as move_date  ")
            strSql.Append(" ,rq.app_no")
            strSql.Append(" ,'' borrowname")
            strSql.Append(" ,'สร้างแฟ้ม' location_name")
            strSql.Append(" ,rq.createon  realdate  ")
            strSql.Append(" ,'Create' status_name")
            strSql.Append(" ,p.patent_type_name")
            strSql.Append(" from tb_requistion rq")
            strSql.Append(" inner join tb_patent_type p  ")
            strSql.Append(" on p.id = rq.patent_type_id ")
            strSql.Append(" where app_no='" & app_no & "' ")
            strSql.Append(" union")
            strSql.Append(" select ")
            strSql.Append(" rq.id ")
            strSql.Append(" ,convert(varchar, dateadd(year,0,tl.operation_date),103) + ' ' + left(convert(varchar, tl.operation_date,108),5)  as move_date  ")
            strSql.Append(" ,tl.app_no")
            strSql.Append(" ,'' borrowname")
            strSql.Append(" ,'เก็บแฟ้ม' location_name")
            strSql.Append(" ,tl.operation_date as  realdate")
            strSql.Append(" ,'Store' status_name")
            strSql.Append(" ,p.patent_type_name")
            strSql.Append(" from TS_FILE_OPERATION_TIMELINE tl")
            strSql.Append(" inner join tb_requistion rq on tl.app_no = rq.app_no")
            strSql.Append(" inner join tb_patent_type p  on p.id = rq.patent_type_id ")
            strSql.Append(" where tl.app_no='" & app_no & "' ")
            'strSql.Append(" select")
            'strSql.Append(" rq.id")
            'strSql.Append("  ,convert(varchar, dateadd(year,0,rq.createon+2),103) + ' ' + left(convert(varchar, rq.createon+2,108),5)  as move_date  ")
            'strSql.Append(" ,rq.app_no")
            'strSql.Append(" ,'' borrowname")
            'strSql.Append(" ,'เก็บแฟ้ม' location_name")
            'strSql.Append(" ,rq.createon+2  realdate   ")
            'strSql.Append(" ,'Store' status_name")
            'strSql.Append(" ,p.patent_type_name")
            'strSql.Append(" from tb_requistion rq")
            'strSql.Append(" inner join tb_patent_type p  ")
            'strSql.Append(" on p.id = rq.patent_type_id ")
            'strSql.Append(" where app_no='" & app_no & "' ")
            strSql.Append(" union")
            strSql.Append(" select")
            strSql.Append(" r.id")
            strSql.Append(" ,convert(varchar, dateadd(year,0,r.reserve_date),103) + ' ' + left(convert(varchar, r.reserve_date,108),5)  as move_date ")
            strSql.Append(" ,rq.app_no ")
            strSql.Append(" ,r.member_name as borrowname ")
            strSql.Append(" ,'จองแฟ้ม' as location_name  ")
            strSql.Append(" ,r.reserve_date as realdate   ")
            strSql.Append(" ,'Share' status_name  ")
            strSql.Append(" ,p.patent_type_name  ")
            strSql.Append(" from tb_reserve  r")
            strSql.Append(" inner join tb_requistion rq  on rq.id  =r.requidition_id  ")
            strSql.Append(" left join tb_status s   on s.id = rq.app_status ")
            strSql.Append(" inner join tb_patent_type p  on p.id = rq.patent_type_id   ")
            strSql.Append(" where borrowstatus='S'  and rq.app_no='" & app_no & "' ")
            strSql.Append(" union")
            strSql.Append(" select   ")
            strSql.Append(" fbi.id")
            strSql.Append(" ,convert(varchar, dateadd(year,0,fb.borrowerdate ),103) + ' ' + left(convert(varchar, fb.borrowerdate ,108),5)  as move_date ")
            strSql.Append(" ,rq.app_no ")
            strSql.Append(" ,fb.borrowername as borrowname")
            strSql.Append(" ,isnull(fl.location_name,'ยืมแฟ้ม') as location_name  ")
            strSql.Append(" ,fb.borrowerdate as realdate ")
            strSql.Append(" ,'Share' status_name")
            strSql.Append(" ,p.patent_type_name ")
            strSql.Append(" from tb_fileborrow fb ")
            strSql.Append(" inner join tb_fileborrowitem fbi   on fb.id = fbi.fileborrow_id")
            strSql.Append(" inner join tb_requistion rq   on rq.id  =fbi.requisition_id  ")
            strSql.Append(" left join tb_filelocation fl   on fl.id  =fb.tb_filelocation_id  ")
            strSql.Append(" left join tb_status s   on s.id = rq.app_status  ")
            strSql.Append(" inner join tb_patent_type p  on p.id = rq.patent_type_id   ")
            strSql.Append(" where 1=1 and rq.app_no='" & app_no & "'  ")
            strSql.Append(" union")
            strSql.Append(" select ")
            strSql.Append(" fb.id")
            strSql.Append(" ,convert(varchar, dateadd(year,0,fb.returndate),103) + ' ' + left(convert(varchar, fb.returndate,108),5)  as move_date ")
            strSql.Append(" ,rq.app_no")
            strSql.Append(" ,fb.officer_return borrowname")
            strSql.Append(" ,'คืนแฟ้ม' location_name")
            strSql.Append(" ,fb.returndate  realdate  ")
            strSql.Append("  ,'Share' status_name")
            strSql.Append(" ,p.patent_type_name")
            strSql.Append(" from TB_FILEBORROWITEM fb")
            strSql.Append(" inner join tb_requistion rq")
            strSql.Append(" on fb.requisition_id = rq.id")
            strSql.Append(" inner join tb_patent_type p  ")
            strSql.Append(" on p.id = rq.patent_type_id ")
            strSql.Append(" where rq.app_no='" & app_no & "' ")
            strSql.Append(" and fb.return_scan_by is not null")
            strSql.Append("  union")
            strSql.Append(" select  ")
            strSql.Append(" fvh.id")
            strSql.Append(" ,convert(varchar, dateadd(year,0,fvh.move_date),103) + ' ' + left(convert(varchar, fvh.move_date,108),5)  as move_date   ")
            strSql.Append(" ,fvh.app_no  ,isnull(t.title_name,'') + o.fname + ' ' + o.lname  as borrowname ")
            strSql.Append(" ,fvh.location_name  + ',' + r.room_name  + ',' + f.floor_name as location_name")
            strSql.Append(" ,fvh.move_date as realdate  ")
            strSql.Append(" ,'Achive' status_name   ")
            strSql.Append(" ,p.patent_type_name ")
            strSql.Append(" from ts_file_move_history fvh ")
            strSql.Append(" left join tb_officer o  on o.id = fvh.tb_officer_id ")
            strSql.Append(" left join tb_title t  on t.id=o.title_id  ")
            strSql.Append(" inner join tb_requistion rq  on rq.app_no = fvh.app_no")
            strSql.Append(" left join tb_status s   on s.id = rq.app_status  ")
            strSql.Append(" inner join tb_patent_type p  on p.id = rq.patent_type_id  ")
            strSql.Append(" inner join ms_room r on r.id = fvh.ms_room_id  ")
            strSql.Append(" inner join ms_floor f  on  r.ms_floor_id = f.id  ")
            strSql.Append(" where 1=1   and fvh.app_no='" & app_no & "'  ")
            strSql.Append(" union")
            strSql.Append(" select ")
            strSql.Append(" rq.id")
            strSql.Append(" ,convert(varchar, dateadd(year,0,rq.createon),103) + ' ' + left(convert(varchar, rq.createon,108),5)  as move_date ")
            strSql.Append(" ,rq.app_no")
            strSql.Append(" ,'' borrowname")
            strSql.Append(" ,'ทำลายแฟ้ม' location_name")
            strSql.Append(" ,rq.createon  realdate   ")
            strSql.Append(" ,'Destroy' status_name")
            strSql.Append(" ,p.patent_type_name")
            strSql.Append(" from tb_requistion rq")
            strSql.Append(" inner join tb_patent_type p  ")
            strSql.Append(" on p.id = rq.patent_type_id ")
            strSql.Append(" where app_no='" & app_no & "' and [filelocation]=5")
            strSql.Append(" ) as table1  ")
            strSql.Append(" order by  table1.realdate  asc  ")









            'strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY table1.realdate asc) AS no, table1.* from (  ")
            'strSql.Append(" select   ")
            'strSql.Append(" r.id ")
            'strSql.Append(" ,convert(varchar, dateadd(year,0,r.reserve_date),103) + ' ' + left(convert(varchar, r.reserve_date,108),5)  as move_date ")
            'strSql.Append(" ,rq.app_no ")
            'strSql.Append(" ,r.member_name as borrowname ")
            'strSql.Append(" ,'จองผ่านระบบ ePattent' as location_name  ")
            'strSql.Append(" ,r.reserve_date as realdate  ")
            'strSql.Append(" ,s.status_name   ")
            'strSql.Append(" ,p.patent_type_name  ")
            'strSql.Append(" from tb_reserve  r ")
            'strSql.Append(" inner join tb_requistion rq ")
            'strSql.Append(" on rq.id  =r.requidition_id ")
            'strSql.Append(" left join tb_status s  ")
            'strSql.Append(" on s.id = rq.app_status ")
            'strSql.Append(" inner join tb_patent_type p ")
            'strSql.Append(" on p.id = rq.patent_type_id  ")
            'strSql.Append(" where borrowstatus='S' ")
            'If app_no <> "" Then
            '    strSql.Append(" and rq.app_no='" & app_no & "'")
            'End If


            'strSql.Append(" union  ")
            'strSql.Append(" select  ")
            'strSql.Append(" fbi.id  ")
            'strSql.Append(" ,convert(varchar, dateadd(year,0,fb.borrowerdate ),103) + ' ' + left(convert(varchar, fb.borrowerdate ,108),5)  as move_date ")
            'strSql.Append(" ,rq.app_no   ")
            'strSql.Append(" ,fb.borrowername as borrowname  ")
            'strSql.Append(" ,isnull(fl.location_name,'แฟ้มได้ถูกยืมจากห้องแฟ้มชั้น 6') as location_name   ")
            'strSql.Append(" ,fb.borrowerdate as realdate  ")
            'strSql.Append("  ,s.status_name   ")
            'strSql.Append("  ,p.patent_type_name  ")
            'strSql.Append(" from tb_fileborrow fb  ")
            'strSql.Append(" inner join tb_fileborrowitem fbi  ")
            'strSql.Append(" on fb.id = fbi.fileborrow_id  ")
            'strSql.Append(" inner join tb_requistion rq  ")
            'strSql.Append(" on rq.id  =fbi.requisition_id  ")
            'strSql.Append(" left join tb_filelocation fl  ")
            'strSql.Append(" on fl.id  =fb.tb_filelocation_id  ")
            'strSql.Append(" left join tb_status s  ")
            'strSql.Append(" on s.id = rq.app_status ")
            'strSql.Append(" inner join tb_patent_type p ")
            'strSql.Append(" on p.id = rq.patent_type_id  ")
            'strSql.Append(" where 1=1")
            'If app_no <> "" Then
            '    strSql.Append(" and rq.app_no='" & app_no & "'")
            'End If


            'strSql.Append("  union  ")
            'strSql.Append("  select")
            'strSql.Append("  fvh.id ")
            'strSql.Append("  ,convert(varchar, dateadd(year,0,fvh.move_date),103) + ' ' + left(convert(varchar, fvh.move_date,108),5)  as move_date  ")
            'strSql.Append("  ,fvh.app_no")
            'strSql.Append("  ,isnull(t.title_name,'') + o.fname + ' ' + o.lname  as borrowname ")
            'strSql.Append("  ,fvh.location_name  ")
            'strSql.Append("  ,fvh.move_date as realdate  ")
            'strSql.Append("  ,s.status_name   ")
            'strSql.Append("  ,p.patent_type_name  ")
            'strSql.Append("  from ts_file_move_history fvh  ")
            'strSql.Append("  inner join tb_officer o")
            'strSql.Append("  on o.id = fvh.tb_officer_id")
            'strSql.Append("  left join tb_title t")
            'strSql.Append("  on t.id=o.title_id")
            'strSql.Append("  inner join tb_requistion rq")
            'strSql.Append("  on rq.app_no = fvh.app_no")
            'strSql.Append("  left join tb_status s ")
            'strSql.Append("  on s.id = rq.app_status")
            'strSql.Append("  inner join tb_patent_type p")
            'strSql.Append("  on p.id = rq.patent_type_id")
            'strSql.Append("  where 1=1  ")
            'If app_no <> "" Then
            '    strSql.Append(" and fvh.app_no='" & app_no & "'")
            'End If

            'strSql.Append("   ) as table1")
            'strSql.Append("   order by  table1.realdate  asc  ")

            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)


            Dim strtemp As String = ""
            If dt.Rows.Count > 0 Then
                strtemp = "<section id=""cd-timeline"" class=""cd-container"">"
                For i As Integer = 0 To dt.Rows.Count - 1
                    strtemp &= "<div class=""cd-timeline-block"">"
                    strtemp &= "    <div class=""cd-timeline-img cd-picture"">"
                    strtemp &= "        <img src=""assets/js/vertical-timeline/img/cd-icon-location.svg"" alt=""Location"">"
                    strtemp &= "    </div> "
                    strtemp &= "    <div class=""cd-timeline-content"">"
                    strtemp &= "        <h2>" & dt.Rows(i)("status_name") & "</h2>"
                    strtemp &= "        <p>" & dt.Rows(i)("location_name") & "</p>"
                    If dt.Rows(i)("borrowname") <> "" Then
                        strtemp &= "        <p>" & dt.Rows(i)("borrowname") & "</p>"
                    End If

                    strtemp &= "    <span class=""cd-date"">" & dt.Rows(i)("move_date") & "</span>"
                    strtemp &= "    </div> "
                    strtemp &= "</div> "
                Next
                strtemp &= "</section>"
            End If


            '  If dt.Rows.Count > 0 Then
            'strtemp = "<section id=""cd-timeline"" class=""cd-container"">"
            'strtemp &= "<div class=""cd-timeline-block"">"
            'strtemp &= "    <div class=""cd-timeline-img cd-picture"">"
            'strtemp &= "        <img src=""assets/js/vertical-timeline/img/cd-icon-location.svg"" alt=""Location"">"
            'strtemp &= "    </div> "
            'strtemp &= "    <div class=""cd-timeline-content"">"
            'strtemp &= "        <h2>จอง</h2>"
            'strtemp &= "        <p>ผู้จอง นายนิรุจน์ ประยูรโต</p>"
            'strtemp &= "    <span class=""cd-date"">1 มกราคม 2015</span>"
            'strtemp &= "    </div> "
            'strtemp &= "</div> "

            'strtemp &= "<div class=""cd-timeline-block"">"
            'strtemp &= "    <div class=""cd-timeline-img cd-picture"">"
            'strtemp &= "        <img src=""assets/js/vertical-timeline/img/cd-icon-location.svg"" alt=""Location"">"
            'strtemp &= "    </div> "
            'strtemp &= "    <div class=""cd-timeline-content"">"
            'strtemp &= "        <h2>ยืม</h2>"
            'strtemp &= "        <p>ผู้ยืม นายนิรุจน์ ประยูรโต</p>"
            'strtemp &= "    <span class=""cd-date"">2 มกราคม 2015</span>"
            'strtemp &= "    </div> "
            'strtemp &= "</div> "

            'strtemp &= "<div class=""cd-timeline-block"">"
            'strtemp &= "    <div class=""cd-timeline-img cd-picture"">"
            'strtemp &= "        <img src=""assets/js/vertical-timeline/img/cd-icon-location.svg"" alt=""Location"">"
            'strtemp &= "    </div> "
            'strtemp &= "    <div class=""cd-timeline-content"">"
            'strtemp &= "        <h2>โอน</h2>"
            'strtemp &= "        <p>ผู้โอน นายบุญนริศร์ สุวรรณพูล</p>"
            'strtemp &= "    <span class=""cd-date"">10 มกราคม 2015</span>"
            'strtemp &= "    </div> "
            'strtemp &= "</div> "

            'strtemp &= "<div class=""cd-timeline-block"">"
            'strtemp &= "    <div class=""cd-timeline-img cd-picture"">"
            'strtemp &= "        <img src=""assets/js/vertical-timeline/img/cd-icon-location.svg"" alt=""Location"">"
            'strtemp &= "    </div> "
            'strtemp &= "    <div class=""cd-timeline-content"">"
            'strtemp &= "        <h2>คืน</h2>"
            'strtemp &= "        <p>ผู้คืน นายบุญนริศร์ สุวรรณพูล</p>"
            'strtemp &= "    <span class=""cd-date"">25 มกราคม 2015</span>"
            'strtemp &= "    </div> "
            'strtemp &= "</div> "
            'strtemp &= "</section>"
            'strdata = clsdtHelper.ConvertDataTableToJson(dt)
            'End If

            Return strtemp
        Catch ex As Exception
            Return ""
        End Try
    End Function

#End Region

#Region "Master"
    <WebMethod()> _
    Public Function LoadActiveFloor() As String
        Try
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY fl.id asc) AS no")
            strSql.Append(" ,fl.id")
            strSql.Append(" ,fl.floor_name")
            strSql.Append(" from ms_floor fl")
            strSql.Append(" where fl.active_status ='Y'")
            strSql.Append(" order by fl.floor_name")
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadLocation() As String
        Try
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY ID asc) AS no")
            strSql.Append(" ,ID")
            strSql.Append(" ,LocationName")
            strSql.Append(" from TB_LOCATION")
            strSql.Append(" order by LocationName")
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadActivePatent() As String
        Try
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY pt.id asc) AS no")
            strSql.Append(" ,pt.id")
            strSql.Append(" ,pt.patent_type_name")
            strSql.Append(" from tb_patent_type pt")
            strSql.Append(" order by pt.patent_type_code")
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadActiveStatus() As String
        Try
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select  ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY table1.status_name asc) AS no ")
            strSql.Append(" ,table1.status_name  ")
            strSql.Append(" from	( ")
            strSql.Append(" select distinct status_name from tb_status s ")
            strSql.Append(" ) as table1 order by table1.status_name ")
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadActiveDepartment() As String
        Try
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY d.id asc) AS no")
            strSql.Append(" ,d.id")
            strSql.Append(" ,d.department_name")
            strSql.Append(" from tb_department d")
            strSql.Append(" order by d.department_name")
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadConditionCompare() As String
        Try
            Dim strdata As String
            Dim dt As New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("name")
            Dim dr As DataRow

            dr = dt.NewRow
            dr("id") = "1"
            dr("name") = "น้อยกว่า"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "2"
            dr("name") = "น้อยกว่าเท่ากับ"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "3"
            dr("name") = "เท่ากับ"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "4"
            dr("name") = "มากกว่าเท่ากับ"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "5"
            dr("name") = "มากกว่า"
            dt.Rows.Add(dr)

            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadConditionTime() As String
        Try
            Dim strdata As String
            Dim dt As New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("name")
            Dim dr As DataRow

            dr = dt.NewRow
            dr("id") = "1"
            dr("name") = "วัน"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "2"
            dr("name") = "เดือน"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "3"
            dr("name") = "ปี"
            dt.Rows.Add(dr)


            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

#End Region

#Region "User"
    <WebMethod()> _
    Public Function LoadUserByName(name As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select distinct borrowername as label from tb_fileborrow")
            strSql.Append(" where  borrowername like '%" & name & "%' order by borrowername ")

            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadUserByDepartment(name As String, department_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select table2.* from (")
            strSql.Append(" select  ")
            strSql.Append(" distinct fb.borrowername + '('  + table1.department_name + ')' as label  ")
            strSql.Append(" ,fb.borrowername as fullname  ")
            strSql.Append(" ,table1.department_id ")
            strSql.Append(" from tb_fileborrow fb ")
            strSql.Append(" inner join ( ")
            strSql.Append("         select distinct t.title_name + o.fname + ' ' + lname as fullname,o.department_id,d.department_name   from tb_officer o ")
            strSql.Append("         inner join tb_title t ")
            strSql.Append("         on o.title_id = t.id ")
            strSql.Append("         inner join tb_department d ")
            strSql.Append("         on o.department_id = d.id ")
            strSql.Append(" )  as table1 on table1.fullname = fb.borrowername  ")
            strSql.Append(" where table1.department_id Is Not null ")
            strSql.Append(" and  fb.borrowername like '%" & name & "%'")
            If department_id <> "" Then
                strSql.Append(" and  table1.department_id=" & department_id)
            End If
            strSql.Append("  ) as table2")
            strSql.Append(" order by table2.label ")
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadAllUserByName(name As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY u.id asc) AS no")
            strSql.Append(" ,u.id")
            strSql.Append(" ,title_name + ' ' + fname + ' ' + lname as label")
            strSql.Append(" ,username")
            strSql.Append(" ,fname")
            strSql.Append(" ,lname")
            strSql.Append(" ,title_id")
            strSql.Append(" ,title_name + ' ' + fname + ' ' + lname as fullname")
            strSql.Append(" from TB_OFFICER u")
            strSql.Append(" inner join TB_TITLE t on u.title_id = t.id")
            strSql.Append(" where  fname like '%" & name & "%' or lname like '%" & name & "%' order by fname,lname ")

            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function
#End Region

#Region "Portal"
    <WebMethod()> _
    Public Function LoadPortalReserve(memberid As String) As String
        Try
            Dim strdata As String
            Dim strSql As New StringBuilder
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY reserve_order desc) AS no")
            strSql.Append(" ,req_no as app_no")
            strSql.Append(" ,convert(varchar,reserve_date,103) as reserve_date")
            strSql.Append(" ,patent_type_name ")
            strSql.Append(" ,reserve_order")
            strSql.Append(" ,app_status")
            strSql.Append(" ,(case when reserve_status='Y' then 'ว่าง' ")
            strSql.Append(" else 'ไม่ว่าง' end) as reserve_status")
            strSql.Append(" ,BORROWNAME ")
            strSql.Append(" from   v_reserve_list where member_id='" & memberid & "'")
            strSql.Append(" and  reserve_status='Y'")
            strSql.Append(" order by reserve_date desc, reserve_order asc,reserve_status desc")
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadPortalBorrow(memberid As String) As String
        Try
            Dim strdata As String
            Dim strSql As New StringBuilder
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY tfi.borrowdate desc) AS no ")
            strSql.Append(" ,tfi.app_no ")
            strSql.Append(" ,convert(varchar,tfi.borrowdate,103) as borrowdate ")
            strSql.Append(" ,datediff(day,tfi.borrowdate,getdate()) as duration ")
            strSql.Append(" ,'' as strduration ")
            strSql.Append(" ,patent_type_name ")
            strSql.Append(" from TMP_FILEBORROWITEM tfi ")
            strSql.Append(" inner join TB_REQUISTION rq ")
            strSql.Append(" on rq.app_no = tfi.app_no ")
            strSql.Append(" inner join TB_PATENT_TYPE pt ")
            strSql.Append(" on pt.id=rq.patent_type_id ")
            strSql.Append(" where borrower_id='" & memberid & "' ")
            strSql.Append(" order by tfi.borrowdate desc ")
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("strduration") = FormatNumber(dt.Rows(i)("duration"), 0) & " วัน"
                Next
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try
    End Function
#End Region


End Class
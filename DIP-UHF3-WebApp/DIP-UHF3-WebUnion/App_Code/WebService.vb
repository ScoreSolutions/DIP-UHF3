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

#Region "Doctracking"
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
            strSql.Append(" ,'จองผ่านระบบ ePatent' as location_name  ")
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
            strSql.Append("  ,p.patent_type_name,'4' as ms_floor_id  ")
            strSql.Append(" from tb_fileborrow fb  ")
            strSql.Append(" inner join tb_fileborrowitem fbi  ")
            strSql.Append(" on fb.id = fbi.fileborrow_id  ")
            strSql.Append(" inner join tb_requistion rq  ")
            strSql.Append(" on rq.id  =fbi.requisition_id  ")
            strSql.Append(" left join tb_filelocation fl  ")
            strSql.Append(" on fl.id  =fb.tb_filelocation_id ")
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


            strSql.Append(" union  ")
            strSql.Append(" select ")
            strSql.Append(" fit.id")
            strSql.Append(" ,convert(varchar, dateadd(year,0,fit.returndate ),103) + ' ' + left(convert(varchar, fit.returndate ,108),5)  as move_date")
            strSql.Append(" ,rq.app_no")
            strSql.Append(" , isnull( t.title_name,'') + o.fname + ' ' + o.lname  as borrowname ")
            strSql.Append(" ,'แฟ้มได้ถูกคืนจากห้องแฟ้มชั้น 6' as location_name")
            strSql.Append(" ,fit.returndate as realdate")
            strSql.Append(" ,s.status_name ")
            strSql.Append(" ,p.patent_type_name")
            strSql.Append(" ,'4' as ms_floor_id   ")
            strSql.Append(" from TB_FILEBORROWITEM  fit")
            strSql.Append(" inner join tb_requistion rq")
            strSql.Append(" on fit.requisition_id = rq.id")
            strSql.Append(" inner join tb_patent_type p ")
            strSql.Append(" on p.id = rq.patent_type_id")
            strSql.Append(" left join tb_status s")
            strSql.Append(" on s.id = rq.app_status ")
            strSql.Append(" left join tb_officer o")
            strSql.Append(" on o.username = fit.officer_return")
            strSql.Append(" inner join tb_title t")
            strSql.Append(" on t.id = o.title_id")
            strSql.Append("  where fit.returndate Is Not null")

            If app_no <> "" Then
                strSql.Append(" and rq.app_no='" & app_no & "'")
            End If
            If datefrom <> "" And dateto <> "" Then
                strSql.Append(" and convert(varchar, fit.returndate,112)  between CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(datefrom) & "')  and CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(dateto) & "')")
            End If

            If borrowername <> "" Then
                strSql.Append(" and isnull( t.title_name,'') + o.fname + ' ' + o.lname like '%" & borrowername & "%'")
            End If
            If statusname <> "" Then
                strSql.Append(" and s.status_name = '" & statusname & "'")
            End If
            If patenttypeid <> "" Then
                strSql.Append(" and rq.patent_type_id = '" & patenttypeid & "'")
            End If


            strSql.Append("  union  ")
            'strSql.Append("  select")
            'strSql.Append("  fvh.id ")
            'strSql.Append("  ,convert(varchar, dateadd(year,0,fvh.move_date),103) + ' ' + left(convert(varchar, fvh.move_date,108),5)  as move_date  ")
            'strSql.Append("  ,fvh.app_no")
            'strSql.Append("  ,isnull(t.title_name,'') + o.fname + ' ' + o.lname  as borrowname ")
            'strSql.Append("  ,fvh.location_name  ")
            'strSql.Append("  ,fvh.move_date as realdate  ")
            'strSql.Append("  ,s.status_name   ")
            'strSql.Append("  ,p.patent_type_name,ms_floor_id  ")
            'strSql.Append("  from ts_file_move_history fvh  ")
            'strSql.Append("  left join tb_officer o")
            'strSql.Append("  on o.id = fvh.tb_officer_id")
            'strSql.Append("  left join tb_title t")
            'strSql.Append("  on t.id=o.title_id")
            'strSql.Append("  inner join tb_requistion rq")
            'strSql.Append("  on rq.app_no = fvh.app_no")
            'strSql.Append("  left join tb_status s ")
            'strSql.Append("  on s.id = rq.app_status")
            'strSql.Append("  inner join tb_patent_type p")
            'strSql.Append("  on p.id = rq.patent_type_id")
            'strSql.Append("  left join MS_ROOM r on fvh.ms_room_id = r.id")
            'strSql.Append("  where 1 = 1")
            strSql.Append("  select ROW_NUMBER() OVER(ORDER BY table1.realdate desc) AS id  ")
            strSql.Append("  ,convert(varchar, dateadd(year,0,table1.realdate),103) + ' ' + left(convert(varchar, table1.realdate,108),5)  as move_date  ")
            strSql.Append("  ,table1.*")
            strSql.Append("  from (")
            strSql.Append("  select")
            strSql.Append("  fvh.app_no")
            strSql.Append("  ,isnull(t.title_name,'') + o.fname + ' ' + o.lname  as borrowname ")
            strSql.Append("  ,fvh.location_name  ")
            strSql.Append("  ,max(fvh.move_date) as realdate  ")
            strSql.Append("  ,s.status_name  ")
            strSql.Append("  ,p.patent_type_name,ms_floor_id ")
            strSql.Append("  from ts_file_move_history fvh  ")
            strSql.Append("  left join tb_officer o")
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
            strSql.Append("   where 1 = 1")
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
            strSql.Append("  group by ")
            strSql.Append("  fvh.app_no")
            strSql.Append("  ,isnull(t.title_name,'') + o.fname + ' ' + o.lname ")
            strSql.Append("  ,fvh.location_name ")
            strSql.Append("  ,s.status_name  ")
            strSql.Append("  ,p.patent_type_name,ms_floor_id ")
            strSql.Append("  ) as table1")



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
            strSql.Append(" ,'จองผ่านระบบ ePatent' as location_name  ")
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

            strSql.Append(" union  ")
            strSql.Append(" select ")
            strSql.Append(" fit.id")
            strSql.Append(" ,convert(varchar, dateadd(year,0,fit.returndate ),103) + ' ' + left(convert(varchar, fit.returndate ,108),5)  as move_date")
            strSql.Append(" ,rq.app_no")
            strSql.Append(" , isnull( t.title_name,'') + o.fname + ' ' + o.lname  as borrowname ")
            strSql.Append(" ,'แฟ้มได้ถูกคืนจากห้องแฟ้มชั้น 6' as location_name")
            strSql.Append(" ,fit.returndate as realdate")
            strSql.Append(" ,s.status_name ")
            strSql.Append(" ,p.patent_type_name")
            strSql.Append(" from TB_FILEBORROWITEM  fit")
            strSql.Append(" inner join tb_requistion rq")
            strSql.Append(" on fit.requisition_id = rq.id")
            strSql.Append(" inner join tb_patent_type p ")
            strSql.Append(" on p.id = rq.patent_type_id")
            strSql.Append(" left join tb_status s")
            strSql.Append(" on s.id = rq.app_status ")
            strSql.Append(" left join tb_officer o")
            strSql.Append(" on o.username = fit.officer_return")
            strSql.Append(" inner join tb_title t")
            strSql.Append(" on t.id = o.title_id")
            strSql.Append("  where fit.returndate Is Not null")

            If app_no <> "" Then
                strSql.Append(" and rq.app_no='" & app_no & "'")
            End If
            If datefrom <> "" And dateto <> "" Then
                strSql.Append(" and convert(varchar, fit.returndate,112)  between CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(datefrom) & "')  and CONVERT(DATETIME,'" & clsdtHelper.ConvertStringDate(dateto) & "')")
            End If

            If borrowername <> "" Then
                strSql.Append(" and isnull( t.title_name,'') + o.fname + ' ' + o.lname like '%" & borrowername & "%'")
            End If
            If statusname <> "" Then
                strSql.Append(" and s.status_name = '" & statusname & "'")
            End If
            If patenttypeid <> "" Then
                strSql.Append(" and rq.patent_type_id = '" & patenttypeid & "'")
            End If


            strSql.Append("  union  ")
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
            'strSql.Append("  left join tb_officer o")
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
            strSql.Append("  select ROW_NUMBER() OVER(ORDER BY table1.realdate desc) AS id  ")
            strSql.Append("  ,convert(varchar, dateadd(year,0,table1.realdate),103) + ' ' + left(convert(varchar, table1.realdate,108),5)  as move_date  ")
            strSql.Append("  ,table1.*")
            strSql.Append("  from (")
            strSql.Append("  select")
            strSql.Append("  fvh.app_no")
            strSql.Append("  ,isnull(t.title_name,'') + o.fname + ' ' + o.lname  as borrowname ")
            strSql.Append("  ,fvh.location_name  ")
            strSql.Append("  ,max(fvh.move_date) as realdate  ")
            strSql.Append("  ,s.status_name  ")
            strSql.Append("  ,p.patent_type_name ")
            strSql.Append("  from ts_file_move_history fvh  ")
            strSql.Append("  left join tb_officer o")
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
            strSql.Append("   where 1 = 1")
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
            strSql.Append("  group by ")
            strSql.Append("  fvh.app_no")
            strSql.Append("  ,isnull(t.title_name,'') + o.fname + ' ' + o.lname ")
            strSql.Append("  ,fvh.location_name ")
            strSql.Append("  ,s.status_name  ")
            strSql.Append("  ,p.patent_type_name ")
            strSql.Append("  ) as table1")


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
            'Dim strSql As New StringBuilder
            'strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY f.floor_name) AS no ")
            'strSql.Append(" ,f.id,f.floor_name,pt.patent_type_name,count(fcl.id) as amountfile")
            'strSql.Append(" from ts_file_current_location fcl")
            'strSql.Append(" inner join ms_room r on r.id = fcl.ms_room_id")
            'strSql.Append(" inner join ms_floor f on f.id = r.ms_floor_id")
            'strSql.Append(" inner join tb_requistion rq on fcl.app_no = rq.app_no")
            'strSql.Append(" inner join tb_patent_type pt on pt.id = rq.patent_type_id")
            'strSql.Append(" where 1=1")
            'If floor_id <> "" Then
            '    strSql.Append(" and f.id='" & floor_id & "'")
            'End If
            'If patent_type_id <> "" Then
            '    strSql.Append(" and rq.patent_type_id='" & patent_type_id & "'")
            'End If
            'If isshow <> "" Then
            '    strSql.Append(" and 1=" & isshow)
            'End If
            'strSql.Append(" group by f.id,f.floor_name,pt.patent_type_name")
            'strSql.Append(" order by f.floor_name")

            'Dim trans As New TransactionDB(SelectDB.DIPRFID)
            'Dim dt As DataTable
            'dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)

            If floor_id = "" Then
                floor_id = Engine.GlobalFunction.GetSysConfing("Signage6FloorID")
            End If
            Dim dt As DataTable
            dt = Engine.FileLocationENG.GetSearchFileByFloor(floor_id)
            If dt.Rows.Count > 0 Then
                If patent_type_id <> "" Then
                    dt.DefaultView.RowFilter = "patent_type_id='" & patent_type_id & "'"
                    dt = dt.DefaultView.ToTable
                End If
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "floor_name, patent_type_name"
                    dt = dt.DefaultView.ToTable.Copy

                    For i As Integer = 0 To dt.Rows.Count - 1
                        dt.Rows(i)("no") = (i + 1).ToString
                    Next
                    strdata = clsdtHelper.ConvertDataTableToJson(dt)
                Else
                    strdata = "[]"
                End If
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
            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY s.status_name) AS no")
            strSql.Append(" ,s.status_name,pt.patent_type_name,count(rq.id) as amountfile")
            strSql.Append(" from tb_requistion rq")
            strSql.Append(" inner join tb_status s")
            strSql.Append(" on s.id = rq.app_status")
            strSql.Append(" inner join tb_patent_type pt")
            strSql.Append(" on pt.id = rq.patent_type_id")
            strSql.Append(" where pt.id<>2 ")
            If status_name <> "" Then
                strSql.Append(" and s.status_name='" & status_name & "'")
            End If
            If patent_type_id <> "" Then
                strSql.Append(" and rq.patent_type_id='" & patent_type_id & "'")
            End If
            If isshow <> "" Then
                strSql.Append(" and 1=" & isshow)
            End If
            strSql.Append(" group by s.status_name,pt.patent_type_name")
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
            strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY d.department_name,fb.borrower_name) AS no")
            strSql.Append(" ,fb.borrower_id tb_officer_id,fb.borrower_name officer_name ,d.department_name, pt.patent_type_name,count(fb.id) as amountfile")
            strSql.Append(" from TMP_FILEBORROWITEM fb")
            strSql.Append(" inner join tb_requistion rq on rq.app_no=fb.app_no")
            strSql.Append(" inner join tb_officer o on o.id = fb.borrower_id")
            strSql.Append(" inner join tb_department d on d.id = o.department_id")
            strSql.Append(" inner join tb_patent_type pt on pt.id = rq.patent_type_id")
            strSql.Append(" where pt.id<>2 and fb.borrower_id<>0 ")
            If department_id <> "" Then
                strSql.Append(" and o.department_id='" & department_id & "'")
            End If
            If username <> "" Then
                strSql.Append(" and fb.borrower_name like'%" & username & "%'")
            End If
            If patent_type_id <> "" Then
                strSql.Append(" and rq.patent_type_id='" & patent_type_id & "'")
            End If
            If isshow <> "" Then
                strSql.Append(" and 1=" & isshow)
            End If
            strSql.Append(" group by fb.borrower_id,fb.borrower_name ,d.department_name, pt.patent_type_name")
            strSql.Append(" order by d.department_name,fb.borrower_name")
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
            strSql.Append(" where pt.id<>2 and tmp.borrower_id<>0 ")
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
        Return Engine.FileLocationENG.LoadFloorPlanByApp_No(app_no, login_username)
        'Try
        '    'app_no = "0001000002"
        '    Dim re As Boolean = True
        '    Dim TagNo As String = Engine.FileLocationENG.GetTagNoByAppNo(app_no)
        '    If TagNo.Trim <> "" Then
        '        Dim trans As New TransactionDB(SelectDB.DIPRFID)

        '        Dim ret As Boolean = False
        '        Dim tLnq As New TmpDocTracingLinqDB

        '        Dim tmpDt As DataTable = tLnq.GetDataList("tag_no='" & app_no & "' and tracing_status='1'", "", trans.Trans) '
        '        If tmpDt.Rows.Count = 0 Then
        '            tLnq.TAG_NO = app_no
        '            tLnq.TRACING_STATUS = "1"
        '            tLnq.TRACING_START_TIME = DateTime.Now
        '            re = tLnq.InsertData(login_username, trans.Trans)
        '            If re = False Then
        '                trans.RollbackTransaction()
        '                Return "[]"
        '            Else
        '                trans.CommitTransaction()
        '                Threading.Thread.Sleep(10000)
        '            End If
        '        End If
        '        tmpDt.Dispose()
        '        tLnq = Nothing
        '    Else
        '        re = True
        '    End If
        '    'Threading.Thread.Sleep(10000)
        '    If re = True Then
        '        Dim dtdetail As DataTable
        '        Dim strSQlDetail As New StringBuilder
        '        strSQlDetail.Append(" select T1.*,T2.borrowerdate,T2.borrowname from (")
        '        strSQlDetail.Append(" select top 1 ")
        '        strSQlDetail.Append(" convert(varchar, fcl.move_date,103) + ' ' + left(convert(varchar, fcl.move_date,108),5)  as strmove_date")
        '        strSQlDetail.Append(" , fcl.app_no")
        '        strSQlDetail.Append(" ,fcl.officer_name")
        '        strSQlDetail.Append(" ,location_name")
        '        strSQlDetail.Append(" ,fp.image_floor_plan")
        '        strSQlDetail.Append(" ,fp.image_file_ext")
        '        strSQlDetail.Append(" ,gl.vertical_line")
        '        strSQlDetail.Append(" ,gl.horizontal_line")
        '        strSQlDetail.Append(" ,fcg.grid_col")
        '        strSQlDetail.Append(" ,fcg.grid_row")
        '        strSQlDetail.Append(" from ts_file_current_location fcl ")
        '        strSQlDetail.Append(" inner join ms_room r ")
        '        strSQlDetail.Append(" on fcl.ms_room_id = r.id ")
        '        strSQlDetail.Append(" inner join ms_floor_plan fp ")
        '        strSQlDetail.Append(" on fp.id = r.ms_floor_plan_id_current  ")
        '        strSQlDetail.Append(" inner join ms_grid_layout gl  ")
        '        strSQlDetail.Append(" on r.ms_grid_layout_id_current = gl.id  ")
        '        strSQlDetail.Append(" inner join ts_file_current_grid fcg")
        '        strSQlDetail.Append(" on fcg.ts_file_current_location_id  =fcl.id")
        '        strSQlDetail.Append(" where fcl.app_no='" & app_no & "'")
        '        strSQlDetail.Append(" order by fcl.move_date desc")
        '        strSQlDetail.Append(" ) T1")
        '        strSQlDetail.Append(" Left Join")
        '        strSQlDetail.Append(" (select top 1 convert(varchar, dateadd(year,0,fb.borrowdate ),103) + ' ' + left(convert(varchar, fb.borrowdate ,108),5)  as borrowerdate ")
        '        strSQlDetail.Append(" ,fb.app_no,fb.borrower_name as borrowname  from [dbo].[TMP_FILEBORROWITEM] fb")
        '        strSQlDetail.Append(" where 1=1 and fb.app_no='" & app_no & "' order by fb.borrowdate desc) T2 on T1.app_no = T2.app_no ")


        '        ' strSQlDetail.Append(" (select top 1 convert(varchar, dateadd(year,0,fb.borrowerdate ),103) + ' ' + left(convert(varchar, fb.borrowerdate ,108),5)  as borrowerdate ")
        '        ' strSQlDetail.Append(" ,rq.app_no,fb.borrowername as borrowname ")
        '        ' strSQlDetail.Append(" from tb_fileborrow fb ")
        '        ' strSQlDetail.Append(" inner join tb_fileborrowitem fbi   on fb.id = fbi.fileborrow_id ")
        '        'strSQlDetail.Append(" inner join tb_requistion rq   on rq.id  =fbi.requisition_id ")
        '        'strSQlDetail.Append(" where 1=1 and rq.app_no='" & app_no & "' order by borrowerdate desc) T2 on T1.app_no = T2.app_no ")

        '        dtdetail = DIPRFIDSqlDB.ExecuteTable(strSQlDetail.ToString)
        '        If dtdetail.Rows.Count <> 0 Then

        '            Dim strimagebase64 As String = ""
        '            Dim strimagebasesrc As String = ""
        '            If dtdetail.Rows(0)("image_file_ext") & "" <> "" Then
        '                strimagebasesrc = "data:image/" & dtdetail.Rows(0)("image_file_ext") & ";base64," & Convert.ToBase64String(dtdetail.Rows(0)("image_floor_plan"))
        '            End If

        '            Dim strfloorplanpath As String
        '            Dim indexstrart As Integer = 1
        '            Dim gridfound_index As Integer
        '            Dim gridfound_col As Integer = Val(dtdetail.Rows(0)("grid_col") & "")
        '            Dim gridfound_row As Integer = Val(dtdetail.Rows(0)("grid_row") & "")
        '            Dim countRows As Integer = Val(dtdetail.Rows(0)("vertical_line") & "")
        '            Dim countColums As Integer = Val(dtdetail.Rows(0)("horizontal_line") & "")
        '            Dim addstyle As String = " style=""background-color:red"""
        '            Dim tmpstyle As String = ""
        '            Dim strSQl As New StringBuilder
        '            strSQl.Append("<table border=""1"" style="" background: url('" & strimagebasesrc & "');background-size: 100% auto;background-repeat: no-repeat;align-content: center; border: 1px solid #484;width:740px;height:550px"" >")
        '            For i As Integer = 1 To countRows
        '                strSQl.Append("<tr>")
        '                For j As Integer = 1 To countColums
        '                    'If indexstrart = gridfound Then
        '                    '    tmpstyle = addstyle
        '                    'Else
        '                    '    tmpstyle = ""
        '                    'End If
        '                    If gridfound_col = j And gridfound_row = i Then
        '                        tmpstyle = addstyle
        '                        gridfound_index = indexstrart
        '                    Else
        '                        tmpstyle = ""
        '                    End If
        '                    strSQl.Append("<td id=" & indexstrart & " " & tmpstyle & ">")
        '                    strSQl.Append("</td>")
        '                    indexstrart = indexstrart + 1
        '                Next
        '                strSQl.Append("</tr>")
        '            Next
        '            strSQl.Append("</table>")

        '            Dim dt As New DataTable
        '            Dim dr As DataRow
        '            dt.Columns.Add("strmove_date")
        '            dt.Columns.Add("app_no")
        '            dt.Columns.Add("officer_name")
        '            dt.Columns.Add("location_name")
        '            dt.Columns.Add("showdata")
        '            dt.Columns.Add("showfound")
        '            dt.Columns.Add("borrowname")
        '            dt.Columns.Add("borrowerdate")
        '            dr = dt.NewRow
        '            dr("strmove_date") = dtdetail.Rows(0)("strmove_date") & ""
        '            dr("app_no") = dtdetail.Rows(0)("app_no") & ""
        '            dr("officer_name") = dtdetail.Rows(0)("officer_name") & ""
        '            dr("location_name") = dtdetail.Rows(0)("location_name") & ""
        '            dr("showdata") = strSQl.ToString
        '            dr("showfound") = gridfound_index
        '            dr("borrowname") = dtdetail.Rows(0)("borrowname") & ""
        '            dr("borrowerdate") = dtdetail.Rows(0)("borrowerdate") & ""
        '            dt.Rows.Add(dr)

        '            Dim strdata As String
        '            strdata = clsdtHelper.ConvertDataTableToJson(dt)

        '            Return strdata
        '        Else
        '            Return "[]"
        '        End If
        '    End If

        'Catch ex As Exception
        '    Return "[]"
        'End Try
    End Function

    <WebMethod()> _
    Public Function LoadFloorPlanByApp_No_NotMap(app_no As String, login_username As String) As String

        Return Engine.FileLocationENG.LoadFloorPlanByApp_No_NotMap(app_no, login_username)

        'Try
        '    'app_no = "0001000002"

        '        Dim dtdetail As DataTable
        '        Dim strSQlDetail As New StringBuilder

        '    ''strSQlDetail.Append(" select rq.id")
        '    ''strSQlDetail.Append(" ,fl.location_name")
        '    ''strSQlDetail.Append(" ,fl.description from ")
        '    ''strSQlDetail.Append(" TB_REQUISTION rq")
        '    ''strSQlDetail.Append(" inner join TB_FILELOCATION fl")
        '    ''strSQlDetail.Append(" on rq.filelocation = fl.id")
        '    ''strSQlDetail.Append(" where rq.app_no='" & app_no & "'")
        '    strSQlDetail.Append(" select fmh.id,r.room_name location_name, '' description  ")
        '    strSQlDetail.Append(" from [dbo].[TS_FILE_CURRENT_LOCATION] fmh")
        '    strSQlDetail.Append(" inner join ms_room r")
        '    strSQlDetail.Append(" on fmh.ms_room_id = r.id")
        '    strSQlDetail.Append(" where fmh.app_no='" & app_no & "'")



        '    dtdetail = DIPRFIDSqlDB.ExecuteTable(strSQlDetail.ToString)
        '    If dtdetail.Rows.Count <> 0 Then
        '        Dim strdata As String
        '        strdata = clsdtHelper.ConvertDataTableToJson(dtdetail)
        '        Return strdata
        '    Else
        '        Return "[]"
        '    End If
        'Catch ex As Exception
        '    Return "[]"
        'End Try
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
            strSql.Append(" select table1.id,convert(varchar, dateadd(year,0,table1.realdate),103) + ' ' + left(convert(varchar, table1.realdate,108),5)  as move_date,table1.app_no ,table1.borrowname,table1.location_name,table1.realdate,table1.status_name,table1.patent_type_name    from (")
            strSql.Append(" select  ")
            strSql.Append("  0 id")
            strSql.Append(" ,fvh.app_no  ,isnull(t.title_name,'') + o.fname + ' ' + o.lname  as borrowname ")
            strSql.Append(" ,fvh.location_name  + ',' + r.room_name  + ',' + f.floor_name as location_name")
            strSql.Append(" ,max(fvh.move_date) as realdate  ")
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
            strSql.Append(" group by")
            strSql.Append(" fvh.app_no  ,isnull(t.title_name,'') + o.fname + ' ' + o.lname ")
            strSql.Append(" ,fvh.location_name  + ',' + r.room_name  + ',' + f.floor_name ")
            strSql.Append(" ,p.patent_type_name ")
            strSql.Append(" ) as table1 ")
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

            Dim checktime As Integer = 0
            Dim counttime As Integer = 1
            Dim strStatus As String = ""
            Dim strStatusfrom As String = ""
            Dim strStatusTo As String = ""
            Dim strDatefrom As Date
            Dim strDateTo As Date
            Dim strtemp As String = ""
            If dt.Rows.Count > 0 Then
                strtemp = "<section id=""cd-timeline"" class=""cd-container"">"
                For i As Integer = 0 To dt.Rows.Count - 1
                    If checktime = 1 Then
                        strStatus = dt.Rows(i)("status_name") & ""
                    End If
                    If strStatus = "" Then
                        strStatusfrom = dt.Rows(i)("status_name") & ""
                        strStatus = dt.Rows(i)("status_name") & ""
                        strDatefrom = dt.Rows(i)("realdate") & ""
                    ElseIf strStatus <> dt.Rows(i)("status_name") & "" Then
                        strStatus = dt.Rows(i)("status_name") & ""
                        strStatusTo = dt.Rows(i)("status_name") & ""
                        strDateTo = dt.Rows(i)("realdate") & ""
                        checktime = 1
                    ElseIf strStatus = dt.Rows(i)("status_name") & "" Then
                        strStatus = dt.Rows(i)("status_name") & ""
                        strDatefrom = dt.Rows(i)("realdate") & ""
                        strStatusfrom = dt.Rows(i)("status_name") & ""
                        checktime = 0
                        counttime += 1
                    End If
                    Dim days As Integer = DateDiff(DateInterval.Day, strDatefrom, strDateTo)
                    Dim avg As Double = FormatNumber(days / counttime, 0)
                    Dim strlocation_name As String = dt.Rows(i)("location_name") & ""
                    Dim strborrowname As String = dt.Rows(i)("borrowname") & ""
                    Dim strMove_date As String = dt.Rows(i)("move_date") & ""

                    If checktime = 1 Then
                        strStatus = strStatus & " (" & strStatusfrom & "-->" & strStatusTo & " ใช้เวลาทั้งหมดเฉลี่ย=" & avg & "วัน)"
                    End If

                    strtemp &= "<div class=""cd-timeline-block"">"
                    strtemp &= "    <div class=""cd-timeline-img cd-picture"">"
                    strtemp &= "        <img src=""assets/js/vertical-timeline/img/cd-icon-location.svg"" alt=""Location"">"
                    strtemp &= "    </div> "
                    strtemp &= "    <div class=""cd-timeline-content"">"
                    strtemp &= "        <h2>" & strStatus & "</h2>"
                    strtemp &= "        <p>" & strlocation_name & "</p>"
                    If strborrowname <> "" Then
                        strtemp &= "        <p>" & strborrowname & "</p>"
                    End If

                    strtemp &= "    <span class=""cd-date"">" & strMove_date & "</span>"
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

    <WebMethod()> _
    Public Function LoadSearchFileStatus_ByTime(patenttype As String, datefrom As String, dateto As String) As String
        Try
            '0201001501
            Dim strdata As String
            Dim strSql As New StringBuilder
            strSql.Append(" exec SP_Timeline " & patenttype & ",'" & datefrom & "','" & dateto & "' ")


            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)

            Dim checktime As Integer = 0
            Dim counttime As Integer = 1
            Dim strStatus As String = ""
            Dim strStatusfrom As String = ""
            Dim strStatusTo As String = ""
            Dim stramountcounttext As String = ""
            Dim strtemp As String = ""
            Dim stramountcount As String
            Dim stravgamountcounttext As String
            If dt.Rows.Count > 0 Then
                strtemp = "<section id=""cd-timeline"" class=""cd-container"">"
                For i As Integer = 0 To dt.Rows.Count - 1

                    stramountcount = dt.Rows(i)("amountcount") & ""
                    stramountcounttext = dt.Rows(i)("stramountcount") & ""
                    stravgamountcounttext = dt.Rows(i)("stravgamount") & ""
                    strStatus = dt.Rows(i)("status") & ""

                    strtemp &= "<div class=""cd-timeline-block"">"
                    strtemp &= "    <div class=""cd-timeline-img cd-picture"">"
                    strtemp &= "        <img src=""assets/js/vertical-timeline/img/cd-icon-location.svg"" alt=""Location"">"
                    strtemp &= "    </div> "
                    strtemp &= "    <div class=""cd-timeline-content"">"
                    strtemp &= "        <h2>" & strStatus & "</h2>"
                    strtemp &= "        <p>" & stramountcounttext & "</p>"
                    strtemp &= "    <span class=""cd-date"">" & stravgamountcounttext & "</span>"
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

    <WebMethod()> _
    Public Function LoadSearchFileStatus_ByTime_Type2(patenttype As String, datefrom As String, dateto As String) As String
       Try
            '0201001501
            Dim strdata As String
            Dim strSql As New StringBuilder
            strSql.Append(" exec SP_Timeline " & patenttype & ",'" & datefrom & "','" & dateto & "' ")


            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)

            Dim checktime As Integer = 0
            Dim counttime As Integer = 1
            Dim strStatus As String = ""
            Dim strStatusfrom As String = ""
            Dim strStatusTo As String = ""
            Dim stramountcounttext As String = ""
            Dim strtemp As String = ""
            Dim stramountcount As String
            Dim stravgamountcounttext As String
            Dim stravgamountcountdifftext As String
            Dim strTable As String
            Dim strcolorheader As String = "#FFFFFF"
            strTable = "<table width=""100%"" border=""3"" cellspacing=""5"" cellpadding=""5"">"
            strTable &= "   <tr>"
            strTable &= "    <td width=""20%""  align=""center"" bgcolor=""#FF0000"" color=""#00FFFF""><img src=""images/Create.jpg""  style=""display:block;"" width=""100%"" height=""100%""/></td>"
            strTable &= "    <td width=""20%""  align=""center"" bgcolor=""#00FF00""><img src=""images/Store.jpg""  style=""display:block;"" width=""100%"" height=""100%""/></td>"
            strTable &= "    <td width=""20%""  align=""center"" bgcolor=""#0000FF""><img src=""images/Share.jpg""  style=""display:block;"" width=""100%"" height=""100%""/></td>"
            strTable &= "    <td width=""20%""  align=""center"" bgcolor=""#FFFF00""><img src=""images/Archive.jpg""  style=""display:block;"" width=""100%"" height=""100%""/></td>"
            strTable &= "    <td width=""20%""  align=""center"" bgcolor=""#00FFFF""><img src=""images/Destroy.jpg""  style=""display:block;"" width=""100%"" height=""100%""/></td>"
            strTable &= "   </tr>"
            strTable &= "   <tr>"
            Dim strall As String() = {"#FF0000", "#00FF00", "#0000FF", "#FFFF00", "#00FFFF"}
            If dt.Rows.Count > 0 Then
                'strtemp = "<section id=""cd-timeline"" class=""cd-container"">"
                For i As Integer = 0 To dt.Rows.Count - 1

                    stramountcount = dt.Rows(i)("amountcount") & ""
                    stramountcounttext = dt.Rows(i)("stramountcount") & ""
                    stravgamountcounttext = dt.Rows(i)("stravgamount") & ""
                    stravgamountcountdifftext = dt.Rows(i)("stramountcountdiff") & ""
                    strStatus = dt.Rows(i)("status") & ""

                    strtemp = "    <div>"
                    strtemp &= "        <p>" & stramountcounttext & "</p>"
                    ' strtemp &= "    <span >" & stravgamountcounttext & "</span>"
                    strtemp &= "        <p>" & stravgamountcounttext & "</p>"
                    strtemp &= "        <p>" & stravgamountcountdifftext & "</p>"
                    strtemp &= "    </div> "

                    strTable &= "    <td width=""20%"" height=""425px"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & strtemp & "</strong></td>"

                    '    strtemp &= "<div class=""cd-timeline-block"">"
                    '    strtemp &= "    <div class=""cd-timeline-img cd-picture"">"
                    '    strtemp &= "        <img src=""assets/js/vertical-timeline/img/cd-icon-location.svg"" alt=""Location"">"
                    '    strtemp &= "    </div> "
                    '    strtemp &= "    <div class=""cd-timeline-content"">"
                    '    strtemp &= "        <h2>" & strStatus & "</h2>"
                    '    strtemp &= "        <p>" & stramountcounttext & "</p>"
                    '    strtemp &= "    <span class=""cd-date"">" & stravgamountcounttext & "</span>"
                    '    strtemp &= "    </div> "
                    '    strtemp &= "</div> "
                Next

                'strtemp &= "</section>"
            End If
            strTable &= "   </tr>"
            strTable &= "</table>"
            Return strTable
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
    Public Function LoadSearchByFloor() As String
        Try
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY fl.id asc) AS no")
            strSql.Append(" ,fl.id")
            strSql.Append(" ,fl.floor_name")
            strSql.Append(" from ms_floor fl")
            strSql.Append(" where fl.active_status ='Y'")
            strSql.Append(" and fl.id in (" & Engine.GlobalFunction.GetSysConfing("Signage6FloorID") & ")")
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
            strSql.Append(" where pt.id<>2")
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
    Public Function LoadUserByName2(name As String) As String
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

    '<WebMethod()> _
    'Public Function LoadUserByDepartment(name As String, department_id As String) As String
    '    Try
    '        Dim dt As DataTable
    '        Dim strSql As New StringBuilder
    '        Dim strdata As String
    '        strSql.Append(" select table2.* from (")
    '        strSql.Append(" select  ")
    '        strSql.Append(" distinct fb.borrowername + '('  + table1.department_name + ')' as label  ")
    '        strSql.Append(" ,fb.borrowername as fullname  ")
    '        strSql.Append(" ,table1.department_id ")
    '        strSql.Append(" from tb_fileborrow fb ")
    '        strSql.Append(" inner join ( ")
    '        strSql.Append("         select distinct t.title_name + o.fname + ' ' + lname as fullname,o.department_id,d.department_name   from tb_officer o ")
    '        strSql.Append("         inner join tb_title t ")
    '        strSql.Append("         on o.title_id = t.id ")
    '        strSql.Append("         inner join tb_department d ")
    '        strSql.Append("         on o.department_id = d.id ")
    '        strSql.Append(" )  as table1 on table1.fullname = fb.borrowername  ")
    '        strSql.Append(" where table1.department_id Is Not null ")
    '        strSql.Append(" and  fb.borrowername like '%" & name & "%'")
    '        If department_id <> "" Then
    '            strSql.Append(" and  table1.department_id=" & department_id)
    '        End If
    '        strSql.Append("  ) as table2")
    '        strSql.Append(" order by table2.label ")
    '        dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
    '        If dt.Rows.Count > 0 Then
    '            strdata = clsdtHelper.ConvertDataTableToJson(dt)
    '        Else
    '            strdata = "[]"
    '        End If
    '        Return strdata
    '    Catch ex As Exception
    '        Return "[]"
    '    End Try

    'End Function

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

    '#Region "Portal"
    '    <WebMethod()> _
    '    Public Function LoadPortalReserve(memberid As String) As String
    '        Try
    '            Dim strdata As String
    '            Dim strSql As New StringBuilder
    '            strSql.Append(" select ")
    '            strSql.Append(" ROW_NUMBER() OVER(ORDER BY reserve_order desc) AS no")
    '            strSql.Append(" ,req_no as app_no")
    '            strSql.Append(" ,convert(varchar,reserve_date,103) as reserve_date")
    '            strSql.Append(" ,patent_type_name ")
    '            strSql.Append(" ,reserve_order")
    '            strSql.Append(" ,app_status")
    '            strSql.Append(" ,(case when reserve_status='Y' then 'ว่าง' ")
    '            strSql.Append(" else 'ไม่ว่าง' end) as reserve_status")
    '            strSql.Append(" ,BORROWNAME ")
    '            strSql.Append(" from   v_reserve_list where member_id='" & memberid & "'")
    '            strSql.Append(" and  reserve_status='Y'")
    '            strSql.Append(" order by reserve_date desc, reserve_order asc,reserve_status desc")
    '            Dim trans As New TransactionDB(SelectDB.DIPRFID)
    '            Dim dt As DataTable
    '            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
    '            If dt.Rows.Count > 0 Then
    '                strdata = clsdtHelper.ConvertDataTableToJson(dt)
    '            Else
    '                strdata = "[]"
    '            End If
    '            Return strdata
    '        Catch ex As Exception
    '            Return "[]"
    '        End Try
    '    End Function

    '    <WebMethod()> _
    '    Public Function LoadPortalBorrow(memberid As String) As String
    '        Try
    '            Dim strdata As String
    '            Dim strSql As New StringBuilder
    '            strSql.Append(" select ")
    '            strSql.Append(" ROW_NUMBER() OVER(ORDER BY tfi.borrowdate desc) AS no ")
    '            strSql.Append(" ,tfi.app_no ")
    '            strSql.Append(" ,convert(varchar,tfi.borrowdate,103) as borrowdate ")
    '            strSql.Append(" ,datediff(day,tfi.borrowdate,getdate()) as duration ")
    '            strSql.Append(" ,'' as strduration ")
    '            strSql.Append(" ,patent_type_name ")
    '            strSql.Append(" from TMP_FILEBORROWITEM tfi ")
    '            strSql.Append(" inner join TB_REQUISTION rq ")
    '            strSql.Append(" on rq.app_no = tfi.app_no ")
    '            strSql.Append(" inner join TB_PATENT_TYPE pt ")
    '            strSql.Append(" on pt.id=rq.patent_type_id ")
    '            strSql.Append(" where borrower_id='" & memberid & "' ")
    '            strSql.Append(" order by tfi.borrowdate desc ")
    '            Dim trans As New TransactionDB(SelectDB.DIPRFID)
    '            Dim dt As DataTable
    '            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
    '            If dt.Rows.Count > 0 Then
    '                For i As Integer = 0 To dt.Rows.Count - 1
    '                    dt.Rows(i)("strduration") = FormatNumber(dt.Rows(i)("duration"), 0) & " วัน"
    '                Next
    '                strdata = clsdtHelper.ConvertDataTableToJson(dt)
    '            Else
    '                strdata = "[]"
    '            End If
    '            Return strdata
    '        Catch ex As Exception
    '            Return "[]"
    '        End Try
    '    End Function
    '#End Region
#End Region

#Region "Web Config"

#Region "Desktop"
    <WebMethod()> _
    Public Function LoadDesktopAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY msd.id asc) AS no,[dbo].IsReferenctDesktop(msd.id) as IsDelete")
            strSql.Append(" ,msd.id")
            strSql.Append(" ,ms_room_id")
            strSql.Append(" ,desk_name")
            strSql.Append(" ,tb_officer_id")
            strSql.Append(" ,room_name")
            strSql.Append(" ,floor_name")
            strSql.Append(" ,title_name + ' ' + fname + ' ' + lname as fullname")
            strSql.Append(" ,(case when isnull(msd.active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status")
            strSql.Append(" from MS_DESKTOP msd inner join ms_room msr on msd.ms_room_id = msr.id inner join ms_floor msf on msr.ms_floor_id = msf.id")
            strSql.Append(" inner join TB_OFFICER o on msd.tb_officer_id = o.id")
            strSql.Append(" inner join TB_TITLE t on o.title_id = t.id")
            strSql.Append(" order by desk_name")

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
    Public Function GetDesktopById(id As String) As String
        Try
            Dim dt As DataTable
            Dim sql As String = "select msd.id,ms_room_id,desk_name,tb_officer_id,msd.active_status,title_name + ' ' + fname + ' ' + lname as label,msr.ms_floor_id "
            sql &= " from MS_DESKTOP msd inner join ms_room msr on msd.ms_room_id = msr.id inner join ms_floor msf on msr.ms_floor_id = msf.id"
            sql &= " inner join TB_OFFICER o on msd.tb_officer_id = o.id"
            sql &= " inner join TB_TITLE t on o.title_id = t.id  WHERE msd.ID=" & id
            dt = DIPRFIDSqlDB.ExecuteTable(Sql)
            If dt.Rows.Count <> 0 Then
                Return clsdtHelper.ConvertDataTableToJson(dt)
            Else
                Return "[]"
            End If
        Catch ex As Exception
            Return "[]"
        End Try

    End Function


    <WebMethod()> _
    Public Function GetDesktopNameByOfficer(officer_id As String) As String
        Try
            Dim dt As DataTable
            Dim sql As String = "select top 1 desk_name,isnull(room_name,'') room_name,isnull(floor_name,'') floor_name "
            sql &= " from ms_desktop left join ms_room on ms_desktop.ms_room_id = ms_room.id"
            sql &= " left join ms_floor on ms_room.ms_floor_id = ms_floor.id where tb_officer_id ='" & officer_id & "'"
            dt = DIPRFIDSqlDB.ExecuteTable(sql)
            If dt.Rows.Count <> 0 Then
                Return clsdtHelper.ConvertDataTableToJson(dt)
            Else
                Return "[]"
            End If
        Catch ex As Exception
            Return "[]"
        End Try

    End Function


    <WebMethod()> _
    Public Function SaveDesktop(id As String, desk_name As String, ms_room_id As String, tb_officer_id As String _
                             , active As String, login_username As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from MS_DESKTOP where desk_name ='" & desk_name & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_desk_name
                Return retStatus
            End If

            ret = DIPRFIDSqlDB.ExecuteNonQuery("delete from MS_DESKTOP_GRID where ms_desktop_id in (select id from MS_DESKTOP where id='" & id & "' and ms_room_id <> '" & ms_room_id & "')")
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If

            Dim lnq As New MsDesktopLinqDB
            With lnq
                .GetDataByPK(id, trans.Trans)
                .MS_ROOM_ID = ms_room_id
                .DESK_NAME = desk_name
                .TB_OFFICER_ID = tb_officer_id
                .ACTIVE_STATUS = IIf(active = 0, "N", "Y")

                If lnq.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If
            End With


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function DeleteDesktop(id As String) As Boolean
        Try
            Dim ret As Boolean = False
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_DESKTOP WHERE ID=" & id)
            Return ret
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "Department"
    <WebMethod()> _
    Public Function LoadDepartment() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY b.id asc) AS no")
            strSql.Append(" ,b.id")
            strSql.Append(" ,b.department_name")
            strSql.Append(" ,b.department_code")
            strSql.Append(" from ms_department b")
            strSql.Append(" order by b.department_name")
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
    Public Function LoadDepartmentByUser(user_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY d.id asc) AS no")
            strSql.Append(" ,d.id")
            strSql.Append(" ,d.department_name")
            strSql.Append(" ,d.department_code")
            strSql.Append(" , (case  when isnull(u.department_id,'')='' then '' else 'selected' end) selected")
            strSql.Append(" from tb_department d")
            strSql.Append(" left join tb_officer u")
            strSql.Append(" on d.id = u.department_id and u.id = " & Val(user_id))
            strSql.Append(" order by d.department_name")

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

#Region "Temperature&Particle"

    <WebMethod()> _
    Public Function SaveHumidity(MsHumidityTempID As Long) As String
        Dim retStatus As String = False
        Try
            Dim TextFile As String = Server.MapPath("Temp") & "\file.xls"
            If File.Exists(TextFile) = False Then
                retStatus = Utility.DefaultStringStatusReturn.notfoundtempfile
                Return retStatus
            End If

            Engine.ExcelFileENG.ReadTextExcelFromMHT381SD(MsHumidityTempID, TextFile)


            File.Delete(TextFile)
            retStatus = Utility.DefaultStringStatusReturn.complete
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try
        Return retStatus
    End Function


    <WebMethod()> _
    Public Function SavePaticle(ms_particle_counter_device_id As String, counter_mode As String, channel_0_3 As String, channel_0_5 As String, _
                                channel_1_0 As String, channel_2_5 As String, channel_5_0 As String, _
                                channel_10_0 As String, at As String, rh As String, dp As String, _
                                wb As String, filename As String, strfilebase64 As String) As String
        Dim retStatus As String = False
        Try

            Dim byteData As Byte()
            byteData = Convert.FromBase64String(strfilebase64)

            Dim eng As New Engine.ParticleENG
            With eng
                .COUNTER_MODE = counter_mode
                .CHANNEL_0_3 = channel_0_3
                .CHANNEL_0_5 = channel_0_5
                .CHANNEL_1_0 = channel_1_0
                .CHANNEL_2_5 = channel_2_5
                .CHANNEL_5_0 = channel_5_0
                .CHANNEL_10_0 = channel_10_0
                .AIR_TEMPERATURE = at
                .RELATIVE_HUMIDITY = rh
                .DEWPOINT_TEMPERATURE = dp
                .WET_BULB_TEMPERATURE = wb
                .MS_PARTICLE_COUNTER_DEVICE_ID = ms_particle_counter_device_id
                .IMPORT_TIME = DateTime.Now
                .LOG_FILE_NAME = filename
                .LOG_FILE_BYTE = byteData
            End With

            Dim trans As New LinqDB.ConnectDB.TransactionDB(LinqDB.ConnectDB.SelectDB.DIPRFID)
            Dim ret = Engine.ParticleENG.SaveParticleCounterData("SYSTEM", eng, trans)
            If ret = True Then
                trans.CommitTransaction()
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                trans.RollbackTransaction()
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If


        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try
        Return retStatus
    End Function


    <WebMethod()> _
    Public Function LoadTempertureHistory(room As String, datefrom As String, dateto As String, device As String, _
                                          humidityfrom As String, humidityto As String, temperaturefrom As String, _
                                          temperatureto As String, temptype As String) As String
        Try

            Dim wh As String = ""
            If room <> "" Then
                wh &= " and  ms_room_id = '" & room & "'"
            End If

            If datefrom <> "" And dateto <> "" Then
                wh &= " and convert(varchar(10),record_datetime,103) between '" & datefrom & "' and '" & dateto & "'"
            End If

            If device <> "" Then
                wh &= " and h.ms_humidity_temp_id ='" & device & "'"
            End If

            If humidityfrom <> "" And humidityto <> "" Then
                wh &= " and humidity_value between " & humidityfrom & " and " & humidityto
            End If

            If temperaturefrom <> "" And temperatureto <> "" Then
                wh &= " and temp_value between " & temperaturefrom & " and " & temperatureto
            End If

            If temptype <> "" Then
                wh &= " and temp_unit ='" & temptype & "'"
            End If

            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select Top 10000 ROW_NUMBER() OVER(ORDER BY h.id asc) AS no,room_name,d.serial_no,")
            strSql.Append(" convert(varchar(10),record_datetime,103) as record_datetime,humidity_value,(Str(temp_value, 25, 1) + ' '+ temp_unit) as temp")
            strSql.Append(" from TS_HUMIDITY_TEMP_HISTORY h inner join MS_HUMIDITY_TEMP_DEVICE  d on h.ms_humidity_temp_id = d.id")
            strSql.Append(" left join MS_ROOM r on d.ms_room_id = r.id ")
            strSql.Append(" where  1 = 1 " & wh & " order by room_name,d.serial_no ")

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
    Public Function LoadParticleHistory(room As String, datefrom As String, dateto As String, device As String) As String
        Try

            Dim wh As String = ""
            If room <> "" Then
                wh &= " and  ms_room_id = '" & room & "'"
            End If

            If datefrom <> "" And dateto <> "" Then
                wh &= " and convert(varchar(10),import_time,103) between '" & datefrom & "' and '" & dateto & "'"
            End If

            If device <> "" Then
                wh &= " and h.ms_particle_counter_device_id ='" & device & "'"
            End If

            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String

            strSql.Append(" select Top 10000 ROW_NUMBER() OVER(ORDER BY h.id asc) AS no,room_name,d.serial_no")
            strSql.Append(" ,convert(varchar,import_time ,103) + ' ' + convert(varchar,import_time ,108) as import_time")
            strSql.Append(" ,counter_mode,channel_0_3,channel_0_5,channel_1_0,channel_2_5,channel_5_0,channel_10_0")
            strSql.Append(" ,air_temperature,relative_humidity,dewpoint_temperature,wet_bulb_temperature")
            strSql.Append(" from TS_PARTICLE_COUNTER_HISTORY h inner join MS_PARTICLE_COUNTER_DEVICE d on h.ms_particle_counter_device_id = d.id")
            strSql.Append(" left join MS_ROOM r on d.ms_room_id = r.id")
            strSql.Append(" where  1 = 1 " & wh & " order by room_name,d.serial_no ")

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
    Public Function LoadDeviceByMsTempRoom(ms_room_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select id,serial_no from MS_HUMIDITY_TEMP_DEVICE where ms_room_id ='" & ms_room_id & "' and active_status = 'Y' order by serial_no ")

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
    Public Function LoadDeviceByMsParticle(ms_room_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select id,serial_no from MS_PARTICLE_COUNTER_DEVICE where ms_room_id ='" & ms_room_id & "' and active_status = 'Y' order by serial_no ")

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
    Public Function LoadTemperature() As String
        Try
            Dim dt As New DataTable
            dt.Columns.Add("ID")
            dt.Columns.Add("Temp")
            Dim dr As DataRow

            dr = dt.NewRow
            dr("ID") = "C"
            dr("Temp") = "C"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("ID") = "F"
            dr("Temp") = "F"
            dt.Rows.Add(dr)

            Dim strdata As String
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
    Public Sub UpLoadFile(strfilebase64 As String, filename As String)

        Dim path As String = Server.MapPath("Temp")
        If Directory.Exists(path) = False Then
            Directory.CreateDirectory(path)
        End If

        If File.Exists(path & "\" & filename) Then
            File.Delete(path & "\" & filename)
        End If

        Dim byteData As Byte()
        byteData = Convert.FromBase64String(strfilebase64)

        Dim oFileStream As System.IO.FileStream
        oFileStream = New System.IO.FileStream(path & "\" & filename, System.IO.FileMode.Create)
        oFileStream.Write(byteData, 0, byteData.Length)
        oFileStream.Close()
    End Sub

    <WebMethod()> _
    Public Function ClearDataFromFile() As String
        Dim path As String = Server.MapPath("Temp") & "\file.xls"
        If File.Exists(path) Then
            File.Delete(path)
        End If

        Dim dt As New DataTable
        dt.Columns.Add("no")
        dt.Columns.Add("record_datetime")
        dt.Columns.Add("humidity_value")
        dt.Columns.Add("temp")
        Dim strdata As String
        strdata = clsdtHelper.ConvertDataTableToJson(dt)
        Return strdata
    End Function

    <WebMethod()> _
    Public Function LoadDataFromFile() As String
        Try
            Dim path As String = Server.MapPath("Temp") & "\file.xls"
            Dim dt As New DataTable
            dt.Columns.Add("no")
            dt.Columns.Add("record_datetime")
            dt.Columns.Add("humidity_value")
            dt.Columns.Add("temp")
            Dim dr As DataRow

            Dim Stream As New StreamReader(path, System.Text.UnicodeEncoding.Default)
            Dim i As Long = 0
            Dim r As Integer = 1
            While Stream.Peek <> -1
                Dim str As String = Stream.ReadLine
                If str.Trim <> "" Then
                    Try
                        If i = 0 Then   'First row is a Header Row
                            i += 1
                            Continue While
                        End If

                        Dim strFld As String() = Split(str, Chr(9))

                        dr = dt.NewRow
                        dr("no") = r
                        dr("record_datetime") = cStrToDateTime3(strFld(1).Trim, strFld(2).Trim)
                        dr("humidity_value") = Convert.ToDouble(strFld(3).Trim)
                        dr("temp") = Convert.ToDouble(strFld(5).Trim) & " " & strFld(6).Trim.Replace("DEGREE ", "")
                        dt.Rows.Add(dr)

                    Catch ex As Exception
                    End Try
                End If
                i += 1
                r += 1
            End While
            Stream.Close()
            Stream = Nothing

            Dim strdata As String
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
    Public Function LoadDataFromParticleFile() As String

        Try
            Dim path As String = Server.MapPath("Temp") & "\particlefile.txt"
            Dim dt As New DataTable
            dt.Columns.Add("CounterMode")
            dt.Columns.Add("c03mu")
            dt.Columns.Add("c05mu")
            dt.Columns.Add("c10mu")
            dt.Columns.Add("c25mu")
            dt.Columns.Add("c50mu")
            dt.Columns.Add("c100mu")
            dt.Columns.Add("AT")
            dt.Columns.Add("RH")
            dt.Columns.Add("DP")
            dt.Columns.Add("WB")
            Dim dr As DataRow

            Dim eng As New Engine.ParticleENG
            eng.ReadTextFileData("SYSTEM", path)
            If eng.HaveData = True Then
                dr = dt.NewRow
                dr("CounterMode") = eng.COUNTER_MODE
                dr("c03mu") = eng.CHANNEL_0_3
                dr("c05mu") = eng.CHANNEL_0_5
                dr("c10mu") = eng.CHANNEL_1_0
                dr("c25mu") = eng.CHANNEL_2_5
                dr("c50mu") = eng.CHANNEL_5_0
                dr("c100mu") = eng.CHANNEL_10_0
                dr("AT") = eng.AIR_TEMPERATURE
                dr("RH") = eng.RELATIVE_HUMIDITY
                dr("DP") = eng.DEWPOINT_TEMPERATURE
                dr("WB") = eng.WET_BULB_TEMPERATURE
                dt.Rows.Add(dr)
            End If
            Dim strdata As String
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

    Function cStrToDateTime2(ByVal StrDate As String, ByVal StrTime As String) As DateTime
        'Convert วันที่จาก d/M/yyyy HH:mm:ss เป็น DateTime
        Dim ret As New Date(1, 1, 1)
        If StrDate.Trim <> "" Then
            Dim vDate() As String = Split(StrDate, "/")
            If StrTime.Trim <> "" Then
                Dim vTime() As String = Split(StrTime, ":")
                ret = New Date(vDate(2), vDate(1), vDate(0), vTime(0), vTime(1), vTime(2))
            Else
                ret = New Date(vDate(0), vDate(1), vDate(2))
            End If
        End If
        Return ret
    End Function

    Function cStrToDateTime3(ByVal StrDate As String, ByVal StrTime As String) As DateTime
        'Convert วันที่จาก yyyy/MM/dd HH:mm:ss เป็น DateTime
        Dim ret As New Date(1, 1, 1)
        If StrDate.Trim <> "" Then
            Dim vDate() As String = Split(StrDate, "/")
            If StrTime.Trim <> "" Then
                Dim vTime() As String = Split(StrTime, ":")
                ret = New Date(vDate(0), vDate(1), vDate(2), vTime(0), vTime(1), vTime(2))
            Else
                ret = New Date(vDate(0), vDate(1), vDate(2))
            End If
        End If
        Return ret
    End Function
#End Region

#Region "DigitalSinageTemplateSchedule"

    <WebMethod()> _
    Public Function LoadSinageScheduleAll() As String
        Try

            Dim strdata As String
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            'strSql.Append(" select ROW_NUMBER() OVER(ORDER BY s.id asc) AS no,s.id,schedule_name,ms_led_tv_id,tv_name,floor_name,")
            'strSql.Append(" (case when isnull(s.active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status,schedule_type,[dbo].IsReferenctSinageContentTemplateSchedule(s.id) as IsDelete ")
            'strSql.Append(" ,convert(varchar(10),start_time,103)+ ' ' + convert(varchar(10),start_time,108) start_time")
            'strSql.Append(" ,convert(varchar(10),end_time,103)+ ' ' + convert(varchar(10),end_time,108) end_time")
            'strSql.Append(" from MS_SIGNAGE_TEMPLATE_SCHEDULE s left join MS_LED_TV  l on s.ms_led_tv_id = l.id ")
            'strSql.Append(" left join MS_FLOOR f on l.ms_floor_id = f.id order by schedule_name")


            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY s.id asc) AS no,s.id,schedule_name,ms_led_tv_id,tv_name,floor_name,")
            strSql.Append(" (case when isnull(s.active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status,schedule_type")
            strSql.Append(" ,[dbo].IsReferenctSinageContentTemplateSchedule(s.id) as IsDelete ")
            strSql.Append(" ,convert(varchar(10),start_time,103)+ ' ' + convert(varchar(10),start_time,108) start_time")
            strSql.Append(" ,convert(varchar(10),end_time,103)+ ' ' + convert(varchar(10),end_time,108) end_time,")
            strSql.Append(" isnull((select id ")
            strSql.Append(" from MS_SIGNAGE_CONTENT_SCH_DATA")
            strSql.Append(" where ms_led_tv_id = s.ms_led_tv_id And ms_signage_template_schedule_id = s.id")
            strSql.Append(" and getdate() between start_time and end_time),0) current_schedule")
            strSql.Append(" from MS_SIGNAGE_TEMPLATE_SCHEDULE s ")
            strSql.Append(" left join MS_LED_TV  l on s.ms_led_tv_id = l.id ")
            strSql.Append(" left join MS_FLOOR f on l.ms_floor_id = f.id ")
            strSql.Append(" order by tv_name")

            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            'dt.Columns.Add("trigger")

            'For i As Integer = 0 To dt.Rows.Count - 1
            '    Dim ms_signage_template_schedule_id As String = dt.Rows(i).Item("id").ToString
            '    Dim schedule_type As String = dt.Rows(i).Item("schedule_type").ToString
            '    Dim trigger As String = ""
            '    If schedule_type = "D" Then
            '        Dim dtDaily As DataTable
            '        strSql = New StringBuilder
            '        strSql.Append(" select id,ms_signage_template_schedule_id,recur_every_days from MS_SIGNAGE_SCHEDULE_DAILY")
            '        strSql.Append(" where ms_signage_template_schedule_id ='" & ms_signage_template_schedule_id & "'")
            '        dtDaily = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            '        If dtDaily.Rows.Count > 0 Then
            '            Dim recur_every_days As String = dtDaily.Rows(0)("recur_every_days") & ""
            '            trigger = "Recur every " & recur_every_days & " Days"
            '        End If
            '    End If


            '    If schedule_type = "W" Then
            '        Dim dtWeekly As DataTable
            '        strSql = New StringBuilder
            '        strSql.Append(" select id,ms_signage_template_schedule_id,recur_every_week,sch_sun ,")
            '        strSql.Append(" sch_mon,sch_tue,sch_wed,sch_thu,sch_fri,sch_sat  from MS_SIGNAGE_SCHEDULE_WEEKLY")
            '        strSql.Append(" where ms_signage_template_schedule_id ='" & ms_signage_template_schedule_id & "'")
            '        dtWeekly = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            '        If dtWeekly.Rows.Count > 0 Then
            '            Dim recur_every_week As String = dtWeekly.Rows(0)("recur_every_week") & ""
            '            Dim sch_sun As String = dtWeekly.Rows(0)("sch_sun") & ""
            '            Dim sch_mon As String = dtWeekly.Rows(0)("sch_mon") & ""
            '            Dim sch_tue As String = dtWeekly.Rows(0)("sch_tue") & ""
            '            Dim sch_wed As String = dtWeekly.Rows(0)("sch_wed") & ""
            '            Dim sch_thu As String = dtWeekly.Rows(0)("sch_thu") & ""
            '            Dim sch_fri As String = dtWeekly.Rows(0)("sch_fri") & ""
            '            Dim sch_sat As String = dtWeekly.Rows(0)("sch_sat") & ""
            '            trigger = "Recur every " & recur_every_week & " Week on "
            '            If sch_sun = "Y" Then
            '                trigger &= "Sunday,"
            '            End If
            '            If sch_mon = "Y" Then
            '                trigger &= "Monday,"
            '            End If
            '            If sch_tue = "Y" Then
            '                trigger &= "Tuesday,"
            '            End If
            '            If sch_wed = "Y" Then
            '                trigger &= "Wednesday,"
            '            End If
            '            If sch_thu = "Y" Then
            '                trigger &= "Thursday,"
            '            End If
            '            If sch_fri = "Y" Then
            '                trigger &= "Friday,"
            '            End If
            '            If sch_sat = "Y" Then
            '                trigger &= "Saturday,"
            '            End If

            '            trigger = trigger.Substring(0, trigger.Length - 1)
            '        End If
            '    End If


            '    If schedule_type = "M" Then
            '        Dim dtMonthly As DataTable
            '        strSql = New StringBuilder
            '        strSql.Append(" select distinct ms_signage_template_schedule_id,month_no,date_no,case month_no")
            '        strSql.Append(" when 1 then 'January'")
            '        strSql.Append(" when 2 then 'February'")
            '        strSql.Append(" when 3 then 'March'")
            '        strSql.Append(" when 4 then 'April'")
            '        strSql.Append(" when 5 then 'May'")
            '        strSql.Append(" when 6 then 'June'")
            '        strSql.Append(" when 7 then 'July'")
            '        strSql.Append(" when 8 then 'August'")
            '        strSql.Append(" when 9 then 'September'")
            '        strSql.Append(" when 10 then 'October'")
            '        strSql.Append(" when 11 then 'November'")
            '        strSql.Append(" when 12 then 'December'")
            '        strSql.Append(" end [MonthsEng],")
            '        strSql.Append(" Case month_no")
            '        strSql.Append(" when 1 then 'มกราคม'")
            '        strSql.Append(" when 2 then 'กุมภาพันธ์'")
            '        strSql.Append(" when 3 then 'มีนาคม'")
            '        strSql.Append(" when 4 then 'เมษายน'")
            '        strSql.Append(" when 5 then 'พฤษภาคม'")
            '        strSql.Append(" when 6 then 'มิถุนายน'")
            '        strSql.Append(" when 7 then 'กรกฏาคม'")
            '        strSql.Append(" when 8 then 'สิงหาคม'")
            '        strSql.Append(" when 9 then 'กันยายน'")
            '        strSql.Append(" when 10 then 'ตุลาคม'")
            '        strSql.Append(" when 11 then 'พฤศจิกายน'")
            '        strSql.Append(" when 12 then 'ธันวาคม'")
            '        strSql.Append(" end [MonthsThai] from MS_SIGNAGE_SCHEDULE_MONTHLY")
            '        strSql.Append(" where ms_signage_template_schedule_id ='" & ms_signage_template_schedule_id & "'")
            '        dtMonthly = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)

            '        If dtMonthly.Rows.Count > 0 Then
            '            Dim dttempM As DataTable
            '            dttempM = dtMonthly.DefaultView.ToTable(True, "MonthsThai").Copy

            '            Dim dttempD As DataTable
            '            dttempD = dtMonthly.DefaultView.ToTable(True, "date_no").Copy

            '            trigger = "Month :"
            '            For j As Integer = 0 To dttempM.Rows.Count - 1
            '                Dim months As String = dttempM.Rows(j)("MonthsThai") & ""
            '                trigger &= months & ","
            '            Next
            '            trigger = trigger.Substring(0, trigger.Length - 1) & vbCrLf

            '            trigger &= "Days :"
            '            For k As Integer = 0 To dttempD.Rows.Count - 1
            '                Dim days As String = dttempD.Rows(k)("date_no") & ""
            '                trigger &= days & ","
            '            Next
            '            trigger = trigger.Substring(0, trigger.Length - 1) & vbCrLf
            '        End If
            '    End If


            'Dim dtTime As DataTable
            'strSql = New StringBuilder
            'strSql.Append(" select st.id,ms_signage_template_schedule_id,duration_minute,ms_signage_content_template_id ,template_name")
            'strSql.Append(" from MS_SIGNAGE_SCHEDULE_TIME st inner join MS_SIGNAGE_CONTENT_TEMPLATE ct on st.ms_signage_content_template_id =ct.id")
            'strSql.Append(" where ms_signage_template_schedule_id ='" & ms_signage_template_schedule_id & "'")
            'dtTime = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            'trigger &= vbCrLf
            'trigger &= " Time :"
            'For n As Integer = 0 To dtTime.Rows.Count - 1
            '    Dim timefrom As String = dtTime.Rows(n)("time_from")
            '    Dim timeto As String = dtTime.Rows(n)("time_to")
            '    trigger &= vbCrLf
            '    trigger &= timefrom & "-" & timeto & ","
            'Next
            'trigger = trigger.Substring(0, trigger.Length - 1) & vbCrLf


            'dt.Rows(i)("trigger") = trigger
            'Next


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
    Public Function LoadSinageScheduleID(id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select id,schedule_name,ms_led_tv_id,")
            strSql.Append(" convert(varchar(10),start_time,103) start_date,convert(varchar(10),end_time,103) end_date,")
            strSql.Append(" convert(varchar(5),start_time,108) start_time,convert(varchar(5),end_time,108) end_time,")
            strSql.Append(" active_status, schedule_type")
            strSql.Append(" from MS_SIGNAGE_TEMPLATE_SCHEDULE where id ='" & id & "'")

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
    Public Function LoadMonthByDigitalSinageTemplateSchedule(ms_signage_template_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append("  select distinct T1.id,monthsthai,monthseng,isnull(selected,'') selected from (")
            strSql.Append("  select id,monthseng,monthsthai from  fnGetMonth()) T1")
            strSql.Append("  left join (")
            strSql.Append("  select month_no,'selected' selected from  MS_SIGNAGE_SCHEDULE_MONTHLY ssm")
            strSql.Append("  where ms_signage_template_schedule_id ='" & ms_signage_template_schedule_id & "') T2 on T1.id =T2.month_no")
            strSql.Append("  order by id")
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
    Public Function LoadDayByDigitalSinageTemplateSchedule(ms_signage_template_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select distinct T1.d,isnull(selected,'') selected from (")
            strSql.Append(" select * from  fnGetDay()) T1")
            strSql.Append(" left join (")
            strSql.Append(" select date_no,'selected' selected from  MS_SIGNAGE_SCHEDULE_MONTHLY ssm")
            strSql.Append(" where ms_signage_template_schedule_id ='" & ms_signage_template_schedule_id & "') T2 on T1.d =T2.date_no")
            strSql.Append(" order by d")

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
    Public Function LoadSinageScheduleDailyByTemplateID(ms_signage_template_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select id,ms_signage_template_schedule_id,recur_every_days from MS_SIGNAGE_SCHEDULE_DAILY")
            strSql.Append(" where ms_signage_template_schedule_id ='" & ms_signage_template_schedule_id & "'")

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
    Public Function LoadSinageScheduleWeeklyByTemplateID(ms_signage_template_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select id,ms_signage_template_schedule_id,recur_every_week,sch_sun ,")
            strSql.Append(" sch_mon,sch_tue,sch_wed,sch_thu,sch_fri,sch_sat   from MS_SIGNAGE_SCHEDULE_WEEKLY")
            strSql.Append(" where ms_signage_template_schedule_id ='" & ms_signage_template_schedule_id & "'")

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
    Public Function LoadSinageScheduleTimeByTemplateID(ms_signage_template_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY st.id asc) AS no,st.id,ms_signage_template_schedule_id,duration_minute,ms_signage_content_template_id ,template_name")
            strSql.Append(" from MS_SIGNAGE_SCHEDULE_TIME st inner join MS_SIGNAGE_CONTENT_TEMPLATE ct on st.ms_signage_content_template_id =ct.id")
            strSql.Append(" where ms_signage_template_schedule_id ='" & ms_signage_template_schedule_id & "'")

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
    Public Function CheckSinageScheduleTime(MsSignageTemplateScheduleID As Long, MsLedTvID As Long, start_date As String, _
                                         end_date As String, start_time As String, end_time As String) As Boolean

        Dim tempstartdate As DateTime = Date.ParseExact(start_date, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) & " " & start_time
        Dim tempenddate As DateTime = Date.ParseExact(end_date, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) & " " & end_time

        Dim ret As Boolean = Engine.DigitalSignageENG.CheckDuplicateSignageScheduleTime(MsSignageTemplateScheduleID, MsLedTvID, _
                                                                                        tempstartdate, tempenddate)
        Return ret
    End Function


    <WebMethod()> _
    Public Function SaveSinageSchedule(id As String, schedule_name As String, ms_led_tv_id As String, start_date As String, end_date As String, start_time As String, end_time As String, _
        active_status As String, daily As String, weekly As String, monthly As String, recur_every_days As String, recur_every_week As String, _
        sch_sun As String, sch_mon As String, sch_tue As String, sch_wed As String, sch_thu As String, sch_fri As String, sch_sat As String, _
        month_no As String, date_no As String, jsonobject_time As String, login_username As String) As String

        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try


            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from MS_SIGNAGE_TEMPLATE_SCHEDULE where schedule_name ='" & schedule_name & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_schedulename
                Return retStatus
            End If

            dt = New DataTable
            Dim sql As String = "select id from MS_SIGNAGE_TEMPLATE_SCHEDULE where ms_led_tv_id ='" & ms_led_tv_id & _
                                "' and convert(varchar(10),start_time,103) + ' ' + convert(varchar(5),start_time,108) = '" & start_date & " " & start_time & "' and id <> '" & id & "'"
            dt = DIPRFIDSqlDB.ExecuteTable(sql, trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_schedulestartdate
                Return retStatus
            End If

            Dim dtJson_time As DataTable = clsdtHelper.ConvertJSONToDataTable(jsonobject_time)
            dtJson_time.Rows.RemoveAt(dtJson_time.Rows.Count - 1)
            dtJson_time.AcceptChanges()
            'For i As Integer = 0 To dtJson_time.Rows.Count - 1
            '    Dim strtime() As String = dtJson_time.Rows(i)("strtime").ToString.Split("-")
            '    Dim dttime As New DataTable
            '    dttime = DIPRFIDSqlDB.ExecuteTable("select [dbo].CheckTimePeriod('" & id & "','" & ms_led_tv_id & "', '" & Replace(Trim(strtime(0)), ".", ":") & "','" & Replace(Trim(strtime(1)), ".", ":") & "')", trans.Trans)
            '    If dttime.Rows.Count > 0 Then
            '        Dim val As String = dttime.Rows(0)(0)
            '        If val = "T" Then
            '            retStatus = Utility.DefaultStringStatusReturn.duplicate_scheduletime & "|" & dtJson_time.Rows(i)("strtime").ToString
            '            Return retStatus
            '        End If
            '    End If
            'Next

            Dim SCHEDULE_TYPE As String = ""
            If daily.ToLower = "true" Then
                SCHEDULE_TYPE = "D"
            End If
            If weekly.ToLower = "true" Then
                SCHEDULE_TYPE = "W"
            End If
            If monthly.ToLower = "true" Then
                SCHEDULE_TYPE = "M"
            End If

            Dim tempstartdate As Date = Date.ParseExact(start_date, "dd/MM/yyyy",
            System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Dim tempenddate As Date = Date.ParseExact(end_date, "dd/MM/yyyy",
            System.Globalization.DateTimeFormatInfo.InvariantInfo)


            Dim ms_signage_template_schedule_id As String
            Dim lnq As New MsSignageTemplateScheduleLinqDB
            With lnq
                .GetDataByPK(id, trans.Trans)
                .SCHEDULE_NAME = schedule_name
                '.MS_SIGNAGE_CONTENT_TEMPLATE_ID = ms_signage_content_template_id
                .MS_LED_TV_ID = ms_led_tv_id
                .START_TIME = tempstartdate & " " & start_time
                .END_TIME = tempenddate & " " & end_time
                .SCHEDULE_TYPE = SCHEDULE_TYPE
                .SCHEDULE_STATUS = "N"
                .ACTIVE_STATUS = IIf(active_status = 0, "N", "Y")

                If lnq.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If

                ms_signage_template_schedule_id = .ID

                If ret = False Then
                    trans.RollbackTransaction()
                    Return Utility.DefaultStringStatusReturn.fail
                End If
            End With


            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_SIGNAGE_SCHEDULE_DAILY WHERE ms_signage_template_schedule_id =" & ms_signage_template_schedule_id, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_SIGNAGE_SCHEDULE_WEEKLY WHERE ms_signage_template_schedule_id =" & ms_signage_template_schedule_id, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_SIGNAGE_SCHEDULE_MONTHLY WHERE ms_signage_template_schedule_id =" & ms_signage_template_schedule_id, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If


            '== Daily ==
            If SCHEDULE_TYPE = "D" Then
                Dim lnqDaily As New MsSignageScheduleDailyLinqDB
                With lnqDaily
                    .MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = ms_signage_template_schedule_id
                    .RECUR_EVERY_DAYS = recur_every_days
                    ret = .InsertData(login_username, trans.Trans)

                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If
                End With
            End If


            '== Weekly ==
            If SCHEDULE_TYPE = "W" Then
                Dim lnqWeekly As New MsSignageScheduleWeeklyLinqDB
                With lnqWeekly
                    .MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = ms_signage_template_schedule_id
                    .RECUR_EVERY_WEEK = recur_every_week
                    .SCH_SUN = IIf(sch_sun = 0, "N", "Y")
                    .SCH_MON = IIf(sch_mon = 0, "N", "Y")
                    .SCH_TUE = IIf(sch_tue = 0, "N", "Y")
                    .SCH_WED = IIf(sch_wed = 0, "N", "Y")
                    .SCH_THU = IIf(sch_thu = 0, "N", "Y")
                    .SCH_FRI = IIf(sch_fri = 0, "N", "Y")
                    .SCH_SAT = IIf(sch_sat = 0, "N", "Y")
                    ret = .InsertData(login_username, trans.Trans)

                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If
                End With
            End If



            '== Monthly ==
            If SCHEDULE_TYPE = "M" Then
                month_no = month_no.Substring(0, month_no.Length - 1)
                date_no = date_no.Substring(0, date_no.Length - 1)
                Dim months() As String = month_no.Split(",")
                Dim dates() As String = date_no.Split(",")

                For i As Integer = 0 To months.Length - 1
                    For j As Integer = 0 To dates.Length - 1
                        Dim lnqMonthly As New MsSignageScheduleMonthlyLinqDB
                        With lnqMonthly
                            .MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = ms_signage_template_schedule_id
                            .MONTH_NO = months(i)
                            .DATE_NO = dates(j)
                            ret = .InsertData(login_username, trans.Trans)

                            If ret = False Then
                                trans.RollbackTransaction()
                                Return Utility.DefaultStringStatusReturn.fail
                            End If
                        End With
                    Next
                Next
            End If

            '== Time
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_SIGNAGE_SCHEDULE_TIME WHERE ms_signage_template_schedule_id =" & ms_signage_template_schedule_id, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If

            For i As Integer = 0 To dtJson_time.Rows.Count - 1
                Dim template_id As String = dtJson_time.Rows(i)("ms_signage_content_template_id")
                Dim duration_minute As String = dtJson_time.Rows(i)("duration_minute")
                Dim clsSpeedwayAntLinqDB As New MsSignageScheduleTimeLinqDB
                With clsSpeedwayAntLinqDB
                    .MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = ms_signage_template_schedule_id
                    '.TIME_FROM = Trim(strtime(0))
                    '.TIME_TO = Trim(strtime(1))
                    .DURATION_MINUTE = duration_minute
                    .MS_SIGNAGE_CONTENT_TEMPLATE_ID = template_id
                    ret = .InsertData(login_username, trans.Trans)

                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If

                End With
            Next


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            trans.RollbackTransaction()
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function DeleteSinageSchedule(id As String) As Boolean

        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Try
            Dim ret As Boolean = True
            Dim sql As String = "DELETE FROM  MS_SIGNAGE_SCHEDULE_TIME where ms_signage_template_schedule_id ='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM  MS_SIGNAGE_SCHEDULE_DAILY where ms_signage_template_schedule_id ='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM  MS_SIGNAGE_SCHEDULE_WEEKLY where ms_signage_template_schedule_id  ='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM  MS_SIGNAGE_SCHEDULE_MONTHLY where ms_signage_template_schedule_id ='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM MS_SIGNAGE_TEMPLATE_SCHEDULE where id='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret
        Catch ex As Exception
            Return False
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadTextSpeedLevel(text_speed As String) As String
        Try
            Dim dt As New DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String

            dt.Columns.Add("id")
            dt.Columns.Add("name")
            dt.Columns.Add("selected")

            Dim dr As DataRow
            dr = dt.NewRow
            dr("id") = "1"
            dr("name") = "Slow"
            dr("selected") = ""
            If text_speed = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "2"
            dr("name") = "Medium"
            dr("selected") = ""
            If text_speed = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "3"
            dr("name") = "Fast"
            dr("selected") = ""
            If text_speed = dr("id") Then
                dr("selected") = "selected"
            End If
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

#Region "Floor"
    <WebMethod()> _
    Public Function LoadFloorAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY f.id asc) AS no,[dbo].IsReferenctFLOOR(id) as IsDelete")
            strSql.Append(" ,f.id")
            strSql.Append(" ,(case when isnull(f.active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status")
            strSql.Append(" ,f.floor_name")
            strSql.Append(" ,f.ms_building_id,color")
            strSql.Append(" from ms_floor f")
            strSql.Append(" order by f.floor_name")

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
    Public Function GetFloorById(id As String) As String
        Try
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id,floor_name,color,active_status from ms_Floor WHERE ID=" & id)
            If dt.Rows.Count <> 0 Then
                Return clsdtHelper.ConvertDataTableToJson(dt)
            Else
                Return "[]"
            End If
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function SaveFloor(id As String, floor_name As String, color As String, active As String, login_username As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from ms_floor where floor_name ='" & floor_name & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_floorname
                Return retStatus
            End If


            Dim lnq As New MsFloorLinqDB
            With lnq
                .GetDataByPK(id, trans.Trans)
                .MS_BUILDING_ID = "1"
                .FLOOR_NAME = floor_name
                .COLOR = color
                .ACTIVE_STATUS = IIf(active = 0, "N", "Y")

                If lnq.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If
            End With


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadFloorByFloorPlan(floor_plan_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append("  select T1.id,floor_name,isnull(selected,'') selected from (")
            strSql.Append("  select distinct f.id ,f.floor_name")
            strSql.Append("  from ms_floor f")
            strSql.Append("  where f.active_status ='Y') T1")
            strSql.Append("  left join (")
            strSql.Append("  select ms_room_id,f.id as ms_floor_id,'selected' selected from  ms_floor_plan p")
            strSql.Append("  inner join ms_room r on p.ms_room_id = r.id")
            strSql.Append("  inner join ms_floor f on r.ms_floor_id = f.id")
            strSql.Append("  where p.id ='" & floor_plan_id & "') T2 on T1.id =T2.ms_floor_id")
            strSql.Append(" order by floor_name")

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
    Public Function LoadFloorByDesktop(desktop_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select T1.id,floor_name,isnull(selected,'') selected from (")
            strSql.Append(" select distinct f.id ,f.floor_name")
            strSql.Append(" from ms_floor f")
            strSql.Append(" where f.active_status ='Y') T1")
            strSql.Append(" left join (")
            strSql.Append(" select ms_room_id,f.id as ms_floor_id,'selected' selected from  ms_desktop d")
            strSql.Append(" inner join ms_room r on d.ms_room_id = r.id")
            strSql.Append(" inner join ms_floor f on r.ms_floor_id = f.id")
            strSql.Append(" where d.id ='" & desktop_id & "') T2 on T1.id =T2.ms_floor_id order by floor_name")

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
    Public Function LoadFloorBySpeedway(speedway_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select T1.id,floor_name,isnull(selected,'') selected from (")
            strSql.Append(" select distinct f.id ,f.floor_name")
            strSql.Append(" from ms_floor f")
            strSql.Append(" where f.active_status ='Y') T1")
            strSql.Append(" left join (")
            strSql.Append(" select ms_room_id,f.id as ms_floor_id,'selected' selected from ms_speedway s")
            strSql.Append(" inner join ms_room r on s.ms_room_id = r.id")
            strSql.Append(" inner join ms_floor f on r.ms_floor_id = f.id")
            strSql.Append(" where s.id ='" & speedway_id & "') T2 on T1.id =T2.ms_floor_id")
            strSql.Append(" order by floor_name")

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
    Public Function LoadFloorByRFIDConfig(cfid As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select T1.id,floor_name,isnull(selected,'') selected from (")
            strSql.Append(" select distinct f.id ,f.floor_name")
            strSql.Append(" from ms_floor f")
            strSql.Append(" where f.active_status ='Y') T1")
            strSql.Append(" left join (")
            strSql.Append(" select ms_room_id,f.id as ms_floor_id,'selected' selected from cf_speedway s")
            strSql.Append(" inner join ms_room r on s.ms_room_id = r.id")
            strSql.Append(" inner join ms_floor f on r.ms_floor_id = f.id")
            strSql.Append(" where s.id ='" & cfid & "') T2 on T1.id =T2.ms_floor_id")
            strSql.Append(" order by floor_name")

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
    Public Function LoadFloorByLEDTV(ledtv_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select T1.id,floor_name,isnull(selected,'') selected from (")
            strSql.Append(" select distinct f.id ,f.floor_name")
            strSql.Append(" from ms_floor f")
            strSql.Append(" where f.active_status ='Y') T1")
            strSql.Append(" left join (")
            strSql.Append(" select l.ms_floor_id,'selected' selected from  ms_led_tv l")
            strSql.Append(" where l.id ='" & ledtv_id & "') T2 on T1.id =T2.ms_floor_id order by floor_name")

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
    Public Function LoadFloorByRoom(room_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select T1.id,floor_name,isnull(selected,'') selected from (")
            strSql.Append(" select distinct f.id ,f.floor_name")
            strSql.Append(" from ms_floor f")
            strSql.Append(" where f.active_status ='Y') T1")
            strSql.Append(" left join (")
            strSql.Append(" select l.ms_floor_id,'selected' selected from  ms_room l")
            strSql.Append(" where l.id ='" & room_id & "') T2 on T1.id =T2.ms_floor_id order by floor_name")

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
    Public Function DeleteFloor(id As String) As Boolean
        Try
            Dim ret As Boolean = False
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_FLOOR WHERE ID=" & id)
            Return ret
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "FloorPlan"
    <WebMethod()> _
    Public Function LoadFloorPlanAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY P.id asc) AS no,[dbo].IsReferenctFloorPlan(P.id) as IsDelete")
            strSql.Append(" ,P.id")
            strSql.Append(" ,P.floor_plan_name")
            strSql.Append(" ,P.ms_floor_id")
            strSql.Append(" ,P.ms_room_id")
            strSql.Append(" ,P.image_floor_plan")
            strSql.Append(" ,floor_name")
            strSql.Append(" ,room_name")
            strSql.Append(" ,(case when isnull(p.active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status")
            strSql.Append(" ,image_file_ext,'' image_floor_plan_show")
            strSql.Append(" from MS_FLOOR_PLAN P")
            strSql.Append(" inner join MS_FLOOR F ON P.ms_floor_id = F.ID")
            strSql.Append(" inner join MS_ROOM R ON P.ms_room_id = R.ID")
            strSql.Append(" order by floor_name,room_name")

            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim strimagebasesrc As String = ""
                    If dt.Rows(i)("image_file_ext") & "" <> "" Then
                        strimagebasesrc = "data:image/" & dt.Rows(i)("image_file_ext") & ";base64," & Convert.ToBase64String(dt.Rows(i)("image_floor_plan"))
                    End If
                    dt.Rows(i)("image_floor_plan_show") = strimagebasesrc
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

    <WebMethod()> _
    Public Function GetFloorPlanById(id As String) As String
        Try
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id,floor_plan_name,ms_floor_id,ms_room_id,image_floor_plan,'' base,active_status,image_file_ext,'' image_floor_plan_show from MS_FLOOR_PLAN WHERE ID=" & id)
            If dt.Rows.Count <> 0 Then
                Dim strimagebase64 As String = ""
                Dim strimagebasesrc As String = ""
                If dt.Rows(0)("image_file_ext") & "" <> "" Then
                    strimagebasesrc = "data:image/" & dt.Rows(0)("image_file_ext") & ";base64," & Convert.ToBase64String(dt.Rows(0)("image_floor_plan"))
                    strimagebase64 = Convert.ToBase64String(dt.Rows(0)("image_floor_plan"))
                End If

                dt.Rows(0)("image_floor_plan_show") = strimagebasesrc
                dt.Rows(0)("base") = strimagebase64

                Return clsdtHelper.ConvertDataTableToJson(dt)
            Else
                Return "[]"
            End If
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function SaveFloorPlan(id As String, floor_id As String, room_id As String, login_username As String _
                             , active As String, strimagebase64 As String, strimagename As String, floor_plan_name As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from MS_FLOOR_PLAN where floor_plan_name ='" & floor_plan_name & "'  and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                trans.CommitTransaction()
                retStatus = Utility.DefaultStringStatusReturn.duplicate_floor_plan_name
                Return retStatus
            End If

            dt = New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from MS_FLOOR_PLAN where ms_floor_id ='" & floor_id & "' and ms_room_id='" & room_id & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                trans.CommitTransaction()
                retStatus = Utility.DefaultStringStatusReturn.duplicate_floor_plan
                Return retStatus
            End If

            Dim bytes As Byte()
            bytes = Convert.FromBase64String(strimagebase64)
            Dim image_file_ext As String = ""
            Dim strimagenametem As String()
            If strimagename <> "" Then
                strimagenametem = strimagename.Split(".")
                strimagename = strimagenametem(0)
                image_file_ext = strimagenametem(1)
            End If

            Dim lnq As New MsFloorPlanLinqDB
            With lnq
                .GetDataByPK(id, trans.Trans)
                .FLOOR_PLAN_NAME = floor_plan_name
                .MS_FLOOR_ID = floor_id
                .MS_ROOM_ID = room_id
                .IMAGE_FLOOR_PLAN = bytes
                .IMAGE_FILE_EXT = image_file_ext
                .ACTIVE_STATUS = IIf(active = 0, "N", "Y")

                If lnq.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If

            End With


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            lnq = Nothing
            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function DeleteFloorPlan(id As String) As Boolean
        Try
            Dim ret As Boolean = False
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_FLOOR_PLAN WHERE ID=" & id)
            Return ret
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "GridLayout"
    <WebMethod()> _
    Public Function LoadGridLayoutAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY id asc) AS no,[dbo].IsReferenctGridLayout(id) as IsDelete")
            strSql.Append(" ,id")
            strSql.Append(" ,layout_name")
            strSql.Append(" ,vertical_line")
            strSql.Append(" ,horizontal_line")
            strSql.Append(" ,(case when isnull(active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status")
            strSql.Append(" from MS_GRID_LAYOUT")
            strSql.Append(" order by layout_name")

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
    Public Function GetGridLayoutById(id As String) As String
        Try
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id,layout_name,vertical_line,horizontal_line,active_status from MS_GRID_LAYOUT WHERE ID=" & id)
            If dt.Rows.Count <> 0 Then
                Return clsdtHelper.ConvertDataTableToJson(dt)
            Else
                Return "[]"
            End If
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function SaveGridLayout(id As String, layout_name As String, vertical_line As String _
                             , horizontal_line As String, active As String, login_username As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from MS_GRID_LAYOUT where layout_name ='" & layout_name & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_layout_name
                Return retStatus
            End If

            Dim lnq As New MsGridLayoutLinqDB
            With lnq
                .GetDataByPK(id, trans.Trans)
                .LAYOUT_NAME = layout_name
                .VERTICAL_LINE = vertical_line
                .HORIZONTAL_LINE = horizontal_line
                .ACTIVE_STATUS = IIf(active = 0, "N", "Y")

                If lnq.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If
            End With


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function DeleteGridLayout(id As String) As Boolean
        Try
            Dim ret As Boolean = False
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_GRID_LAYOUT WHERE ID=" & id)
            Return ret
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "LEDTV"

    <WebMethod()> _
    Public Function LoadLEDTVAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY tv.id asc) AS no,[dbo].IsReferenctLEDTV(tv.id) as IsDelete")
            strSql.Append(" ,tv.id,tv_name,install_position,ms_floor_id,ip_address,floor_name")
            strSql.Append(" ,(case when isnull(tv.active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status")
            strSql.Append(" from MS_LED_TV tv left join MS_FLOOR f on tv.ms_floor_id = f.id")
            strSql.Append(" order by floor_name,tv_name")

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
    Public Function LoadLEDTVID(id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select id,tv_name,install_position,ms_floor_id,ip_address, mac_address,ms_signage_template_id_default,")
            strSql.Append(" default_text_scrolling, text_scrolling_speed,active_status from MS_LED_TV  where id ='" & id & "'")

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
    Public Function SaveLEDTV(id As String, tv_name As String, install_position As String, ms_floor_id As String, ip_address As String, mac_address As String _
                              , ms_signage_template_id_default As String, default_text_scrolling As String, text_scrolling_speed As String _
                              , active As String, login_username As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try
            Dim lnq As New MsLedTvLinqDB
            If lnq.ChkDuplicateByIP_ADDRESS(ip_address, id, trans.Trans) = True Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_led_ipaddress
                Return retStatus
            End If
            If lnq.ChkDuplicateByMAC_ADDRESS(mac_address, id, trans.Trans) = True Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_led_macaddress
                Return retStatus
            End If
            If lnq.ChkDuplicateByTV_NAME(tv_name, id, trans.Trans) = True Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_led_tvname
                Return retStatus
            End If

            With lnq
                .GetDataByPK(id, trans.Trans)
                .TV_NAME = tv_name
                .INSTALL_POSITION = install_position
                .MS_FLOOR_ID = ms_floor_id
                .IP_ADDRESS = ip_address
                .MAC_ADDRESS = mac_address
                .MS_SIGNAGE_TEMPLATE_ID_DEFAULT = ms_signage_template_id_default
                .DEFAULT_TEXT_SCROLLING = default_text_scrolling
                .TEXT_SCROLLING_SPEED = text_scrolling_speed
                .ACTIVE_STATUS = IIf(active = 0, "N", "Y")

                If lnq.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If
            End With

            If ret = True Then
                trans.CommitTransaction()
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                trans.RollbackTransaction()
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function DeleteLEDTV(id As String) As Boolean
        Try
            Dim ret As Boolean = False
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_LED_TV WHERE ID=" & id)
            Return ret
        Catch ex As Exception
            Return False
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadLEDTVBySinageSchedule(ms_signage_template_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select T1.id,tv_name,isnull(selected,'') selected from (")
            strSql.Append(" select distinct l.id ,l.tv_name")
            strSql.Append(" from MS_LED_TV l")
            strSql.Append(" where l.active_status ='Y') T1")
            strSql.Append(" left join (")
            strSql.Append(" select ms_led_tv_id,s.id as ms_signage_template_id_default,'selected' selected from  MS_SIGNAGE_TEMPLATE_SCHEDULE s")
            strSql.Append(" where s.id ='" & ms_signage_template_schedule_id & "') T2 on T1.id =T2.ms_led_tv_id")
            strSql.Append(" order by tv_name")

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
    Public Function LoadLEDTVIDBySinageContent(ms_signage_template_id_default As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select l.id,l.tv_name")
            strSql.Append(" ,(case  when isnull(l.ms_signage_template_id_default,'')='' then '' else 'selected' end) selected")
            strSql.Append(" from MS_LED_TV l left join MS_SIGNAGE_CONTENT_TEMPLATE s ")
            strSql.Append(" on l.ms_signage_template_id_default = s.id and s.id ='" & ms_signage_template_id_default & "'")
            strSql.Append(" where s.id='" & ms_signage_template_id_default & "' and l.active_status='Y' order by l.tv_name")

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
    Public Function LoadLEDTVByScrollingTextSchedule(ms_text_scrolling_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select T1.id,tv_name,isnull(selected,'') selected from (")
            strSql.Append(" select distinct l.id ,l.tv_name")
            strSql.Append(" from MS_LED_TV l")
            strSql.Append(" where l.active_status ='Y') T1")
            strSql.Append(" left join (")
            strSql.Append(" select ms_led_tv_id,'selected' selected from  MS_TEXT_SCROLLING_SCHEDULE s")
            strSql.Append(" where s.id ='" & ms_text_scrolling_schedule_id & "') T2 on T1.id =T2.ms_led_tv_id")
            strSql.Append(" order by tv_name")

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

#Region "Location"
    <WebMethod()> _
    Public Function LoadLocationByRequisition(tb_requisition_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select T1.id,LocationName,isnull(selected,'') selected from (")
            strSql.Append(" select distinct id ,LocationName")
            strSql.Append(" from TB_LOCATION) T1")
            strSql.Append(" left join (")
            strSql.Append(" select filelocation,'selected' selected from  TB_REQUISTION")
            strSql.Append(" where id ='" & tb_requisition_id & "') T2 on T1.id =T2.filelocation")
            strSql.Append(" order by LocationName")

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

#Region "Objective or Profile"

    <WebMethod()> _
    Public Function LoadObjectiveAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY id asc) AS no,[dbo].IsReferenctObjective(id) as IsDelete")
            strSql.Append(" ,id")
            strSql.Append(" ,(case when isnull(active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status")
            strSql.Append(" ,objective_name")
            strSql.Append(" from ms_speedway_objective")
            strSql.Append(" order by objective_name")

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
    Public Function GetObjectiveById(id As String) As String
        Try
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id,objective_name,active_status from ms_speedway_objective WHERE ID=" & id)
            If dt.Rows.Count <> 0 Then
                Return clsdtHelper.ConvertDataTableToJson(dt)
            Else
                Return "[]"
            End If
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function SaveObjective(id As String, objective_name As String, active As String, login_username As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from ms_speedway_objective where objective_name ='" & objective_name & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_objectivename
                Return retStatus
            End If


            Dim lnq As New MsSpeedwayObjectiveLinqDB
            With lnq
                .GetDataByPK(id, trans.Trans)
                .OBJECTIVE_NAME = objective_name
                .ACTIVE_STATUS = IIf(active = 0, "N", "Y")

                If lnq.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If
            End With


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function


    <WebMethod()> _
    Public Function DeleteObjective(id As String) As Boolean
        Try
            Dim ret As Boolean = False
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_SPEEDWAY_OBJECTIVE WHERE ID=" & id)
            Return ret
        Catch ex As Exception
            Return False
        End Try
    End Function


    <WebMethod()> _
    Public Function LoadObjectveBySpeedway(speedway_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select distinct")
            strSql.Append(" o.id")
            strSql.Append(" ,o.objective_name")
            strSql.Append(" , (case  when isnull(s.ms_speedway_objective_id,'')='' then '' else 'selected' end) selected")
            strSql.Append(" from ms_speedway_objective o")
            strSql.Append(" left join ms_speedway s")
            strSql.Append(" on o.id = s.ms_speedway_objective_id and s.id = " & Val(speedway_id))
            strSql.Append(" where o.active_status ='Y'")
            strSql.Append(" order by o.objective_name")

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
    Public Function LoadObjectveByRFIDConfig(cfid As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select distinct")
            strSql.Append(" o.id")
            strSql.Append(" ,o.objective_name")
            strSql.Append(" , (case  when isnull(s.ms_speedway_objective_id,'')='' then '' else 'selected' end) selected")
            strSql.Append(" from ms_speedway_objective o")
            strSql.Append(" left join cf_speedway s")
            strSql.Append(" on o.id = s.ms_speedway_objective_id and s.id = " & Val(cfid))
            strSql.Append(" where o.active_status ='Y'")
            strSql.Append(" order by o.objective_name")

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

#Region "PatentType"
    <WebMethod()> _
    Public Function LoadPatentTypeAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY id asc) AS no,[dbo].IsReferenctPatentType(id) as IsDelete")
            strSql.Append(" ,id")
            strSql.Append(" ,patent_type_code")
            strSql.Append(" ,patent_type_name")
            strSql.Append(" ,(case when isnull(active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status")
            strSql.Append(" from TB_PATENT_TYPE")
            strSql.Append(" order by patent_type_name")

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
    Public Function GetPatentTypeById(id As String) As String
        Try
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id,patent_type_code,patent_type_name,active_status from TB_PATENT_TYPE WHERE ID=" & id)
            If dt.Rows.Count <> 0 Then
                Return clsdtHelper.ConvertDataTableToJson(dt)
            Else
                Return "[]"
            End If
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function SavePatentType(id As String, patent_type_code As String, patent_type_name As String _
                             , active As String, login_username As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from TB_PATENT_TYPE where patent_type_code ='" & patent_type_code & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_patent_type_code
                Return retStatus
            End If

            dt = New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from TB_PATENT_TYPE where patent_type_name ='" & patent_type_name & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_patent_type_name
                Return retStatus
            End If


            Dim lnq As New TbPatentTypeLinqDB
            With lnq
                .GetDataByPK(id, trans.Trans)
                .PATENT_TYPE_CODE = patent_type_code
                .PATENT_TYPE_NAME = patent_type_name
                .ACTIVE_STATUS = IIf(active = 0, "N", "Y")

                If lnq.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If
            End With


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function DeletePatentType(id As String) As Boolean
        Try
            Dim ret As Boolean = False
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM TB_PATENT_TYPE WHERE ID=" & id)
            Return ret
        Catch ex As Exception
            Return False
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadPatentTypeByRequisition(tb_requisition_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append("  select T1.id,patent_type_name,isnull(selected,'') selected from (")
            strSql.Append("  select distinct id ,patent_type_name")
            strSql.Append("  from TB_PATENT_TYPE where active_status ='Y') T1")
            strSql.Append("  left join (")
            strSql.Append("  select patent_type_id,'selected' selected from  TB_REQUISTION")
            strSql.Append("  where id ='" & tb_requisition_id & "') T2 on T1.id =T2.patent_type_id")
            strSql.Append("  order by patent_type_name")

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

#Region "Position"
    <WebMethod()> _
    Public Function LoadPosition() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY p.id asc) AS no")
            strSql.Append(" ,p.id")
            strSql.Append(" ,p.position_name")
            strSql.Append(" ,p.position_code")
            strSql.Append(" from tb_position p")
            strSql.Append(" order by p.position_name")
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
    Public Function LoadPositionByUser(user_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY p.id asc) AS no")
            strSql.Append(" ,p.id")
            strSql.Append(" ,p.position_name")
            strSql.Append(" ,p.position_code")
            strSql.Append(" , (case  when isnull(u.position_id,'')='' then '' else 'selected' end) selected")
            strSql.Append(" from tb_position p")
            strSql.Append(" left join tb_officer u")
            strSql.Append(" on p.id = u.position_id and u.id = " & Val(user_id))
            strSql.Append(" order by p.position_name")

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

#Region "Prefix"
    <WebMethod()> _
    Public Function LoadTitleAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY id asc) AS no")
            strSql.Append(" ,id")
            strSql.Append(" ,title_code")
            strSql.Append(" ,title_name")
            strSql.Append(" from TB_TITLE")
            strSql.Append(" order by title_name")

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
    Public Function LoadTitleByUser(user_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY t.id asc) AS no")
            strSql.Append(" ,t.id")
            strSql.Append(" ,t.title_name")
            strSql.Append(" , (case  when isnull(u.title_id,'')='' then '' else 'selected' end) selected")
            strSql.Append(" from tb_title t")
            strSql.Append(" left join tb_officer u")
            strSql.Append(" on t.id = u.title_id and u.id = " & Val(user_id))
            strSql.Append(" order by t.title_name")

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

#Region "Room"
    <WebMethod()> _
    Public Function LoadRoomAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY r.id asc) AS no,[dbo].IsReferenctRoom(r.id) as IsDelete")
            strSql.Append(" ,r.id")
            strSql.Append(" ,(case when isnull(r.active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status")
            strSql.Append(" ,r.room_name")
            strSql.Append(" ,r.ms_floor_id")
            strSql.Append(" ,r.ms_floor_plan_id_current")
            strSql.Append(" ,r.ms_grid_layout_id_current")
            strSql.Append(" ,f.floor_name")
            strSql.Append(" from ms_room r inner join ms_floor f on r.ms_floor_id = f.id")
            strSql.Append(" order by r.room_name,f.floor_name")
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
    Public Function LoadRoomActive() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select id,room_name from ms_room where active_status ='Y' order by room_name ")

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
    Public Function GetRoomById(id As String) As String
        Try
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id,room_name,ms_floor_id,active_status from ms_room WHERE ID=" & id)
            If dt.Rows.Count <> 0 Then
                Return clsdtHelper.ConvertDataTableToJson(dt)
            Else
                Return "[]"
            End If
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function SaveRoom(id As String, room_name As String, floor_id As String _
                             , active As String, login_username As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from ms_room where room_name ='" & room_name & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_roomname
                Return retStatus
            End If


            Dim lnq As New MsRoomLinqDB
            With lnq
                .GetDataByPK(id, trans.Trans)
                .ROOM_NAME = room_name
                .MS_FLOOR_ID = floor_id
                '.MS_FLOOR_PLAN_ID_CURRENT = DBNull.Value
                '.MS_GRID_LAYOUT_ID_CURRENT = DBNull.Value
                .ACTIVE_STATUS = IIf(active = 0, "N", "Y")

                If lnq.ID = -1 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If
            End With


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadRoomByFloorPlan(floor_plan_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append("  declare @floorID varchar(50);")
            strSql.Append("  set @floorID =(select f.id as ms_floor_id  from ms_floor_plan p")
            strSql.Append("  inner join ms_room r on p.ms_room_id = r.id")
            strSql.Append("  inner join ms_floor f on r.ms_floor_id = f.id where p.id ='" & floor_plan_id & "')")
            strSql.Append("  select T1.id,room_name,isnull(selected,'') selected from (")
            strSql.Append("  select distinct r.id ,r.room_name")
            strSql.Append("  from ms_room r")
            strSql.Append("  where r.active_status ='Y' and ms_floor_id = @floorID) T1")
            strSql.Append("  left join (")
            strSql.Append("  select ms_room_id,f.id as ms_floor_id,'selected' selected from  ms_floor_plan p")
            strSql.Append("  inner join ms_room r on p.ms_room_id = r.id")
            strSql.Append("  inner join ms_floor f on r.ms_floor_id = f.id")
            strSql.Append("  where p.id ='" & floor_plan_id & "') T2 on T1.id =T2.ms_room_id")
            strSql.Append(" order by room_name")

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
    Public Function LoadRoomByDesktop(desktop_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append("  declare @floorID varchar(50);")
            strSql.Append("  set @floorID =(select f.id as ms_floor_id  from ms_desktop d")
            strSql.Append("  inner join ms_room r on d.ms_room_id = r.id")
            strSql.Append("  inner join ms_floor f on r.ms_floor_id = f.id where d.id ='" & desktop_id & "')")
            strSql.Append("  select T1.id,room_name,isnull(selected,'') selected from (")
            strSql.Append("  select distinct r.id ,r.room_name")
            strSql.Append("  from ms_room r")
            strSql.Append("  where r.active_status ='Y' and ms_floor_id = @floorID) T1")
            strSql.Append("  left join (")
            strSql.Append("  select ms_room_id,f.id as ms_floor_id,'selected' selected from  ms_desktop d")
            strSql.Append("  inner join ms_room r on d.ms_room_id = r.id")
            strSql.Append("  inner join ms_floor f on r.ms_floor_id = f.id")
            strSql.Append("  where d.id ='" & desktop_id & "') T2 on T1.id =T2.ms_room_id")
            strSql.Append(" order by room_name")

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
    Public Function LoadRoomByFloor(floor_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY r.id asc) AS no")
            strSql.Append(" ,r.id")
            strSql.Append(" ,r.room_name")
            strSql.Append(" , (case  when isnull(r.ms_floor_id,'')='' then '' else 'selected' end) selected")
            strSql.Append(" from ms_room r left join ms_floor p on r.ms_floor_id = p.id and p.id =" & Val(floor_id))
            strSql.Append(" where p.id='" & floor_id & "' and r.active_status='Y' order by r.room_name")

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
    Public Function LoadRoomBySpeedway(speedway_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append("declare @floorID varchar(50);")
            strSql.Append(" set @floorID =(select f.id as ms_floor_id  from ms_speedway s")
            strSql.Append(" inner join ms_room r on s.ms_room_id = r.id")
            strSql.Append(" inner join ms_floor f on r.ms_floor_id = f.id where s.id ='" & speedway_id & "')")
            strSql.Append(" select T1.id,room_name,isnull(selected,'') selected from (")
            strSql.Append(" select distinct r.id ,r.room_name ,ms_floor_id")
            strSql.Append(" from ms_room r inner join ms_floor f on r.ms_floor_id = f.id")
            strSql.Append(" where r.active_status ='Y' and ms_floor_id =@floorID) T1")
            strSql.Append(" left join (")
            strSql.Append(" select ms_room_id,f.id as ms_floor_id,'selected' selected from ms_speedway s")
            strSql.Append(" inner join ms_room r on s.ms_room_id = r.id")
            strSql.Append(" inner join ms_floor f on r.ms_floor_id = f.id")
            strSql.Append(" where s.id ='" & speedway_id & "') T2 on T1.id =T2.ms_room_id  ")
            strSql.Append(" order by room_name")

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
    Public Function LoadRoomByRFIDConfig(cfid As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append("declare @floorID varchar(50);")
            strSql.Append(" set @floorID =(select f.id as ms_floor_id  from cf_speedway s")
            strSql.Append(" inner join ms_room r on s.ms_room_id = r.id")
            strSql.Append(" inner join ms_floor f on r.ms_floor_id = f.id where s.id ='" & cfid & "')")
            strSql.Append(" select T1.id,room_name,isnull(selected,'') selected from (")
            strSql.Append(" select distinct r.id ,r.room_name ,ms_floor_id")
            strSql.Append(" from ms_room r inner join ms_floor f on r.ms_floor_id = f.id")
            strSql.Append(" where r.active_status ='Y' and ms_floor_id =@floorID) T1")
            strSql.Append(" left join (")
            strSql.Append(" select ms_room_id,f.id as ms_floor_id,'selected' selected from cf_speedway s")
            strSql.Append(" inner join ms_room r on s.ms_room_id = r.id")
            strSql.Append(" inner join ms_floor f on r.ms_floor_id = f.id")
            strSql.Append(" where s.id ='" & cfid & "') T2 on T1.id =T2.ms_room_id  ")
            strSql.Append(" order by room_name")

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
    Public Function DeleteRoom(id As String) As Boolean
        Try
            Dim ret As Boolean = False
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_ROOM WHERE ID=" & id)
            Return ret
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "User"
    <WebMethod()> _
    Public Function LoadUserAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            'strSql.Append(" select ")
            'strSql.Append(" ROW_NUMBER() OVER(ORDER BY u.id asc) AS no")
            'strSql.Append(" ,u.id")
            'strSql.Append(" ,username")
            'strSql.Append(" ,fname")
            'strSql.Append(" ,lname")
            'strSql.Append(" ,title_id")
            'strSql.Append(" ,isnull(title_name,'') + ' ' + fname + ' ' + lname as fullname")
            'strSql.Append(" ,department_id")
            'strSql.Append(" ,isnull(department_name,'') department_name")
            'strSql.Append(" ,position_id")
            'strSql.Append(" ,isnull(position_name,'') position_name")
            'strSql.Append(" from TB_OFFICER u")
            'strSql.Append(" left join TB_TITLE t on u.title_id = t.id")
            'strSql.Append(" left join TB_Department d on u.department_id = d.id")
            'strSql.Append(" left join TB_Position p on u.position_id = p.id")
            'strSql.Append(" order by fname,lname")


            strSql.AppendLine(" select ")
            strSql.AppendLine(" ROW_NUMBER() OVER(ORDER BY u.id asc) AS no")
            strSql.AppendLine(" ,u.id,username,fname,lname,title_id,isnull(title_name,'') + ' ' + fname + ' ' + lname + ")
            strSql.AppendLine("  case when ltrim(rtrim(isnull(username,''))) <>'' then ' (' + username + ')' else '' end as fullname ")
            strSql.AppendLine(" ,department_id,isnull(department_name,'') department_name,position_id")
            strSql.AppendLine(" ,isnull(position_name,'') position_name from ( ")
            strSql.AppendLine(" select MAX(officer_no) as of_no ")
            strSql.AppendLine(" ,ltrim(isnull(title_name,'') + isnull(fname,'') + ' ' + isnull(lname,'')) as fullname")
            strSql.AppendLine(" from TB_OFFICER x  ")
            strSql.AppendLine(" left join TB_TITLE y on x.title_id = y.id  ")
            strSql.AppendLine(" group by title_name,fname,lname ) as tb1")
            strSql.AppendLine(" left join TB_OFFICER as u on tb1.of_no = u.officer_no")
            strSql.AppendLine(" left join TB_TITLE t on u.title_id = t.id ")
            strSql.AppendLine(" left join TB_Department d on u.department_id = d.id")
            strSql.AppendLine(" left join TB_Position p on u.position_id = p.id")
            strSql.AppendLine(" order by fname,lname")


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
    Public Function LoadUserByName(name As String) As String
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
            strSql.Append(" ,department_id")
            strSql.Append(" ,department_name")
            strSql.Append(" ,position_id")
            strSql.Append(" ,position_name")
            strSql.Append(" from  (select MAX(officer_no) as of_no ,ltrim(isnull(title_name,'') + isnull(fname,'') + ' ' + isnull(lname,'')) as fullname")
            strSql.Append(" from TB_OFFICER x  ")
            strSql.Append(" left join TB_TITLE y on x.title_id = y.id  ")
            strSql.Append(" group by title_name,fname,lname ) tb1")
            strSql.Append(" left join TB_OFFICER u on  tb1.of_no = u.officer_no")
            strSql.Append(" inner join TB_TITLE t on u.title_id = t.id")
            strSql.Append(" inner join TB_Department d on u.department_id = d.id")
            strSql.Append(" inner join TB_Position p on u.position_id = p.id")
            strSql.Append(" where title_name  like '%" & name & "%' or fname like '%" & name & "%' or lname like '%" & name & "%' order by fname,lname ")

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
    Public Function GetUserById(id As String) As String
        Try
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id,username,password,fname,lname,title_id,department_id,position_id,email from TB_OFFICER WHERE ID=" & id)
            If dt.Rows.Count <> 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i)("password").ToString <> "" Then
                        dt.Rows(i)("password") = Engine.GlobalFunction.GetDecrypt(dt.Rows(i)("password"))
                    End If
                Next

                Return clsdtHelper.ConvertDataTableToJson(dt)
            Else
                Return "[]"
            End If
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function GetPermissionByOfficer(officer_id As String) As String
        Try
            Dim sql As String = "select distinct [permission_name] from TB_PERMISSION_OFFICER inner join "
            sql &= " tb_Permission on TB_PERMISSION_OFFICER.permission_id = tb_Permission.id"
            sql &= " where officer_id ='" & officer_id & "'"
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(sql)
            If dt.Rows.Count <> 0 Then
                Dim strRole As String = ""
                For i As Integer = 0 To dt.Rows.Count - 1
                    strRole &= dt.Rows(i)("permission_name").ToString & ","
                Next
                strRole = strRole.Substring(0, strRole.Length - 1)

                Return strRole
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try

    End Function

    <WebMethod()> _
    Public Function SaveUser(id As String _
                             , title_id As String _
                             , name As String _
                             , surname As String _
                             , email As String _
                             , department_id As String _
                             , position_id As String _
                             , username As String _
                             , password As String _
                             , login_username As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from TB_OFFICER where username ='" & username & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicateUsername
                Return retStatus
            End If

            Dim strSql As New StringBuilder
            Dim EnCripPW As String = Engine.GlobalFunction.GetEncrypt(password)

            If id = "0" Then
                strSql.Append(" declare @maxid varchar(255)")
                strSql.Append(" set @maxid =(select isnull(max(id),0) + 1 from TB_OFFICER)")
                strSql.Append(" Insert into TB_OFFICER (id,officer_no,fname,lname,department_id,position_id,username,password")
                strSql.Append(" ,createby,createon,title_id,mifare_card_id,email,is_change_pwd)")
                strSql.Append(" values(@maxid,@maxid,'" & name & "','" & surname & "','" & department_id & "','" & position_id & "','" & username & "','" & EnCripPW & "'")
                strSql.Append(" ,'" & login_username & "',GETDATE(),'" & title_id & "','','" & email & "','Y')")
            Else
                strSql.Append(" Update TB_OFFICER set fname='" & name & "',lname='" & surname & "'")
                strSql.Append(" ,department_id='" & department_id & "',position_id ='" & position_id & "'")
                strSql.Append(" ,username ='" & username & "',password='" & EnCripPW & "'")
                strSql.Append(" ,updateby ='" & login_username & "',updateon =GETDATE(),title_id ='" & title_id & "'")
                strSql.Append(" ,email = '" & email & "',is_change_pwd='Y'")
                strSql.Append(" where id ='" & id & "'")
            End If

            ret = DIPRFIDSqlDB.ExecuteNonQuery(strSql.ToString, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                trans.RollbackTransaction()
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function DeleteUser(id As String) As Boolean
        Try
            Dim ret As Boolean = False
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM TB_OFFICER WHERE ID=" & id)
            Return ret
        Catch ex As Exception
            Return False
        End Try
    End Function

    <WebMethod()> _
    Public Function ChangePassword(login_userid As String, current_password As String, password As String, login_username As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try
            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from TB_OFFICER where id ='" & login_userid & "' and password <> '" & Engine.GlobalFunction.GetEncrypt(current_password) & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.IncorrectPassword
                Return retStatus
            End If

            Dim EnCripPW As String = Engine.GlobalFunction.GetEncrypt(password)
            Dim lnq As New TbOfficerLinqDB
            With lnq
                .GetDataByPK(login_userid, trans.Trans)
                .PASSWORD = EnCripPW
                .IS_CHANGE_PWD = "N"
                ret = .UpdateByPK(login_username, trans.Trans)
            End With


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function




#End Region

#Region "ScrollingTextSchedule"
    <WebMethod()> _
    Public Function CheckTextScheduleTime(MsSignageTemplateScheduleID As Long, MsLedTvID As Long, start_date As String, _
                                          end_date As String, start_time As String, end_time As String) As Boolean

        Dim tempstartdate As DateTime = Date.ParseExact(start_date, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) & " " & start_time
        Dim tempenddate As DateTime = Date.ParseExact(end_date, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) & " " & end_time

        Dim ret As Boolean = Engine.DigitalSignageENG.CheckDuplicateTextScheduleTime(MsSignageTemplateScheduleID, MsLedTvID, _
                                                                                        tempstartdate, tempenddate)
        Return ret
    End Function

    <WebMethod()> _
    Public Function LoadScrollingTextScheduleAll() As String
        Try

            Dim strdata As String
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            'strSql.Append(" select ROW_NUMBER() OVER(ORDER BY s.id asc) AS no,s.id,ms_led_tv_id,tv_name,floor_name,")
            'strSql.Append(" (case when isnull(s.active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status,schedule_type ")
            'strSql.Append(" ,convert(varchar(10),start_time,103)+ ' ' + convert(varchar(10),start_time,108) start_time")
            'strSql.Append(" ,convert(varchar(10),end_time,103)+ ' ' + convert(varchar(10),end_time,108) end_time")
            'strSql.Append(" from MS_TEXT_SCROLLING_SCHEDULE s left join MS_LED_TV  l on s.ms_led_tv_id = l.id ")
            'strSql.Append(" left join MS_FLOOR f on l.ms_floor_id = f.id order by s.id")


            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY s.id asc) AS no,s.id,ms_led_tv_id,tv_name,floor_name,")
            strSql.Append(" (case when isnull(s.active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status,schedule_type ")
            strSql.Append(" ,convert(varchar(10),start_time,103)+ ' ' + convert(varchar(10),start_time,108) start_time")
            strSql.Append(" ,convert(varchar(10),end_time,103)+ ' ' + convert(varchar(10),end_time,108) end_time,")
            strSql.Append("  isnull((select id ")
            strSql.Append("  from MS_TEXT_SCROLLING_SCH_DATA")
            strSql.Append("  where ms_led_tv_id = s.ms_led_tv_id And ms_text_scrolling_schedule_id = s.id")
            strSql.Append(" and getdate() between start_time and end_time),0) current_schedule")
            strSql.Append(" from MS_TEXT_SCROLLING_SCHEDULE s ")
            strSql.Append(" left join MS_LED_TV  l on s.ms_led_tv_id = l.id ")
            strSql.Append(" left join MS_FLOOR f on l.ms_floor_id = f.id ")
            strSql.Append(" order by tv_name")


            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            'dt.Columns.Add("trigger")

            'For i As Integer = 0 To dt.Rows.Count - 1
            '    Dim ms_text_scrolling_schedule_id As String = dt.Rows(i).Item("id").ToString
            '    Dim schedule_type As String = dt.Rows(i).Item("schedule_type").ToString
            '    Dim trigger As String = ""
            '    If schedule_type = "D" Then
            '        Dim dtDaily As DataTable
            '        strSql = New StringBuilder
            '        strSql.Append(" select id,ms_text_scrolling_schedule_id,recur_every_days from MS_TEXT_SCROLLING_SCH_DAILY")
            '        strSql.Append(" where ms_text_scrolling_schedule_id ='" & ms_text_scrolling_schedule_id & "'")
            '        dtDaily = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            '        If dtDaily.Rows.Count > 0 Then
            '            Dim recur_every_days As String = dtDaily.Rows(0)("recur_every_days") & ""
            '            trigger = "Recur every " & recur_every_days & " Days"
            '        End If
            '    End If


            '    If schedule_type = "W" Then
            '        Dim dtWeekly As DataTable
            '        strSql = New StringBuilder
            '        strSql.Append(" select id,ms_text_scrolling_schedule_id,recur_every_week,sch_sun ,")
            '        strSql.Append(" sch_mon,sch_tue,sch_wed,sch_thu,sch_fri,sch_sat  from MS_TEXT_SCROLLING_SCH_WEEKLY")
            '        strSql.Append(" where ms_text_scrolling_schedule_id ='" & ms_text_scrolling_schedule_id & "'")
            '        dtWeekly = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            '        If dtWeekly.Rows.Count > 0 Then
            '            Dim recur_every_week As String = dtWeekly.Rows(0)("recur_every_week") & ""
            '            Dim sch_sun As String = dtWeekly.Rows(0)("sch_sun") & ""
            '            Dim sch_mon As String = dtWeekly.Rows(0)("sch_mon") & ""
            '            Dim sch_tue As String = dtWeekly.Rows(0)("sch_tue") & ""
            '            Dim sch_wed As String = dtWeekly.Rows(0)("sch_wed") & ""
            '            Dim sch_thu As String = dtWeekly.Rows(0)("sch_thu") & ""
            '            Dim sch_fri As String = dtWeekly.Rows(0)("sch_fri") & ""
            '            Dim sch_sat As String = dtWeekly.Rows(0)("sch_sat") & ""
            '            trigger = "Recur every " & recur_every_week & " Week on "
            '            If sch_sun = "Y" Then
            '                trigger &= "Sunday,"
            '            End If
            '            If sch_mon = "Y" Then
            '                trigger &= "Monday,"
            '            End If
            '            If sch_tue = "Y" Then
            '                trigger &= "Tuesday,"
            '            End If
            '            If sch_wed = "Y" Then
            '                trigger &= "Wednesday,"
            '            End If
            '            If sch_thu = "Y" Then
            '                trigger &= "Thursday,"
            '            End If
            '            If sch_fri = "Y" Then
            '                trigger &= "Friday,"
            '            End If
            '            If sch_sat = "Y" Then
            '                trigger &= "Saturday,"
            '            End If

            '            trigger = trigger.Substring(0, trigger.Length - 1)
            '        End If
            '    End If


            '    If schedule_type = "M" Then
            '        Dim dtMonthly As DataTable
            '        strSql = New StringBuilder
            '        strSql.Append(" select distinct ms_text_scrolling_schedule_id,month_no,date_no,case month_no")
            '        strSql.Append(" when 1 then 'January'")
            '        strSql.Append(" when 2 then 'February'")
            '        strSql.Append(" when 3 then 'March'")
            '        strSql.Append(" when 4 then 'April'")
            '        strSql.Append(" when 5 then 'May'")
            '        strSql.Append(" when 6 then 'June'")
            '        strSql.Append(" when 7 then 'July'")
            '        strSql.Append(" when 8 then 'August'")
            '        strSql.Append(" when 9 then 'September'")
            '        strSql.Append(" when 10 then 'October'")
            '        strSql.Append(" when 11 then 'November'")
            '        strSql.Append(" when 12 then 'December'")
            '        strSql.Append(" end [MonthsEng],")
            '        strSql.Append(" Case month_no")
            '        strSql.Append(" when 1 then 'มกราคม'")
            '        strSql.Append(" when 2 then 'กุมภาพันธ์'")
            '        strSql.Append(" when 3 then 'มีนาคม'")
            '        strSql.Append(" when 4 then 'เมษายน'")
            '        strSql.Append(" when 5 then 'พฤษภาคม'")
            '        strSql.Append(" when 6 then 'มิถุนายน'")
            '        strSql.Append(" when 7 then 'กรกฏาคม'")
            '        strSql.Append(" when 8 then 'สิงหาคม'")
            '        strSql.Append(" when 9 then 'กันยายน'")
            '        strSql.Append(" when 10 then 'ตุลาคม'")
            '        strSql.Append(" when 11 then 'พฤศจิกายน'")
            '        strSql.Append(" when 12 then 'ธันวาคม'")
            '        strSql.Append(" end [MonthsThai] from MS_TEXT_SCROLLING_SCH_MONTHLY")
            '        strSql.Append(" where ms_text_scrolling_schedule_id ='" & ms_text_scrolling_schedule_id & "'")
            '        dtMonthly = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)

            '        If dtMonthly.Rows.Count > 0 Then
            '            Dim dttempM As DataTable
            '            dttempM = dtMonthly.DefaultView.ToTable(True, "MonthsThai").Copy

            '            Dim dttempD As DataTable
            '            dttempD = dtMonthly.DefaultView.ToTable(True, "date_no").Copy

            '            trigger = "Month :"
            '            For j As Integer = 0 To dttempM.Rows.Count - 1
            '                Dim months As String = dttempM.Rows(j)("MonthsThai") & ""
            '                trigger &= months & ","
            '            Next
            '            trigger = trigger.Substring(0, trigger.Length - 1) & vbCrLf

            '            trigger &= "Days :"
            '            For k As Integer = 0 To dttempD.Rows.Count - 1
            '                Dim days As String = dttempD.Rows(k)("date_no") & ""
            '                trigger &= days & ","
            '            Next
            '            trigger = trigger.Substring(0, trigger.Length - 1) & vbCrLf
            '        End If
            '    End If


            'Dim dtTime As DataTable
            'strSql = New StringBuilder
            'strSql.Append(" select id,ms_text_scrolling_schedule_id,")
            'strSql.Append(" convert(varchar(5),time_from,108) time_from,convert(varchar(5),time_to,108) time_to from MS_TEXT_SCROLLING_SCH_TIME")
            'strSql.Append(" where ms_text_scrolling_schedule_id ='" & ms_text_scrolling_schedule_id & "'")
            'dtTime = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            'trigger &= vbCrLf
            'trigger &= " Time :"
            'For n As Integer = 0 To dtTime.Rows.Count - 1
            '    Dim timefrom As String = dtTime.Rows(n)("time_from")
            '    Dim timeto As String = dtTime.Rows(n)("time_to")
            '    trigger &= vbCrLf
            '    trigger &= timefrom & "-" & timeto & ","
            'Next
            'trigger = trigger.Substring(0, trigger.Length - 1) & vbCrLf


            'dt.Rows(i)("trigger") = trigger
            'Next


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
    Public Function LoadScrollingTextScheduleID(id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select id,ms_led_tv_id,")
            strSql.Append(" convert(varchar(10),start_time,103) start_date,convert(varchar(10),end_time,103) end_date,")
            strSql.Append(" convert(varchar(5),start_time,108) start_time,convert(varchar(5),end_time,108) end_time,")
            strSql.Append(" active_status, schedule_type")
            strSql.Append(" from MS_TEXT_SCROLLING_SCHEDULE where id ='" & id & "'")

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
    Public Function LoadMonthByScrollingTextSchedule(ms_text_scrolling_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append("  select distinct T1.id,monthsthai,monthseng,isnull(selected,'') selected from (")
            strSql.Append("  select id,monthseng,monthsthai from  fnGetMonth()) T1")
            strSql.Append("  left join (")
            strSql.Append("  select month_no,'selected' selected from  MS_TEXT_SCROLLING_SCH_MONTHLY ssm")
            strSql.Append("  where ms_text_scrolling_schedule_id ='" & ms_text_scrolling_schedule_id & "') T2 on T1.id =T2.month_no")
            strSql.Append("  order by id")
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
    Public Function LoadDayByScrollingTextSchedule(ms_text_scrolling_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select distinct T1.d,isnull(selected,'') selected from (")
            strSql.Append(" select * from  fnGetDay()) T1")
            strSql.Append(" left join (")
            strSql.Append(" select date_no,'selected' selected from  MS_TEXT_SCROLLING_SCH_MONTHLY ssm")
            strSql.Append(" where ms_text_scrolling_schedule_id ='" & ms_text_scrolling_schedule_id & "') T2 on T1.d =T2.date_no")
            strSql.Append(" order by d")

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
    Public Function LoadScrollingTextScheduleDailyByScheduleID(ms_text_scrolling_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select id,ms_text_scrolling_schedule_id,recur_every_days from MS_TEXT_SCROLLING_SCH_DAILY")
            strSql.Append(" where ms_text_scrolling_schedule_id ='" & ms_text_scrolling_schedule_id & "'")

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
    Public Function LoadScrollingTextScheduleWeeklyByScheduleID(ms_text_scrolling_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select id,ms_text_scrolling_schedule_id,recur_every_week,sch_sun ,")
            strSql.Append(" sch_mon,sch_tue,sch_wed,sch_thu,sch_fri,sch_sat   from MS_TEXT_SCROLLING_SCH_WEEKLY")
            strSql.Append(" where ms_text_scrolling_schedule_id ='" & ms_text_scrolling_schedule_id & "'")

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
    Public Function LoadScrollingTextScheduleTimeByScheduleID(ms_text_scrolling_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY id asc) AS no,id,ms_text_scrolling_schedule_id,scrolling_text,duration_minute,speed_level as speed_level_id,")
            strSql.Append(" case speed_level when 1 then 'Slow' when 2 then 'Medium' when 3 then 'Fast' else '' end as speed_level_name from MS_TEXT_SCROLLING_SCH_TIME")
            strSql.Append(" where ms_text_scrolling_schedule_id ='" & ms_text_scrolling_schedule_id & "'")

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
    Public Function SaveScrollingTextSchedule(id As String, ms_led_tv_id As String, start_date As String, end_date As String, start_time As String, end_time As String, _
        active_status As String, daily As String, weekly As String, monthly As String, recur_every_days As String, recur_every_week As String, _
        sch_sun As String, sch_mon As String, sch_tue As String, sch_wed As String, sch_thu As String, sch_fri As String, sch_sat As String, _
        month_no As String, date_no As String, jsonobject_time As String, login_username As String) As String

        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            'Dim dt As New DataTable
            'dt = DIPRFIDSqlDB.ExecuteTable("select id from MS_TEXT_SCROLLING_SCHEDULE where scrolling_text ='" & scrolling_text & "' and id <> '" & id & "'", trans.Trans)
            'If dt.Rows.Count > 0 Then
            '    retStatus = Utility.DefaultStringStatusReturn.duplicate_scrollingtext
            '    Return retStatus
            'End If

            Dim dtJson_time As DataTable = clsdtHelper.ConvertJSONToDataTable(jsonobject_time)
            dtJson_time.Rows.RemoveAt(dtJson_time.Rows.Count - 1)
            dtJson_time.AcceptChanges()
            'For i As Integer = 0 To dtJson_time.Rows.Count - 1
            '    Dim strtime() As String = dtJson_time.Rows(i)("strtime").ToString.Split("-")
            '    Dim dttime As New DataTable
            '    dttime = DIPRFIDSqlDB.ExecuteTable("select [dbo].CheckTimePeriodScollingText('" & id & "','" & ms_led_tv_id & "', '" & Replace(Trim(strtime(0)), ".", ":") & "','" & Replace(Trim(strtime(1)), ".", ":") & "')", trans.Trans)
            '    If dttime.Rows.Count > 0 Then
            '        Dim val As String = dttime.Rows(0)(0)
            '        If val = "T" Then
            '            retStatus = Utility.DefaultStringStatusReturn.duplicate_scheduletime & "|" & dtJson_time.Rows(i)("strtime").ToString
            '            Return retStatus
            '        End If
            '    End If
            'Next

            Dim SCHEDULE_TYPE As String = ""
            If daily.ToLower = "true" Then
                SCHEDULE_TYPE = "D"
            End If
            If weekly.ToLower = "true" Then
                SCHEDULE_TYPE = "W"
            End If
            If monthly.ToLower = "true" Then
                SCHEDULE_TYPE = "M"
            End If

            Dim tempstartdate As Date = Date.ParseExact(start_date, "dd/MM/yyyy",
            System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Dim tempenddate As Date = Date.ParseExact(end_date, "dd/MM/yyyy",
            System.Globalization.DateTimeFormatInfo.InvariantInfo)

            Dim ms_text_scrolling_schedule_id As String
            Dim lnq As New MsTextScrollingScheduleLinqDB
            With lnq
                .GetDataByPK(id, trans.Trans)
                '.SCROLLING_TEXT = scrolling_text
                .MS_LED_TV_ID = ms_led_tv_id
                .START_TIME = tempstartdate & " " & start_time
                .END_TIME = tempenddate & " " & end_time
                .SCHEDULE_TYPE = SCHEDULE_TYPE
                '.SPEED_LEVEL = speed_level
                .SCHEDULE_STATUS = "N"
                .ACTIVE_STATUS = IIf(active_status = 0, "N", "Y")

                If lnq.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If

                ms_text_scrolling_schedule_id = .ID

                If ret = False Then
                    trans.RollbackTransaction()
                    Return Utility.DefaultStringStatusReturn.fail
                End If
            End With


            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_TEXT_SCROLLING_SCH_DAILY WHERE ms_text_scrolling_schedule_id =" & ms_text_scrolling_schedule_id, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_TEXT_SCROLLING_SCH_WEEKLY WHERE ms_text_scrolling_schedule_id =" & ms_text_scrolling_schedule_id, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_TEXT_SCROLLING_SCH_MONTHLY WHERE ms_text_scrolling_schedule_id =" & ms_text_scrolling_schedule_id, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If


            '== Daily ==
            If SCHEDULE_TYPE = "D" Then
                Dim lnqDaily As New MsTextScrollingSchDailyLinqDB
                With lnqDaily
                    .MS_TEXT_SCROLLING_SCHEDULE_ID = ms_text_scrolling_schedule_id
                    .RECUR_EVERY_DAYS = recur_every_days
                    ret = .InsertData(login_username, trans.Trans)

                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If
                End With
            End If


            '== Weekly ==
            If SCHEDULE_TYPE = "W" Then
                Dim lnqWeekly As New MsTextScrollingSchWeeklyLinqDB
                With lnqWeekly
                    .MS_TEXT_SCROLLING_SCHEDULE_ID = ms_text_scrolling_schedule_id
                    .RECUR_EVERY_WEEK = recur_every_week
                    .SCH_SUN = IIf(sch_sun = 0, "N", "Y")
                    .SCH_MON = IIf(sch_mon = 0, "N", "Y")
                    .SCH_TUE = IIf(sch_tue = 0, "N", "Y")
                    .SCH_WED = IIf(sch_wed = 0, "N", "Y")
                    .SCH_THU = IIf(sch_thu = 0, "N", "Y")
                    .SCH_FRI = IIf(sch_fri = 0, "N", "Y")
                    .SCH_SAT = IIf(sch_sat = 0, "N", "Y")
                    ret = .InsertData(login_username, trans.Trans)

                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If
                End With
            End If



            '== Monthly ==
            If SCHEDULE_TYPE = "M" Then
                month_no = month_no.Substring(0, month_no.Length - 1)
                date_no = date_no.Substring(0, date_no.Length - 1)
                Dim months() As String = month_no.Split(",")
                Dim dates() As String = date_no.Split(",")

                For i As Integer = 0 To months.Length - 1
                    For j As Integer = 0 To dates.Length - 1
                        Dim lnqMonthly As New MsTextScrollingSchMonthlyLinqDB
                        With lnqMonthly
                            .MS_TEXT_SCROLLING_SCHEDULE_ID = ms_text_scrolling_schedule_id
                            .MONTH_NO = months(i)
                            .DATE_NO = dates(j)
                            ret = .InsertData(login_username, trans.Trans)

                            If ret = False Then
                                trans.RollbackTransaction()
                                Return Utility.DefaultStringStatusReturn.fail
                            End If
                        End With
                    Next
                Next
            End If

            '== Time
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_TEXT_SCROLLING_SCH_TIME WHERE ms_text_scrolling_schedule_id =" & ms_text_scrolling_schedule_id, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If

            For i As Integer = 0 To dtJson_time.Rows.Count - 1
                Dim scrolling_text As String = dtJson_time.Rows(i)("scrolling_text")
                Dim duration_minute As String = dtJson_time.Rows(i)("duration_minute")
                Dim speed_level As String = dtJson_time.Rows(i)("speed_level_id")
                Dim clsSpeedwayAntLinqDB As New MsTextScrollingSchTimeLinqDB
                With clsSpeedwayAntLinqDB
                    .MS_TEXT_SCROLLING_SCHEDULE_ID = ms_text_scrolling_schedule_id
                    .SCROLLING_TEXT = scrolling_text
                    .DURATION_MINUTE = duration_minute
                    .SPEED_LEVEL = speed_level
                    ret = .InsertData(login_username, trans.Trans)

                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If

                End With
            Next


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            trans.RollbackTransaction()
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function DeleteScollingTextSchedule(id As String) As Boolean

        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Try
            Dim ret As Boolean = True
            Dim sql As String = "DELETE FROM  MS_TEXT_SCROLLING_SCH_TIME where ms_text_scrolling_schedule_id ='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM  MS_TEXT_SCROLLING_SCH_DAILY where ms_text_scrolling_schedule_id ='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM  MS_TEXT_SCROLLING_SCH_WEEKLY where ms_text_scrolling_schedule_id ='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM  MS_TEXT_SCROLLING_SCH_MONTHLY where ms_text_scrolling_schedule_id  ='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM MS_TEXT_SCROLLING_SCHEDULE where id ='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "SignageContent"
    <WebMethod()> _
    Public Function LoadSignageContentByLEDTV(ledtv_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select T1.id,template_name,isnull(selected,'') selected from (")
            strSql.Append(" select distinct s.id ,s.template_name")
            strSql.Append(" from MS_SIGNAGE_CONTENT_TEMPLATE s")
            strSql.Append(" where s.active_status ='Y') T1")
            strSql.Append(" left join (")
            strSql.Append(" select l.ms_signage_template_id_default,'selected' selected from  MS_LED_TV l")
            strSql.Append(" where l.id ='" & ledtv_id & "') T2 on T1.id =T2.ms_signage_template_id_default order by template_name")

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
    Public Function LoadSignageContentBySignageSchedule(ms_signage_template_schedule_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            'strSql.Append(" select T1.id,template_name,isnull(selected,'') selected from (")
            'strSql.Append(" select distinct s.id ,s.template_name")
            'strSql.Append(" from MS_SIGNAGE_CONTENT_TEMPLATE s")
            'strSql.Append(" where s.active_status ='Y') T1")
            'strSql.Append(" left join (")
            'strSql.Append(" select l.ms_signage_content_template_id,'selected' selected from  MS_SIGNAGE_TEMPLATE_SCHEDULE l")
            'strSql.Append(" where l.id ='" & ms_signage_template_schedule_id & "') T2 on T1.id =T2.ms_signage_content_template_id order by template_name")
            strSql.Append("  select distinct s.id ,s.template_name ,'' selected")
            strSql.Append("  from MS_SIGNAGE_CONTENT_TEMPLATE s where s.active_status ='Y'")

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

#Region "Requisition"
    <WebMethod()> _
    Public Function LoadRequisitionAll(app_no As String, app_name As String, shelf_name As String, patent_type_id As String, location As String) As String
        Dim wh As String = ""
        Try

            If app_no <> "" Then
                wh &= " and app_no like '%" & app_no & "%'"
            End If
            If app_name <> "" Then
                wh &= " and app_name like '%" & app_name & "%'"
            End If
            If shelf_name <> "" Then
                wh &= " and shelf_name like '%" & shelf_name & "%'"
            End If
            If patent_type_id <> "" Then
                wh &= " and patent_type_id ='" & patent_type_id & "'"
            End If
            If location <> "" Then
                wh &= " and filelocation ='" & location & "'"
            End If

            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select Top 10000 ROW_NUMBER() OVER(ORDER BY TB_REQUISTION.id asc) AS no")
            strSql.Append(" ,TB_REQUISTION.id,app_no,app_name,patent_type_id,isnull(patent_type_name,'') patent_type_name,qty,shelf_name,isnull(location_name,'') location_name")
            strSql.Append(" from TB_REQUISTION inner Join TB_PATENT_TYPE on TB_REQUISTION.patent_type_id = TB_PATENT_TYPE.id")
            strSql.Append(" left Join TB_FILELOCATION on TB_REQUISTION.filelocation = TB_FILELOCATION.id")
            strSql.Append(" where 1 = 1 " & wh)
            strSql.Append(" order by app_no")

            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            ' LogENG.SaveErrLog("WebService.LoadRequisitionAll", ex.Message)
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function GetRequisitionById(id As String) As String
        Try
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select TB_REQUISTION.id,app_no,app_name,patent_type_id,qty,shelf_name,filelocation from TB_REQUISTION WHERE ID=" & id)
            If dt.Rows.Count <> 0 Then
                Return clsdtHelper.ConvertDataTableToJson(dt)
            Else
                Return "[]"
            End If
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function SaveRequisition(id As String, app_no As String, app_name As String, patent_type_id As String, qty As String, _
                                    shlef_name As String, filelocation As String, jsonobject_tag As Object, login_username As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from TB_REQUISTION where app_no ='" & app_no & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_requisitionapp_no
                Return retStatus
            End If

            Dim tb_requisition_tag_id As String = "0"
            Dim lnq As New TbRequistionLinqDB
            With lnq
                .GetDataByPK(id, trans.Trans)
                .APP_NO = app_no
                .APP_NAME = app_name
                .PATENT_TYPE_ID = patent_type_id
                .QTY = qty
                .SHELF_NAME = shlef_name
                .FILELOCATION = filelocation
                If lnq.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If

                tb_requisition_tag_id = lnq.ID

                If ret = False Then
                    trans.RollbackTransaction()
                    Return Utility.DefaultStringStatusReturn.fail
                End If
            End With

            '== Tag 
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM TS_REQUISITION_TAG where tb_requisition_id ='" & tb_requisition_tag_id & "'", trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If

            Dim dtJson_tag As DataTable = clsdtHelper.ConvertJSONToDataTable(jsonobject_tag)
            dtJson_tag.Rows.RemoveAt(dtJson_tag.Rows.Count - 1)
            dtJson_tag.AcceptChanges()
            For i As Integer = 0 To dtJson_tag.Rows.Count - 1
                Dim clsSpeedwayTagFilterLinqDB As New TsRequisitionTagLinqDB
                With clsSpeedwayTagFilterLinqDB
                    .TB_REQUISITION_ID = tb_requisition_tag_id
                    .TAG_NO = Replace(dtJson_tag.Rows(i)("TAG_NO"), " ", "")
                    ret = .InsertData(login_username, trans.Trans)
                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If
                End With
            Next


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function DeleteRequisition(id As String) As String
        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Try
            Dim ret As Boolean = True
            Dim retStatus As String = False
            Dim sql As String = ""
            Dim dttemp As New DataTable
            sql = " select id from TB_RESERVE where requidition_id ='" & id & "' "
            dttemp = DIPRFIDSqlDB.ExecuteTable(sql.ToString)
            If dttemp.Rows.Count > 0 Then
                trans.RollbackTransaction()
                retStatus = Utility.DefaultStringStatusReturn.deletefilefail
                Return retStatus
            End If

            dttemp = New DataTable
            sql = " select id from TB_RESERVE_HISTORY where  requidition_id ='" & id & "' "
            dttemp = DIPRFIDSqlDB.ExecuteTable(sql.ToString)
            If dttemp.Rows.Count > 0 Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.deletefilefail
            End If

            dttemp = New DataTable
            sql = " select id from TB_FILEBORROWITEM where  requisition_id ='" & id & "' "
            dttemp = DIPRFIDSqlDB.ExecuteTable(sql.ToString)
            If dttemp.Rows.Count > 0 Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.deletefilefail
            End If

            dttemp = New DataTable
            sql = " select id from TMP_FILEBORROWITEM where  app_no ='" & id & "' "
            dttemp = DIPRFIDSqlDB.ExecuteTable(sql.ToString)
            If dttemp.Rows.Count > 0 Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.deletefilefail
            End If

            dttemp = New DataTable
            sql = " select id from TS_FILE_CURRENT_LOCATION where  app_no ='" & id & "' "
            dttemp = DIPRFIDSqlDB.ExecuteTable(sql.ToString)
            If dttemp.Rows.Count > 0 Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.deletefilefail
            End If

            dttemp = New DataTable
            sql = " select id from TS_FILE_MOVE_HISTORY where  app_no ='" & id & "' "
            dttemp = DIPRFIDSqlDB.ExecuteTable(sql.ToString)
            If dttemp.Rows.Count > 0 Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.deletefilefail
            End If

            dttemp = New DataTable
            sql = " select id from TB_GATE_CONSOLE_LOG where  app_no ='" & id & "' "
            dttemp = DIPRFIDSqlDB.ExecuteTable(sql.ToString)
            If dttemp.Rows.Count > 0 Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.deletefilefail
            End If

            dttemp = New DataTable
            sql = " select id from TB_FILESTORE where  app_no ='" & id & "' "
            dttemp = DIPRFIDSqlDB.ExecuteTable(sql.ToString)
            If dttemp.Rows.Count > 0 Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.deletefilefail
            End If

            dttemp = New DataTable
            sql = " select id from TB_FIND_HHT where  app_no ='" & id & "' "
            dttemp = DIPRFIDSqlDB.ExecuteTable(sql.ToString)
            If dttemp.Rows.Count > 0 Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.deletefilefail
            End If



            ''== delete ==
            sql = "DELETE FROM  TS_REQUISITION_TAG where tb_requisition_id='" & id & "' "
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If


            sql = "DELETE FROM TB_REQUISTION where id ='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret
        Catch ex As Exception
            trans.RollbackTransaction()
            Return False
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadRequisitionTag(tb_requisition_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY id asc) AS no,id,tb_requisition_id,tag_no from TS_REQUISITION_TAG where tb_requisition_id ='" & tb_requisition_id & "' order by tag_no")

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

#Region "RFID ConfigSchedule"
    <WebMethod()> _
    Public Function LoadRFIDConfigScheduleAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY cf_speedway.id asc) AS no, cf_speedway.id,case isnull(ReaderID,'') when '' then 'New' else ReaderID end ReaderID,serial_no,ip_address,")
            strSql.Append(" install_position,floor_name,ms_floor_id,[dbo].IsReferenctRFIDConfigSchedule(cf_speedway.id) as IsDelete,")
            strSql.Append(" (case when isnull(cf_speedway.active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status from cf_speedway")
            strSql.Append(" inner join MS_ROOM on cf_speedway.ms_room_id =MS_ROOM.id inner join MS_FLOOR on MS_ROOM.ms_floor_id = MS_FLOOR.id")
            strSql.Append(" order by floor_name,ReaderID")

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
    Public Function LoadRFIDConfigScheduleByID(speedway_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ms.id,ReaderID,serial_no,ip_address,install_position,mac_address,floor_name,ms_floor_id,ms.active_status,ms.ms_room_id,ms.active_status,ms_speedway_objective_id,")
            strSql.Append(" mss.id as ms_speedway_setting_id,setting_label,setting_description,setting_search_mode,setting_session,setting_tag_populate_estimate,setting_time_correct_enabled,filters_mode,")
            strSql.Append(" keepalive_is_enabled,keepalive_period_in_ms,keepalive_link_down_threshold,mld.is_enabled as mld_is_enable,field_ping_interval_in_ms,")
            strSql.Append(" emptry_field_timeout_in_ms, report_mode, include_peak_rssi, include_antenna_port_number, include_first_seen_time, include_last_seen_time,")
            strSql.Append(" include_seen_count, include_channel, include_phase_angle, include_serialized_tid,ms.brand_name,ms.model_name,schedule_type,convert(varchar(10),schedule_date,103) schedule_date")
            strSql.Append(" ,ftp_user,ftp_pwd,ftp_port,ftp_path,ftp_data_path")
            strSql.Append(" from cf_speedway ms")
            strSql.Append(" inner join MS_ROOM mr on ms.ms_room_id = mr.id")
            strSql.Append(" inner join MS_FLOOR mf on mr.ms_floor_id = mf.id")
            strSql.Append(" inner join CF_SPEEDWAY_SETTING mss on ms.id = mss.cf_speedway_id")
            strSql.Append(" inner join CF_SPEEDWAY_LOW_DUTY_CYCLE mld on mss.id = mld.cf_speedway_setting_id")
            strSql.Append(" inner join CF_SPEEDWAY_REPORT mrp on mss.id = mrp.cf_speedway_setting_id")
            strSql.Append(" where ms.id ='" & speedway_id & "'")

            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("ftp_pwd") = SqlDB.DeCripPwd(dt.Rows(i)("ftp_pwd"))
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

    <WebMethod()> _
    Public Function SaveRFIDConfigSchedule(id As String, login_username As String, serial_no As String, _
        ip_address As String, mac_address As String, install_position As String, setting_label As String, _
        setting_description As String, setting_session As String, setting_tag_populate_estimate As String, _
        keepalive_period_in_ms As String, keepalive_link_down_threshold As String, field_ping_interval_in_ms As String, _
        emptry_field_timeout_in_ms As String, active_status As String, setting_time_correct_enabled As String, _
        keepalive_is_enabled As String, mld_is_enable As String, include_peak_rssi As String, _
        include_antenna_port_number As String, include_first_seen_time As String, include_last_seen_time As String, _
        include_seen_count As String, include_channel As String, include_phase_angle As String, include_serialized_tid As String, _
        ms_speedway_objective_id As String, ms_room_id As String, setting_search_mode As String, filters_mode As String, report_mode As String, _
        jsonobject_antenna As Object, jsonobject_gpi As Object, jsonobject_tagfilter As Object, reader_brand_name As String, reader_model_name As String, _
        rdnow As String, rdschedule As String, schedule_date As String, ftp_user As String, ftp_pwd As String, ftp_port As String, _
        ftp_path As String, ftp_data_path As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            Dim schedule_type As String = "N"
            Dim str_schedule_date As Date = Today.Date

            If rdschedule.ToLower = "true" Then
                schedule_type = "S"
                str_schedule_date = Date.ParseExact(schedule_date, "dd/MM/yyyy",
                System.Globalization.DateTimeFormatInfo.InvariantInfo)
            End If

            Dim sql As String = "select ID,ReaderID from ms_speedway where serial_no ='" & serial_no & "'"
            Dim dt_speedway As DataTable = DIPRFIDSqlDB.ExecuteTable(sql, trans.Trans)
            Dim ms_speedway_id As String = "0"
            Dim reader_id As String = ""
            If dt_speedway.Rows.Count > 0 Then
                ms_speedway_id = dt_speedway.Rows(0)("ID")
                reader_id = dt_speedway.Rows(0)("ReaderID")
            End If

            Dim cfid As String
            Dim lnq As New CfSpeedwayLinqDB
            With lnq

                If id = 0 Then
                    Dim dttemp As DataTable
                    dttemp = .GetDataList(" convert(varchar(10),schedule_date,103) ='" & schedule_date & "' and serial_no ='" & serial_no & "'", "", trans.Trans)
                    If dttemp.Rows.Count > 0 Then
                        .GetDataByPK(dttemp(0)("id"), trans.Trans)
                    End If
                Else
                    .GetDataByPK(id, trans.Trans)
                End If
                .MS_SPEEDWAY_ID = ms_speedway_id
                .READERID = reader_id
                .SERIAL_NO = serial_no
                .IP_ADDRESS = ip_address
                .MAC_ADDRESS = mac_address
                .INSTALL_POSITION = install_position
                .MS_ROOM_ID = ms_room_id
                .MS_SPEEDWAY_OBJECTIVE_ID = ms_speedway_objective_id
                .ACTIVE_STATUS = IIf(active_status = 0, "N", "Y")
                .BRAND_NAME = reader_brand_name
                .MODEL_NAME = reader_model_name
                .SCHEDULE_TYPE = schedule_type
                .SCHEDULE_DATE = str_schedule_date
                .IS_SEND_SPEEDWAY = "N"
                .IS_UPDATE_SETTING = "N"
                .FTP_USER = ftp_user
                .FTP_PWD = SqlDB.EnCripPwd(ftp_pwd)
                .FTP_PORT = ftp_port
                .FTP_PATH = ftp_path
                .FTP_DATA_PATH = ftp_data_path
                If lnq.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If

                cfid = .ID

                If ret = False Then
                    trans.RollbackTransaction()
                    Return Utility.DefaultStringStatusReturn.fail
                End If
            End With

            Dim settingid As String
            Dim lnqSetting As New CfSpeedwaySettingLinqDB
            With lnqSetting
                Dim dttemp As DataTable
                dttemp = .GetDataList("CF_SPEEDWAY_ID ='" & cfid & "'", "", trans.Trans)
                If dttemp.Rows.Count > 0 Then
                    .GetDataByPK(dttemp(0)("id"), trans.Trans)
                End If
                .CF_SPEEDWAY_ID = cfid
                .SETTING_LABEL = setting_label
                .SETTING_DESCRIPTION = setting_description
                .SETTING_SEARCH_MODE = setting_search_mode
                If setting_session <> "" Then .SETTING_SESSION = setting_session
                If setting_tag_populate_estimate <> "" Then .SETTING_TAG_POPULATE_ESTIMATE = setting_tag_populate_estimate
                .SETTING_TIME_CORRECT_ENABLED = IIf(setting_time_correct_enabled = "1", "true", "false")
                .FILTERS_MODE = filters_mode
                .KEEPALIVE_IS_ENABLED = IIf(keepalive_is_enabled = "1", "true", "false")
                If keepalive_period_in_ms <> "" Then .KEEPALIVE_PERIOD_IN_MS = keepalive_period_in_ms
                If keepalive_link_down_threshold <> "" Then .KEEPALIVE_LINK_DOWN_THRESHOLD = keepalive_link_down_threshold
                If lnqSetting.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If

                settingid = lnqSetting.ID
                If ret = False Then
                    trans.RollbackTransaction()
                    Return Utility.DefaultStringStatusReturn.fail
                End If
            End With

            Dim lnqLowDutyCycle As New CfSpeedwayLowDutyCycleLinqDB
            With lnqLowDutyCycle
                Dim dttemp As DataTable
                dttemp = .GetDataList("CF_SPEEDWAY_SETTING_ID ='" & settingid & "'", "", trans.Trans)
                If dttemp.Rows.Count > 0 Then
                    .GetDataByPK(dttemp(0)("id"), trans.Trans)
                End If
                .CF_SPEEDWAY_SETTING_ID = settingid
                .IS_ENABLED = IIf(mld_is_enable = "1", "true", "false")
                If field_ping_interval_in_ms <> "" Then .FIELD_PING_INTERVAL_IN_MS = field_ping_interval_in_ms
                If emptry_field_timeout_in_ms <> "" Then .EMPTRY_FIELD_TIMEOUT_IN_MS = emptry_field_timeout_in_ms
                If lnqLowDutyCycle.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If

                If ret = False Then
                    trans.RollbackTransaction()
                    Return Utility.DefaultStringStatusReturn.fail
                End If
            End With


            Dim lnqReport As New CfSpeedwayReportLinqDB
            With lnqReport
                Dim dttemp As DataTable
                dttemp = .GetDataList("CF_SPEEDWAY_SETTING_ID ='" & settingid & "'", "", trans.Trans)
                If dttemp.Rows.Count > 0 Then
                    .GetDataByPK(dttemp(0)("id"), trans.Trans)
                End If
                .CF_SPEEDWAY_SETTING_ID = settingid
                .REPORT_MODE = report_mode
                .INCLUDE_PEAK_RSSI = IIf(include_peak_rssi = "1", "true", "false")
                .INCLUDE_ANTENNA_PORT_NUMBER = IIf(include_antenna_port_number = "1", "true", "false")
                .INCLUDE_FIRST_SEEN_TIME = IIf(include_first_seen_time = "1", "true", "false")
                .INCLUDE_LAST_SEEN_TIME = IIf(include_last_seen_time = "1", "true", "false")
                .INCLUDE_SEEN_COUNT = IIf(include_seen_count = "1", "true", "false")
                .INCLUDE_CHANNEL = IIf(include_channel = "1", "true", "false")
                .INCLUDE_PHASE_ANGLE = IIf(include_phase_angle = "1", "true", "false")
                .INCLUDE_SERIALIZED_TID = IIf(include_serialized_tid = "1", "true", "false")

                If lnqReport.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If

                If ret = False Then
                    trans.RollbackTransaction()
                    Return Utility.DefaultStringStatusReturn.fail
                End If
            End With


            '== Antenna
            sql = "DELETE FROM CF_SPEEDWAY_ANT WHERE CF_SPEEDWAY_ID ='" & cfid & "' "
            'sql &= " and id not in (select distinct cf_speedway_ant_id from CF_SPEEDWAY_ANT_GRID where cf_speedway_id ='" & cfid & "' ) "
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If

            Dim dtJson_antenna As DataTable = clsdtHelper.ConvertJSONToDataTable(jsonobject_antenna)
            dtJson_antenna.Rows.RemoveAt(dtJson_antenna.Rows.Count - 1)
            dtJson_antenna.AcceptChanges()

            For i As Integer = 0 To dtJson_antenna.Rows.Count - 1
                Dim clsSpeedwayAntLinqDB As New CfSpeedwayAntLinqDB
                With clsSpeedwayAntLinqDB
                    .ChkDataByCF_SPEEDWAY_ID_PORT_NUMBER(cfid, dtJson_antenna.Rows(i)("port_number"), trans.Trans)

                    .CF_SPEEDWAY_ID = cfid
                    .PORT_NUMBER = dtJson_antenna.Rows(i)("port_number")
                    .IS_ENABLED = dtJson_antenna.Rows(i)("IS_ENABLED")
                    .TX_POWER_IN_DBM = Replace(dtJson_antenna.Rows(i)("TX_POWER_IN_DBM"), " ", "")
                    .RX_SENSITIVITY_IN_DBM = Replace(dtJson_antenna.Rows(i)("RX_SENSITIVITY_IN_DBM"), " ", "")
                    .BRAND_NAME = Replace(dtJson_antenna.Rows(i)("BRAND_NAME"), " ", "")
                    .MODEL_NAME = Replace(dtJson_antenna.Rows(i)("MODEL_NAME"), " ", "")
                    If .ID > 0 Then
                        ret = .UpdateByPK(login_username, trans.Trans)
                    Else
                        ret = .InsertData(login_username, trans.Trans)
                    End If

                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If

                End With
            Next


            '== GPI
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM CF_SPEEDWAY_GPI WHERE CF_SPEEDWAY_ID =" & cfid, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If

            Dim dtJson_gpi As DataTable = clsdtHelper.ConvertJSONToDataTable(jsonobject_gpi)
            dtJson_gpi.Rows.RemoveAt(dtJson_gpi.Rows.Count - 1)
            dtJson_gpi.AcceptChanges()
            For i As Integer = 0 To dtJson_gpi.Rows.Count - 1
                Dim clsSpeedwayGPILinqDB As New CfSpeedwayGpiLinqDB
                With clsSpeedwayGPILinqDB
                    .CF_SPEEDWAY_ID = cfid
                    .PORT_NUMBER = Replace(dtJson_gpi.Rows(i)("port_number"), " ", "")
                    .IS_ENABLED = dtJson_gpi.Rows(i)("IS_ENABLED")
                    .DEBOUNCE_IN_MS = dtJson_gpi.Rows(i)("DEBOUNCE_IN_MS")
                    .AUTO_START_MODE = dtJson_gpi.Rows(i)("AUTO_START_MODE")
                    .AUTO_START_GPI_LEVEL = dtJson_gpi.Rows(i)("AUTO_START_GPI_LEVEL")
                    .AUTO_START_FIRST_DELAY = Replace(dtJson_gpi.Rows(i)("AUTO_START_FIRST_DELAY"), " ", "")
                    .AUTO_START_PERIOD = Replace(dtJson_gpi.Rows(i)("AUTO_START_PERIOD"), " ", "")
                    .AUTO_STOP_MODE = dtJson_gpi.Rows(i)("AUTO_STOP_MODE")
                    .AUTO_STOP_GPI_LEVEL = Replace(dtJson_gpi.Rows(i)("AUTO_STOP_GPI_LEVEL"), " ", "")
                    .AUTO_STOP_DURATION = Replace(dtJson_gpi.Rows(i)("AUTO_STOP_DURATION"), " ", "")
                    .BRAND_NAME = Replace(dtJson_gpi.Rows(i)("BRAND_NAME"), " ", "")
                    .MODEL_NAME = Replace(dtJson_gpi.Rows(i)("MODEL_NAME"), " ", "")
                    ret = .InsertData(login_username, trans.Trans)

                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If
                End With
            Next


            '== Tag Filter
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM CF_SPEEDWAY_SETTING_FILTER where cf_speedway_setting_id ='" & settingid & "'", trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If

            Dim dtJson_tagfilter As DataTable = clsdtHelper.ConvertJSONToDataTable(jsonobject_tagfilter)
            dtJson_tagfilter.Rows.RemoveAt(dtJson_tagfilter.Rows.Count - 1)
            dtJson_tagfilter.AcceptChanges()
            For i As Integer = 0 To dtJson_tagfilter.Rows.Count - 1
                Dim clsSpeedwayTagFilterLinqDB As New CfSpeedwaySettingFilterLinqDB
                With clsSpeedwayTagFilterLinqDB
                    .CF_SPEEDWAY_SETTING_ID = settingid
                    .TAG_FILTER_NO = Replace(dtJson_tagfilter.Rows(i)("TAG_FILTER_NO"), " ", "")
                    .MEMORY_BANK = dtJson_tagfilter.Rows(i)("MEMORY_BANK")
                    .BIT_POINTER = Replace(dtJson_tagfilter.Rows(i)("BIT_POINTER"), " ", "")
                    .BIT_COUNT = Replace(dtJson_tagfilter.Rows(i)("BIT_COUNT"), " ", "")
                    .TAG_MASK = dtJson_tagfilter.Rows(i)("TAG_MASK")
                    .FILTER_OP = dtJson_tagfilter.Rows(i)("FILTER_OP")
                    ret = .InsertData(login_username, trans.Trans)
                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If
                End With
            Next


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            trans.RollbackTransaction()
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Private Function GetMaxCFReaderID(trans As TransactionDB) As String

        Dim sql As String = "select isnull(max(readerid),0)+1 maxid from cf_speedway "
        Dim dt As DataTable = DIPRFIDSqlDB.ExecuteTable(sql, trans.Trans)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("maxid")
        End If

        Return "1"

    End Function

    <WebMethod()> _
    Public Function DeleteRFIDConfigSchedul(id As String) As Boolean
        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Try
            Dim ret As Boolean = True
            Dim sql As String = "DELETE FROM  CF_SPEEDWAY_LOW_DUTY_CYCLE where cf_speedway_setting_id in (select distinct id from CF_SPEEDWAY_SETTING where cf_speedway_id='" & id & "')"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM  CF_SPEEDWAY_REPORT where cf_speedway_setting_id in (select distinct id from CF_SPEEDWAY_SETTING where cf_speedway_id='" & id & "')"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM CF_SPEEDWAY_SETTING_FILTER where cf_speedway_setting_id in (select distinct id from CF_SPEEDWAY_SETTING where cf_speedway_id='" & id & "')"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM CF_SPEEDWAY_SETTING where cf_speedway_id='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM CF_SPEEDWAY_ANT where cf_speedway_id='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM CF_SPEEDWAY_GPI where cf_speedway_id='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM cf_speedway where id ='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret
        Catch ex As Exception
            trans.RollbackTransaction()
            Return False
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadRFIDConfigScheduleAntenna(id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY id asc) AS no,id,cf_speedway_id,")
            strSql.Append(" port_number,(case when isnull(is_enabled ,'N') = 'N' then 'False' else 'True' end ) is_enabled,tx_power_in_dbm,rx_sensitivity_in_dbm,brand_name,model_name")
            strSql.Append(" from CF_SPEEDWAY_ANT ")
            strSql.Append(" where cf_speedway_id ='" & id & "' order by port_number")


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
    Public Function LoadRFIDConfigScheduleGPI(id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY id asc) AS no,id,cf_speedway_id,")
            strSql.Append(" port_number,(case when isnull(is_enabled ,'N') = 'N' then 'False' else 'True' end ) is_enabled")
            strSql.Append(" ,debounce_in_ms,auto_start_mode,auto_start_gpi_level,")
            strSql.Append(" auto_start_first_delay,auto_start_period,auto_stop_mode,auto_stop_gpi_level,auto_stop_duration,brand_name,model_name")
            strSql.Append(" from CF_SPEEDWAY_GPI")
            strSql.Append(" where cf_speedway_id ='" & id & "' order by port_number")


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
    Public Function LoadRFIDConfigScheduleTagFilter(id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY id asc) AS no")
            strSql.Append(" ,cf_speedway_setting_id,id,tag_filter_no,memory_bank,bit_pointer,bit_count,tag_mask,filter_op")
            strSql.Append(" from CF_SPEEDWAY_SETTING_FILTER")
            strSql.Append(" where cf_speedway_setting_id ='" & id & "' order by tag_filter_no")

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

#Region "Speedway"

    <WebMethod()> _
    Public Function LoadSpeedwayAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY ms_speedway.id asc) AS no, ms_speedway.id,ReaderID,serial_no,ip_address,")
            strSql.Append("install_position,floor_name,ms_floor_id,[dbo].IsReferenctSpeedway(ms_speedway.id) as IsDelete,")
            strSql.Append(" (case when isnull(ms_speedway.active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status from ms_speedway")
            strSql.Append(" inner join MS_ROOM on ms_speedway.ms_room_id =MS_ROOM.id inner join MS_FLOOR on MS_ROOM.ms_floor_id = MS_FLOOR.id")
            strSql.Append(" order by floor_name,ReaderID")

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
    Public Function LoadSpeedwayByID(speedway_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ms.id,ReaderID,serial_no,ip_address, mac_address,install_position,floor_name,ms_floor_id,ms.active_status,ms.ms_room_id,ms.active_status,ms_speedway_objective_id,")
            strSql.Append(" mss.id as ms_speedway_setting_id,setting_label,setting_description,setting_search_mode,setting_session,setting_tag_populate_estimate,setting_time_correct_enabled,filters_mode,")
            strSql.Append(" keepalive_is_enabled,keepalive_period_in_ms,keepalive_link_down_threshold,mld.is_enabled as mld_is_enable,field_ping_interval_in_ms,")
            strSql.Append(" emptry_field_timeout_in_ms, report_mode, include_peak_rssi, include_antenna_port_number, include_first_seen_time, include_last_seen_time,")
            strSql.Append(" include_seen_count, include_channel, include_phase_angle, include_serialized_tid,ms.brand_name,ms.model_name,ftp_user,ftp_pwd,ftp_port,ftp_path,ftp_data_path")
            strSql.Append(" from ms_speedway ms")
            strSql.Append(" inner join MS_ROOM mr on ms.ms_room_id = mr.id")
            strSql.Append(" inner join MS_FLOOR mf on mr.ms_floor_id = mf.id")
            strSql.Append(" inner join MS_SPEEDWAY_SETTING mss on ms.id = mss.ms_speedway_id")
            strSql.Append(" inner join MS_SPEEDWAY_LOW_DUTY_CYCLE mld on mss.id = mld.ms_speedway_setting_id")
            strSql.Append(" inner join MS_SPEEDWAY_REPORT mrp on mss.id = mrp.ms_speedway_setting_id")
            strSql.Append(" where ms.id ='" & speedway_id & "'")

            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("ftp_pwd") = SqlDB.DeCripPwd(dt.Rows(i)("ftp_pwd"))
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

    <WebMethod()> _
    Public Function SaveSpeedway(id As String, login_username As String, serial_no As String, _
        ip_address As String, mac_address As String, install_position As String, setting_label As String, _
        setting_description As String, setting_session As String, setting_tag_populate_estimate As String, _
        keepalive_period_in_ms As String, keepalive_link_down_threshold As String, field_ping_interval_in_ms As String, _
        emptry_field_timeout_in_ms As String, active_status As String, setting_time_correct_enabled As String, _
        keepalive_is_enabled As String, mld_is_enable As String, include_peak_rssi As String, _
        include_antenna_port_number As String, include_first_seen_time As String, include_last_seen_time As String, _
        include_seen_count As String, include_channel As String, include_phase_angle As String, include_serialized_tid As String, _
        ms_speedway_objective_id As String, ms_room_id As String, setting_search_mode As String, filters_mode As String, report_mode As String, _
        jsonobject_antenna As Object, jsonobject_gpi As Object, jsonobject_tagfilter As Object, reader_brand_name As String, reader_model_name As String, _
        ftp_user As String, ftp_pwd As String, ftp_port As String, ftp_path As String, ftp_data_path As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from ms_speedway where serial_no ='" & serial_no & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_speedway_serailno
                Return retStatus
            End If


            Dim speedwayid As String
            Dim lnq As New MsSpeedwayLinqDB
            With lnq
                .GetDataByPK(id, trans.Trans)
                .SERIAL_NO = serial_no
                .IP_ADDRESS = ip_address
                .MAC_ADDRESS = mac_address
                .INSTALL_POSITION = install_position
                .MS_ROOM_ID = ms_room_id
                .MS_SPEEDWAY_OBJECTIVE_ID = ms_speedway_objective_id
                .ACTIVE_STATUS = IIf(active_status = 0, "N", "Y")
                .BRAND_NAME = reader_brand_name
                .MODEL_NAME = reader_model_name
                .FTP_USER = ftp_user
                .FTP_PWD = SqlDB.EnCripPwd(ftp_pwd)
                .FTP_PORT = ftp_port
                .FTP_PATH = ftp_path
                .FTP_DATA_PATH = ftp_data_path
                If lnq.ID = 0 Then
                    .READERID = GetMaxReaderID(trans)
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If

                speedwayid = .ID

                If ret = False Then
                    trans.RollbackTransaction()
                    Return Utility.DefaultStringStatusReturn.fail
                End If
            End With

            Dim settingid As String
            Dim lnqSetting As New MsSpeedwaySettingLinqDB
            With lnqSetting
                Dim dttemp As DataTable
                dttemp = .GetDataList("MS_SPEEDWAY_ID ='" & speedwayid & "'", "", trans.Trans)
                If dttemp.Rows.Count > 0 Then
                    .GetDataByPK(dttemp(0)("id"), trans.Trans)
                End If
                .MS_SPEEDWAY_ID = speedwayid
                .SETTING_LABEL = setting_label
                .SETTING_DESCRIPTION = setting_description
                .SETTING_SEARCH_MODE = setting_search_mode
                If setting_session <> "" Then .SETTING_SESSION = setting_session
                If setting_tag_populate_estimate <> "" Then .SETTING_TAG_POPULATE_ESTIMATE = setting_tag_populate_estimate
                .SETTING_TIME_CORRECT_ENABLED = IIf(setting_time_correct_enabled = "1", "true", "false")
                .FILTERS_MODE = filters_mode
                .KEEPALIVE_IS_ENABLED = IIf(keepalive_is_enabled = "1", "true", "false")
                If keepalive_period_in_ms <> "" Then .KEEPALIVE_PERIOD_IN_MS = keepalive_period_in_ms
                If keepalive_link_down_threshold <> "" Then .KEEPALIVE_LINK_DOWN_THRESHOLD = keepalive_link_down_threshold
                If lnqSetting.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If

                settingid = lnqSetting.ID
                If ret = False Then
                    trans.RollbackTransaction()
                    Return Utility.DefaultStringStatusReturn.fail
                End If
            End With

            Dim lnqLowDutyCycle As New MsSpeedwayLowDutyCycleLinqDB
            With lnqLowDutyCycle
                Dim dttemp As DataTable
                dttemp = .GetDataList("MS_SPEEDWAY_SETTING_ID ='" & settingid & "'", "", trans.Trans)
                If dttemp.Rows.Count > 0 Then
                    .GetDataByPK(dttemp(0)("id"), trans.Trans)
                End If
                .MS_SPEEDWAY_SETTING_ID = settingid
                .IS_ENABLED = IIf(mld_is_enable = "1", "true", "false")
                If field_ping_interval_in_ms <> "" Then .FIELD_PING_INTERVAL_IN_MS = field_ping_interval_in_ms
                If emptry_field_timeout_in_ms <> "" Then .EMPTRY_FIELD_TIMEOUT_IN_MS = emptry_field_timeout_in_ms
                If lnqLowDutyCycle.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If

                If ret = False Then
                    trans.RollbackTransaction()
                    Return Utility.DefaultStringStatusReturn.fail
                End If
            End With


            Dim lnqReport As New MsSpeedwayReportLinqDB
            With lnqReport
                Dim dttemp As DataTable
                dttemp = .GetDataList("MS_SPEEDWAY_SETTING_ID ='" & settingid & "'", "", trans.Trans)
                If dttemp.Rows.Count > 0 Then
                    .GetDataByPK(dttemp(0)("id"), trans.Trans)
                End If
                .MS_SPEEDWAY_SETTING_ID = settingid
                .REPORT_MODE = report_mode
                .INCLUDE_PEAK_RSSI = IIf(include_peak_rssi = "1", "true", "false")
                .INCLUDE_ANTENNA_PORT_NUMBER = IIf(include_antenna_port_number = "1", "true", "false")
                .INCLUDE_FIRST_SEEN_TIME = IIf(include_first_seen_time = "1", "true", "false")
                .INCLUDE_LAST_SEEN_TIME = IIf(include_last_seen_time = "1", "true", "false")
                .INCLUDE_SEEN_COUNT = IIf(include_seen_count = "1", "true", "false")
                .INCLUDE_CHANNEL = IIf(include_channel = "1", "true", "false")
                .INCLUDE_PHASE_ANGLE = IIf(include_phase_angle = "1", "true", "false")
                .INCLUDE_SERIALIZED_TID = IIf(include_serialized_tid = "1", "true", "false")

                If lnqReport.ID = 0 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If

                If ret = False Then
                    trans.RollbackTransaction()
                    Return Utility.DefaultStringStatusReturn.fail
                End If
            End With


            '== Antenna
            Dim sql As String = "DELETE FROM MS_SPEEDWAY_ANT WHERE MS_SPEEDWAY_ID ='" & speedwayid & "' "
            sql &= " and id not in (select distinct ms_speedway_ant_id from MS_SPEEDWAY_ANT_GRID where ms_speedway_id ='" & speedwayid & "' ) "
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If

            Dim dtJson_antenna As DataTable = clsdtHelper.ConvertJSONToDataTable(jsonobject_antenna)
            dtJson_antenna.Rows.RemoveAt(dtJson_antenna.Rows.Count - 1)
            dtJson_antenna.AcceptChanges()

            For i As Integer = 0 To dtJson_antenna.Rows.Count - 1
                Dim clsSpeedwayAntLinqDB As New MsSpeedwayAntLinqDB
                With clsSpeedwayAntLinqDB
                    .ChkDataByMS_SPEEDWAY_ID_PORT_NUMBER(speedwayid, dtJson_antenna.Rows(i)("port_number"), trans.Trans)

                    .MS_SPEEDWAY_ID = speedwayid
                    .PORT_NUMBER = dtJson_antenna.Rows(i)("port_number")
                    .IS_ENABLED = dtJson_antenna.Rows(i)("IS_ENABLED")
                    .TX_POWER_IN_DBM = Replace(dtJson_antenna.Rows(i)("TX_POWER_IN_DBM"), " ", "")
                    .RX_SENSITIVITY_IN_DBM = Replace(dtJson_antenna.Rows(i)("RX_SENSITIVITY_IN_DBM"), " ", "")
                    .BRAND_NAME = dtJson_antenna.Rows(i)("BRAND_NAME") & ""
                    .MODEL_NAME = dtJson_antenna.Rows(i)("MODEL_NAME") & ""
                    If .ID > 0 Then
                        ret = .UpdateByPK(login_username, trans.Trans)
                    Else
                        ret = .InsertData(login_username, trans.Trans)
                    End If

                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If

                End With
            Next


            '== GPI
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_SPEEDWAY_GPI WHERE MS_SPEEDWAY_ID =" & speedwayid, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If

            Dim dtJson_gpi As DataTable = clsdtHelper.ConvertJSONToDataTable(jsonobject_gpi)
            dtJson_gpi.Rows.RemoveAt(dtJson_gpi.Rows.Count - 1)
            dtJson_gpi.AcceptChanges()
            For i As Integer = 0 To dtJson_gpi.Rows.Count - 1
                Dim clsSpeedwayGPILinqDB As New MsSpeedwayGpiLinqDB
                With clsSpeedwayGPILinqDB
                    .MS_SPEEDWAY_ID = speedwayid
                    .PORT_NUMBER = Replace(dtJson_gpi.Rows(i)("port_number"), " ", "")
                    .IS_ENABLED = dtJson_gpi.Rows(i)("IS_ENABLED")
                    .DEBOUNCE_IN_MS = dtJson_gpi.Rows(i)("DEBOUNCE_IN_MS")
                    .AUTO_START_MODE = dtJson_gpi.Rows(i)("AUTO_START_MODE")
                    .AUTO_START_GPI_LEVEL = dtJson_gpi.Rows(i)("AUTO_START_GPI_LEVEL")
                    .AUTO_START_FIRST_DELAY = Replace(dtJson_gpi.Rows(i)("AUTO_START_FIRST_DELAY"), " ", "")
                    .AUTO_START_PERIOD = Replace(dtJson_gpi.Rows(i)("AUTO_START_PERIOD"), " ", "")
                    .AUTO_STOP_MODE = dtJson_gpi.Rows(i)("AUTO_STOP_MODE")
                    .AUTO_STOP_GPI_LEVEL = Replace(dtJson_gpi.Rows(i)("AUTO_STOP_GPI_LEVEL"), " ", "")
                    .AUTO_STOP_DURATION = Replace(dtJson_gpi.Rows(i)("AUTO_STOP_DURATION"), " ", "")
                    .BRAND_NAME = dtJson_gpi.Rows(i)("BRAND_NAME") & ""
                    .MODEL_NAME = dtJson_gpi.Rows(i)("MODEL_NAME") & ""
                    ret = .InsertData(login_username, trans.Trans)

                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If
                End With
            Next


            '== Tag Filter
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_SPEEDWAY_SETTING_FILTER where ms_speedway_setting_id ='" & settingid & "'", trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return Utility.DefaultStringStatusReturn.fail
            End If

            Dim dtJson_tagfilter As DataTable = clsdtHelper.ConvertJSONToDataTable(jsonobject_tagfilter)
            dtJson_tagfilter.Rows.RemoveAt(dtJson_tagfilter.Rows.Count - 1)
            dtJson_tagfilter.AcceptChanges()
            For i As Integer = 0 To dtJson_tagfilter.Rows.Count - 1
                Dim clsSpeedwayTagFilterLinqDB As New MsSpeedwaySettingFilterLinqDB
                With clsSpeedwayTagFilterLinqDB
                    .MS_SPEEDWAY_SETTING_ID = settingid
                    .TAG_FILTER_NO = Replace(dtJson_tagfilter.Rows(i)("TAG_FILTER_NO"), " ", "")
                    .MEMORY_BANK = dtJson_tagfilter.Rows(i)("MEMORY_BANK")
                    .BIT_POINTER = Replace(dtJson_tagfilter.Rows(i)("BIT_POINTER"), " ", "")
                    .BIT_COUNT = Replace(dtJson_tagfilter.Rows(i)("BIT_COUNT"), " ", "")
                    .TAG_MASK = dtJson_tagfilter.Rows(i)("TAG_MASK")
                    .FILTER_OP = dtJson_tagfilter.Rows(i)("FILTER_OP")
                    ret = .InsertData(login_username, trans.Trans)
                    If ret = False Then
                        trans.RollbackTransaction()
                        Return Utility.DefaultStringStatusReturn.fail
                    End If
                End With
            Next


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            trans.RollbackTransaction()
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    Private Function GetMaxReaderID(trans As TransactionDB) As String
        Return Engine.SpeedwayENG.GetMaxReaderID(trans)
    End Function

    <WebMethod()> _
    Public Function GetSpeedwayDefaultMaxGPI() As Integer
        Return Engine.GlobalFunction.GetSysConfing("SpeedwayDefaultMaxGPI")
    End Function

    <WebMethod()> _
    Public Function GetSpeedwayDefaultMaxAnt() As Integer
        Return Engine.GlobalFunction.GetSysConfing("SpeedwayDefaultMaxAnt")
    End Function

    <WebMethod()> _
    Public Function DeleteSpeedway(id As String) As Boolean
        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Try
            Dim ret As Boolean = True
            Dim sql As String = "DELETE FROM  MS_SPEEDWAY_LOW_DUTY_CYCLE where ms_speedway_setting_id in (select distinct id from MS_SPEEDWAY_SETTING where ms_speedway_id='" & id & "')"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM  MS_SPEEDWAY_REPORT where ms_speedway_setting_id in (select distinct id from MS_SPEEDWAY_SETTING where ms_speedway_id='" & id & "')"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM MS_SPEEDWAY_SETTING_FILTER where ms_speedway_setting_id in (select distinct id from MS_SPEEDWAY_SETTING where ms_speedway_id='" & id & "')"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM MS_SPEEDWAY_SETTING where ms_speedway_id='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM MS_SPEEDWAY_ANT where ms_speedway_id='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM MS_SPEEDWAY_GPI where ms_speedway_id='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM ms_speedway where id ='" & id & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans)
            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret
        Catch ex As Exception
            trans.RollbackTransaction()
            Return False
        End Try
    End Function


    <WebMethod()> _
    Public Function LoadSearchMode(SearchMode As String) As String
        Try
            Dim dt As New DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String

            dt.Columns.Add("id")
            dt.Columns.Add("name")
            dt.Columns.Add("selected")


            Dim dr As DataRow
            dr = dt.NewRow
            dr("id") = "DualTarget"
            dr("name") = "DualTarget"
            dr("selected") = ""
            If SearchMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "Single Target Inventory"
            dr("name") = "Single Target Inventory"
            dr("selected") = ""
            If SearchMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "Single Target w/ Suppression"
            dr("name") = "Single Target w/ Suppression"
            dr("selected") = ""
            If SearchMode = dr("id") Then
                dr("selected") = "selected"
            End If
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
    Public Function LoadFilterMode(FilterMode As String) As String
        Try
            Dim dt As New DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String

            dt.Columns.Add("id")
            dt.Columns.Add("name")
            dt.Columns.Add("selected")

            Dim dr As DataRow
            dr = dt.NewRow
            dr("id") = "None"
            dr("name") = "None"
            dr("selected") = ""
            If FilterMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "Filter1AndFilter2"
            dr("name") = "Filter1AndFilter2"
            dr("selected") = ""
            If FilterMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "Filter1OrFilter2"
            dr("name") = "Filter1OrFilter2"
            dr("selected") = ""
            If FilterMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "OnlyFilter1"
            dr("name") = "OnlyFilter1"
            dr("selected") = ""
            If FilterMode = dr("id") Then
                dr("selected") = "selected"
            End If
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
    Public Function LoadReportMode(ReportMode As String) As String
        Try
            Dim dt As New DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String

            dt.Columns.Add("id")
            dt.Columns.Add("name")
            dt.Columns.Add("selected")

            Dim dr As DataRow
            dr = dt.NewRow
            dr("id") = "Individual"
            dr("name") = "Individual"
            dr("selected") = ""
            If ReportMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "BatchAfterStop"
            dr("name") = "BatchAfterStop"
            dr("selected") = ""
            If ReportMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "IndividualUnbuffered"
            dr("name") = "IndividualUnbuffered"
            dr("selected") = ""
            If ReportMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "WaitForQuery"
            dr("name") = "WaitForQuery"
            dr("selected") = ""
            If ReportMode = dr("id") Then
                dr("selected") = "selected"
            End If
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
    Public Function LoadAutoStartMode(AutoStartMode As String) As String
        Try
            Dim dt As New DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String

            dt.Columns.Add("id")
            dt.Columns.Add("name")
            dt.Columns.Add("selected")

            Dim dr As DataRow
            dr = dt.NewRow
            dr("id") = "None"
            dr("name") = "None"
            dr("selected") = ""
            If AutoStartMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "GpiTrigger"
            dr("name") = "GpiTrigger"
            dr("selected") = ""
            If AutoStartMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "Immediate"
            dr("name") = "Immediate"
            dr("selected") = ""
            If AutoStartMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "Periodic"
            dr("name") = "Periodic"
            dr("selected") = ""
            If AutoStartMode = dr("id") Then
                dr("selected") = "selected"
            End If
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
    Public Function LoadGPILevel(GPILevel As String) As String
        Try
            Dim dt As New DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String

            dt.Columns.Add("id")
            dt.Columns.Add("name")
            dt.Columns.Add("selected")

            Dim dr As DataRow
            dr = dt.NewRow
            dr("id") = "True"
            dr("name") = "True"
            dr("selected") = ""
            If GPILevel = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "False"
            dr("name") = "False"
            dr("selected") = ""
            If GPILevel = dr("id") Then
                dr("selected") = "selected"
            End If
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
    Public Function LoadAutoStopMode(AutoStopMode As String) As String
        Try
            Dim dt As New DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String

            dt.Columns.Add("id")
            dt.Columns.Add("name")
            dt.Columns.Add("selected")

            Dim dr As DataRow
            dr = dt.NewRow
            dr("id") = "None"
            dr("name") = "None"
            dr("selected") = ""
            If AutoStopMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "GpiTrigger"
            dr("name") = "GpiTrigger"
            dr("selected") = ""
            If AutoStopMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "Immediate"
            dr("name") = "Immediate"
            dr("selected") = ""
            If AutoStopMode = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "Periodic"
            dr("name") = "Periodic"
            dr("selected") = ""
            If AutoStopMode = dr("id") Then
                dr("selected") = "selected"
            End If
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
    Public Function LoadMemoryBank(MemoryBank As String) As String
        Try
            Dim dt As New DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String

            dt.Columns.Add("id")
            dt.Columns.Add("name")
            dt.Columns.Add("selected")

            Dim dr As DataRow
            dr = dt.NewRow
            dr("id") = "None"
            dr("name") = "None"
            dr("selected") = ""
            If MemoryBank = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "Epc"
            dr("name") = "Epc"
            dr("selected") = ""
            If MemoryBank = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "Reserved"
            dr("name") = "Reserved"
            dr("selected") = ""
            If MemoryBank = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "Tid"
            dr("name") = "Tid"
            dr("selected") = ""
            If MemoryBank = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "User"
            dr("name") = "User"
            dr("selected") = ""
            If MemoryBank = dr("id") Then
                dr("selected") = "selected"
            End If
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
    Public Function LoadFilterOp(FilterOp As String) As String
        Try
            Dim dt As New DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String

            dt.Columns.Add("id")
            dt.Columns.Add("name")
            dt.Columns.Add("selected")

            Dim dr As DataRow
            dr = dt.NewRow
            dr("id") = "None"
            dr("name") = "None"
            dr("selected") = ""
            If FilterOp = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "Match"
            dr("name") = "Match"
            dr("selected") = ""
            If FilterOp = dr("id") Then
                dr("selected") = "selected"
            End If
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("id") = "NotMatch"
            dr("name") = "NotMatch"
            dr("selected") = ""
            If FilterOp = dr("id") Then
                dr("selected") = "selected"
            End If
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
    Public Function LoadSpeedwayAntenna(id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY id asc) AS no,id,ms_speedway_id,[dbo].IsReferenctAnt(id)  as IsDelete,")
            strSql.Append(" port_number,(case when isnull(is_enabled ,'N') = 'N' then 'False' else 'True' end ) is_enabled,tx_power_in_dbm,rx_sensitivity_in_dbm,brand_name,model_name")
            strSql.Append(" from MS_SPEEDWAY_ANT ")
            strSql.Append(" where ms_speedway_id ='" & id & "' order by port_number")


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
    Public Function LoadSpeedwayGPI(id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY id asc) AS no,id,ms_speedway_id,")
            strSql.Append(" port_number,(case when isnull(is_enabled ,'N') = 'N' then 'False' else 'True' end ) is_enabled")
            strSql.Append(" ,debounce_in_ms,auto_start_mode,auto_start_gpi_level,")
            strSql.Append(" auto_start_first_delay,auto_start_period,auto_stop_mode,auto_stop_gpi_level,auto_stop_duration,brand_name,model_name")
            strSql.Append(" from MS_SPEEDWAY_GPI")
            strSql.Append(" where ms_speedway_id ='" & id & "' order by port_number")


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
    Public Function LoadSpeedwayTagFilter(id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY id asc) AS no")
            strSql.Append(" ,ms_speedway_setting_id,id,tag_filter_no,memory_bank,bit_pointer,bit_count,tag_mask,filter_op")
            strSql.Append(" from MS_SPEEDWAY_SETTING_FILTER")
            strSql.Append(" where ms_speedway_setting_id ='" & id & "' order by tag_filter_no")

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

#Region "Authorize"
    <WebMethod()> _
    Public Function GetUserMapAuthorizeGroup(groupid As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            

            strSql.AppendLine(" select ")
            strSql.AppendLine(" ROW_NUMBER() OVER(ORDER BY au.id asc) AS no")
            strSql.AppendLine(" ,au.id ")
            strSql.AppendLine(" ,tb1.fullname as fullname_eng ")
            strSql.AppendLine(" ,tb1.fullname as fullname_thai ")
            strSql.AppendLine(" ,o.officer_no ")
            strSql.AppendLine(" ,p.position_name ")
            strSql.AppendLine(" ,dp.department_name   ")
            strSql.AppendLine(" from ( ")
            strSql.AppendLine("     select officer_no as of_no ")
            strSql.AppendLine("     ,ltrim(isnull(title_name,'') + isnull(fname,'') + ' ' + isnull(lname,'')) + ")
            strSql.AppendLine("     case when ltrim(rtrim(isnull(username,''))) <> '' then ' (' + username + ')' end as fullname ")
            strSql.AppendLine("     from TB_OFFICER x  ")
            strSql.AppendLine("     left join TB_TITLE y on x.title_id = y.id  ) as tb1  ")
            strSql.AppendLine(" inner join TB_OFFICER as o on tb1.of_no = o.officer_no  ")
            strSql.AppendLine(" left join TB_DEPARTMENT dp on o.department_id = dp.id  ")
            strSql.AppendLine(" left join TB_POSITION p on o.position_id = p.id ")
            strSql.AppendLine(" inner join tb_permission_officer au on au.officer_id = o.id")
            strSql.AppendLine(" where au.permission_id =" & groupid)
            strSql.AppendLine(" and tb1.fullname <> ''")
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
    Public Function GetNotUserMapAuthorizeGroup(name As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" isnull(p.prefix_eng,'') + u.name_eng + ' ' + u.surname_eng as label")
            strSql.Append(" ,u.id")
            strSql.Append(" ,isnull(p.prefix_eng,'') + u.name_eng + ' ' + u.surname_eng as fullname_eng")
            strSql.Append(" ,isnull(p.prefix_thai,'') + u.name_thai + ' ' + u.surname_thai as fullname_thai")
            strSql.Append(" from  ms_user  u")
            strSql.Append(" inner join ms_prefix p")
            strSql.Append(" on u.ms_prefix_id = p.id")
            strSql.Append(" where u.active_status='Y'  and u.id not in(select id_ms_user from ts_authorizegroup_user) and (isnull(p.prefix_eng,'') + u.name_eng + ' ' + u.surname_eng) like '%" & name & "%'")
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
    Public Function LoadUserAll2() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY u.id asc) AS no")
            strSql.Append(" ,u.id")
            strSql.Append(" ,(case when isnull(u.active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status_desc")
            strSql.Append(" ,u.name_thai")
            strSql.Append(" ,u.name_eng")
            strSql.Append(" ,u.surname_thai")
            strSql.Append(" ,u.surname_eng")
            strSql.Append(" ,u.ms_prefix_id")
            strSql.Append(" ,u.ms_department_id")
            strSql.Append(" ,u.ms_position_id")
            strSql.Append(" ,pf.prefix_eng")
            strSql.Append(" ,d.department_name")
            strSql.Append(" ,p.position_name")
            strSql.Append(" ,isnull(pf.prefix_eng,'') + u.name_eng + ' ' + u.surname_eng as fullname")
            strSql.Append(" ,u.employee_code")
            strSql.Append(" from ms_user u")
            strSql.Append(" inner join ms_prefix pf")
            strSql.Append(" on pf.id = u.ms_prefix_id")
            strSql.Append(" inner join ms_department d")
            strSql.Append(" on d.id = u.ms_department_id")
            strSql.Append(" inner join ms_position p")
            strSql.Append(" on p.id = u.ms_position_id")
            strSql.Append(" order by u.name_thai")

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
    Public Function LoadGroupPermissionAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select	ROW_NUMBER() OVER(ORDER BY id asc) AS no ")
            strSql.Append(" ,id")
            strSql.Append(" ,(case active_status when 'Y' then 'Active' else 'No Active' end) as active_status_desc  ")
            strSql.Append(" ,permission_name as group_name")
            strSql.Append(" ,permission_desc as group_desc")
            strSql.Append(" from tb_permission ")
            strSql.Append(" order by permission_name ")

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
    Public Function SaveAuthorizeGroup(strId As String, groupid As String, userid As String) As Boolean
        Try
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim ret As Boolean = False
            'Delete Old Data
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM TB_PERMISSION_MENU WHERE PERMISSION_ID =" & groupid)

            Dim dtgetallscreen As DataTable = DIPRFIDSqlDB.ExecuteTable("select id from tb_menu where id in(" & strId & ")	union select id from tb_menu where id in (select rowid_rootmenu from tb_menu where id in(" & strId & "))")

            'Insert New Data
            Dim clsTbPermissionMenuLinqDB As New TbPermissionMenuLinqDB
            '  Dim strTemp() As String = strId.Split(",")
            For i As Integer = 0 To dtgetallscreen.Rows.Count - 1
                If dtgetallscreen.Rows(i)("id") <> 0 Then
                    clsTbPermissionMenuLinqDB = New TbPermissionMenuLinqDB
                    With clsTbPermissionMenuLinqDB
                        .PERMISSION_ID = groupid
                        .MENU_ID = dtgetallscreen.Rows(i)("id")
                        ret = .InsertData(userid, trans.Trans)
                        If ret = False Then
                            Exit For
                        End If
                    End With

                    'clsTsAuthorizegroupMenuLinqDB = New TsAuthorizegroupMenuLinqDB
                    'Dim strSQl As New StringBuilder
                    'Dim dtcheck As DataTable
                    'strSQl.Append(" select count(am.id) from ts_authorizegroup_menu am ")
                    'strSQl.Append(" where am.id_ms_authorizegroup =" & groupid)
                    'strSQl.Append(" and am.id_ms_screen in ( ")
                    'strSQl.Append(" select rowid_rootmenu from ms_screen where id =" & strTemp(i) & " ) ")
                    ''dtcheck = clsTsAuthorizegroupMenuLinqDB.GetListBySql(strSQl.ToString, trans.Trans)
                    'dtcheck = SqlDB.ExecuteTable(strSQl.ToString)
                    'If dtcheck.Rows.Count = 0 Then

                    '    'clsTsAuthorizegroupMenuLinqDB = New TsAuthorizegroupMenuLinqDB
                    '    Dim strSQl2 As New StringBuilder
                    '    Dim dtcheck2 As DataTable
                    '    strSQl2.Append(" select rowid_rootmenu from ms_screen where id =" & strTemp(i))
                    '    ' dtcheck2 = clsTsAuthorizegroupMenuLinqDB.GetListBySql(strSQl.ToString, trans.Trans)
                    '    dtcheck2 = SqlDB.ExecuteTable(strSQl2.ToString)
                    '    If dtcheck2.Rows.Count > 0 Then
                    '        clsTsAuthorizegroupMenuLinqDB = New TsAuthorizegroupMenuLinqDB
                    '        With clsTsAuthorizegroupMenuLinqDB
                    '            .ID_MS_AUTHORIZEGROUP = groupid
                    '            .ID_MS_SCREEN = dtcheck2.Rows(0)("rowid_rootmenu") & ""
                    '            ret = .InsertData(userid, trans.Trans)
                    '            If ret = False Then
                    '                Exit For
                    '            End If
                    '        End With
                    '    End If


                    'End If


                End If
            Next

            If ret = False Then
                trans.RollbackTransaction()
            Else
                trans.CommitTransaction()
            End If

            Return ret
        Catch ex As Exception
            Return False
        End Try

    End Function

    <WebMethod()> _
    Public Function SaveGroup(id As String, group_name As String, group_desc As String, userid As String, active As String) As String
        Try
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim retStatus As String = False
            Dim ret As Boolean = False
            Dim dt As DataTable
            Dim clsTbPermissionLinqDB As New TbPermissionLinqDB
            With clsTbPermissionLinqDB
                dt = .GetDataList("permission_name='" & group_name.Trim & "' and id <>" & id, "", trans.Trans)
                If dt.Rows.Count > 0 Then
                    retStatus = Utility.DefaultStringStatusReturn.duplicate
                    Return retStatus
                End If
            End With

            clsTbPermissionLinqDB = New TbPermissionLinqDB
            With clsTbPermissionLinqDB
                .GetDataByPK(id, trans.Trans)
                If .HaveData = True Then
                    .PERMISSION_NAME = group_name
                    .PERMISSION_DESC = group_desc
                    .ACTIVE_STATUS = IIf(active = 0, "N", "Y")
                    ret = .UpdateByPK(userid, trans.Trans)
                Else
                    .PERMISSION_NAME = group_name
                    .PERMISSION_DESC = group_desc
                    .ACTIVE_STATUS = IIf(active = 0, "N", "Y")
                    ret = .InsertData(userid, trans.Trans)
                End If
            End With
            clsTbPermissionLinqDB = Nothing
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function SaveGroupUser(id As String, groupid As String, userid As String) As String
        Try
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim retStatus As String = False
            Dim ret As Boolean = False
            Dim dt As DataTable
            Dim clsTbPermissionOfficerLinqDB As New TbPermissionOfficerLinqDB
            With clsTbPermissionOfficerLinqDB
                dt = .GetDataList("permission_id=" & groupid & " and officer_id =" & id, "", trans.Trans)
                'dt = .GetDataList("officer_id =" & id, "", trans.Trans)
                If dt.Rows.Count > 0 Then
                    retStatus = Utility.DefaultStringStatusReturn.duplicate
                    Return retStatus
                End If
            End With

            clsTbPermissionOfficerLinqDB = New TbPermissionOfficerLinqDB

            With clsTbPermissionOfficerLinqDB
                .OFFICER_ID = id
                .PERMISSION_ID = groupid
                ret = .InsertData(userid, trans.Trans)
            End With
            clsTbPermissionOfficerLinqDB = Nothing
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function DeleteGroup(id As String) As Boolean
        Try
            'Dim trans As New TransactionDB
            Dim ret As Boolean = False
            'Dim clsMsAuthorizegroupLinqDB As New MsAuthorizegroupLinqDB
            'With clsMsAuthorizegroupLinqDB
            '    ret = .DeleteByPK(id, trans.Trans)
            'End With
            'clsMsAuthorizegroupLinqDB = Nothing
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM TB_PERMISSION_OFFICER WHERE PERMISSION_ID=" & id & ";DELETE FROM TB_PERMISSION_MENU WHERE PERMISSION_ID=" & id & ";DELETE FROM TB_PERMISSION WHERE ID=" & id)
            'If ret = True Then
            '    trans.CommitTransaction()
            'Else
            '    trans.RollbackTransaction()
            'End If

            Return ret
        Catch ex As Exception
            Return False
        End Try

    End Function

    <WebMethod()> _
    Public Function DeleteGroupUser(id As String) As Boolean
        Try

            Dim ret As Boolean = False
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM TB_PERMISSION_OFFICER WHERE ID=" & id)

            Return ret
        Catch ex As Exception
            Return False
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadAuthorizeGroup(groupid As String) As String
        Try
            'Dim ret As String = ""
            'Dim trans As New TransactionDB
            'Dim clsMsAuthorizegroupLinqDB As New MsAuthorizegroupLinqDB
            'With clsMsAuthorizegroupLinqDB
            '    .GetDataByPK(groupid, trans.Trans)
            '    If .HaveData = True Then
            '        ret = .GROUP_NAME & "," & .GROUP_DESC & "," & .ACTIVE_STATUS
            '    End If
            'End With
            'clsMsAuthorizegroupLinqDB = Nothing
            'trans.CommitTransaction()
            'Return ret
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id, permission_name as group_name,permission_desc as group_desc,active_status FROM tb_permission where id=" & groupid)
            Return clsdtHelper.ConvertDataTableToJson(dt)
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function GetAuthorizeGroupMap(groupid As String) As String
        Try
            Dim dt As DataTable
            Dim ret As String = ""
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim clsTbPermissionMenuLinqDB As New TbPermissionMenuLinqDB
            With clsTbPermissionMenuLinqDB
                dt = .GetDataList("permission_id=" & groupid, "", trans.Trans)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If i = 0 Then
                            ret = dt.Rows(i)("menu_id")
                        Else
                            ret &= "," & dt.Rows(i)("menu_id")
                        End If
                    Next
                End If
            End With
            clsTbPermissionMenuLinqDB = Nothing
            trans.CommitTransaction()
            Return ret
        Catch ex As Exception
            Return ""
        End Try

    End Function

    <WebMethod()> _
    Public Function CheckAuthorizeGroupScreenByUser(userid As String, screenid As String) As Boolean
        Try
            Dim dt As DataTable
            Dim ret As String = ""
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim strSQL As New StringBuilder
            strSQL.Append(" Select u.username")
            strSQL.Append(" ,au.officer_id")
            strSQL.Append(" ,am.menu_id from tb_officer u")
            strSQL.Append(" inner join tb_permission_officer au")
            strSQL.Append(" on u.id=au.officer_id")
            strSQL.Append(" inner join tb_permission_menu am")
            strSQL.Append(" on au.permission_id= am.permission_id")
            strSQL.Append(" where u.id = " & userid & " And am.menu_id = " & screenid)
            dt = DIPRFIDSqlDB.ExecuteTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadAuthorizeGroupMap(groupid As String) As String
        Try
            Dim dtMenu As DataTable
            Dim dvMainMenu, dvMinorMenu, dvSubMenu, dvSubSubMenu As DataView
            Dim strDefaultImageCssName As String = "icon-folder-close"
            Dim strID, strScreenName, strImageCssName, strGroupSelect As String
            Dim intRowID As Long

            Dim dt As DataTable
            Dim strSql As New StringBuilder
            'strSql.Append(" SELECT	Screen.Id,")
            strSql.Append(" select table1.* from ")
            strSql.Append(" (")
            strSql.Append(" select -1  id")
            strSql.Append(" ,    0 RowID_M_Module")
            strSql.Append(" ,    0 RowID_M_SubModule")
            strSql.Append(" ,    wm.web_module_name  ModuleName")
            strSql.Append(" ,    '' SubModuleName")
            strSql.Append(" ,    0 RowID_RootMenu")
            strSql.Append(" ,    0 RowID_ParentMenu")
            strSql.Append(" ,    0 RowID_SubParentMenu")
            strSql.Append(" ,    id Sequence")
            strSql.Append(" ,    wm.web_module_name  as ScreenName")
            strSql.Append(" ,    '' as ScreenID")
            strSql.Append(" ,    'Y' IsMenu")
            strSql.Append(" ,    '' as NavigateURL")
            strSql.Append(" ,    '' as Remark")
            strSql.Append(" ,    '' ImageURL")
            strSql.Append(" ,    1 as LevelCheck")
            strSql.Append(" ,    0 IsMap")
            strSql.Append(" from ms_web_module wm where id=1")
            strSql.Append(" union")
            strSql.Append(" Select Screen.ID")
            strSql.Append(" ,   Screen.ms_web_module_id RowID_M_Module")
            strSql.Append(" ,    Screen.ms_submodule_id RowID_M_SubModule")
            strSql.Append(" ,    isnull(Module.web_module_name,'') ModuleName")
            strSql.Append(" ,    isnull(SubModule.submodule_name,'') SubModuleName")
            strSql.Append(" ,    -1 RowID_RootMenu")
            strSql.Append(" ,    isnull(Screen.RowID_RootMenu,0) RowID_ParentMenu")
            strSql.Append(" ,    isnull(Screen.RowID_ParentMenu,0) RowID_SubParentMenu")
            strSql.Append(" ,    isnull(Screen.Sequence,5)  Sequence")
            strSql.Append(" ,   Screen.menu_name as ScreenName")
            strSql.Append(" ,   Screen.menu_url as ScreenID")
            strSql.Append(" ,   isnull(Screen.IsMenu,0) IsMenu")
            strSql.Append(" ,   Screen.menu_url as NavigateURL,   Screen.menu_tooltip as Remark")
            strSql.Append(" ,   Screen.ImageURL")
            strSql.Append(" , (select COUNT(ID) from TB_MENU where (RowID_RootMenu=Screen.ID or RowID_ParentMenu=Screen.ID  or  RowID_SubParentMenu  =Screen.ID ) ) as LevelCheck ")
            strSql.Append(" ,   (case when isnull(menu.menu_id ,0) = 0 then 0 else 1 end )  IsMap  ")
            strSql.Append(" FROM TB_MENU Screen   left join MS_WEB_MODULE Module ")
            strSql.Append(" ON Module.ID = Screen.ms_web_module_id   left join MS_SubModule SubModule ")
            strSql.Append(" ON SubModule.ID = Screen.ms_submodule_id  left join tb_permission_menu menu   ")
            strSql.Append(" ON menu.menu_id = Screen.id  ")
            strSql.Append(" and  menu.permission_id =" & groupid)
            strSql.Append(" where Screen.isnotuse = 'N'  ")
            strSql.Append(" and isnull(Screen.module_id,0) <> 0 ")
            strSql.Append(" union")
            strSql.Append(" select -2  id")
            strSql.Append(" ,    0 RowID_M_Module")
            strSql.Append(" ,    0 RowID_M_SubModule")
            strSql.Append(" ,    wm.web_module_name  ModuleName")
            strSql.Append(" ,    '' SubModuleName")
            strSql.Append(" ,    0 RowID_RootMenu")
            strSql.Append(" ,    0 RowID_ParentMenu")
            strSql.Append(" ,    0 RowID_SubParentMenu")
            strSql.Append(" ,    id Sequence")
            strSql.Append(" ,    wm.web_module_name  as ScreenName")
            strSql.Append(" ,    '' as ScreenID")
            strSql.Append(" ,    'Y' IsMenu")
            strSql.Append(" ,    '' as NavigateURL")
            strSql.Append(" ,    '' as Remark")
            strSql.Append(" ,    '' ImageURL")
            strSql.Append(" ,    1 as LevelCheck")
            strSql.Append(" ,    0 IsMap")
            strSql.Append(" from ms_web_module wm where id=2")
            strSql.Append(" union")
            strSql.Append(" Select Screen.ID")
            strSql.Append(" ,   Screen.ms_web_module_id RowID_M_Module")
            strSql.Append(" ,    Screen.ms_submodule_id RowID_M_SubModule")
            strSql.Append(" ,    isnull(Module.web_module_name,'') ModuleName")
            strSql.Append(" ,    isnull(SubModule.submodule_name,'') SubModuleName")
            strSql.Append(" ,    -2 RowID_RootMenu")
            strSql.Append(" ,    isnull(Screen.RowID_RootMenu,0) RowID_ParentMenu")
            strSql.Append(" ,    isnull(Screen.RowID_ParentMenu,0) RowID_SubParentMenu")
            strSql.Append(" ,    isnull(Screen.Sequence,5)  Sequence")
            strSql.Append(" ,   Screen.menu_name as ScreenName")
            strSql.Append(" ,   Screen.menu_url as ScreenID")
            strSql.Append(" ,   isnull(Screen.IsMenu,0) IsMenu")
            strSql.Append(" ,   Screen.menu_url as NavigateURL,   Screen.menu_tooltip as Remark")
            strSql.Append(" ,   Screen.ImageURL")
            strSql.Append(" , (select COUNT(ID) from TB_MENU where (RowID_RootMenu=Screen.ID or RowID_ParentMenu=Screen.ID  or  RowID_SubParentMenu  =Screen.ID ) ) as LevelCheck ")
            strSql.Append(" ,   (case when isnull(menu.menu_id ,0) = 0 then 0 else 1 end )  IsMap  ")
            strSql.Append(" FROM TB_MENU Screen   left join MS_WEB_MODULE Module ")
            strSql.Append(" ON Module.ID = Screen.ms_web_module_id   left join MS_SubModule SubModule ")
            strSql.Append(" ON SubModule.ID = Screen.ms_submodule_id  left join tb_permission_menu menu   ")
            strSql.Append(" ON menu.menu_id = Screen.id  ")
            strSql.Append(" and  menu.permission_id =" & groupid)
            strSql.Append(" where Screen.isnotuse = 'N'  ")
            strSql.Append(" and isnull(Screen.module_id,0) = 0 and isnull(Screen.ms_web_module_id,0) = 2")
            strSql.Append(" union")
            strSql.Append(" select -3  id")
            strSql.Append(" ,    0 RowID_M_Module")
            strSql.Append(" ,    0 RowID_M_SubModule")
            strSql.Append(" ,    wm.web_module_name  ModuleName")
            strSql.Append(" ,    '' SubModuleName")
            strSql.Append(" ,    0 RowID_RootMenu")
            strSql.Append(" ,    0 RowID_ParentMenu")
            strSql.Append(" ,    0 RowID_SubParentMenu")
            strSql.Append(" ,    id Sequence")
            strSql.Append(" ,    wm.web_module_name  as ScreenName")
            strSql.Append(" ,    '' as ScreenID")
            strSql.Append(" ,    'Y' IsMenu")
            strSql.Append(" ,    '' as NavigateURL")
            strSql.Append(" ,    '' as Remark")
            strSql.Append(" ,    '' ImageURL")
            strSql.Append(" ,    1 as LevelCheck")
            strSql.Append(" ,    0 IsMap")
            strSql.Append(" from ms_web_module wm where id=3")
            strSql.Append(" union")
            strSql.Append(" Select Screen.ID")
            strSql.Append(" ,   Screen.ms_web_module_id RowID_M_Module")
            strSql.Append(" ,    Screen.ms_submodule_id RowID_M_SubModule")
            strSql.Append(" ,    isnull(Module.web_module_name,'') ModuleName")
            strSql.Append(" ,    isnull(SubModule.submodule_name,'') SubModuleName")
            strSql.Append(" ,    -3 RowID_RootMenu")
            strSql.Append(" ,    isnull(Screen.RowID_RootMenu,0) RowID_ParentMenu")
            strSql.Append(" ,    isnull(Screen.RowID_SubParentMenu,0) RowID_SubParentMenu")
            strSql.Append(" ,    isnull(Screen.Sequence,5)  Sequence")
            strSql.Append(" ,   Screen.menu_name as ScreenName")
            strSql.Append(" ,   Screen.menu_url as ScreenID")
            strSql.Append(" ,   isnull(Screen.IsMenu,0) IsMenu")
            strSql.Append(" ,   Screen.menu_url as NavigateURL,   Screen.menu_tooltip as Remark")
            strSql.Append(" ,   Screen.ImageURL")
            strSql.Append(" , (select COUNT(ID) from TB_MENU where (RowID_RootMenu=Screen.ID or RowID_ParentMenu=Screen.ID  or  RowID_SubParentMenu  =Screen.ID ) ) as LevelCheck ")
            strSql.Append(" ,   (case when isnull(menu.menu_id ,0) = 0 then 0 else 1 end )  IsMap  ")
            strSql.Append(" FROM TB_MENU Screen   left join MS_WEB_MODULE Module ")
            strSql.Append(" ON Module.ID = Screen.ms_web_module_id   left join MS_SubModule SubModule ")
            strSql.Append(" ON SubModule.ID = Screen.ms_submodule_id  left join tb_permission_menu menu   ")
            strSql.Append(" ON menu.menu_id = Screen.id  ")
            strSql.Append(" and  menu.permission_id =" & groupid)
            strSql.Append(" where Screen.isnotuse = 'N'  ")
            strSql.Append(" and isnull(Screen.module_id,0) = 0 and isnull(Screen.ms_web_module_id,0) = 3")
            strSql.Append(" union")
            strSql.Append(" select -4  id")
            strSql.Append(" ,    0 RowID_M_Module")
            strSql.Append(" ,    0 RowID_M_SubModule")
            strSql.Append(" ,    wm.web_module_name  ModuleName")
            strSql.Append(" ,    '' SubModuleName")
            strSql.Append(" ,    0 RowID_RootMenu")
            strSql.Append(" ,    0 RowID_ParentMenu")
            strSql.Append(" ,    0 RowID_SubParentMenu")
            strSql.Append(" ,    id Sequence")
            strSql.Append(" ,    wm.web_module_name  as ScreenName")
            strSql.Append(" ,    '' as ScreenID")
            strSql.Append(" ,    'Y' IsMenu")
            strSql.Append(" ,    '' as NavigateURL")
            strSql.Append(" ,    '' as Remark")
            strSql.Append(" ,    '' ImageURL")
            strSql.Append(" ,    1 as LevelCheck")
            strSql.Append(" ,    0 IsMap")
            strSql.Append(" from ms_web_module wm where id=4")
            strSql.Append(" union")
            strSql.Append(" Select Screen.ID")
            strSql.Append(" ,   Screen.ms_web_module_id RowID_M_Module")
            strSql.Append(" ,    Screen.ms_submodule_id RowID_M_SubModule")
            strSql.Append(" ,    isnull(Module.web_module_name,'') ModuleName")
            strSql.Append(" ,    isnull(SubModule.submodule_name,'') SubModuleName")
            strSql.Append(" ,    -4 RowID_RootMenu")
            strSql.Append(" ,    isnull(Screen.RowID_RootMenu,0) RowID_ParentMenu")
            strSql.Append(" ,    isnull(Screen.RowID_ParentMenu,0) RowID_SubParentMenu")
            strSql.Append(" ,    Screen.Sequence ")
            strSql.Append(" ,   Screen.menu_name as ScreenName")
            strSql.Append(" ,   Screen.menu_url as ScreenID")
            strSql.Append(" ,   isnull(Screen.IsMenu,0) IsMenu")
            strSql.Append(" ,   Screen.menu_url as NavigateURL,   Screen.menu_tooltip as Remark")
            strSql.Append(" ,   Screen.ImageURL")
            strSql.Append(" , (select COUNT(ID) from TB_MENU where (RowID_RootMenu=Screen.ID or RowID_ParentMenu=Screen.ID  or  RowID_SubParentMenu  =Screen.ID ) ) as LevelCheck ")
            strSql.Append(" ,   (case when isnull(menu.menu_id ,0) = 0 then 0 else 1 end )  IsMap  ")
            strSql.Append(" FROM TB_MENU Screen   left join MS_WEB_MODULE Module ")
            strSql.Append(" ON Module.ID = Screen.ms_web_module_id   left join MS_SubModule SubModule ")
            strSql.Append(" ON SubModule.ID = Screen.ms_submodule_id  left join tb_permission_menu menu   ")
            strSql.Append(" ON menu.menu_id = Screen.id  ")
            strSql.Append(" and  menu.permission_id =" & groupid)
            strSql.Append(" where Screen.isnotuse = 'N'  ")
            strSql.Append(" and isnull(Screen.module_id,0) = 0 and isnull(Screen.ms_web_module_id,0) = 4")

            strSql.Append(" ) as table1  ")
            strSql.Append(" order by table1.sequence  ")


            strSql.Append("  SELECT	Screen.ID, ")
            strSql.Append("  Screen.ms_web_module_id RowID_M_Module,  ")
            strSql.Append("  Screen.ms_submodule_id RowID_M_SubModule,  ")
            strSql.Append("  isnull(Module.web_module_name,'') ModuleName,  ")
            strSql.Append("  isnull(SubModule.submodule_name,'') SubModuleName,  ")
            strSql.Append("  isnull(Screen.RowID_RootMenu,0)RowID_RootMenu,  ")
            strSql.Append("  isnull(Screen.RowID_ParentMenu,0)RowID_ParentMenu,  ")
            strSql.Append("  isnull(Screen.RowID_SubParentMenu,0)RowID_SubParentMenu,  ")
            strSql.Append("   Screen.Sequence,  ")
            strSql.Append("   Screen.menu_name as ScreenName, ")
            strSql.Append("  Screen.menu_url as ScreenID, ")
            strSql.Append("  isnull(Screen.IsMenu,0) IsMenu, ")
            strSql.Append("  Screen.menu_url as NavigateURL, ")
            strSql.Append("  Screen.menu_tooltip as Remark, ")
            strSql.Append("  Screen.ImageURL, ")
            strSql.Append("  (select COUNT(ID) from TB_MENU where (RowID_RootMenu=Screen.ID or RowID_ParentMenu=Screen.ID  or  RowID_SubParentMenu  =Screen.ID ) ) as LevelCheck, ")
            strSql.Append(" (case when isnull(menu.menu_id ,0) = 0 then 0 else 1 end )  IsMap")
            strSql.Append("  FROM TB_MENU Screen ")
            strSql.Append("  left join MS_WEB_MODULE Module ")
            strSql.Append("  ON Module.ID = Screen.ms_web_module_id ")
            strSql.Append("  left join MS_SubModule SubModule ")
            strSql.Append("  ON SubModule.ID = Screen.ms_submodule_id")
            strSql.Append("  left join tb_permission_menu menu")
            strSql.Append("  ON menu.menu_id = Screen.id  and  menu.permission_id =" & groupid)
            strSql.Append("  where Screen.isnotuse = 'N' ")
            strSql.Append("  and isnull(Screen.ms_web_module_id,0) = 2 ")
            strSql.Append("   order by Screen.sequence  ")

            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)

            Dim strComma As String = ","

            Dim strMenu As New StringBuilder
            dtMenu = dt.Copy
            dvMainMenu = dtMenu.Copy.DefaultView
            dvMainMenu.RowFilter = "RowId_RootMenu = 0"
            dvMainMenu.Sort = "Sequence"
            strMenu.Append("[")

            For i As Integer = 0 To dvMainMenu.Count - 1
                Select Case dvMainMenu(i)("LevelCheck") & ""
                    Case 0 'กรณีมี Root เดียว
                        'Level 1
                        strScreenName = dvMainMenu(i)("ScreenName") & ""
                        strID = dvMainMenu(i)("Id")
                        strImageCssName = "<i class='" & dvMainMenu(i)("ImageURL") & "'> </i> "
                        strGroupSelect = IIf(dvMainMenu(i)("IsMap") = 1, "true", "false")
                        strMenu.Append(IIf(strMenu.Length > 0 And i > 0, strComma, "") & "{""title"": """ & strImageCssName & strScreenName & """, ""key"": """ & strID & """ ,""icon"":false,""select"":" & strGroupSelect & "}")

                    Case Else 'กรณีมีหลาย Root 
                        'Level 1
                        strScreenName = dvMainMenu(i)("ScreenName") & ""
                        strID = dvMainMenu(i)("Id") ' IIf(dvMainMenu(i)("RowID_RootMenu") = 0, 0, dvMainMenu(i)("Id"))
                        strImageCssName = "<i class='" & dvMainMenu(i)("ImageURL") & "'> </i> "
                        strGroupSelect = IIf(dvMainMenu(i)("IsMap") = 1, "true", "false")



                        strMenu.Append(IIf(i > 0, strComma, "") & "{""title"": """ & strImageCssName & strScreenName & """, ""key"": """ & strID & """, ""expand"": true,""icon"":false,""select"":" & strGroupSelect & "")
                        'Level 2
                        dvMinorMenu = dtMenu.Copy.DefaultView
                        dvMinorMenu.RowFilter = "RowId_ParentMenu = 0  AND RowId_RootMenu = " & dvMainMenu(i)("Id")
                        dvMinorMenu.Sort = "Sequence"
                        If dvMinorMenu.Count > 0 Then
                            strMenu.Append(strComma & """children"": [")
                            For j As Integer = 0 To dvMinorMenu.Count - 1 'Level 2
                                intRowID = dvMinorMenu(j)("id")
                                strScreenName = dvMinorMenu(j)("ScreenName") & ""
                                strID = dvMinorMenu(j)("Id") 'IIf(dvMinorMenu(j)("RowID_RootMenu") = 0, 0, dvMinorMenu(j)("Id"))
                                strImageCssName = "<i class='" & dvMinorMenu(j)("ImageURL") & "'> </i> "  'dvMinorMenu(j)("ImageURL") & ""
                                strGroupSelect = IIf(dvMinorMenu(j)("IsMap") = 1, "true", "false")

                                dvSubMenu = dtMenu.Copy.DefaultView
                                dvSubMenu.RowFilter = "RowId_SubParentMenu=0 AND RowId_RootMenu = " & dvMinorMenu(j)("RowId_RootMenu") & " AND RowId_ParentMenu = " & intRowID
                                dvSubMenu.Sort = "Sequence"

                                strMenu.Append(IIf(j > 0, strComma, "") & "{""title"": """ & strImageCssName & strScreenName & """, ""key"": """ & strID & """ ,""expand"": true,""icon"":false,""select"":" & strGroupSelect & "")
                                If dvSubMenu.Count > 0 Then


                                    strMenu.Append(strComma & """children"": [")

                                    For k As Integer = 0 To dvSubMenu.Count - 1   ' Level 3

                                        intRowID = dvSubMenu(k)("Id")
                                        strScreenName = dvSubMenu(k)("ScreenName") & ""
                                        strID = dvSubMenu(k)("Id") 'IIf(dvSubMenu(k)("RowID_RootMenu") = 0, 0, dvSubMenu(k)("Id"))
                                        strImageCssName = "<i class='" & dvSubMenu(k)("ImageURL") & "'> </i> "
                                        strGroupSelect = IIf(dvSubMenu(k)("IsMap") = 1, "true", "false")

                                        dvSubSubMenu = dtMenu.Copy.DefaultView
                                        dvSubSubMenu.RowFilter = "RowId_RootMenu = " & dvSubMenu(k)("RowId_RootMenu") & " AND RowId_ParentMenu=" & dvSubMenu(k)("RowId_ParentMenu") & "  AND RowId_SubParentMenu = " & intRowID
                                        dvSubSubMenu.Sort = "Sequence"
                                        strMenu.Append(IIf(k > 0, strComma, "") & "{""title"": """ & strImageCssName & strScreenName & """, ""key"": """ & strID & """ ,""expand"": true,""icon"":false,""select"":" & strGroupSelect & "")

                                        If dvSubSubMenu.Count > 0 Then
                                            strMenu.Append(strComma & """children"": [")
                                            For L As Integer = 0 To dvSubSubMenu.Count - 1 ' Level 4
                                                strScreenName = dvSubSubMenu(L)("ScreenName") & ""
                                                strID = dvSubSubMenu(L)("Id") ' IIf(dvSubSubMenu(L)("RowID_RootMenu") = 0, 0, dvSubSubMenu(L)("Id"))
                                                strImageCssName = "<i class='" & dvMinorMenu(j)("ImageURL") & "'> </i> "
                                                strGroupSelect = IIf(dvSubSubMenu(L)("IsMap") = 1, "true", "false")

                                                strMenu.Append(IIf(L = 0, "", ",") & "{""title"": """ & strImageCssName & strScreenName & """, ""key"": """ & strID & """,""icon"":false,""select"":" & strGroupSelect & "}")

                                            Next
                                            strMenu.Append("]")
                                            strMenu.Append("}")
                                        Else
                                            strMenu.Append("}")
                                        End If

                                    Next
                                    strMenu.Append("]")
                                    strMenu.Append("}")

                                Else
                                    strMenu.Append("}")

                                End If


                            Next
                            strMenu.Append("]")
                        Else
                            strMenu.Append("}")
                        End If
                        strMenu.Append("}")
                End Select
            Next
            strMenu.Append("]")




            Dim strdata As String = strMenu.ToString
            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadUserByDepartment(name As String, department_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            ''strSql.Append(" select table2.* from (")
            ''strSql.Append(" select  ")
            ''strSql.Append(" distinct table1.id, fb.borrowername + '(No:'  + convert(varchar,table1.officer_no) + ')' as label  ")
            ''strSql.Append(" ,fb.borrowername as fullname  ")
            ''strSql.Append(" ,table1.department_id ")
            ''strSql.Append(" from tb_fileborrow fb ")
            ''strSql.Append(" inner join ( ")
            ''strSql.Append("         select distinct o.id, t.title_name + o.fname + ' ' + lname as fullname,o.department_id,d.department_name,o.officer_no   from tb_officer o ")
            ''strSql.Append("         inner join tb_title t ")
            ''strSql.Append("         on o.title_id = t.id ")
            ''strSql.Append("         inner join tb_department d ")
            ''strSql.Append("         on o.department_id = d.id ")
            ''strSql.Append(" )  as table1 on table1.fullname = fb.borrowername  ")
            ''strSql.Append(" where table1.department_id Is Not null and table1.id not in (select officer_id from tb_permission_officer )")
            ''strSql.Append(" and  fb.borrowername like '%" & name & "%'")
            ''If department_id <> "" Then
            ''    strSql.Append(" and  table1.department_id=" & department_id)
            ''End If
            ''strSql.Append("  ) as table2")
            ''strSql.Append(" order by table2.label ")

            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY u.id asc) AS no")
            strSql.Append(" ,u.id")
            strSql.Append(" ,title_name + ' ' + fname + ' ' + lname as label")
            strSql.Append(" ,username")
            strSql.Append(" ,fname")
            strSql.Append(" ,lname")
            strSql.Append(" ,title_id")
            strSql.Append(" ,title_name + ' ' + fname + ' ' + lname as fullname")
            strSql.Append(" ,department_id")
            strSql.Append(" ,department_name")
            strSql.Append(" ,position_id")
            strSql.Append(" ,position_name")
            strSql.Append(" from  (select MAX(officer_no) as of_no ,ltrim(isnull(title_name,'') + isnull(fname,'') + ' ' + isnull(lname,'')) as fullname")
            strSql.Append(" from TB_OFFICER x  ")
            strSql.Append(" left join TB_TITLE y on x.title_id = y.id  ")
            strSql.Append(" group by title_name,fname,lname ) tb1")
            strSql.Append(" left join TB_OFFICER u on  tb1.of_no = u.officer_no")
            strSql.Append(" inner join TB_TITLE t on u.title_id = t.id")
            strSql.Append(" inner join TB_Department d on u.department_id = d.id")
            strSql.Append(" inner join TB_Position p on u.position_id = p.id")
            strSql.Append(" where title_name  like '%" & name & "%' or fname like '%" & name & "%' or lname like '%" & name & "%' ")
            If department_id <> "" Then
                strSql.Append(" and  d.id=" & department_id)
            End If
            strSql.Append(" order by fname,lname ")
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
    Public Function LoadUserDeaprtByName(name As String, department_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.AppendLine(" select  ")
            strSql.AppendLine(" o.id  ")
            strSql.AppendLine(" ,ltrim(isnull(y.title_name,'') + isnull(o.fname,'') + ' ' + isnull(o.lname,'')) + ")
            strSql.AppendLine("  case when ltrim(rtrim(isnull(o.username,'')))<>'' then ' (' + o.username + ')' else '' end as fullname ")
            strSql.AppendLine(" ,ltrim(isnull(y.title_name,'') + isnull(o.fname,'') + ' ' + isnull(o.lname,'')) + ")
            strSql.AppendLine("  case when ltrim(rtrim(isnull(o.username,'')))<>'' then ' (' + o.username + ')' else '' end as label ")
            strSql.AppendLine(" ,o.officer_no  ")
            strSql.AppendLine(" ,p.position_name  ")
            strSql.AppendLine(" ,o.department_id ")
            strSql.AppendLine(" ,dp.department_name ")
            strSql.AppendLine(" from TB_OFFICER as o ")
            strSql.AppendLine(" left join TB_TITLE y on o.title_id = y.id  ")
            strSql.AppendLine(" left join TB_DEPARTMENT dp on o.department_id = dp.id   ")
            strSql.AppendLine(" left join TB_POSITION p on o.position_id = p.id  ")
            ' strSql.AppendLine(" where table1.officer_id Is null ")

            strSql.AppendLine(" where  ltrim(isnull(y.title_name,'') + isnull(o.fname,'') + ' ' + isnull(o.lname,'')) + ")
            strSql.AppendLine(" case when ltrim(rtrim(isnull(o.username,'')))<>'' then ' (' + o.username + ')' else '' end like '%" & name & "%'")
            If department_id <> "" Then
                strSql.AppendLine(" and  o.department_id =" & department_id)
            End If
            strSql.AppendLine(" order by fullname  ")
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

#Region "Mapping Grid Desktop"
    <WebMethod()> _
    Public Function LoadMapGridDesktopAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY f.floor_name,r.room_name) AS no")
            strSql.Append(" ,r.id ")
            strSql.Append(" ,f.floor_name")
            strSql.Append(" ,r.room_name")
            strSql.Append(" ,fp.floor_plan_name")
            strSql.Append(" ,(case f.active_status when 'Y' then 'Active' else 'No Active' end) as active_status  ")
            'strSql.Append(" ,fp.image_floor_plan")
            'strSql.Append(" ,fp.image_file_ext")
            'strSql.Append(" ,'' image_floor_plan_show")
            strSql.Append(" ,isnull(fp.id,0) as image_floor_plan_id")
            strSql.Append(" ,isnull(r.ms_floor_plan_id_current,0) as isshow")
            strSql.Append(" from ms_room r")
            strSql.Append(" inner join ms_floor f")
            strSql.Append(" on r.ms_floor_id = f.id")
            strSql.Append(" left join ms_floor_plan fp")
            strSql.Append(" on fp.id = r.ms_floor_plan_id_current")
            strSql.Append(" where r.active_status='Y'")
            strSql.Append(" order by f.floor_name,r.room_name")
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then

                'For i As Integer = 0 To dt.Rows.Count - 1
                '    Dim strimagebasesrc As String = ""
                '    If dt.Rows(i)("image_file_ext") & "" <> "" Then
                '        strimagebasesrc = "data:image/" & dt.Rows(i)("image_file_ext") & ";base64," & Convert.ToBase64String(dt.Rows(i)("image_floor_plan"))
                '    End If
                '    dt.Rows(i)("image_floor_plan_show") = strimagebasesrc
                'Next

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
    Public Function GetImageFloorPlan(id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select image_floor_plan,image_file_ext from ms_floor_plan where id=" & id)
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                Dim strimagebasesrc As String = ""
                If dt.Rows(0)("image_file_ext") & "" <> "" Then
                    strimagebasesrc = "data:image/" & dt.Rows(0)("image_file_ext") & ";base64," & Convert.ToBase64String(dt.Rows(0)("image_floor_plan"))
                End If

                strdata = strimagebasesrc
            Else
                strdata = ""
            End If
            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadFloorPlanByFloorAndRoom(ms_floor_id As String, ms_room_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select  ")
            strSql.Append(" id ")
            strSql.Append(" ,floor_plan_name as floorplanname ")
            strSql.Append(" from ms_floor_plan ")
            strSql.Append(" where ms_floor_id =" & ms_floor_id)
            strSql.Append(" and ms_room_id=" & ms_room_id)
            strSql.Append(" and active_status='Y' ")
            strSql.Append(" order by floor_plan_name")

            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Return strdata
            'If dt.Rows.Count > 0 Then
            '    strdata = clsdtHelper.ConvertDataTableToJson(dt)
            'Else
            '    strdata = "[]"
            'End If
            'Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadGridLayoutActive() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" id")
            strSql.Append(" ,layout_name")
            strSql.Append(" ,vertical_line")
            strSql.Append(" ,horizontal_line")
            strSql.Append(" from ms_grid_layout")
            strSql.Append(" where active_status='Y' ")
            strSql.Append(" order by layout_name")

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
    Public Function GetRoomDetailById(id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select  ")
            strSql.Append(" r.id ")
            strSql.Append(" ,r.room_name ")
            strSql.Append(" ,f.floor_name ")
            strSql.Append(" ,f.id as ms_floor_id")
            strSql.Append(" ,isnull(r.ms_floor_plan_id_current,0) ms_floor_plan_id_current ")
            strSql.Append(" ,isnull(r.ms_grid_layout_id_current,0) ms_grid_layout_id_current ")
            strSql.Append(" from ms_room r ")
            strSql.Append(" inner join ms_floor f ")
            strSql.Append(" on r.ms_floor_id = f.id ")
            strSql.Append(" where r.id=" & id)

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
    Public Function SaveCurrentInRoom(id As String, floorcurrentId As String, gridcurrentId As String, userid As String) As Boolean
        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim ret As Boolean = False
        Try
            Dim clsMsRoomLinqDB As New MsRoomLinqDB
            With clsMsRoomLinqDB
                .GetDataByPK(id, trans.Trans)
                .MS_FLOOR_PLAN_ID_CURRENT = floorcurrentId
                .MS_GRID_LAYOUT_ID_CURRENT = gridcurrentId
                If clsMsRoomLinqDB.ID <> 0 Then
                    ret = .UpdateByPK(userid, trans.Trans)
                End If
            End With
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            Return ret
        Catch ex As Exception
            Return ret
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadOfficerRoomByRoomId(roomid As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String

            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY o.fname) AS no ")
            strSql.Append(" ,dt.id ")
            strSql.Append(" ,t.title_name + o.fname + ' ' + o.lname as fullname ")
            strSql.Append(" ,dt.desk_name ")
            strSql.Append(" ,isnull((select ms_grid_layout_id_current from ms_room where id=dt.ms_room_id ),0) as ms_grid_layout_id_current")
            strSql.Append(" ,dt.ms_room_id")
            strSql.Append(" from ms_desktop dt ")
            strSql.Append(" inner join tb_officer o ")
            strSql.Append(" on dt.tb_officer_id = o.id ")
            strSql.Append(" inner join TB_TITLE t ")
            strSql.Append(" on t.id=o.title_id ")
            strSql.Append(" where dt.active_status='Y' ")
            strSql.Append(" and dt.ms_room_id =" & roomid)
            strSql.Append(" order by o.fname  ")

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
    Public Function LoadFloorPlanByRoomId(roomid As String, gridlayoutcurrentid As String, desktopid As String) As String
        Try
            'app_no = "0001000002"
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dtdetail As DataTable
            Dim strSQlDetail As New StringBuilder
            strSQlDetail.Append(" select ")
            strSQlDetail.Append(" fp.image_floor_plan")
            strSQlDetail.Append(" ,fp.image_file_ext ")
            strSQlDetail.Append(" ,(select top 1 gl.horizontal_line from ms_grid_layout gl where gl.id =" & gridlayoutcurrentid & ") as horizontal_line")
            strSQlDetail.Append(" ,(select top 1 gl.vertical_line from ms_grid_layout gl where gl.id =" & gridlayoutcurrentid & ") as vertical_line")
            strSQlDetail.Append(" ,(select top 1 dg.grid_col from ms_desktop_grid dg where dg.ms_grid_layout_id=" & gridlayoutcurrentid & " and dg.ms_desktop_id=" & desktopid & ") as grid_col")
            strSQlDetail.Append(" ,(select top 1 dg.grid_row from ms_desktop_grid dg where dg.ms_grid_layout_id=" & gridlayoutcurrentid & " and dg.ms_desktop_id=" & desktopid & ") as grid_row")
            strSQlDetail.Append(" from ms_floor_plan fp ")
            strSQlDetail.Append(" where fp.ms_room_id = " & roomid)
            dtdetail = DIPRFIDSqlDB.ExecuteTable(strSQlDetail.ToString)
            If dtdetail.Rows.Count <> 0 Then

                Dim strimagebase64 As String = ""
                Dim strimagebasesrc As String = ""
                If dtdetail.Rows(0)("image_file_ext") & "" <> "" Then
                    strimagebasesrc = "data:image/" & dtdetail.Rows(0)("image_file_ext") & ";base64," & Convert.ToBase64String(dtdetail.Rows(0)("image_floor_plan"))
                End If

                Dim indexstrart As Integer = 1
                Dim gridfound_index As Integer
                Dim gridfound_col As Integer = Val(dtdetail.Rows(0)("grid_col") & "")
                Dim gridfound_row As Integer = Val(dtdetail.Rows(0)("grid_row") & "")
                Dim countRows As Integer = Val(dtdetail.Rows(0)("horizontal_line") & "")
                Dim countColums As Integer = Val(dtdetail.Rows(0)("vertical_line") & "")
                Dim tmpstyle As String = "style='cursor:pointer;background-color:rgba(255,255,0,0);'"
                Dim strSQl As New StringBuilder
                strSQl.Append("<table border=""1"" style="" background: url('" & strimagebasesrc & "');background-size: 100% auto;background-repeat: no-repeat;align-content: center; border: 1px solid #484;width:640px;height:460px"" >")
                For i As Integer = 1 To countRows
                    strSQl.Append("<tr>")
                    For j As Integer = 1 To countColums
                        'If indexstrart = gridfound Then
                        '    tmpstyle = addstyle
                        'Else
                        '    tmpstyle = ""
                        'End If
                        'If gridfound_col = j And gridfound_row = i Then
                        '    gridfound_index = indexstrart
                        'End If


                        strSQl.Append("<td " & tmpstyle & " id=" & indexstrart & " " & " onmouseover='onOver(" + indexstrart.ToString + ");' onmouseout=onOut('" + indexstrart.ToString + "'); onclick='onMark(" + indexstrart.ToString + "," + i.ToString + "," + j.ToString + "," + countRows.ToString + "," + countColums.ToString + ")';>")
                        strSQl.Append("</td>")
                        indexstrart = indexstrart + 1
                    Next
                    strSQl.Append("</tr>")
                Next
                strSQl.Append("</table>")

                Dim dt As New DataTable
                Dim dr As DataRow
                dt.Columns.Add("showdata")
                dr = dt.NewRow
                dr("showdata") = strSQl.ToString
                dt.Rows.Add(dr)

                Dim strdata As String
                strdata = clsdtHelper.ConvertDataTableToJson(dt)

                Return strdata
            Else
                Return "[]"
            End If


        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    <WebMethod()> _
    Public Function LoadOfficerMapLayoutByLayoutId(gridlayoutid As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY dg.id) AS no ")
            strSql.Append(" ,ms_grid_layout_id")
            strSql.Append(" ,gl.layout_name ")
            strSql.Append(" ,convert(varchar,dg.grid_row) + ',' + convert(varchar,dg.grid_col) as cell ")
            strSql.Append(" ,dt.desk_name ")
            strSql.Append(" ,isnull(t.title_name,'') + o.fname + ' ' + o.lname as fullname ")
            strSql.Append(" , gl.horizontal_line  maxrow")
            strSql.Append(" , gl.vertical_line maxcol")
            strSql.Append(" , dg.grid_col col")
            strSql.Append(" , dg.grid_row row")
            strSql.Append(" , ((dg.grid_row -1)  * gl.vertical_line) + dg.grid_col  as point")
            strSql.Append(" , dg.ms_desktop_id ")
            strSql.Append(" from ms_desktop_grid dg ")
            strSql.Append(" inner join ms_grid_layout gl ")
            strSql.Append(" on dg.ms_grid_layout_id = gl.id ")
            strSql.Append(" inner join MS_DESKTOP dt ")
            strSql.Append(" on dt.id = dg.ms_desktop_id ")
            strSql.Append(" inner join tb_officer o ")
            strSql.Append(" on o.id = dt.tb_officer_id ")
            strSql.Append(" left join tb_title t ")
            strSql.Append(" on  t.id = o.title_id ")
            strSql.Append(" where dg.ms_desktop_id=" & gridlayoutid)
            strSql.Append(" order by dg.id ")

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
    Public Function SaveMapGrid(desktopid As String, strdataall_dt As String) As Boolean

        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim ret As Boolean = False
        Try

            ret = DIPRFIDSqlDB.ExecuteNonQuery("delete from ms_desktop_grid where ms_desktop_id =" & desktopid, trans.Trans)

            Dim clsMsDesktopGridLinqDB As New MsDesktopGridLinqDB
            Dim tmpdt As String() = strdataall_dt.Split("#")
            Dim tmpdt_sub As String()
            For i As Integer = 0 To tmpdt.Length - 1
                tmpdt_sub = tmpdt(i).Split(",")
                clsMsDesktopGridLinqDB = New MsDesktopGridLinqDB
                With clsMsDesktopGridLinqDB
                    '.GetDataByPK(id, trans.Trans)
                    .MS_DESKTOP_ID = tmpdt_sub(0)
                    .MS_GRID_LAYOUT_ID = tmpdt_sub(1)
                    .GRID_COL = tmpdt_sub(2)
                    .GRID_ROW = tmpdt_sub(3)
                    ret = .InsertData(tmpdt_sub(4), trans.Trans)
                End With
                clsMsDesktopGridLinqDB = Nothing
            Next

            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret

        Catch ex As Exception
            trans.RollbackTransaction()
            Return False
        End Try

    End Function
#End Region

#Region "Antenna Reading Area"
    <WebMethod()> _
    Public Function LoadSpeedWayReadAreaAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY s.readerid) AS no ")
            strSql.Append(" ,s.id ")
            strSql.Append(" ,s.readerid ")
            strSql.Append(" ,s.serial_no ")
            strSql.Append(" ,s.ip_address ")
            strSql.Append(" ,s.install_position ")
            strSql.Append(" ,s.ms_room_id ")
            strSql.Append(" ,r.ms_floor_id ")
            strSql.Append(" ,r.room_name ")
            strSql.Append(" ,f.floor_name ")
            strSql.Append(" ,s.ant_qty ")
            strSql.Append(" ,r.ms_grid_layout_id_current ")
            strSql.Append(" from ms_speedway s ")
            strSql.Append(" inner join ms_room r ")
            strSql.Append(" on s.ms_room_id = r.id ")
            strSql.Append(" inner join ms_floor f ")
            strSql.Append(" on r.ms_floor_id = f.id ")
            strSql.Append(" order by s.readerid ")
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
    Public Function LoadSpeedWayByRoomId(roomid As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY s.readerid) AS no ")
            strSql.Append(" ,s.id")
            strSql.Append(" ,s.readerid")
            strSql.Append(" ,s.serial_no")
            strSql.Append(" ,s.ip_address")
            strSql.Append(" ,s.install_position")
            strSql.Append(" ,r.ms_floor_id")
            strSql.Append(" ,s.ms_room_id")
            strSql.Append(" ,r.room_name")
            strSql.Append(" ,f.floor_name")
            strSql.Append(" ,s.ant_qty")
            strSql.Append(" ,r.ms_grid_layout_id_current")
            strSql.Append(" ,isnull((select top 1 id from ms_speedway_ant sn where sn.ms_speedway_id=s.id),0) as ms_speedway_ant_id")
            strSql.Append(" from ms_speedway s")
            strSql.Append(" inner join ms_room r")
            strSql.Append(" on s.ms_room_id = r.id")
            strSql.Append(" inner join ms_floor f")
            strSql.Append(" on r.ms_floor_id = f.id")
            strSql.Append(" where s.ms_room_id=" & roomid & " and s.ms_speedway_objective_id=2")
            strSql.Append(" order by s.readerid")

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
    Public Function LoadAntennaBySpeedway(speedwayid As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" sa.id")
            strSql.Append(" ,sa.port_number ")
            strSql.Append(" from ms_speedway_ant sa")
            strSql.Append(" where ms_speedway_id = " & speedwayid)
            strSql.Append(" order by sa.port_number ")
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
    Public Function LoadAttenaMapLayoutByPort(ms_speedway_id As String) As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select  ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY sg.id) AS no  ")
            strSql.Append(" ,sg.id  ")
            strSql.Append(" ,gl.layout_name  ")
            strSql.Append(" ,convert(varchar,sg.grid_row) + ',' + convert(varchar,sg.grid_col) as cell  ")
            strSql.Append(" ,sn.port_number ")
            strSql.Append(" , gl.horizontal_line  maxrow ")
            strSql.Append(" , gl.vertical_line maxcol ")
            strSql.Append(" , sg.grid_col col ")
            strSql.Append(" , sg.grid_row row ")
            strSql.Append(" , ((sg.grid_row -1)  * gl.vertical_line) + sg.grid_col  as point ")
            strSql.Append(" ,sg.ms_speedway_ant_id")
            strSql.Append(" ,sg.ms_grid_layout_id")
            strSql.Append(" from ms_speedway_ant_grid sg  ")
            strSql.Append(" inner join ms_grid_layout gl  ")
            strSql.Append(" on sg.ms_grid_layout_id = gl.id  ")
            strSql.Append(" inner join  ms_speedway_ant sn ")
            strSql.Append(" on sn.id = sg.ms_speedway_ant_id ")
            strSql.Append(" where sn.ms_speedway_id =" & ms_speedway_id)
            strSql.Append(" order by sg.id  ")

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
    Public Function LoadAntennaPlanByRoomId(roomid As String, gridlayoutcurrentid As String, speedwayantid As String) As String
        Try
            'app_no = "0001000002"
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dtdetail As DataTable
            Dim strSQlDetail As New StringBuilder
            strSQlDetail.Append(" select ")
            strSQlDetail.Append(" fp.image_floor_plan")
            strSQlDetail.Append(" ,fp.image_file_ext ")
            strSQlDetail.Append(" ,(select top 1 gl.horizontal_line from ms_grid_layout gl where gl.id =" & gridlayoutcurrentid & ") as horizontal_line")
            strSQlDetail.Append(" ,(select top 1 gl.vertical_line from ms_grid_layout gl where gl.id =" & gridlayoutcurrentid & ") as vertical_line")
            strSQlDetail.Append(" ,(select top 1 dg.grid_col from ms_speedway_ant_grid dg where dg.ms_grid_layout_id=" & gridlayoutcurrentid & " and dg.ms_speedway_ant_id=" & speedwayantid & ") as grid_col")
            strSQlDetail.Append(" ,(select top 1 dg.grid_row from ms_speedway_ant_grid dg where dg.ms_grid_layout_id=" & gridlayoutcurrentid & " and dg.ms_speedway_ant_id=" & speedwayantid & ") as grid_row")
            strSQlDetail.Append(" from ms_floor_plan fp ")
            strSQlDetail.Append(" where fp.ms_room_id = " & roomid)
            dtdetail = DIPRFIDSqlDB.ExecuteTable(strSQlDetail.ToString)
            If dtdetail.Rows.Count <> 0 Then

                Dim strimagebase64 As String = ""
                Dim strimagebasesrc As String = ""
                If dtdetail.Rows(0)("image_file_ext") & "" <> "" Then
                    strimagebasesrc = "data:image/" & dtdetail.Rows(0)("image_file_ext") & ";base64," & Convert.ToBase64String(dtdetail.Rows(0)("image_floor_plan"))
                End If

                Dim indexstrart As Integer = 1
                Dim gridfound_index As Integer
                Dim gridfound_col As Integer = Val(dtdetail.Rows(0)("grid_col") & "")
                Dim gridfound_row As Integer = Val(dtdetail.Rows(0)("grid_row") & "")
                Dim countRows As Integer = Val(dtdetail.Rows(0)("horizontal_line") & "")
                Dim countColums As Integer = Val(dtdetail.Rows(0)("vertical_line") & "")
                ' Dim addstyle As String = "style='cursor:pointer;background-color:rgba(255,255,0,0.5);'"
                Dim tmpstyle As String = "style='cursor:pointer;background-color:rgba(255,255,0,0);'"
                Dim strSQl As New StringBuilder
                strSQl.Append("<table border=""0"" style="" background: url('" & strimagebasesrc & "');background-size: 100% auto;background-repeat: no-repeat;align-content: center; width:850px;height:650px"" >")
                For i As Integer = 1 To countRows
                    strSQl.Append("<tr>")
                    For j As Integer = 1 To countColums
                        'If indexstrart = gridfound Then
                        '    tmpstyle = addstyle
                        'Else
                        '    tmpstyle = ""
                        'End If
                        'If gridfound_col = j And gridfound_row = i Then
                        '    gridfound_index = indexstrart
                        'End If
                        strSQl.Append("<td " & tmpstyle & " id=" & indexstrart & " " & " onmouseover='onOver(" + indexstrart.ToString + ");' onmouseout=onOut('" + indexstrart.ToString + "'); onclick='onMark(" + indexstrart.ToString + "," + i.ToString + "," + j.ToString + "," + countRows.ToString + "," + countColums.ToString + ");return false;'>")
                        strSQl.Append("</td>")
                        indexstrart = indexstrart + 1
                    Next
                    strSQl.Append("</tr>")
                Next
                strSQl.Append("</table>")

                Dim dt As New DataTable
                Dim dr As DataRow
                dt.Columns.Add("showdata")
                dr = dt.NewRow
                dr("showdata") = strSQl.ToString
                dt.Rows.Add(dr)

                Dim strdata As String
                strdata = clsdtHelper.ConvertDataTableToJson(dt)

                Return strdata
            Else
                Return "[]"
            End If


        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    <WebMethod()> _
    Public Function SaveMapAntenna(speedwayid As String, strdataall_dt As String) As Boolean

        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            ret = DIPRFIDSqlDB.ExecuteNonQuery("delete from ms_speedway_ant_grid where  ms_speedway_ant_id in ( select id from ms_speedway_ant where ms_speedway_id =" & speedwayid & ")", trans.Trans)

            Dim clsMsSpeedwayAntGridLinqDB As New MsSpeedwayAntGridLinqDB
            Dim tmpdt As String() = strdataall_dt.Split("#")
            Dim tmpdt_sub As String()
            For i As Integer = 0 To tmpdt.Length - 1
                tmpdt_sub = tmpdt(i).Split(",")
                clsMsSpeedwayAntGridLinqDB = New MsSpeedwayAntGridLinqDB
                With clsMsSpeedwayAntGridLinqDB
                    '.GetDataByPK(id, trans.Trans)
                    .MS_SPEEDWAY_ANT_ID = tmpdt_sub(0)
                    .MS_GRID_LAYOUT_ID = tmpdt_sub(1)
                    .GRID_COL = tmpdt_sub(2)
                    .GRID_ROW = tmpdt_sub(3)
                    ret = .InsertData(tmpdt_sub(4), trans.Trans)
                End With
                clsMsSpeedwayAntGridLinqDB = Nothing
            Next

            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret

        Catch ex As Exception
            trans.RollbackTransaction()
            Return False
        End Try

    End Function

    <WebMethod()> _
    Public Function DeleteMapAntenna(ms_speedway_ant_id As String, _
                                  ms_grid_layout_id As String) As String
        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try
            DIPRFIDSqlDB.ExecuteNonQuery("delete from ms_speedway_ant_grid where ms_speedway_ant_id ='" & ms_speedway_ant_id & "'  and ms_grid_layout_id='" & ms_grid_layout_id & "'", trans.Trans)
            trans.CommitTransaction()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "System Configuration"
    <WebMethod()> _
    Public Function LoadSysConfig() As String
        Dim ret As String = ""
        Try
            Dim lnq As New CfSysconfigLinqDB
            Dim dt As DataTable = lnq.GetDataList("1=1", "config_name", Nothing)
            If dt.Rows.Count > 0 Then
                ret = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                ret = "[]"
            End If
            dt.Dispose()
            lnq = Nothing
        Catch ex As Exception
            Return "[]"
        End Try
        Return ret
    End Function

    <WebMethod()> _
    Public Function SaveSysconfig(UserName As String, ConfigName As String, ConfigValue As String) As String
        Dim ret As String = ""
        Try
            ret = Engine.GlobalFunction.SaveSysconfig(UserName, ConfigName, ConfigValue)
        Catch ex As Exception
            ret = "false|Exception " & ex.Message & vbNewLine & ex.StackTrace
        End Try
        Return ret
    End Function

    <WebMethod()> _
    Public Function LoadBorrowNotificationData() As String
        Dim ret As String = "[]"
        Try
            Dim dt As DataTable = Engine.MailAlertENG.BuiltConfigData()
            If dt.Rows.Count > 0 Then
                Dim ptDT As DataTable = Engine.GlobalFunction.GetDatatable("select id, patent_type_name from tb_patent_type where active_status='Y'")

                dt.Columns.Add("no")
                dt.Columns.Add("patent_type_name")
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("no") = (i + 1)

                    ptDT.DefaultView.RowFilter = "id='" & dt.Rows(i)("patent_type_id") & "'"
                    If ptDT.DefaultView.Count > 0 Then
                        dt.Rows(i)("patent_type_name") = ptDT.DefaultView(0)("patent_type_name")
                    End If
                Next
                ptDT.Dispose()

                ret = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                ret = "[]"
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "[]"
        End Try
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetBorrowNotificationByPatentTypeId(patent_type_id As String) As String
        Dim ret As String = "[]"
        Try
            Dim dt As DataTable = Engine.MailAlertENG.BuiltConfigData()
            If dt.Rows.Count > 0 Then
                Dim ptDT As DataTable = Engine.GlobalFunction.GetDatatable("select id, patent_type_name from tb_patent_type where active_status='Y'")

                dt.Columns.Add("patent_type_name")
                For i As Integer = 0 To dt.Rows.Count - 1
                    ptDT.DefaultView.RowFilter = "id='" & dt.Rows(i)("patent_type_id") & "'"
                    If ptDT.DefaultView.Count > 0 Then
                        dt.Rows(i)("patent_type_name") = ptDT.DefaultView(0)("patent_type_name")
                    End If
                Next
                ptDT.Dispose()

                dt.DefaultView.RowFilter = "patent_type_id='" & patent_type_id & "'"
                dt = dt.DefaultView.ToTable()

                ret = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                ret = "[]"
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "[]"
        End Try
        Return ret
    End Function
#End Region

#Region "SinageContentTemplate"
    <WebMethod()> _
    Public Function LoadSinageContentTemplateAll() As String
        Try
            Dim dt As DataTable
            Dim strSql As New StringBuilder
            Dim strdata As String
            strSql.Append(" select ")
            strSql.Append(" ROW_NUMBER() OVER(ORDER BY id asc) AS no,[dbo].IsReferenctSinageContentTemplate(id) as IsDelete")
            strSql.Append(" ,id")
            strSql.Append(" ,(case when isnull(active_status ,'N') = 'N' then 'No Active' else 'Active' end )  active_status")
            strSql.Append(" ,template_name")
            strSql.Append(" ,template_url")
            strSql.Append(" from MS_SIGNAGE_CONTENT_TEMPLATE")
            strSql.Append(" order by template_name")

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
    Public Function GetSinageContentTemplateById(id As String) As String
        Try
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id,template_name,template_url,active_status from MS_SIGNAGE_CONTENT_TEMPLATE WHERE ID=" & id)
            If dt.Rows.Count <> 0 Then
                Return clsdtHelper.ConvertDataTableToJson(dt)
            Else
                Return "[]"
            End If
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function SaveSinageContentTemplate(id As String, template_name As String, template_url As String, active As String, login_username As String) As String


        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim retStatus As String = False
        Dim ret As Boolean = False
        Try

            Dim dt As New DataTable
            dt = DIPRFIDSqlDB.ExecuteTable("select id from MS_SIGNAGE_CONTENT_TEMPLATE where template_name ='" & template_name & "' and id <> '" & id & "'", trans.Trans)
            If dt.Rows.Count > 0 Then
                retStatus = Utility.DefaultStringStatusReturn.duplicate_sinagecontenttemplate
                Return retStatus
            End If


            Dim lnq As New MsSignageContentTemplateLinqDB
            With lnq
                .GetDataByPK(id, trans.Trans)
                .TEMPLATE_NAME = template_name
                .TEMPLATE_URL = template_url
                .ACTIVE_STATUS = IIf(active = 0, "N", "Y")

                If lnq.ID = -1 Then
                    ret = .InsertData(login_username, trans.Trans)
                Else
                    ret = .UpdateByPK(login_username, trans.Trans)
                End If
            End With


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            If ret = True Then
                retStatus = Utility.DefaultStringStatusReturn.complete
            Else
                retStatus = Utility.DefaultStringStatusReturn.fail
            End If

            Return retStatus
        Catch ex As Exception
            Return Utility.DefaultStringStatusReturn.fail
        End Try

    End Function

    <WebMethod()> _
    Public Function DeleteSinageContentTemplate(id As String) As Boolean
        Try
            Dim ret As Boolean = False
            ret = DIPRFIDSqlDB.ExecuteNonQuery("DELETE FROM MS_SIGNAGE_CONTENT_TEMPLATE WHERE ID=" & id)
            Return ret
        Catch ex As Exception
            Return False
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
            strSql.Append(" ,isnull((select top 1 convert(varchar,fb.send_time,103) as send_time from tb_fileborrow fb  ")
            strSql.Append(" inner join (")
            strSql.Append(" select distinct fileborrow_id from tb_fileborrowitem where id=tfi.fileborrowitem_id")
            strSql.Append(" ) as table1 on fb.id = table1.fileborrow_id),'') as receive_date")
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

    <WebMethod()> _
    Public Function LoadPortalNew() As String
        Try
            Dim strdata As String
            Dim strSql As New StringBuilder

            'รายการแฟ้มเกิดใหม่ที่จัดทำแฟ้มแล้ว(อายุ 5 วัน) และรอจัดเก็บเข้าชั้น 6
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY rq.receive_date desc) AS no,")
            strSql.Append(" rq.app_no, convert(varchar(10),isnull(rq.RECEIVE_DATE,rq.FRM_SUBMIT_DATE),103) receive_date,st.status_name")
            strSql.Append(" from TB_REQUISTION rq")
            strSql.Append(" inner join INV_REQUISTION prq on rq.app_no = prq.app_no and prq.formtype=1")
            strSql.Append(" left join (  ")
            strSql.Append(" 		select app_no,min(move_date) realdate  ")
            strSql.Append("         from TS_FILE_MOVE_HISTORY  ")
            strSql.Append("         where Len(app_no) = 10  ")
            strSql.Append(" 		and ms_room_id in (6,7,23)  ")
            strSql.Append(" 		group by app_no  ")
            strSql.Append(" 	) as fm on fm.app_no=rq.app_no")
            strSql.Append(" inner join TB_STATUS st on st.id=rq.app_status")
            strSql.Append(" where rq.formtype = 1")
            strSql.Append(" and st.status_name ='เบื้องต้น'")
            strSql.Append(" and rq.patent_type_id in (1,3)")
            strSql.Append(" and isnull(rq.RECEIVE_DATE,rq.FRM_SUBMIT_DATE)<DATEADD(day,-5,getdate())")
            strSql.Append(" and fm.app_no is null")
            strSql.Append(" order by rq.app_no")

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
    Public Function LoadPortal5year() As String
        Try
            Dim strdata As String
            Dim strSql As New StringBuilder

            '--แฟ้มสิทธิบัตรที่ประกาศแล้ว อายุเกิน 5 ปี และยังเก็บอยู่ที่ชั้น 6 จะต้องย้ายไปชั้น 1
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY rq.receive_date desc) AS no,")
            strSql.Append(" rq.app_no, convert(varchar(10),rq.receive_date,103) receive_date,")
            strSql.Append(" st.status_name")
            strSql.Append(" from tb_requistion rq")
            strSql.Append(" inner join TB_STATUS st on st.id=rq.app_status")
            strSql.Append(" left join TS_FILE_CURRENT_LOCATION fc on fc.app_no=rq.app_no")
            strSql.Append(" left join TB_FILELOCATION fl on fl.id=rq.filelocation")
            strSql.Append(" where rq.patent_type_id = 1")  '--เฉพาะสิทธิบัตร
            strSql.Append(" and rq.publicdate is not null ")      ' --ที่ประกาศแล้ว
            strSql.Append(" and datediff(year,rq.receive_date ,getdate()) > 5 ") ' --อายุเกิน 5 ปี
            strSql.Append(" and isnull(fc.ms_room_id,fl.ms_room_id)=6 ") '--แล้วยังเก็บอยู่ชั้น 6
            strSql.Append(" and st.status_name not in('ละทิ้ง','สิ้นอายุ') ")
            strSql.Append(" order by rq.app_no ")

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
    Public Function LoadPortalPublicBMove() As String
        Dim ret As String = ""
        Try
            Dim strSql As New StringBuilder

            '--แฟ้มที่ละทิ้งหรือสิ้นอายุ และยังเก็บอยู่ที่ชั้น 6 จะต้องย้ายไปเก็บที่ทรัพย์ศรีไทย
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY rq.receive_date desc) AS no,")
            strSql.Append(" rq.app_no, convert(varchar(10),rq.receive_date,103) receive_date,")
            strSql.Append(" st.status_name")
            strSql.Append(" from tb_requistion rq")
            strSql.Append(" inner join TB_STATUS st on st.id=rq.app_status")
            strSql.Append(" left join TS_FILE_CURRENT_LOCATION fc on fc.app_no=rq.app_no")
            strSql.Append(" left join TB_FILELOCATION fl on fl.id=rq.filelocation")
            strSql.Append(" where  st.status_name in ('ละทิ้ง','สิ้นอายุ')")  '--สถานะละทิ้งหรือสิ้นอายุ
            strSql.Append(" and isnull(fc.ms_room_id,fl.ms_room_id)=6 ") '--แล้วยังเก็บอยู่ชั้น 6
            strSql.Append(" and rq.patent_type_id in (1,3)")
            strSql.Append(" order by rq.app_no")

            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                ret = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                ret = "[]"
            End If
        Catch ex As Exception
            ret = "[]"
        End Try
        Return ret
    End Function


    <WebMethod()> _
    Public Function LoadPortal10year() As String
        Try
            Dim strdata As String
            Dim strSql As New StringBuilder
            '--แฟ้มที่ละทิ้งหรือสิ้นอายุ อายุเกิน 20 ปี และยังเก็บอยู่ที่ชั้น 1จะต้องย้ายไปเก็บที่ทรัพย์ศรีไทย
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY rq.receive_date desc) AS no,")
            strSql.Append(" rq.app_no, convert(varchar(10),rq.receive_date,103) receive_date,")
            strSql.Append(" st.status_name")
            strSql.Append(" from tb_requistion rq")
            strSql.Append(" left join TS_FILE_CURRENT_LOCATION fc on fc.app_no=rq.app_no")
            strSql.Append(" left join TB_FILELOCATION fl on fl.id=rq.filelocation")
            strSql.Append(" inner join TB_STATUS st on st.id=rq.app_status")
            strSql.Append(" where  (datediff(year,rq.receive_date ,getdate()) > 20")   '--อายุเกิน 20 ปี
            strSql.Append(" or st.status_name in ('ละทิ้ง','สิ้นอายุ'))")  '--หรือสถานะละทิ้งหรือสิ้นอายุ
            'strSql.Append(" and rq.filelocation in (2,3) ") '--แล้วยังเก็บอยู่ชั้น 1 
            strSql.Append(" and isnull(fc.ms_room_id,fl.ms_room_id) in (1,2) ") '--แล้วยังเก็บอยู่ชั้น 1
            strSql.Append(" and rq.patent_type_id in (1,3)")
            strSql.Append(" order by rq.app_no")

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
    Public Function LoadPortalNewBMove() As String
        Dim ret As String = ""
        Try
            Dim strSql As New StringBuilder
            '--แฟ้มเกิดใหม่ที่ละทิ้ง รอการเคลื่อนย้ายไปเก็บที่ทรัพย์ศรีไทย
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY rq.receive_date desc) AS no,")
            strSql.Append(" rq.app_no, convert(varchar(10),isnull(rq.RECEIVE_DATE,rq.FRM_SUBMIT_DATE),103) receive_date,st.status_name")
            strSql.Append(" from TB_REQUISTION rq")
            strSql.Append(" left join TB_FILESTORE fs on fs.app_no=rq.app_no")
            strSql.Append(" inner join TB_STATUS st on st.id=rq.app_status")
            strSql.Append(" where rq.formtype = 1")  'แฟ้มใหม่
            strSql.Append(" and fs.id is null ")  'ยังไม่จัดเก็บ
            strSql.Append(" and rq.filelocation is null ") 'ยังไม่จัดเก็บ
            strSql.Append(" and st.status_name ='ละทิ้ง'")  'สถานะละทิ้ง
            strSql.Append(" and rq.patent_type_id in (1,3)")   'เฉพาะสิทธิบัตรการประดิษฐ์และอนุสิทธิบัตร
            strSql.Append(" order by rq.app_no")

            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable
            dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                ret = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                ret = "[]"
            End If
        Catch ex As Exception
            ret = "[]"
        End Try
        Return ret
    End Function

   
#End Region
#End Region


End Class
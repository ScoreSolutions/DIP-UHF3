Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Web
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.Shared
Public Class Reports
    Inherits System.Web.UI.Page
    Private dt As New DataTable
    Private sql As String = ""

    Private Sub Reports_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Request.QueryString("reportname") IsNot Nothing Then
            Dim reportname As String = Request.QueryString("reportname")
            Select Case reportname.ToLower
                Case "frmborrowbyofficer"
                    frmBorrowByOfficer()
                Case "frmborrowbydepartment"
                    frmBorrowByDepartment()
                Case "frmborrowbydate"
                    frmBorrowByDate()
                Case "frmborrowbetween"
                    frmBorrowBetween()
                Case "frmborrownoreturn"
                    frmBorrowNoReturn()
                Case "frmborrowwithname"
                    frmBorrowWithName()
                Case "frmreturnbyofficer"
                    frmReturnByOfficer()
                Case "frmreturnbydepartment"
                    frmReturnByDepartment()
                Case "frmreturnbyday"
                    frmReturnByDay()
                Case "frmstatisticsborrow"
                    frmStatisticsBorrow()
                Case "frmstatisticsreturn"
                    frmStatisticsReturn()
                Case "frmstatisticsbyofficer"
                    frmStatisticsByOfficer()
                Case "frmperform"
                    frmPerform()
                Case "frmfilehistory"
                    frmFileHistory()
                Case "frmgraphall"
                    frmGraphAll()
                Case "frmgraphbydepartment"
                    frmGraphByDepartment()
                Case "frmgraphbypatenttype"
                    frmGraphByPatentType()
                Case "frmgraphbyofficer"
                    frmGraphByOfficer()
                Case "frmtransferbylocation"
                    frmTransferByLocation()
            End Select
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

#Region "Fuction"
    Private Sub frmBorrowByOfficer() 'DIP_R004
        'Dim officername As String = "จตุพล " 
        'Dim officerid As String = "11106000005" 
        'Dim datefrom As String = "19/09/2013" 
        'Dim dateto As String = "20/09/2013" 
        'Dim borrowType As String = 1 
        'Dim fullname As String = "DIP_R004" 
        'Dim datenow As String = DateNowCondition()

        Dim officername As String = Request.QueryString("officername")
        Dim officerid As String = Request.QueryString("officerid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim borrowType As String = Request.QueryString("borrowType")
        Dim fullname As String = HttpUtility.UrlDecode(Request.QueryString("fullname"))
        Dim datenow As String = DateNowCondition()

        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password
        Dim sql1 As String = ""
        Dim sql2 As String = ""
        sql1 = "select rq.app_no,CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate),103) borrowdate,"
        sql1 &= vbCrLf & " 'ยืมที่ห้องแฟ้ม'  borrow_quality,fb.borrower_id, ISNULL(tt.title_name,'') + of2.fname + ' ' ++ of2.lname staff_name"
        sql1 &= vbCrLf & " from TB_FILEBORROW fb"
        sql1 &= vbCrLf & " inner join TB_FILEBORROWITEM fbi on fb.id =fbi.fileborrow_id "
        sql1 &= vbCrLf & " inner join TB_REQUISTION rq on rq.id =fbi.requisition_id "
        sql1 &= vbCrLf & " inner join TB_OFFICER OF2 on of2.username = fb.createby "
        sql1 &= vbCrLf & " left join TB_TITLE TT on tt.id =of2.title_id "
        sql1 &= vbCrLf & " inner join TB_RESERVE re on re.id = fbi.reserve_id "
        sql1 &= vbCrLf & " where fb.borrower_id  ='" & officerid & "'"
        sql1 &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"

        sql2 = "select rq.app_no, CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) transfer_date,"
        sql2 &= vbCrLf & " 'ยืมโดยการโอน',re.member_id,ISNULL(ti.title_name,'') + ofo.fname + ' ' + ofo.lname staff_name"
        sql2 &= vbCrLf & " from TB_RESERVE re"
        sql2 &= vbCrLf & " inner join TB_REQUISTION rq on rq.id=re.requidition_id"
        sql2 &= vbCrLf & " inner join TB_OFFICER ofo on ofo.id=re.member_id"
        sql2 &= vbCrLf & " left join TB_TITLE ti on ti.id=ofo.title_id"
        sql2 &= vbCrLf & " where re.borrowstatus='T'"
        sql2 &= vbCrLf & " and re.officer_id_receive  ='" & officerid & "'"
        sql2 &= vbCrLf & " and convert(varchar(10),re.reserve_date,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"

        If borrowType = 1 Then
            sql = sql1
        ElseIf borrowType = 2 Then
            sql = sql2
        Else
            sql = sql1 & vbCrLf & " union all " & vbCrLf & sql2
        End If
        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R004.rpt")
            rpt.SetDataSource(dt)
            rpt.DataDefinition.FormulaFields("from_date").Text = "'" & ShowDateThai(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("to_date").Text = "'" & ShowDateThai(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            rpt.DataDefinition.FormulaFields("member_name").Text = "'" & officername & "'"
            Dim dal As New TbOfficerDAL
            Dim dt_department As New DataTable
            dt_department = dal.GetListBySql("select y.department_name  from TB_OFFICER x left join TB_DEPARTMENT y on x.department_id = y.id where x.id = '" & officerid & "'", "", Nothing)
            If dt_department.Rows.Count > 0 Then
                rpt.DataDefinition.FormulaFields("member_department").Text = "'" & dt_department.Rows(0).Item("department_name").ToString & "'"
            End If
            rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmBorrowByDepartment()

        'Dim departmentname As String = "xxxxxx"
        'Dim departmentid As String = "610" 
        'Dim datefrom As String = "17/02/2014"
        'Dim dateto As String = "17/02/2014" 
        'Dim statusreturntype As String = 1
        'Dim fullname As String = "DIP_R005" 
        'Dim datenow As String = DateNowCondition()

        Dim departmentname As String = Request.QueryString("departmentname")
        Dim departmentid As String = Request.QueryString("departmentid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim statusreturntype As String = Request.QueryString("statusreturntype")
        Dim fullname As String = Request.QueryString("fullname")
        Dim datenow As String = DateNowCondition()

        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password
        Dim sql1 As String = ""
        Dim sql2 As String = ""
        sql1 = "select rq.app_no,fb.borrower_id, isnull(tib.title_name,'')+ofb.fname + ' ' + ofb.lname borrowername,"
        sql1 &= vbCrLf & " CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate),103) borrowdate,"
        sql1 &= vbCrLf & " 'ยืมที่ห้องแฟ้ม'  borrow_quality, ISNULL(tt.title_name,'') + of2.fname + ' ' + of2.lname staff_name,"
        sql1 &= vbCrLf & " isnull((select isnull(t.title_name,'')+f.fname + ' ' + f.lname borrowname"
        sql1 &= vbCrLf & " from TB_OFFICER f"
        sql1 &= vbCrLf & " left join TB_TITLE t on t.id=f.title_id"
        sql1 &= vbCrLf & " inner join TB_FILEBORROW b on b.borrower_id=f.id"
        sql1 &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
        sql1 &= vbCrLf & " where(bi.requisition_id = fbi.requisition_id And bi.returndate Is null)"
        sql1 &= vbCrLf & " ),'ว่าง') file_status"
        sql1 &= vbCrLf & " from TB_FILEBORROW fb"
        sql1 &= vbCrLf & " inner join TB_FILEBORROWITEM fbi on fb.id =fbi.fileborrow_id "
        sql1 &= vbCrLf & " left join TB_OFFICER ofb on ofb.id=fb.borrower_id "
        sql1 &= vbCrLf & " left join TB_TITLE tib on tib.id=ofb.title_id "
        sql1 &= vbCrLf & " inner join TB_REQUISTION rq on rq.id =fbi.requisition_id "
        sql1 &= vbCrLf & " inner join TB_OFFICER OF2 on of2.username = fb.createby "
        sql1 &= vbCrLf & " left join TB_TITLE TT on tt.id =of2.title_id "
        sql1 &= vbCrLf & " inner join TB_RESERVE re on re.id = fbi.reserve_id "
        sql1 &= vbCrLf & " where  ofb.department_id = '" & departmentid & "'"
        sql1 &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"

        sql2 = " select rq.app_no, re.officer_id_receive, ISNULL(tir.title_name,'')+ofr.fname + ' ' + ofr.lname borrowername,"
        sql2 &= vbCrLf & " CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) transfer_date,"
        sql2 &= vbCrLf & " 'ยืมโดยการโอน' borrow_quality,ISNULL(ti.title_name,'') + ofo.fname + ' ' + ofo.lname staff_name,"
        sql2 &= vbCrLf & " isnull((select isnull(t.title_name,'')+f.fname + ' ' + f.lname borrowname"
        sql2 &= vbCrLf & " from TB_OFFICER f"
        sql2 &= vbCrLf & " left join TB_TITLE t on t.id=f.title_id"
        sql2 &= vbCrLf & " inner join TB_FILEBORROW b on b.borrower_id=f.id"
        sql2 &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
        sql2 &= vbCrLf & " where(bi.requisition_id = rq.id And bi.returndate Is null)"
        sql2 &= vbCrLf & " ),'ว่าง') file_status"
        sql2 &= vbCrLf & " from TB_RESERVE re"
        sql2 &= vbCrLf & " inner join TB_REQUISTION rq on rq.id=re.requidition_id"
        sql2 &= vbCrLf & " left join TB_OFFICER ofr on ofr.id=re.officer_id_receive"
        sql2 &= vbCrLf & " left join TB_TITLE tir on tir.id=ofr.title_id"
        sql2 &= vbCrLf & " inner join TB_OFFICER ofo on ofo.id=re.member_id"
        sql2 &= vbCrLf & " left join TB_TITLE ti on ti.id=ofo.title_id"
        sql2 &= vbCrLf & " where re.borrowstatus='T'"
        sql2 &= vbCrLf & " and ofr.department_id = '" & departmentid & "'"
        sql2 &= vbCrLf & " and convert(varchar(10),re.reserve_date,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"

        If StatusReturnType = 1 Then
            sql = sql1
        ElseIf StatusReturnType = 2 Then
            sql = sql2
        Else
            sql = sql1 & vbCrLf & " union all " & vbCrLf & sql2
        End If
        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R005.rpt")
            rpt.SetDataSource(dt)
            rpt.DataDefinition.FormulaFields("from_date").Text = "'" & ShowDateThai(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("to_date").Text = "'" & ShowDateThai(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            rpt.DataDefinition.FormulaFields("department").Text = "'" & departmentname & "'"
            Dim dal As New TbDepartmentDAL
            Dim dt_department As New DataTable
            dt_department = dal.GetListBySql("select department_name  from TB_DEPARTMENT where id = '" & departmentid & "'", "", Nothing)
            If dt_department.Rows.Count > 0 Then
                rpt.DataDefinition.FormulaFields("group").Text = "'" & dt_department.Rows(0).Item("department_name").ToString & "'"
            End If
            rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmBorrowByDate()
        'Dim datefrom As String = "28/04/2011"
        'Dim dateto As String = "28/04/2011"
        'Dim statusreturntype As String = 1 
        'Dim borrowtype As String = 1 
        'Dim fullname As String = "DIP_R006"
        'Dim datenow As String = DateNowCondition()

        Dim datefrom As String = Request.QueryString("datefrom") '##validat
        Dim dateto As String = Request.QueryString("dateto") '##validat
        Dim statusreturntype As String = Request.QueryString("statusreturntype")
        Dim borrowtype As String = Request.QueryString("borrowtype")
        Dim fullname As String = Request.QueryString("fullname")
        Dim datenow As String = DateNowCondition()

        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password
        Dim sql1 As String = ""
        Dim sql2 As String = ""
        sql1 = "select rq.app_no,fb.borrower_id, isnull(tib.title_name,'')+ofb.fname + ' ' + ofb.lname borrowername,"
        sql1 &= vbCrLf & " dp.department_name, CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate),103) borrowdate,"
        sql1 &= vbCrLf & " 'ยืมที่ห้องแฟ้ม'  borrow_quality, ISNULL(tt.title_name,'') + of2.fname + ' ' + of2.lname staff_name,"
        sql1 &= vbCrLf & " isnull((select isnull(t.title_name,'')+f.fname + ' ' + f.lname borrowname"
        sql1 &= vbCrLf & " from TB_OFFICER f"
        sql1 &= vbCrLf & " left join TB_TITLE t on t.id=f.title_id"
        sql1 &= vbCrLf & " inner join TB_FILEBORROW b on b.borrower_id=f.id"
        sql1 &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
        sql1 &= vbCrLf & " where(bi.requisition_id = fbi.requisition_id And bi.returndate Is null)"
        sql1 &= vbCrLf & " ),'ว่าง') file_status"
        sql1 &= vbCrLf & " from TB_FILEBORROW fb"
        sql1 &= vbCrLf & " inner join TB_FILEBORROWITEM fbi on fb.id =fbi.fileborrow_id "
        sql1 &= vbCrLf & " left join TB_OFFICER ofb on ofb.id=fb.borrower_id "
        sql1 &= vbCrLf & " left join TB_TITLE tib on tib.id=ofb.title_id "
        sql1 &= vbCrLf & " left join TB_DEPARTMENT dp on dp.id=ofb.department_id"
        sql1 &= vbCrLf & " inner join TB_REQUISTION rq on rq.id =fbi.requisition_id "
        sql1 &= vbCrLf & " inner join TB_OFFICER OF2 on of2.username = fb.createby "
        sql1 &= vbCrLf & " left join TB_TITLE TT on tt.id =of2.title_id "
        sql1 &= vbCrLf & " where  convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"
        sql1 &= vbCrLf & " and fb.borrowerstatus='B'  --ลักษณะการยืม B=ยืมที่ห้องแฟ้ม"

        If statusreturntype = 1 Then
            sql1 &= vbCrLf & " and fbi.returndate is not null  --สถานะแฟ้มยังไม่คืน ถ้าคืนแล้วให้เป็น fbi.returndate is not null"
        ElseIf statusreturntype = 2 Then
            sql1 &= vbCrLf & " and fbi.returndate is null  --สถานะแฟ้มยังไม่คืน ถ้าคืนแล้วให้เป็น fbi.returndate is not null"
        End If

        sql2 = "select * from ( select rq.app_no, re.officer_id_receive, ISNULL(tir.title_name,'')+ofr.fname + ' ' + ofr.lname borrowername,"
        sql2 &= vbCrLf & " dp.department_name, CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) transfer_date,"
        sql2 &= vbCrLf & " 'ยืมโดยการโอน' borrow_quality,ISNULL(ti.title_name,'') + ofo.fname + ' ' + ofo.lname staff_name,"
        sql2 &= vbCrLf & " isnull((select isnull(t.title_name,'')+f.fname + ' ' + f.lname borrowname"
        sql2 &= vbCrLf & " from TB_OFFICER f"
        sql2 &= vbCrLf & " left join TB_TITLE t on t.id=f.title_id"
        sql2 &= vbCrLf & " inner join TB_FILEBORROW b on b.borrower_id=f.id"
        sql2 &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
        sql2 &= vbCrLf & " where(bi.requisition_id = rq.id And bi.returndate Is null)"
        sql2 &= vbCrLf & " ),'ว่าง') file_status"
        sql2 &= vbCrLf & " from TB_RESERVE re"
        sql2 &= vbCrLf & " inner join TB_REQUISTION rq on rq.id=re.requidition_id"
        sql2 &= vbCrLf & " left join TB_OFFICER ofr on ofr.id=re.officer_id_receive"
        sql2 &= vbCrLf & " left join TB_TITLE tir on tir.id=ofr.title_id"
        sql2 &= vbCrLf & " left join TB_DEPARTMENT dp on dp.id=ofr.department_id"
        sql2 &= vbCrLf & " inner join TB_OFFICER ofo on ofo.id=re.member_id"
        sql2 &= vbCrLf & " left join TB_TITLE ti on ti.id=ofo.title_id"
        sql2 &= vbCrLf & " where re.borrowstatus='T' --ลักษณะการยืม T=ยืมโดยการโอน"
        sql2 &= vbCrLf & " and convert(varchar(10),re.reserve_date,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "') as TB"
        If statusreturntype = 1 Then
            sql2 &= vbCrLf & "  where file_status <> 'ว่าง'  --กรณีคืนแล้ว ถ้ายังไม่คืนให้ file_status<>'ว่าง'"
        ElseIf statusreturntype = 2 Then
            sql2 &= vbCrLf & "  where file_status = 'ว่าง'  --กรณีคืนแล้ว ถ้ายังไม่คืนให้ file_status<>'ว่าง'"
        End If

        If borrowtype = 1 Then
            sql = sql1
        ElseIf borrowtype = 2 Then
            sql = sql2
        Else
            sql = sql1 & vbCrLf & " union all " & vbCrLf & sql2
        End If

        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R006.rpt")
            rpt.SetDataSource(dt)
            rpt.DataDefinition.FormulaFields("from_date").Text = "'" & ShowDateThai(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("to_date").Text = "'" & ShowDateThai(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If

    End Sub

    Private Sub frmBorrowBetween()

        'Dim departmentname As String = "xxxxxx"
        'Dim departmentid As String = "610"
        'Dim datefrom As String = "17/02/2014" 
        'Dim dateto As String = "17/02/2014"
        'Dim statusreturntype As String = 1 
        'Dim fullname As String = "DIP_R007" 
        'Dim datenow As String = DateNowCondition()

        Dim departmentname As String = Request.QueryString("departmentname")
        Dim departmentid As String = Request.QueryString("departmentid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim statusreturntype As String = Request.QueryString("statusreturntype")
        Dim fullname As String = Request.QueryString("fullname")
        Dim datenow As String = DateNowCondition()

        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password

        sql = "select rq.app_no,fb.borrower_id, isnull(tib.title_name,'')+ofb.fname + ' ' + ofb.lname borrowername,"
        sql &= vbCrLf & " CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate),103) borrowdate,"
        sql &= vbCrLf & " ISNULL(tt.title_name,'') + of2.fname + ' ' + of2.lname staff_name"
        sql &= vbCrLf & " from TB_FILEBORROW fb"
        sql &= vbCrLf & " inner join TB_FILEBORROWITEM fbi on fb.id =fbi.fileborrow_id "
        sql &= vbCrLf & " left join TB_OFFICER ofb on ofb.id=fb.borrower_id "
        sql &= vbCrLf & " left join TB_TITLE tib on tib.id=ofb.title_id "
        sql &= vbCrLf & " inner join TB_REQUISTION rq on rq.id =fbi.requisition_id "
        sql &= vbCrLf & " inner join TB_OFFICER OF2 on of2.username = fb.createby "
        sql &= vbCrLf & " left join TB_TITLE TT on tt.id =of2.title_id "
        sql &= vbCrLf & " where(fbi.returndate Is null)"
        sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"
        sql &= vbCrLf & " and ofb.department_id = '" & departmentid & "'"
        sql &= vbCrLf & " union all"
        sql &= vbCrLf & " select rq.app_no, re.officer_id_receive, ISNULL(tir.title_name,'')+ofr.fname + ' ' + ofr.lname borrowername,"
        sql &= vbCrLf & " CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) transfer_date,"
        sql &= vbCrLf & " ISNULL(ti.title_name,'') + ofo.fname + ' ' + ofo.lname staff_name"
        sql &= vbCrLf & " from TB_RESERVE re"
        sql &= vbCrLf & " inner join TB_REQUISTION rq on rq.id=re.requidition_id"
        sql &= vbCrLf & " left join TB_OFFICER ofr on ofr.id=re.officer_id_receive"
        sql &= vbCrLf & " left join TB_TITLE tir on tir.id=ofr.title_id"
        sql &= vbCrLf & " left join TB_DEPARTMENT dp on dp.id=ofr.department_id"
        sql &= vbCrLf & " inner join TB_OFFICER ofo on ofo.id=re.member_id"
        sql &= vbCrLf & " left join TB_TITLE ti on ti.id=ofo.title_id"
        sql &= vbCrLf & " left join (select bi.requisition_id"
        sql &= vbCrLf & " from TB_FILEBORROW b "
        sql &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
        sql &= vbCrLf & " where  bi.returndate is null) b on b.requisition_id=rq.id"
        sql &= vbCrLf & " where re.borrowstatus='T'  and b.requisition_id is null"
        sql &= vbCrLf & " and convert(varchar(10),re.reserve_date,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"
        sql &= vbCrLf & " and ofo.department_id = '" & departmentid & "'"

        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R007.rpt")
            rpt.SetDataSource(dt)
            rpt.DataDefinition.FormulaFields("from_date").Text = "'" & ShowDateThai(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("to_date").Text = "'" & ShowDateThai(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            rpt.DataDefinition.FormulaFields("dapartment").Text = "'" & departmentname & "'"
            rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If

    End Sub

    Private Sub frmBorrowNoReturn()

        'Dim officerid As String = "2010000668"
        'Dim datefrom As String = "18/11/2014" 
        'Dim dateto As String = "18/11/2014"
        'Dim fullname As String = "DIP_R008" 
        'Dim datenow As String = DateNowCondition()

        Dim officerid As String = Request.QueryString("officerid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")
        Dim datenow As String = DateNowCondition()


        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password
        sql = "select rq.app_no,fb.borrower_id, isnull(tib.title_name,'')+ofb.fname + ' ' + ofb.lname borrowername,"
        sql &= vbCrLf & " dp.department_name, CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate),103) borrowdate,"
        sql &= vbCrLf & " 'ยืมที่ห้องแฟ้ม'  borrow_quality, ISNULL(tt.title_name,'') + of2.fname + ' ' + of2.lname staff_name,"
        sql &= vbCrLf & " isnull((select top 1 isnull(t.title_name,'')+f.fname + ' ' + f.lname borrowname"
        sql &= vbCrLf & " from TB_OFFICER f"
        sql &= vbCrLf & " left join TB_TITLE t on t.id=f.title_id"
        sql &= vbCrLf & " inner join TB_FILEBORROW b on b.borrower_id=f.id"
        sql &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
        sql &= vbCrLf & " where(bi.requisition_id = fbi.requisition_id And bi.returndate Is null)"
        sql &= vbCrLf & " ),'ว่าง') file_status"
        sql &= vbCrLf & " from TB_FILEBORROW fb"
        sql &= vbCrLf & " inner join TB_FILEBORROWITEM fbi on fb.id =fbi.fileborrow_id "
        sql &= vbCrLf & " left join TB_OFFICER ofb on ofb.id=fb.borrower_id "
        sql &= vbCrLf & " left join TB_TITLE tib on tib.id=ofb.title_id "
        sql &= vbCrLf & " left join TB_DEPARTMENT dp on dp.id=ofb.department_id"
        sql &= vbCrLf & " inner join TB_REQUISTION rq on rq.id =fbi.requisition_id "
        sql &= vbCrLf & " inner join TB_OFFICER OF2 on of2.username = fb.createby "
        sql &= vbCrLf & " left join TB_TITLE TT on tt.id =of2.title_id "
        sql &= vbCrLf & " where(fbi.returndate Is null)"
        sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"
        sql &= vbCrLf & " and fb.borrower_id = '" & officerid & "'"
        sql &= vbCrLf & " union all "
        sql &= vbCrLf & " select rq.app_no, re.officer_id_receive, ISNULL(tir.title_name,'')+ofr.fname + ' ' + ofr.lname borrowername,"
        sql &= vbCrLf & " dp.department_name, CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) transfer_date,"
        sql &= vbCrLf & " 'ยืมโดยการโอน',ISNULL(ti.title_name,'') + ofo.fname + ' ' + ofo.lname staff_name,"
        sql &= vbCrLf & " isnull((select top 1 isnull(t.title_name,'')+f.fname + ' ' + f.lname borrowname"
        sql &= vbCrLf & " from TB_OFFICER f"
        sql &= vbCrLf & " left join TB_TITLE t on t.id=f.title_id"
        sql &= vbCrLf & " inner join TB_FILEBORROW b on b.borrower_id=f.id"
        sql &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
        sql &= vbCrLf & " where(bi.requisition_id = rq.id And bi.returndate Is null)"
        sql &= vbCrLf & " ),'ว่าง') file_status"
        sql &= vbCrLf & " from TB_RESERVE re"
        sql &= vbCrLf & " inner join TB_REQUISTION rq on rq.id=re.requidition_id"
        sql &= vbCrLf & " left join TB_OFFICER ofr on ofr.id=re.officer_id_receive"
        sql &= vbCrLf & " left join TB_TITLE tir on tir.id=ofr.title_id"
        sql &= vbCrLf & " left join TB_DEPARTMENT dp on dp.id=ofr.department_id"
        sql &= vbCrLf & " inner join TB_OFFICER ofo on ofo.id=re.member_id"
        sql &= vbCrLf & " left join TB_TITLE ti on ti.id=ofo.title_id"
        sql &= vbCrLf & " left join (select bi.requisition_id"
        sql &= vbCrLf & " from TB_FILEBORROW b "
        sql &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
        sql &= vbCrLf & " where  bi.returndate is null) b on b.requisition_id=rq.id"
        sql &= vbCrLf & " where re.borrowstatus='T' and b.requisition_id is null"
        sql &= vbCrLf & " and convert(varchar(10),re.reserve_date,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"
        sql &= vbCrLf & " and re.officer_id_receive ='" & officerid & "'"
        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R008.rpt")
            rpt.SetDataSource(dt)
            rpt.DataDefinition.FormulaFields("from_date").Text = "'" & ShowDateThai(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("to_date").Text = "'" & ShowDateThai(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None

            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmBorrowWithName()

        'Dim datefrom As String = "17/06/2014"
        'Dim dateto As String = "17/06/2014" 
        'Dim fullname As String = "DIP_R009"
        'Dim datenow As String = DateNowCondition()

        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")
        Dim datenow As String = DateNowCondition()

        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password

        Dim str As String = ""
        str = "SELECT TB_REQUISTION.app_no,convert(varchar(8),TB_FILEBORROW.borrowerdate,112) "
        str += "as borrowerdate,TB_PATENT_TYPE.patent_type_name"
        str += ",TB_FILEBORROW.borrowername as borrowername,isnull(TT.title_name,'')+"
        str += "OF2.fname+ ' ' +OF2.lname as officercreateby "
        str += "FROM TB_FILEBORROWITEM "
        str += "INNER JOIN TB_REQUISTION ON TB_FILEBORROWITEM.requisition_id = TB_REQUISTION.id "
        str += "INNER JOIN TB_PATENT_TYPE ON TB_REQUISTION.patent_type_id = TB_PATENT_TYPE.id "
        str += "INNER JOIN TB_FILEBORROW ON TB_FILEBORROWITEM.fileborrow_id=TB_FILEBORROW.id "
        str += "INNER JOIN TB_OFFICER ON TB_FILEBORROW.borrower_id=TB_OFFICER.id "
        str += "left JOIN TB_TITLE ON TB_OFFICER.title_id=TB_TITLE.id "
        str += "INNER JOIN TB_OFFICER OF2 ON OF2.username = TB_FILEBORROW.createby "
        str += "left JOIN TB_TITLE TT ON TT.id = OF2.title_id "
        str += "WHERE TB_FILEBORROWITEM.returndate Is NULL "
        str += "and convert(varchar(8),TB_FILEBORROW.createon,112)"
        str += "between '" & FixDate(datefrom) & "' AND '" & FixDate(dateto) & "' "
        str += "ORDER BY TB_FILEBORROW.borrowerdate ASC"
        dt = SqlDB.ExecuteTable(str)
        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R009.rpt")
            rpt.SetDataSource(dt)
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None

            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmReturnByOfficer()
        'Dim officerid As String = "2003000677"
        'Dim datefrom As String = "09/05/2011"
        'Dim dateto As String = "09/05/2011"
        'Dim fullname As String = "DIP_R010"

        Dim officerid As String = Request.QueryString("officerid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = HttpUtility.UrlDecode(Request.QueryString("fullname"))
        Dim Str As String = ""
        Str = "SELECT rq.app_no,convert(varchar(8),fbi.returndate,112) as returndate"
        Str += ",isnull(tt.title_name,'')+tof.fname+' '+tof.lname as officerreturn"
        Str += ",ti.title_name+TBO.fname+' '+TBO.lname as borrowername,dp.department_name "
        Str += "FROM TB_FILEBORROW fb "
        Str += "INNER JOIN TB_FILEBORROWITEM fbi on fb.id=fbi.fileborrow_id "
        Str += "INNER JOIN TB_OFFICER tbo on tbo.id=fb.borrower_id "
        Str += "LEFT JOIN TB_TITLE ti ON tbo.title_id = ti.id "
        Str += "LEFT JOIN TB_DEPARTMENT dp ON dp.id=tbo.department_id "
        Str += "INNER JOIN TB_REQUISTION rq ON fbi.requisition_id = rq.id "
        Str += "INNER JOIN TB_PATENT_TYPE pt on pt.id=rq.patent_type_id "
        Str += "INNER JOIN TB_OFFICER TOF ON TOF.username=fbi.officer_return "
        Str += "LEFT JOIN TB_TITLE TT ON TOF.title_id=TT.id "
        Str += "WHERE convert(varchar(8),fbi.returndate,112) "
        Str += "between '" & FixDate(datefrom) & "' AND '" & FixDate(dateto) & "' "
        Str += "and fb.borrower_id='" & officerid & "'"
        Str += "order by fbi.returndate ASC"
        dt = SqlDB.ExecuteTable(Str)

        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R010.rpt")
            rpt.SetDataSource(dt)

            rpt.DataDefinition.FormulaFields("datestart").Text = "'" & FixDate(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("datestop").Text = "'" & FixDate(dateto) & "'"
            rpt.SetDataSource(dt)
            Dim paramValue As New ParameterDiscreteValue
            Dim curValue As New ParameterValues
            paramValue.Value = fullname
            curValue = rpt.ParameterFields("staff").CurrentValues
            curValue.Add(paramValue)
            rpt.ParameterFields("staff").CurrentValues = curValue
            paramValue.Value = DateNowCondition()
            curValue = rpt.ParameterFields("date").CurrentValues
            curValue.Add(paramValue)
            rpt.ParameterFields("date").CurrentValues = curValue
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmReturnByDepartment()
        'Dim departmentid As String = "510" 
        'Dim datefrom As String = "31/05/2011" 
        'Dim dateto As String = "31/05/2011" 
        'Dim fullname As String = "DIP_R011" 

        Dim departmentid As String = Request.QueryString("departmentid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")


        Dim Str As String = ""
        Str = "SELECT rq.app_no,isnull(ti.title_name,'')+tbo.fname + ' ' + tbo.lname as borrowername"
        Str += ",dp.department_name,convert(varchar(8),fbi.returndate,112) as returndate"
        Str += ",isnull(tt.title_name,'')+tof.fname+' '+tof.lname as officerreturn "
        Str += "FROM TB_FILEBORROW fb "
        Str += "INNER JOIN TB_FILEBORROWITEM fbi on fb.id=fbi.fileborrow_id "
        Str += "INNER JOIN TB_OFFICER tbo on tbo.id=fb.borrower_id "
        Str += "INNER JOIN TB_DEPARTMENT dp ON dp.id=tbo.department_id "
        Str += "INNER JOIN TB_TITLE ti ON tbo.title_id = ti.id "
        Str += "INNER JOIN TB_REQUISTION rq ON fbi.requisition_id = rq.id "
        Str += "INNER JOIN TB_OFFICER TOF ON TOF.username=fbi.officer_return "
        Str += "LEFT JOIN TB_TITLE TT ON TOF.title_id=TT.id "
        Str += "WHERE convert(varchar(8),fbi.returndate,112) "
        Str += "between '" & FixDate(datefrom) & "' AND '" & FixDate(dateto) & "' "
        Str += "AND dp.id='" & departmentid & "'"
        Str += "order by fbi.returndate ASC"
        dt = SqlDB.ExecuteTable(Str)
        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R011.rpt")
            rpt.SetDataSource(dt)

            rpt.DataDefinition.FormulaFields("datestart").Text = "'" & FixDate(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("datestop").Text = "'" & FixDate(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmReturnByDay()
        'Dim patentid As String = "1" 
        'Dim datefrom As String = "09/05/2011" 
        'Dim dateto As String = "09/05/2011" 
        'Dim fullname As String = "DIP_R012" 

        Dim patentid As String = Request.QueryString("patentid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")


        Dim sqlqury, str As String
        'MsgBox(pattened)
        If patentid = 0 Then
            sqlqury = ""
        Else
            sqlqury = "and pt.id='" & patentid & "'"
        End If

        str = "SELECT convert(varchar(8),fbi.returndate,112)returndate , rq.app_no"
        str += ",isnull(ti.title_name,'')+tbo.fname+' '+tbo.lname as borrowername"
        str += ",dp.department_name,pt.patent_type_name "
        str += ",isnull(tt.title_name,'')+tof.fname + ' ' + tof.lname as officerreturn "
        str += "FROM TB_FILEBORROW fb "
        str += "inner join TB_FILEBORROWITEM fbi on fb.id=fbi.fileborrow_id "
        str += "inner join TB_OFFICER tbo on tbo.id=fb.borrower_id "
        str += "left JOIN TB_TITLE ti ON tbo.title_id = ti.id "
        str += "left JOIN TB_DEPARTMENT dp ON dp.id=tbo.department_id "
        str += "INNER JOIN TB_REQUISTION rq ON fbi.requisition_id = rq.id "
        str += "inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id "
        str += "INNER JOIN TB_OFFICER TOF ON TOF.username=fbi.officer_return "
        str += "left JOIN TB_TITLE TT ON TOF.title_id=TT.id "
        str += "WHERE convert(varchar(8),fbi.returndate,112) "
        str += "between '" & FixDate(datefrom) & "' AND '" & FixDate(dateto) & "'"
        str += "" & sqlqury & " order by fbi.returndate ASC"
        dt = SqlDB.ExecuteTable(str)

        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R012.rpt")
            rpt.SetDataSource(dt)

            rpt.DataDefinition.FormulaFields("datestart").Text = "'" & FixDate(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("datestop").Text = "'" & FixDate(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If

    End Sub

    Private Sub frmStatisticsBorrow()
        'Dim patentid As String = "1"
        'Dim datefrom As String = "27/07/2012" 
        'Dim dateto As String = "27/07/2012"
        'Dim fullname As String = "DIP_R013" 

        Dim patentid As String = Request.QueryString("patentid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")

        Dim sqlqury, str As String
        'MsgBox(pattened)
        If patentid = 0 Then
            sqlqury = ""
        Else
            sqlqury = "and pt.id='" & patentid & "'"
        End If

        str = "select CONVERT(VARCHAR(8),fb.borrowerdate,112) as dateBorrow"
        str += ",pt.patent_type_name,COUNT (fbi.requisition_id)as borrow "
        str += "from TB_FILEBORROWITEM fbi "
        str += "inner join TB_FILEBORROW fb on fb.id=fbi.fileborrow_id "
        str += "inner join TB_REQUISTION rq on rq.id=fbi.requisition_id "
        str += "inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id "
        str += "where Convert(VARCHAR(8),fb.borrowerdate,112) "
        str += "between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "' "
        str += "" & sqlqury & " group by fb.borrowerdate,pt.patent_type_name "
        str += "order by fb.borrowerdate ASC"
        dt = SqlDB.ExecuteTable(str)

        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R013.rpt")
            rpt.SetDataSource(dt)

            rpt.DataDefinition.FormulaFields("datestart").Text = "'" & FixDate(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("datestop").Text = "'" & FixDate(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If

    End Sub

    Private Sub frmStatisticsReturn()
        'Dim patentid As String = "1" 
        'Dim datefrom As String = "27/07/2012" 
        'Dim dateto As String = "27/07/2012" 
        'Dim fullname As String = "DIP_R014" 

        Dim patentid As String = Request.QueryString("patentid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")

        Dim sqlqury, str As String
        'MsgBox(pattened)
        If patentid = 0 Then
            sqlqury = ""
        Else
            sqlqury = "and pt.id='" & patentid & "'"
        End If

        str = "select CONVERT(VARCHAR(8),fbi.returndate,112) as returndate ,pt.patent_type_name"
        str += ",COUNT (fbi.requisition_id)as returned "
        str += "from TB_FILEBORROWITEM fbi "
        str += "inner join TB_REQUISTION rq on rq.id=fbi.requisition_id "
        str += "inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id "
        str += "where Convert(VARCHAR(8), fbi.returndate, 112) "
        str += "between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "' "
        str += "" & sqlqury & ""
        str += "group by CONVERT(VARCHAR(8),fbi.returndate,112),pt.patent_type_name "
        str += "order by CONVERT(VARCHAR(8),fbi.returndate,112) ASC"
        dt = SqlDB.ExecuteTable(str)

        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R014.rpt")
            rpt.SetDataSource(dt)

            rpt.DataDefinition.FormulaFields("datestart").Text = "'" & FixDate(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("datestop").Text = "'" & FixDate(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmStatisticsByOfficer()

        'Dim officerid As String = "11218700001" 
        'Dim datefrom As String = "09/11/2012" 
        'Dim dateto As String = "09/11/2012"
        'Dim fullname As String = "DIP_R015"

        Dim officerid As String = Request.QueryString("officerid") '##validat
        Dim officername As String = Request.QueryString("officername")
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")

        Dim Str As String = ""
        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password

        sql = "select rq.app_no,CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate),103) borrowdate,"
        sql &= vbCrLf & " 'ยืมที่ห้องแฟ้ม'  borrow_quality,fb.borrower_id, ISNULL(tt1.title_name,'') + of1.fname + ' ' ++ of1.lname staff_name"
        sql &= vbCrLf & " ,CONVERT(varchar(10), DATEADD(year,543, fbi.returndate),103) returndate "
        sql &= vbCrLf & " ,case when ISNULL(returndate,'') <> '' then 'คืนที่ห้องแฟ้ม' else '' end return_quality"
        sql &= vbCrLf & " ,ISNULL(tt2.title_name,'') + of2.fname + ' ' ++ of2.lname return_staff_name"
        sql &= vbCrLf & " from TB_FILEBORROW fb"
        sql &= vbCrLf & " inner join TB_FILEBORROWITEM fbi on fb.id =fbi.fileborrow_id "
        sql &= vbCrLf & " inner join TB_REQUISTION rq on rq.id =fbi.requisition_id "
        sql &= vbCrLf & " inner join TB_OFFICER OF1 on of1.username = fb.createby "
        sql &= vbCrLf & " left join TB_TITLE TT1 on tt1.id =of1.title_id "
        sql &= vbCrLf & " inner join TB_RESERVE re on re.id = fbi.reserve_id "
        sql &= vbCrLf & " left join TB_OFFICER OF2 on of2.username = fbi.officer_return  "
        sql &= vbCrLf & " left join TB_TITLE TT2 on tt2.id =of2.title_id "
        sql &= vbCrLf & " where fb.borrower_id  ='" & officerid & "'"
        sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"
        sql &= vbCrLf & " union all"
        sql &= vbCrLf & " Select rq.app_no"
        sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) else '' end borrowdate"
        sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then 'ยืมโดยการโอน' else '' end borrow_quality"
        sql &= vbCrLf & " ,re.member_id borrower_id "
        sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then ISNULL(ti.title_name,'') + ofo.fname + ' ' + ofo.lname else '' end staff_name"
        sql &= vbCrLf & " ,case when re.borrowstatus = 'R' then CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) else '' end returndate"
        sql &= vbCrLf & " ,case when re.borrowstatus = 'R' then 'คืนโดยการโอน' else '' end return_quality"
        sql &= vbCrLf & " ,case when re.borrowstatus = 'R' then ISNULL(ti.title_name,'') + ofo.fname + ' ' + ofo.lname else '' end return_staff_name"
        sql &= vbCrLf & " from TB_RESERVE re"
        sql &= vbCrLf & " inner join TB_REQUISTION rq on rq.id=re.requidition_id"
        sql &= vbCrLf & " inner join TB_OFFICER ofo on ofo.id=re.member_id"
        sql &= vbCrLf & " left join TB_TITLE ti on ti.id=ofo.title_id"
        sql &= vbCrLf & " where re.borrowstatus in ('T','R')"
        sql &= vbCrLf & " and re.officer_id_receive  ='" & officerid & "'"
        sql &= vbCrLf & " and convert(varchar(10),re.reserve_date,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"

        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R015.rpt")
            rpt.SetDataSource(dt)
            rpt.DataDefinition.FormulaFields("from_date").Text = "'" & ShowDateThai(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("to_date").Text = "'" & ShowDateThai(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            rpt.DataDefinition.FormulaFields("membername").Text = "'" & officername & "'"

            Dim dt_ As New DataTable
            dt_ = SqlDB.ExecuteTable("select officer_no,department_name  from TB_OFFICER x left join TB_DEPARTMENT y on x.department_id = y.id where x.id = '" & officerid & "'")
            If dt_.Rows.Count > 0 Then
                rpt.DataDefinition.FormulaFields("membercode").Text = "'" & dt_.Rows(0).Item("officer_no").ToString & "'"
                'rpt.DataDefinition.FormulaFields("membercode").Text = "'" & officername & "'"
                rpt.DataDefinition.FormulaFields("group").Text = "'" & dt_.Rows(0).Item("department_name").ToString & "'"
            End If

            rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmPerform()
        'Dim officername As String = "จตุพล" 
        'Dim officerid As String = "2003000629" 
        'Dim datefrom As String = "08/02/2012" 
        'Dim dateto As String = "08/02/2012"
        'Dim fullname As String = "DIP_R016" 
        'Dim Str As String = ""

        Dim officername As String = Request.QueryString("officername") '##validat
        Dim officerid As String = Request.QueryString("officerid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")
        Dim Str As String = ""


        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password
        '******************** หา Username และ รหัสพนักงาน *******************
        Dim dt_ As New DataTable
        Dim username As String = ""
        Dim membercode As String = ""
        dt_ = SqlDB.ExecuteTable("select officer_no,username from TB_OFFICER where id = '" & officerid & "'")
        If dt_.Rows.Count > 0 Then
            username = dt_.Rows(0).Item("username").ToString.Trim
            membercode = dt_.Rows(0).Item("officer_no").ToString.Trim
        End If
        '***************************************************************
        '********** หาข้อมูล Borrow และ Return เพื่อใส่ใน sub report ***********
        Dim dt_borrow As New DataTable
        Dim dt_return As New DataTable

        sql = "select borrowdate,SUM(type1) type1,SUM(type2) type2,SUM(type3) type3 from ("
        sql &= vbCrLf & " select CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate ),103) borrowdate"
        sql &= vbCrLf & " ,case when rq.patent_type_id = 1 then 1 else 0 end as type1"
        sql &= vbCrLf & " ,case when rq.patent_type_id = 2 then 1 else 0 end as type2"
        sql &= vbCrLf & " ,case when rq.patent_type_id = 3 then 1 else 0 end as type3"
        sql &= vbCrLf & " ,fb.createby "
        sql &= vbCrLf & " from TB_FILEBORROW fb "
        sql &= vbCrLf & " left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
        sql &= vbCrLf & " left join TB_REQUISTION rq on fbi.requisition_id = rq.id"
        sql &= vbCrLf & " where fb.createby = '" & username & "'"
        sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"
        sql &= vbCrLf & " ) as TB group by borrowdate order by borrowdate desc"
        dt_borrow = SqlDB.ExecuteTable(sql)

        sql = "select returndate,SUM(type1) type1,SUM(type2) type2,SUM(type3) type3 from ("
        sql &= vbCrLf & " select CONVERT(varchar(10), DATEADD(year,543, fbi.returndate ),103) returndate"
        sql &= vbCrLf & " ,case when rq.patent_type_id = 1 then 1 else 0 end as type1"
        sql &= vbCrLf & " ,case when rq.patent_type_id = 2 then 1 else 0 end as type2"
        sql &= vbCrLf & " ,case when rq.patent_type_id = 3 then 1 else 0 end as type3"
        sql &= vbCrLf & " ,fbi.officer_return  "
        sql &= vbCrLf & " from TB_FILEBORROWITEM fbi left join TB_REQUISTION rq on fbi.requisition_id = rq.id"
        sql &= vbCrLf & " where returndate is not null and fbi.officer_return = '" & username & "' "
        sql &= vbCrLf & " and convert(varchar(10),fbi.returndate,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"
        sql &= vbCrLf & " ) as TB group by returndate order by returndate desc"
        dt_return = SqlDB.ExecuteTable(sql)
        '***************************************************************

        If dt_borrow.Rows.Count > 0 Or dt_return.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R016.rpt")
            rpt.SetDataSource(dt)

            rpt.Subreports(0).SetDataSource(dt_borrow)
            rpt.Subreports(1).SetDataSource(dt_return)

            rpt.DataDefinition.FormulaFields("from_date").Text = "'" & ShowDateThai(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("to_date").Text = "'" & ShowDateThai(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            rpt.DataDefinition.FormulaFields("membername").Text = "'" & officername & "'"
            rpt.DataDefinition.FormulaFields("membercode").Text = "'" & membercode & "'"

            rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmFileHistory()
        'Dim appno As String = "0803001487"
        'Dim fullname As String = "DIP_R017"
        'Dim datefrom As String = "30/07/2013"
        'Dim dateto As String = "30/07/2013"
        'Dim Str As String = ""

        Dim appno As String = Request.QueryString("appno") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")
        Dim Str As String = ""


        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password

        sql = "select rq.app_no,CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) reserve_date,re.member_name"
        sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then re.member_name else fb.borrowername  end borrowname  "
        sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) else CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate ),103)  end borrowdate"
        sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then 'ยืมโดยการโอน' else case when isnull(fb.borrowerdate,'') = '' then '' else 'ยืมที่ห้องแฟ้ม' end end borrow_quality "
        sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then re.member_name else case when isnull(fb.borrowerdate,'') = '' then '' else ISNULL(tt1.title_name,'') + of1.fname + ' ' + of1.lname end end staff_borrow "
        sql &= vbCrLf & " ,case when re.borrowstatus = 'R' then CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) else CONVERT(varchar(10), DATEADD(year,543, fbi.returndate ),103)  end returndate"
        sql &= vbCrLf & " ,case when re.borrowstatus = 'R' then 'คืนโดยการโอน' else case when isnull(fbi.returndate,'') = '' then '' else 'คืนที่ห้องแฟ้ม' end end return_quality "
        sql &= vbCrLf & " ,case when re.borrowstatus = 'R' then re.member_name else case when isnull(fbi.returndate,'') = '' then '' else ISNULL(tt2.title_name,'') + of2.fname + ' ' + of2.lname end end staff_return"
        sql &= vbCrLf & " from TB_RESERVE re "
        sql &= vbCrLf & " left join TB_REQUISTION rq on re.requidition_id = rq.id "
        sql &= vbCrLf & " left join TB_RESERVE_JOB rej on re.reserve_job_id = rej.id"
        sql &= vbCrLf & " left join TB_FILEBORROW fb on re.reserve_job_id = fb.reserve_job_id"
        sql &= vbCrLf & " left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id and re.requidition_id = fbi.requisition_id"
        sql &= vbCrLf & " left join TB_OFFICER of1 on fb.createby = of1.username "
        sql &= vbCrLf & " left join TB_TITLE tt1 on of1.title_id = tt1.id"
        sql &= vbCrLf & " left join TB_OFFICER of2 on fbi.officer_return = of2.username "
        sql &= vbCrLf & " left join TB_TITLE tt2 on of2.title_id = tt2.id"
        sql &= vbCrLf & " where re.reserve_job_id Is Not null"
        sql &= vbCrLf & " and rq.app_no = '" & appno & "'"
        sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"

        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count > 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R017.rpt")
            rpt.SetDataSource(dt)
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"

            rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmGraphAll()
        'Dim datefrom As String = "23/03/2014"
        'Dim dateto As String = "23/03/2014"
        'Dim fullname As String = "DIP_R018"
        'Dim Str As String = ""

        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")
        Dim Str As String = ""

        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password

        sql = "declare @f_date as varchar(8); select @f_date = '" & FixDate(datefrom) & "'"
        sql &= vbCrLf & " declare @t_date as varchar(8); select @t_date = '" & FixDate(dateto) & "' "
        sql &= vbCrLf & " select SUM(data) as data,'ยืม' as txt from ("
        sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
        sql &= vbCrLf & " where convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
        sql &= vbCrLf & " union all"
        sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
        sql &= vbCrLf & " where borrowstatus = 'T' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
        sql &= vbCrLf & " ) as TB"
        sql &= vbCrLf & " union all"
        sql &= vbCrLf & " select SUM(data) as data,'คืน' as txt from ("
        sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROWITEM "
        sql &= vbCrLf & " where(returndate Is Not null)"
        sql &= vbCrLf & " and convert(varchar(10),returndate,112) between @f_date and @t_date"
        sql &= vbCrLf & " union all"
        sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE "
        sql &= vbCrLf & " where borrowstatus = 'R' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
        sql &= vbCrLf & " ) as TB"

        dt = SqlDB.ExecuteTable(sql)        '***************************************************************

        If CInt(dt.Rows(0).Item("data").ToString) <> 0 Or CInt(dt.Rows(1).Item("data").ToString) <> 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R018.rpt")
            rpt.SetDataSource(dt)

            rpt.DataDefinition.FormulaFields("from_date").Text = "'" & ShowDateThai(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("to_date").Text = "'" & ShowDateThai(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"

            rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmGraphByDepartment()

        'Dim departmentname As String = "xxxxxx" 
        'Dim departmentid As String = "510" 
        'Dim datefrom As String = "29/05/2012"
        'Dim dateto As String = "29/05/2012" 
        'Dim fullname As String = "DIP_R019"
        'Dim Str As String = ""

        Dim departmentname As String = Request.QueryString("departmentname")
        Dim departmentid As String = Request.QueryString("departmentid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")
        Dim Str As String = ""


        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password

        sql = "declare @f_date as varchar(8); select @f_date = '" & FixDate(datefrom) & "'"
        sql &= vbCrLf & " declare @t_date as varchar(8); select @t_date = '" & FixDate(dateto) & "' "
        sql &= vbCrLf & " declare @dpm as varchar(10); select @dpm = '" & departmentid & "'"
        sql &= vbCrLf & " select SUM(data) as data,'ยืม' as txt from ("
        sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
        sql &= vbCrLf & " left join TB_OFFICER ofc on fb.borrower_id = ofc.id"
        sql &= vbCrLf & " where convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
        sql &= vbCrLf & " and ofc.department_id = @dpm"
        sql &= vbCrLf & " Union all"
        sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
        sql &= vbCrLf & " left join TB_OFFICER ofc on re.member_id = ofc.id"
        sql &= vbCrLf & " where borrowstatus = 'T' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
        sql &= vbCrLf & " and ofc.department_id = @dpm"
        sql &= vbCrLf & " ) as TB"
        sql &= vbCrLf & " Union all"
        sql &= vbCrLf & " select SUM(data) as data,'คืน' as txt from ("
        sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
        sql &= vbCrLf & " left join TB_OFFICER ofc on fb.borrower_id = ofc.id"
        sql &= vbCrLf & " where(fbi.returndate Is Not null)"
        sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
        sql &= vbCrLf & " and ofc.department_id = @dpm"
        sql &= vbCrLf & " Union all"
        sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
        sql &= vbCrLf & " left join TB_OFFICER ofc on re.member_id = ofc.id"
        sql &= vbCrLf & " where borrowstatus = 'R' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
        sql &= vbCrLf & " and ofc.department_id = @dpm"
        sql &= vbCrLf & " ) as TB"

        dt = SqlDB.ExecuteTable(sql)


        If CInt(dt.Rows(0).Item("data").ToString) <> 0 Or CInt(dt.Rows(1).Item("data").ToString) <> 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R019.rpt")
            rpt.SetDataSource(dt)

            rpt.DataDefinition.FormulaFields("from_date").Text = "'" & ShowDateThai(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("to_date").Text = "'" & ShowDateThai(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            rpt.DataDefinition.FormulaFields("department").Text = "'" & departmentname & "'"

            rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmGraphByPatentType()

        'Dim patentid As String = "0" 
        'Dim datefrom As String = "29/05/2012" 
        'Dim dateto As String = "29/05/2012" 
        'Dim fullname As String = "DIP_R020" 
        'Dim Str As String = ""

        Dim patentid As String = Request.QueryString("patentid") ' ##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")
        Dim Str As String = ""

        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password

        sql = "declare @f_date as varchar(8); select @f_date = '" & FixDate(datefrom) & "'"
        sql &= vbCrLf & " declare @t_date as varchar(8); select @t_date = '" & FixDate(dateto) & "' "
        sql &= vbCrLf & " declare @type as varchar(10); select @type = '" & patentid & "'"
        sql &= vbCrLf & " select SUM(data) as data,'ยืม' as txt from ("
        sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
        sql &= vbCrLf & " left join TB_REQUISTION rq on fbi.requisition_id = rq.id "
        sql &= vbCrLf & " where convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
        If patentid > 0 Then
            sql &= vbCrLf & " and rq.patent_type_id  = @type"
        End If
        sql &= vbCrLf & " Union all"
        sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
        sql &= vbCrLf & " left join TB_REQUISTION rq on re.requidition_id = rq.id"
        sql &= vbCrLf & " where borrowstatus = 'T' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
        If patentid > 0 Then
            sql &= vbCrLf & " and rq.patent_type_id  = @type"
        End If
        sql &= vbCrLf & " ) as TB"
        sql &= vbCrLf & " Union all"
        sql &= vbCrLf & " select SUM(data) as data,'คืน' as txt from ("
        sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
        sql &= vbCrLf & " left join TB_REQUISTION rq on fbi.requisition_id  = rq.id"
        sql &= vbCrLf & " where(fbi.returndate Is Not null)"
        sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
        If patentid > 0 Then
            sql &= vbCrLf & " and rq.patent_type_id  = @type"
        End If
        sql &= vbCrLf & " Union all"
        sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
        sql &= vbCrLf & " left join TB_REQUISTION rq on re.requidition_id  = rq.id"
        sql &= vbCrLf & " where borrowstatus = 'R' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
        If patentid > 0 Then
            sql &= vbCrLf & " and rq.patent_type_id  = @type"
        End If
        sql &= vbCrLf & " ) as TB"
        dt = SqlDB.ExecuteTable(sql)

        If dt.Rows.Count > 0 Then
            If CInt(dt.Rows(0).Item("data").ToString) <> 0 Or CInt(dt.Rows(1).Item("data").ToString) <> 0 Then
                Dim rpt As New ReportDocument
                Dim strPath As String = Server.MapPath("~\Reports")
                rpt.Load(strPath & "\DIP_R020.rpt")
                rpt.SetDataSource(dt)

                rpt.DataDefinition.FormulaFields("from_date").Text = "'" & ShowDateThai(datefrom) & "'"
                rpt.DataDefinition.FormulaFields("to_date").Text = "'" & ShowDateThai(dateto) & "'"
                rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
                rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                If patentid = 0 Then
                    rpt.DataDefinition.FormulaFields("type").Text = "'ทั้งหมด'"
                Else
                    Dim lnq As New TbPatentTypeDAL
                    lnq.GetDataByid(patentid, Nothing)
                    If lnq.ID > 0 Then
                        rpt.DataDefinition.FormulaFields("type").Text = "'" & lnq.PATENT_TYPE_NAME & "'"
                    End If
                    lnq = Nothing
                End If

                rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
                datafound.Visible = True
                datanotfound.Visible = False
            Else
                datafound.Visible = False
                datanotfound.Visible = True
            End If
        End If
    End Sub

    Private Sub frmGraphByOfficer()
        'Dim officername As String = "จตุพล" 
        'Dim officerid As String = "2003000629" 
        'Dim datefrom As String = "08/02/2012"
        'Dim dateto As String = "08/02/2012"
        'Dim fullname As String = "DIP_R021"

        Dim officername As String = Request.QueryString("officername") '##validat
        Dim officerid As String = Request.QueryString("officerid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")


        Dim Str As String = ""
        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password
        Dim dt_ As New DataTable
        Dim username As String = ""
        sql = "select username from TB_OFFICER where id = '" & officerid & "'"
        dt_ = SqlDB.ExecuteTable(sql)
        If dt_.Rows.Count > 0 Then
            username = dt_.Rows(0).Item("username").ToString.Trim
        End If

        sql = "declare @f_date as varchar(8); select @f_date = '" & FixDate(datefrom) & "'"
        sql &= vbCrLf & " declare @t_date as varchar(8); select @t_date = '" & FixDate(dateto) & "' "
        sql &= vbCrLf & " declare @user as varchar(20); select @user = '" & username & "'"
        sql &= vbCrLf & " select SUM(data) as data,'ยืม' as txt from ("
        sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
        sql &= vbCrLf & " where convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
        sql &= vbCrLf & " and fb.createby = @user"
        sql &= vbCrLf & " union all"
        sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
        sql &= vbCrLf & " left join TB_OFFICER ofc on re.officer_id_receive = ofc.id"
        sql &= vbCrLf & " where borrowstatus = 'T' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
        sql &= vbCrLf & " and ofc.username = @user"
        sql &= vbCrLf & " ) as TB"
        sql &= vbCrLf & " union all"
        sql &= vbCrLf & " select SUM(data) as data,'คืน' as txt from ("
        sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
        sql &= vbCrLf & " where(fbi.returndate Is Not null)"
        sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
        sql &= vbCrLf & " and fbi.officer_return = @user"
        sql &= vbCrLf & " union all"
        sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
        sql &= vbCrLf & " left join TB_OFFICER ofc on re.officer_id_receive = ofc.id"
        sql &= vbCrLf & " where borrowstatus = 'R' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
        sql &= vbCrLf & " and ofc.username = @user"
        sql &= vbCrLf & " ) as TB"
        dt = SqlDB.ExecuteTable(sql)
        If CInt(dt.Rows(0).Item("data").ToString) <> 0 Or CInt(dt.Rows(1).Item("data").ToString) <> 0 Then
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\DIP_R021.rpt")
            rpt.SetDataSource(dt)

            rpt.DataDefinition.FormulaFields("from_date").Text = "'" & ShowDateThai(datefrom) & "'"
            rpt.DataDefinition.FormulaFields("to_date").Text = "'" & ShowDateThai(dateto) & "'"
            rpt.DataDefinition.FormulaFields("staff").Text = "'" & fullname & "'"
            rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            rpt.DataDefinition.FormulaFields("user").Text = "'" & officername & "'"


            rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub

    Private Sub frmTransferByLocation()
        'Dim locationname As String = "ชั้น 1" 
        'Dim locationid As String = "2"
        'Dim datefrom As String = ""
        'Dim dateto As String = "" 
        'Dim fullname As String = "rptTransferHistory"

        Dim locationname As String = Request.QueryString("locationname") '##validat
        Dim locationid As String = Request.QueryString("locationid") '##validat
        Dim datefrom As String = Request.QueryString("datefrom")
        Dim dateto As String = Request.QueryString("dateto")
        Dim fullname As String = Request.QueryString("fullname")


        Dim Str As String = ""
        sql = " SELECT "
        sql &= " LG.app_no,"
        sql &= " convert(varchar,dateadd(year,543,LG.log_date),103)  as log_date,"
        sql &= " convert(varchar,LG.log_date,108)  as log_time,"
        sql &= " FL.Location_Name  as location,"
        sql &= "'" & fullname & "'  as staff,"
        sql &= "'" & DateNowCondition() & "'  as printdate"
        sql &= " FROM TB_LOG_LOCATION LG  "
        sql &= " LEFT JOIN  TB_FILELOCATION FL ON FL.READERID = LG.READERID  where 1=1 "
        If datefrom <> "" And dateto <> "" Then
            sql &= " and convert(varchar(10),LG.log_date,112) between '" & FixDate(datefrom) & "' and '" & FixDate(dateto) & "'"
        End If
        If locationid <> 0 Then
            sql &= " and LG.readerid ='" & locationid & "'"
        End If
        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count > 0 Then
            dt.TableName = "dsTransferHistory"
            Dim rpt As New ReportDocument
            Dim strPath As String = Server.MapPath("~\Reports")
            rpt.Load(strPath & "\rptTransferHistory.rpt")
            rpt.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            datafound.Visible = True
            datanotfound.Visible = False
        Else
            datafound.Visible = False
            datanotfound.Visible = True
        End If
    End Sub
#End Region


#Region "Unity"
    Public Function DateNowCondition() As String
        Dim d As String = ""
        Dim m As String = ""
        Dim y As String = ""
        Dim dmy As Date = Date.Now
        d = dmy.Day
        m = dmy.Month
        y = dmy.Year
        If y < 2500 Then
            y = y + 543
        End If
        Return d.ToString.PadLeft(2, "0") & "/" & m.ToString.PadLeft(2, "0") & "/" & y.ToString
    End Function
    Public Function FixDate(ByVal StringDate As String) As String
        Dim d As String = ""
        Dim m As String = ""
        Dim y As String = ""
        Dim temp As String() = StringDate.Split("/")
        If temp.Length = 3 Then
            d = temp(0)
            m = temp(1)
            y = temp(2)
            If y > 2500 Then
                y = y - 543
            End If
            Return y.ToString & m.ToString.PadLeft(2, "0") & d.ToString.PadLeft(2, "0")
        Else
            Return ""
        End If
    End Function
    Public Function ShowDateThai(ByVal StringDate As String) As String
        Dim d As String = ""
        Dim m As String = ""
        Dim y As String = ""
        Dim temp As String() = StringDate.Split("/")
        If temp.Length = 3 Then
            d = temp(0)
            m = temp(1)
            y = temp(2) + 543

            Return d & "/" & m & "/" & y
        Else
            Return ""
        End If
    End Function
#End Region
End Class
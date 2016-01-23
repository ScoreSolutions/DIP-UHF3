Imports LinqDB.ConnectDB
Public Class ePatentLinqWS

#Region "ดึงข้อมูล"
    Public Shared Function GetWorkgroupList() As DataTable
        Dim ret As New DataTable
        Try
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String = "select * from workgroup"
            ret = PatentSqlDB.ExecuteTable(sql, trans.Trans)
            trans.CommitTransaction()
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
    Public Shared Function GetOfficerListByWorkgroup(WorkgroupID As Long) As DataTable
        Dim ret As New DataTable
        Try
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String = "select * from OFFICER where workgroup='" & WorkgroupID & "'"
            ret = PatentSqlDB.ExecuteTable(sql, trans.Trans)
            trans.CommitTransaction()
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
    'สถานะ แฟ้ม
    Public Shared Function GetStatus() As DataTable
        Dim ret As New DataTable
        Try
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String = "select distinct ID as status_code,PROCESS as status_name,[STATUS] as description from  [192.168.180.75].PATENTSYSTEM.dbo.[STATUS]"
            ret = PatentSqlDB.ExecuteTable(sql, trans.Trans)
            trans.CommitTransaction()
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
    'สถานที่เก็บ แฟ้ม
    Public Shared Function GetFilaLocation() As DataTable
        Dim ret As New DataTable
        Try
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String = "select distinct ID as location_code,LOCATIONNAME as location_name, description from [192.168.180.75].PATENTSYSTEM.dbo.[FILELOCATION]"
            ret = PatentSqlDB.ExecuteTable(sql, trans.Trans)
            trans.CommitTransaction()
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
    'สถานที่เก็บปัจจุบัน แฟ้ม
    Public Shared Function GetFilaStore() As DataTable
        Dim ret As New DataTable
        Try
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String = "select distinct ID as filestore_code,app_no, filelocation from  [192.168.180.75].PATENTSYSTEM.dbo.[FILESTORE]"
            ret = PatentSqlDB.ExecuteTable(sql, trans.Trans)
            trans.CommitTransaction()
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
    'ตำแหน่งพนักงาน
    Public Shared Function GetPosition() As DataTable
        Dim ret As New DataTable
        Try
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String = "select distinct ID as position_code,name as position_name from [192.168.180.75].PATENTSYSTEM.dbo.POSITION"
            ret = PatentSqlDB.ExecuteTable(sql, trans.Trans)
            trans.CommitTransaction()
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
    'พนักงาน
    Public Shared Function GetOfficer() As DataTable
        Dim ret As New DataTable
        Try
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String
            sql = " select distinct A.ID as officer_no,"
            sql &= " B.title_code as title_id,"
            sql &= " FNAME,LNAME,"
            sql &= " WORKGROUP as department_id,"
            sql &= " POSITION as position_id"
            sql &= " from [192.168.180.75].PATENTSYSTEM.dbo.OFFICER A"
            sql &= " LEFT JOIN RFID.dbo.TB_TITLE B"
            sql &= " on rtrim(ltrim(A.TITLENAME)) = rtrim(ltrim(b.title_name))"
            sql &= " where isnull(A.TITLENAME,'') + isnull(FNAME,'') + isnull(LNAME,'') <> ''"
            ret = PatentSqlDB.ExecuteTable(sql, trans.Trans)
            trans.CommitTransaction()
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
    'แฟ้ม
    Public Shared Function GetRequistion() As DataTable
        Dim ret As New DataTable
        Try
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim yy2 As String = Date.Now.Year.ToString.Substring(2, 2)
            Dim yy1 As String = CStr(CInt(yy2) - 1).PadLeft(2, "0")
            Dim yy3 As String = CStr(CInt(yy2) + 1).PadLeft(2, "0")

            Dim sql As String
            sql = " select app_no,MAX(NAME) AS [app_name],PAT_TYPE AS patent_type_id,app_status from [192.168.180.75].PATENTSYSTEM.dbo.REQUISITION"
            sql &= " where ISNULL(APP_NO,'') <> '' and APP_NO <> '0' "
            sql &= " AND (" & yy1 & " IS NULL OR " & yy2 & "  IS NULL OR " & yy3 & "  IS NULL OR app_no LIKE " & yy1 & "  + '%' or app_no " & yy2 & "  + '%' or app_no LIKE " & yy3 & "  + '%')"
            sql &= " GROUP BY APP_NO,PAT_TYPE,app_status "
            sql &= " order by APP_NO"
            ret = PatentSqlDB.ExecuteTable(sql, trans.Trans)
            trans.CommitTransaction()
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
    'แฟ้มที่จอง
    Public Shared Function GetFileitemborrow() As DataTable
        Dim ret As New DataTable
        Try
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String
            sql = " select ID,CREATEON as create_date,APP_NO,BORROWERID as member_id,BORROWNAME as member_name,borrowstatus"
            sql &= " ,ROW_NUMBER() OVER(PARTITION BY APP_NO ORDER BY RESERVEDATE ASC) AS reserve_order"
            sql &= " ,CONVERT(varchar(8),CREATEON,112) as CreateDate"
            sql &= " ,CONVERT(varchar(8),CREATEON,114) as CreateTime"
            sql &= " from [192.168.180.75].PATENTSYSTEM.dbo.FILEBORROWITEM"
            sql &= " where  BORROWSTATUS = 'S' " 'AND (@DATE IS NULL OR DATEDIFF(D,RESERVEDATE,@DATE) = 0)"
            sql &= " union all"
            sql &= " select ID,CREATEON as create_date,APP_NO,BORROWERID as member_id,BORROWNAME as member_name,borrowstatus"
            sql &= " ,1 as reserve_order"
            sql &= " ,CONVERT(varchar(8),CREATEON,112) as CreateDate"
            sql &= " ,CONVERT(varchar(8),CREATEON,114) as CreateTime"
            sql &= " from [192.168.180.75].PATENTSYSTEM.dbo.FILEBORROWITEM"
            sql &= " where  BORROWSTATUS = 'T' " 'AND (@DATE IS NULL OR DATEDIFF(D,RESERVEDATE,@DATE) = 0)"
            sql &= " order by APP_NO"
            ret = PatentSqlDB.ExecuteTable(sql, trans.Trans)
            trans.CommitTransaction()
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
#End Region

#Region "Update ข้อมูล"
    'Update สถานะยืม
    Public Shared Function SetUpdateborrow(id As String, officerId As String) As Boolean
        Dim ret As Boolean
        Try
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String
            sql = "  update  [192.168.180.75].PATENTSYSTEM.dbo.FILEBORROWITEM set "
            sql &= "  STARTSTATUS = 'B',"
            sql &= "  BORROWSTATUS = 'B',"
            sql &= "  [GETDATE] = GETDATE(),"
            sql &= "  BORROWDATE = GETDATE(),"
            sql &= "  OFFICERAPPROVE = " & officerId
            sql &= "  where ID = " & id
            ret = PatentSqlDB.ExecuteNonQuery(sql, trans.Trans)
            trans.CommitTransaction()
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function
    'Update สถานะคืน
    Public Shared Function SetUpdatereturn(id As String, officerId As String) As Boolean
        Dim ret As Boolean
        Try
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String
            sql = " update  [192.168.180.75].PATENTSYSTEM.dbo.FILEBORROWITEM set "
            sql &= " BORROWSTATUS = 'R',"
            sql &= " RETURNDATE = GETDATE(),"
            sql &= " OFFICERRETURN = " & officerId & ","
            sql &= " ENDSTATUS = 'R'"
            sql &= " where ID = " & id
            ret = PatentSqlDB.ExecuteNonQuery(sql, trans.Trans)
            trans.CommitTransaction()
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function
    'Update สถานที่
    Public Shared Function SetUpdatefilestore(app_no As String, locationid As String) As Boolean
        Dim ret As Boolean
        Try
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String
            sql = " update [192.168.180.75].PATENTSYSTEM.dbo.FILESTORE set "
            sql &= " filelocation = " & locationid & ","
            sql &= " updateon = GETDATE()"
            sql &= " where app_no = " & app_no & ";"
            sql &= " update TB_FILESTORE set"
            sql &= " filelocation = " & locationid & ","
            sql &= " updateon = GETDATE()"
            sql &= " where app_no = " & app_no & ";"
            ret = PatentSqlDB.ExecuteNonQuery(sql, trans.Trans)
            trans.CommitTransaction()
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function
#End Region
End Class

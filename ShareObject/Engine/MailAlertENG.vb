Imports System.Net.Mail
Imports LinqDB.TABLE
Imports LinqDB.ConnectDB
Public Class MailAlertENG

    'Email Connection Informaion
    Private Shared SMTPServer As String = GlobalFunction.GetSysConfing("SMTPServer")
    Private Shared SMTPMailFrom As String = GlobalFunction.GetSysConfing("SMTPMailFrom")
    Private Shared SMTPPassword As String = GlobalFunction.GetSysConfing("SMTPPassword")
    Private Shared MailPort As String = GlobalFunction.GetSysConfing("MailPort")
    Private Shared MailSSL As Boolean = GlobalFunction.GetSysConfing("MailSSL")

    'สำหรับเครื่อง Production
    'Private Shared SMTPServer As String = "smtp.ipthailand.go.th"
    'Private Shared SMTPMailFrom As String = "rfid@ipthailand.go.th"
    'Private Shared SMTPPassword As String = "1qaz@WSX"
    'Private Shared MailPort As String = "25"
    'Private Shared MailSSL As Boolean = False

    'MailServer : smtp.ipthailand.go.th  หรือ 164.115.3.136
    'MailFrom : rfid@ipthailand.go.th
    'Password : 1qaz@WSX
    'MailPort : 25
    'MailSSL : False

    'Duedate Config Information
    Private Shared AlertBorrowBeforeDueDate As String = GlobalFunction.GetSysConfing("AlertBorrowBeforeDueDate")
    Private Shared AlertBorrowOverDueDate As String = GlobalFunction.GetSysConfing("AlertBorrowOverDueDate")

    Public Shared Sub SentMailAlert()
        Try
            Dim cDt As DataTable = BuiltConfigData()
            If cDt.Rows.Count > 0 Then
                'GetFileBorrowBeforeDueDateList(cDt)
                GetFileBorrowOverDueDateList(cDt)
            End If
            cDt.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function BuiltConfigData() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("patent_type_id")
        dt.Columns.Add("AlertBorrowBeforeDueDate")
        dt.Columns.Add("AlertBorrowOverDueDate")

        Try
            If AlertBorrowBeforeDueDate.Trim = "" Then
                AlertBorrowBeforeDueDate = "1|7##2|7##3|7"
            End If

            If AlertBorrowOverDueDate.Trim = "" Then
                AlertBorrowOverDueDate = "1|90##2|90##3|90"
            End If

            For Each tmpConfig As String In Split(AlertBorrowBeforeDueDate, "##")
                Dim bConfig() As String = Split(tmpConfig, "|")
                Dim ConfigPatentType As String = bConfig(0)
                Dim ConfigBeforeDueDate As String = bConfig(1)

                Dim dr As DataRow = dt.NewRow
                dr("patent_type_id") = ConfigPatentType
                dr("AlertBorrowBeforeDueDate") = ConfigBeforeDueDate

                For Each tmpOver As String In Split(AlertBorrowOverDueDate, "##")
                    Dim oConfig() As String = Split(tmpOver, "|")
                    If oConfig(0) = ConfigPatentType Then
                        dr("AlertBorrowOverDueDate") = oConfig(1)
                    End If
                Next
                dt.Rows.Add(dr)
            Next
        Catch ex As Exception
            dt = New DataTable
            LogFile.LogENG.SaveErrLog("MailAlertENG.BuiltConfigData", "Exception " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return dt
    End Function

    Private Shared Sub GetFileBorrowBeforeDueDateList(cDt As DataTable)
        Try
            Dim tSql As String = ""
            For Each cDr As DataRow In cDt.Rows
                Dim ConfigBeforDueDate As Integer = Convert.ToInt16(cDr("AlertBorrowOverDueDate")) - Convert.ToInt16(cDr("AlertBorrowBeforeDueDate"))
                Dim Sql As String = "select fb.fileborrowitem_id, fb.borrowdate, fb.borrower_name, o.email, fb.app_no, pt.patent_type_name,  " & vbNewLine
                Sql += " '" & cDr("AlertBorrowOverDueDate") & "' AlertBorrowOverDueDate" & vbNewLine
                Sql += " from TMP_FILEBORROWITEM fb" & vbNewLine
                Sql += " inner join TB_REQUISTION r on r.app_no=fb.app_no " & vbNewLine
                Sql += " inner join TB_PATENT_TYPE pt on pt.id=r.patent_type_id" & vbNewLine
                Sql += " inner join TB_OFFICER o on o.id=fb.borrower_id" & vbNewLine
                Sql += " where borrower_id<>0" & vbNewLine
                Sql += " and dateadd(d," & ConfigBeforDueDate & ",fb.borrowdate)<getdate()" & vbNewLine
                Sql += " and r.patent_type_id='" & cDr("patent_type_id") & "'" & vbNewLine
                Sql += " and o.email is not null " & vbNewLine

                If tSql = "" Then
                    tSql = Sql
                Else
                    tSql += " Union all " & vbNewLine & Sql
                End If
            Next

            ProcessSentEmailAlert(tSql, "1")
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("MailAlertENG.GetFileBorrowBeforeDueDateList", "Exception " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Shared Sub GetFileBorrowOverDueDateList(cDt As DataTable)
        Try
            Dim tSql As String = ""
            For Each cDr As DataRow In cDt.Rows
                Dim Sql As String = "select fb.fileborrowitem_id, fb.borrowdate, fb.borrower_name, o.email, fb.app_no, pt.patent_type_name,  " & vbNewLine
                Sql += " '" & cDr("AlertBorrowOverDueDate") & "' AlertBorrowOverDueDate" & vbNewLine
                Sql += " from TMP_FILEBORROWITEM fb" & vbNewLine
                Sql += " inner join TB_REQUISTION r on r.app_no=fb.app_no " & vbNewLine
                Sql += " inner join TB_PATENT_TYPE pt on pt.id=r.patent_type_id" & vbNewLine
                Sql += " inner join TB_OFFICER o on o.id=fb.borrower_id" & vbNewLine
                Sql += " where borrower_id<>0" & vbNewLine
                Sql += " and dateadd(d," & Convert.ToInt16(cDr("AlertBorrowOverDueDate")) & ",fb.borrowdate)<getdate()" & vbNewLine
                Sql += " and r.patent_type_id='" & cDr("patent_type_id") & "'" & vbNewLine
                Sql += " and o.email is not null " & vbNewLine

                If tSql = "" Then
                    tSql = Sql
                Else
                    tSql += " Union all " & vbNewLine & Sql
                End If
            Next

            ProcessSentEmailAlert(tSql, "2")
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("MailAlertENG.GetFileBorrowOverDueDateList", "Exception " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Shared Sub ProcessSentEmailAlert(tSql As String, MailAlertType As String)
        Dim dt As DataTable = GlobalFunction.GetDatatable(tSql)
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                If Convert.IsDBNull(dr("email")) = False Then
                    Dim smLnq As New TsSendMailAlertDuedateLinqDB
                    smLnq.ChkDataByMAIL_ALERT_TYPE_TB_FILEBORROWITEM_ID(MailAlertType, dr("fileborrowitem_id"), Nothing)
                    If smLnq.ID = 0 Then
                        Dim ret As Boolean = False
                        Dim IsSentMail As Boolean = False
                        'ถ้าไม่มีข้อมูลก็ส่งเมล์เลย
                        Dim DueDate As DateTime = DateAdd(DateInterval.Day, dr("AlertBorrowOverDueDate"), Convert.ToDateTime(dr("borrowdate")))

                        If MailAlertType = "1" Then
                            If DueDate >= DateTime.Now Then
                                IsSentMail = True
                            End If
                        Else
                            IsSentMail = True
                        End If
                        If IsSentMail = True Then
                            Dim MailSubject As String = "แจ้งเตือนสถานะการยืมแฟ้ม"
                            Dim MailContent As String = CreateMailContent(dr("borrower_name"), dr("patent_type_name"), dr("app_no"), dr("borrowdate"), DueDate, MailAlertType)
                            ret = SentMail(dr("email"), MailSubject, MailContent)
                        Else
                            ret = True
                        End If

                        If ret = True Then
                            SaveSendMailAlertDuedate(dr("fileborrowitem_id"), dr("borrower_name"), dr("borrowdate"), DueDate, dr("email"), MailAlertType, dr("app_no"), dr("patent_type_name"))
                        End If
                    End If
                    smLnq = Nothing
                End If
            Next
        End If
        dt.Dispose()
    End Sub

    Private Shared Function CreateMailContent(BorrowerName As String, PatentTypeName As String, AppNo As String, BorrowDate As DateTime, DueDate As DateTime, MailAlertType As String) As String
        Dim ret As String = ""
        Try
            Dim vBorrowDate As String = BorrowDate.ToString("dd", New Globalization.CultureInfo("th-TH"))
            vBorrowDate += " เดือน " & BorrowDate.ToString("MMMM", New Globalization.CultureInfo("th-TH"))
            vBorrowDate += " พ.ศ. " & BorrowDate.ToString("yyyy", New Globalization.CultureInfo("th-TH"))

            Dim DateQty As Int16 = DateDiff(DateInterval.Day, BorrowDate, DateTime.Now)

            'Dim vDueDate As String = DueDate.ToString("dd MMMM yyyy", New Globalization.CultureInfo("th-TH"))

            If MailAlertType = "1" Then  'แจ้งเตือนก่อนถึงกำหนดคืน
                'ret += "เรียนคุณ " & BorrowerName & "<br />"
                'ret += "    ตามที่ท่านได้ขอยืมแฟ้ม" & PatentTypeName & " เลขที่แฟ้ม " & AppNo & " ไปเมื่อวันที่ " & vBorrowDate & " นั้น <br />"
                'ret += "ขณะนี้ใกล้จะครบกำหนดที่จะต้องคืนแฟ้มแล้ว ซึ่งแฟ้มหมายเลข " & AppNo & " จะครบกำหนดที่จะต้องคืนในวันที่ " & vDueDate & "<br />"
                'ret += "<br />"
                'ret += "จึงเรียนมาเพื่อทราบ<br />"
                'ret += "<br />"
                'ret += "[เมล์ฉบับนี้เป็นระบบแจ้งเตือนอัตโนมัติจากระบบ กรุณาอย่าตอบกลับ]"
            ElseIf MailAlertType = "2" Then  'แจ้งเตือนเกินกำหนดคืน
                ret += "เมลล์นี้เป็นระบบแจ้งเตือนอัตโนมัติ ส่งโดยระบบการยืม-คืนและรักษาความปลอดภัยแฟ้มคำขอรับสิทธิบัตร/อนุสิทธิบัตร<br />"
                ret += "<br />"
                ret += "เรียนคุณ " & BorrowerName & "<br />"
                ret += "    ตามที่ท่านได้ขอยืมแฟ้ม เลขที่คำขอ " & AppNo & " เมื่อวันที่ " & vBorrowDate & " นั้น <br />"
                ret += "ขณะนี้ท่านได้ยืมแฟ้มนี้เป็นระยะเวลา " & DateQty & "วันแล้ว หากท่านไม่ได้ดำเนินการใดๆ กับแฟ้มคำขอดังกล่าว โปรดส่งคืนห้องแฟ้ม<br />"
                ret += "เพื่อความปลอดภัยของแฟ้มคำขอ"
                ret += "<br />"
                ret += "    หากท่านไม่ได้ถือครองแฟ้มเลขที่ดังกล่าวแล้ว โปรดติดต่อเจ้าหน้าที่ห้องแฟ้ม เพื่อดำเนินการแก้ไขสถานะ<br />"
                ret += "ยืม/คืน ให้ถูกต้อง หรือท่านกำลังดำเนินการตรวจสอบแฟ้มคำขอนี้อยู่ ระบบต้องขออภัยมา ณ ที่นี้<br />"
                ret += "<br />"
                ret += "จึงเรียนมาเพื่อทราบ<br />"
                ret += "[เมลล์นี้ส่งโดยระบบอัตโนมัติ กรุณาอย่าตอบกลับ]"
            End If
        Catch ex As Exception
            ret = ""
        End Try
        Return ret
    End Function

    Private Shared Function SaveSendMailAlertDuedate(FileBorrowItemID As Long, BorrowName As String, BorrowDate As DateTime, DueDate As DateTime, Email As String, MailAlertType As String, AppNo As String, PatentTypeName As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New TsSendMailAlertDuedateLinqDB
            lnq.TB_FILEBORROWITEM_ID = FileBorrowItemID
            lnq.BORROWER_NAME = BorrowName
            lnq.BORROW_DATE = BorrowDate
            lnq.DUE_DATE = DueDate
            lnq.EMAIL = Email
            lnq.MAIL_ALERT_TYPE = MailAlertType
            lnq.SENT_MAIL_DATE = DateTime.Now
            lnq.APP_NO = AppNo
            lnq.PATENT_TYPE_NAME = PatentTypeName
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            ret = lnq.InsertData("MailAlertENG.SaveSendMailAlertDuedate", trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                LogFile.LogENG.SaveErrLog("MailAlertENG.SaveSendMailAlertDuedate", lnq.ErrorMessage)
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = False
            LogFile.LogENG.SaveErrLog("MailAlertENG.SaveSendMailAlertDuedate", "Exception " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Private Shared Function SentMail(MailTo As String, MailSubject As String, MailContent As String) As Boolean
        Dim ret As Boolean = False
        Dim Mail As New MailMessage
        Dim SMTP As New SmtpClient(SMTPServer)
        Try
            Mail.Subject = MailSubject
            Mail.From = New MailAddress(SMTPMailFrom, "rfid@ipthailand.go.th")
            SMTP.Credentials = New System.Net.NetworkCredential(SMTPMailFrom, SMTPPassword) '<-- ชื่อเมลที่เราจะใช้ส่ง และรหัส 
            SMTP.Timeout = 20000
            Mail.To.Add(MailTo) 'I used ByVal here for address
            Mail.IsBodyHtml = True

            Mail.Body = MailContent 'Message Here
            SMTP.EnableSsl = MailSSL
            SMTP.Port = MailPort
            Mail.BodyEncoding = System.Text.Encoding.UTF8
            SMTP.Send(Mail)
            ret = True
        Catch ex As Exception
            ret = False
            LogFile.LogENG.SaveErrLog("MailAlertENG.SentMailAlert", "Exception " & ex.Message & vbNewLine & ex.StackTrace)
        Finally
            Mail.Dispose()
            SMTP.Dispose()
        End Try
        Return ret
    End Function
End Class

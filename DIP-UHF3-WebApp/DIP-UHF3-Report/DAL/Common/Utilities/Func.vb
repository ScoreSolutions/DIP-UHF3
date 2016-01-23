Imports System.Security.Cryptography
Imports System.Text
Imports DIP_RFID.DAL.Table
Imports System.Data.SqlClient

Namespace Common.Utilities
    Public Class Func

        Const encryptKey As String = "DiPRfId"
        Private Shared IV() As Byte = {10, 20, 30, 40, 50, 60, 70, 80}
        Public Shared Function GetEncrypt(ByVal text As String) As String
            Dim tdsp As New TripleDESCryptoServiceProvider
            Dim md5csp = New MD5CryptoServiceProvider
            Dim buffer As Byte() = Encoding.ASCII.GetBytes(text)
            tdsp.Key = md5csp.ComputeHash(ASCIIEncoding.ASCII.GetBytes(encryptKey))
            tdsp.IV = IV
            Return Convert.ToBase64String(tdsp.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length))
        End Function
        Public Shared Function GetDecrypt(ByVal text As String) As String
            Dim tdsp As New TripleDESCryptoServiceProvider
            Dim md5csp = New MD5CryptoServiceProvider
            Dim buffer As Byte() = Encoding.ASCII.GetBytes(text)
            buffer = Convert.FromBase64String(text)
            tdsp.Key = md5csp.ComputeHash(ASCIIEncoding.ASCII.GetBytes(encryptKey))
            tdsp.IV = IV
            Return Encoding.ASCII.GetString(tdsp.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length))
        End Function

        Public Shared Function GetSetupValue(ByVal SetupName As String, ByVal trans As SqlTransaction) As String
            Dim ret As String = ""
            Dim dal As New TbSetupDAL
            Dim dt As DataTable = dal.GetDataList("setup_name = '" & SetupName & "'", "", trans)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows(0)("setup_value").ToString
            End If
            Return ret
        End Function

        Public Shared Function ChkUserPermission(ByVal OfficerID As Long, ByVal PermissionID As Integer, ByVal trans As SqlTransaction) As Boolean
            'ตรวจสอบว่าผู้ใช้มีสิทธิ์ตามกลุ่มที่ต้องการค้นหาหรือไม่
            Dim ret As Boolean = False
            Dim oDal As New TbOfficerDAL
            oDal.GetDataByid(OfficerID, trans)

            Dim pDal As New TbPermissionOfficerDAL
            Dim dt As DataTable = pDal.GetDataList("permission_id=" & PermissionID & " and officer_id = " & OfficerID, "", trans)
            If dt.Rows.Count > 0 Then
                ret = True
            End If

            Return ret
        End Function

        Public Shared Function ChkUserMenu(ByVal OfficerID As Long, ByVal MenuID As Integer, ByVal trans As SqlTransaction) As Boolean
            'ตรวจสอบว่าผู้ใช้มีสิทธิ์เข้าเมนูที่ต้องการค้นหาหรือไม่
            Dim ret As Boolean = False
            Dim oDal As New TbOfficerDAL
            oDal.GetDataByid(OfficerID, trans)

            Dim mDal As New OfficerMenuListDAL
            Dim dt As DataTable = mDal.GetDataList("officer_id = " & OfficerID & " and menu_id = " & MenuID, "", trans)
            If dt.Rows.Count > 0 Then
                ret = True
            End If

            Return ret
        End Function

        Public Shared Function UpdateStatusToInnova(ByVal status As String, ByVal refInnovaId As String, ByVal UserId As String, ByVal REQUISITION_ID As String) As Boolean
            'สำหรับการ Update สถานะการยืม-คืน กลับไปยังระบบของ Innova
            'status = B คือการยืมที่ห้องแฟ้ม
            'status = R คือ การคืนแฟ้มที่ห้องแฟ้ม
            Dim ret As Boolean = True
            Dim sql As String = ""
            Dim dt As New DataTable
            Try
                If status = "B" Then
                    sql = "exec UPDATEBORROW '" & refInnovaId & "','" & UserId & "'"
                    SqlDB.ExecuteTable(sql)
                    ret = True
                ElseIf status = "R" Then
                    dt = New DataTable
                    sql = "select id,ref_innova_id from TB_RESERVE where requidition_id = '" & REQUISITION_ID & "' and borrowstatus = 'T' and reserve_status = 'Y'"
                    dt = SqlDB.ExecuteTable(sql)
                    If dt.Rows.Count > 0 Then
                        sql = "exec UPDATERETURN '" & dt.Rows(0).Item("ref_innova_id").ToString & "','" & UserId & "'"
                        SqlDB.ExecuteTable(sql)
                        sql = "Update TB_RESERVE set reserve_status = 'N' where id = '" & dt.Rows(0).Item("id").ToString & "' and borrowstatus = 'T'"
                        SqlDB.ExecuteTable(sql)
                        ret = True
                    Else
                        sql = "exec UPDATERETURN '" & refInnovaId & "','" & UserId & "'"
                        SqlDB.ExecuteTable(sql)
                        ret = True
                    End If
                End If
            Catch ex As Exception
                ret = False
            End Try



            Return ret

        End Function

        Public Shared Function InsertModuleTemp(ByVal reader_id As String, ByVal TAG_ID As String) As Boolean
            Dim IsInsert As Boolean = True
            Dim dt As New DataTable

            Try
                Dim Trans As New SqlTransactionDB
                Trans.CreateTransaction()
                Dim tbreq As New TbRequisitionDAL
                Dim dtReq As New DataTable
                'dtReq = tbreq.GetListBySql("Select App_No From TB_REQUISTION WHERE App_No='" & TAG_ID & "'", "", Trans.Trans)
                'TAG_ID = ""
                '  If dtReq.Rows.Count > 0 Then
                Dim tmp As New TmpGateReaderTagDAL
                tmp.READER_ID = reader_id
                tmp.TAG_ID = TAG_ID
                tmp.READ_TYPE = IsModule()

                Dim a = tmp.InsertData(reader_id, Trans.Trans)
                'End If
                Trans.CommitTransaction()
            Catch ex As Exception
                IsInsert = False
            End Try

            Return IsInsert

        End Function


        '1 = ยืม,2 = คืน,3 ย้าย
        Public Shared Function IsModule() As String

            Dim ret As String = "0"
            Try
                Dim sqlDB As New SqlDB
                Dim dt As DataTable = sqlDB.ExecuteTable("SELECT  TOP 1 SetAction FROM TB_SETMODULE where readerid=" & GetReaderId())
                If dt.Rows.Count > 0 Then
                    ret = dt.Rows(0)("SetAction")
                Else
                    ret = "0"
                End If
                ret = "0"
                Return ret

            Catch ex As Exception

            End Try

            Return ret
        End Function

        Public Shared Function GetReaderId()
            Dim INIFlieName As String = "C:\Windows\DIP.ini"
            Dim ini As New IniReader(INIFlieName)
            ini.Section = "SETTING"
            If Dir(INIFlieName) <> "" Then
                Return ini.ReadString("ReaderId") & ""
            Else
                Return "0"
            End If
        End Function

        'Set Module
        Public Shared Function IsUpdateActionModule(ByVal Type As String, ByVal ID As String) As Boolean
            Dim IsUpdate As Boolean = True
            Try

                Dim sql As String
                'sql = "Update TB_SETMODULE set SETACTION = " & Type & " where readerid = '" & GetReaderId() & "';"
                ' sql &= " Update TB_CONFIG set TYPE = " & Type & " where reader_id = '" & GetReaderId() & "'"


                sql = " Update TB_CONFIG set Type = '" & Type & "' where id = '" & ID & "'"


                SqlDB.ExecuteNonQuery(sql)



            Catch ex As Exception
                IsUpdate = False
            End Try

            Return IsUpdate
        End Function

    End Class
End Namespace
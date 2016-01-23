Imports System.Data
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.IO


Namespace Web_Config
    Public Class UserEng

        Dim _err As String = ""

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err.Trim()
            End Get
        End Property

        Public Function CheckDuplicateUser(ByVal id As Long, ByVal idcard As String, ByVal username As String, ByVal mobile As String) As Boolean

            Dim ret As Boolean = False
            Dim lnq As New TbUserLinqDB
            Dim trans As New TransactionDB

            ret = lnq.ChkDataByWhere("ID_Card = '" & idcard & "' and id <>'" & id & "'", trans.Trans)
            If ret = False Then

                ret = lnq.ChkDataByWhere("UserName = '" & username & "' and id <>'" & id & "'", trans.Trans)
                If ret = False Then

                    ret = lnq.ChkDataByWhere("mobile_no = '" & mobile & "' and id <> '" & id & "'", trans.Trans)
                    If ret = True Then

                        _err = "alert('Mobile No. Repeated !');"

                    End If
                Else
                    _err = "alert('Username Repeated !');"
                End If

            Else
                _err = "alert('ID Card Repeated !');"

            End If
            trans.CommitTransaction()
            lnq = Nothing

            Return ret


        End Function


        Public Function GetgvUser(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbUserLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = ("Select id, FirstName+'  '+LastName as name,case when gender > 1 then 'Female' else 'Male' END AS gender,mobile_no,active_status from TB_User") + wh
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetdrpRole() As DataTable

            Dim dt As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRoleLinqDB
            dt = lnq.GetDataList("active_status='Y'", "role_desc", trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt

        End Function


        Public Function CheckDuplicateGroup(ByVal id As Long, ByVal group_code As String, ByVal group_desc As String) As Boolean

            Dim ret As Boolean = False
            Dim lnq As New TbGroupLinqDB
            Dim trans As New TransactionDB

            ret = lnq.ChkDataByWhere("group_code = '" & group_code & "' and id <>'" & id & "'", trans.Trans)
            If ret = False Then

                ret = lnq.ChkDataByWhere("group_desc = '" & group_desc & "' and id <>'" & id & "'", trans.Trans)
                If ret = True Then

                    _err = "alert('Description Repeated !');"
                End If

            Else

                _err = "alert('Group Code Repeated !');"
            End If
            trans.CommitTransaction()
            lnq = Nothing

            Return ret


        End Function


        Public Function GetgvGroupList(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbGroupLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = ("Select id,group_code ,group_desc,active_status from TB_GROUP where id <> 0 ") + wh
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetgvShowServer(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB
            Dim sql As String
            sql = ("Select id,ServerName,ServerIP  ,LocationServer  +' / '+ LocationNo as Location , MacAddress from TB_REGISTER where group_id = '" & wh & "' and group_id <> '0' and Active_Status = 'Y' Order by ServerName")
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function


        Public Function GetdrpGroup() As DataTable

            Dim dt As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbGroupLinqDB
            dt = lnq.GetDataList("active_status='Y' and group_desc <> 'NoGroup' ", "group_desc", trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt

        End Function

        'Public Function GetdrpServerIP(ByRef wh As String) As DataTable

        '    Dim dt As DataTable
        '    Dim trans As New TransactionDB
        '    Dim lnq As New TbIamAliveLinqDB
        '    If wh <> "" Then
        '        wh = " and " + wh
        '    End If
        '    Dim sql As String
        '    sql = ("Select * from TB_IAM_ALIVE where ServerName not in (Select ServerName from TB_Register) Order by id ") + wh
        '    dt = lnq.GetListBySql(sql, trans.Trans)
        '    trans.CommitTransaction()
        '    lnq = Nothing
        '    Return dt

        'End Function


        Public Function CheckDuplicateRegister(ByVal id As Long, ByVal ServerIP As String, ByVal ServerName As String, ByVal MacAddress As String) As Boolean

            Dim ret As Boolean = False
            Dim lnq As New TbRegisterLinqDB
            Dim trans As New TransactionDB

            ret = lnq.ChkDataByWhere("ServerIP = '" & ServerIP & "' and id <>'" & id & "'", trans.Trans)
            If ret = False Then

                ret = lnq.ChkDataByWhere("ServerName = '" & ServerName & "' and id <>'" & id & "'", trans.Trans)
                If ret = False Then

                    ret = lnq.ChkDataByWhere("MacAddress = '" & MacAddress & "' and id <>'" & id & "'", trans.Trans)
                    If ret = False Then
                        _err = "alert('Mac Address Repeated !');"

                    End If
                Else
                    _err = "alert('Server Name Repeated !');"
                End If
            Else
                _err = "alert('Server IP Repeated !');"

            End If
                trans.CommitTransaction()
                lnq = Nothing

                Return ret


        End Function

        Public Function GetgvRegister(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = "Select id,ServerIP,ServerName,OS,E_mail,Fname + '  ' + Lname as name ,System_Type,Active_Status from TB_REGISTER where 1=1 " + wh
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function



        Public Function CheckDuplicateRole(ByVal id As Long, ByVal role_code As String, ByVal role_desc As String) As Boolean

            Dim ret As Boolean = False
            Dim lnq As New TbRoleLinqDB
            Dim trans As New TransactionDB

            ret = lnq.ChkDataByWhere("role_code = '" & role_code & "' and id <>'" & id & "'", trans.Trans)
            If ret = False Then

                ret = lnq.ChkDataByWhere("role_desc = '" & role_desc & "' and id <>'" & id & "'", trans.Trans)
                If ret = True Then

                    _err = "alert('Description Repeated !');"
                End If

            Else
                _err = "alert('Role Code Repeated !');"

            End If
            trans.CommitTransaction()
            lnq = Nothing

            Return ret


        End Function

        Public Function GetgvRole(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRoleLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = ("Select id,role_code,role_desc,active_status from TB_ROLE  ") + wh
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function


        Public Function GetgvResponsibility(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbResponsibilityLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = ("Select id,responsibility_desc  from TB_RESPONSIBILITY ") + wh
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function


        Public Function GetgvServer(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = ("Select id, ServerName,ServerIP  ,LocationServer  +' / '+ LocationNo as Location , MacAddress  from TB_REGISTER where group_id = '0' and Active_Status='Y' Order by ServerName") + wh
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function


    End Class

End Namespace


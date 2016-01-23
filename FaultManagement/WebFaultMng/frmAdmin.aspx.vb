Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Script.Services

Partial Class frmAdmin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'SetdrpGroup()  ' ใส่ค่า GroupName ใน dropdownlist อยู่ใน Tab Register
            SetdrpRole()  ' ใส่ค่า Role Desc ใน dropdownlist อยู่ใน Tab User
            SetgvUser()  ' ใส่ข้อมูล User ลงใน datagridview
            'SetgvGroupList() 'ใส่ข้อมูล Group ลงใน datagridview
            'SetgvRegister()   ' ใส่ข้อมูลจากตาราง Register ลงใน datagridview 
            SetgvRoleList()   ' ใส่ข้อมูล Role ลงใน datagridview
            'ImageButton1.Attributes.Add("onclick", "showModal('frmPopupAddServer.aspx',600,400,0)")  ' ปุ่ม Show Popup เพื่อเพิ่มข้อมูล Server ให้กับ Group อยู่ใน Tab Gruop > Group desc link
            SetgvResponsibility() ' ใสข้อมูล Responsibility ลงใน datagridview
        End If

        'If Session("SaveServer") = True Then  ' ค่า Session นี้ มาจากปุ่ม Add Server ใน Tab Group ถ้าค่านี้ถูก บันทึก Session จะ เท่ากับ true
        'SetgvShowServer()  ' แล้วเข้าฟังก์ชันนี้เพื่อ refresh gridview หลังจากเพิ่มข้อมูล
        'Session.Remove("SaveServer")
        'End If



    End Sub

    Private Function Validations() As Boolean 'Check Validate of User ถ้า textbox ที่จำเป็นมีค่าว่าง ให้แสดงข้อความ alert

        If txtFirstname.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify First Name !');", True)
            Return False
        End If

        If txtLastname.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Last Name !');", True)
            Return False
        End If

        If txtIDcard.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify ID Card !');", True)
            Return False
        End If

        If txtIDcard.Text.Trim() = "0000000000000" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Check ID Card !');", True)
            Return False
        End If

        If txtIDcard.Text.Length < 13 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('ID Card Incorrect !');", True)
            Return False
        End If

        If txtMobile.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Mobile !');", True)
            Return False
        End If

        If chkMale.Checked = False And chkFemale.Checked = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Choose Gender !');", True)
            Return False
        End If

        If txtUsername.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Username !');", True)
            Return False
        End If

        If drpRole.SelectedValue.Trim = 0 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Select Role !');", True)
            Return False
        End If

        If txtPassword.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Password !');", True)
            Return False
        End If

        If txtConpass.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Confirm Password !');", True)
            Return False
        End If

        If txtConpass.Text.Trim() <> txtPassword.Text.Trim() Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Password not Match !');", True)
            Return False
        End If

        ' ตรวจสอบว่าค่า ID Card, Usernsme และ Mobile ว่า มีค่าซ้ำกับค่าเดิมหรือไม่
        Dim UEng As New UserEng
        If UEng.CheckDuplicateUser(Convert.ToInt64(txtIDUser.Text), txtIDcard.Text.Trim(), txtUsername.Text.Trim(), txtMobile.Text.Trim()) = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (UEng.ErrorMessage), True)
            UEng = Nothing
            Return False
        End If

        UEng = Nothing
        Return True

        Return Validations()
    End Function

    Private Function ChkValidations() As Boolean 'Check Validate of User ถ้า textbox ที่จำเป็นมีค่าว่าง ให้แสดงข้อความ alert กรณี Edit แล้ว ไม่กรอกค่าบางตัว

        If txtFirstname.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify First Name !');", True)
            Return False
        End If

        If txtLastname.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Last Name !');", True)
            Return False
        End If

        If txtIDcard.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify ID Card !');", True)
            Return False
        End If

        If txtIDcard.Text.Trim() = "0000000000000" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Check ID Card !');", True)
            Return False
        End If

        If txtIDcard.Text.Length < 13 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('ID Card Incorrect !');", True)
            Return False
        End If

        If txtMobile.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Mobile !');", True)
            Return False
        End If

        If chkMale.Checked = False And chkFemale.Checked = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Choose Gender !');", True)
            Return False
        End If

        If drpRole.SelectedValue.Trim = 0 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Select Role !');", True)
            Return False
        End If

        If txtUsername.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Username !');", True)
            Return False
        End If

        If txtPassword.Text.Trim() <> "" And txtConpass.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Confirm Password !');", True)
            Return False
        End If

        If txtConpass.Text.Trim() <> txtPassword.Text.Trim() Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Password not Match !');", True)
            Return False
        End If

        ' ตรวจสอบว่าค่า ID Card, Usernsme และ Mobile ว่า มีค่าซ้ำกับค่าเดิมหรือไม่
        Dim UEng As New UserEng
        If UEng.CheckDuplicateUser(Convert.ToInt64(txtIDUser.Text), txtIDcard.Text.Trim(), txtUsername.Text.Trim(), txtMobile.Text.Trim()) = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (UEng.ErrorMessage), True)
            UEng = Nothing
            Return False
        End If

        UEng = Nothing
        Return True


        Return Validations()
    End Function

    Private Sub SetdrpRole() 'Set Value for DropdownList 'Role' on TabUser

        Dim eng As New UserEng
        Dim dt As New DataTable
        Dim cf As New Config

        dt = eng.GetdrpRole()  'ดึงค่าที่ต้องการมา
        cf.SetDDLData(dt, drpRole, "role_desc", "id", "Select", "0") ' เพิ่มลงใน dropdownlist
        eng = Nothing

    End Sub

    Private Sub SaveUserRole() 'Function for Save data on TB_User_Role 

        Dim trans As New TransactionDB
        Dim lnq As New TbUserRoleLinqDB
        Dim dt As New DataTable
        Dim eng As New UserEng
        Dim sql As String
        Dim chkid As String
        Dim ret As Boolean = False

        dt = eng.GetgvUser("")  ' ดึงข้อมูลในตาราง User มา 

        ' Check ค่า id
        If txtIDUser.Text = 0 Then 'ถ้า id user = 0
            chkid = dt.Rows(dt.Rows.Count - 1)(0) ' กรณีที่ยังไม่ id
        Else
            chkid = txtIDUser.Text ' กรณีที่ มี ไอดีแล้วต้องการเปลี่ยน Role
        End If

        Dim user_id As String = chkid  ' เก็บค่า Userid ที่ต้องการเพิ่ม
        Dim whid As String 'เก็บค่า id ที่มีอยู่แล้ว

        sql = "select id from TB_USER_ROLE where tb_user_id = '" & user_id & "' " ' ดึงค่า id จากตาราง TB_USER_ROLE ที่มี id user = user_id
        dt = lnq.GetListBySql(sql, trans.Trans)
        If dt.Rows.Count > 0 Then ' ถ้ามี ข้อมูล

            whid = dt.Rows(0)(0).ToString() ' ก็จะเก็บค่า id ที่ได้

            lnq.GetDataByPK(Convert.ToInt64(whid), trans.Trans)  ' เลือกข้อมูล จาก whid เพื่อแก้ไข
            lnq.TB_USER_ID = user_id
            lnq.TB_ROLE_ID = Convert.ToInt64(drpRole.SelectedValue)

            ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans) 'Update ข้อมูล

        Else ' ถ้าไม่มี 

            lnq.TB_USER_ID = user_id
            lnq.TB_ROLE_ID = Convert.ToInt64(drpRole.SelectedValue)
            ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans) ' Insert ค่าใหม่

        End If

        If ret = True Then 'ถ้า ret = true 

            trans.CommitTransaction()  ' ทำการบันทึกค่าลง ฐานข้อมูล
        Else

            trans.RollbackTransaction()
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data');", True)

        End If
        lnq = Nothing

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click 'Save button of TabUser

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabUser", "TabUser();", True) 'Script of TabStrip

        'Check Validate of User
        If Convert.ToInt64(txtIDUser.Text) = 0 Then
            If Validations() = False Then
                Return
            End If
        Else
            If ChkValidations() = False Then
                Return
            End If
        End If

        Dim trans As New TransactionDB
        Dim lnq As New TbUserLinqDB

        If Convert.ToInt64(txtIDUser.Text) > 0 Then

            lnq.GetDataByPK(Convert.ToInt64(txtIDUser.Text), trans.Trans)

        End If

        lnq.FIRSTNAME = txtFirstname.Text
        lnq.LASTNAME = txtLastname.Text
        lnq.NICKNAME = txtNickname.Text
        lnq.ID_CARD = txtIDcard.Text
        lnq.MOBILE_NO = txtMobile.Text
        lnq.USERNAME = txtUsername.Text

        If Convert.ToInt64(txtIDUser.Text) > 0 Then

            If txtPassword.Text = "" Then

                lnq.PASSWORD = LinqDB.ConnectDB.SqlDB.EnCripPwd(LinqDB.ConnectDB.SqlDB.DeCripPwd(lnq.PASSWORD))

            Else
                lnq.PASSWORD = LinqDB.ConnectDB.SqlDB.EnCripPwd(txtPassword.Text)
            End If

        Else
            lnq.PASSWORD = LinqDB.ConnectDB.SqlDB.EnCripPwd(txtPassword.Text)
        End If


        If chkFemale.Checked = True Then

            lnq.GENDER = Convert.ToChar("2")

        Else
            lnq.GENDER = Convert.ToChar("1")

        End If

        If chkActiveStatus.Checked = True Then

            lnq.ACTIVE_STATUS = Convert.ToChar("Y")

        Else
            lnq.ACTIVE_STATUS = Convert.ToChar("N")
        End If

        Dim ret As Boolean = False

        If (lnq.ID > 0) Then
            ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)

        Else
            ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
        End If

        If ret = True Then

            trans.CommitTransaction()
            SetgvUser()
            If drpRole.SelectedValue.ToString().Trim() <> 0 Then
                SaveUserRole()
            End If
            ClearTextBox(Me)
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Save data Complete !');", True)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabUser", "TabUser();", True) 'Script of TabStrip

        Else

            trans.RollbackTransaction()
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data !');", True)

        End If
        lnq = Nothing

    End Sub

    Private Sub SetgvUser() 'Set data of User for DataGridView

        Dim dt As DataTable
        Dim UEng As New UserEng

        dt = UEng.GetgvUser("")

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvUser.DataSource = dt
            gvUser.DataBind()
            Cache("Data") = dt 'เก็บค่าเพื่อเอาไปใช้กับ Paging Gridview ใน event PageIndexchanging

            If dt.Rows.Count = 0 Then
                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvUser.DataSource = dt
                gvUser.DataBind()
                Dim columnCount As Integer = gvUser.Rows(0).Cells.Count
                gvUser.Rows(0).Cells.Clear()
                gvUser.Rows(0).Cells.Add(New TableCell)
                gvUser.Rows(0).Cells(0).ColumnSpan = columnCount
                gvUser.Rows(0).Cells(0).Text = "No Records Found."
            End If

        Else
            gvUser.DataSource = Nothing

        End If

    End Sub

    Public Sub ClearTextBox(ByVal root As Control)

        ' Control for clear all textboxs
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl

        chkActiveStatus.Checked = True
        chkFemale.Checked = False
        chkMale.Checked = True
        txtIDUser.Text = "0"
        drpRole.SelectedValue = 0
        SetgvUser()

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabUser", "TabUser();", True) 'Script of TabStrip

        ClearTextBox(Me) 'Function Clear textboxs

    End Sub


    Public Class GetidClass 'Class for keep any id

        Public Shared lblID As Label

    End Class

    Protected Sub gvUser_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvUser.RowCommand 'Handles gvUser.RowCommand

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabUser", "TabUser();", True) 'Script of TabStrip

        Dim lnq As New TbUserLinqDB
        Dim lnq2 As New TbRoleResponsibilityLinqDB
        Dim lnq3 As New TbUserRoleLinqDB
        Dim trans As New TransactionDB
        Dim ret As Boolean = False

        If e.CommandName = "DeleteRow" Then ' คำสั่ง delete

            Dim confirmValue As String = Request.Form("confirm_value")

            If confirmValue = "Yes" Then

                Dim RowIndex As Integer
                Integer.TryParse(e.CommandArgument.ToString, RowIndex)

                Dim sql As String = "Select UR.id ID,tb_role_id from TB_USER U join TB_USER_ROLE UR on U.id = UR.tb_user_id where tb_user_id = '" & RowIndex & "' "
                Dim dt As New DataTable
                dt = lnq.GetListBySql(sql, trans.Trans)
                If dt.Rows.Count > 0 Then
                    lblUserRoleID.Text = dt.Rows(0).Item("ID").ToString
                    lblRoleID.Text = dt.Rows(0).Item("tb_role_id").ToString
                End If

                sql = "Select RR.id ID from TB_ROLE R join TB_ROLE_RESPONSIBILITY RR on R.id = RR.tb_role_id where tb_role_id = '" & lblRoleID.Text & "' "
                dt = lnq.GetListBySql(sql, trans.Trans)
                If dt.Rows.Count > 0 Then
                    lblRoleResID.Text = dt.Rows(0).Item("ID").ToString
                End If

                ret = lnq2.DeleteByPK(lblRoleResID.Text, trans.Trans)
                If ret = True Then
                    ret = lnq3.DeleteByPK(lblUserRoleID.Text, trans.Trans)
                    If ret = True Then
                        ret = lnq.DeleteByPK(RowIndex, trans.Trans)
                        If ret = True Then
                            trans.CommitTransaction()
                            ClearTextBox(Me)
                            SetgvUser()
                            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Delete Data Complete!');", True)
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabUser", "TabUser();", True)
                        Else
                            trans.RollbackTransaction()
                            ClearTextBox(Me)
                        End If
                    End If
                ElseIf ret = False Then
                    ret = lnq3.DeleteByPK(lblUserRoleID.Text, trans.Trans)
                    If ret = True Then
                        ret = lnq.DeleteByPK(RowIndex, trans.Trans)
                        If ret = True Then
                            trans.CommitTransaction()
                            ClearTextBox(Me)
                            SetgvUser()
                            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Delete Data Complete!');", True)
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabUser", "TabUser();", True)
                        Else
                            trans.RollbackTransaction()
                            ClearTextBox(Me)
                        End If
                    ElseIf ret = False Then
                        ret = lnq.DeleteByPK(RowIndex, trans.Trans)
                        If ret = True Then
                            trans.CommitTransaction()
                            ClearTextBox(Me)
                            SetgvUser()
                            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Delete Data Complete!');", True)
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabUser", "TabUser();", True)
                        Else
                            trans.RollbackTransaction()
                            ClearTextBox(Me)
                        End If
                    End If
                End If
            Else
                ClearTextBox(Me)
            End If
        End If

        If e.CommandName = "EditRow" Then 'คำสั่ง edit

            Dim lblID As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lblID = CType(gvUser.Rows(RowIndex).FindControl("LabelID"), Label)

            lnq.GetDataByPK(lblID.Text, trans.Trans)
            If lnq.ID > 0 Then

                txtFirstname.Text = lnq.FIRSTNAME.ToString()
                txtLastname.Text = lnq.LASTNAME.ToString()
                txtNickname.Text = lnq.NICKNAME.ToString()
                txtIDcard.Text = lnq.ID_CARD.ToString()
                txtMobile.Text = lnq.MOBILE_NO.ToString()
                txtUsername.Text = lnq.USERNAME.ToString()
                txtIDUser.Text = lnq.ID.ToString()

                If lnq.GENDER = "2" Then
                    chkFemale.Checked = True
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), " ChkBox", " ChkBox();", True)
                Else
                    chkMale.Checked = True
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ChkBoxs", "ChkBoxs();", True)
                End If
                If lnq.ACTIVE_STATUS = "Y" Then
                    chkActiveStatus.Checked = True
                Else
                    chkActiveStatus.Checked = False
                End If

                Dim roleid As String
                Dim sql As String = "select tb_role_id  from TB_USER_ROLE where tb_user_id = '" & lblID.Text & "' "
                Dim dt As New DataTable
                dt = lnq3.GetListBySql(sql, trans.Trans)
                If dt.Rows.Count > 0 Then
                    roleid = dt.Rows(0)(0).ToString()
                    drpRole.SelectedValue = roleid
                End If

            End If

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabUser", "TabUser();", True)
        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabUser", "TabUser();", True)
    End Sub

    'Private Function Validate_Group() As Boolean ' Check textbox ที่จำเป็นต้องกรอก ไม่ให้มีค่าว่าง

    '    If txtGroupCode.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Group Code!');", True)
    '        Return False
    '    End If

    '    If txtDesc.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Description!');", True)
    '        Return False
    '    End If

    '    ' check ค่าซ้ำ
    '    Dim GEng As New UserEng
    '    If GEng.CheckDuplicateGroup(Convert.ToInt64(txtIDGroup.Text.Trim()), txtGroupCode.Text.Trim(), txtDesc.Text.Trim()) = True Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (GEng.ErrorMessage), True)
    '        GEng = Nothing
    '        Return False
    '    End If

    '    GEng = Nothing
    '    Return True

    '    Return Validate_Group()
    'End Function

    'Private Sub SetgvGroupList() ' ข้อมูล Group ใน datagridview

    '    Dim dt As DataTable
    '    Dim GEng As New UserEng

    '    dt = GEng.GetgvGroupList("")

    '    If Not dt Is Nothing Then

    '        dt.Columns.Add("No", GetType(Long))
    '        For i As Integer = 0 To dt.Rows.Count - 1

    '            dt.Rows(i)("No") = i + 1
    '        Next

    '        gvGroupList.DataSource = dt
    '        gvGroupList.DataBind()
    '        Cache("Data") = dt ' เก็บค่าเพื่อเอาไปใช้กับ Paging Gridview ใน event PageIndexchanging

    '        If dt.Rows.Count = 0 Then
    '            Dim dr As DataRow
    '            dr = dt.NewRow
    '            dt.Rows.Add(dr)
    '            gvGroupList.DataSource = dt
    '            gvGroupList.DataBind()
    '            Dim columnCount As Integer = gvGroupList.Rows(0).Cells.Count
    '            gvGroupList.Rows(0).Cells.Clear()
    '            gvGroupList.Rows(0).Cells.Add(New TableCell)
    '            gvGroupList.Rows(0).Cells(0).ColumnSpan = columnCount
    '            gvGroupList.Rows(0).Cells(0).Text = "No Records Found."
    '        End If


    '    Else
    '        gvGroupList.DataSource = Nothing
    '    End If

    'End Sub

    'Protected Sub btnSaveGroup_Click(sender As Object, e As EventArgs) Handles btnSaveGroup.Click ' ปุ่มบันทึกข้อมูล Group

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabGroup", "TabGroup();", True) ' มีไว้เพื่อบันทึกเสร็จจะได้กลับมา Tab เดิม

    '    If Validate_Group() = False Then
    '        Return
    '    End If

    '    Dim trans As New TransactionDB
    '    Dim lnq As New TbGroupLinqDB

    '    If Convert.ToInt64(txtIDGroup.Text) > 0 Then

    '        lnq.GetDataByPK(Convert.ToInt64(txtIDGroup.Text), trans.Trans)
    '    End If

    '    lnq.GROUP_CODE = txtGroupCode.Text
    '    lnq.GROUP_DESC = txtDesc.Text

    '    If chkActiveStatusG.Checked = True Then

    '        lnq.ACTIVE_STATUS = Convert.ToChar("Y")

    '    Else
    '        lnq.ACTIVE_STATUS = Convert.ToChar("N")
    '    End If

    '    Dim ret As Boolean = False

    '    If (lnq.ID > 0) Then
    '        ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)

    '    Else
    '        ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
    '    End If

    '    If ret = True Then

    '        trans.CommitTransaction()
    '        SetgvGroupList()
    '        SetdrpGroup()
    '        ClearTextBox_Group(Me)
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Save data Complete !');", True)
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabGroup", "TabGroup();", True)
    '    Else

    '        trans.RollbackTransaction()
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data !');", True)

    '    End If
    '    lnq = Nothing


    'End Sub

    'Public Sub ClearTextBox_Group(ByVal root As Control) ' Clear textbox Tab Group

    '    ' Control for clear all textboxs
    '    For Each ctrl As Control In root.Controls
    '        ClearTextBox(ctrl)
    '        If TypeOf ctrl Is TextBox Then
    '            CType(ctrl, TextBox).Text = String.Empty
    '        End If
    '    Next ctrl

    '    chkActiveStatus.Checked = False
    '    txtIDGroup.Text = "0"
    '    SetgvGroupList()

    'End Sub

    'Protected Sub btnCancelGroup_Click(sender As Object, e As EventArgs) Handles btnCancelGroup.Click

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabGroup", "TabGroup();", True)

    '    ClearTextBox_Group(Me)
    'End Sub

    'Protected Sub gvGroupList_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvGroupList.RowCommand

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabGroup", "TabGroup();", True)

    '    Dim lnq As New TbGroupLinqDB
    '    Dim trans As New TransactionDB
    '    Dim ret As Boolean = False

    '    If e.CommandName = "DeleteRow" Then ' คำสั่ง delete

    '        Dim confirmValue As String = Request.Form("confirm_value")

    '        If confirmValue = "Yes" Then

    '            Dim RowIndex As Integer
    '            Integer.TryParse(e.CommandArgument.ToString, RowIndex)

    '            ret = lnq.DeleteByPK(RowIndex, trans.Trans)

    '            If ret = True Then

    '                trans.CommitTransaction()
    '                ClearTextBox_Group(Me)
    '                SetgvGroupList()
    '                SetdrpGroup()
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Delete Data Complete!');", True)
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabGroup", "TabGroup();", True)
    '            Else
    '                trans.RollbackTransaction()
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Delete Data!');", True)
    '            End If
    '        End If
    '    End If

    '    If e.CommandName = "EditRow" Then 'คำสั่ง Edit

    '        Dim dt As New DataTable
    '        Dim sql As String = "Select G.id from TB_REGISTER R join TB_GROUP G on R.group_id = G.id  where R.group_id <> '0'"

    '        dt = lnq.GetListBySql(sql, trans.Trans)
    '        If dt.Rows.Count > 0 Then
    '            chkActiveStatusG.Enabled = False
    '        End If

    '        Dim lblID As Label
    '        Dim RowIndex As Integer
    '        Integer.TryParse(e.CommandArgument.ToString, RowIndex)
    '        lblID = CType(gvGroupList.Rows(RowIndex).FindControl("LabelID"), Label)

    '        lnq.GetDataByPK(lblID.Text, trans.Trans)
    '        If lnq.ID > 0 Then

    '            txtDesc.Text = lnq.GROUP_DESC.ToString()
    '            txtGroupCode.Text = lnq.GROUP_CODE.ToString()
    '            txtIDGroup.Text = lnq.ID.ToString()

    '            If lnq.ACTIVE_STATUS = "Y" Then
    '                chkActiveStatusG.Checked = True
    '            Else
    '                chkActiveStatusG.Checked = False
    '            End If

    '        End If
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabGroup", "TabGroup();", True)
    '    End If

    '    If e.CommandName = "GroupName" Then  ' link เพื่อแสดงข้อมูล Server ที่อยู่ใน Group

    '        Panel1.Visible = True
    '        Dim lblID As Label
    '        Dim RowIndex As Integer
    '        Integer.TryParse(e.CommandArgument.ToString, RowIndex)
    '        lblID = CType(gvGroupList.Rows(RowIndex).FindControl("LabelID"), Label)
    '        GetidClass.lblID = lblID
    '        Session("idGroup") = lblID.Text  ' Session นี้เก็บค่า id Group ไว้เพื่อเอาไปใช้ใน frmPopupAddServer 
    '        Dim GName As Label = CType(gvGroupList.Rows(RowIndex).FindControl("LabelDesc"), Label)
    '        lblName.Text = GName.Text  ' แสดงชื่อ Group ใน label

    '        SetgvShowServer() 'แสดง gvShowServer เพื่อแสดงเครื่องที่มีอยู่ใน group
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabGroup", "TabGroup();", True)
    '    End If
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabGroup", "TabGroup();", True)

    'End Sub

    'Private Sub SetgvShowServer()

    '    Dim dt As DataTable
    '    Dim GEng As New UserEng
    '    Dim lblID As Label = GetidClass.lblID ' เก็บค่า Group id ที่ดึงมาจาก gvGrouplist

    '    dt = GEng.GetgvShowServer(lblID.Text) ' จะแสดงเฉพาะเครื่องที่อยู่ใน id ของ group ที่เลือกมา เท่านั้น

    '    If Not dt Is Nothing Then

    '        dt.Columns.Add("No", GetType(Long))
    '        For i As Integer = 0 To dt.Rows.Count - 1

    '            dt.Rows(i)("No") = i + 1
    '        Next

    '        gvShowServer.DataSource = dt
    '        gvShowServer.DataBind()
    '        Cache("Data") = dt  ' เก็บค่าเพื่อเอาไปใช้กับ Paging Gridview ใน event PageIndexchanging

    '        If dt.Rows.Count = 0 Then
    '            Dim dr As DataRow
    '            dr = dt.NewRow
    '            dt.Rows.Add(dr)
    '            gvShowServer.DataSource = dt
    '            gvShowServer.DataBind()
    '            Dim columnCount As Integer = gvShowServer.Rows(0).Cells.Count
    '            gvShowServer.Rows(0).Cells.Clear()
    '            gvShowServer.Rows(0).Cells.Add(New TableCell)
    '            gvShowServer.Rows(0).Cells(0).ColumnSpan = columnCount
    '            gvShowServer.Rows(0).Cells(0).Text = "No Records Found."
    '        End If

    '    Else
    '        gvShowServer.DataSource = Nothing
    '    End If

    'End Sub

    'Private Function Validate_Register() As Boolean ' Check textbox ที่จำเป็นต้องกรอก ไม่ให้มีค่าว่าง Tab Register

    '    If txtServerIP.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Server IP !');", True)
    '        Return False
    '    End If

    '    If txtServerName.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Server Name !');", True)
    '        Return False
    '    End If

    '    If txtOS.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify OS !');", True)
    '        Return False
    '    End If

    '    If txtSystem.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Project Name !');", True)
    '        Return False
    '    End If

    '    If txtFnameR.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify First Name !');", True)
    '        Return False
    '    End If

    '    If txtLnameR.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Last Name !');", True)
    '        Return False
    '    End If

    '    If txtEmail.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify E-mail !');", True)
    '        Return False
    '    End If

    '    ' check ค่าซ้ำ
    '    Dim REng As New UserEng
    '    If REng.CheckDuplicateRegister(Convert.ToInt64(txtIDRegister.Text), txtServerIP.Text.Trim(), txtServerName.Text.Trim(), txtMacAddress.Text.Trim()) = True Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (REng.ErrorMessage), True)
    '        REng = Nothing
    '        Return False
    '    End If

    '    REng = Nothing
    '    Return True

    '    Return Validate_Register()
    'End Function

    'Private Sub SetgvRegister() ' ข้อมูล register ใน datagridview 

    '    Dim dt As DataTable
    '    Dim REng As New UserEng

    '    dt = REng.GetgvRegister("")

    '    If Not dt Is Nothing Then

    '        dt.Columns.Add("No", GetType(Long))
    '        For i As Integer = 0 To dt.Rows.Count - 1

    '            dt.Rows(i)("No") = i + 1
    '        Next

    '        gvRegister.DataSource = dt
    '        gvRegister.DataBind()
    '        Cache("Data") = dt ' เก็บค่าเพื่อเอาไปใช้กับ Paging gridview ใน event PageIndexChanging

    '        If dt.Rows.Count = 0 Then
    '            Dim dr As DataRow
    '            dr = dt.NewRow
    '            dt.Rows.Add(dr)
    '            gvRegister.DataSource = dt
    '            gvRegister.DataBind()
    '            Dim columnCount As Integer = gvRegister.Rows(0).Cells.Count
    '            gvRegister.Rows(0).Cells.Clear()
    '            gvRegister.Rows(0).Cells.Add(New TableCell)
    '            gvRegister.Rows(0).Cells(0).ColumnSpan = columnCount
    '            gvRegister.Rows(0).Cells(0).Text = "No Records Found."
    '        End If

    '    Else
    '        gvRegister.DataSource = Nothing
    '    End If

    'End Sub

    'Private Sub SetdrpGroup() ' ใส่ค่าให้ dropdownlist
    '    Dim eng As New UserEng
    '    Dim dt As New DataTable
    '    Dim cf As New Config

    '    dt = eng.GetdrpGroup() 'ดึงค่าที่ต้องการจะแสดง
    '    cf.SetDDLData(dt, drpGroup, "group_desc", "id", "Select", "0") ' ใส่ค่าใน dropdownlist
    '    eng = Nothing

    'End Sub

    'Protected Sub btnSaveRegister_Click(sender As Object, e As EventArgs) Handles btnSaveRegister.Click 'ปุ่มบันทึก Register

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRegister", "TabRegister();", True)

    '    If Validate_Register() = False Then
    '        Return
    '    End If

    '    Dim trans As New TransactionDB
    '    Dim lnq As New TbRegisterLinqDB

    '    If Convert.ToInt64(txtIDRegister.Text) > 0 Then

    '        lnq.GetDataByPK(Convert.ToInt64(txtIDRegister.Text), trans.Trans)
    '    End If

    '    lnq.SERVERIP = txtServerIP.Text
    '    lnq.SERVERNAME = txtServerName.Text
    '    lnq.OS = txtOS.Text
    '    lnq.SYSTEM_TYPE = txtSystem.Text
    '    lnq.FNAME = txtFnameR.Text
    '    lnq.LNAME = txtLnameR.Text
    '    lnq.E_MAIL = txtEmail.Text
    '    lnq.MACADDRESS = txtMacAddress.Text
    '    lnq.GROUP_ID = Convert.ToInt64(drpGroup.SelectedValue)
    '    lnq.LOCATIONSERVER = txtLacServer.Text
    '    lnq.LOCATIONNO = txtLacNumber.Text

    '    If chkActiveStatusR.Checked = True Then

    '        lnq.ACTIVE_STATUS = Convert.ToChar("Y")

    '    Else
    '        lnq.ACTIVE_STATUS = Convert.ToChar("N")
    '    End If

    '    Dim ret As Boolean = False

    '    If (lnq.ID > 0) Then
    '        ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)

    '    Else
    '        ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
    '    End If

    '    If ret = True Then

    '        trans.CommitTransaction()
    '        SetgvRegister()
    '        ClearTextBox_Register(Me)
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Save data Complete !');", True)
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRegister", "TabRegister();", True)
    '    Else

    '        trans.RollbackTransaction()
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data !');", True)

    '    End If
    '    lnq = Nothing

    'End Sub

    'Public Sub ClearTextBox_Register(ByVal root As Control)

    '    ' Control for clear all textboxs
    '    For Each ctrl As Control In root.Controls
    '        ClearTextBox(ctrl)
    '        If TypeOf ctrl Is TextBox Then
    '            CType(ctrl, TextBox).Text = String.Empty
    '        End If
    '    Next ctrl

    '    chkActiveStatusR.Checked = False
    '    txtIDRegister.Text = "0"
    '    drpGroup.SelectedValue = "0"
    '    SetgvRegister()

    'End Sub

    'Protected Sub btnCancelRegister_Click(sender As Object, e As EventArgs) Handles btnCancelRegister.Click

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRegister", "TabRegister();", True)

    '    ClearTextBox_Register(Me)

    'End Sub

    'Protected Sub gvRegister_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvRegister.RowCommand

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRegister", "TabRegister();", True)

    '    Dim lnq As New TbRegisterLinqDB
    '    Dim trans As New TransactionDB
    '    Dim ret As Boolean = False

    '    If e.CommandName = "DeleteRow" Then 'คำสั่ง delete

    '        Dim confirmValue As String = Request.Form("confirm_value")

    '        If confirmValue = "Yes" Then

    '            Dim RowIndex As Integer
    '            Integer.TryParse(e.CommandArgument.ToString, RowIndex)

    '            ret = lnq.DeleteByPK(RowIndex, trans.Trans)
    '            If ret = True Then

    '                trans.CommitTransaction()
    '                ClearTextBox_Register(Me)
    '                SetgvRegister()
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Delete Data Complete!');", True)
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRegister", "TabRegister();", True)
    '            Else
    '                trans.RollbackTransaction()
    '                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Confirm value", "alert('Can not Delete data')", True)
    '            End If
    '        End If
    '    End If

    '    If e.CommandName = "EditRow" Then ' คำสั่ง edit

    '        Dim lblID As Label
    '        Dim RowIndex As Integer
    '        Integer.TryParse(e.CommandArgument.ToString, RowIndex)
    '        lblID = CType(gvRegister.Rows(RowIndex).FindControl("LabelID"), Label)

    '        lnq.GetDataByPK(lblID.Text, trans.Trans)
    '        If lnq.ID > 0 Then

    '            txtServerIP.Text = lnq.SERVERIP.ToString()
    '            txtServerName.Text = lnq.SERVERNAME.ToString()
    '            txtOS.Text = lnq.OS.ToString()
    '            txtSystem.Text = lnq.SYSTEM_TYPE.ToString()
    '            txtEmail.Text = lnq.E_MAIL.ToString()
    '            txtIDRegister.Text = lnq.ID.ToString()
    '            txtFnameR.Text = lnq.FNAME.ToString()
    '            txtLnameR.Text = lnq.LNAME.ToString()
    '            txtMacAddress.Text = lnq.MACADDRESS.ToString()
    '            txtLacServer.Text = lnq.LOCATIONSERVER.ToString()
    '            txtLacNumber.Text = lnq.LOCATIONNO.ToString()

    '            If lnq.ACTIVE_STATUS = "Y" Then
    '                chkActiveStatusR.Checked = True
    '            Else
    '                chkActiveStatusR.Checked = False
    '            End If

    '            drpGroup.Text = lnq.GROUP_ID.ToString()

    '        End If
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRegister", "TabRegister();", True)
    '    End If

    'End Sub

    Private Function Validate_Role() As Boolean ' Check textbox ที่จำเป็นต้องกรอก ไม่ให้มีค่าว่าง Tab Role

        If txtRoleCode.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Role Code !');", True)
            Return False
        End If

        If txtRoleDesc.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Description !');", True)
            Return False
        End If

        Dim chk As Boolean = False
        For j As Integer = 0 To gvResponsibility.Rows.Count - 1
            Dim chkRespons As CheckBox = DirectCast(gvResponsibility.Rows(j).FindControl("ChkRespons"), CheckBox)
            If chkRespons.Checked = True Then
                chk = True
            End If
        Next
        If chk = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Select Responsibility !');", True)
            Return False
        End If

        ' Check ค่าซ้ำ
        Dim Eng As New UserEng
        If Eng.CheckDuplicateRole(Convert.ToInt64(txtIDRole.Text), txtRoleCode.Text.Trim(), txtRoleDesc.Text.Trim()) = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (Eng.ErrorMessage), True)
            Eng = Nothing
            Return False
        End If

        Eng = Nothing
        Return True

        Return Validate_Role()
    End Function

    Private Sub SetgvRoleList() ' ใส่ข้อมูล Role ลงใน datagridview

        Dim dt As DataTable
        Dim REng As New UserEng

        dt = REng.GetgvRole("")

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvRoleList.DataSource = dt
            gvRoleList.DataBind()
            Cache("Data") = dt  ' เก็บค่าเพื่อใช้กับ Paging datagridview ใน event PageIndexChanging

            If dt.Rows.Count = 0 Then
                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvRoleList.DataSource = dt
                gvRoleList.DataBind()
                Dim columnCount As Integer = gvRoleList.Rows(0).Cells.Count
                gvRoleList.Rows(0).Cells.Clear()
                gvRoleList.Rows(0).Cells.Add(New TableCell)
                gvRoleList.Rows(0).Cells(0).ColumnSpan = columnCount
                gvRoleList.Rows(0).Cells(0).Text = "No Records Found."
            End If

        Else
            gvRoleList.DataSource = Nothing
        End If

    End Sub

    Private Sub SaveSelectedRespon() ' Save Selected Responsibility with Role

        Dim dt As New DataTable
        Dim eng As New UserEng
        Dim role_id As String

        Dim selected_id As New Integer
        Dim ret As Boolean = False

        dt = eng.GetgvRole("") ' ดึงข้อมูลในตาราง Role 

        If txtIDRole.Text = 0 Then ' ถ้า id role = 0 
            role_id = dt.Rows(dt.Rows.Count - 1)(0)

            For i As Integer = 0 To gvResponsibility.Rows.Count - 1
                Dim lnq As New TbRoleResponsibilityLinqDB
                Dim trans As New TransactionDB
                Dim chkRespons As CheckBox = DirectCast(gvResponsibility.Rows(i).FindControl("ChkRespons"), CheckBox)

                If chkRespons.Checked = True Then

                    Dim lblID As Label = DirectCast(gvResponsibility.Rows(i).FindControl("lblID"), Label)

                    lnq.TB_RESPONSIBILITY_ID = lblID.Text
                    lnq.TB_ROLE_ID = role_id

                    ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)

                    If ret = True Then

                        trans.CommitTransaction()

                    Else

                        trans.RollbackTransaction()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data !');", True)

                    End If

                End If
                lnq = Nothing

            Next

        Else

            role_id = txtIDRole.Text
            For i As Integer = 0 To gvResponsibility.Rows.Count - 1

                Dim chkRespons As CheckBox = DirectCast(gvResponsibility.Rows(i).FindControl("ChkRespons"), CheckBox)

                If chkRespons.Checked = True Then
                    Dim lnq As New TbRoleResponsibilityLinqDB
                    Dim trans As New TransactionDB
                    Dim lblID As Label = DirectCast(gvResponsibility.Rows(i).FindControl("lblID"), Label)

                    If Convert.ToInt64(role_id) > 0 Then

                        Dim sql As String = "Select id from TB_ROLE_RESPONSIBILITY where tb_role_id = '" & role_id & "' and tb_responsibility_id = '" & lblID.Text & "' "
                        dt = lnq.GetListBySql(sql, trans.Trans)
                        If dt.Rows.Count > 0 Then
                            For j As Integer = 0 To dt.Rows.Count - 1
                                Dim Rid As String = dt.Rows(j)(0).ToString
                                lnq.GetDataByPK(Convert.ToInt64(Rid), trans.Trans)

                                lnq.TB_RESPONSIBILITY_ID = lblID.Text
                                lnq.TB_ROLE_ID = role_id

                                ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)

                                If ret = True Then

                                    trans.CommitTransaction()

                                Else

                                    trans.RollbackTransaction()
                                    ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data !');", True)

                                End If

                            Next
                        Else

                            lnq.TB_RESPONSIBILITY_ID = lblID.Text
                            lnq.TB_ROLE_ID = role_id

                            ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)

                            If ret = True Then

                                trans.CommitTransaction()

                            Else

                                trans.RollbackTransaction()
                                ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data !');", True)

                            End If
                        End If
                    End If

                    lnq = Nothing

                Else

                    Dim lblID As Label = DirectCast(gvResponsibility.Rows(i).FindControl("lblID"), Label)

                    If Convert.ToInt64(role_id) > 0 Then
                        Dim lnq As New TbRoleResponsibilityLinqDB
                        Dim trans As New TransactionDB
                        Dim sql2 As String = "Select id from TB_ROLE_RESPONSIBILITY where tb_role_id = '" & role_id & "' and tb_responsibility_id = '" & lblID.Text & "' "
                        dt = lnq.GetListBySql(sql2, trans.Trans)
                        If dt.Rows.Count > 0 Then
                            For j As Integer = 0 To dt.Rows.Count - 1
                                Dim Rid As String = dt.Rows(j)(0).ToString
                                lnq.GetDataByPK(Convert.ToInt64(Rid), trans.Trans)

                                lnq.TB_RESPONSIBILITY_ID = lblID.Text
                                lnq.TB_ROLE_ID = role_id

                                ret = lnq.DeleteByPK(Rid, trans.Trans)

                                If ret = True Then

                                    trans.CommitTransaction()

                                Else

                                    trans.RollbackTransaction()
                                    ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data !');", True)

                                End If

                            Next
                            '        Else

                            '            lnq.TB_RESPONSIBILITY_ID = lblID.Text
                            '            lnq.TB_ROLE_ID = role_id

                            '            ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)

                            '            If ret = True Then

                            '                trans.CommitTransaction()

                            '            Else

                            '                trans.RollbackTransaction()
                            '                ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data !');", True)

                            '            End If
                            '        End If

                        End If
                        lnq = Nothing
                    End If
                End If
            Next
        End If

    End Sub

    Protected Sub btnSaveRole_Click(sender As Object, e As EventArgs) Handles btnSaveRole.Click

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRole", "TabRole();", True)

        If Validate_Role() = False Then
            Return
        End If

        Dim trans As New TransactionDB
        Dim lnq As New TbRoleLinqDB

        If Convert.ToInt64(txtIDRole.Text) > 0 Then

            lnq.GetDataByPK(Convert.ToInt64(txtIDRole.Text), trans.Trans)

        End If

        lnq.ROLE_CODE = txtRoleCode.Text
        lnq.ROLE_DESC = txtRoleDesc.Text

        If chkActiveStatusRole.Checked = True Then

            lnq.ACTIVE_STATUS = Convert.ToChar("Y")

        Else

            lnq.ACTIVE_STATUS = Convert.ToChar("N")

        End If

        Dim ret As Boolean = False

        If (lnq.ID > 0) Then

            ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)

        Else

            ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)

        End If

        If ret = True Then

            trans.CommitTransaction()
            SetgvRoleList()
            SaveSelectedRespon()
            SetdrpRole()
            ClearTextBox_Role(Me)
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Save data Complete !');", True)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRole", "TabRole();", True)
        Else

            trans.RollbackTransaction()
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data !');", True)

        End If
        lnq = Nothing

    End Sub

    Protected Sub btnCancelRole_Click(sender As Object, e As EventArgs) Handles btnCancelRole.Click

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRole", "TabRole();", True)

        ClearTextBox_Role(Me)

    End Sub

    Public Sub ClearTextBox_Role(ByVal root As Control)

        ' Control for clear all textboxs
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl

        chkActiveStatusRole.Checked = True
        txtIDRole.Text = "0"

        For i As Integer = 0 To gvResponsibility.Rows.Count - 1

            Dim chkRespons As CheckBox = DirectCast(gvResponsibility.Rows(i).FindControl("ChkRespons"), CheckBox)
            If chkRespons.Checked = True Then
                chkRespons.Checked = False
            End If
        Next

        SetgvRoleList()

    End Sub

    Protected Sub gvRoleList_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvRoleList.RowCommand

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRole", "TabRole();", True)
        ClearTextBox_Role(Me)

        Dim lnq As New TbRoleLinqDB
        Dim lnq2 As New TbRoleResponsibilityLinqDB
        Dim trans As New TransactionDB
        Dim ret As Boolean = False

        If e.CommandName = "DeleteRow" Then
            Dim confirmValue As String = Request.Form("confirm_value")

            If confirmValue = "Yes" Then

                Dim RowIndex As Integer
                Integer.TryParse(e.CommandArgument.ToString, RowIndex)

                Dim dt As DataTable
                Dim Sql = "Select RR.id  from TB_ROLE_RESPONSIBILITY RR join TB_ROLE R on  RR.tb_role_id = R.id  where tb_role_id = '" & RowIndex & "' "
                dt = lnq.GetListBySql(Sql, trans.Trans)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        lbltbidrole.Text = dt.Rows(i)(0).ToString
                        ret = lnq2.DeleteByPK(lbltbidrole.Text, trans.Trans)
                    Next
                End If

                If ret = True Then
                    ret = lnq.DeleteByPK(RowIndex, trans.Trans)
                    If ret = True Then

                        trans.CommitTransaction()
                        ClearTextBox_Role(Me)
                        SetgvRoleList()
                        SetdrpRole()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Delete Data Complete !');", True)
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRole", "TabRole();", True)
                    Else

                        trans.RollbackTransaction()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Delete Data !');", True)

                    End If
                ElseIf ret = False Then
                    ret = lnq.DeleteByPK(RowIndex, trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()
                        ClearTextBox_Role(Me)
                        SetgvRoleList()
                        SetdrpRole()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Delete Data Complete !');", True)
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRole", "TabRole();", True)
                    Else

                        trans.RollbackTransaction()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Delete Data !');", True)

                    End If
                End If
            End If
        End If

        If e.CommandName = "EditRow" Then

            Dim lblID As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lblID = CType(gvRoleList.Rows(RowIndex).FindControl("LabelID"), Label)

            Dim dt1 As New DataTable
            Dim sql1 As String = "Select UR.id from TB_USER U join TB_USER_ROLE UR on U.id = UR.tb_user_id where UR.tb_role_id = '" & lblID.Text & "' "

            dt1 = lnq.GetListBySql(sql1, trans.Trans)
            If dt1.Rows.Count > 0 Then
                chkActiveStatusRole.Enabled = False
            End If

            lnq.GetDataByPK(lblID.Text, trans.Trans)

            If lnq.ID > 0 Then

                txtIDRole.Text = lnq.ID.ToString()
                txtRoleCode.Text = lnq.ROLE_CODE.ToString()
                txtRoleDesc.Text = lnq.ROLE_DESC.ToString()

                If lnq.ACTIVE_STATUS = "Y" Then

                    chkActiveStatusRole.Checked = True

                Else

                    chkActiveStatusRole.Checked = False

                End If


                Dim sql As String = "Select tb_responsibility_id from TB_ROLE_RESPONSIBILITY where tb_role_id = '" & lblID.Text & "' "
                Dim lnq1 As New TbRoleResponsibilityLinqDB
                Dim dt As New DataTable
                Dim tran As New TransactionDB

                dt = lnq.GetListBySql(sql, tran.Trans)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1

                        lblidRes.Text = dt.Rows(i)(0).ToString

                        For j As Integer = 0 To gvResponsibility.Rows.Count - 1
                            Dim chkRespons As CheckBox = DirectCast(gvResponsibility.Rows(j).FindControl("ChkRespons"), CheckBox)
                            If lblidRes.Text = (j + 1) Then
                                chkRespons.Checked = True
                            End If
                        Next
                    Next

                End If



            End If
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRole", "TabRole();", True)
        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRole", "TabRole();", True)
    End Sub

    Private Sub SetgvResponsibility()

        Dim dt As DataTable
        Dim Eng As New UserEng

        dt = Eng.GetgvResponsibility("")

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvResponsibility.DataSource = dt
            gvResponsibility.DataBind()

        Else
            gvResponsibility.DataSource = Nothing
        End If

    End Sub

    'Protected Sub gvShowServer_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvShowServer.RowCommand

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabGroup", "TabGroup();", True)

    '    Dim lnq As New TbRegisterLinqDB
    '    Dim trans As New TransactionDB
    '    Dim ret As Boolean = False

    '    If e.CommandName = "DeleteRow" Then

    '        Dim lblID As Label
    '        Dim RowIndex As Integer
    '        Integer.TryParse(e.CommandArgument.ToString, RowIndex)
    '        lblID = CType(gvShowServer.Rows(RowIndex).FindControl("LabelID"), Label)
    '        lnq.GetDataByPK(lblID.Text, trans.Trans)

    '        lnq.GROUP_ID = "0"

    '        If (lnq.ID > 0) Then
    '            ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)
    '        End If

    '        If ret = True Then

    '            trans.CommitTransaction()
    '            SetgvShowServer()
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Delete data Complete !');", True)

    '        Else
    '            trans.RollbackTransaction()
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Delete data Complete !');", True)

    '        End If
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabGroup", "TabGroup();", True)
    '    End If
    'End Sub

    'Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabGroup", "TabGroup();", True)

    'End Sub

    Protected Sub gvUser_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvUser.PageIndexChanging

        SetgvUser()
        gvUser.PageIndex = e.NewPageIndex
        gvUser.DataSource = CType(Cache("Data"), DataTable)
        gvUser.DataBind()

    End Sub

    Protected Sub gvRoleList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvRoleList.PageIndexChanging

        SetgvRoleList()
        gvRoleList.PageIndex = e.NewPageIndex
        gvRoleList.DataSource = CType(Cache("Data"), DataTable)
        gvRoleList.DataBind()

    End Sub

    'Protected Sub gvGroupList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvGroupList.PageIndexChanging

    '    SetgvGroupList()
    '    gvGroupList.PageIndex = e.NewPageIndex
    '    gvGroupList.DataSource = CType(Cache("Data"), DataTable)
    '    gvGroupList.DataBind()

    'End Sub

    'Protected Sub gvShowServer_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvShowServer.PageIndexChanging

    '    SetgvShowServer()
    '    gvShowServer.PageIndex = e.NewPageIndex
    '    gvShowServer.DataSource = CType(Cache("Data"), DataTable)
    '    gvShowServer.DataBind()

    'End Sub

    'Protected Sub gvRegister_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvRegister.PageIndexChanging

    '    SetgvRegister()
    '    gvRegister.PageIndex = e.NewPageIndex
    '    gvRegister.DataSource = CType(Cache("Data"), DataTable)
    '    gvRegister.DataBind()

    'End Sub

    
End Class

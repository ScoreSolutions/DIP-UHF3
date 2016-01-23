Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Script.Services
Partial Class frmRegister
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btnSearch_Click(sender, e) ' ใส่ข้อมูลจากตาราง Register ลงใน datagridview 
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" & btnSearch.ClientID & "')")
        End If

        If Session("SaveServer") = True Then  ' ค่า Session นี้ มาจากปุ่ม Add Server ใน Tab Group ถ้าค่านี้ถูก บันทึก Session จะ เท่ากับ true
            Session.Remove("SaveServer")
        End If
    End Sub

    'Private Function Validations() As Boolean 'Check Validate of User ถ้า textbox ที่จำเป็นมีค่าว่าง ให้แสดงข้อความ alert

    '    If txtFirstname.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify First Name !');", True)
    '        Return False
    '    End If

    '    If txtLastname.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Last Name !');", True)
    '        Return False
    '    End If

    '    If txtIDcard.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify ID Card !');", True)
    '        Return False
    '    End If

    '    If txtIDcard.Text.Trim() = "0000000000000" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Check ID Card !');", True)
    '        Return False
    '    End If

    '    If txtIDcard.Text.Length < 13 Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('ID Card Incorrect !');", True)
    '        Return False
    '    End If

    '    If txtMobile.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Mobile !');", True)
    '        Return False
    '    End If

    '    If chkMale.Checked = False And chkFemale.Checked = False Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Choose Gender !');", True)
    '        Return False
    '    End If

    '    If txtUsername.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Username !');", True)
    '        Return False
    '    End If

    '    If drpRole.SelectedValue.Trim = 0 Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Select Role !');", True)
    '        Return False
    '    End If

    '    If txtPassword.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Password !');", True)
    '        Return False
    '    End If

    '    If txtConpass.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Confirm Password !');", True)
    '        Return False
    '    End If

    '    If txtConpass.Text.Trim() <> txtPassword.Text.Trim() Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Password not Match !');", True)
    '        Return False
    '    End If

    '    ' ตรวจสอบว่าค่า ID Card, Usernsme และ Mobile ว่า มีค่าซ้ำกับค่าเดิมหรือไม่
    '    Dim UEng As New UserEng
    '    If UEng.CheckDuplicateUser(Convert.ToInt64(txtIDUser.Text), txtIDcard.Text.Trim(), txtUsername.Text.Trim(), txtMobile.Text.Trim()) = True Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (UEng.ErrorMessage), True)
    '        UEng = Nothing
    '        Return False
    '    End If

    '    UEng = Nothing
    '    Return True

    '    Return Validations()
    'End Function

    'Private Function ChkValidations() As Boolean 'Check Validate of User ถ้า textbox ที่จำเป็นมีค่าว่าง ให้แสดงข้อความ alert กรณี Edit แล้ว ไม่กรอกค่าบางตัว

    '    If txtFirstname.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify First Name !');", True)
    '        Return False
    '    End If

    '    If txtLastname.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Last Name !');", True)
    '        Return False
    '    End If

    '    If txtIDcard.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify ID Card !');", True)
    '        Return False
    '    End If

    '    If txtIDcard.Text.Trim() = "0000000000000" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Check ID Card !');", True)
    '        Return False
    '    End If

    '    If txtIDcard.Text.Length < 13 Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('ID Card Incorrect !');", True)
    '        Return False
    '    End If

    '    If txtMobile.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Mobile !');", True)
    '        Return False
    '    End If

    '    If chkMale.Checked = False And chkFemale.Checked = False Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Choose Gender !');", True)
    '        Return False
    '    End If

    '    If drpRole.SelectedValue.Trim = 0 Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Select Role !');", True)
    '        Return False
    '    End If

    '    If txtUsername.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Username !');", True)
    '        Return False
    '    End If

    '    If txtPassword.Text.Trim() <> "" And txtConpass.Text.Trim() = "" Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Confirm Password !');", True)
    '        Return False
    '    End If

    '    If txtConpass.Text.Trim() <> txtPassword.Text.Trim() Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Password not Match !');", True)
    '        Return False
    '    End If

    '    ' ตรวจสอบว่าค่า ID Card, Usernsme และ Mobile ว่า มีค่าซ้ำกับค่าเดิมหรือไม่
    '    Dim UEng As New UserEng
    '    If UEng.CheckDuplicateUser(Convert.ToInt64(txtIDUser.Text), txtIDcard.Text.Trim(), txtUsername.Text.Trim(), txtMobile.Text.Trim()) = True Then
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (UEng.ErrorMessage), True)
    '        UEng = Nothing
    '        Return False
    '    End If

    '    UEng = Nothing
    '    Return True


    '    Return Validations()
    'End Function

    'Private Sub SetdrpRole() 'Set Value for DropdownList 'Role' on TabUser

    '    Dim eng As New UserEng
    '    Dim dt As New DataTable
    '    Dim cf As New Config

    '    dt = eng.GetdrpRole()  'ดึงค่าที่ต้องการมา
    '    cf.SetDDLData(dt, drpRole, "role_desc", "id", "Select", "0") ' เพิ่มลงใน dropdownlist
    '    eng = Nothing

    'End Sub

    'Private Sub SaveUserRole() 'Function for Save data on TB_User_Role 

    '    Dim trans As New TransactionDB
    '    Dim lnq As New TbUserRoleLinqDB
    '    Dim dt As New DataTable
    '    Dim eng As New UserEng
    '    Dim sql As String
    '    Dim chkid As String
    '    Dim ret As Boolean = False

    '    dt = eng.GetgvUser("")  ' ดึงข้อมูลในตาราง User มา 

    '    ' Check ค่า id
    '    If txtIDUser.Text = 0 Then 'ถ้า id user = 0
    '        chkid = dt.Rows(dt.Rows.Count - 1)(0) ' กรณีที่ยังไม่ id
    '    Else
    '        chkid = txtIDUser.Text ' กรณีที่ มี ไอดีแล้วต้องการเปลี่ยน Role
    '    End If

    '    Dim user_id As String = chkid  ' เก็บค่า Userid ที่ต้องการเพิ่ม
    '    Dim whid As String 'เก็บค่า id ที่มีอยู่แล้ว

    '    sql = "select id from TB_USER_ROLE where tb_user_id = '" & user_id & "' " ' ดึงค่า id จากตาราง TB_USER_ROLE ที่มี id user = user_id
    '    dt = lnq.GetListBySql(sql, trans.Trans)
    '    If dt.Rows.Count > 0 Then ' ถ้ามี ข้อมูล

    '        whid = dt.Rows(0)(0).ToString() ' ก็จะเก็บค่า id ที่ได้

    '        lnq.GetDataByPK(Convert.ToInt64(whid), trans.Trans)  ' เลือกข้อมูล จาก whid เพื่อแก้ไข
    '        lnq.TB_USER_ID = user_id
    '        lnq.TB_ROLE_ID = Convert.ToInt64(drpRole.SelectedValue)

    '        ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans) 'Update ข้อมูล

    '    Else ' ถ้าไม่มี 

    '        lnq.TB_USER_ID = user_id
    '        lnq.TB_ROLE_ID = Convert.ToInt64(drpRole.SelectedValue)
    '        ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans) ' Insert ค่าใหม่

    '    End If

    '    If ret = True Then 'ถ้า ret = true 

    '        trans.CommitTransaction()  ' ทำการบันทึกค่าลง ฐานข้อมูล
    '    Else

    '        trans.RollbackTransaction()
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data');", True)

    '    End If
    '    lnq = Nothing

    'End Sub

    'Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click 'Save button of TabUser

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabUser", "TabUser();", True) 'Script of TabStrip

    '    'Check Validate of User
    '    If Convert.ToInt64(txtIDUser.Text) = 0 Then
    '        If Validations() = False Then
    '            Return
    '        End If
    '    Else
    '        If ChkValidations() = False Then
    '            Return
    '        End If
    '    End If

    '    Dim trans As New TransactionDB
    '    Dim lnq As New TbUserLinqDB

    '    If Convert.ToInt64(txtIDUser.Text) > 0 Then

    '        lnq.GetDataByPK(Convert.ToInt64(txtIDUser.Text), trans.Trans)

    '    End If

    '    lnq.FIRSTNAME = txtFirstname.Text
    '    lnq.LASTNAME = txtLastname.Text
    '    lnq.NICKNAME = txtNickname.Text
    '    lnq.ID_CARD = txtIDcard.Text
    '    lnq.MOBILE_NO = txtMobile.Text
    '    lnq.USERNAME = txtUsername.Text

    '    If Convert.ToInt64(txtIDUser.Text) > 0 Then

    '        If txtPassword.Text = "" Then

    '            lnq.PASSWORD = LinqDB.ConnectDB.SqlDB.EnCripPwd(LinqDB.ConnectDB.SqlDB.DeCripPwd(lnq.PASSWORD))

    '        Else
    '            lnq.PASSWORD = LinqDB.ConnectDB.SqlDB.EnCripPwd(txtPassword.Text)
    '        End If

    '    Else
    '        lnq.PASSWORD = LinqDB.ConnectDB.SqlDB.EnCripPwd(txtPassword.Text)
    '    End If


    '    If chkFemale.Checked = True Then

    '        lnq.GENDER = Convert.ToChar("2")

    '    Else
    '        lnq.GENDER = Convert.ToChar("1")

    '    End If

    '    If chkActiveStatus.Checked = True Then

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
    '        SetgvUser()
    '        If drpRole.SelectedValue.ToString().Trim() <> 0 Then
    '            SaveUserRole()
    '        End If
    '        ClearTextBox(Me)
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Save data Complete !');", True)
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabUser", "TabUser();", True) 'Script of TabStrip

    '    Else

    '        trans.RollbackTransaction()
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data !');", True)

    '    End If
    '    lnq = Nothing

    'End Sub

    'Private Sub SetgvUser() 'Set data of User for DataGridView

    '    Dim dt As DataTable
    '    Dim UEng As New UserEng

    '    dt = UEng.GetgvUser("")

    '    If Not dt Is Nothing Then

    '        dt.Columns.Add("No", GetType(Long))
    '        For i As Integer = 0 To dt.Rows.Count - 1

    '            dt.Rows(i)("No") = i + 1
    '        Next

    '        gvUser.DataSource = dt
    '        gvUser.DataBind()
    '        Cache("Data") = dt 'เก็บค่าเพื่อเอาไปใช้กับ Paging Gridview ใน event PageIndexchanging

    '        If dt.Rows.Count = 0 Then
    '            Dim dr As DataRow
    '            dr = dt.NewRow
    '            dt.Rows.Add(dr)
    '            gvUser.DataSource = dt
    '            gvUser.DataBind()
    '            Dim columnCount As Integer = gvUser.Rows(0).Cells.Count
    '            gvUser.Rows(0).Cells.Clear()
    '            gvUser.Rows(0).Cells.Add(New TableCell)
    '            gvUser.Rows(0).Cells(0).ColumnSpan = columnCount
    '            gvUser.Rows(0).Cells(0).Text = "No Records Found."
    '        End If

    '    Else
    '        gvUser.DataSource = Nothing

    '    End If

    'End Sub

    Public Sub ClearTextBox(ByVal root As Control)

        ' Control for clear all textboxs
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl

 
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim wh As String = ""
        If Trim(txtSearch.Text) <> "" Then
            wh = " (replace(ServerIP,'_','9x9x9')  like replace('%" & Trim(txtSearch.Text) & "%','_','9x9x9') or replace(ServerName,'_','9x9x9') like replace('%" & Trim(txtSearch.Text) & "%','_','9x9x9'))"
        End If
        SetgvRegister(wh)
    End Sub

    Private Sub SetgvRegister(wh As String) ' ข้อมูล register ใน datagridview 

        Dim dt As DataTable
        Dim REng As New UserEng

        dt = REng.GetgvRegister(wh)

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvRegister.DataSource = dt
            gvRegister.DataBind()
            Cache("Data") = dt ' เก็บค่าเพื่อเอาไปใช้กับ Paging gridview ใน event PageIndexChanging

            If dt.Rows.Count = 0 Then
                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvRegister.DataSource = dt
                gvRegister.DataBind()
                Dim columnCount As Integer = gvRegister.Rows(0).Cells.Count
                gvRegister.Rows(0).Cells.Clear()
                gvRegister.Rows(0).Cells.Add(New TableCell)
                gvRegister.Rows(0).Cells(0).ColumnSpan = columnCount
                gvRegister.Rows(0).Cells(0).Text = "No Records Found."
            End If

        Else
            gvRegister.DataSource = Nothing
        End If

    End Sub

    Protected Sub gvRegister_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvRegister.RowCommand

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRegister", "TabRegister();", True)

        Dim lnq As New TbRegisterLinqDB
        Dim trans As New TransactionDB
        Dim ret As Boolean = False

        If e.CommandName = "DeleteRow" Then 'คำสั่ง delete

            Dim confirmValue As String = Request.Form("confirm_value")

            If confirmValue = "Yes" Then

                Dim RowIndex As Integer
                Integer.TryParse(e.CommandArgument.ToString, RowIndex)

                ret = lnq.DeleteByPK(RowIndex, trans.Trans)
                If ret = True Then

                    trans.CommitTransaction()
                    btnSearch_Click(sender, e)
                    ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Delete Data Complete!');", True)
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRegister", "TabRegister();", True)
                Else
                    trans.RollbackTransaction()
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "Confirm value", "alert('Can not Delete data')", True)
                End If
            End If
        End If

        If e.CommandName = "EditRow" Then ' คำสั่ง edit

            Dim lblID As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lblID = CType(gvRegister.Rows(RowIndex).FindControl("LabelID"), Label)
            If lblID.Text > 0 Then
                Response.Redirect("frmRegisterForm.aspx?ID=" & lblID.Text & "")
            End If
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabRegister", "TabRegister();", True)
        End If

    End Sub

    Protected Sub gvRegister_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvRegister.PageIndexChanging
        btnSearch_Click(sender, e)
        gvRegister.PageIndex = e.NewPageIndex
        gvRegister.DataSource = CType(Cache("Data"), DataTable)
        gvRegister.DataBind()
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        'divdata.Attributes.Clear()
        'divgrid.Attributes.Add("style", "display:none")
        '' btnBack.Visible = True
        'btnNew.Visible = False
        Response.Redirect("frmRegisterForm.aspx")
    End Sub

    'Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
    '    divgrid.Attributes.Clear()
    '    divdata.Attributes.Add("style", "display:none")
    '    btnNew.Visible = True
    '    ' btnBack.Visible = False
    'End Sub
End Class

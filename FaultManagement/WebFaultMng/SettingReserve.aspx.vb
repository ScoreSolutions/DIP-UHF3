Imports Engine
Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.IO
Imports Globals

Partial Class SettingReserve
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim trans As New TransactionDB
        Dim lnq As New TbUserLinqDB
        Label1.Text = Globals.uData.USERNAME





        If Not IsPostBack Then
            btnBrownparthfile.Attributes.Add("onclick", "showModal('frmAddPathFile.aspx',600,400,0)")

            btnSerchipRAM.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx',600,400,0)")
            btnSerchGroupRAM.Attributes.Add("onclick", "showModal('frmPopupSearchGroup.aspx',600,400,0)")

            btnSerchipCPU.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx',600,400,0)")
            btnSerchGroupCPU.Attributes.Add("onclick", "showModal('frmPopupSearchGroup.aspx',600,400,0)")

            btnSerchipDrive.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx',600,400,0)")
            btnSerchipService.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx',600,400,0)")
            btnSerchipProcess.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx',600,400,0)")
            btnSerchipFileSize.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx',600,400,0)")
            chkByGroupRAM.Checked = False
            chkByServerRAM.Checked = True

            

            ddlDriveName()


            GetShowServiec()
            GetShowProcess()
        End If

        SetgvRAM()
        SetgvDrive()
        SetgvCPU()
        SetgvService()
        SetgvProcess()
        SetgvFileSize()
        GetgvCfPortList()
    End Sub

    Public Sub SetgvRAM()
        Dim dt As New DataTable
        Dim eng As New Web_Config.RAMEng

        dt = eng.GetgvRAM("")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next
            gvRAM.DataSource = dt
            gvRAM.DataBind()

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

        'chkActiveStatus.Checked = False
        chkByGroupRAM.Checked = False
        chkByServerRAM.Checked = True
        chkActiveStatusRAM.Checked = True
        lblidRAM.Text = "0"
        chkByGroupCPU.Checked = False
        chkByServerCPU.Checked = True
        chkActiveStatusCPU.Checked = True
        lblidCPU.Text = "0"
    End Sub
    Private Function ValidateRAM() As Boolean

        If chkByServerRAM.Checked = True Then

            If txtServeripRAM.Text.Trim() = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server IP !"");</script>")
                Return False
            End If
            If txtServernameRAM.Text.Trim() = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server Name !"");</script>")
                Return False
            End If
            If txtMacAddressRAM.Text.Trim() = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server MacAddress !"");</script>")
                Return False
            End If
        Else
            If txtGroupRAM.Text.Trim() = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server MacAddress !"");</script>")
                Return False
            End If
        End If


        If txtRepeatCheckRAM.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat check !"");</script>")
            Return False
        End If
        If txtIntervalRAM.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check IntervalRAM !"");</script>")
            Return False
        End If

        If txtMinorRAM.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Minor !"");</script>")
            Return False
        End If
        If txtMajorRAM.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Major !"");</script>")
            Return False
        End If
        If txtCriticalRAM.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Critical !"");</script>")
            Return False
        End If


        Dim REng As New RAMEng
        If REng.CheckDuplicateRegister(Convert.ToInt64(lblidRAM.Text), txtServeripRAM.Text.Trim(), txtServernameRAM.Text.Trim(), txtMacAddressRAM.Text.Trim()) = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (REng.ErrorMessage), True)
            REng = Nothing
            Return False
        End If

        REng = Nothing
        Return True

    End Function
    Private Function GetIDcfRAM(ByVal ServerIP As String) As String
        Dim Reng As New Web_Config.RAMEng
        Dim id As String
        Dim dt As New DataTable
        If dt.Rows.Count > 0 Then
            id = dt.Rows(0)(0).ToString()
        Else
            id = 0
        End If

        Return id

    End Function
    Protected Sub btnSaveRAM_Click(sender As Object, e As EventArgs) Handles btnSaveRAM.Click

        If ValidateRAM() = False Then
            Return
        End If


        Dim Reng As New Web_Config.RAMEng

        If (chkByServerRAM.Checked = True) Then
            Dim lnq As New CfConfigRamLinqDB
            Dim trans As New TransactionDB
            Dim checkIDcfRAM As String


            checkIDcfRAM = lblidRAM.Text
            If Convert.ToInt64(checkIDcfRAM) > 0 Then
                lnq.GetDataByPK(Convert.ToInt64(checkIDcfRAM), trans.Trans)
            End If



            lnq.SERVERIP = txtServeripRAM.Text
            lnq.SERVERNAME = txtServernameRAM.Text
            lnq.MACADDRESS = txtMacAddressRAM.Text
            'lnq.REPEATCHECKQTY = txtRepeatCheckRAM.Text
            lnq.CHECKINTERVALMINUTE = txtIntervalRAM.Text
            lnq.ALARMMINORVALUE = txtMinorRAM.Text
            lnq.ALARMMAJORVALUE = txtMajorRAM.Text
            lnq.ALARMCRITICALVALUE = txtCriticalRAM.Text

            If chkActiveStatusRAM.Checked Then
                lnq.ACTIVESTATUS = Convert.ToChar("Y")

            Else
                lnq.ACTIVESTATUS = Convert.ToChar("N")
            End If


            Dim ret As Boolean = False

            If (lnq.ID > 0) Then
                ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)

            Else
                ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()
                Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")



            Else
                trans.RollbackTransaction()
                Response.Write("<script language=""javaScript"">alert(""Not Save data !"");</script>")

            End If

            lnq = Nothing

        End If


        If (chkByGroupRAM.Checked = True) Then
            Dim dt As DataTable
            Dim IDcfRAM As String
            dt = Reng.gvByGroup("group_desc = '" & txtGroupRAM.Text & "'")

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim d As String = dt.Rows(i)(5).ToString()
                Dim lnq As New CfConfigRamLinqDB
                Dim trans As New TransactionDB

                IDcfRAM = Reng.GetIDcfRAM(dt.Rows(i)(5).ToString())

                If Convert.ToInt64(IDcfRAM) > 0 Then
                    lnq.GetDataByPK(Convert.ToInt64(IDcfRAM), trans.Trans)
                End If



                lnq.SERVERIP = dt.Rows(i)(5).ToString()
                lnq.SERVERNAME = dt.Rows(i)(4).ToString()
                lnq.MACADDRESS = dt.Rows(i)(6).ToString()
                'lnq.REPEATCHECKQTY = txtRepeatCheckRAM.Text
                lnq.CHECKINTERVALMINUTE = txtIntervalRAM.Text
                lnq.ALARMMINORVALUE = txtMinorRAM.Text
                lnq.ALARMMAJORVALUE = txtMajorRAM.Text
                lnq.ALARMCRITICALVALUE = txtCriticalRAM.Text

                If chkActiveStatusRAM.Checked Then
                    lnq.ACTIVESTATUS = Convert.ToChar("Y")

                Else
                    lnq.ACTIVESTATUS = Convert.ToChar("N")
                End If


                Dim ret As Boolean = False

                If (lnq.ID > 0) Then
                    ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)

                Else
                    ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
                End If

                If ret = True Then
                    trans.CommitTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")



                Else
                    trans.RollbackTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Not Save data !"");</script>")

                End If

                lnq = Nothing





            Next

        End If


        ClearTextBox(Me)
        SetgvRAM()
    End Sub
    Protected Sub btnCancelRAM_Click(sender As Object, e As EventArgs) Handles btnCancelRAM.Click
        ClearTextBox(Me)
    End Sub
    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Dim Leng As New Web_Config.LoginENG
        Leng.Logout(Globals.uData.LOGIN_HISTORY_ID)
        Response.Redirect("frmLogin.aspx")
    End Sub
    Protected Sub gvRAM_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvRAM.RowCommand
        Dim trans As New TransactionDB
        Dim lnq As New CfConfigRamLinqDB
        Dim ret As Boolean = False



        If e.CommandName = "EditRow" Then

            Dim lblID As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lblID = CType(gvRAM.Rows(RowIndex).FindControl("lblidcfRAM"), Label)
            lnq.GetDataByPK(lblID.Text, trans.Trans)

            Dim GroupName As Label = CType(gvRAM.Rows(RowIndex).FindControl("lblgroup_desc"), Label)
            txtGroupRAM.Text = GroupName.Text
            If lnq.ID > 0 Then

                txtServeripRAM.Text = lnq.SERVERIP
                txtServernameRAM.Text = lnq.SERVERNAME
                txtMacAddressRAM.Text = lnq.MACADDRESS
                'txtRepeatCheckRAM.Text = lnq.REPEATCHECKQTY
                txtMinorRAM.Text = lnq.ALARMMINORVALUE
                txtMajorRAM.Text = lnq.ALARMMAJORVALUE
                txtCriticalRAM.Text = lnq.ALARMCRITICALVALUE
                txtIntervalRAM.Text = lnq.CHECKINTERVALMINUTE
                lblidRAM.Text = lnq.ID


                If lnq.ACTIVESTATUS = "Y" Then
                    chkActiveStatusRAM.Checked = True
                Else
                    chkActiveStatusRAM.Checked = False
                End If

                chkByServerRAM.Checked = True
                chkByGroupRAM.Checked = False

            End If

        End If


        If e.CommandName = "DeleteRow" Then
            Dim lblID As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lblID = CType(gvRAM.Rows(RowIndex).FindControl("lblidcfRAM"), Label)
            Dim id As Integer = lblID.Text


            ret = lnq.DeleteByPK(id, trans.Trans)
            If ret = True Then


                trans.CommitTransaction()
                ClearTextBox(Me)
                SetgvRAM()

            Else
                trans.RollbackTransaction()
                Response.Write("<script language=""javaScript"">alert(""Can not Delete Data"");</script>")
            End If
            ClearTextBox(Me)
        End If


    End Sub
    Protected Sub btnSerchipRAM_Click(sender As Object, e As EventArgs) Handles btnSerchipRAM.Click
       
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "chkServer", "chkServer();", True)


        txtServeripRAM.Text = Session("_serverip")
        txtServernameRAM.Text = Session("_servername")
        txtMacAddressRAM.Text = Session("_macaddress")
    End Sub
    Protected Sub btnSerchGroupRAM_Click(sender As Object, e As EventArgs) Handles btnSerchGroupRAM.Click

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "chkGroup", "chkGroup();", True)

        txtGroupRAM.Text = Session("_group")

    End Sub
 

    'Drive---------------------------------------------------------------------------------------------

    Public Sub ClearTextBox_Drive()

        txtServerIPDriver.Text = ""
        txtServerNameDrive.Text = ""
        txtMacAddressDrive.Text = ""
        txtMinorDrive.Text = ""
        txtMajorDrive.Text = ""
        txtCriticalDrive.Text = ""
        txtRepeatCheckDrive.Text = ""
        txtIntervalDrive.Text = ""
        lblidDrive.Text = "0"
        lblDriveid.Text = "0"
        ddlDriverName.SelectedValue = "0"


        gvSelectDrive.DataSource = New DataTable
        gvSelectDrive.DataBind()
        chkActiveStatusDrive.Checked = True
        SetgvDrive()
    End Sub
    Protected Sub btnCancelDrive_Click(sender As Object, e As EventArgs) Handles btnCancelDrive.Click
        ClearTextBox_Drive()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
    End Sub
    Public Sub SetgvDrive()
        Dim dt As New DataTable
        Dim Deng As New DriveENG

        dt = Deng._GetgvDrive("")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvDrive.DataSource = dt
            gvDrive.DataBind()
        End If

    End Sub
    Public Sub ddlDriveName()

        Dim dt As New DataTable
        Dim Deng As New DriveENG
        Dim cf As New Config
        If txtServerIPDriver.Text.Trim <> "" Then
            dt = Deng.ddlDriverName("ServerIP = '" & txtServerIPDriver.Text & "'")
        Else
            dt = Deng.ddlDriverName("ServerIP = ''")
        End If

        cf.SetDDLData(dt, ddlDriverName, "DriveLetter", "id", "<-- Select -->", "0")
        Deng = Nothing

    End Sub

    'Public Sub _ddlCheck()
    '    Dim Drive As String = ""
    '    For i As Integer = 0 To gvSelectDrive.Rows.Count - 1
    '        Dim DriveName As Label = CType(gvSelectDrive.Rows(i).FindControl("lblDrivename"), Label)


    '        If DriveName.Text.Trim() <> "" Then
    '            Drive += "'" & DriveName.Text & "',"
    '        End If
    '    Next
    '    If Drive <> "" Then
    '        Drive = Drive.Substring(0, Drive.Length - 1)

    '    End If
    '    Dim dt As New DataTable
    '    Dim Deng As New DriveENG
    '    Dim cf As New Config

    '    dt = Deng.ddlDriverName("ServerIP = '" & txtServerIPDriver.Text & "' and DriveLetter not in(" & Drive & ")")
    '    cf.SetDDLData(dt, ddlDriverName, "DriveLetter", "id", "<-- Select -->", "0")
    'End Sub
    Protected Sub SubmitDriveName_Click(sender As Object, e As EventArgs) Handles SubmitDriveName.Click
       
        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Long))
        dt.Columns.Add("DriveName", GetType(String))
        dt.Columns.Add("Minor", GetType(String))
        dt.Columns.Add("Major", GetType(String))
        dt.Columns.Add("Critical", GetType(String))

        If gvSelectDrive.Rows.Count > 0 Then

            For i As Integer = 0 To gvSelectDrive.Rows.Count - 1

                Dim id As Label = CType(gvSelectDrive.Rows(i).FindControl("lblid"), Label)
                Dim DriveName As Label = CType(gvSelectDrive.Rows(i).FindControl("lblDrivename"), Label)
                Dim Minor As Label = CType(gvSelectDrive.Rows(i).FindControl("lblMinor"), Label)
                Dim Major As Label = CType(gvSelectDrive.Rows(i).FindControl("lblMajor"), Label)
                Dim Critical As Label = CType(gvSelectDrive.Rows(i).FindControl("lblCritical"), Label)

                Dim Drive As String = ddlDriverName.SelectedItem.Text

                If DriveName.Text.Trim() <> Drive.Trim() Then
                    Dim _dr As DataRow
                    _dr = dt.NewRow
                    _dr("id") = id.Text
                    _dr("DriveName") = DriveName.Text
                    _dr("Minor") = Minor.Text
                    _dr("Major") = Major.Text
                    _dr("Critical") = Critical.Text
                    dt.Rows.Add(_dr)
              
                End If
            Next
        End If


        Dim dr As DataRow
        dr = dt.NewRow
        If lblDriveid.Text <> "0" Then
            dr("id") = lblDriveid.Text
        Else
            dr("id") = "0"
        End If

        dr("DriveName") = ddlDriverName.SelectedItem.Text
        dr("Minor") = txtMinorDrive.Text
        dr("Major") = txtMajorDrive.Text
        dr("Critical") = txtCriticalDrive.Text
        dt.Rows.Add(dr)

        gvSelectDrive.DataSource = dt
        gvSelectDrive.DataBind()


        '_ddlCheck()
        ddlDriveName()
        txtMinorDrive.Text = ""
        txtMajorDrive.Text = ""
        txtCriticalDrive.Text = ""
        lblDriveid.Text = "0"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)

    End Sub
    Protected Sub gvSelectDrive_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvSelectDrive.RowCommand
        If e.CommandName = "EditRow" Then
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)

            Dim id As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblid"), Label)
            Dim DriveName As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblDrivename"), Label)
            Dim Minor As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblMinor"), Label)
            Dim Major As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblMajor"), Label)
            Dim Critical As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblCritical"), Label)

            
            Dim _dt As New DataTable
            Dim cf As New Config
            Dim Deng As New DriveENG
            _dt = Deng.ddlDriverName("ServerIP = '" & txtServerIPDriver.Text & "'")
            For i As Integer = 0 To _dt.Rows.Count - 1
                If DriveName.Text = _dt.Rows(i)("DriveLetter").ToString() Then
                    ddlDriverName.SelectedValue = _dt.Rows(i)("id").ToString()
                End If
            Next

            txtMinorDrive.Text = Minor.Text
            txtMajorDrive.Text = Major.Text
            txtCriticalDrive.Text = Critical.Text
            lblDriveid.Text = id.Text
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
        End If


        If e.CommandName = "DeleteRow" Then
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            Dim DeletID As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblid"), Label)
            Dim DeleteDrive As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblDrivename"), Label)

            If DeletID.Text <> "0" Then
                Dim trans As New TransactionDB
                Dim ret As Boolean = False
                Dim lnq As New CfConfigDriveDetailLinqDB
                ret = lnq.DeleteByPK(DeletID.Text, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
                lnq = Nothing
            End If


            Dim dt As New DataTable
            dt.Columns.Add("id", GetType(Long))
            dt.Columns.Add("DriveName", GetType(String))
            dt.Columns.Add("Minor", GetType(String))
            dt.Columns.Add("Major", GetType(String))
            dt.Columns.Add("Critical", GetType(String))


            For i As Integer = 0 To gvSelectDrive.Rows.Count - 1

                Dim id As Label = CType(gvSelectDrive.Rows(i).FindControl("lblid"), Label)
                Dim DriveName As Label = CType(gvSelectDrive.Rows(i).FindControl("lblDrivename"), Label)
                Dim Minor As Label = CType(gvSelectDrive.Rows(i).FindControl("lblMinor"), Label)
                Dim Major As Label = CType(gvSelectDrive.Rows(i).FindControl("lblMajor"), Label)
                Dim Critical As Label = CType(gvSelectDrive.Rows(i).FindControl("lblCritical"), Label)



                If DeleteDrive.Text.Trim() <> DriveName.Text.Trim() Then
                    Dim dr As DataRow
                    dr = dt.NewRow
                    dr("id") = id.Text
                    dr("DriveName") = DriveName.Text
                    dr("Minor") = Minor.Text
                    dr("Major") = Major.Text
                    dr("Critical") = Critical.Text
                    dt.Rows.Add(dr)
                End If

            Next
            gvSelectDrive.DataSource = dt
            gvSelectDrive.DataBind()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
        End If
    End Sub
    Protected Sub ddlDriverName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDriverName.SelectedIndexChanged

        txtMinorDrive.Text = ""
        txtMajorDrive.Text = ""
        txtCriticalDrive.Text = ""

       
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
    End Sub
    Private Function GetIDcfDrive(ByVal ServerIP As String) As String
        Dim Deng As New Web_Config.DriveENG
        Dim id As String
        Dim dt As New DataTable
        If dt.Rows.Count > 0 Then
            id = dt.Rows(0)(0).ToString()
        Else
            id = 0
        End If

        Return id

    End Function
    Protected Sub btnSaveDrive_Click(sender As Object, e As EventArgs) Handles btnSaveDrive.Click

        If ValidateDrive() = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
            Return
        End If

        Dim Deng As New DriveENG
        Dim lnq As New CfConfigDriveLinqDB
        Dim trans As New TransactionDB

        Dim checkIDcfDrive As String


        checkIDcfDrive = lblidDrive.Text
        If Convert.ToInt64(checkIDcfDrive > 0) Then
            lnq.GetDataByPK(Convert.ToInt64(checkIDcfDrive), trans.Trans)
        End If


        lnq.SERVERIP = txtServerIPDriver.Text
        lnq.SERVERNAME = txtServerNameDrive.Text
        lnq.MACADDRESS = txtMacAddressDrive.Text
        lnq.REPEATCHECKQTY = txtRepeatCheckDrive.Text
        lnq.CHECKINTERVALMINUTE = txtIntervalDrive.Text

        If chkActiveStatusDrive.Checked Then
            lnq.ACTIVESTATUS = Convert.ToChar("Y")
        Else
            lnq.ACTIVESTATUS = Convert.ToChar("N")

        End If

        Dim ret As Boolean = False

        If (lnq.ID > 0) Then
            ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)
        Else
            ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
        End If

        If ret = True Then
            trans.CommitTransaction()

            If checkIDcfDrive = 0 Then
                SaveDriveDetail(Deng.GetidMaxDrive(""))
            Else
                SaveDriveDetail(checkIDcfDrive)
            End If


            Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")
        Else
            trans.RollbackTransaction()
            Response.Write("<script language=""javaScript"">alert(""Not Save data !"");</script>")
        End If


        lnq = Nothing
        ClearTextBox_Drive()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)


    End Sub
    Public Sub SaveDriveDetail(ByVal idDrive As String)
     
        For i As Integer = 0 To gvSelectDrive.Rows.Count - 1
            Dim lnq As New CfConfigDriveDetailLinqDB
            Dim trans As New TransactionDB

            Dim id As Label = CType(gvSelectDrive.Rows(i).FindControl("lblid"), Label)
            Dim DriveName As Label = CType(gvSelectDrive.Rows(i).FindControl("lblDrivename"), Label)
            Dim Minor As Label = CType(gvSelectDrive.Rows(i).FindControl("lblMinor"), Label)
            Dim Major As Label = CType(gvSelectDrive.Rows(i).FindControl("lblMajor"), Label)
            Dim Critical As Label = CType(gvSelectDrive.Rows(i).FindControl("lblCritical"), Label)
            Dim _id As Int64 = Convert.ToInt64(id.Text)

            If _id > 0 Then
                lnq.GetDataByPK(_id, trans.Trans)
            End If

            lnq.CF_CONFIG_DRIVE_ID = Convert.ToInt32(idDrive)
            lnq.DRIVELETTER = DriveName.Text
            lnq.ALARMMINORVALUE = Minor.Text
            lnq.ALARMMAJORVALUE = Major.Text
            lnq.ALARMCRITICALVALUE = Critical.Text

            Dim ret As Boolean = False
            If (lnq.ID > 0) Then
                ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)
            Else
                ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
            End If


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            lnq = Nothing

        Next


    End Sub

    'Dim _dtDriveDetail As New DataTable

    'Public Property dtDriveDetail() As DataTable
    '    Set(value As DataTable)
    '        _dtDriveDetail = value
    '    End Set
    '    Get
    '        Return _dtDriveDetail
    '    End Get
    'End Property

    Private Function ValidateDrive() As Boolean

        If txtServerIPDriver.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server IP !"");</script>")
            Return False
        End If
        If txtServerNameDrive.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server Name !"");</script>")
            Return False
        End If
        If txtMacAddressDrive.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server MacAddress !"");</script>")
            Return False
        End If
        If txtIntervalDrive.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Interval !"");</script>")
            Return False
        End If
        If txtRepeatCheckDrive.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat check !"");</script>")
            Return False
        End If
       
        If gvSelectDrive.Rows.Count = 0 Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Drive check !"");</script>")
            Return False
        End If


        Dim Deng As New DriveENG
        If Deng.CheckDuplicateRegister(Convert.ToInt64(lblidDrive.Text), txtServerIPDriver.Text.Trim(), txtServerNameDrive.Text.Trim(), txtMacAddressDrive.Text.Trim()) = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (Deng.ErrorMessage), True)
            Deng = Nothing
            Return False
        End If

        Deng = Nothing
        Return True

    End Function

    Protected Sub gvDrive_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDrive.RowCommand

        Dim Deng As New DriveENG

        If e.CommandName = "EditRow" Then
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigDriveLinqDB
            Dim dt As New DataTable()
            Dim drive_id As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            drive_id = CType(gvDrive.Rows(RowIndex).FindControl("lblcf_config_drive_id"), Label)

            lnq.GetDataByPK(drive_id.Text, trans.Trans)

            If lnq.ID > 0 Then

                dt = Deng.GetgvDrive("cfD.id='" & drive_id.Text & "'")

                Dim dtTypeDrive As New DataTable()
                dtTypeDrive.Columns.Add("id", GetType(String))
                dtTypeDrive.Columns.Add("DriveName", GetType(String))
                dtTypeDrive.Columns.Add("Minor", GetType(String))
                dtTypeDrive.Columns.Add("Major", GetType(String))
                dtTypeDrive.Columns.Add("Critical", GetType(String))

                For i As Integer = 0 To dt.Rows.Count - 1

                    Dim dr As DataRow = dtTypeDrive.NewRow()
                    dr(0) = dt.Rows(i)("idDriveDetail").ToString()
                    dr(1) = dt.Rows(i)("DriveLetter").ToString()
                    dr(2) = dt.Rows(i)("AlarmMinorValue").ToString()
                    dr(3) = dt.Rows(i)("AlarmMajorValue").ToString()
                    dr(4) = dt.Rows(i)("AlarmCriticalValue").ToString()

                    dtTypeDrive.Rows.Add(dr)

                Next
                gvSelectDrive.DataSource = dtTypeDrive
                gvSelectDrive.DataBind()

                txtServerIPDriver.Text = lnq.SERVERIP
                txtServerNameDrive.Text = lnq.SERVERNAME
                txtMacAddressDrive.Text = lnq.MACADDRESS
                txtRepeatCheckDrive.Text = lnq.REPEATCHECKQTY
                txtIntervalDrive.Text = lnq.CHECKINTERVALMINUTE
                lblidDrive.Text = lnq.ID
                ddlDriveName()
                If lnq.ACTIVESTATUS = "Y" Then
                    chkActiveStatusDrive.Checked = True
                Else
                    chkActiveStatusDrive.Checked = False
                End If

               
            End If
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
        End If



        If e.CommandName = "DeleteRow" Then

            Dim CheckIDdrive As Label
            Dim RowIndex As Integer
            Dim dt As New DataTable
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)

         
            CheckIDdrive = CType(gvDrive.Rows(RowIndex).FindControl("lblcf_config_drive_id"), Label)



            Dim _CheckIDdrive As String = CheckIDdrive.Text


            dt = Deng.GetgvDrive("cfD.id='" & CheckIDdrive.Text & "'")
            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1

                    Dim trans As New TransactionDB
                    Dim lnq As New CfConfigDriveDetailLinqDB
                    Dim ret As Boolean = False
                    Dim _id As String = dt.Rows(i)("idDriveDetail").ToString
                    ret = lnq.DeleteByPK(_id, trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()                      
                    End If
                    lnq = Nothing
                Next
            End If
            dt = Deng.GetgvDrive("cfD.id='" & CheckIDdrive.Text & "'")
            If dt.Rows.Count = 0 Then

                Dim ret As Boolean = False
                Dim lnq As New CfConfigDriveLinqDB
                Dim trans As New TransactionDB

                ret = lnq.DeleteByPK(_CheckIDdrive, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()

                Else
                    trans.RollbackTransaction()

                End If
            End If

            ClearTextBox_Drive()
            SetgvDrive()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
        End If

    End Sub
    Protected Sub btnSerchipDrive_Click(sender As Object, e As EventArgs) Handles btnSerchipDrive.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)

        txtServerIPDriver.Text = Session("_serverip")
        txtServerNameDrive.Text = Session("_servername")
        txtMacAddressDrive.Text = Session("_macaddress")
        ddlDriveName()
    End Sub

    '--------------------------------------------------------------------------------CPU
    Protected Sub btnCancelCPU_Click(sender As Object, e As EventArgs) Handles btnCancelCPU.Click
        ClearTextBox(Me)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
    End Sub
    'Public Sub ClearTextBox_CPU(ByVal root As Control)

    '    For Each ctrl As Control In root.Controls
    '        ClearTextBox(ctrl)
    '        If TypeOf ctrl Is TextBox Then
    '            CType(ctrl, TextBox).Text = String.Empty
    '        End If
    '    Next ctrl


    '    chkByGroupCPU.Checked = False
    '    chkByServerCPU.Checked = True
    '    chkActiveStatusCPU.Checked = False

    'End Sub  
    Protected Sub btnSaveCPU_Click(sender As Object, e As EventArgs) Handles btnSaveCPU.Click

        If ValidateCPU() = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
            Return
        End If

        If (chkByServerCPU.Checked = True) Then
            Dim Ceng As New CPUEng
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigCpuLinqDB
            Dim dt As New DataTable
            Dim checkIDcfCPU As String

            'checkIDcfCPU = Ceng.GetIDcfCPU(txtServeripCPU.Text)
            checkIDcfCPU = lblidCPU.Text
            If Convert.ToInt64(checkIDcfCPU > 0) Then
                lnq.GetDataByPK(Convert.ToInt64(checkIDcfCPU), trans.Trans)
            End If


            lnq.SERVERIP = txtServeripCPU.Text
            lnq.SERVERNAME = txtServerNameCPU.Text
            lnq.MACADDRESS = txtMacAddressCPU.Text
            'lnq.REPEATCHECKQTY = txtRepeatCheckCPU.Text
            lnq.CHECKINTERVALMINUTE = txtIntervalCPU.Text
            lnq.ALARMMINORVALUE = txtMinorCPU.Text
            lnq.ALARMMAJORVALUE = txtMajorCPU.Text
            lnq.ALARMCRITICALVALUE = txtCriticalCPU.Text

            If chkActiveStatusCPU.Checked Then
                lnq.ACTIVESTATUS = Convert.ToChar("Y")
            Else
                lnq.ACTIVESTATUS = Convert.ToChar("N")

            End If

            Dim ret As Boolean = False

            If (lnq.ID > 0) Then
                ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)
            Else
                ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
            End If


            If ret = True Then
                trans.CommitTransaction()
                Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")
            Else
                trans.RollbackTransaction()
                Response.Write("<script language=""javaScript"">alert(""Not Save data !"");</script>")
            End If


            lnq = Nothing
        End If

        If (chkByGroupCPU.Checked = True) Then
            Dim Ceng As New CPUEng
            Dim dt As New DataTable
            Dim IDcfRAM As String
            Dim Reng As New RAMEng
            dt = Reng.gvByGroup("group_desc = '" & txtGroupCPU.Text & "'")

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim d As String = dt.Rows(i)(5).ToString()
                Dim lnq As New CfConfigCpuLinqDB
                Dim trans As New TransactionDB


                IDcfRAM = Ceng.GetIDcfCPU(dt.Rows(i)(5).ToString())
                'IDcfRAM = lblidCPU.Text
                If Convert.ToInt64(IDcfRAM) > 0 Then
                    lnq.GetDataByPK(Convert.ToInt64(IDcfRAM), trans.Trans)
                End If



                lnq.SERVERIP = dt.Rows(i)(5).ToString()
                lnq.SERVERNAME = dt.Rows(i)(4).ToString()
                lnq.MACADDRESS = dt.Rows(i)(6).ToString()
                'lnq.REPEATCHECKQTY = txtRepeatCheckCPU.Text
                lnq.CHECKINTERVALMINUTE = txtIntervalCPU.Text
                lnq.ALARMMINORVALUE = txtMinorCPU.Text
                lnq.ALARMMAJORVALUE = txtMajorCPU.Text
                lnq.ALARMCRITICALVALUE = txtCriticalCPU.Text

                If chkActiveStatusCPU.Checked Then
                    lnq.ACTIVESTATUS = Convert.ToChar("Y")

                Else
                    lnq.ACTIVESTATUS = Convert.ToChar("N")
                End If


                Dim ret As Boolean = False

                If (lnq.ID > 0) Then
                    ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)

                Else
                    ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
                End If

                If ret = True Then
                    trans.CommitTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")



                Else
                    trans.RollbackTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Not Save data !"");</script>")

                End If

                lnq = Nothing
            Next

        End If

        SetgvCPU()
        ClearTextBox(Me)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
    End Sub
    Public Sub SetgvCPU()
        Dim dt As New DataTable
        Dim Ceng As New CPUEng

        dt = Ceng.GetgvCPU("")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvCPU.DataSource = dt
            gvCPU.DataBind()

        End If



    End Sub
    Protected Sub gvCPU_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCPU.RowCommand


        If e.CommandName = "EditRow" Then
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigCpuLinqDB
            Dim lblID As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lblID = CType(gvCPU.Rows(RowIndex).FindControl("lblidcfCPU"), Label)
            lnq.GetDataByPK(lblID.Text, trans.Trans)


            Dim GroupName As Label = CType(gvCPU.Rows(RowIndex).FindControl("lblgroup_desc"), Label)
            txtGroupCPU.Text = GroupName.Text

            If lnq.ID > 0 Then


                txtServeripCPU.Text = lnq.SERVERIP
                txtServerNameCPU.Text = lnq.SERVERNAME
                txtMacAddressCPU.Text = lnq.MACADDRESS
                'txtRepeatCheckCPU.Text = lnq.REPEATCHECKQTY
                txtIntervalCPU.Text = lnq.CHECKINTERVALMINUTE
                txtMinorCPU.Text = lnq.ALARMMINORVALUE
                txtMajorCPU.Text = lnq.ALARMMAJORVALUE
                txtCriticalCPU.Text = lnq.ALARMCRITICALVALUE
                lblidCPU.Text = lnq.ID

                If lnq.ACTIVESTATUS = "Y" Then
                    chkActiveStatusCPU.Checked = True
                Else
                    chkActiveStatusCPU.Checked = False
                End If


                chkByServerCPU.Checked = True
                chkByGroupCPU.Checked = False
            End If
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
        End If


        If e.CommandName = "DeleteRow" Then
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigCpuLinqDB
            Dim ret As Boolean = False
            Dim lblID As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lblID = CType(gvCPU.Rows(RowIndex).FindControl("lblidcfCPU"), Label)
            Dim id As Integer = lblID.Text

            ret = lnq.DeleteByPK(id, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
                SetgvCPU()

            Else
                trans.RollbackTransaction()
                Response.Write("<script language=""javaScript"">alert(""Can not Delete Data"");</script>")
            End If
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
            ClearTextBox(Me)
        End If

    End Sub
    Private Function ValidateCPU() As Boolean

        If chkByServerCPU.Checked = True Then

            If txtServeripCPU.Text.Trim() = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server IP CPU!"");</script>")
                Return False
            End If
            If txtServerNameCPU.Text.Trim() = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server Name CPU!"");</script>")
                Return False
            End If
            If txtMacAddressCPU.Text.Trim() = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server MacAddress CPU!"");</script>")
                Return False
            End If
        Else
            If txtGroupCPU.Text.Trim() = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server Group CPU!"");</script>")
                Return False
            End If
        End If


        If txtRepeatCheckCPU.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat check!"");</script>")
            Return False
        End If
        If txtIntervalCPU.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Interval !"");</script>")
            Return False
        End If

        If txtMinorCPU.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Minor!"");</script>")
            Return False
        End If
        If txtMajorCPU.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Major!"");</script>")
            Return False
        End If
        If txtCriticalCPU.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Critical!"");</script>")
            Return False
        End If



        Dim CEng As New CPUEng
        If CEng.CheckDuplicateRegister(Convert.ToInt64(lblidCPU.Text), txtServeripCPU.Text.Trim(), txtServerNameCPU.Text.Trim(), txtMacAddressCPU.Text.Trim()) = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (CEng.ErrorMessage), True)
            CEng = Nothing
            Return False
        End If

        CEng = Nothing
        Return True

    End Function
    Protected Sub btnSerchipCPU_Click(sender As Object, e As EventArgs) Handles btnSerchipCPU.Click

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "chkServer", "chkServerCPU();", True)
        txtServeripCPU.Text = Session("_serverip")
        txtServerNameCPU.Text = Session("_servername")
        txtMacAddressCPU.Text = Session("_macaddress")

    End Sub
    Protected Sub btnSerchGroupCPU_Click(sender As Object, e As EventArgs) Handles btnSerchGroupCPU.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "chkGroup", "chkGroupCPU(); ", True)
        txtGroupCPU.Text = Session("_group")

    End Sub


    '------------------------------------------------------------------------------------------Service

    Private Function ValidateService() As Boolean

        If txtServeripService.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server IP !"");</script>")
            Return False
        End If
        If txtServerNameService.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server Name !"");</script>")
            Return False
        End If
        If txtMacAddressService.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server MacAddress !"");</script>")
            Return False
        End If
        If txtIntervalService.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Interval !"");</script>")
            Return False
        End If
        If txtRepeatCheckService.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat check!"");</script>")
            Return False
        End If

        'Dim Seng As New ServiceENG
        'If Seng.CheckDuplicateRegister(Convert.ToInt64(lblidCPU.Text), txtServeripCPU.Text.Trim(), txtServerNameCPU.Text.Trim(), txtMacAddressCPU.Text.Trim()) = True Then
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (Seng.ErrorMessage), True)
        '    Seng = Nothing
        '    Return False
        'End If
        'Seng = Nothing
        Return True

    End Function
    Public Sub GetShowServiec()
        Dim dt As New DataTable
        Dim Seng As New ServiceENG

        dt = Seng.SetShowService("")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvShowService.DataSource = dt
            gvShowService.DataBind()

        End If

    End Sub
    Public Sub SetgvService()
        Dim dt As DataTable
        Dim Seng As New ServiceENG

        dt = Seng._SetgvService("")
        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvService.DataSource = dt
            gvService.DataBind()

        End If
    End Sub
    Public Sub CheckIdcfService(ByVal wh As String)
        Dim dt As New DataTable
        Dim dtService As DataTable
        Dim Seng As New ServiceENG

        For m As Integer = 0 To gvShowService.Rows.Count - 1
            Dim chkService As CheckBox = DirectCast(gvShowService.Rows(m).FindControl("chkService"), CheckBox)
            If chkService.Checked = True Then
                chkService.Checked = False
            End If

        Next

        dtService = Seng.SetShowService("")

        dt = Seng.SetgvService("CF.ServerIP = '" & wh & "'")


        Dim table As New DataTable()



        For i As Integer = 0 To dt.Rows.Count - 1

            Dim idDt As String
            idDt = dt.Rows(i)("ms_service_checklist_id").ToString()

            For j As Integer = 0 To dtService.Rows.Count - 1
                Dim idDtService As String = dtService.Rows(j)("id").ToString()

                If idDt.Trim() = idDtService.Trim() Then

                    Dim chkService As CheckBox = DirectCast(gvShowService.Rows(j).FindControl("chkService"), CheckBox)
                    chkService.Checked = True

                    Exit For
                End If


            Next

        Next




    End Sub
    Private Function CheckIdConfig(ByVal idConfig As String, ByVal ServerIP As String) As String
        Dim id As String
        Dim dt As New DataTable
        Dim Seng As New ServiceENG

        dt = Seng.SetgvService("CF.ms_service_checklist_id = '" & idConfig & "' and CF.ServerIP = '" & ServerIP & "'")

        If dt.Rows.Count > 0 Then
            id = dt.Rows(0)(0).ToString
        Else
            id = "0"
        End If



        Return id
    End Function
    Protected Sub btnSaveService_Click(sender As Object, e As EventArgs) Handles btnSaveService.Click


        If ValidateService() = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True)
            Return
        End If


        For i As Integer = 0 To gvShowService.Rows.Count - 1


            Dim chkService As CheckBox = DirectCast(gvShowService.Rows(i).FindControl("chkService"), CheckBox)

            If chkService.Checked = True Then



                Dim trans As New TransactionDB
                Dim lnq As New CfConfigServiceLinqDB
                Dim checkIDcfService As String
                Dim Seng As New ServiceENG


                Dim Service_checklist_id As String

                Dim ID As Label = DirectCast(gvShowService.Rows(i).FindControl("lblid"), Label)
                Service_checklist_id = ID.Text



                checkIDcfService = CheckIdConfig(Service_checklist_id, txtServeripService.Text)

                If Convert.ToInt64(checkIDcfService > 0) Then
                    lnq.GetDataByPK(Convert.ToInt64(checkIDcfService), trans.Trans)
                End If


                lnq.SERVERIP = txtServeripService.Text
                lnq.SERVERNAME = txtServerNameService.Text
                lnq.MACADDRESS = txtMacAddressService.Text
                lnq.CHECKINTERVALMINUTE = txtIntervalService.Text
                'lnq.REPEATCHECKQTY = txtRepeatCheckService.Text
                'lnq.MS_SERVICE_CHECKLIST_ID = Service_checklist_id


                If chkActiveStatusService.Checked = True Then
                    lnq.ACTIVESTATUS = Convert.ToChar("Y")
                Else
                    lnq.ACTIVESTATUS = Convert.ToChar("N")
                End If

                Dim ret As Boolean = False
                If (lnq.ID > 0) Then
                    ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)

                Else
                    ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
                End If

                If ret = True Then
                    trans.CommitTransaction()

                Else
                    trans.RollbackTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Not Save data !"");</script>")

                End If

                lnq = Nothing
            End If




            If chkService.Checked = False Then
                Dim checkIDcfService As String
                Dim Service_checklist_id As String
                Dim ID As Label = DirectCast(gvShowService.Rows(i).FindControl("lblid"), Label)
                Service_checklist_id = ID.Text

                If txtServeripService.Text.Trim() <> "" Then
                    checkIDcfService = CheckIdConfig(Service_checklist_id, txtServeripService.Text)

                    If checkIDcfService.Trim() <> "0" Then
                        Dim trans As New TransactionDB
                        Dim lnq As New CfConfigServiceLinqDB
                        Dim ret As Boolean = False


                        ret = lnq.DeleteByPK(Convert.ToInt32(checkIDcfService), trans.Trans)
                        If ret = True Then
                            trans.CommitTransaction()

                        Else
                            trans.RollbackTransaction()
                            Response.Write("<script language=""javaScript"">alert(""Can not Delete Data"");</script>")
                        End If

                    End If

                End If
            End If

        Next

        ClearService()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True)
    End Sub

    'Dim _EditIdService As String

    'Public Property EditIdService() As String
    '    Set(value As String)
    '        _EditIdService = value
    '    End Set
    '    Get
    '        Return _EditIdService
    '    End Get
    'End Property
    Protected Sub gvService_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvService.RowCommand

        If e.CommandName = "EditRow" Then
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigServiceLinqDB
            Dim dt As New DataTable

            Dim lblServiceIP As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)

            lblServiceIP = CType(gvService.Rows(RowIndex).FindControl("lblServerIP"), Label)

            Dim _id As String = _Idservice(lblServiceIP.Text)

            lnq.GetDataByPK(_id, trans.Trans)


            If lnq.ID > 0 Then

                CheckIdcfService(lblServiceIP.Text)

                txtServeripService.Text = lnq.SERVERIP
                txtServerNameService.Text = lnq.SERVERNAME
                txtMacAddressService.Text = lnq.MACADDRESS
                'txtRepeatCheckService.Text = lnq.REPEATCHECKQTY
                txtIntervalService.Text = lnq.CHECKINTERVALMINUTE


                If lnq.ACTIVESTATUS = "Y" Then
                    chkActiveStatusService.Checked = True
                Else
                    chkActiveStatusService.Checked = False
                End If


            End If

        End If


        If e.CommandName = "DeleteRow" Then
           

            Dim lblServiceIP As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lblServiceIP = CType(gvService.Rows(RowIndex).FindControl("lblServerIP"), Label)

            Dim Seng As New ServiceENG
            Dim dt As New DataTable
            dt = Seng.SetgvService("ServerIP = '" & lblServiceIP.Text & "'")

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim trans As New TransactionDB
                Dim lnq As New CfConfigServiceLinqDB
                Dim ret As Boolean = False
                Dim id As String = dt.Rows(i)(0).ToString
                ret = lnq.DeleteByPK(id, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Can not Delete Data"");</script>")
                End If
                lnq = Nothing

            Next

            SetgvService()
            CheckIdcfService(lblServiceIP.Text)
            ClearService()
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True)
    End Sub

    Public Function _Idservice(ByVal ip As String) As String
        Dim dt As DataTable
        Dim Seng As New ServiceENG
        Dim id As String = ""

        dt = Seng.SetgvService("ServerIP = '" & ip & "'")
        id = dt.Rows(0)(0).ToString()
        Return id
    End Function
    Protected Sub btnCancelService_Click(sender As Object, e As EventArgs) Handles btnCancelService.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True)
    End Sub
    Protected Sub btnSerchipService_Click(sender As Object, e As EventArgs) Handles btnSerchipService.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True)
        txtServeripService.Text = Session("_serverip")
        txtServerNameService.Text = Session("_servername")
        txtMacAddressService.Text = Session("_macaddress")
    End Sub
    Public Sub ClearService()
        txtServeripService.Text = ""
        txtServerNameService.Text = ""
        txtMacAddressService.Text = ""
        txtRepeatCheckService.Text = ""
        txtIntervalService.Text = ""
        chkActiveStatusService.Checked = True

        GetShowServiec()
        SetgvService()

    End Sub

    '------------------------------------------------------------------------------------------Process

    Private Function ValidateProcess() As Boolean

        If txtServeripProcess.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server IP !"");</script>")
            Return False
        End If
        If txtServernameProcess.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server Name !"");</script>")
            Return False
        End If
        If txtMacAddressProcess.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server MacAddress !"");</script>")
            Return False
        End If
        If txtIntervalProcess.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Interval !"");</script>")
            Return False
        End If
        If txtRepeatCheckProcess.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat check!"");</script>")
            Return False
        End If

        'Dim Seng As New ServiceENG
        'If Seng.CheckDuplicateRegister(Convert.ToInt64(lblidCPU.Text), txtServeripCPU.Text.Trim(), txtServerNameCPU.Text.Trim(), txtMacAddressCPU.Text.Trim()) = True Then
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (Seng.ErrorMessage), True)
        '    Seng = Nothing
        '    Return False
        'End If
        'Seng = Nothing
        Return True

    End Function
    Public Sub GetShowProcess()
        Dim dt As New DataTable
        Dim Seng As New ProcessENG

        dt = Seng.SetShowProcess("")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvShowProcess.DataSource = dt
            gvShowProcess.DataBind()

        End If

    End Sub
    Public Sub SetgvProcess()
        Dim dt As DataTable
        Dim Peng As New ProcessENG

        dt = Peng._SetgvProcess("")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvProcess.DataSource = dt
            gvProcess.DataBind()

        End If
    End Sub 
    Private Function CheckIdConfigProcess(ByVal idConfig As String, ByVal ServerIP As String) As String
        Dim id As String
        Dim dt As New DataTable
        Dim Seng As New ProcessENG

        dt = Seng.SetgvProcess("CF.ms_process_checklist_id = '" & idConfig & "' and CF.ServerIP = '" & ServerIP & "'")

        If dt.Rows.Count > 0 Then
            id = dt.Rows(0)(0).ToString
        Else
            id = "0"
        End If



        Return id
    End Function
    Protected Sub btnSaveProcess_Click(sender As Object, e As EventArgs) Handles btnSaveProcess.Click

        If ValidateProcess() = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivProcess", "DivProcess();", True)
            Return
        End If

        For i As Integer = 0 To gvShowProcess.Rows.Count - 1

            Dim chkProcess As CheckBox = DirectCast(gvShowProcess.Rows(i).FindControl("chkProcess"), CheckBox)

            If chkProcess.Checked = True Then
                Dim trans As New TransactionDB
                Dim lnq As New CfConfigProcessLinqDB
                Dim Process_checklist_id As String
                Dim CheckIdcfProcess As String

                Dim ID As Label = DirectCast(gvShowService.Rows(i).FindControl("lblid"), Label)
                Process_checklist_id = ID.Text


                CheckIdcfProcess = CheckIdConfigProcess(Process_checklist_id, txtServeripProcess.Text)

                If Convert.ToInt64(CheckIdcfProcess > 0) Then
                    lnq.GetDataByPK(Convert.ToInt64(CheckIdcfProcess), trans.Trans)
                End If


                lnq.SERVERIP = txtServeripProcess.Text
                lnq.SERVERNAME = txtServernameProcess.Text
                lnq.MACADDRESS = txtMacAddressProcess.Text
                lnq.CHECKINTERVALMINUTE = txtIntervalProcess.Text
                'lnq.REPEATCHECKQTY = txtRepeatCheckProcess.Text
                'lnq.MS_PROCESS_CHECKLIST_ID = Process_checklist_id


                If chkActiveStatusProcess.Checked = True Then
                    lnq.ACTIVESTATUS = Convert.ToChar("Y")
                Else
                    lnq.ACTIVESTATUS = Convert.ToChar("N")
                End If


                Dim ret As Boolean = False
                If (lnq.ID > 0) Then
                    ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)

                Else
                    ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
                End If

                If ret = True Then
                    trans.CommitTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")


                Else
                    trans.RollbackTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Not Save data !"");</script>")

                End If

                lnq = Nothing

            End If

            If chkProcess.Checked = False Then

                Dim checkIDcfProcess As String
                Dim Process_checklist_id As String
                Dim ID As Label = DirectCast(gvShowProcess.Rows(i).FindControl("lblid"), Label)
                Process_checklist_id = ID.Text

                If txtServeripProcess.Text.Trim() <> "" Then
                    checkIDcfProcess = CheckIdConfigProcess(Process_checklist_id, txtServeripProcess.Text)

                    If checkIDcfProcess.Trim() <> "0" Then
                        Dim trans As New TransactionDB
                        Dim lnq As New CfConfigProcessLinqDB
                        Dim ret As Boolean = False


                        ret = lnq.DeleteByPK(Convert.ToInt32(checkIDcfProcess), trans.Trans)
                        If ret = True Then
                            trans.CommitTransaction()
                        Else
                            trans.RollbackTransaction()
                            Response.Write("<script language=""javaScript"">alert(""Can not Delete Data"");</script>")
                        End If

                    End If

                End If
            End If

        Next

        ClearProcess()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivProcess", "DivProcess();", True)
    End Sub
    Protected Sub gvProcess_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvProcess.RowCommand
        If e.CommandName = "EditRow" Then
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigProcessLinqDB
            Dim dt As New DataTable

            Dim lblServiceIP As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)

            lblServiceIP = CType(gvProcess.Rows(RowIndex).FindControl("lblServerIP"), Label)

            Dim _id As String = _IdProcess(lblServiceIP.Text)
            lnq.GetDataByPK(_id, trans.Trans)

            If lnq.ID > 0 Then

                CheckIdcfProcess(lblServiceIP.Text)

                txtServeripProcess.Text = lnq.SERVERIP
                txtServernameProcess.Text = lnq.SERVERNAME
                txtMacAddressProcess.Text = lnq.MACADDRESS
                'txtRepeatCheckProcess.Text = lnq.REPEATCHECKQTY
                txtIntervalProcess.Text = lnq.CHECKINTERVALMINUTE


                If lnq.ACTIVESTATUS = "Y" Then
                    chkActiveStatusProcess.Checked = True
                Else
                    chkActiveStatusProcess.Checked = False
                End If


            End If

        End If


        If e.CommandName = "DeleteRow" Then


       
            Dim lblServiceIP As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lblServiceIP = CType(gvProcess.Rows(RowIndex).FindControl("lblServerIP"), Label)

            Dim Peng As New ProcessENG
            Dim dt As New DataTable

            dt = Peng.SetgvProcess("ServerIP = '" & lblServiceIP.Text & "'")

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim id As Integer = dt.Rows(i)(0).ToString
                Dim trans As New TransactionDB
                Dim lnq As New CfConfigProcessLinqDB
                Dim ret As Boolean = False
                ret = lnq.DeleteByPK(id, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Can not Delete Data"");</script>")
                End If
            Next

            ClearProcess()
            CheckIdcfProcess(lblServiceIP.Text)
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivProcess", "DivProcess();", True)
    End Sub
    Public Sub CheckIdcfProcess(ByVal wh As String)
        Dim dt As New DataTable
        Dim dtProcess As DataTable
        Dim Peng As New ProcessENG

        For m As Integer = 0 To gvShowProcess.Rows.Count - 1
            Dim chkProcess As CheckBox = DirectCast(gvShowProcess.Rows(m).FindControl("chkProcess"), CheckBox)
            If chkProcess.Checked = True Then
                chkProcess.Checked = False
            End If


        Next

        dtProcess = Peng.SetShowProcess("")

        dt = Peng.SetgvProcess("CF.ServerIP = '" & wh & "'")


        Dim table As New DataTable()

        For i As Integer = 0 To dt.Rows.Count - 1

            Dim idDt As String
            idDt = dt.Rows(i)("ms_process_checklist_id").ToString()

            For j As Integer = 0 To dtProcess.Rows.Count - 1
                Dim idDtService As String = dtProcess.Rows(j)("id").ToString()

                If idDt.Trim() = idDtService.Trim() Then

                    Dim chkProcess As CheckBox = DirectCast(gvShowProcess.Rows(j).FindControl("chkProcess"), CheckBox)
                    chkProcess.Checked = True
                    Exit For

                End If


            Next

        Next
    End Sub
    Protected Sub btnCancelProcess_Click(sender As Object, e As EventArgs) Handles btnCancelProcess.Click
        ClearProcess()

    End Sub
    Protected Sub btnSerchipProcess_Click(sender As Object, e As EventArgs) Handles btnSerchipProcess.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivProcess", "DivProcess();", True)
        txtServeripProcess.Text = Session("_serverip")
        txtServernameProcess.Text = Session("_servername")
        txtMacAddressProcess.Text = Session("_macaddress")
    End Sub
    Public Function _IdProcess(ByVal ip As String) As String
        Dim dt As DataTable
        Dim Peng As New ProcessENG
        Dim id As String = ""

        dt = Peng.SetgvProcess("ServerIP = '" & ip & "'")
        id = dt.Rows(0)(0).ToString()
        Return id
    End Function
    Public Sub ClearProcess()
        txtServeripProcess.Text = ""
        txtServernameProcess.Text = ""
        txtMacAddressProcess.Text = ""
        txtRepeatCheckProcess.Text = ""
        txtIntervalProcess.Text = ""
        chkActiveStatusProcess.Checked = True
        GetShowProcess()
        SetgvProcess()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivProcess", "DivProcess();", True)
    End Sub
    '------------------------------------------------------------------------------------------Process

    '---------------------------------------------------------------------------FileSize
    Private Function ValidateFileSize() As Boolean

        If txtServeripFile.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server IP !"");</script>")
            Return False
        End If
        If txtServerNameFile.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server Name !"");</script>")
            Return False
        End If
        If txtMacAddressFile.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server MacAddress !"");</script>")
            Return False
        End If
        If txtIntervelFile.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Interval !"");</script>")
            Return False
        End If
        If txtRepeatcheckFile.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat check !"");</script>")
            Return False
        End If
        If gvPathFile.Rows.Count = 0 Then
            Response.Write("<script language=""javaScript"">alert(""Please, PathFile check !"");</script>")
            Return False
        End If


        Dim Feng As New FileSizeENG
        If Feng.CheckDuplicateRegister(Convert.ToInt64(lblTempID.Text), txtServeripFile.Text.Trim(), txtServerNameFile.Text.Trim(), txtMacAddressFile.Text.Trim()) = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (Feng.ErrorMessage), True)
            Feng = Nothing
            Return False
        End If
        Feng = Nothing
        Return True

    End Function

    Public Sub SetgvFileSize()
        Dim Feng As New FileSizeENG
        Dim dt As New DataTable

        dt = Feng.GetgvFileSize("")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvFileSize.DataSource = dt
            gvFileSize.DataBind()

        End If

    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click


        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Long))
        dt.Columns.Add("PathFile", GetType(String))
        dt.Columns.Add("FileSizeMinor", GetType(String))
        dt.Columns.Add("FileSizeMajor", GetType(String))
        dt.Columns.Add("FileSizeCritical", GetType(String))

        If gvPathFile.Rows.Count > 0 Then

            For i As Integer = 0 To gvPathFile.Rows.Count - 1

                Dim id As Label = CType(gvPathFile.Rows(i).FindControl("lblid"), Label)
                Dim PathFile As Label = CType(gvPathFile.Rows(i).FindControl("lblPathFile"), Label)
                Dim FileSizeMinor As Label = CType(gvPathFile.Rows(i).FindControl("lblMinor"), Label)
                Dim FileSizeMajor As Label = CType(gvPathFile.Rows(i).FindControl("lblMajor"), Label)
                Dim FileSizeCritical As Label = CType(gvPathFile.Rows(i).FindControl("lblCritical"), Label)

                If PathFile.Text.Trim() <> txtPathFile.Text.Trim() Then
                    Dim _dr As DataRow
                    _dr = dt.NewRow
                    _dr("id") = id.Text
                    _dr("PathFile") = PathFile.Text
                    _dr("FileSizeMinor") = FileSizeMinor.Text
                    _dr("FileSizeMajor") = FileSizeMajor.Text
                    _dr("FileSizeCritical") = FileSizeCritical.Text
                    dt.Rows.Add(_dr)
                End If


            Next
        End If
     

        Dim dr As DataRow
        dr = dt.NewRow
        If lblidPathFile.Text <> "0" Then
            dr("id") = lblidPathFile.Text
        Else
            dr("id") = "0"
        End If

        dr("PathFile") = txtPathFile.Text
        dr("FileSizeMinor") = txtMinorFile.Text
        dr("FileSizeMajor") = txtMajorFile.Text
        dr("FileSizeCritical") = txtCriticalFile.Text
        dt.Rows.Add(dr)

        gvPathFile.DataSource = dt
        gvPathFile.DataBind()






        lblidPathFile.Text = "0"
        txtPathFile.Text = ""
        txtMinorFile.Text = ""
        txtMajorFile.Text = ""
        txtCriticalFile.Text = ""



        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)

    End Sub

    Protected Sub btnSaveFile_Click(sender As Object, e As EventArgs) Handles btnSaveFile.Click

        If ValidateFileSize() = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
            Return
        End If

        Dim Feng As New FileSizeENG
        Dim lnq As New CfConfigFilesizeLinqDB
        Dim trans As New TransactionDB

        Dim checkIDcfFile As String

        checkIDcfFile = lblTempID.Text

        If Convert.ToInt64(checkIDcfFile > 0) Then
            lnq.GetDataByPK(Convert.ToInt64(checkIDcfFile), trans.Trans)
        End If


        lnq.SERVERIP = txtServeripFile.Text
        lnq.SERVERNAME = txtServerNameFile.Text
        lnq.MACADDRESS = txtMacAddressFile.Text
        lnq.REPEATECHECKQTY = txtRepeatcheckFile.Text
        lnq.CHECKINTERVALMINUTE = txtIntervelFile.Text

        If chkActiveStatusFile.Checked Then
            lnq.ACTIVESTATUS = Convert.ToChar("Y")
        Else
            lnq.ACTIVESTATUS = Convert.ToChar("N")

        End If

        Dim ret As Boolean = False

        If (lnq.ID > 0) Then
            ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)


        Else
            ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
        End If

        If ret = True Then
            trans.CommitTransaction()

            If checkIDcfFile = 0 Then
                SaveDetailFileSize(Feng.GetidMaxFileSize(""))
            Else
                SaveEditFileSize(Convert.ToString(lnq.ID))
            End If


            Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")
        Else
            trans.RollbackTransaction()
            Response.Write("<script language=""javaScript"">alert(""Not Save data !"");</script>")
        End If


        lnq = Nothing

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
        SetgvFileSize()
        ClearFileSize()
    End Sub

    Public Sub SaveDetailFileSize(ByVal idFileSize As String)


        For i As Integer = 0 To gvPathFile.Rows.Count - 1
            Dim lnq As New CfConfigFilesizeDetailLinqDB
            Dim trans As New TransactionDB

        
            Dim PathFile As Label = CType(gvPathFile.Rows(i).FindControl("lblPathFile"), Label)
            Dim FileSizeMinor As Label = CType(gvPathFile.Rows(i).FindControl("lblMinor"), Label)
            Dim FileSizeMajor As Label = CType(gvPathFile.Rows(i).FindControl("lblMajor"), Label)
            Dim FileSizeCritical As Label = CType(gvPathFile.Rows(i).FindControl("lblCritical"), Label)

            lnq.FILENAME = PathFile.Text
            lnq.CF_CONFIG_FILESIZE_ID = idFileSize
            lnq.FILESIZEMINOR = FileSizeMinor.Text
            lnq.FILESIZEMAJOR = FileSizeMajor.Text
            lnq.FILESIZECRITICAL = FileSizeCritical.Text


            Dim ret As Boolean = False

            ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            lnq = Nothing
        Next



    End Sub

    Public Sub SaveEditFileSize(ByVal _cfidFile As String)

        For i As Integer = 0 To gvPathFile.Rows.Count - 1
            Dim lnq As New CfConfigFilesizeDetailLinqDB
            Dim trans As New TransactionDB

            Dim id As Label = CType(gvPathFile.Rows(i).FindControl("lblid"), Label)
            Dim Path As Label = CType(gvPathFile.Rows(i).FindControl("lblPathFile"), Label)
            Dim Minor As Label = CType(gvPathFile.Rows(i).FindControl("lblMinor"), Label)
            Dim Major As Label = CType(gvPathFile.Rows(i).FindControl("lblMajor"), Label)
            Dim Critical As Label = CType(gvPathFile.Rows(i).FindControl("lblCritical"), Label)

            If Convert.ToInt64(id.Text > 0) Then
                lnq.GetDataByPK(Convert.ToInt64(id.Text), trans.Trans)
            End If

            lnq.FILENAME = Path.Text
            lnq.CF_CONFIG_FILESIZE_ID = _cfidFile
            lnq.FILESIZEMINOR = Minor.Text
            lnq.FILESIZEMAJOR = Major.Text
            lnq.FILESIZECRITICAL = Critical.Text

            Dim ret As Boolean = False

            If (lnq.ID > 0) Then
                ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)
            Else
                ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            lnq = Nothing
        Next


    End Sub

    Protected Sub gvFileSize_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvFileSize.RowCommand

        If e.CommandName = "EditRow" Then
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigFilesizeLinqDB
            Dim dt As New DataTable
            Dim lblID As Label

            Dim Feng As New FileSizeENG




            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lblID = CType(gvFileSize.Rows(RowIndex).FindControl("lblcfDETAILid"), Label)
            lnq.GetDataByPK(lblID.Text, trans.Trans)

            If lnq.ID > 0 Then
                Dim idFileSize As String = lnq.ID

                EditFileSize(idFileSize)
                lblTempID.Text = lnq.ID
                txtServeripFile.Text = lnq.SERVERIP
                txtServerNameFile.Text = lnq.SERVERNAME
                txtMacAddressFile.Text = lnq.MACADDRESS
                txtRepeatcheckFile.Text = lnq.REPEATECHECKQTY
                txtIntervelFile.Text = lnq.CHECKINTERVALMINUTE
                Session("_serverip") = lnq.SERVERIP
                If lnq.ACTIVESTATUS = "Y" Then
                    chkActiveStatusFile.Checked = True
                Else
                    chkActiveStatusFile.Checked = False
                End If


            End If

        End If


        If e.CommandName = "DeleteRow" Then
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigFilesizeLinqDB
            Dim ret As Boolean = False

            Dim lblID As Label


            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)

            lblID = CType(gvFileSize.Rows(RowIndex).FindControl("lblcfDETAILid"), Label)
            DelidcfFileDetail(lblID.Text)
            ret = lnq.DeleteByPK(lblID.Text, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()

            End If


            ClearFileSize()
        End If


        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
    End Sub

    Public Sub EditFileSize(ByVal idFileSize As String)

        Dim dt As New DataTable
        Dim Feng As New FileSizeENG
        dt = Feng._FileSize("CFD.cf_config_filesize_id = '" & idFileSize & "'")

        If dt.Rows.Count > 0 Then
            Dim _dt As New DataTable
            _dt.Columns.Add("id", GetType(Long))
            _dt.Columns.Add("PathFile", GetType(String))
            _dt.Columns.Add("FileSizeMinor", GetType(String))
            _dt.Columns.Add("FileSizeMajor", GetType(String))
            _dt.Columns.Add("FileSizeCritical", GetType(String))

            For i As Integer = 0 To dt.Rows.Count - 1

                Dim q As String = dt.Rows(i)("id").ToString()
                Dim s As String = dt.Rows(i)("FileName").ToString()
                Dim a As String = dt.Rows(i)("FileSizeMinor").ToString()
                Dim f As String = dt.Rows(i)("FileSizeMajor").ToString()
                Dim ad As String = dt.Rows(i)("FileSizeCritical").ToString()


                Dim _dr As DataRow
                _dr = _dt.NewRow
                _dr("id") = dt.Rows(i)("id").ToString()
                _dr("PathFile") = dt.Rows(i)("FileName").ToString()
                _dr("FileSizeMinor") = dt.Rows(i)("FileSizeMinor").ToString()
                _dr("FileSizeMajor") = dt.Rows(i)("FileSizeMajor").ToString()
                _dr("FileSizeCritical") = dt.Rows(i)("FileSizeCritical").ToString()
                _dt.Rows.Add(_dr)
            Next

            gvPathFile.DataSource = _dt
            gvPathFile.DataBind()

        End If


    End Sub

    Public Sub DelidcfFileDetail(ByVal id As String)
        
        Dim Feng As New FileSizeENG
        Dim dt As New DataTable
        Dim ret As Boolean = False

        dt = Feng._FileSize("CFD.cf_config_filesize_id = '" & id & "'")
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim lnq As New CfConfigFilesizeDetailLinqDB
            Dim trans As New TransactionDB
            Dim _idDetail As String = dt.Rows(i)(0).ToString()
            ret = lnq.DeleteByPK(_idDetail, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing
        Next



    End Sub

    Public Sub ClearFileSize()
        txtServeripFile.Text = ""
        txtServerNameFile.Text = ""
        txtMacAddressFile.Text = ""
        txtIntervelFile.Text = ""
        txtRepeatcheckFile.Text = ""
        txtMinorFile.Text = ""
        txtMajorFile.Text = ""
        txtCriticalFile.Text = ""
        txtPathFile.Text = ""
        lblidPathFile.Text = "0"
        lblTempID.Text = "0"
        Dim dt As New DataTable()
        gvPathFile.DataSource = dt
        gvPathFile.DataBind()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
        Globals.Serverip = ""
        SetgvFileSize()
    End Sub

    Protected Sub btnCancalFile_Click(sender As Object, e As EventArgs) Handles btnCancalFile.Click
        ClearFileSize()
    End Sub

    Protected Sub btnBrownparthfile_Click(sender As Object, e As EventArgs) Handles btnBrownparthfile.Click


        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
        txtPathFile.Text = Session("PathFile")
    End Sub

    Protected Sub gvPathFile_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvPathFile.RowCommand
        If e.CommandName = "EditRow" Then
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)

            Dim id As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblid"), Label)
            Dim Path As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblPathFile"), Label)
            Dim Minor As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblMinor"), Label)
            Dim Major As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblMajor"), Label)
            Dim Critical As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblCritical"), Label)
            Dim pa As String = Path.Text
            txtPathFile.Text = Path.Text
            txtMinorFile.Text = Minor.Text
            txtMajorFile.Text = Major.Text
            txtCriticalFile.Text = Critical.Text
            lblidPathFile.Text = id.Text

        End If


        If e.CommandName = "DeleteRow" Then
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            Dim DeletID As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblid"), Label)
            Dim DeletePathFile As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblPathFile"), Label)

            Dim trans As New TransactionDB
            Dim ret As Boolean = False
            Dim lnq As New CfConfigFilesizeDetailLinqDB
            ret = lnq.DeleteByPK(DeletID.Text, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing

            Dim dt As New DataTable
            dt.Columns.Add("id", GetType(Long))
            dt.Columns.Add("PathFile", GetType(String))
            dt.Columns.Add("FileSizeMinor", GetType(String))
            dt.Columns.Add("FileSizeMajor", GetType(String))
            dt.Columns.Add("FileSizeCritical", GetType(String))


            For i As Integer = 0 To gvPathFile.Rows.Count - 1

                Dim path As Label = CType(gvPathFile.Rows(i).FindControl("lblPathFile"), Label)
                Dim id As Label = CType(gvPathFile.Rows(i).FindControl("lblid"), Label)
                Dim Minor As Label = CType(gvPathFile.Rows(i).FindControl("lblMinor"), Label)
                Dim Major As Label = CType(gvPathFile.Rows(i).FindControl("lblMajor"), Label)
                Dim Critical As Label = CType(gvPathFile.Rows(i).FindControl("lblCritical"), Label)


                If DeletePathFile.Text.Trim() <> path.Text.Trim() Then
                    Dim dr As DataRow
                    dr = dt.NewRow
                    dr("id") = id.Text
                    dr("PathFile") = path.Text
                    dr("FileSizeMinor") = Minor.Text
                    dr("FileSizeMajor") = Major.Text
                    dr("FileSizeCritical") = Critical.Text
                    dt.Rows.Add(dr)
                End If

            Next
            gvPathFile.DataSource = dt
            gvPathFile.DataBind()

        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
    End Sub

    Protected Sub btnSerchipFileSize_Click(sender As Object, e As EventArgs) Handles btnSerchipFileSize.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
        txtServeripFile.Text = Session("_serverip")
        txtServerNameFile.Text = Session("_servername")
        txtMacAddressFile.Text = Session("_macaddress")
    End Sub
    '---------------------------------------------------------------------------FileSize






    '---------------------------------------------------------------------------Port

    Private Function ValidatePort() As Boolean

        If txtServeripPort.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server IP !"");</script>")
            Return False
        End If
        If txtServerNamePort.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server Name !"");</script>")
            Return False
        End If
        If txtPort.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Port !"");</script>")
            Return False
        End If

        'Dim Peng As New PortEng
        'If Peng.CheckDuplicatePort(Convert.ToInt64(lblidPort.Text), txtPort.Text.Trim(), txtServerNamePort.Text.Trim(), txtServeripPort.Text.Trim()) = True Then
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (Peng.ErrorMessage), True)
        '    Peng = Nothing
        '    Return False
        'End If
        'Peng = Nothing
        Return True

    End Function
    Public Sub GetgvCfPortList()
        Dim Peng As New PortEng
        Dim dt As New DataTable

        dt = Peng.SetgvCfPortList("")


        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvCfPortList.DataSource = dt
            gvCfPortList.DataBind()

        End If

    End Sub
    Public Sub ClearPort()
        txtServeripPort.Text = ""
        txtServerNamePort.Text = ""
        txtPort.Text = ""
        chkSun.Checked = False
        chkMon.Checked = False
        chkTue.Checked = False
        chkWed.Checked = False
        chkThu.Checked = False
        chkFri.Checked = False
        chkSat.Checked = False
        chkAllDayEvent.Checked = False
        lblidPort.Text = ""
        txtFromtime.Text = ""
        txtToTime.Text = ""
        GetgvCfPortList()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivPort", "DivPort();", True)
    End Sub
    Protected Sub btnSavePort_Click(sender As Object, e As EventArgs) Handles btnSavePort.Click

        If ValidatePort() = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivPort", "DivPort();", True)
            Return
        End If


        Dim Peng As New PortEng
        Dim lnq As New CfConfigPortLinqDB
        Dim trans As New TransactionDB

        Dim checkIDcfPort As String

        checkIDcfPort = lblidPort.Text
        If Convert.ToInt64(checkIDcfPort > 0) Then
            lnq.GetDataByPK(Convert.ToInt64(checkIDcfPort), trans.Trans)
        End If

        If (lnq.ID > 0) Then
            Peng.EditConfigPort(txtServerNamePort.Text, txtServeripPort.Text, txtPort.Text, GetCheckBox(chkSun), GetCheckBox(chkMon), GetCheckBox(chkTue), GetCheckBox(chkWed), GetCheckBox(chkThu), GetCheckBox(chkFri), GetCheckBox(chkSat), GetCheckBox(chkAllDayEvent), txtFromtime.Text, txtToTime.Text, lnq.ID)
        Else
            Peng.AddConfigPort(txtServerNamePort.Text, txtServeripPort.Text, txtPort.Text, GetCheckBox(chkSun), GetCheckBox(chkMon), GetCheckBox(chkTue), GetCheckBox(chkWed), GetCheckBox(chkThu), GetCheckBox(chkFri), GetCheckBox(chkSat), GetCheckBox(chkAllDayEvent), txtFromtime.Text, txtToTime.Text)
        End If


        ClearPort()

    End Sub
    Private Function GetCheckBox(ByVal chk As CheckBox) As String
        Dim ret As String = ""
        If chk.Checked = True Then
            ret = "Y"
        Else
            ret = "N"
        End If
        Return ret
    End Function
    Protected Sub gvCfPortList_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCfPortList.RowCommand
        If e.CommandName = "EditRow" Then
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)

            Dim id As Label = CType(gvCfPortList.Rows(RowIndex).FindControl("lblid"), Label)
            Dim Servername As Label = CType(gvCfPortList.Rows(RowIndex).FindControl("lblServername"), Label)
            Dim Serverip As Label = CType(gvCfPortList.Rows(RowIndex).FindControl("lblServerip"), Label)
            Dim Port As Label = CType(gvCfPortList.Rows(RowIndex).FindControl("lblPort"), Label)

            Dim Peng As New PortEng
            Dim dt As New DataTable

            dt = Peng.SetgvCfPortList("id = '" & id.Text & "'")
            chkDay(dt)


            txtServerNamePort.Text = Servername.Text
            txtServeripPort.Text = Serverip.Text
            txtPort.Text = Port.Text
            lblidPort.Text = id.Text

        End If

        If e.CommandName = "DeleteRow" Then
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)

            Dim id As Label = CType(gvCfPortList.Rows(RowIndex).FindControl("lblid"), Label)
            Dim trans As New TransactionDB
            Dim ret As Boolean = False
            Dim lnq As New CfConfigPortLinqDB
            ret = lnq.DeleteByPK(id.Text, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing

            ClearPort()

        End If
    End Sub
    Public Sub chkDay(ByVal dt As DataTable)

        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("AlarmSun").ToString = "Y" Then
                chkSun.Checked = True
            End If
            If dt.Rows(0)("AlarmMon").ToString = "Y" Then
                chkMon.Checked = True
            End If
            If dt.Rows(0)("AlarmTue").ToString = "Y" Then
                chkTue.Checked = True
            End If
            If dt.Rows(0)("AlarmWed").ToString = "Y" Then
                chkWed.Checked = True
            End If
            If dt.Rows(0)("AlarmThu").ToString = "Y" Then
                chkThu.Checked = True
            End If
            If dt.Rows(0)("AlarmFri").ToString = "Y" Then
                chkFri.Checked = True
            End If
            If dt.Rows(0)("AlarmSat").ToString = "Y" Then
                chkSat.Checked = True
            End If
            If dt.Rows(0)("ALLDayEvent").ToString = "Y" Then
                chkAllDayEvent.Checked = True
            End If
            txtFromtime.Text = dt.Rows(0)("AlarmTimeFrom").ToString
            txtToTime.Text = dt.Rows(0)("AlarmTimeTo").ToString

        End If

    End Sub

    '---------------------------------------------------------------------------Port


   
  
  
  

   
    
End Class

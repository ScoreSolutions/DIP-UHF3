Imports Engine
Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.IO
Imports Globals
Partial Class frmConfig
    Inherits System.Web.UI.Page

    Private Function GetCheckDay(ByVal chk As CheckBox) As Char
        Dim ret As String = ""
        If chk.Checked = True Then
            ret = "Y"
        Else
            ret = "N"
        End If
        Return ret
    End Function
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim trans As New TransactionDB
        Dim lnq As New TbUserLinqDB

        
            If Not IsPostBack Then

            chkDay()
            chkdayCPU()

            btnBrownparthfile.Attributes.Add("onclick", "showModal('frmAddPathFile.aspx',490,400,0)")

            btnSerchipRAM.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx?Arg=1',490,400,0)")
            btnSerchGroupRAM.Attributes.Add("onclick", "showModal('frmPopupSearchGroup.aspx',700,400,0)")

            btnSerchipCPU.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx?Arg=2',490,400,0)")
            btnSerchGroupCPU.Attributes.Add("onclick", "showModal('frmPopupSearchGroup.aspx',700,400,0)")

            btnSerchipDrive.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx?Arg=3',490,400,0)")
            btnSerchipService.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx?Arg=4',490,400,0)")
            btnSerchipProcess.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx?Arg=5',490,400,0)")
            btnSerchipFileSize.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx?Arg=6',490,400,0)")
            btnSerchipPort.Attributes.Add("onclick", "showModal('frmPopupSerchIP.aspx?Arg=7',490,400,0)")
            btnAddService.Attributes.Add("onclick", "showModal('frmAddService.aspx',500,400,0)")
            btnAddProcess.Attributes.Add("onclick", "showModal(' frmAddProcess.aspx',500,400,0)")

            chkByServerRAM.Checked = True
            chkByGroupRAM.Checked = False


            ddlDriveName()
          

            GetShowServiec()
            GetShowProcess()
            SetgvRAM()
            SetgvDrive()
            SetgvCPU()
            SetgvService()
            SetgvProcess()
            SetgvFileSize()
            GetgvCfPortList()
            CheckRole()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivRAM", "DivRAM();", True)
        End If


        If gvPathFile.Rows.Count > 0 Then
            lblnoPathFile.Visible = False

        Else
            lblnoPathFile.Visible = True
        End If
        If gvSelectDrive.Rows.Count > 0 Then
            lblnoDrive.Visible = False
        Else
            lblnoDrive.Visible = True
        End If


    End Sub


    Public Sub Allgv()
        'GetShowServiec()
        'GetShowProcess()

        SetgvRAM()
        SetgvCPU()
        SetgvService()
        SetgvProcess()
        SetgvDrive()
        SetgvFileSize()
        GetgvCfPortList()

    End Sub

    Public Sub GetgvSelectDrive()

        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Long))
        dt.Columns.Add("DriveName", GetType(String))
        dt.Columns.Add("Minor", GetType(String))
        dt.Columns.Add("RepeatMinor", GetType(String))
        dt.Columns.Add("Major", GetType(String))
        dt.Columns.Add("RepeatMajor", GetType(String))
        dt.Columns.Add("Critical", GetType(String))
        dt.Columns.Add("RepeatCritical", GetType(String))

            Dim dr As DataRow
            dr = dt.NewRow
            dt.Rows.Add(dr)
            gvSelectDrive.DataSource = dt
            gvSelectDrive.DataBind()
            Dim columnCount As Integer = gvSelectDrive.Rows(0).Cells.Count
            gvSelectDrive.Rows(0).Cells.Clear()
            gvSelectDrive.Rows(0).Cells.Add(New TableCell)
            gvSelectDrive.Rows(0).Cells(0).ColumnSpan = columnCount
            gvSelectDrive.Rows(0).Cells(0).Text = "No Records Found."

    End Sub
    Public Sub GetgvAddPathFile()

        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Long))
        dt.Columns.Add("PathFile", GetType(String))
        dt.Columns.Add("FileSizeMinor", GetType(String))
        dt.Columns.Add("RepeatMinor", GetType(String))
        dt.Columns.Add("FileSizeMajor", GetType(String))
        dt.Columns.Add("RepeatMajor", GetType(String))
        dt.Columns.Add("FileSizeCritical", GetType(String))
        dt.Columns.Add("RepeatCritical", GetType(String))

        Dim dr As DataRow
        dr = dt.NewRow
        dt.Rows.Add(dr)
        gvPathFile.DataSource = dt
        gvPathFile.DataBind()
        Dim columnCount As Integer = gvPathFile.Rows(0).Cells.Count
        gvPathFile.Rows(0).Cells.Clear()
        gvPathFile.Rows(0).Cells.Add(New TableCell)
        gvPathFile.Rows(0).Cells(0).ColumnSpan = columnCount
        gvPathFile.Rows(0).Cells(0).Text = "No Records Found."

    End Sub
    Private Sub CheckRole()

        Dim EditOnly As String = Session("idres5")
        Dim DeleteOnly As String = Session("idres6")

        If EditOnly = "5" And DeleteOnly Is Nothing Then

            btnSaveCPU.Enabled = False
            btnSaveDrive.Enabled = False
            btnSaveFile.Enabled = False
            btnSavePort.Enabled = False
            btnSaveProcess.Enabled = False
            btnSaveRAM.Enabled = False
            btnSaveService.Enabled = False
            btnSerchGroupCPU.Enabled = False
            btnSerchGroupRAM.Enabled = False
            btnSerchipCPU.Enabled = False
            btnSerchipDrive.Enabled = False
            btnSerchipFileSize.Enabled = False
            btnSerchipPort.Enabled = False
            btnSerchipProcess.Enabled = False
            btnSerchipRAM.Enabled = False
            btnSerchipService.Enabled = False
            btnCancalFile.Enabled = False
            btnCancelCPU.Enabled = False
            btnCancelDrive.Enabled = False
            btnCancelPort.Enabled = False
            btnCancelProcess.Enabled = False
            btnCancelRAM.Enabled = False
            btnCancelService.Enabled = False
            SubmitDriveName.Enabled = False
            btnAddService.Enabled = False
            btnAddProcess.Enabled = False
            btnBrownparthfile.Enabled = False
            btnConfirm.Enabled = False

            RoleEditOnly()
        End If

        If DeleteOnly = "6" And EditOnly Is Nothing Then

            btnSaveCPU.Enabled = False
            btnSaveDrive.Enabled = False
            btnSaveFile.Enabled = False
            btnSavePort.Enabled = False
            btnSaveProcess.Enabled = False
            btnSaveRAM.Enabled = False
            btnSaveService.Enabled = False
            btnSerchGroupCPU.Enabled = False
            btnSerchGroupRAM.Enabled = False
            btnSerchipCPU.Enabled = False
            btnSerchipDrive.Enabled = False
            btnSerchipFileSize.Enabled = False
            btnSerchipPort.Enabled = False
            btnSerchipProcess.Enabled = False
            btnSerchipRAM.Enabled = False
            btnSerchipService.Enabled = False
            btnCancalFile.Enabled = False
            btnCancelCPU.Enabled = False
            btnCancelDrive.Enabled = False
            btnCancelPort.Enabled = False
            btnCancelProcess.Enabled = False
            btnCancelRAM.Enabled = False
            btnCancelService.Enabled = False
            SubmitDriveName.Enabled = False
            btnAddService.Enabled = False
            btnAddProcess.Enabled = False
            btnBrownparthfile.Enabled = False
            btnConfirm.Enabled = False
            RoleDeleteOnly()

        End If

        If EditOnly IsNot Nothing And DeleteOnly IsNot Nothing Then

            btnSaveCPU.Enabled = False
            btnSaveDrive.Enabled = False
            btnSaveFile.Enabled = False
            btnSavePort.Enabled = False
            btnSaveProcess.Enabled = False
            btnSaveRAM.Enabled = False
            btnSaveService.Enabled = False
            btnSerchGroupCPU.Enabled = False
            btnSerchGroupRAM.Enabled = False
            btnSerchipCPU.Enabled = False
            btnSerchipDrive.Enabled = False
            btnSerchipFileSize.Enabled = False
            btnSerchipPort.Enabled = False
            btnSerchipProcess.Enabled = False
            btnSerchipRAM.Enabled = False
            btnSerchipService.Enabled = False
            btnCancalFile.Enabled = False
            btnCancelCPU.Enabled = False
            btnCancelDrive.Enabled = False
            btnCancelPort.Enabled = False
            btnCancelProcess.Enabled = False
            btnCancelRAM.Enabled = False
            btnCancelService.Enabled = False
            SubmitDriveName.Enabled = False
            btnAddService.Enabled = False
            btnAddProcess.Enabled = False
            btnBrownparthfile.Enabled = False
            btnConfirm.Enabled = False

        End If


    End Sub

    Private Sub RoleEditOnly()

        If gvRAM.Rows.Count > 0 Then

            For i As Integer = 0 To gvRAM.Rows.Count - 1

                Dim lblIDRAM As Label = gvRAM.Rows(i).FindControl("lblidcfRAM")
                Dim btnDeleteRAM As ImageButton = gvRAM.Rows(i).FindControl("Delete")

                If lblIDRAM.Text > "0" Then
                    btnDeleteRAM.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivRAM", "DivRAM();", True) 'Script of TabStrip
        End If

        If gvCPU.Rows.Count > 0 Then

            For i As Integer = 0 To gvCPU.Rows.Count - 1

                Dim lblIDCPU As Label = gvCPU.Rows(i).FindControl("idcfCPU")
                Dim btnDeleteCPU As ImageButton = gvCPU.Rows(i).FindControl("Delete")

                If lblIDCPU.Text > "0" Then
                    btnDeleteCPU.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True) 'Script of TabStrip

        End If

        If gvDrive.Rows.Count > 0 Then

            For i As Integer = 0 To gvDrive.Rows.Count - 1

                Dim lblIDDrive As Label = gvDrive.Rows(i).FindControl("lblcf_config_drive_id")
                Dim btnDeleteDrive As ImageButton = gvDrive.Rows(i).FindControl("Delete")

                If lblIDDrive.Text > "0" Then
                    btnDeleteDrive.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True) 'Script of TabStrip

        End If


        If gvService.Rows.Count > 0 Then

            For i As Integer = 0 To gvService.Rows.Count - 1

                Dim lblIDService As Label = gvService.Rows(i).FindControl("lblServerIP")
                Dim btnDeleteService As ImageButton = gvService.Rows(i).FindControl("Delete")

                If lblIDService.Text <> "" Then
                    btnDeleteService.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True) 'Script of TabStrip


        End If

        If gvProcess.Rows.Count > 0 Then

            For i As Integer = 0 To gvProcess.Rows.Count - 1

                Dim lblIDProcess As Label = gvProcess.Rows(i).FindControl("lblServerIP")
                Dim btnDeleteProcess As ImageButton = gvProcess.Rows(i).FindControl("Delete")

                If lblIDProcess.Text <> "" Then
                    btnDeleteProcess.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivProcess", "DivProcess();", True) 'Script of TabStrip


        End If

        If gvFileSize.Rows.Count > 0 Then

            For i As Integer = 0 To gvFileSize.Rows.Count - 1

                Dim lblIDFileSize As Label = gvFileSize.Rows(i).FindControl("lblcfDETAILid")
                Dim btnDeleteFileSize As ImageButton = gvFileSize.Rows(i).FindControl("Delete")

                If lblIDFileSize.Text > "0" Then
                    btnDeleteFileSize.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True) 'Script of TabStrip


        End If

        If gvCfPortList.Rows.Count > 0 Then

            For i As Integer = 0 To gvCfPortList.Rows.Count - 1

                Dim lblIDPort As Label = gvCfPortList.Rows(i).FindControl("lblid")
                Dim btnDeletePort As ImageButton = gvCfPortList.Rows(i).FindControl("Delete")

                If lblIDPort.Text > "0" Then
                    btnDeletePort.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivPort", "DivPort();", True) 'Script of TabStrip


        End If

    End Sub

    Private Sub RoleDeleteOnly()

        If gvRAM.Rows.Count > 0 Then

            For i As Integer = 0 To gvRAM.Rows.Count - 1

                Dim lblIDRAM As Label = gvRAM.Rows(i).FindControl("lblidcfRAM")
                Dim btnEditRAM As ImageButton = gvRAM.Rows(i).FindControl("Edit")

                If lblIDRAM.Text > "0" Then
                    btnEditRAM.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivRAM", "DivRAM();", True) 'Script of TabStrip
        End If

        If gvCPU.Rows.Count > 0 Then

            For i As Integer = 0 To gvCPU.Rows.Count - 1

                Dim lblIDCPU As Label = gvCPU.Rows(i).FindControl("lblidcfCPU")
                Dim btnEditCPU As ImageButton = gvCPU.Rows(i).FindControl("Edit")

                If lblIDCPU.Text > "0" Then
                    btnEditCPU.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True) 'Script of TabStrip

        End If

        If gvDrive.Rows.Count > 0 Then

            For i As Integer = 0 To gvDrive.Rows.Count - 1

                Dim lblIDDrive As Label = gvDrive.Rows(i).FindControl("lblcf_config_drive_id")
                Dim btnEditDrive As ImageButton = gvDrive.Rows(i).FindControl("Edit")

                If lblIDDrive.Text > "0" Then
                    btnEditDrive.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True) 'Script of TabStrip

        End If


        If gvService.Rows.Count > 0 Then

            For i As Integer = 0 To gvService.Rows.Count - 1

                Dim lblIDService As Label = gvService.Rows(i).FindControl("lblServerIP")
                Dim btnEditService As ImageButton = gvService.Rows(i).FindControl("Edit")

                If lblIDService.Text <> "" Then
                    btnEditService.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True) 'Script of TabStrip


        End If

        If gvProcess.Rows.Count > 0 Then

            For i As Integer = 0 To gvProcess.Rows.Count - 1

                Dim lblIDProcess As Label = gvProcess.Rows(i).FindControl("lblServerIP")
                Dim btnEditProcess As ImageButton = gvProcess.Rows(i).FindControl("Edit")

                If lblIDProcess.Text <> "" Then
                    btnEditProcess.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivProcess", "DivProcess();", True) 'Script of TabStrip


        End If

        If gvFileSize.Rows.Count > 0 Then

            For i As Integer = 0 To gvFileSize.Rows.Count - 1

                Dim lblIDFileSize As Label = gvFileSize.Rows(i).FindControl("lblcfDETAILid")
                Dim btnEditFileSize As ImageButton = gvFileSize.Rows(i).FindControl("Edit")

                If lblIDFileSize.Text > "0" Then
                    btnEditFileSize.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True) 'Script of TabStrip


        End If

        If gvCfPortList.Rows.Count > 0 Then

            For i As Integer = 0 To gvCfPortList.Rows.Count - 1

                Dim lblIDPort As Label = gvCfPortList.Rows(i).FindControl("lblid")
                Dim btnEditPort As ImageButton = gvCfPortList.Rows(i).FindControl("Edit")

                If lblIDPort.Text > "0" Then
                    btnEditPort.Visible = False
                End If

            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivPort", "DivPort();", True) 'Script of TabStrip


        End If

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
            If dt.Rows.Count = 0 Then

                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvRAM.DataSource = dt
                gvRAM.DataBind()
                Dim columnCount As Integer = gvRAM.Rows(0).Cells.Count
                gvRAM.Rows(0).Cells.Clear()
                gvRAM.Rows(0).Cells.Add(New TableCell)
                gvRAM.Rows(0).Cells(0).ColumnSpan = columnCount
                gvRAM.Rows(0).Cells(0).Text = "No Records Found."
            End If

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



        If txtIntervalRAM.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check IntervalRAM !"");</script>")
            Return False
        End If

        If chkAllDayRAM.Checked = False Then
            Dim ret As Boolean = False
            If chkSunRAM.Checked = True Then
                ret = True
            End If
            If chkMonRAM.Checked = True Then
                ret = True
            End If
            If chkTueRAM.Checked = True Then
                ret = True
            End If
            If chkWedRAM.Checked = True Then
                ret = True
            End If
            If chkThuRAM.Checked = True Then
                ret = True
            End If
            If chkFriRAM.Checked = True Then
                ret = True
            End If
            If chkSatRAM.Checked = True Then
                ret = True
            End If

            If ret = False Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Day !"");</script>")
                Return False
            End If


        End If
        If chkAllDayRAM.Checked = False Then
            If txtFromTimeRAM.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check From Time !"");</script>")
                Return False
            End If

            If txtTOTimeRAM.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check To Time !"");</script>")
                Return False
            End If

            Dim FromTime As DateTime = Convert.ToDateTime(txtFromTimeRAM.Text)
            Dim ToTime As DateTime = Convert.ToDateTime(txtTOTimeRAM.Text)

            If FromTime > ToTime Then
                Response.Write("<script language=""javaScript"">alert(""Please, Check " & ToTime.ToString("HH:mm") & " more than  " & FromTime.ToString("HH:mm") & " !"");</script>")
                Return False
            End If
        End If



        If txtMinorRAM.Text.Trim() = "" Or txtMinorRAM.Text.Trim() = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Minor !"");</script>")
            Return False
        End If
        If txtRepeatMinorRAM.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat Minor !"");</script>")
            Return False
        End If

        If txtMajorRAM.Text.Trim() = "" Or txtMajorRAM.Text.Trim() = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Major !"");</script>")
            Return False
        End If
        If txtRepeatMajorRAM.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat Major !"");</script>")
            Return False
        End If

        If txtCriticalRAM.Text.Trim() = "" Or txtCriticalRAM.Text.Trim() = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Critical !"");</script>")
            Return False
        End If
        If txtRepeatCriticalRAM.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat Critical !"");</script>")
            Return False
        End If

        Dim chk As Boolean = False
        If Convert.ToInt32(txtCriticalRAM.Text) > Convert.ToInt32(txtMajorRAM.Text) Then
            If Convert.ToInt32(txtMajorRAM.Text) > Convert.ToInt32(txtMinorRAM.Text) Then
                chk = True
            Else
                chk = False
            End If
        Else
            chk = False
        End If

        If chk = False Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Severity!"");</script>")
            txtMinorRAM.Text = ""
            txtMajorRAM.Text = ""
            txtCriticalRAM.Text = ""
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
    Public Sub chkdayRAM()
        If chkAllDayRAM.Checked = True Then
            chkSunRAM.Enabled = False
            chkMonRAM.Enabled = False
            chkTueRAM.Enabled = False
            chkWedRAM.Enabled = False
            chkThuRAM.Enabled = False
            chkFriRAM.Enabled = False
            chkSatRAM.Enabled = False
            txtTOTimeRAM.Enabled = False
            txtFromTimeRAM.Enabled = False

        Else

            chkSunRAM.Enabled = True
            chkMonRAM.Enabled = True
            chkTueRAM.Enabled = True
            chkWedRAM.Enabled = True
            chkThuRAM.Enabled = True
            chkFriRAM.Enabled = True
            chkSatRAM.Enabled = True
            txtTOTimeRAM.Enabled = True
            txtFromTimeRAM.Enabled = True

        End If
    End Sub
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
            Allgv()
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

            lnq.CHECKINTERVALMINUTE = txtIntervalRAM.Text

            If chkAllDayRAM.Checked = True Then
                lnq.ALLDAYEVENT = GetCheckDay(chkAllDayRAM)
            Else
                lnq.ALARMSUN = GetCheckDay(chkSunRAM)
                lnq.ALARMMON = GetCheckDay(chkMonRAM)
                lnq.ALARMTUE = GetCheckDay(chkTueRAM)
                lnq.ALARMWED = GetCheckDay(chkWedRAM)
                lnq.ALARMTHU = GetCheckDay(chkThuRAM)
                lnq.ALARMFRI = GetCheckDay(chkFriRAM)
                lnq.ALARMSAT = GetCheckDay(chkSatRAM)
                lnq.ALLDAYEVENT = GetCheckDay(chkAllDayRAM)
                lnq.ALARMTIMEFROM = txtFromTimeRAM.Text
                lnq.ALARMTIMETO = txtTOTimeRAM.Text
            End If




            lnq.ALARMMINORVALUE = txtMinorRAM.Text
            lnq.REPEATCHECKMINOR = txtRepeatMinorRAM.Text

            lnq.ALARMMAJORVALUE = txtMajorRAM.Text
            lnq.REPEATCHECKMAJOR = txtRepeatMajorRAM.Text

            lnq.ALARMCRITICALVALUE = txtCriticalRAM.Text
            lnq.REPEATCHECKCRITICAL = txtRepeatCriticalRAM.Text



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
                Response.Write("<script language=""javaScript"">alert(""Can not save !"");</script>")

            End If

            lnq = Nothing

        End If


        If (chkByGroupRAM.Checked = True) Then
            If txtGroupRAM.Text = "NoGroup" Then
                Response.Write("<script language=""javaScript"">alert(""Can not save !"");</script>")
                Allgv()

                Return
            End If
            Dim dt As DataTable
            Dim IDcfRAM As String
            dt = Reng.gvByGroup("group_desc = '" & txtGroupRAM.Text & "'")
            Dim _ret As Boolean = False
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

                lnq.CHECKINTERVALMINUTE = txtIntervalRAM.Text
                If chkAllDayRAM.Checked = True Then
                    lnq.ALLDAYEVENT = GetCheckDay(chkAllDayRAM)
                Else
                    lnq.ALARMSUN = GetCheckDay(chkSunRAM)
                    lnq.ALARMMON = GetCheckDay(chkMonRAM)
                    lnq.ALARMTUE = GetCheckDay(chkTueRAM)
                    lnq.ALARMWED = GetCheckDay(chkWedRAM)
                    lnq.ALARMTHU = GetCheckDay(chkThuRAM)
                    lnq.ALARMFRI = GetCheckDay(chkFriRAM)
                    lnq.ALARMSAT = GetCheckDay(chkSatRAM)
                    lnq.ALLDAYEVENT = GetCheckDay(chkAllDayRAM)
                    lnq.ALARMTIMEFROM = txtFromTimeRAM.Text
                    lnq.ALARMTIMETO = txtTOTimeRAM.Text
                End If




                lnq.ALARMMINORVALUE = txtMinorRAM.Text
                lnq.REPEATCHECKMINOR = txtRepeatMinorRAM.Text

                lnq.ALARMMAJORVALUE = txtMajorRAM.Text
                lnq.REPEATCHECKMAJOR = txtRepeatMajorRAM.Text

                lnq.ALARMCRITICALVALUE = txtCriticalRAM.Text
                lnq.REPEATCHECKCRITICAL = txtRepeatCriticalRAM.Text

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

                    _ret = ret

                Else
                    trans.RollbackTransaction()

                    _ret = ret
                End If

                lnq = Nothing

            Next

            If _ret = True Then
                Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")

            Else
                Response.Write("<script language=""javaScript"">alert(""Can not save !"");</script>")
            End If

        End If

        Allgv()
        ClearRAM()
        CheckRole()
    End Sub
    Protected Sub btnCancelRAM_Click(sender As Object, e As EventArgs) Handles btnCancelRAM.Click
        ClearRAM()
        Allgv()
        CheckRole()
        chkdayRAM()
    End Sub

    Public Sub ClearRAM()
        SetgvRAM()
        chkByServerRAM.Checked = True
        chkByGroupRAM.Checked = False
        chkActiveStatusRAM.Checked = True
        lblidRAM.Text = "0"
        txtServeripRAM.Text = ""
        txtServernameRAM.Text = ""
        txtMacAddressRAM.Text = ""
        txtIntervalRAM.Text = ""
        txtMinorRAM.Text = ""
        txtRepeatMinorRAM.Text = ""
        txtMajorRAM.Text = ""
        txtRepeatMajorRAM.Text = ""
        txtCriticalRAM.Text = ""
        txtRepeatCriticalRAM.Text = ""


        chkSunRAM.Checked = False
        chkMonRAM.Checked = False
        chkTueRAM.Checked = False
        chkWedRAM.Checked = False
        chkThuRAM.Checked = False
        chkFriRAM.Checked = False
        chkSatRAM.Checked = False
        chkAllDayRAM.Checked = False

        txtFromTimeRAM.Text = ""
        txtTOTimeRAM.Text = ""
        txtGroupRAM.Text = ""
    End Sub

    'Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
    '    Dim Leng As New Web_Config.LoginENG
    '    Leng.Logout(Globals.uData.LOGIN_HISTORY_ID)
    '    Response.Redirect("frmLogin.aspx")
    'End Sub
    Protected Sub gvRAM_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvRAM.RowCommand
        Dim trans As New TransactionDB
        Dim lnq As New CfConfigRamLinqDB
        Dim ret As Boolean = False

        If e.CommandName = "EditRow" Then

            'Dim lblID As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            'lblID = CType(gvRAM.Rows(RowIndex).FindControl("lblidcfRAM"), Label)
            lnq.GetDataByPK(RowIndex, trans.Trans)

            Dim dt As New DataTable
            Dim groupName As String
            Dim sql = "Select G.group_desc  from TB_GROUP G join TB_REGISTER R on G.id = R.group_id"
            sql += " join CF_CONFIG_RAM CR on R .ServerIP = CR .ServerIP where CR.id ='" & RowIndex & "' "
            dt = lnq.GetListBySql(sql, trans.Trans)
            If dt.Rows.Count > 0 Then

                groupName = dt.Rows(0)(0).ToString
                txtGroupRAM.Text = groupName.ToString

            End If

            'Dim GroupName As Label = CType(gvRAM.Rows(RowIndex).FindControl("lblgroup_desc"), Label)
            'txtGroupRAM.Text = GroupName.Text

            If lnq.ID > 0 Then

                txtServeripRAM.Text = lnq.SERVERIP
                txtServernameRAM.Text = lnq.SERVERNAME
                txtMacAddressRAM.Text = lnq.MACADDRESS
                txtIntervalRAM.Text = lnq.CHECKINTERVALMINUTE
                lblidRAM.Text = lnq.ID

                If lnq.ALARMSUN = "Y" Then
                    chkSunRAM.Checked = True
                Else
                    chkSunRAM.Checked = False
                End If

                If lnq.ALARMMON = "Y" Then
                    chkMonRAM.Checked = True
                Else
                    chkMonRAM.Checked = False
                End If

                If lnq.ALARMTUE = "Y" Then
                    chkTueRAM.Checked = True
                Else
                    chkTueRAM.Checked = False
                End If

                If lnq.ALARMWED = "Y" Then
                    chkWedRAM.Checked = True
                Else
                    chkWedRAM.Checked = False
                End If

                If lnq.ALARMTHU = "Y" Then
                    chkThuRAM.Checked = True
                Else
                    chkThuRAM.Checked = False
                End If

                If lnq.ALARMFRI = "Y" Then
                    chkFriRAM.Checked = True
                Else
                    chkFriRAM.Checked = False
                End If

                If lnq.ALARMSAT = "Y" Then
                    chkSatRAM.Checked = True
                Else
                    chkSatRAM.Checked = False
                End If

                If lnq.ALLDAYEVENT = "Y" Then
                    chkAllDayRAM.Checked = True
                Else
                    chkAllDayRAM.Checked = False
                End If
                chkdayRAM()

                txtFromTimeRAM.Text = lnq.ALARMTIMEFROM
                txtTOTimeRAM.Text = lnq.ALARMTIMETO

                txtMinorRAM.Text = lnq.ALARMMINORVALUE
                txtRepeatMinorRAM.Text = lnq.REPEATCHECKMINOR
                txtMajorRAM.Text = lnq.ALARMMAJORVALUE
                txtRepeatMajorRAM.Text = lnq.REPEATCHECKMAJOR
                txtCriticalRAM.Text = lnq.ALARMCRITICALVALUE
                txtRepeatCriticalRAM.Text = lnq.REPEATCHECKCRITICAL


                If lnq.ACTIVESTATUS = "Y" Then
                    chkActiveStatusRAM.Checked = True
                Else
                    chkActiveStatusRAM.Checked = False
                End If

                chkByServerRAM.Checked = True
                chkByGroupRAM.Checked = False

            End If

            btnSerchGroupRAM.Enabled = True
            btnSerchipRAM.Enabled = True
            btnSaveRAM.Enabled = True
            btnCancelRAM.Enabled = True

        End If


        If e.CommandName = "DeleteRow" Then

            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then

                'Dim lblID As Label
                Dim RowIndex As Integer
                Integer.TryParse(e.CommandArgument.ToString, RowIndex)
                'lblID = CType(gvRAM.Rows(RowIndex).FindControl("lblidcfRAM"), Label)
                'Dim id As Integer = lblID.Text

                ret = lnq.DeleteByPK(RowIndex, trans.Trans)
                If ret = True Then

                    trans.CommitTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Delete data Complete !"");</script>")
                Else
                    trans.RollbackTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Can not Delete Data!"");</script>")
                End If
                ClearRAM()

            End If
        End If

        Allgv()
    End Sub
    Protected Sub btnSerchipRAM_Click(sender As Object, e As EventArgs) Handles btnSerchipRAM.Click

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "chkServer", "chkServer();", True)
        Dim ip As String = Session("_serverip")
        If ip <> "" Then
            txtServeripRAM.Text = Session("_serverip")
            txtServernameRAM.Text = Session("_servername")
            txtMacAddressRAM.Text = Session("_macaddress")
        End If
        'SetgvRAM()
        Allgv()
    End Sub
    Protected Sub btnSerchGroupRAM_Click(sender As Object, e As EventArgs) Handles btnSerchGroupRAM.Click
        Allgv()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "chkGroup", "chkGroup();", True)

        txtGroupRAM.Text = Session("_group")

    End Sub
    Protected Sub chkAllDayRAM_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllDayRAM.CheckedChanged
        chkdayRAM()
    End Sub

    '--------------------------------------------------------------------------------CPU
    Protected Sub btnCancelCPU_Click(sender As Object, e As EventArgs) Handles btnCancelCPU.Click
        ClearCPU()
        CheckRole()
        Allgv()
        chkdayCPU()
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
    Public Sub chkdayCPU()
        If chkAllDayCPU.Checked = True Then
            chkSunCPU.Enabled = False
            chkMonCPU.Enabled = False
            chkTueCPU.Enabled = False
            chkWedCPU.Enabled = False
            chkThuCPU.Enabled = False
            chkFriCPU.Enabled = False
            chkSatCPU.Enabled = False
            txtToTimeCPU.Enabled = False
            txtFromTimeCPU.Enabled = False
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
        Else

            chkSunCPU.Enabled = True
            chkMonCPU.Enabled = True
            chkTueCPU.Enabled = True
            chkWedCPU.Enabled = True
            chkThuCPU.Enabled = True
            chkFriCPU.Enabled = True
            chkSatCPU.Enabled = True
            txtToTimeCPU.Enabled = True
            txtFromTimeCPU.Enabled = True
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
        End If
    End Sub
    Protected Sub chkAllDayCPU_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllDayCPU.CheckedChanged
        chkdayCPU()
    End Sub
    Protected Sub btnSaveCPU_Click(sender As Object, e As EventArgs) Handles btnSaveCPU.Click

        If ValidateCPU() = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
            Allgv()
            Return
        End If

        If (chkByServerCPU.Checked = True) Then
            Dim Ceng As New CPUEng
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigCpuLinqDB
            Dim dt As New DataTable
            Dim checkIDcfCPU As String


            checkIDcfCPU = lblidCPU.Text
            If Convert.ToInt64(checkIDcfCPU > 0) Then
                lnq.GetDataByPK(Convert.ToInt64(checkIDcfCPU), trans.Trans)
            End If


            lnq.SERVERIP = txtServeripCPU.Text
            lnq.SERVERNAME = txtServerNameCPU.Text
            lnq.MACADDRESS = txtMacAddressCPU.Text

            lnq.CHECKINTERVALMINUTE = txtIntervalCPU.Text

            If chkAllDayCPU.Checked = True Then
                lnq.ALLDAYEVENT = GetCheckDay(chkAllDayCPU)
            Else
                lnq.ALARMSUN = GetCheckDay(chkSunCPU)
                lnq.ALARMMON = GetCheckDay(chkMonCPU)
                lnq.ALARMTUE = GetCheckDay(chkTueCPU)
                lnq.ALARMWED = GetCheckDay(chkWedCPU)
                lnq.ALARMTHU = GetCheckDay(chkThuCPU)
                lnq.ALARMFRI = GetCheckDay(chkFriCPU)
                lnq.ALARMSAT = GetCheckDay(chkSatCPU)
                lnq.ALLDAYEVENT = GetCheckDay(chkAllDayCPU)
                lnq.ALARMTIMEFROM = txtFromTimeCPU.Text
                lnq.ALARMTIMETO = txtToTimeCPU.Text
            End If




            lnq.ALARMMINORVALUE = txtMinorCPU.Text
            lnq.REPEATCHECKMINOR = txtRepeatMinorCPU.Text

            lnq.ALARMMAJORVALUE = txtMajorCPU.Text
            lnq.REPEATCHECKMAJOR = txtRepeatMajorCPU.Text

            lnq.ALARMCRITICALVALUE = txtCriticalCPU.Text
            lnq.REPEATCHECKCRITICAL = txtRepeatCriticalCPU.Text


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
                Response.Write("<script language=""javaScript"">alert(""Can not save !"");</script>")
            End If


            lnq = Nothing
        End If

        If (chkByGroupCPU.Checked = True) Then
            If txtGroupCPU.Text = "NoGroup" Then
                Response.Write("<script language=""javaScript"">alert(""Can not save !"");</script>")
                Allgv()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
                Return
            End If
            Dim Ceng As New CPUEng
            Dim dt As New DataTable
            Dim IDcfRAM As String
            Dim Reng As New RAMEng
            Dim _ret As Boolean = False
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

                lnq.CHECKINTERVALMINUTE = txtIntervalCPU.Text

                If chkAllDayCPU.Checked = True Then
                    lnq.ALLDAYEVENT = GetCheckDay(chkAllDayCPU)
                Else
                    lnq.ALARMSUN = GetCheckDay(chkSunCPU)
                    lnq.ALARMMON = GetCheckDay(chkMonCPU)
                    lnq.ALARMTUE = GetCheckDay(chkTueCPU)
                    lnq.ALARMWED = GetCheckDay(chkWedCPU)
                    lnq.ALARMTHU = GetCheckDay(chkThuCPU)
                    lnq.ALARMFRI = GetCheckDay(chkFriCPU)
                    lnq.ALARMSAT = GetCheckDay(chkSatCPU)
                    lnq.ALLDAYEVENT = GetCheckDay(chkAllDayCPU)
                    lnq.ALARMTIMEFROM = txtFromTimeCPU.Text
                    lnq.ALARMTIMETO = txtToTimeCPU.Text
                End If

                lnq.ALARMMINORVALUE = txtMinorCPU.Text
                lnq.REPEATCHECKMINOR = txtRepeatMinorCPU.Text

                lnq.ALARMMAJORVALUE = txtMajorCPU.Text
                lnq.REPEATCHECKMAJOR = txtRepeatMajorCPU.Text

                lnq.ALARMCRITICALVALUE = txtCriticalCPU.Text
                lnq.REPEATCHECKCRITICAL = txtRepeatCriticalCPU.Text


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
                    _ret = ret

                Else
                    trans.RollbackTransaction()
                    _ret = ret

                End If

                lnq = Nothing
            Next


            If _ret = True Then
                Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")
            Else
                Response.Write("<script language=""javaScript"">alert(""Can not save !"");</script>")
            End If

        End If
        ClearCPU()
        Allgv()
        CheckRole()
    End Sub
    Public Sub ClearCPU()

        chkByGroupCPU.Checked = False
        chkByServerCPU.Checked = True
        chkActiveStatusCPU.Checked = True
        lblidCPU.Text = "0"
        SetgvCPU()
        txtServeripCPU.Text = ""
        txtServerNameCPU.Text = ""
        txtMacAddressCPU.Text = ""
        txtIntervalCPU.Text = ""

        chkSunCPU.Checked = False
        chkMonCPU.Checked = False
        chkTueCPU.Checked = False
        chkWedCPU.Checked = False
        chkThuCPU.Checked = False
        chkFriCPU.Checked = False
        chkSatCPU.Checked = False
        chkAllDayCPU.Checked = False

        txtFromTimeCPU.Text = ""
        txtToTimeCPU.Text = ""

        txtMinorCPU.Text = ""
        txtRepeatMinorCPU.Text = ""
        txtMajorCPU.Text = ""
        txtRepeatMajorCPU.Text = ""
        txtCriticalCPU.Text = ""
        txtRepeatCriticalCPU.Text = ""

        txtGroupCPU.Text = ""
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)

    End Sub
    Public Sub SetgvCPU()
        Dim dt As New DataTable
        Dim Ceng As New CPUEng

        dt = Ceng.GetgvCPU("")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("no") = i + 1
                Next

                gvCPU.DataSource = dt
                gvCPU.DataBind()
            End If
            If dt.Rows.Count = 0 Then
                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvCPU.DataSource = dt
                gvCPU.DataBind()
                Dim columnCount As Integer = gvCPU.Rows(0).Cells.Count
                gvCPU.Rows(0).Cells.Clear()
                gvCPU.Rows(0).Cells.Add(New TableCell)
                gvCPU.Rows(0).Cells(0).ColumnSpan = columnCount
                gvCPU.Rows(0).Cells(0).Text = "No Records Found."
            End If

        End If


    End Sub
    Protected Sub gvCPU_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCPU.RowCommand


        If e.CommandName = "EditRow" Then
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigCpuLinqDB
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lnq.GetDataByPK(RowIndex, trans.Trans)

            Dim dt As New DataTable
            Dim groupName As String
            Dim sql = "Select G.group_desc  from TB_GROUP G join TB_REGISTER R on G.id = R.group_id"
            sql += " join CF_CONFIG_CPU CP on R .ServerIP = CP .ServerIP  where CP.id = '" & RowIndex & "' "
            dt = lnq.GetListBySql(sql, trans.Trans)
            If dt.Rows.Count > 0 Then

                groupName = dt.Rows(0)(0).ToString
                txtGroupCPU.Text = groupName.ToString

            End If

            'Dim GroupName As Label = CType(gvCPU.Rows(RowIndex).FindControl("lblgroup_desc"), Label)
            'txtGroupCPU.Text = GroupName.Text

            If lnq.ID > 0 Then

                txtServeripCPU.Text = lnq.SERVERIP
                txtServerNameCPU.Text = lnq.SERVERNAME
                txtMacAddressCPU.Text = lnq.MACADDRESS

                txtIntervalCPU.Text = lnq.CHECKINTERVALMINUTE

                If lnq.ALARMSUN = "Y" Then
                    chkSunCPU.Checked = True
                Else
                    chkSunCPU.Checked = False
                End If

                If lnq.ALARMMON = "Y" Then
                    chkMonCPU.Checked = True
                Else
                    chkMonCPU.Checked = False
                End If

                If lnq.ALARMTUE = "Y" Then
                    chkTueCPU.Checked = True
                Else
                    chkTueCPU.Checked = False
                End If

                If lnq.ALARMWED = "Y" Then
                    chkWedCPU.Checked = True
                Else
                    chkWedCPU.Checked = False
                End If

                If lnq.ALARMTHU = "Y" Then
                    chkThuCPU.Checked = True
                Else
                    chkThuCPU.Checked = False
                End If

                If lnq.ALARMFRI = "Y" Then
                    chkFriCPU.Checked = True
                Else
                    chkFriCPU.Checked = False
                End If

                If lnq.ALARMSAT = "Y" Then
                    chkSatCPU.Checked = True
                Else
                    chkSatCPU.Checked = False
                End If

                If lnq.ALLDAYEVENT = "Y" Then
                    chkAllDayCPU.Checked = True
                Else
                    chkAllDayCPU.Checked = False
                End If
                chkdayCPU()

                txtFromTimeCPU.Text = lnq.ALARMTIMEFROM
                txtToTimeCPU.Text = lnq.ALARMTIMETO

                txtMinorCPU.Text = lnq.ALARMMINORVALUE
                txtRepeatMinorCPU.Text = lnq.REPEATCHECKMINOR
                txtMajorCPU.Text = lnq.ALARMMAJORVALUE
                txtRepeatMajorCPU.Text = lnq.REPEATCHECKMAJOR
                txtCriticalCPU.Text = lnq.ALARMCRITICALVALUE
                txtRepeatCriticalCPU.Text = lnq.REPEATCHECKCRITICAL

                lblidCPU.Text = lnq.ID

                If lnq.ACTIVESTATUS = "Y" Then
                    chkActiveStatusCPU.Checked = True
                Else
                    chkActiveStatusCPU.Checked = False
                End If


                chkByServerCPU.Checked = True
                chkByGroupCPU.Checked = False


            End If

            btnSerchGroupCPU.Enabled = True
            btnSerchipCPU.Enabled = True
            btnSaveCPU.Enabled = True
            btnCancelCPU.Enabled = True

        End If


        If e.CommandName = "DeleteRow" Then

            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then

                Dim trans As New TransactionDB
                Dim lnq As New CfConfigCpuLinqDB
                Dim ret As Boolean = False
                'Dim lblID As Label
                Dim RowIndex As Integer
                Integer.TryParse(e.CommandArgument.ToString, RowIndex)
              
                ret = lnq.DeleteByPK(RowIndex, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()

                    Response.Write("<script language=""javaScript"">alert(""Delete data Complete !"");</script>")
                Else
                    trans.RollbackTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Can not Delete Data!"");</script>")
                End If

                'ClearTextBox(Me)
                ClearCPU()
            End If
        End If
        Allgv()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
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

        If txtIntervalCPU.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Interval !"");</script>")
            Return False
        End If

        If chkAllDayCPU.Checked = False Then
            Dim ret As Boolean = False
            If chkSunCPU.Checked = True Then
                ret = True
            End If
            If chkMonCPU.Checked = True Then
                ret = True
            End If
            If chkTueCPU.Checked = True Then
                ret = True
            End If
            If chkWedCPU.Checked = True Then
                ret = True
            End If
            If chkThuCPU.Checked = True Then
                ret = True
            End If
            If chkFriCPU.Checked = True Then
                ret = True
            End If
            If chkSatCPU.Checked = True Then
                ret = True
            End If

            If ret = False Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Day !"");</script>")
                Return False
            End If


        End If
        If chkAllDayCPU.Checked = False Then
            If txtFromTimeCPU.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check From Time !"");</script>")
                Return False
            End If

            If txtToTimeCPU.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check To Time !"");</script>")
                Return False
            End If

            Dim FromTime As DateTime = Convert.ToDateTime(txtFromTimeCPU.Text)
            Dim ToTime As DateTime = Convert.ToDateTime(txtToTimeCPU.Text)

            If FromTime > ToTime Then
                Response.Write("<script language=""javaScript"">alert(""Please, Check " & ToTime.ToString("HH:mm") & " more than  " & FromTime.ToString("HH:mm") & " !"");</script>")
                Return False
            End If
        End If




        If txtMinorCPU.Text.Trim() = "" Or txtMinorCPU.Text.Trim() = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Minor!"");</script>")
            Return False
        End If
        If txtRepeatMinorCPU.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat Minor !"");</script>")
            Return False
        End If
        If txtMajorCPU.Text.Trim() = "" Or txtMajorCPU.Text.Trim() = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Major!"");</script>")
            Return False
        End If
        If txtRepeatMajorCPU.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat Major !"");</script>")
            Return False
        End If
        If txtCriticalCPU.Text.Trim() = "" Or txtCriticalCPU.Text.Trim() = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Critical!"");</script>")
            Return False
        End If
        If txtRepeatCriticalCPU.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat Critical !"");</script>")
            Return False
        End If

        Dim chk As Boolean = False
        If Convert.ToInt32(txtCriticalCPU.Text) > Convert.ToInt32(txtMajorCPU.Text) Then
            If Convert.ToInt32(txtMajorCPU.Text) > Convert.ToInt32(txtMinorCPU.Text) Then
                chk = True
            Else
                chk = False
            End If
        Else
            chk = False
        End If

        If chk = False Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Severity!"");</script>")
            txtMinorCPU.Text = ""
            txtMajorCPU.Text = ""
            txtCriticalCPU.Text = ""
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
        Dim ip As String = Session("_serverip")
        If ip <> "" Then
            txtServeripCPU.Text = Session("_serverip")
            txtServerNameCPU.Text = Session("_servername")
            txtMacAddressCPU.Text = Session("_macaddress")
        End If
        'SetgvCPU()
        Allgv()
    End Sub
    Protected Sub btnSerchGroupCPU_Click(sender As Object, e As EventArgs) Handles btnSerchGroupCPU.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivCPU", "DivCPU();", True)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "chkGroup", "chkGroupCPU(); ", True)
        txtGroupCPU.Text = Session("_group")
        'SetgvCPU()
        Allgv()
    End Sub


    'Drive---------------------------------------------------------------------------------------------

    Public Sub ClearTextBox_Drive()
        chkSunDrive.Checked = False
        chkMonDrive.Checked = False
        chkTueDrive.Checked = False
        chkWedDrive.Checked = False
        chkThuDrive.Checked = False
        chkFriDrive.Checked = False
        chkSatDrive.Checked = False
        chkAllDayDrive.Checked = False
        chkdayDrive()
        txtFromTimeDrive.Text = ""
        txtToTimeDrive.Text = ""

        txtServerIPDriver.Text = ""
        txtServerNameDrive.Text = ""
        txtMacAddressDrive.Text = ""
        txtMinorDrive.Text = ""
        txtRepeatMinorDrive.Text = ""
        txtMajorDrive.Text = ""
        txtRepeatMajorDrive.Text = ""
        txtCriticalDrive.Text = ""
        txtRepeatCriticalDrive.Text = ""

        txtIntervalDrive.Text = ""
        lblidDrive.Text = "0"
        lblDriveid.Text = "0"

        ddlDriveName()


        gvSelectDrive.DataSource = New DataTable
        gvSelectDrive.DataBind()
        chkActiveStatusDrive.Checked = True
        SetgvDrive()
    End Sub
    Protected Sub btnCancelDrive_Click(sender As Object, e As EventArgs) Handles btnCancelDrive.Click
        ClearTextBox_Drive()
        CheckRole()
        Allgv()
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

            If dt.Rows.Count = 0 Then

                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvDrive.DataSource = dt
                gvDrive.DataBind()
                Dim columnCount As Integer = gvDrive.Rows(0).Cells.Count
                gvDrive.Rows(0).Cells.Clear()
                gvDrive.Rows(0).Cells.Add(New TableCell)
                gvDrive.Rows(0).Cells(0).ColumnSpan = columnCount
                gvDrive.Rows(0).Cells(0).Text = "No Records Found."
            End If
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
    Public Sub _ddlCheck()
        Dim Drive As String = ""
        For i As Integer = 0 To gvSelectDrive.Rows.Count - 1
            Dim DriveName As Label = CType(gvSelectDrive.Rows(i).FindControl("lblDrivename"), Label)


            If DriveName.Text.Trim() <> "" Then
                Drive += "'" & DriveName.Text & "',"
            End If
        Next
        If Drive <> "" Then
            Drive = Drive.Substring(0, Drive.Length - 1)

        End If
        Dim dt As New DataTable
        Dim Deng As New DriveENG
        Dim cf As New Config

        dt = Deng.ddlDriverName("ServerIP = '" & txtServerIPDriver.Text & "' and DriveLetter not in(" & Drive & ")")
        cf.SetDDLData(dt, ddlDriverName, "DriveLetter", "id", "<-- Select -->", "0")
    End Sub
    Public Sub _NameDrive(ByVal _drive As String)
        Dim Drive As String = ""
        For i As Integer = 0 To gvSelectDrive.Rows.Count - 1
            Dim DriveName As Label = CType(gvSelectDrive.Rows(i).FindControl("lblDrivename"), Label)

            If _drive <> DriveName.Text Then

                If DriveName.Text.Trim() <> "" Then
                    Drive += "'" & DriveName.Text & "',"
                End If

            End If


        Next
        If Drive <> "" Then
            Drive = Drive.Substring(0, Drive.Length - 1)

            Drive = " and DriveLetter not in(" & Drive & ")"
        End If
        Dim dt As New DataTable
        Dim Deng As New DriveENG
        Dim cf As New Config

        dt = Deng.ddlDriverName("ServerIP = '" & txtServerIPDriver.Text & "'" & Drive)
        cf.SetDDLData(dt, ddlDriverName, "DriveLetter", "id", "<-- Select -->", "0")
    End Sub
    Protected Sub SubmitDriveName_Click(sender As Object, e As EventArgs) Handles SubmitDriveName.Click

        If ddlDriverName.SelectedValue = 0 Then
            Response.Write("<script language=""javaScript"">alert(""Please, Select Drive "");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
            Return
        End If
        If txtMinorDrive.Text = "" Or txtMinorDrive.Text = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Minor !"");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
            Return
        End If
        If txtRepeatMinorDrive.Text = "" Then
            Response.Write("<script language=""javaScript"">alert(""Check Repeat Minor Null"");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
            Return
        End If
        If txtMajorDrive.Text = "" Or txtMajorDrive.Text = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Major !"");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
            Return
        End If
        If txtRepeatMajorDrive.Text = "" Then
            Response.Write("<script language=""javaScript"">alert(""Check Repeat Major Null "");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
            Return
        End If
        If txtCriticalDrive.Text = "" Or txtCriticalDrive.Text = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Critical !"");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
            Return
        End If
        If txtRepeatCriticalDrive.Text = "" Then
            Response.Write("<script language=""javaScript"">alert(""Check Repeat Critical Null "");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
            Return
        End If
        Dim chk As Boolean = False
        If Convert.ToInt32(txtCriticalDrive.Text) > Convert.ToInt32(txtMajorDrive.Text) Then
            If Convert.ToInt32(txtMajorDrive.Text) > Convert.ToInt32(txtMinorDrive.Text) Then
                chk = True
            Else
                chk = False
            End If
        Else
            chk = False
        End If

        If chk = False Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Severity!"");</script>")
            txtMinorDrive.Text = ""
            txtMajorDrive.Text = ""
            txtCriticalDrive.Text = ""
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
            Return

        End If


        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Long))
        dt.Columns.Add("DriveName", GetType(String))
        dt.Columns.Add("Minor", GetType(String))
        dt.Columns.Add("RepeatMinor", GetType(String))
        dt.Columns.Add("Major", GetType(String))
        dt.Columns.Add("RepeatMajor", GetType(String))
        dt.Columns.Add("Critical", GetType(String))
        dt.Columns.Add("RepeatCritical", GetType(String))

        If gvSelectDrive.Rows.Count > 0 Then

            For i As Integer = 0 To gvSelectDrive.Rows.Count - 1

                Dim id As Label = CType(gvSelectDrive.Rows(i).FindControl("lblid"), Label)
                Dim DriveName As Label = CType(gvSelectDrive.Rows(i).FindControl("lblDrivename"), Label)
                Dim Minor As Label = CType(gvSelectDrive.Rows(i).FindControl("lblMinor"), Label)
                Dim RepeatMinor As Label = CType(gvSelectDrive.Rows(i).FindControl("lblRepeatMinor"), Label)
                Dim Major As Label = CType(gvSelectDrive.Rows(i).FindControl("lblMajor"), Label)
                Dim RepeatMajor As Label = CType(gvSelectDrive.Rows(i).FindControl("lblRepeatMajor"), Label)
                Dim Critical As Label = CType(gvSelectDrive.Rows(i).FindControl("lblCritical"), Label)
                Dim RepeatCritical As Label = CType(gvSelectDrive.Rows(i).FindControl("lblRepeatCritical"), Label)
                Dim Drive As String = ddlDriverName.SelectedItem.Text

                If DriveName.Text.Trim() <> Drive.Trim() Then
                    Dim _dr As DataRow
                    _dr = dt.NewRow
                    _dr("id") = id.Text
                    _dr("DriveName") = DriveName.Text
                    _dr("Minor") = Minor.Text
                    _dr("RepeatMinor") = RepeatMinor.Text
                    _dr("Major") = Major.Text
                    _dr("RepeatMajor") = RepeatMajor.Text
                    _dr("Critical") = Critical.Text
                    _dr("RepeatCritical") = RepeatCritical.Text
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
        dr("RepeatMinor") = txtRepeatMinorDrive.Text
        dr("Major") = txtMajorDrive.Text
        dr("RepeatMajor") = txtRepeatMajorDrive.Text
        dr("Critical") = txtCriticalDrive.Text
        dr("RepeatCritical") = txtRepeatCriticalDrive.Text
        dt.Rows.Add(dr)

        gvSelectDrive.DataSource = dt
        gvSelectDrive.DataBind()
      


        _ddlCheck()
        'ddlDriveName()
        txtMinorDrive.Text = ""
        txtMajorDrive.Text = ""
        txtCriticalDrive.Text = ""
        txtRepeatMinorDrive.Text = ""
        txtRepeatMajorDrive.Text = ""
        txtRepeatCriticalDrive.Text = ""
        lblDriveid.Text = "0"

    
        If gvSelectDrive.Rows.Count > 0 Then
            lblnoDrive.Visible = False
        Else
            lblnoDrive.Visible = True
        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)

    End Sub
    Protected Sub gvSelectDrive_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvSelectDrive.RowCommand

        If e.CommandName = "EditRow" Then

            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)

            Dim id As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblid"), Label)
            Dim DriveName As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblDrivename"), Label)
            Dim Minor As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblMinor"), Label)
            Dim RepeatMinor As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblRepeatMinor"), Label)
            Dim Major As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblMajor"), Label)
            Dim RepeatMajor As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblRepeatMajor"), Label)
            Dim Critical As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblCritical"), Label)
            Dim RepeatCritical As Label = CType(gvSelectDrive.Rows(RowIndex).FindControl("lblRepeatCritical"), Label)

            Dim _dt As New DataTable
            Dim cf As New Config
            Dim Deng As New DriveENG
            _dt = Deng.ddlDriverName("ServerIP = '" & txtServerIPDriver.Text & "'")
            For i As Integer = 0 To _dt.Rows.Count - 1
                If DriveName.Text = _dt.Rows(i)("DriveLetter").ToString() Then
                    _NameDrive(DriveName.Text)
                    ddlDriverName.SelectedValue = _dt.Rows(i)("id").ToString()
                End If
            Next

            txtMinorDrive.Text = Minor.Text
            txtRepeatMinorDrive.Text = RepeatMinor.Text
            txtMajorDrive.Text = Major.Text
            txtRepeatMajorDrive.Text = RepeatMajor.Text
            txtCriticalDrive.Text = Critical.Text
            txtRepeatCriticalDrive.Text = RepeatCritical.Text
            lblDriveid.Text = id.Text

            If gvSelectDrive.Rows.Count > 0 Then
                lblnoDrive.Visible = False

            Else
                gvSelectDrive.Visible = True
            End If

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
                dt.Columns.Add("RepeatMinor", GetType(String))
                dt.Columns.Add("Major", GetType(String))
                dt.Columns.Add("RepeatMajor", GetType(String))
                dt.Columns.Add("Critical", GetType(String))
                dt.Columns.Add("RepeatCritical", GetType(String))


                For i As Integer = 0 To gvSelectDrive.Rows.Count - 1

                    Dim id As Label = CType(gvSelectDrive.Rows(i).FindControl("lblid"), Label)
                    Dim DriveName As Label = CType(gvSelectDrive.Rows(i).FindControl("lblDrivename"), Label)
                    Dim Minor As Label = CType(gvSelectDrive.Rows(i).FindControl("lblMinor"), Label)
                    Dim RepeatMinor As Label = CType(gvSelectDrive.Rows(i).FindControl("lblRepeatMinor"), Label)
                    Dim Major As Label = CType(gvSelectDrive.Rows(i).FindControl("lblMajor"), Label)
                    Dim RepeatMajor As Label = CType(gvSelectDrive.Rows(i).FindControl("lblRepeatMajor"), Label)
                    Dim Critical As Label = CType(gvSelectDrive.Rows(i).FindControl("lblCritical"), Label)
                    Dim RepeatCritical As Label = CType(gvSelectDrive.Rows(i).FindControl("lblRepeatCritical"), Label)


                    If DeleteDrive.Text.Trim() <> DriveName.Text.Trim() Then
                        Dim dr As DataRow
                        dr = dt.NewRow
                        dr("id") = id.Text
                        dr("DriveName") = DriveName.Text
                        dr("Minor") = Minor.Text
                        dr("RepeatMinor") = RepeatMinor.Text
                        dr("Major") = Major.Text
                        dr("RepeatMajor") = RepeatMajor.Text
                        dr("Critical") = Critical.Text
                        dr("RepeatCritical") = RepeatCritical.Text
                        dt.Rows.Add(dr)
                    End If

                Next
                gvSelectDrive.DataSource = dt
                gvSelectDrive.DataBind()
                _ddlCheck()

            If gvSelectDrive.Rows.Count > 0 Then
                lblnoDrive.Visible = False
            Else
                lblnoDrive.Visible = True
            End If
        End If
        Allgv()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
    End Sub
    Protected Sub ddlDriverName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDriverName.SelectedIndexChanged

        txtMinorDrive.Text = ""
        txtRepeatMinorDrive.Text = ""
        txtMajorDrive.Text = ""
        txtRepeatMajorDrive.Text = ""
        txtCriticalDrive.Text = ""
        txtRepeatCriticalDrive.Text = ""

        Allgv()
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
            Allgv()
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
        lnq.CHECKINTERVALMINUTE = txtIntervalDrive.Text

        If chkAllDayCPU.Checked = True Then
            lnq.ALLDAYEVENT = GetCheckDay(chkAllDayDrive)
        Else
            lnq.ALARMSUN = GetCheckDay(chkSunDrive)
            lnq.ALARMMON = GetCheckDay(chkMonDrive)
            lnq.ALARMTUE = GetCheckDay(chkTueDrive)
            lnq.ALARMWED = GetCheckDay(chkWedDrive)
            lnq.ALARMTHU = GetCheckDay(chkThuDrive)
            lnq.ALARMFRI = GetCheckDay(chkFriDrive)
            lnq.ALARMSAT = GetCheckDay(chkSatDrive)
            lnq.ALLDAYEVENT = GetCheckDay(chkAllDayDrive)
            lnq.ALARMTIMEFROM = txtFromTimeDrive.Text
            lnq.ALARMTIMETO = txtToTimeDrive.Text
        End If



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
            Response.Write("<script language=""javaScript"">alert(""Can not save !"");</script>")
        End If


        lnq = Nothing
        ClearTextBox_Drive()
        Allgv()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
        CheckRole()

    End Sub
    Public Sub SaveDriveDetail(ByVal idDrive As String)

        For i As Integer = 0 To gvSelectDrive.Rows.Count - 1
            Dim lnq As New CfConfigDriveDetailLinqDB
            Dim trans As New TransactionDB

            Dim id As Label = CType(gvSelectDrive.Rows(i).FindControl("lblid"), Label)
            Dim DriveName As Label = CType(gvSelectDrive.Rows(i).FindControl("lblDrivename"), Label)
            Dim Minor As Label = CType(gvSelectDrive.Rows(i).FindControl("lblMinor"), Label)
            Dim RepeatMinor As Label = CType(gvSelectDrive.Rows(i).FindControl("lblRepeatMinor"), Label)
            Dim Major As Label = CType(gvSelectDrive.Rows(i).FindControl("lblMajor"), Label)
            Dim RepeatMajor As Label = CType(gvSelectDrive.Rows(i).FindControl("lblRepeatMajor"), Label)
            Dim Critical As Label = CType(gvSelectDrive.Rows(i).FindControl("lblCritical"), Label)
            Dim RepeatCritical As Label = CType(gvSelectDrive.Rows(i).FindControl("lblRepeatCritical"), Label)

            Dim _id As Int64 = Convert.ToInt64(id.Text)

            If _id > 0 Then
                lnq.GetDataByPK(_id, trans.Trans)
            End If

            lnq.CF_CONFIG_DRIVE_ID = Convert.ToInt32(idDrive)
            lnq.DRIVELETTER = DriveName.Text
            lnq.ALARMMINORVALUE = Minor.Text
            lnq.REPEATCHECKMINOR = RepeatMinor.Text
            lnq.ALARMMAJORVALUE = Major.Text
            lnq.REPEATCHECKMAJOR = RepeatMajor.Text
            lnq.ALARMCRITICALVALUE = Critical.Text
            lnq.REPEATCHECKCRITICAL = RepeatCritical.Text

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

        If chkAllDayDrive.Checked = False Then
            Dim ret As Boolean = False
            If chkSunDrive.Checked = True Then
                ret = True
            End If
            If chkMonDrive.Checked = True Then
                ret = True
            End If
            If chkTueDrive.Checked = True Then
                ret = True
            End If
            If chkWedDrive.Checked = True Then
                ret = True
            End If
            If chkThuDrive.Checked = True Then
                ret = True
            End If
            If chkFriDrive.Checked = True Then
                ret = True
            End If
            If chkSatDrive.Checked = True Then
                ret = True
            End If

            If ret = False Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Day !"");</script>")
                Return False
            End If


        End If
        If chkAllDayDrive.Checked = False Then
            If txtFromTimeDrive.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check From Time !"");</script>")
                Return False
            End If

            If txtToTimeDrive.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check To Time !"");</script>")
                Return False
            End If

            Dim FromTime As DateTime = Convert.ToDateTime(txtFromTimeDrive.Text)
            Dim ToTime As DateTime = Convert.ToDateTime(txtToTimeDrive.Text)

            If FromTime > ToTime Then
                Response.Write("<script language=""javaScript"">alert(""Please, Check " & ToTime.ToString("HH:mm") & " more than  " & FromTime.ToString("HH:mm") & " !"");</script>")
                Return False
            End If
        End If

        If gvSelectDrive.Rows.Count = 0 Then
            Response.Write("<script language=""javaScript"">alert(""Please, Click Submit before !"");</script>")
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
            'Dim drive_id As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            'drive_id = CType(gvDrive.Rows(RowIndex).FindControl("lblcf_config_drive_id"), Label)

            lnq.GetDataByPK(RowIndex, trans.Trans)

            If lnq.ID > 0 Then

                dt = Deng.GetgvDrive("cfD.id='" & RowIndex & "'")

                Dim dtTypeDrive As New DataTable()
                dtTypeDrive.Columns.Add("id", GetType(String))
                dtTypeDrive.Columns.Add("DriveName", GetType(String))
                dtTypeDrive.Columns.Add("Minor", GetType(String))
                dtTypeDrive.Columns.Add("RepeatMinor", GetType(String))
                dtTypeDrive.Columns.Add("Major", GetType(String))
                dtTypeDrive.Columns.Add("RepeatMajor", GetType(String))
                dtTypeDrive.Columns.Add("Critical", GetType(String))
                dtTypeDrive.Columns.Add("RepeatCritical", GetType(String))
                For i As Integer = 0 To dt.Rows.Count - 1

                    Dim dr As DataRow = dtTypeDrive.NewRow()
                    dr(0) = dt.Rows(i)("idDriveDetail").ToString()
                    dr(1) = dt.Rows(i)("DriveLetter").ToString()
                    dr(2) = dt.Rows(i)("AlarmMinorValue").ToString()
                    dr(3) = dt.Rows(i)("RepeatCheckMinor").ToString()
                    dr(4) = dt.Rows(i)("AlarmMajorValue").ToString()
                    dr(5) = dt.Rows(i)("RepeatCheckMajor").ToString()
                    dr(6) = dt.Rows(i)("AlarmCriticalValue").ToString()
                    dr(7) = dt.Rows(i)("RepeatCheckCritical").ToString()
                    dtTypeDrive.Rows.Add(dr)

                Next
                gvSelectDrive.DataSource = dtTypeDrive
                gvSelectDrive.DataBind()

                txtServerIPDriver.Text = lnq.SERVERIP
                txtServerNameDrive.Text = lnq.SERVERNAME
                txtMacAddressDrive.Text = lnq.MACADDRESS
                txtIntervalDrive.Text = lnq.CHECKINTERVALMINUTE

                If lnq.ALARMSUN = "Y" Then
                    chkSunDrive.Checked = True
                Else
                    chkSunDrive.Checked = False
                End If

                If lnq.ALARMMON = "Y" Then
                    chkMonDrive.Checked = True
                Else
                    chkMonDrive.Checked = False
                End If

                If lnq.ALARMTUE = "Y" Then
                    chkTueDrive.Checked = True
                Else
                    chkTueDrive.Checked = False
                End If

                If lnq.ALARMWED = "Y" Then
                    chkWedDrive.Checked = True
                Else
                    chkWedDrive.Checked = False
                End If

                If lnq.ALARMTHU = "Y" Then
                    chkThuDrive.Checked = True
                Else
                    chkThuDrive.Checked = False
                End If

                If lnq.ALARMFRI = "Y" Then
                    chkFriDrive.Checked = True
                Else
                    chkFriDrive.Checked = False
                End If

                If lnq.ALARMSAT = "Y" Then
                    chkSatDrive.Checked = True
                Else
                    chkSatDrive.Checked = False
                End If

                If lnq.ALLDAYEVENT = "Y" Then
                    chkAllDayDrive.Checked = True
                Else
                    chkAllDayDrive.Checked = False
                End If
                chkdayDrive()

                txtFromTimeDrive.Text = lnq.ALARMTIMEFROM
                txtToTimeDrive.Text = lnq.ALARMTIMETO

                lblidDrive.Text = lnq.ID
                'ddlDriveName()
                _ddlCheck()
                If lnq.ACTIVESTATUS = "Y" Then
                    chkActiveStatusDrive.Checked = True
                Else
                    chkActiveStatusDrive.Checked = False
                End If

            End If
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)

            SubmitDriveName.Enabled = True
            btnSerchipDrive.Enabled = True
            btnSaveDrive.Enabled = True
            btnCancelDrive.Enabled = True

        End If



        If e.CommandName = "DeleteRow" Then

            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then

                'Dim CheckIDdrive As Label
                Dim RowIndex As Integer
                Dim dt As New DataTable
                Integer.TryParse(e.CommandArgument.ToString, RowIndex)

                'CheckIDdrive = CType(gvDrive.Rows(RowIndex).FindControl("lblcf_config_drive_id"), Label)
                'Dim _CheckIDdrive As String = CheckIDdrive.Text


                dt = Deng.GetgvDrive("cfD.id='" & RowIndex & "'")
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
                dt = Deng.GetgvDrive("cfD.id='" & RowIndex & "'")
                If dt.Rows.Count = 0 Then

                    Dim ret As Boolean = False
                    Dim lnq As New CfConfigDriveLinqDB
                    Dim trans As New TransactionDB

                    ret = lnq.DeleteByPK(RowIndex, trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()
                        Response.Write("<script language=""javaScript"">alert(""Delete data Complete !"");</script>")
                    Else
                        trans.RollbackTransaction()
                        Response.Write("<script language=""javaScript"">alert(""Can not Delete !"");</script>")
                    End If
                End If

                ClearTextBox_Drive()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
            End If
        End If
        Allgv()
    End Sub
    Protected Sub btnSerchipDrive_Click(sender As Object, e As EventArgs) Handles btnSerchipDrive.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)

        Dim ip As String = Session("_serverip")
        If ip <> "" Then
            txtServerIPDriver.Text = Session("_serverip")
            txtServerNameDrive.Text = Session("_servername")
            txtMacAddressDrive.Text = Session("_macaddress")
            ddlDriveName()
        End If
        Allgv()
    End Sub
    Protected Sub chkAllDayDrive_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllDayDrive.CheckedChanged
        chkdayDrive()
    End Sub
    Public Sub chkdayDrive()
        If chkAllDayDrive.Checked = True Then
            chkSunDrive.Enabled = False
            chkMonDrive.Enabled = False
            chkTueDrive.Enabled = False
            chkWedDrive.Enabled = False
            chkThuDrive.Enabled = False
            chkFriDrive.Enabled = False
            chkSatDrive.Enabled = False
            txtToTimeDrive.Enabled = False
            txtFromTimeDrive.Enabled = False

        Else
            chkSunDrive.Enabled = True
            chkMonDrive.Enabled = True
            chkTueDrive.Enabled = True
            chkWedDrive.Enabled = True
            chkThuDrive.Enabled = True
            chkFriDrive.Enabled = True
            chkSatDrive.Enabled = True
            txtToTimeDrive.Enabled = True
            txtFromTimeDrive.Enabled = True

        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivDrive", "DivDrive();", True)
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
        If txtRepeatCheckService.Text.Trim() = "" Or txtRepeatCheckService.Text = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Interval !"");</script>")
            Return False
        End If
        If txtIntervalService.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Interval !"");</script>")
            Return False
        End If

        If chkAllDayService.Checked = False Then
            Dim ret As Boolean = False
            If chkSunService.Checked = True Then
                ret = True
            End If
            If chkMonService.Checked = True Then
                ret = True
            End If
            If chkTueService.Checked = True Then
                ret = True
            End If
            If chkWedService.Checked = True Then
                ret = True
            End If
            If chkThuService.Checked = True Then
                ret = True
            End If
            If chkFriService.Checked = True Then
                ret = True
            End If
            If chkSatService.Checked = True Then
                ret = True
            End If

            If ret = False Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Day !"");</script>")
                Return False
            End If


        End If
        If chkAllDayService.Checked = False Then
            If txtFromTimeService.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check From Time !"");</script>")
                Return False
            End If

            If txtToTimeService.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check To Time !"");</script>")
                Return False
            End If

            Dim FromTime As DateTime = Convert.ToDateTime(txtFromTimeService.Text)
            Dim ToTime As DateTime = Convert.ToDateTime(txtToTimeService.Text)

            If FromTime > ToTime Then
                Response.Write("<script language=""javaScript"">alert(""Please, Check " & ToTime.ToString("HH:mm") & " more than  " & FromTime.ToString("HH:mm") & " !"");</script>")
                Return False
            End If
        End If


        Dim chk As Boolean = False
        For m As Integer = 0 To gvShowService.Rows.Count - 1

            Dim chkService As CheckBox = DirectCast(gvShowService.Rows(m).FindControl("chkService"), CheckBox)
            If chkService.Checked = True Then
                chk = True
            End If

        Next

        If chk = False Then
            Response.Write("<script language=""javaScript"">alert(""Please, check Alarm Severity!"");</script>")
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
            If dt.Rows.Count = 0 Then
                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvService.DataSource = dt
                gvService.DataBind()
                Dim columnCount As Integer = gvService.Rows(0).Cells.Count
                gvService.Rows(0).Cells.Clear()
                gvService.Rows(0).Cells.Add(New TableCell)
                gvService.Rows(0).Cells(0).ColumnSpan = columnCount
                gvService.Rows(0).Cells(0).Text = "No Records Found."
            End If
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
            Allgv()
            Return
        End If

        Dim _ret As Boolean = False
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

                If chkAllDayCPU.Checked = True Then
                    lnq.ALLDAYEVENT = GetCheckDay(chkAllDayService)
                Else
                    lnq.ALARMSUN = GetCheckDay(chkSunService)
                    lnq.ALARMMON = GetCheckDay(chkMonService)
                    lnq.ALARMTUE = GetCheckDay(chkTueService)
                    lnq.ALARMWED = GetCheckDay(chkWedService)
                    lnq.ALARMTHU = GetCheckDay(chkThuService)
                    lnq.ALARMFRI = GetCheckDay(chkFriService)
                    lnq.ALARMSAT = GetCheckDay(chkSatService)
                    lnq.ALLDAYEVENT = GetCheckDay(chkAllDayService)
                    lnq.ALARMTIMEFROM = txtFromTimeService.Text
                    lnq.ALARMTIMETO = txtToTimeService.Text
                End If

                If chkActiveStatusService.Checked = True Then
                    lnq.ACTIVESTATUS = Convert.ToChar("Y")
                Else
                    lnq.ACTIVESTATUS = Convert.ToChar("N")
                End If


                If (lnq.ID > 0) Then
                    _ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)

                Else
                    _ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
                End If

                If _ret = True Then
                    trans.CommitTransaction()

                Else
                    trans.RollbackTransaction()
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

                        End If

                    End If

                End If
            End If

        Next

        If _ret = True Then
            Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")

        Else
            Response.Write("<script language=""javaScript"">alert(""Can not save !"");</script>")
        End If

        Allgv()
        ClearService()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True)
        CheckRole()
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

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigServiceLinqDB
            Dim lblServiceIP As String = e.CommandArgument.ToString
            Dim _id As String
          
            _id = _Idservice(lblServiceIP.ToString)

            lnq.GetDataByPK(_id, trans.Trans)

            If lnq.ID > 0 Then

                CheckIdcfService(lblServiceIP.ToString)

                txtServeripService.Text = lnq.SERVERIP
                txtServerNameService.Text = lnq.SERVERNAME
                txtMacAddressService.Text = lnq.MACADDRESS
                'txtRepeatCheckService.Text = lnq.REPEATCHECKQTY
                txtIntervalService.Text = lnq.CHECKINTERVALMINUTE

                If lnq.ALARMSUN = "Y" Then
                    chkSunService.Checked = True
                Else
                    chkSunService.Checked = False
                End If

                If lnq.ALARMMON = "Y" Then
                    chkMonService.Checked = True
                Else
                    chkMonService.Checked = False
                End If

                If lnq.ALARMTUE = "Y" Then
                    chkTueService.Checked = True
                Else
                    chkTueService.Checked = False
                End If

                If lnq.ALARMWED = "Y" Then
                    chkWedService.Checked = True
                Else
                    chkWedService.Checked = False
                End If

                If lnq.ALARMTHU = "Y" Then
                    chkThuService.Checked = True
                Else
                    chkThuService.Checked = False
                End If

                If lnq.ALARMFRI = "Y" Then
                    chkFriService.Checked = True
                Else
                    chkFriService.Checked = False
                End If

                If lnq.ALARMSAT = "Y" Then
                    chkSatService.Checked = True
                Else
                    chkSatService.Checked = False
                End If

                If lnq.ALLDAYEVENT = "Y" Then
                    chkAllDayService.Checked = True
                Else
                    chkAllDayService.Checked = False
                End If
                chkdayService()

                txtFromTimeService.Text = lnq.ALARMTIMEFROM
                txtToTimeService.Text = lnq.ALARMTIMETO

                If lnq.ACTIVESTATUS = "Y" Then
                    chkActiveStatusService.Checked = True
                Else
                    chkActiveStatusService.Checked = False
                End If

            End If

            btnAddService.Enabled = True
            btnSerchipService.Enabled = True
            btnSaveService.Enabled = True
            btnCancelService.Enabled = True
        End If

        If e.CommandName = "DeleteRow" Then

            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then
                Dim ret As Boolean = False
                Dim lblServiceIP As String = e.CommandArgument.ToString
               
                Dim Seng As New ServiceENG
                Dim dt As New DataTable
                dt = Seng.SetgvService("ServerIP = '" & lblServiceIP.ToString & "'")

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim trans As New TransactionDB
                    Dim lnq As New CfConfigServiceLinqDB

                    Dim id As String = dt.Rows(i)(0).ToString
                    ret = lnq.DeleteByPK(id, trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()

                    Else
                        trans.RollbackTransaction()

                    End If
                    lnq = Nothing

                Next

                SetgvService()
                CheckIdcfService(lblServiceIP.ToString)
                ClearService()
                If ret = True Then

                    Response.Write("<script language=""javaScript"">alert(""Delete data Complete !"");</script>")
                Else

                    Response.Write("<script language=""javaScript"">alert(""Can not Delete Data"");</script>")
                End If
            End If
        End If

        Allgv()
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
        ClearService()
        Allgv()
        CheckRole()
        chkdayService()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True)
    End Sub
    Protected Sub btnSerchipService_Click(sender As Object, e As EventArgs) Handles btnSerchipService.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True)
        Dim ip As String = Session("_serverip")
        If ip <> "" Then
            txtServeripService.Text = Session("_serverip")
            txtServerNameService.Text = Session("_servername")
            txtMacAddressService.Text = Session("_macaddress")
        End If
        Allgv()
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

        chkSunService.Checked = False
        chkMonService.Checked = False
        chkTueService.Checked = False
        chkWedService.Checked = False
        chkThuService.Checked = False
        chkFriService.Checked = False
        chkSatService.Checked = False
        chkAllDayService.Checked = False

        txtFromTimeService.Text = ""
        txtToTimeService.Text = ""
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True)
    End Sub
    Protected Sub btnAddService_Click(sender As Object, e As EventArgs) Handles btnAddService.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True)
        GetShowServiec()
        Allgv()
    End Sub
    Protected Sub chkAllDayService_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllDayService.CheckedChanged
        chkdayService()
    End Sub
    Public Sub chkdayService()
        If chkAllDayService.Checked = True Then
            chkSunService.Enabled = False
            chkMonService.Enabled = False
            chkTueService.Enabled = False
            chkWedService.Enabled = False
            chkThuService.Enabled = False
            chkFriService.Enabled = False
            chkSatService.Enabled = False
            txtToTimeService.Enabled = False
            txtFromTimeService.Enabled = False

        Else

            chkSunService.Enabled = True
            chkMonService.Enabled = True
            chkTueService.Enabled = True
            chkWedService.Enabled = True
            chkThuService.Enabled = True
            chkFriService.Enabled = True
            chkSatService.Enabled = True
            txtToTimeService.Enabled = True
            txtFromTimeService.Enabled = True

        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivService", "DivService();", True)
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
        If txtRepeatCheckProcess.Text.Trim() = "" Or txtRepeatCheckProcess.Text = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Repeat check!"");</script>")
            Return False
        End If

        If chkAllDayProcess.Checked = False Then
            Dim ret As Boolean = False
            If chkSunProcess.Checked = True Then
                ret = True
            End If
            If chkMonProcess.Checked = True Then
                ret = True
            End If
            If chkTueProcess.Checked = True Then
                ret = True
            End If
            If chkWedProcess.Checked = True Then
                ret = True
            End If
            If chkThuProcess.Checked = True Then
                ret = True
            End If
            If chkFriProcess.Checked = True Then
                ret = True
            End If
            If chkSatProcess.Checked = True Then
                ret = True
            End If

            If ret = False Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Day !"");</script>")
                Return False
            End If


        End If
        If chkAllDayProcess.Checked = False Then
            If txtFromTimeProcess.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check From Time !"");</script>")
                Return False
            End If

            If txtToTimeProcess.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check To Time !"");</script>")
                Return False
            End If

            Dim FromTime As DateTime = Convert.ToDateTime(txtFromTimeProcess.Text)
            Dim ToTime As DateTime = Convert.ToDateTime(txtToTimeProcess.Text)

            If FromTime > ToTime Then
                Response.Write("<script language=""javaScript"">alert(""Please, Check " & ToTime.ToString("HH:mm") & " more than  " & FromTime.ToString("HH:mm") & " !"");</script>")
                Return False
            End If
        End If



        Dim chk As Boolean = False
        For m As Integer = 0 To gvShowProcess.Rows.Count - 1
            Dim chkProcess As CheckBox = DirectCast(gvShowProcess.Rows(m).FindControl("chkProcess"), CheckBox)
            If chkProcess.Checked = True Then
                chk = True
            End If
        Next

        If chk = False Then
            Response.Write("<script language=""javaScript"">alert(""Please, check Alarm Severity!"");</script>")
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
            If dt.Rows.Count = 0 Then

                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvShowProcess.DataSource = dt
                gvShowProcess.DataBind()
                Dim columnCount As Integer = gvShowProcess.Rows(0).Cells.Count
                gvShowProcess.Rows(0).Cells.Clear()
                gvShowProcess.Rows(0).Cells.Add(New TableCell)
                gvShowProcess.Rows(0).Cells(0).ColumnSpan = columnCount
                gvShowProcess.Rows(0).Cells(0).Text = "No Records Found."
            End If
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
            If dt.Rows.Count = 0 Then
                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvProcess.DataSource = dt
                gvProcess.DataBind()
                Dim columnCount As Integer = gvProcess.Rows(0).Cells.Count
                gvProcess.Rows(0).Cells.Clear()
                gvProcess.Rows(0).Cells.Add(New TableCell)
                gvProcess.Rows(0).Cells(0).ColumnSpan = columnCount
                gvProcess.Rows(0).Cells(0).Text = "No Records Found."
            End If
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
            Allgv()
            Return
        End If
        Dim _ret As Boolean = False
        For i As Integer = 0 To gvShowProcess.Rows.Count - 1

            Dim chkProcess As CheckBox = DirectCast(gvShowProcess.Rows(i).FindControl("chkProcess"), CheckBox)

            If chkProcess.Checked = True Then
                Dim trans As New TransactionDB
                Dim lnq As New CfConfigProcessLinqDB
                Dim Process_checklist_id As String
                Dim CheckIdcfProcess As String

                Dim ID As Label = DirectCast(gvShowProcess.Rows(i).FindControl("lblid"), Label)
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


                If chkAllDayCPU.Checked = True Then
                    lnq.ALLDAYEVENT = GetCheckDay(chkAllDayService)
                Else
                    lnq.ALARMSUN = GetCheckDay(chkSunProcess)
                    lnq.ALARMMON = GetCheckDay(chkMonProcess)
                    lnq.ALARMTUE = GetCheckDay(chkTueProcess)
                    lnq.ALARMWED = GetCheckDay(chkWedProcess)
                    lnq.ALARMTHU = GetCheckDay(chkThuProcess)
                    lnq.ALARMFRI = GetCheckDay(chkFriProcess)
                    lnq.ALARMSAT = GetCheckDay(chkSatProcess)
                    lnq.ALLDAYEVENT = GetCheckDay(chkAllDayProcess)
                    lnq.ALARMTIMEFROM = txtFromTimeProcess.Text
                    lnq.ALARMTIMETO = txtToTimeProcess.Text
                End If

                If chkActiveStatusProcess.Checked = True Then
                    lnq.ACTIVESTATUS = Convert.ToChar("Y")
                Else
                    lnq.ACTIVESTATUS = Convert.ToChar("N")
                End If



                If (lnq.ID > 0) Then
                    _ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)

                Else
                    _ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
                End If

                If _ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()

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

                        End If

                    End If

                End If
            End If

        Next

        If _ret = True Then
            Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")

        Else
            Response.Write("<script language=""javaScript"">alert(""Can not save !"");</script>")
        End If
        Allgv()
        ClearProcess()
        CheckRole()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivProcess", "DivProcess();", True)
    End Sub
    Protected Sub gvProcess_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvProcess.RowCommand

        If e.CommandName = "EditRow" Then
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigProcessLinqDB
            Dim dt As New DataTable

            Dim lblServiceIP As String = e.CommandArgument.ToString

            Dim _id As String = _IdProcess(lblServiceIP.ToString)
            lnq.GetDataByPK(_id, trans.Trans)

            If lnq.ID > 0 Then

                CheckIdcfProcess(lblServiceIP.ToString)

                txtServeripProcess.Text = lnq.SERVERIP
                txtServernameProcess.Text = lnq.SERVERNAME
                txtMacAddressProcess.Text = lnq.MACADDRESS
                'txtRepeatCheckProcess.Text = lnq.REPEATCHECKQTY
                txtIntervalProcess.Text = lnq.CHECKINTERVALMINUTE
                If lnq.ALARMSUN = "Y" Then
                    chkSunProcess.Checked = True
                Else
                    chkSunProcess.Checked = False
                End If

                If lnq.ALARMMON = "Y" Then
                    chkMonProcess.Checked = True
                Else
                    chkMonProcess.Checked = False
                End If

                If lnq.ALARMTUE = "Y" Then
                    chkTueProcess.Checked = True
                Else
                    chkTueProcess.Checked = False
                End If

                If lnq.ALARMWED = "Y" Then
                    chkWedProcess.Checked = True
                Else
                    chkWedProcess.Checked = False
                End If

                If lnq.ALARMTHU = "Y" Then
                    chkThuProcess.Checked = True
                Else
                    chkThuProcess.Checked = False
                End If

                If lnq.ALARMFRI = "Y" Then
                    chkFriProcess.Checked = True
                Else
                    chkFriProcess.Checked = False
                End If

                If lnq.ALARMSAT = "Y" Then
                    chkSatProcess.Checked = True
                Else
                    chkSatProcess.Checked = False
                End If

                If lnq.ALLDAYEVENT = "Y" Then
                    chkAllDayProcess.Checked = True
                Else
                    chkAllDayProcess.Checked = False
                End If
                chkdayProcess()

                txtFromTimeProcess.Text = lnq.ALARMTIMEFROM
                txtToTimeProcess.Text = lnq.ALARMTIMETO

                If lnq.ACTIVESTATUS = "Y" Then
                    chkActiveStatusProcess.Checked = True
                Else
                    chkActiveStatusProcess.Checked = False
                End If

            End If

            btnAddProcess.Enabled = True
            btnSerchipProcess.Enabled = True
            btnSaveProcess.Enabled = True
            btnCancelProcess.Enabled = True

        End If

        If e.CommandName = "DeleteRow" Then

            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then
                Dim ret As Boolean = False
                Dim lblServiceIP As String = e.CommandArgument.ToString
                Dim Peng As New ProcessENG
                Dim dt As New DataTable

                dt = Peng.SetgvProcess("ServerIP = '" & lblServiceIP.ToString & "'")

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim trans As New TransactionDB
                    Dim lnq As New CfConfigProcessLinqDB
                    Dim id As Integer = dt.Rows(i)(0).ToString

                    ret = lnq.DeleteByPK(id, trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()

                    Else
                        trans.RollbackTransaction()

                    End If
                Next
                If ret = True Then

                    Response.Write("<script language=""javaScript"">alert(""Delete data Complete !"");</script>")
                Else

                    Response.Write("<script language=""javaScript"">alert(""Can not Delete Data"");</script>")
                End If
                ClearProcess()
                CheckIdcfProcess(lblServiceIP.ToString)
            End If
        End If

        Allgv()
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
        Allgv()
        CheckRole()
        chkdayProcess()
    End Sub
    Protected Sub btnSerchipProcess_Click(sender As Object, e As EventArgs) Handles btnSerchipProcess.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivProcess", "DivProcess();", True)
        Dim ip As String = Session("_serverip")
        If ip <> "" Then
            txtServeripProcess.Text = Session("_serverip")
            txtServernameProcess.Text = Session("_servername")
            txtMacAddressProcess.Text = Session("_macaddress")
        End If
        Allgv()
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
        chkSunProcess.Checked = False
        chkMonProcess.Checked = False
        chkTueProcess.Checked = False
        chkWedProcess.Checked = False
        chkThuProcess.Checked = False
        chkFriProcess.Checked = False
        chkSatProcess.Checked = False
        chkAllDayProcess.Checked = False

        txtFromTimeProcess.Text = ""
        txtToTimeProcess.Text = ""
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivProcess", "DivProcess();", True)
    End Sub
    Protected Sub btnAddProcess_Click(sender As Object, e As EventArgs) Handles btnAddProcess.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivProcess", "DivProcess();", True)
        GetShowProcess()
        Allgv()
    End Sub
    Protected Sub chkAllDayProcess_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllDayProcess.CheckedChanged
        chkdayProcess()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivProcess", "DivProcess();", True)
    End Sub
    Public Sub chkdayProcess()
        If chkAllDayProcess.Checked = True Then
            chkSunProcess.Enabled = False
            chkMonProcess.Enabled = False
            chkTueProcess.Enabled = False
            chkWedProcess.Enabled = False
            chkThuProcess.Enabled = False
            chkFriProcess.Enabled = False
            chkSatProcess.Enabled = False
            txtFromTimeProcess.Enabled = False
            txtToTimeProcess.Enabled = False

        Else

            chkSunProcess.Enabled = True
            chkMonProcess.Enabled = True
            chkTueProcess.Enabled = True
            chkWedProcess.Enabled = True
            chkThuProcess.Enabled = True
            chkFriProcess.Enabled = True
            chkSatProcess.Enabled = True
            txtToTimeProcess.Enabled = True
            txtFromTimeProcess.Enabled = True

        End If
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

        If gvPathFile.Rows.Count = 0 Then
            Response.Write("<script language=""javaScript"">alert(""Please, Click Submit before !"");</script>")
            Return False
        End If

       



        If chkAllDayFile.Checked = False Then
            Dim ret As Boolean = False
            If chkSunFile.Checked = True Then
                ret = True
            End If
            If chkMonFile.Checked = True Then
                ret = True
            End If
            If chkTueFile.Checked = True Then
                ret = True
            End If
            If chkWedFile.Checked = True Then
                ret = True
            End If
            If chkThuFile.Checked = True Then
                ret = True
            End If
            If chkFriFile.Checked = True Then
                ret = True
            End If
            If chkSatFile.Checked = True Then
                ret = True
            End If

            If ret = False Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Day !"");</script>")
                Return False
            End If


        End If
        If chkAllDayFile.Checked = False Then
            If txtFromTimeFile.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check From Time !"");</script>")
                Return False
            End If

            If txtToTimeFile.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check To Time !"");</script>")
                Return False
            End If

            Dim FromTime As DateTime = Convert.ToDateTime(txtFromTimeFile.Text)
            Dim ToTime As DateTime = Convert.ToDateTime(txtToTimeFile.Text)

            If FromTime > ToTime Then
                Response.Write("<script language=""javaScript"">alert(""Please, Check " & ToTime.ToString("HH:mm") & " more than  " & FromTime.ToString("HH:mm") & " !"");</script>")
                Return False
            End If
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
            If dt.Rows.Count = 0 Then
                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvFileSize.DataSource = dt
                gvFileSize.DataBind()
                Dim columnCount As Integer = gvFileSize.Rows(0).Cells.Count
                gvFileSize.Rows(0).Cells.Clear()
                gvFileSize.Rows(0).Cells.Add(New TableCell)
                gvFileSize.Rows(0).Cells(0).ColumnSpan = columnCount
                gvFileSize.Rows(0).Cells(0).Text = "No Records Found."
            End If
        End If

    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click

        If txtPathFile.Text = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please,Browse file !"");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
            Return
        End If
        If txtMinorFile.Text = "" Or txtMinorFile.Text = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Minor !"");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
            Return
        End If
        If txtRepeatMinorFile.Text = "" Then
            Response.Write("<script language=""javaScript"">alert(""Check Repeat Minor Null"");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
            Return
        End If
        If txtMajorFile.Text = "" Or txtMajorFile.Text = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Major !"");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
            Return
        End If
        If txtRepeatMajorFile.Text = "" Then
            Response.Write("<script language=""javaScript"">alert(""Check Repeat Major Null"");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
            Return
        End If
        If txtCriticalFile.Text = "" Or txtCriticalFile.Text = "0" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Critical !"");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
            Return
        End If
        If txtRepeatCriticalFile.Text = "" Then
            Response.Write("<script language=""javaScript"">alert(""Check Repeat Critical Null"");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
            Return
        End If
        Dim chk As Boolean = False
        If Convert.ToInt32(txtCriticalFile.Text) > Convert.ToInt32(txtMajorFile.Text) Then
            If Convert.ToInt32(txtMajorFile.Text) > Convert.ToInt32(txtMinorFile.Text) Then
                chk = True
            Else
                chk = False
            End If
        Else
            chk = False
        End If

        If chk = False Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Severity!"");</script>")
            txtMinorFile.Text = ""
            txtMajorFile.Text = ""
            txtCriticalFile.Text = ""
            Return

        End If

        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Long))
        dt.Columns.Add("PathFile", GetType(String))
        dt.Columns.Add("FileSizeMinor", GetType(String))
        dt.Columns.Add("RepeatMinor", GetType(String))
        dt.Columns.Add("FileSizeMajor", GetType(String))
        dt.Columns.Add("RepeatMajor", GetType(String))
        dt.Columns.Add("FileSizeCritical", GetType(String))
        dt.Columns.Add("RepeatCritical", GetType(String))
        If gvPathFile.Rows.Count > 0 Then

            For i As Integer = 0 To gvPathFile.Rows.Count - 1

                Dim id As Label = CType(gvPathFile.Rows(i).FindControl("lblid"), Label)
                Dim PathFile As Label = CType(gvPathFile.Rows(i).FindControl("lblPathFile"), Label)
                Dim FileSizeMinor As Label = CType(gvPathFile.Rows(i).FindControl("lblMinor"), Label)
                Dim RepeatMinor As Label = CType(gvPathFile.Rows(i).FindControl("lblRepeatMinor"), Label)
                Dim FileSizeMajor As Label = CType(gvPathFile.Rows(i).FindControl("lblMajor"), Label)
                Dim RepeatMajor As Label = CType(gvPathFile.Rows(i).FindControl("lblRepeatMajor"), Label)
                Dim FileSizeCritical As Label = CType(gvPathFile.Rows(i).FindControl("lblCritical"), Label)
                Dim RepeatCritical As Label = CType(gvPathFile.Rows(i).FindControl("lblRepeatCritical"), Label)

                If PathFile.Text.Trim() <> txtPathFile.Text.Trim() Then
                    Dim _dr As DataRow
                    _dr = dt.NewRow
                    _dr("id") = id.Text
                    _dr("PathFile") = PathFile.Text
                    _dr("FileSizeMinor") = FileSizeMinor.Text
                    _dr("RepeatMinor") = RepeatMinor.Text
                    _dr("FileSizeMajor") = FileSizeMajor.Text
                    _dr("RepeatMajor") = RepeatMajor.Text
                    _dr("FileSizeCritical") = FileSizeCritical.Text
                    _dr("RepeatCritical") = RepeatCritical.Text
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
        dr("RepeatMinor") = txtRepeatMinorFile.Text
        dr("FileSizeMajor") = txtMajorFile.Text
        dr("RepeatMajor") = txtRepeatMajorFile.Text
        dr("FileSizeCritical") = txtCriticalFile.Text
        dr("RepeatCritical") = txtRepeatCriticalFile.Text
        dt.Rows.Add(dr)

        gvPathFile.DataSource = dt
        gvPathFile.DataBind()
     

        lblidPathFile.Text = "0"
        txtPathFile.Text = ""
        txtMinorFile.Text = ""
        txtRepeatMinorFile.Text = ""
        txtMajorFile.Text = ""
        txtRepeatMajorFile.Text = ""
        txtCriticalFile.Text = ""
        txtRepeatCriticalFile.Text = ""

        If gvPathFile.Rows.Count > 0 Then
            lblnoPathFile.Visible = False

        Else
            lblnoPathFile.Visible = True
        End If
      
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)

    End Sub

    Protected Sub btnSaveFile_Click(sender As Object, e As EventArgs) Handles btnSaveFile.Click

        If ValidateFileSize() = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
            Allgv()
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

        lnq.CHECKINTERVALMINUTE = txtIntervelFile.Text

        If chkAllDayCPU.Checked = True Then
            lnq.ALLDAYEVENT = GetCheckDay(chkAllDayFile)
        Else
            lnq.ALARMSUN = GetCheckDay(chkSunFile)
            lnq.ALARMMON = GetCheckDay(chkMonFile)
            lnq.ALARMTUE = GetCheckDay(chkTueFile)
            lnq.ALARMWED = GetCheckDay(chkWedFile)
            lnq.ALARMTHU = GetCheckDay(chkThuFile)
            lnq.ALARMFRI = GetCheckDay(chkFriFile)
            lnq.ALARMSAT = GetCheckDay(chkSatFile)
            lnq.ALLDAYEVENT = GetCheckDay(chkAllDayFile)
            lnq.ALARMTIMEFROM = txtFromTimeFile.Text
            lnq.ALARMTIMETO = txtToTimeFile.Text
        End If


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
                SaveDetailFileSize(checkIDcfFile)
            End If


            Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")
        Else
            trans.RollbackTransaction()
            Response.Write("<script language=""javaScript"">alert(""Can not save !"");</script>")
        End If


        lnq = Nothing

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
        SetgvFileSize()
        ClearFileSize()
        Allgv()
        CheckRole()
    End Sub

    'Public Sub SaveDetailFileSize(ByVal idFileSize As String)


    '    For i As Integer = 0 To gvPathFile.Rows.Count - 1
    '        Dim lnq As New CfConfigFilesizeDetailLinqDB
    '        Dim trans As New TransactionDB


    '        Dim PathFile As Label = CType(gvPathFile.Rows(i).FindControl("lblPathFile"), Label)
    '        Dim FileSizeMinor As Label = CType(gvPathFile.Rows(i).FindControl("lblMinor"), Label)
    '        Dim FileSizeMajor As Label = CType(gvPathFile.Rows(i).FindControl("lblMajor"), Label)
    '        Dim FileSizeCritical As Label = CType(gvPathFile.Rows(i).FindControl("lblCritical"), Label)

    '        lnq.FILENAME = PathFile.Text
    '        lnq.CF_CONFIG_FILESIZE_ID = idFileSize
    '        lnq.FILESIZEMINOR = FileSizeMinor.Text
    '        lnq.FILESIZEMAJOR = FileSizeMajor.Text
    '        lnq.FILESIZECRITICAL = FileSizeCritical.Text


    '        Dim ret As Boolean = False

    '        ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
    '        If ret = True Then
    '            trans.CommitTransaction()
    '        Else
    '            trans.RollbackTransaction()
    '        End If

    '        lnq = Nothing
    '    Next



    'End Sub

    Public Sub SaveDetailFileSize(ByVal _cfidFile As String)

        For i As Integer = 0 To gvPathFile.Rows.Count - 1
            Dim lnq As New CfConfigFilesizeDetailLinqDB
            Dim trans As New TransactionDB

            Dim id As Label = CType(gvPathFile.Rows(i).FindControl("lblid"), Label)
            Dim Path As Label = CType(gvPathFile.Rows(i).FindControl("lblPathFile"), Label)
            Dim Minor As Label = CType(gvPathFile.Rows(i).FindControl("lblMinor"), Label)
            Dim RepeatMinor As Label = CType(gvPathFile.Rows(i).FindControl("lblRepeatMinor"), Label)
            Dim Major As Label = CType(gvPathFile.Rows(i).FindControl("lblMajor"), Label)
            Dim RepeatMajor As Label = CType(gvPathFile.Rows(i).FindControl("lblRepeatMajor"), Label)
            Dim Critical As Label = CType(gvPathFile.Rows(i).FindControl("lblCritical"), Label)
            Dim RepeatCritical As Label = CType(gvPathFile.Rows(i).FindControl("lblRepeatCritical"), Label)
            If Convert.ToInt64(id.Text > 0) Then
                lnq.GetDataByPK(Convert.ToInt64(id.Text), trans.Trans)
            End If

            lnq.FILENAME = Path.Text
            lnq.CF_CONFIG_FILESIZE_ID = _cfidFile
            lnq.FILESIZEMINOR = Minor.Text
            lnq.REPEATCHECKMINOR = RepeatMinor.Text
            lnq.FILESIZEMAJOR = Major.Text
            lnq.REPEATCHECKMAJOR = RepeatMajor.Text
            lnq.FILESIZECRITICAL = Critical.Text
            lnq.REPEATCHECKCRITICAL = RepeatCritical.Text
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
            'Dim lblID As Label

            Dim Feng As New FileSizeENG

            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            'lblID = CType(gvFileSize.Rows(RowIndex).FindControl("lblcfDETAILid"), Label)
            lnq.GetDataByPK(RowIndex, trans.Trans)

            If lnq.ID > 0 Then
                Dim idFileSize As String = lnq.ID


                lblTempID.Text = lnq.ID
                txtServeripFile.Text = lnq.SERVERIP
                txtServerNameFile.Text = lnq.SERVERNAME
                txtMacAddressFile.Text = lnq.MACADDRESS
                txtIntervelFile.Text = lnq.CHECKINTERVALMINUTE
                EditFileSize(idFileSize)
                Session("_serverip") = lnq.SERVERIP
                If lnq.ALARMSUN = "Y" Then
                    chkSunFile.Checked = True
                Else
                    chkSunFile.Checked = False
                End If

                If lnq.ALARMMON = "Y" Then
                    chkMonFile.Checked = True
                Else
                    chkMonFile.Checked = False
                End If

                If lnq.ALARMTUE = "Y" Then
                    chkTueFile.Checked = True
                Else
                    chkTueFile.Checked = False
                End If

                If lnq.ALARMWED = "Y" Then
                    chkWedFile.Checked = True
                Else
                    chkWedFile.Checked = False
                End If

                If lnq.ALARMTHU = "Y" Then
                    chkThuFile.Checked = True
                Else
                    chkThuFile.Checked = False
                End If

                If lnq.ALARMFRI = "Y" Then
                    chkFriFile.Checked = True
                Else
                    chkFriFile.Checked = False
                End If

                If lnq.ALARMSAT = "Y" Then
                    chkSatFile.Checked = True
                Else
                    chkSatFile.Checked = False
                End If

                If lnq.ALLDAYEVENT = "Y" Then
                    chkAllDayFile.Checked = True
                Else
                    chkAllDayFile.Checked = False
                End If
                chkdayFile()

                txtFromTimeFile.Text = lnq.ALARMTIMEFROM
                txtToTimeFile.Text = lnq.ALARMTIMETO


                If lnq.ACTIVESTATUS = "Y" Then
                    chkActiveStatusFile.Checked = True
                Else
                    chkActiveStatusFile.Checked = False
                End If


            End If

            btnBrownparthfile.Enabled = True
            btnConfirm.Enabled = True
            btnSerchipFileSize.Enabled = True
            btnSaveFile.Enabled = True
            btnCancalFile.Enabled = True

        End If


        If e.CommandName = "DeleteRow" Then

            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then

                Dim trans As New TransactionDB
                Dim lnq As New CfConfigFilesizeLinqDB
                Dim ret As Boolean = False

                'Dim lblID As Label

                Dim RowIndex As Integer
                Integer.TryParse(e.CommandArgument.ToString, RowIndex)

                'lblID = CType(gvFileSize.Rows(RowIndex).FindControl("lblcfDETAILid"), Label)
                DelidcfFileDetail(RowIndex)
                ret = lnq.DeleteByPK(RowIndex, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Delete data Complete !"");</script>")
                Else
                    trans.RollbackTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Can not Delete data  !"");</script>")
                End If


                ClearFileSize()
            End If
        End If

        Allgv()
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
            _dt.Columns.Add("RepeatMinor", GetType(String))
            _dt.Columns.Add("FileSizeMajor", GetType(String))
            _dt.Columns.Add("RepeatMajor", GetType(String))
            _dt.Columns.Add("FileSizeCritical", GetType(String))
            _dt.Columns.Add("RepeatCritical", GetType(String))
            For i As Integer = 0 To dt.Rows.Count - 1

                Dim _dr As DataRow
                _dr = _dt.NewRow
                _dr("id") = dt.Rows(i)("id").ToString()
                _dr("PathFile") = dt.Rows(i)("FileName").ToString()
                _dr("FileSizeMinor") = dt.Rows(i)("FileSizeMinor").ToString()
                _dr("RepeatMinor") = dt.Rows(i)("RepeatCheckMinor").ToString()
                _dr("FileSizeMajor") = dt.Rows(i)("FileSizeMajor").ToString()
                _dr("RepeatMajor") = dt.Rows(i)("RepeatCheckMajor").ToString()
                _dr("FileSizeCritical") = dt.Rows(i)("FileSizeCritical").ToString()
                _dr("RepeatCritical") = dt.Rows(i)("RepeatCheckCritical").ToString()
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
        txtMinorFile.Text = ""
        txtRepeatMajorFile.Text = ""
        txtMajorFile.Text = ""
        txtRepeatMajorFile.Text = ""
        txtCriticalFile.Text = ""
        txtRepeatCriticalFile.Text = ""
        txtPathFile.Text = ""
        lblidPathFile.Text = "0"
        lblTempID.Text = "0"

        chkSunFile.Checked = False
        chkMonFile.Checked = False
        chkTueFile.Checked = False
        chkWedFile.Checked = False
        chkThuFile.Checked = False
        chkFriFile.Checked = False
        chkSatFile.Checked = False
        chkAllDayFile.Checked = False
        chkdayFile()
        txtFromTimeFile.Text = ""
        txtToTimeFile.Text = ""

        Dim dt As New DataTable()
        gvPathFile.DataSource = dt
        gvPathFile.DataBind()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
        Globals.Serverip = ""
        SetgvFileSize()
    End Sub
    Protected Sub btnCancalFile_Click(sender As Object, e As EventArgs) Handles btnCancalFile.Click
        ClearFileSize()
        CheckRole()
        Allgv()
    End Sub
    Protected Sub btnBrownparthfile_Click(sender As Object, e As EventArgs) Handles btnBrownparthfile.Click


        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
        txtPathFile.Text = Session("PathFile")
        Allgv()
    End Sub
    Protected Sub gvPathFile_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvPathFile.RowCommand
        If e.CommandName = "EditRow" Then
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)

            Dim id As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblid"), Label)
            Dim Path As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblPathFile"), Label)
            Dim Minor As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblMinor"), Label)
            Dim RepeatMinor As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblMinor"), Label)
            Dim Major As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblMajor"), Label)
            Dim RepeatMajor As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblMinor"), Label)
            Dim Critical As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblCritical"), Label)
            Dim RepeatCritical As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblMinor"), Label)
            Dim pa As String = Path.Text
            txtPathFile.Text = Path.Text
            txtMinorFile.Text = Minor.Text
            txtRepeatMinorFile.Text = RepeatMinor.Text
            txtMajorFile.Text = Major.Text
            txtRepeatMajorFile.Text = RepeatMajor.Text
            txtCriticalFile.Text = Critical.Text
            txtRepeatCriticalFile.Text = RepeatCritical.Text
            lblidPathFile.Text = id.Text
            If gvPathFile.Rows.Count > 0 Then
                lblnoPathFile.Visible = False

            Else
                lblnoPathFile.Visible = True
            End If
        End If


        If e.CommandName = "DeleteRow" Then
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            Dim DeletID As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblid"), Label)
            Dim DeletePathFile As Label = CType(gvPathFile.Rows(RowIndex).FindControl("lblPathFile"), Label)

            If DeletID.Text <> "0" Then
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
            End If


            Dim dt As New DataTable
            dt.Columns.Add("id", GetType(Long))
            dt.Columns.Add("PathFile", GetType(String))
            dt.Columns.Add("FileSizeMinor", GetType(String))
            dt.Columns.Add("RepeatMinor", GetType(String))
            dt.Columns.Add("FileSizeMajor", GetType(String))
            dt.Columns.Add("RepeatMajor", GetType(String))
            dt.Columns.Add("FileSizeCritical", GetType(String))
            dt.Columns.Add("RepeatCritical", GetType(String))

            For i As Integer = 0 To gvPathFile.Rows.Count - 1

                Dim path As Label = CType(gvPathFile.Rows(i).FindControl("lblPathFile"), Label)
                Dim id As Label = CType(gvPathFile.Rows(i).FindControl("lblid"), Label)
                Dim Minor As Label = CType(gvPathFile.Rows(i).FindControl("lblMinor"), Label)
                Dim RepeatMinor As Label = CType(gvPathFile.Rows(i).FindControl("lblRepeatMinor"), Label)
                Dim Major As Label = CType(gvPathFile.Rows(i).FindControl("lblMajor"), Label)
                Dim RepeatMajor As Label = CType(gvPathFile.Rows(i).FindControl("lblRepeatMajor"), Label)
                Dim Critical As Label = CType(gvPathFile.Rows(i).FindControl("lblCritical"), Label)
                Dim RepeatCritical As Label = CType(gvPathFile.Rows(i).FindControl("lblRepeatCritical"), Label)

                If DeletePathFile.Text.Trim() <> path.Text.Trim() Then
                    Dim dr As DataRow
                    dr = dt.NewRow
                    dr("id") = id.Text
                    dr("PathFile") = path.Text
                    dr("FileSizeMinor") = Minor.Text
                    dr("RepeatMinor") = RepeatMinor.Text
                    dr("FileSizeMajor") = Major.Text
                    dr("RepeatMajor") = RepeatMajor.Text
                    dr("FileSizeCritical") = Critical.Text
                    dr("RepeatCritical") = RepeatCritical.Text
                    dt.Rows.Add(dr)
                End If

            Next
            gvPathFile.DataSource = dt
            gvPathFile.DataBind()
            If gvPathFile.Rows.Count > 0 Then
                lblnoPathFile.Visible = False

            Else
                lblnoPathFile.Visible = True
            End If
        End If
        Allgv()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
    End Sub

    Protected Sub btnSerchipFileSize_Click(sender As Object, e As EventArgs) Handles btnSerchipFileSize.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
        Dim ip As String = Session("_serverip")
        If ip <> "" Then
            txtServeripFile.Text = Session("_serverip")
            txtServerNameFile.Text = Session("_servername")
            txtMacAddressFile.Text = Session("_macaddress")
        End If
        Allgv()
    End Sub
    Protected Sub chkAllDayFile_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllDayFile.CheckedChanged
        chkdayFile()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivFileSize", "DivFileSize();", True)
    End Sub
    Public Sub chkdayFile()
        If chkAllDayFile.Checked = True Then
            chkSunFile.Enabled = False
            chkMonFile.Enabled = False
            chkTueFile.Enabled = False
            chkWedFile.Enabled = False
            chkThuFile.Enabled = False
            chkFriFile.Enabled = False
            chkSatFile.Enabled = False
            txtToTimeFile.Enabled = False
            txtFromTimeFile.Enabled = False

        Else

            chkSunFile.Enabled = True
            chkMonFile.Enabled = True
            chkTueFile.Enabled = True
            chkWedFile.Enabled = True
            chkThuFile.Enabled = True
            chkFriFile.Enabled = True
            chkSatFile.Enabled = True
            txtToTimeFile.Enabled = True
            txtFromTimeFile.Enabled = True

        End If
    End Sub
    '---------------------------------------------------------------------------FileSize






    '---------------------------------------------------------------------------Port

    Private Function ValidatePort() As Boolean


        If txtServerNamePort.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server Name !"");</script>")
            Return False
        End If
        If txtServeripPort.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Server IP !"");</script>")
            Return False
        End If
        If txtPort.Text.Trim() = "" Then
            Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Port !"");</script>")
            Return False
        End If
        If chkAllDayEvent.Checked = False Then
            Dim ret As Boolean = False
            If chkSun.Checked = True Then
                ret = True
            End If
            If chkMon.Checked = True Then
                ret = True
            End If
            If chkTue.Checked = True Then
                ret = True
            End If
            If chkWed.Checked = True Then
                ret = True
            End If
            If chkThu.Checked = True Then
                ret = True
            End If
            If chkFri.Checked = True Then
                ret = True
            End If
            If chkSat.Checked = True Then
                ret = True
            End If

            If ret = False Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check Day !"");</script>")
                Return False
            End If


        End If
        If chkAllDayEvent.Checked = False Then
            If txtFromtime.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check From Time !"");</script>")
                Return False
            End If

            If txtToTime.Text = "" Then
                Response.Write("<script language=""javaScript"">alert(""Please, Specify Check To Time !"");</script>")
                Return False
            End If

            Dim FromTime As DateTime = Convert.ToDateTime(txtFromtime.Text)
            Dim ToTime As DateTime = Convert.ToDateTime(txtToTime.Text)

            If FromTime > ToTime Then
                Response.Write("<script language=""javaScript"">alert(""Please, Check " & ToTime.ToString("HH:mm") & " more than  " & FromTime.ToString("HH:mm") & " !"");</script>")
                Return False
            End If
        End If

        '55
        'Dim Peng As New PortEng
        'If Peng.CheckDuplicateRegister(Convert.ToInt64(lblidPort.Text), txtPort.Text.Trim()) = True Then
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
            If dt.Rows.Count = 0 Then
                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvCfPortList.DataSource = dt
                gvCfPortList.DataBind()
                Dim columnCount As Integer = gvCfPortList.Rows(0).Cells.Count
                gvCfPortList.Rows(0).Cells.Clear()
                gvCfPortList.Rows(0).Cells.Add(New TableCell)
                gvCfPortList.Rows(0).Cells(0).ColumnSpan = columnCount
                gvCfPortList.Rows(0).Cells(0).Text = "No Records Found."
            End If
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
        lblidPort.Text = "0"
        txtFromtime.Text = ""
        txtToTime.Text = ""
        GetgvCfPortList()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivPort", "DivPort();", True)
    End Sub
    Protected Sub btnSavePort_Click(sender As Object, e As EventArgs) Handles btnSavePort.Click

        If ValidatePort() = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivPort", "DivPort();", True)
            Allgv()
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

        lnq.HOSTIP = txtServeripPort.Text
        lnq.HOSTNAME = txtServerNamePort.Text
        'lnq.PORTNUMBER = txtPort.Text

        If chkAllDayEvent.Checked = True Then
            lnq.ALLDAYEVENT = GetCheckDay(chkAllDayEvent)
        Else
            lnq.ALARMSUN = GetCheckBox(chkSun)
            lnq.ALARMMON = GetCheckDay(chkMon)
            lnq.ALARMTUE = GetCheckDay(chkTue)
            lnq.ALARMWED = GetCheckDay(chkWed)
            lnq.ALARMTHU = GetCheckDay(chkThu)
            lnq.ALARMFRI = GetCheckDay(chkFri)
            lnq.ALARMSAT = GetCheckDay(chkSat)
            lnq.ALLDAYEVENT = GetCheckDay(chkAllDayEvent)
            lnq.ALARMTIMEFROM = txtFromtime.Text
            lnq.ALARMTIMETO = txtToTime.Text
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
            Response.Write("<script language=""javaScript"">alert(""Can not save !"");</script>")

        End If

        lnq = Nothing
        'If (lnq.ID > 0) Then
        '    If Peng.EditConfigPort(txtServerNamePort.Text, txtServeripPort.Text, txtPort.Text, GetCheckBox(chkSun), GetCheckBox(chkMon), GetCheckBox(chkTue), GetCheckBox(chkWed), GetCheckBox(chkThu), GetCheckBox(chkFri), GetCheckBox(chkSat), GetCheckBox(chkAllDayEvent), txtFromtime.Text, txtToTime.Text, lnq.ID) = True Then
        '        Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")
        '    Else
        '        Response.Write("<script language=""javaScript"">alert(""Can not save !"");</script>")
        '    End If

        'Else
        '    If Peng.AddConfigPort(txtServerNamePort.Text, txtServeripPort.Text, txtPort.Text, GetCheckBox(chkSun), GetCheckBox(chkMon), GetCheckBox(chkTue), GetCheckBox(chkWed), GetCheckBox(chkThu), GetCheckBox(chkFri), GetCheckBox(chkSat), GetCheckBox(chkAllDayEvent), txtFromtime.Text, txtToTime.Text) = True Then
        '        Response.Write("<script language=""javaScript"">alert(""Save data Complete !"");</script>")
        '    Else
        '        Response.Write("<script language=""javaScript"">alert(""Can not save!"");</script>")
        '    End If
        'End If

        Allgv()
        ClearPort()
        CheckRole()
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
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigPortLinqDB
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivPort", "DivPort();", True)
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lnq.GetDataByPK(RowIndex, trans.Trans)

            If lnq.ID > 0 Then

                'Dim id As Label = CType(gvCfPortList.Rows(RowIndex).FindControl("lblid"), Label)
                'Dim Servername As Label = CType(gvCfPortList.Rows(RowIndex).FindControl("lblServername"), Label)
                'Dim Serverip As Label = CType(gvCfPortList.Rows(RowIndex).FindControl("lblServerip"), Label)
                'Dim Port As Label = CType(gvCfPortList.Rows(RowIndex).FindControl("lblPort"), Label)

                Dim Peng As New PortEng
                Dim dt As New DataTable

                dt = Peng.SetgvCfPortList("CP.id = '" & RowIndex & "'")
                chkDay(dt)
                chkDay()
                txtServerNamePort.Text = lnq.HOSTNAME
                txtServeripPort.Text = lnq.HOSTIP
                'txtPort.Text = lnq.PORTNUMBER
                lblidPort.Text = RowIndex

            End If

            btnSerchipPort.Enabled = True
            btnSavePort.Enabled = True
            btnCancelPort.Enabled = True

        End If

        If e.CommandName = "DeleteRow" Then

            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then

                Dim RowIndex As Integer
                Integer.TryParse(e.CommandArgument.ToString, RowIndex)

                'Dim id As Label = CType(gvCfPortList.Rows(RowIndex).FindControl("lblid"), Label)
                Dim trans As New TransactionDB
                Dim ret As Boolean = False
                Dim lnq As New CfConfigPortLinqDB
                ret = lnq.DeleteByPK(RowIndex, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Delete data Complete !"");</script>")
                Else
                    trans.RollbackTransaction()
                    Response.Write("<script language=""javaScript"">alert(""Can not Delete data !"");</script>")
                End If
                lnq = Nothing

                ClearPort()

            End If
        End If
        Allgv()
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
    Public Sub chkday()
        If chkAllDayEvent.Checked = True Then
            chkSun.Enabled = False
            chkMon.Enabled = False
            chkTue.Enabled = False
            chkWed.Enabled = False
            chkThu.Enabled = False
            chkFri.Enabled = False
            chkSat.Enabled = False
            txtToTime.Enabled = False
            txtFromtime.Enabled = False

        Else

            chkSun.Enabled = True
            chkMon.Enabled = True
            chkTue.Enabled = True
            chkWed.Enabled = True
            chkThu.Enabled = True
            chkFri.Enabled = True
            chkSat.Enabled = True
            txtToTime.Enabled = True
            txtFromtime.Enabled = True

        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivPort", "DivPort();", True)
    End Sub
    Protected Sub chkAllDayEvent_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllDayEvent.CheckedChanged

        chkDay()
    End Sub
    Protected Sub btnCancelPort_Click(sender As Object, e As EventArgs) Handles btnCancelPort.Click
        ClearPort()
        CheckRole()
        Allgv()
        chkDay()
    End Sub
    Protected Sub btnSerchipPort_Click(sender As Object, e As EventArgs) Handles btnSerchipPort.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DivPort", "DivPort();", True)
        Dim ip As String = Session("_serverip")
        If ip <> "" Then
            txtServeripPort.Text = Session("_serverip")
            txtServerNamePort.Text = Session("_servername")
        End If
        Allgv()
    End Sub

End Class

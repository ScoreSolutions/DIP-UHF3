Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Script.Services
Partial Class frmRegisterForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            ClearRegister()
            ClearCPU()
            ClearRam()
            ClearService()
            ClearProcess()
            ClearDrive()
            ClearFileSize()
            ClearPort()

            SetService()
            SetProcess()

            If Not Request.QueryString("ID") Is Nothing AndAlso Request.QueryString("ID").ToString <> "" Then
                LoadRegister(Request.QueryString("ID"))
            End If
        End If

        If Session("SaveServer") = True Then  ' ค่า Session นี้ มาจากปุ่ม Add Server ใน Tab Group ถ้าค่านี้ถูก บันทึก Session จะ เท่ากับ true
            Session.Remove("SaveServer")
        End If

        If Session("PathFile") <> "" Then
            txtFilePath.Text = Session("PathFile")
        End If

        SetValidTextNumber()
        btnAddPathFileSize.Attributes.Add("onclick", "return showModal('frmAddPathFile.aspx?serverip=' + document.getElementById('" & txtServerIP.ClientID & "').value + '&macaddress='+ document.getElementById('" & txtMacAddress.ClientID & "').value,600,400,0);")
    End Sub

    Sub SetValidTextNumber()
        txtRepeatCheck.Attributes.Add("OnKeyPress", "ChkMinusInt(this,event);")
        txtRepeatCheck.Attributes.Add("onKeyDown", "CheckKeyNumber(event);")

        txtPortNo.Attributes.Add("OnKeyPress", "ChkMinusInt(this,event);")
        txtPortNo.Attributes.Add("onKeyDown", "CheckKeyNumber(event);")
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("frmRegister.aspx")
    End Sub

    Function Save() As String
        Dim strRet As String = ""
        Dim trans As New TransactionDB
        Try

            Dim ret As Boolean = False
            '## Register
            Dim lnq As New TbRegisterLinqDB
            With lnq
                .GetDataByPK(Convert.ToInt64(txtIDRegister.Text), trans.Trans)
                .SERVERIP = txtServerIP.Text
                .SERVERNAME = txtServerName.Text
                .OS = txtOS.Text
                .SYSTEM_TYPE = txtSystem.Text
                .FNAME = txtFnameR.Text
                .LNAME = txtLnameR.Text
                .E_MAIL = txtEmail.Text
                .MACADDRESS = txtMacAddress.Text
                .GROUP_ID = 0
                .LOCATIONSERVER = txtLacServer.Text
                .LOCATIONNO = txtLacNumber.Text
                .ACTIVE_STATUS = IIf(chkActiveStatusR.Checked = True, "Y", "N")

                If .ID > 0 Then
                    ret = .UpdateByPK(Globals.uData.USERNAME, trans.Trans)
                Else
                    ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                End If
            End With

            If ret = False Then
                trans.RollbackTransaction()
                strRet = lnq.ErrorMessage
                Return strRet
            End If
            lnq = Nothing
            '##########

            '## CPU
            Dim lnqcpu As New CfConfigCpuLinqDB
            With lnqcpu
                .GetDataByPK(Convert.ToInt64(txtIDCPU.Text), trans.Trans)
                .SERVERIP = txtServerIP.Text
                .SERVERNAME = txtServerName.Text
                .MACADDRESS = txtMacAddress.Text
                .CHECKINTERVALMINUTE = ctlCPUConfig.IntervalMinute
                .ALLDAYEVENT = ctlCPUConfig.AllDayEvent
                .ALARMSUN = ctlCPUConfig.CheckSun
                .ALARMMON = ctlCPUConfig.CheckMon
                .ALARMTUE = ctlCPUConfig.CheckTue
                .ALARMWED = ctlCPUConfig.CheckWed
                .ALARMTHU = ctlCPUConfig.CheckThu
                .ALARMFRI = ctlCPUConfig.CheckFri
                .ALARMSAT = ctlCPUConfig.CheckSat
                .ALARMTIMEFROM = ctlCPUConfig.TimeFrom
                .ALARMTIMETO = ctlCPUConfig.TimeTo
                .LASTCHECKTIME = Today.Date

                .ALARMMINORVALUE = ctlCPUSeverity.MinorValue
                .REPEATCHECKMINOR = ctlCPUSeverity.RepeatMinor

                .ALARMMAJORVALUE = ctlCPUSeverity.MajorValue
                .REPEATCHECKMAJOR = ctlCPUSeverity.RepeatMajor

                .ALARMCRITICALVALUE = ctlCPUSeverity.CriticalValue
                .REPEATCHECKCRITICAL = ctlCPUSeverity.RepeatCritical
                .ACTIVESTATUS = ctlCPUConfig.ActiveStatus

                If .ID > 0 Then
                    ret = .UpdateByPK(Globals.uData.USERNAME, trans.Trans)
                Else
                    ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                End If
            End With
            If ret = False Then
                trans.RollbackTransaction()
                strRet = lnqcpu.ErrorMessage
                Return strRet
            End If
            lnqcpu = Nothing
            '##########

            '## Ram
            Dim lnqram As New CfConfigRamLinqDB
            With lnqram
                .GetDataByPK(Convert.ToInt64(txtIDRAM.Text), trans.Trans)
                .SERVERIP = txtServerIP.Text
                .SERVERNAME = txtServerName.Text
                .MACADDRESS = txtMacAddress.Text
                .CHECKINTERVALMINUTE = ctlRamConfig.IntervalMinute
                .ALLDAYEVENT = ctlRamConfig.AllDayEvent
                .ALARMSUN = ctlRamConfig.CheckSun
                .ALARMMON = ctlRamConfig.CheckMon
                .ALARMTUE = ctlRamConfig.CheckTue
                .ALARMWED = ctlRamConfig.CheckWed
                .ALARMTHU = ctlRamConfig.CheckThu
                .ALARMFRI = ctlRamConfig.CheckFri
                .ALARMSAT = ctlRamConfig.CheckSat
                .ALARMTIMEFROM = ctlRamConfig.TimeFrom
                .ALARMTIMETO = ctlRamConfig.TimeTo
                .LASTCHECKTIME = Today.Date

                .ALARMMINORVALUE = ctlRamSeverity.MinorValue
                .REPEATCHECKMINOR = ctlRamSeverity.RepeatMinor

                .ALARMMAJORVALUE = ctlRamSeverity.MajorValue
                .REPEATCHECKMAJOR = ctlRamSeverity.RepeatMajor

                .ALARMCRITICALVALUE = ctlRamSeverity.CriticalValue
                .REPEATCHECKCRITICAL = ctlRamSeverity.RepeatCritical
                .ACTIVESTATUS = ctlRamConfig.ActiveStatus
                If .ID > 0 Then
                    ret = .UpdateByPK(Globals.uData.USERNAME, trans.Trans)
                Else
                    ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                End If
            End With
            If ret = False Then
                trans.RollbackTransaction()
                strRet = lnqram.ErrorMessage
                Return strRet
            End If
            lnqram = Nothing
            '##########

            '## Drive 
            Dim lnqdrive As New CfConfigDriveLinqDB
            With lnqdrive
                .GetDataByPK(Convert.ToInt64(txtIDDrive.Text), trans.Trans)
                .SERVERIP = txtServerIP.Text
                .SERVERNAME = txtServerName.Text
                .MACADDRESS = txtMacAddress.Text
                .CHECKINTERVALMINUTE = ctlDriveConfig.IntervalMinute
                .ALLDAYEVENT = ctlDriveConfig.AllDayEvent
                .ALARMSUN = ctlDriveConfig.CheckSun
                .ALARMMON = ctlDriveConfig.CheckMon
                .ALARMTUE = ctlDriveConfig.CheckTue
                .ALARMWED = ctlDriveConfig.CheckWed
                .ALARMTHU = ctlDriveConfig.CheckThu
                .ALARMFRI = ctlDriveConfig.CheckFri
                .ALARMSAT = ctlDriveConfig.CheckSat
                .ALARMTIMEFROM = ctlDriveConfig.TimeFrom
                .ALARMTIMETO = ctlDriveConfig.TimeTo
                .LASTCHECKTIME = Today.Date
                .ACTIVESTATUS = ctlDriveConfig.ActiveStatus
                If .ID > 0 Then
                    ret = .UpdateByPK(Globals.uData.USERNAME, trans.Trans)
                Else
                    ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                End If
            End With
            If ret = False Then
                trans.RollbackTransaction()
                strRet = lnqdrive.ErrorMessage
                Return strRet
            End If

            Dim sql As String = "delete from CF_CONFIG_DRIVE_DETAIL where cf_config_drive_id ='" & lnqdrive.ID & "'"
            SqlDB.ExecuteNonQuery(sql, trans.Trans)

            If gvDriveDetail.Rows.Count > 0 Then
                For i As Integer = 0 To gvDriveDetail.Rows.Count - 1
                    Dim lblDriveLetter As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblDriveLetter"), Label)
                    Dim lblMinorValue As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblMinorValue"), Label)
                    Dim lblMinorRepeatCheck As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblMinorRepeatCheck"), Label)
                    Dim lblMajorValue As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblMajorValue"), Label)
                    Dim lblMajorRepeatCheck As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblMajorRepeatCheck"), Label)
                    Dim lblCriticalValue As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblCriticalValue"), Label)
                    Dim lblCriticalRepeatCheck As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblCriticalRepeatCheck"), Label)

                    Dim lnqdrivedetail As New CfConfigDriveDetailLinqDB
                    With lnqdrivedetail
                        .CF_CONFIG_DRIVE_ID = lnqdrive.ID
                        .DRIVELETTER = lblDriveLetter.Text
                        .ALARMMINORVALUE = lblMinorValue.Text
                        .REPEATCHECKMINOR = lblMinorRepeatCheck.Text
                        .ALARMMAJORVALUE = lblMajorValue.Text
                        .REPEATCHECKMAJOR = lblMajorRepeatCheck.Text
                        .ALARMCRITICALVALUE = lblCriticalValue.Text
                        .REPEATCHECKCRITICAL = lblCriticalRepeatCheck.Text
                        ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                    End With
                    If ret = False Then
                        trans.RollbackTransaction()
                        strRet = lnqdrivedetail.ErrorMessage
                        Return strRet
                    End If
                Next
            End If

            lnqdrive = Nothing
            '##########

            '## Service
            Dim lnqservice As New CfConfigServiceLinqDB
            With lnqservice
                .GetDataByPK(Convert.ToInt64(txtIDService.Text), trans.Trans)
                .SERVERIP = txtServerIP.Text
                .SERVERNAME = txtServerName.Text
                .MACADDRESS = txtMacAddress.Text
                .CHECKINTERVALMINUTE = CtlServiceConfig.IntervalMinute
                .ALLDAYEVENT = CtlServiceConfig.AllDayEvent
                .ALARMSUN = CtlServiceConfig.CheckSun
                .ALARMMON = CtlServiceConfig.CheckMon
                .ALARMTUE = CtlServiceConfig.CheckTue
                .ALARMWED = CtlServiceConfig.CheckWed
                .ALARMTHU = CtlServiceConfig.CheckThu
                .ALARMFRI = CtlServiceConfig.CheckFri
                .ALARMSAT = CtlServiceConfig.CheckSat
                .ALARMTIMEFROM = CtlServiceConfig.TimeFrom
                .ALARMTIMETO = CtlServiceConfig.TimeTo
                .LASTCHECKTIME = Today.Date
                .ACTIVESTATUS = CtlServiceConfig.ActiveStatus
                If .ID > 0 Then
                    ret = .UpdateByPK(Globals.uData.USERNAME, trans.Trans)
                Else
                    ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                End If
            End With
            If ret = False Then
                trans.RollbackTransaction()
                strRet = lnqservice.ErrorMessage
                Return strRet
            End If

            sql = "delete from CF_CONFIG_SERVICE_DETAIL where cf_config_service_id ='" & lnqservice.ID & "'"
            SqlDB.ExecuteNonQuery(sql, trans.Trans)

            If gvService.Rows.Count > 0 Then
                For i As Integer = 0 To gvService.Rows.Count - 1
                    Dim chk As CheckBox = DirectCast(gvService.Rows(i).FindControl("ckbSelect"), CheckBox)
                    Dim lblID As Label = DirectCast(gvService.Rows(i).FindControl("lblID"), Label)
                    If chk.Checked = True Then
                        Dim lnqservicedetail As New CfConfigServiceDetailLinqDB
                        With lnqservicedetail
                            .CF_CONFIG_SERVICE_ID = lnqservice.ID
                            .MS_MASTER_SERVICE_CHECKLIST_ID = lblID.Text
                            .REPEATCHECKQTY = 1
                            ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                        End With
                        If ret = False Then
                            trans.RollbackTransaction()
                            strRet = lnqservicedetail.ErrorMessage
                            Return strRet
                        End If
                    End If
                Next
            End If
            lnqservice = Nothing
            '##########

            '## Process
            Dim lnqprocess As New CfConfigProcessLinqDB
            With lnqprocess
                .GetDataByPK(Convert.ToInt64(txtIDProcess.Text), trans.Trans)
                .SERVERIP = txtServerIP.Text
                .SERVERNAME = txtServerName.Text
                .MACADDRESS = txtMacAddress.Text
                .CHECKINTERVALMINUTE = CtlProcessConfig.IntervalMinute
                .ALLDAYEVENT = CtlProcessConfig.AllDayEvent
                .ALARMSUN = CtlProcessConfig.CheckSun
                .ALARMMON = CtlProcessConfig.CheckMon
                .ALARMTUE = CtlProcessConfig.CheckTue
                .ALARMWED = CtlProcessConfig.CheckWed
                .ALARMTHU = CtlProcessConfig.CheckThu
                .ALARMFRI = CtlProcessConfig.CheckFri
                .ALARMSAT = CtlProcessConfig.CheckSat
                .ALARMTIMEFROM = CtlProcessConfig.TimeFrom
                .ALARMTIMETO = CtlProcessConfig.TimeTo
                .LASTCHECKTIME = Today.Date
                .ACTIVESTATUS = CtlProcessConfig.ActiveStatus
                If .ID > 0 Then
                    ret = .UpdateByPK(Globals.uData.USERNAME, trans.Trans)
                Else
                    ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                End If
            End With
            If ret = False Then
                trans.RollbackTransaction()
                strRet = lnqprocess.ErrorMessage
                Return strRet
            End If

            sql = "delete from CF_CONFIG_PROCESS_DETAIL where cf_config_process_id ='" & lnqprocess.ID & "'"
            SqlDB.ExecuteNonQuery(sql, trans.Trans)

            If gvProcess.Rows.Count > 0 Then
                For i As Integer = 0 To gvProcess.Rows.Count - 1
                    Dim chk As CheckBox = DirectCast(gvProcess.Rows(i).FindControl("ckbSelect"), CheckBox)
                    Dim lblID As Label = DirectCast(gvProcess.Rows(i).FindControl("lblID"), Label)
                    If chk.Checked = True Then
                        Dim lnqprocessdetail As New CfConfigProcessDetailLinqDB
                        With lnqprocessdetail
                            .CF_CONFIG_PROCESS_ID = lnqprocess.ID
                            .MS_MASTER_PROCESS_CHECKLIST_ID = lblID.Text
                            .REPEATCHECKQTY = 1
                            ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                        End With
                        If ret = False Then
                            trans.RollbackTransaction()
                            strRet = lnqprocessdetail.ErrorMessage
                            Return strRet
                        End If
                    End If
                Next
            End If
            lnqprocess = Nothing
            '##########


            '## FileSize
            Dim lnqfilesize As New CfConfigFilesizeLinqDB
            With lnqfilesize
                .GetDataByPK(Convert.ToInt64(txtIDFileSize.Text), trans.Trans)
                .SERVERIP = txtServerIP.Text
                .SERVERNAME = txtServerName.Text
                .MACADDRESS = txtMacAddress.Text
                .CHECKINTERVALMINUTE = CtlFileSizeConfig.IntervalMinute
                .ALLDAYEVENT = CtlFileSizeConfig.AllDayEvent
                .ALARMSUN = CtlFileSizeConfig.CheckSun
                .ALARMMON = CtlFileSizeConfig.CheckMon
                .ALARMTUE = CtlFileSizeConfig.CheckTue
                .ALARMWED = CtlFileSizeConfig.CheckWed
                .ALARMTHU = CtlFileSizeConfig.CheckThu
                .ALARMFRI = CtlFileSizeConfig.CheckFri
                .ALARMSAT = CtlFileSizeConfig.CheckSat
                .ALARMTIMEFROM = CtlFileSizeConfig.TimeFrom
                .ALARMTIMETO = CtlFileSizeConfig.TimeTo
                .LASTCHECKTIME = Today.Date
                .ACTIVESTATUS = CtlFileSizeConfig.ActiveStatus
                If .ID > 0 Then
                    ret = .UpdateByPK(Globals.uData.USERNAME, trans.Trans)
                Else
                    ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                End If
            End With
            If ret = False Then
                trans.RollbackTransaction()
                strRet = lnqfilesize.ErrorMessage
                Return strRet
            End If

            sql = "delete from CF_CONFIG_FileSize_DETAIL where cf_config_filesize_id ='" & lnqfilesize.ID & "'"
            SqlDB.ExecuteNonQuery(sql, trans.Trans)

            If gvFileSize.Rows.Count > 0 Then
                For i As Integer = 0 To gvFileSize.Rows.Count - 1
                    Dim lblFilePath As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblFilePath"), Label)
                    Dim lblMinorValue As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblMinorValue"), Label)
                    Dim lblMinorRepeatCheck As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblMinorRepeatCheck"), Label)
                    Dim lblMajorValue As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblMajorValue"), Label)
                    Dim lblMajorRepeatCheck As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblMajorRepeatCheck"), Label)
                    Dim lblCriticalValue As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblCriticalValue"), Label)
                    Dim lblCriticalRepeatCheck As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblCriticalRepeatCheck"), Label)

                    Dim lnqfilesizedetail As New CfConfigFilesizeDetailLinqDB
                    With lnqfilesizedetail
                        .CF_CONFIG_FILESIZE_ID = lnqfilesize.ID
                        .FILENAME = lblFilePath.Text
                        .FILESIZEMINOR = lblMinorValue.Text
                        .FILESIZEMAJOR = lblMajorValue.Text
                        .FILESIZECRITICAL = lblCriticalValue.Text
                        .REPEATCHECKMINOR = lblMinorRepeatCheck.Text
                        .REPEATCHECKMAJOR = lblMajorRepeatCheck.Text
                        .REPEATCHECKCRITICAL = lblCriticalRepeatCheck.Text
                        ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                        If ret = False Then
                            trans.RollbackTransaction()
                            strRet = lnqfilesizedetail.ErrorMessage
                            Return strRet
                        End If
                    End With
                Next
            End If
            lnqfilesize = Nothing
            '##########

            '## Port
            Dim lnqport As New CfConfigPortLinqDB
            With lnqport
                .GetDataByPK(Convert.ToInt64(txtIDPort.Text), trans.Trans)
                .HOSTIP = txtServerIP.Text
                .HOSTNAME = txtServerName.Text
                .MACADDRESS = txtMacAddress.Text
                .ALLDAYEVENT = CtlPortConfig.AllDayEvent
                .ALARMSUN = CtlPortConfig.CheckSun
                .ALARMMON = CtlPortConfig.CheckMon
                .ALARMTUE = CtlPortConfig.CheckTue
                .ALARMWED = CtlPortConfig.CheckWed
                .ALARMTHU = CtlPortConfig.CheckThu
                .ALARMFRI = CtlPortConfig.CheckFri
                .ALARMSAT = CtlPortConfig.CheckSat
                .ALARMTIMEFROM = CtlPortConfig.TimeFrom
                .ALARMTIMETO = CtlPortConfig.TimeTo
                .LASTCHECKTIME = Today.Date
                .ACTIVESTATUS = CtlPortConfig.ActiveStatus
                If .ID > 0 Then
                    ret = .UpdateByPK(Globals.uData.USERNAME, trans.Trans)
                Else
                    ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                End If
            End With
            If ret = False Then
                trans.RollbackTransaction()
                strRet = lnqport.ErrorMessage
                Return strRet
            End If

            sql = "delete from CF_CONFIG_PORT_DETAIL where cf_config_port_id ='" & lnqport.ID & "'"
            SqlDB.ExecuteNonQuery(sql, trans.Trans)

            If gvPort.Rows.Count > 0 Then
                For i As Integer = 0 To gvPort.Rows.Count - 1
                    Dim lblportnumber As Label = DirectCast(gvPort.Rows(i).FindControl("lblPortNo"), Label)
                    Dim lblrepeatcheck As Label = DirectCast(gvPort.Rows(i).FindControl("lblRepeatCheck"), Label)
                    Dim lnqportdetail As New CfConfigPortDetailLinqDB
                    With lnqportdetail
                        .CF_CONFIG_PORT_ID = lnqport.ID
                        .PORTNUMBER = lblportnumber.Text
                        .REPEATCHECK = lblrepeatcheck.Text
                        ret = .InsertData(Globals.uData.USERNAME, trans.Trans)
                        If ret = False Then
                            trans.RollbackTransaction()
                            strRet = lnqportdetail.ErrorMessage
                            Return strRet
                        End If
                    End With
                Next
            End If


            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            Return strRet
        Catch ex As Exception
            trans.RollbackTransaction()
            Return ex.ToString()
        End Try


    End Function

    Protected Sub btnSaveRegister_Click(sender As Object, e As EventArgs) Handles btnSaveRegister.Click
        If Validate() Then
            Dim ret As String = Save()
            If ret = "" Then
                'ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Save data Complete !');", True)
                Response.Redirect("frmRegister.aspx")
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save Data !');", True)
            End If
        End If
       
    End Sub

    Protected Sub btnCancelRegister_Click(sender As Object, e As EventArgs) Handles btnCancelRegister.Click
        Response.Redirect("frmRegister.aspx")
    End Sub

#Region "Register"

    Sub ClearRegister()
        txtIDRegister.Text = "0"
        txtServerIP.Text = ""
        txtMacAddress.Text = ""
        txtSystem.Text = ""
        txtLacServer.Text = ""
        txtLacNumber.Text = ""
        txtServerName.Text = ""
        txtOS.Text = ""
        txtFnameR.Text = ""
        txtLnameR.Text = ""
        txtEmail.Text = ""
        chkActiveStatusR.Checked = True
    End Sub
    Sub LoadRegister(ID As String)
        Dim eng_reg As New Engine.Web_Config.RegisterENG
        Dim dt_reg As New DataTable
        dt_reg = eng_reg.GetRegisterByID(ID)

        Dim serverip As String = ""
        Dim servername As String = ""
        Dim macaddress As String = ""

        If dt_reg.Rows.Count > 0 Then
            With dt_reg
                serverip = .Rows(0)("ServerIP").ToString
                servername = .Rows(0)("ServerName").ToString
                macaddress = .Rows(0)("MacAddress").ToString

                txtIDRegister.Text = .Rows(0)("ID").ToString
                txtServerIP.Text = .Rows(0)("ServerIP").ToString
                txtMacAddress.Text = .Rows(0)("MacAddress").ToString
                txtSystem.Text = .Rows(0)("System_Type").ToString
                txtLacServer.Text = .Rows(0)("LocationServer").ToString
                txtLacNumber.Text = .Rows(0)("LocationNo").ToString
                txtServerName.Text = .Rows(0)("ServerName").ToString
                txtOS.Text = .Rows(0)("OS").ToString
                txtFnameR.Text = .Rows(0)("Fname").ToString
                txtLnameR.Text = .Rows(0)("Lname").ToString
                txtEmail.Text = .Rows(0)("E_mail").ToString
                chkActiveStatusR.Checked = IIf(.Rows(0)("Active_Status").ToString = "Y", True, False)
            End With
        Else
            ClearRegister()
        End If
        eng_reg = Nothing

        LoadCPU(serverip, servername, macaddress)
        LoadRam(serverip, servername, macaddress)
        LoadService(serverip, servername, macaddress)
        LoadProcess(serverip, servername, macaddress)
        LoadDrive(serverip, servername, macaddress)
        LoadFileSize(serverip, servername, macaddress)
        LoadPort(serverip, servername, macaddress)

    End Sub

    Private Function Validate() As Boolean

        If txtServerIP.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Server IP !');", True)
            Return False
        End If

        If txtServerName.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Server Name !');", True)
            Return False
        End If

        If txtOS.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify OS !');", True)
            Return False
        End If

        If txtSystem.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Project Name !');", True)
            Return False
        End If

        If txtFnameR.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify First Name !');", True)
            Return False
        End If

        If txtLnameR.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Last Name !');", True)
            Return False
        End If

        If txtEmail.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify E-mail !');", True)
            Return False
        End If

        ' check ค่าซ้ำ
        Dim REng As New UserEng
        If REng.CheckDuplicateRegister(Convert.ToInt64(txtIDRegister.Text), txtServerIP.Text.Trim(), txtServerName.Text.Trim(), txtMacAddress.Text.Trim()) = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (REng.ErrorMessage), True)
            REng = Nothing
            Return False
        End If

        REng = Nothing

        If ctlCPUConfig.AllDayEvent = "N" And (ctlCPUConfig.TimeFrom = "" Or ctlCPUConfig.TimeTo = "") Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify CPU Alarm Time !');", True)
            Return False
        End If

        If ctlRamConfig.AllDayEvent = "N" And (ctlRamConfig.TimeFrom = "" Or ctlRamConfig.TimeTo = "") Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify RAM Alarm Time !');", True)
            Return False
        End If

        If ctlDriveConfig.AllDayEvent = "N" And (ctlDriveConfig.TimeFrom = "" Or ctlDriveConfig.TimeTo = "") Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Drive Alarm Time !');", True)
            Return False
        End If

        If CtlServiceConfig.AllDayEvent = "N" And (CtlServiceConfig.TimeFrom = "" Or CtlServiceConfig.TimeTo = "") Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Service Alarm Time !');", True)
            Return False
        End If

        If CtlProcessConfig.AllDayEvent = "N" And (CtlProcessConfig.TimeFrom = "" Or CtlProcessConfig.TimeTo = "") Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Process Alarm Time !');", True)
            Return False
        End If

        If CtlFileSizeConfig.AllDayEvent = "N" And (CtlFileSizeConfig.TimeFrom = "" Or CtlFileSizeConfig.TimeTo = "") Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify File Size Alarm Time !');", True)
            Return False
        End If

        If CtlPortConfig.AllDayEvent = "N" And (CtlPortConfig.TimeFrom = "" Or CtlPortConfig.TimeTo = "") Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Specify Port Alarm Time !');", True)
            Return False
        End If


        Return True
    End Function

#End Region

#Region "CPU"

    Sub ClearCPU()
        txtIDCPU.Text = "0"
        ctlCPUConfig.IntervalMinute = ""
        ctlCPUConfig.ActiveStatus = "Y"
        ctlCPUConfig.CheckSun = "N"
        ctlCPUConfig.CheckMon = "N"
        ctlCPUConfig.CheckTue = "N"
        ctlCPUConfig.CheckWed = "N"
        ctlCPUConfig.CheckThu = "N"
        ctlCPUConfig.CheckFri = "N"
        ctlCPUConfig.CheckSat = "N"
        ctlCPUConfig.TimeFrom = ""
        ctlCPUConfig.TimeTo = ""
        ctlCPUConfig.AllDayEvent = "N"

        ctlCPUSeverity.MinorValue = ""
        ctlCPUSeverity.MajorValue = ""
        ctlCPUSeverity.CriticalValue = ""
        ctlCPUSeverity.RepeatMinor = ""
        ctlCPUSeverity.RepeatMajor = ""
        ctlCPUSeverity.RepeatCritical = ""
    End Sub

    Sub LoadCPU(ServerIP As String, ServerName As String, MacAddress As String)
        Dim eng_cpu As New Engine.Web_Config.CPUEng
        Dim dt_cpu As New DataTable
        dt_cpu = eng_cpu.GetCPU(ServerIP, ServerName, MacAddress)
        If dt_cpu.Rows.Count > 0 Then
            With dt_cpu
                txtIDCPU.Text = .Rows(0)("ID").ToString
                ctlCPUConfig.IntervalMinute = IIf(.Rows(0)("CheckIntervalMinute").ToString = "0", "", .Rows(0)("CheckIntervalMinute").ToString)
                ctlCPUConfig.ActiveStatus = .Rows(0)("ActiveStatus").ToString
                ctlCPUConfig.CheckSun = .Rows(0)("AlarmSun").ToString
                ctlCPUConfig.CheckMon = .Rows(0)("AlarmMon").ToString
                ctlCPUConfig.CheckTue = .Rows(0)("AlarmTue").ToString
                ctlCPUConfig.CheckWed = .Rows(0)("AlarmWed").ToString
                ctlCPUConfig.CheckThu = .Rows(0)("AlarmThu").ToString
                ctlCPUConfig.CheckFri = .Rows(0)("AlarmFri").ToString
                ctlCPUConfig.CheckSat = .Rows(0)("AlarmSat").ToString
                ctlCPUConfig.TimeFrom = .Rows(0)("AlarmTimeFrom").ToString
                ctlCPUConfig.TimeTo = .Rows(0)("AlarmTimeTo").ToString
                ctlCPUConfig.AllDayEvent = .Rows(0)("AllDayEvent").ToString

                ctlCPUSeverity.MinorValue = IIf(.Rows(0)("AlarmMinorValue").ToString = "0", "", .Rows(0)("AlarmMinorValue").ToString)
                ctlCPUSeverity.MajorValue = IIf(.Rows(0)("AlarmMajorValue").ToString = "0", "", .Rows(0)("AlarmMajorValue").ToString)
                ctlCPUSeverity.CriticalValue = IIf(.Rows(0)("AlarmCriticalValue").ToString = "0", "", .Rows(0)("AlarmCriticalValue").ToString)
                ctlCPUSeverity.RepeatMinor = IIf(.Rows(0)("RepeatCheckMinor").ToString = "0", "", .Rows(0)("RepeatCheckMinor").ToString)
                ctlCPUSeverity.RepeatMajor = IIf(.Rows(0)("RepeatCheckMajor").ToString = "0", "", .Rows(0)("RepeatCheckMajor").ToString)
                ctlCPUSeverity.RepeatCritical = IIf(.Rows(0)("RepeatCheckCritical").ToString = "0", "", .Rows(0)("RepeatCheckCritical").ToString)
            End With
        Else
            ClearCPU()
        End If

        eng_cpu = Nothing
    End Sub

#End Region

#Region "RAM"

    Sub ClearRam()
        txtIDRAM.Text = "0"
        ctlRamConfig.IntervalMinute = ""
        ctlRamConfig.ActiveStatus = "Y"
        ctlRamConfig.CheckSun = "N"
        ctlRamConfig.CheckMon = "N"
        ctlRamConfig.CheckTue = "N"
        ctlRamConfig.CheckWed = "N"
        ctlRamConfig.CheckThu = "N"
        ctlRamConfig.CheckFri = "N"
        ctlRamConfig.CheckSat = "N"
        ctlRamConfig.TimeFrom = ""
        ctlRamConfig.TimeTo = ""
        ctlRamConfig.AllDayEvent = "N"

        ctlRamSeverity.MinorValue = ""
        ctlRamSeverity.MajorValue = ""
        ctlRamSeverity.CriticalValue = ""
        ctlRamSeverity.RepeatMinor = ""
        ctlRamSeverity.RepeatMajor = ""
        ctlRamSeverity.RepeatCritical = ""
    End Sub

    Sub LoadRam(ServerIP As String, ServerName As String, MacAddress As String)
        Dim eng As New Engine.Web_Config.RAMEng
        Dim dt As New DataTable
        dt = eng.GetRam(ServerIP, ServerName, MacAddress)
        If dt.Rows.Count > 0 Then
            With dt
                txtIDRAM.Text = .Rows(0)("ID").ToString
                ctlRamConfig.IntervalMinute = IIf(.Rows(0)("CheckIntervalMinute").ToString = "0", "", .Rows(0)("CheckIntervalMinute").ToString)
                ctlRamConfig.ActiveStatus = .Rows(0)("ActiveStatus").ToString
                ctlRamConfig.CheckSun = .Rows(0)("AlarmSun").ToString
                ctlRamConfig.CheckMon = .Rows(0)("AlarmMon").ToString
                ctlRamConfig.CheckTue = .Rows(0)("AlarmTue").ToString
                ctlRamConfig.CheckWed = .Rows(0)("AlarmWed").ToString
                ctlRamConfig.CheckThu = .Rows(0)("AlarmThu").ToString
                ctlRamConfig.CheckFri = .Rows(0)("AlarmFri").ToString
                ctlRamConfig.CheckSat = .Rows(0)("AlarmSat").ToString
                ctlRamConfig.TimeFrom = .Rows(0)("AlarmTimeFrom").ToString
                ctlRamConfig.TimeTo = .Rows(0)("AlarmTimeTo").ToString
                ctlRamConfig.AllDayEvent = .Rows(0)("AllDayEvent").ToString

                ctlRamSeverity.MinorValue = IIf(.Rows(0)("AlarmMinorValue").ToString = "0", "", .Rows(0)("AlarmMinorValue").ToString)
                ctlRamSeverity.MajorValue = IIf(.Rows(0)("AlarmMajorValue").ToString = "0", "", .Rows(0)("AlarmMajorValue").ToString)
                ctlRamSeverity.CriticalValue = IIf(.Rows(0)("AlarmCriticalValue").ToString = "0", "", .Rows(0)("AlarmCriticalValue").ToString)
                ctlRamSeverity.RepeatMinor = IIf(.Rows(0)("RepeatCheckMinor").ToString = "0", "", .Rows(0)("RepeatCheckMinor").ToString)
                ctlRamSeverity.RepeatMajor = IIf(.Rows(0)("RepeatCheckMajor").ToString = "0", "", .Rows(0)("RepeatCheckMajor").ToString)
                ctlRamSeverity.RepeatCritical = IIf(.Rows(0)("RepeatCheckCritical").ToString = "0", "", .Rows(0)("RepeatCheckCritical").ToString)
            End With
        Else
            ClearRam()
        End If
    End Sub

#End Region

#Region "Service"

    Sub ClearService()
        txtIDService.Text = "0"
        CtlServiceConfig.IntervalMinute = ""
        CtlServiceConfig.ActiveStatus = "Y"
        CtlServiceConfig.CheckSun = "N"
        CtlServiceConfig.CheckMon = "N"
        CtlServiceConfig.CheckTue = "N"
        CtlServiceConfig.CheckWed = "N"
        CtlServiceConfig.CheckThu = "N"
        CtlServiceConfig.CheckFri = "N"
        CtlServiceConfig.CheckSat = "N"
        CtlServiceConfig.TimeFrom = ""
        CtlServiceConfig.TimeTo = ""
        CtlServiceConfig.AllDayEvent = "N"

        For i As Integer = 0 To gvService.Rows.Count - 1
            Dim chk As CheckBox = DirectCast(gvService.Rows(i).FindControl("ckbSelect"), CheckBox)
            chk.Checked = False
        Next

    End Sub

    Sub LoadService(ServerIP As String, ServerName As String, MacAddress As String)
        Dim eng As New Engine.Web_Config.ServiceENG
        Dim dt As New DataTable
        dt = eng.GetService(ServerIP, ServerName, MacAddress)
        If dt.Rows.Count > 0 Then
            With dt
                txtIDService.Text = .Rows(0)("ID").ToString
                CtlServiceConfig.IntervalMinute = IIf(.Rows(0)("CheckIntervalMinute").ToString = "0", "", .Rows(0)("CheckIntervalMinute").ToString)
                CtlServiceConfig.ActiveStatus = .Rows(0)("ActiveStatus").ToString
                CtlServiceConfig.CheckSun = .Rows(0)("AlarmSun").ToString
                CtlServiceConfig.CheckMon = .Rows(0)("AlarmMon").ToString
                CtlServiceConfig.CheckTue = .Rows(0)("AlarmTue").ToString
                CtlServiceConfig.CheckWed = .Rows(0)("AlarmWed").ToString
                CtlServiceConfig.CheckThu = .Rows(0)("AlarmThu").ToString
                CtlServiceConfig.CheckFri = .Rows(0)("AlarmFri").ToString
                CtlServiceConfig.CheckSat = .Rows(0)("AlarmSat").ToString
                CtlServiceConfig.TimeFrom = .Rows(0)("AlarmTimeFrom").ToString
                CtlServiceConfig.TimeTo = .Rows(0)("AlarmTimeTo").ToString
                CtlServiceConfig.AllDayEvent = .Rows(0)("AllDayEvent").ToString
            End With


            Dim dtdetail As New DataTable
            dtdetail = eng.GetServiceDetail(txtIDService.Text)
            If dtdetail.Rows.Count > 0 Then
                For i As Integer = 0 To gvService.Rows.Count - 1
                    Dim chk As CheckBox = DirectCast(gvService.Rows(i).FindControl("ckbSelect"), CheckBox)
                    Dim lblID As Label = DirectCast(gvService.Rows(i).FindControl("lblID"), Label)
                    Dim tmpdr As DataRow()
                    tmpdr = dtdetail.Select("ms_master_service_checklist_id ='" & lblID.Text & "'")
                    If tmpdr.Length > 0 Then
                        chk.Checked = True
                    Else
                        chk.Checked = False
                    End If
                Next
            End If

        Else
            ClearService()
        End If
    End Sub

    Sub SetService()
        Try
            Dim dt As DataTable
            Dim eng As New Engine.Web_Config.ServiceENG
            dt = eng.SetShowService("")

            dt.Columns.Add("seq")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("seq") = i + 1
            Next
            gvService.DataSource = dt
            gvService.DataBind()
        Catch ex As Exception
            gvService.DataSource = Nothing
            gvService.DataBind()
        End Try

    End Sub
#End Region

#Region "Process"

    Sub ClearProcess()
        txtIDProcess.Text = "0"
        CtlProcessConfig.IntervalMinute = ""
        CtlProcessConfig.ActiveStatus = "Y"
        CtlProcessConfig.CheckSun = "N"
        CtlProcessConfig.CheckMon = "N"
        CtlProcessConfig.CheckTue = "N"
        CtlProcessConfig.CheckWed = "N"
        CtlProcessConfig.CheckThu = "N"
        CtlProcessConfig.CheckFri = "N"
        CtlProcessConfig.CheckSat = "N"
        CtlProcessConfig.TimeFrom = ""
        CtlProcessConfig.TimeTo = ""
        CtlProcessConfig.AllDayEvent = "N"

        For i As Integer = 0 To gvProcess.Rows.Count - 1
            Dim chk As CheckBox = DirectCast(gvProcess.Rows(i).FindControl("ckbSelect"), CheckBox)
            chk.Checked = False
        Next

    End Sub

    Sub LoadProcess(ServerIP As String, ServerName As String, MacAddress As String)
        Dim eng As New Engine.Web_Config.ProcessENG
        Dim dt As New DataTable
        dt = eng.GetProcess(ServerIP, ServerName, MacAddress)
        If dt.Rows.Count > 0 Then
            With dt
                txtIDProcess.Text = .Rows(0)("ID").ToString
                CtlProcessConfig.IntervalMinute = IIf(.Rows(0)("CheckIntervalMinute").ToString = "0", "", .Rows(0)("CheckIntervalMinute").ToString)
                CtlProcessConfig.ActiveStatus = .Rows(0)("ActiveStatus").ToString
                CtlProcessConfig.CheckSun = .Rows(0)("AlarmSun").ToString
                CtlProcessConfig.CheckMon = .Rows(0)("AlarmMon").ToString
                CtlProcessConfig.CheckTue = .Rows(0)("AlarmTue").ToString
                CtlProcessConfig.CheckWed = .Rows(0)("AlarmWed").ToString
                CtlProcessConfig.CheckThu = .Rows(0)("AlarmThu").ToString
                CtlProcessConfig.CheckFri = .Rows(0)("AlarmFri").ToString
                CtlProcessConfig.CheckSat = .Rows(0)("AlarmSat").ToString
                CtlProcessConfig.TimeFrom = .Rows(0)("AlarmTimeFrom").ToString
                CtlProcessConfig.TimeTo = .Rows(0)("AlarmTimeTo").ToString
                CtlProcessConfig.AllDayEvent = .Rows(0)("AllDayEvent").ToString
            End With

            Dim dtdetail As New DataTable
            dtdetail = eng.GetProcessDetail(txtIDService.Text)
            If dtdetail.Rows.Count > 0 Then
                For i As Integer = 0 To gvProcess.Rows.Count - 1
                    Dim chk As CheckBox = DirectCast(gvProcess.Rows(i).FindControl("ckbSelect"), CheckBox)
                    Dim lblID As Label = DirectCast(gvProcess.Rows(i).FindControl("lblID"), Label)
                    Dim tmpdr As DataRow()
                    tmpdr = dtdetail.Select("ms_master_process_checklist_id ='" & lblID.Text & "'")
                    If tmpdr.Length > 0 Then
                        chk.Checked = True
                    Else
                        chk.Checked = False
                    End If
                Next
            End If
        Else
            ClearProcess()
        End If



    End Sub

    Sub SetProcess()
        Try
            Dim dt As New DataTable
            Dim eng As New Engine.Web_Config.ProcessENG
            dt = eng.SetShowProcess("")

            dt.Columns.Add("seq")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("seq") = i + 1
            Next

            gvProcess.DataSource = dt
            gvProcess.DataBind()
        Catch ex As Exception
            gvProcess.DataSource = Nothing
            gvProcess.DataBind()
        End Try

    End Sub


#End Region

#Region "Drive"

    Sub ClearDrive()
        txtIDDrive.Text = "0"
        ctlDriveConfig.IntervalMinute = ""
        ctlDriveConfig.ActiveStatus = "Y"
        ctlDriveConfig.CheckSun = "N"
        ctlDriveConfig.CheckMon = "N"
        ctlDriveConfig.CheckTue = "N"
        ctlDriveConfig.CheckWed = "N"
        ctlDriveConfig.CheckThu = "N"
        ctlDriveConfig.CheckFri = "N"
        ctlDriveConfig.CheckSat = "N"
        ctlDriveConfig.TimeFrom = ""
        ctlDriveConfig.TimeTo = ""
        ctlDriveConfig.AllDayEvent = "N"

        Dim dt As New DataTable
        With dt
            .Columns.Add("seq")
            .Columns.Add("DriveLetter")
            .Columns.Add("AlarmMinorValue")
            .Columns.Add("RepeatCheckMinor")
            .Columns.Add("AlarmMajorValue")
            .Columns.Add("RepeatCheckMajor")
            .Columns.Add("AlarmCriticalValue")
            .Columns.Add("RepeatCheckCritical")
        End With
        gvDriveDetail.DataSource = dt
        gvDriveDetail.DataBind()
    End Sub

    Sub LoadDrive(ServerIP As String, ServerName As String, MacAddress As String)
        Dim eng As New Engine.Web_Config.DriveENG
        Dim dt As DataTable
        dt = eng.GetDrive(ServerIP, ServerName, MacAddress)
        If dt.Rows.Count > 0 Then
            With dt
                txtIDDrive.Text = .Rows(0)("ID").ToString
                ctlDriveConfig.IntervalMinute = IIf(.Rows(0)("CheckIntervalMinute").ToString = "0", "", .Rows(0)("CheckIntervalMinute").ToString)
                ctlDriveConfig.ActiveStatus = .Rows(0)("ActiveStatus").ToString
                ctlDriveConfig.CheckSun = .Rows(0)("AlarmSun").ToString
                ctlDriveConfig.CheckMon = .Rows(0)("AlarmMon").ToString
                ctlDriveConfig.CheckTue = .Rows(0)("AlarmTue").ToString
                ctlDriveConfig.CheckWed = .Rows(0)("AlarmWed").ToString
                ctlDriveConfig.CheckThu = .Rows(0)("AlarmThu").ToString
                ctlDriveConfig.CheckFri = .Rows(0)("AlarmFri").ToString
                ctlDriveConfig.CheckSat = .Rows(0)("AlarmSat").ToString
                ctlDriveConfig.TimeFrom = .Rows(0)("AlarmTimeFrom").ToString
                ctlDriveConfig.TimeTo = .Rows(0)("AlarmTimeTo").ToString
                ctlDriveConfig.AllDayEvent = .Rows(0)("AllDayEvent").ToString
            End With


            Dim dtdetail As New DataTable
            dtdetail = eng.GetDriveDetail(txtIDDrive.Text)

            dtdetail.Columns.Add("seq")
            For i As Integer = 0 To dtdetail.Rows.Count - 1
                dtdetail.Rows(i)("seq") = i + 1
            Next

            gvDriveDetail.DataSource = dtdetail
            gvDriveDetail.DataBind()
        Else
            ClearDrive()
        End If
    End Sub

    Protected Sub btnAddDrive_Click(sender As Object, e As EventArgs) Handles btnAddDrive.Click
        ClearDriveDetail()
        popAddDrive.Show()
    End Sub

    Protected Sub btnCancelAddDrive_Click(sender As Object, e As EventArgs) Handles btnCancelAddDrive.Click
        popAddDrive.Hide()
    End Sub

    Protected Sub btnSaveAddDrive_Click(sender As Object, e As EventArgs) Handles btnSaveAddDrive.Click
        If ValidateDriveDetail() Then
            AddDrive()
            popAddDrive.Hide()
        Else
            popAddDrive.Show()
        End If
    End Sub

    Sub ClearDriveDetail()
        txtDriveLetter.Text = ""
        ctlConfigSeverityDrive.MinorValue = ""
        ctlConfigSeverityDrive.RepeatMinor = ""
        ctlConfigSeverityDrive.MajorValue = ""
        ctlConfigSeverityDrive.RepeatMajor = ""
        ctlConfigSeverityDrive.CriticalValue = ""
        ctlConfigSeverityDrive.RepeatCritical = ""
        lblErrorDrive.Text = ""
        hidDriveDetailSeq.Value = ""

        'select DriveLetter,AlarmMinorValue,AlarmMajorValue,AlarmCriticalValue,RepeatCheckMinor
        ',RepeatCheckMajor,RepeatCheckCritical from [dbo].[CF_CONFIG_DRIVE_DETAIL]
    End Sub

    Function ValidateDriveDetail() As Boolean
        Dim minor_value As String = ctlConfigSeverityDrive.MinorValue
        Dim minor_repeat As String = ctlConfigSeverityDrive.RepeatMinor
        Dim major_value As String = ctlConfigSeverityDrive.MajorValue
        Dim major_repeat As String = ctlConfigSeverityDrive.RepeatMajor
        Dim critical_value As String = ctlConfigSeverityDrive.CriticalValue
        Dim critical_repeat As String = ctlConfigSeverityDrive.RepeatCritical

        lblErrorDrive.Text = ""
        If txtDriveLetter.Text = "" Then
            lblErrorDrive.Text = "Please, Specify Drive Letter !"
            Return False
        End If
        If minor_value = "0" Then
            lblErrorDrive.Text = "Please, Specify Minor Value !"
            Return False
        End If

        If major_value = "0" Then
            lblErrorDrive.Text = "Please, Specify Major Value !"
            Return False
        End If

        If critical_value = "0" Then
            lblErrorDrive.Text = "Please, Specify Critical Value !"
            Return False
        End If

        If minor_repeat = "0" Then
            lblErrorDrive.Text = "Please, Specify Repeat Minor !"
            Return False
        End If

        If major_repeat = "0" Then
            lblErrorDrive.Text = "Please, Specify Repeat Major !"
            Return False
        End If

        If critical_repeat = "0" Then
            lblErrorDrive.Text = "Please, Specify Repeat Critical !"
            Return False
        End If

        For i As Integer = 0 To gvDriveDetail.Rows.Count - 1
            Dim lblseq As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblseq"), Label)
            Dim lblDriveLetter As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblDriveLetter"), Label)
            If lblDriveLetter.Text = txtDriveLetter.Text And hidDriveDetailSeq.Value <> lblseq.Text Then
                lblErrorDrive.Text = "This Drive Letter is already exist!"
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub AddDrive()
        Dim minor_value As String = ctlConfigSeverityDrive.MinorValue
        Dim minor_repeat As String = ctlConfigSeverityDrive.RepeatMinor
        Dim major_value As String = ctlConfigSeverityDrive.MajorValue
        Dim major_repeat As String = ctlConfigSeverityDrive.RepeatMajor
        Dim critical_value As String = ctlConfigSeverityDrive.CriticalValue
        Dim critical_repeat As String = ctlConfigSeverityDrive.RepeatCritical

        Dim dt As New DataTable
        With dt
            .Columns.Add("seq")
            .Columns.Add("DriveLetter")
            .Columns.Add("AlarmMinorValue")
            .Columns.Add("RepeatCheckMinor")
            .Columns.Add("AlarmMajorValue")
            .Columns.Add("RepeatCheckMajor")
            .Columns.Add("AlarmCriticalValue")
            .Columns.Add("RepeatCheckCritical")
        End With

        Dim dr As DataRow
        For i As Integer = 0 To gvDriveDetail.Rows.Count - 1
            Dim lblseq As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblseq"), Label)
            Dim lblDriveLetter As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblDriveLetter"), Label)
            Dim lblMinorValue As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblMinorValue"), Label)
            Dim lblMinorRepeatCheck As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblMinorRepeatCheck"), Label)
            Dim lblMajorValue As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblMajorValue"), Label)
            Dim lblMajorRepeatCheck As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblMajorRepeatCheck"), Label)
            Dim lblCriticalValue As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblCriticalValue"), Label)
            Dim lblCriticalRepeatCheck As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblCriticalRepeatCheck"), Label)
            If hidDriveDetailSeq.Value = lblseq.Text Then
                dr = dt.NewRow
                dr("seq") = i + 1
                dr("DriveLetter") = txtDriveLetter.Text
                dr("AlarmMinorValue") = minor_value
                dr("RepeatCheckMinor") = minor_repeat
                dr("AlarmMajorValue") = major_value
                dr("RepeatCheckMajor") = major_repeat
                dr("AlarmCriticalValue") = critical_value
                dr("RepeatCheckCritical") = critical_repeat
                dt.Rows.Add(dr)
            Else
                dr = dt.NewRow
                dr("seq") = i + 1
                dr("DriveLetter") = Replace(lblDriveLetter.Text, "&nbsp;", "")
                dr("AlarmMinorValue") = Replace(lblMinorValue.Text, "&nbsp;", "")
                dr("RepeatCheckMinor") = Replace(lblMinorRepeatCheck.Text, "&nbsp;", "")
                dr("AlarmMajorValue") = Replace(lblMajorValue.Text, "&nbsp;", "")
                dr("RepeatCheckMajor") = Replace(lblMajorRepeatCheck.Text, "&nbsp;", "")
                dr("AlarmCriticalValue") = Replace(lblCriticalValue.Text, "&nbsp;", "")
                dr("RepeatCheckCritical") = Replace(lblCriticalRepeatCheck.Text, "&nbsp;", "")
                dt.Rows.Add(dr)
            End If
        Next

        If hidDriveDetailSeq.Value = "" Then
            dr = dt.NewRow()
            dr("seq") = dt.Rows.Count + 1
            dr("DriveLetter") = txtDriveLetter.Text
            dr("AlarmMinorValue") = minor_value
            dr("RepeatCheckMinor") = minor_repeat
            dr("AlarmMajorValue") = major_value
            dr("RepeatCheckMajor") = major_repeat
            dr("AlarmCriticalValue") = critical_value
            dr("RepeatCheckCritical") = critical_repeat
            dt.Rows.Add(dr)
        End If

        gvDriveDetail.DataSource = dt
        gvDriveDetail.DataBind()

    End Sub

    Protected Sub imgEditDrive_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ClearDriveDetail()
        Dim img As ImageButton = sender
        Dim grv As GridViewRow = img.Parent.Parent
        Dim lblseq As Label = DirectCast(grv.FindControl("lblseq"), Label)
        Dim lblDriveLetter As Label = DirectCast(grv.FindControl("lblDriveLetter"), Label)
        Dim lblMinorValue As Label = DirectCast(grv.FindControl("lblMinorValue"), Label)
        Dim lblMinorRepeatCheck As Label = DirectCast(grv.FindControl("lblMinorRepeatCheck"), Label)
        Dim lblMajorValue As Label = DirectCast(grv.FindControl("lblMajorValue"), Label)
        Dim lblMajorRepeatCheck As Label = DirectCast(grv.FindControl("lblMajorRepeatCheck"), Label)
        Dim lblCriticalValue As Label = DirectCast(grv.FindControl("lblCriticalValue"), Label)
        Dim lblCriticalRepeatCheck As Label = DirectCast(grv.FindControl("lblCriticalRepeatCheck"), Label)

        hidDriveDetailSeq.Value = lblseq.Text
        txtDriveLetter.Text = lblDriveLetter.Text
        ctlConfigSeverityDrive.MinorValue = lblMinorValue.Text
        ctlConfigSeverityDrive.RepeatMinor = lblMinorRepeatCheck.Text
        ctlConfigSeverityDrive.MajorValue = lblMajorValue.Text
        ctlConfigSeverityDrive.RepeatMajor = lblMajorRepeatCheck.Text
        ctlConfigSeverityDrive.CriticalValue = lblCriticalValue.Text
        ctlConfigSeverityDrive.RepeatCritical = lblCriticalRepeatCheck.Text
        popAddDrive.Show()
    End Sub

    Protected Sub imgDeleteDrive_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim img As ImageButton = sender
        Dim grv As GridViewRow = img.Parent.Parent

        Dim seq As String = img.CommandArgument

        ClearDriveDetail()
        Dim dt As New DataTable
        With dt
            .Columns.Add("seq")
            .Columns.Add("DriveLetter")
            .Columns.Add("AlarmMinorValue")
            .Columns.Add("RepeatCheckMinor")
            .Columns.Add("AlarmMajorValue")
            .Columns.Add("RepeatCheckMajor")
            .Columns.Add("AlarmCriticalValue")
            .Columns.Add("RepeatCheckCritical")
        End With

        Dim dr As DataRow
        For i As Integer = 0 To gvDriveDetail.Rows.Count - 1
            Dim lblseq As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblseq"), Label)
            If seq <> lblseq.Text Then
                Dim lblDriveLetter As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblDriveLetter"), Label)
                Dim lblMinorValue As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblMinorValue"), Label)
                Dim lblMinorRepeatCheck As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblMinorRepeatCheck"), Label)
                Dim lblMajorValue As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblMajorValue"), Label)
                Dim lblMajorRepeatCheck As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblMajorRepeatCheck"), Label)
                Dim lblCriticalValue As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblCriticalValue"), Label)
                Dim lblCriticalRepeatCheck As Label = DirectCast(gvDriveDetail.Rows(i).FindControl("lblCriticalRepeatCheck"), Label)

                dr = dt.NewRow
                dr("seq") = dt.Rows.Count + 1
                dr("DriveLetter") = Replace(lblDriveLetter.Text, "&nbsp;", "")
                dr("AlarmMinorValue") = Replace(lblMinorValue.Text, "&nbsp;", "")
                dr("RepeatCheckMinor") = Replace(lblMinorRepeatCheck.Text, "&nbsp;", "")
                dr("AlarmMajorValue") = Replace(lblMajorValue.Text, "&nbsp;", "")
                dr("RepeatCheckMajor") = Replace(lblMajorRepeatCheck.Text, "&nbsp;", "")
                dr("AlarmCriticalValue") = Replace(lblCriticalValue.Text, "&nbsp;", "")
                dr("RepeatCheckCritical") = Replace(lblCriticalRepeatCheck.Text, "&nbsp;", "")
                dt.Rows.Add(dr)
            End If
        Next

        gvDriveDetail.DataSource = dt
        gvDriveDetail.DataBind()
    End Sub

#End Region

#Region "FileSize"

    Sub ClearFileSize()
        txtIDFileSize.Text = "0"
        CtlFileSizeConfig.IntervalMinute = ""
        CtlFileSizeConfig.ActiveStatus = "Y"
        CtlFileSizeConfig.CheckSun = "N"
        CtlFileSizeConfig.CheckMon = "N"
        CtlFileSizeConfig.CheckTue = "N"
        CtlFileSizeConfig.CheckWed = "N"
        CtlFileSizeConfig.CheckThu = "N"
        CtlFileSizeConfig.CheckFri = "N"
        CtlFileSizeConfig.CheckSat = "N"
        CtlFileSizeConfig.TimeFrom = ""
        CtlFileSizeConfig.TimeTo = ""
        CtlFileSizeConfig.AllDayEvent = "N"

        Dim dt As New DataTable
        With dt
            .Columns.Add("seq")
            .Columns.Add("FileName")
            .Columns.Add("FileSizeMinor")
            .Columns.Add("RepeatCheckMinor")
            .Columns.Add("FileSizeMajor")
            .Columns.Add("RepeatCheckMajor")
            .Columns.Add("FileSizeCritical")
            .Columns.Add("RepeatCheckCritical")
        End With
        gvFileSize.DataSource = dt
        gvFileSize.DataBind()
    End Sub

    Sub LoadFileSize(ServerIP As String, ServerName As String, MacAddress As String)
        Dim eng As New Engine.Web_Config.FileSizeENG
        Dim dt As New DataTable
        dt = eng.GetFileSize(ServerIP, ServerName, MacAddress)
        If dt.Rows.Count > 0 Then
            With dt
                txtIDFileSize.Text = .Rows(0)("ID").ToString
                CtlFileSizeConfig.IntervalMinute = IIf(.Rows(0)("CheckIntervalMinute").ToString = "0", "", .Rows(0)("CheckIntervalMinute").ToString)
                CtlFileSizeConfig.ActiveStatus = .Rows(0)("ActiveStatus").ToString
                CtlFileSizeConfig.CheckSun = .Rows(0)("AlarmSun").ToString
                CtlFileSizeConfig.CheckMon = .Rows(0)("AlarmMon").ToString
                CtlFileSizeConfig.CheckTue = .Rows(0)("AlarmTue").ToString
                CtlFileSizeConfig.CheckWed = .Rows(0)("AlarmWed").ToString
                CtlFileSizeConfig.CheckThu = .Rows(0)("AlarmThu").ToString
                CtlFileSizeConfig.CheckFri = .Rows(0)("AlarmFri").ToString
                CtlFileSizeConfig.CheckSat = .Rows(0)("AlarmSat").ToString
                CtlFileSizeConfig.TimeFrom = .Rows(0)("AlarmTimeFrom").ToString
                CtlFileSizeConfig.TimeTo = .Rows(0)("AlarmTimeTo").ToString
                CtlFileSizeConfig.AllDayEvent = .Rows(0)("AllDayEvent").ToString
            End With

            Dim dtdetail As New DataTable
            dtdetail = eng.GetFileSizeDetail(txtIDFileSize.Text)

            dtdetail.Columns.Add("seq")
            For i As Integer = 0 To dtdetail.Rows.Count - 1
                dtdetail.Rows(i)("seq") = i + 1
            Next

            gvFileSize.DataSource = dtdetail
            gvFileSize.DataBind()
        Else
            ClearFileSize()
        End If
    End Sub

    Protected Sub btnAddPathFileSize_Click(sender As Object, e As EventArgs) Handles btnAddPathFileSize.Click
        popAddFileSize.Show()
    End Sub

    Protected Sub btnAddFileSize_Click(sender As Object, e As EventArgs) Handles btnAddFileSize.Click
        ClearFileSizeDetail()
        popAddFileSize.Show()
    End Sub

    Protected Sub btnCancelFileSize_Click(sender As Object, e As EventArgs) Handles btnCancelFileSize.Click
        popAddFileSize.Hide()
    End Sub

    Protected Sub btnSaveFileSize_Click(sender As Object, e As EventArgs) Handles btnSaveFileSize.Click
        If ValidateFileSizeDetail() Then
            AddFileSize()
            popAddFileSize.Hide()
        Else
            popAddFileSize.Show()
        End If
    End Sub

    Sub ClearFileSizeDetail()
        txtFilePath.Text = ""
        ctlConfigSeverityFileSize.MinorValue = ""
        ctlConfigSeverityFileSize.RepeatMinor = ""
        ctlConfigSeverityFileSize.MajorValue = ""
        ctlConfigSeverityFileSize.RepeatMajor = ""
        ctlConfigSeverityFileSize.CriticalValue = ""
        ctlConfigSeverityFileSize.RepeatCritical = ""
        lblErrorFileSize.Text = ""
        hidFileSizeDetailSeq.Value = ""
    End Sub

    Function ValidateFileSizeDetail() As Boolean
        Dim minor_value As String = ctlConfigSeverityFileSize.MinorValue
        Dim minor_repeat As String = ctlConfigSeverityFileSize.RepeatMinor
        Dim major_value As String = ctlConfigSeverityFileSize.MajorValue
        Dim major_repeat As String = ctlConfigSeverityFileSize.RepeatMajor
        Dim critical_value As String = ctlConfigSeverityFileSize.CriticalValue
        Dim critical_repeat As String = ctlConfigSeverityFileSize.RepeatCritical

        lblErrorFileSize.Text = ""
        If txtFilePath.Text = "" Then
            lblErrorFileSize.Text = "Please, Specify File Path !"
            Return False
        End If
        If minor_value = "0" Then
            lblErrorFileSize.Text = "Please, Specify Minor Value !"
            Return False
        End If

        If major_value = "0" Then
            lblErrorFileSize.Text = "Please, Specify Major Value !"
            Return False
        End If

        If critical_value = "0" Then
            lblErrorFileSize.Text = "Please, Specify Critical Value !"
            Return False
        End If

        If minor_repeat = "0" Then
            lblErrorFileSize.Text = "Please, Specify Repeat Minor !"
            Return False
        End If

        If major_repeat = "0" Then
            lblErrorFileSize.Text = "Please, Specify Repeat Major !"
            Return False
        End If

        If critical_repeat = "0" Then
            lblErrorFileSize.Text = "Please, Specify Repeat Critical !"
            Return False
        End If

        For i As Integer = 0 To gvFileSize.Rows.Count - 1
            Dim lblseq As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblseq"), Label)
            Dim lblFilePath As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblFilePath"), Label)
            If lblFilePath.Text = txtFilePath.Text And hidFileSizeDetailSeq.Value <> lblseq.Text Then
                lblErrorFileSize.Text = "This File is already exist!"
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub AddFileSize()
        Dim minor_value As String = ctlConfigSeverityFileSize.MinorValue
        Dim minor_repeat As String = ctlConfigSeverityFileSize.RepeatMinor
        Dim major_value As String = ctlConfigSeverityFileSize.MajorValue
        Dim major_repeat As String = ctlConfigSeverityFileSize.RepeatMajor
        Dim critical_value As String = ctlConfigSeverityFileSize.CriticalValue
        Dim critical_repeat As String = ctlConfigSeverityFileSize.RepeatCritical

        Dim dt As New DataTable
        With dt
            .Columns.Add("seq")
            .Columns.Add("FileName")
            .Columns.Add("FileSizeMinor")
            .Columns.Add("RepeatCheckMinor")
            .Columns.Add("FileSizeMajor")
            .Columns.Add("RepeatCheckMajor")
            .Columns.Add("FileSizeCritical")
            .Columns.Add("RepeatCheckCritical")
        End With

        Dim dr As DataRow
        For i As Integer = 0 To gvFileSize.Rows.Count - 1
            Dim lblseq As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblseq"), Label)
            Dim lblFilePath As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblFilePath"), Label)
            Dim lblMinorValue As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblMinorValue"), Label)
            Dim lblMinorRepeatCheck As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblMinorRepeatCheck"), Label)
            Dim lblMajorValue As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblMajorValue"), Label)
            Dim lblMajorRepeatCheck As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblMajorRepeatCheck"), Label)
            Dim lblCriticalValue As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblCriticalValue"), Label)
            Dim lblCriticalRepeatCheck As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblCriticalRepeatCheck"), Label)
            If hidFileSizeDetailSeq.Value = lblseq.Text Then
                dr = dt.NewRow
                dr("seq") = i + 1
                dr("FileName") = txtFilePath.Text
                dr("FileSizeMinor") = minor_value
                dr("RepeatCheckMinor") = minor_repeat
                dr("FileSizeMajor") = major_value
                dr("RepeatCheckMajor") = major_repeat
                dr("FileSizeCritical") = critical_value
                dr("RepeatCheckCritical") = critical_repeat
                dt.Rows.Add(dr)
            Else
                dr = dt.NewRow
                dr("seq") = i + 1
                dr("FileName") = Replace(lblFilePath.Text, "&nbsp;", "")
                dr("FileSizeMinor") = Replace(lblMinorValue.Text, "&nbsp;", "")
                dr("RepeatCheckMinor") = Replace(lblMinorRepeatCheck.Text, "&nbsp;", "")
                dr("FileSizeMajor") = Replace(lblMajorValue.Text, "&nbsp;", "")
                dr("RepeatCheckMajor") = Replace(lblMajorRepeatCheck.Text, "&nbsp;", "")
                dr("FileSizeCritical") = Replace(lblCriticalValue.Text, "&nbsp;", "")
                dr("RepeatCheckCritical") = Replace(lblCriticalRepeatCheck.Text, "&nbsp;", "")
                dt.Rows.Add(dr)
            End If
        Next

        If hidFileSizeDetailSeq.Value = "" Then
            dr = dt.NewRow()
            dr("seq") = dt.Rows.Count + 1
            dr("FileName") = txtFilePath.Text
            dr("FileSizeMinor") = minor_value
            dr("RepeatCheckMinor") = minor_repeat
            dr("FileSizeMajor") = major_value
            dr("RepeatCheckMajor") = major_repeat
            dr("FileSizeCritical") = critical_value
            dr("RepeatCheckCritical") = critical_repeat
            dt.Rows.Add(dr)
        End If

        gvFileSize.DataSource = dt
        gvFileSize.DataBind()

    End Sub

    Protected Sub imgEditFileSize_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ClearFileSizeDetail()
        Dim img As ImageButton = sender
        Dim grv As GridViewRow = img.Parent.Parent
        Dim lblseq As Label = DirectCast(grv.FindControl("lblseq"), Label)
        Dim lblFilePath As Label = DirectCast(grv.FindControl("lblFilePath"), Label)
        Dim lblMinorValue As Label = DirectCast(grv.FindControl("lblMinorValue"), Label)
        Dim lblMinorRepeatCheck As Label = DirectCast(grv.FindControl("lblMinorRepeatCheck"), Label)
        Dim lblMajorValue As Label = DirectCast(grv.FindControl("lblMajorValue"), Label)
        Dim lblMajorRepeatCheck As Label = DirectCast(grv.FindControl("lblMajorRepeatCheck"), Label)
        Dim lblCriticalValue As Label = DirectCast(grv.FindControl("lblCriticalValue"), Label)
        Dim lblCriticalRepeatCheck As Label = DirectCast(grv.FindControl("lblCriticalRepeatCheck"), Label)

        hidFileSizeDetailSeq.Value = lblseq.Text
        txtFilePath.Text = lblFilePath.Text
        ctlConfigSeverityFileSize.MinorValue = lblMinorValue.Text
        ctlConfigSeverityFileSize.RepeatMinor = lblMinorRepeatCheck.Text
        ctlConfigSeverityFileSize.MajorValue = lblMajorValue.Text
        ctlConfigSeverityFileSize.RepeatMajor = lblMajorRepeatCheck.Text
        ctlConfigSeverityFileSize.CriticalValue = lblCriticalValue.Text
        ctlConfigSeverityFileSize.RepeatCritical = lblCriticalRepeatCheck.Text
        popAddFileSize.Show()
    End Sub

    Protected Sub imgDeleteFileSize_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim img As ImageButton = sender
        Dim grv As GridViewRow = img.Parent.Parent
        Dim seq As String = img.CommandArgument

        ClearFileSizeDetail()
        Dim dt As New DataTable
        With dt
            .Columns.Add("seq")
            .Columns.Add("FileName")
            .Columns.Add("FileSizeMinor")
            .Columns.Add("RepeatCheckMinor")
            .Columns.Add("FileSizeMajor")
            .Columns.Add("RepeatCheckMajor")
            .Columns.Add("FileSizeCritical")
            .Columns.Add("RepeatCheckCritical")
        End With

        Dim dr As DataRow
        For i As Integer = 0 To gvFileSize.Rows.Count - 1
            Dim lblseq As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblseq"), Label)
            If seq <> lblseq.Text Then
                Dim lblFilePath As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblFilePath"), Label)
                Dim lblMinorValue As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblMinorValue"), Label)
                Dim lblMinorRepeatCheck As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblMinorRepeatCheck"), Label)
                Dim lblMajorValue As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblMajorValue"), Label)
                Dim lblMajorRepeatCheck As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblMajorRepeatCheck"), Label)
                Dim lblCriticalValue As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblCriticalValue"), Label)
                Dim lblCriticalRepeatCheck As Label = DirectCast(gvFileSize.Rows(i).FindControl("lblCriticalRepeatCheck"), Label)

                dr = dt.NewRow
                dr("seq") = dt.Rows.Count + 1
                dr("FileName") = Replace(lblFilePath.Text, "&nbsp;", "")
                dr("FileSizeMinor") = Replace(lblMinorValue.Text, "&nbsp;", "")
                dr("RepeatCheckMinor") = Replace(lblMinorRepeatCheck.Text, "&nbsp;", "")
                dr("FileSizeMajor") = Replace(lblMajorValue.Text, "&nbsp;", "")
                dr("RepeatCheckMajor") = Replace(lblMajorRepeatCheck.Text, "&nbsp;", "")
                dr("FileSizeCritical") = Replace(lblCriticalValue.Text, "&nbsp;", "")
                dr("RepeatCheckCritical") = Replace(lblCriticalRepeatCheck.Text, "&nbsp;", "")
                dt.Rows.Add(dr)
            End If
        Next

        gvFileSize.DataSource = dt
        gvFileSize.DataBind()
    End Sub
#End Region

#Region "Port"

    Sub ClearPort()
        txtIDPort.Text = "0"
        CtlPortConfig.IntervalMinute = ""
        CtlPortConfig.ActiveStatus = "Y"
        CtlPortConfig.CheckSun = "N"
        CtlPortConfig.CheckMon = "N"
        CtlPortConfig.CheckTue = "N"
        CtlPortConfig.CheckWed = "N"
        CtlPortConfig.CheckThu = "N"
        CtlPortConfig.CheckFri = "N"
        CtlPortConfig.CheckSat = "N"
        CtlPortConfig.TimeFrom = ""
        CtlPortConfig.TimeTo = ""
        CtlPortConfig.AllDayEvent = "N"
        CtlPortConfig.EnableInterval = False

        Dim dt As New DataTable
        With dt
            .Columns.Add("seq")
            .Columns.Add("PortNumber")
            .Columns.Add("RepeatCheck")
        End With
        gvPort.DataSource = dt
        gvPort.DataBind()
    End Sub

    Sub LoadPort(ServerIP As String, ServerName As String, MacAddress As String)
        Dim eng As New Engine.Web_Config.PortEng
        Dim dt As New DataTable
        dt = eng.GetPort(ServerIP, ServerName, MacAddress)
        If dt.Rows.Count > 0 Then
            With dt
                txtIDPort.Text = .Rows(0)("ID").ToString
                'CtlPortConfig.IntervalMinute = ("CheckIntervalMinute").ToString
                CtlPortConfig.ActiveStatus = .Rows(0)("ActiveStatus").ToString
                CtlPortConfig.CheckSun = .Rows(0)("AlarmSun").ToString
                CtlPortConfig.CheckMon = .Rows(0)("AlarmMon").ToString
                CtlPortConfig.CheckTue = .Rows(0)("AlarmTue").ToString
                CtlPortConfig.CheckWed = .Rows(0)("AlarmWed").ToString
                CtlPortConfig.CheckThu = .Rows(0)("AlarmThu").ToString
                CtlPortConfig.CheckFri = .Rows(0)("AlarmFri").ToString
                CtlPortConfig.CheckSat = .Rows(0)("AlarmSat").ToString
                CtlPortConfig.TimeFrom = .Rows(0)("AlarmTimeFrom").ToString
                CtlPortConfig.TimeTo = .Rows(0)("AlarmTimeTo").ToString
                CtlPortConfig.AllDayEvent = .Rows(0)("AllDayEvent").ToString
            End With

            Dim dtdetail As New DataTable
            dtdetail = eng.GetPortDetail(txtIDPort.Text)

            dtdetail.Columns.Add("seq")
            For i As Integer = 0 To dtdetail.Rows.Count - 1
                dtdetail.Rows(i)("seq") = i + 1
            Next

            gvPort.DataSource = dtdetail
            gvPort.DataBind()
        Else
            ClearPort()
        End If

    End Sub


    Protected Sub btnAddPort_Click(sender As Object, e As EventArgs) Handles btnAddPort.Click
        ClearPortDetail()
        PopAddPort.Show()
    End Sub

    Protected Sub btnCancelPort_Click(sender As Object, e As EventArgs) Handles BtnCancelPort.Click
        PopAddPort.Hide()
    End Sub

    Protected Sub btnSavePort_Click(sender As Object, e As EventArgs) Handles btnSavePort.Click
        If ValidatePortDetail() Then
            AddPort()
            PopAddPort.Hide()
        Else
            PopAddPort.Show()
        End If

    End Sub

    Sub ClearPortDetail()
        txtPortNo.Text = ""
        txtRepeatCheck.Text = ""
        lblErrorPort.Text = ""
        hidPortDetailSeq.Value = ""
    End Sub

    Function ValidatePortDetail() As Boolean

        lblErrorPort.Text = ""
        If txtPortNo.Text = "" Then
            lblErrorPort.Text = "Please, Specify Port No !"
            Return False
        End If
        If txtRepeatCheck.Text = "" Then
            lblErrorPort.Text = "Please, Specify Repeat Check !"
            Return False
        End If

        For i As Integer = 0 To gvPort.Rows.Count - 1
            Dim lblseq As Label = DirectCast(gvPort.Rows(i).FindControl("lblseq"), Label)
            Dim lblPortNo As Label = DirectCast(gvPort.Rows(i).FindControl("lblPortNo"), Label)
            If lblPortNo.Text = txtPortNo.Text And hidPortDetailSeq.Value <> lblseq.Text Then
                lblErrorPort.Text = "This Port No is already exist!"
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub AddPort()

        Dim dt As New DataTable
        With dt
            .Columns.Add("seq")
            .Columns.Add("PortNumber")
            .Columns.Add("RepeatCheck")
        End With

        Dim dr As DataRow
        For i As Integer = 0 To gvPort.Rows.Count - 1
            Dim lblseq As Label = DirectCast(gvPort.Rows(i).FindControl("lblseq"), Label)
            Dim lblPortNo As Label = DirectCast(gvPort.Rows(i).FindControl("lblPortNo"), Label)
            Dim lblRepeatCheck As Label = DirectCast(gvPort.Rows(i).FindControl("lblRepeatCheck"), Label)
            If hidPortDetailSeq.Value = lblseq.Text Then
                dr = dt.NewRow
                dr("seq") = i + 1
                dr("PortNumber") = lblPortNo.Text
                dr("RepeatCheck") = txtRepeatCheck.Text
                dt.Rows.Add(dr)
            Else
                dr = dt.NewRow
                dr("seq") = i + 1
                dr("PortNumber") = Replace(lblPortNo.Text, "&nbsp;", "")
                dr("RepeatCheck") = Replace(lblRepeatCheck.Text, "&nbsp;", "")
                dt.Rows.Add(dr)
            End If
        Next

        If hidPortDetailSeq.Value = "" Then
            dr = dt.NewRow()
            dr("seq") = dt.Rows.Count + 1
            dr("PortNumber") = txtPortNo.Text
            dr("RepeatCheck") = txtRepeatCheck.Text
            dt.Rows.Add(dr)
        End If

        gvPort.DataSource = dt
        gvPort.DataBind()

    End Sub

    Protected Sub imgEditPort_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ClearPortDetail()
        Dim img As ImageButton = sender
        Dim grv As GridViewRow = img.Parent.Parent
        Dim lblseq As Label = DirectCast(grv.FindControl("lblseq"), Label)
        Dim lblPortNo As Label = DirectCast(grv.FindControl("lblPortNo"), Label)
        Dim lblRepeatCheck As Label = DirectCast(grv.FindControl("lblRepeatCheck"), Label)

        hidPortDetailSeq.Value = lblseq.Text
        txtPortNo.Text = lblPortNo.Text
        txtRepeatCheck.Text = lblRepeatCheck.Text
        PopAddPort.Show()
    End Sub

    Protected Sub imgDeletePort_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim img As ImageButton = sender
        Dim grv As GridViewRow = img.Parent.Parent

        Dim seq As String = img.CommandArgument

        ClearPortDetail()
        Dim dt As New DataTable
        With dt
            .Columns.Add("seq")
            .Columns.Add("PortNumber")
            .Columns.Add("RepeatCheck")
        End With

        Dim dr As DataRow
        For i As Integer = 0 To gvPort.Rows.Count - 1
            Dim lblseq As Label = DirectCast(gvPort.Rows(i).FindControl("lblseq"), Label)
            If seq <> lblseq.Text Then
                Dim lblPortNo As Label = DirectCast(gvPort.Rows(i).FindControl("lblPortNo"), Label)
                Dim lblRepeatCheck As Label = DirectCast(gvPort.Rows(i).FindControl("lblRepeatCheck"), Label)

                dr = dt.NewRow
                dr("seq") = dt.Rows.Count + 1
                dr("PortNumber") = Replace(lblPortNo.Text, "&nbsp;", "")
                dr("RepeatCheck") = Replace(lblRepeatCheck.Text, "&nbsp;", "")
                dt.Rows.Add(dr)
            End If
        Next

        gvPort.DataSource = dt
        gvPort.DataBind()
    End Sub
#End Region


  
End Class

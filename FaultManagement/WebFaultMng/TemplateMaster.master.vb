Imports System
Imports System.Data
Imports System.Linq
Imports Engine
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE


Partial Class TemplateMaster
    Inherits System.Web.UI.MasterPage

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim Leng As New Web_Config.LoginENG
    '    Leng.Logout(Globals.uData.LOGIN_HISTORY_ID)
    '    Response.Redirect("frmLogin.aspx")

    'End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click

        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Yes" Then

            Dim Leng As New Web_Config.LoginENG
            Leng.Logout(Globals.uData.LOGIN_HISTORY_ID)
            Response.Redirect("frmLogin.aspx")
            
        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim trans As New TransactionDB
        Dim lnq As New TbUserLinqDB

        'Label1.Text = Globals.uData.USERNAME
        Label1.Text = Session("Username")

        If Not IsPostBack Then
            Dim idres1 As String = Session("idres1")
            Dim idres2 As String = Session("idres2")
            Dim idres3 As String = Session("idres3")
            Dim idres4 As String = Session("idres4")
            Dim idres5 As String = Session("idres5")
            Dim idres6 As String = Session("idres6")

            If idres1 = "1" Then
                btnSetting.Enabled = True
                btnOverview.Enabled = True
                btnRegister.Enabled = True
            End If
            If idres2 = "2" Then
                btnOverview.Enabled = True
                btnAlarm.Enabled = True
                btnHistory.Enabled = True
            End If
            If idres3 = "3" Then
                btnOverview.Enabled = True
                btnAlarm.Enabled = True
                btnHistory.Enabled = True
            End If
            If idres4 = "4" Then
                btnOverview.Enabled = True
                btnAdmin.Enabled = True
                btnRegister.Enabled = True
            End If
            If idres5 = "5" Then
                btnOverview.Enabled = True
                btnSetting.Enabled = True
                btnRegister.Enabled = True
            End If

            If idres6 = "6" Then
                btnOverview.Enabled = True
                btnSetting.Enabled = True
                btnRegister.Enabled = True
            End If


        End If

        If btnOverview.Enabled = True Then
            btnOverview.ImageUrl = "Images/icon_Overview.png"
        End If
        If btnSetting.Enabled = True Then
            btnSetting.ImageUrl = "Images/icon_Setting.png"
        End If
        If btnAlarm.Enabled = True Then
            btnAlarm.ImageUrl = "Images/icon_Alarm.png"
        End If
        If btnHistory.Enabled = True Then
            btnHistory.ImageUrl = "Images/icon_History.png"
        End If
        If btnAdmin.Enabled = True Then
            btnAdmin.ImageUrl = "~/Images/icon_Admin.png"
        End If
        If btnRegister.Enabled = True Then
            btnRegister.ImageUrl = "~/Images/icon_fRegister.png"
        End If

       
    End Sub

    Protected Sub btnOverview_Click(sender As Object, e As ImageClickEventArgs) Handles btnOverview.Click

        If btnOverview.Enabled = True Then
            Response.Redirect("frmOverview.aspx")

        End If

    End Sub

    Protected Sub btnSetting_Click(sender As Object, e As ImageClickEventArgs) Handles btnSetting.Click

        If btnSetting.Enabled = True Then
            Response.Redirect("frmConfig.aspx")
        End If

    End Sub

    Protected Sub btnAlarm_Click(sender As Object, e As ImageClickEventArgs) Handles btnAlarm.Click

        If btnAlarm.Enabled = True Then
            Response.Redirect("frmAlarm.aspx")
        End If

    End Sub

    Protected Sub btnHistory_Click(sender As Object, e As ImageClickEventArgs) Handles btnHistory.Click

        If btnHistory.Enabled = True Then
            Response.Redirect("frmHistory.aspx")
        End If

    End Sub

    Protected Sub btnAdmin_Click(sender As Object, e As ImageClickEventArgs) Handles btnAdmin.Click

        If btnAdmin.Enabled = True Then
            Response.Redirect("frmAdmin.aspx")
        End If

    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As ImageClickEventArgs) Handles btnRegister.Click
        If btnRegister.Enabled = True Then
            Response.Redirect("frmRegister.aspx")
        End If
    End Sub
End Class


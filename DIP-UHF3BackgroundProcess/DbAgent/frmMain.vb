Imports System.Data
Imports System.Data.SqlClient
Imports DbAgent.Org.Mentalis.Files

Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text &= " v" & getVersion()
        Me.WindowState = FormWindowState.Maximized
        loadDBINI()
        loadFrmDBA()
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Tabs.Refresh()
    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest1.Click
        GroupBox1.Enabled = False
        Dim cn As New SqlConnection()
        Try
            cn.ConnectionString = formatConnectionString(txtserver1.Text, txtDatabase1.Text, txtUsername1.Text, txtPassword1.Text)
            cn.Open()
            Dim ini As New IniReader(INIfName)
            ini.Section = "DIP"
            ini.Write("Server1", txtserver1.Text)
            ini.Write("Database1", txtDatabase1.Text)
            ini.Write("Username1", txtUsername1.Text)
            ini.Write("Password1", txtPassword1.Text)
            MessageBox.Show(Me, "Configurations has been saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            StrconnInnova = formatConnectionString(txtserver1.Text, txtDatabase1.Text, txtUsername1.Text, txtPassword1.Text)
        Catch ex As Exception
            MsgBox("Problem with one of the database connection." & Environment.NewLine & ex.Message, MsgBoxStyle.Exclamation, "Failed")
        End Try
        cn.Dispose()
        GroupBox1.Enabled = True
    End Sub

    Sub loadFrmDBA()
        frmDBA.MdiParent = Me
        frmDBA.Show()
    End Sub

    Private Sub btnDBA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDBA.Click
        frmDBA.MdiParent = Me
        frmDBA.Show()
    End Sub


    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Application.Exit()
    End Sub

    Private Sub btnSideBySide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSideBySide.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub btnStacked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStacked.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub btnCascade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Public Sub loadDBINI()
        'Dim INIfName As String = Windows.Forms.Application.StartupPath & "\qagent.ini"
        If Dir(INIfName) <> "" Then
            Dim ini As New IniReader(INIfName)
            ini.Section = "DIP"
            txtserver1.Text = ini.ReadString("Server1")
            txtDatabase1.Text = ini.ReadString("Database1")
            txtUsername1.Text = ini.ReadString("Username1")
            txtPassword1.Text = ini.ReadString("Password1")
            txtserver2.Text = ini.ReadString("Server2")
            txtDatabase2.Text = ini.ReadString("Database2")
            txtUsername2.Text = ini.ReadString("Username2")
            txtPassword2.Text = ini.ReadString("Password2")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest2.Click
        GroupBox1.Enabled = False
        Dim cn As New SqlConnection()
        Try
            cn.ConnectionString = formatConnectionString(txtserver2.Text, txtDatabase2.Text, txtUsername2.Text, txtPassword2.Text)
            cn.Open()

            Dim ini As New IniReader(INIfName)
            ini.Section = "DIP"
            ini.Write("Server2", txtserver2.Text)
            ini.Write("Database2", txtDatabase2.Text)
            ini.Write("Username2", txtUsername2.Text)
            ini.Write("Password2", txtPassword2.Text)
            MessageBox.Show(Me, "Configurations has been saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            StrconnScore = formatConnectionString(txtserver2.Text, txtDatabase2.Text, txtUsername2.Text, txtPassword2.Text)
        Catch ex As Exception
            MsgBox("Problem with one of the database connection." & Environment.NewLine & ex.Message, MsgBoxStyle.Exclamation, "Failed")
        End Try
        cn.Dispose()
        GroupBox1.Enabled = True
    End Sub
End Class

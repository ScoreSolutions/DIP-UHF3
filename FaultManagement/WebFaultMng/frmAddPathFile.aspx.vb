Imports Engine
Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.IO
Imports Globals
Partial Class frmAddPathFile
    Inherits System.Web.UI.Page

    Dim serverip As String = ""


    Private Sub LoadTempPath(FilePath As String, LoginHisID As Long)
        Try
            Dim lnq As New TbLoadTempPathLinqDB
            lnq.ChkDataByTS_LOGIN_HISTORY_ID(LoginHisID, Nothing)

            lnq.SERVERIP = lblServerip.Text
            lnq.PATHFILE = FilePath
            lnq.TS_LOGIN_HISTORY_ID = LoginHisID
            lnq.STATUS = "N"

            Dim ret As Boolean = False
            Dim trans As New TransactionDB
            If lnq.ID > 0 Then
                ret = lnq.UpdateByPK("frmAddPathFile.LoadTempPath", trans.Trans)
            Else
                ret = lnq.InsertData("frmAddPathFile.LoadTempPath", trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing
        Catch ex As Exception
            Engine.Common.FunctionEng.CreateErrorLog("frmAddPath", "LoadTempPath", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid.ToString, "alert('" & Request.QueryString("serverip") & "');", True)
      
        If Not IsPostBack Then

            serverip = Request.QueryString("serverip")
            lblServerip.Text = serverip

            lblMacAddress.Text = Request.QueryString("macaddress")

            lblLoginHistoryID.Text = Session("LoginHistoryID")
            TEMPFILEeng.DeleteAllTempFile(lblServerip.Text)
            LoadTempPath("ROOT", lblLoginHistoryID.Text)
            SetDDLDrive()
            Image1.Visible = False
        End If
    End Sub


    Public Sub SetDDLDrive()

        Dim dt As DataTable
        Dim Deng As New DriveENG
        Dim cf As New Config

        dt = Deng.ddlDriverName("MacAddress ='" & lblMacAddress.Text & "'")
        cf.SetDDLData(dt, ddlDriveNameFile, "DriveLetter", "DriveLetter", "<-- Select -->", "")
        Deng = Nothing

    End Sub

  
    Protected Sub ddlDriveNameFile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDriveNameFile.SelectedIndexChanged
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "hide", " hide();", True)
        Image1.Visible = True

        Dim dt As DataTable = TEMPFILEeng.GetFileListOnDrive(ddlDriveNameFile.SelectedValue, lblLoginHistoryID.Text)
        If dt.Rows.Count > 0 Then
            gvSelectPahtFile.DataSource = dt
            gvSelectPahtFile.DataBind()

            lblPathFile.Text = ddlDriveNameFile.SelectedValue & ":\"
        Else
            TEMPFILEeng.DeleteAllTempFile(lblServerip.Text)

            Dim PathFile As String = ddlDriveNameFile.SelectedValue & ":\"
            LoadTempPath(PathFile, lblLoginHistoryID.Text)
            Do

            Loop Until TEMPFILEeng.CheckLoadPathFile(PathFile, lblLoginHistoryID.Text) = "True"

            dt = TEMPFILEeng.getgvPathFile(PathFile, lblLoginHistoryID.Text)
            If dt.Rows.Count > 0 Then
                gvSelectPahtFile.DataSource = dt
                gvSelectPahtFile.DataBind()

                lblPathFile.Text = PathFile
            End If
        End If
        dt.Dispose()
        Image1.Visible = False
    End Sub

    Protected Sub gvSelectPahtFile_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvSelectPahtFile.RowCommand
        If e.CommandName = "PathFile" Then
            Dim ComAgr() As String = Split(e.CommandArgument, "##")
            Dim PathFile As String = ComAgr(0)
            Dim DisplayType As String = ComAgr(1)

            If DisplayType = "Folder" Then
                Image1.Visible = True
                LoadTempPath(PathFile, lblLoginHistoryID.Text)
                Do

                Loop Until TEMPFILEeng.CheckLoadPathFile(PathFile, lblLoginHistoryID.Text) = "True"

                Dim dt As DataTable = TEMPFILEeng.getgvPathFile(PathFile, lblLoginHistoryID.Text)
                If dt.Rows.Count > 0 Then
                    gvSelectPahtFile.DataSource = dt
                    gvSelectPahtFile.DataBind()

                    lblPathFile.Text = PathFile & "\"
                End If
                dt.Dispose()

                btnBack.Visible = True
            Else
                Session("PathFile") = PathFile
                ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "window.close();", True)
            End If
        End If
        Image1.Visible = False
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnBack.Click
        Image1.Visible = True

        If lblPathFile.Text.Trim <> "" Then
            Dim vSlash() As String = Split(lblPathFile.Text, "\")
            If vSlash.Length > 2 Then
                TEMPFILEeng.DeleteAllTempFile(lblServerip.Text)

                Dim PathFile As String = lblPathFile.Text.Substring(0, lblPathFile.Text.Length - vSlash(vSlash.Length - 2).Length - 1)
                lblPathFile.Text = PathFile
                LoadTempPath(PathFile, lblLoginHistoryID.Text)
                Do

                Loop Until TEMPFILEeng.CheckLoadPathFile(PathFile, lblLoginHistoryID.Text) = "True"

                Dim dt As DataTable = TEMPFILEeng.getgvPathFile(PathFile, lblLoginHistoryID.Text)
                If dt.Rows.Count > 0 Then
                    gvSelectPahtFile.DataSource = dt
                    gvSelectPahtFile.DataBind()

                    If PathFile.EndsWith("\") = True Then
                        lblPathFile.Text = PathFile
                    Else
                        lblPathFile.Text = PathFile & "\"
                    End If
                End If
                dt.Dispose()
            End If
            If Split(lblPathFile.Text, "\").Length = 2 Then
                btnBack.Visible = False
            End If
        Else
            btnBack.Visible = False
        End If

        
        Image1.Visible = False
    End Sub
End Class

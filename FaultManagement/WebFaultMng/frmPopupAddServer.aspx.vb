Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Script.Services

Partial Class frmPopupAddServer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsPostBack = False Then

            Dim dt As New DataTable
            Dim UEng As New UserEng

            dt = UEng.GetgvServer("")

            If dt.Rows.Count > 0 Then
                SetgvServer()
            Else
                btnSave.Visible = False
                lblShow.Visible = True
            End If

        End If

    End Sub

    Private Sub SetgvServer()

        Dim dt As DataTable
        Dim UEng As New UserEng

        dt = UEng.GetgvServer("")

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvServer.DataSource = dt
            gvServer.DataBind()

        Else
            gvServer.DataSource = Nothing
        End If

    End Sub

    Private Function ValidateChk() As Boolean

        Dim chk As Boolean = False
        For j As Integer = 0 To gvServer.Rows.Count - 1
            Dim chkServer As CheckBox = DirectCast(gvServer.Rows(j).FindControl("ChkServer"), CheckBox)
            If chkServer.Checked = True Then
                chk = True
            End If
        Next
        If chk = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please, Select Server !');", True)
            Return False
        End If

        Return True

        Return ValidateChk()
    End Function

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If ValidateChk() = False Then
            Return
        End If

        For i As Integer = 0 To gvServer.Rows.Count - 1

            Dim lnq As New TbRegisterLinqDB
            Dim trans As New TransactionDB
            Dim ret As Boolean = False
            Dim idGroup As String = Session("idGroup")
            Dim chkServer As CheckBox = DirectCast(gvServer.Rows(i).FindControl("ChkServer"), CheckBox)

            If chkServer.Checked = True Then

                Dim lblID As Label = DirectCast(gvServer.Rows(i).FindControl("LabelID"), Label)
                lnq.GetDataByPK(lblID.Text, trans.Trans)

                lnq.GROUP_ID = idGroup.ToString()

                If (lnq.ID > 0) Then
                    ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)
                End If

                If ret = True Then

                    trans.CommitTransaction()
                    Session("SaveServer") = True

                Else
                    trans.RollbackTransaction()
                    'ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not save data !');", True)
                End If

            End If
            lnq = Nothing
        Next
        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Save data Complete !');", True)
        SetgvServer()
        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "window.close();", True)

    End Sub

    

End Class

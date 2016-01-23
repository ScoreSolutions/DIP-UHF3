Imports Engine
Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.IO
Imports Globals
Partial Class frmPopupSerchIP
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
       
        If Not IsPostBack Then
            GetgvIP()
        End If
    End Sub


    Protected Sub btnSerch_Click(sender As Object, e As EventArgs) Handles btnSerch.Click
        Dim dt As New DataTable
        Dim eng As New Web_Config.RAMEng

        dt = eng.gvByServerName("ServerIP like '%" & txtServerip.Text & "%'")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvServerIP.DataSource = dt
            gvServerIP.DataBind()
        End If

    End Sub

    Public Sub GetgvIP()
        Dim dt As New DataTable
        Dim eng As New Web_Config.RAMEng

        Dim Id As String = ""
        Dim valueOfArg As String = Page.Request.QueryString("Arg")

        Select Case Convert.ToInt64(valueOfArg)
            Case 1
                Id = chkRAM("")
            Case 2
                Id = chkCPU("")
            Case 3
                Id = chkDrive("")
            Case 4
                Id = chkService("")
            Case 5
                Id = chkProcess("")
            Case 6
                Id = chkFileSize("")
            Case 7
                Id = chkPort("")
        End Select
      
        dt = eng.gvByServerName(Id)



        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvServerIP.DataSource = dt
            gvServerIP.DataBind()
        End If
    End Sub

    Public Function chkRAM(ByVal id As String) As String
        Dim dt As New DataTable
        Dim eng As New Web_Config.RAMEng
        dt = eng.GetgvRAM("")


        For i As Integer = 0 To dt.Rows.Count - 1
            id += dt.Rows(i)("id").ToString & ","
        Next

        If id <> "" Then
            id = id.Substring(0, id.Length - 1)
            id = "id not in (" & id & ")"
        End If

        


        Return id
    End Function

    Public Function chkCPU(ByVal id As String) As String
        Dim dt As New DataTable
        Dim eng As New Web_Config.CPUEng
        dt = eng.GetgvCPU("")

        For i As Integer = 0 To dt.Rows.Count - 1
            id += dt.Rows(i)("idRes").ToString & ","
        Next

        If id <> "" Then
            id = id.Substring(0, id.Length - 1)
            id = "id not in (" & id & ")"
        End If

        Return id
    End Function

    Public Function chkDrive(ByVal id As String) As String
        Dim dt As New DataTable
        Dim eng As New Web_Config.DriveENG
        dt = eng._GetgvDrive("")

        For i As Integer = 0 To dt.Rows.Count - 1
            id += dt.Rows(i)("idRegis").ToString & ","
        Next

        If id <> "" Then
            id = id.Substring(0, id.Length - 1)
            id = "id not in (" & id & ")"
        End If

        Return id
    End Function

    Public Function chkService(ByVal id As String) As String
        Dim dt As New DataTable
        Dim eng As New Web_Config.ServiceENG
        dt = eng._SetgvService("")

        For i As Integer = 0 To dt.Rows.Count - 1
            id += dt.Rows(i)("idRes").ToString & ","
        Next

        If id <> "" Then
            id = id.Substring(0, id.Length - 1)
            id = "id not in (" & id & ")"
        End If

        Return id
    End Function

    Public Function chkProcess(ByVal id As String) As String
        Dim dt As New DataTable
        Dim eng As New Web_Config.ProcessENG
        dt = eng._SetgvProcess("")

        For i As Integer = 0 To dt.Rows.Count - 1
            id += dt.Rows(i)("idRes").ToString & ","
        Next

        If id <> "" Then
            id = id.Substring(0, id.Length - 1)
            id = "id not in (" & id & ")"
        End If

        Return id
    End Function

    Public Function chkFileSize(ByVal id As String) As String
        Dim dt As New DataTable
        Dim eng As New Web_Config.FileSizeENG
        dt = eng.GetgvFileSize("")

        For i As Integer = 0 To dt.Rows.Count - 1
            id += dt.Rows(i)("idRes").ToString & ","
        Next

        If id <> "" Then
            id = id.Substring(0, id.Length - 1)
            id = "id not in (" & id & ")"
        End If

        Return id
    End Function

    Public Function chkPort(ByVal id As String) As String
       
        Return id
    End Function

    Protected Sub gvServerIP_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvServerIP.RowCommand
        If e.CommandName = "Serverip" Then

            Dim lblID As Label
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            lblID = CType(gvServerIP.Rows(RowIndex).FindControl("lblid"), Label)

            Dim Serverip As Label = CType(gvServerIP.Rows(RowIndex).FindControl("lblip"), Label)
            Dim Servername As Label = CType(gvServerIP.Rows(RowIndex).FindControl("lblServername"), Label)
            Dim Macaddress As Label = CType(gvServerIP.Rows(RowIndex).FindControl("lblMacaddress"), Label)

            Session("_serverip") = Serverip.Text
            Session("_servername") = Servername.Text
            Session("_macaddress") = Macaddress.Text
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "window.close();", True)
        End If
    End Sub


    Protected Sub imgBack_Click(sender As Object, e As ImageClickEventArgs) Handles imgBack.Click
        GetgvIP()
    End Sub
End Class

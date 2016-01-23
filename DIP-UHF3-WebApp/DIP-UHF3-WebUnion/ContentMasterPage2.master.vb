
Partial Class ContentMasterPage2
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Not IsNothing(Session("fullname")) Then
            lblUserID.Text = Session("userid")
            lblUserName.Text = Session("username")
            lblfullname.Text = Session("fullname") & "(" & Session("username") & ")"
            lblHostReport.Text = Session("HostReport") '"http://localhost/dipreport/Reports.aspx"
            lblFloorID.Text = Session("FloorID")
        Else
            Response.Redirect("Default.aspx")
        End If
    End Sub
End Class


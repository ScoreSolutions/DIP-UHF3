
Partial Class ContentMasterPage
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Not IsNothing(Session("fullname")) Then
            lblUserID.Text = Session("userid")
            lblfullname.Text = Session("fullname")
            lblUserName.Text = Session("username")
            lblHostReport.Text = Session("HostReport") '"http://localhost/dipreport/Reports.aspx"
        Else
            Response.Redirect("Default.aspx")
        End If
    End Sub
End Class


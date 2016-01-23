
Partial Class frmSignage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim param As String = Request.QueryString("myParam")
        myframe.Attributes.Add("src", param)
    End Sub
End Class

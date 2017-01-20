
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub txtIP_Init(sender As Object, e As EventArgs) Handles txtIP.Init
        txtIP.Value = Request.UserHostAddress '"192.168.1.36" ' 
    End Sub

End Class

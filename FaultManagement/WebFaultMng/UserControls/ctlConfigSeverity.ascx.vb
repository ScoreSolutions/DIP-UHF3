
Partial Class UserControls_ctlConfigSeverity
    Inherits System.Web.UI.UserControl

    Public Property MinorValue As String
        Get
            If txtMinor.Text.Trim = "" Then
                Return 0
            Else
                Return Convert.ToInt32(txtMinor.Text)
            End If
        End Get
        Set(value As String)
            txtMinor.Text = value
        End Set
    End Property

    Public Property MajorValue As String
        Get
            If txtMajor.Text.Trim = "" Then
                Return 0
            Else
                Return Convert.ToInt32(txtMajor.Text)
            End If
        End Get
        Set(value As String)
            txtMajor.Text = value
        End Set
    End Property

    Public Property CriticalValue As String
        Get
            If txtCritical.Text.Trim = "" Then
                Return 0
            Else
                Return Convert.ToInt32(txtCritical.Text)
            End If
        End Get
        Set(value As String)
            txtCritical.Text = value
        End Set
    End Property

    Public Property RepeatMinor As String
        Get
            If txtRepeatMinor.Text.Trim = "" Then
                Return 0
            Else
                Return Convert.ToInt32(txtRepeatMinor.Text)
            End If
        End Get
        Set(value As String)
            txtRepeatMinor.Text = value
        End Set
    End Property

    Public Property RepeatMajor As String
        Get
            If txtRepeatMajor.Text.Trim = "" Then
                Return 0
            Else
                Return Convert.ToInt32(txtRepeatMajor.Text)
            End If
        End Get
        Set(value As String)
            txtRepeatMajor.Text = value
        End Set
    End Property

    Public Property RepeatCritical As String
        Get
            If txtRepeatCritical.Text.Trim = "" Then
                Return 0
            Else
                Return Convert.ToInt32(txtRepeatCritical.Text)
            End If
        End Get
        Set(value As String)
            txtRepeatCritical.Text = value
        End Set
    End Property

    Private Sub SetValidTextInteger()
        txtMinor.Attributes.Add("OnKeyPress", "ChkMinusInt(this,event);")
        txtMinor.Attributes.Add("onKeyDown", "CheckKeyNumber(event);")

        txtRepeatMinor.Attributes.Add("OnKeyPress", "ChkMinusInt(this,event);")
        txtRepeatMinor.Attributes.Add("onKeyDown", "CheckKeyNumber(event);")

        txtMajor.Attributes.Add("OnKeyPress", "ChkMinusInt(this,event);")
        txtMajor.Attributes.Add("onKeyDown", "CheckKeyNumber(event);")

        txtRepeatMajor.Attributes.Add("OnKeyPress", "ChkMinusInt(this,event);")
        txtRepeatMajor.Attributes.Add("onKeyDown", "CheckKeyNumber(event);")

        txtCritical.Attributes.Add("OnKeyPress", "ChkMinusInt(this,event);")
        txtCritical.Attributes.Add("onKeyDown", "CheckKeyNumber(event);")

        txtRepeatCritical.Attributes.Add("OnKeyPress", "ChkMinusInt(this,event);")
        txtRepeatCritical.Attributes.Add("onKeyDown", "CheckKeyNumber(event);")
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            SetValidTextInteger()
        End If
    End Sub
End Class

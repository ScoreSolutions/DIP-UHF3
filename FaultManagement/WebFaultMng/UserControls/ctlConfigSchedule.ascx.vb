
Partial Class UserControls_ctlConfigSchedule
    Inherits System.Web.UI.UserControl

    Public Property IntervalMinute As String
        Get
            If txtIntervalMinute.Text.Trim = "" Then
                Return 0
            Else
                Return txtIntervalMinute.Text
            End If
        End Get
        Set(value As String)
            txtIntervalMinute.Text = value
        End Set
    End Property

    Public Property ActiveStatus As String
        Get
            Return IIf(chkActiveStatus.Checked = True, "Y", "N")
        End Get
        Set(value As String)
            chkActiveStatus.Checked = (value = "Y")
        End Set
    End Property

    Public Property CheckSun As String
        Get
            Return IIf(chkSun.Checked = True, "Y", "N")
        End Get
        Set(value As String)
            chkSun.Checked = (value = "Y")
        End Set
    End Property

    Public Property CheckMon As String
        Get
            Return IIf(chkMon.Checked = True, "Y", "N")
        End Get
        Set(value As String)
            chkMon.Checked = (value = "Y")
        End Set
    End Property

    Public Property CheckTue As String
        Get
            Return IIf(chkTue.Checked = True, "Y", "N")
        End Get
        Set(value As String)
            chkTue.Checked = (value = "Y")
        End Set
    End Property

    Public Property CheckWed As String
        Get
            Return IIf(chkWed.Checked = True, "Y", "N")
        End Get
        Set(value As String)
            chkWed.Checked = (value = "Y")
        End Set
    End Property

    Public Property CheckThu As String
        Get
            Return IIf(chkThu.Checked = True, "Y", "N")
        End Get
        Set(value As String)
            chkThu.Checked = (value = "Y")
        End Set
    End Property

    Public Property CheckFri As String
        Get
            Return IIf(chkFri.Checked = True, "Y", "N")
        End Get
        Set(value As String)
            chkFri.Checked = (value = "Y")
        End Set
    End Property

    Public Property CheckSat As String
        Get
            Return IIf(chkSat.Checked = True, "Y", "N")
        End Get
        Set(value As String)
            chkSat.Checked = (value = "Y")
        End Set
    End Property

    Public Property TimeFrom As String
        Get
            Return txtTimeFrom.TimeText
        End Get
        Set(value As String)
            txtTimeFrom.TimeText = value
        End Set
    End Property

    Public Property TimeTo As String
        Get
            Return txtTimeTo.TimeText
        End Get
        Set(value As String)
            txtTimeTo.TimeText = value
        End Set
    End Property
    Public Property AllDayEvent As String
        Get
            Return IIf(chkAllDay.Checked = True, "Y", "N")
        End Get
        Set(value As String)
            chkAllDay.Checked = (value = "Y")
        End Set
    End Property

    Public WriteOnly Property EnableInterval As Boolean
        Set(value As Boolean)
            txtIntervalMinute.Enabled = value
        End Set
    End Property

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            txtIntervalMinute.Attributes.Add("OnKeyPress", "ChkMinusInt(this,event);")
            txtIntervalMinute.Attributes.Add("onKeyDown", "CheckKeyNumber(event);")
            chkAllDay_CheckedChanged(sender, e)
        End If
    End Sub

    Protected Sub chkAllDay_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllDay.CheckedChanged
        txtTimeFrom.TxtBox.Enabled = Not chkAllDay.Checked
        txtTimeTo.TxtBox.Enabled = Not chkAllDay.Checked

        If chkAllDay.Checked Then
            txtTimeFrom.TxtBox.Text = ""
            txtTimeTo.TxtBox.Text = ""
        End If
    End Sub
End Class

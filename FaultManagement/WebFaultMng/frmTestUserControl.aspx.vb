
Partial Class frmTestUserControl
    Inherits System.Web.UI.Page

    Protected Sub btnTest1_Click(sender As Object, e As EventArgs) Handles btnTest1.Click
        lblIntervalMinute.Text = ctlConfigSchedule1.IntervalMinute
        lblActiveStatus.Text = ctlConfigSchedule1.ActiveStatus
        lblSunday.Text = ctlConfigSchedule1.CheckSun
        lblMonday.Text = ctlConfigSchedule1.CheckMon
        lblTueday.Text = ctlConfigSchedule1.CheckTue
        lblWenedday.Text = ctlConfigSchedule1.CheckWed
        lblThursday.Text = ctlConfigSchedule1.CheckThu
        lblFriday.Text = ctlConfigSchedule1.CheckFri
        lblTimeFrom.Text = ctlConfigSchedule1.TimeFrom
        lblTimeTo.Text = ctlConfigSchedule1.TimeTo
        lblAllDayEvent.Text = ctlConfigSchedule1.AllDayEvent
    End Sub
End Class

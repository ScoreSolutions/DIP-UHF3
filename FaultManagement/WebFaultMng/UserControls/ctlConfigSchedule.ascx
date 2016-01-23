<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlConfigSchedule.ascx.vb" Inherits="UserControls_ctlConfigSchedule" %>
<%@ Register src="txtTime.ascx" tagname="txtTime" tagprefix="uc1" %>
<table width="100%" style="background-color: #AFEEEE;  font-family: Quark; font-size: medium;" border="0">
    <tr>
        <td colspan="3"></td>
    </tr>
    <tr>
        <td style="color: #006666; text-align: right; font-size: 12pt; width:140px;">Interval Minute :
        </td>
        <td style="color: #006666; text-align: left; font-size: 12pt;width:200px">&nbsp;
            <asp:TextBox ID="txtIntervalMinute" Width="80px" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" onkeypress="return isNumberKey(event)"></asp:TextBox>&nbsp;Minute
        </td>
        <td style="color: #006666; text-align: left; font-size: 12pt;">&nbsp;
            <asp:CheckBox ID="chkActiveStatus" runat="server" Text="Active Status" Checked="true" />
        </td>
    </tr>
    <tr>
        <td style="color: #006666; text-align: right; vertical-align: top; font-size: 12pt;">&nbsp;
    Alarm Date :</td>
        <td style="color: #006666; text-align: left; font-size: 12pt;" colspan="2" >
            <table style=" color: #006666; font-size: 12pt;">
                <tr>
                    <td>
                        <asp:CheckBox ID="chkSun" runat="server" Text="Sunday" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chkMon" runat="server" Text="Monday" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chkTue" runat="server" Text="Tuesday" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkWed" runat="server" Text="Wednesday" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chkThu" runat="server" Text="Thursday" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chkFri" runat="server" Text="Friday" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkSat" runat="server" Text="Saturday" />
                    </td>
                    <td colspan="2"></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="color: #006666; text-align: right; vertical-align: top; font-size: 12pt;">Alarm Time :</td>
        <td style="color: #006666; text-align: left; vertical-align: top; font-size: 12pt; padding-left: 4px;" colspan="2" >
            <uc1:txtTime ID="txtTimeFrom" runat="server" VisibleStar="false" />
            &nbsp;To : &nbsp;
            <uc1:txtTime ID="txtTimeTo" runat="server" VisibleStar="false" />
            <asp:CheckBox ID="chkAllDay" runat="server" Text="All Day Event" AutoPostBack="True" />
        </td>
    </tr>
</table>
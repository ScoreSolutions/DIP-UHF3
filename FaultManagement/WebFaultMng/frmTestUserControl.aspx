<%@ Page Title="" Language="VB" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="false" CodeFile="frmTestUserControl.aspx.vb" Inherits="frmTestUserControl" %>

<%@ Register src="UserControls/ctlConfigSchedule.ascx" tagname="ctlConfigSchedule" tagprefix="uc1" %>

<%@ Register src="UserControls/ctlConfigSeverity.ascx" tagname="ctlConfigSeverity" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:80%" >
        <tr>
            <td style="text-align:left">
                <uc1:ctlConfigSchedule ID="ctlConfigSchedule1" runat="server" />
                <uc2:ctlConfigSeverity ID="ctlConfigSeverity1" runat="server" />

                <uc1:ctlConfigSchedule ID="ctlConfigSchedule2" runat="server" />

                <uc1:ctlConfigSchedule ID="ctlConfigSchedule3" runat="server" />

                <uc1:ctlConfigSchedule ID="ctlConfigSchedule4" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnTest1" runat="server" Text="Click" />
                
            </td>
        </tr>
        
        <tr>
            <td><asp:Label ID="lblIntervalMinute" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblActiveStatus" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblSunday" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblMonday" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTueday" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblWenedday" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblThursday" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblFriday" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblSaturday" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTimeFrom" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTimeTo" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblAllDayEvent" runat="server"></asp:Label></td>
        </tr>

    </table>
</asp:Content>


<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlConfigSeverity.ascx.vb" Inherits="UserControls_ctlConfigSeverity" %>
<table style="width:100%;background-color: #AFEEEE;  font-family: Quark; font-size: medium;"  >
    <tr>
        <td style="color: #006666; text-align: right; vertical-align: top; font-size: 12pt; width:22%;">Minor Value :
        </td>
        <td style="color: #006666; text-align: left; vertical-align: top; font-size: 12pt;">
            <table style="width: 100%; color: #006666; font-size: 12pt;">
                <tr>
                    <td class="auto-style11" style="width:100px">
                        <asp:TextBox ID="txtMinor" runat="server" Font-Names="Quark" Font-Size="11pt" ForeColor="Black" MaxLength="3"  Width="50px"></asp:TextBox>
                        &nbsp;%</td>
                    <td class="auto-style12" style="text-align: right;width:200px" >Check Repeat Minor :
                    </td>
                    <td>
                        <asp:TextBox ID="txtRepeatMinor" runat="server" Font-Names="Quark" Font-Size="11pt" ForeColor="Black" MaxLength="3"  Width="50px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="color: #006666; text-align: right; vertical-align: top; font-size: 12pt;">Major Value :
        </td>
        <td style="color: #006666; text-align: left; vertical-align: top; font-size: 12pt;">
            <table style="width: 100%; color: #006666; font-size: 12pt;">
                <tr>
                    <td class="auto-style11" style="width:100px">
                        <asp:TextBox ID="txtMajor" runat="server" Font-Names="Quark" Font-Size="11pt" ForeColor="Black" MaxLength="3"   Width="50px"></asp:TextBox>
                        &nbsp;%</td>
                    <td class="auto-style12" style="text-align: right;width:200px">Check Repeat Major :
                    </td>
                    <td>
                        <asp:TextBox ID="txtRepeatMajor" runat="server" Font-Names="Quark" Font-Size="11pt" ForeColor="Black" MaxLength="3"  Width="50px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="color: #006666; text-align: right; vertical-align: top; font-size: 12pt;">Critical Value :
        </td>
        <td style="color: #006666; text-align: left; vertical-align: top; font-size: 12pt;">
            <table style="width: 100%; color: #006666; font-size: 12pt;">
                <tr>
                    <td class="auto-style11" style="width:100px">
                        <asp:TextBox ID="txtCritical" runat="server" Font-Names="Quark" Font-Size="11pt" ForeColor="Black" MaxLength="3"  Width="50px"></asp:TextBox>
                        &nbsp;%</td>
                    <td class="auto-style12" style="text-align: right;width:200px">Check Repeat Critical :
                    </td>
                    <td>
                        <asp:TextBox ID="txtRepeatCritical" runat="server" Font-Names="Quark" Font-Size="11pt" ForeColor="Black" MaxLength="3"  Width="50px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
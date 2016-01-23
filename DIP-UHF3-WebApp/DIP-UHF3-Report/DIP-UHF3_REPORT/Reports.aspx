<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reports.aspx.vb" Inherits="DIP_UHF3_REPORT.Reports" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
    </div>
        <table style="width:100%">
            <tr id="datanotfound" runat="server">
                <td>
                    <asp:Label ID="lbldatanotfound" runat="server" Text="ไม่พบข้อมูล"></asp:Label>
                </td>
            </tr>
                        <tr id="datafound" runat="server">
                <td>
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableTheming="True" HasCrystalLogo="False" Height="50px" Width="350px" />

                </td>
            </tr>
        </table>
       
    </form>
</body>
</html>

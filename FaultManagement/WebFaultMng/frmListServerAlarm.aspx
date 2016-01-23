<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmListServerAlarm.aspx.vb" Inherits="frmListServerAlarm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvAlarmServer" runat="server" Width="925px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Font-Bold="True" Font-Names="Quark" Font-Size="12pt">
            <Columns>
                <asp:TemplateField HeaderText="id" SortExpression="id" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="LabelID" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="No" HeaderText="No.">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                 <asp:ButtonField HeaderText="Server Name" CommandName="Detail" DataTextField="ServerName" Text="ServerName" />
                <asp:BoundField DataField="ServerIP" HeaderText="Server IP" />
                <asp:BoundField DataField="SpecificProblem" HeaderText="Specific Problem" />
                <asp:TemplateField HeaderText="Severity" SortExpression="Severity" Visible="true">
                    <ItemTemplate>
                        <asp:Image ID="Minor" runat="server" ImageUrl="Images/Severity_Yellow.png" Visible='<%# IIf(Eval("Severity").ToString() = "Minor", True, False)%>' />
                        <asp:Image ID="Major" runat="server" ImageUrl="Images/Severity_Orange.png" Visible='<%# IIf(Eval("Severity").ToString() = "Major", True, False)%>' />
                        <asp:Image ID="Critical" runat="server" ImageUrl="Images/Severity_Red.png" Visible='<%# IIf(Eval("Severity").ToString() = "Critical", True, False)%>' />
                    <asp:Label ID="lblSeverity" runat="server" Text='<%# Bind("Severity")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Percents" HeaderText="Percent">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="CreateDate" HeaderText="Create Date" />
                <asp:BoundField DataField="UpdateDate" HeaderText="Update Date" />

            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>

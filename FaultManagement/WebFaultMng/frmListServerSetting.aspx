<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmListServerSetting.aspx.vb" Inherits="frmListServerSetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvServerSetting" runat="server" Width="925px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Font-Bold="True" Font-Names="Quark" Font-Size="12pt">
            <Columns>
                <asp:TemplateField HeaderText="id" SortExpression="id" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="LabelID" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="No" HeaderText="No." />
                <asp:BoundField DataField="ServerName" HeaderText="Server Name" />
                <asp:BoundField DataField="ServerIP" HeaderText="Server IP" />
                <asp:BoundField DataField="AlarmType" HeaderText="Alarm Type" />
                <asp:BoundField DataField="Percents" HeaderText="Percent" />
                <asp:BoundField DataField="ConfigValue" HeaderText="Config Value" />
                <asp:BoundField DataField="CreatedBy" HeaderText="Config By" />
                <asp:BoundField DataField="CreatedDate" HeaderText="Config Date" />

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

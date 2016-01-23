<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmListServerGroup.aspx.vb" Inherits="frmListServerGroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="gvServerList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="1004px" Font-Bold="True" Font-Names="Quark" Font-Size="12pt">
                    <Columns>
                        <asp:TemplateField HeaderText="id" SortExpression="id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="LabelID" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="No" HeaderText="No." >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ServerIP" HeaderText="Server IP" />
                        <asp:ButtonField HeaderText="Server Name" CommandName="Detail" DataTextField="ServerName" Text="ServerName" />
                        <asp:BoundField DataField="MacAddress" HeaderText="Mac Address" />
                        <asp:BoundField DataField="OS" HeaderText="OS" />
                        <asp:BoundField DataField="System_Type" HeaderText="Project Name" />
                        <asp:BoundField DataField="Locate_No" HeaderText="Locate/No." NullDisplayText="-">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="name" HeaderText="Name" />
                        <asp:BoundField DataField="E_mail" HeaderText="E-mail" />
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

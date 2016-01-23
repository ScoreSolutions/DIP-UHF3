<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmPopupSerchIP.aspx.vb" Inherits="frmPopupSerchIP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<script type="text/Javascript">
    function getServerIP() {
        var Name = document.getElementById('lblName');
        if (Name == "Group") {
            alert("You are using Netscape");
            document.getElementById('Server').style.display = 'none';
            document.getElementById('Group').style.display = 'block';
        }
    }
</script>
<style type="text/css">

body{
     
     background-color:#E3F3F9;
}        
    #Group{
    display :none ;
}

</style>

</head>
<body>
    <form id="form1" runat="server">
         <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style ="width :100%">

                         <tr>
                          <td>
                           Server IP :&nbsp;&nbsp; <asp:TextBox ID="txtServerip" runat="server"></asp:TextBox>
                            &nbsp;
                            <asp:Button ID="btnSerch" runat="server" Text="Search" />
                         </td>                           
                       </tr>

                        <tr>
                            <td>
                                <asp:ImageButton ID="imgBack" runat="server" Height="22px" ImageUrl="~/Images/Back.png" Width="25px" /> 
                               
                                <asp:Label ID="lblvalue" runat="server"></asp:Label>
                               
                           
                            </td>
                        </tr>
                        
                         <tr>
                            <td>
                                 <div style="width: 100%; height: 300px; overflow-y: auto;">
                                   
                                <asp:GridView ID="gvServerIP" runat="server" AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">

                                    <Columns>
                                        <asp:TemplateField HeaderText="id" Visible="False">
                                            <ItemTemplate >
                                                <asp:Label ID="lblid" runat="server" Text='<%#Bind("id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:BoundField DataField="no" HeaderText="No." />
                                        <asp:ButtonField DataTextField="HostIP" HeaderText="Server ip" Text="Server ip"  CommandName="Serverip"/>
                                        <asp:TemplateField HeaderText="Server Name">
                                            <ItemTemplate >
                                                  <asp:Label ID="lblServername" runat="server" Text='<%#Bind("ServerName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Macaddress">
                                             <ItemTemplate >
                                                  <asp:Label ID="lblMacaddress" runat="server" Text='<%#Bind("MacAddress")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Hostip" Visible="False">
                                             <ItemTemplate >
                                                  <asp:Label ID="lblip" runat="server" Text='<%#Bind("HostIP")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                       
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
       </div>
    </form>
</body>
</html>

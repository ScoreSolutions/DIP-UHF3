<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmPopupSearchGroup.aspx.vb" Inherits="frmPopupSearchGroup_aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style =" background-color:#E3F3F9;">
    <form id="form1" runat="server">
    <div >
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <table style ="width :100%">

                       <tr>
                          <td colspan ="2">
                           Group :&nbsp;&nbsp; <asp:TextBox ID="txtGroup" runat="server"></asp:TextBox>
                            &nbsp;
                            <asp:Button ID="btnSerch" runat="server" Text="Search" />
                         </td>                           
                       </tr>

                        <tr>
                            <td colspan ="2">
                               
                                <asp:ImageButton ID="imgBack" runat="server" Height="22px" ImageUrl="~/Images/Back.png" Width="25px" /> 
                                <asp:Label ID="Label1" runat="server" ></asp:Label>
                            </td>
                     
                        </tr>
                        <tr>
                                <td style="width: 270px;">
                              <div style="width: 100%; height: 280px; overflow-y: auto;">
                                      <table>
                                          <tr>
                                              <td>
                                                    <asp:Button ID="btnSave" runat="server" Text="Confrim" />
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  
                               <asp:GridView ID="gvGroup" runat="server" AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Font-Bold="True" Font-Names="Quark" Font-Size="Medium">

                                    <Columns>
                                        <asp:BoundField DataField="no" HeaderText="No." />
                                        <asp:ButtonField DataTextField="group_desc" HeaderText="Group" CommandName="Group"  >
                                        <ItemStyle Width="100px" />
                                        </asp:ButtonField>
                                        <asp:BoundField DataField="Qty" HeaderText="QTY" />
                                        <asp:TemplateField HeaderText="Group" Visible="False">
                                              <ItemTemplate >
                                                  <asp:Label ID="lblGroup" runat="server"  Text='<%# Bind("group_desc")%>'></asp:Label>
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
                                              </td>
                                          </tr>
                                      </table>
                                      </div>
                           
                                </td>
                                 <td>
                   
                                      <div style="width: 100%; height: 280px; overflow-y: auto;">

                                      <table >
                                          <tr>
                                              <td style="text-align: left ;">
                                      Group :  <asp:Label ID="lblgroupName" runat="server" ></asp:Label>
                                              </td>
                                          </tr
                                          <tr>
                                              <tr>
                                                  <td style="text-align: left;">


                                                      <asp:Label ID="lblNoServer" runat="server" ></asp:Label>
                                                      <asp:GridView ID="gvGroupbyName" runat="server" AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Font-Bold="True" Font-Names="Quark" Font-Size="Medium">
                                                          <Columns>
                                                              <asp:TemplateField HeaderText="id" Visible="False">
                                                                  <ItemTemplate>
                                                                      <asp:Label ID="lblGroupid" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                                                  </ItemTemplate>
                                                              </asp:TemplateField>
                                                              <asp:BoundField DataField="no" HeaderText="No." />
                                                              <asp:TemplateField HeaderText="Serverid" Visible="False">
                                                                  <ItemTemplate>
                                                                      <asp:Label ID="lblServerid" runat="server" Text='<%# Bind("Serverid")%>'></asp:Label>
                                                                  </ItemTemplate>
                                                              </asp:TemplateField>
                                                              <asp:BoundField DataField="ServerName" HeaderText="Server Name" />
                                                              <asp:BoundField DataField="ServerIP" HeaderText="Server IP" />
                                                              <asp:BoundField DataField="MacAddress" HeaderText="MacAddress" />
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
                                                  </td>
                                          </tr>
                                          </tr>
                                      </table>
                               </div> 

                                 </td>
                            </tr> 
                      
                        </table> 

                </ContentTemplate>
            </asp:UpdatePanel>
       </div>
    </form>
</body>
</html>

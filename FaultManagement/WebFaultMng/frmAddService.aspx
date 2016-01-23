<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAddService.aspx.vb" Inherits="frmAddService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function ConfirmService() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you like to Delete item?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
     </script>
</head>
<body style =" background-color:#E3F3F9;">
    <form id="form1" runat="server">
   
    
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style ="width :100%">
                        <tr>
                            <td style="text-align: right; font-size: 12pt;width :150px;">
                                Service Name :
                            </td>
                             <td>

                                 <asp:TextBox ID="txtWindowServiceName" runat="server"></asp:TextBox>

                             </td>
                        </tr>
                         <tr>
                            <td style="text-align: right; font-size: 12pt;width :150px;">
                                Description :
                            </td>
                             <td>

                                 <asp:TextBox ID="txtDisplayName" runat="server"></asp:TextBox>

                                 &nbsp;
                                 <asp:Button ID="btnSave" runat="server" Text="Save" />

                             </td>
                        </tr>
                         <tr>
                            <td>
                               
                                <asp:Label ID="lblid" runat="server" Text="0" Visible="False"></asp:Label>
                               
                            </td>
                             <td>

                                     <asp:CheckBox ID="chkActiveStatus" runat="server" Text="Active Status" Checked="True" />
                               
                             </td>
                        </tr>
                        <tr>
                            <td colspan ="2">
                                  <div style="width: 490px; height: 300px; overflow-y: auto;">

                                <asp:GridView ID="gvService" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                    <Columns>
                                        <asp:TemplateField HeaderText="id" Visible="False">
                                             <ItemTemplate >
                                                <asp:Label ID="lblid" runat="server" Text='<%#Bind("id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="no" HeaderText="No." />
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate >
                                                <asp:Label ID="lblWindowServiceName" runat="server" Text='<%#Bind("WindowServiceName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate >
                                                <asp:Label ID="lblDisplayName" runat="server" Text='<%#Bind("DisplayName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="150px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Active Status" SortExpression="active_status" Visible="true" >
                                           <ItemTemplate>
                                              <asp:CheckBox ID="ChkActive" runat="server" Checked='<%# IIf(Eval("ActiveStatus").ToString() = "Y", True, False)%>'  Enabled="False" />
                                         </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png"   CommandName="EditRow" />
                                         <%--<asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:ButtonField>--%>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Delete" runat="server" CommandName="DeleteRow" ImageUrl="~/Images/icon_Delete.png" OnClientClick="ConfirmService()" CommandArgument='<%#Bind("id")%>' />
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
                    </table>
                 </ContentTemplate>
            </asp:UpdatePanel>
       </div>
       
    
    
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAddPathFile.aspx.vb" Inherits="frmAddPathFile" %>

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
                    
            <table style ="width : 100%">
            <tr>
                <td colspan ="2" >
                    Browse Directory
                </td>
            </tr>
            <tr>
                <td style=" width :115px;text-align: right">
                   Service IP :
                </td>
                <td>
                   &nbsp;
                    <asp:Label ID="lblServerip" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblMacAddress" runat="server" Text="" Visible="false" ></asp:Label>
                   
                </td>
            </tr>
            <tr>
                <td  style="text-align: right">
                   Drive : 
                </td>
                 <td>
                   &nbsp;
                   <asp:DropDownList ID="ddlDriveNameFile" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
             <tr>
                 <td style="text-align: right">Address : </td>
                <td>
                    <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Images/icon_back.png" Width="20px" Visible="false" />
                    <asp:Label ID="lblPathFile" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblLoginHistoryID" runat="server" Visible="false" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan ="2">
                                <div>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/wait.gif" />
                                </div>
                      <div id="gv" style="width: 100%; height: 300px; overflow-y: auto;">
          
                   <asp:GridView ID="gvSelectPahtFile" runat="server" Width="98%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">

                       <Columns>
                           <asp:TemplateField HeaderText="id" Visible="false" >
                               <ItemTemplate >
                                   <asp:Label ID="lblid" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="No" >
                               <ItemTemplate >
                                   <asp:Label ID="lblNo" runat="server" Text='<%# Bind("no")%>' ></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="PathFile" >
                               <ItemTemplate >
                                   <asp:LinkButton ID="lblPathFile" runat="server" Text='<%# Bind("PathFile")%>'
                                       CommandName="PathFile" CommandArgument='<%# Bind("PathArgs")%>'  ></asp:LinkButton>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Type" >
                               <ItemTemplate >
                                   <asp:LinkButton ID="lblDisplayType" runat="server" Text='<%# Bind("DisplayType")%>'
                                       CommandName="PathFile" CommandArgument='<%# Bind("PathArgs")%>'  ></asp:LinkButton>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="FileSizeGB" >
                                <ItemTemplate >
                                    <asp:Label ID="lblFileSizeGB" runat="server" Text='<%# Bind("FileSizeGB")%>' ></asp:Label>
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

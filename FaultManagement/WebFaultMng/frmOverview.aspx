<%@ Page Title="" Language="VB" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="false" CodeFile="frmOverview.aspx.vb" Inherits="frmOverview" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
  
    <table>
        <tr>
            <td colspan="3" style="font-family: quark; font-size: 20pt; font-weight: bold; color: #000000; border-radius:15px; ">&nbsp;&nbsp; Overview</td>
        </tr>
        <tr><td colspan="3" style="background-color: #666666"></td></tr>
       <%-- <tr><td>
            &nbsp;</td></tr>--%>
         <tr><td colspan="3">
             <asp:Timer ID="Timer1" runat="server" Interval="30000">
             </asp:Timer>
             <asp:ScriptManager ID="ScriptManager1" runat="server">
             </asp:ScriptManager>
             </td></tr>
        <tr>
            <td>&nbsp;</td>
            <td style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;" >
                 <table><tr><td>&nbsp;</td><td style="font-family: quark; font-weight: bold; color: #FFFFFF; font-size: 14pt">&nbsp;Recent 50 Alarm</td></tr></table> 
               <asp:UpdatePanel runat="server" ><ContentTemplate > 
                   <asp:GridView ID="gvRecently" runat="server" AutoGenerateColumns="False" 
                       BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                       BorderWidth="1px" CellPadding="3" Width="988px" Font-Bold="True" 
                       Font-Names="Quark" Font-Size="12pt" AllowPaging="True" PageSize="25">
                    <Columns>
                        <asp:BoundField DataField="No" HeaderText="No." >
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ServerName" HeaderText="Server Name" >
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Specific Problem" DataField="SpecificProblem" >
                            <ItemStyle Width="350px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Severity" SortExpression="Severity" Visible="true">
                            <ItemTemplate>
                                <asp:Image ID="Minor" runat="server" ImageUrl="Images/Severity_Yellow.png" Visible='<%# IIf(Eval("Severity").ToString() = "Minor", True, False)%>' />
                                <asp:Image ID="Major" runat="server" ImageUrl="Images/Severity_Orange.png" Visible='<%# IIf(Eval("Severity").ToString() = "Major", True, False)%>' />
                                <asp:Image ID="Critical" runat="server" ImageUrl="Images/Severity_Red.png" Visible='<%# IIf(Eval("Severity").ToString() = "Critical", True, False)%>' />
                                <asp:Label ID="lblSeverity" runat="server" Text='<%# Bind("Severity")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="PercentValue" HeaderText="Value" >
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CreatedDate" HeaderText="Created Date">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="25" Position="TopAndBottom" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView></ContentTemplate></asp:UpdatePanel>
            </td>

            <td>&nbsp;</td>
        </tr>
        <tr><td colspan="3">&nbsp;</td></tr>
        <%--<tr>
            <td>&nbsp;</td>
            <td  style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;" >
                 <table><tr><td>&nbsp;</td><td style="font-family: quark; font-weight: bold; color: #FFFFFF; font-size: 14pt">&nbsp;Monitor Group</td></tr></table> 
                
                <asp:GridView ID="gvMGroup" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="988px" Font-Bold="True" Font-Names="Quark" Font-Size="12pt" AllowPaging="True">
                    <Columns>
                         <asp:TemplateField HeaderText="group_desc" SortExpression="group_desc" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("group_desc")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="No" HeaderText="No." >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:ButtonField HeaderText="Group Name" DataTextField="group_desc" CommandName = "Detail">
                        <ItemStyle HorizontalAlign="Center" Width="400px" />
                        </asp:ButtonField>
                        <asp:BoundField DataField="Qty" HeaderText="Qty." >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                   
            </td>
           <td>&nbsp;</td>
        </tr>--%>
        <tr><td colspan="2">&nbsp;</td>
            
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;" >
                 <table><tr><td>&nbsp;</td><td style="font-family: quark; font-weight: bold; color: #FFFFFF; font-size: 14pt">&nbsp;Monitor Server</td></tr></table> 
              
                 <asp:GridView ID="gvRegister" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="988px" Font-Bold="True" Font-Names="Quark" Font-Size="12pt" AllowPaging="True" PageSize="20">
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
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" Position="TopAndBottom" />
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
    
 
     

</asp:Content>


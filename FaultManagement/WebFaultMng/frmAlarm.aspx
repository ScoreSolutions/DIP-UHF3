<%@ Page Title="" Language="VB" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="false" CodeFile="frmAlarm.aspx.vb" Inherits="frmAlarm" enableEventValidation ="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script>

        //Refresh Tab
        function TabSetting() {

            document.getElementById('css3-tabstrip-0-0').checked = true
        };
        function TabAlarm() {

            document.getElementById('css3-tabstrip-0-1').checked = true
        };

        //Validate textbox number'0-9' & decimal point '.'

        function isNumberPKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode != 46))
                return false;

            return true;
        }

        //Validate textbox ServerName
        function isServerNameKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                if (charCode > 31 && (charCode < 65 || charCode > 90))
                    if (charCode > 31 && (charCode < 97 || charCode > 122))
                        if (charCode > 31 && (charCode < 3585 || charCode > 3642) && (charCode < 3648 || charCode > 3660))
                            if (charCode > 31 && (charCode != 45))
                                return false;

            return true;
        }
     
    </script>

    <style>
                /*
 * @CSS3 Tabstrip
 * @author Martin Ivanov
 * @website http://wemakesites.net
 * @blog http://acidmartin.wordpress.com/
 * @twitter https://twitter.com/wemakesitesnet
 **/
        /*Credit css3-tabstip*/

         .css3-tabstrip ul,
        .css3-tabstrip li {
            margin: 0;
            padding: 0;
            list-style: none;
        }

        .css3-tabstrip,
        .css3-tabstrip input[type="radio"]:checked + label {
            position: relative;
        }

            .css3-tabstrip li,
            .css3-tabstrip input[type="radio"] + label {
                display: inline-block;
            }

                .css3-tabstrip li > div,
                .css3-tabstrip input[type="radio"] {
                    position: absolute;
                }

                    .css3-tabstrip li > div,
                    .css3-tabstrip input[type="radio"] + label {
                        border: solid 1px #ccc;
                    }

        .css3-tabstrip {
            font: bold 12px arial,quark;
            color: #ffffff;
            top: 0px;
            left: 0px;
            height: 1407px;
        }

            .css3-tabstrip li {
                vertical-align: top;
            }

                .css3-tabstrip li:first-child {
                    margin-left: 8px;
                }

                .css3-tabstrip li > div {
                    top: 33px;
                    bottom: 0;
                    left: 0;
                    width: 100%;
                    padding: 8px;
                    overflow: auto;
                    background: #e5fff9;
                    -moz-box-sizing: border-box;
                    -webkit-box-sizing: border-box;
                    box-sizing: border-box;
                }

            .css3-tabstrip input[type="radio"] + label {
                margin: 0 2px 0 0;
                padding: 0 18px;
                line-height: 32px;
                background: #808080;
                text-align: center;
                border-radius: 5px 5px 0 0;
                cursor: pointer;
                -moz-user-select: none;
                -webkit-user-select: none;
                user-select: none;
            }

            .css3-tabstrip input[type="radio"]:checked + label {
                z-index: 1;
                background: #008080;
                border-bottom-color: #AFEEEE;
                cursor: default;
            }

            .css3-tabstrip input[type="radio"] {
                opacity: 0;
            }

                .css3-tabstrip input[type="radio"] ~ div {
                    display: none;
                }

                .css3-tabstrip input[type="radio"]:checked:not(:disabled) ~ div {
                    display: block;
                }

                .css3-tabstrip input[type="radio"]:disabled + label {
                    opacity: .5;
                    cursor: no-drop;
                }

        .auto-style2 {
            height: 40px;
        }

         /*CSS of Textbox*/
        .textbox {
            height: 25px;
            width: 175px;
            border: 1px solid #20B2AA;
            color: #20B2AA;
            -moz-box-shadow: 0 2px 4px #66CDAA inset;
            -webkit-box-shadow: 0 2px 4px #66CDAA inset;
            box-shadow: 0 2px 4px #66CDAA inset;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
        }

            .textbox:focus {
                background-color: #E0FFFF;
                outline: 0;
            }

        .auto-style3 {
            width: 431px;
        }

    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     <table width="100%">
         <tr>
            <td style="font-family: quark; font-size: 20pt; font-weight: bold; color: #000000; border-radius:15px; " class="auto-style2">&nbsp;&nbsp; Alarm</td>
        </tr>
         <tr><td style="background-color: #666666"></td></tr>
         <tr>
             <td>
               <%--  <asp:Timer ID="Timer1" runat="server" Interval="30000">
                 </asp:Timer>
                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                 </asp:ScriptManager>--%>
             </td>
         </tr>
    </table>
   

<%--    <table width="100%" style="text-align: center; font-family: quark; font-size: 12pt; color: #000000;">
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>

    </table>--%>
    <table width="100%" style="text-align: center; font-family: quark; font-size: 12pt; color: #000000;">
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: center">
                <table width="100%">
                    <tr>
                        <td style="text-align: right; font-family: quark; font-weight: bold;">Server IP :
                        </td>
                        <td style="text-align: left">&nbsp;

                                        <asp:TextBox ID="txtAServerIP" runat="server" CssClass="textbox " oncopy="return false" oncut="return false" onpaste="return false" OnKeypress="return isNumberPKey(event)"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-family: quark; font-weight: bold;">Server Name :
                        </td>
                        <td style="text-align: left">&nbsp;

                                        <asp:TextBox ID="txtAServerName" runat="server" CssClass="textbox " OnKeypress="return isServerNameKey(event)"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-family: quark; font-weight: bold;">Specific Problem :
                        </td>
                        <td style="text-align: left">&nbsp;

                                        <asp:TextBox ID="txtAProblem" runat="server" CssClass="textbox " OnKeypress="return isServerNameKey(event)"></asp:TextBox>

                        </td>
                    </tr>

                </table>
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ImageButton ID="btnSearch" runat="server" Height="35px" ImageUrl="~/Images/btnSearch.png" Width="132px" Enabled="False" />
            </td>
        </tr>
       
        <tr>
            <td></td>
            <td style="text-align: left">
                <asp:ImageButton ID="btnExportServerA" runat="server" OnClick="ExportServerAlarm" ImageUrl="~/Images/icon_Excel.png" />
            </td>
            <td></td>
        </tr>

        <tr>
            <td width="5%" rowspan="2"></td>
            <td style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium; border-top-left-radius: 10px; border-top-right-radius: 10px;">
                <table>
                    <tr>
                        <td>&nbsp;</td>
                        <td style="font-family: quark; font-weight: bold; color: #FFFFFF; font-size: 14pt">&nbsp;List Alarm</td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvAlarmServer" runat="server"  BackColor="White" BorderColor="#CCCCCC" 
                                BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" AllowPaging="True" Font-Size="10pt">
                                <Columns>
                                    <asp:TemplateField HeaderText="id" SortExpression="id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="No" HeaderText="No.">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:ButtonField HeaderText="Server Name" CommandName="Detail" DataTextField="ServerName" Text="ServerName" />
                                    <asp:BoundField DataField="HostIP" HeaderText="Server IP">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SpecificProblem" HeaderText="Specific Problem">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AlarmActivity" HeaderText="Alarm Type" />
                                    <asp:TemplateField HeaderText="Severity" SortExpression="Severity" Visible="true">
                                        <ItemTemplate>
                                            <asp:Image ID="Minor" runat="server" ImageUrl="Images/Severity_Yellow.png" Visible='<%# IIf(Eval("Severity").ToString() = "Minor", True, False)%>' />
                                            <asp:Image ID="Major" runat="server" ImageUrl="Images/Severity_Orange.png" Visible='<%# IIf(Eval("Severity").ToString() = "Major", True, False)%>' />
                                            <asp:Image ID="Critical" runat="server" ImageUrl="Images/Severity_Red.png" Visible='<%# IIf(Eval("Severity").ToString() = "Critical", True, False)%>' />
                                            <asp:Label ID="lblSeverity" runat="server" Text='<%# Bind("Severity")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Value" HeaderText="Value">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AlarmQty" HeaderText="Alarm Qty." />
                                    <asp:BoundField DataField="CreatedDate" HeaderText="Create Date">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UpdatedDate" HeaderText="Update Date">

                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                            <div hidden="hidden">
                                <asp:GridView ID="gvAlarmS2" runat="server"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Font-Bold="True">
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
                                        <asp:BoundField DataField="HostIP" HeaderText="Server IP">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SpecificProblem" HeaderText="Specific Problem">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AlarmActivity" HeaderText="Alarm Type" />
                                        <asp:TemplateField HeaderText="Severity" SortExpression="Severity" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSeverity" runat="server" Text='<%# Bind("Severity")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Value" HeaderText="Value">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AlarmQty" HeaderText="Alarm Qty." />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="Create Date">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UpdatedDate" HeaderText="Update Date">

                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>

                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
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
            </td>
            <td width="5%" rowspan="2"></td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>

    </table>


    <%--<div class="css3-tabstrip" >
    <ul>
      
        <li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-1" /><label for="css3-tabstrip-0-1">List Alarm</label>
            <div>
               
                <table width="100%" style="text-align: center; font-family: quark; font-size: 12pt; color: #000000;">
                    
                     
                    
                </table>
            </div>
        </li>
       <%-- <li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-2" /><label for="css3-tabstrip-0-2">List Alert</label>
             <div>

             </div>
        </li>
    </ul>
</div>--%>
</asp:Content>


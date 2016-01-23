<%@ Page Title="" Language="VB" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="false" CodeFile="frmHistory.aspx.vb" Inherits="_Default" enableEventValidation ="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        /*Textbox Rounded Corner */
.tb5 {
	border:2px solid #456879;
	border-radius:10px;
	height: 22px;
	width: 230px;
}
          .auto-style1 {
          }
          .auto-style2 {
              height: 34px;
          }
          .auto-style3 {
              height: 25px;
          }

           /*CSS of Textbox*/
        .textbox {
            border:2px solid #456879;
	        border-radius:10px;
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

        .auto-style4 {
        }
        .auto-style5 {
            height: 25px;
            width: 419px;
        }

            /*style css of button*/
        .myButton {
            -moz-box-shadow: inset 0px 1px 3px 0px #199993;
            -webkit-box-shadow: inset 0px 1px 3px 0px #199993;
            box-shadow: inset 0px 1px 3px 0px #199993;
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #11d6af), color-stop(1, #40998d));
            background: -moz-linear-gradient(top, #11d6af 5%, #40998d 100%);
            background: -webkit-linear-gradient(top, #11d6af 5%, #40998d 100%);
            background: -o-linear-gradient(top, #11d6af 5%, #40998d 100%);
            background: -ms-linear-gradient(top, #11d6af 5%, #40998d 100%);
            background: linear-gradient(to bottom, #11d6af 5%, #40998d 100%);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#11d6af', endColorstr='#40998d',GradientType=0);
            background-color: #11d6af;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            border: 1px solid #139e7b;
            display: inline-block;
            cursor: pointer;
            color: #ffffff;
            font-family: Quark;
            font-size: 15px;
            font-weight: bold;
            padding: 5px 28px;
            text-decoration: none;
            text-shadow: 0px -1px 0px #0da16b;
        }

            .myButton:hover {
                background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #40998d), color-stop(1, #11d6af));
                background: -moz-linear-gradient(top, #40998d 5%, #11d6af 100%);
                background: -webkit-linear-gradient(top, #40998d 5%, #11d6af 100%);
                background: -o-linear-gradient(top, #40998d 5%, #11d6af 100%);
                background: -ms-linear-gradient(top, #40998d 5%, #11d6af 100%);
                background: linear-gradient(to bottom, #40998d 5%, #11d6af 100%);
                filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#40998d', endColorstr='#11d6af',GradientType=0);
                background-color: #40998d;
            }

            .myButton:active {
                position: relative;
                top: 1px;
            }

    </style>
    <script>
        //Validate textbox number'0-9' & decimal point '.'

        function isNumberPKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode != 46))
                return false;

            return true;

        }

            //Validate textbox Specific Problem
            function isSpecificKey(evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if (charCode > 31 && (charCode < 48 || charCode > 57))
                    if (charCode > 31 && (charCode < 65 || charCode > 90))
                        if (charCode > 31 && (charCode < 97 || charCode > 122))
                            if (charCode > 31 && (charCode < 3585 || charCode > 3642) && (charCode < 3648 || charCode > 3660))
                                if (charCode > 31 && (charCode != 32))
                                    if (charCode > 31 && (charCode != 37))
                                        if (charCode > 31 && (charCode != 46))
                                            if (charCode > 31 && (charCode != 45))
                                                return false;

                return true;
            }
      

       
  
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <%--  <asp:UpdatePanel runat="server" ><ContentTemplate >
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
     <div runat="server" >


         <table style="background-color: #AFEEEE; width: 100%">
             
             <tr>
                 <td colspan="5" style="font-family: quark; font-size: 20pt; font-weight: bold; color: #000000; border-radius: 15px;">&nbsp;&nbsp; History</td>                  
             </tr>
              <tr><td colspan="5" style="background-color: #666666"></td></tr>
             <tr>
                 <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt; font-weight: bold">

                     Server Name :</td>
                 <td>
                     
                <asp:TextBox ID="txtServerName" runat="server" CssClass="textbox "  oncopy="return false" oncut="return false" onpaste="return false" Height="25px" Width="200px"></asp:TextBox>
                     
                 </td>
                 <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt; font-weight: bold">

                     Alam Date :</td>
                 <td style="font-weight: bold;color: #006666;">
                     <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Height="25px" Width="150px" ReadOnly="True" TextMode="Date" Enabled="False"></asp:TextBox>
                     <asp:ImageButton ID="ImgCalendarF" runat="server" ImageUrl="~/Images/icon_Calendar.png" />

                     &nbsp; To&nbsp;
               <asp:TextBox ID="txtToDate" runat="server" CssClass="textbox" Height="25px" Width="150px" ReadOnly="True" TextMode="Date" Enabled="False"></asp:TextBox>
                     <asp:ImageButton ID="ImgCalendarT" runat="server" ImageUrl="~/Images/icon_Calendar.png" />

                     <br />
                     <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" Visible="False">
                         <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                         <NextPrevStyle VerticalAlign="Bottom" />
                         <OtherMonthDayStyle ForeColor="#808080" />
                         <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                         <SelectorStyle BackColor="#CCCCCC" />
                         <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                         <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                         <WeekendDayStyle BackColor="#FFFFCC" />
                     </asp:Calendar>
                     <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Visible="False" Width="200px">
                         <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                         <NextPrevStyle VerticalAlign="Bottom" />
                         <OtherMonthDayStyle ForeColor="#808080" />
                         <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                         <SelectorStyle BackColor="#CCCCCC" />
                         <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                         <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                         <WeekendDayStyle BackColor="#FFFFCC" />
                     </asp:Calendar>
                 </td>
                 <td>

                 </td>
             </tr>
             <tr>
                 <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt; font-weight: bold">Host IP :</td>
                 <td>
                     <asp:TextBox ID="txtIP" runat="server" CssClass="textbox " OnKeypress="return isNumberPKey(event)" oncopy="return false" oncut="return false" onpaste="return false" Height="25px" Width="200px"></asp:TextBox>
                 </td>
                 <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt; font-weight: bold">Time :</td>
                 <td style="font-weight: bold;color: #006666;">
                     <asp:TextBox ID="txtTime" runat="server" CssClass="textbox" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)" Height="25px" Width="150px" MaxLength="5"></asp:TextBox>
                     &nbsp; To&nbsp;
                    <asp:TextBox ID="txtToTime" runat="server" CssClass="textbox" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)" Height="25px" Width="150px" MaxLength="5"></asp:TextBox>
                 </td>
                 <td></td>
             </tr>
             <tr>
                 <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt; font-weight: bold">
                     Alam Type :</td>
                 <td>

                <asp:DropDownList ID="drpAlarmT" runat="server" Height="25px" Width="203px" CssClass="textbox">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>RAM</asp:ListItem>
                    <asp:ListItem>CPU</asp:ListItem>
                    <asp:ListItem>HDD</asp:ListItem>
                    <asp:ListItem>Service</asp:ListItem>
                    <asp:ListItem>Process</asp:ListItem>
                    <asp:ListItem>FileSize</asp:ListItem>
                    <asp:ListItem>Port</asp:ListItem>
                </asp:DropDownList>

                 </td>
                 <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt; font-weight: bold">Order Type :</td>
                 <td>

                <asp:DropDownList ID="drpViewby" runat="server" Height="25px" Width="146px" AutoPostBack="True" CssClass="textbox">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>ServerName</asp:ListItem>
                    <asp:ListItem>CreateDate</asp:ListItem>
                    <asp:ListItem>ClearDate</asp:ListItem>
                </asp:DropDownList>

                 </td>
                 <td>

                 </td>
             </tr>
             <tr>
                 <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt; font-weight: bold">                     

                     Specific Problem :</td>
                 <td>

                <asp:TextBox ID="txtSpecProb" runat="server" CssClass="textbox" OnKeypress="return isSpecificKey(event)" Height="25px" Width="200px"></asp:TextBox>

                 </td>
                 <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">

                 </td>
                 <td>

                 </td>
                 <td>

                 </td>
             </tr>
             <tr>
                 <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">
                   
                 </td>
                 <td>

                 </td>
                 <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">

                 </td>
                 <td>

                 </td>
                 <td>

                 </td>
             </tr>

           

             <tr>
                 <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">
                   
                     &nbsp;</td>
                 <td>

                     &nbsp;</td>
                 <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">

                     &nbsp;</td>
                 <td>

                     &nbsp;</td>
                 <td>

                     &nbsp;</td>
             </tr>

           

             <tr>
                 <td style="color: #006666; text-align: center; font-family: Quark; font-size: 12pt;" colspan="4">
                   
                <asp:Button ID="Button1" runat="server" Text="Search" CssClass="myButton" />
                &nbsp;<asp:Button ID="Button2" runat="server" Text="Clear" CssClass="myButton" Width="128px" />
                   
                 </td>
                 <td>

                     &nbsp;</td>
             </tr>

           

         </table>













 
    <table style="width: 100%">
        
       

         <tr>
           <td class="auto-style5" style="text-align: right; font-family: quark; font-size: 12pt; font-weight: bold"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            
            <td style="text-align: left">
                <asp:ImageButton ID="btnExportHistory" runat="server" OnClick="ExportHistory" ImageUrl="~/Images/icon_Excel.png" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="2" style="text-align: center">
                <asp:GridView ID="gvAlarmH" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Font-Bold="True" Font-Names="Quark" Font-Size="11pt" Width="1000px" OnPageIndexChanging ="gvAlarmH_PageIndexChanging" PageSize="20" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="No" HeaderText="No.">
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ServerName" HeaderText="Server Name" >
                        <ItemStyle HorizontalAlign="Left" Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HostIP" HeaderText="Host IP" >
                        <ItemStyle HorizontalAlign="Left" Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SpecificProblem" HeaderText="Specific Problem" >
                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AlarmActivity" HeaderText="Alarm Type" >
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
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
                        <asp:BoundField DataField="Value" HeaderText="Value" >
                        <ItemStyle HorizontalAlign="Left" Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AlarmQty" HeaderText="Alarm Qty." >
                        <ItemStyle Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FlagAlarm" HeaderText="Status" >
                        </asp:BoundField>
                        <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" >
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ClearDate" HeaderText="Clear Date">
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="" PageButtonCount="20" Position="TopAndBottom" PreviousPageText="" />
                  
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <div hidden="hidden">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Font-Bold="True" Font-Names="Quark" Font-Size="11pt" Width="1000px" OnPageIndexChanging ="gvAlarmH_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="No" HeaderText="No.">
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ServerName" HeaderText="Server Name" >
                        <ItemStyle HorizontalAlign="Left" Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HostIP" HeaderText="Host IP" >
                        <ItemStyle HorizontalAlign="Left" Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SpecificProblem" HeaderText="Specific Problem" >
                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AlarmActivity" HeaderText="Alarm Type" >
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Severity" SortExpression="Severity" Visible="true">
                            <ItemTemplate>
                               <asp:Label ID="lblSeverity" runat="server" Text='<%# Bind("Severity")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Value" HeaderText="Value" >
                        <ItemStyle HorizontalAlign="Left" Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AlarmQty" HeaderText="Alarm Qty." >
                        </asp:BoundField>
                        <asp:BoundField DataField="FlagAlarm" HeaderText="Status" >
                        </asp:BoundField>
                        <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" >
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ClearDate" HeaderText="Clear Date">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="" PageButtonCount="20" Position="TopAndBottom" PreviousPageText="" />
                  
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
</div>
            </td>
        </tr>
    </table></div>
      <%-- </ContentTemplate>
       </asp:UpdatePanel>--%>
</asp:Content>


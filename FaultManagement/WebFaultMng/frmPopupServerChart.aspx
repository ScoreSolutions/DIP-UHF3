<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmPopupServerChart.aspx.vb" Inherits="frmPopupServerChart" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script language="Javascript" type="text/javascript" src="FusionCharts/FusionCharts.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 21px;
            
        }
        .body{
            background-color :#F0F0F0 ;
        }
        .auto-style4 {
            width: 40px;
        }
        .auto-style8 {
            width: 194px;
        }
        .auto-style10 {
            width: 267px;
        }
        .auto-style11 {
            width: 28%;
        }
        .auto-style12 {
            width: 27%;
        }
        .auto-style13 {
            height: 29px;
        }
        .auto-style14 {
            width: 123px;
        }
        .auto-style15 {
            width: 86px;
        }
        .auto-style16 {
            width: 98px;
        }
        .auto-style17 {
            width: 82px;
        }
        </style>
  
<%--    <script src="assets/js/jquery-2.0.3.min.js"></script>
    <script src="assets/js/jQuery.Marquee/jquery.marquee.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.core.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.tooltips.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.dynamic.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.key.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.drawing.rect.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.line.js"></script>--%>

</head>
<body class="body">
    <form id="form1" runat="server">
      
<asp:UpdatePanel runat="server" ><ContentTemplate >
    <div>
        <table width="100%">
            <tr>
                <td class="auto-style11" style="border: thin solid #C0C0C0; vertical-align: top; width:20%;">
                    <table width="100%">
                        <tr style="background-color: #33CCFF; border: thin groove #C0C0C0">
                            <td>

                                <asp:Label ID="lblAviChart" runat="server" Font-Bold="True" Font-Names="Quark" Font-Size="12pt">Today Available Chart</asp:Label>

                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Chart ID="ServerChart" runat="server" Height="269px" Width="244px" Palette="None" PaletteCustomColors="LawnGreen; Red" BackColor="Transparent" BackImageTransparentColor="Transparent">
                        <Series>
                            <asp:Series Name="Series1" ChartType="Pie" Font="Quark, 9.75pt, style=Bold" IsValueShownAsLabel="True" Legend="Legend1" XValueMember="0" YValueMembers="1" YValueType="Int32" BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent" Color="Transparent"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent">
                                <AxisY TitleFont="Quark, 11.25pt, style=Bold" TitleForeColor="White">
                                </AxisY>
                                <AxisX TitleFont="Quark, 11.25pt, style=Bold" TitleForeColor="White">
                                </AxisX>
                                <Area3DStyle Enable3D="True" />
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" TitleFont="Quark, 11.25pt, style=Bold" BackColor="Transparent" BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent" Font="Quark, 9.75pt" IsTextAutoFit="False">
                            </asp:Legend>
                        </Legends>
                    </asp:Chart>
                </td>

                <td style="border: thin solid #C0C0C0; vertical-align: middle; width:30%;">
                    <table>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: right" class="auto-style8">Server Name :</td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: left" class="auto-style10">&nbsp;

                                <asp:Label ID="lblServerName" runat="server">-</asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtkeepIP" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                            </td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: right" class="auto-style8">Server IP :</td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: left" class="auto-style10">&nbsp;

                                <asp:Label ID="lblServerIP" runat="server">-</asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1"></td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: right" class="auto-style8">Mac Address :</td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: left" class="auto-style10">&nbsp;

                                <asp:Label ID="lblMac" runat="server">-</asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1"></td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: right" class="auto-style8">OS :</td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: left" class="auto-style10">&nbsp;

                                <asp:Label ID="lblOS" runat="server">-</asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1"></td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: right" class="auto-style8">Project Name :</td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: left" class="auto-style10">&nbsp;

                                <asp:Label ID="lblProject" runat="server">-</asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1"></td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: right" class="auto-style8">Location/No. :</td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: left" class="auto-style10">&nbsp;

                                <asp:Label ID="lblLocation" runat="server">-</asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1"></td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: right" class="auto-style8">Name :</td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: left" class="auto-style10">&nbsp;

                                <asp:Label ID="lblName" runat="server">-</asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1"></td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: right" class="auto-style8">E-mail :</td>
                            <td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #000000; text-align: left" class="auto-style10">&nbsp;

                                <asp:Label ID="lblEmail" runat="server">-</asp:Label>

                            </td>
                        </tr>
                    </table>
                </td>

                <td style="border: thin solid #C0C0C0; vertical-align: top; text-align: left; width:25%;">
                    <table width="100%">
                        <tr>
                            <td style="height:300px; vertical-align: top; ">
                                <table width="100%">
                                    <tr style="background-color: #33CCFF; border: thin groove #C0C0C0">
                                        <td style="text-align: center">

                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Quark" Font-Size="12pt">Process</asp:Label>

                                        </td>
                                    </tr>
                                </table>

                                <center>
                                    <div style="width: 300px; height: 280px; overflow-y: scroll;">
                                    <asp:GridView ID="gvProcess" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Quark" Font-Size="12pt" ForeColor="#333333" GridLines="None" Width="272px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="WindowProcessName" HeaderText="Process Name">
                                                <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Status" SortExpression="ProcessAlive" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="Images/icon_Red.png" Visible='<%# IIf(Eval("ProcessAlive").ToString() = "N", True, False)%>' />
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/icon_Green.png" Visible='<%# IIf(Eval("ProcessAlive").ToString() = "Y", True, False)%>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </div>
                                </center>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 190px; text-align: center;">

                                    <tr>
                                        <td class="auto-style15">
                                            <asp:Label ID="lblStatus4" runat="server" Font-Bold="False" Font-Names="Quark" Font-Size="8pt">RUNNING </asp:Label>
                                        </td>
                                        <td class="auto-style17">
                                            <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/icon_Green.png" Height="18px" Width="18px" />
                                        </td>
                                        <td class="auto-style15">
                                            <asp:Label ID="lblStatus5" runat="server" Font-Bold="False" Font-Names="Quark" Font-Size="8pt">DOWN</asp:Label>
                                        </td>
                                        <td class="auto-style17">
                                            <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/icon_Red.png" Height="18px" Width="18px" />
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                    </table>
                </td>

                <td style="border: thin solid #C0C0C0; vertical-align: top; text-align: left; width:25%;">
                    <table width="100%">
                        <tr>
                            <td style="height: 300px; vertical-align: top;">
                                <table width="100%">
                                    <tr style="background-color: #33CCFF; border: thin groove #C0C0C0">
                                        <td style="text-align: center">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Quark" Font-Size="12pt">Service</asp:Label>
                                        </td>
                                    </tr>
                                </table>

                                <center>
                                    <div style="width: 300px; height: 280px; overflow-y: scroll;">
                                    <asp:GridView ID="gvService" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Quark" Font-Size="12pt" ForeColor="#333333" GridLines="None" Width="272px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="WindowServiceName" HeaderText="Service Name">
                                                <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Status" SortExpression="ServiceStatus" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="Images/icon_Red.png" Visible='<%# IIf(Eval("ServiceStatus").ToString() = "STOPPED", True, False)%>' />
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="Images/icon_Green.png" Visible='<%# IIf(Eval("ServiceStatus").ToString() = "RUNNING", True, False)%>' />
                                                    <asp:Image ID="Image5" runat="server" ImageUrl="Images/icon_Black.png" Visible='<%# IIf(Eval("ServiceStatus").ToString() = "Not_Service", True, False)%>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                    </div>
                                </center>
                                
                                
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table style=" width: 100%; text-align: center; ">

                                    <tr>
                                        <td>
                                            <asp:Label ID="lblStatus0" runat="server" Font-Bold="False" Font-Names="Quark" Font-Size="8pt">RUNNING </asp:Label>
                                        </td>
                                        <td >
                                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/icon_Green.png" Height="18px" Width="18px" />
                                        </td>
                                        <td >
                                            <asp:Label ID="lblStatus1" runat="server" Font-Bold="False" Font-Names="Quark" Font-Size="8pt">STOPPED</asp:Label>
                                        </td>
                                        <td >
                                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/icon_Red.png" Height="18px" Width="17px" />
                                        </td>
                                        <td >
                                            <asp:Label ID="lblStatus2" runat="server" Font-Bold="False" Font-Names="Quark" Font-Size="8pt">NOT SERVICE</asp:Label>
                                        </td>
                                        <td >
                                            <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/icon_Black.png" Height="18px" Width="18px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>

        <table width="100%">
     
        <tr>
            <td style="background-color: #33CCFF; border: thin groove #C0C0C0" class="auto-style13">
                <asp:Label ID="lblCPUChart0" runat="server" Font-Bold="True" Font-Names="Quark" Font-Size="12pt" ForeColor="Black">CPU Chart</asp:Label>
                    </td>
            <td style="background-color: #33CCFF; border: thin groove #C0C0C0" class="auto-style13">
                <asp:Label ID="lblRAMChart0" runat="server" Font-Bold="True" Font-Names="Quark" Font-Size="12pt">RAM Chart</asp:Label>
                    </td>
            <td style="background-color: #33CCFF; border: thin groove #C0C0C0" class="auto-style13">
                <asp:Label ID="lblDriveChart0" runat="server" Font-Bold="True" Font-Names="Quark" Font-Size="12pt">Drive Chart</asp:Label>
                    </td>
           
        </tr>
        <tr>
            
            <td class="auto-style11" style="border: thin solid #C0C0C0; vertical-align: top; text-align: center; width:20%;">
                <asp:Chart ID="CPUChart" runat="server" Height="185px" Width="231px" Palette="None" PaletteCustomColors="IndianRed; MediumSeaGreen" BackColor="Transparent" BackImageTransparentColor="Transparent">
                <Series>
                    <asp:Series Name="Series1" ChartType="Pie" Font="Quark, 9.75pt, style=Bold" IsValueShownAsLabel="True" LabelForeColor="Snow" Legend="Legend1" XValueMember="0" YValueMembers="1" YValueType="Int32" BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent" Color="Transparent"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent">
                        <AxisY TitleFont="Quark, 11.25pt, style=Bold" TitleForeColor="White">
                        </AxisY>
                        <AxisX TitleFont="Quark, 11.25pt, style=Bold" TitleForeColor="White">
                        </AxisX>
                        <Area3DStyle Enable3D="True" />
                    </asp:ChartArea>
                </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend1" TitleFont="Quark, 11.25pt, style=Bold" BackColor="Transparent" BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent" Font="Quark, 9.75pt" IsTextAutoFit="False">
                        </asp:Legend>
                    </Legends>
                </asp:Chart>
                <asp:Label ID="lblCPU" runat="server" Visible="False"></asp:Label>
          

                <center>
                    <table style="font-family: quark; font-size: 12pt; font-weight: bold">
                        <tr>
                            <td style="border-style: solid; border-width: thin; font-family: quark; font-size: 12pt; font-weight: bold; text-align: right;">Minor :</td>
                            <td style="border-width: thin; border-style: solid;"><asp:Label ID="lblCMinor" runat="server">-</asp:Label></td>
                            <td style="border-style: solid; border-width: thin; font-family: quark; font-size: 12pt; font-weight: bold; text-align: right;">Critical :</td>
                            <td style="border-width: thin; border-style: solid;"><asp:Label ID="lblCCritical" runat="server">-</asp:Label></td>
                        </tr>
                        <tr>
                            <td style="border-style: solid; border-width: thin; font-family: quark; font-size: 12pt; font-weight: bold; text-align: right;">Major :</td>
                            <td style="border-width: thin; border-style: solid;"><asp:Label ID="lblCMajor" runat="server">-</asp:Label></td>
                            <td style="border-style: solid; border-width: thin; font-family: quark; font-size: 12pt; font-weight: bold; text-align: right;">Usage :</td>
                            <td style="border-width: thin; border-style: solid;"><asp:Label ID="lblCOver" runat="server">-</asp:Label></td>
                        </tr>
                    </table>
                </center>


                 <asp:Chart ID="CPULogChart" runat="server">
                    <Series>
                        <asp:Series Name="Series1" Font="7pt">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"  Area3DStyle-Enable3D="true">
                            <AxisY TitleFont="Quark, 10pt, style=Bold" TitleForeColor="Black" Title="Percent">
                            </AxisY>
                            <AxisX TitleFont="Quark, 10pt, style=Bold" TitleForeColor="Black"  Title="Time" >
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>

                <%--<canvas id="cvsline" width="700" height="300" !style="border:1px solid #ccc">[No canvas support]</canvas>
               
                <asp:Literal ID="FCLiteral3" runat="server"></asp:Literal>--%>
            </td>

            <td style="border: thin solid #C0C0C0; vertical-align: top; text-align: center;   width:20%;" class="auto-style12;">
                <asp:Chart ID="RAMChart" runat="server" Height="185px" Width="230px" Palette="None" PaletteCustomColors="Tomato; Turquoise" BackColor="Transparent">
                <Series>
                    <asp:Series Name="Series1" ChartType="Pie" Font="Quark, 9.75pt, style=Bold" IsValueShownAsLabel="True" LabelForeColor="Snow" Legend="Legend1" XValueMember="0" YValueMembers="1" YValueType="Int32"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="Transparent">
                        <AxisY TitleFont="Quark, 11.25pt, style=Bold" TitleForeColor="White">
                        </AxisY>
                        <AxisX TitleFont="Quark, 11.25pt, style=Bold" TitleForeColor="White">
                        </AxisX>
                        <Area3DStyle Enable3D="True" />
                    </asp:ChartArea>
                </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend1" TitleFont="Quark, 11.25pt, style=Bold" BackColor="Transparent" Font="Quark, 9.75pt" IsTextAutoFit="False">
                        </asp:Legend>
                    </Legends>
            </asp:Chart>
                <asp:Label ID="lblRAM" runat="server" Visible="False"></asp:Label>

                <center>
                     <table>
                        <tr>
                            <td  style="border-style: solid; border-width: thin; font-family: quark; font-size: 12pt; font-weight: bold; text-align: right;">Minor :</td>
                            <td style="border-style: solid; border-width: thin; font-family: quark; font-size: 12pt; font-weight: bold"><asp:Label ID="lblRMinor" runat="server">-</asp:Label></td>
                            <td style="border-style: solid; border-width: thin; font-family: quark; font-size: 12pt; font-weight: bold; text-align: right;">Critical :</td>
                            <td style="border-style: solid; border-width: thin; font-family: quark; font-size: 12pt; font-weight: bold"><asp:Label ID="lblRCritical" runat="server">-</asp:Label></td>
                        </tr>
                        <tr>
                            <td style="border-style: solid; border-width: thin; font-family: quark; font-size: 12pt; font-weight: bold; text-align: right;">Major :</td>
                            <td style="border-style: solid; border-width: thin; font-family: quark; font-size: 12pt; font-weight: bold"><asp:Label ID="lblRMajor" runat="server">-</asp:Label></td>
                            <td style="border-style: solid; border-width: thin; font-family: quark; font-size: 12pt; font-weight: bold; text-align: right;">Usage :</td>
                            <td style="border-style: solid; border-width: thin; font-family: quark; font-size: 12pt; font-weight: bold"><asp:Label ID="lblROver" runat="server">-</asp:Label></td>
                        </tr>
                    </table>
                 </center>

                  <asp:Chart ID="RAMLogChart" runat="server">
                    <Series>
                        <asp:Series Name="Series1" Font="7pt">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"  Area3DStyle-Enable3D="true">
                            <AxisY TitleFont="Quark, 10pt, style=Bold" TitleForeColor="Black" Title="Percent">
                            </AxisY>
                            <AxisX TitleFont="Quark, 10pt, style=Bold" TitleForeColor="Black"  Title="Time" >
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>

            <td width="25%" style="border: thin solid #C0C0C0; vertical-align: top; text-align: center;   width:60%;" aria-dropeffect="none" aria-readonly="True">

                <br />
                <br />

                <asp:Chart ID="DriveChart" runat="server" Palette="Pastel" PaletteCustomColors="255, 192, 192; 255, 255, 192; 192, 255, 192; 192, 255, 255; 192, 192, 255; 255, 192, 128" BackColor="Transparent" Height="250px" Width="230px">
                    <Series>
                        <asp:Series Name="Series1" Palette="Pastel" Font="Quark, 9.75pt, style=Bold" IsValueShownAsLabel="True" Legend="Legend1">
                            <EmptyPointStyle IsValueShownAsLabel="True" />
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BackColor="Transparent" AlignmentOrientation="Horizontal" BorderColor="White">
                            <AxisY IsStartedFromZero="False" TitleFont="Quark, 11.25pt" Title="Percent Used">
                                <ScaleBreakStyle Enabled="True" />
                            </AxisY>
                            <AxisX TitleFont="Quark, 11.25pt" Title="Drive">
                                <ScaleBreakStyle LineColor="White" />
                            </AxisX>
                            <Area3DStyle Enable3D="True" />
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>

                
               <center>
                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
              
                <asp:GridView ID="gvDriveSeverity" runat="server" AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                    GridLines="Vertical" Width="277px" Font-Bold="True" Font-Names="Quark" Font-Size="10pt">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="DriveLetter" HeaderText="Drive">
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Config" HeaderText="Config Value (Minor,Major,Critical)" NullDisplayText="-">
                        <ItemStyle Width="65px" HorizontalAlign="Center"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="PercentUse" HeaderText="Usage" NullDisplayText="-">
                        <ItemStyle Width="60px" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                </center>
                

            </td>
            
        </tr>
     
    </table>

 <table width="100%">
     <tr>

          <td style="background-color: #33CCFF; border: thin groove #C0C0C0" class="auto-style13">
                <asp:Label ID="lblFileSize" runat="server" Font-Bold="True" Font-Names="Quark" Font-Size="12pt">List Files Size </asp:Label>
                    </td>
     </tr>
     <tr>
         <td style="vertical-align: top" >

              
                <asp:GridView ID="gvFileSize" runat="server" AutoGenerateColumns="False" CellPadding="3" Font-Names="Quark" Font-Size="12pt" Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                    <Columns>
                        <asp:BoundField DataField="FileName" HeaderText="Files " >
                        <ItemStyle Width="50%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Config" HeaderText="Config Value (Minor,Major,Critical)" >
                        <ItemStyle Width="30%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Used" HeaderText="Size">
                        <ItemStyle Width="20%" HorizontalAlign="Center"/>
                        </asp:BoundField>
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
                
                
                    <br />
                   
                    <br />
               
          </td>

     </tr>

 </table>

  


    </div>
            
        <asp:Timer ID="Timer1" runat="server" Interval="30000">
        </asp:Timer>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

      </ContentTemplate>
    </asp:UpdatePanel>





       <%--     <script>
                //$(document).ready(function () {

                //})

                ShowGraphLine();
                function ShowGraphLine() {
                    var ServerIP = $('#' + '<%=Me.FindControl("lblServerIP").ClientID%>').text();
                var param = "{'ServerIP':" + JSON.stringify(ServerIP) + "}";
                var dataurl = 'WebService.asmx/LoadCPULog';
                $.ajax({
                    "type": "POST",
                    "dataType": 'json',
                    "contentType": "application/json; charset=utf-8",
                    "url": dataurl,
                    "data": param,
                    "success": function (data) {
                        //alert(data.d);
                        var temp = data.d.split('|');
                        var data1 = temp[0].split(',');
                        var label1 = temp[1].split(',');
                        if (temp.length > 0) {//Check null value
                            var data = [];
                            var labels = [];
                            for (var i = 0; i < data1.length; ++i) {
                                // data1[i] = RGraph.log(data1[i], 10);
                                data.push(parseInt(data1[i]));//add value to array
                                labels.push(label1[i]);
                            }

                            var line = new RGraph.Line({ id: 'cvsline', data: data, options: { outofbounds: true } })

                            line.set({
                                numyticks: 6,
                                ymax: 5000,

                                gutter: {
                                    left: 65
                                },
                                labels: labels,
                                numxticks: 7,
                                background: {
                                    grid: {
                                        autofit: {
                                            numhlines: 6,
                                            numvlines: 7
                                        }
                                    }
                                }
                            }).draw()

                        }



                    },
                    error: function (xhr, status, error) {

                    }
                });

            }
        </script>--%>
    </form>
    

</body>
</html>

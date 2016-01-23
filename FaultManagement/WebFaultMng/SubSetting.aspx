<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SubSetting.aspx.vb" Inherits="SubSetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel ="stylesheet" href ="CSS/autocomplete.css" type ="text/css" />
    <script type ="text/javascript" src ="Script/jscautocomplete.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    

      
      <script type="text/Javascript">

          function getServerIP() {

              CellValue = "";
              var table = document.getElementById('<%=gvServerNameRAM.ClientID%>');
              var rowsCount = ('<%=gvServerNameRAM.Rows.Count %>');
              var ServerIP;
              my_word_list = new Array();
             for (i = 1; i <= rowsCount; i++) {

                 my_word_list[my_word_list.length] = table.rows[i].cells[1].innerText;
               
             }
             alert(CellValue);
          }

          function test() {
              var d = "";
              var dd;
              var table = document.getElementById('<%=gvServerNameRAM.ClientID%>');
              var rowsCount = ('<%=gvServerNameRAM.Rows.Count %>')
              var jobValue = document.getElementById('my_textctrl').value;
              var input2 = document.getElementById('<%=txtServernameRAM.ClientID%>');
               


               for (i = 1; i <= rowsCount; i++) {
                   dd = table.rows[i].cells[1].innerText
                   if (jobValue == dd)
                   {
                       document.getElementById("<%=txtServername.ClientID%>").innerText = table.rows[i].cells[2].innerText
                       document.getElementById("<%=txtMacAddress.ClientID%>").innerText = table.rows[i].cells[3].innerText
                       d+=table.rows[i].cells[1].innerText;
                       d+=table.rows[i].cells[2].innerText;
                       d+= table.rows[i].cells[3].innerText;
                       
                   }
                
              }
               
          }
  
    $(function () {
        var overlay = $('<div id="overlay"></div>');
        $('.close').click(function () {
            $('.popup').hide();
            overlay.appendTo(document.body).remove();
            return false;
        });

        $('.x').click(function () {
            $('.popup').hide();
            overlay.appendTo(document.body).remove();
            return false;
        });

        $('.click').click(function () {
            overlay.show();
            overlay.appendTo(document.body);
            $('.popup').show();
            return false;
        });
       
    });
    function Close()
    {
        alert("Heelo");
  
    }

</script>

        <style type="text/css">
      .pageheader
       {
          width:2500px;
          height:110px;
          background-color:MediumTurquoise;
          background-color:  #36b0b6;
          position:fixed;
          top:0;
          /*right:0;*/
          left:0;
          /*margin-left:auto;
          margin-right:auto;*/
          z-index:99;
          clear:both;
          /*background: linear-gradient(to bottom, #1e5799 0%,#2989d8 50%,#207cca 51%,#7db9e8 100%);*/ 
       }
     

           .center{
             
              width:1024px;
              height:700px;
              margin-left:auto;
              margin-right:auto;
              background-color:#E3F3F9;
              
           }
        .body{
            background-color:#CCFFFF;
        }
 
ul.flipboard{
margin:0;
padding:0;
list-style:none;
-webkit-perspective: 10000px; /* larger the value, the less pronounced the 3D effect */
-moz-perspective: 10000px;
-o-perspective: 10000px;
perspective: 10000px;
}

ul.flipboard li{
display: inline-block;
width: 80px; /* dimensions of buttons. Do not add padding/margins inside this rule */
height: 80px;
margin-right: 10px; /* spacing between buttons */
background: #36b0b6;
font: bold 36px Arial; /* font size */
text-transform: uppercase;
text-align: center;
cursor: pointer;
}

ul.flipboard li a{
display:block;
width: 100%;
height: 100%;
color: black;
text-decoration: none;
outline: none;
-webkit-transition:all 300ms ease-out 0.1s; /* CSS3 transition. Last value is pause before transition play */
-moz-transition:all 300ms ease-out 0.1s;
-o-transition:all 300ms ease-out 0.1s;
transition:all 300ms ease-out 0.1s;
}

ul.flipboard li a span{
-moz-box-sizing: border-box;
-webkit-box-sizing: border-box;
box-sizing: border-box;
padding-top: 15px; /* Add top padding to "center" content */
display:block;
width: 100%;
height: 100%;
-webkit-transition:all 300ms ease-out 0.1s; /* CSS3 transition. Last value is pause before transition play */
-moz-transition:all 300ms ease-out 0.1s;
-o-transition:all 300ms ease-out 0.1s;
transition:all 300ms ease-out 0.1s;
}

ul.flipboard li a img{
border-width: 0;
}

ul.flipboard li:hover a{
-moz-transform: rotateY(180deg); /* flip horizontally 180deg*/
-webkit-transform: rotateY(180deg);
transform: rotateY(180deg);
background: #cef1ff; /* background color of button onmouseover */
-webkit-border-radius:7px;
-moz-border-radius:7px;
border-radius:7px;
-webkit-box-shadow:0 0 5px #eee inset;
-moz-box-shadow:0 0 5px #eee inset;
box-shadow:0 0 5px #eee inset;
}

ul.flipboard li:hover a span{
-moz-transform: rotateY(180deg); /* flip horizontally 180deg*/
-webkit-transform: rotateY(180deg);
transform: rotateY(180deg);
}


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
            top: 1px;
            left: 8px;
            height: 791px;
        }

            .css3-tabstrip li {
                vertical-align: top;
            }

                .css3-tabstrip li:first-child {
                    margin-left: 8px;
                }

                .css3-tabstrip li > div {
                    top: 33px;
                    bottom: -18px;
                    left: 0;
                    width: 97%;
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
            /*sss*/
#overlay {
position:fixed ;
top: 0;
left: 0;
width: 100%;
height: 100%;
background-color: #000;
filter:alpha(opacity=70);
-moz-opacity:0.7;
-khtml-opacity: 0.7;
opacity: 0.7;
z-index: 100;
display: none;
}
.content a{
text-decoration: none;
}
.popup{
width: 100%;
margin: 0 auto;
display: none;
position:absolute ;
z-index: 101;
}
.content{
min-width: 1000px;
width: 1000px;
min-height: 400px;
margin: 100px auto;
background: #f3f3f3;
position:absolute ;
z-index: 103;
padding: 10px;
border-radius: 5px;
box-shadow: 0 2px 5px #000;

}
.content p{
clear: both;
color: #555555;
text-align: justify;
}
.content p a{
color: #d91900;
font-weight: bold;
}
.content .x{
float: right;
height: 35px;
left: 22px;
position: relative;
top: -25px;
width: 34px;
}
.content .x:hover{
cursor: pointer;
}
</style>
</head>

<body class="body">


    <form id="form1" runat="server">
<div class='popup'>
<div class='content'>
<p>
      
</p>
        <table>
             <tr>
                 <td style="color: #006666;text-align: right; font-size:12pt;">
                    <asp:Label ID="Label2" runat="server" Text="Apply by"></asp:Label>   Server IP
                  </td>
                  <td>&nbsp;<asp:TextBox id="my_textctrl" runat="server" onkeyup='acAutoComplete("my_textctrl", event, my_word_list);' onblur='acDelayHide();' OnChange="test()" ></asp:TextBox>
                  </td>
              </tr>
             <tr>
                 <td style="color: #006666;text-align: right; font-size: 12pt;">
                  Server Name :
                 </td>
                 <td>
                  &nbsp;<asp:TextBox ID="txtServername" runat="server"  Font-Names="Quark" ForeColor="Black" Font-Size="11pt" OnMouseOver ="test()" ></asp:TextBox>
                 </td>
             </tr>
            <tr>
                 <td style="color: #006666;text-align: right; font-size: 12pt;">
                  Mac Address :
                 </td>
                 <td>
                  &nbsp;<asp:TextBox ID="txtMacAddress" runat="server"  Font-Names="Quark" ForeColor="Black" Font-Size="11pt" ></asp:TextBox>
                 </td>
             </tr>
        </table>

<a href="#" class='close'>Close</a>
    <asp:Label ID="Label3" runat="server" Text="Label" onclick="Close()"></asp:Label>
 <asp:GridView ID="gvServerNameRAM" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="id">
                <ItemTemplate>
                    <asp:Label ID="lblid" runat="server" text='<%# Bind ("id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Server IP">
                <ItemTemplate >
                    <asp:Label ID="lblServerIP" runat="server" Text='<%# Bind("HostIP") %>'>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Server Name">
                <ItemTemplate >
                    <asp:Label ID="lblServerName" runat="server" Text='<%# Bind ("ServerName") %>'>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mac Address">
                <ItemTemplate >
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("MacAddress")%>'>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
</div>  

         <table style="width: 100%">
            <tr class="pageheader">
                <td>
                    <table>
                        <tr>
                <td width="100px"></td>
                <td width="224px" style="text-align: right">
                    <asp:Image ID="Image1" runat="server" Height="95px" ImageUrl="~/Images/logo.png" />
                </td>
                <td width="60px"></td>
                <td style="vertical-align:bottom;">
                   <ul class="flipboard">
                        <li><a href="frmOverview.aspx"><span><img src="images/icon_Overview.png" title="Overview" /></span></a></li>
                        <li><a href="frmSetting.aspx"><span><img src="images/icon_Setting.png" title="Setting" /></span></a></li>
                        <li><a href="frmAlarm.aspx"><span><img src="images/icon_Alarm.png" title="Alarm" /></span></a></li>
                        <li><a href="frmHistory.aspx"><span><img src="images/icon_History.png" title="History" /></span></a></li>
                        <li><a href="frmReport.aspx"><span><img src="images/icon_Report.png" title="Report" /></span></a></li>
                        <li><a href="frmAdmin.aspx"><span><img src="images/icon_Admin.png" title="Admin" /></span></a></li>
                       
                    </ul>
                </td>
                            <td width="290px" style="text-align: right; vertical-align: top">
                                
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Quark" Font-Size="12pt"></asp:Label>
                                     &nbsp;&nbsp;
                                     <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/icon_Logout.png" Height="20px" Width="20px" />
                                   
                                
                           <%--<asp:Button ID="Button1" runat="server" Text="Button" />--%>
                               
                            </td>
                            </tr>
                    </table>
                </td>
            </tr>
             <%--Header--%>


              <%--Center--%>

               <tr style="height:110px">
                <td >
                    </td>
              </tr>

           
            
            <tr>
                <td >
                    <table class ="center" style="background-color: #AFEEEE;border-radius:15px;border:solid;border-color:MediumTurquoise">
                        <tr>
                            <td style="vertical-align:top;">

                              <div class="css3-tabstrip" >
       <ul>
        <li>
            <input type="radio" name="css3-tabstrip-0" checked="checked" id="css3-tabstrip-0-0" /><label for="css3-tabstrip-0-0">RAM</label>
            <div>
                <table width="100%">
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td width ="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;RAM Information
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr>
                                    <td>

                                  
                                </td>
                                    <td>

                                        <div id='container'>
<a href="#" class='click' onclick="getServerIP()">Click Here to See Popup!</a> <br/>
</div>
       

                                    </td>

                                </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Apply by :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:CheckBox ID="chkByServerRAM" type="checkbox" runat="server" Text="Server" />&nbsp;
                                        &nbsp;<asp:CheckBox ID="chkByGroupRAM" type="checkbox" runat="server" Text="Group" />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                   
                                    </td>
                                    <td>

                                    </td>

                                </tr>

                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Server Name :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="txtServernameRAM"  runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServeripRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Repeat check :
                                    </td>
                                    <td style="color: #006666; font-size:12pt;">&nbsp;<asp:TextBox ID="txtRepeatRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Time
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                            </table>
                        </td>
                        <td width="4%"></td>
                        <td width="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Minor Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMinorRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMajorRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtCriticalRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Method :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="CheckBox3" runat="server" Text="E-mail" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Interval Minute :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtIntervalRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Time
                                    </td>
                                </tr>
                                 <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="chkActiveStatusRAM" runat="server" Text="Active Status" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                            </table>
                        </td>
                         <td width="2%"></td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:Button ID="btnSaveRAM" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancelRAM" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                   </tr>
                    <tr><td>&nbsp;</td></tr>
                </table>
            </div>
        </li>
       <%-- RAM--%>
      <%--  <li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-1" /><label for="css3-tabstrip-0-1">RAM</label>
            <div>
                 <table width="100%">
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td width ="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;RAM Information
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Apply by :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:CheckBox ID="CheckBox5" type="checkbox" onclick="like_a_radio(this)" runat="server" Text="Server" />&nbsp;
                                        &nbsp;<asp:CheckBox ID="CheckBox6" type="checkbox" onclick="like_a_radio(this)" runat="server" Text="Group" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Server Name :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="TextBox8" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="TextBox9" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Repeat check :
                                    </td>
                                    <td style="color: #006666; font-size:12pt;">&nbsp;<asp:TextBox ID="TextBox10" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Time
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                            </table>
                        </td>
                        <td width="4%"></td>
                        <td width="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Minor Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox11" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox12" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox13" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Method :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="CheckBox7" runat="server" Text="E-mail" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Interval Minute :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox14" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Time
                                    </td>
                                </tr>
                                 <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="CheckBox8" runat="server" Text="Active Status" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                            </table>
                        </td>
                         <td width="2%"></td>
                    </tr>
                     <tr><td>&nbsp;</td></tr>
                     <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:Button ID="Button4" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="Button5" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                   </tr>
                    <tr><td>&nbsp;</td></tr>
                </table>
            </div>
        </li>--%>

       <%-- Drive--%>
       <%-- <li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-2" /><label for="css3-tabstrip-0-2">Drive</label>
            <div>
                 <table width="100%">
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td width ="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Drive Information
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Apply by :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:CheckBox ID="CheckBox9" type="checkbox" onclick="like_a_radio(this)" runat="server" Text="Server" />&nbsp;
                                        &nbsp;<asp:CheckBox ID="CheckBox10" type="checkbox" onclick="like_a_radio(this)" runat="server" Text="Group" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Server Name :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="TextBox15" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="TextBox16" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Repeat check :
                                    </td>
                                    <td style="color: #006666; font-size:12pt;">&nbsp;<asp:TextBox ID="TextBox17" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Time
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Drive Name :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="TextBox22" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                            </table>
                        </td>
                        <td width="4%"></td>
                        <td width="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Minor Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox18" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox19" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox20" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Method :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="CheckBox11" runat="server" Text="E-mail" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Interval Minute :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox21" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Time
                                    </td>
                                </tr>
                                 <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="CheckBox12" runat="server" Text="Active Status" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                            </table>
                        </td>
                         <td width="2%"></td>
                    </tr>
                     <tr><td>&nbsp;</td></tr>
                     <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:Button ID="Button3" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="Button6" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                   </tr>
                    <tr><td>&nbsp;</td></tr>
                </table>
            </div>
        </li>--%>
        
      <%--  FileSize--%>
      <%--  <li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-3" /><label for="css3-tabstrip-0-3">FileSize</label>
            <div>
                 <table width="100%">
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td width ="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;File Information
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Apply by :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:CheckBox ID="CheckBox13" type="checkbox" onclick="like_a_radio(this)" runat="server" Text="Server" />&nbsp;
                                        &nbsp;<asp:CheckBox ID="CheckBox14" type="checkbox" onclick="like_a_radio(this)" runat="server" Text="Group" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Server Name :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="TextBox23" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="TextBox24" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Repeat check :
                                    </td>
                                    <td style="color: #006666; font-size:12pt;">&nbsp;<asp:TextBox ID="TextBox25" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Time
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        File Name :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="TextBox26" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                            </table>
                        </td>
                        <td width="4%"></td>
                        <td width="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Minor Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox27" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox28" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox29" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Method :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="CheckBox15" runat="server" Text="E-mail" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Interval Minute :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox30" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Time
                                    </td>
                                </tr>
                                 <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="CheckBox16" runat="server" Text="Active Status" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                            </table>
                        </td>
                         <td width="2%"></td>
                    </tr>
                     <tr><td>&nbsp;</td></tr>
                     <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:Button ID="Button7" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="Button8" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                   </tr>
                    <tr><td>&nbsp;</td></tr>
                </table>
            </div>
        </li>--%>


    </ul>
                             </div>

                            </td>
                        </tr>
                    </table>
                </td>
                
            </tr>
        </table>
     
    </form>
</body>
</html>
      



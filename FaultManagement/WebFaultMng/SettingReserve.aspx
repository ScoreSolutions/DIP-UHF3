<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SettingReserve.aspx.vb" Inherits="SettingReserve" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel ="stylesheet" href ="CSS/autocomplete.css" type ="text/css" />
    <script type ="text/javascript" src ="Script/jscautocomplete.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    
  

      
<script type="text/Javascript">

    //Show dialog
    function showModal(page, width, height, scroll) {
        showModalDialog(page, "", "dialogWidth:" + width + "px; dialogHeight:" + height + "px;help:no;status:no;center:yes;scroll:" + scroll);
    }
      
          






          function chkServer() {
              var AreaServer = document.getElementById('AreaServer');
              var AreaGroup = document.getElementById('AreaGroup');
              var Server = document.getElementById("<%=chkByServerRAM.ClientID%>");
              var Group = document.getElementById("<%= chkByGroupRAM.ClientID%>");

              if (Server.checked = true)
              {
                  Group.checked = false
                  AreaGroup.style.display = 'none'
                  if (AreaServer.style.display = 'none')
                  {
                      AreaServer.style.display = 'block';
                      document.getElementById('<%=btnSerchipRAM.ClientID%>').style.display = 'block';
                      document.getElementById('<%=btnSerchGroupRAM.ClientID%>').style.display = 'none';
                  }
              }
          }



          function chkGroup() {
              var AreaServer = document.getElementById('AreaServer');
              var AreaGroup = document.getElementById('AreaGroup');
              var Server = document.getElementById("<%=chkByServerRAM.ClientID%>");
              var Group = document.getElementById("<%= chkByGroupRAM.ClientID%>");

              if (Group.checked = true) {
                  Server.checked = false
                  AreaServer.style.display = 'none'
                  if (AreaGroup.style.display = 'none') {
                      AreaGroup.style.display = 'block';
                      document.getElementById('<%=btnSerchipRAM.ClientID%>').style.display = 'none';
                      document.getElementById('<%=btnSerchGroupRAM.ClientID%>').style.display = 'block';
                  }
              }
          }




    function chkServerCPU() {
        var AreaServerCPU = document.getElementById('AreaServerCPU');
        var AreaGroupCPU = document.getElementById('AreaGroupCPU');
        var ServerCPU = document.getElementById("<%=chkByServerCPU.ClientID%>");
        var GroupCPU = document.getElementById("<%= chkByGroupCPU.ClientID%>");

        if (ServerCPU.checked = true) {
            GroupCPU.checked = false
            AreaGroupCPU.style.display = 'none'
                  if (AreaServerCPU.style.display = 'none') {
                      AreaServerCPU.style.display = 'block';
                      document.getElementById('<%=btnSerchipCPU.ClientID%>').style.display = 'block';
                      document.getElementById('<%=btnSerchGroupCPU.ClientID%>').style.display = 'none';
                  }
              }
    }

    function chkGroupCPU() {
        var AreaServerCPU = document.getElementById('AreaServerCPU');
        var AreaGroupCPU = document.getElementById('AreaGroupCPU');
        var ServerCPU = document.getElementById("<%=chkByServerCPU.ClientID%>");
        var GroupCPU = document.getElementById("<%= chkByGroupCPU.ClientID%>");

        if (GroupCPU.checked = true) {
            ServerCPU.checked = false
            AreaServerCPU.style.display = 'none'
            if (AreaGroupCPU.style.display = 'none') {
                AreaGroupCPU.style.display = 'block';
                document.getElementById('<%=btnSerchipCPU.ClientID%>').style.display = 'none';
                document.getElementById('<%=btnSerchGroupCPU.ClientID%>').style.display = 'block';
             }
         }
     }




    function DivCPU() {

        document.getElementById('css3-tabstrip-0-1').checked = true
    };
         
    function DivDrive() {

        document.getElementById('css3-tabstrip-0-2').checked = true
    };

    function DivService() {

        document.getElementById('css3-tabstrip-0-4').checked = true
    };

    function DivProcess() {
        document.getElementById('css3-tabstrip-0-5').checked = true
    }

    function DivFileSize() {
        document.getElementById('css3-tabstrip-0-3').checked = true
    }
    function DivPort() {
        document.getElementById('css3-tabstrip-0-6').checked = true
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
              height:1120px;
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
            height: 920px;
        }

            .css3-tabstrip li {
                vertical-align: top;
            }

                .css3-tabstrip li:first-child {
                    margin-left: 8px;
                }

                .css3-tabstrip li > div {
                    top: 33px;
                    bottom: -171px;
                    left: 5px;
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



.imgBox {
     width: 441px; 
     height: 248px; 
     background: url(http://www.corelangs.com/css/box/img/water.jpg) no-repeat; 

}
#imgAddnew:hover {
    -moz-box-shadow: 0 0 10px black;
     -webkit-box-shadow: 0 0 10px black;
      box-shadow: 0 0 10px black;
}

#AreaGroup{
    display :none ;
}
#_Group{
    display :none ;
}

#btnSerchGroupRAM {
    display :none ;
}                      
#btnSerchGroupCPU{
    display :none ;
}

    .auto-style1 {
        height: 25px;
    }


    #AreaGroupCPU{
    display :none ;
}

</style>

</head>
<body class="body">

    <form id="form1" runat="server">
    



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
                        <li><a href="SettingReserve.aspx"><span><img src="images/icon_Setting.png" title="Setting" /></span></a></li>
                        <li><a href="frmAlarm.aspx"><span><img src="images/icon_Alarm.png" title="Alarm" /></span></a></li>
                        <li><a href="frmHistory.aspx"><span><img src="images/icon_History.png" title="History" /></span></a></li>
                       
                        <li><a href="frmAdmin.aspx"><span><img src="images/icon_Admin.png" title="Admin" /></span></a></li>
                       
                    </ul>
                </td>
                            <td width="290px" style="text-align: right; vertical-align: top">
                                
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Quark" Font-Size="12pt"></asp:Label>
                                     &nbsp;&nbsp;
                                     <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/icon_Logout.png" Height="20px" Width="20px" />
                                   
                                
                        
                               
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
          
                <%-- RAM--%>
            
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
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :143px;">
                                        Apply by :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:CheckBox ID="chkByServerRAM" type="checkbox" runat="server" Text="Server" onclick="chkServer()"  />&nbsp;
                                        &nbsp;<asp:CheckBox ID="chkByGroupRAM" type="checkbox" runat="server" Text="Group"  onclick="chkGroup()"  />
                                          
                                    </td>
                                </tr>

                               <tr>
                                    <td>
                                                             
                                   </td>
                                    <td>
                                        <asp:Button ID="btnSerchipRAM" runat="server" Text="Server ip" />  
                                        <asp:Button ID="btnSerchGroupRAM" runat="server" Text="Group" />    
                                    
                                    </td>

                                </tr>

                              <tr>
                                  <td colspan ="2">

                                <div id="AreaServer" style ="width :100%">
                                    <table style ="width :100%">
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt; width :140px;">
                                       Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServeripRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                       
                                    </td>
                                </tr>

                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                      Server Name :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="txtServernameRAM"  runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                  <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;  </td>
                                </tr>
                                  <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;width :140px;">
                                         Mac Address :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="txtMacAddressRAM"  runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                    </table>
                                </div>


                                 <div id="AreaGroup" style ="width :100%">
                                    <table style ="width :100%">
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt; width :140px;">
                                      Group RAM :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtGroupRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                              
                                    </table>
                                </div>


                                  </td>
                              </tr>



                                 <tr>
                                    <td class="auto-style1"></td>
                                    <td class="auto-style1"></td>
                                </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Repeat check :
                                    </td>
                                    <td style="color: #006666; font-size:12pt;">&nbsp;<asp:TextBox ID="txtRepeatCheckRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                 <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Interval Minute :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtIntervalRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Minute
                                    </td>
                                </tr>
                                  <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="chkActiveStatusRAM" runat="server" Text="Active Status" Checked="True" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="4%"></td>
                        <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table style="width :100%;background-color:#AFEEEE;">
                                <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Minor Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMinorRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMajorRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtCriticalRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                               <tr><td colspan ="2">&nbsp;</td></tr>
                              <tr><td colspan ="2">&nbsp;</td></tr>
                              <tr><td colspan ="2">&nbsp;</td></tr>
                              <tr><td colspan ="2">&nbsp;</td></tr>
                              <tr><td colspan ="2">&nbsp;</td></tr>
                              <tr><td colspan ="2">&nbsp;</td></tr>
                               <tr><td colspan ="2">&nbsp;</td></tr>
                                 <tr><td colspan ="2">
                                     <asp:Label ID="lblidRAM" runat="server" Visible="False" >0</asp:Label>

                                     </td></tr>
                            </table>
                        </td>
                         <td width="2%"></td>
                    </tr>
                    <tr><td>
                        
                        </td></tr>
                    <tr><td>
                        
                        
                        
                        </td></tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:Button ID="btnSaveRAM" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancelRAM" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                   </tr>
                    <tr><td colspan ="5">&nbsp;</td></tr>
                    <tr><td colspan ="5">
                     <div style="width: 920px; height: 400px; overflow-y: auto;">
                         <asp:GridView ID="gvRAM" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="True" Font-Names="Quark" Font-Size="10pt">
                             <AlternatingRowStyle BackColor="White" />
                             <Columns>
                                 <asp:TemplateField HeaderText="No.">
                                     <ItemTemplate >
                                         <asp:Label ID="lblno" runat="server" Text='<%# Bind ("no") %>' ></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="id" Visible="False">
                                      <ItemTemplate >
                                          <asp:Label ID="lblid" runat="server" Text='<%#Bind("id")%>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Server Name">
                                     <ItemTemplate >
                                          <asp:Label ID="lblServerName" runat="server" Text='<%#Bind("ServerName")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Server IP">
                                     <ItemTemplate >
                                         <asp:Label ID="lblServerIP" runat="server" Text='<%#Bind("ServerIP")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="MacAddress">
                                     <ItemTemplate >
                                         <asp:Label ID="lblMacAddress" runat="server" Text='<%#Bind("MacAddress")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="group_id" Visible="False">
                                     <ItemTemplate >
                                         <asp:Label ID="lblgroup_id" runat="server" Text='<%#Bind("group_id")%>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="group_code">
                                     <ItemTemplate >
                                         <asp:Label ID="lblgroup_code" runat="server" Text='<%#Bind("group_code")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="group_desc">
                                     <ItemTemplate >
                                         <asp:Label ID="lblgroup_desc" runat="server" Text='<%#Bind("group_desc")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Minor Value(percent)">
                                     <ItemTemplate >
                                         <asp:Label ID="lblAlarmMinorValue" runat="server" Text='<%#Bind("AlarmMinorValue")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Major Value(percent)">
                                     <ItemTemplate >
                                         <asp:Label ID="lblAlarmMajorValue" runat="server" Text='<%#Bind("AlarmMajorValue")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Critical Value(percent)">
                                     <ItemTemplate >
                                         <asp:Label ID="lblAlarmCriticalValue" runat="server" Text='<%#Bind("AlarmCriticalValue")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Interval (minute)">
                                     <ItemTemplate >
                                         <asp:Label ID="lblCheckIntervalMinute" runat="server" Text='<%#Bind("CheckIntervalMinute")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="RepeatCheckQty">
                                     <ItemTemplate >
                                         <asp:Label ID="lblRepeatCheckQty" runat="server" Text='<%#Bind("RepeatCheckQty")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" CommandName="EditRow" />
                                 <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png"  CommandName="DeleteRow" />
                                 <asp:TemplateField HeaderText="idcfRAM" Visible="False">
                                    <ItemTemplate >
                                        <asp:Label ID="lblidcfRAM" runat="server" Text='<%#Bind("idcfRAM")%>'></asp:Label>
                                    </ItemTemplate>
                                 </asp:TemplateField>
                             </Columns>
                             <EditRowStyle BackColor="#7C6F57" />
                             <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                             <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                             <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                             <RowStyle BackColor="#E3EAEB" />
                             <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                             <SortedAscendingCellStyle BackColor="#F8FAFA" />
                             <SortedAscendingHeaderStyle BackColor="#246B61" />
                             <SortedDescendingCellStyle BackColor="#D4DFE1" />
                             <SortedDescendingHeaderStyle BackColor="#15524A" />
                         </asp:GridView>
                     </div>
                        
                        </td></tr>
                </table>
            </div>
        </li>


       <%--    CPU--%>
      
           <li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-1" /><label for="css3-tabstrip-0-1">CPU</label>
            <div>
                 <table width="100%">
                  <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td width ="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;CPU Information
                            <table width="100%" style="background-color:#AFEEEE;">                                
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Apply by :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:CheckBox ID="chkByServerCPU" type="checkbox"  runat="server" Text="Server" onclick="chkServerCPU()" Checked="True"/>&nbsp;
                                        &nbsp;<asp:CheckBox ID="chkByGroupCPU" type="checkbox"  runat="server" Text="Group"   onclick="chkGroupCPU()"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnSerchipCPU" runat="server" Text="Server ip" />  
                                        <asp:Button ID="btnSerchGroupCPU" runat="server" Text="Group" /> 
                                    </td>
                                </tr>
                               
                               
                                <tr>
                                    <td colspan ="2">


                         <div id="AreaServerCPU" style ="width :100%">
                                    <table style ="width :100%">
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt; width :143px;">
                                       Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServeripCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                       
                                    </td>
                                </tr>

                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                     Server Name :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="txtServerNameCPU"  runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                  <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                  <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;width :140px;">
                                      Mac Address :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="txtMacAddressCPU"  runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                    </table>
                                </div>


                          <div id="AreaGroupCPU" style ="width :100%">
                                    <table style ="width :100%">
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt; width :140px;">
                                       Group :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtGroupCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                              
                                    </table>
                                </div>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;width:146px">
                                        Repeat check :
                                    </td>
                                    <td style="color: #006666; font-size:12pt;">&nbsp;<asp:TextBox ID="txtRepeatCheckCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>

                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Interval Minute :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtIntervalCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Minute
                                    </td>
                                </tr>
                                 <tr><td colspan ="2">&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="chkActiveStatusCPU" runat="server" Text="Active Status" Checked="True" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="4%"></td>
                        <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Minor Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMinorCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMajorCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtCriticalCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                               
                                <tr><td colspan ="2">&nbsp;</td></tr>
                                  <tr><td colspan ="2">&nbsp;</td></tr>
                              <tr><td colspan ="2">&nbsp;</td></tr>
                              <tr><td colspan ="2">&nbsp;</td></tr>
                              <tr><td colspan ="2">&nbsp;</td></tr>
                              <tr><td colspan ="2">&nbsp;</td></tr>
                              <tr><td colspan ="2">&nbsp;</td></tr>
                               <tr><td colspan ="2">&nbsp;</td></tr>
                                 <tr><td colspan ="2">
                                     <asp:Label ID="lblidCPU" runat="server" Visible="False" >0</asp:Label>

                                     </td></tr>
                            </table>
                        </td>
                         <td width="2%"></td>
                    </tr>
                     <tr><td>&nbsp;</td></tr>
                   
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:Button ID="btnSaveCPU" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancelCPU" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                   </tr>
                    <tr><td colspan ="5">&nbsp;</td></tr>
                     <tr>
                         <td colspan ="5">
                             <div style="width: 920px; height: 400px; overflow-y: auto;">
                             <asp:GridView ID="gvCPU" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="True" Font-Names="Quark" Font-Size="10pt">
                                 <AlternatingRowStyle BackColor="White" />
                                 <Columns>
                                     <asp:TemplateField HeaderText="No.">
                                         <ItemTemplate >
                                             <asp:Label ID="lblno" runat="server" Text='<%# Bind ("no") %>' ></asp:Label>
                                         </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="idRegister" Visible="False">
                                          <ItemTemplate >
                                              <asp:Label ID="lblidRes" runat="server" Text='<%# Bind("idRes")%>'></asp:Label>                                
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Server Name">
                                          <ItemTemplate >
                                              <asp:Label ID="lblServerIP" runat="server" Text='<%# Bind("ServerIP")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Server IP">
                                          <ItemTemplate >
                                              <asp:Label ID="lblServerName" runat="server" Text='<%# Bind("ServerName")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Mac Address">
                                          <ItemTemplate >
                                              <asp:Label ID="lblMacAddress" runat="server" Text='<%# Bind("MacAddress")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="group_id" Visible="False">
                                          <ItemTemplate >
                                              <asp:Label ID="lblgroup_id" runat="server" Text='<%# Bind("group_id")%>' ></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Group Code">
                                          <ItemTemplate >
                                              <asp:Label ID="lblgroup_code" runat="server" Text='<%# Bind("group_code")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Group desc">
                                          <ItemTemplate >
                                              <asp:Label ID="lblgroup_desc" runat="server" Text='<%# Bind("group_desc")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Minor Value (percent)">
                                          <ItemTemplate >
                                              <asp:Label ID="lblAlarmMinorValue" runat="server" Text='<%# Bind("AlarmMinorValue")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Major Value (percent)">
                                          <ItemTemplate >
                                              <asp:Label ID="lblAlarmMajorValue" runat="server" Text='<%# Bind("AlarmMajorValue")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Critical Value (percent)">
                                          <ItemTemplate >
                                              <asp:Label ID="lblAlarmCriticalValue" runat="server" Text='<%# Bind("AlarmCriticalValue")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Interval(minute)">
                                          <ItemTemplate >
                                              <asp:Label ID="lblCheckIntervalMinute" runat="server" Text='<%# Bind("CheckIntervalMinute")%>' ></asp:Label>

                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Repeat Check Qty">
                                          <ItemTemplate >
                                              <asp:Label ID="lblRepeatCheckQty" runat="server" Text='<%# Bind("RepeatCheckQty")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="idcfCPU" Visible="False">
                                          <ItemTemplate >
                                              <asp:Label ID="lblidcfCPU" runat="server" Text='<%# Bind ("idcfCPU") %>' ></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit" CommandName="EditRow" />
                                     <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete" CommandName="DeleteRow"/>
                                 </Columns>
                                 <EditRowStyle BackColor="#7C6F57" />
                                 <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                 <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                 <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                 <RowStyle BackColor="#E3EAEB" />
                                 <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                 <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                 <SortedAscendingHeaderStyle BackColor="#246B61" />
                                 <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                 <SortedDescendingHeaderStyle BackColor="#15524A" />
                             </asp:GridView>
                                 </div> 
                         </td>
                     </tr>
                </table>
            </div>
        </li>
      

       <%-- Drive--%>
        <li>             
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-2" /><label for="css3-tabstrip-0-2">Drive</label>
            <div>
                 <table width="100%">
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td width ="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Drive Information
                            <table width="100%" style="background-color:#AFEEEE;">
                                
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Apply by :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:CheckBox ID="chkServerDrive" runat="server" text="Server" Checked="True" Enabled="False" />
                                      
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnSerchipDrive" runat="server" Text="Server ip" /><asp:Label ID="lblidDrive" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServerIPDriver" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                               
                                <tr><td colspan ="2">&nbsp;</td></tr>
                               
                                  <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Server Name :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="txtServerNameDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Mac Address :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtMacAddressDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                               
                               
                                <tr><td colspan ="2">&nbsp;</td></tr>
                                
                                <tr>
                                      
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Repeat check :
                                    </td>
                                    <td style="color: #006666; font-size:12pt;">&nbsp;<asp:TextBox ID="txtRepeatCheckDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;
                                    </td>
                                
                                 </tr>
                                 
                                <tr><td colspan ="2">&nbsp;</td></tr>
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Interval Minute :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtIntervalDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Minute</td>
                                </tr>
                                 <tr><td colspan ="2">&nbsp;</td></tr>
                                  
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;" class="auto-style1">
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;" class="auto-style1">
                                       &nbsp;<asp:CheckBox ID="chkActiveStatusDrive" runat="server" Text="Active Status" Checked="True" />
                                    </td>
                                </tr>
                           
                            </table>
                        </td>
                        <td width="4%"></td>
                        <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <div>
                                <table style="width :100%;  background-color:#AFEEEE;">
                                  
                                <tr><td colspan ="2">&nbsp;
                                    <%--border:2px solid #009999;--%> 
                                    <div id ="AreaDriveName" style ="width :70%;margin-left :auto;margin-right :auto;">
                                        <table style="width : 100%">
                                           
                                            <tr>
                                            <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Drive Name :
                                    </td>
                                    <td>&nbsp;
                                        <asp:DropDownList ID="ddlDriverName" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                                </tr>
                                            <tr>
                                                <td colspan ="2"></td>
                                            </tr>
                                              <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Minor Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMinorDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMajorDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtCriticalDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                             <tr>
                                                <td colspan ="2"></td>
                                            </tr>
                                              <tr>
                                                <td></td>
                                                <td>
                                                    <asp:Button ID="SubmitDriveName" runat="server" Text="Submit" />
                                                    <asp:Label ID="lblDriveid" runat="server" Text="0" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan ="2">
                                                    <asp:GridView ID="gvSelectDrive" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="True" Font-Names="Quark" Font-Size="10pt" Width="100%">
                                                        <AlternatingRowStyle BackColor="White" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="id">
                                                                <ItemTemplate>
                                                                     <asp:Label ID="lblid" runat="server" Text='<%# Bind("id")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Drive Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDrivename" runat="server" Text='<%# Bind("DriveName")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Minor">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMinor" runat="server" Text='<%# Bind("Minor")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Major">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMajor" runat="server" Text='<%# Bind("Major")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Critical">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCritical" runat="server" Text='<%# Bind("Critical")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png"   CommandName="EditRow" />
                                                             <asp:ButtonField ButtonType="Image"  ImageUrl="~/Images/icon_Delete.png"   CommandName="DeleteRow" HeaderText="Delete" />
                                                        </Columns>
                                                        <EditRowStyle BackColor="#7C6F57" />
                                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#E3EAEB" />
                                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    </td></tr>
                             
                              
                            </table>
                            </div>
                            
                        </td>
                         <td width="2%"></td>
                    </tr>
                     <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:Button ID="btnSaveDrive" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancelDrive" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                   </tr>
                      <tr><td colspan ="5">&nbsp;</td></tr>
                    <tr>
                        <td colspan ="4" >
                             <div style="width: 920px; height: 400px; overflow-y: auto;margin-left: auto;">                               
                            <asp:GridView ID="gvDrive" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="True" Font-Names="Quark" Font-Size="10pt" Width="100%">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate >
                                            <asp:Label ID="lblno" runat="server" Text='<%# Bind("no")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="cf_config_drive_id" Visible="False">
                                        <ItemTemplate >
                                            <asp:Label ID="lblcf_config_drive_id" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Server Name">
                                        <ItemTemplate >
                                             <asp:Label ID="lblServerName" runat="server" Text='<%# Bind("ServerName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Server IP">
                                        <ItemTemplate >
                                             <asp:Label ID="lblServerIP" runat="server" Text='<%# Bind("ServerIP")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MacAddress">
                                        <ItemTemplate >
                                            <asp:Label ID="lblMacAddress" runat="server" Text='<%# Bind("MacAddress")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Check Interval (minute)">
                                        <ItemTemplate >
                                            <asp:Label ID="lblCheckIntervalMinute" runat="server" Text='<%# Bind("CheckIntervalMinute")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Repeat Check Qty">
                                        <ItemTemplate >
                                            <asp:Label ID="lblRepeatCheckQty" runat="server" Text='<%# Bind("RepeatCheckQty")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit"  CommandName="EditRow" />
                                    <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" />
                                </Columns>

                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />

                            </asp:GridView>
                                 </div> 
                        </td>
                    </tr>
                </table>
            </div>
        </li>
        

          <%--Service--%>

        <li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-4" /><label for="css3-tabstrip-0-4">Services</label>
            <div>
                 <table width="100%">
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td width ="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Service Information
                            <table width="100%" style="background-color:#AFEEEE;">
                                
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Apply by :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:CheckBox ID="chkServerService" type="checkbox"  runat="server" Text="Server" Checked="True" Enabled="False" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnSerchipService" runat="server" Text="Server ip" />
                                    </td>
                                </tr>
                                 
                                  <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServeripService" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>
                                   <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Server Name :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="txtServerNameService" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>
                              
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Mac Address :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtMacAddressService" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                               
                               
                                <tr><td colspan ="2">&nbsp;</td></tr>
                                

                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Repeat check :
                                    </td>
                                    <td style="color: #006666; font-size:12pt;">&nbsp;<asp:TextBox ID="txtRepeatCheckService" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                              
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Interval Minute :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtIntervalService" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Minute
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td>

                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">&nbsp;
                                        <asp:CheckBox ID="chkActiveStatusService" runat="server" Text="Active Status" Checked="True" />
                                        <asp:Label ID="lblServiceid" runat="server" Text="0"></asp:Label>
                                    </td>

                                </tr>
                               
                            </table>
                        </td>
                        <td width="4%"></td>
                        <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr><td colspan ="2">&nbsp;</td></tr>
                               
                                <tr>
                                    <td colspan ="2">
                                        <div style="width: 100%; height: 300px; overflow-y: auto; margin-left :auto;margin-right :auto;">   
                                        <asp:GridView ID="gvShowService" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="True" Font-Names="Quark" Font-Size="10pt" Width="100%">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate >
                                                        <asp:CheckBox ID="chkService" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblno" runat="server" Text='<%# Bind("no")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id" Visible="False">
                                                    <ItemTemplate >
                                                        <asp:Label ID="lblid" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Display Name">
                                                    <ItemTemplate >
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("DisplayName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Active Status">
                                                    <ItemTemplate >
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("ActiveStatus")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle BackColor="#7C6F57" />
                                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#E3EAEB" />
                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                                        </asp:GridView>
                                            </div> 
                                    </td>                                  
                                </tr>

                                <tr>
                                    <td colspan ="2">&nbsp;</td>
                                </tr>

                            </table>
                        </td>

                         <td width="2%"></td>
                    </tr>

                     <tr><td>&nbsp;</td></tr>

                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:Button ID="btnSaveService" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancelService" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                   </tr>
                    <tr><td colspan ="5">&nbsp;</td></tr>
                    <tr>
                        <td colspan ="5">
                             <div style="width: 920px; height: 400px; overflow-y: auto; margin-left :auto;margin-right :auto;">   
                            <%--<asp:GridView ID="gvService" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Bold="True" Font-Names="Quark" Font-Size="10pt">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate >
                                            <asp:Label ID="lblno" runat="server" Text='<%# Bind("no")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="id" Visible="False">
                                        <ItemTemplate >
                                            <asp:Label ID="lblid" runat="server" Text='<%# Bind("idConfig")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Server Name">
                                        <ItemTemplate >
                                            <asp:Label ID="lblServerName" runat="server" Text='<%# Bind("ServerName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Server IP">
                                        <ItemTemplate >
                                            <asp:Label ID="lblServerIP" runat="server" Text='<%# Bind("ServerIP")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MacAddress">
                                        <ItemTemplate >
                                            <asp:Label ID="lblMacAddress" runat="server" Text='<%# Bind("MacAddress")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="130px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Display Name">
                                        <ItemTemplate >
                                            <asp:Label ID="lblDisplayName" runat="server"  Text='<%# Bind("DisplayName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Check Interval (minute)">
                                        <ItemTemplate >
                                            <asp:Label ID="lblCheckIntervalMinute" runat="server" Text='<%# Bind("CheckIntervalMinute")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Repeat CheckQty">
                                        <ItemTemplate >
                                            <asp:Label ID="lblRepeatCheckQty" runat="server" Text='<%# Bind("RepeatCheckQty")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ms_service_checklist_id" Visible="False">
                                        <ItemTemplate >
                                            <asp:Label ID="lblservice_checklist_id" runat="server" Text='<%# Bind("ms_service_checklist_id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit"  CommandName="EditRow" />
                                    <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" />
                                </Columns>
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>--%>
                                 <asp:GridView ID="gvService" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Bold="True" Font-Names="Quark" Font-Size="10pt">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate >
                                            <asp:Label ID="lblno" runat="server" Text='<%# Bind("no")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Server Name">
                                        <ItemTemplate >
                                            <asp:Label ID="lblServerName" runat="server" Text='<%# Bind("ServerName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Server IP">
                                        <ItemTemplate >
                                            <asp:Label ID="lblServerIP" runat="server" Text='<%# Bind("ServerIP")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MacAddress">
                                        <ItemTemplate >
                                            <asp:Label ID="lblMacAddress" runat="server" Text='<%# Bind("MacAddress")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="130px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Check Interval (minute)">
                                        <ItemTemplate >
                                            <asp:Label ID="lblCheckIntervalMinute" runat="server" Text='<%# Bind("CheckIntervalMinute")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Repeat CheckQty">
                                        <ItemTemplate >
                                            <asp:Label ID="lblRepeatCheckQty" runat="server" Text='<%# Bind("RepeatCheckQty")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                      <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit"  CommandName="EditRow" />
                                    <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" />
                                </Columns>
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                            </div>
                        </td>
                    </tr>

                </table>
            </div>
        </li>


          <%--Process--%>
             <li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-5" /><label for="css3-tabstrip-0-5">Process</label>
            <div>
                 <table width="100%">
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td width ="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Process Information
                            <table width="100%" style="background-color:#AFEEEE;">
                               
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Apply by :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:CheckBox ID="chkServerProcess" type="checkbox"  runat="server" Text="Server" Checked="True" Enabled="False" />
                                    </td>
                                </tr>
                                 <tr>
                                     <td></td>
                                     <td >
                                          
                                           <asp:Button ID="btnSerchipProcess" runat="server" Text="Server ip" />
                                    
                                     </td>
                                 </tr>
                                  <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServeripProcess" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>
                                   <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Server Name :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="txtServernameProcess" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>
                              
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Mac Address :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtMacAddressProcess" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                               
                               
                                <tr><td colspan ="2">&nbsp;</td></tr>
                                

                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Repeat check :
                                    </td>
                                    <td style="color: #006666; font-size:12pt;">
                                        &nbsp;<asp:TextBox ID="txtRepeatCheckProcess" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                              
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Interval Minute :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtIntervalProcess" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Minute
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td>

                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">&nbsp;
                                        <asp:CheckBox ID="chkActiveStatusProcess" runat="server" Text="Active Status" Checked="True" />

                                    </td>

                                </tr>
                               
                            </table>
                        </td>
                        <td width="4%"></td>
                        <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr><td colspan ="2">&nbsp;</td></tr>
                               
                                <tr>
                                    <td colspan ="2">
                                          <div style="width: 100%; height: 300px; overflow-y: auto;margin-left :auto;margin-right :auto;">   
                                        <asp:GridView ID="gvShowProcess" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="True" Font-Names="Quark" Font-Size="10pt" Width="100%">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate >
                                                        <asp:CheckBox ID="chkProcess" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemTemplate> 
                                                        <asp:Label ID="lblno" runat="server" Text='<%#Bind ("no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id" Visible="False">
                                                    <ItemTemplate> 
                                                        <asp:Label ID="lblid" runat="server" Text='<%#Bind("id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Process Name">
                                                    <ItemTemplate> 
                                                        <asp:Label ID="lblProcessName" runat="server" Text='<%#Bind("DisplayName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ActiveStatus">
                                                    <ItemTemplate >
                                                    <asp:Label ID="lblActiveStatus" runat="server" Text='<%#Bind("ActiveStatus")%>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle BackColor="#7C6F57" />
                                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#E3EAEB" />
                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                                        </asp:GridView>
                                              </div> 
                                    </td>
                                  
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>
                            </table>
                        </td>
                         <td width="2%"></td>
                    </tr>
                     <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:Button ID="btnSaveProcess" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancelProcess" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                   </tr>
                    <tr><td colspan ="5">&nbsp;</td></tr>
                     <tr>
                         <td colspan ="5">
                               <div style="width: 920px; height: 400px; overflow-y: auto; margin-left :auto;margin-right :auto;">   
                             <%--<asp:GridView ID="gvProcess" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Bold="True" Font-Names="Quark" Font-Size="10pt">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate >
                                            <asp:Label ID="lblno" runat="server" Text='<%# Bind("no")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="id" Visible="False">
                                        <ItemTemplate >
                                            <asp:Label ID="lblid" runat="server" Text='<%# Bind("idConfig")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Server Name">
                                        <ItemTemplate >
                                            <asp:Label ID="lblServerName" runat="server" Text='<%# Bind("ServerName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Server IP">
                                        <ItemTemplate >
                                            <asp:Label ID="lblServerIP" runat="server" Text='<%# Bind("ServerIP")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MacAddress">
                                        <ItemTemplate >
                                            <asp:Label ID="lblMacAddress" runat="server" Text='<%# Bind("MacAddress")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="130px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Display Name">
                                        <ItemTemplate >
                                            <asp:Label ID="lblDisplayName" runat="server"  Text='<%# Bind("DisplayName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Check Interval (minute)">
                                        <ItemTemplate >
                                            <asp:Label ID="lblCheckIntervalMinute" runat="server" Text='<%# Bind("CheckIntervalMinute")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Repeat CheckQty">
                                        <ItemTemplate >
                                            <asp:Label ID="lblRepeatCheckQty" runat="server" Text='<%# Bind("RepeatCheckQty")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ms_service_checklist_id" Visible="False">
                                        <ItemTemplate >
                                            <asp:Label ID="lblservice_checklist_id" runat="server" Text='<%# Bind("ms_process_checklist_id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit"  CommandName="EditRow" />
                                    <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" />
                                </Columns>
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>--%>
                                <asp:GridView ID="gvProcess" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Bold="True" Font-Names="Quark" Font-Size="10pt">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate >
                                            <asp:Label ID="lblno" runat="server" Text='<%# Bind("no")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Server Name">
                                        <ItemTemplate >
                                            <asp:Label ID="lblServerName" runat="server" Text='<%# Bind("ServerName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Server IP">
                                        <ItemTemplate >
                                            <asp:Label ID="lblServerIP" runat="server" Text='<%# Bind("ServerIP")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MacAddress">
                                        <ItemTemplate >
                                            <asp:Label ID="lblMacAddress" runat="server" Text='<%# Bind("MacAddress")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="130px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Check Interval (minute)">
                                        <ItemTemplate >
                                            <asp:Label ID="lblCheckIntervalMinute" runat="server" Text='<%# Bind("CheckIntervalMinute")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Repeat CheckQty">
                                        <ItemTemplate >
                                            <asp:Label ID="lblRepeatCheckQty" runat="server" Text='<%# Bind("RepeatCheckQty")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                      <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit"  CommandName="EditRow" />
                                    <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" />
                                </Columns>
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                               
                               </div> 
                         </td>
                     </tr>
                </table>
            </div>
        </li>
       



      <%--  FileSize--%>
        <li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-3" /><label for="css3-tabstrip-0-3">FileSize</label>
            <div>
                 <table width="100%">
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td width ="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;File Information
                            <table width="100%" style="background-color:#AFEEEE;">
                                
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Apply by :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:CheckBox ID="chkServerFileSize" type="checkbox" runat="server" Text="Server" Checked="True" Enabled="False" />&nbsp;                                     
                                    </td>
                                </tr>
                                  <tr>
                                     <td>
                                         <asp:Label ID="lblTempID" runat="server" Visible="False">0</asp:Label>
                                     </td>
                                     <td >
                                          
                                         <asp:Button ID="btnSerchipFileSize" runat="server" Text="Server ip" />
                                    
                                     </td>
                                 </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServeripFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Server Name :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="txtServerNameFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Mac Address :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="txtMacAddressFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                        Repeat check :
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="txtRepeatcheckFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Interval Minute :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtIntervelFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;Minute
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                   <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">

                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="chkActiveStatusFile" runat="server" Text="Active Status" Checked="True" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                            </table>
                        </td>
                        <td width="4%">&nbsp;</td>
                        <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                         
                            <table width="100%" style="background-color:#AFEEEE;">
                               
                                <tr><td colspan ="2">&nbsp;</td></tr>
                               
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Path File :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtPathFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                        &nbsp;<asp:Button ID="btnBrownparthfile" runat="server" Text="..." />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="2" >
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Minor Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMinorFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;GB
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMajorFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;GB
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtCriticalFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;GB
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="2">&nbsp;</td>
                                </tr>
                              
                                 <tr>
                                  <td>&nbsp;</td>
                                   <td>
                                       <asp:Button ID="btnConfirm" runat="server" Text="Confirm" />
                                       <asp:Label ID="lblidPathFile" runat="server" Text="0" Visible="False"></asp:Label>
                                   </td>
                                </tr>
                                <tr>
                               <td colspan ="2" style="color: #006666;font-size: 12pt;">&nbsp;
                               </td>
                                </tr>
                     
                                
                                <tr>
                      <td colspan ="2">                  
                      
                       <div style="width: 100%; height: 200px; overflow-y: auto;">
                          <asp:GridView ID="gvPathFile" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Quark" Font-Size="10pt">
                              <AlternatingRowStyle BackColor="White" />
                              <Columns>
                                  <asp:TemplateField HeaderText="id" Visible="False">
                                      <ItemTemplate >
                                          <asp:Label ID="lblid" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="PathFile">
                                        <ItemTemplate >
                                          <asp:Label ID="lblPathFile" runat="server" Text='<%# Bind("PathFile")%>'></asp:Label>
                                      </ItemTemplate>
                                        <ControlStyle Width="130px" />
                                        <ItemStyle Width="200px" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Minor">
                                       <ItemTemplate >
                                          <asp:Label ID="lblMinor" runat="server" Text='<%# Bind("FileSizeMinor")%>'></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Major">
                                        <ItemTemplate >
                                          <asp:Label ID="lblMajor" runat="server" Text='<%# Bind("FileSizeMajor")%>'></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Critical">
                                      <ItemTemplate >
                                          <asp:Label ID="lblCritical" runat="server" Text='<%# Bind("FileSizeCritical")%>'></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png"   CommandName="EditRow" />
                                  <asp:ButtonField ButtonType="Image"  ImageUrl="~/Images/icon_Delete.png"   CommandName="DeleteRow" HeaderText="Delete" >
                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                  </asp:ButtonField>
                              </Columns>
                              <EditRowStyle BackColor="#7C6F57" />
                              <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                              <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                              <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                              <RowStyle BackColor="#E3EAEB" />
                              <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                              <SortedAscendingCellStyle BackColor="#F8FAFA" />
                              <SortedAscendingHeaderStyle BackColor="#246B61" />
                              <SortedDescendingCellStyle BackColor="#D4DFE1" />
                              <SortedDescendingHeaderStyle BackColor="#15524A" />
                          </asp:GridView>
                    </div> 
                                     
                        </td>
                      </tr>
                                    

                                <tr>
                                    <td colspan ="2">&nbsp;</td>
                                </tr>
                            </table>
                                
                        </td>
                         <td width="2%"></td>
                    </tr>
                     <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:Button ID="btnSaveFile" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancalFile" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                   </tr>
                      <tr><td colspan ="5">&nbsp;
                        
                          </td></tr>
                      <tr>
                         <td colspan ="5">

                              <div style="width: 920px; height: 400px; overflow-y: auto;">
                              <asp:GridView ID="gvFileSize" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Quark" Font-Size="Small" Width="100%">
                                 <AlternatingRowStyle BackColor="White" />
                                 <Columns>
                                     <asp:TemplateField HeaderText="No.">
                                         <ItemTemplate >
                                             <asp:Label ID="lblno" runat="server" Text='<%# Bind("no")%>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="cfDETAILid" Visible="False">
                                         <ItemTemplate >
                                             <asp:Label ID="lblcfDETAILid" runat="server" Text='<%# Bind("cfDETAILid")%>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="ServerIP">
                                         <ItemTemplate >
                                              <asp:Label ID="lblServerIP" runat="server" Text='<%# Bind("ServerIP")%>'></asp:Label>
                                         </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="ServerName">
                                         <ItemTemplate >
                                               <asp:Label ID="lblServerName" runat="server" Text='<%# Bind("ServerName")%>'></asp:Label>
                                         </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="MacAddress">
                                         <ItemTemplate >
                                               <asp:Label ID="lblMacAddress" runat="server" Text='<%# Bind("MacAddress")%>'></asp:Label>
                                         </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Interval (minute)">
                                         <ItemTemplate >
                                             <asp:Label ID="lblCheckIntervalMinute" runat="server" Text='<%# Bind("CheckIntervalMinute")%>'></asp:Label>
                                         </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Repeat Check Qty">
                                         <ItemTemplate >
                                              <asp:Label ID="lblRepeateCheckQty" runat="server" Text='<%# Bind("RepeateCheckQty")%>'></asp:Label>
                                         </ItemTemplate>                   
                                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                      <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit"  CommandName="EditRow" />
                                    <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" />
                                 </Columns>
                                 <EditRowStyle BackColor="#7C6F57" />
                                 <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                 <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                 <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                 <RowStyle BackColor="#E3EAEB" />
                                 <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                 <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                 <SortedAscendingHeaderStyle BackColor="#246B61" />
                                 <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                 <SortedDescendingHeaderStyle BackColor="#15524A" />
                             </asp:GridView>   
                            </div> 
                         </td>
                     </tr>
                </table>
            </div>
        </li>


     <%-- Port--%>
          <li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-6" /><label for="css3-tabstrip-0-6">Port</label>
            <div>
                 <table width="100%">
                  <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td width ="46%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Port Information
                            <table width="100%" style="background-color:#AFEEEE;">                                
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :100px">
                                        Apply by :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:CheckBox ID="chkByServerPort" type="checkbox"  runat="server" Text="Server" onclick="chkServerCPU()" Checked="True" Enabled="False"/>&nbsp;
                                       
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td colspan ="2">
                                       
                                    </td>
                                </tr>
                             
                              
                                <tr>
                                     <td  style="color: #006666;text-align: right; font-size: 12pt;width :100px">
                                        Server Name :
                                     </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:TextBox ID="txtServerNamePort" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                   
                                        Server IP :
                                    
                                        &nbsp;<asp:TextBox ID="txtServeripPort" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;
                                  
                                        Port :
                                  
                                        &nbsp;<asp:TextBox ID="txtPort" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>

                               <tr>
                                    <td colspan ="2">
                                        &nbsp;
                                    </td>
                                </tr>
                              <tr>
                                    <td style="color: #006666;text-align: right; font-size:12pt;">
                                      Alarm Date :    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        
                                        <asp:CheckBox ID="chkSun" runat="server" Text="Sunday" />
                                        <asp:CheckBox ID="chkMon" runat="server" Text="Monday" />
                                        <asp:CheckBox ID="chkTue" runat="server" Text="Tuesday" />
                                        <asp:CheckBox ID="chkWed" runat="server" Text="Wednesday" />
                                        <asp:CheckBox ID="chkThu" runat="server" Text="Thursday"/>
                                        <asp:CheckBox ID="chkFri" runat="server" Text="Friday"/>
                                        <asp:CheckBox ID="chkSat" runat="server" Text="Saturday"/>
                                    </td>
                                </tr>
                                 <tr>
                                    <td colspan ="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                  <tr>
                                    <td style="color: #006666;text-align: right ; font-size:12pt;width :100px">
                                        Alarm Time : &nbsp;</td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:TextBox ID="txtFromtime" runat="server" Height="16px" Width="76px"></asp:TextBox>
                                       &nbsp; To : &nbsp;
                                        <asp:TextBox ID="txtToTime" runat="server" Height="16px" Width="76px"></asp:TextBox>
                                        &nbsp;
                                        <asp:CheckBox ID="chkAllDayEvent" runat="server" Text="All Day Event"/>
                                    </td>
                                </tr>
                                 <tr>
                                    <td colspan ="2">
                                        &nbsp;<asp:Label ID="lblidPort" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                               
                            </table>
                        </td>
                        <td width="4%"></td>
                       <%-- <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Minor Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox7" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox8" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value :
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="TextBox9" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>&nbsp;%
                                    </td>
                                </tr>
                               
                                <tr><td colspan ="2">&nbsp;</td></tr>
                            </table>
                        </td>
                         <td width="2%"></td>--%>
                    </tr>
                     <tr><td colspan ="3">&nbsp;</td></tr>
                   
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:Button ID="btnSavePort" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancelPort" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                   </tr>
                    <tr><td colspan ="3">&nbsp;</td></tr>
                     <tr>
                         <td width="2%"></td>
                         <td>
                             <asp:GridView ID="gvCfPortList" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                                 <AlternatingRowStyle BackColor="White" />
                                 <Columns>
                                     <asp:TemplateField HeaderText="id" Visible="False">
                                          <ItemTemplate >
                                             <asp:Label ID="lblid" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:BoundField DataField="no" HeaderText="No." >
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:BoundField>
                                     <asp:TemplateField HeaderText="Server Name">
                                           <ItemTemplate >
                                             <asp:Label ID="lblServername" runat="server" Text='<%# Bind("HostName")%>'></asp:Label>
                                         </ItemTemplate>
                                           <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Server IP">
                                           <ItemTemplate >
                                             <asp:Label ID="lblServerip" runat="server" Text='<%# Bind("HostIP")%>'></asp:Label>
                                         </ItemTemplate>
                                           <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Port">
                                           <ItemTemplate >
                                             <asp:Label ID="lblPort" runat="server" Text='<%# Bind("PortNumber")%>'></asp:Label>
                                         </ItemTemplate>
                                           <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                        <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit"  CommandName="EditRow" >
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" >
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:ButtonField>
                                 </Columns>
                                 <EditRowStyle BackColor="#7C6F57" />
                                 <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                 <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                 <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                 <RowStyle BackColor="#E3EAEB" />
                                 <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                 <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                 <SortedAscendingHeaderStyle BackColor="#246B61" />
                                 <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                 <SortedDescendingHeaderStyle BackColor="#15524A" />
                             </asp:GridView>
                         </td>
                         <td width="4%"></td>
                     </tr>
                </table>
            </div>
        </li>


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
      




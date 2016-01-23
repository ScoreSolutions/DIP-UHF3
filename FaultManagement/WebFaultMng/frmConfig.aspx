<%@ Page Title="" Language="VB" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="false" CodeFile="frmConfig.aspx.vb" Inherits="frmConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel ="stylesheet" href="Script/JScript.js" type ="text/javascript" />
  
    <script type ="text/javascript" src ="Script/jscautocomplete.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>

    

<script type="text/Javascript">
        function isNumberPKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode != 46))
                return false;

            return true;
        }
        //Confirm Delete 

        function Confirm() {
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
        //Validate textbox only number

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }


       

        //Show dialog
        function showModal(page, width, height, scroll) {
            showModalDialog(page, "", "dialogWidth:" + width + "px; dialogHeight:" + height + "px;help:no;status:no;center:yes;scroll:" + scroll);
        }

        function chkServer() {
            var AreaServer = document.getElementById('AreaServer');
            var AreaGroup = document.getElementById('AreaGroup');
            var Server = document.getElementById("<%=chkByServerRAM.ClientID%>");
              var Group = document.getElementById("<%= chkByGroupRAM.ClientID%>");

              if (Server.checked = true) {
                  Group.checked = false
                  AreaGroup.style.display = 'none'
                  if (AreaServer.style.display = 'none') {
                      AreaServer.style.display = 'block';
                     
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
             
            }
        }
    }

     

       

    function DivRAM() {

            document.getElementById('css3-tabstrip-0-0').checked = true
        };

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

    function ValidateTime(sender) {
        if (sender.value.length == 0) return false;
        var regEx = /^(\d{2}):(\d{2})$/;
        var arrMatch = sender.value.match(regEx);
        if (arrMatch == null) {
            alert("Invalid time.");
            sender.value = "";
            return false;
        }
        var hh = arrMatch[1];
        var mm = arrMatch[2];
        if (hh >= 24 || mm >= 60) {
            alert("Invalid time.");
            sender.value = "";
            return false;
        }
        return true;
    }

    function txtTime_OnKeyPress(sender, e) {
        var evt = e ? e : window.event;
        var charCode = evt.keyCode || evt.charCode;
        
        //var charCode = (event.which) ? event.which : event.keyCode
        //alert(charCode);
        if ((charCode != 8) && (charCode != 46)) {

            var myTime = sender.value;
            if (myTime.length > 4) {
                if (window.event)
                    event.returnValue = false;
                else
                    e.preventDefault();
            }

            switch (myTime.length) {
                case 0:
                    if (charCode < 48 || charCode > 50) {
                        if (window.event)
                            event.returnValue = false;
                        else
                            e.preventDefault();
                    }
                    break;
                case 1:
                    //alert("charCode=" + charCode + "  $$$$ " + myTime);
                    if (myTime == 2) {
                        if (charCode > 51 || charCode < 48) {
                            if (window.event)
                                event.returnValue = false;
                            else
                                e.preventDefault();
                        }
                    } else {
                        if (charCode < 48 || charCode > 57) {
                            if (window.event)
                                event.returnValue = false;
                            else
                                e.preventDefault();
                        }
                    }
                    break;
                case 2:
                    {
                        if (charCode < 48 || charCode > 53) {
                            if (window.event)
                                event.returnValue = false;
                            else
                                e.preventDefault();
                        }
                        sender.value = sender.value + ':';
                    }
                    break;
                case 3:
                    if (charCode < 48 || charCode > 53) {
                        if (window.event)
                            event.returnValue = false;
                        else
                            e.preventDefault();
                    }
                    //alert(3);
                    break;
                default:
                    if (charCode < 48 || charCode > 57) {
                        if (window.event)
                            event.returnValue = false;
                        else
                            e.preventDefault();
                    }
            }
        }
    }


    function Minor(sender) {
        var Major = parseInt(document.getElementById("<%=txtMajorRAM.ClientID%>").value, 10)
           

            if (sender.value > 100) {
                alert("Minor more than 100")
                sender.value = "";
                return
            }
            if (sender.value > Major - 1) {
                alert("Minor more than Major")
                sender.value = "";
                return
            }
        }

        function Major(sender) {

            var Minor = parseInt(document.getElementById("<%=txtMinorRAM.ClientID%>").value, 10)
             var Critical = parseInt(document.getElementById("<%=txtCriticalRAM.ClientID%>").value, 10)


             if (isNaN(Minor)) {
                 alert("Enter value Minor");
                 sender.value = "";
                 return
             }

             if (sender.value > 100) {
                 alert("Major more than 100")
                 sender.value = "";
                 return
             }


             if (sender.value < Minor - 1) {
                 alert("Minor more than Major")
                 sender.value = "";
                 return
             }
             if (sender.value > Critical - 1) {
                 alert("Major more than Critical")
                 sender.value = "";
                 return
             }
         }

         function Critical(sender) {
             var Minor = parseInt(document.getElementById("<%=txtMinorRAM.ClientID%>").value, 10)
             var Major = parseInt(document.getElementById("<%=txtMajorRAM.ClientID%>").value, 10)
            

             if (isNaN(Minor)) {
                 alert("Enter value Minor");
                 sender.value = "";
                 return
             }
             if (isNaN(Major)) {
                 alert("Enter value Major");
                 sender.value = "";
                 return
             }

             if (sender.value > 100) {
                 alert("Critical more than 100")
                 sender.value = "";
                 return
             }

             if (sender.value < Major - 1) {
                 alert("Critical more than Major")
                 sender.value = "";
                 return
             }
         }



        function MinorCPU(sender) {
            var Major = parseInt(document.getElementById("<%=txtMajorCPU.ClientID%>").value, 10)


             if (sender.value > 100) {
                 alert("Minor more than 100")
                 sender.value = "";
                 return
             }
             if (sender.value > Major - 1) {
                 alert("Minor more than Major")
                 sender.value = "";
                 return
             }
         }

        function MajorCPU(sender) {

             var Minor = parseInt(document.getElementById("<%=txtMinorCPU.ClientID%>").value, 10)
            var Critical = parseInt(document.getElementById("<%=txtCriticalCPU.ClientID%>").value, 10)


            if (isNaN(Minor)) {
                alert("Enter value Minor");
                sender.value = "";
                return
            }

            if (sender.value > 100) {
                alert("Minor more than 100")
                sender.value = "";
                return
            }


            if (sender.value < Minor - 1) {
                alert("Minor more than Major")
                sender.value = "";
                return
            }
            if (sender.value > Critical - 1) {
                alert("Major more than Critical")
                sender.value = "";
                return
            }
        }

        function CriticalCPU(sender) {
            var Minor = parseInt(document.getElementById("<%=txtMinorCPU.ClientID%>").value, 10)
             var Major = parseInt(document.getElementById("<%=txtMajorCPU.ClientID%>").value, 10)


             if (isNaN(Minor)) {
                 alert("Enter value Minor");
                 sender.value = "";
                 return
             }
             if (isNaN(Major)) {
                 alert("Enter value Major");
                 sender.value = "";
                 return
             }

             if (sender.value > 100) {
                 alert("Minor more than 100")
                 sender.value = "";
                 return
             }

             if (sender.value < Major - 1) {
                 alert("Critical more than Major")
                 sender.value = "";
                 return
             }
         }


        function MinorDrive(sender) {
            var Major = parseInt(document.getElementById("<%=txtMajorDrive.ClientID%>").value, 10)


               if (sender.value > 100) {
                   alert("Minor more than 100")
                   sender.value = "";
                   return
               }
               if (sender.value > Major - 1) {
                   alert("Minor more than Major")
                   sender.value = "";
                   return
               }
           }

        function MajorDrive(sender) {

               var Minor = parseInt(document.getElementById("<%=txtMinorDrive.ClientID%>").value, 10)
            var Critical = parseInt(document.getElementById("<%=txtCriticalDrive.ClientID%>").value, 10)


            if (isNaN(Minor)) {
                alert("Enter value Minor");
                sender.value = "";
                return
            }

            if (sender.value > 100) {
                alert("Minor more than 100")
                sender.value = "";
                return
            }


            if (sender.value < Minor - 1) {
                alert("Minor more than Major")
                sender.value = "";
                return
            }
            if (sender.value > Critical - 1) {
                alert("Major more than Critical")
                sender.value = "";
                return
            }
        }

        function CriticalDrive(sender) {
            var Minor = parseInt(document.getElementById("<%=txtMinorDrive.ClientID%>").value, 10)
            var Major = parseInt(document.getElementById("<%=txtMajorDrive.ClientID%>").value, 10)


            if (isNaN(Minor)) {
                alert("Enter value Minor");
                sender.value = "";
                return
            }
            if (isNaN(Major)) {
                alert("Enter value Major");
                sender.value = "";
                return
            }

            if (sender.value > 100) {
                alert("Minor more than 100")
                sender.value = "";
                return
            }

            if (sender.value < Major - 1) {
                alert("Critical more than Major")
                sender.value = "";
                return
            }
        }


        function MinorFile(sender) {
            var Major = parseInt(document.getElementById("<%=txtMajorFile.ClientID%>").value, 10)


            if (sender.value > 100) {
                alert("Minor more than 100")
                sender.value = "";
                return
            }
            if (sender.value > Major - 1) {
                alert("Minor more than Major")
                sender.value = "";
                return
            }
        }

        function MajorFile(sender) {

            var Minor = parseInt(document.getElementById("<%=txtMinorFile.ClientID%>").value, 10)
            var Critical = parseInt(document.getElementById("<%=txtCriticalFile.ClientID%>").value, 10)


            if (isNaN(Minor)) {
                alert("Enter value Minor");
                sender.value = "";
                return
            }

            if (sender.value > 100) {
                alert("Minor more than 100")
                sender.value = "";
                return
            }


            if (sender.value < Minor - 1) {
                alert("Minor more than Major")
                sender.value = "";
                return
            }
            if (sender.value > Critical - 1) {
                alert("Major more than Critical")
                sender.value = "";
                return
            }
        }

        function CriticalFile(sender) {
            var Minor = parseInt(document.getElementById("<%=txtMinorFile.ClientID%>").value, 10)
            var Major = parseInt(document.getElementById("<%=txtMajorFile.ClientID%>").value, 10)


            if (isNaN(Minor)) {
                alert("Enter value Minor");
                sender.value = "";
                return
            }
            if (isNaN(Major)) {
                alert("Enter value Major");
                sender.value = "";
                return
            }

            if (sender.value > 100) {
                alert("Minor more than 100")
                sender.value = "";
                return
            }

            if (sender.value < Major - 1) {
                alert("Critical more than Major")
                sender.value = "";
                return
            }
        }
</script>


<style type="text/css">
     

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
            height: 1000px;
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
                
    .auto-style1 {
        height: 25px;
    }


    #AreaGroupCPU{
    display :none ;
}

</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
      <table width="100%">
         <tr>
            <td style="font-family: quark; font-size: 20pt; font-weight: bold; color: #000000; border-radius:15px; ">&nbsp;&nbsp; Setting </td>
        </tr>
        <tr><td style="background-color: #666666"></td></tr>
        <tr>
            <td></td>
        </tr>
    </table>
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
                            &nbsp;RAM Configuration
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
                                  <td colspan ="2">

                                <div id="AreaServer" style ="width :100%">
                                    <table style ="width :100%">
                                 <tr>
                                    <td>
                                                             
                                   </td>
                                    <td>
                                       
                                                                             
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt; width :140px;">
                                       Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServeripRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>  <asp:Button ID="btnSerchipRAM" runat="server" Text="..." /> <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
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
                                    <td>
                                                             
                                   </td>
                                    <td>
                                        
                                    </td>
                                 </tr> 
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt; width :140px;">
                                      Group RAM :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtGroupRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                         <asp:Button ID="btnSerchGroupRAM" runat="server" Text="..." /> 
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
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="chkActiveStatusRAM" runat="server" Text="Active Status" Checked="True" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            &nbsp;Time Config
                            <div>
                              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                     
                            <table width="100%" style=" background-color:#AFEEEE; font-family: Quark; font-size: medium;">
                                <tr>
                                    <td colspan ="2"></td>
                                </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :143px;">
                                        Interval Minute : <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                     <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtIntervalRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" onkeypress="return isNumberKey(event)"></asp:TextBox>&nbsp;Minute
                                    </td>
                                </tr> 
                                            <tr>
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                     &nbsp;
                                         Alarm Date : <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                                    <td style="color: #006666;text-align: left; font-size: 12pt;">
                                      
                                        <table style="width :100% ;color: #006666; font-size:12pt;">
                                            <tr>
                                                <td>
                                                   <asp:CheckBox ID="chkSunRAM" runat="server" Text="Sunday" />
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkMonRAM" runat="server" Text="Monday" />
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkTueRAM" runat="server" Text="Tuesday" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:CheckBox ID="chkWedRAM" runat="server" Text="Wednesday" />
                                                </td>
                                                <td>
                                                     <asp:CheckBox ID="chkThuRAM" runat="server" Text="Thursday"/>
                                                </td>
                                                <td>
                                                     <asp:CheckBox ID="chkFriRAM" runat="server" Text="Friday"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkSatRAM" runat="server" Text="Saturday"/>
                                                </td>
                                                <td colspan ="2">
                                                    
                                                </td>
                                                
                                            </tr>
                                            
                                        </table>
  
                                    </td>
                                </tr>
                                 
                                <tr >
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                      Alarm Time : <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left ;vertical-align  :top ; font-size:12pt;">
                                        <asp:TextBox ID="txtFromTimeRAM" runat="server" Width="50px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox> &nbsp;To : &nbsp;<asp:TextBox ID="txtTOTimeRAM" runat="server" Width="50px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox>
                                        <asp:CheckBox ID="chkAllDayRAM" runat="server" Text="All Day Event" AutoPostBack="True"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="2"></td>
                                </tr>       
                            </table>
                       </ContentTemplate>
            </asp:UpdatePanel>
       </div>
                        </td>
                        <td width="4%"></td>
                        <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table style="width :100%;background-color:#AFEEEE;">
                                <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :110px">
                                        Minor Value : <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;width :70px">
                                       &nbsp;<asp:TextBox ID="txtMinorRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" onkeypress="return isNumberKey(event)" MaxLength="3" OnChange="Minor(this);" Width="30px"></asp:TextBox>&nbsp;%
                                    </td>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                      Check Repeat Minor : <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                         &nbsp;<asp:TextBox ID="txtRepeatMinorRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" onkeypress="return isNumberKey(event)" MaxLength="3" Width="30px"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value : <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMajorRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" OnChange="Major(this);" Width="30px"></asp:TextBox>&nbsp;%
                                    </td>
                                     <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Check Repeat Major : <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                         &nbsp;<asp:TextBox ID="txtRepeatMajorRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" onkeypress="return isNumberKey(event)" MaxLength="3" Width="30px"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value : <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtCriticalRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" OnChange="Critical(this);" Width="30px"></asp:TextBox>&nbsp;%
                                    </td>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Check Repeat Critical : <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                         &nbsp;<asp:TextBox ID="txtRepeatCriticalRAM" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" onkeypress="return isNumberKey(event)" MaxLength="3" Width="30px"></asp:TextBox>&nbsp;
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
                         <asp:GridView ID="gvRAM" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="True" Font-Names="Quark" Font-Size="10pt"  >
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
                                 <asp:TemplateField HeaderText="Group Code">
                                     <ItemTemplate >
                                         <asp:Label ID="lblgroup_code" runat="server" Text='<%#Bind("group_code")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Group desc">
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
                                 <asp:TemplateField HeaderText="Repeat Check Minor">
                                     <ItemTemplate >
                                         <asp:Label ID="lblRepeatCheckMinor" runat="server" Text='<%#Bind("RepeatCheckMinor")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Major Value(percent)">
                                     <ItemTemplate >
                                         <asp:Label ID="lblAlarmMajorValue" runat="server" Text='<%#Bind("AlarmMajorValue")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Repeat Check Major">
                                     <ItemTemplate >
                                              <asp:Label ID="lblRepeatCheckMajor" runat="server" Text='<%# Bind("RepeatCheckMajor")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Critical Value(percent)">
                                     <ItemTemplate >
                                         <asp:Label ID="lblAlarmCriticalValue" runat="server" Text='<%#Bind("AlarmCriticalValue")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Repeat Check Critical">
                                      <ItemTemplate >
                                         <asp:Label ID="lblRepeatCheckCritical" runat="server" Text='<%#Bind("RepeatCheckCritical")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Interval (minute)">
                                     <ItemTemplate >
                                         <asp:Label ID="lblCheckIntervalMinute" runat="server" Text='<%#Bind("CheckIntervalMinute")%>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Active Status" SortExpression="active_status" Visible="true" >
                                           <ItemTemplate>
                                              <asp:CheckBox ID="ChkActive" runat="server" Checked='<%# IIf(Eval("ActiveStatus").ToString() = "Y", True, False)%>'  Enabled="False" />
                                         </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                               <%--  <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" CommandName="EditRow" />
                                  <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete" CommandName="DeleteRow"/>--%>
                                  <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Edit" runat="server" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png"  CommandName="EditRow" CommandArgument ='<%# Bind("idcfRAM")%>'/>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Delete" runat="server" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" OnClientClick ="Confirm()" CommandName ="DeleteRow" CommandArgument ='<%# Bind("idcfRAM")%>'/>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>

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
                            &nbsp;CPU Configuration
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
                                    <td colspan ="2">


                                     <div id="AreaServerCPU" style ="width :100%">
                                    <table style ="width :100%">
                                         <tr>
                                    <td></td>
                                    <td>
                                        
                                       
                                    </td>
                                </tr>
                               
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt; width :143px;">
                                       Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServeripCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>&nbsp;<asp:Button ID="btnSerchipCPU" runat="server" Text="..." /><asp:Label ID="Label13" runat="server" Text="*" ForeColor="Red"></asp:Label>
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
                                    <td></td>
                                    <td>
                                         
                                            
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt; width :140px;">
                                       Group :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtGroupCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                            <asp:Button ID="btnSerchGroupCPU" runat="server" Text="..." /> <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
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
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :140px;">
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="chkActiveStatusCPU" runat="server" Text="Active Status" Checked="True" />
                                    </td>
                                </tr>
                            </table>
                         
                            <br />
                            &nbsp;Time Config
                            <div>
                             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                   <ContentTemplate>
                            <table width="100%" style=" background-color:#AFEEEE; font-family: Quark; font-size: medium;">
                                <tr>
                                    <td colspan ="2"></td>
                                </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :143px;">
                                        Interval Minute : <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtIntervalCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" onkeypress="return isNumberKey(event)"></asp:TextBox>&nbsp;Minute
                                    </td>
                                </tr> 
                                            <tr>
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                     &nbsp;
                                         Alarm Date : <asp:Label ID="Label16" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                                    <td style="color: #006666;text-align: left; font-size: 12pt;">
                                        <table style="width :100% ;color: #006666; font-size:12pt;">
                                            <tr>
                                                <td>
                                                   <asp:CheckBox ID="chkSunCPU" runat="server" Text="Sunday" />
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkMonCPU" runat="server" Text="Monday" />
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkTueCPU" runat="server" Text="Tuesday" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:CheckBox ID="chkWedCPU" runat="server" Text="Wednesday" />
                                                </td>
                                                <td>
                                                     <asp:CheckBox ID="chkThuCPU" runat="server" Text="Thursday"/>
                                                </td>
                                                <td>
                                                     <asp:CheckBox ID="chkFriCPU" runat="server" Text="Friday"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkSatCPU" runat="server" Text="Saturday"/>
                                                </td>
                                                <td colspan ="2">
                                                    
                                                </td>
                                                
                                            </tr>
                                            
                                        </table>
  
                                    </td>
                                </tr>
                                 
                                <tr >
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                      Alarm Time : <asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left ;vertical-align  :top ; font-size:12pt;">
                                        <asp:TextBox ID="txtFromTimeCPU" runat="server" Width="50px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox> &nbsp;To : &nbsp;<asp:TextBox ID="txtToTimeCPU" runat="server" Width="50px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox>
                                        <asp:CheckBox ID="chkAllDayCPU" runat="server" Text="All Day Event" AutoPostBack="True"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="2"></td>
                                </tr>       
                            </table>
                            </ContentTemplate>
                             </asp:UpdatePanel>
                            </div>
                        </td>
                        <td width="4%"></td>
                        <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table width="100%" style="background-color:#AFEEEE;">
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :110px">
                                        Minor Value : <asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;width :70px">
                                       &nbsp;<asp:TextBox ID="txtMinorCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" OnChange="MinorCPU(this);" Width="30px"></asp:TextBox>&nbsp;%
                                    </td>
                                      <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Check Repeat Minor : <asp:Label ID="Label19" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtRepeatMinorCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" Width="30px"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value : <asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMajorCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" OnChange="MajorCPU(this);" Width="30px"></asp:TextBox>&nbsp;%
                                    </td>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Check Repeat Major : <asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtRepeatMajorCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" Width="30px"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value : <asp:Label ID="Label22" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtCriticalCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" OnChange="CriticalCPU(this);" Width="30px"></asp:TextBox>&nbsp;%
                                    </td>
                                   <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Check Repeat Critical : <asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtRepeatCriticalCPU" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)"  Width="30px"></asp:TextBox>&nbsp;
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
                             <asp:GridView ID="gvCPU" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="True" Font-Names="Quark" Font-Size="10pt" emptydatatext="No data available." ShowHeaderWhenEmpty ="true"    >
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
                                     <asp:TemplateField HeaderText="Server IP">
                                          <ItemTemplate >
                                              <asp:Label ID="lblServerIP" runat="server" Text='<%# Bind("ServerIP")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Server Name">
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
                                     <asp:TemplateField HeaderText="Repeat Check Minor">
                                          <ItemTemplate >
                                              <asp:Label ID="lblRepeatCheckMinor" runat="server" Text='<%# Bind("RepeatCheckMinor")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Major Value (percent)">
                                          <ItemTemplate >
                                              <asp:Label ID="lblAlarmMajorValue" runat="server" Text='<%# Bind("AlarmMajorValue")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Repeat Check Major">
                                          <ItemTemplate >
                                              <asp:Label ID="lblRepeatCheckMajor" runat="server" Text='<%# Bind("RepeatCheckMajor")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Critical Value (percent)">
                                          <ItemTemplate >
                                              <asp:Label ID="lblAlarmCriticalValue" runat="server" Text='<%# Bind("AlarmCriticalValue")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Repeat Check Critical">
                                          <ItemTemplate >
                                              <asp:Label ID="lblRepeatCheckCritical" runat="server" Text='<%# Bind("RepeatCheckCritical")%>' ></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Interval(minute)">
                                          <ItemTemplate >
                                              <asp:Label ID="lblCheckIntervalMinute" runat="server" Text='<%# Bind("CheckIntervalMinute")%>' ></asp:Label>

                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="idcfCPU" Visible="False">
                                          <ItemTemplate >
                                              <asp:Label ID="lblidcfCPU" runat="server" Text='<%# Bind ("idcfCPU") %>' ></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Active Status" SortExpression="active_status" Visible="true" >
                                           <ItemTemplate>
                                              <asp:CheckBox ID="ChkActive" runat="server" Checked='<%# IIf(Eval("ActiveStatus").ToString() = "Y", True, False)%>'  Enabled="False" />
                                         </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                     <%--<asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit" CommandName="EditRow"  />--%>
                                     <%--<asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete" CommandName="DeleteRow"/>--%>
                                      <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Edit" runat="server" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png"  CommandName="EditRow" CommandArgument ='<%# Bind("idcfCPU")%>'/>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Delete" runat="server" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" OnClientClick ="Confirm()" CommandName ="DeleteRow" CommandArgument ='<%# Bind("idcfCPU")%>'/>
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
                            &nbsp;Drive Configuration
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
                                        <asp:Label ID="lblidDrive" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServerIPDriver" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                    &nbsp;<asp:Button ID="btnSerchipDrive" runat="server" Text="..." /><asp:Label ID="Label24" runat="server" Text="*" ForeColor="Red"></asp:Label>
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
                                    <td style="color: #006666;text-align: right; font-size: 12pt;" class="auto-style1">
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;" class="auto-style1">
                                       &nbsp;<asp:CheckBox ID="chkActiveStatusDrive" runat="server" Text="Active Status" Checked="True" />
                                    </td>
                                </tr>
                           
                            </table>
                             <br />
                            &nbsp;Time Config
                             <div>
                             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                   <ContentTemplate>
                            <table width="100%" style=" background-color:#AFEEEE; font-family: Quark; font-size: medium;">
                                <tr>
                                    <td colspan ="2"></td>
                                </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :143px;">
                                        Interval Minute : <asp:Label ID="Label25" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                     &nbsp;<asp:TextBox ID="txtIntervalDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"  onkeypress="return isNumberKey(event)"></asp:TextBox>&nbsp;Minute
                                    </td>
                                </tr> 
                                 <tr>
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                     &nbsp;
                                         Alarm Date : <asp:Label ID="Label26" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                                    <td style="color: #006666;text-align: left; font-size: 12pt;">
                                        <table style="width :100% ;color: #006666; font-size:12pt;">
                                            <tr>
                                                <td>
                                                   <asp:CheckBox ID="chkSunDrive" runat="server" Text="Sunday" />
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkMonDrive" runat="server" Text="Monday" />
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkTueDrive" runat="server" Text="Tuesday" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:CheckBox ID="chkWedDrive" runat="server" Text="Wednesday" />
                                                </td>
                                                <td>
                                                     <asp:CheckBox ID="chkThuDrive" runat="server" Text="Thursday"/>
                                                </td>
                                                <td>
                                                     <asp:CheckBox ID="chkFriDrive" runat="server" Text="Friday"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkSatDrive" runat="server" Text="Saturday"/>
                                                </td>
                                                <td colspan ="2">
                                                    
                                                </td>
                                                
                                            </tr>
                                            
                                        </table>
  
                                    </td>
                                </tr>
                                 
                                <tr >
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                      Alarm Time : <asp:Label ID="Label27" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left ;vertical-align  :top ; font-size:12pt;">
                                        <asp:TextBox ID="txtFromTimeDrive" runat="server" Width="50px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox> &nbsp;To : &nbsp;<asp:TextBox ID="txtToTimeDrive" runat="server" Width="50px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox>
                                        <asp:CheckBox ID="chkAllDayDrive" runat="server" Text="All Day Event" AutoPostBack="True"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="2"></td>
                                </tr>       
                            </table>
                                       </ContentTemplate>
                             </asp:UpdatePanel>
                            </div>
                        </td>
                        <td width="4%"></td>
                        <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                             <div>
                             <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                   <ContentTemplate>
                           
                                <table style="width :100%;  background-color:#AFEEEE;">
                                  
                                <tr>
                                    <td colspan ="4">&nbsp;
                                    <%--border:2px solid #009999;--%> 
                               <div id ="AreaDriveName" style ="width :100%;">
                                <table style="width : 100%">                                           
                                  <tr>
                                    <td colspan="2" style="color: #006666;text-align: right; font-size:12pt;width :100px;">
                                        Drive Name : <asp:Label ID="Label28" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td colspan ="2">&nbsp;
                                        <asp:DropDownList ID="ddlDriverName" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                   </tr>
                                   <tr>
                                       <td colspan ="2"></td>
                                   </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :110px">
                                        Minor Value : <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;width :70px">
                                       &nbsp;<asp:TextBox ID="txtMinorDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" OnChange="MinorDrive(this);" Width="30px"></asp:TextBox>&nbsp;%
                                    </td>
                                     <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Check Repeat Minor : <asp:Label ID="Label30" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtRepeatMinorDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)"  Width="30px"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value : <asp:Label ID="Label31" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMajorDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" OnChange="MajorDrive(this);" Width="30px"></asp:TextBox>&nbsp;%
                                    </td>
                                     <td style="color: #006666;text-align: right; font-size: 12pt;">
                                       Check Repeat Major : <asp:Label ID="Label32" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtRepeatMajorDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" Width="30px"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr><td colspan ="2">&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value : <asp:Label ID="Label33" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtCriticalDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" OnChange="CriticalDrive(this);" Width="30px"></asp:TextBox>&nbsp;%
                                    </td>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Check Repeat Critical : <asp:Label ID="Label34" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtRepeatCriticalDrive" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" Width="30px"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                             <tr>
                                                <td colspan ="4"></td>
                                            </tr>
                                              <tr>
                                                <td colspan ="2">
                                                    </td>
                                                <td colspan ="2">
                                                    <asp:Button ID="SubmitDriveName" runat="server" Text="Submit" /> <asp:Label ID="Label35" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                                    <asp:Label ID="lblDriveid" runat="server" Text="0" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                               <tr>
                                                <td colspan ="4">
                                                    <asp:Label ID="lblnoDrive" runat="server" Text="No Data Drive" ForeColor="#CC0000"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan ="4">
                                                 
                                                     <div style="width: 100%; height: 220px; overflow-y: auto; margin-left :auto;margin-right :auto;">
                                                    <asp:GridView ID="gvSelectDrive" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="True" Font-Names="Quark" Font-Size="10pt" Width="100%">
                                                        <AlternatingRowStyle BackColor="White" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="id" Visible="False">
                                                                <ItemTemplate>
                                                                     <asp:Label ID="lblid" runat="server" Text='<%# Bind("id")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Drive">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDrivename" runat="server" Text='<%# Bind("DriveName")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Minor">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMinor" runat="server" Text='<%# Bind("Minor")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Repeat Minor">
                                                                 <ItemTemplate>
                                                                    <asp:Label ID="lblRepeatMinor" runat="server" Text='<%# Bind("RepeatMinor")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Major">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMajor" runat="server" Text='<%# Bind("Major")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Repeat Major">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRepeatMajor" runat="server" Text='<%# Bind("RepeatMajor")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Critical">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCritical" runat="server" Text='<%# Bind("Critical")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Repeat Critical">
                                                                 <ItemTemplate>
                                                                    <asp:Label ID="lblRepeatCritical" runat="server" Text='<%# Bind("RepeatCritical")%>' ></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
                                                     </div>    
                                                    
                                                </td>
                                            </tr>
                                          
                                        </table>
                                    </div>
                                    </td></tr>
                             
                              
                            </table>
                              </ContentTemplate>
                             </asp:UpdatePanel>
                            </div>
                            <table >
                                <tr>
                                    <td>

                                    </td>
                                </tr>
                            </table>
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
                                     <asp:TemplateField HeaderText="Active Status" SortExpression="active_status" Visible="true" >
                                           <ItemTemplate>
                                              <asp:CheckBox ID="ChkActive" runat="server" Checked='<%# IIf(Eval("ActiveStatus").ToString() = "Y", True, False)%>'  Enabled="False" />
                                         </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
               <%--                     <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit"  CommandName="EditRow" />
                                    <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" />--%>
                                     <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Edit" runat="server" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png"  CommandName="EditRow" CommandArgument ='<%# Bind("id")%>'/>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Delete" runat="server" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" OnClientClick ="Confirm()" CommandName ="DeleteRow" CommandArgument ='<%# Bind("id")%>'/>
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
                            &nbsp;Service Configuration
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
                                        
                                    </td>
                                </tr>
                                 
                                  <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServeripService" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                        <asp:Button ID="btnSerchipService" runat="server" Text="..." />&nbsp;<asp:Label ID="Label36" runat="server" Text="*" ForeColor="Red"></asp:Label>
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
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                      Check Repeat : <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtRepeatCheckService" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"  onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    </td>
                                </tr>
                             
                                <tr><td colspan ="2">&nbsp;</td></tr> 
                                <tr>
                                    <td></td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">&nbsp;
                                        <asp:CheckBox ID="chkActiveStatusService" runat="server" Text="Active Status" Checked="True" />
                                        <asp:Label ID="lblServiceid" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>

                                </tr>
                               
                            </table>
                               <br />
                            &nbsp;Time Config
                            <div>
                             <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                   <ContentTemplate>
                           
                            <table width="100%" style=" background-color:#AFEEEE; font-family: Quark; font-size: medium;">
                                <tr>
                                    <td colspan ="2"></td>
                                </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :143px;">
                                        Interval Minute : <asp:Label ID="Label38" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtIntervalService" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" onkeypress="return isNumberKey(event)"></asp:TextBox>&nbsp;Minute
                                    </td>
                                </tr> 
                                            <tr>
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                     &nbsp;
                                         Alarm Date : <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                                    <td style="color: #006666;text-align: left; font-size: 12pt;">
                                        <table style="width :100% ;color: #006666; font-size:12pt;">
                                            <tr>
                                                <td>
                                                   <asp:CheckBox ID="chkSunService" runat="server" Text="Sunday" />
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkMonService" runat="server" Text="Monday" />
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkTueService" runat="server" Text="Tuesday" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:CheckBox ID="chkWedService" runat="server" Text="Wednesday" />
                                                </td>
                                                <td>
                                                     <asp:CheckBox ID="chkThuService" runat="server" Text="Thursday"/>
                                                </td>
                                                <td>
                                                     <asp:CheckBox ID="chkFriService" runat="server" Text="Friday"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkSatService" runat="server" Text="Saturday"/>
                                                </td>
                                                <td colspan ="2">
                                                    
                                                </td>
                                                
                                            </tr>
                                            
                                        </table>
  
                                    </td>
                                </tr>
                                 
                                <tr >
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                      Alarm Time : <asp:Label ID="Label40" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left ;vertical-align  :top ; font-size:12pt;">
                                        <asp:TextBox ID="txtFromTimeService" runat="server" Width="50px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox> &nbsp;To : &nbsp;<asp:TextBox ID="txtToTimeService" runat="server" Width="50px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox>
                                        <asp:CheckBox ID="chkAllDayService" runat="server" Text="All Day Event" AutoPostBack="True"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="2"></td>
                                </tr>       
                            </table>
                                       </ContentTemplate> 
                                 </asp:UpdatePanel> 
                                </div> 
                        </td>
                        <td width="4%"></td>
                        <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table width="100%" style="background-color:#AFEEEE;">
                               
                               <tr>
                                   <td style="color: #006666;text-align: left ; font-size: 12pt;">Add Service : <asp:Button ID="btnAddService" runat="server" Text="Service" /></td>
                                   <td>
                                       

                                   </td>
                               </tr>
                                <tr>
                                    <td colspan ="2">
                                        <div style="width: 100%; height: 470px; overflow-y: auto; margin-left :auto;margin-right :auto;">   
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
                                                <asp:TemplateField HeaderText="Service Name">
                                                    <ItemTemplate >
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("WindowServiceName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate >
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("DisplayName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle VerticalAlign="Middle" />
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
                                     <asp:TemplateField HeaderText="Active Status" SortExpression="active_status" Visible="true" >
                                           <ItemTemplate>
                                              <asp:CheckBox ID="ChkActive" runat="server" Checked='<%# IIf(Eval("ActiveStatus").ToString() = "Y", True, False)%>'  Enabled="False" />
                                         </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                   <%--   <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit"  CommandName="EditRow" />
                                    <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" />--%>
                                     <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Edit" runat="server" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png"  CommandName="EditRow" CommandArgument ='<%# Bind("ServerIP")%>'/>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Delete" runat="server" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" OnClientClick ="Confirm()" CommandName ="DeleteRow" CommandArgument ='<%# Bind("ServerIP")%>'/>
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
                            &nbsp;Process Configuration
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
                                     <td></td>
                                 </tr>
                                  <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServeripProcess" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                     <asp:Button ID="btnSerchipProcess" runat="server" Text="..." /> <asp:Label ID="Label41" runat="server" Text="*" ForeColor="Red"></asp:Label>
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
                                       Check Repeat : <asp:Label ID="Label42" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666; font-size:12pt;">
                                        &nbsp;<asp:TextBox ID="txtRepeatCheckProcess" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" onkeypress="return isNumberKey(event)"></asp:TextBox>
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
                            <br />
                            &nbsp;Time Config
                              <div>
                             <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                   <ContentTemplate>
                            <table width="100%" style=" background-color:#AFEEEE; font-family: Quark; font-size: medium;">
                                <tr>
                                    <td colspan ="2"></td>
                                </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :143px;">
                                        Interval Minute : <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        &nbsp;<asp:TextBox ID="txtIntervalProcess" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" onkeypress="return isNumberKey(event)"></asp:TextBox>&nbsp;Minute
                                    </td>
                                </tr> 
                                            <tr>
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                     &nbsp;
                                         Alarm Date : <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                                    <td style="color: #006666;text-align: left; font-size: 12pt;">
                                        <table style="width :100% ;color: #006666; font-size:12pt;">
                                            <tr>
                                                <td>
                                                   <asp:CheckBox ID="chkSunProcess" runat="server" Text="Sunday" />
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkMonProcess" runat="server" Text="Monday" />
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkTueProcess" runat="server" Text="Tuesday" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:CheckBox ID="chkWedProcess" runat="server" Text="Wednesday" />
                                                </td>
                                                <td>
                                                     <asp:CheckBox ID="chkThuProcess" runat="server" Text="Thursday"/>
                                                </td>
                                                <td>
                                                     <asp:CheckBox ID="chkFriProcess" runat="server" Text="Friday"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkSatProcess" runat="server" Text="Saturday"/>
                                                </td>
                                                <td colspan ="2">
                                                    
                                                </td>
                                                
                                            </tr>
                                            
                                        </table>
  
                                    </td>
                                </tr>
                                 
                                <tr >
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                      Alarm Time : <asp:Label ID="Label45" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left ;vertical-align  :top ; font-size:12pt;">
                                        <asp:TextBox ID="txtFromTimeProcess" runat="server" Width="50px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox> &nbsp;To : &nbsp;<asp:TextBox ID="txtToTimeProcess" runat="server" Width="50px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox>
                                        <asp:CheckBox ID="chkAllDayProcess" runat="server" Text="All Day Event" AutoPostBack="True"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="2"></td>
                                </tr>       
                            </table>
                                       </ContentTemplate>
                                 </asp:UpdatePanel>
                                  </div> 
                        </td>
                        <td width="4%"></td>
                        <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                            <table width="100%" style="background-color:#AFEEEE;">
                               <tr>
                                <td style="color: #006666;text-align: left ; font-size: 12pt;">Add Process : <asp:Button ID="btnAddProcess" runat="server" Text="Process" /></td>
                                   <td>
                                       

                                   </td>
                                   </tr>
                                <tr>
                                    <td colspan ="2">
                                          <div style="width: 100%; height: 470px; overflow-y: auto;margin-left :auto;margin-right :auto;">   
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
                                                        <asp:Label ID="lblProcessName" runat="server" Text='<%#Bind("WindowProcessName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate >
                                                    <asp:Label ID="lblActiveStatus" runat="server" Text='<%#Bind("DisplayName")%>'></asp:Label>
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
                                     <asp:TemplateField HeaderText="Active Status" SortExpression="active_status" Visible="true" >
                                           <ItemTemplate>
                                              <asp:CheckBox ID="ChkActive" runat="server" Checked='<%# IIf(Eval("ActiveStatus").ToString() = "Y", True, False)%>'  Enabled="False" />
                                         </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                   <%--   <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit"  CommandName="EditRow" />
                                    <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" />--%>
                                     <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Edit" runat="server" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png"  CommandName="EditRow" CommandArgument ='<%# Bind("ServerIP")%>'/>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Delete" runat="server" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" OnClientClick ="Confirm()" CommandName ="DeleteRow" CommandArgument ='<%# Bind("ServerIP")%>'/>
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
                            &nbsp;File Size Configuration
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
                                            
                                     </td>
                                 </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Server IP :
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtServeripFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>   <asp:Button ID="btnSerchipFileSize" runat="server" Text="..." /> <asp:Label ID="Label46" runat="server" Text="*" ForeColor="Red"></asp:Label>
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
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">

                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:CheckBox ID="chkActiveStatusFile" runat="server" Text="Active Status" Checked="True" />
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                            </table>

                             <br />
                            &nbsp;Time Config
                              <div>
                             <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                   <ContentTemplate>
                            <table width="100%" style=" background-color:#AFEEEE; font-family: Quark; font-size: medium;">
                                <tr>
                                    <td colspan ="2"></td>
                                </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :130px;">
                                        Interval Minute : <asp:Label ID="Label47" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                    &nbsp;<asp:TextBox ID="txtIntervelFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" onkeypress="return isNumberKey(event)"></asp:TextBox>&nbsp;Minute
                                    </td>
                                </tr> 
                                 <tr>
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                     &nbsp;
                                         Alarm Date : <asp:Label ID="Label48" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                                    <td style="color: #006666;text-align: left; font-size: 12pt;">
                                        <table style="width :100% ;color: #006666; font-size:12pt;">
                                            <tr>
                                                <td>
                                                   <asp:CheckBox ID="chkSunFile" runat="server" Text="Sunday" />
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkMonFile" runat="server" Text="Monday" />
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkTueFile" runat="server" Text="Tuesday" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:CheckBox ID="chkWedFile" runat="server" Text="Wednesday" />
                                                </td>
                                                <td>
                                                     <asp:CheckBox ID="chkThuFile" runat="server" Text="Thursday"/>
                                                </td>
                                                <td>
                                                     <asp:CheckBox ID="chkFriFile" runat="server" Text="Friday"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkSatFile" runat="server" Text="Saturday"/>
                                                </td>
                                                <td colspan ="2">
                                                    
                                                </td>
                                                
                                            </tr>
                                            
                                        </table>
  
                                    </td>
                                </tr>
                                 
                                <tr >
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                      Alarm Time : <asp:Label ID="Label49" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left ;vertical-align  :top ; font-size:12pt;">
                                        <asp:TextBox ID="txtFromTimeFile" runat="server" Width="50px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox> &nbsp;To : &nbsp;<asp:TextBox ID="txtToTimeFile" runat="server" Width="50px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox>
                                        <asp:CheckBox ID="chkAllDayFile" runat="server" Text="All Day Event" AutoPostBack="True"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="2"></td>
                                </tr>       
                            </table>
                                       </ContentTemplate> 
                                 </asp:UpdatePanel> 
                                  </div> 
                        </td>
                        <td width="4%">&nbsp;</td>
                        <td width="450px" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;">
                            &nbsp;Alarm Severity
                         
                            <table width="100%" style="background-color:#AFEEEE;">
                               
                                <tr><td colspan ="4">&nbsp;</td></tr>
                               
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Path File : <asp:Label ID="Label50" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td colspan ="3" style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtPathFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>
                                        &nbsp;<asp:Button ID="btnBrownparthfile" runat="server" Text="..." />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="4" >
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :110px">
                                        Minor Value : <asp:Label ID="Label51" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;width :70px">
                                       &nbsp;<asp:TextBox ID="txtMinorFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" OnChange="MinorFile(this);" Width="30px"></asp:TextBox>&nbsp;GB
                                    </td>
                                     <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Check Repeat Minor : <asp:Label ID="Label52" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtRepeatMinorFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" Width="30px"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr><td colspan ="4">&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Major Value : <asp:Label ID="Label53" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtMajorFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" OnChange="MajorFile(this);" Width="30px"></asp:TextBox>&nbsp;GB
                                    </td>
                                     <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Check Repeat Major : <asp:Label ID="Label54" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtRepeatMajorFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" Width="30px"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr><td colspan ="4">&nbsp;</td></tr>
                               <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Critical Value : <asp:Label ID="Label55" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtCriticalFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" OnChange="CriticalFile(this);" Width="30px"></asp:TextBox>&nbsp;GB
                                    </td>
                                   <td style="color: #006666;text-align: right; font-size: 12pt;">
                                        Check Repeat Critical : <asp:Label ID="Label56" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       &nbsp;<asp:TextBox ID="txtRepeatCriticalFile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="3" onkeypress="return isNumberKey(event)" Width="30px"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="4">&nbsp;</td>
                                </tr>
                              
                                 <tr>
                                  <td colspan ="2">&nbsp;</td>
                                   <td colspan ="2">
                                       <asp:Button ID="btnConfirm" runat="server" Text="Submit" /> <asp:Label ID="Label57" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                       <asp:Label ID="lblidPathFile" runat="server" Text="0" Visible="False"></asp:Label>
                                   </td>
                                </tr>
                                <tr>
                               <td colspan ="2" style="color: #006666;font-size: 12pt;">&nbsp;
                                   <asp:Label ID="lblnoPathFile" runat="server" Text="No Data PathFile" ForeColor="#CC0000"></asp:Label>
                               </td>
                                </tr>
                     
                                
                                <tr>
                      <td colspan ="4">                  
                      
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
                                        <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Minor">
                                       <ItemTemplate >
                                          <asp:Label ID="lblMinor" runat="server" Text='<%# Bind("FileSizeMinor")%>'></asp:Label>
                                      </ItemTemplate>
                                       <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Repeat Minor">
                                      <ItemTemplate>
                                        <asp:Label ID="lblRepeatMinor" runat="server" Text='<%# Bind("RepeatMinor")%>' ></asp:Label>
                                       </ItemTemplate>
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Major">
                                        <ItemTemplate >
                                          <asp:Label ID="lblMajor" runat="server" Text='<%# Bind("FileSizeMajor")%>'></asp:Label>
                                      </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Repeat Major">
                                      <ItemTemplate>
                                        <asp:Label ID="lblRepeatMajor" runat="server" Text='<%# Bind("RepeatMajor")%>' ></asp:Label>
                                       </ItemTemplate>
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Critical">
                                      <ItemTemplate >
                                          <asp:Label ID="lblCritical" runat="server" Text='<%# Bind("FileSizeCritical")%>'></asp:Label>
                                      </ItemTemplate>
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Repeat Critical">
                                      <ItemTemplate>
                                        <asp:Label ID="lblRepeatCritical" runat="server" Text='<%# Bind("RepeatCritical")%>' ></asp:Label>
                                       </ItemTemplate>
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                  </asp:TemplateField>
                                  <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png"   CommandName="EditRow" >
                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                  </asp:ButtonField>
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
                                       <asp:TemplateField HeaderText="Active Status" SortExpression="active_status" Visible="true" >
                                           <ItemTemplate>
                                              <asp:CheckBox ID="ChkActive" runat="server" Checked='<%# IIf(Eval("ActiveStatus").ToString() = "Y", True, False)%>'  Enabled="False" />
                                         </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                     <%-- <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit"  CommandName="EditRow" >
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:ButtonField>--%>
                                    <%--<asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" >
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:ButtonField>--%>
                                      <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Edit" runat="server" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png"  CommandName="EditRow" CommandArgument ='<%# Bind("cfDETAILid")%>'/>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Delete" runat="server" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" OnClientClick ="Confirm()" CommandName ="DeleteRow" CommandArgument ='<%# Bind("cfDETAILid")%>'/>
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
                            &nbsp;Port Configuration
                            <table width="100%" style="background-color:#AFEEEE;">                                
                                <tr>
                                    <td style="color: #006666;text-align: right; font-size: 12pt;width :110px">
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
                                     <td  style="color: #006666;text-align: right; font-size: 12pt;width :110px">
                                        Server IP :
                                     </td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                       <asp:TextBox ID="txtServeripPort" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"  onkeypress="return isNumberPKey(event)" Enabled="False"></asp:TextBox> 
                                   
                                        &nbsp;<asp:Button ID="btnSerchipPort" runat="server" Text="..." /> &nbsp;<asp:Label ID="Label58" runat="server" Text="*" ForeColor="Red"></asp:Label>&nbsp; 
                                   
                                        Server Name :
                                    
                                        &nbsp;<asp:TextBox ID="txtServerNamePort" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Enabled="False"></asp:TextBox>&nbsp;
                                  
                                        Port : <asp:Label ID="Label59" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                  
                                        &nbsp;<asp:TextBox ID="txtPort" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="4"  onkeypress="return isNumberKey(event)"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>

                               <tr>
                                    <td colspan ="2">
                                        &nbsp;
                                    </td>
                                </tr>
                               <tr>
                                   <td colspan ="2"  style="color: #006666;text-align: right; font-size: 12pt;">
                           <div>
                             <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                   <ContentTemplate>
                                       <table>
<tr>
                                    <td style="color: #006666;text-align: right;vertical-align  :top ; font-size:12pt;">
                                     &nbsp;
                                         Alarm Date : <asp:Label ID="Label60" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                                    <td style="color: #006666;text-align: left; font-size: 12pt;">

                                        
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
                                    <td style="color: #006666;text-align: right ; font-size:12pt;width :110px">
                                        Alarm Time : <asp:Label ID="Label61" runat="server" Text="*" ForeColor="Red"></asp:Label>&nbsp;</td>
                                    <td style="color: #006666;text-align: left;font-size: 12pt;">
                                        <asp:TextBox ID="txtFromtime" runat="server" Height="16px" Width="76px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox>
                                        
                                       &nbsp; To : <asp:Label ID="Label62" runat="server" Text="*" ForeColor="Red"></asp:Label>&nbsp;
                                        <asp:TextBox ID="txtToTime" runat="server" Height="16px" Width="76px" onkeypress="txtTime_OnKeyPress(this,event);" OnChange="ValidateTime(this)"></asp:TextBox>
                                        &nbsp;
                                         <asp:CheckBox ID="chkAllDayEvent" runat="server" Text="All Day Event" AutoPostBack="True"/>  
                                    </td>
                                </tr>
                                       </table>
                                     
                                       </ContentTemplate>
                                 </asp:UpdatePanel>
                                </div>
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
                             <asp:GridView ID="gvCfPortList" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Bold="True" Font-Names="Quark" Font-Size="Small">
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
                                       
                                        <%--<asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" Text="Edit"  CommandName="EditRow" >
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" Text="Delete"  CommandName="DeleteRow" >
                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:ButtonField>--%>
                                      <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Edit" runat="server" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png"  CommandName="EditRow" CommandArgument ='<%# Bind("id")%>'/>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Delete" runat="server" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" OnClientClick ="Confirm()" CommandName ="DeleteRow" CommandArgument ='<%# Bind("id")%>'/>
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
                         </td>
                         <td width="4%"></td>
                     </tr>
                </table>
            </div>
        </li>


    </ul>
                             </div>
      
</asp:Content>


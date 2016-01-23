<%@ Page Title="" Language="VB" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="false" CodeFile="frmRegisterForm.aspx.vb" Inherits="frmRegisterForm" %>
<%@ Register src="UserControls/ctlConfigSeverity.ascx" tagname="ctlConfigSeverity" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="UserControls/ctlConfigSchedule.ascx" tagname="ctlConfigSchedule" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
    //Show dialog
    function showModal(page, width, height, scroll) {
        showModalDialog(page, "", "dialogWidth:" + width + "px; dialogHeight:" + height + "px;help:no;status:no;center:yes;scroll:" + scroll);
    }

    //function of Checkbox


    //Refresh Tab
    function TabUser() {

        document.getElementById('css3-tabstrip-0-0').checked = true
    };
    function TabRole() {

        document.getElementById('css3-tabstrip-0-1').checked = true
    };
    function TabGroup() {

        document.getElementById('css3-tabstrip-0-2').checked = true
    };
    function TabRegister() {

        document.getElementById('css3-tabstrip-0-3').checked = true
    };

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

    //Validate Password
    function isPasswordKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode != 92))
            if (charCode > 31 && (charCode != 47))
                if (charCode > 31 && (charCode != 58))
                    if (charCode > 31 && (charCode != 42))
                        if (charCode > 31 && (charCode != 63))
                            if (charCode > 31 && (charCode != 34))
                                if (charCode > 31 && (charCode != 60))
                                    if (charCode > 31 && (charCode != 62))
                                        if (charCode > 31 && (charCode != 124))

                                            return true;
        return false;
    }

    //Validate textbox number'0-9' & decimal point '.'

    function isNumberPKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode != 46))
            return false;

        return true;
    }

    //Validate textbox email

    function isNumberEKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode != 46) && (charCode < 64 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode != 95))
            return false;

        return true;
    }

    //Validate textbox name
    function isNameKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode != 46))
            if (charCode > 31 && (charCode < 65 || charCode > 90))
                if (charCode > 31 && (charCode < 97 || charCode > 122))
                    if (charCode > 31 && (charCode < 3585 || charCode > 3642) && (charCode < 3648 || charCode > 3660))
                        return false;
        return true;

    }

    //Validate textbox Lastname & Nickname
    function isLNameKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 65 || charCode > 90))
            if (charCode > 31 && (charCode < 97 || charCode > 122))
                if (charCode > 31 && (charCode < 3585 || charCode > 3642) && (charCode < 3648 || charCode > 3660))
                    return false;
        return true;

    }

    //Validate textbox Username & code & Description

    function isUsernameKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            if (charCode > 31 && (charCode < 65 || charCode > 90))
                if (charCode > 31 && (charCode < 97 || charCode > 122))
                    if (charCode > 31 && (charCode < 3585 || charCode > 3642) && (charCode < 3648 || charCode > 3660))

                        return false;

        return true;
    }

    //Validate textbox Data etc.
    function isDataKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            if (charCode > 31 && (charCode < 65 || charCode > 90))
                if (charCode > 31 && (charCode < 97 || charCode > 122))
                    if (charCode > 31 && (charCode < 3585 || charCode > 3642) && (charCode < 3648 || charCode > 3660))
                        if (charCode > 31 && (charCode != 32))

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
                            if (charCode > 31 && (charCode != 32))
                                return false;

        return true;
    }

    //Validate textbox Mac Address & OS
    function isMacAddressKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            if (charCode > 31 && (charCode < 65 || charCode > 90))
                if (charCode > 31 && (charCode < 97 || charCode > 122))
                    return false;
        return true;

    }


    </script>
    
    <style type="text/css">
  
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
            height: 940px;
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

        .auto-style11 {
            width: 121px;
        }
        .auto-style12 {
            width: 232px;
        }

        .auto-style13 {
            width: 130px;
        }
        .zHidden {
            display:none;
        }

        .auto-style14 {
            width: 100%;
        }

        .auto-style15 {
            height: 31px;
        }

        </style>
     <script type="text/javascript">
         function showModal(page, width, height, scroll) {
             var ServerIP = document.getElementById('<%= txtServerIP.ClientID%>').value;  
             if (ServerIP.trim() != "") {
                 showModalDialog(page, "", "dialogWidth:" + width + "px; dialogHeight:" + height + "px;help:no;status:no;center:yes;scroll:" + scroll);
                 return true;
             } else {
                 alert("Please input Server IP");
                 return false;
             }
         }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <table width="100%">
         <tr>
            <td style="font-family: quark; font-size: 20pt; font-weight: bold; color: #000000; border-radius:15px; ">&nbsp;&nbsp; Register</td>
        </tr>
        <tr><td style="background-color: #666666"></td></tr>
        <tr>
            <td>
                <asp:Button ID="btnBack" CssClass="myButton" runat="server" Text="Back" />
            </td>
        </tr>
    </table>

    <div id="divregister">
        <table width="100%">
            <tr>
                <td style="border: 0px; border-style: none; border-color: red; background-color: #009999; height: 30px; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium; border-top-left-radius: 10px; border-top-right-radius: 10px;">&nbsp;Register
                </td>
                <td style="border: 0px; border-style: none; border-color: red; background-color: #009999; height: 30px; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium; border-top-left-radius: 10px; border-top-right-radius: 10px;">&nbsp;Notification
                </td>
            </tr>
            <tr>
                <td style="width: 66%; background-color: #009999; height: 200px;">

                    <table style="background-color: #AFEEEE; width: 100%">
                        <tr>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">Server IP :
                                         <asp:Label ID="Label23" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtServerIP" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="15" onkeypress="return isNumberPKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                            </td>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">Server Name :
                                         <asp:Label ID="lbl19" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtServerName" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="100" Onkeypress="return isServerNameKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">Mac Address :&nbsp;
                                        <asp:Label ID="lbl21" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMacAddress" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="12" Onkeypress="return isMacAddressKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                            </td>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">OS :&nbsp;
                                        <asp:Label ID="lbl20" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOS" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="255" Onkeypress="return isDataKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">Project Name :
                                        <asp:Label ID="lbl22" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSystem" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="100" oncopy="return false" oncut="return false" onpaste="return false" OnKeypress="return isDataKey(event)"></asp:TextBox>
                            </td>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">
                                <asp:TextBox ID="txtIDRegister" runat="server" Visible="False" Width="86px">0</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIDCPU" runat="server" Visible="False" Width="83px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">
                                <asp:Label ID="Label21" runat="server" Text="Location Server :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLacServer" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="100" oncopy="return false" oncut="return false" onpaste="return false" OnKeypress="return isDataKey(event)"></asp:TextBox>
                            </td>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">
                                <asp:TextBox ID="txtIDRAM" runat="server" Visible="False" Width="84px">0</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIDDrive" runat="server" Visible="False" Width="84px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">
                                <asp:Label ID="Label22" runat="server" Text="Location Number :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLacNumber" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="100" oncopy="return false" oncut="return false" onpaste="return false" OnKeypress="return isDataKey(event)"></asp:TextBox>
                            </td>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">
                                <asp:TextBox ID="txtIDService" runat="server" Visible="False" Width="84px">0</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIDProcess" runat="server" Visible="False" Width="84px">0</asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;">
                                <asp:TextBox ID="txtIDFileSize" runat="server" Visible="False" Width="84px">0</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIDPort" runat="server" Visible="False" Width="84px">0</asp:TextBox>
                            </td>
                        </tr>


                        <tr>
                            <td style="height: 40px"></td>
                            <td></td>
                        </tr>

                    </table>

                </td>
                <td style="width: 40%; vertical-align: top; background-color: #009999; height: 200px;">

                    <table style="background-color: #AFEEEE; width: 100%">

                        <tr>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;" class="auto-style13">First Name :
                                        <asp:Label ID="lbl16" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFnameR" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="100" onkeypress="return isNameKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;" class="auto-style13">Last Name :
                                           <asp:Label ID="lbl17" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLnameR" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="100" onkeypress="return isNameKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;" class="auto-style13">E-mail :
                                         <asp:Label ID="lbl18" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="100" onkeypress="return isNumberEKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="'email@gmail.com'" Font-Names="Quark" Font-Size="12pt" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;" class="auto-style13">
                                &nbsp;</td>
                            <td>
                                <asp:CheckBox ID="chkActiveStatusR" runat="server" Text="Active Status" Font-Names="Quark" ForeColor="#006666" Font-Size="12pt" Checked="True" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 74px">
                                <br />

                            </td>
                        </tr>




                    </table>

                </td>
            </tr>

        </table>

    </div>


    <div id="divcpu">
        <table width="66%">
            <tr>
                <td style="border: 0px; border-style: none; border-color: red; background-color: #009999; height: 30px; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium; border-top-left-radius: 10px; border-top-right-radius: 10px;">&nbsp;CPU Configuration
                </td>
            </tr>
            <tr>
                <td style="border: 0px; border-style: none; background-color: #009999;">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <uc2:ctlConfigSchedule ID="ctlCPUConfig" runat="server" />
                                <uc1:ctlConfigSeverity ID="ctlCPUSeverity" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
            </tr>
        </table>
    </div>


    <div id="divram">
        <table width="66%">
            <tr>
                <td style="border: 0px; border-style: none; border-color: red; background-color: #009999; height: 30px; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium; border-top-left-radius: 10px; border-top-right-radius: 10px;">&nbsp;RAM Configuration
                </td>
            </tr>
            <tr>
                <td style="border: 0px; border-style: none; background-color: #009999;">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <uc2:ctlConfigSchedule ID="ctlRamConfig" runat="server" />
                                <uc1:ctlConfigSeverity ID="ctlRamSeverity" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>

            </tr>

        </table>
    </div>


    <div id="divdrive">
        <table width="66%">
            <tr>
                <td style="border: 0px; border-style: none; border-color: red; background-color: #009999; height: 30px; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium; border-top-left-radius: 10px; border-top-right-radius: 10px;">&nbsp;Drive Configuration
                </td>
            </tr>
            <tr>
                <td style="border: 0px; border-style: none; background-color: #009999;">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <table width="100%" style="background-color: #AFEEEE; font-family: Quark; font-size: medium;">
                                    <tr>
                                        <td colspan="2" style="color: #006666; text-align: left; vertical-align: top; font-size: 12pt;">
                                            <uc2:ctlConfigSchedule ID="ctlDriveConfig" runat="server" />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnAddDrive" CssClass="myButton" runat="server" Text="Add" />
                                                        <asp:HiddenField id="hidDriveDetailSeq" runat="server"/>
                                                        <asp:Panel ID="pnlPopDrive" runat="server" Width="700px">
                                                            <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#AFEEEE"
                                                                style="border-color: black;" runat="server">
                                                                <tr class="popHead">
                                                                    <td align="left" colspan="2" style="color: #FFFFFF; font-weight: bold; background-color: #009999; border-top-left-radius: 10px; border-top-right-radius: 10px;">
                                                                        <asp:Label ID="lblHeader" runat="server" Text="Add Drive"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
                                                                            <tr>
                                                                                <td colspan="2">&nbsp</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="22%" align="right">Drive Letter :&nbsp;
                                                                                    <asp:Label ID="Label13" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                </td>
                                                                                <td width="78%" align="left" style="padding-left:5px">
                                                                                    <asp:TextBox ID="txtDriveLetter" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="1"></asp:TextBox>
                                                                                </td>
                                                                            </tr>

                                                                        </table>
                                                                        <uc1:ctlConfigSeverity ID="ctlConfigSeverityDrive" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="height:30px">
                                                                        <asp:Label ID="lblErrorDrive" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td align="center">
                                                                        <asp:Button ID="btnSaveAddDrive" CssClass="myButton" runat="server" Text="Save" />
                                                                        <asp:Button ID="btnCancelAddDrive" CssClass="myButton" runat="server" Text="Cancel" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Button ID="btnTmpAddDrive" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
                                                        <cc1:ModalPopupExtender ID="popAddDrive" runat="server" PopupControlID="pnlPopDrive" TargetControlID="btnTmpAddDrive"
                                                            BackgroundCssClass="modalBackground" DropShadow="true">
                                                        </cc1:ModalPopupExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvDriveDetail" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Data"
                                                            BorderWidth="0" GridLines="None" Width="970px"  Font-Size="10pt" AllowSorting="True" AlternatingRowStyle-BackColor="#ECE5E5">
                                                            <AlternatingRowStyle BackColor="#ECE5E5"  />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblseq" runat="server" Text='<%# bind("seq") %>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Drive Letter" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDriveLetter" runat="server" Text='<%# Bind("DriveLetter")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Value(%)" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <table class="auto-style14">
                                                                            <tr>
                                                                                <td style="text-align:center">Minor</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:center">Value(%)</td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMinorValue" runat="server" Text='<%# Bind("AlarmMinorValue")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Repeat Check" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <table class="auto-style14">
                                                                            <tr>
                                                                                <td style="text-align:center">Minor</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:center">Repeat Check</td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMinorRepeatCheck" runat="server" Text='<%# Bind("RepeatCheckMinor")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Value(%)" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <table class="auto-style14">
                                                                            <tr>
                                                                                <td style="text-align:center">Major</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:center">Value(%)</td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMajorValue" runat="server" Text='<%# Bind("AlarmMajorValue")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Repeat Check" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <table class="auto-style14">
                                                                            <tr>
                                                                                <td style="text-align:center">Major</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:center">Repeat Check</td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMajorRepeatCheck" runat="server" Text='<%# Bind("RepeatCheckMajor")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Value(%)" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <table class="auto-style14">
                                                                            <tr>
                                                                                <td style="text-align:center">Critical</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:center">Value(%)</td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCriticalValue" runat="server" Text='<%# Bind("AlarmCriticalValue")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Repeat Check" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <table class="auto-style14">
                                                                            <tr >
                                                                                <td style="text-align:center">Critical</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:center">Repeat Check</td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCriticalRepeatCheck" runat="server" Text='<%# Bind("RepeatCheckCritical")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        Manage
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgEditDrive" runat="server" OnClick="imgEditDrive_Click" ImageUrl="~/images/ico_edit.jpg"
                                                                            ToolTip="Edit" CommandArgument='<%# Bind("seq")%>'></asp:ImageButton>
                                                                        <asp:ImageButton ID="imgDeleteDrive" runat="server" OnClick="imgDeleteDrive_Click" ImageUrl="~/images/ico_delete.jpg"
                                                                            ToolTip="Delete" CommandArgument='<%# Bind("seq")%>' OnClientClick="return confirm('Are you sure?');"></asp:ImageButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                                                                </asp:TemplateField>
                                                            </Columns>

                                                            <HeaderStyle BackColor="#009999" ForeColor="#ffffff"></HeaderStyle>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>

                                        </td>
                                    </tr>

                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>

            </tr>

        </table>
    </div>


    <div id="divservice">
        <table width="66%">
            <tr>
                <td style="border: 0px; border-style: none; border-color: red; background-color: #009999; height: 30px; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium; border-top-left-radius: 10px; border-top-right-radius: 10px;">&nbsp;Service Configuration
                </td>
            </tr>
            <tr>
                <td style="border: 0px; border-style: none; background-color: #009999;">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <table width="100%" style="background-color: #AFEEEE; font-family: Quark; font-size: medium;">
                                    <tr>
                                        <td colspan="2" style="color: #006666; text-align: left; vertical-align: top; font-size: 12pt;">
                                            <uc2:ctlConfigSchedule ID="CtlServiceConfig" runat="server" />
                                            <table>

                                                <tr>
                                                    <td>
                                                        <script type="text/javascript">
                                                            function SelectAllService(CheckBoxControl) {
                                                                if (CheckBoxControl.checked == true) {
                                                                    var i;
                                                                    for (i = 0; i < document.forms[0].elements.length; i++) {
                                                                        if ((document.forms[0].elements[i].type == 'checkbox') &&
                                                                        (document.forms[0].elements[i].name.indexOf('gvService') > -1)) {
                                                                            if (document.forms[0].elements[i].disabled) {
                                                                                document.forms[0].elements[i].checked = false;
                                                                            }
                                                                            else {
                                                                                document.forms[0].elements[i].checked = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else {
                                                                    var i;
                                                                    for (i = 0; i < document.forms[0].elements.length; i++) {
                                                                        if ((document.forms[0].elements[i].type == 'checkbox') &&
                                                                        (document.forms[0].elements[i].name.indexOf('gvService') > -1)) {
                                                                            document.forms[0].elements[i].checked = false;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        </script>
                                                        <asp:GridView ID="gvService" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Data"
                                                            BorderWidth="0" GridLines="None" Width="650px" AllowSorting="True" AlternatingRowStyle-BackColor="#ECE5E5" Font-Size="10pt">
                                                            <AlternatingRowStyle BackColor="#ECE5E5" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Select">
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="ckbAll" runat="server" onclick="SelectAllService(this)" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ckbSelect" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle  HorizontalAlign="Center"/>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblseq" runat="server" Text='<%# bind("seq") %>' />
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID")%>' Visible="false" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Service Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblServiceName" runat="server" Text='<%# Bind("WindowServiceName")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Description">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDisplayName" runat="server" Text='<%# Bind("DisplayName")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle BackColor="#009999" ForeColor="#ffffff"></HeaderStyle>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>

                                        </td>
                                    </tr>

                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>

            </tr>

        </table>
    </div>


    <div id="divprocess">
        <table width="66%">
            <tr>
                <td style="border: 0px; border-style: none; border-color: red; background-color: #009999; height: 30px; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium; border-top-left-radius: 10px; border-top-right-radius: 10px;">&nbsp;
                    Process Configuration
                </td>
            </tr>
            <tr>
                <td style="border: 0px; border-style: none; background-color: #009999;">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <table width="100%" style="background-color: #AFEEEE; font-family: Quark; font-size: medium;">
                                    <tr>
                                        <td colspan="2" style="color: #006666; text-align: left; vertical-align: top; font-size: 12pt;">
                                            <uc2:ctlConfigSchedule ID="CtlProcessConfig" runat="server" />
                                            <table>

                                                <tr>
                                                    <td>
                                                        <script type="text/javascript">
                                                            function SelectAllProcess(CheckBoxControl) {
                                                                if (CheckBoxControl.checked == true) {
                                                                    var i;
                                                                    for (i = 0; i < document.forms[0].elements.length; i++) {
                                                                        if ((document.forms[0].elements[i].type == 'checkbox') &&
                                                                        (document.forms[0].elements[i].name.indexOf('gvProcess') > -1)) {
                                                                            if (document.forms[0].elements[i].disabled) {
                                                                                document.forms[0].elements[i].checked = false;
                                                                            }
                                                                            else {
                                                                                document.forms[0].elements[i].checked = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else {
                                                                    var i;
                                                                    for (i = 0; i < document.forms[0].elements.length; i++) {
                                                                        if ((document.forms[0].elements[i].type == 'checkbox') &&
                                                                        (document.forms[0].elements[i].name.indexOf('gvProcess') > -1)) {
                                                                            document.forms[0].elements[i].checked = false;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        </script>
                                                        <asp:GridView ID="gvProcess" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Data"
                                                            BorderWidth="0" GridLines="None" Width="650px" AllowSorting="True" AlternatingRowStyle-BackColor="#ECE5E5" Font-Size="10pt">
                                                            <AlternatingRowStyle BackColor="#ECE5E5" />
                                                            <Columns>
                                                                 <asp:TemplateField HeaderText="Select">
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="ckbAll" runat="server" onclick="SelectAllProcess(this)" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ckbSelect" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle  HorizontalAlign="Center"/>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblseq" runat="server" Text='<%# bind("seq") %>' />
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID")%>' Visible="false" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Process Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblProcessName" runat="server" Text='<%# Bind("WindowProcessName")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Description">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDisplayName" runat="server" Text='<%# Bind("DisplayName")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle BackColor="#009999" ForeColor="#ffffff"></HeaderStyle>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>

                                        </td>
                                    </tr>

                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>

            </tr>

        </table>
    </div>


    <div id="divfilesize">
        <table width="66%">
            <tr>
                <td style="border: 0px; border-style: none; border-color: red; background-color: #009999; height: 30px; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium; border-top-left-radius: 10px; border-top-right-radius: 10px;">&nbsp;
                    File Size Configuration
                </td>
            </tr>
            <tr>
                <td style="border: 0px; border-style: none; background-color: #009999;">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <table width="100%" style="background-color: #AFEEEE; font-family: Quark; font-size: medium;">
                                    <tr>
                                        <td colspan="2" style="color: #006666; text-align: left; vertical-align: top; font-size: 12pt;">
                                            <uc2:ctlConfigSchedule ID="CtlFileSizeConfig" runat="server" />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnAddFileSize" CssClass="myButton" runat="server" Text="Add" />

                                                        <asp:Panel ID="pnlPopFileSize" runat="server" Width="700px">
                                                            <table id="Table2" width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#AFEEEE"
                                                                style="border-color: black;" runat="server">
                                                                <tr class="popHead">
                                                                    <td align="left" colspan="2" style="color: #FFFFFF; font-weight: bold; background-color: #009999; border-top-left-radius: 10px; border-top-right-radius: 10px;">
                                                                        <asp:Label ID="Label1" runat="server" Text="Add File Size"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
                                                                            <tr>
                                                                                <td colspan="2">&nbsp</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">File Path :&nbsp;
                                                                                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                </td>
                                                                                <td width="77%" align="left" >
                                                                                    <asp:TextBox ID="txtFilePath" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Width="320px"></asp:TextBox>
                                                                                    <asp:Button ID="btnAddPathFileSize" runat="server" Text="..." />
                                                                                </td>
                                                                            </tr>

                                                                        </table>
                                                                        <uc1:ctlConfigSeverity ID="ctlConfigSeverityFileSize" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="height:30px">
                                                                        <asp:Label ID="lblErrorFileSize" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                                        <asp:HiddenField id="hidFileSizeDetailSeq" runat="server"/>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td align="center">
                                                                        <asp:Button ID="btnSaveFileSize" CssClass="myButton" runat="server" Text="Save" />
                                                                        <asp:Button ID="btnCancelFileSize" CssClass="myButton" runat="server" Text="Cancel" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Button ID="btnTmpSaveFileSize" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
                                                        <cc1:ModalPopupExtender ID="popAddFileSize" runat="server" PopupControlID="pnlPopFileSize" TargetControlID="btnTmpSaveFileSize"
                                                            BackgroundCssClass="modalBackground" DropShadow="true">
                                                        </cc1:ModalPopupExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvFileSize" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Data"
                                                            BorderWidth="0" GridLines="None" Width="970px" Font-Size="10pt" AllowSorting="True" AlternatingRowStyle-BackColor="#ECE5E5">
                                                            <AlternatingRowStyle BackColor="#ECE5E5" />
                                                            <Columns>
                                                               <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblseq" runat="server" Text='<%# bind("seq") %>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Path File" ItemStyle-HorizontalAlign="left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFilePath" runat="server" Text='<%# Bind("filename")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Value(%)" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <table class="auto-style14">
                                                                            <tr>
                                                                                <td style="text-align:center">Minor</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:center">Value(%)</td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMinorValue" runat="server" Text='<%# Bind("FileSizeMinor")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Repeat Check" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <table class="auto-style14">
                                                                            <tr>
                                                                                <td style="text-align:center">Minor</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:center">Repeat Check</td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMinorRepeatCheck" runat="server" Text='<%# Bind("RepeatCheckMinor")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Value(%)" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <table class="auto-style14">
                                                                            <tr>
                                                                                <td style="text-align:center">Major</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:center">Value(%)</td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMajorValue" runat="server" Text='<%# Bind("FileSizeMajor")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Repeat Check" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <table class="auto-style14">
                                                                            <tr>
                                                                                <td style="text-align:center">Major</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:center">Repeat Check</td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMajorRepeatCheck" runat="server" Text='<%# Bind("RepeatCheckMajor")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Value(%)" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <table class="auto-style14">
                                                                            <tr>
                                                                                <td style="text-align:center">Critical</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:center">Value(%)</td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCriticalValue" runat="server" Text='<%# Bind("FileSizeCritical")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Repeat Check" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <table class="auto-style14">
                                                                            <tr >
                                                                                <td style="text-align:center">Critical</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:center">Repeat Check</td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCriticalRepeatCheck" runat="server" Text='<%# Bind("RepeatCheckCritical")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        Manage
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgEditFileSize" runat="server" OnClick="imgEditFileSize_Click" ImageUrl="~/images/ico_edit.jpg"
                                                                            ToolTip="Edit" CommandArgument='<%# Bind("seq")%>'></asp:ImageButton>
                                                                        <asp:ImageButton ID="imgDeleteFileSize" runat="server" OnClick="imgDeleteFileSize_Click" ImageUrl="~/images/ico_delete.jpg"
                                                                            ToolTip="Delete" CommandArgument='<%# Bind("seq")%>' OnClientClick="return confirm('Are you sure?');"></asp:ImageButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                            <HeaderStyle BackColor="#009999" ForeColor="#ffffff"></HeaderStyle>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>

                                        </td>
                                    </tr>

                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>

            </tr>

        </table>
    </div>


    <div id="divport">
        <table width="66%">
            <tr>
                <td style="border: 0px; border-style: none; border-color: red; background-color: #009999; height: 30px; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium; border-top-left-radius: 10px; border-top-right-radius: 10px;">&nbsp;
                    Port Configuration
                </td>
            </tr>
            <tr>
                <td style="border: 0px; border-style: none; background-color: #009999;">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <table width="100%" style="background-color: #AFEEEE; font-family: Quark; font-size: medium;">
                                    <tr>
                                        <td colspan="2" style="color: #006666; text-align: left; vertical-align: top; font-size: 12pt;">
                                            <uc2:ctlConfigSchedule ID="CtlPortConfig" runat="server" />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnAddPort" CssClass="myButton" runat="server" Text="Add" />

                                                        <asp:Panel ID="pnlPopPort" runat="server" Width="700px">
                                                            <table id="Table3" width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#AFEEEE"
                                                                style="border-color: black;" runat="server">
                                                                <tr class="popHead">
                                                                    <td align="left" colspan="2" style="color: #FFFFFF; font-weight: bold; background-color: #009999; border-top-left-radius: 10px; border-top-right-radius: 10px;">
                                                                        <asp:Label ID="Label3" runat="server" Text="Add Port"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
                                                                            <tr>
                                                                                <td colspan="2">&nbsp</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%" align="right" class="auto-style15">Port No :&nbsp;
                                                                                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                </td>
                                                                                <td width="70%" align="left" class="auto-style15">&nbsp;
                                                                                    <asp:TextBox ID="txtPortNo" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%" align="right">Repeat Check :&nbsp;
                                                                                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                </td>
                                                                                <td width="70%" align="left">&nbsp;
                                                                                    <asp:TextBox ID="txtRepeatCheck" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt"></asp:TextBox>
                                                                                </td>
                                                                            </tr>

                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="height:30px">
                                                                        <asp:Label ID="lblErrorPort" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                                        <asp:HiddenField id="hidPortDetailSeq" runat="server"/>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td align="center">
                                                                        <asp:Button ID="btnSavePort" CssClass="myButton" runat="server" Text="Save" />
                                                                        <asp:Button ID="BtnCancelPort" CssClass="myButton" runat="server" Text="Cancel" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Button ID="btnTmpSavePort" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
                                                        <cc1:ModalPopupExtender ID="PopAddPort" runat="server" PopupControlID="pnlPopPort" TargetControlID="btnTmpSavePort"
                                                            BackgroundCssClass="modalBackground" DropShadow="true">
                                                        </cc1:ModalPopupExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvPort" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Data"
                                                            BorderWidth="0" GridLines="None" Width="650px"  Font-Size="10pt" AllowSorting="True" AlternatingRowStyle-BackColor="#ECE5E5">
                                                            <AlternatingRowStyle BackColor="#ECE5E5" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblseq" runat="server" Text='<%# bind("seq") %>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Port No" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPortNo" runat="server" Text='<%# Bind("portnumber")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Repeat Check" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRepeatCheck" runat="server" Text='<%# Bind("repeatcheck")%>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        Manage
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgEditPort" runat="server" OnClick="imgEditPort_Click" ImageUrl="~/images/ico_edit.jpg"
                                                                            ToolTip="Edit" CommandArgument='<%# Bind("seq")%>'></asp:ImageButton>
                                                                        <asp:ImageButton ID="imgDeletePort" runat="server" OnClick="imgDeletePort_Click" ImageUrl="~/images/ico_delete.jpg"
                                                                            ToolTip="Delete" CommandArgument='<%# Bind("seq")%>' OnClientClick="return confirm('Are you sure?');"></asp:ImageButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                            <HeaderStyle BackColor="#009999" ForeColor="#ffffff"></HeaderStyle>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>

                                        </td>
                                    </tr>

                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>

            </tr>

        </table>
    </div>


    <center>
        <br />
        <br />
          <asp:Button ID="btnSaveRegister" CssClass="myButton" runat="server" Text="Save" />
          <asp:Button ID="btnCancelRegister" CssClass="myButton" runat="server" Text="Cancel" />
    </center>

</asp:Content>


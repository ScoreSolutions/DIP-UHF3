<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmLogin.aspx.vb" Inherits="frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--link style sheet of slide--%>
     <link rel="stylesheet" type="text/css" href="css/slideshow.css" media="screen" />
    <style type="text/css">.slideshow a#vlb{display:none}</style>
	<script type="text/javascript" src="Script/mootools.js"></script>
	<script type="text/javascript" src="Script/visualslideshow.js"></script>


     <style type="text/css">
        
        .body{
            background:url('Images/background_login.jpg') no-repeat;
        }
        
        .auto-style1 {
            height: 459px;
        }
        .auto-style2 {
            height: 459px;
            width: 70%;
        }
        .auto-style3 {
            height: 23px;
        }
        
        .auto-style8 {
            height: 101px;
        }
        .auto-style9 {
            height: 183px;
        }
        .auto-style10 {
            height: 111px;
        }
        .auto-style11 {
            height: 80px;
        }
        .tb8 {
	width: 230px;
	border: 1px solid #3366FF;
	border-left: 4px solid #3366FF;
    /*Textbox*/
}
        </style>

    <script type="text/javascript">
        function show() {
            alert("Not Password")
        }

        //Validate textbox Username 

        function isUsernameKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                if (charCode > 31 && (charCode < 65 || charCode > 90))
                    if (charCode > 31 && (charCode < 97 || charCode > 122))
                        if (charCode > 31 && (charCode < 3585 || charCode > 3642) && (charCode < 3648 || charCode > 3660))

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
</script>
</head>
<body class="body">
    <form id="form1" runat="server">
        <div>
    <table>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style3">
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
         <tr>
            <td colspan="2">
            </td>
        </tr>
         <tr>
            <td colspan="2" class="auto-style3">
                &nbsp;&nbsp;</td>
        </tr>
        <tr style="text-align: center">
            <td width="5%"></td>
            <td width="60%" class="auto-style2">
                <div align="center">
                    <table>
                        <tr>
                            <td style="text-align: center; ">
                                <div id="show" class="slideshow" style="text-align: left">
	<div class="slideshow-images">
<a href="#"><img id="slide-1" src="images/slide2.jpg" alt="Untitled-2" title="Untitled-2" style="width: 515px" /></a>
<a href="#"><img id="slide-2" src="images/slide3.jpg" alt="Untitled-3" title="Untitled-3" style="width: 515px; height: 360px" /></a>
<a href="#"><img id="slide-3" src="images/slide4.jpg" alt="Untitled-4" title="Untitled-4" style="width: 515px; height: 360px" /></a>
</div></div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td class="auto-style1" width="20%">
                <div>
                    <table style="background-image: url('images/_login.png'); background-repeat: no-repeat; width: 310px; height: 540px; margin-left: 0px;">
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <br />
                                </td>
                        </tr>

                        <tr>
                            <td class="auto-style11">
                                <table><tr><td></td><td></td><td></td><td></td><td></td><td></td><td><asp:Label ID="Label1" runat="server" Text="Username" Font-Bold="True" Font-Names="Quark" ForeColor="#137D7A" Font-Size="Large"></asp:Label></td></tr></table>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="tb8" Height="25px" Width="249px" Font-Bold="True" Font-Names="quark" Font-Size="12pt" onkeypress="return isUsernameKey(event)" MaxLength="100"  oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center" class="auto-style8">
                                 <table><tr><td></td><td></td><td></td><td></td><td></td><td></td><td><asp:Label ID="Label2" runat="server" Text="Password" Font-Bold="True" Font-Names="Quark" ForeColor="#137D7A" Font-Size="Large"></asp:Label></td></tr></table>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="tb8" Height="25px" Width="250px" Font-Bold="True" Font-Names="quark" Font-Size="12pt" TextMode="Password" MaxLength="30" OnKeypress="return isPasswordKey(event)"  oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style10">

                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/btn_login.jpg"/>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblUsername" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td width="10%"></td>
        </tr>
         <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
    </div>
    
    </form>
</body>
</html>

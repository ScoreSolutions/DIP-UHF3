﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>โครงการพัฒนาระบบการยืม-คืน และรักษาความปลอดภัย แฟ้มคำขอรับสิทธิบัตร/อนุสิทธิบัตร</title>

    <meta name="description" content="User login page" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!--basic styles-->

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!--page specific plugin styles-->

    <!--fonts-->

    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />

    <!--ace styles-->

    <link rel="stylesheet" href="assets/css/ace.min.css" />
    <link rel="stylesheet" href="assets/css/ace-responsive.min.css" />
    <link rel="stylesheet" href="assets/css/ace-skins.min.css" />

    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

    <!--inline styles related to this page-->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        .classname {
            background: #428eb8;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            box-shadow: 5px 5px 5px #888888;
        }

        .text {
            color: #FFF;
        }

        .fixed-nav-bar-bottom {
            position: fixed;
            bottom: 0;
            left: 0;
            z-index: 9999;
            width: 100%;
            height: 27px;
            background-color: #2283c5;
        }

        .fixed-nav-bar-top {
            position: fixed;
            top: 0;
            left: 0;
            z-index: 9999;
            width: 100%;
            height: 122px;
            background-color: #2283c5;
        }

        .fixed-nav-bar-center {
            position: fixed;
            top: 50%;
            left: 50%;
            width: 30em;
            height: 18em;
            margin-top: -9em; /*set to a negative number 1/2 of your height*/
            margin-left: -15em; /*set to a negative number 1/2 of your width*/
        }
    </style>
</head>
<body class="login-layout">
    <div class="fixed-nav-bar-top" align="right">

        <img src="images/header.jpg" height="122" />
        <%--<span id="divbottomtxt" style="font-size:27px;"></span>--%>
    </div>

    <div class="fixed-nav-bar-center">
        <div class="main-container container-fluid">
            <div class="main-content">
<%--                <div class="row-fluid">
                    <center>
    <h4>
   
	<span class="red">กรุณากรอกชื่อผู้ใช้และรหัสผ่าน เพื่อเข้าใช้งานระบบ</span>
    </h4>
    </center>
                </div>--%>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="login-container">
                            <%--           <div class="row-fluid">
                            <div class="center">
                                <h1>
                                    <%--<i class="icon-cloud green "></i>
										<span class="red">โครงการพัฒนาระบบการยืม-คืน และรักษาความปลอดภัย แฟ้มคำขอรับสิทธิบัตร/อนุสิทธิบัตร</span>
                                </h1>
                                <h4 class="blue">กรุณากรอกชื่อผู้ใช้และรหัสผ่าน เพื่อเข้าใช้งานระบบ</h4>
                            </div>

                        </div>--%>
                            <div class="space-6"></div>
                            <div class="row-fluid">
                                <div class="position-relative">
                                    <div id="login-box" class="login-box visible widget-box no-border">
                                        <div class="widget-body">
                                            <div class="widget-main">

                                                <h4 class="header blue lighter bigger">
                                                    <i class=" icon-signin"></i>
                                                  กรุณากรอกชื่อผู้ใช้และรหัสผ่าน
                                                </h4>

                                                <div class="space-6"></div>


                                                <form runat="server">
                                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <fieldset>
                                                                <label>
                                                                    <span class="block input-icon input-icon-right">
                                                                        <input type="text" class="span12" placeholder="ผู้ใช้" runat="server" id="txtUsername" />
                                                                        <i class="icon-user"></i>
                                                                    </span>
                                                                </label>

                                                                <label>
                                                                    <span class="block input-icon input-icon-right">
                                                                        <input type="password" class="span12" placeholder="รหัสผ่าน" runat="server" id="txtPassword" />
                                                                        <i class="icon-lock"></i>
                                                                    </span>
                                                                </label>

                                                                <div class="space"></div>

                                                                <div class="clearfix">
                                                                    <center>
                                                               <%--     <img src="images/login_btn.png" width="321" height="41" />--%>
                                                                    <button class="width-100 btn btn-small btn-success" style="font-size:larger"   id="btnLogin"  runat="server" onserverclick="Login_Click">
                                                                        <i class="icon-key"></i>
                                                                        เข้าสู่ระบบ
                                                                    </button>
                                                                    </center>
                                                                </div>

                                                                <div class="space-4"></div>
                                                                <div class="center">

                                                                    <span class="color red" runat="server" id="lblshowvalid"></span>

                                                                </div>
                                                            </fieldset>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </form>

                                                <%--       <div class="social-or-login center">
                                                <span class="bigger-110"></span>
                                            </div>--%>

                                                <%--<div class="social-login center">
													<a class="btn btn-primary">
														<i class="icon-facebook"></i>
													</a>

													<a class="btn btn-info">
														<i class="icon-twitter"></i>
													</a>

													<a class="btn btn-danger">
														<i class="icon-google-plus"></i>
													</a>
												</div>--%>
                                            </div>
                                            <!--/widget-main-->

                                            <div class="toolbar clearfix">

                                                <div class="center">
                                                    &nbsp;
											<%--		<a href="#" onclick="show_box('forgot-box'); return false;" class="forgot-password-link">
														<i class="icon-arrow-left"></i>
														I forgot my password
													</a>--%>
                                                </div>

                                                <div style="display: none">
                                                    <a href="#" onclick="show_box('signup-box'); return false;" class="user-signup-link">I want to register
														<i class="icon-arrow-right"></i>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <!--/widget-body-->
                                    </div>
                                    <!--/login-box-->

                                    <div id="forgot-box" class="forgot-box widget-box no-border">
                                        <div class="widget-body">
                                            <div class="widget-main">
                                                <h4 class="header red lighter bigger">
                                                    <i class="icon-key"></i>
                                                    Retrieve Password
                                                </h4>

                                                <div class="space-6"></div>
                                                <p>
                                                    Enter your email and to receive instructions
                                                </p>

                                                <form>
                                                    <fieldset>
                                                        <label>
                                                            <span class="block input-icon input-icon-right">
                                                                <input type="email" class="span12" placeholder="Email" />
                                                                <i class="icon-envelope"></i>
                                                            </span>
                                                        </label>

                                                        <div class="clearfix">
                                                            <button onclick="return false;" class="width-35 pull-right btn btn-small btn-danger">
                                                                <i class="icon-lightbulb"></i>
                                                                Send Me!
                                                            </button>
                                                        </div>
                                                    </fieldset>
                                                </form>
                                            </div>
                                            <!--/widget-main-->

                                            <div class="toolbar center">
                                                <a href="#" onclick="show_box('login-box'); return false;" class="back-to-login-link">Back to login
													<i class="icon-arrow-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!--/widget-body-->
                                    </div>
                                    <!--/forgot-box-->

                                    <div id="signup-box" class="signup-box widget-box no-border">
                                        <div class="widget-body">
                                            <div class="widget-main">
                                                <h4 class="header green lighter bigger">
                                                    <i class="icon-group blue"></i>
                                                    New User Registration
                                                </h4>

                                                <div class="space-6"></div>
                                                <p>Enter your details to begin: </p>

                                                <form>
                                                    <fieldset>
                                                        <label>
                                                            <span class="block input-icon input-icon-right">
                                                                <input type="email" class="span12" placeholder="Email" />
                                                                <i class="icon-envelope"></i>
                                                            </span>
                                                        </label>

                                                        <label>
                                                            <span class="block input-icon input-icon-right">
                                                                <input type="text" class="span12" placeholder="Username" />
                                                                <i class="icon-user"></i>
                                                            </span>
                                                        </label>

                                                        <label>
                                                            <span class="block input-icon input-icon-right">
                                                                <input type="password" class="span12" placeholder="Password" />
                                                                <i class="icon-lock"></i>
                                                            </span>
                                                        </label>

                                                        <label>
                                                            <span class="block input-icon input-icon-right">
                                                                <input type="password" class="span12" placeholder="Repeat password" />
                                                                <i class="icon-retweet"></i>
                                                            </span>
                                                        </label>

                                                        <label>
                                                            <input type="checkbox" />
                                                            <span class="lbl">I accept the
																<a href="#">User Agreement</a>
                                                            </span>
                                                        </label>

                                                        <div class="space-24"></div>

                                                        <div class="clearfix">
                                                            <button type="reset" class="width-30 pull-left btn btn-small">
                                                                <i class="icon-refresh"></i>
                                                                Reset
                                                            </button>

                                                            <button onclick="return false;" class="width-65 pull-right btn btn-small btn-success">
                                                                Register
																<i class="icon-arrow-right icon-on-right"></i>
                                                            </button>
                                                        </div>
                                                    </fieldset>
                                                </form>
                                            </div>

                                            <div class="toolbar center">
                                                <a href="#" onclick="show_box('login-box'); return false;" class="back-to-login-link">
                                                    <i class="icon-arrow-left"></i>
                                                    Back to login
                                                </a>
                                            </div>
                                        </div>
                                        <!--/widget-body-->
                                    </div>
                                    <!--/signup-box-->
                                </div>
                                <!--/position-relative-->
                            </div>
                        </div>
                    </div>
                    <!--/.span-->
                </div>
                <!--/.row-fluid-->
            </div>
        </div>
    </div>

    <div class="fixed-nav-bar-bottom" align="right">
        <img src="images/footer.jpg" width="208" height="27" />
        <%--<span id="divbottomtxt" style="font-size:27px;"></span>--%>
    </div>
    <!--/.main-container-->

    <!--basic scripts-->

    <!--[if !IE]>-->

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>

    <!--<![endif]-->

    <!--[if IE]>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
<![endif]-->

    <!--[if !IE]>-->

    <script type="text/javascript">
        window.jQuery || document.write("<script src='assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>

    <!--<![endif]-->

    <!--[if IE]>
<script type="text/javascript">
 window.jQuery || document.write("<script src='assets/js/jquery-1.10.2.min.js'>"+"<"+"/script>");
</script>
<![endif]-->

    <script type="text/javascript">
        if ("ontouchend" in document) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
    </script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!--page specific plugin scripts-->

    <!--ace scripts-->

    <script src="assets/js/ace-elements.min.js"></script>
    <script src="assets/js/ace.min.js"></script>

    <!--inline scripts related to this page-->

    <script type="text/javascript">
        function show_box(id) {
            $('.widget-box.visible').removeClass('visible');
            $('#' + id).addClass('visible');
        }
    </script>
</body>
</html>

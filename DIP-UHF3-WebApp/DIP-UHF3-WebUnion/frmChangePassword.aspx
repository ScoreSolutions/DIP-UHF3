<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage2.master" AutoEventWireup="false" CodeFile="frmChangePassword.aspx.vb" Inherits="frmChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main-content">
        <div class="breadcrumbs" id="breadcrumbs">
            <ul class="breadcrumb">
                <li>
                    <i class="icon-home home-icon"></i>
                    <a href="frmPortal.aspx">Home</a>

                    <span class="divider">
                        <i class="icon-angle-right arrow-icon"></i>
                    </span>
                </li>
                <li class="active">Change Password</li>
            </ul>

        </div>

        <div class="page-content">
             <h3 class="header smaller lighter blue">Change Password</h3>
             
        <div class="row-fluid">
            <div class="span2">
                <label class="control-label" id="lblCurrentPassword">Current Password</label>
            </div>
            <div class="span10">
                <input type="password" id="txtCurrentPassword" class="limited" data-maxlength="50" maxlength="50" >
                <span class="help-inline color red" id="lblvalidCurrentPassword" style="display: none">This field is required</span>
            </div>
        </div>

        <div class="row-fluid">
            <div class="span2">
                <label class="control-label" id="lblNewPassword">New Password</label>
            </div>
            <div class="span10">
                <input type="password" id="txtPassword" class="limited" data-maxlength="50" maxlength="50" >
                <span class="help-inline color red" id="lblvalidNewPassword" style="display: none">This field is required</span>

            </div>
        </div>

        <div class="row-fluid">
            <div class="span2">
                <label class="control-label" id="lblConfirmPassword">Confirm Password</label>
            </div>
            <div class="span10">
                <input type="password" id="txtConfirmPassword" class="limited" data-maxlength="50" maxlength="50" >
                <span class="help-inline color red" id="lblvalidConfrimPassword" style="display: none">This field is required</span>
                <span class="help-inline color red" id="lblvalidComprePassword" style="display: none">Password and Confirm Password does not match</span>

            </div>
        </div>


        <div class="row-fluid">
                            <div class="span2">
                            </div>
                            <div class="span10">
                                <button class="btn btn-primary" id="btnSave" name="btnSave">
                                    <i class="icon-edit  bigger-110"></i>
                                    Save
                       
                                </button>
                                <button class="btn" type="reset" id="btnClear" name="btnClear">
                                    <i class="icon-undo bigger-110"></i>
                                    Clear
                                </button>
                            </div>
                        </div>
        </div>
        </div>
  
     <script type="text/javascript">
         $(document).ready(function () {
             clearInput();

             $("#btnSave").click(function () {
                 var ret = onValid();
                 if (ret == true) {
                     onSave();
                 }

             });
             $("#btnClear").click(function () {
                 clearInput();
             });
         });

         //Hide Valid
         function onValidHide() {
             $("#lblvalidCurrentPassword").hide();
             $("#lblvalidNewPassword").hide();
             $("#lblvalidConfrimPassword").hide();
             $("#lblvalidComprePassword").hide();
         }

         function onValid() {

             var isValid;
             isValid = true;
             var CurrentPassword = $("#txtCurrentPassword").val();
             var password = $("#txtPassword").val();
             var passwordconfirm = $("#txtConfirmPassword").val();

             if (CurrentPassword == '') {
                 $("#lblvalidCurrentPassword").show();
                 isValid = false;
             } else {
                 $("#lblvalidCurrentPassword").hide();
             }

             if (password == '') {
                 $("#lblvalidNewPassword").show();
                 isValid = false;
             } else {
                 $("#lblvalidNewPassword").hide();
             }

             if (password != passwordconfirm) {
                 $("#lblvalidComprePassword").show();
                 isValid = false;
             } else {
                 $("#lblvalidComprePassword").hide();
             }

             return isValid;
         }


         function clearInput() {
             $("#txtCurrentPassword").val("");
             $("#txtPassword").val("");
             $("#txtConfirmPassword").val("");
             onValidHide();
         }


         function onSave() {
             var id = $("#HiddenId").val();
             var login_userid = $('#' + '<%=Master.FindControl("lblUserID").ClientID%>').text();
             var login_username = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();
             var current_password = $("#txtCurrentPassword").val();
             var password = $("#txtPassword").val();

             var param = "{'login_userid':" + JSON.stringify(login_userid)
                 + ",'current_password':" + JSON.stringify(current_password)
                 + ",'password':" + JSON.stringify(password)
                 + ",'login_username':" + JSON.stringify(login_username) + "}";

             $.ajax({
                 type: "POST",
                 url: "WebService/WebService.asmx/ChangePassword",
                 data: param,
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: onUserSuccess,
                 error: onFailed
             });
         }

         function onUserSuccess(result) {
             if (result.d == "YES") {
                 onAlert2("Save Complete");
                 //clearInput();
                
             } else {
                
                 if (result.d == "INCORRECTPASSWORD") {
                     onAlert("Invalid Current Password.");
                 }
                 else {

                     onAlert("Save Fail");
                 }

             }

         }

         //Alert Save when false
         function onFailed() {
             onAlert("Save Fail");
         }

         function onAlert(msg) {

             var div = $("<div>" + msg + "</div>");
             div.dialog({
                 title: "Message",
                 modal: true,
                 buttons: [

                             {
                                 text: "Ok",
                                 click: function () {
                                     div.dialog("close");
                                 }
                             }
                 ]
             });

         }

         function onAlert2(msg) {

             var div = $("<div>" + msg + "</div>");
             div.dialog({
                 title: "Message",
                 modal: true,
                 buttons: [

                             {
                                 text: "Ok",
                                 click: function () {
                                     //div.dialog("close");
                                     window.location.href = 'Login.aspx';
                                 }
                             }
                 ]
             });

         }
     </script>

</asp:Content>


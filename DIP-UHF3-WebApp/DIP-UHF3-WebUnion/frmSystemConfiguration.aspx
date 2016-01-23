<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage2.master" AutoEventWireup="false" CodeFile="frmSystemConfiguration.aspx.vb" Inherits="frmSystemConfiguration" %>

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
                <li class="active">System Configuration</li>
            </ul>
            <!--#nav-search-->
        </div>

        <div class="page-content">
            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">System Configuration</h3>

                    <div class="row-fluid">
                        <div class="span12">
                            <b>Mail Configuration</b>
                        </div>
                    </div>
                </div>
                <div class="span12">
                    <div class="span2" >
                        <label class="control-label" id="lblMailSMTPServer">SMTP Server</label>
                    </div>
                    <div class="span10">
                        <input type="text" class="input-mini" id="txtMailSMTPServer" style="width:430px;" maxlength="255" />
                    </div>
                </div>
                <div class="span12">
                    <div class="span2">
                        <label class="control-label" id="lblMailPort">Port</label>
                    </div>
                    <div class="span10">
                        <input type="text" class="input-mini" id="txtMailPort" style="width:430px;" maxlength="255"/>
                    </div>
                </div>
                <div class="span12">
                    <div class="span2" >
                        <label class="control-label" id="lblMailEnableSSL">Enable SSL</label>
                    </div>
                    <div class="span10" >
                        <input type="checkbox" id="chkMailEnableSSL" checked="checked" />
                    </div>
                </div>
                <div class="span12">
                    <div class="span2">
                        <label class="control-label" id="lblMailSenderAccount">Sender Account</label>
                    </div>
                    <div class="span10">
                        <input type="text" id="txtMailSenderAccount" style="width: 430px" >
                    </div>
                </div>
                <div class="span12">
                    <div class="span2">
                        <label class="control-label" id="lblMailPassword">Password</label>
                    </div>
                    <div class="span10">
                         <input type="password" id="txtMailPassword" style="width: 150px" maxlength="50" >
                    </div>
                </div>
                <div class="span12">
                    <div class="span2">
                        <label class="control-label" id="lblMailConfirmPassword">Confirm Password</label>
                    </div>
                    <div class="span10">
                         <input type="password" id="txtMailConfirmPassword" style="width: 150px" maxlength="50"   >
                    </div>
                </div>
                <div class="span12">
                    <div class="span2">
                    </div>
                    <div class="span10"  >
                        <button class="btn btn-primary btn-mini" id="btnSaveMailConfig" name="btnSave">
                            <i class="icon-edit bigger-110"></i>
                            Save
                        </button>
                    </div>
                </div>
            </div>
            <div class="row-fluid">
                <span class="help-inline color red" id="lblvalid_MailSMTPServer" style="display: none">SMTP is required</span>
                <span class="help-inline color red" id="lblvalid_MailPort" style="display: none">Port is required</span>
                <span class="help-inline color red" id="lblvalid_MailSenderAccount" style="display: none">Sender Account is required</span>
                <span class="help-inline color red" id="lblvalid_MailPassword" style="display: none">Password is required</span>
                <span class="help-inline color red" id="lblvalid_MailConfirmPassword" style="display: none">Password != Confirm Password</span>
        </div>

            <div class="row-fluid">
                <div class="span12">
                    <div class="row-fluid">
                        <div class="span12">
                            <b>Borrow Notification</b>
                        </div>
                    </div>
                </div>
                <div class="span12">
                    <table class="table table-striped table-bordered table-hover" id="dt_out"></table>
                </div>
            </div>

            <div class="row-fluid">
                <div class="span12">
                    <div class="span2">
                    </div>
                    <div class="span10"  >
                        <button class="btn btn-primary btn-mini" id="btnSaveBorrowNotit" name="btnSave">
                            <i class="icon-edit bigger-110"></i>
                            Save
                        </button>
                    </div>
                </div>
            </div>
            <!--/.span-->
        </div>
        <!--/.row-fluid-->
        <!--/.page-content-->
        <!--/#ace-settings-container-->
    </div>

    <div id="dialog-edit" >
        <div class="row-fluid" >
            <div class="span12">
                <div class="span4">
                    <label class="control-label" id="lblPatentType">Patent Type</label>
                    <input id="popPatentTypeId" type="text" />
                </div>
                <div class="span8">
                    <input type="text" class="input-mini" id="txtPatentTypeName" style="width: 150px;background-color:gray;" onkeypress="txtKeyPress(event);" onkeydown="CheckKeyBackSpace(event);"  />
                    <span class="help-inline color red" id="lblvalidPatentTypeName" style="display: none">This field is required</span>
                </div>
            </div>
        </div>
        <div class="row-fluid" >
            <div class="span12">
                <div class="span4">
                    <label class="control-label" id="lblAlertBeforeDuedate">Alert Before Duedate</label>
                </div>
                <div class="span8">
                    <input type="text" class="input-mini" id="txtAlertBorrowBeforeDueDate" style="width:40px;"  maxlength="3"/>
                    Day(s)
                    <span class="help-inline color red" id="lblvalid_AlertBorrowBeforeDueDate" style="display: none">This field is required</span>
                </div>
            </div>
        </div>
         
        <div class="row-fluid">
            <div class="span12">
                <div class="span4">
                    <label class="control-label" id="lblAlertOverDueate">Alert Over Duedate</label>
                </div>
                <div class="span8">
                    <input type="text" class="input-mini" id="txtAlertBorrowOverDueDate" style="width:40px;"  maxlength="3"/>
                    Day(s)
                    <span class="help-inline color red" id="lblvalid_AlertBorrowOverDueDate" style="display: none">This field is required</span>
                </div>
            </div>
        </div>

    </div>

    <script type="text/javascript">
        //Open page
        $(document).ready(function () {
            //Load Data
            LoadData();
            LoadBorrowNotificationData();

            $("#dialog-edit").hide();
        });

        //Save Config
        function onSaveMailConfig() {
            var ret = onValidMailConfig();
            if (ret == true) {
                var txtMailSMTPServer = $('#txtMailSMTPServer').val();
                var txtMailPort = $('#txtMailPort').val();
                var txtMailSenderAccount = $("#txtMailSenderAccount").text();
                var txtMailPassword = $('#txtMailPassword').val();
                var login_username = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();

                var param = "{'UserName':" + JSON.stringify(login_username)
                + ",'ConfigName':'SMTPServer'"
                + ",'ConfigValue':" + JSON.stringify(txtMailSMTPServer) + "}";

                $.ajax({
                    type: "POST",
                    url: "WebService/WebService.asmx/SaveSysconfig",
                    data: param,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: onSuccess,
                    error: onFailed
                });

            }
        }

        function LoadData() {
            var dataurl = 'WebService/WebService.asmx/LoadSysConfig';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    var strvalue = JSON.parse(data.d);
                    $.each(strvalue, function (key, val) {
                        if (val.CONFIG_NAME == "SMTPServer") {
                            $("#txtMailSMTPServer").val(val.CONFIG_VALUE);
                        } else if (val.CONFIG_NAME == "MailPort") {
                            $("#txtMailPort").val(val.CONFIG_VALUE);
                        } else if (val.CONFIG_NAME == "MailSSL") {
                            if (val.CONFIG_VALUE == "False") {
                                $("#chkMailEnableSSL").prop("checked", false);
                            } else {
                                $("#chkMailEnableSSL").prop("checked", true);
                            }
                        } else if (val.CONFIG_NAME == "SMTPMailFrom") {
                            $("#txtMailSenderAccount").val(val.CONFIG_VALUE);
                        } else if (val.CONFIG_NAME == "SMTPPassword") {
                            $("#txtMailPassword").val(val.CONFIG_VALUE);
                            $("#txtMailConfirmPassword").val(val.CONFIG_VALUE);
                        //} else if (val.CONFIG_NAME == "AlertBorrowBeforeDueDate") {
                        //    $("#txtNotitBeforeDueDate").val(val.CONFIG_VALUE);
                        //} else if (val.CONFIG_NAME == "AlertBorrowOverDueDate") {
                        //    $("#txtNotitOverDueDate").val(val.CONFIG_VALUE);
                        }
                    });
                }
            });
        }

        

        function onValidMailConfig() {
            var isValid;
            isValid = true;
            var txtMailSMTPServer = $('#txtMailSMTPServer').val();
            var txtMailPort = $('#txtMailPort').val();
            var txtMailSenderAccount = $("#txtMailSenderAccount").text();
            var txtMailPassword = $('#txtMailPassword').val();
            var txtMailConfirmPassword = $('#txtMailConfirmPassword').val();

            if (txtMailSMTPServer == '') {
                $("#lblvalid_MailSMTPServer").show();
                isValid = false;
            } else {
                $("#lblvalid_MailSMTPServer").hide();
            }

            if (txtMailPort == '') {
                $("#lblvalid_MailPort").show();
                isValid = false;
            } else {
                $("#lblvalid_MailPort").hide();
            }

            if (txtMailSenderAccount == '') {
                $("#lblvalid_MailSenderAccount").show();
                isValid = false;
            } else {
                $("#lblvalid_MailSenderAccount").hide();
            }

            if (txtMailPassword == '') {
                $("#lblvalid_MailPassword").show();
                isValid = false;
            }
            else {
                $("#lblvalid_MailPassword").hide();
            }

            if (txtMailConfirmPassword != txtMailPassword) {
                $("#lblvalid_MailConfirmPassword").show();
                isValid = false;
            } else {
                $("#lblvalid_MailConfirmPassword").hide();
            }

            return isValid;

        }

        function Numbers(e) {
            var keynum;
            var keychar;
            var numcheck;
            if (window.event) {// IE
                keynum = e.keyCode;
            }
            else if (e.which) {// Netscape/Firefox/Opera
                keynum = e.which;
            }
            if (keynum == 13 || keynum == 8 || typeof (keynum) == "undefined") {
                return true;
            }
            keychar = String.fromCharCode(keynum);
            numcheck = /^[0-9]$/;
            return numcheck.test(keychar);
        }



        //Call
        function LoadBorrowNotificationData() {
            var dataurl = 'WebService/WebService.asmx/LoadBorrowNotificationData';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": PopulateGrid
            });
        }

        function PopulateGrid(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var columns = [{
                "sTitle": "No",
                "sType": "numeric",
                "mDataProp": "no",
                "bSortable": false,
                "bUseRendered": false

            },
                {
                    "sTitle": "Patent Type",
                    "sType": "string",
                    "bSortable": false,
                    "sDefaultContent": "",
                    "mDataProp": "patent_type_name"

                },
                {
                    "sTitle": "Alert Before Duedate",
                    "sType": "string",
                    "bSortable": false,
                    "sDefaultContent": "",
                    "mDataProp": "AlertBorrowBeforeDueDate"
                },
                {
                    "sTitle": "Alert Over Duedate",
                    "sType": "string",
                    "bSortable": false,
                    "sDefaultContent": "",
                    "mDataProp": "AlertBorrowOverDueDate"
                },

                {
                    "sTitle": "Action",
                    "bSortable": false,
                    "fnRender": function (obj) {
                        return '<div class="hidden-phone visible-desktop action-buttons">'
                                + '<a href="#"  class="Green"  title="Edit" onClick="onEdit(' + obj.aData.patent_type_id + '); return false;">'
                                + '<span class="green"><i class="icon-pencil bigger-130"></i></span>'
                                + '</a>'
                                + '</div>'
                                
                        ;
                    },
                    "sDefaultContent": "",
                    "bUseRendered": false
                }
            ];

            oTable = $('#dt_out').dataTable({
                "aaData": jsonobject,
                "bAutoWidth": false,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "50%", "aTargets": [1] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });
        }

        function onEdit(id) {

            var param = "{'patent_type_id':" + JSON.stringify(id) + "}";
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/GetBorrowNotificationByPatentTypeId",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = JSON.parse(data.d);
                    if (strvalue.length == 1) {
                        $("#popPatentTypeId").val(id);
                        $("#txtPatentTypeName").val(strvalue[0].patent_type_name);
                        $("#txtAlertBorrowBeforeDueDate").val(strvalue[0].AlertBorrowBeforeDueDate);
                        $("#txtAlertBorrowOverDueDate").val(strvalue[0].AlertBorrowOverDueDate);
                    }
                    
                }
            });

            $("#dialog-edit").dialog({
                autoOpen: false,
                resizable: false,
                width: "500px",
                modal: true,
                buttons: {
                    "Save": function () {
                        //var checkvalid = onValidTag();
                        //if (checkvalid == true) {
                        //    if (checkid_duplicate_tag($('#txtTagNo').val(), $('#HiddenTag').val()) == false) {
                        //        $('#txtTagNo').focus();
                        //        onAlert("Tag no already exists. Please modify Tag no");
                        //    }
                        //    else {
                        //        onSaveTag(id);
                        //        //onAlert("Add Complete");
                        //        $(this).dialog("close");
                        //    }
                        //}
                    },
                    "Close": function () {
                        $(this).dialog("close");
                    }

                },
                show: {
                    effect: 'fade',
                    duration: 500
                },
                hide: {
                    effect: 'fade',
                    duration: 500
                }
            });

            var titledialog = "Edit";
            //if (id == 0) {
            //    titledialog = "Edit";
            //} else {
            //    titledialog = "Edit Tag";
            //}

            $("#dialog-edit").dialog("option", "title", titledialog).dialog("open");
        }

    </script>
</asp:Content>


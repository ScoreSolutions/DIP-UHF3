<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmRFIDProfile.aspx.vb" Inherits="frmRFIDProfile" %>

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
                <li class="active">RFID Profile</li>
            </ul>
          
            <!--#nav-search-->
        </div>

        <div class="page-content">

 
            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">RFID Profile</h3>

                    <div class="row-fluid">
                        <div class="span12">
                            <button class="btn btn-small btn-success" id="btnAdd" name="btnAdd">
                                <i class="icon-plus"></i>
                                Add New
                            </button>
                        </div>
 
                    </div>
                       <div class="space-2"></div>
                    <div class="row-fluid">
                        <div class="span12">
                            <table class="table table-striped table-bordered table-hover" id="dt_out"></table>
                        </div>
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
                    <label class="control-label" id="lblProfile">Profile</label>
                </div>
                <div class="span8">
                    <input type="text" class="input-mini" id="txtProfile" style="width:300px;"  maxlength="255"/>
                    <span class="help-inline color red" id="lblvalid_Profile" style="display: none">This field is required</span>
                </div>

            </div>
        </div>
         
        <div class="row-fluid">
            <div class="span4">
                <label class="control-label" id="lblActive">Active</label>
            </div>
            <div class="span8">
                <div class="controls">
                    <label class="inline">
                        <input name="ckbActive" type="checkbox" id="ckbActive" />
                        <span >&nbsp;</span>
                    </label>

                </div>
            </div>
        </div>

    </div>


    <script type="text/javascript">
        //Open page
        $(document).ready(function () {

            //Load Data
            var oTable;
            var isAddNew = false;
            LoadData();

            //Add Click
            $("#btnAdd").click(function () {
                onEdit(0); return false;
            });

            $("#dialog-edit").hide();
        });



        //Call
        function LoadData() {
            var dataurl = 'WebService/WebService.asmx/LoadObjectiveAll';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": PopulateGrid
            });
        }

        //Populate Grid
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
                                "sTitle": "Profile",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "objective_name"

                            },
                            {
                                "sTitle": "Active",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "active_status"

                            },

                            {
                                "sTitle": "Action",
                                "bSortable": false,
                                "fnRender": function (obj) {
                                    var IsDelete = obj.aData.IsDelete;
                                    var str = "";
                                    if (IsDelete == "T") {
                                        str = " style='display:none;'"
                                    }
                                    return '<div class="hidden-phone visible-desktop action-buttons">'
                                            + '<a href="#"  class="Green"  title="Edit" onClick="onEdit(' + obj.aData.id + '); return false;">'
                                            + '<span class="green"><i class="icon-pencil bigger-130"></i></span>'
                                            + '</a>'
                                            + '&nbsp;'
                                            + '<a href="#"  class="Red"  title="Delete" onclick="onConfirmDelete(' + obj.aData.id + ');"' + str + '  return false;>'
                                            + '<span class="red"><i class="icon-trash bigger-130"></i></span>'
                                            + '</a>'
                                            + '</div>'
                                            + '<div class="hidden-desktop visible-phone">'
                                            + '			<div class="inline position-relative">'
                                            + '				<button class="btn btn-minier btn-primary dropdown-toggle" data-toggle="dropdown">'
                                            + '					<i class="icon-cog icon-only bigger-110"></i>'
                                            + '				</button>'
                                            + '				<ul class="dropdown-menu dropdown-icon-only dropdown-yellow pull-right dropdown-caret dropdown-close">'
                                            + ''
                                            + '					<li>'
                                            + '						<a href="#"   class="tooltip-success" data-rel="tooltip" title="Edit" onClick="onEdit(' + obj.aData.id + '); return false;">'
                                            + '							<span class="green">'
                                            + '								<i class="icon-edit bigger-120"></i>'
                                            + '							</span>'
                                            + '						</a>'
                                            + '					</li>'
                                            + '					<li>'
                                            + '						<a href="#"  class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDelete(' + obj.aData.id + ');"' + str + '  return false;>'
                                            + '							<span class="red">'
                                            + '								<i class="icon-trash bigger-120"></i>'
                                            + '							</span>'
                                            + '						</a>'
                                            + '					</li>'
                                            + '				</ul>'
                                            + '			</div>'
                                            + '		</div>'


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
                { "sWidth": "50%", "aTargets": [1] },
                { "sWidth": "20%", "aTargets": [2] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });


        }

        //Add or Edit 
        function onEdit(id) {
            onValidHide();
            var param = "{'id':" + JSON.stringify(id) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/GetObjectiveById",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = JSON.parse(data.d);

                    if (strvalue.length == 1) {
                        $("#txtProfile").val(strvalue[0].objective_name);
                        if (strvalue[0].active_status == "Y") {
                            $("#ckbActive").prop("checked", true);
                        } else {
                            $("#ckbActive").prop("checked", false);
                        }
                    } else {
                        $("#txtProfile").val("");
                        $("#ckbActive").prop("checked", true);
                    }
                }
            });



            $("#dialog-edit").dialog({
                autoOpen: false,
                resizable: false,
                width: "600px",
                modal: true,
                buttons: {
                    "Save": function () {
                        var ret = onValid();
                        if (ret == true) {
                            onSave(id);
                        }

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

            var titledialog;
            if (id == 0) {
                titledialog = "Add New";
            } else {
                titledialog = "Edit";
            }

            $("#dialog-edit").dialog("option", "title", titledialog).dialog("open");

        }

        //Save 
        function onSave(id) {
            var login_username = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();
            var objective_name = $('#txtProfile').val();
            var active = $('input[name="ckbActive"]:checked').length;

            var param = "{'id':" + JSON.stringify(id)
                + ",'objective_name':" + JSON.stringify(objective_name)
                + ",'active':" + JSON.stringify(active)
                + ",'login_username':" + JSON.stringify(login_username) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/SaveObjective",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onSuccess,
                error: onFailed
            });
        }

        //Delete 
        function onDelete(id) {
            var param = "{'id':" + JSON.stringify(id) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/DeleteObjective",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onDeleteSuccess,
                error: onDeleteFailed
            });
        }

        //Confirm delete 
        function onConfirmDelete(id) {

            var msg = 'Please confirm the delete';
            var div = $("<div>" + msg + "</div>");
            div.dialog({
                title: "Confirm",
                modal: true,
                buttons: [
                            {
                                text: "Yes",
                                click: function () {
                                    div.dialog("close");
                                    onDelete(id);

                                }
                            },
                            {
                                text: "No",
                                click: function () {
                                    div.dialog("close");
                                }
                            }
                ]
            });



        }

        //Group  Alert  True
        function onSuccess(result) {

            if (result.d == "YES") {
                $("#dialog-edit").dialog('close');
                onAlert("Save Complete");
                LoadData();
            } else {
                if (result.d == "DUPLICATEOBJECTIVENAME") {
                    onAlert("Profile already exists.");
                    LoadData();
                } else {
                    onAlert("Save Fail");
                }

            }

        }

        //Alert Save when false
        function onFailed() {
            onAlert("Save Fail");
        }

        //Alert Delete when true
        function onDeleteSuccess(result) {

            if (result.d == true) {
                onAlert("Delete Complete");
                LoadData();

            } else {
                onAlert("Delete Fail");
            }

        }

        //Alert Delete when false
        function onDeleteFailed() {
            onAlert("Delete Fail");
        }

        // Alert Box
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

        //Hide Valid
        function onValidHide() {
            $("#lblvalid_Profile").hide();
        }

        //Check Valid
        function onValid() {
            var isValid;
            isValid = true;
            var profile = $('#txtProfile').val();
            if (profile == '') {
                $("#lblvalid_Profile").show();
                isValid = false;
            } else {
                $("#lblvalid_Profile").hide();
            }
            return isValid;
        }

        function clearInput() {
            $("txtProfile").val("");
            $("#ckbActive").prop("checked", false);
        }

      
    </script>
</asp:Content>


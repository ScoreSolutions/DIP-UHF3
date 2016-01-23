<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage2.master" AutoEventWireup="false" CodeFile="frmGridLayout.aspx.vb" Inherits="frmGridLayout" %>

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
                <li class="active">Grid Layout</li>
            </ul>
          
            <!--#nav-search-->
        </div>

        <div class="page-content">

 
            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">Grid Layout</h3>

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

        <div class="row-fluid">
            <div class="span12">

                <div class="span4">
                    <label class="control-label" id="lblLayoutName">Layout Name</label>
                </div>
                <div class="span8">
                    <input type="text" class="input-mini" id="txtLayoutName" style="width:200px;" maxlength="255" />
                    <span class="help-inline color red" id="lblvalid_LayoutName" style="display: none">This field is required</span>
                </div>

            </div>
        </div>
        <div class="row-fluid" >
            <div class="span12">

                <div class="span4">
                    <label class="control-label" id="lblVerticalLine">Vertical Line</label>
                </div>
                <div class="span8">
                    <input type="text" class="input-mini" id="txtVerticalLine" style="width:100px;" onkeypress="return Numbers(event)" maxlength="3"/>
                    <span class="help-inline color red" id="lblvalid_VerticalLine" style="display: none">This field is required</span>
                    <span class="help-inline color red" id="lblvalid_VerticalLineminmax" style="display: none">This field must be between 5 and 100</span>
                </div>

            </div>
        </div>
         <div class="row-fluid" >
            <div class="span12">

                <div class="span4">
                    <label class="control-label" id="lblHorizontalLine">Horizontal Line</label>
                </div>
                <div class="span8">
                   <input type="text" class="input-mini" id="txtHorizontalLine" style="width:100px;" onkeypress="return Numbers(event)"  maxlength="3"/>
                   <span class="help-inline color red" id="lblvalid_HorizontalLine" style="display: none">This field is required</span>
                   <span class="help-inline color red" id="lblvalid_HorizontalLineminmax" style="display: none">This field must be between 5 and 100</span>
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
            var dataurl = 'WebService/WebService.asmx/LoadGridLayoutAll';
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
                                "sTitle": "Layout Name",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "layout_name"

                            },
                            {
                                "sTitle": "Vertical Line",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "vertical_line"

                            },
                            {
                                "sTitle": "Horizontal Line",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "horizontal_line"

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

                                    var ret = '<div class="hidden-phone visible-desktop action-buttons">'
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
                                            + '						<a href="#"  class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDelete(' + obj.aData.id + ');"' + str + ' return false;>'
                                            + '							<span class="red">'
                                            + '								<i class="icon-trash bigger-120"></i>'
                                            + '							</span>'
                                            + '						</a>'
                                            + '					</li>'
                                            + '				</ul>'
                                            + '			</div>'
                                            + '		</div>'

                                    //alert(ret);
                                    return ret

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
                { "sWidth": "20%", "aTargets": [1] },
                { "sWidth": "20%", "aTargets": [2] },
                { "sWidth": "20%", "aTargets": [3] },
                { "sWidth": "15%", "aTargets": [4] }
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
                url: "WebService/WebService.asmx/GetGridLayoutById",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = JSON.parse(data.d);

                    if (strvalue.length == 1) {
                        $("#txtLayoutName").val(strvalue[0].layout_name);
                        $("#txtVerticalLine").val(strvalue[0].vertical_line);
                        $("#txtHorizontalLine").val(strvalue[0].horizontal_line);     
                        if (strvalue[0].active_status == "Y") {
                            $("#ckbActive").prop("checked", true);
                        } else {
                            $("#ckbActive").prop("checked", false);
                        }
                    } else {
                        $("#txtLayoutName").val("");
                        $("#txtVerticalLine").val("");
                        $("#txtHorizontalLine").val("");
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
            var layout_name = $('#txtLayoutName').val();
            var vertical_line = $('#txtVerticalLine').val();
            var horizontal_line = $('#txtHorizontalLine').val();
            var active = $('input[name="ckbActive"]:checked').length;

            var param = "{'id':" + JSON.stringify(id)
                + ",'layout_name':" + JSON.stringify(layout_name)
                + ",'vertical_line':" + JSON.stringify(vertical_line)
                + ",'horizontal_line':" + JSON.stringify(horizontal_line)
                + ",'active':" + JSON.stringify(active)
                + ",'login_username':" + JSON.stringify(login_username) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/SaveGridLayout",
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
                url: "WebService/WebService.asmx/DeleteGridLayout",
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
                if (result.d == "DUPLICATE") {
                    onAlert("Grid Layout already exists.");
                    LoadData();

                } else if (result.d == "DUPLICATELAYOUTNAME") {
                    onAlert("Grid Layout Name already exists.");
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
            $("#lblvalid_LayoutName").hide();
            $("#lblvalid_VerticalLine").hide();
            $("#lblvalid_HorizontalLine").hide();


        }

        //Check Valid
        function onValid() {
            var isValid;
            isValid = true;
            var layout_name = $('#txtLayoutName').val();
            var vertical_line = $('#txtVerticalLine').val();
            var horizontal_line = $('#txtHorizontalLine').val();
            if (layout_name == '') {
                $("#lblvalid_LayoutName").show();
                isValid = false;
            } else {
                $("#lblvalid_LayoutName").hide();
            }

            if (vertical_line == '') {
                $("#lblvalid_VerticalLine").show();
                isValid = false;
            } else {
                $("#lblvalid_VerticalLine").hide();

                if ((vertical_line < 5) || ((vertical_line > 100))) {
                    $("#lblvalid_VerticalLineminmax").show();
                    isValid = false;
                } else {
                    $("#lblvalid_VerticalLineminmax").hide();
                }
            }

            if (horizontal_line == '') {
                $("#lblvalid_HorizontalLine").show();
                isValid = false;
            } else {
                $("#lblvalid_HorizontalLine").hide();

                if ((horizontal_line < 5) || (horizontal_line > 100)) {
                    $("#lblvalid_HorizontalLineminmax").show();
                    isValid = false;
                } else {
                    $("#lblvalid_HorizontalLineminmax").hide();
                }
            }
 


            return isValid;

        }

        function clearInput() {
            $("txtLayoutName").val("");
            $("txtVerticalLine").val("");
            $("txtHorizontalLine").val("");
            $("#ckbActive").prop("checked", false);
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
    </script>
</asp:Content>


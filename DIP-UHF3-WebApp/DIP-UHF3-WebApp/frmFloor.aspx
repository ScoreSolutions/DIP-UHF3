<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmFloor.aspx.vb" Inherits="frmFloor" %>

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
                <li class="active">Floor</li>
            </ul>
          
            <!--#nav-search-->
        </div>

        <div class="page-content">

 
            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">Floor</h3>

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
                        <div class="span12" >
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
                    <label class="control-label" id="lblFloorName">Floor Name</label>
                </div>
                <div class="span8">
                    <input type="text" class="input-mini" id="txtFloorName" style="width:200px;"  maxlength="255"/>
                    <span class="help-inline color red" id="lblvalid_FloorName" style="display: none">This field is required</span>
                </div>

            </div>
        </div>
        <div class="row-fluid" >
            <div class="span12">

                <div class="span4">
                    <label class="control-label" id="lblColor">Color</label>
                </div>
                <div class="span8">
                    <div class="control-group">
                        <div class="bootstrap-colorpicker">
                            <input id="colorpicker1" type="text" class="input-mini" style="width:100px"  />
                             <span class="trigger" >X </span>
                        </div>
                    </div>
                    <span class="help-inline color red" id="lblvalid_Color" style="display: none">This field is required</span>
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
            $('#colorpicker1').colorpicker();            $(".trigger").click(function () {
                $('#colorpicker1').colorpicker('setValue', '#FFFFFF').val();
            });           
        });



        //Call
        function LoadData() {
            var dataurl = 'WebService/WebService.asmx/LoadFloorAll';
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
                    "sTitle": "Floor Name",
                    "sType": "string",
                    "sDefaultContent": "",
                    "mDataProp": "floor_name"

                },
                {
                    "sTitle": "Color",
                    "sType": "string",
                    "fnRender": function (obj) {                                 
                        //var str = "background-color:red";                     
                        //return '<div style="width:100%; height:40px; ' + str + '">' + obj.aData.floor_name + '</div>'
                        return '<div style="width:100%; height:40px; background-color:' + obj.aData.color + '"></div>'
                        ;
                       },
                    "sDefaultContent": ""

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
                                + '		</div>';
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
                { "sWidth": "40%", "aTargets": [1] },
                { "sWidth": "10%", "aTargets": [2] },
                { "sWidth": "20%", "aTargets": [3] }
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
                url: "WebService/WebService.asmx/GetFloorById",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = JSON.parse(data.d);

                    if (strvalue.length == 1) {
                        $("#txtFloorName").val(strvalue[0].floor_name);
                        $("#colorpicker1").val(strvalue[0].color);
                        
                        if (strvalue[0].active_status == "Y") {
                            $("#ckbActive").prop("checked", true);
                        } else {
                            $("#ckbActive").prop("checked", false);
                        }
                    } else {
                        $("#txtFloorName").val("");
                        $("#colorpicker1").val("");
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
            var floor_name = $('#txtFloorName').val();
            var active = $('input[name="ckbActive"]:checked').length;
            var color = $('#colorpicker1').val();
         
            var param = "{'id':" + JSON.stringify(id)
                + ",'floor_name':" + JSON.stringify(floor_name)
                + ",'color':" + JSON.stringify(color)
                + ",'active':" + JSON.stringify(active)
                + ",'login_username':" + JSON.stringify(login_username) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/SaveFloor",
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
                url: "WebService/WebService.asmx/DeleteFloor",
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
                if (result.d == "DUPLICATEFLOORNAME") {
                    onAlert("Floor Name already exists.");
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
            $("#lblvalid_FloorName").hide();
        }

        //Check Valid
        function onValid() {
            var isValid;
            isValid = true;
            var floor_name = $('#txtFloorName').val();
            var color = $('#colorpicker1').val();
            if (floor_name == '') {
                $("#lblvalid_FloorName").show();
                isValid = false;
            } else {
                $("#lblvalid_FloorName").hide();
            }
            if (color == '') {
                $("#lblvalid_Color").show();
                isValid = false;
            } else {
                $("#lblvalid_Color").hide();
            }
            return isValid;
        }

        function clearInput() {
            $("txtFloorName").val("");
            $("#ckbActive").prop("checked", false);
            $('#colorpicker1').val("");
        }
    </script>
</asp:Content>


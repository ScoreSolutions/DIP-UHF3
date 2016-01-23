<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmMappingGridDesktop.aspx.vb" Inherits="frmMappingGridDesktop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-content">
        <div class="breadcrumbs" id="breadcrumbs">
            <ul class="breadcrumb">
                <li>
                    <i class="icon-home home-icon"></i>
                    <a href="frmPortal.aspx">Home</a>
                    <span class="divider">
                        <i class="icon-angle-right arrow-icon"></i>
                        <%-- <i class="icon-anchor"></i>--%>
                    </span>
                </li>
                <li class="active">Mapping Grid Desktop</li>
            </ul>

            <!--#nav-search-->
        </div>

        <div class="page-content">
            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">Mapping Grid Desktop</h3>
                    <div class="row-fluid">
                        <div class="span12">
                            <table class="table table-striped table-bordered table-hover" id="dt_out"></table>
                        </div>
                    </div>
                </div>

            </div>

            <div id="dialog-image" style="display: none">
                <img id="imgPopup" src="images/No_image.gif" style="height: 350px; width: 500px;" />
            </div>
            <div class="row-fluid">
            </div>
            <div class="row-fluid">
            </div>
        </div>

    </div>
    <div id="dialog-edit">
        <div class="row-fluid">

            <div class="span3">
                <label class="control-label" id="lblfloor">Floor</label>
            </div>
            <div class="span9">
                <input type="text" class="input-mini" id="txtFloor" style="width: 300px;" maxlength="255" disabled="disabled" />
            </div>

        </div>
        <div class="row-fluid">
            <div class="span3">
                <label class="control-label" id="lblRoom">Room</label>
            </div>
            <div class="span9">
                <input type="text" class="input-mini" id="txtRoom" style="width: 300px;" maxlength="255" disabled="disabled" />
            </div>
        </div>
        <div class="row-fluid">
            <div class="span3">
                <label class="control-label" id="lblFloorPlan">Floor Plan</label>
            </div>
            <div class="span9">
                <select id="cbfloorPlanGrid" data-placeholder="Choose a Floor Plan..." style="width: 300px;">
                </select>
                <span class="help-inline color red" id="lblvalid_floor_plan" style="display: none">This field is required</span>
            </div>
        </div>
        <div class="row-fluid">
            <div class="span3">
                <label class="control-label" id="lblGridLayout">Grid Layout</label>
            </div>
            <div class="span9">
                <select id="cbgridlayout" data-placeholder="Choose a Grid Layout..." style="width: 300px;">
                </select>
                <span class="help-inline color red" id="lblvalid_grid_layout" style="display: none">This field is required</span>
            </div>
        </div>
    </div>
    <div id="dialog-officer">
        <div class="row-fluid">
            <table class="table table-striped table-bordered table-hover" id="dt_officer"></table>
        </div>
    </div>
    <div id="dialog-setgrid">
        <div class="row-fluid">
            <div class="span7">
                <div id="divGridShowBackcolor"></div>
                <div id="divGridShowBackcolorSelect2"></div>
                <div id="divGridShowBackcolorSelect"></div>
                <div id="divGridShow"></div>
                         <input type="text" class="input-mini" id="txtNo" maxlength="255"  style="display:none" />
                        <input type="text" class="input-mini" id="txtRow" maxlength="255"  style="display:none" />
                        <input type="text" class="input-mini" id="txtCol" maxlength="255"  style="display:none" />
                        <input type="text" class="input-mini" id="txtMaxRow" maxlength="255"  style="display:none" />
                        <input type="text" class="input-mini" id="txtMaxCol" maxlength="255"  style="display:none" />
            </div>

            <div class="span5">
                <div class="row-fluid">
                    <div class="span4">
                        <div class="control-label">Grid Layout</div>
                    </div>

                    <div class="span8">
                        <select id="cbofficermapLayout" data-placeholder="Choose a Grid Layout..." style="width: 200px;" >
                        </select>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span4">
                        <div class="control-label">Desktop</div>
                    </div>

                    <div class="span8">
                        <input type="text" class="input-mini" id="txtDesktop" maxlength="255" disabled="disabled" style="width: 300px;" />
                        <input type="text" class="input-mini" id="txtDesktopID" maxlength="255"  style="display:none" />
                        <input type="text" class="input-mini" id="txtRoomID" maxlength="255"  style="display:none" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span4">
                        <div class="control-label">Officer</div>
                    </div>

                    <div class="span8">
                        <input type="text" class="input-mini" id="txtOfficer"  maxlength="255" disabled="disabled" style="width: 300px;"/>
                    </div>
                </div>
                <div class="row-fluid">
                      <div class="span12">
                        <table class="table table-striped table-bordered table-hover" id="dt_mapgridlayout"></table>
                      </div>
                    
                </div>
            </div>
        </div>
    </div>

<%--    <img src="image.jpg" onmouseover="this.style.backgroundColor=Blue;';" onmouseout="if (domouseout) this.style.backgroundColor=Red;;" onclick="domouseout = false;this.style.backgroundColor=Green;" />--%>

    <script type="text/javascript">
        //Open page
        $(document).ready(function () {
            localStorage['gridmapdata']='';
            //Load Data
            var oTable;
            var isAddNew = false;
            LoadData();
            //Add Click
            $("#btnAdd").click(function () {
                onEdit(0); return false;
            });

            $('#cbofficermapLayout').change(function () {
               var desktopid = $("#txtDesktopID").val();
               var roomid = $("#txtRoomID").val();
               var gridlayoutcurrentid = $('#cbofficermapLayout').val();
               LoadDataSetGrid(roomid, gridlayoutcurrentid, desktopid);
            });

            $("#dialog-edit").hide();
            $("#dialog-officer").hide();
            $("#dialog-setgrid").hide();
            // populateSelectFloorPlan(0, 0, 0);

        });



        //Call
        function LoadData() {
            var dataurl = 'WebService/WebService.asmx/LoadMapGridDesktopAll';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": PopulateGrid
            });
        }

        function LoadDataOfficer(roomid) {
            var dataurl = 'WebService/WebService.asmx/LoadOfficerRoomByRoomId';
            var param = "{'roomid':" + JSON.stringify(roomid) + "}";

            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": PopulateGridOfficer
            });
        }

        function LoadDataSetGrid(roomid, gridlayoutcurrentid, desktopid) {

            var param =  "{'roomid':" + JSON.stringify(roomid)
                        + ",'gridlayoutcurrentid':" + JSON.stringify(gridlayoutcurrentid)
                        + ",'desktopid':" + JSON.stringify(desktopid)
                        + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadFloorPlanByRoomId",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
 

                    var jsonobject = JSON.parse(data.d);

                    if (jsonobject.length > 0) {

                        $("#divGridShow").html(jsonobject[0].showdata);

                        var objtemp = JSON.parse(localStorage['gridmapdata']);
                        //var point = getObjects(objtemp, 'id', gridlayoutcurrentid);
                        var point;
                        var countforclear = 0;
                        $.each(objtemp, function (key, val) {
      

                            if (gridlayoutcurrentid == val.ms_grid_layout_id) {
                                point = val.point;
                                if (point != 0) {

                                    //set grid position
                                    $("#divGridShow").find("td#" + val.point).css('background-color', 'rgba(255,255,0,0.5)');
                                    $("#txtNo").val(val.point);
                                    $("#txtRow").val(val.row);
                                    $("#txtCol").val(val.col);
                                    $("#txtMaxRow").val(val.maxrow);
                                    $("#txtMaxCol").val(val.maxcol);
                                    // onSaveGridMap(point[0].point);

                                }
                                //return false;
                            }

                        })
                       

                    } else {

                    }

                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });

        }

        //Search in json object
        function getObjects(obj, key, val) {
            var objects = [];
            for (var i in obj) {
                if (!obj.hasOwnProperty(i)) continue;
                if (typeof obj[i] == 'object') {
                    objects = objects.concat(getObjects(obj[i], key, val));
                } else if (i == key && obj[key] == val) {
                    objects.push(obj);
                }
            }
            return objects;
        }


        function LoadDataOfficerMapGridLayout(gridlayoutid) {
            var dataurl = 'WebService/WebService.asmx/LoadOfficerMapLayoutByLayoutId';
            var param = "{'gridlayoutid':" + JSON.stringify(gridlayoutid) + "}";

            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": PopulateGridOfficerMapGridLayout
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
                                "sTitle": "Floor",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "floor_name"

                            },
                            {
                                "sTitle": "Room",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "room_name"

                            },
                            {
                                "sTitle": "Image",
                                "bSortable": false,
                                "fnRender": function (obj) {
                                    var oj;
                                    if (obj.aData.isshow != 0) {
                                        oj = ' <i class="icon-search" style="cursor:pointer" onclick="onLoadImage(' + obj.aData.image_floor_plan_id + ');"></i>';
                                    } else {
                                        oj = ''
                                    }
                                    //return '<img  style="cursor:pointer" onclick="onLoadImage(' + obj.aData.image_floor_plan_id + ');" src="' + obj.aData.image_floor_plan_show + '" width="100px"/>';
                                    return oj

                                },
                                "sDefaultContent": "",
                                "bUseRendered": false

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

                           

                                    var ret = '<div class="hidden-phone visible-desktop action-buttons">'
                                            + '<button title="Mapping Floor Plan" class="btn btn-small btn-warning" id="btnFloorPlan" name="btnFloorPlan" onClick="onEdit(' + obj.aData.id + '); return false;">'
                                            + '<i class="icon-building"></i>'
                                            + 'Floor Plan'
                                            + '</button>'
                                            + '&nbsp;'
                                            + '<button title="Mapping Officer" class="btn btn-small btn-danger" id="btnOfficer" name="btnOfficer" onclick="onOfficer(' + obj.aData.id + ');return false;">'
                                            + '<i class="icon-user"></i>'
                                            + 'Officer'
                                            + '</button>'
                                            + '</div>'
                                            + '<div class="hidden-desktop visible-phone">'
                                            + '			<div class="inline position-relative">'
                                            + '				<button class="btn btn-minier btn-primary dropdown-toggle" data-toggle="dropdown">'
                                            + '					<i class="icon-cog icon-only bigger-110"></i>'
                                            + '				</button>'
                                            + '				<ul class="dropdown-menu dropdown-icon-only dropdown-yellow pull-right dropdown-caret dropdown-close">'
                                            + ''
                                            + '					<li>'
                                            + '						<a href="#"   class="tooltip-success" data-rel="tooltip" title="Mapping Floor Plan" onClick="onEdit(' + obj.aData.id + '); return false;">'
                                            + '							<span class="orange">'
                                            + '								<i class="icon-building bigger-120"></i>'
                                            + '							</span>'
                                            + '						</a>'
                                            + '					</li>'
                                            + '					<li>'
                                            + '						<a href="#"  class="tooltip-error" data-rel="tooltip" title="Mapping Officer" onclick="onOfficer(' + obj.aData.id + ');"' +  ' return false;>'
                                            + '							<span class="red">'
                                            + '								<i class="icon-user bigger-120"></i>'
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
                { "sWidth": "10%", "aTargets": [1] },
                { "sWidth": "40%", "aTargets": [2] },
                { "sWidth": "10%", "aTargets": [3] },
                { "sWidth": "10%", "aTargets": [4] },
                { "sWidth": "20%", "aTargets": [5] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });


        }

        function PopulateGridOfficer(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var columns = [{
                "sTitle": "No",
                "sType": "numeric",
                "mDataProp": "no",
                "bSortable": false,
                "bUseRendered": false

            },
                            {
                                "sTitle": "Officer",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "fullname"

                            },
                            {
                                "sTitle": "Desktop",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "desk_name"

                            },
                            {
                                "sTitle": "Action",
                                "bSortable": false,
                                "fnRender": function (obj) {
                                    var sdparam = obj.aData.id + ',' + obj.aData.ms_grid_layout_id_current + ',' + SetStringParam(obj.aData.desk_name) + ',' + SetStringParam(obj.aData.fullname) + ',' + obj.aData.ms_room_id;
                                    var ret = '<div class="hidden-phone visible-desktop action-buttons">'
                                            + '<button title="Set Grid" class="btn btn-small btn-danger" id="btnSetGrid" name="btnSetGrid" onclick="onSetGrid(' + sdparam + ')";return false;">'
                                            + '<i class="icon-user"></i>'
                                            + 'Set Grid'
                                            + '</button>'
                                            + '</div>'
                                            + '<div class="hidden-desktop visible-phone">'
                                            + '			<div class="inline position-relative">'
                                            + '				<button class="btn btn-minier btn-primary dropdown-toggle" data-toggle="dropdown">'
                                            + '					<i class="icon-cog icon-only bigger-110"></i>'
                                            + '				</button>'
                                            + '				<ul class="dropdown-menu dropdown-icon-only dropdown-yellow pull-right dropdown-caret dropdown-close">'
                                            + '					<li>'
                                            + '						<a href="#"  class="tooltip-error" data-rel="tooltip" title="Mapping Officer" onclick="onSetGrid(' + sdparam + ');return false;>'
                                            + '							<span class="red">'
                                            + '								<i class="icon-user bigger-120"></i>'
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

            oTable = $('#dt_officer').dataTable({
                "aaData": jsonobject,
                "bAutoWidth": false,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "35%", "aTargets": [1] },
                { "sWidth": "30%", "aTargets": [2] },
                { "sWidth": "25%", "aTargets": [3] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });


        }


        function PopulateGridOfficerMapGridLayout(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var yetVisited = localStorage['gridmapdata'];
            if (yetVisited.length > 0) {

            }
            else {
                localStorage['gridmapdata'] = jsondata.d;
            }

            var columns = [{
                "sTitle": "No",
                "sType": "numeric",
                "mDataProp": "no",
                "bSortable": false,
                "bUseRendered": false

            },
                            {
                                "sTitle": "Grid Layout",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "layout_name"

                            },
                            {
                                "sTitle": "Cell (Row,Col)",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "cell"

                            }
                            //{
                            //    "sTitle": "Desktop",
                            //    "sType": "string",
                            //    "sDefaultContent": "",
                            //    "mDataProp": "desk_name"

                            //},
                            //{
                            //    "sTitle": "Officer",
                            //    "sType": "string",
                            //    "sDefaultContent": "",
                            //    "mDataProp": "fullanme"

                            //}
            ];

            var aaData = getGridMapData();

            oTable = $('#dt_mapgridlayout').dataTable({
                "aaData": aaData,
                "bAutoWidth": false,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "50%", "aTargets": [1] },
                { "sWidth": "40%", "aTargets": [2] }
                //{ "sWidth": "20%", "aTargets": [3] },
                //{ "sWidth": "30%", "aTargets": [4] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });


        }

        function getGridMapData() {
            var jsonobject = JSON.parse(localStorage['gridmapdata']);
            var aaData = [];
            aaData = jsonobject;
            return aaData;
        }
        //Add or Edit 
        function onEdit(id) {
            onValidHide();
            var param = "{'id':" + JSON.stringify(id) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/GetRoomDetailById",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = JSON.parse(data.d);

                    if (strvalue.length == 1) {
                        $("#txtFloor").val(strvalue[0].floor_name);
                        $("#txtRoom").val(strvalue[0].room_name);
                        populateSelectFloorPlan(strvalue[0].ms_floor_plan_id_current, strvalue[0].ms_floor_id, strvalue[0].id);
                        populateSelectGridLayout(strvalue[0].ms_grid_layout_id_current);
                    } else {
                        $("#txtFloor").val("");
                        $("#txtRoom").val("");
                        populateSelectFloorPlan(0, 0, 0);
                        populateSelectGridLayout(0);

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
                },
                open: function (event, ui) {

                    // $(".ui-dialog-titlebar-close").hide(); // Hide the [x] button

                    //$(":button:contains('Save')").focus(); // Set focus to the [Ok] button
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

        function onOfficer(roomid) {
            LoadDataOfficer(roomid);

            $("#dialog-officer").dialog({
                autoOpen: false,
                resizable: false,
                width: "600px",
                modal: true,
                buttons: {
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


            $("#dialog-officer").dialog("option", "title", "Map Officer").dialog("open");

        }

        function onSetGrid(desktopid, gridlayoutcurrentid, desktopname, officername, roomid) {
           // alert(id);
            //alert(ms_grid_layout_id_current);
            //alert(desktopname);
            //alert(officername);
            localStorage['gridmapdata'] = '';
           populateSelectGridLayoutMap(gridlayoutcurrentid);
           $("#txtDesktop").val(desktopname);
           $("#txtOfficer").val(officername);
           $("#txtDesktopID").val(desktopid);
           $("#txtRoomID").val(roomid);
           LoadDataSetGrid(roomid, gridlayoutcurrentid, desktopid);
           LoadDataOfficerMapGridLayout(desktopid);
            $("#dialog-setgrid").dialog({
                autoOpen: false,
                resizable: false,
                modal: true,
                width: "85%",//$(window).width(),
                buttons: {
                    "Save": function () {
                        //onSaveMapGridLayOut();
                        var rows = $("#dt_mapgridlayout").dataTable().fnGetNodes();
                        if (parseInt(rows.length) > 0) {
                            onConfirm();
                        } else {
                            onAlert("Please select grid");
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
                },
                open: function (event, ui) {

                    // $(".ui-dialog-titlebar-close").hide(); // Hide the [x] button

                    //$(":button:contains('Save')").focus(); // Set focus to the [Ok] button
                }
            });


            $("#dialog-setgrid").dialog("option", "title", "Set Grid").dialog("open");
        }

        function onConfirm() {

            var msg = 'Please confirm the save';
            var div = $("<div>" + msg + "</div>");
            div.dialog({
                title: "Confirm",
                modal: true,
                buttons: [
                            {
                                text: "Yes",
                                click: function () {
                                    div.dialog("close");
                                    onSaveMapGridLayOut();
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


        //Save 
        function onSave(id) {
            var userid = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();
            var floorcurrentId = $('#cbfloorPlanGrid').val();
            var gridcurrentId = $('#cbgridlayout').val();

            var param = "{'id':" + JSON.stringify(id)
                + ",'floorcurrentId':" + JSON.stringify(floorcurrentId)
                + ",'gridcurrentId':" + JSON.stringify(gridcurrentId)
                + ",'userid':" + JSON.stringify(userid)
                + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/SaveCurrentInRoom",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onSuccess,
                error: onFailed
            });
        }


        //Group  Alert  True
        function onSuccess(result) {
            if (result.d == true) {
                $("#dialog-edit").dialog('close');
                onAlert("Save Data Complete");
                LoadData();
            } else {
                onAlert("Save Data Fail");
            }

        }
        //Map Desktop
        function onMapSuccess(result) {
            if (result.d == true) {
                $("#dialog-setgrid").dialog('close');
                onAlert("Save Data Complete");
            } else {
                onAlert("Save Data Fail");
            }

        }

        //Alert Save when false
        function onFailed() {
            onAlert("Save Data Fail");
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
            $("#lblvalid_floor_plan").hide();
            $("#lblvalid_grid_layout").hide();
        }

        //Check Valid
        function onValid() {
            var isValid;
            isValid = true;
            var floor_plan_id = $('#cbfloorPlanGrid').val();
            var grid_layout_id = $('#cbgridlayout').val();
            if (floor_plan_id == '') {
                $("#lblvalid_floor_plan").show();
                isValid = false;
            } else {
                $("#lblvalid_floor_plan").hide();
            }

            if (grid_layout_id == '') {
                $("#lblvalid_grid_layout").show();
                isValid = false;
            } else {
                $("#lblvalid_grid_layout").hide();
            }

            return isValid;

        }


        //Save 
        function onLoadImage(id) {
            var param = "{'id':" + JSON.stringify(id) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/GetImageFloorPlan",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != "") {
                        $("#imgPopup").attr("src", data.d)
                        $("#dialog-image").dialog({
                            autoOpen: false,
                            resizable: false,
                            width: "500px",
                            modal: true
                        });
                        var titledialog = 'Image';
                        $("#dialog-image").dialog("option", "title", titledialog).dialog("open");

                    }
                }
            });
        }

        function populateSelectFloorPlan(ms_floor_plan_id_current, ms_floor_id, ms_room_id) {
            var strselect;
            var param = "{'ms_floor_id':" + JSON.stringify(ms_floor_id)
                + ",'ms_room_id':" + JSON.stringify(ms_room_id) + "}";

            $selectFloorplan = $("#cbfloorPlanGrid");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadFloorPlanByFloorAndRoom',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    $selectFloorplan.html('');
                    $selectFloorplan.append('<option value="">Choose a Floor Plan</option>');
                    $selectFloorplan.trigger("chosen:updated");
                    //append a select option
                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        if (ms_floor_plan_id_current == val.id) {
                            strselect = ' selected="selected"';
                        }
                        $selectFloorplan.append('<option value="' + val.id + '" ' + strselect + '>' + val.floorplanname + '</option>');
                        // $selectFloorplan.trigger("liszt:updated");//update select option
                        $selectFloorplan.trigger("chosen:updated");
                    })

                    $selectFloorplan.chosen();
                }
            });
        }

        function populateSelectGridLayout(ms_grid_layout_id_current) {
            var strselect;
            $selectGridlayout = $("#cbgridlayout");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadGridLayoutActive',
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectGridlayout.html('');
                    $selectGridlayout.append('<option value="">Choose a Grid Layout</option>');
                    $selectGridlayout.trigger("chosen:updated");
                    //append a select option

                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        if (ms_grid_layout_id_current == val.id) {
                            strselect = ' selected="selected"';
                        }
                        $selectGridlayout.append('<option value="' + val.id + '" ' + strselect + '>' + val.layout_name + '</option>');
                        $selectGridlayout.trigger("chosen:updated");//update select option
                    })

                    $selectGridlayout.chosen();
                }
            });
        }

        function populateSelectGridLayoutMap(ms_grid_layout_id_current) {
            var strselect;
            $selectOfficerMaplayout = $("#cbofficermapLayout");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadGridLayoutActive',
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //append a select option
                    //clear 
                    $selectOfficerMaplayout.html('');
                    $selectOfficerMaplayout.trigger("chosen:updated");

                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        if (ms_grid_layout_id_current == val.id) {
                            strselect = ' selected="selected"';
                        }
                        $selectOfficerMaplayout.append('<option value="' + val.id + '" ' + strselect + '>' + val.layout_name + '</option>');
                        $selectOfficerMaplayout.trigger("chosen:updated");//update select option
                    })

                    $selectOfficerMaplayout.chosen();
                }
            });
        }

        function SetStringParam(param) {
            return '\'' + param + '\'';
        }
        function onMark(id, row, col, maxrow, maxcol) {
            var backgroundColor = $("#" + id).css('backgroundColor');
            $("#divGridShowBackcolor").css('background-color', 'rgba(255,255,0,0)');
            var backgroundColor2 = $("#divGridShowBackcolor").css('backgroundColor');
            $("#divGridShowBackcolorSelect2").css('background-color', 'rgba(255,255,0,0.2)');
            var backgroundColor3 = $("#divGridShowBackcolorSelect2").css('backgroundColor');
            if (backgroundColor == backgroundColor2 || backgroundColor == backgroundColor3) {
                $("#" + id).css('background-color', 'rgba(255,255,0,0.5)');
                $("#txtNo").val(id);
                $("#txtRow").val(row);
                $("#txtCol").val(col);
                $("#txtMaxRow").val(maxrow);
                $("#txtMaxCol").val(maxcol);
                onSaveGridMap(id);
            } else {
                $("#" + id).css('background-color', 'rgba(255,255,0,0)');
                //get no from json object
                var jsonobject = JSON.parse(localStorage['gridmapdata']);
                var getvalue = getObjects(jsonobject, 'point', id);
                if (getvalue.length > 0) {
                    onDeleteGridMap(getvalue[0].no);
                }
            }
        }


        function onOver(id) {
            $("#divGridShowBackcolorSelect").css('background-color', 'rgba(255,255,0,0.5)');
            var backgroundColor2 = $("#divGridShowBackcolorSelect").css('backgroundColor');
            var backgroundColor = $("#" + id).css('backgroundColor');
            if (backgroundColor != backgroundColor2) {
                $("#" + id).css('background-color', 'rgba(255,255,0,0.2)');
            }
        }
        function onOut(id) {
            var backgroundColor = $("#" + id).css('backgroundColor');
            $("#divGridShowBackcolorSelect2").css('background-color', 'rgba(255,255,0,0.2)');
            var backgroundColor2 = $("#divGridShowBackcolorSelect2").css('backgroundColor');
            if (backgroundColor == backgroundColor2) {
                $("#" + id).css('background-color', 'rgba(255,255,0,0)');

            } 
        }

        function onSaveGridMap(id) {
            var no = $('#txtNo').val();
            var col = $('#txtCol').val();
            var row = $('#txtRow').val();
            var maxcol = $('#txtMaxCol').val();
            var maxrow = $('#txtMaxRow').val();
            var gridlayoutid = $("#cbofficermapLayout").val();
            var gridlayoutname = $("#cbofficermapLayout option:selected").text();
            var desktopid = $("#txtDesktopID").val();
            //running no
            var rows = $("#dt_mapgridlayout").dataTable().fnGetNodes();

            //data in current session
            var jsonobject = JSON.parse(localStorage['gridmapdata']);
            var aaData = [];
            aaData = jsonobject;
            //add data in current session
            var isedit=0;
            for (var i = 0; i < aaData.length; i++) {
                if (aaData[i].ms_grid_layout_id == gridlayoutid) {
                    if (aaData[i].point == id) {
                            aaData[i].layout_name = gridlayoutname;
                            aaData[i].cell = row + ',' + col;
                            aaData[i].point = id;
                            aaData[i].ms_grid_layout_id = gridlayoutid;
                            aaData[i].desktopid = desktopid;
                            isedit = 1;
                            break;
                    }
          
                }
            }
            if (isedit == 0) {
                aaData.push({
                    "no": parseInt(rows.length) + 1,
                    "ms_desktop_id": desktopid,
                    "ms_grid_layout_id": gridlayoutid,
                    "layout_name": gridlayoutname,
                    "cell": row + ',' + col,
                    "point": id
                });
            }


            //update data in session
            localStorage['gridmapdata'] = JSON.stringify(aaData);

            // Reload
            LoadDataOfficerMapGridLayout(gridlayoutid)
        }

        function onDeleteGridMap(no) {
            var gridlayoutid = $("#cbofficermapLayout").val();
            var jsonobject = JSON.parse(localStorage['gridmapdata']);
            var aaData = [];
            aaData = jsonobject;
            //delete position 1 to 1 record
            aaData.splice(parseInt(no) - 1, 1);
            //running inndex new
            var icount = 1;
            $.each(aaData, function (key, val) {
                aaData[icount - 1].no = icount;
                icount = icount + 1
            })
            localStorage['gridmapdata'] = JSON.stringify(aaData);
            LoadDataOfficerMapGridLayout(gridlayoutid)
        }

<%--        function onSaveMapGridLayOut() {
            var countitem=0;
            var countitemall;
            var userid = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();
            var desktopid = $("#txtDesktopID").val();
            var gridlayoutid = $("#cbofficermapLayout").val();
            var jsonobject = JSON.parse(localStorage['gridmapdata']);
            var aaData = [];
            aaData = jsonobject;
            countitemall = aaData.length;
            //add data in current session
            for (var i = 0; i < aaData.length; i++) {
                var strtemp = aaData[i].cell;
                var strtemp2 = strtemp.split(',');
                var param = "{'ms_desktop_id':" + JSON.stringify(desktopid)
                  + ",'ms_grid_layout_id':" + JSON.stringify(aaData[i].id)
                  + ",'grid_col':" + JSON.stringify(strtemp2[1])
                  + ",'grid_row':" + JSON.stringify(strtemp2[0])
                  + ",'userid':" + JSON.stringify(userid)
                  + "}";
               // alert(param);
                var dataurl = 'WebService/WebService.asmx/SaveMapGrid';

                $.ajax({
                    "type": "POST",
                    "dataType": 'json',
                    "contentType": "application/json; charset=utf-8",
                    "url": dataurl,
                    "data": param,
                    "success": function (data) {
                        if (data.d == true) {
                            countitem = countitem + 1;
                        }
                    },
                    "error": onFailed
                });

            }
            onAlert("Save Data Complete");
           $("#dialog-setgrid").dialog("close");
        }--%>


        function onSaveMapGridLayOut() {
            var userid = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();
            var jsonobject = JSON.parse(localStorage['gridmapdata']);
            var desktopid = $("#txtDesktopID").val();
            var aaData = [];
            aaData = jsonobject;
            var strdataall_dt = '';
            var strdataall_shape = '';

            for (var i = 0; i < aaData.length; i++) {

                var strtemp = aaData[i].cell;
                var strtemp2 = strtemp.split(',');

                if (i != 0) {
                    strdataall_shape = "#";
                }

                strdataall_dt = strdataall_dt + strdataall_shape + aaData[i].ms_desktop_id + ',' + aaData[i].ms_grid_layout_id + ',' + strtemp2[1] + ',' + strtemp2[0] + ',' + userid;

            }
            var param = "{'desktopid':" + JSON.stringify(desktopid)
                + ",'strdataall_dt':" + JSON.stringify(strdataall_dt) + "}";

            var dataurl = 'WebService/WebService.asmx/SaveMapGrid';

            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": onMapSuccess,
                "error": onFailed
            });
        }

    </script>
  
</asp:Content>




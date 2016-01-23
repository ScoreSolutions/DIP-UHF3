<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmAntennaReadingArea.aspx.vb" Inherits="frmAntennaReadingArea" %>

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
                <li class="active">Antenna Reading Area</li>
            </ul>

            <!--#nav-search-->
        </div>

        <div class="page-content">

            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 id="lblheader" class="header smaller lighter blue">Antenna Reading Area</h3>
  <%--                  <div class="row-fluid">
                                           <div class="input-append bootstrap-timepicker">
                                    <input id="txtTimepickerstart" type="text" class="input-small width-55" />

                                    <span class="add-on">
                                        <i class="icon-time"></i>
                                    </span>

                                    <span class="help-inline">To</span>
                                </div>
                    </div>--%>
                    <div class="row-fluid" id="dialog-action">
                        <button class="btn btn-small" id="btnBack" name="btnBack">
                            <i class=" icon-undo"></i>
                            Back
                        </button>
                        <div class=" space-2"></div>
                    </div>
                    <div class="row-fluid" id="dialog-first">
                        <div class="span12">
                            <table class="table table-striped table-bordered table-hover" id="dt_out"></table>
                        </div>
                    </div>
                    <div id="dialog-speedway">
                        <div class="row-fluid">
                            <table class="table table-striped table-bordered table-hover" id="dt_speedway"></table>
                        </div>
                    </div>
                </div>

            </div>

            <div id="dialog-image" style="display: none">
                <img id="imgPopup" src="images/No_image.gif" style="height: 350px; width: 500px;" />
            </div>






        </div>

    </div>

    <div id="dialog-setgrid">
        <div class="row-fluid">
            <div class="span7">
                 <div id="divGridShowBackcolor"></div>
                <div id="divGridShowBackcolorSelect"></div>
                <div id="divGridShowBackcolorSelect2"></div>
                <div id="divGridShow"></div>
                <input type="text" class="input-mini" id="txtNo" maxlength="255" style="display: none" />
                <input type="text" class="input-mini" id="txtRow" maxlength="255" style="display: none" />
                <input type="text" class="input-mini" id="txtCol" maxlength="255" style="display: none" />
                <input type="text" class="input-mini" id="txtMaxRow" maxlength="255" style="display: none" />
                <input type="text" class="input-mini" id="txtMaxCol" maxlength="255" style="display: none" />
            </div>

            <div class="span5">

                <div class="row-fluid">
                    <div class="span4">
                        <div class="control-label">Reader ID</div>
                    </div>

                    <div class="span8">
                        <input type="text" class="input-mini" id="txtReaderID" maxlength="255" disabled="disabled" style="width: 300px;" />
                        <input type="text" class="input-mini" id="txtRoomID" maxlength="255" style="display: none" />
                        <input type="text" class="input-mini" id="txtSpeedWayID" maxlength="255" style="display: none" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span4">
                        <div class="control-label">IP Address</div>
                    </div>

                    <div class="span8">
                        <input type="text" class="input-mini" id="txtIPAddress" maxlength="255" disabled="disabled" style="width: 300px;" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span4">
                        <div class="control-label">Install Position</div>
                    </div>

                    <div class="span8">
                        <input type="text" class="input-mini" id="txtInstallPosition" maxlength="255" disabled="disabled" style="width: 300px;" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span4">
                        <div class="control-label">Antenna Port No </div>
                    </div>

                    <div class="span8">
                        <select id="cboant" data-placeholder="Choose a Antenna..." style="width: 200px;">
                        </select>
                    </div>
            </div>

            <div class="row-fluid">
                <div class="span4">
                    <div class="control-label">Grid Layount</div>
                </div>

                <div class="span8">
                    <select id="cbofficermapLayout" data-placeholder="Choose a Grid Layout..." style="width: 200px;">
                    </select>
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
            localStorage['gridmapdata'] = '';
            //Load Data
            var oTable;
            var isAddNew = false;
            LoadData();
            //Add Click
            $("#btnBack").click(function () {
                $("#dialog-speedway").hide();
                $("#dialog-action").hide();
                $("#dialog-first").show();
                $("#lblheader").text('Antenna Reading Area');
                return false;
            });

            $('#cbofficermapLayout').change(function () {
                var speedwayantid = $('#cboant').val();
                var roomid = $("#txtRoomID").val();
                var gridlayoutcurrentid = $('#cbofficermapLayout').val();
                LoadDataSetGrid(roomid, gridlayoutcurrentid, speedwayantid);
            });

            $('#cboant').change(function () {
                var speedwayantid = $('#cboant').val();
                var roomid = $("#txtRoomID").val();
                var gridlayoutcurrentid = $('#cbofficermapLayout').val();
                LoadDataSetGrid(roomid, gridlayoutcurrentid, speedwayantid);
            });


            $("#dialog-edit").hide();
            $("#dialog-speedway").hide();
            $("#dialog-setgrid").hide();
            $("#dialog-action").hide();
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

        function LoadDataSpeedWay(roomid) {
            var dataurl = 'WebService/WebService.asmx/LoadSpeedWayByRoomId';
            var param = "{'roomid':" + JSON.stringify(roomid) + "}";

            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": PopulateGridSpeedWay
            });
        }

        function LoadDataSetGrid(roomid, gridlayoutcurrentid, speedwayantid) {

            var param = "{'roomid':" + JSON.stringify(roomid)
                        + ",'gridlayoutcurrentid':" + JSON.stringify(gridlayoutcurrentid)
                        + ",'speedwayantid':" + JSON.stringify(speedwayantid)
                        + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadAntennaPlanByRoomId",
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
                            //countforclear = countforclear + 1;
                          
                            ////clear all td
                            //if (countforclear == 1) {
                            //var i;
                            //var j;
                            //var indexstrart = 1;
                            //for (i = 1; i <= val.maxrow; i++) {
                            //    for (j = 1; j <= val.maxcol; j++) {
                            //        $("#divGridShow").find("td#" + indexstrart).css('background-color', 'rgba(255,255,0,0)');
                            //        indexstrart = indexstrart + 1;
                            //    }
                            //    j = 1;

                            //}
                            //}

                            if (speedwayantid == val.ms_speedway_ant_id && gridlayoutcurrentid == val.ms_grid_layout_id) {
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
                       // alert(point);
                       // alert(point2);

                        //set default from database
                        //if (point.length != 0) {

                        //    //clear all td
                        //    var i;
                        //    var j;
                        //    var indexstrart = 1;
                        //    for (i = 1; i <= point[0].maxrow; i++) {
                        //        for (j = 1; j <= point[0].maxcol; j++) {
                        //            $("#divGridShow").find("td#" + indexstrart).css('background-color', 'rgba(255,255,0,0)');
                        //            indexstrart = indexstrart + 1;
                        //        }
                        //        j = 1;

                        //    }
                        //    //set grid position
                        //    $("#divGridShow").find("td#" + point[0].point).css('background-color', 'rgba(255,255,0,0.5)');
                        //    $("#txtNo").val(point[0].point);
                        //    $("#txtRow").val(point[0].row);
                        //    $("#txtCol").val(point[0].col);
                        //    $("#txtMaxRow").val(point[0].maxrow);
                        //    $("#txtMaxCol").val(point[0].maxcol);
                        //    // onSaveGridMap(point[0].point);

                        //}



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



        function LoadDataOfficerMapGridLayout(ms_speedway_id) {
            var dataurl = 'WebService/WebService.asmx/LoadAttenaMapLayoutByPort';
            var param = "{'ms_speedway_id':" + JSON.stringify(ms_speedway_id) + "}";

            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": PopulateGridAntennaMapGridLayout
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
                                            + '<button title="Speedway" class="btn btn-small btn-warning" id="btnSpeedway" name="btnSpeedway" onclick="onSpeedWay(' + obj.aData.id + ');return false;">'
                                            + '<i class="icon-building"></i>'
                                            + 'Speedway'
                                            + '</button>'
                                            + '</div>'
                                            + '<div class="hidden-desktop visible-phone">'
                                            + '			<div class="inline position-relative">'
                                            + '				<button class="btn btn-minier btn-primary dropdown-toggle" data-toggle="dropdown">'
                                            + '					<i class="icon-cog icon-only bigger-110"></i>'
                                            + '				</button>'
                                            + '				<ul class="dropdown-menu dropdown-icon-only dropdown-yellow pull-right dropdown-caret dropdown-close">'
                                            + '					<li>'
                                            + '						<a href="#"  class="tooltip-error" data-rel="tooltip" title="Mapping Speedway" onclick="onSpeedWay(' + obj.aData.id + ');"' + ' return false;>'
                                            + '							<span class="orange">'
                                            + '								<i class="icon-user building-120"></i>'
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

        function PopulateGridSpeedWay(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var columns = [{
                "sTitle": "No",
                "sType": "numeric",
                "mDataProp": "no",
                "bSortable": false,
                "bUseRendered": false

            },
                            {
                                "sTitle": "Reader ID",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "readerid"

                            },
                            {
                                "sTitle": "Serial No",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "serial_no"

                            },
                            {
                                "sTitle": "IP Address",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "ip_address"

                            },
                            {
                                "sTitle": "Install Position",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "install_position"

                            },
                            {
                                "sTitle": "Floor",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "floor_name"

                            },
                            {
                                "sTitle": "Ant",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "ant_qty"

                            },

                            {
                                "sTitle": "Action",
                                "bSortable": false,
                                "fnRender": function (obj) {
                                    var sdparam = SetStringParam(obj.aData.readerid) + ',' + SetStringParam(obj.aData.ip_address) + ',' + SetStringParam(obj.aData.install_position) + ',' + obj.aData.ms_grid_layout_id_current + ',' + obj.aData.ms_room_id + ',' + obj.aData.id + ',' + obj.aData.ms_speedway_ant_id;
                                    var ret = '<div class="hidden-phone visible-desktop action-buttons">'
                                            + '<button title="Read Area" class="btn btn-small btn-warning" id="btnReadArea" name="btnReadArea" onclick="onSetGrid(' + sdparam + ')";return false;">'
                                            + '<i class="icon-building"></i>'
                                            + 'Read Area'
                                            + '</button>'
                                            + '</div>'
                                            + '<div class="hidden-desktop visible-phone">'
                                            + '			<div class="inline position-relative">'
                                            + '				<button class="btn btn-minier btn-primary dropdown-toggle" data-toggle="dropdown">'
                                            + '					<i class="icon-cog icon-only bigger-110"></i>'
                                            + '				</button>'
                                            + '				<ul class="dropdown-menu dropdown-icon-only dropdown-yellow pull-right dropdown-caret dropdown-close">'
                                            + '					<li>'
                                            + '						<a href="#"  class="tooltip-error" data-rel="tooltip" title="Mapping Area" onclick="onSetGrid(' + sdparam + ');return false;>'
                                            + '							<span class="orange">'
                                            + '								<i class="icon-building bigger-120"></i>'
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

            oTable = $('#dt_speedway').dataTable({
                "aaData": jsonobject,
                "bAutoWidth": false,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "10%", "aTargets": [1] },
                { "sWidth": "20%", "aTargets": [2] },
                { "sWidth": "10%", "aTargets": [3] },
                { "sWidth": "20%", "aTargets": [4] },
                { "sWidth": "10%", "aTargets": [5] },
                { "sWidth": "5%", "aTargets": [6] },
                { "sWidth": "15%", "aTargets": [7] },
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });


        }


        function PopulateGridAntennaMapGridLayout(jsondata) {
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
                                "sTitle": "Antenna Port No",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "port_number"

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
                { "sWidth": "30%", "aTargets": [1] },
                { "sWidth": "30%", "aTargets": [2] },
                { "sWidth": "30%", "aTargets": [3] }
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

        function onSpeedWay(roomid) {
            LoadDataSpeedWay(roomid);
            $("#dialog-speedway").show();
            $("#dialog-action").show();
            $("#dialog-first").hide();
            $("#lblheader").text('Speedway');

            //$("#dialog-speedway").dialog({
            //    autoOpen: false,
            //    resizable: false,
            //    width: "100%",
            //    modal: true,
            //    buttons: {
            //        "Close": function () {
            //            $(this).dialog("close");
            //        }

            //    },
            //    show: {
            //        effect: 'fade',
            //        duration: 500
            //    },
            //    hide: {
            //        effect: 'fade',
            //        duration: 500
            //    }
            //});


            //$("#dialog-speedway").dialog("option", "title", "Map Officer").dialog("open");

        }

        function onSetGrid(readerid, ip_address, install_position, ms_grid_layout_id_current, ms_room_id, id, ms_speedway_ant_id) {
            // alert(id);
            //alert(ms_grid_layout_id_current);
            //alert(desktopname);
            //alert(officername);
            localStorage['gridmapdata'] = '';
            populateSelectAntenna(id);
            populateSelectGridLayoutMap(ms_grid_layout_id_current);
            $("#txtReaderID").val(readerid);
            $("#txtIPAddress").val(ip_address);
            $("#txtInstallPosition").val(install_position);
            $("#txtRoomID").val(ms_room_id);
            $("#txtSpeedWayID").val(id);
            LoadDataSetGrid(ms_room_id, ms_grid_layout_id_current, ms_speedway_ant_id);
            LoadDataOfficerMapGridLayout(id);



            $("#dialog-setgrid").dialog({
                autoOpen: false,
                resizable: false,
                modal: true,
                width: "85%",//$(window).width(),
                buttons: {
                    "Save": function () {
                        //onSaveMapAntena();
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


            $("#dialog-setgrid").dialog("option", "title", "Read Area").dialog("open");
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
                                    onSaveMapAntena();
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
            if (result.d == true) {
                $("#dialog-edit").dialog('close');
                onAlert("Save Data Complete");
                LoadData();
            } else {
                onAlert("Save Data Fail");
            }

        }
        //Map Attenna
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

        function populateSelectAntenna(speedwayid) {
            var strselect;
            var param = "{'speedwayid':" + JSON.stringify(speedwayid) + "}";

            $selectAnt = $("#cboant");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadAntennaBySpeedway',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    $selectAnt.html('');
                    $selectAnt.trigger("chosen:updated");
                    //append a select option
                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        //if (ms_floor_plan_id_current == val.id) {
                        //    strselect = ' selected="selected"';
                        //}
                        $selectAnt.append('<option value="' + val.id + '" ' + strselect + '>' + val.port_number + '</option>');
                        // $selectFloorplan.trigger("liszt:updated");//update select option
                        $selectAnt.trigger("chosen:updated");
                    })

                    $selectAnt.chosen();
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
                    $selectOfficerMaplayout.prop('disabled', true)
                    $selectOfficerMaplayout.chosen();
        
                }
            });
        }

        function SetStringParam(param) {
            return '\'' + param + '\'';
        }
        function onMark(id, row, col, maxrow, maxcol) {

            //alert(id);
            //alert(row);
            //alert(col);
            //alert(maxrow);
            //alert(maxcol);
            //var i;
            //var j;
            //var indexstrart = 1;
            //for (i = 1; i <= maxrow; i++) {
            //    for (j = 1; j <= maxcol; j++) {
            //        $("#" + indexstrart).css('background-color', '');
            //        indexstrart = indexstrart + 1;
            //    }
            //    j = 1;

            //}
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
            //if (backgroundColor != backgroundColor2) {// if color same is  insert or not same  is delete
            //    $("#" + id).css('background-color', 'rgba(255,255,0,0)');
            //    //get no from json object
            //    var jsonobject = JSON.parse(localStorage['gridmapdata']);
            //    var getvalue = getObjects(jsonobject, 'point', id);
            //    if (getvalue.length > 0) {
            //        onDeleteGridMap(getvalue[0].no);
            //    }
               
            //} else {
            //    $("#" + id).css('background-color', 'rgba(255,255,0,0.5)');
            //    $("#txtNo").val(id);
            //    $("#txtRow").val(row);
            //    $("#txtCol").val(col);
            //    $("#txtMaxRow").val(maxrow);
            //    $("#txtMaxCol").val(maxcol);
            //     onSaveGridMap(id);
            //}
     
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
            //alert(backgroundColor);
            //alert(backgroundColor2);
            if (backgroundColor == backgroundColor2) {
                $("#" + id).css('background-color', 'rgba(255,255,0,0)');
           
            }

            //if ($("#txtNo").val() != id) {
            //    $("#" + id).css('background-color', 'rgba(255,255,0,0)');
            //} else {
            //    $("#" + id).css('background-color', 'rgba(255,255,0,0.5)');
            //}
        }

        function onSaveGridMap(id) {
            var no = $('#txtNo').val();
            var col = $('#txtCol').val();
            var row = $('#txtRow').val();
            var maxcol = $('#txtMaxCol').val();
            var maxrow = $('#txtMaxRow').val();
            var gridlayoutid = $("#cbofficermapLayout").val();
            var gridlayoutname = $("#cbofficermapLayout option:selected").text();
            var antid = $("#cboant").val();
            var antname = $("#cboant option:selected").text();
            //running no
            var rows = $("#dt_mapgridlayout").dataTable().fnGetNodes();

            //data in current session
            var jsonobject = JSON.parse(localStorage['gridmapdata']);
            var aaData = [];
            aaData = jsonobject;
            //add data in current session
            var isedit = 0;
            for (var i = 0; i < aaData.length; i++) {
                if (aaData[i].ms_grid_layout_id == gridlayoutid && aaData[i].ms_speedway_ant_id == antid) {
                    if (aaData[i].point == id) {
                        aaData[i].layout_name = gridlayoutname;
                        aaData[i].cell = row + ',' + col;
                        aaData[i].port_number = antname;
                        aaData[i].point = id;
                        isedit = 1;
                        break;
                    }
                }
            }
            if (isedit == 0) {
                aaData.push({
                    "no": parseInt(rows.length) + 1,
                    "id": id,
                    "ms_grid_layout_id": gridlayoutid,
                    "ms_speedway_ant_id": antid,
                    "layout_name": gridlayoutname,
                    "cell": row + ',' + col,
                    "port_number": antname,
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


        function onSaveMapAntena() {
            var countitem = 0;
            var countitemall;
            var userid = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();
            var jsonobject = JSON.parse(localStorage['gridmapdata']);
            var speedwayid = $("#txtSpeedWayID").val();
            var aaData = [];
            aaData = jsonobject;
            countitemall = aaData.length;
            var strdataall_dt= '';
            var strdataall_shape ='';

            for (var i = 0; i < aaData.length; i++) {

                var strtemp = aaData[i].cell;
                var strtemp2 = strtemp.split(',');

                if (i != 0) {
                    strdataall_shape = "#";
                }

                strdataall_dt = strdataall_dt + strdataall_shape + aaData[i].ms_speedway_ant_id + ',' + aaData[i].ms_grid_layout_id + ',' + strtemp2[1] + ',' + strtemp2[0] + ',' + userid;


                //var strtemp = aaData[i].cell;
                //var strtemp2 = strtemp.split(',');

            }
            var param = "{'speedwayid':" + JSON.stringify(speedwayid)
                + ",'strdataall_dt':" + JSON.stringify(strdataall_dt) + "}";

            var dataurl = 'WebService/WebService.asmx/SaveMapAntenna';

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


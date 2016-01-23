<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage2.master" AutoEventWireup="false" CodeFile="frmFloorPlan.aspx.vb" Inherits="frmFloorPlan" %>

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
                <li class="active">Floor Plan</li>
            </ul>
          
            <!--#nav-search-->
        </div>

        <div class="page-content">

 
            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">Floor Plan</h3>

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

                <div class="span3">
                    <label class="control-label" id="lblFloorPlanName">Floor Plan Name</label>
                </div>
                <div class="span9">
                    <input type="text" id="txtFloorPlanName" style="width: 200px">
                    <span class="help-inline color red" id="lblvalid_floor_plan_name" style="display: none">This field is required</span>
                </div>

            </div>
        </div>
        <div class="row-fluid">
            <div class="span12">

                <div class="span3">
                    <label class="control-label" id="lblFloor">Floor</label>
                </div>
                <div class="span9">
                    <select  id="cbfloor" data-placeholder="Choose a Floor..." style="width:250px">
                    </select>
                    <span class="help-inline color red" id="lblvalid_floor_id" style="display: none">This field is required</span>
                </div>

            </div>
        </div>
        <div class="row-fluid" >
            <div class="span12">

                <div class="span3">
                    <label class="control-label" id="lblRoom">Room</label>
                </div>
                <div class="span9">
                   <select  id="cbroom" data-placeholder="Choose a Room..." style="width:250px">
                    </select>
                    <span class="help-inline color red" id="lblvalid_room_id" style="display: none">This field is required</span>
                </div>

            </div>
        </div>
         <div class="row-fluid" >
            <div class="span12">

                <div class="span3">
                    <label class="control-label" id="lblImage">Image</label>
                </div>
                <div class="span9">
                    <div class="row-fluid">
                        <div class="span5">
                            <a href="images/No_image.gif" id="aimg" style="display: none;"></a>
                            <img id="img" src="images/No_image.gif" style="height: 150px; width: 200px; cursor: pointer;" />
                            <div id="dialog-image" style="display: none">
                                <img id="imgPopup" src="images/No_image.gif" style="height: 350px; width: 500px;" />
                            </div>

                            <div id="base" style="display: none"></div>
                           <%-- <div id="basepath" style="display: none"></div>--%>
                            <div id="basename" style="display: none"></div>

                            <div class="space-2"></div>
                            <span class="btn btn-default btn-mini btn-file">Browse&hellip; 
                                    <input type='file' id="roomimagefile" class="ace-file-input" />
                            </span>
                            <button class="btn btn-danger btn-mini" id="btnClearImage">
                                Clear
                            </button>
                        <span class="help-inline color red" id="lblvalid_image" style="display: none">This field is required</span>
                        </div>
                        <div class="span6">
                            <span class="help-inline" id="lblvalidfiletype">file type: gif,png,jpg,jpeg</span>
                            <span class="help-inline" id="lblvalidfilesize">file size: size less than 1MB</span>
                        </div>
 
                    </div>

                </div>

            </div>
        </div>
        <div class="row-fluid">
            <div class="span3">
                <label class="control-label" id="lblRoomPropertyActive">Active</label>
            </div>
            <div class="span9">
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

            $('#cbfloor').change(function () {
                populateSelectRoomById();
            });

            //Add Click
            $("#btnAdd").click(function () {
                onEdit(0); return false;
            });

            $("#roomimagefile").change(function () {
                readImage(this);
            });

            $("#roomimagefile").click(function () {
                this.value = null;
            });

            $("#img").click(function () {
                imagePopup();
            });

            $("#btnClearImage").click(function () {
                $("roomimagefile").val("");
                clearImage();
            });

            $("#dialog-edit").hide();
        });



        //Call
        function LoadData() {
            var dataurl = 'WebService/WebService.asmx/LoadFloorPlanAll';
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
                                "sTitle": "Floor Plan Name",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "floor_plan_name"

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
                                    //return '<img class="img-responsive" ng-alt="" src="' + obj.aData.image_floor_plan_show + '" width="100px"/>';
                                    return ' <i class="icon-search" style="cursor:pointer" onclick="onLoadImage(' + obj.aData.id + ');"></i>';
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
                                            + '						<a href="#"  class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDelete(' + obj.aData.id + ');"' + str + ' return false;>'
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
                { "sWidth": "20%", "aTargets": [1] },
                { "sWidth": "10%", "aTargets": [2] },
                { "sWidth": "20%", "aTargets": [3] },
                { "sWidth": "20%", "aTargets": [4] },
                { "sWidth": "10%", "aTargets": [5] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
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

        //Add or Edit 
        function onEdit(id) {
            onValidHide();
            var param = "{'id':" + JSON.stringify(id) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/GetFloorPlanById",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = JSON.parse(data.d);

                    if (strvalue.length == 1) {
                        $("#txtFloorPlanName").val(strvalue[0].floor_plan_name);
                        $("#cbfloor").val(strvalue[0].ms_floor_id);
                        $("#cbroom").val(strvalue[0].ms_room_id);
                        if (strvalue[0].base != '') {
                            $("#img").attr("src", strvalue[0].image_floor_plan_show);
                            $("#imgPopup").attr("src", strvalue[0].image_floor_plan_show);
                            $("#base").text(strvalue[0].base);
                            $("#basepath").text('');
                            $("#basename").text('xx' + '.' + strvalue[0].image_file_ext);
                            //$("#img").attr("alt", 'xx' + '.' + strvalue[0].image_file_ext);
                            $("#aimg").attr("href", strvalue[0].image_floor_plan_show);

                        } else {
                           clearImage();
                        }

                        populateSelect(strvalue[0].id);
                        if (strvalue[0].active_status == "Y") {
                            $("#ckbActive").prop("checked", true);
                        } else {
                            $("#ckbActive").prop("checked", false);
                        }
                    } else {
                        $("#txtFloorPlanName").val("");
                        $("#cbfloor").val("");
                        $("#cbroom").val("");
                        clearImage();
                        populateSelect(0);
                        $("#ckbActive").prop("checked", true);
                    }
                }
            });



            $("#dialog-edit").dialog({
                autoOpen: false,
                resizable: false,
                width: "620px",
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
            var floor_id = $('#cbfloor').val();
            var room_id = $('#cbroom').val();
            var active = $('input[name="ckbActive"]:checked').length;
            var strimagebase64 = $("#base").text();
            var strimagename = $("#basename").text();
            var floor_plan_name = $("#txtFloorPlanName").val();

            var param = "{'id':" + JSON.stringify(id)
                + ",'floor_id':" + JSON.stringify(floor_id)
                + ",'room_id':" + JSON.stringify(room_id)
                + ",'login_username':" + JSON.stringify(login_username)
                + ",'active':" + JSON.stringify(active)
                + ",'strimagebase64':" + JSON.stringify(strimagebase64)
                + ",'strimagename':" + JSON.stringify(strimagename) 
                + ",'floor_plan_name':" + JSON.stringify(floor_plan_name) + "}";
           
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/SaveFloorPlan",
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
                url: "WebService/WebService.asmx/DeleteFloorPlan",
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
                if (result.d == "DUPLICATEFLOORPLAN") {
                    onAlert("Floor plan already exists.");
                    LoadData();
                } else if (result.d == "DUPLICATEFLOORPLANNAME") {
                    onAlert("Floor plan name already exists.");
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
            $("#lblvalid_floor_id").hide();
            $("#lblvalid_room_id").hide();
            $("#lblvalid_image").hide();
            $("#lblvalid_floor_plan_name").hide();

        }

        //Check Valid
        function onValid() {
            var isValid;
            isValid = true;
            var floor_id = $('#cbfloor').val();
            var room_id = $('#cbroom').val();
            var basename = $("#basename").text();
            var floor_plan_name = $('#txtFloorPlanName').val();

            if (floor_id == '') {
                $("#lblvalid_floor_id").show();
                isValid = false;
            } else {
                $("#lblvalid_floor_id").hide();
            }

            if (room_id == '') {
                $("#lblvalid_room_id").show();
                isValid = false;
            } else {
                $("#lblvalid_room_id").hide();
            }
           
            if (basename == '') {
                $("#lblvalid_image").show();
                isValid = false;
            } else {
                $("#lblvalid_image").hide();               
            }

            if (floor_plan_name == '') {
                $("#lblvalid_floor_plan_name").show();
                isValid = false;
            }
            else {
                $("#lblvalid_floor_plan_name").hide();
            }

            return isValid;

        }

        //Populate Option 
        function populateSelect(floor_plan_id) {
            var strselect;
            var param = "{'floor_plan_id':" + JSON.stringify(floor_plan_id) + "}";

            $select = $("#cbfloor");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadFloorByFloorPlan',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    $select.html('');
                    $select.append('<option value="">Choose a Floor</option>');
                    //append a select option
                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        if (val.selected != "") {
                            strselect = ' selected="' + val.selected + '"';
                        }

                        $select.append('<option value="' + val.id + '" ' + strselect + '>' + val.floor_name + '</option>');
                        $select.trigger("chosen:updated");//update select option
                    })

                    $select.chosen();
                }
            });

            var param = "{'floor_plan_id':" + JSON.stringify(floor_plan_id) + "}";
            $selectRoom = $("#cbroom");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadRoomByFloorPlan',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectRoom.html('');
                    $selectRoom.append('<option value="">Choose a Room</option>');
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectRoom.append('<option value="' + val.id + '" ' + strselect + '>' + val.room_name + '</option>');
                            $selectRoom.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectRoom.html('');
                        $selectRoom.append('<option value="">Choose a Room</option>');
                        $selectRoom.trigger("chosen:updated");//update select option
                    }

                    $selectRoom.chosen();
                }
            });

        }

        function populateSelectRoomById() {
            var strselect;
            var param = "{'floor_id':" + JSON.stringify($("#cbfloor").val()) + "}";
            $selectRoom = $("#cbroom");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadRoomByFloor',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectRoom.html('');
                    $selectRoom.append('<option value="">Choose a Room</option>');
                    //append a select option

                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                      
                            $selectRoom.append('<option value="' + val.id + '">' + val.room_name + '</option>');
                            $selectRoom.trigger("chosen:updated");//update select option
                        })

                    }
                    else {

                        $selectRoom.html('');
                        $selectRoom.append('<option value="">Choose a Room</option>');
                        $selectRoom.trigger("chosen:updated");//update select option
                    }
                  
                    $selectRoom.chosen();
                   
                }
            });


        }

        

        //Read image file
        function readImage(input) {
            if (input.files && input.files[0]) {
                var FR = new FileReader();
                FR.onload = function (e) {
                    var binaryString = [];
                    var file = input.files[0];
                    var fileName = file.name;
                    var fileExt = fileName.split('.').pop().toLowerCase();

                    var filesize = file.size;

                    if ($.inArray(fileExt, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
                        onAlert("Please input image type gif,png,jpg,jpeg");
                    } else if ((filesize / 1024) > 1000) { //1Mb
                        onAlert("Please input image size less than 1MB");
                    } else {
                        $("#img").attr("src", e.target.result);
                        $("#imgPopup").attr("src", e.target.result);
                        binaryString = e.target.result;
                        binaryString = binaryString.split(',');
                        $("#base").text(binaryString[1]);
                       // $("#basepath").text($('input[type=file]').val());

                        $('#basename').text(fileName);
                        $("#aimg").attr("href", e.target.result);
                    }


                };
                FR.readAsDataURL(input.files[0]);
            }
        }

        //Image popup
        function imagePopup() {
            $("#dialog-image").dialog({
                autoOpen: false,
                resizable: false,
                width: "500px",
                modal: true
            });

            var titledialog = "Image";


            $("#dialog-image").dialog("option", "title", titledialog).dialog("open");
        }

        //Clear image
        function clearImage() {
            $("#img").attr("src", "images/No_image.gif");
            $("#imgPopup").attr("src", "images/No_image.gif");
            $("#aimg").attr("img", "")
            $("#aimg").attr("href", "images/No_image.gif");
            $("#base").text("");
            //$("#basepath").text("");
            $("#basename").text("");
        }

        function clearInput() {
            clearImage();
            populateSelect(0);
            $("#ckbActive").prop("checked", false);
        }

    </script>
</asp:Content>


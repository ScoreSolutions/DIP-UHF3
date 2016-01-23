<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage2.master" AutoEventWireup="false" CodeFile="frmDesktop.aspx.vb" Inherits="frmDesktop" %>

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
                <li class="active">Work Station</li>
            </ul>
          
            <!--#nav-search-->
        </div>

        <div class="page-content">

 
            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">Work Station</h3>

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
<div id="dialog-edit" >

        <div class="row-fluid">
            <div class="span12">

                <div class="span4">
                    <label class="control-label" id="lblDesktopNo">Desktop No</label>
                </div>
                <div class="span8">
                    <input type="text" class="input-mini" id="txtDesktopNo" style="width:200px;" maxlength="255" />
                    <span class="help-inline color red" id="lblvalid_DesktopNo" style="display: none">This field is required</span>
                </div>

            </div>
        </div>
        <div class="row-fluid" >
            <div class="span12">

                <div class="span4">
                    <label class="control-label" id="lblFloor">Floor</label>
                </div>
                <div class="span8">
                    <select  id="cbfloor" data-placeholder="Choose a Floor..."  style="width:250px">
                    </select>
                    <span class="help-inline color red" id="lblvalid_floor_id" style="display: none">This field is required</span>
                </div>

            </div>
        </div>
         <div class="row-fluid" >
            <div class="span12">

                <div class="span4">
                    <label class="control-label" id="lblHorizontalLine">Room</label>
                </div>
                <div class="span8">
                  <select  id="cbroom" data-placeholder="Choose a Room..." style="width:250px">
                    </select>
                    <span class="help-inline color red" id="lblvalid_room_id" style="display: none">This field is required</span>
                </div>

            </div>
        </div>
        <div class="row-fluid" >
            <div class="span12">

                <div class="span4">
                    <label class="control-label" id="lblOwner">Owner</label>
                </div>
                <div class="span8">
                  <%--<select class="chzn-select" id="cbowner" data-placeholder="Choose a Owner..."></select>--%>
                     <input type="text" id="txtUserName" style="width: 200px" placeholder="Input Name or Surname">
                     <input type="text" id="txtUserId" style="width: 200px; display: none;" placeholder="Id">
                    
                    <span class="help-inline color red" id="lblvalid_owner" style="display: none">Please select owner</span>
                </div>

            </div>
        </div>
        <%--<div class="row-fluid" >
            <div class="span12">

                <div class="span4">
                    <label class="control-label" id="lblOw">Owner</label>
                </div>
                <div class="span8">
                  <label for="tags">Tags: </label>
                  <input id="tags">
                </div>

            </div>
        </div>--%>
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
            <!--/.span-->
        </div>
        <!--/.row-fluid-->

        <!--/.page-content-->

        <!--/#ace-settings-container-->
         
    </div>
    

    <script type="text/javascript">
        //Open page
        $(document).ready(function () {

            //Load Data
            var oTable;
            var isAddNew = false;
            LoadData();
            //populateSelect(0);

            //Add Click
            $("#btnAdd").click(function () {
                onEdit(0); return false;
            });

            $('#cbfloor').change(function () {
               // populateSelectRoom();
                populateSelectRoomById();
            });


     

            $("#dialog-edit").hide();
          

        });


        //Call
        function LoadData() {
            var dataurl = 'WebService/WebService.asmx/LoadDesktopAll';
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
                                "sTitle": "Desktop No",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "desk_name"

                            },
                            {
                                "sTitle": "Room",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "room_name"

                            },
                            {
                                "sTitle": "Floor",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "floor_name"

                            },
                            {
                                "sTitle": "Officer Name",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "fullname"

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
                                            + '<a href="#"  class="Green"  title="Edit" onClick="onEdit(' + obj.aData.id + ');">'
                                            + '<span class="green"><i class="icon-pencil bigger-130"></i></span>'
                                            + '</a>'
                                            + '&nbsp;'
                                            + '<a href="#"  class="Red"  title="Delete" onclick="onConfirmDelete(' + obj.aData.id + ');"' + str + ' >'
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
                                            + '						<a href="#"   class="tooltip-success" data-rel="tooltip" title="Edit" onClick="onEdit(' + obj.aData.id + ');">'
                                            + '							<span class="green">'
                                            + '								<i class="icon-edit bigger-120"></i>'
                                            + '							</span>'
                                            + '						</a>'
                                            + '					</li>'
                                            + '					<li>'
                                            + '						<a href="#"  class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDelete(' + obj.aData.id + ');"' + str + ' >'
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
                { "sWidth": "15%", "aTargets": [2] },
                { "sWidth": "15%", "aTargets": [3] },
                { "sWidth": "20%", "aTargets": [4] },
                { "sWidth": "10%", "aTargets": [5] }
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
                url: "WebService/WebService.asmx/GetDesktopById",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = JSON.parse(data.d);

                    if (strvalue.length == 1) {
                        $("#txtDesktopNo").val(strvalue[0].desk_name);
                        $("#cbfloor").val(strvalue[0].ms_floor_id);
                        $("#cbroom").val(strvalue[0].ms_room_id);
                        $("#txtUserName").val(strvalue[0].label);
                        $("#txtUserId").val(strvalue[0].tb_officer_id);

                        populateSelect(strvalue[0].id);
                       // populateSelectRoomById();
                        if (strvalue[0].active_status == "Y") {
                            $("#ckbActive").prop("checked", true);
                        } else {
                            $("#ckbActive").prop("checked", false);
                        }
                    } else {
                        $("#txtDesktopNo").val("");
                        $("#txtUserName").val("");
                        $("#txtUserId").val("");
                        $("#ckbActive").prop("checked", true);
                        populateSelect(0);
                    }

                    populateAuto();
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

        function populateAuto() {
            $("#txtUserName").autocomplete({
                //source: data,
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "WebService/WebService.asmx/LoadUserByName",
                        data: "{ 'name': '" + request.term + "' }",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            $("#txtUserId").val('');
                            var jsonobject = JSON.parse(data.d);
                            response(jsonobject);
                        },
                        error: function (xhr, status, error) {
                            alert(xhr.responseText);
                        }
                    });
                },
                select: function (event, ui) {
                    $("#txtUserName").val(ui.item.label);
                    $("#txtUserId").val(ui.item.id);
                    return false;
                }
            });
        }
        //Save 
        function onSave(id) {
            var login_username = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();
            var desk_name = $('#txtDesktopNo').val();
            var ms_room_id = $('#cbroom').val();
            var tb_officer_id = $('#txtUserId').val();
            var active = $('input[name="ckbActive"]:checked').length;

            var param = "{'id':" + JSON.stringify(id)
                + ",'desk_name':" + JSON.stringify(desk_name)
                + ",'ms_room_id':" + JSON.stringify(ms_room_id)
                + ",'tb_officer_id':" + JSON.stringify(tb_officer_id)
                + ",'active':" + JSON.stringify(active)
                + ",'login_username':" + JSON.stringify(login_username) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/SaveDesktop",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onSuccess,
                error: onFailed
            });
        }

            //Populate Option 
        function populateSelect(desktop_id) {
           
                var strselect;
                var param = "{'desktop_id':" + JSON.stringify(desktop_id) + "}";

                $select = $("#cbfloor");
                $.ajax({
                    type: "POST",
                    url: 'WebService/WebService.asmx/LoadFloorByDesktop',
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

                var param = "{'desktop_id':" + JSON.stringify(desktop_id) + "}";
                $selectRoom = $("#cbroom");
                $.ajax({
                    type: "POST",
                    url: 'WebService/WebService.asmx/LoadRoomByDesktop',
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
                        else
                        {

                            $selectRoom.html('');
                            $selectRoom.append('<option value="">Choose a Room</option>');
                            $selectRoom.trigger("chosen:updated");//update select option
                        }

                        $selectRoom.chosen();
                   
                    }
                });

            }

      

            //Delete 
            function onDelete(id) {
                var param = "{'id':" + JSON.stringify(id) + "}";

                $.ajax({
                    type: "POST",
                    url: "WebService/WebService.asmx/DeleteDesktop",
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
                        onAlert("Desktop already exists.");
                        LoadData();
                    } else if (result.d == "DUPLICATEDESKNAME") {
                        onAlert("Desktop No already exists.");
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
                $("#lblvalid_DesktopNo").hide();
                $("#lblvalid_floor_id").hide();
                $("#lblvalid_room_id").hide();
                $("#lblvalid_owner").hide();
            }

            //Check Valid
            function onValid() {
                var isValid;
                isValid = true;
                var desktop_no = $('#txtDesktopNo').val();
                var floor = $('#cbfloor').val();
                var room = $('#cbroom').val();
                var owner = $('#txtUserId').val();
                if (desktop_no == '') {
                    $("#lblvalid_DesktopNo").show();
                    isValid = false;
                } else {
                    $("#lblvalid_DesktopNo").hide();
                }

                if (floor == '') {
                    $('#lblvalid_floor_id').show();
                    isValid = false;
                }else{
                    $('#lblvalid_floor_id').hide();
                }

                if (room == '') {
                    $("#lblvalid_room_id").show();
                    isValid = false;
                } else {
                    $("#lblvalid_room_id").hide();
                }

                if (owner == '') {
                    $("#lblvalid_owner").show();
                    isValid = false;
                } else {
                    $("#lblvalid_owner").hide();
                }


                return isValid;

            }

            function clearInput() {
                $("txtDesktopNo").val("");
                $("txtUserName").val("");
                $("txtUserId").val("");
                populateSelect(0);
                $("#ckbActive").prop("checked", false);
            }

        
    </script>
</asp:Content>


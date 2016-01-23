<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmLEDTV.aspx.vb" Inherits="frmLEDTV" %>

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
                <li class="active">LED TV</li>
            </ul>
          
            <!--#nav-search-->
        </div>

        <div class="page-content">

 
            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">LED TV</h3>

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
                    <label class="control-label" id="lblTVName">TV Name</label>
                </div>
                <div class="span9">
                    <input type="text" class="input-mini" id="txtTVName" style="width:435px;" maxlength="255" />
                   <span class="help-inline color red" id="lblvalid_TVName" style="display: none">This field is required</span>
                </div>

            </div>
        </div>
        <div class="row-fluid" >
            <div class="span12">
                <div class="span3">
                    <label class="control-label" id="lblFloor">Floor</label>
                </div>
                <div class="span3">
                    <select id="cbfloor"  style="width:150px">
                    </select>
                    <span class="help-inline color red" id="lblvalid_floor_id" style="display: none">Floor is required</span>
                </div>

                <div class="span2">
                    <label class="control-label" id="lblInstallPosition">Position</label>
                </div>
                <div class="span4">
                    <input type="text" class="input-mini" id="txtInstallPosition" style="width:150px;" maxlength="255"/>
                    <span class="help-inline color red" id="lblvalid_InstallPosition" style="display: none">This field is required</span>
                </div>

            </div>
        </div>
        <div class="row-fluid">
            <div class="span12">
                <div class="span3">
                    <label class="control-label" id="lblIPAddress">IP Address</label>
                </div>
                <div class="span3">
                    <input type="text" id="txtIPAddress" style="width: 150px"  ">
                    <span class="help-inline color red" id="lblvalid_ipaddress" style="display: none">This field is required</span>
                    <span class="help-inline color red" id="lblvalidIPAddressFormat" style="display: none">Invalid IP Address</span>
                </div>

                <div class="span2">
                    <label class="control-label" id="lblMacAddress">Mac Address</label>
                </div>
                <div class="span4">
                    <input type="text" id="txtMacAddress" style="width: 150px">
                    <span class="help-inline color red" id="lblvalid_macaddress" style="display: none">This field is required</span>
                </div>
            </div>
        </div>
         <div class="row-fluid" >
            <div class="span12">
                <div class="span3">
                    <label class="control-label" id="lblSignageContent">Signage Content</label>
                </div>
                <div class="span9">
                     <select  id="cbSignageContent"  style="width:450px;">
                    </select>
                   <span class="help-inline color red" id="lblvalid_SignageContent" style="display: none">This field is required</span>
                </div>

            </div>
        </div>
        <div class="space-4"></div>
        <div class="row-fluid">
            <div class="span12">
                <div class="span3">
                    <label class="control-label" id="lblDefaultTextScrolling">Default Text Scrolling</label>
                </div>
                <div class="span9">
                    <input type="text" class="input-mini" id="txtDefaultTextScrolling" style="width:435px;" maxlength="255"/>
                   <span class="help-inline color red" id="lblvalid_DefaultTextScrolling" style="display: none">This field is required</span> 
                </div>
            </div>
        </div>
        <div class="row-fluid">
            <div class="span12">
                 <div class="span3">
                    <label class="control-label" id="lblTextSpeed">Text Speed</label>
                </div>
                <div class="span5">
                   <%--<input type="text" id="txtTextSpeed" style="width: 140px" onkeypress="return Numbers(event)" maxlength="5">--%>
                   <select  id="cbTextSpeed"  style="width:250px;">
                      <option value="">Choose a Text Speed...</option>
                      <option value="3">Slow</option>
                      <option value="2">Mediem</option>
                      <option value="1">Fast</option>
                   </select> 
                    <span class="help-inline color red" id="lblvalid_TextSpeed" style="display: none">This field is required</span>
                </div>
                <div class="span4">
                    <%-- <label class="control-label" id="lblMin">Min</label>--%>
                </div>
            </div>
        </div>

        <div class="row-fluid">
            <div class="span3">
                <label class="control-label" id="lblActive">Active</label>
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
        <div class="row-fluid">
            <br />
                
            <br />
            <br />

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

        $("#cbTextSpeed").chosen();
</script>

 <script type="text/javascript">

        function populateSelect(ledtv_id) {

            var strselect;
            var param = "{'ledtv_id':" + JSON.stringify(ledtv_id) + "}";

            $select = $("#cbfloor");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadFloorByLEDTV',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $select.html('');
                    $select.append('<option value="">Choose a Floor...</option>');
                    $select.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $select.append('<option value="' + val.id + '" ' + strselect + '>' + val.floor_name + '</option>');
                            $select.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $select.html('');
                        $select.append('<option value="">Choose a Floor...</option>');
                        $select.trigger("chosen:updated");//update select option
                    }

                    $select.chosen();

                    
                }
            });

            var param = "{'ledtv_id':" + JSON.stringify(ledtv_id) + "}";
            $selectSignageContent = $("#cbSignageContent");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadSignageContentByLEDTV',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectSignageContent.html('');
                    $selectSignageContent.append('<option value="">Choose a Signage Content...</option>');
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectSignageContent.append('<option value="' + val.id + '" ' + strselect + '>' + val.template_name + '</option>');
                            $selectSignageContent.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectSignageContent.html('');
                        $selectSignageContent.append('<option value="">Choose a Signage Content...</option>');
                        $selectSignageContent.trigger("chosen:updated");//update select option
                    }

                    $selectSignageContent.chosen();
                  
                   
                }
            });

        }

        function populateSelectTextSpeed(text_speed) {
            var param = "{'text_speed':" + JSON.stringify(text_speed) + "}";
            $selectTextSpeed = $("#cbTextSpeed");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadTextSpeedLevel',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectTextSpeed.html('');
                    $selectTextSpeed.append('<option value="">Choose a Text Speed...</option>');
                    $selectTextSpeed.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectTextSpeed.append('<option value="' + val.id + '" ' + strselect + '>' + val.name + '</option>');
                            $selectTextSpeed.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectTextSpeed.html('');
                        $selectTextSpeed.append('<option value="">Choose a Text Speed...</option>');
                        $selectTextSpeed.trigger("chosen:updated");//update select option
                    }

                    $selectTextSpeed.chosen();
                }
            });

        }

        function LoadData() {
            var dataurl = 'WebService/WebService.asmx/LoadLEDTVAll';
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
                                "sTitle": "TV Name",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "tv_name"

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
                                "sTitle": "IP Address",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "ip_address"

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
                                            + '						<a href="#"  class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDelete(' + obj.aData.id + ');"' + str + '  return false;>'
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
                { "sWidth": "10%", "aTargets": [3] },
                { "sWidth": "10%", "aTargets": [4] }
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
                url: "WebService/WebService.asmx/LoadLEDTVID",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = JSON.parse(data.d);

                    if (strvalue.length == 1) {
                        $("#txtTVName").val(strvalue[0].tv_name);
                        $("#txtInstallPosition").val(strvalue[0].install_position);
                        $("#cbfloor").val(strvalue[0].ms_floor_id);
                        $("#txtIPAddress").val(strvalue[0].ip_address);
                        $("#txtMacAddress").val(strvalue[0].mac_address);
                        $("#cbSignageContent").val(strvalue[0].ms_signage_template_id_default);
                        $("#txtDefaultTextScrolling").val(strvalue[0].default_text_scrolling);
                        //$("#cbTextSpeed").val(strvalue[0].text_scrolling_speed);

                        populateSelect(strvalue[0].id);
                        populateSelectTextSpeed(strvalue[0].text_scrolling_speed);
                        if (strvalue[0].active_status == "Y") {
                            $("#ckbActive").prop("checked", true);
                        } else {
                            $("#ckbActive").prop("checked", false);
                        }
                    } else {

                        $("#txtTVName").val("");
                        $("#txtInstallPosition").val("");
                        $("#txtIPAddress").val("");
                        $("#txtDefaultTextScrolling").val("");
                        $("#cbTextSpeed").val("");
                        populateSelect(0);
                        populateSelectTextSpeed(0);
                        $("#ckbActive").prop("checked", true);
                    }
                }
            });



            $("#dialog-edit").dialog({
                autoOpen: false,
                resizable: false,
                width: "700px",
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
            var tv_name =  $("#txtTVName").val();
            var install_position = $("#txtInstallPosition").val();
            var ms_floor_id = $("#cbfloor").val();
            var ip_address = $("#txtIPAddress").val();
            var mac_address = $("#txtMacAddress").val();
            var ms_signage_template_id_default = $("#cbSignageContent").val();
            var default_text_scrolling = $("#txtDefaultTextScrolling").val();
            var text_scrolling_speed = $("#cbTextSpeed").val();
            var active = $('input[name="ckbActive"]:checked').length;

            var param = "{'id':" + JSON.stringify(id)
                + ",'tv_name':" + JSON.stringify(tv_name)
                + ",'install_position':" + JSON.stringify(install_position)
                + ",'ms_floor_id':" + JSON.stringify(ms_floor_id)
                + ",'ip_address':" + JSON.stringify(ip_address)
                + ",'mac_address':" + JSON.stringify(mac_address)
                + ",'ms_signage_template_id_default':" + JSON.stringify(ms_signage_template_id_default)
                + ",'default_text_scrolling':" + JSON.stringify(default_text_scrolling)
                + ",'text_scrolling_speed':" + JSON.stringify(text_scrolling_speed)
                + ",'active':" + JSON.stringify(active)
                + ",'login_username':" + JSON.stringify(login_username) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/SaveLEDTV",
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
                url: "WebService/WebService.asmx/DeleteLEDTV",
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
                if (result.d == "DUPLICATELEDTVNAME") {
                    onAlert("TV Name already exists.");
                    LoadData();
                } else if (result.d == "DUPLICATELEDIPADDRESS") {
                    onAlert("IP Address already exists.")
                    LoadData();
                } else if (result.d == "DUPLICATELEDMACADDRESS") {
                    onAlert("Mac Address already exists.")
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
            $("#lblvalid_TVName").hide();
            $("#lblvalid_InstallPosition").hide();
            $("#lblvalid_floor_id").hide();
            $("#lblvalid_ipaddress").hide();
            $("#lblvalid_macaddress").hide();
            $("#lblvalid_SignageContent").hide();
            $("#lblvalid_DefaultTextScrolling").hide();
            $("#lblvalid_TextSpeed").hide();
            $("#lblvalidIPAddressFormat").hide();
            
        }

        //Check Valid
        function onValid() {
            var isValid;
            isValid = true;
            var tv_name = $("#txtTVName").val();
            var install_position = $("#txtInstallPosition").val();
            var ms_floor_id = $("#cbfloor").val();
            var ip_address = $("#txtIPAddress").val();
            var mac_address = $("#txtMacAddress").val();
            var ms_signage_template_id_default = $("#cbSignageContent").val();
            var default_text_scrolling = $("#txtDefaultTextScrolling").val();
            var text_scrolling_speed = $("#cbTextSpeed").val();

            if (tv_name == '') {
                $("#lblvalid_TVName").show();
                isValid = false;
                //return;
            } else {
                $("#lblvalid_TVName").hide();
            }

            if (ms_floor_id == '') {
                $("#lblvalid_floor_id").show();
                isValid = false;
                //return;
            } else {
                $("#lblvalid_floor_id").hide();
            }

            if (install_position == '') {
                $("#lblvalid_InstallPosition").show();
                isValid = false;
                //return;
            } else {
                $("#lblvalid_InstallPosition").hide();
            }

            if (ip_address == '') {
                $("#lblvalid_ipaddress").show();
                isValid = false;
                //return;
            } else {
                $("#lblvalid_ipaddress").hide();
            }

            if (mac_address == '') {
                $("#lblvalid_macaddress").show();
                isValid = false;
                //return;
            } else {
                $("#lblvalid_macaddress").hide();
            }

            $("#lblvalidIPAddressFormat").hide();
            if (ip_address != '') {
                if (/^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/.test(ip_address)) {

                }
                else {
                    $("#lblvalidIPAddressFormat").show();
                    isValid = false;
                    //return;
                }
            }


            if (ms_signage_template_id_default == '') {
                $("#lblvalid_SignageContent").show();
                isValid = false;
                //return;
            } else {
                $("#lblvalid_SignageContent").hide();
            }

            if ( default_text_scrolling == '') {
                $("#lblvalid_DefaultTextScrolling").show();
                isValid = false;
                //return;
            } else {
                $("#lblvalid_DefaultTextScrolling").hide();
            }

            if ( text_scrolling_speed == '') {
                $("#lblvalid_TextSpeed").show();
                isValid = false;
                //return;
            } else {
                $("#lblvalid_TextSpeed").hide();
            }

          

            return isValid;

        }

        function clearInput() {
            $("#txtTVName").val("");
            $("#txtInstallPosition").val("");
            $("#txtIPAddress").val("");
            $("#txtDefaultTextScrolling").val("");
            $("#cbTextSpeed").val("");
            populateSelect(0);
            populateSelectTextSpeed(0);
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


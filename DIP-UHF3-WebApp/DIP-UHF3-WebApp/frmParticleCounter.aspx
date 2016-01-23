<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmParticleCounter.aspx.vb" Inherits="frmParticleCounter" %>

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
                <li class="active">Particle Counter</li>
            </ul>

        </div>

        <div class="page-content">


            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">Particle Counter</h3>

                    <div class="row-fluid">
                        <div class="span12" id="divbtnAdd">
                            <button class="btn btn-small btn-success" id="btnAdd" name="btnAdd">
                                <i class=" icon-plus"></i>
                                Add New
                            </button>
                            <button class="btn btn-small" id="btnBack" name="btnBack">
                                <i class=" icon-undo"></i>
                                Back
                            </button>    

                        </div>
                    </div>
                    <div class="space-2"></div>
                    <br />
                    <div id="dialog-grid">

                         <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblRoom_ctr">Room</label>
                                </div>
                                <div class="span4">
                                    <select  id="cbroom_ctr" data-placeholder="Choose a Room..." style="width:200px"> </select>
                                </div>
                                <div class="span2">
                                    
                                </div>
                                <div class="span4">
                                    
                                </div>
                            </div>
                        </div>
                         <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblDevice_ctr">Device</label>
                                </div>
                                <div class="span4">
                                    <select  id="cbdevice_ctr" data-placeholder="Choose a Device..." style="width:200px"> </select>
                                </div>
                                <div class="span2">
                                    
                                </div>
                                <div class="span4">
                                    
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblimportdate_ctr">Import Date</label>
                                </div>
                                <div class="span4" >
                                     <input class="date-picker width-55" id="txtDateFrom" type="text" data-date-format="dd/mm/yyyy" />
                                    <span class="add-on">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                             <%--    <div class="span1" style="margin:0px">
                                     <label class="control-label" id="lblEnd">End</label>
                                </div>--%>
                                <div class="span4" style="margin:0px">
                                     <span class="help-inline">To</span>
                                     <input class="date-picker width-55" id="txtDateEnd" type="text" data-date-format="dd/mm/yyyy" />
                                    <span class="add-on">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                                 <div class="span2">
                                    
                                </div>
                            </div>
                        </div>  

                        <div class="space-4"></div>
                        <div class="row-fluid">
                            <div class="span4">
                            </div>
                            <div class="span8">
                                <button class="btn btn-primary" id="btnSearch" name="btnSearch">
                                    <i class="icon-search  bigger-110"></i>
                                    Search
                                </button>
                                <button class="btn" type="reset" id="btnClear_ctr" name="btnClear_ctr">
                                    <i class="icon-undo bigger-110"></i>
                                    Clear
                                </button>
                            </div>
                        </div>
                         <div class="space-4"></div>

                        <div class="row-fluid">
                            <div class="span12">
                                <table class="table table-striped table-bordered table-hover" id="dt_out"></table>
                            </div>
                        </div>
                    </div>




                    <div id="dialog-edit">
                       <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblRoom">Room</label>
                                </div>
                                <div class="span10">
                                    <select  id="cbroom" data-placeholder="Choose a Room..." style="width:260px"> </select>
                                    <span class="help-inline color red" id="lblvalidRoom" style="display: none">This field is required</span>
                                </div>

                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblDevice">Device</label>
                                </div>
                                <div class="span10">
                                     <select  id="cbdevice" data-placeholder="Choose a Device..." style="width:260px"> </select>
                                    <span class="help-inline color red" id="lblvalidDevice" style="display: none">This field is required</span>
                                </div>
                            </div>
                        </div>
                      
                        <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblPatentType">Data File</label>
                                </div>
                                <div class="span3">
                                    <div id="base" style="display: none"></div>
                                   <input type="text" class="input-mini" id="txtfilename" style="width: 250px;" maxlength="20" readonly="true"/>
                                </div>
                                <div class="span3">
                                    <span class="btn btn-default btn-mini btn-file">Choose&hellip; 
                                        <input type="file" id="inputfile" class="ace-file-input" />
                                    </span>
                                </div>
                               <div class="span4">
                               </div>

                            </div>
                        </div>
                                           
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblCounterMode">Counter Mode</label>
                                </div>
                                <div class="span10">
                                    <input type="text" class="input-mini" id="txtCounterMode" style="width: 250px;" maxlength="1000" readonly="true" />
                                    <span class="help-inline color red" id="lblvalidCounterMode" style="display: none">This field is required</span>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lbl03mu">0.3mu</label>
                                </div>
                                <div class="span2">
                                    <%-- <span class="help-inline">0.3mu</span>--%>
                                    <input type="text" id="txt03mu" style="width: 150px" onkeypress="return Numbers(event)" readonly="true">
                                    <span class="help-inline color red" id="lblvalid03mu" style="display: none">This field is required</span>
                                </div>
                                <div class="span1" >
                                    <label class="control-label" id="lbl05mu">0.5mu</label>
                                </div>
                                <div class="span2"  style="margin:0px">
                                    <%-- <span class="help-inline">0.5mu</span>--%>
                                    <input type="text" id="txt05mu" style="width: 150px" onkeypress="return Numbers(event)" readonly="true" >
                                    <span class="help-inline color red" id="lblvalid05mu" style="display: none">This field is required</span>
                                </div>
                                <div class="span1"  >
                                    <label class="control-label" id="lbl10mu">1.0mu</label>
                                </div>
                                <div class="span2"  style="margin:0px">
                                    <%-- <span class="help-inline">1.0mu</span>--%>
                                    <input type="text" id="txt10mu" style="width: 150px" onkeypress="return Numbers(event)"  readonly="true">
                                    <span class="help-inline color red" id="lblvalid10mu" style="display: none">This field is required</span>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lbl25mu">2.5mu</label>
                                </div>
                                <div class="span2">
                                    <%-- <span class="help-inline">0.3mu</span>--%>
                                    <input type="text" id="txt25mu" style="width: 150px" onkeypress="return Numbers(event)"  readonly="true">
                                    <span class="help-inline color red" id="lblvalid25mu" style="display: none">This field is required</span>
                                </div>
                                <div class="span1" >
                                    <label class="control-label" id="lbl50mu">5.0mu</label>
                                </div>
                                <div class="span2"  style="margin:0px">
                                    <%-- <span class="help-inline">0.5mu</span>--%>
                                    <input type="text" id="txt50mu" style="width: 150px" onkeypress="return Numbers(event)"  readonly="true">
                                    <span class="help-inline color red" id="lblvalid50mu" style="display: none">This field is required</span>
                                </div>
                                <div class="span1"  >
                                    <label class="control-label" id="lbl100mu">10mu</label>
                                </div>
                                <div class="span2"  style="margin:0px">
                                    <%-- <span class="help-inline">1.0mu</span>--%>
                                    <input type="text" id="txt100mu" style="width: 150px" onkeypress="return Numbers(event)"  readonly="true">
                                    <span class="help-inline color red" id="lblvalid100mu" style="display: none">This field is required</span>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblAT">AT</label>
                                </div>
                                <div class="span2">
                                    <input type="text" id="txtAT" style="width: 150px" onkeypress="return Numbers(event)" readonly="true">
                                    <span class="help-inline color red" id="lblvalidAT" style="display: none">This field is required</span>
                                </div>
                                <div class="span1" >
                                    <label class="control-label" id="lblRH">RH</label>
                                </div>
                                <div class="span2"  style="margin:0px">
                                    <input type="text" id="txtRH" style="width: 150px" onkeypress="return Numbers(event)" readonly="true">
                                    <span class="help-inline color red" id="lblvalidRH" style="display: none">This field is required</span>
                                </div>
                                <div class="span1"  >
                                   
                                </div>
                                <div class="span2"  style="margin:0px">
                                   
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblDP">DP</label>
                                </div>
                                <div class="span2">
                                    <input type="text" id="txtDP" style="width: 150px" onkeypress="return Numbers(event)" readonly="true">
                                    <span class="help-inline color red" id="lblvalidDP" style="display: none">This field is required</span>
                                </div>
                                <div class="span1" >
                                    <label class="control-label" id="lblWB">WB</label>
                                </div>
                                <div class="span2"  style="margin:0px">
                                    <input type="text" id="txtWB" style="width: 150px" onkeypress="return Numbers(event)" readonly="true">
                                    <span class="help-inline color red" id="lblvalidWB" style="display: none">This field is required</span>
                                </div>
                                <div class="span1"  >
                                   
                                </div>
                                <div class="span2"  style="margin:0px">
                                   
                                </div>
                            </div>
                        </div>


                        <div class="space-4"></div>
                        <div class="row-fluid">
                            <div class="span4">
                            </div>
                            <div class="span8">
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
            </div>

        </div>
    </div>

   

<script type="text/javascript">
    //Open page
    $(document).ready(function () {
        var oTable;
        var isAddNew = false;

        populateSelect_ctr();
        populateSelectDeviceById_ctr();
        LoadData();

        //Add Click
        $("#btnAdd").click(function () {
            onEdit(0);
            clickEdit();
        });

        $("#btnBack").click(function () {
            onEdit(0);
            clickEndEdit();
        });

        $("#btnSave").click(function () {
            var ret = onValid();
            if (ret == true) {
                onSave();
            }
        });

        $("#btnClear").click(function () {
            clearInput();
        });

        $("#btnClear_ctr").click(function () {
            clearInput_Ctr();
        });

        $("#btnSearch").click(function () {
            LoadData();
        });

        $("#inputfile").change(function () {
            readFile(this);
        });

        $("#inputfile").click(function () {
            this.value = null;
        });

        $('#cbroom').change(function () {
            populateSelectDeviceById();
        });

        $('#cbroom_ctr').change(function () {
            populateSelectDeviceById_ctr();
        });

        //ปฎิธิน
        $('.date-picker').datepicker({ "autoclose": true }).next().on(ace.click_event, function () {
            $(this).prev().focus();
        });

        //Hide div or other
        $("#dialog-edit").hide();
        $("#btnBack").hide();

    });
</script>

<%--File--%>
<script type="text/javascript">
    function readFile(input) {
        if (input.files && input.files[0]) {
            var FR = new FileReader();
            FR.onload = function (e) {
                var binaryString = [];
                var file = input.files[0];
                var fileName = file.name;
                var fileExt = fileName.split('.').pop().toLowerCase();

                var filesize = file.size;

                if ($.inArray(fileExt, ['txt', 'TXT']) == -1) {
                    onAlert("Please input file type txt");
                } else if ((filesize / 1024) > 1000) { //1Mb
                    onAlert("Please input file size less than 1MB");
                } else {
                    binaryString = e.target.result;
                    binaryString = binaryString.split(',');
                    $("#base").text(binaryString[1]);
                    $('#txtfilename').val(fileName);
                    // $('#txtfilepath').val($('input[type=file]').val());
                   
                    UploadFile();
                }

            };
            FR.readAsDataURL(input.files[0]);
        }
    }

    function UploadFile() {
        var strfilebase64 = $("#base").text();
        var param = "{'strfilebase64':" + JSON.stringify(strfilebase64) + ",'filename':'particlefile.txt'}";
        $.ajax({
            type: "POST",
            url: "WebService/WebService.asmx/UpLoadFile",
            data: param,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                GetDataFromFile();
            },
            error: function () {
                alert('upload error!');
            }
        });

        function GetDataFromFile() {
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadDataFromParticleFile",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = JSON.parse(data.d);

                    if (strvalue.length == 1) {
                        $("#txtCounterMode").val(strvalue[0].CounterMode);
                        $("#txt03mu").val(strvalue[0].c03mu);
                        $("#txt05mu").val(strvalue[0].c05mu);
                        $("#txt10mu").val(strvalue[0].c10mu);
                        $("#txt25mu").val(strvalue[0].c25mu);
                        $("#txt50mu").val(strvalue[0].c50mu);
                        $("#txt100mu").val(strvalue[0].c100mu);
                        $("#txtAT").val(strvalue[0].AT);
                        $("#txtRH").val(strvalue[0].RH);
                        $("#txtDP").val(strvalue[0].DP);
                        $("#txtWB").val(strvalue[0].WB);
                      
                    } else {
                        clearInput();
                    }

                },
                error: function () {
                    //alert('get data error!');
                    clearInput();
                }
            });
        }


    }

  
</script>


<script type="text/javascript">

    function LoadData() {
        var room = $('#cbroom_ctr').val();
        var datefrom = $('#txtDateFrom').val();
        var dateto = $('#txtDateEnd').val();
        var device = $('#cbdevice_ctr').val();
       
        //if ((datefrom != '') || (dateto != '')) {
        //    if ((datefrom == '')) {
        //        onAlert("Please specify date from.");
        //        return;
        //    }
        //    else if ((dateto == '')) {
        //        onAlert("Please specify date to.");
        //        return;
        //    }
        //}

        var param = "{'room':" + JSON.stringify(room)
                    + ",'datefrom':" + JSON.stringify(datefrom)
                    + ",'dateto':" + JSON.stringify(dateto)
                    + ",'device':" + JSON.stringify(device) + "}";

        var dataurl = 'WebService/WebService.asmx/LoadParticleHistory';
        $.ajax({
            "type": "POST",
            "dataType": 'json',
            "contentType": "application/json; charset=utf-8",
            "url": dataurl,
            "success": PopulateGrid,
            "data": param,
            "error": function () {
               // alert('load data error!');
            }
        });
    }

    //Populate Grid
    function PopulateGrid(jsondata) {
        var jsonobject = JSON.parse(jsondata.d);
        var columns = [
                        {
                            "sTitle": "No",
                            "sType": "numeric",
                            "mDataProp": "no",
                            "bSortable": false,
                            "bUseRendered": false

                        },

                        {
                            "sTitle": "Room",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "room_name"

                        },
                        {
                            "sTitle": "Device",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "serial_no"

                        },
                       {
                           "sTitle": "Import Date",
                           "sType": "string",
                           "sDefaultContent": "",
                           "mDataProp": "import_time"

                       },
                        {
                            "sTitle": "Counter Mode",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "counter_mode"
                        },
                        {
                            "sTitle": "0.3mu",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "channel_0_3"
                        },
                        {
                            "sTitle": "0.5mu",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "channel_0_5"
                        },
                        {
                            "sTitle": "1.0mu",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "channel_1_0"
                        },
                        {
                            "sTitle": "2.5mu",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "channel_2_5"
                        },
                        {
                            "sTitle": "5.0mu",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "channel_5_0"
                        }
                        ,
                        {
                            "sTitle": "1.0mu",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "channel_10_0"
                        },
                        {
                            "sTitle": "AT",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "air_temperature"
                        },
                        {
                            "sTitle": "RH",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "relative_humidity"
                        },
                        {
                            "sTitle": "DP",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "dewpoint_temperature"
                        },
                        {
                            "sTitle": "WB",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "wet_bulb_temperature"
                        }
        ];

        oTable = $('#dt_out').dataTable({
            "aaData": jsonobject,
            "bAutoWidth": false,
            "iDisplayLength": 100,
            "aoColumnDefs": [
            { "sWidth": "5%", "aTargets": [0] },
            { "sWidth": "13%", "aTargets": [1] },
            { "sWidth": "7%", "aTargets": [2] },
            { "sWidth": "9%", "aTargets": [3] },
            { "sWidth": "10%", "aTargets": [4] },
            { "sWidth": "6%", "aTargets": [5] },
            { "sWidth": "6%", "aTargets": [6] },
            { "sWidth": "6%", "aTargets": [7] },
            { "sWidth": "6%", "aTargets": [8] },
            { "sWidth": "6%", "aTargets": [9] },
            { "sWidth": "6%", "aTargets": [10] },
            { "sWidth": "5%", "aTargets": [11] },
            { "sWidth": "5%", "aTargets": [12] },
            { "sWidth": "5%", "aTargets": [13] },
            { "sWidth": "5%", "aTargets": [14] }

            ],
            "aoColumns": columns,
            "bDestroy": true,
        });


    }

    //Add or Edit 
    function clickEdit() {
        $("#btnAdd").hide();
        $("#btnBack").show();
        $("#dialog-grid").hide();
        $("#dialog-edit").show();
    }


    function clickEndEdit() {
        $("#btnAdd").show();
        $("#btnBack").hide();
        $("#dialog-grid").show();
        $("#dialog-edit").hide();
    }


    function onEdit(id) {
        clearInput();
        onValidHide();
    }

    //Save 
    function onSave() {
        var login_username = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();
        var deviceid = $("#cbdevice").val();
        var strfilebase64 = $("#base").text();
        var fileName = $('#txtfilename').val();
        var counter_mode = $('#txtCounterMode').val();
        var channel_0_3 = $('#txt03mu').val();
        var channel_0_5 = $('#txt05mu').val();
        var channel_1_0 = $('#txt10mu').val();
        var channel_2_5 = $('#txt25mu').val();
        var channel_5_0 = $('#txt50mu').val();
        var channel_10_0 = $('#txt100mu').val();
        var at = $('#txtAT').val();
        var rh = $('#txtRH').val();
        var dp = $('#txtDP').val();
        var wb = $('#txtWB').val();

        var param = "{'ms_particle_counter_device_id':" + JSON.stringify(deviceid)
            + ",'counter_mode':" + JSON.stringify(counter_mode)
            + ",'channel_0_3':" + JSON.stringify(channel_0_3)
            + ",'channel_0_5':" + JSON.stringify(channel_0_5)
            + ",'channel_1_0':" + JSON.stringify(channel_1_0)
            + ",'channel_2_5':" + JSON.stringify(channel_2_5)
            + ",'channel_5_0':" + JSON.stringify(channel_5_0)
            + ",'channel_10_0':" + JSON.stringify(channel_10_0)
            + ",'at':" + JSON.stringify(at)
            + ",'rh':" + JSON.stringify(rh)
            + ",'dp':" + JSON.stringify(dp)
            + ",'wb':" + JSON.stringify(wb)
            + ",'filename':" + JSON.stringify(fileName)
            + ",'strfilebase64':" + JSON.stringify(strfilebase64)
            + ",'login_username':" + JSON.stringify(login_username) + "}";

        $.ajax({
            type: "POST",
            url: "WebService/WebService.asmx/SavePaticle",
            data: param,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onSuccess,
            error: onFailed
        });
    }

    function populateSelect_ctr() {
        var strselect;
        $selectRoom_ctr = $("#cbroom_ctr");
        $.ajax({
            type: "POST",
            url: 'WebService/WebService.asmx/LoadRoomActive',
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonobject = JSON.parse(data.d);
                //clear 
                $selectRoom_ctr.html('');
                $selectRoom_ctr.append('<option value="">All</option>');
                //append a select option
                if (jsonobject.length > 0) {
                    $.each(jsonobject, function (key, val) {

                        $selectRoom_ctr.append('<option value="' + val.id + '">' + val.room_name + '</option>');
                        $selectRoom_ctr.trigger("chosen:updated");//update select option
                    })
                }
                else {

                    $selectRoom_ctr.html('');
                    $selectRoom_ctr.append('<option value="">All</option>');
                    $selectRoom_ctr.trigger("chosen:updated");//update select option
                }

                $selectRoom_ctr.chosen();
            }
        });

       
    }

    function populateSelect() {
        var strselect;

        $selectRoom = $("#cbroom");
        $.ajax({
            type: "POST",
            url: 'WebService/WebService.asmx/LoadRoomActive',
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

    function populateSelectDeviceById() {
        var param = "{'ms_room_id':" + JSON.stringify($("#cbroom").val()) + "}";
        $selectDevice = $("#cbdevice");
        $.ajax({
            type: "POST",
            url: 'WebService/WebService.asmx/LoadDeviceByMsParticle',
            data: param,
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonobject = JSON.parse(data.d);
                //clear 
                $selectDevice.html('');
                $selectDevice.append('<option value="">Choose a Device</option>');
                //append a select option

                if (jsonobject.length > 0) {
                    $.each(jsonobject, function (key, val) {
                        $selectDevice.append('<option value="' + val.id + '">' + val.serial_no + '</option>');
                        $selectDevice.trigger("chosen:updated");//update select option
                    })
                }
                else {

                    $selectDevice.html('');
                    $selectDevice.append('<option value="">Choose a Device</option>');
                    $selectDevice.trigger("chosen:updated");//update select option
                }

                $selectDevice.chosen();

            }
        });


    }

    function populateSelectDeviceById_ctr() {
        var param = "{'ms_room_id':" + JSON.stringify($("#cbroom_ctr").val()) + "}";
        $selectDevice = $("#cbdevice_ctr");
        $.ajax({
            type: "POST",
            url: 'WebService/WebService.asmx/LoadDeviceByMsParticle',
            data: param,
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonobject = JSON.parse(data.d);
                //clear 
                $selectDevice.html('');
                $selectDevice.append('<option value="">All</option>');
                //append a select option

                if (jsonobject.length > 0) {
                    $.each(jsonobject, function (key, val) {

                        $selectDevice.append('<option value="' + val.id + '">' + val.serial_no + '</option>');
                        $selectDevice.trigger("chosen:updated");//update select option
                    })
                }
                else {

                    $selectDevice.html('');
                    $selectDevice.append('<option value="">All</option>');
                    $selectDevice.trigger("chosen:updated");//update select option
                }

                $selectDevice.chosen();

            }
        });


    }

    //Room  Alert  True
    function onSuccess(result) {
        if (result.d == "YES") {
            onAlert("Save Complete");
            LoadData();
            clearInput();
            clickEndEdit();
        } else {
            if (result.d == "NOTFOUNDTEMPFILE") {
                onAlert("file not found.");
                LoadData();
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
        $("#lblvalidCounterMode").hide();
        $("#lblvalidRoom").hide();
        $("#lblvalidDevice").hide();
        //$("#lblvalid03mu").hide();
        //$("#lblvalid05mu").hide();
        //$("#lblvalid10mu").hide();
        //$("#lblvalid25mu").hide();
        //$("#lblvalid50mu").hide();
        //$("#lblvalid100mu").hide();
        //$("#lblvalidAT").hide();
        //$("#lblvalidRH").hide();
        //$("#lblvalidDP").hide();
        //$("#lblvalidWB").hide();     
    }

    //Check Valid
    function onValid() {
        var isValid;
        isValid = true;
        var CounterMode = $("#txtCounterMode").val();
        var room = $("#cbroom").val();
        var device = $("#cbdevice").val();
        //var c03mu = $("#txt03mu").val();
        //var c05mu = $("#txt05mu").val();
        //var c10mu = $("#txt10mu").val();
        //var c25mu = $("#txt25mu").val();
        //var c50mu = $("#txt50mu").val();
        //var c100mu = $("#txt100mu").val();
        //var at = $("#txtAT").val();
        //var rh = $("#txtRH").val();
        //var dp = $("#txtDP").val();
        //var wb = $("#txtWB").val();          
      
        if (CounterMode == '') {
            $("#lblvalidCounterMode").show();
            isValid = false;
        } else {
            $("#lblvalidCounterMode").hide();
        }
        if (room == '') {
            $("#lblvalidRoom").show();
            isValid = false;
        } else {
            $("#lblvalidRoom").hide();
        }
        if (device == '') {
            $("#lblvalidDevice").show();
            isValid = false;
        } else {
            $("#lblvalidDevice").hide();
        }
        //if (c03mu == '') {
        //    $("#lblvalid03mu").show();
        //    isValid = false;
        //} else {
        //    $("#lblvalid03mu").hide();
        //}
        //if (c05mu == '') {
        //    $("#lblvalid05mu").show();
        //    isValid = false;
        //} else {
        //    $("#lblvalid05mu").hide();
        //}
        //if (c10mu == '') {
        //    $("#lblvalid10mu").show();
        //    isValid = false;
        //} else {
        //    $("#lblvalid10mu").hide();
        //}
        //if (c25mu == '') {
        //    $("#lblvalid25mu").show();
        //    isValid = false;
        //} else {
        //    $("#lblvalid25mu").hide();
        //}
        //if (c50mu == '') {
        //    $("#lblvalid50mu").show();
        //    isValid = false;
        //} else {
        //    $("#lblvalid50mu").hide();
        //}
        //if (c100mu == '') {
        //    $("#lblvalid100mu").show();
        //    isValid = false;
        //} else {
        //    $("#lblvalid100mu").hide();
        //}
        //if (at == '') {
        //    $("#lblvalidAT").show();
        //    isValid = false;
        //} else {
        //    $("#lblvalidAT").hide();
        //}
        //if (rh == '') {
        //    $("#lblvalidRH").show();
        //    isValid = false;
        //} else {
        //    $("#lblvalidRH").hide();
        //}
        //if (dp == '') {
        //    $("#lblvalidDP").show();
        //    isValid = false;
        //} else {
        //    $("#lblvalidDP").hide();
        //}
        //if (wb == '') {
        //    $("#lblvalidWB").show();
        //    isValid = false;
        //} else {
        //    $("#lblvalidWB").hide();
        //}
        
        return isValid;
    }

    function clearInput() {
        $("#txtfilename").val("");
        $("#txtCounterMode").val("");
        $("#txt03mu").val("");
        $("#txt05mu").val("");
        $("#txt10mu").val("");
        $("#txt25mu").val("");
        $("#txt50mu").val("");
        $("#txt100mu").val("");
        $("#txtAT").val("");
        $("#txtRH").val("");
        $("#txtDP").val("");
        $("#txtWB").val("");
        populateSelect();
        populateSelectDeviceById();
    }

    function clearInput_Ctr() {
        $("#txtDateFrom").val("");
        $("#txtDateEnd").val("");
       
        populateSelect_ctr();
        populateSelectDeviceById_ctr();
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

